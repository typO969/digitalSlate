<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Me.gbCaps = New System.Windows.Forms.GroupBox()
        Me.rbYesCaps = New System.Windows.Forms.RadioButton()
        Me.rbNoCaps = New System.Windows.Forms.RadioButton()
        Me.gbSyncBeeps = New System.Windows.Forms.GroupBox()
        Me.rb2SB = New System.Windows.Forms.RadioButton()
        Me.rb1SB = New System.Windows.Forms.RadioButton()
        Me.rb0SB = New System.Windows.Forms.RadioButton()
        Me.gbCountdown = New System.Windows.Forms.GroupBox()
        Me.rb4CD = New System.Windows.Forms.RadioButton()
        Me.rb3CD = New System.Windows.Forms.RadioButton()
        Me.rb2CD = New System.Windows.Forms.RadioButton()
        Me.rb1CD = New System.Windows.Forms.RadioButton()
        Me.rb0CD = New System.Windows.Forms.RadioButton()
        Me.butOK = New System.Windows.Forms.Button()
        Me.gbClapVisuals = New System.Windows.Forms.GroupBox()
        Me.cbAlwaysFullPreroll = New System.Windows.Forms.CheckBox()
        Me.cbMetadataDate = New System.Windows.Forms.CheckBox()
        Me.cbMetadataFps = New System.Windows.Forms.CheckBox()
        Me.cbShowCountdownNumbers = New System.Windows.Forms.CheckBox()
        Me.cbQuietSticks = New System.Windows.Forms.CheckBox()
        Me.gbLtc = New System.Windows.Forms.GroupBox()
        Me.cmbLtcDevice = New System.Windows.Forms.ComboBox()
        Me.lblLtcDevice = New System.Windows.Forms.Label()
        Me.cmbLtcFps = New System.Windows.Forms.ComboBox()
        Me.lblLtcFps = New System.Windows.Forms.Label()
        Me.cbLtcUnmute = New System.Windows.Forms.CheckBox()
        Me.cbLtcEnabled = New System.Windows.Forms.CheckBox()
        Me.gbCaps.SuspendLayout()
        Me.gbSyncBeeps.SuspendLayout()
        Me.gbCountdown.SuspendLayout()
        Me.gbClapVisuals.SuspendLayout()
        Me.gbLtc.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCaps
        '
        Me.gbCaps.Controls.Add(Me.rbYesCaps)
        Me.gbCaps.Controls.Add(Me.rbNoCaps)
        Me.gbCaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbCaps.Location = New System.Drawing.Point(321, 190)
        Me.gbCaps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCaps.Name = "gbCaps"
        Me.gbCaps.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCaps.Size = New System.Drawing.Size(205, 78)
        Me.gbCaps.TabIndex = 4
        Me.gbCaps.TabStop = False
        Me.gbCaps.Text = "Display CAPS?"
        '
        'rbYesCaps
        '
        Me.rbYesCaps.AutoSize = True
        Me.rbYesCaps.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbYesCaps.Location = New System.Drawing.Point(97, 35)
        Me.rbYesCaps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rbYesCaps.Name = "rbYesCaps"
        Me.rbYesCaps.Size = New System.Drawing.Size(50, 28)
        Me.rbYesCaps.TabIndex = 3
        Me.rbYesCaps.Text = "Y"
        Me.rbYesCaps.UseVisualStyleBackColor = True
        '
        'rbNoCaps
        '
        Me.rbNoCaps.AutoSize = True
        Me.rbNoCaps.Checked = True
        Me.rbNoCaps.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNoCaps.Location = New System.Drawing.Point(25, 38)
        Me.rbNoCaps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rbNoCaps.Name = "rbNoCaps"
        Me.rbNoCaps.Size = New System.Drawing.Size(50, 28)
        Me.rbNoCaps.TabIndex = 2
        Me.rbNoCaps.TabStop = True
        Me.rbNoCaps.Text = "N"
        Me.rbNoCaps.UseVisualStyleBackColor = True
        '
        'gbSyncBeeps
        '
        Me.gbSyncBeeps.Controls.Add(Me.rb2SB)
        Me.gbSyncBeeps.Controls.Add(Me.rb1SB)
        Me.gbSyncBeeps.Controls.Add(Me.rb0SB)
        Me.gbSyncBeeps.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbSyncBeeps.Location = New System.Drawing.Point(321, 105)
        Me.gbSyncBeeps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbSyncBeeps.Name = "gbSyncBeeps"
        Me.gbSyncBeeps.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbSyncBeeps.Size = New System.Drawing.Size(212, 69)
        Me.gbSyncBeeps.TabIndex = 6
        Me.gbSyncBeeps.TabStop = False
        Me.gbSyncBeeps.Text = "Sync Beep Count:"
        '
        'rb2SB
        '
        Me.rb2SB.AutoSize = True
        Me.rb2SB.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb2SB.Location = New System.Drawing.Point(147, 31)
        Me.rb2SB.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb2SB.Name = "rb2SB"
        Me.rb2SB.Size = New System.Drawing.Size(46, 28)
        Me.rb2SB.TabIndex = 9
        Me.rb2SB.Text = "2"
        Me.rb2SB.UseVisualStyleBackColor = True
        '
        'rb1SB
        '
        Me.rb1SB.AutoSize = True
        Me.rb1SB.Checked = True
        Me.rb1SB.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb1SB.Location = New System.Drawing.Point(84, 30)
        Me.rb1SB.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb1SB.Name = "rb1SB"
        Me.rb1SB.Size = New System.Drawing.Size(46, 28)
        Me.rb1SB.TabIndex = 8
        Me.rb1SB.TabStop = True
        Me.rb1SB.Text = "1"
        Me.rb1SB.UseVisualStyleBackColor = True
        '
        'rb0SB
        '
        Me.rb0SB.AutoSize = True
        Me.rb0SB.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb0SB.Location = New System.Drawing.Point(21, 30)
        Me.rb0SB.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb0SB.Name = "rb0SB"
        Me.rb0SB.Size = New System.Drawing.Size(46, 28)
        Me.rb0SB.TabIndex = 7
        Me.rb0SB.Text = "0"
        Me.rb0SB.UseVisualStyleBackColor = True
        '
        'gbCountdown
        '
        Me.gbCountdown.Controls.Add(Me.rb4CD)
        Me.gbCountdown.Controls.Add(Me.rb3CD)
        Me.gbCountdown.Controls.Add(Me.rb2CD)
        Me.gbCountdown.Controls.Add(Me.rb1CD)
        Me.gbCountdown.Controls.Add(Me.rb0CD)
        Me.gbCountdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbCountdown.Location = New System.Drawing.Point(321, 17)
        Me.gbCountdown.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCountdown.Name = "gbCountdown"
        Me.gbCountdown.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCountdown.Size = New System.Drawing.Size(280, 72)
        Me.gbCountdown.TabIndex = 5
        Me.gbCountdown.TabStop = False
        Me.gbCountdown.Text = "Countdown Beep Count:"
        '
        'rb4CD
        '
        Me.rb4CD.AutoSize = True
        Me.rb4CD.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb4CD.Location = New System.Drawing.Point(229, 31)
        Me.rb4CD.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb4CD.Name = "rb4CD"
        Me.rb4CD.Size = New System.Drawing.Size(46, 28)
        Me.rb4CD.TabIndex = 6
        Me.rb4CD.Text = "4"
        Me.rb4CD.UseVisualStyleBackColor = True
        '
        'rb3CD
        '
        Me.rb3CD.AutoSize = True
        Me.rb3CD.Checked = True
        Me.rb3CD.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb3CD.Location = New System.Drawing.Point(177, 31)
        Me.rb3CD.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb3CD.Name = "rb3CD"
        Me.rb3CD.Size = New System.Drawing.Size(46, 28)
        Me.rb3CD.TabIndex = 5
        Me.rb3CD.TabStop = True
        Me.rb3CD.Text = "3"
        Me.rb3CD.UseVisualStyleBackColor = True
        '
        'rb2CD
        '
        Me.rb2CD.AutoSize = True
        Me.rb2CD.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb2CD.Location = New System.Drawing.Point(125, 31)
        Me.rb2CD.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb2CD.Name = "rb2CD"
        Me.rb2CD.Size = New System.Drawing.Size(46, 28)
        Me.rb2CD.TabIndex = 4
        Me.rb2CD.Text = "2"
        Me.rb2CD.UseVisualStyleBackColor = True
        '
        'rb1CD
        '
        Me.rb1CD.AutoSize = True
        Me.rb1CD.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb1CD.Location = New System.Drawing.Point(73, 31)
        Me.rb1CD.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb1CD.Name = "rb1CD"
        Me.rb1CD.Size = New System.Drawing.Size(46, 28)
        Me.rb1CD.TabIndex = 3
        Me.rb1CD.Text = "1"
        Me.rb1CD.UseVisualStyleBackColor = True
        '
        'rb0CD
        '
        Me.rb0CD.AutoSize = True
        Me.rb0CD.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb0CD.Location = New System.Drawing.Point(21, 31)
        Me.rb0CD.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rb0CD.Name = "rb0CD"
        Me.rb0CD.Size = New System.Drawing.Size(46, 28)
        Me.rb0CD.TabIndex = 2
        Me.rb0CD.Text = "0"
        Me.rb0CD.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Font = New System.Drawing.Font("HelveticaNeueLT Std", 12.0!)
        Me.butOK.Location = New System.Drawing.Point(503, 452)
        Me.butOK.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(98, 38)
        Me.butOK.TabIndex = 7
        Me.butOK.Text = "OK"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'gbClapVisuals
        '
        Me.gbClapVisuals.Controls.Add(Me.cbAlwaysFullPreroll)
        Me.gbClapVisuals.Controls.Add(Me.cbMetadataDate)
        Me.gbClapVisuals.Controls.Add(Me.cbMetadataFps)
        Me.gbClapVisuals.Controls.Add(Me.cbShowCountdownNumbers)
        Me.gbClapVisuals.Controls.Add(Me.cbQuietSticks)
        Me.gbClapVisuals.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbClapVisuals.Location = New System.Drawing.Point(18, 17)
        Me.gbClapVisuals.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbClapVisuals.Name = "gbClapVisuals"
        Me.gbClapVisuals.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbClapVisuals.Size = New System.Drawing.Size(285, 264)
        Me.gbClapVisuals.TabIndex = 8
        Me.gbClapVisuals.TabStop = False
        Me.gbClapVisuals.Text = "Clap Visual Options"
        '
        'cbAlwaysFullPreroll
        '
        Me.cbAlwaysFullPreroll.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlwaysFullPreroll.Location = New System.Drawing.Point(13, 199)
        Me.cbAlwaysFullPreroll.Margin = New System.Windows.Forms.Padding(4)
        Me.cbAlwaysFullPreroll.Name = "cbAlwaysFullPreroll"
        Me.cbAlwaysFullPreroll.Size = New System.Drawing.Size(280, 56)
        Me.cbAlwaysFullPreroll.TabIndex = 4
        Me.cbAlwaysFullPreroll.Text = "Always full pre-roll on every start"
        Me.cbAlwaysFullPreroll.UseVisualStyleBackColor = True
        '
        'cbMetadataDate
        '
        Me.cbMetadataDate.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMetadataDate.Location = New System.Drawing.Point(11, 163)
        Me.cbMetadataDate.Margin = New System.Windows.Forms.Padding(4)
        Me.cbMetadataDate.Name = "cbMetadataDate"
        Me.cbMetadataDate.Size = New System.Drawing.Size(233, 24)
        Me.cbMetadataDate.TabIndex = 3
        Me.cbMetadataDate.Text = "Flash DATE on countdown"
        Me.cbMetadataDate.UseVisualStyleBackColor = True
        '
        'cbMetadataFps
        '
        Me.cbMetadataFps.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMetadataFps.Location = New System.Drawing.Point(12, 127)
        Me.cbMetadataFps.Margin = New System.Windows.Forms.Padding(4)
        Me.cbMetadataFps.Name = "cbMetadataFps"
        Me.cbMetadataFps.Size = New System.Drawing.Size(223, 24)
        Me.cbMetadataFps.TabIndex = 2
        Me.cbMetadataFps.Text = "Flash FPS on countdown"
        Me.cbMetadataFps.UseVisualStyleBackColor = True
        '
        'cbShowCountdownNumbers
        '
        Me.cbShowCountdownNumbers.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShowCountdownNumbers.Location = New System.Drawing.Point(13, 57)
        Me.cbShowCountdownNumbers.Margin = New System.Windows.Forms.Padding(4)
        Me.cbShowCountdownNumbers.Name = "cbShowCountdownNumbers"
        Me.cbShowCountdownNumbers.Size = New System.Drawing.Size(291, 62)
        Me.cbShowCountdownNumbers.TabIndex = 1
        Me.cbShowCountdownNumbers.Text = "Show large countdown numbers (count >= 2)"
        Me.cbShowCountdownNumbers.UseVisualStyleBackColor = True
        '
        'cbQuietSticks
        '
        Me.cbQuietSticks.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQuietSticks.Location = New System.Drawing.Point(15, 28)
        Me.cbQuietSticks.Margin = New System.Windows.Forms.Padding(4)
        Me.cbQuietSticks.Name = "cbQuietSticks"
        Me.cbQuietSticks.Size = New System.Drawing.Size(278, 31)
        Me.cbQuietSticks.TabIndex = 0
        Me.cbQuietSticks.Text = "Quiet sticks (mute beeps)"
        Me.cbQuietSticks.UseVisualStyleBackColor = True
        '
        'gbLtc
        '
        Me.gbLtc.Controls.Add(Me.cmbLtcDevice)
        Me.gbLtc.Controls.Add(Me.lblLtcDevice)
        Me.gbLtc.Controls.Add(Me.cmbLtcFps)
        Me.gbLtc.Controls.Add(Me.lblLtcFps)
        Me.gbLtc.Controls.Add(Me.cbLtcUnmute)
        Me.gbLtc.Controls.Add(Me.cbLtcEnabled)
        Me.gbLtc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbLtc.Location = New System.Drawing.Point(18, 297)
        Me.gbLtc.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbLtc.Name = "gbLtc"
        Me.gbLtc.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbLtc.Size = New System.Drawing.Size(474, 201)
        Me.gbLtc.TabIndex = 9
        Me.gbLtc.TabStop = False
        Me.gbLtc.Text = "LTC Output"
        '
        'cmbLtcDevice
        '
        Me.cmbLtcDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLtcDevice.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLtcDevice.FormattingEnabled = True
        Me.cmbLtcDevice.Location = New System.Drawing.Point(134, 152)
        Me.cmbLtcDevice.Name = "cmbLtcDevice"
        Me.cmbLtcDevice.Size = New System.Drawing.Size(328, 32)
        Me.cmbLtcDevice.TabIndex = 5
        '
        'lblLtcDevice
        '
        Me.lblLtcDevice.AutoSize = True
        Me.lblLtcDevice.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLtcDevice.Location = New System.Drawing.Point(9, 155)
        Me.lblLtcDevice.Name = "lblLtcDevice"
        Me.lblLtcDevice.Size = New System.Drawing.Size(119, 24)
        Me.lblLtcDevice.TabIndex = 4
        Me.lblLtcDevice.Text = "Device Out:"
        '
        'cmbLtcFps
        '
        Me.cmbLtcFps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLtcFps.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLtcFps.FormattingEnabled = True
        Me.cmbLtcFps.Items.AddRange(New Object() {"23.976", "24", "25", "30"})
        Me.cmbLtcFps.Location = New System.Drawing.Point(117, 109)
        Me.cmbLtcFps.Name = "cmbLtcFps"
        Me.cmbLtcFps.Size = New System.Drawing.Size(106, 32)
        Me.cmbLtcFps.TabIndex = 3
        '
        'lblLtcFps
        '
        Me.lblLtcFps.AutoSize = True
        Me.lblLtcFps.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLtcFps.Location = New System.Drawing.Point(12, 112)
        Me.lblLtcFps.Name = "lblLtcFps"
        Me.lblLtcFps.Size = New System.Drawing.Size(99, 24)
        Me.lblLtcFps.TabIndex = 2
        Me.lblLtcFps.Text = "LTC FPS:"
        '
        'cbLtcUnmute
        '
        Me.cbLtcUnmute.AutoSize = True
        Me.cbLtcUnmute.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLtcUnmute.Location = New System.Drawing.Point(12, 68)
        Me.cbLtcUnmute.Name = "cbLtcUnmute"
        Me.cbLtcUnmute.Size = New System.Drawing.Size(347, 28)
        Me.cbLtcUnmute.TabIndex = 1
        Me.cbLtcUnmute.Text = "Unmute LTC output (manual sync)"
        Me.cbLtcUnmute.UseVisualStyleBackColor = True
        '
        'cbLtcEnabled
        '
        Me.cbLtcEnabled.AutoSize = True
        Me.cbLtcEnabled.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLtcEnabled.Location = New System.Drawing.Point(12, 34)
        Me.cbLtcEnabled.Name = "cbLtcEnabled"
        Me.cbLtcEnabled.Size = New System.Drawing.Size(273, 28)
        Me.cbLtcEnabled.TabIndex = 0
        Me.cbLtcEnabled.Text = "Enable LTC (Left channel)"
        Me.cbLtcEnabled.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbLtc)
        Me.Controls.Add(Me.gbClapVisuals)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.gbSyncBeeps)
        Me.Controls.Add(Me.gbCountdown)
        Me.Controls.Add(Me.gbCaps)
        Me.Font = New System.Drawing.Font("Helvetica", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TopMost = True
        Me.gbCaps.ResumeLayout(False)
        Me.gbCaps.PerformLayout()
        Me.gbSyncBeeps.ResumeLayout(False)
        Me.gbSyncBeeps.PerformLayout()
        Me.gbCountdown.ResumeLayout(False)
        Me.gbCountdown.PerformLayout()
        Me.gbClapVisuals.ResumeLayout(False)
        Me.gbLtc.ResumeLayout(False)
        Me.gbLtc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbCaps As GroupBox
    Friend WithEvents rbYesCaps As RadioButton
    Friend WithEvents rbNoCaps As RadioButton
    Friend WithEvents gbSyncBeeps As GroupBox
    Friend WithEvents gbCountdown As GroupBox
    Friend WithEvents rb1CD As RadioButton
    Friend WithEvents rb0CD As RadioButton
    Friend WithEvents rb2SB As RadioButton
    Friend WithEvents rb1SB As RadioButton
    Friend WithEvents rb0SB As RadioButton
    Friend WithEvents rb4CD As RadioButton
    Friend WithEvents rb3CD As RadioButton
    Friend WithEvents rb2CD As RadioButton
    Friend WithEvents butOK As Button
    Friend WithEvents gbClapVisuals As GroupBox
    Friend WithEvents cbAlwaysFullPreroll As CheckBox
    Friend WithEvents cbMetadataDate As CheckBox
    Friend WithEvents cbMetadataFps As CheckBox
    Friend WithEvents cbShowCountdownNumbers As CheckBox
    Friend WithEvents cbQuietSticks As CheckBox
    Friend WithEvents gbLtc As GroupBox
    Friend WithEvents cmbLtcDevice As ComboBox
    Friend WithEvents lblLtcDevice As Label
    Friend WithEvents cmbLtcFps As ComboBox
    Friend WithEvents lblLtcFps As Label
    Friend WithEvents cbLtcUnmute As CheckBox
    Friend WithEvents cbLtcEnabled As CheckBox
End Class
