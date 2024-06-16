<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.pnlHelp = New System.Windows.Forms.Panel()
        Me.pnlPlay = New System.Windows.Forms.Panel()
        Me.lblLoad = New System.Windows.Forms.Label()
        Me.lblNewGame = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.pnlLoadingScreen = New System.Windows.Forms.Panel()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.pbTextLogo = New System.Windows.Forms.PictureBox()
        Me.pnlIntro = New System.Windows.Forms.Panel()
        Me.pbIntro = New System.Windows.Forms.PictureBox()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblOptions = New System.Windows.Forms.Label()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.lblPlay = New System.Windows.Forms.Label()
        Me.pbKey = New System.Windows.Forms.PictureBox()
        Me.pbTextLogoWhite = New System.Windows.Forms.PictureBox()
        Me.tmrAnimation = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLoading = New System.Windows.Forms.Timer(Me.components)
        Me.pnlPlay.SuspendLayout()
        Me.pnlLoadingScreen.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTextLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIntro.SuspendLayout()
        CType(Me.pbIntro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.pbKey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTextLogoWhite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.Transparent
        Me.pnlOptions.Location = New System.Drawing.Point(12, 273)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(30, 30)
        Me.pnlOptions.TabIndex = 14
        '
        'pnlHelp
        '
        Me.pnlHelp.BackColor = System.Drawing.Color.Transparent
        Me.pnlHelp.Location = New System.Drawing.Point(12, 227)
        Me.pnlHelp.Name = "pnlHelp"
        Me.pnlHelp.Size = New System.Drawing.Size(30, 30)
        Me.pnlHelp.TabIndex = 15
        '
        'pnlPlay
        '
        Me.pnlPlay.BackColor = System.Drawing.Color.Transparent
        Me.pnlPlay.Controls.Add(Me.lblLoad)
        Me.pnlPlay.Controls.Add(Me.lblNewGame)
        Me.pnlPlay.Controls.Add(Me.lblBack)
        Me.pnlPlay.Location = New System.Drawing.Point(12, 174)
        Me.pnlPlay.Name = "pnlPlay"
        Me.pnlPlay.Size = New System.Drawing.Size(30, 30)
        Me.pnlPlay.TabIndex = 19
        '
        'lblLoad
        '
        Me.lblLoad.AutoSize = True
        Me.lblLoad.Font = New System.Drawing.Font("MARIO Font v3_2 Solid", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLoad.ForeColor = System.Drawing.Color.White
        Me.lblLoad.Location = New System.Drawing.Point(1030, 206)
        Me.lblLoad.Name = "lblLoad"
        Me.lblLoad.Size = New System.Drawing.Size(219, 83)
        Me.lblLoad.TabIndex = 2
        Me.lblLoad.Text = "LOAD"
        '
        'lblNewGame
        '
        Me.lblNewGame.AutoSize = True
        Me.lblNewGame.Font = New System.Drawing.Font("MARIO Font v3_2 Solid", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNewGame.ForeColor = System.Drawing.Color.White
        Me.lblNewGame.Location = New System.Drawing.Point(166, 206)
        Me.lblNewGame.Name = "lblNewGame"
        Me.lblNewGame.Size = New System.Drawing.Size(408, 83)
        Me.lblNewGame.TabIndex = 1
        Me.lblNewGame.Text = "NEW GAME"
        '
        'lblBack
        '
        Me.lblBack.AutoSize = True
        Me.lblBack.Font = New System.Drawing.Font("MARIO Font v3_2 Solid", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBack.ForeColor = System.Drawing.Color.White
        Me.lblBack.Location = New System.Drawing.Point(45, 19)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(256, 83)
        Me.lblBack.TabIndex = 0
        Me.lblBack.Text = "<BACK"
        '
        'pnlLoadingScreen
        '
        Me.pnlLoadingScreen.Controls.Add(Me.pbLogo)
        Me.pnlLoadingScreen.Controls.Add(Me.pbTextLogo)
        Me.pnlLoadingScreen.Location = New System.Drawing.Point(12, 64)
        Me.pnlLoadingScreen.Name = "pnlLoadingScreen"
        Me.pnlLoadingScreen.Size = New System.Drawing.Size(30, 30)
        Me.pnlLoadingScreen.TabIndex = 18
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.Patel_Shivam_MathScape.My.Resources.Brand.LOGO_PNG
        Me.pbLogo.Location = New System.Drawing.Point(724, 39)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(176, 286)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbLogo.TabIndex = 1
        Me.pbLogo.TabStop = False
        '
        'pbTextLogo
        '
        Me.pbTextLogo.Image = Global.Patel_Shivam_MathScape.My.Resources.Brand.TEXT_LOGO
        Me.pbTextLogo.Location = New System.Drawing.Point(300, 313)
        Me.pbTextLogo.Name = "pbTextLogo"
        Me.pbTextLogo.Size = New System.Drawing.Size(973, 535)
        Me.pbTextLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbTextLogo.TabIndex = 0
        Me.pbTextLogo.TabStop = False
        '
        'pnlIntro
        '
        Me.pnlIntro.Controls.Add(Me.pbIntro)
        Me.pnlIntro.Location = New System.Drawing.Point(12, 12)
        Me.pnlIntro.Name = "pnlIntro"
        Me.pnlIntro.Size = New System.Drawing.Size(30, 30)
        Me.pnlIntro.TabIndex = 17
        '
        'pbIntro
        '
        Me.pbIntro.Image = Global.Patel_Shivam_MathScape.My.Resources.Intro.Intro_Animation
        Me.pbIntro.Location = New System.Drawing.Point(260, 162)
        Me.pbIntro.Name = "pbIntro"
        Me.pbIntro.Size = New System.Drawing.Size(1080, 586)
        Me.pbIntro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbIntro.TabIndex = 0
        Me.pbIntro.TabStop = False
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.Transparent
        Me.pnlMain.Controls.Add(Me.lblOptions)
        Me.pnlMain.Controls.Add(Me.lblHelp)
        Me.pnlMain.Controls.Add(Me.lblPlay)
        Me.pnlMain.Controls.Add(Me.pbKey)
        Me.pnlMain.Controls.Add(Me.pbTextLogoWhite)
        Me.pnlMain.ForeColor = System.Drawing.Color.White
        Me.pnlMain.Location = New System.Drawing.Point(12, 117)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(30, 30)
        Me.pnlMain.TabIndex = 16
        Me.pnlMain.Visible = False
        '
        'lblOptions
        '
        Me.lblOptions.AutoSize = True
        Me.lblOptions.BackColor = System.Drawing.Color.Transparent
        Me.lblOptions.Font = New System.Drawing.Font("MARIO Font v3_2 Solid", 71.99999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptions.ForeColor = System.Drawing.Color.White
        Me.lblOptions.Location = New System.Drawing.Point(576, 750)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.Size = New System.Drawing.Size(472, 124)
        Me.lblOptions.TabIndex = 9
        Me.lblOptions.Text = "Options"
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.BackColor = System.Drawing.Color.Transparent
        Me.lblHelp.Font = New System.Drawing.Font("MARIO Font v3_2 Solid", 71.99999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(659, 588)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(299, 124)
        Me.lblHelp.TabIndex = 8
        Me.lblHelp.Text = "Help"
        '
        'lblPlay
        '
        Me.lblPlay.AutoSize = True
        Me.lblPlay.BackColor = System.Drawing.Color.Transparent
        Me.lblPlay.Font = New System.Drawing.Font("MARIO Font v3_2 Solid", 71.99999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlay.ForeColor = System.Drawing.Color.White
        Me.lblPlay.Location = New System.Drawing.Point(659, 410)
        Me.lblPlay.Name = "lblPlay"
        Me.lblPlay.Size = New System.Drawing.Size(284, 124)
        Me.lblPlay.TabIndex = 7
        Me.lblPlay.Text = "Play"
        '
        'pbKey
        '
        Me.pbKey.BackColor = System.Drawing.Color.Transparent
        Me.pbKey.Image = Global.Patel_Shivam_MathScape.My.Resources.Brand.LOGO_KEY
        Me.pbKey.Location = New System.Drawing.Point(741, 26)
        Me.pbKey.Name = "pbKey"
        Me.pbKey.Size = New System.Drawing.Size(119, 71)
        Me.pbKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbKey.TabIndex = 6
        Me.pbKey.TabStop = False
        '
        'pbTextLogoWhite
        '
        Me.pbTextLogoWhite.BackColor = System.Drawing.Color.Transparent
        Me.pbTextLogoWhite.Image = Global.Patel_Shivam_MathScape.My.Resources.Brand.TEXT_LOGO_WHITE
        Me.pbTextLogoWhite.Location = New System.Drawing.Point(140, 113)
        Me.pbTextLogoWhite.Name = "pbTextLogoWhite"
        Me.pbTextLogoWhite.Size = New System.Drawing.Size(1321, 229)
        Me.pbTextLogoWhite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbTextLogoWhite.TabIndex = 5
        Me.pbTextLogoWhite.TabStop = False
        '
        'tmrAnimation
        '
        Me.tmrAnimation.Interval = 10
        '
        'tmrLoading
        '
        Me.tmrLoading.Interval = 10
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1600, 900)
        Me.Controls.Add(Me.pnlOptions)
        Me.Controls.Add(Me.pnlHelp)
        Me.Controls.Add(Me.pnlPlay)
        Me.Controls.Add(Me.pnlLoadingScreen)
        Me.Controls.Add(Me.pnlIntro)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MathScape"
        Me.pnlPlay.ResumeLayout(False)
        Me.pnlPlay.PerformLayout()
        Me.pnlLoadingScreen.ResumeLayout(False)
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTextLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIntro.ResumeLayout(False)
        CType(Me.pbIntro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.pbKey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTextLogoWhite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlOptions As Panel
    Friend WithEvents pnlHelp As Panel
    Friend WithEvents pnlPlay As Panel
    Friend WithEvents lblLoad As Label
    Friend WithEvents lblNewGame As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents pnlLoadingScreen As Panel
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents pbTextLogo As PictureBox
    Friend WithEvents pnlIntro As Panel
    Friend WithEvents pbIntro As PictureBox
    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblOptions As Label
    Friend WithEvents lblHelp As Label
    Friend WithEvents lblPlay As Label
    Friend WithEvents pbKey As PictureBox
    Friend WithEvents pbTextLogoWhite As PictureBox
    Friend WithEvents tmrAnimation As Timer
    Friend WithEvents tmrLoading As Timer
End Class
