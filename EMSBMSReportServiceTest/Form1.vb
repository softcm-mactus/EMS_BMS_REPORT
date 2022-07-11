Imports System.Data.Odbc
Imports MactusReportLib.MactusReportLib
Imports MactusReportLib.IndusoftEMSReport
Imports MactusReportLib

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sError As String = ""

            Dim oTime As DateTime = DateTime.Now
            If ReadDatabaseConnection(sError) = False Then
                Try
                    Dim file As System.IO.StreamWriter
                    file = My.Computer.FileSystem.OpenTextFileWriter("d:\emsbmsreportservice.txt", True)
                    file.WriteLine(sError)
                    file.Close()
                Catch ex As Exception

                End Try

                End
            End If

            Timer1.Interval = 1000
            Timer1.Start()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()

            Static bErrorCheckTimerStarted As Boolean = False

            MactusReportLib.GenerateReport()

            If Now.Second > 5 And bErrorCheckTimerStarted = False Then
                '   m_tmrErrorCheck.Start()
                bErrorCheckTimerStarted = True
            End If

            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub
End Class
