Imports System.Runtime.InteropServices

Public Class FixedRatio
    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class


Public Class Form1
    Public Structure Rect
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_SIZING As Long = &H214
        Const WMSZ_LEFT As Integer = 1
        Const WMSZ_RIGHT As Integer = 2
        Const WMSZ_TOP As Integer = 3
        Const WMSZ_TOPLEFT As Integer = 4
        Const WMSZ_TOPRIGHT As Integer = 5
        Const WMSZ_BOTTOM As Integer = 6
        Const WMSZ_BOTTOMLEFT As Integer = 7
        Const WMSZ_BOTTOMRIGHT As Integer = 8
        Static fixed_aspect_ratio As Double = 0
        Dim new_aspect_ratio As Double
        If m.Msg = WM_SIZING And m.HWnd.Equals(Me.Handle) Then
            ' Turn the messages lParam into a Rect.
            Dim r As Rect
            r = DirectCast(
            Marshal.PtrToStructure(m.LParam, GetType(Rect)),
            Rect)
            ' Get the current dimensions.
            Dim wid As Double = r.right - r.left
            Dim hgt As Double = r.bottom - r.top
            ' Get the new aspect ratio.
            new_aspect_ratio = hgt / wid
            ' The first time, save the forms aspect ratio.
            If fixed_aspect_ratio = 0 Then
                fixed_aspect_ratio = new_aspect_ratio
            End If
            ' See if the aspect ratio is changing.
            If fixed_aspect_ratio <> new_aspect_ratio Then
                ' To decide which dimension we should preserve,
                ' see what border the user is dragging.
                If m.WParam.ToInt32 = WMSZ_TOPLEFT Or
                m.WParam.ToInt32 = WMSZ_TOPRIGHT Or
                m.WParam.ToInt32 = WMSZ_BOTTOMLEFT Or
                m.WParam.ToInt32 = WMSZ_BOTTOMRIGHT _
                Then
                    ' The user is dragging a corner.
                    ' Preserve the bigger dimension.
                    If new_aspect_ratio > fixed_aspect_ratio Then
                        ' Its too tall and thin. Make it wider.
                        wid = hgt / fixed_aspect_ratio
                    Else
                        ' Its too short and wide. Make it taller.
                        hgt = wid * fixed_aspect_ratio
                    End If
                ElseIf m.WParam.ToInt32 = WMSZ_LEFT Or
                m.WParam.ToInt32 = WMSZ_RIGHT _
                Then
                    ' The user is dragging a side.
                    ' Preserve the width.
                    hgt = wid * fixed_aspect_ratio
                ElseIf m.WParam.ToInt32 = WMSZ_TOP Or
                m.WParam.ToInt32 = WMSZ_BOTTOM _
                Then
                    ' The user is dragging the top or bottom.
                    ' Preserve the height.
                    wid = hgt / fixed_aspect_ratio
                End If
                ' Figure out whether to reset the top/bottom
                ' and left/right.
                ' See if the user is dragging the top edge.
                If m.WParam.ToInt32 = WMSZ_TOP Or
                m.WParam.ToInt32 = WMSZ_TOPLEFT Or
                m.WParam.ToInt32 = WMSZ_TOPRIGHT _
                Then
                    ' Reset the top.
                    r.top = r.bottom - CInt(hgt)
                Else
                    ' Reset the bottom.
                    r.bottom = r.top + CInt(hgt)
                End If
                ' See if the user is dragging the left edge.
                If m.WParam.ToInt32 = WMSZ_LEFT Or
                m.WParam.ToInt32 = WMSZ_TOPLEFT Or
                m.WParam.ToInt32 = WMSZ_BOTTOMLEFT _
                Then
                    ' Reset the left.
                    r.left = r.right - CInt(wid)
                Else
                    ' Reset the right.
                    r.right = r.left + CInt(wid)
                End If
                ' Update the Message objects LParam field.
                Marshal.StructureToPtr(r, m.LParam, True)
            End If
        End If
        MyBase.WndProc(m)
    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Name = "Form1"
        Me.Text = "FixedAspectRatio"
        Me.ResumeLayout(False)

    End Sub

End Class