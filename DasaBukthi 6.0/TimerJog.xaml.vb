Public Class TimerJog

    Public Event ValueChanged(ByVal value As Integer)

    Private _IsThisFocused As Boolean = False
    Public Property IsTimerJogFocused As Boolean
        Get
            Return _IsThisFocused
        End Get
        Set(ByVal value As Boolean)
            Dim bc As New BrushConverter
            If value Then
                focusUp.Background = bc.ConvertFrom("#7E002104")
                focusDown.Background = bc.ConvertFrom("#7E002104")
            Else
                focusUp.Background = bc.ConvertFrom("#00002104")
                focusDown.Background = bc.ConvertFrom("#00002104")
            End If
            _IsThisFocused = value
        End Set
    End Property

    Private _LLimit As Integer
    Public Property LowerLimit As Integer
        Get
            Return _LLimit
        End Get
        Set(ByVal value As Integer)
            _LLimit = value
        End Set
    End Property

    Private _ULimit As Integer
    Public Property UpperLimit As Integer
        Get
            Return _ULimit
        End Get
        Set(ByVal value As Integer)
            _ULimit = value
        End Set
    End Property

    Private _Index As Integer = 0
    Public Property Value As Integer
        Set(ByVal value As Integer)
            _Index = value
            JogValue.Text = _Index.ToString
        End Set
        Get
            Return _Index
        End Get

    End Property

    Private Sub IncrBtn_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles IncrBtn.Click
        IncrementValue()
    End Sub

    Private Sub DecrBtn_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles DecrBtn.Click
        DecrementValue()
    End Sub

    Public Sub IncrementValue()
        _Index += 1
        If _Index > UpperLimit Then
            _Index = LowerLimit
        End If
        RaiseEvent ValueChanged(_Index)
        JogValue.Text = _Index.ToString
    End Sub

    Public Sub DecrementValue()
        _Index -= 1
        If _Index < LowerLimit Then
            _Index = UpperLimit
        End If
        RaiseEvent ValueChanged(_Index)
        JogValue.Text = _Index.ToString
    End Sub

    Private Sub MyBase_MouseWheel(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseWheelEventArgs) Handles MyBase.MouseWheel
        If e.Delta > 0 Then
            IncrementValue()
        Else
            DecrementValue()
        End If
    End Sub
End Class
