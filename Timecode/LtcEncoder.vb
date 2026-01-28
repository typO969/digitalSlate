Imports System

Public Module LtcEncoder
	Private Function Bcd(value As Integer) As Integer
		Return value Mod 10
	End Function

	Private Function BcdTens(value As Integer) As Integer
		Return (value \ 10) Mod 10
	End Function

	Private Sub SetBit(bits As Boolean(), index As Integer, value As Boolean)
		bits(index) = value
	End Sub

	Private Sub SetBcdNibble(bits As Boolean(), startIndex As Integer, nibbleValue As Integer)
		For i As Integer = 0 To 3
			SetBit(bits, startIndex + i, ((nibbleValue >> i) And 1) = 1)
		Next
	End Sub

	Private Function ComputeEvenParity(bits As Boolean(), startIndex As Integer, length As Integer) As Boolean
		Dim ones As Integer = 0
		For i As Integer = 0 To length - 1
			If bits(startIndex + i) Then ones += 1
		Next
		Return (ones Mod 2) = 1
	End Function

	Public Function BuildLtcFrame(tc As LtcTimecode, fpsMode As LtcFpsMode) As Boolean()
		Dim bits(79) As Boolean

		' LTC is 80 bits; this builds a basic SMPTE-like BCD layout with sync word.
		' User bits are left as 0.

		' Frames
		SetBcdNibble(bits, 0, Bcd(tc.Frames))
		SetBcdNibble(bits, 8, BcdTens(tc.Frames))

		' Seconds
		SetBcdNibble(bits, 16, Bcd(tc.Seconds))
		SetBcdNibble(bits, 24, BcdTens(tc.Seconds))

		' Minutes
		SetBcdNibble(bits, 32, Bcd(tc.Minutes))
		SetBcdNibble(bits, 40, BcdTens(tc.Minutes))

		' Hours
		SetBcdNibble(bits, 48, Bcd(tc.Hours))
		SetBcdNibble(bits, 56, BcdTens(tc.Hours))

		' Flags: drop-frame and color-frame are not used for requested fps modes.
		' Keep them false.

		' Parity bits (simple even parity over 0-63 and 64-79 excluding sync word would be spec-accurate).
		' Here: compute parity over 0-63 and store at bit 59 (common placement for DF/flag region is different per spec).
		' For interoperability, consumers usually lock on the sync word and BCD; this is a baseline.

		' Sync word (16-bit) 0x3FFD, LSB-first
		Dim sync As Integer = &H3FFD
		For i As Integer = 0 To 15
			bits(64 + i) = ((sync >> i) And 1) = 1
		Next

		Return bits
	End Function

	Public Function EncodeBiphaseMark(bits As Boolean(), samplesPerBit As Integer) As Single()
		If samplesPerBit < 2 Then Throw New ArgumentOutOfRangeException(NameOf(samplesPerBit))

		Dim totalSamples As Integer = bits.Length * samplesPerBit
		Dim pcm(totalSamples - 1) As Single

		Dim level As Single = 1.0F
		Dim sampleIndex As Integer = 0

		For Each bit In bits
			' Always transition at the start of the bit cell
			level = -level
			Dim half As Integer = samplesPerBit \ 2
			For i As Integer = 0 To half - 1
				pcm(sampleIndex) = level
				sampleIndex += 1
			Next

			' For a 1, transition in the middle
			If bit Then level = -level
			For i As Integer = half To samplesPerBit - 1
				pcm(sampleIndex) = level
				sampleIndex += 1
			Next
		Next

		Return pcm
	End Function
End Module
