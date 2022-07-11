Imports MactusReportLib.MactusReportLib

Public Class EventReport
    Inherits System.Web.UI.Page
    Private m_sUserName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            tToDate.Text = Now.ToString(MactusReportLib.g_sTimeFormatIndian)
            tFromDate.Text = Now.AddDays(-1).ToString(MactusReportLib.g_sTimeFormatIndian)
        End If

        Try
            m_sUserName = Request.QueryString("UserName")
        Catch ex As Exception
            m_sUserName = "Not Provided"
        End Try
    End Sub

    Protected Sub bGenerateReport_Click(sender As Object, e As EventArgs) Handles bGenerateReport.Click
        Dim oFromDate As Date
        Dim oToDate As Date
        Dim nReportID As Integer
        Dim nInterval As Integer
        Try



            oFromDate = DateTime.ParseExact(tFromDate.Text, MactusReportLib.g_sTimeFormatIndian, Nothing)
            oToDate = DateTime.ParseExact(tToDate.Text, MactusReportLib.g_sTimeFormatIndian, Nothing)
            If oFromDate >= oToDate Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('From Date Time Should Be Less Than To Date Time');", True)
                Exit Sub
            End If



            nReportID = MactusReportLib.GetEventReportID()
            nInterval = 1


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try

        Dim nReportStatusID As Long
        nReportStatusID = MactusReportLib.InsertNewReportStatusRecord(nReportID, oFromDate, oToDate, nInterval, m_sUserName, ReportType.EventReport)
        Response.Redirect("ReportProgress.aspx?ReportStatusID=" + nReportStatusID.ToString())

        'Dim sFileName As String = ""
        'Dim sPathName As String = ""
        'Dim sError As String = ""
        'If MactusReportLib.g_bIsBMS Then
        '    Dim oReport As New MactusReportLib.EBOReport()
        '    If oReport.GenerateReport(nReportID, oFromDate, oToDate, m_sUserName, sFileName, sPathName, nInterval, sError) Then
        '        Response.Redirect("Output\" + sFileName)
        '        Exit Sub
        '    Else
        '        sError = "alert(' " + sError + +" ');"
        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", sError, True)
        '    End If
        'Else
        '    Dim oReport As New MactusReportLib.IndusoftEMSReport()
        '    If oReport.GenerateReport(nReportID, oFromDate, oToDate, m_sUserName, sFileName, sPathName, nInterval, sError) Then
        '        Response.Redirect("Output\" + sFileName)
        '        Exit Sub
        '    Else
        '        sError = "alert(' " + sError + +" ');"
        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", sError, True)
        '    End If
        'End If

    End Sub
End Class