Imports System.Timers
Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib
Imports System.Net.NetworkInformation
Imports System.Threading.ManualResetEvent

Public Class EMSBMSReportService
    Private m_tmrTime As Timer = New Timer()
    Private m_tmrErrorCheck As Timer = New Timer()
    Public Sub TestStartupAndStop(ByVal args() As String)
        OnStart(args)
        Dim WaitEvent As New Threading.ManualResetEvent(False)
        WaitEvent.WaitOne()
        OnStop()
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        Dim sError As String = ""

        Dim oTime As DateTime = DateTime.Now
        If ReadDatabaseConnection(sError) = False Then
            Try
                LogError("EMSBMSReportService", "OnStart()", sError)
                'Dim file As System.IO.StreamWriter
                'file = My.Computer.FileSystem.OpenTextFileWriter("d:\emsbmsreportservice.txt", True)
                'file.WriteLine(sError)
                'file.Close()
            Catch ex As Exception
                LogError("EMSBMSReportService", "OnStart()", ex.Message)
            End Try

            End
        End If

        m_tmrTime.Interval = 1000
        AddHandler m_tmrTime.Elapsed, AddressOf ElapsedTimer


        m_tmrErrorCheck.Interval = 60000
        AddHandler m_tmrTime.Elapsed, AddressOf CheckForDataError

        m_tmrTime.Start()

    End Sub

    Protected Overrides Sub OnStop()
        LogError("EMSBMSReportService", "OnStop()", "Service Stopped")
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

    Private Sub ElapsedTimer()
        m_tmrTime.Stop()

        Static bErrorCheckTimerStarted As Boolean = False

        MactusReportLib.GenerateReport()

        If Now.Second > 5 And bErrorCheckTimerStarted = False Then
            '   m_tmrErrorCheck.Start()
            bErrorCheckTimerStarted = True
        End If

        m_tmrTime.Start()
    End Sub


    Public Sub CheckForDataError()
        m_tmrErrorCheck.Stop()

        Try
            If g_bIsBMS = 0 Then
                Exit Sub
            End If

            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(g_sOutputFileDir + "\DataError.csv", True)

            Dim oFromDate As Date
            Dim sQuery As String
            Dim sPointName As String
            Dim oReader As OdbcDataReader

            oFromDate = Now.AddMilliseconds(-Now.Millisecond)
            oFromDate = oFromDate.AddSeconds(-oFromDate.Second)
            oFromDate = oFromDate.ToUniversalTime

            sQuery = "SELECT DISTINCT ColNameInDB,*  FROM TBL_ReportColumns where ReportID<>-1 and ReportID<>-2 and ColType<>1"
            Dim oReportServer As New MactusReportLib.EBOReport()
            Using oConnection As New OdbcConnection(g_sConString)
                Dim cmd As New OdbcCommand(sQuery, oConnection)
                oConnection.Open()
                Try
                    oReader = cmd.ExecuteReader()
                    While oReader.Read()

                        Dim nPointID As Integer
                        Dim sLine As String
                        Dim sIP As String
                        Try
                            nPointID = CInt(oReader("ColNameInDB"))
                            sIP = oReader("deviceip")
                            sPointName = GetPointName(nPointID)
                        Catch ex As Exception
                            Continue While
                        End Try

                        If oReportServer.IsPointDataAvailable(nPointID, oFromDate) = False Then

                            sLine = nPointID.ToString() + "," + sPointName + "," + oFromDate.ToLocalTime.ToString(g_sColTimeFormatIndian)
                            If GetPingStatus(sIP) Then
                                sLine = sLine + ", PING SUCCESS"
                            Else
                                sLine = sLine + ", PING FAILURE"
                            End If
                            file.WriteLine(sLine)

                        End If


                    End While
                    oReader.Close()
                Catch ex As Exception

                End Try
                oConnection.Close()

            End Using

            file.Close()

        Catch ex As Exception

        End Try

        m_tmrErrorCheck.Start()

    End Sub

    Public Function GetPingStatus(ByRef sIP As String) As Boolean
        GetPingStatus = False
        Try
            Dim oPing = New Ping()
            Dim oPingReply = oPing.Send(sIP)
            If oPingReply.Status = IPStatus.Success Then
                GetPingStatus = True
            End If
        Catch ex As Exception

        End Try
    End Function
End Class
