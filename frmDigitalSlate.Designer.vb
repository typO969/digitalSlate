<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDigitalSlate
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.cmsPrimary = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiProfiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiProfNum0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiProfNum1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiProfNum2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiProfNum3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiProfNum4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiProfNum5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiZeroTC = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.plPrimary = New System.Windows.Forms.Panel()
        Me.butSwAudio = New System.Windows.Forms.Button()
        Me.butSwDayNit = New System.Windows.Forms.Button()
        Me.butSwIntExt = New System.Windows.Forms.Button()
        Me.butEdit = New System.Windows.Forms.Button()
        Me.cbTakeInc = New System.Windows.Forms.CheckBox()
        Me.butQuit = New System.Windows.Forms.Button()
        Me.lblHideMos = New System.Windows.Forms.Label()
        Me.lblHideSync = New System.Windows.Forms.Label()
        Me.lblHideNite = New System.Windows.Forms.Label()
        Me.lblHideDay = New System.Windows.Forms.Label()
        Me.lblHideExt = New System.Windows.Forms.Label()
        Me.lblHideInt = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblFPS = New System.Windows.Forms.Label()
        Me.lblDOP = New System.Windows.Forms.Label()
        Me.lblDirector = New System.Windows.Forms.Label()
        Me.lblProduction = New System.Windows.Forms.Label()
        Me.lblRoll = New System.Windows.Forms.Label()
        Me.lblTake = New System.Windows.Forms.Label()
        Me.lblScene = New System.Windows.Forms.Label()
        Me.lblTimecode = New System.Windows.Forms.Label()
        Me.pbClapper = New System.Windows.Forms.PictureBox()
        Me.pbSlateBody = New System.Windows.Forms.PictureBox()
        Me.cmsPrimary.SuspendLayout()
        Me.plPrimary.SuspendLayout()
        CType(Me.pbClapper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSlateBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'cmsPrimary
        '
        Me.cmsPrimary.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.cmsPrimary.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiEdit, Me.tsiProfiles, Me.tsiImport, Me.tsiExport, Me.tsiOptions, Me.tsiZeroTC, Me.tsiReset, Me.ToolStripSeparator1, Me.tsiExit})
        Me.cmsPrimary.Name = "cmsPrimary"
        Me.cmsPrimary.Size = New System.Drawing.Size(261, 266)
        '
        'tsiEdit
        '
        Me.tsiEdit.AutoToolTip = True
        Me.tsiEdit.Name = "tsiEdit"
        Me.tsiEdit.ShortcutKeys = CType(((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.tsiEdit.Size = New System.Drawing.Size(260, 32)
        Me.tsiEdit.Text = "&Edit Slate"
        '
        'tsiProfiles
        '
        Me.tsiProfiles.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiProfNum0, Me.tsiProfNum1, Me.tsiProfNum2, Me.tsiProfNum3, Me.tsiProfNum4, Me.tsiProfNum5})
        Me.tsiProfiles.Enabled = False
        Me.tsiProfiles.Name = "tsiProfiles"
        Me.tsiProfiles.Size = New System.Drawing.Size(260, 32)
        Me.tsiProfiles.Text = "Load/Save"
        '
        'tsiProfNum0
        '
        Me.tsiProfNum0.AutoToolTip = True
        Me.tsiProfNum0.Name = "tsiProfNum0"
        Me.tsiProfNum0.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)
        Me.tsiProfNum0.Size = New System.Drawing.Size(221, 34)
        Me.tsiProfNum0.Text = "Slot 0"
        '
        'tsiProfNum1
        '
        Me.tsiProfNum1.AutoToolTip = True
        Me.tsiProfNum1.Name = "tsiProfNum1"
        Me.tsiProfNum1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.tsiProfNum1.Size = New System.Drawing.Size(221, 34)
        Me.tsiProfNum1.Text = "Slot 1"
        '
        'tsiProfNum2
        '
        Me.tsiProfNum2.AutoToolTip = True
        Me.tsiProfNum2.Name = "tsiProfNum2"
        Me.tsiProfNum2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.tsiProfNum2.Size = New System.Drawing.Size(221, 34)
        Me.tsiProfNum2.Text = "Slot 2"
        '
        'tsiProfNum3
        '
        Me.tsiProfNum3.AutoToolTip = True
        Me.tsiProfNum3.Name = "tsiProfNum3"
        Me.tsiProfNum3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D3), System.Windows.Forms.Keys)
        Me.tsiProfNum3.Size = New System.Drawing.Size(221, 34)
        Me.tsiProfNum3.Text = "Slot 3"
        '
        'tsiProfNum4
        '
        Me.tsiProfNum4.AutoToolTip = True
        Me.tsiProfNum4.Name = "tsiProfNum4"
        Me.tsiProfNum4.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D4), System.Windows.Forms.Keys)
        Me.tsiProfNum4.Size = New System.Drawing.Size(221, 34)
        Me.tsiProfNum4.Text = "Slot 4"
        '
        'tsiProfNum5
        '
        Me.tsiProfNum5.AutoToolTip = True
        Me.tsiProfNum5.Name = "tsiProfNum5"
        Me.tsiProfNum5.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D5), System.Windows.Forms.Keys)
        Me.tsiProfNum5.Size = New System.Drawing.Size(221, 34)
        Me.tsiProfNum5.Text = "Slot 5"
        '
        'tsiImport
        '
        Me.tsiImport.AutoToolTip = True
        Me.tsiImport.Enabled = False
        Me.tsiImport.Name = "tsiImport"
        Me.tsiImport.Size = New System.Drawing.Size(260, 32)
        Me.tsiImport.Text = "Import Slate"
        '
        'tsiExport
        '
        Me.tsiExport.AutoToolTip = True
        Me.tsiExport.Enabled = False
        Me.tsiExport.Name = "tsiExport"
        Me.tsiExport.Size = New System.Drawing.Size(260, 32)
        Me.tsiExport.Text = "Export Slate"
        '
        'tsiOptions
        '
        Me.tsiOptions.AutoToolTip = True
        Me.tsiOptions.Name = "tsiOptions"
        Me.tsiOptions.Size = New System.Drawing.Size(260, 32)
        Me.tsiOptions.Text = "&Settings..."
        '
        'tsiZeroTC
        '
        Me.tsiZeroTC.Name = "tsiZeroTC"
        Me.tsiZeroTC.Size = New System.Drawing.Size(260, 32)
        Me.tsiZeroTC.Text = "Zero Timecode"
        '
        'tsiReset
        '
        Me.tsiReset.AutoToolTip = True
        Me.tsiReset.Name = "tsiReset"
        Me.tsiReset.Size = New System.Drawing.Size(260, 32)
        Me.tsiReset.Text = "&Restore Defaults"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(257, 6)
        '
        'tsiExit
        '
        Me.tsiExit.AutoToolTip = True
        Me.tsiExit.Name = "tsiExit"
        Me.tsiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.tsiExit.Size = New System.Drawing.Size(260, 32)
        Me.tsiExit.Text = "&Quit"
        '
        'plPrimary
        '
        Me.plPrimary.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.plPrimary.Controls.Add(Me.butSwAudio)
        Me.plPrimary.Controls.Add(Me.butSwDayNit)
        Me.plPrimary.Controls.Add(Me.butSwIntExt)
        Me.plPrimary.Controls.Add(Me.butEdit)
        Me.plPrimary.Controls.Add(Me.cbTakeInc)
        Me.plPrimary.Controls.Add(Me.butQuit)
        Me.plPrimary.Controls.Add(Me.lblHideMos)
        Me.plPrimary.Controls.Add(Me.lblHideSync)
        Me.plPrimary.Controls.Add(Me.lblHideNite)
        Me.plPrimary.Controls.Add(Me.lblHideDay)
        Me.plPrimary.Controls.Add(Me.lblHideExt)
        Me.plPrimary.Controls.Add(Me.lblHideInt)
        Me.plPrimary.Controls.Add(Me.lblDate)
        Me.plPrimary.Controls.Add(Me.lblFPS)
        Me.plPrimary.Controls.Add(Me.lblDOP)
        Me.plPrimary.Controls.Add(Me.lblDirector)
        Me.plPrimary.Controls.Add(Me.lblProduction)
        Me.plPrimary.Controls.Add(Me.lblRoll)
        Me.plPrimary.Controls.Add(Me.lblTake)
        Me.plPrimary.Controls.Add(Me.lblScene)
        Me.plPrimary.Controls.Add(Me.lblTimecode)
        Me.plPrimary.Controls.Add(Me.pbClapper)
        Me.plPrimary.Controls.Add(Me.pbSlateBody)
        Me.plPrimary.Location = New System.Drawing.Point(0, 0)
        Me.plPrimary.Margin = New System.Windows.Forms.Padding(2)
        Me.plPrimary.MaximumSize = New System.Drawing.Size(1628, 1028)
        Me.plPrimary.MinimumSize = New System.Drawing.Size(1628, 1028)
        Me.plPrimary.Name = "plPrimary"
        Me.plPrimary.Size = New System.Drawing.Size(1628, 1028)
        Me.plPrimary.TabIndex = 20
        '
        'butSwAudio
        '
        Me.butSwAudio.AutoSize = True
        Me.butSwAudio.BackColor = System.Drawing.Color.Gainsboro
        Me.butSwAudio.FlatAppearance.BorderSize = 0
        Me.butSwAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSwAudio.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSwAudio.ForeColor = System.Drawing.Color.Red
        Me.butSwAudio.Location = New System.Drawing.Point(1064, 803)
        Me.butSwAudio.Margin = New System.Windows.Forms.Padding(0)
        Me.butSwAudio.MaximumSize = New System.Drawing.Size(68, 68)
        Me.butSwAudio.Name = "butSwAudio"
        Me.butSwAudio.Size = New System.Drawing.Size(68, 68)
        Me.butSwAudio.TabIndex = 42
        Me.butSwAudio.Text = "🔄"
        Me.butSwAudio.UseVisualStyleBackColor = False
        '
        'butSwDayNit
        '
        Me.butSwDayNit.AutoSize = True
        Me.butSwDayNit.BackColor = System.Drawing.Color.Gainsboro
        Me.butSwDayNit.FlatAppearance.BorderSize = 0
        Me.butSwDayNit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSwDayNit.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSwDayNit.ForeColor = System.Drawing.Color.Red
        Me.butSwDayNit.Location = New System.Drawing.Point(529, 803)
        Me.butSwDayNit.Margin = New System.Windows.Forms.Padding(0)
        Me.butSwDayNit.MaximumSize = New System.Drawing.Size(68, 68)
        Me.butSwDayNit.Name = "butSwDayNit"
        Me.butSwDayNit.Size = New System.Drawing.Size(68, 68)
        Me.butSwDayNit.TabIndex = 41
        Me.butSwDayNit.Text = "🔄"
        Me.butSwDayNit.UseVisualStyleBackColor = False
        '
        'butSwIntExt
        '
        Me.butSwIntExt.AutoSize = True
        Me.butSwIntExt.BackColor = System.Drawing.Color.Gainsboro
        Me.butSwIntExt.FlatAppearance.BorderSize = 0
        Me.butSwIntExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSwIntExt.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSwIntExt.ForeColor = System.Drawing.Color.Red
        Me.butSwIntExt.Location = New System.Drawing.Point(41, 803)
        Me.butSwIntExt.Margin = New System.Windows.Forms.Padding(0)
        Me.butSwIntExt.MaximumSize = New System.Drawing.Size(68, 68)
        Me.butSwIntExt.Name = "butSwIntExt"
        Me.butSwIntExt.Size = New System.Drawing.Size(68, 68)
        Me.butSwIntExt.TabIndex = 40
        Me.butSwIntExt.Text = "🔄"
        Me.butSwIntExt.UseVisualStyleBackColor = False
        '
        'butEdit
        '
        Me.butEdit.BackColor = System.Drawing.Color.Gainsboro
        Me.butEdit.FlatAppearance.BorderSize = 0
        Me.butEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.butEdit.ForeColor = System.Drawing.Color.Red
        Me.butEdit.Location = New System.Drawing.Point(41, 216)
        Me.butEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.butEdit.MaximumSize = New System.Drawing.Size(76, 68)
        Me.butEdit.Name = "butEdit"
        Me.butEdit.Size = New System.Drawing.Size(68, 68)
        Me.butEdit.TabIndex = 39
        Me.butEdit.Text = "EDIT"
        Me.butEdit.UseVisualStyleBackColor = False
        '
        'cbTakeInc
        '
        Me.cbTakeInc.BackColor = System.Drawing.Color.White
        Me.cbTakeInc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTakeInc.ForeColor = System.Drawing.Color.Red
        Me.cbTakeInc.Location = New System.Drawing.Point(668, 293)
        Me.cbTakeInc.Margin = New System.Windows.Forms.Padding(2)
        Me.cbTakeInc.Name = "cbTakeInc"
        Me.cbTakeInc.Size = New System.Drawing.Size(155, 25)
        Me.cbTakeInc.TabIndex = 38
        Me.cbTakeInc.Text = "Auto  Increment"
        Me.cbTakeInc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbTakeInc.UseCompatibleTextRendering = True
        Me.cbTakeInc.UseVisualStyleBackColor = False
        '
        'butQuit
        '
        Me.butQuit.BackColor = System.Drawing.Color.DimGray
        Me.butQuit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.butQuit.FlatAppearance.BorderSize = 0
        Me.butQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.butQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.butQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butQuit.Font = New System.Drawing.Font("Segoe MDL2 Assets", 16.0!, System.Drawing.FontStyle.Bold)
        Me.butQuit.ForeColor = System.Drawing.Color.White
        Me.butQuit.Location = New System.Drawing.Point(1535, 43)
        Me.butQuit.Margin = New System.Windows.Forms.Padding(0)
        Me.butQuit.Name = "butQuit"
        Me.butQuit.Size = New System.Drawing.Size(38, 38)
        Me.butQuit.TabIndex = 37
        Me.butQuit.Text = ""
        Me.butQuit.UseCompatibleTextRendering = True
        Me.butQuit.UseVisualStyleBackColor = False
        '
        'lblHideMos
        '
        Me.lblHideMos.BackColor = System.Drawing.Color.White
        Me.lblHideMos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHideMos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHideMos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHideMos.Location = New System.Drawing.Point(1344, 788)
        Me.lblHideMos.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHideMos.Name = "lblHideMos"
        Me.lblHideMos.Size = New System.Drawing.Size(169, 85)
        Me.lblHideMos.TabIndex = 36
        Me.lblHideMos.Visible = False
        '
        'lblHideSync
        '
        Me.lblHideSync.BackColor = System.Drawing.Color.White
        Me.lblHideSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHideSync.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHideSync.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHideSync.Location = New System.Drawing.Point(1139, 788)
        Me.lblHideSync.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHideSync.Name = "lblHideSync"
        Me.lblHideSync.Size = New System.Drawing.Size(185, 85)
        Me.lblHideSync.TabIndex = 35
        Me.lblHideSync.Visible = False
        '
        'lblHideNite
        '
        Me.lblHideNite.BackColor = System.Drawing.Color.White
        Me.lblHideNite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHideNite.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHideNite.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHideNite.Location = New System.Drawing.Point(788, 788)
        Me.lblHideNite.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHideNite.Name = "lblHideNite"
        Me.lblHideNite.Size = New System.Drawing.Size(144, 85)
        Me.lblHideNite.TabIndex = 34
        Me.lblHideNite.Visible = False
        '
        'lblHideDay
        '
        Me.lblHideDay.BackColor = System.Drawing.Color.White
        Me.lblHideDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHideDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHideDay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHideDay.Location = New System.Drawing.Point(613, 788)
        Me.lblHideDay.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHideDay.Name = "lblHideDay"
        Me.lblHideDay.Size = New System.Drawing.Size(139, 85)
        Me.lblHideDay.TabIndex = 33
        Me.lblHideDay.Visible = False
        '
        'lblHideExt
        '
        Me.lblHideExt.BackColor = System.Drawing.Color.White
        Me.lblHideExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHideExt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHideExt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHideExt.Location = New System.Drawing.Point(275, 788)
        Me.lblHideExt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHideExt.MaximumSize = New System.Drawing.Size(181, 101)
        Me.lblHideExt.Name = "lblHideExt"
        Me.lblHideExt.Size = New System.Drawing.Size(128, 85)
        Me.lblHideExt.TabIndex = 32
        Me.lblHideExt.Visible = False
        '
        'lblHideInt
        '
        Me.lblHideInt.BackColor = System.Drawing.Color.White
        Me.lblHideInt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHideInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHideInt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHideInt.Location = New System.Drawing.Point(136, 788)
        Me.lblHideInt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHideInt.MaximumSize = New System.Drawing.Size(154, 125)
        Me.lblHideInt.Name = "lblHideInt"
        Me.lblHideInt.Size = New System.Drawing.Size(108, 85)
        Me.lblHideInt.TabIndex = 31
        Me.lblHideInt.Visible = False
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.White
        Me.lblDate.Font = New System.Drawing.Font("Arial", 35.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(956, 673)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDate.MaximumSize = New System.Drawing.Size(612, 97)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(612, 97)
        Me.lblDate.TabIndex = 30
        Me.lblDate.Text = "10 Jul 1780"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDate.UseCompatibleTextRendering = True
        '
        'lblFPS
        '
        Me.lblFPS.BackColor = System.Drawing.Color.White
        Me.lblFPS.Font = New System.Drawing.Font("Arial Black", 50.0!, System.Drawing.FontStyle.Bold)
        Me.lblFPS.Location = New System.Drawing.Point(128, 679)
        Me.lblFPS.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFPS.MaximumSize = New System.Drawing.Size(679, 92)
        Me.lblFPS.Name = "lblFPS"
        Me.lblFPS.Size = New System.Drawing.Size(679, 92)
        Me.lblFPS.TabIndex = 29
        Me.lblFPS.Text = "23.967"
        Me.lblFPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFPS.UseCompatibleTextRendering = True
        '
        'lblDOP
        '
        Me.lblDOP.BackColor = System.Drawing.Color.White
        Me.lblDOP.Font = New System.Drawing.Font("Arial", 45.0!, System.Drawing.FontStyle.Bold)
        Me.lblDOP.Location = New System.Drawing.Point(895, 576)
        Me.lblDOP.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDOP.MaximumSize = New System.Drawing.Size(695, 83)
        Me.lblDOP.Name = "lblDOP"
        Me.lblDOP.Size = New System.Drawing.Size(695, 83)
        Me.lblDOP.TabIndex = 28
        Me.lblDOP.Text = "lblDOP"
        Me.lblDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDOP.UseCompatibleTextRendering = True
        '
        'lblDirector
        '
        Me.lblDirector.BackColor = System.Drawing.Color.White
        Me.lblDirector.Font = New System.Drawing.Font("Arial", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirector.Location = New System.Drawing.Point(83, 576)
        Me.lblDirector.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDirector.MaximumSize = New System.Drawing.Size(725, 83)
        Me.lblDirector.Name = "lblDirector"
        Me.lblDirector.Size = New System.Drawing.Size(725, 83)
        Me.lblDirector.TabIndex = 27
        Me.lblDirector.Text = "lblDirector"
        Me.lblDirector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDirector.UseCompatibleTextRendering = True
        '
        'lblProduction
        '
        Me.lblProduction.BackColor = System.Drawing.Color.White
        Me.lblProduction.Font = New System.Drawing.Font("Arial Black", 55.0!, System.Drawing.FontStyle.Bold)
        Me.lblProduction.Location = New System.Drawing.Point(119, 463)
        Me.lblProduction.Margin = New System.Windows.Forms.Padding(0)
        Me.lblProduction.MaximumSize = New System.Drawing.Size(1471, 92)
        Me.lblProduction.Name = "lblProduction"
        Me.lblProduction.Size = New System.Drawing.Size(1471, 92)
        Me.lblProduction.TabIndex = 26
        Me.lblProduction.Text = "lblProduction"
        Me.lblProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblProduction.UseCompatibleTextRendering = True
        '
        'lblRoll
        '
        Me.lblRoll.AutoEllipsis = True
        Me.lblRoll.BackColor = System.Drawing.Color.White
        Me.lblRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRoll.Font = New System.Drawing.Font("Arial Black", 45.0!, System.Drawing.FontStyle.Bold)
        Me.lblRoll.Location = New System.Drawing.Point(1280, 160)
        Me.lblRoll.Margin = New System.Windows.Forms.Padding(0)
        Me.lblRoll.MaximumSize = New System.Drawing.Size(308, 164)
        Me.lblRoll.Name = "lblRoll"
        Me.lblRoll.Size = New System.Drawing.Size(308, 164)
        Me.lblRoll.TabIndex = 25
        Me.lblRoll.Text = "A001"
        Me.lblRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblRoll.UseCompatibleTextRendering = True
        '
        'lblTake
        '
        Me.lblTake.AutoEllipsis = True
        Me.lblTake.BackColor = System.Drawing.Color.White
        Me.lblTake.Font = New System.Drawing.Font("Arial Black", 60.0!, System.Drawing.FontStyle.Bold)
        Me.lblTake.Location = New System.Drawing.Point(745, 144)
        Me.lblTake.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTake.MaximumSize = New System.Drawing.Size(421, 180)
        Me.lblTake.Name = "lblTake"
        Me.lblTake.Size = New System.Drawing.Size(421, 180)
        Me.lblTake.TabIndex = 24
        Me.lblTake.Text = "10"
        Me.lblTake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTake.UseCompatibleTextRendering = True
        '
        'lblScene
        '
        Me.lblScene.AutoEllipsis = True
        Me.lblScene.BackColor = System.Drawing.Color.White
        Me.lblScene.Font = New System.Drawing.Font("Arial Black", 59.0!, System.Drawing.FontStyle.Bold)
        Me.lblScene.Location = New System.Drawing.Point(139, 149)
        Me.lblScene.Margin = New System.Windows.Forms.Padding(0)
        Me.lblScene.MaximumSize = New System.Drawing.Size(515, 180)
        Me.lblScene.Name = "lblScene"
        Me.lblScene.Size = New System.Drawing.Size(479, 169)
        Me.lblScene.TabIndex = 23
        Me.lblScene.Text = "01C"
        Me.lblScene.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblScene.UseCompatibleTextRendering = True
        '
        'lblTimecode
        '
        Me.lblTimecode.BackColor = System.Drawing.Color.Black
        Me.lblTimecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTimecode.Font = New System.Drawing.Font("Microsoft Sans Serif", 65.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimecode.ForeColor = System.Drawing.Color.Red
        Me.lblTimecode.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTimecode.Location = New System.Drawing.Point(20, 324)
        Me.lblTimecode.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTimecode.Name = "lblTimecode"
        Me.lblTimecode.Padding = New System.Windows.Forms.Padding(0, 16, 0, 1)
        Me.lblTimecode.Size = New System.Drawing.Size(1573, 137)
        Me.lblTimecode.TabIndex = 20
        Me.lblTimecode.Text = "00 : 00 : 00 : 00"
        Me.lblTimecode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTimecode.UseCompatibleTextRendering = True
        '
        'pbClapper
        '
        Me.pbClapper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbClapper.Image = Global.digitalSlate.My.Resources.Resources.clapper
        Me.pbClapper.Location = New System.Drawing.Point(0, 0)
        Me.pbClapper.Margin = New System.Windows.Forms.Padding(0)
        Me.pbClapper.MaximumSize = New System.Drawing.Size(1628, 133)
        Me.pbClapper.Name = "pbClapper"
        Me.pbClapper.Size = New System.Drawing.Size(1612, 132)
        Me.pbClapper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClapper.TabIndex = 21
        Me.pbClapper.TabStop = False
        '
        'pbSlateBody
        '
        Me.pbSlateBody.BackColor = System.Drawing.Color.Black
        Me.pbSlateBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbSlateBody.ContextMenuStrip = Me.cmsPrimary
        Me.pbSlateBody.Image = Global.digitalSlate.My.Resources.Resources.slateBody
        Me.pbSlateBody.Location = New System.Drawing.Point(0, 132)
        Me.pbSlateBody.Margin = New System.Windows.Forms.Padding(0)
        Me.pbSlateBody.MaximumSize = New System.Drawing.Size(1628, 896)
        Me.pbSlateBody.Name = "pbSlateBody"
        Me.pbSlateBody.Size = New System.Drawing.Size(1612, 880)
        Me.pbSlateBody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSlateBody.TabIndex = 22
        Me.pbSlateBody.TabStop = False
        '
        'frmDigitalSlate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1660, 1042)
        Me.ContextMenuStrip = Me.cmsPrimary
        Me.ControlBox = False
        Me.Controls.Add(Me.plPrimary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1620, 984)
        Me.Name = "frmDigitalSlate"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.cmsPrimary.ResumeLayout(False)
        Me.plPrimary.ResumeLayout(False)
        Me.plPrimary.PerformLayout()
        CType(Me.pbClapper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSlateBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Timer
	Friend WithEvents cmsPrimary As ContextMenuStrip
    Friend WithEvents tsiReset As ToolStripMenuItem
    Friend WithEvents tsiOptions As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents tsiExit As ToolStripMenuItem
	Friend WithEvents tsiEdit As ToolStripMenuItem
	Friend WithEvents tsiProfiles As ToolStripMenuItem
	Friend WithEvents tsiProfNum0 As ToolStripMenuItem
	Friend WithEvents tsiProfNum1 As ToolStripMenuItem
	Friend WithEvents tsiProfNum2 As ToolStripMenuItem
	Friend WithEvents tsiProfNum3 As ToolStripMenuItem
	Friend WithEvents tsiProfNum4 As ToolStripMenuItem
	Friend WithEvents tsiProfNum5 As ToolStripMenuItem
	Friend WithEvents tsiExport As ToolStripMenuItem
	Friend WithEvents plPrimary As Panel
	Friend WithEvents butQuit As Button
	Friend WithEvents lblHideMos As Label
	Friend WithEvents lblHideSync As Label
	Friend WithEvents lblHideNite As Label
	Friend WithEvents lblHideDay As Label
	Friend WithEvents lblHideExt As Label
	Friend WithEvents lblHideInt As Label
	Friend WithEvents lblDate As Label
	Friend WithEvents lblFPS As Label
	Friend WithEvents lblDOP As Label
	Friend WithEvents lblDirector As Label
	Friend WithEvents lblProduction As Label
	Friend WithEvents lblRoll As Label
	Friend WithEvents lblTake As Label
	Friend WithEvents lblScene As Label
	Friend WithEvents lblTimecode As Label
	Friend WithEvents pbClapper As PictureBox
	Friend WithEvents pbSlateBody As PictureBox
    Friend WithEvents tsiZeroTC As ToolStripMenuItem
    Friend WithEvents cbTakeInc As CheckBox
    Friend WithEvents butEdit As Button
    Friend WithEvents butSwAudio As Button
    Friend WithEvents butSwDayNit As Button
    Friend WithEvents butSwIntExt As Button
    Friend WithEvents tsiImport As ToolStripMenuItem
End Class
