<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnRunRight = New System.Windows.Forms.Button()
        Me.btnRunLeft = New System.Windows.Forms.Button()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lbl = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.btnJump = New System.Windows.Forms.Button()
        Me.Btn_Leap = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(159, 66)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(512, 256)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(342, 339)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 6
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnRunRight
        '
        Me.btnRunRight.Location = New System.Drawing.Point(240, 339)
        Me.btnRunRight.Name = "btnRunRight"
        Me.btnRunRight.Size = New System.Drawing.Size(75, 23)
        Me.btnRunRight.TabIndex = 5
        Me.btnRunRight.Text = "Right"
        Me.btnRunRight.UseVisualStyleBackColor = True
        '
        'btnRunLeft
        '
        Me.btnRunLeft.Location = New System.Drawing.Point(159, 339)
        Me.btnRunLeft.Name = "btnRunLeft"
        Me.btnRunLeft.Size = New System.Drawing.Size(75, 23)
        Me.btnRunLeft.TabIndex = 4
        Me.btnRunLeft.Text = "Left"
        Me.btnRunLeft.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 60
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(643, 344)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(23, 13)
        Me.lbl.TabIndex = 7
        Me.lbl.Text = "X : "
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(672, 344)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(39, 13)
        Me.lblX.TabIndex = 8
        Me.lblX.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(643, 369)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Y: "
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(672, 369)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(39, 13)
        Me.lblY.TabIndex = 10
        Me.lblY.Text = "Label2"
        '
        'btnJump
        '
        Me.btnJump.Location = New System.Drawing.Point(434, 339)
        Me.btnJump.Name = "btnJump"
        Me.btnJump.Size = New System.Drawing.Size(75, 23)
        Me.btnJump.TabIndex = 13
        Me.btnJump.Text = "Jump"
        Me.btnJump.UseVisualStyleBackColor = True
        '
        'Btn_Leap
        '
        Me.Btn_Leap.Location = New System.Drawing.Point(527, 339)
        Me.Btn_Leap.Name = "Btn_Leap"
        Me.Btn_Leap.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Leap.TabIndex = 14
        Me.Btn_Leap.Text = "Leap"
        Me.Btn_Leap.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 425)
        Me.Controls.Add(Me.Btn_Leap)
        Me.Controls.Add(Me.btnJump)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnRunRight)
        Me.Controls.Add(Me.btnRunLeft)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Overdrive Ostrich"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnStop As Button
    Friend WithEvents btnRunRight As Button
    Friend WithEvents btnRunLeft As Button
    Friend WithEvents lbl As Label
    Friend WithEvents lblX As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblY As Label
    Friend WithEvents Timer As Timer
    Friend WithEvents btnJump As Button
    Friend WithEvents Btn_Leap As Button
End Class
