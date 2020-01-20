Public Class Timer

    Public Event TimerValueChanged(ByVal value As Integer)

    Private Sub RestrictLimit(ByVal value As Integer) Handles Me.TimerValueChanged
        If value > 3600 Then
            NaOne.Value = 0
            NaTen.Value = 6
            ViOne.Value = 0
            ViTen.Value = 0
        End If
    End Sub

    Private _TimerValue As Integer = 0
    Public ReadOnly Property TimerValue As Integer
        Get
            Return _TimerValue
        End Get
    End Property


    Public Sub SelectNext()
        If ViTen.IsTimerJogFocused Then
            NaTen.IsTimerJogFocused = False
            NaOne.IsTimerJogFocused = False
            ViTen.IsTimerJogFocused = False
            ViOne.IsTimerJogFocused = True
        End If
        If NaOne.IsTimerJogFocused Then
            NaTen.IsTimerJogFocused = False
            NaOne.IsTimerJogFocused = False
            ViTen.IsTimerJogFocused = True
            ViOne.IsTimerJogFocused = False
        End If
        If NaTen.IsTimerJogFocused Then
            NaTen.IsTimerJogFocused = False
            NaOne.IsTimerJogFocused = True
            ViTen.IsTimerJogFocused = False
            ViOne.IsTimerJogFocused = False
        End If
    End Sub

    Public Sub SelectPrev()
        If NaOne.IsTimerJogFocused Then
            NaTen.IsTimerJogFocused = True
            NaOne.IsTimerJogFocused = False
            ViTen.IsTimerJogFocused = False
            ViOne.IsTimerJogFocused = False
        End If
        If ViTen.IsTimerJogFocused Then
            NaTen.IsTimerJogFocused = False
            NaOne.IsTimerJogFocused = True
            ViTen.IsTimerJogFocused = False
            ViOne.IsTimerJogFocused = False
        End If
        If ViOne.IsTimerJogFocused Then
            NaTen.IsTimerJogFocused = False
            NaOne.IsTimerJogFocused = False
            ViTen.IsTimerJogFocused = True
            ViOne.IsTimerJogFocused = False
        End If
    End Sub

    Private Sub MyBase_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ResetValues()
    End Sub

    Public Sub IncrementValue()
        If NaTen.IsTimerJogFocused Then
            NaTen.IncrementValue()
        ElseIf NaOne.IsTimerJogFocused Then
            NaOne.IncrementValue()
        ElseIf ViTen.IsTimerJogFocused Then
            ViTen.IncrementValue()
        ElseIf ViOne.IsTimerJogFocused Then
            ViOne.IncrementValue()
        End If
    End Sub

    Public Sub DecrementValue()
        If NaTen.IsTimerJogFocused Then
            NaTen.DecrementValue()
        ElseIf NaOne.IsTimerJogFocused Then
            NaOne.DecrementValue()
        ElseIf ViTen.IsTimerJogFocused Then
            ViTen.DecrementValue()
        ElseIf ViOne.IsTimerJogFocused Then
            ViOne.DecrementValue()
        End If
    End Sub

    Public Sub ResetValues()
        NaTen.Value = 0
        NaOne.Value = 0
        ViTen.Value = 0
        ViOne.Value = 0
        LooseFocus()
    End Sub

    Public Sub LooseFocus()
        NaTen.IsTimerJogFocused = True
        NaOne.IsTimerJogFocused = False
        ViTen.IsTimerJogFocused = False
        ViOne.IsTimerJogFocused = False
    End Sub

    Private Sub NaTen_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles NaTen.MouseMove
        NaTen.IsTimerJogFocused = True
        NaOne.IsTimerJogFocused = False
        ViTen.IsTimerJogFocused = False
        ViOne.IsTimerJogFocused = False
    End Sub

    Private Sub NaOne_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles NaOne.MouseMove
        NaTen.IsTimerJogFocused = False
        NaOne.IsTimerJogFocused = True
        ViTen.IsTimerJogFocused = False
        ViOne.IsTimerJogFocused = False
    End Sub

    Private Sub ViTen_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles ViTen.MouseMove
        NaTen.IsTimerJogFocused = False
        NaOne.IsTimerJogFocused = False
        ViTen.IsTimerJogFocused = True
        ViOne.IsTimerJogFocused = False
    End Sub

    Private Sub ViOne_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles ViOne.MouseMove
        NaTen.IsTimerJogFocused = False
        NaOne.IsTimerJogFocused = False
        ViTen.IsTimerJogFocused = False
        ViOne.IsTimerJogFocused = True
    End Sub

    Private Sub UserControl_MouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles MyBase.MouseLeave
        LooseFocus()
    End Sub

    Dim naonevalue As Integer = 0
    Dim natenvalue As Integer = 0
    Dim vionevalue As Integer = 0
    Dim vitenvalue As Integer = 0

    Private Sub NaOne_ValueChanged(ByVal value As Integer) Handles NaOne.ValueChanged
        naonevalue = value
        _TimerValue = ((natenvalue * 10) + naonevalue) * 60 + ((vitenvalue * 10) + vionevalue)
        RaiseEvent TimerValueChanged(_TimerValue)
    End Sub

    Private Sub NaTen_ValueChanged(ByVal value As Integer) Handles NaTen.ValueChanged
        natenvalue = value
        _TimerValue = ((natenvalue * 10) + naonevalue) * 60 + ((vitenvalue * 10) + vionevalue)
        RaiseEvent TimerValueChanged(_TimerValue)
    End Sub

    Private Sub ViOne_ValueChanged(ByVal value As Integer) Handles ViOne.ValueChanged
        vionevalue = value
        _TimerValue = ((natenvalue * 10) + naonevalue) * 60 + ((vitenvalue * 10) + vionevalue)
        RaiseEvent TimerValueChanged(_TimerValue)
    End Sub

    Private Sub ViTen_ValueChanged(ByVal value As Integer) Handles ViTen.ValueChanged
        vitenvalue = value
        _TimerValue = ((natenvalue * 10) + naonevalue) * 60 + ((vitenvalue * 10) + vionevalue)
        RaiseEvent TimerValueChanged(_TimerValue)
    End Sub
End Class
