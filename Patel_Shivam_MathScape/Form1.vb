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



Imports System.IO
Imports System.Media
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Media
Imports System.Reflection

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

    Sub PlayMusic(ByVal resourceFile As Object, ByVal resourceName As String)
        ' Create a new SoundPlayer
        Dim soundPlayer As New SoundPlayer()

        ' Retrieve the resource stream using the specified resource file and resource name
        Dim resourceManager = resourceFile.ResourceManager
        Dim resourceStream As IO.Stream = resourceManager.GetStream(resourceName)

        If resourceStream IsNot Nothing Then
            ' Assign the stream to the SoundPlayer
            soundPlayer.Stream = resourceStream        ' Play the sound
            soundPlayer.Play()
        Else
            ' Handle the case where the resource is not found
            Throw New Exception("Resource not found: " & resourceName)
        End If

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

    Sub PlaySound(ByVal resourceFileName As String, ByVal resourceName As String)
        ' Create a new SoundPlayer
        Dim soundPlayer As New SoundPlayer()

        ' Use reflection to get the ResourceManager from the specified resource file name
        Dim resourceManager As ResourceManager
        Try
            ' Get the type of the resource file from the assembly
            Dim resourceFileType As Type = Assembly.GetExecutingAssembly().GetType("Patel_Shivam_MathScape.My.Resources." & resourceFileName)
            If resourceFileType Is Nothing Then
                Throw New Exception("Resource file not found: " & resourceFileName)
            End If

            ' Get the ResourceManager property from the resource file type
            Dim resourceManagerProperty As PropertyInfo = resourceFileType.GetProperty("ResourceManager", BindingFlags.Static Or BindingFlags.NonPublic)
            If resourceManagerProperty Is Nothing Then
                Throw New Exception("ResourceManager property not found in resource file: " & resourceFileName)
            End If

            ' Get the ResourceManager instance
            resourceManager = CType(resourceManagerProperty.GetValue(Nothing, Nothing), ResourceManager)
        Catch ex As Exception
            Throw New Exception("Failed to get ResourceManager for resource file: " & resourceFileName, ex)
        End Try

        ' Retrieve the resource stream using the resource manager and resource name
        Dim resourceStream As IO.Stream = resourceManager.GetStream(resourceName)

        If resourceStream IsNot Nothing Then
            ' Assign the stream to the SoundPlayer
            soundPlayer.Stream = resourceStream
            ' Play the sound
            soundPlayer.Play()
        Else
            ' Handle the case where the resource is not found
            Throw New Exception("Resource not found: " & resourceName)
        End If

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
                pnlPlay.Hide()
                pnlPlay.Controls.Remove(lblBack)

            Case "pnlHelp"
                pnlHelp.Hide()
                pnlHelp.Controls.Remove(lblBack)

            Case "pnlOptions"
                pnlOptions.Hide()
                pnlOptions.Controls.Remove(lblBack)

        End Select

        strParentName = Nothing

    End Sub

End Class
