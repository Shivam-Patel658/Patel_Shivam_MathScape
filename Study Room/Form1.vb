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
'      "Description": "Escape Room Game File"
'    }
'}

'Importing neccessary namepsaces:
Imports System.Media        'For SoundPlayer class
Imports System.Reflection       'For PlaySound Procedure
Imports System.Resources

Public Class Form1

    'Declaring neccesary global scope variables:
    Dim pbClueBookState, pbBriefCaseState, pbBookState, pbPhoneState, pbKeyHolderState As Integer               'These variables will hold 0 or 1, telling which "state" (opend or closed)

    Dim soundPlayer As New SoundPlayer()

    'Timer variables
    Dim intTimeLeft As Integer
    Dim decExitTime As Decimal

    Dim strMsg, strTitle As String                                  'Messagebox and Inputbox variables

    Dim strSlot1, strSlot2, strSlot3, strSlot4              'These variables will store the content of each inventory slot
    Dim blnScrewdriver, blnKeycard, blnFlashlight, blnMagGlass As Boolean       'These variables will tell which item is EQUIPPED







    'Procedures:

    'Sub Procedure to play sound effects using Sound (Sources: In presentation)
    Sub PlaySound(resourceFileName As String, resourceName As String)

        Dim resourceManager As ResourceManager
        Dim resourceFileType As Type = Assembly.GetExecutingAssembly().GetType("Study_Room.My.Resources." & resourceFileName)

        Dim resourceManagerProperty As PropertyInfo = resourceFileType.GetProperty("ResourceManager", BindingFlags.Static Or BindingFlags.NonPublic)

        resourceManager = CType(resourceManagerProperty.GetValue(Nothing, Nothing), ResourceManager)

        Dim resourceStream As IO.Stream = resourceManager.GetStream(resourceName)

        soundPlayer.Stream = resourceStream
        soundPlayer.Play()

    End Sub

    'Asynchronous Function to play garbage bin animation of pulling crumpled papers out. Asychronous allows to this code run in the background (simultanouesly)
    'Otherwise, For Loop will freeze UI, recall Looping Unit (how the whole form was forzen when a drawing was happening)
    Async Function ShowPaperAsync() As Task '(Sources in Presentation *Partial, didn't copy everything, some code was made by myself)

        Dim pictureBoxes As Array = {pbCrumpled1, pbCrumpled2, pbCrumpled3, pbCrumpled4}        'Array to store all pictureboxes

        Dim i As Integer        'For loop iteration variable

        PlaySound("RealisticFX", "crumping_paper")      'SoundFX

        For i = 0 To 3

            pictureBoxes(i).Show()
            Await Task.Delay(500)               'Very similar to Sleeping a Thread (except this fucntion is asynchronous not synchronous)

        Next

        pbBinNote.Show()            'Show the hidden note at the end

    End Function

    'This procedure is a function (a procedure that returns a value, while Subs don't. Both accept parameters though.)
    'Returns the next avaiable inventory slot AS A PICTUREBOX, no DirectCast or any TYPE conversions required
    Function GetNextAvailableSlot() As PictureBox

        Dim slots As PictureBox() = {pbSlot1, pbSlot2, pbSlot3, pbSlot4}                'Array

        For Each slot As PictureBox In slots                    'For Each loop, loops nested code for each element of a collection variable (in our case from index 0-3)

            If slot.Image Is Nothing Then

                Return slot                                             'As soon as a "free" slot found, return the slot value (functions end when values have been returned)

            End If

        Next

        Return Nothing                      'When all slots are full

    End Function

    'Inventory full sub in case needed
    Sub InventoryFull()

        strMsg = "Your inventory cannot hold more items. Drop items to free up space."
        strTitle = "INVENTORY FULL"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    'Game end sub
    Sub EndScreen()

        tmrExit.Start()

        PlaySound("SFX", "game_success")
        lblTime.Hide()

        Me.Controls.Remove(pbNoteMF)                        'A pb that glitched on label for an odd reason

        lblEscaped.Show()
        lblTimeTaken.Show()
        lblTimeTaken.Text = lblTimeTaken.Text & lblTime.Text            'Gets the time when end sub called (approximately game end time)



    End Sub

    'When form loads, play start sound effect
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PlaySound("SFX", "game_start")

    End Sub









    'CONTAINERS' EVENT HANDLERS (any object that contains something such as Safes)

    'Most follow a constant structure like the one below:
    Private Sub pbSafeTF_Click(sender As Object, e As EventArgs) Handles pbSafeTF.Click


        PlaySound("SFX", "code_request")    'play SFX
        strMsg = "Enter Code:"              'assign variables
        strTitle = "TOP LEFT SAFE"
        Dim input = InputBox(strMsg, strTitle, "4 Digit CODE")      'show InputBox and save Input to a variable


        'Check variable for desired input and react accordingly
        If input = "71420" Then

            PlaySound("SFX", "code_success")
            pbShine.Hide()
            pbSafeTF.Image = My.Resources.Containers.safe_normal_open_default
            pbSafeTF.Enabled = False
            pbNoteTF.Show()

        Else

            PlaySound("SFX", "code_failure")

        End If




    End Sub

    Private Sub pbSafeTR_Click(sender As Object, e As EventArgs) Handles pbSafeTR.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        strTitle = "TOP RIGHT SAFE"
        Dim input = InputBox(strMsg, strTitle, "2 Digit Code")

        If input = "64" Then

            PlaySound("SFX", "code_success")
            pbSafeTR.Image = My.Resources.Containers.safe_normal_open_default
            pbSafeTR.Enabled = False
            pbMagGlass.Show()

        Else

            PlaySound("SFX", "code_failure")

        End If

    End Sub

    Private Sub pbSafeMF_Click(sender As Object, e As EventArgs) Handles pbSafeMF.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        strTitle = "MIDDLE LEFT SAFE"
        Dim input = InputBox(strMsg, strTitle, "2 Digit CODE")

        If input = "15" Then

            PlaySound("SFX", "code_success")
            pbSafeMF.Image = My.Resources.Containers.safe_normal_open_default
            pbSafeMF.Enabled = False
            pbNoteMF.Show()

        Else

            PlaySound("SFX", "code_failure")

        End If

    End Sub

    Private Sub pbSafeMR_Click(sender As Object, e As EventArgs) Handles pbSafeMR.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        strTitle = "MIDDLE RIGHT SAFE"
        Dim input = InputBox(strMsg, strTitle, "Coefficient")

        If input = "1.5" Then

            PlaySound("SFX", "code_success")
            pbSafeMR.Image = My.Resources.Containers.safe_normal_open_default
            pbSafeMR.Enabled = False
            pbPhone.Show()

        Else

            PlaySound("SFX", "code_failure")

        End If

    End Sub

    Private Sub pbSafeB_Click(sender As Object, e As EventArgs) Handles pbSafeB.Click

        PlaySound("SFX", "code_request")
        strMsg = "Enter Code:"
        strTitle = "BOTTOM SAFE"
        Dim input = InputBox(strMsg, strTitle, "2 Digit Code")

        If input = "24" Then

            PlaySound("SFX", "code_success")
            pbSafeB.Image = My.Resources.Containers.safe_normal_open_default
            pbSafeB.Enabled = False
            pbFlashlight.Show()

        Else

            PlaySound("SFX", "code_failure")

        End If


    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles pbBriefCase.Click

        Select Case pbBriefCaseState

            Case 0
                pbBriefCase.Image = My.Resources.Containers.briefcase_front_default
                pbBriefCase.Location = New Point(778, 502)
                pbBriefCase.Size = New Size(100, 83)
                pbBriefCaseState = 1
                strMsg = "The BriefCase you just checked is empty. However, you discovered an identical hidden BriefCase."
                MessageBox.Show(strMsg, "BRIEFCASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            Case 1
                PlaySound("SFX", "code_request")
                strMsg = "Enter Code:"
                strTitle = "UNLOCK BRIEFCASE"
                Dim input = InputBox(strMsg, strTitle, "2 Digit Code")

                If input = "48" Then

                    PlaySound("SFX", "code_success")
                    pbBriefCase.Image = My.Resources.Containers.briefcase_front_open_default
                    pbBriefCase.Enabled = False
                    pbKeycard.Show()

                Else

                    PlaySound("SFX", "code_failure")

                End If

        End Select


    End Sub

    'This shine was just to add visual effects. It blocked the top left safe from being clicked, so its click event handler triggers the safes event handler
    Private Sub pbShine_Click(sender As Object, e As EventArgs) Handles pbShine.Click

        pbSafeTF_Click(pbSafeTF, EventArgs.Empty)           'Fire event handler with initator and empty EventArgs

    End Sub

    'Special case, the envelope does not have any barriers
    Private Sub pbEnvelope_Click(sender As Object, e As EventArgs) Handles pbEnvelope.Click

        pbEnvelopeNote.Show()
        pbEnvelope.Image = My.Resources.Containers.envelope_open_bd8d51

    End Sub







    'EQUIPEMENT EVENT HANDLERS (anything that can be put into the inventory)

    'All follow same structure!

    Private Sub pbKeycard_Click(sender As Object, e As EventArgs) Handles pbKeycard.Click

        Dim nextAvailableSlot As PictureBox = GetNextAvailableSlot()        'Get next free slot

        If nextAvailableSlot Is Nothing Then                'Recall function returns nothing at end if there are no empty slots

            InventoryFull()

        Else

            'VISUAL COMPONENT OF EQUIPPING ITEMS (just to create illusion)
            nextAvailableSlot.Image = My.Resources.Equipement.card_35ce5c
            pbKeycard.Hide()

            'VARIABLE COMPONENT (to register in memory which slot has what item)
            Select Case nextAvailableSlot.Name

                Case "pbSlot1"
                    strSlot1 = "Keycard"

                Case "pbSlot2"
                    strSlot2 = "Keycard"

                Case "pbSlot3"
                    strSlot3 = "Keycard"

                Case "pbSlot4"
                    strSlot4 = "Keycard"

            End Select

        End If

    End Sub

    Private Sub pbScrewDriver_Click(sender As Object, e As EventArgs) Handles pbScrewDriver.Click

        Dim nextAvailableSlot As PictureBox = GetNextAvailableSlot()

        If nextAvailableSlot Is Nothing Then

            inventoryFull()

        Else

            nextAvailableSlot.Image = My.Resources.Equipement.screwdriver_default__1_
            pbScrewDriver.Hide()

            Select Case nextAvailableSlot.Name

                Case "pbSlot1"
                    strSlot1 = "Screwdriver"

                Case "pbSlot2"
                    strSlot2 = "Screwdriver"

                Case "pbSlot3"
                    strSlot3 = "Screwdriver"

                Case "pbSlot4"
                    strSlot4 = "Screwdriver"

            End Select

        End If

    End Sub

    Private Sub pbMagGlass_Click(sender As Object, e As EventArgs) Handles pbMagGlass.Click

        Dim nextAvailableSlot As PictureBox = GetNextAvailableSlot()

        If nextAvailableSlot Is Nothing Then

            inventoryFull()

        Else

            nextAvailableSlot.Image = My.Resources.Equipement.magnifying_glass_default
            pbMagGlass.Hide()

            Select Case nextAvailableSlot.Name

                Case "pbSlot1"
                    strSlot1 = "MagGlass"

                Case "pbSlot2"
                    strSlot2 = "MagGlass"

                Case "pbSlot3"
                    strSlot3 = "MagGlass"

                Case "pbSlot4"
                    strSlot4 = "MagGlass"

            End Select

        End If

    End Sub

    Private Sub pbFlashlight_Click(sender As Object, e As EventArgs) Handles pbFlashlight.Click

        Dim nextAvailableSlot As PictureBox = GetNextAvailableSlot()

        If nextAvailableSlot Is Nothing Then

            InventoryFull()

        Else

            nextAvailableSlot.Image = My.Resources.Equipement.flashlight_2_default
            pbFlashlight.Hide()

            Select Case nextAvailableSlot.Name

                Case "pbSlot1"
                    strSlot1 = "Flashlight"

                Case "pbSlot2"
                    strSlot2 = "Flashlight"

                Case "pbSlot3"
                    strSlot3 = "Flashlight"

                Case "pbSlot4"
                    strSlot4 = "Flashlight"

            End Select

        End If

    End Sub


    'Special Case. Equipping Items. Concise Event Handler
    Private Sub pbSlots_Click(sender As Object, e As EventArgs) Handles pbSlot1.Click, pbSlot2.Click, pbSlot3.Click, pbSlot4.Click, pbSlot5.Click

        Dim selectedSlot = DirectCast(sender, PictureBox)

        Select Case selectedSlot.Name

            Case "pbSlot1"

                'Set the boolean variable accordingly, MAKE SURE TO SET THEM FALSE when needed OR ELSE MULTIPLE ITEMS WILL BE EQUIPPED SIMULTANOEUSLY
                If strSlot1 = "Screwdriver" Then
                    blnScrewdriver = True
                Else
                    blnScrewdriver = False
                End If

                If strSlot1 = "Flashlight" Then
                    blnFlashlight = True
                Else
                    blnFlashlight = False
                End If

                If strSlot1 = "Keycard" Then
                    blnKeycard = True
                Else
                    blnKeycard = False
                End If

                If strSlot1 = "MagGlass" Then
                    blnMagGlass = True
                Else
                    blnMagGlass = False
                End If

                'If after firing this specific slot, any items equipped? Then visually select slot!
                If blnScrewdriver Or blnFlashlight Or blnKeycard Or blnMagGlass = True Then

                    pbSlot1.BackColor = Color.WhiteSmoke
                    pbSlot2.BackColor = Color.DimGray
                    pbSlot3.BackColor = Color.DimGray
                    pbSlot4.BackColor = Color.DimGray

                End If

            Case "pbSlot2"

                If strSlot2 = "Screwdriver" Then
                    blnScrewdriver = True
                Else
                    blnScrewdriver = False
                End If

                If strSlot2 = "Flashlight" Then
                    blnFlashlight = True
                Else
                    blnFlashlight = False
                End If

                If strSlot2 = "Keycard" Then
                    blnKeycard = True
                Else
                    blnKeycard = False
                End If

                If strSlot2 = "MagGlass" Then
                    blnMagGlass = True
                Else
                    blnMagGlass = False
                End If

                If blnScrewdriver Or blnFlashlight Or blnKeycard Or blnMagGlass = True Then

                    pbSlot1.BackColor = Color.DimGray
                    pbSlot2.BackColor = Color.WhiteSmoke
                    pbSlot3.BackColor = Color.DimGray
                    pbSlot4.BackColor = Color.DimGray

                End If

            Case "pbSlot3"

                If strSlot3 = "Screwdriver" Then
                    blnScrewdriver = True
                Else
                    blnScrewdriver = False
                End If

                If strSlot3 = "Flashlight" Then
                    blnFlashlight = True
                Else
                    blnFlashlight = False
                End If

                If strSlot3 = "Keycard" Then
                    blnKeycard = True
                Else
                    blnKeycard = False
                End If

                If strSlot3 = "MagGlass" Then
                    blnMagGlass = True
                Else
                    blnMagGlass = False
                End If

                If blnScrewdriver Or blnFlashlight Or blnKeycard Or blnMagGlass = True Then

                    pbSlot1.BackColor = Color.DimGray
                    pbSlot2.BackColor = Color.DimGray
                    pbSlot3.BackColor = Color.WhiteSmoke
                    pbSlot4.BackColor = Color.DimGray

                End If

            Case "pbSlot4"

                If strSlot4 = "Screwdriver" Then
                    blnScrewdriver = True
                Else
                    blnScrewdriver = False
                End If

                If strSlot4 = "Flashlight" Then
                    blnFlashlight = True
                Else
                    blnFlashlight = False
                End If

                If strSlot4 = "Keycard" Then
                    blnKeycard = True
                Else
                    blnKeycard = False
                End If

                If strSlot4 = "MagGlass" Then
                    blnMagGlass = True
                Else
                    blnMagGlass = False
                End If

                If blnScrewdriver Or blnFlashlight Or blnKeycard Or blnMagGlass = True Then

                    pbSlot1.BackColor = Color.DimGray
                    pbSlot2.BackColor = Color.DimGray
                    pbSlot3.BackColor = Color.DimGray
                    pbSlot4.BackColor = Color.WhiteSmoke

                End If

            Case Else


        End Select


    End Sub







    'BOOKS' EVENT HANDLERS (Any object that holds piece of information and its not bound to the room)

    'Multiple states to create illusion of Opening and Closing
    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles pbClueBook.Click

        Select Case pbClueBookState

            Case 0 'Integers are always auto initialized to 0, therefore primary state
                PlaySound("RealisticFX", "book_pages_book_book_sheets_10762_WZNxw2Xm")
                pbClueBook.Image = My.Resources.Books.book_open_v_text_image
                pbClueBook.Location = New Point(931, 431)
                pbClueBook.Size = New Size(141, 84)
                pbClueBookState = 1  'IMPORTANT to switch states

            Case 1
                pbClueBook.Image = My.Resources.Books.book_horizontal_6b482b
                pbClueBook.Location = New Point(961, 491)
                pbClueBook.Size = New Size(89, 82)

                strMsg = "The Earth is the third farthest planet from the Sun. This may not seem like a lot at glance, however, the distance is in millions of kilometres. Approximately, distance from the Earth to the Sun is 150 million km. One unit of distance from the Earth to the Sun is one Astronomical Unit (AU)."
                strTitle = "BOOK CONTENTS"
                MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                pbClueBookState = 0

        End Select


    End Sub


    Private Sub PictureBox27_Click(sender As Object, e As EventArgs) Handles pbBook.Click

        Select Case pbBookState

            Case 0
                PlaySound("RealisticFX", "book_pages_book_book_sheets_10762_WZNxw2Xm")
                pbBook.Image = My.Resources.Books.book_open_default
                pbBook.Location = New Point(505, 381)
                pbBook.Size = New Size(159, 87)
                pbBookState = 1

            Case 1

                If blnMagGlass = True Then

                    strMsg = "Almost there! The bottom and last safe can be opened by one who knows the cost of 8kg of apples if 5 kg cost $15."
                    strTitle = "BOOK CONTENTS"
                    MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    strMsg = "The book contents are too small to read. Wonder if this is done on purpose."
                    strTitle = "BOOK"
                    MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)


                    pbBook.Image = My.Resources.Books.book_761d10
                    pbBook.Location = New Point(601, 381)
                    pbBook.Size = New Size(21, 87)
                    pbBookState = 0

                End If

        End Select

    End Sub

    'Simple Messagebox structure for Notes (as they do not have multiple states)
    Private Sub pbEnvelopeNote_Click(sender As Object, e As EventArgs) Handles pbEnvelopeNote.Click

        strMsg = "The Top Right Safe you seek, I see, open it when you conquer the 10 to the mighty power of 3 and multiply it with 0.064."
        strTitle = "ENVELOPE STICKY NOTE"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub pbNoteT_Click(sender As Object, e As EventArgs) Handles pbBoardNote.Click

        strMsg = "You can start here if you want. Find the answer to open the shiny safe!"
        strTitle = "STICKY NOTE"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub pbNoteTF_Click(sender As Object, e As EventArgs) Handles pbNoteTF.Click

        strMsg = "Well done! The safe below will open when 225 is square rooted."
        strTitle = "STICKY NOTE"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub pbNoteMF_Click(sender As Object, e As EventArgs) Handles pbNoteMF.Click

        strMsg = "Keep it up! To open the safe beside bubbles, you need to input the coefficient of the Distance (km) from the Earth to Sun in Scientific Notation."
        strTitle = "STICKY NOTE"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub pbBinNote_Click(sender As Object, e As EventArgs) Handles pbBinNote.Click

        strMsg = "Unlock the phone by entering the piece of data found in the wall hole that will evaluate to an irrational number. You will receive instructions to obtain the Keycard for the door. Don't do anything else on my phone. It is very old from my time."
        strTitle = "BIN STICKY NOTE"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    'ROOMITEMS' EVENT HANDLERS

    Private Sub pbDoor_Click(sender As Object, e As EventArgs) Handles pbDoor.Click

        strMsg = "You need a card to open this door."
        strTitle = "ESCAPE DOOR"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)


    End Sub


    Private Sub pbCardScanner_Click(sender As Object, e As EventArgs) Handles pbCardScanner.Click

        'Item interaction conditional
        If blnKeycard = True Then   'If true means player has item equipped

            EndScreen()

        Else

            strMsg = "You need a keycard to scan!"
            strTitle = "KEYCARD LOCK"
            MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    'In case player clicks screw, fire keyholder event handler
    Private Sub pbScrews_Click(sender As Object, e As EventArgs) Handles pbScrewL.Click, pbScrewR.Click

        If pbKeycard.Visible = True Then

            pbKeyHolder_Click(pbKeyHolder, EventArgs.Empty)

        End If

    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles pbStorageBox.Click

        pbScrewDriver.Show()
        pbStorageBox.Enabled = False        'Disabled control, making it one time use only. Don't want user infinitely showing the pocitureboxe even after its equipped.

    End Sub


    Private Sub pbKeyHolder_Click(sender As Object, e As EventArgs) Handles pbKeyHolder.Click

        If blnScrewdriver = True Then

            pbWallHole.Show()
            pbKeyHolder.Hide()

            pbScrewL.Image = My.Resources.Other.screw_default
            pbScrewR.Image = My.Resources.Other.slotted_screw_fastened_default
            pbScrewL.Location = New Point(96, 602)
            pbScrewR.Location = New Point(127, 625)

            pbEnvelope.Show()

        Else

            strMsg = "This is a Keyholder with two screws"
            strTitle = "KEY HOLDER"
            MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If


    End Sub


    Private Sub pbWallHole_Click(sender As Object, e As EventArgs) Handles pbWallHole.Click

        If blnFlashlight = True Then

            strMsg = "2345, 5, 9.7, 2/3, -10, 3.14159, Square Root of 2"
            strTitle = "HIDDEN MESSAGE"
            MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            strMsg = "Too dark to see anything in here. Need a source of light."
            strTitle = "WALL HOLE"
            MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub


    Private Async Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles pbBin.Click

        Await ShowPaperAsync()

    End Sub




    Private Sub pbPhone_Click(sender As Object, e As EventArgs) Handles pbPhone.Click

        Select Case pbPhoneState

            Case 0
                PlaySound("RealisticFX", "Windows_XP_Startup")
                pbPhone.Image = My.Resources.Other.mobile_phone_v_lock
                'pbClueBook.Location = New Point(931, 431)
                'pbClueBook.Size = New Size(141, 84)
                pbPhoneState = 1

            Case 1
                strMsg = "Enter Password or Face ID"
                strTitle = "PHONE SCREEN LOCK"
                Dim input = InputBox(strMsg, strTitle, "Password")

                If input = "Square root of 2" Then

                    PlaySound("SFX", "code_success")
                    pbPhone.Image = My.Resources.Other.mobile_phone_v_call
                    pbPhone.Enabled = False

                    strMsg = "WELL DONE! Student, I now ask you to unlock the briefcase, which has what you seek, with one last riddle. The area of this room is 12 m^2 with dimensions 4 x 3 (m). If I scaled the dimensions by a scale factor of merely 2, what would the new area of this room be (without units)? Remember, student, use your intellect. Don't not calculate the dimensions of the new room. You are my student, instead use the scale factor to directly find the area. Good luck and see you tomorrow during class."
                    strTitle = "VOICE MESSAGE FROM MATH TEACHER"
                    MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    PlaySound("SFX", "code_failure")

                End If


        End Select

    End Sub




    'ANIMALS' EVENT HANDLERS

    'All animals have simple event handlers. They jsut share a short irrelavant but fun/happy message.

    Private Sub pbFish_Click(sender As Object, e As EventArgs) Handles pbFish.Click

        strMsg = "Bubbles would love to escape as well!"
        strTitle = "FISH BOWL"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub pbDog_Click(sender As Object, e As EventArgs) Handles pbDog.Click

        strMsg = "This is Oscar. He loves sleeping a lot."
        strTitle = "DOG"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles pbCat.Click

        strMsg = "This is Luna. A very curious cat!"
        strTitle = "CAT"
        MessageBox.Show(strMsg, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub









    'TIMER EVENT HANDLERS

    'Countinous timer to time player
    Private Sub tmrEscape_Tick(sender As Object, e As EventArgs) Handles tmrEscape.Tick

        intTimeLeft += 1

        Dim intMinutes As Integer = Int(intTimeLeft / 60)
        Dim intSeconds As Integer = intTimeLeft Mod 60

        If intMinutes < 10 And intSeconds < 10 Then

            lblTime.Text = "0" & intMinutes & ":" & "0" & intSeconds


        ElseIf intMinutes < 10 Then

            lblTime.Text = "0" & intMinutes & ":" & intSeconds

        ElseIf intSeconds < 10 Then

            lblTime.Text = intMinutes & ":" & "0" & intSeconds

        Else

            lblTime.Text = intMinutes & ":" & intSeconds

        End If

    End Sub


    'Exit Timer. (Delay to allow exit music to play fully and player to proccess results)
    Private Sub tmrExit_Tick(sender As Object, e As EventArgs) Handles tmrExit.Tick

        decExitTime += 0.5

        If decExitTime = 2 Then

            Me.Close()

        End If

    End Sub



End Class

