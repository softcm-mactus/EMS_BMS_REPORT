Imports System.ComponentModel.Design
Imports System.Data.Odbc
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports EmsBMSReports.dlgTableView
Imports MactusReportLib.MactusReportLib
Public Class DlgConfigureViewGroup
    Public Class Column
        Public id As Integer
        Public name As String
    End Class
    Public Class Group
        Public name As String
        Public columns As New List(Of Column)
    End Class
    Public Class Category
        Public name As String
        Public groups As New List(Of Group)
        Public groupMap As New Dictionary(Of String, Group)
    End Class
    Public Class ColumnMetaData
        Public id As Integer
        Public name As String
        Public source As String
        Public Overrides Function ToString() As String
            ToString = id.ToString() + ": " + name + ":" + source
        End Function

    End Class
    Public categories As New List(Of Category)
    Public categoriesMap As New Dictionary(Of String, Category)
    Public metaData As New Dictionary(Of Integer, ColumnMetaData)
    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles colGrid.CellContentClick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles addCategory.Click
        Dim node = groupView.Nodes.Add("Category " + categories.Count.ToString())
        Dim c As New Category
        c.name = node.Text
        node.Tag = c
        node.BeginEdit()
        categories.Add(c)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles addGroup.Click
        Dim parent = groupView.SelectedNode
        If parent IsNot Nothing Then
            If parent.Parent IsNot Nothing Then
                parent = parent.Parent
            End If
            If parent.Tag IsNot Nothing And TypeOf (parent.Tag) Is Category Then
                Dim parentCategory As Category = parent.Tag
                Dim node = parent.Nodes.Add("Group " + parentCategory.groups.Count.ToString())
                Dim g As New Group
                g.name = node.Text
                node.Tag = g
                node.BeginEdit()
                parentCategory.groups.Add(g)
            End If
        End If

    End Sub

    Private Sub DlgConfigureViewGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sQuery = "SELECT * FROM nsp.Trend_Meta order by ExternalLogId"
            Dim eConnection As New OdbcConnection(g_sEMSDbConString)
            eConnection.Open()
            Dim oCmd = New OdbcCommand(sQuery, eConnection)
            Dim oReader = oCmd.ExecuteReader
            Dim kvCol As DataGridViewComboBoxColumn = colGrid.Columns(0)
            While oReader.Read()
                Dim o As New ColumnMetaData
                o.id = Integer.Parse(oReader("ExternalLogId"))
                Try
                    o.source = Integer.Parse(oReader("Source"))
                    o.name = o.source.Split("/").Last
                Catch ex As Exception

                End Try
                metaData.Add(o.id, o)
            End While
            kvCol.DataSource = metaData.Values
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim sQuery = "SELECT * FROM TBL_ReportGroups order by CategoryName, GroupName, ExternalLogId"
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            Dim oReader = oCmd.ExecuteReader()
            While oReader.Read()
                Dim o = New Column
                o.id = Integer.Parse(oReader("ExternalLogId"))
                o.name = oReader("ColumnName")
                Dim cat As Category
                Dim group As Group
                If Not categoriesMap.ContainsKey(oReader("CategoryName")) Then
                    cat = New Category
                    cat.name = oReader("CategoryName")
                    categoriesMap.Add(cat.name, cat)
                    categories.Add(cat)
                Else
                    cat = categories(oReader("CategoryName"))
                End If
                If Not cat.groupMap.ContainsKey(oReader("GroupName")) Then
                    group = New Group
                    group.name = oReader("GroupName")
                    cat.groupMap.Add(group.name, group)
                    cat.groups.Add(group)
                Else
                    group = cat.groups(oReader("GroupName"))
                End If
                group.columns.Add(o)
            End While
            Dim isFirst = True
            For Each c In categories
                Dim n = groupView.Nodes.Add(c.name)
                n.Tag = c
                If isFirst Then
                    groupView.SelectedNode = n
                End If
                For Each g In c.groups
                    Dim n1 = n.Nodes.Add(g.name)
                    n1.Tag = g
                    If isFirst Then
                        groupView.SelectedNode = n1
                        colGrid.Rows.Clear()
                        For Each col In g.columns
                            Dim r = colGrid.Rows.Add()
                            colGrid.Rows(r).Tag = col
                            colGrid.Rows(r).Cells(0).Value = col.id.ToString()
                            colGrid.Rows(r).Cells(1).Value = col.name
                        Next
                    End If
                    isFirst = False
                Next
                isFirst = False
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub groupView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles groupView.AfterSelect

    End Sub

    Private Sub addGroup_TextChanged(sender As Object, e As EventArgs) Handles addGroup.TextChanged
        Dim parent = groupView.SelectedNode
        If parent IsNot Nothing Then
            If parent.Tag IsNot Nothing And TypeOf (parent.Tag) Is Category Then
                Dim parentCategory As Category = parent.Tag
                parentCategory.name = parent.Text
            ElseIf parent.Tag IsNot Nothing And TypeOf (parent.Tag) Is Group Then
                Dim parentGroup As Group = parent.Tag
                parentGroup.name = parent.Text
            End If
        End If
    End Sub

    Private Sub groupView_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles groupView.MouseDoubleClick
        Dim parent = groupView.SelectedNode
        If parent IsNot Nothing Then
            If parent.Tag IsNot Nothing And TypeOf (parent.Tag) Is Category Then
                parent.BeginEdit()
            ElseIf parent.Tag IsNot Nothing And TypeOf (parent.Tag) Is Group Then
                parent.BeginEdit()
            End If
        End If
    End Sub

    Private Sub colGrid_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles colGrid.MouseDoubleClick
        Try
            colGrid.EditMode = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub colGrid_TextChanged(sender As Object, e As EventArgs) Handles colGrid.TextChanged
        For r = 0 To colGrid.Rows.Count
            Try
                Dim c As Column = colGrid.Rows(r).Tag
                c.id = Integer.Parse(colGrid.Rows(r).Cells(0).Value)
                c.name = colGrid.Rows(r).Cells(1).Value
            Catch ex As Exception

            End Try
        Next
    End Sub
End Class