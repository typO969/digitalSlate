Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Threading
Imports NAudio.Wave

Public Class LtcAudioOutputService
	Implements IDisposable

	Private Const DefaultSampleRate As Integer = 48000
	Private Const Channels As Integer = 2

	Private ReadOnly _lockObj As New Object()
	Private _waveOut As NAudio.Wave.WaveOutEvent
	Private _provider As NAudio.Wave.BufferedWaveProvider
	Private _thread As Thread
	Private _stopRequested As Boolean

	Private _fpsMode As LtcFpsMode
	Private _tc As LtcTimecode
	Private _samplesPerBit As Integer
	Private _amplitude As Single = 0.25F
	Private _muted As Boolean = True

	Public Property Muted As Boolean
		Get
			SyncLock _lockObj
				Return _muted
			End SyncLock
		End Get
		Set(value As Boolean)
			SyncLock _lockObj
				_muted = value
			End SyncLock
		End Set
	End Property

	Public ReadOnly Property IsRunning As Boolean
		Get
			SyncLock _lockObj
				Return _waveOut IsNot Nothing
			End SyncLock
		End Get
	End Property

	Public Shared Function GetOutputDevices() As List(Of Tuple(Of Integer, String))
		Dim devices As New List(Of Tuple(Of Integer, String))()
		For i As Integer = 0 To NAudio.Wave.WaveOut.DeviceCount - 1
			Dim caps = NAudio.Wave.WaveOut.GetCapabilities(i)
			devices.Add(New Tuple(Of Integer, String)(i, caps.ProductName))
		Next
		Return devices
	End Function

	Public Sub Start(deviceId As Integer, fpsMode As LtcFpsMode)
		SyncLock _lockObj
			If _waveOut IsNot Nothing Then Return

			_fpsMode = fpsMode
			_tc = LtcTimecode.FromDateTime(Date.Now, fpsMode)

			_provider = New NAudio.Wave.BufferedWaveProvider(New NAudio.Wave.WaveFormat(DefaultSampleRate, 16, Channels))
			_provider.BufferDuration = TimeSpan.FromSeconds(2)
			_provider.DiscardOnBufferOverflow = True

			_waveOut = New NAudio.Wave.WaveOutEvent()
			_waveOut.DeviceNumber = deviceId
			_waveOut.DesiredLatency = 100
			_waveOut.Init(_provider)
			_waveOut.Play()

			_stopRequested = False
			_thread = New Thread(AddressOf ProducerLoop)
			_thread.IsBackground = True
			_thread.Name = "LTC Producer"

			' LTC nominal bitrate is 80 bits per frame.
			Dim fps = fpsMode.ToFps()
			Dim bitsPerSecond = 80.0 * fps
			_samplesPerBit = CInt(Math.Round(DefaultSampleRate / bitsPerSecond))
			If _samplesPerBit < 2 Then _samplesPerBit = 2

			_thread.Start()
		End SyncLock
	End Sub

	Public Sub SetMuted(value As Boolean)
		Muted = value
	End Sub

	Public Sub [Stop]()
		Dim wo As NAudio.Wave.WaveOutEvent = Nothing
		Dim t As Thread = Nothing

		SyncLock _lockObj
			If _waveOut Is Nothing Then Return
			_stopRequested = True
			wo = _waveOut
			t = _thread
			_waveOut = Nothing
			_thread = Nothing
			_provider = Nothing
		End SyncLock

		Try
			If t IsNot Nothing AndAlso t.IsAlive Then t.Join(500)
		Catch
		End Try

		Try
			wo.Stop()
		Catch
		End Try

		Try
			wo.Dispose()
		Catch
		End Try
	End Sub

	Private Sub ProducerLoop()
		Dim localProvider As NAudio.Wave.BufferedWaveProvider
		SyncLock _lockObj
			localProvider = _provider
		End SyncLock

		If localProvider Is Nothing Then Return

		Dim bytesPerSampleFrame As Integer = 2 * Channels
		Dim targetBufferedMs As Integer = 300

		Do
			If _stopRequested Then Exit Do

			Dim bufferedMs As Integer = CInt((localProvider.BufferedBytes / CDbl(bytesPerSampleFrame)) / DefaultSampleRate * 1000.0)
			If bufferedMs < targetBufferedMs Then
				Dim framesToGenerate As Integer = Math.Max(1, CInt(Math.Ceiling((targetBufferedMs - bufferedMs) / 1000.0 * _fpsMode.ToFps())))

				For i As Integer = 0 To framesToGenerate - 1
					Dim isMuted As Boolean
					SyncLock _lockObj
						isMuted = _muted
					End SyncLock

					Dim bits = LtcEncoder.BuildLtcFrame(_tc, _fpsMode)
					Dim floatMono = LtcEncoder.EncodeBiphaseMark(bits, _samplesPerBit)
					Dim pcmBytes = RenderStereo16(floatMono, _amplitude, isMuted)
					localProvider.AddSamples(pcmBytes, 0, pcmBytes.Length)
					_tc.Increment(_fpsMode)
				Next
			Else
				Thread.Sleep(10)
			End If
		Loop
	End Sub

	Private Shared Function RenderStereo16(mono As Single(), amplitude As Single, muted As Boolean) As Byte()
		Dim bytes(mono.Length * 4 - 1) As Byte
		Dim o As Integer = 0
		For Each s In mono
			Dim v As Integer = 0
			If Not muted Then
				v = CInt(Math.Max(Math.Min(s * amplitude, 1.0F), -1.0F) * Short.MaxValue)
			End If
			Dim lo As Byte = CByte(v And &HFF)
			Dim hi As Byte = CByte((v >> 8) And &HFF)

			' Left = LTC
			bytes(o) = lo
			bytes(o + 1) = hi

			' Right = silence
			bytes(o + 2) = 0
			bytes(o + 3) = 0

			o += 4
		Next
		Return bytes
	End Function

	Public Sub Dispose() Implements IDisposable.Dispose
		[Stop]()
	End Sub
End Class
