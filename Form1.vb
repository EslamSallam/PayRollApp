Public Class Form1

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Try
            SoftexEngine.FrmMain = Me
            MC_Shared.FrmMain_Obj = Me

            'Softex Demo
            MC_Shared.StartupRoutines.DB = New SoftexEngine.SoftexSQLDB(GetMarketControl_ConnString("SoftexDemo", "104.243.33.149"))
            MC_Shared.ServerIP = "104.243.33.149"

            MC_Shared.Scode = 1006
            SoftexEngine.Lang = SoftexEngine.Languages.Arabic
            MC_Shared.LoadSoftexSetupDataToMCShared(MC_Shared.GetConStr)

        Catch ex As Exception
            SoftexEngine.LogError("@@:FrmMain.New")
            SoftexEngine.Connerror()
        End Try

    End Sub




#Region "Connection For MC Shared"
    Private Shared DB As New SoftexEngine.SoftexSQLDB
    Friend Shared Function GetMarketControl_ConnString(ByVal dbname As String, IPStr As String) As String
        'Building Connection String 
        Dim UserID As String = dbname & "user", PassStr As String = DB.GetMCPassword("1234", IPStr, dbname)
        Return "server=" & MC_Shared.SharedFunctions.GetActualMC_ServerName(IPStr) & ";Initial Catalog=" & dbname & ";User ID=" & dbname & "user" & ";pwd=" & PassStr
    End Function


#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmx As New Payroll_Control.frmAssessments
        frmx.ShowDialog()
    End Sub
End Class