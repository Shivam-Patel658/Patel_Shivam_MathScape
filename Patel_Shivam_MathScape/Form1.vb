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


'Importing neccessary namepsaces
Imports System.Media        'For SoundPlayer class
Imports System.Reflection       'PlaySound Procedure
Imports System.Resources
Imports Study_Room          'To be able to use Study_Room Projects Escape Room Form (Study_Room is referenced by this Project. This project DEPENDS on it)
Imports Color = System.Drawing.Color        'For predefined colors


Public Class frmMain


    'Declaring neccesary global scope variables
    Dim tickIntro As Decimal
    Dim tickLoading As Decimal

    Public soundPlayer As New SoundPlayer()                                                 'SoundPlayer variable to play audio (slightly complex method but allows for Porject Resources)

    Dim sizeAddend As Integer

    Dim Study_Room_Form As Form1







    'Attempt to load custom font for portability (doesn't work)

    'Public Function loadFont(fontFile As Byte(), Size As Integer) As Font
    '    Return loadFont(fontFile, Size, FontStyle.Regular)
    'End Function

    '' Font loading
    'Public Function loadFont(fontFile As Byte(), Size As Integer, Style As FontStyle) As Font
    '    Dim privateFontCollection As New System.Drawing.Text.PrivateFontCollection
    '    Dim ptr As IntPtr = Runtime.InteropServices.Marshal.AllocCoTaskMem(fontFile.Length)
    '    Runtime.InteropServices.Marshal.Copy(fontFile, 0, ptr, fontFile.Length)
    '    privateFontCollection.AddMemoryFont(ptr, fontFile.Length)
    '    Runtime.InteropServices.Marshal.FreeCoTaskMem(ptr)
    '    Return New Font(privateFontCollection.Families(0), Size, Style)
    'End Function



    'Procedures:


    'Prerequist Sub (Simply resizes and hides panels to values appropiate for the program. To allow for visual feedback and editing, I changed the properties. Via code, I change them back regardless 
    'of the Designer.
    Sub Pre()

        Me.BackgroundImage = Nothing

        'Local array (collection variable type)
        Dim panels() As Panel = {pnlMain, pnlIntro, pnlLoadingScreen}

        'For each Loop to repeat code for every element
        For Each panel As Panel In panels

            panel.Hide()
            panel.Location = New Point(0, 0)
            panel.Size = New Size(1600, 900)

        Next



    End Sub


    'Sound Sub to allow me to play a sound using a SoundPlay with only 2 parameters: ResourceFileName (Custom resources file name) and ResourceName. I added extra resources files to organize
    'resources and reduce overhead.

    '**Code obtained via external source that has been cited in presentation.
    Sub PlaySound(resourceFileName As String, resourceName As String)

        Dim soundPlayer As New SoundPlayer()
        Dim resourceManager As ResourceManager
        Dim resourceFileType As Type = Assembly.GetExecutingAssembly().GetType("Patel_Shivam_MathScape.My.Resources." & resourceFileName)

        Dim resourceManagerProperty As PropertyInfo = resourceFileType.GetProperty("ResourceManager", BindingFlags.Static Or BindingFlags.NonPublic)

        resourceManager = CType(resourceManagerProperty.GetValue(Nothing, Nothing), ResourceManager)

        Dim resourceStream As IO.Stream = resourceManager.GetStream(resourceName)

        soundPlayer.Stream = resourceStream
        soundPlayer.Play()

    End Sub

    'Game intro procedure
    Sub Intro()

        tmrAnimation.Start()    'Starts appropiate timer
        pnlIntro.Show()             'Shows appropiate panel
        PlaySound("Audio", "Intro_Music")       'Playing appropiate Music

    End Sub



    'Game Loading Screen procedure (after intro)
    Sub LoadingScreen()

        tmrLoading.Start()
        pnlLoadingScreen.Show()
        PlaySound("Audio", "LOADING_SOUND")


    End Sub



    'Game MainMenu (After Loading Screen)
    Sub MainMenu()

        Me.BackgroundImage = My.Resources.Intro.BACKGROUND  'Changing background to a resource lcoated in my Intro Resources File

        pnlMain.Show()


        'Oddly, PlaySound sub does not work with this resource. Result is Access Violation error which may cease with Admin perms. 
        'Therefore, I have manually updated the stream and played the music.
        soundPlayer.Stream = My.Resources.Audio.Main_Menu_Theme
        soundPlayer.Play()

    End Sub


    'Form Load Event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Pre()
        Intro()                                                                      'Runs subroutiness, no call keyword required, no parenthesis required as there are no parameters

    End Sub


    'Concise grouping of all Main Menu Label events
    Private Sub MainMenuLabels_Click(sender As Object, e As EventArgs) Handles lblPlay.Click, lblHelp.Click, lblOptions.Click

        Dim label As Label = DirectCast(sender, Label)      'DirectCast forces TYPE conversion of the sender (initiator of event As OBJECT) to a label so we can use a label's properties

        'Using label's name property to check for which label the initiator is (remember, the event handler handles multiple events, therefore there can be multiple initators
        Select Case label.Name

            Case "lblPlay"

                'To prevent player from creating infinite instances of Form1 from Study_Room
                If Study_Room_Form Is Nothing OrElse Study_Room_Form.IsDisposed Then            'Checks if the variable holding the form contains an instance of it or if it was disposed
                    '(meaning closed but application not exited)
                    Study_Room_Form = New Form1()                                               'Only then it created a new instance
                End If


                'Otherwise, if the form instance is still active, just bring it to the front and show it (to alert the player)
                Study_Room_Form.Show()
                Study_Room_Form.BringToFront()

            Case "lblHelp"
                MessageBox.Show("INTRODUCTION: The Game is easy to play. MathScape™ is a 2D Math Escape Room game. Click play to start an instance of the ER. Once an instance is running, the Main Menu will be automatically closed. The Main Menu will reopen when the ER is completed or when you restart the game. As with all ER's, find clues around the room and attempt to escape. Make sure to carefully read and follow any information provided. There will be riddles and trick questions." _
                & vbNewLine & vbNewLine & "HOW TO PLAY: Interact with objects by clicking on them. Equipe objects by selecting slots in your inventory.", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question)

        End Select


    End Sub


    'Timer Tick Events (Classic timer structures with counter variable and conditional that operates every tick)
    Private Sub tmrIntro_Tick(sender As Object, e As EventArgs) Handles tmrAnimation.Tick

        tickIntro += 0.01

        If tickIntro = 1 Then

            pnlIntro.Hide()
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

    'Main Menu Label Visual Feedback (When mouse enters control and leaves it)
    '**MouseEnter = when mouse pointer physically enters the boundaries of the control
    '**MouseHover = when mosue point rests on the control 
    'Careful selection of event handlers. If MouseHover was chosen, would cause bugs

    'MouseEnter event (Concise Event Handler)
    Private Sub label_MouseEnter(sender As Object, e As EventArgs) Handles _
        lblPlay.MouseEnter, lblHelp.MouseEnter, lblOptions.MouseEnter

        Dim label As Label = DirectCast(sender, Label)      'DirectCast on initiator

        sizeAddend = 10

        label.BackColor = Color.White
        label.ForeColor = Color.Black
        label.Font = New Font(label.Font.FontFamily, 85.0F, label.Font.Style)

        label.Size = New Size(label.Width + sizeAddend, label.Height + sizeAddend)
        label.Location = New Point(label.Location.X - sizeAddend / 2, label.Location.Y - sizeAddend / 2)


    End Sub

    'MoustLeave event (Concise Event Handler)
    Private Sub label_MouseLeave(sender As Object, e As EventArgs) Handles _
        lblPlay.MouseLeave, lblHelp.MouseLeave, lblOptions.MouseLeave

        Dim label As Label = DirectCast(sender, Label)      'DirectCast on initiator

        label.BackColor = Color.Transparent
        label.ForeColor = Color.White
        label.Font = New Font(label.Font.FontFamily, 72.0F, label.Font.Style)

        label.Size = New Size(label.Width - sizeAddend, label.Height - sizeAddend)
        label.Location = New Point(label.Location.X + sizeAddend / 2, label.Location.Y + sizeAddend / 2)

    End Sub

End Class
