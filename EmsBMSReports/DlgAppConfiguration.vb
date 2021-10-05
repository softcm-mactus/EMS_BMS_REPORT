Imports System.Data.Odbc
Imports System.Windows.Forms

Public Class DlgAppConfiguration

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgAppConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateGridView()
    End Sub

    Private Sub UpdateGridView()
        Dim oButton As DataGridViewButtonCell
        Dim oCheckBox As DataGridViewCheckBoxCell
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nType As Integer
        Dim sValue As String
        Dim nRow As Integer

        'Delete all old rows if any
        oGrid.Rows.Clear()

        sQuery = "SELECT * FROM TBL_ReportAppConfig"

        Using oConnection As New OdbcConnection(MactusReportLib.g_sConString)
            Dim cmd As New OdbcCommand(sQuery, oConnection)
            oConnection.Open()
            oReader = cmd.ExecuteReader()
            While oReader.Read()
                nRow = oGrid.Rows.Add
                nType = oReader("Type")
                sValue = oReader("Value")
                oGrid.Rows(nRow).Cells(0).Value = oReader("ID")
                oGrid.Rows(nRow).Cells(1).Value = oReader("Description")
                oGrid.Rows(nRow).Cells(2).Value = nType
                'Try
                '    oGrid.Rows(nRow).Cells(4).Value = oReader("MinValue")
                'Catch ex As Exception
                '    If nType = 1 Or nType = 3 Then 'String or Dir
                '        oGrid.Rows(nRow).Cells(4).Value = 10
                '    Else
                '        oGrid.Rows(nRow).Cells(4).Value = 0
                '    End If
                'End Try
                'Try
                '    oGrid.Rows(nRow).Cells(5).Value = oReader("MaxValue")
                'Catch ex As Exception
                '    If nType = 1 Or nType = 3 Then 'String or Dir
                '        oGrid.Rows(nRow).Cells(5).Value = 95
                '    Else
                '        oGrid.Rows(nRow).Cells(5).Value = 60
                '    End If
                'End Try

                If nType = 2 Then 'Checkbox
                    oCheckBox = New DataGridViewCheckBoxCell
                    oCheckBox.Value = CBool(sValue)
                    oCheckBox.ValueType = GetType(System.Boolean)

                    oGrid.Rows(nRow).Cells(3) = oCheckBox
                    oCheckBox = New DataGridViewCheckBoxCell
                    oCheckBox.Value = CBool(sValue)
                    oCheckBox.ValueType = GetType(System.Boolean)
                    oGrid.Rows(nRow).Cells(6) = oCheckBox
                ElseIf nType = 3 Then 'Folder
                    oButton = New DataGridViewButtonCell
                    oButton.ValueType = GetType(System.String)
                    oButton.Value = Convert.ToString(sValue)
                    oGrid.Rows(nRow).Cells(3) = oButton
                    oButton = New DataGridViewButtonCell
                    oButton.ValueType = GetType(System.String)
                    oButton.Value = Convert.ToString(sValue)
                    oGrid.Rows(nRow).Cells(6) = oButton
                Else
                    oGrid.Rows(nRow).Cells(3).Value = sValue
                    oGrid.Rows(nRow).Cells(6).Value = sValue
                End If
            End While
            oConnection.Close()
        End Using
        oGrid.ClearSelection()
        oGrid.Refresh()
    End Sub

    Private Sub oGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellClick
        Dim nType As Integer
        If e.ColumnIndex = 3 And e.RowIndex > 0 Then
            nType = oGrid.Rows(e.RowIndex).Cells(2).Value
            If nType = 3 Then
                Dim folderDlg As New FolderBrowserDialog
                folderDlg.ShowNewFolderButton = False
                folderDlg.SelectedPath = oGrid.Rows(e.RowIndex).Cells(3).Value
                If (folderDlg.ShowDialog() = DialogResult.OK) Then
                    oGrid.Rows(e.RowIndex).Cells(3).Value = folderDlg.SelectedPath
                End If
            End If
        End If
    End Sub

    Private Sub oGrid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles oGrid.CellValueChanged
        'Don't Handle for header row
        If e.RowIndex = -1 Then
            Exit Sub
        End If
        If e.ColumnIndex <> 3 Then
            Exit Sub
        End If

        Dim nID As Integer
        Dim nType As Integer
        Dim sValue As String = ""
        Dim nTemp As Integer
        Try

            nID = oGrid.Rows(e.RowIndex).Cells(0).Value
            nType = oGrid.Rows(e.RowIndex).Cells(2).Value
            If nType = 0 Then
                Exit Sub
            End If
            sValue = oGrid.Rows(e.RowIndex).Cells(3).Value
            'If nType = 1 Or nType = 3 Then 'String or Dir
            '    If sValue.Length() < oGrid.Rows(e.RowIndex).Cells(4).Value Then
            '        ShowMessageBox("Text Length Is Smaller Than MinValue", MessageBoxIcon.Error)
            '        oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
            '    ElseIf sValue.Length() > oGrid.Rows(e.RowIndex).Cells(5).Value Then
            '        ShowMessageBox("Text Length Is Larger Than MaxValue", MessageBoxIcon.Error)
            '        oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
            '    Else
            '        oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.White
            '    End If
            'End If

            If nType = 4 Then
                Try
                    nTemp = CInt(sValue)
                    'If nTemp < oGrid.Rows(e.RowIndex).Cells(4).Value Then
                    '    ShowMessageBox("Entered Value Is Smaller Than MinValue", MessageBoxIcon.Error)
                    '    oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                    'ElseIf nTemp > oGrid.Rows(e.RowIndex).Cells(5).Value Then
                    '    ShowMessageBox("Entered Value Is Larger Than MaxValue", MessageBoxIcon.Error)
                    '    oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                    'Else
                    '    oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.White
                    'End If
                    oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.White
                Catch ex As Exception
                    oGrid.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                    MessageBox.Show("Please Enter Valid Numeric Value", "Report Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    oGrid.Rows(e.RowIndex).Cells(3).Value = oGrid.Rows(e.RowIndex).Cells(6).Value
                End Try

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        Dim nRowIndex As Integer = 0
        Dim nID As Integer = 0
        Dim sDesc As String
        Dim sOldValue As String = ""
        Dim sNewValue As String
        Dim sQuery As String
        Dim bChanged As Boolean = False
        Dim nType As Integer
        Dim bError As Boolean = False
        Dim sValue As String
        Dim nTemp As Integer
        Dim nCount As Integer = 0

        For nRowIndex = 0 To oGrid.Rows.Count - 1
            sValue = oGrid.Rows(nRowIndex).Cells(3).Value
            nType = oGrid.Rows(nRowIndex).Cells(2).Value
            If nType = 4 Then
                Try
                    nTemp = CInt(sValue)

                    oGrid.Rows(nRowIndex).Cells(3).Style.BackColor = Color.White

                Catch ex As Exception
                    oGrid.Rows(nRowIndex).Cells(3).Style.BackColor = Color.OrangeRed
                    bError = True
                    oGrid.Rows(nRowIndex).Cells(3).Value = oGrid.Rows(nRowIndex).Cells(6).Value
                End Try
            End If
        Next

        If bError Then
            MessageBox.Show("Please Correct Data Validation Errors. No Records Updated", "Report Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("Do You Really Want To Update the Site Configuration?", "Report Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If


        'Validate The Data
        For nRowIndex = 0 To oGrid.Rows.Count - 1
            nID = oGrid.Rows(nRowIndex).Cells(0).Value
            nType = oGrid.Rows(nRowIndex).Cells(2).Value
            sDesc = oGrid.Rows(nRowIndex).Cells(1).Value
            If nType = 2 Then
                If oGrid.Rows(nRowIndex).Cells(3).Value Then
                    sNewValue = "1"
                Else
                    sNewValue = "0"
                End If
            Else
                sNewValue = oGrid.Rows(nRowIndex).Cells(3).Value.ToString
            End If

            If oGrid.Rows(nRowIndex).Cells(3).Value <> oGrid.Rows(nRowIndex).Cells(6).Value Then
                sQuery = "Update TBL_ReportAppConfig SET Value = '" + sNewValue + "' WHERE ID=" + nID.ToString
                MactusReportLib.ExecuteSQLInDb(sQuery)
                bChanged = True
                nCount = nCount + 1
            End If
        Next

        If bChanged Then
            MessageBox.Show(nCount.ToString() + " Records Updated. You Need to Restart Server Computer and Client Application For Changes To Take Effect ", "Report Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
End Class
