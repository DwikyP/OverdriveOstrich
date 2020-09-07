Public Class TElementFrame
    Public CenterPoint As Point
    Public Top, Bottom, Left, Right As Integer
    Public index As Integer
    Public MaxFrameTimer As Integer
    Public nextFrame As TElementFrame

    Public Sub New(newCenterPoint As Point, newTop As Integer, newBottom As Integer, newLeft As Integer, newRight As Integer, newIndex As Integer, newMaxFrameTimer As Integer)
        CenterPoint = newCenterPoint
        Top = newTop
        Bottom = newBottom
        Left = newLeft
        Right = newRight
        index = newIndex
        MaxFrameTimer = newMaxFrameTimer
        nextFrame = Nothing
    End Sub
End Class