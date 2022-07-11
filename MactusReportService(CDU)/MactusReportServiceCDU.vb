Imports System.Timers
Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib
Public Class MactusReportServiceCDU
    Private m_tmrTime As Timer = New Timer()
    Protected Overrides Sub OnStart(ByVal args() As String)
        Try
            Dim sError As String = ""

            Dim oTime As DateTime = DateTime.Now
            If ReadDatabaseConnection(sError) = False Then
                Try
                    LogError("MactusReportServiceCDU", "OnStart()", sError)
                Catch ex As Exception
                    LogError("MactusReportServiceCDU", "OnStart()", ex.Message)
                End Try

                End
            End If
            LogError("MactusReportServiceCDU", "OnStart()", "Service Started")
            m_tmrTime.Interval = 1200
            AddHandler m_tmrTime.Elapsed, AddressOf ElapsedTimer
            m_tmrTime.Start()
        Catch ex As Exception

        End Try
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
    End Sub

    Protected Overrides Sub OnStop()
        LogError("MactusReportServiceCDU", "OnStop()", "Service Stopped")
        m_tmrTime.Stop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub
    Private Sub ElapsedTimer()
        m_tmrTime.Stop()

        ' Static bErrorCheckTimerStarted As Boolean = False

        MactusReportLib.GenerateReport()

        'If Now.Second > 5 And bErrorCheckTimerStarted = False Then
        '    '   m_tmrErrorCheck.Start()
        '    bErrorCheckTimerStarted = True
        'End If

        m_tmrTime.Start()
    End Sub


End Class
