Imports System.Windows.Media.Animation
Imports Evaluator

Class MainWindow

#Region "Declarations"
    Dim NaksIsOpen As Boolean = False
    Dim UdNaIsOpen As Boolean = False
    Dim MuNaIsOpen As Boolean = False
    Dim NaIrIsOpen As Boolean = False
    Dim EvalIsOpen As Boolean = False
    Dim AboutIsOpen As Boolean = False
    Dim ExitIsOpen As Boolean = False
    Dim NErrIsOpen As Boolean = False
    Dim PathErrorReEval As Boolean = False
    Dim WithEvents patherrdiag As PathError
    Dim ev As Evaluate
    Dim nLister As Nakshathram

    Dim patham As Integer = 1
#End Region

#Region "Grid Naks"
    Private Sub gridNaks_MouseDown() Handles gridNaks.MouseDown
        If NaksIsOpen = False Then
            CloseOtherTabs("Naks")
            OpenOrCLoseTab("Naks", True)
            NaksIsOpen = True
        Else
            OpenOrCLoseTab("Naks", False)
            NaksIsOpen = False
        End If
        Me.Focus()
    End Sub

    Private Sub gridNaks_MouseEnter() Handles gridNaks.MouseEnter
        SetTabOpacity("Naks", False)
    End Sub

    Private Sub gridNaks_MouseLeave() Handles gridNaks.MouseLeave
        SetTabOpacity("Naks", True)
    End Sub
#End Region

#Region "Grid UdNa"
    Private Sub gridUdNa_MouseDown() Handles gridUdNa.MouseDown
        If UdNaIsOpen = False Then
            CloseOtherTabs("UdNa")
            OpenOrCLoseTab("UdNa", True)
            UdNaIsOpen = True
        Else
            OpenOrCLoseTab("UdNa", False)
            UdNaIsOpen = False
            UdNaTimer.LooseFocus()
        End If
        Me.Focus()
    End Sub

    Private Sub gridUdNa_MouseEnter() Handles gridUdNa.MouseEnter
        SetTabOpacity("UdNa", False)
    End Sub

    Private Sub gridUdNa_MouseLeave() Handles gridUdNa.MouseLeave
        SetTabOpacity("UdNa", True)
    End Sub
#End Region

#Region "Grid MuNa"
    Private Sub gridMuNa_MouseDown() Handles gridMuNa.MouseDown
        If MuNaIsOpen = False Then
            CloseOtherTabs("MuNa")
            OpenOrCLoseTab("MuNa", True)
            MuNaIsOpen = True
        Else
            OpenOrCLoseTab("MuNa", False)
            MuNaIsOpen = False
        End If
        Me.Focus()
    End Sub

    Private Sub gridMuNa_MouseEnter() Handles gridMuNa.MouseEnter
        SetTabOpacity("MuNa", False)
    End Sub

    Private Sub gridMuNa_MouseLeave() Handles gridMuNa.MouseLeave
        SetTabOpacity("MuNa", True)
    End Sub
#End Region

#Region "Grid NaIr"
    Private Sub gridNaIr_MouseDown() Handles gridNaIr.MouseDown
        If NaIrIsOpen = False Then
            CloseOtherTabs("NaIr")
            OpenOrCLoseTab("NaIr", True)
            NaIrIsOpen = True
        Else
            OpenOrCLoseTab("NaIr", False)
            NaIrIsOpen = False
        End If
        Me.Focus()
    End Sub

    Private Sub gridNaIr_MouseEnter() Handles gridNaIr.MouseEnter
        SetTabOpacity("NaIr", False)
    End Sub

    Private Sub gridNaIr_MouseLeave() Handles gridNaIr.MouseLeave
        SetTabOpacity("NaIr", True)
    End Sub
#End Region

#Region "Grid Eval"
    Private Sub gridEval_MouseDown() Handles gridEval.MouseDown
        If EvalIsOpen = False Then
            CloseOtherTabs("Eval")
            OpenOrCLoseTab("Eval", True)
            EvalIsOpen = True
            Calculate()
        Else
            OpenOrCLoseTab("Eval", False)
            EvalIsOpen = False
        End If
        Me.Focus()
    End Sub

    Private Sub gridEval_MouseEnter() Handles gridEval.MouseEnter
        SetTabOpacity("Eval", False)
    End Sub

    Private Sub gridEval_MouseLeave() Handles gridEval.MouseLeave
        SetTabOpacity("Eval", True)
    End Sub
#End Region

#Region "Grid About"
    Private Sub gridAbout_MouseDown() Handles gridAbout.MouseDown
        If AboutIsOpen = False Then
            CloseOtherTabs("About")
            OpenOrCLoseTab("About", True)
            AboutIsOpen = True
        Else
            OpenOrCLoseTab("About", False)
            AboutIsOpen = False
        End If
        Me.Focus()
    End Sub

    Private Sub gridAbout_MouseEnter() Handles gridAbout.MouseEnter
        SetTabOpacity("About", False)
    End Sub

    Private Sub gridAbout_MouseLeave() Handles gridAbout.MouseLeave
        SetTabOpacity("About", True)
    End Sub

    Private Sub CreditGrid_MouseEnter() Handles CreditGrid.MouseEnter
        Dim a As Storyboard = DirectCast(FindResource("AboutGridCreditAnimation"), Storyboard)
        a.Pause()
    End Sub

    Private Sub CreditGrid_MouseLeave() Handles CreditGrid.MouseLeave
        Dim a As Storyboard = DirectCast(FindResource("AboutGridCreditAnimation"), Storyboard)
        a.Resume()
    End Sub
#End Region

#Region "Grid Exit"
    Private Sub gridExit_MouseDown() Handles gridExit.MouseDown
        If ExitIsOpen = False Then
            CloseOtherTabs("Exit")
            OpenOrCLoseTab("Exit", True)
            ExitIsOpen = True
        Else
            OpenOrCLoseTab("Exit", False)
            ExitIsOpen = False
        End If
        Me.Focus()
    End Sub

    Private Sub gridExit_MouseEnter() Handles gridExit.MouseEnter
        SetTabOpacity("Exit", False)
    End Sub

    Private Sub gridExit_MouseLeave() Handles gridExit.MouseLeave
        SetTabOpacity("Exit", True)
    End Sub

    Private Sub btnExitYes_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnExitYes.Click
        End
    End Sub

    Private Sub btnExitCancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnExitCancel.Click
        OpenOrCLoseTab("Exit", False)
        ExitIsOpen = False
    End Sub

    Private Sub btnExitReset_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnExitReset.Click
        loadDasaBukthi()
    End Sub
#End Region

#Region "Grid ErrorNav"
    Private Sub ErrorNav_MouseDown() Handles ErrorNav.MouseDown
        NErrIsOpen = False
        ErrorNav.Navigate(Nothing)
        ErrorNav.Visibility = Windows.Visibility.Hidden
        If PathErrorReEval Then
            PathErrorReEval = False
            Calculate(True)
        End If
        Me.Focus()
    End Sub
#End Region

    ''' <summary>
    ''' Sets the opacity for the tab with given key
    ''' </summary>
    ''' <param name="key">The key of the tab for which the opacity is to be set</param>
    ''' <param name="MouseLeave">Is the mouse leaving or entering the tab?</param>
    ''' <remarks></remarks>
    Private Sub SetTabOpacity(ByVal key As String, ByVal MouseLeave As Boolean)
        Dim Anim As Storyboard
        If MouseLeave Then
            Anim = DirectCast(FindResource("OnMouseLeave"), Storyboard)
        Else
            Anim = DirectCast(FindResource("OnMouseEnter"), Storyboard)
        End If
        Storyboard.SetTargetName(Anim, "grid" + key)
        Anim.Begin()
    End Sub

    ''' <summary>
    ''' Begins the animation storyboard for the desired key-tab
    ''' </summary>
    ''' <param name="key">The key of the tab that is to be animated</param>
    ''' <param name="open">True to open the key-tab and False to close it.</param>
    ''' <remarks></remarks>
    Private Sub OpenOrCLoseTab(ByVal key As String, ByVal open As Boolean)
        Dim Anim As Storyboard
        Dim a As Storyboard
        If open Then
            Anim = DirectCast(FindResource("OnMouseDownOpen" + key), Storyboard)
            If key = "About" Then
                a = DirectCast(FindResource("AboutGridCreditAnimation"), Storyboard)
                a.Begin()
            End If
        Else
            Anim = DirectCast(FindResource("OnMouseDownClose" + key), Storyboard)
            If key = "About" Then
                a = DirectCast(FindResource("AboutGridCreditAnimation"), Storyboard)
                a.Stop()
            End If
        End If
        Anim.Begin()
    End Sub

    ''' <summary>
    ''' Closes the other key-tabs
    ''' </summary>
    ''' <param name="key">The key of the tab that is to be stayed open</param>
    ''' <remarks></remarks>
    Private Sub CloseOtherTabs(ByVal key As String)
        Select Case (key)
            Case "Naks"
                If UdNaIsOpen Then
                    OpenOrCLoseTab("UdNa", False)
                    UdNaIsOpen = False
                End If
                If MuNaIsOpen Then
                    OpenOrCLoseTab("MuNa", False)
                    MuNaIsOpen = False
                End If
                If NaIrIsOpen Then
                    OpenOrCLoseTab("NaIr", False)
                    NaIrIsOpen = False
                End If
                If EvalIsOpen Then
                    OpenOrCLoseTab("Eval", False)
                    EvalIsOpen = False
                End If
                If AboutIsOpen Then
                    OpenOrCLoseTab("About", False)
                    AboutIsOpen = False
                End If
                If ExitIsOpen Then
                    OpenOrCLoseTab("Exit", False)
                    ExitIsOpen = False
                End If
            Case "UdNa"
                If NaksIsOpen Then
                    OpenOrCLoseTab("Naks", False)
                    NaksIsOpen = False
                End If
                If MuNaIsOpen Then
                    OpenOrCLoseTab("MuNa", False)
                    MuNaIsOpen = False
                End If
                If NaIrIsOpen Then
                    OpenOrCLoseTab("NaIr", False)
                    NaIrIsOpen = False
                End If
                If EvalIsOpen Then
                    OpenOrCLoseTab("Eval", False)
                    EvalIsOpen = False
                End If
                If AboutIsOpen Then
                    OpenOrCLoseTab("About", False)
                    AboutIsOpen = False
                End If
                If ExitIsOpen Then
                    OpenOrCLoseTab("Exit", False)
                    ExitIsOpen = False
                End If
            Case "MuNa"
                If NaksIsOpen Then
                    OpenOrCLoseTab("Naks", False)
                    NaksIsOpen = False
                End If
                If UdNaIsOpen Then
                    OpenOrCLoseTab("UdNa", False)
                    UdNaIsOpen = False
                End If
                If NaIrIsOpen Then
                    OpenOrCLoseTab("NaIr", False)
                    NaIrIsOpen = False
                End If
                If EvalIsOpen Then
                    OpenOrCLoseTab("Eval", False)
                    EvalIsOpen = False
                End If
                If AboutIsOpen Then
                    OpenOrCLoseTab("About", False)
                    AboutIsOpen = False
                End If
                If ExitIsOpen Then
                    OpenOrCLoseTab("Exit", False)
                    ExitIsOpen = False
                End If
            Case "NaIr"
                If NaksIsOpen Then
                    OpenOrCLoseTab("Naks", False)
                    NaksIsOpen = False
                End If
                If UdNaIsOpen Then
                    OpenOrCLoseTab("UdNa", False)
                    UdNaIsOpen = False
                End If
                If MuNaIsOpen Then
                    OpenOrCLoseTab("MuNa", False)
                    MuNaIsOpen = False
                End If
                If EvalIsOpen Then
                    OpenOrCLoseTab("Eval", False)
                    EvalIsOpen = False
                End If
                If AboutIsOpen Then
                    OpenOrCLoseTab("About", False)
                    AboutIsOpen = False
                End If
                If ExitIsOpen Then
                    OpenOrCLoseTab("Exit", False)
                    ExitIsOpen = False
                End If
            Case "Eval"
                If NaksIsOpen Then
                    OpenOrCLoseTab("Naks", False)
                    NaksIsOpen = False
                End If
                If UdNaIsOpen Then
                    OpenOrCLoseTab("UdNa", False)
                    UdNaIsOpen = False
                End If
                If MuNaIsOpen Then
                    OpenOrCLoseTab("MuNa", False)
                    MuNaIsOpen = False
                End If
                If NaIrIsOpen Then
                    OpenOrCLoseTab("NaIr", False)
                    NaIrIsOpen = False
                End If
                If AboutIsOpen Then
                    OpenOrCLoseTab("About", False)
                    AboutIsOpen = False
                End If
                If ExitIsOpen Then
                    OpenOrCLoseTab("Exit", False)
                    ExitIsOpen = False
                End If
            Case "About"
                If NaksIsOpen Then
                    OpenOrCLoseTab("Naks", False)
                    NaksIsOpen = False
                End If
                If UdNaIsOpen Then
                    OpenOrCLoseTab("UdNa", False)
                    UdNaIsOpen = False
                End If
                If MuNaIsOpen Then
                    OpenOrCLoseTab("MuNa", False)
                    MuNaIsOpen = False
                End If
                If NaIrIsOpen Then
                    OpenOrCLoseTab("NaIr", False)
                    NaIrIsOpen = False
                End If
                If EvalIsOpen Then
                    OpenOrCLoseTab("Eval", False)
                    EvalIsOpen = False
                End If
                If ExitIsOpen Then
                    OpenOrCLoseTab("Exit", False)
                    ExitIsOpen = False
                End If
            Case "Exit"
                If NaksIsOpen Then
                    OpenOrCLoseTab("Naks", False)
                    NaksIsOpen = False
                End If
                If UdNaIsOpen Then
                    OpenOrCLoseTab("UdNa", False)
                    UdNaIsOpen = False
                End If
                If MuNaIsOpen Then
                    OpenOrCLoseTab("MuNa", False)
                    MuNaIsOpen = False
                End If
                If NaIrIsOpen Then
                    OpenOrCLoseTab("NaIr", False)
                    NaIrIsOpen = False
                End If
                If EvalIsOpen Then
                    OpenOrCLoseTab("Eval", False)
                    EvalIsOpen = False
                End If
                If AboutIsOpen Then
                    OpenOrCLoseTab("About", False)
                    AboutIsOpen = False
                End If
        End Select
    End Sub

    Private Sub MainWindow_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles MyBase.KeyDown
        If e.Key = Key.Tab AndAlso (Keyboard.Modifiers And ModifierKeys.Control) = ModifierKeys.Control Then
            MessageBox.Show("CTRL + TAB trapped")
        End If
        Select Case (e.Key)
            Case Key.N
                gridNaks_MouseDown()
            Case Key.U
                gridUdNa_MouseDown()
            Case Key.M
                gridMuNa_MouseDown()
            Case Key.I
                gridNaIr_MouseDown()
            Case Key.E
                gridEval_MouseDown()
            Case Key.A
                gridAbout_MouseDown()
            Case Key.R
                btnExitReset.RaiseEvent(New RoutedEventArgs(Button.ClickEvent))
                gridExit_MouseDown()
            Case Key.X
                gridExit_MouseDown()
            Case Key.Enter
                Dim d As Boolean = True
                If NErrIsOpen And d Then
                    ErrorNav_MouseDown()
                    d = False
                End If
                If NaksIsOpen And d Then
                    gridUdNa_MouseDown()
                    d = False
                End If
                If UdNaIsOpen And d Then
                    gridMuNa_MouseDown()
                    d = False
                End If
                If MuNaIsOpen And d Then
                    gridNaIr_MouseDown()
                    d = False
                End If
                If NaIrIsOpen And d Then
                    If Not PathErrorReEval Then
                        gridEval_MouseDown()
                    End If
                    d = False
                End If
                If EvalIsOpen And d Then
                    gridEval_MouseDown()
                End If
                If ExitIsOpen Then
                    btnExitYes.RaiseEvent(New RoutedEventArgs(Button.ClickEvent))
                End If
                If AboutIsOpen Then
                    gridAbout_MouseDown()
                End If
            Case Key.C
                If ExitIsOpen Then
                    gridExit_MouseDown()
                End If
            Case Key.Y
                If ExitIsOpen Then
                    btnExitYes.RaiseEvent(New RoutedEventArgs(Button.ClickEvent))
                End If
            Case Key.Back
                Dim d As Boolean = True
                If UdNaIsOpen And d Then
                    gridNaks_MouseDown()
                    d = False
                End If
                If MuNaIsOpen And d Then
                    gridUdNa_MouseDown()
                    d = False
                End If
                If NaIrIsOpen And d Then
                    gridMuNa_MouseDown()
                    d = False
                End If
                If EvalIsOpen And d Then
                    gridNaIr_MouseDown()
                    d = False
                End If
            Case Key.Escape
                If ExitIsOpen Then
                    btnExitCancel.RaiseEvent(New RoutedEventArgs(Button.ClickEvent))
                End If
            Case Key.Up
                If NaksIsOpen Then
                    ScrollNaksUp.RaiseEvent(New RoutedEventArgs(Button.ClickEvent))
                End If
                If UdNaIsOpen Then
                    UdNaTimer.IncrementValue()
                End If
                If MuNaIsOpen Then
                    MuNaTimer.IncrementValue()
                End If
                If NaIrIsOpen Then
                    NaIrTimer.IncrementValue()
                End If
            Case Key.Down
                If NaksIsOpen Then
                    ScrollNaksDown.RaiseEvent(New RoutedEventArgs(Button.ClickEvent))
                End If
                If UdNaIsOpen Then
                    UdNaTimer.DecrementValue()
                End If
                If MuNaIsOpen Then
                    MuNaTimer.DecrementValue()
                End If
                If NaIrIsOpen Then
                    NaIrTimer.DecrementValue()
                End If
            Case Key.Left
                If UdNaIsOpen Then
                    UdNaTimer.SelectPrev()
                End If
                If MuNaIsOpen Then
                    MuNaTimer.SelectPrev()
                End If
                If NaIrIsOpen Then
                    NaIrTimer.SelectPrev()
                End If
            Case Key.Right
                If UdNaIsOpen Then
                    UdNaTimer.SelectNext()
                End If
                If MuNaIsOpen Then
                    MuNaTimer.SelectNext()
                End If
                If NaIrIsOpen Then
                    NaIrTimer.SelectNext()
                End If
        End Select
    End Sub

    Private Sub loadDasaBukthi()
        nLister = New Nakshathram With {.SelectedIndex = 0}
        naksCurr.Text = nLister.getCurrNaks
        naksNext.Text = nLister.getNextNaks
        naksPrev.Text = nLister.getPrevNaks
        dasaiName.Text = nLister.GetDasaiName
        dasaiYear.Text = nLister.GetDasaiYear
        ev = New Evaluate
        UdNaTimer.ResetValues()
        MuNaTimer.ResetValues()
        NaIrTimer.ResetValues()
        ev.Naks = nLister.GetDasaiYear
        patherrdiag = New PathError
    End Sub

    Private Sub ScrollNaksUp_Click() Handles ScrollNaksUp.Click
        nLister.SelectedIndex += 1
        naksCurr.Text = nLister.getCurrNaks
        naksNext.Text = nLister.getNextNaks
        naksPrev.Text = nLister.getPrevNaks
        dasaiName.Text = nLister.GetDasaiName
        dasaiYear.Text = nLister.GetDasaiYear
        ev.Naks = nLister.GetDasaiYear
    End Sub

    Private Sub ScrollNaksDown_Click() Handles ScrollNaksDown.Click
        nLister.SelectedIndex -= 1
        naksCurr.Text = nLister.getCurrNaks
        naksNext.Text = nLister.getNextNaks
        naksPrev.Text = nLister.getPrevNaks
        dasaiName.Text = nLister.GetDasaiName
        dasaiYear.Text = nLister.GetDasaiYear
        ev.Naks = nLister.GetDasaiYear
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        loadDasaBukthi()
    End Sub

    Private Sub UdNaTimer_TimerValueChanged(ByVal value As Integer) Handles UdNaTimer.TimerValueChanged
        ev.UdNa = value
    End Sub

    Private Sub MuNaTimer_TimerValueChanged(ByVal value As Integer) Handles MuNaTimer.TimerValueChanged
        ev.MuNa = value
    End Sub

    Private Sub NaIrTimer_TimerValueChanged(ByVal value As Integer) Handles NaIrTimer.TimerValueChanged
        ev.NaIr = value
    End Sub

    Private Sub gridNaks_MouseWheel(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseWheelEventArgs) Handles gridNaks.MouseWheel
        If e.Delta > 0 Then
            ScrollNaksUp_Click()
        Else
            ScrollNaksDown_Click()
        End If
    End Sub

    Private Sub Calculate(Optional ByVal reEval As Boolean = False, Optional ByVal se As Boolean = False)
        Dim e As Result
        If reEval And se Then
            e = ev.Evaluate(True)
        ElseIf reEval And Not se Then
            e = ev.Evaluate(True, patham)
        Else
            e = ev.Evaluate(False)
        End If
        Select Case e
            Case Result.Success
                Dim s As Double = ev.Sellu
                Dim i As Double = ev.Iruppu
                syr.Text = Int(s)
                iyr.Text = Int(i)

                s = s - Int(s)
                s = s * 12
                smn.Text = Int(s)
                i = i - Int(i)
                i = i * 12
                imn.Text = Int(i)

                s = s - Int(s)
                s = s * 30
                sdy.Text = Int(s)
                i = i - Int(i)
                i = i * 30
                idy.Text = Int(i)

                s = s - Int(s)
                s = s * 60
                sna.Text = Int(s)
                i = i - Int(i)
                i = i * 60
                ina.Text = Int(i)

                s = s - Int(s)
                s = s * 60
                svi.Text = Int(s)
                i = i - Int(i)
                i = i * 60
                ivi.Text = Int(i)
            Case Result.NaksError
                NErrIsOpen = True
                ErrorNav.Visibility = Windows.Visibility.Visible
                ErrorNav.Navigate(1)
                gridEval_MouseDown()
                gridNaks_MouseDown()
            Case Result.TimeError
                NErrIsOpen = True
                ErrorNav.Visibility = Windows.Visibility.Visible
                ErrorNav.Navigate(New TimeError)
                gridEval_MouseDown()
                gridUdNa_MouseDown()
            Case Result.SameError
                NErrIsOpen = True
                ErrorNav.Visibility = Windows.Visibility.Visible
                ErrorNav.Navigate(New SameError)
                Calculate(True, True)
            Case Result.PathError
                PathErrorReEval = True
                NErrIsOpen = True
                ErrorNav.Visibility = Windows.Visibility.Visible
                ErrorNav.Navigate(patherrdiag)

        End Select
    End Sub

    Private Sub patherrdiag_PathamSelected(ByVal p As Integer) Handles patherrdiag.PathamSelected
        'MsgBox("Path")
        patham = p
        'MsgBox("Path" + p.ToString)
        ErrorNav_MouseDown()
    End Sub
End Class
