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
        Me.gbCaps.SuspendLayout()
        Me.gbSyncBeeps.SuspendLayout()
        Me.gbCountdown.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCaps
        '
        Me.gbCaps.Controls.Add(Me.rbYesCaps)
        Me.gbCaps.Controls.Add(Me.rbNoCaps)
        Me.gbCaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbCaps.Location = New System.Drawing.Point(30, 222)
        Me.gbCaps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCaps.Name = "gbCaps"
        Me.gbCaps.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCaps.Size = New System.Drawing.Size(274, 78)
        Me.gbCaps.TabIndex = 4
        Me.gbCaps.TabStop = False
        Me.gbCaps.Text = "Enable DISPLAY CAPS?"
        '
        'rbYesCaps
        '
        Me.rbYesCaps.AutoSize = True
        Me.rbYesCaps.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbYesCaps.Location = New System.Drawing.Point(114, 36)
        Me.rbYesCaps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rbYesCaps.Name = "rbYesCaps"
        Me.rbYesCaps.Size = New System.Drawing.Size(71, 28)
        Me.rbYesCaps.TabIndex = 3
        Me.rbYesCaps.Text = "Yes"
        Me.rbYesCaps.UseVisualStyleBackColor = True
        '
        'rbNoCaps
        '
        Me.rbNoCaps.AutoSize = True
        Me.rbNoCaps.Checked = True
        Me.rbNoCaps.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNoCaps.Location = New System.Drawing.Point(24, 36)
        Me.rbNoCaps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.rbNoCaps.Name = "rbNoCaps"
        Me.rbNoCaps.Size = New System.Drawing.Size(62, 28)
        Me.rbNoCaps.TabIndex = 2
        Me.rbNoCaps.TabStop = True
        Me.rbNoCaps.Text = "No"
        Me.rbNoCaps.UseVisualStyleBackColor = True
        '
        'gbSyncBeeps
        '
        Me.gbSyncBeeps.Controls.Add(Me.rb2SB)
        Me.gbSyncBeeps.Controls.Add(Me.rb1SB)
        Me.gbSyncBeeps.Controls.Add(Me.rb0SB)
        Me.gbSyncBeeps.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbSyncBeeps.Location = New System.Drawing.Point(30, 126)
        Me.gbSyncBeeps.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbSyncBeeps.Name = "gbSyncBeeps"
        Me.gbSyncBeeps.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbSyncBeeps.Size = New System.Drawing.Size(264, 78)
        Me.gbSyncBeeps.TabIndex = 6
        Me.gbSyncBeeps.TabStop = False
        Me.gbSyncBeeps.Text = "Sync Beep Count:"
        '
        'rb2SB
        '
        Me.rb2SB.AutoSize = True
        Me.rb2SB.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb2SB.Location = New System.Drawing.Point(192, 36)
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
        Me.rb1SB.Location = New System.Drawing.Point(111, 36)
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
        Me.rb0SB.Location = New System.Drawing.Point(30, 36)
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
        Me.gbCountdown.Location = New System.Drawing.Point(30, 24)
        Me.gbCountdown.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCountdown.Name = "gbCountdown"
        Me.gbCountdown.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.gbCountdown.Size = New System.Drawing.Size(414, 84)
        Me.gbCountdown.TabIndex = 5
        Me.gbCountdown.TabStop = False
        Me.gbCountdown.Text = "Countdown Beep Count:"
        '
        'rb4CD
        '
        Me.rb4CD.AutoSize = True
        Me.rb4CD.Font = New System.Drawing.Font("Helvetica", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb4CD.Location = New System.Drawing.Point(348, 36)
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
        Me.rb3CD.Location = New System.Drawing.Point(269, 36)
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
        Me.rb2CD.Location = New System.Drawing.Point(190, 36)
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
        Me.rb1CD.Location = New System.Drawing.Point(111, 36)
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
        Me.rb0CD.Location = New System.Drawing.Point(32, 36)
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
        Me.butOK.Location = New System.Drawing.Point(360, 216)
        Me.butOK.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(80, 80)
        Me.butOK.TabIndex = 7
        Me.butOK.Text = "OK"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.gbSyncBeeps)
        Me.Controls.Add(Me.gbCountdown)
        Me.Controls.Add(Me.gbCaps)
        Me.Font = New System.Drawing.Font("Helvetica", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(483, 367)
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Digital Slate Settings"
        Me.TopMost = True
        Me.gbCaps.ResumeLayout(False)
        Me.gbCaps.PerformLayout()
        Me.gbSyncBeeps.ResumeLayout(False)
        Me.gbSyncBeeps.PerformLayout()
        Me.gbCountdown.ResumeLayout(False)
        Me.gbCountdown.PerformLayout()
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
End Class
