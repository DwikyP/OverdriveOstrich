Public Enum TStateOverdriveOstrich
    intro
    stand
    run
    jump
    brake
    run_in_bg
    shoot
    drop
    leap
End Enum

Structure Character
    Public posX, posY As Integer
    Public Vx, Vy, Ax, Ay As Integer
    Public CurrentState As TStateOverdriveOstrich
    Public FrameIndex As Integer
    Public FrameTimer As Integer
End Structure

Public Class Form1
    Dim bmp As New Drawing.Bitmap(512, 256)
    Dim gfx As Graphics = Graphics.FromImage(bmp)
    Dim background As Bitmap = Bitmap.FromFile("bg.png")
    Dim SpritSheet As Bitmap = Bitmap.FromFile("Overdrive Ostrich.png")
    Dim MaskSS As Bitmap = Bitmap.FromFile("MaskOverdrive Ostrich.png")

    Dim backgroundX, backgroundY As Integer 'center point of background
    Dim Direction As String = "right"

    Dim sprite As Character
    Dim ElmtFrame As TElementFrame
    Public First As TElementFrame

    Dim BtnClicked As Boolean = False
    Dim BackgroundPos As Integer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BackgroundPos = 0

        backgroundX = PictureBox1.Width / 2
        backgroundY = PictureBox1.Height / 2

        Intro()

        Timer.Enabled = True

    End Sub

    Private Sub push(newCenterPoint As Point, newTop As Integer, newBottom As Integer, newLeft As Integer, newRight As Integer, newIndex As Integer, newMaxFrameTimer As Integer)
        Dim newNode As TElementFrame = New TElementFrame(newCenterPoint, newTop, newBottom, newLeft, newRight, newIndex, newMaxFrameTimer)

        newNode.nextFrame = First

        First = newNode
    End Sub

    Private Sub deleteList()
        First = Nothing
    End Sub

    Private Sub SetChar(ByVal Vx, ByVal Vy, ByVal PosX, ByVal PosY)
        sprite.Vx = Vx
        sprite.Vy = Vy
        sprite.posX = PosX
        sprite.posY = PosY
    End Sub

    Sub BitBlittingFlip(ByVal Mask As Bitmap, ByVal Sprite As Bitmap, ByVal Background As Bitmap, ByVal PosX As Integer, ByVal PosY As Integer)
        Dim spColor As Color
        Dim black As Color = Color.Black
        Dim counterX = 0
        Dim counterY = 0
        Dim Px = 0
        Dim Py = 0

        '''''''ANDing Operation
        For y = ElmtFrame.Top To ElmtFrame.Bottom - 1
            For x = ElmtFrame.Right To ElmtFrame.Left Step -1
                spColor = Mask.GetPixel(x, y)
                If spColor.ToArgb = black.ToArgb Then
                    Px = counterX + PosX
                    Py = counterY + PosY
                    If ((Px >= 0) And (Px < bmp.Width) And (Py >= 0) And (Py < bmp.Height)) Then
                        bmp.SetPixel(Px, Py, spColor)
                    End If
                End If
                counterX += 1
            Next
            counterX = 0
            counterY += 1
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        counterX = 0
        counterY = 0
        Px = 0
        Py = 0
        ''''''''ORing Operation
        For y = ElmtFrame.Top To ElmtFrame.Bottom - 1
            For x = ElmtFrame.Right To ElmtFrame.Left Step -1
                spColor = Sprite.GetPixel(x, y)
                If spColor.ToArgb <> black.ToArgb Then
                    Px = counterX + PosX
                    Py = counterY + PosY
                    If ((Px >= 0) And (Px < bmp.Width) And (Py >= 0) And (Py < bmp.Height)) Then
                        bmp.SetPixel(Px, Py, spColor)
                    End If
                End If
                counterX += 1
            Next
            counterX = 0
            counterY += 1
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Sub BitBlitting(ByVal Mask As Bitmap, ByVal Sprite As Bitmap, ByVal Background As Bitmap, ByVal PosX As Integer, ByVal PosY As Integer)
        Dim spColor As Color
        Dim black As Color = Color.Black
        Dim counterX = 0
        Dim counterY = 0
        Dim Px = 0
        Dim Py = 0

        '''''''ANDing Operation
        For y = ElmtFrame.Top To ElmtFrame.Bottom - 1
            For x = ElmtFrame.Left To ElmtFrame.Right - 1
                spColor = Mask.GetPixel(x, y)
                If spColor.ToArgb = black.ToArgb Then
                    Px = counterX + PosX
                    Py = counterY + PosY
                    If ((Px >= 0) And (Px < bmp.Width) And (Py >= 0) And (Py < bmp.Height)) Then
                        bmp.SetPixel(Px, Py, spColor)
                    End If
                End If
                counterX += 1
            Next
            counterX = 0
            counterY += 1
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        counterX = 0
        counterY = 0
        Px = 0
        Py = 0
        ''''''''ORing Operation
        For y = ElmtFrame.Top To ElmtFrame.Bottom - 1
            For x = ElmtFrame.Left To ElmtFrame.Right - 1
                spColor = Sprite.GetPixel(x, y)
                If spColor.ToArgb <> black.ToArgb Then
                    Px = counterX + PosX
                    Py = counterY + PosY
                    If ((Px >= 0) And (Px < bmp.Width) And (Py >= 0) And (Py < bmp.Height)) Then
                        bmp.SetPixel(Px, Py, spColor)
                    End If
                End If
                counterX += 1
            Next
            counterX = 0
            counterY += 1
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub StartAnim()
        gfx.DrawImage(background, BackgroundPos, 0)
        '''''''''''''''''''''''INTRO''''''''''''''''''''''''''''''''''''''''''''''''
        If sprite.CurrentState = TStateOverdriveOstrich.intro Then
            If Direction = "right" Then
                If sprite.FrameIndex = 2 And sprite.posX <= backgroundX - 50 Then
                    ResetAnimation()
                End If
            ElseIf Direction = "left" Then
                If sprite.FrameIndex = 2 And sprite.posX >= backgroundX Then
                    ResetAnimation()
                End If
            End If
            If sprite.FrameIndex >= 3 And sprite.FrameIndex < 11 Then
                If sprite.posY < -70 Then
                    sprite.Vx = 0
                    sprite.Vy = 0
                Else
                    sprite.Vx = 0
                    sprite.Vy = -13
                End If
            End If
            If sprite.FrameIndex = 11 Or sprite.FrameIndex = 12 Or sprite.FrameIndex = 13 Then
                sprite.Vy = 10
            End If
            If sprite.FrameIndex > 13 Then
                sprite.Vy = 0
            End If
            If Direction = "right" Then
                BitBlitting(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
            Else
                BitBlittingFlip(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
            End If
            sprite.posX += sprite.Vx
            sprite.posY += sprite.Vy
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''STAND'''''''''''''''''''''''''''''''''''''''''
        ElseIf sprite.CurrentState = TStateOverdriveOstrich.stand Then
            sprite.posY = 150
            If Direction = "right" Then
                BitBlitting(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
            ElseIf Direction = "left" Then
                BitBlittingFlip(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''RUN''''''''''''''''''''''''''''''''''''''
        ElseIf sprite.CurrentState = TStateOverdriveOstrich.run Then
            sprite.posY = 165
            If Direction = "right" Then
                BitBlittingFlip(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                PictureBox1.Image = bmp
                If BackgroundPos > -500 And sprite.posX >= backgroundX - 50 Then
                    BackgroundPos -= sprite.Vx
                Else
                    sprite.posX += sprite.Vx
                End If
            ElseIf Direction = "left" Then
                BitBlitting(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                PictureBox1.Image = bmp
                If BackgroundPos < 0 And sprite.posX <= backgroundX Then
                    BackgroundPos -= sprite.Vx
                Else
                    sprite.posX += sprite.Vx
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''BRAKE'''''''''''''''''''''''''''''''''''''''''''''
        ElseIf sprite.CurrentState = TStateOverdriveOstrich.brake Then
            sprite.posY = 150
            If Direction = "right" Then
                BitBlitting(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                PictureBox1.Image = bmp
                If BackgroundPos > -500 And sprite.posX >= backgroundX - 50 Then
                    BackgroundPos -= sprite.Vx
                    sprite.Vx -= sprite.Ax
                Else
                    sprite.posX += sprite.Vx
                    sprite.Vx -= sprite.Ax
                End If
            ElseIf Direction = "left" Then
                BitBlittingFlip(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                PictureBox1.Image = bmp
                If BackgroundPos < 0 And sprite.posX <= backgroundX Then
                    BackgroundPos += sprite.Vx
                    sprite.Vx -= sprite.Ax
                Else
                    sprite.posX -= sprite.Vx
                    sprite.Vx -= sprite.Ax
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''JUMP''''''''''''''''''''''''''''''''''''''''''''
        ElseIf sprite.CurrentState = TStateOverdriveOstrich.jump Then
            If sprite.FrameIndex = 0 Then
                sprite.posY = 118
            ElseIf sprite.FrameIndex > 0 And sprite.FrameIndex <= 2 Then
                sprite.posY -= 10
            ElseIf sprite.FrameIndex >= 3 Then
                sprite.posY += 7
            End If
            If Direction = "right" Then
                BitBlitting(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                PictureBox1.Image = bmp
                If BackgroundPos > -500 And sprite.posX >= backgroundX - 50 Then
                    BackgroundPos -= sprite.Vx
                Else
                    sprite.posX += sprite.Vx
                End If
            ElseIf Direction = "left" Then
                BitBlittingFlip(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                PictureBox1.Image = bmp
                If BackgroundPos < 0 And sprite.posX <= backgroundX Then
                    BackgroundPos += sprite.Vx
                Else
                    sprite.posX -= sprite.Vx
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''LEAP''''''''''''''''''''''''''''''''''''''''''''''''''''
        ElseIf sprite.CurrentState = TStateOverdriveOstrich.leap Then
            If Direction = "right" Then
                BitBlittingFlip(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                If sprite.posX <= backgroundX And sprite.FrameIndex >= 2 Then
                    sprite.posX += sprite.Vx
                End If
            ElseIf Direction = "left" Then
                BitBlitting(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
                If sprite.posX >= backgroundX And sprite.FrameIndex >= 2 Then
                    sprite.posX += sprite.Vx
                End If
            End If
            If sprite.posY > 30 And sprite.FrameIndex >= 2 And sprite.FrameIndex < 6 Then
                sprite.posY += sprite.Vy
            ElseIf sprite.posY < 145 And sprite.FrameIndex >= 6 Then
                sprite.posY -= sprite.Vy
            End If
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        PictureBox1.Image = bmp
    End Sub

    Private Sub ChangeState(ByVal CurrentState)
        sprite.CurrentState = CurrentState
    End Sub

    Private Sub ResetAnimation()
        ElmtFrame = First
    End Sub

    Private Function OffScreen(ByVal PosX, ByVal PosY) As Boolean
        Dim Left, Right As Integer
        Dim Width, Height As Integer

        Width = ElmtFrame.Right - ElmtFrame.Left
        Height = ElmtFrame.Bottom - ElmtFrame.Top

        Left = PosX
        Right = PosX + Width

        If Left < 0 And Right < 0 Or Left > PictureBox1.Width And Right > PictureBox1.Width Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnRunLeft_Click(sender As Object, e As EventArgs) Handles btnRunLeft.Click
        If sprite.CurrentState = TStateOverdriveOstrich.stand Then
            If Direction = "right" Then
                Direction = "left"
            End If

            sprite.CurrentState = TStateOverdriveOstrich.run
            deleteList()

            push(New Point(750, 210), 175, 245, 691, 809, 6, 1)
            push(New Point(636, 210), 175, 245, 577, 695, 5, 1)
            push(New Point(521, 210), 175, 245, 462, 580, 4, 1)
            push(New Point(406, 210), 175, 245, 347, 465, 3, 1)
            push(New Point(291, 210), 175, 245, 232, 350, 2, 1)
            push(New Point(175, 210), 175, 245, 116, 234, 1, 1)
            push(New Point(61, 210), 175, 245, 2, 120, 0, 1)

            ElmtFrame = First
            sprite.posX -= 10
            sprite.Vx = -10
            sprite.Ax = 0
            sprite.FrameTimer = 0
            sprite.FrameIndex = ElmtFrame.index
        End If
    End Sub

    Private Sub btnRunRight_Click(sender As Object, e As EventArgs) Handles btnRunRight.Click
        If sprite.CurrentState = TStateOverdriveOstrich.stand Then
            If Direction = "left" Then
                Direction = "right"
            End If

            sprite.CurrentState = TStateOverdriveOstrich.run
            deleteList()

            push(New Point(750, 210), 175, 245, 691, 809, 6, 1)
            push(New Point(636, 210), 175, 245, 577, 695, 5, 1)
            push(New Point(521, 210), 175, 245, 462, 580, 4, 1)
            push(New Point(406, 210), 175, 245, 347, 465, 3, 1)
            push(New Point(291, 210), 175, 245, 232, 350, 2, 1)
            push(New Point(175, 210), 175, 245, 116, 234, 1, 1)
            push(New Point(61, 210), 175, 245, 2, 120, 0, 1)

            ElmtFrame = First
            sprite.posX -= 40

            sprite.Vx = 10
            sprite.Ax = 0
            sprite.FrameTimer = 0
            sprite.FrameIndex = ElmtFrame.index
        End If

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If sprite.CurrentState = TStateOverdriveOstrich.run Or sprite.CurrentState = TStateOverdriveOstrich.jump Then
            If sprite.CurrentState = TStateOverdriveOstrich.jump Then
                BtnClicked = True
            ElseIf sprite.CurrentState = TStateOverdriveOstrich.run Then
                Braking()
                If Direction = "right" Then
                    sprite.posX += 50
                End If
            End If
        End If
    End Sub

    Private Sub btnJump_Click(sender As Object, e As EventArgs) Handles btnJump.Click
        If sprite.CurrentState = TStateOverdriveOstrich.stand Then
            sprite.CurrentState = TStateOverdriveOstrich.jump
            deleteList()

            push(New Point(242, 280), 237, 323, 213, 272, 4, 4)
            push(New Point(190, 280), 237, 323, 165, 215, 3, 1)
            push(New Point(144, 280), 237, 323, 120, 168, 2, 1)
            push(New Point(98, 280), 237, 323, 74, 122, 1, 1)
            push(New Point(45, 280), 237, 323, 14, 76, 0, 1)

            ElmtFrame = First
            sprite.Vx = 10
            sprite.Ax = 0
            sprite.FrameTimer = 0
            sprite.FrameIndex = ElmtFrame.index
        End If
    End Sub

    Sub Braking()
        sprite.CurrentState = TStateOverdriveOstrich.brake
        deleteList()

        push(New Point(248, 519), 483, 555, 224, 272, 4, 4)
        push(New Point(199, 519), 483, 555, 175, 223, 3, 1)
        push(New Point(146, 519), 483, 555, 118, 173, 2, 1)
        push(New Point(89, 519), 483, 555, 62, 116, 1, 1)
        push(New Point(35, 519), 483, 555, 8, 62, 0, 1)

        ElmtFrame = First
        sprite.Vx = 11
        sprite.Ax = 2
        sprite.FrameTimer = 0
        sprite.FrameIndex = ElmtFrame.index
    End Sub

    Sub Intro()
        sprite.CurrentState = TStateOverdriveOstrich.intro
        deleteList()

        push(New Point(484, 128), 88, 160, 444, 524, 22, 9)
        push(New Point(416, 128), 88, 160, 390, 442, 21, 2)
        push(New Point(362, 128), 88, 160, 342, 382, 20, 2)
        push(New Point(311, 128), 88, 160, 286, 336, 19, 1)
        push(New Point(256, 138), 88, 160, 235, 277, 18, 1)
        push(New Point(205, 128), 88, 160, 184, 226, 17, 1)
        push(New Point(153, 128), 88, 160, 127, 179, 16, 5)
        push(New Point(91, 128), 88, 160, 64, 118, 15, 3)
        push(New Point(33, 128), 88, 160, 6, 60, 14, 1)
        push(New Point(559, 41), 2, 80, 526, 592, 13, 9)
        push(New Point(494, 41), 2, 80, 461, 527, 12, 13)
        push(New Point(431, 41), 2, 80, 413, 446, 11, 10)
        push(New Point(395, 41), 2, 80, 381, 409, 10, 1)
        push(New Point(363, 41), 2, 80, 352, 374, 9, 1)
        push(New Point(335, 41), 2, 80, 322, 348, 8, 1)
        push(New Point(308, 41), 2, 80, 299, 317, 7, 1)
        push(New Point(284, 41), 2, 80, 275, 293, 6, 1)
        push(New Point(261, 41), 2, 80, 252, 270, 5, 1)
        push(New Point(238, 41), 2, 80, 229, 247, 4, 1)
        push(New Point(205, 41), 2, 80, 187, 223, 3, 1)
        push(New Point(152, 41), 2, 80, 124, 180, 2, 1)
        push(New Point(96, 41), 2, 80, 68, 124, 1, 1)
        push(New Point(40, 41), 2, 80, 12, 68, 0, 1)

        If Direction = "right" Then
            sprite.Vx = 10
            sprite.Vy = 0
            sprite.posX = -100
            sprite.posY = 80
        ElseIf Direction = "left" Then
            sprite.Vx = -10
            sprite.Vy = 0
            sprite.posX = PictureBox1.Width + 100
            sprite.posY = 80
        End If

        ElmtFrame = First

        sprite.FrameTimer = 0
        sprite.FrameIndex = ElmtFrame.index
    End Sub

    Sub Stand()
        ChangeState(TStateOverdriveOstrich.stand)
        deleteList()

        push(New Point(39, 443), 408, 478, 11, 67, 0, 1)

        sprite.Vx = 0
        sprite.Ax = 0
        sprite.FrameTimer = 0

        ElmtFrame = First
    End Sub

    Private Sub Btn_Leap_Click(sender As Object, e As EventArgs) Handles Btn_Leap.Click
        If sprite.CurrentState = TStateOverdriveOstrich.stand Then
            If sprite.posX > backgroundX Then
                Direction = "left"
            Else
                Direction = "right"
            End If
            sprite.CurrentState = TStateOverdriveOstrich.leap
            deleteList()

            push(New Point(731, 363), 320, 406, 705, 757, 11, 2)
            push(New Point(675, 363), 320, 406, 649, 701, 10, 2)
            push(New Point(619, 363), 320, 406, 593, 645, 9, 2)
            push(New Point(562, 363), 320, 406, 537, 587, 8, 5)
            push(New Point(498, 363), 320, 406, 461, 535, 7, 5)
            push(New Point(426, 363), 320, 406, 389, 463, 6, 4)
            push(New Point(352, 363), 320, 406, 315, 389, 5, 3)
            push(New Point(289, 363), 320, 406, 266, 312, 4, 10)
            push(New Point(227, 363), 320, 406, 190, 264, 3, 12)
            push(New Point(161, 363), 320, 406, 131, 191, 2, 2)
            push(New Point(101, 363), 320, 406, 65, 137, 1, 2)
            push(New Point(38, 363), 320, 406, 1, 75, 0, 2)

            ElmtFrame = First
            sprite.Vx = (backgroundX - sprite.posX) / 10
            sprite.Vy = (30 - sprite.posY) / 10
            sprite.Ax = 0
            sprite.FrameTimer = 0
            sprite.FrameIndex = ElmtFrame.index
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        StartAnim()
        sprite.FrameTimer = sprite.FrameTimer + 1
        If sprite.FrameTimer >= ElmtFrame.MaxFrameTimer Then
            sprite.FrameIndex = ElmtFrame.index
            ElmtFrame = ElmtFrame.nextFrame
            sprite.FrameTimer = 0
            If ElmtFrame Is Nothing Then
                If sprite.CurrentState = TStateOverdriveOstrich.intro Then
                    Stand()
                ElseIf sprite.CurrentState = TStateOverdriveOstrich.stand Then
                    ResetAnimation()
                ElseIf sprite.CurrentState = TStateOverdriveOstrich.run Then
                    ResetAnimation()
                ElseIf sprite.CurrentState = TStateOverdriveOstrich.brake Then
                    Stand()
                ElseIf sprite.CurrentState = TStateOverdriveOstrich.jump Then
                    If BtnClicked Then
                        BtnClicked = False
                        Braking()
                    Else
                        ResetAnimation()
                    End If
                ElseIf sprite.CurrentState = TStateOverdriveOstrich.leap Then
                    ChangeState(TStateOverdriveOstrich.stand)
                    deleteList()
                    push(New Point(39, 443), 408, 478, 11, 67, 0, 1)
                    ElmtFrame = First
                End If
                If OffScreen(sprite.posX, sprite.posY) Then
                    If Direction = "left" Then
                        Direction = "right"
                    ElseIf Direction = "right" Then
                        Direction = "left"
                    End If
                    Intro()
                End If
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        lblX.Text = e.X
        lblY.Text = e.Y
    End Sub

End Class