Public Class FrmMain

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PsExeName = Replace(Replace(AppDomain.CurrentDomain.FriendlyName, ".exe", ""), ".EXE", "")
        GetIds()
        PsPenaltyPercent = getValueFromSQL(My.Resources.GetPercentageInterest)
        refreshFormTitle()
        CreateMainDatabase()
        '[MONTHLYBALANCE] [decimal](15, 4) DEFAULT 0,

        createTable("Select [MONTHLYBALANCE] from [MNP].[dbo].[METERED]", My.Resources.CreateMeteredImportTable)
        createTable("Select [MONTHLYBALANCE] from [MNP].[dbo].[TRUCKED]", My.Resources.CreateTruckedImportFile)
        createTable("Select [IDCUST] from [MNP].[dbo].[METEREDSELECTED]", My.Resources.CreateMeteredSelected)
        createTable("Select [IDCUST] from [MNP].[dbo].[PENALTYOTHERS]", My.Resources.CreatePenaltyOthers)
        'BtnTester.Visible = Command.ToString.ToUpper = "DEBUG"
    End Sub
    Private Sub refreshFormTitle()
        Me.Text = String.Format("{0}   Ver: {1}", Application.ProductName, Application.ProductVersion)
        lblCompany.Text = String.Format("Company: {0}" & vbCrLf & "Interest {1}% (Read from LATEPMT Item)", PsCompanyName, PsPenaltyPercent)
    End Sub
    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    Private Sub BtnSetup_Click(sender As Object, e As EventArgs) Handles BtnSetup.Click
        FrmSetup.ShowDialog()
        refreshFormTitle()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Dispose()
        Environment.ExitCode = 0
        Application.Exit()
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        FrmImport.ShowDialog()
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        FrmExport.ShowDialog()
    End Sub

    Private Sub BtnImportTrucked_Click(sender As Object, e As EventArgs) Handles BtnImportTrucked.Click
        FrmTrucked.ShowDialog()
    End Sub



    Private Sub BtnExport_GotFocus(sender As Object, e As EventArgs) Handles BtnExport.GotFocus

    End Sub

    Private Sub BtnExport_MouseHover(sender As Object, e As EventArgs) Handles BtnExport.MouseHover
        LblHelp.Text = "Click on Export to Neptune to create the WaterExport.txt file to upload to the Handheld device"
    End Sub


    Private Sub BtnImport_MouseHover(sender As Object, e As EventArgs) Handles BtnImport.MouseHover
        LblHelp.Text = "Click on Import from Neptune to import records from the Handheld device (Waterimport.txt) and create Invoices in Sage."
    End Sub

    Private Sub BtnImport_MouseLeave(sender As Object, e As EventArgs) Handles BtnImport.MouseLeave,
                                    BtnExport.MouseLeave, BtnImportTrucked.MouseLeave, BtnExit.MouseLeave, BtnSetup.MouseLeave
        LblHelp.Text = "Help: Put mouse pointer over button to get help"
    End Sub

    Private Sub BtnImportTrucked_MouseHover(sender As Object, e As EventArgs) Handles BtnImportTrucked.MouseHover
        LblHelp.Text = "Click on Import Trucked Water to import records from the Excel file send from Northridge and create Invoices in Sage."
    End Sub

    Private Sub BtnSetup_MouseHover(sender As Object, e As EventArgs) Handles BtnSetup.MouseHover
        LblHelp.Text = "Click on Setup to change program settings."
    End Sub

    Private Sub BtnExit_MouseHover(sender As Object, e As EventArgs) Handles BtnExit.MouseHover
        LblHelp.Text = "Click on Exit to leave this program."
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(DateSerial(2020, 7 + 1, 0).Day)
    End Sub

    Private Sub BtnPenaltyInvoices_MouseHover(sender As Object, e As EventArgs) Handles BtnPenaltyInvoices.MouseHover
        LblHelp.Text = "Click on Create Penalty Invoice to create the WaterExport.txt file to upload to the Handheld device"
    End Sub

    Private Sub BtnPenaltyInvoices_Click(sender As Object, e As EventArgs) Handles BtnPenaltyInvoices.Click
        'MsgBox("Working on it!!", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, psTitle)
        FrmPenaltyOthers.ShowDialog()
    End Sub
End Class
