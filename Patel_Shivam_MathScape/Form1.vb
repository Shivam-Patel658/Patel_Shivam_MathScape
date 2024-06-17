'{
'  "APP METADATA.json": {
'    "About Programmer": {
'      "Name": "Patel, Shivam",
'      "Email": "821658@pdsb.net"
'    },
'    "About Project": {
'      "Title": "MathScape™",
'      "Course": "ICD2O0-B",
'      "Instructor": "A, Simler",
'      "Published": "14 June 2024"
'    }
'    "Additional Information on current file": {
'      "Name": "Form1.vb",
'      "Description": "Main Menu of Video Game"
'    }

'     "Attributions" {
'       "Game TEXT Logo" "https://www.textstudio.com/"
'        "Intro MUSIC": "Supercell"
'        "Main Menu Theme": "NPT Music"

'    }
'  }
'}



Imports System.Media
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Media
Imports System.Drawing
Imports Color = System.Drawing.Color

Module ControlExtensions

    <Extension()> Public Sub Hispose(ctrl As Control)

        If ctrl IsNot Nothing Then

            ctrl.Hide()
            ctrl.Dispose()

        End If

    End Sub

End Module


Public Class frmMain


    'Declaring neccesary variables
    Dim tickIntro As Decimal
    Dim tickLoading As Decimal

    Private fadeOpacity As Decimal
    Private fadeIn As Boolean = True ' To control fade in and fade out

    Public soundPlayer As New SoundPlayer()                                                 'SoundPlayer variable to play audio (slightly complex method but allows for resource files)
    Public bgmPlayer As New MediaPlayer()

    Private tempFilePath As String

    Dim sizeAddend As Integer


    Sub PlayMusic(ByVal resourceFile As Object, ByVal resourceName As String)

        Dim soundPlayer As New SoundPlayer()

        Dim resourceManager = resourceFile.ResourceManager
        Dim resourceStream As IO.Stream = resourceManager.GetStream(resourceName)

        soundPlayer.Stream = resourceStream        '
        soundPlayer.Play()

    End Sub



    Sub Pre()

        Me.BackgroundImage = Nothing

        Dim panels() As Panel = {pnlMain, pnlIntro, pnlLoadingScreen, pnlPlay, pnlHelp, pnlOptions}

        For Each panel As Panel In panels

            panel.Hide()
            panel.Location = New Point(0, 0)
            panel.Size = New Size(1600, 900)

        Next



    End Sub

    'Game intro (first thing when game is opened)

    Sub PlaySound(resourceFileName As String,resourceName As String)

        Dim soundPlayer As New SoundPlayer()
        Dim resourceManager As ResourceManager
        Dim resourceFileType As Type = Assembly.GetExecutingAssembly().GetType("Patel_Shivam_MathScape.My.Resources." & resourceFileName)

        Dim resourceManagerProperty As PropertyInfo = resourceFileType.GetProperty("ResourceManager", BindingFlags.Static Or BindingFlags.NonPublic)

        resourceManager = CType(resourceManagerProperty.GetValue(Nothing, Nothing), ResourceManager)

        Dim resourceStream As IO.Stream = resourceManager.GetStream(resourceName)

        soundPlayer.Stream = resourceStream
        soundPlayer.Play()

    End Sub

    Sub Intro()

        tmrAnimation.Start()
        pnlIntro.Show()
        PlaySound("Audio", "Intro_Music")

        'Throw New ArgumentException("Exception Occured")


    End Sub

    'Game Loading Screen (after intro)
    Sub LoadingScreen()

        tmrLoading.Start()
        pnlLoadingScreen.Show()
        PlaySound("Audio", "LOADING_SOUND")


    End Sub



    'Game MainMenu (After fade)
    Sub MainMenu()

        Me.BackgroundImage = My.Resources.Intro.BACKGROUND

        pnlMain.Show()

        'tempFilePath = Path.GetTempFileName()
        'File.WriteAllBytes(tempFilePath, My.Resources.Audio.Main_Menu_Theme)
        'MediaPlayer.Open(New Uri(tempFilePath))
        'bgmPlayer.Play()

        'PlaySound("Audio", "Main_Menu_Theme")

        bgmPlayer.Play()

    End Sub


    'Form Load Event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Pre()
        Intro()                                                                      'Runs intro sub, no call keyword required, no parenthesis required as there are no parameters


    End Sub



    Private Sub Label_Click(sender As Object, e As EventArgs) Handles lblPlay.Click, lblHelp.Click, lblOptions.Click

        Dim lbl As Label = CType(sender, Label)
        Dim panelToShow As Panel = Nothing

        Select Case lbl.Name

            Case "lblPlay"
                panelToShow = pnlPlay

            Case "lblHelp"
                panelToShow = pnlHelp

            Case "lblOptions"
                panelToShow = pnlOptions

        End Select


        panelToShow.SuspendLayout()

        panelToShow.Show()
        panelToShow.Controls.Add(lblBack)

        panelToShow.ResumeLayout()


    End Sub


    'Timer Tick Event
    Private Sub tmrIntro_Tick(sender As Object, e As EventArgs) Handles tmrAnimation.Tick

        tickIntro += 0.01

        If tickIntro = 1 Then

            pnlIntro.Hispose()
            LoadingScreen()


        End If

    End Sub


    'Timer Tick Event
    Private Sub tmrLoading_Tick(sender As Object, e As EventArgs) Handles tmrLoading.Tick

        tickLoading += 0.01

        If tickLoading = 1.0 Then

            pbLogo.Size = New Point(294, 306)
            pbLogo.Location = New Point(523 + 142, 29)
            pbLogo.Image = My.Resources.Brand.LOGO_LIGHT

        ElseIf tickLoading = 2 Then

            pnlLoadingScreen.Hide()
            MainMenu()

        End If


    End Sub




    Private Sub lblBack_Click(sender As Object, e As EventArgs) Handles lblBack.Click

        Dim strParentName As String = lblBack.Parent.Name

        pnlMain.Show()

        '**Allows me to use one "<back" label for all panels
        Select Case strParentName

            Case "pnlPlay"
                lblBack.Parent.Hide()
                lblBack.Parent = Nothing


            Case "pnlHelp"
                lblBack.Parent.Hide()
                lblBack.Parent = Nothing


            Case "pnlOptions"
                lblBack.Parent.Hide()
                lblBack.Parent = Nothing

        End Select

        strParentName = Nothing

    End Sub

    Private Sub label_MouseEnter(sender As Object, e As EventArgs) Handles _
        lblPlay.MouseEnter, lblHelp.MouseEnter, lblOptions.MouseEnter

        Dim label As Label = CType(sender, Label)
        sizeAddend = 10

        label.BackColor = Color.White
        label.ForeColor = Color.Black
        label.Font = New Font(label.Font.FontFamily, 85.0F, label.Font.Style)

        label.Size = New Size(label.Width + sizeAddend, label.Height + sizeAddend)
        label.Location = New Point(label.Location.X - sizeAddend / 2, label.Location.Y - sizeAddend / 2)


    End Sub

    Private Sub label_MouseLeave(sender As Object, e As EventArgs) Handles _
        lblPlay.MouseLeave, lblHelp.MouseLeave, lblOptions.MouseLeave

        Dim label As Label = CType(sender, Label)

        label.BackColor = Color.Transparent
        label.ForeColor = Color.White
        label.Font = New Font(label.Font.FontFamily, 72.0F, label.Font.Style)

        label.Size = New Size(label.Width - sizeAddend, label.Height - sizeAddend)
        label.Location = New Point(label.Location.X + sizeAddend / 2, label.Location.Y + sizeAddend / 2)

    End Sub


End Class
