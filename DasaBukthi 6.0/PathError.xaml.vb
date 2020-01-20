Public Class PathError
    Public Event PathamSelected(ByVal p As Integer)

    Private Sub btnp4_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnp4.Click
        RaiseEvent PathamSelected(4)
    End Sub

    Private Sub btnp1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnp1.Click
        RaiseEvent PathamSelected(1)
    End Sub
End Class
