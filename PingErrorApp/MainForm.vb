Imports System.Net.NetworkInformation

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sIP As String
        Dim nRow As Integer
        Try
            Dim file As System.IO.StreamReader
            file = My.Computer.FileSystem.OpenTextFileReader("iplist.txt", System.Text.Encoding.ASCII)
            Do While file.Peek() <> -1
                sIP = file.ReadLine()
                If System.Net.IPAddress.TryParse(tIP.Text, Nothing) Then
                    nRow = oIPList.Rows.Add()
                    oIPList.Rows(nRow).Cells(0).Value = sIP
                    oIPList.Rows(nRow).Cells(1).Value = -1

                End If
            Loop
            file.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        oGrid.ClearSelection()
        oGrid.Refresh()
        ReadTextFile()

        nRow = oIPList.Rows.Add()
        oIPList.Rows(nRow).Cells(0).Value = "192.168.100.1"
        oIPList.Rows(nRow).Cells(1).Value = -1
        nRow = oIPList.Rows.Add()
        oIPList.Rows(nRow).Cells(0).Value = "192.168.100.119"
        oIPList.Rows(nRow).Cells(1).Value = -1
    End Sub
    Private Sub ReadTextFile()
        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("iplist.txt")
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim currentRow As String()
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        Dim currentField As String
                        For Each currentField In currentRow
                            MsgBox(currentField)
                        Next
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                    End Try
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub bAdd_Click(sender As Object, e As EventArgs) Handles bAdd.Click
        Dim nRow As Integer
        If System.Net.IPAddress.TryParse(tIP.Text, Nothing) Then
            nRow = oIPList.Rows.Add()
            oIPList.Rows(nRow).Cells(0).Value = tIP.Text
            oIPList.Rows(nRow).Cells(1).Value = -1
            oGrid.ClearSelection()
            oGrid.Refresh()
        End If

    End Sub

    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        oTimer.Enabled = False
        oTimer.Interval = nInterval.Value * 1000
        Dim sIP As String
        Dim nPrevStatus As Integer



        Dim oTime As Date
        oTime = Now
        oIPList.ClearSelection()
        oIPList.Refresh()
        For nRow = 0 To oIPList.Rows.Count - 1
            sIP = oIPList.Rows(nRow).Cells(0).Value
            nPrevStatus = oIPList.Rows(nRow).Cells(1).Value
            Try
                Dim oPing = New Ping()
                Dim oPingReply = oPing.Send(sIP)
                If oPingReply.Status = IPStatus.Success Then
                    oIPList.Rows(nRow).Cells(0).Style.BackColor = Color.LightGreen
                    oIPList.Rows(nRow).Cells(1).Value = 1
                Else
                    oIPList.Rows(nRow).Cells(0).Style.BackColor = Color.OrangeRed
                    oIPList.Rows(nRow).Cells(1).Value = 0
                End If

            Catch ex As Exception

            End Try
        Next

        Label1.Text = Now.Subtract(oTime).TotalSeconds.ToString
        oTimer.Enabled = True
    End Sub

    Private Sub bStartStop_Click(sender As Object, e As EventArgs) Handles bStartStop.Click
        Static Dim bRunning As Boolean = False

        If bRunning = False Then
            bRunning = True
            oTimer.Enabled = True
            bStartStop.Text = "Stop"
        Else
            bRunning = False
            oTimer.Enabled = False
            bStartStop.Text = "Start"
        End If

    End Sub
End Class
