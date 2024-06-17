Imports System.Media
Imports System.Reflection
Imports System.Resources
Imports System.Threading
Module GlobalVariables

    Public strMsg As String

End Module




Public Class Form1

    Dim pbClueBookState As String = "Closed"
    Dim pbBriefCaseState As String = "Untouched"
    Dim soundPlayer As New SoundPlayer()
    Dim strTimeSound As String
    Dim intTick As Decimal
    Dim intTimeLeft As Integer = 1800

    Sub PlaySound(resourceFileName As String, resourceName As String)

        Dim resourceManager As ResourceManager
        Dim resourceFileType As Type = Assembly.GetExecutingAssembly().GetType("Study_Room.My.Resources." & resourceFileName)

        Dim resourceManagerProperty As PropertyInfo = resourceFileType.GetProperty("ResourceManager", BindingFlags.Static Or BindingFlags.NonPublic)

        resourceManager = CType(resourceManagerProperty.GetValue(Nothing, Nothing), ResourceManager)

        Dim resourceStream As IO.Stream = resourceManager.GetStream(resourceName)

        soundPlayer.Stream = resourceStream
        soundPlayer.Play()

    End Sub

    Async Function ShowPaperAsync() As Task

        Dim pictureBoxes As PictureBox() = {pbCrumpled1, pbCrumpled2, pbCrumpled3, pbCrumpled4}
        Dim i As Integer

        PlaySound("RealisticFX", "crumping_paper_109585")
        strTimeSound = "crumping_paper_109585"
        tmrSound.Start()

        For i = 0 To 3 Step 1

            pictureBoxes(i).Show()
            Await Task.Delay(500)

        Next

        pbNoteB.Show()

    End Function

    Private Sub pbDoor_Click(sender As Object, e As EventArgs) Handles pbDoor.Click

        strMsg = "You need a card to open this door."
        MessageBox.Show(strMsg, "DOOR", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Private Sub pbFish_Click(sender As Object, e As EventArgs) Handles pbFish.Click

        strMsg = "Bubbles would love to escape as well!"
        MessageBox.Show(strMsg, "FISH BOWL", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub pbDog_Click(sender As Object, e As EventArgs) Handles pbDog.Click

        strMsg = "This is Oscar. He loves sleeping a lot."
        MessageBox.Show(strMsg, "DOG", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub pbNoteT_Click(sender As Object, e As EventArgs) Handles pbNoteT.Click

        strMsg = "You can start here if you want. Find the answer to open the shiny safe!"
        MessageBox.Show(strMsg, "STICKY NOTE", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

        strMsg = "This is Luna. A very curious cat!"
        MessageBox.Show(strMsg, "CAT", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub pbCardScanner_Click(sender As Object, e As EventArgs) Handles pbCardScanner.Click

        strMsg = "You need a card to scan!"
        MessageBox.Show(strMsg, "CARD SCANNER", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Private Sub pbScrewDriver_Click(sender As Object, e As EventArgs) Handles pbScrewDriver.Click

        pbScrewDriver.Location = New Point()

    End Sub

    Private Sub pbSafeTF_Click(sender As Object, e As EventArgs) Handles pbSafeTF.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        Dim p = InputBox(strMsg, "UNLOCK SAFE", "Value Requirements")

    End Sub

    Private Sub pbSafeTR_Click(sender As Object, e As EventArgs) Handles pbSafeTR.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        Dim p = InputBox(strMsg, "UNLOCK SAFE", "Value Requirements")

    End Sub

    Private Sub pbSafeMF_Click(sender As Object, e As EventArgs) Handles pbSafeMF.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        Dim p = InputBox(strMsg, "UNLOCK SAFE", "Value Requirements")

    End Sub

    Private Sub pbSafeMR_Click(sender As Object, e As EventArgs) Handles pbSafeMR.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        Dim p = InputBox(strMsg, "UNLOCK SAFE", "Value Requirements")

    End Sub

    Private Sub pbSafeB_Click(sender As Object, e As EventArgs) Handles pbSafeB.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        Dim p = InputBox(strMsg, "UNLOCK SAFE", "Value Requirements")

    End Sub


    Private Sub pbKeyHolder_Click(sender As Object, e As EventArgs) Handles pbKeyHolder.Click

        strMsg = "This is a Keyholder with two screws"
        MessageBox.Show(strMsg, "KEY HOLDER", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub pbShine_Click(sender As Object, e As EventArgs) Handles pbShine.Click

        pbSafeTF_Click(pbSafeTF, EventArgs.Empty)

    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles pbClueBook.Click

        Select Case pbClueBookState

            Case "Closed"
                PlaySound("RealisticFX", "book_pages_book_book_sheets_10762_WZNxw2Xm")
                pbClueBook.Image = My.Resources.Books.book_open_v_text_image
                pbClueBook.Location = New Point(931, 431)
                pbClueBook.Size = New Size(141, 84)
                pbClueBookState = "Open"

            Case "Open"
                pbClueBook.Image = My.Resources.Books.book_horizontal_6b482b
                pbClueBook.Location = New Point(961, 491)
                pbClueBook.Size = New Size(89, 82)

                strMsg = "Clue"
                MessageBox.Show(strMsg)

                pbClueBookState = "Closed"

        End Select


    End Sub

    Private Async Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles pbBin.Click


        Await ShowPaperAsync()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PlaySound("SFX", "game_start")


    End Sub

    Private Sub tmrSound_Tick(sender As Object, e As EventArgs) Handles tmrSound.Tick

        intTick += 0.5

        Select Case strTimeSound

            Case "crumping_paper_109585"

                If intTick = 2.5 Then
                    'MessageBox.Show("Yes")

                    soundPlayer.Stop()

                End If


        End Select

    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles pbBriefCase.Click

        Select Case pbBriefCaseState

            Case "Untouched"
                pbBriefCase.Image = My.Resources.Containers.briefcase_front_default
                pbBriefCase.Location = New Point(778, 502)
                pbBriefCase.Size = New Size(100, 83)
                pbBriefCaseState = "Touched"
                strMsg = "The BriefCase you just checked is empty. However, you discovered an identical hidden BriefCase."
                MessageBox.Show(strMsg, "BRIEFCASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            Case "Touched"
                PlaySound("SFX", "code_request")
                strMsg = "Enter Code:"
                Dim p = InputBox(strMsg, "UNLOCK BRIEFCASE")

        End Select





    End Sub

    Private Sub tmrEscape_Tick(sender As Object, e As EventArgs) Handles tmrEscape.Tick

        intTimeLeft -= 1

        If intTimeLeft = 0 Then

            MessageBox.Show("You ran out of time! Try Again.")

        End If

        Dim intMinutes As Integer = Int(intTimeLeft / 60)
        Dim intSeconds As Integer = intTimeLeft Mod 60

        If intSeconds < 10 Then

            lblTime.Text = intMinutes & ":" & "0" & intSeconds

        Else

            lblTime.Text = intMinutes & ":" & intSeconds

        End If

    End Sub

End Class

