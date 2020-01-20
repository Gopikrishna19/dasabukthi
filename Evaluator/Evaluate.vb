
Public Class Evaluate
    Private naksvalue As Integer = 0
    Private udnavalue As Integer = 0
    Private munavalue As Integer = 0
    Private nairvalue As Integer = 0
    Private selluvalue As Double = 0.0
    Private irupuvalue As Double = 0.0

    Public WriteOnly Property Naks As Integer
        Set(ByVal value As Integer)
            naksvalue = value
        End Set
    End Property
    Public WriteOnly Property UdNa As Integer
        Set(ByVal value As Integer)
            udnavalue = value
        End Set
    End Property
    Public WriteOnly Property MuNa As Integer
        Set(ByVal value As Integer)
            munavalue = value
        End Set
    End Property
    Public WriteOnly Property NaIr As Integer
        Set(ByVal value As Integer)
            nairvalue = value
        End Set
    End Property

    Public Function Evaluate(ByVal reEval As Boolean, Optional ByVal patham As Integer = 1) As Result
        If naksvalue = 0 Then
            Return Result.NaksError
        End If
        If udnavalue = nairvalue Or munavalue = udnavalue Then
            Return Result.TimeError
        End If
        If udnavalue > nairvalue And udnavalue < munavalue Then
            Return Result.TimeError
        End If
        Dim f As Integer
        Dim s As Integer
        Dim i As Integer
        s = udnavalue - munavalue '950 - 350 = 600
        If s < 0 Then
            s += 3600               'x
        End If
        f = nairvalue - munavalue + 3600 '3600 - 350 + 3600 = 6850
        If f > 4000 And Not reEval Then ' yes
            Return Result.SameError
        End If
        'MsgBox(f.ToString)
        If f > 4000 Then 'And reEval And Not nairvalue = 3600 Then ' 3250
            f -= 3600
            GoTo a
        End If
        If udnavalue > munavalue And udnavalue < nairvalue Then
            If Not reEval Then
                Return Result.PathError
            Else
                If patham = 4 Then
                    s += 3600
                End If
            End If
        End If
a:      i = f - s
        selluvalue = s * naksvalue / f
        irupuvalue = i * naksvalue / f
        'MsgBox(selluvalue.ToString + " " + irupuvalue.ToString + " " + f.ToString)
        Return Result.Success
    End Function

    Public ReadOnly Property Sellu As Double
        Get
            Return selluvalue
        End Get
    End Property
    Public ReadOnly Property Iruppu As Double
        Get
            Return irupuvalue
        End Get
    End Property
End Class
