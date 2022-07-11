Imports System.Timers
Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib

Public Class EMSBMSReportService2
    Private m_tmrTime As Timer = New Timer()

    Protected Overrides Sub OnStart(ByVal args() As String)
        Dim sError As String = ""

        Dim oTime As DateTime = DateTime.Now
        If ReadDatabaseConnection(sError) = False Then
            Try
                LogError("EMSBMSReportService2", "OnStart()", sError)
                'Dim file As System.IO.StreamWriter
                'file = My.Computer.FileSystem.OpenTextFileWriter("d:\emsbmsreportservice.txt", True)
                'file.WriteLine(sError)
                'file.Close()
            Catch ex As Exception
                LogError("EMSBMSReportService2", "OnStart()", ex.Message)
            End Try

            End
        End If

        m_tmrTime.Interval = 1000
        AddHandler m_tmrTime.Elapsed, AddressOf ElapsedTimer

        m_tmrTime.Start()
    End Sub

    Protected Overrides Sub OnStop()
        LogError("EMSBMSReportService2", "OnStop()", "Service Stopped")
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub
    Private Sub ElapsedTimer()
        m_tmrTime.Stop()

        MactusReportLib.GenerateReport()

        m_tmrTime.Start()
    End Sub
End Class
