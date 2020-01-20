Public Class Nakshathram
    Dim Naks As String() = _
    {
        "Ashwini", "Barani", "Karthigai", "Rohini", "Mirugasheersham", "Thiruvadhirai", "Punarpoosam",
        "Poosam", "Aayilyam", "Magham", "Pooram", "Uthiram", "Hastham", "Chitthirai", "Swathi",
        "Vishakam", "Anusham", "Kettai", "Moolam", "Pooradam", "Utthiradam", "Thiruvonam", "Avittam",
        "Sadhayam", "Poorattadhi", "Utthirattadhi", "Revathi"
    }
    Dim Dasai As String() = _
    {
        "Kethu", "Sukra", "Surya", "Chandra", "Chevvai", "Raaghu", "Guru", "Sani", "Bhudhan"
    }

    Public ReadOnly Property getPrevNaks As String
        Get
            If SelectedIndex > 0 And SelectedIndex < 27 Then
                Return Naks(SelectedIndex - 1)
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property getCurrNaks As String
        Get
            If SelectedIndex > -1 And SelectedIndex < 27 Then
                Return Naks(SelectedIndex)
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property getNextNaks As String
        Get
            If SelectedIndex > -1 And SelectedIndex < 26 Then
                Return Naks(SelectedIndex + 1)
            End If
            Return ""
        End Get
    End Property

    Private _Index As Integer
    Public Property SelectedIndex As Integer
        Get
            Return _Index
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                value = 0
            End If
            If value > 26 Then
                value = 26
            End If
            _Index = value
        End Set
    End Property

    Public ReadOnly Property GetDasaiName As String
        Get
            Select Case (_Index Mod 9)
                Case 0
                    Return Dasai(0)
                Case 1
                    Return Dasai(1)
                Case 2
                    Return Dasai(2)
                Case 3
                    Return Dasai(3)
                Case 4
                    Return Dasai(4)
                Case 5
                    Return Dasai(5)
                Case 6
                    Return Dasai(6)
                Case 7
                    Return Dasai(7)
                Case 8
                    Return Dasai(8)
            End Select
            Return ""
        End Get
    End Property

    Public ReadOnly Property GetDasaiYear As Integer
        Get
            Select Case (_Index Mod 9)
                Case 0
                    Return 7
                Case 1
                    Return 20
                Case 2
                    Return 6
                Case 3
                    Return 10
                Case 4
                    Return 7
                Case 5
                    Return 18
                Case 6
                    Return 16
                Case 7
                    Return 19
                Case 8
                    Return 17
            End Select
            Return ""
        End Get
    End Property
End Class
