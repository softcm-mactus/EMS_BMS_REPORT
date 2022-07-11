Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib
Imports MactusReportLib.IndusoftEMSReport
Imports System.ComponentModel

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""


        If ReadDatabaseConnection(sError) = False Then
            MsgBox(sError)
            End
        End If

        dtFrom.Value = Now.AddDays(-1)
        dtto.Value = Now
    End Sub

    Private Sub bGenerate_Click(sender As Object, e As EventArgs) Handles bGenerate.Click

        If g_bIsBMS = 0 Then
            MsgBox("Not Implemented For Indusoft")
            Exit Sub
        End If



        oGrid.Rows.Clear()

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(g_sOutputFileDir + "\DataError.csv", False)

        Dim oFromDate As Date
        Dim oToDate As Date
        Dim sQuery As String
        Dim sPointName As String
        Dim oReader As OdbcDataReader
        Dim nTemp As Integer = 100

        oFromDate = dtFrom.Value.AddMilliseconds(-dtFrom.Value.Millisecond)
        oFromDate = oFromDate.AddSeconds(-oFromDate.Second)
        '  oFromDate = oFromDate.AddMinutes(-oFromDate.Minute)
        ' oFromDate = oFromDate.AddHours(-oFromDate.Hour)

        oFromDate = oFromDate.ToUniversalTime

        oToDate = dtto.Value.AddMilliseconds(-dtto.Value.Millisecond)
        oToDate = oToDate.AddSeconds(-oToDate.Second)
        '  oToDate = oToDate.AddMinutes(-oToDate.Minute)
        '  oToDate = oToDate.AddHours(-oToDate.Hour)

        oToDate = oToDate.ToUniversalTime

        Try
            sQuery = "SELECT COUNT(DISTINCT ColNameInDB)  FROM TBL_ReportColumns where ReportID<>-1 and ReportID<>-2 and ColType<>1"
            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim cmd As New OdbcCommand(sQuery, oConnection)
                nTemp = CInt(cmd.ExecuteScalar())
                oConnection.Close()
            End Using
        Catch ex As Exception

        End Try
        Label1.Text = ""
        If nTemp = 0 Then
            MsgBox("Not Points Defined In The Reports")
            Exit Sub
        End If

        Label1.Text = "Total Points = " + nTemp.ToString()
        bGenerate.Enabled = False
        oAllPoints.Maximum = nTemp
        sQuery = "SELECT DISTINCT ColNameInDB,*  FROM TBL_ReportColumns where ReportID<>-1 and ReportID<>-2 and ColType<>1"




        Dim nPointCount As Integer = 0
        oAllPoints.Minimum = 0
        oAllPoints.Value = 0
        Dim oReportServer As New MactusReportLib.EBOReport()
        Using oConnection As New OdbcConnection(g_sConString)
            Dim cmd As New OdbcCommand(sQuery, oConnection)
            oConnection.Open()
            Try
                oReader = cmd.ExecuteReader()
                While oReader.Read()
                    oAllPoints.Value = oAllPoints.Value + 1
                    Dim nPointID As Integer
                    Dim fValue As Double
                    Dim oTime As Date
                    Dim sLine As String
                    Try
                        nPointID = CInt(oReader("ColNameInDB"))
                        sPointName = GetPointName(nPointID)
                    Catch ex As Exception
                        Continue While
                    End Try

                    Dim nCount = 0
                    Dim bErrorStart As Boolean = False
                    Dim oErrorStartTime As Date
                    Dim nRow As Integer
                    oTime = oFromDate

                    While oTime <= oToDate
                        fValue = -100
                        If oReportServer.IsPointDataAvailable(nPointID, oTime) = False Then

                            If bErrorStart = False Then
                                oErrorStartTime = oTime
                                bErrorStart = True
                                nCount = 0
                            End If

                            nCount = nCount + 1

                        ElseIf bErrorStart = True Then

                            sLine = nPointID.ToString() + "," + sPointName + "," + oErrorStartTime.ToLocalTime.ToString(g_sColTimeFormatIndian) + "," + oTime.ToLocalTime.AddMinutes(-1).ToString(g_sColTimeFormatIndian) + "," + nCount.ToString()
                            nRow = oGrid.Rows.Add
                            oGrid.Rows(nRow).Cells(0).Value = nPointID
                            oGrid.Rows(nRow).Cells(1).Value = sPointName
                            oGrid.Rows(nRow).Cells(2).Value = oErrorStartTime.ToLocalTime.ToString(g_sColTimeFormatIndian)
                            oGrid.Rows(nRow).Cells(3).Value = oTime.AddMinutes(-1).ToLocalTime.ToString(g_sColTimeFormatIndian)
                            oGrid.Rows(nRow).Cells(4).Value = nCount.ToString()
                            file.WriteLine(sLine)
                            nCount = 0
                            bErrorStart = False
                        Else
                            '  MsgBox(oTime + " 2 SUCCESS")
                        End If

                        oTime = oTime.AddMinutes(1)
                        Application.DoEvents()
                    End While

                    If bErrorStart = True Then
                        ' MsgBox(oTime + " 4 SUCCESS")
                        sLine = nPointID.ToString() + "," + sPointName + "," + oErrorStartTime.ToLocalTime.ToString(g_sColTimeFormatIndian) + "," + oTime.ToLocalTime.AddMinutes(-1).ToString(g_sColTimeFormatIndian) + "," + nCount.ToString()
                        nRow = oGrid.Rows.Add
                        oGrid.Rows(nRow).Cells(0).Value = nPointID
                        oGrid.Rows(nRow).Cells(1).Value = sPointName
                        oGrid.Rows(nRow).Cells(2).Value = oErrorStartTime.ToLocalTime.ToString(g_sColTimeFormatIndian)
                        oGrid.Rows(nRow).Cells(3).Value = oTime.AddMinutes(-1).ToLocalTime.ToString(g_sColTimeFormatIndian)
                        oGrid.Rows(nRow).Cells(4).Value = nCount.ToString()
                        file.WriteLine(sLine)
                        Application.DoEvents()
                        ' MsgBox(oTime + " " + fValue.ToString())
                    End If
                End While
                oReader.Close()
            Catch ex As Exception

            End Try
            oConnection.Close()


            bGenerate.Enabled = True
        End Using








        file.Close()

    End Sub





End Class
