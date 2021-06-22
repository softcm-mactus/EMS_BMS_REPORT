Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Windows.Forms.DataVisualization.Charting

Public Class IndusoftCharReport

    Private g_sReportTitle As String
    Public g_nReportID As Integer
    Public g_nReportType As ReportType
    Public g_nAlmGroupID As Integer

    Private g_fSideMargin As Single = 40
    Private g_fTopBottomMargin As Single = 30
    Private g_fSideFactor As Single = 79.9

    Private g_nHeaderPad = 6
    Private g_nFooterPad = 3
    Private g_nBodyPad = 1
    Private g_nBodyHeaderPad = 2

    Private g_nTimeIntervalMin As Integer
    Private g_nDataAgg As DataAgg
    Private g_bLandScape As Boolean


    Private g_bFRomToDatesPrinted As Boolean
    Private g_sDataTableName As String
    Private g_sGeneratedUserName As String
    Private g_oFooterRowList As New List(Of FooterRow)


    'Body Font
    Private g_oBodyFont As iTextSharp.text.Font
    Private g_oBodyFontLow As iTextSharp.text.Font
    Private g_oBodyFontHigh As iTextSharp.text.Font
    Private g_oBodyHeaderFont As iTextSharp.text.Font

    Private g_oFooterFont As iTextSharp.text.Font

    Private g_oH1Font As iTextSharp.text.Font
    Private g_oH2Font As iTextSharp.text.Font
    Private g_oHFont As iTextSharp.text.Font
    Private g_bIconNeeded As Boolean
    Private g_bGeneratedTime As Boolean
    Private g_bGeneratedBy As Boolean

    Private g_oReportFontName As MyFontFamily = 2 ' Font.FontFamily = iTextSharp.text.Font.FontFamily.TIMES_ROMAN

    Private g_sReportFontName As String


    Private Class IEntryExitReportEvents
        Inherits PdfPageEventHelper

        'This Is the contentbyte object of the writer
        Dim cb As PdfContentByte
        'we will put the final number of pages in a template
        Dim FooterTemplate As PdfTemplate

        Public g_oFooterFont As iTextSharp.text.Font

        Public g_oH1Font As iTextSharp.text.Font
        Public g_oH2Font As iTextSharp.text.Font
        Public g_oHFont As iTextSharp.text.Font
        Public g_bIconNeeded As Boolean
        Public g_bGeneratedTime As Boolean
        Public g_bGeneratedBy As Boolean
        Public g_fSideMargin As Single = 40
        Public g_fTopBottomMargin As Single = 30
        Public g_fSideFactor As Single = 79.9
        Public g_nHeaderPad = 6
        Public g_nFooterPad = 3
        Public g_nBodyPad = 1
        Public g_nBodyHeaderPad = 2
        Public g_sGeneratedUserName As String
        Public g_bLandScape As Boolean
        Public g_oBodyHeaderFont As iTextSharp.text.Font
        Public g_oFooterRowList As List(Of FooterRow)
        Public g_sReportFontName As String
        Public g_nReportType As ReportType


        Public Overrides Sub OnOpenDocument(writer As PdfWriter, document As Document)
            MyBase.OnOpenDocument(writer, document)
            Try
                cb = writer.DirectContent
                FooterTemplate = cb.CreateTemplate(50, 50)
            Catch ex As Exception

            End Try
        End Sub

        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            MyBase.OnEndPage(writer, document)


            Try
                ''Header
                Dim fTemp As Single
                Dim oHeaderTable As PdfPTable

                oHeaderTable = New PdfPTable(1)
                oHeaderTable.TotalWidth = (document.PageSize.Width - 2 * g_fSideMargin) * 0.75
                fTemp = (document.PageSize.Width - 2 * g_fSideMargin) * 0.25
                If g_bHeader1 Then
                    Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader1, g_oH1Font))
                    oHeaderCell.PaddingTop = g_nHeaderPad
                    oHeaderCell.PaddingBottom = g_nHeaderPad
                    oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oHeaderCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oHeaderTable.AddCell(oHeaderCell)
                End If
                If g_bHeaderAddress Then
                    Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeaderAddress, g_oBodyHeaderFont))
                    oHeaderCell.PaddingTop = g_nBodyPad
                    oHeaderCell.PaddingBottom = g_nBodyPad
                    oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oHeaderCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oHeaderTable.AddCell(oHeaderCell)
                End If

                If g_bHeader2 Then
                    Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader2, g_oH2Font))
                    oHeaderCell.PaddingTop = g_nHeaderPad
                    oHeaderCell.PaddingBottom = g_nHeaderPad
                    oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oHeaderCell.VerticalAlignment = Element.ALIGN_CENTER
                    oHeaderTable.AddCell(oHeaderCell)
                End If
                If g_bHeader3 Then
                    Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader3, g_oHFont))
                    oHeaderCell.PaddingTop = g_nHeaderPad
                    oHeaderCell.PaddingBottom = g_nHeaderPad
                    oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oHeaderCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oHeaderTable.AddCell(oHeaderCell)
                End If
                oHeaderTable.WriteSelectedRows(0, -1, g_fSideMargin + fTemp, document.PageSize.Height - g_fTopBottomMargin, writer.DirectContent)

                Dim xtemo, ytemp As Single
                If g_bIconNeeded Then
                    Dim oImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(g_sInFileDir + "\\Images\\ReportLogo.PNG")

                    xtemo = g_fSideMargin + ((fTemp - oImage.width) * 0.5)
                    ytemp = document.PageSize.Height - g_fTopBottomMargin - oImage.Height - (oHeaderTable.TotalHeight - oImage.Height) * 0.5
                    oImage.SETABSOLUTEPOSITION(xtemo, ytemp)
                    document.ADD(oImage)

                    ytemp = document.PageSize.Height - g_fTopBottomMargin - oHeaderTable.TotalHeight
                    cb.SetLineWidth(0.5)
                    cb.MoveTo(g_fSideMargin, ytemp)
                    cb.LineTo(g_fSideMargin + fTemp, ytemp)
                    cb.Stroke()

                End If

                Dim nBodyDeaderYPos As Integer
                nBodyDeaderYPos = document.PageSize.Height - g_fTopBottomMargin - oHeaderTable.TotalHeight ' - 3

                '//Add paging to footer // commanded for footer
                Dim bf As BaseFont = BaseFont.CreateFont(g_sReportFontName, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

                Dim sTemp As String

                cb.BeginText()
                cb.SetFontAndSize(bf, g_fFooterFontSize)

                sTemp = ""
                If g_bGeneratedBy Then
                    sTemp = g_sGeneratedBy + g_sGeneratedUserName
                End If
                If g_bGeneratedTime Then
                    If g_bLandScape Then
                        sTemp = sTemp + g_sLSpace + g_sGeneratedTime + Now.ToString(g_sTimeFormatIndian)
                    Else
                        sTemp = sTemp + g_sPspace + g_sGeneratedTime + Now.ToString(g_sTimeFormatIndian)
                    End If

                End If

                If sTemp.Length() > 0 Then
                    cb.SetTextMatrix(g_fSideMargin * 1.5, g_fTopBottomMargin + 7)
                    cb.ShowText(sTemp)
                End If

                Dim fLen As Single



                sTemp = "Page " + Convert.ToString(writer.PageNumber) + " of 9999"
                fLen = bf.GetWidthPoint(sTemp, g_fFooterFontSize)
                sTemp = "Page " + Convert.ToString(writer.PageNumber) + " of "
                cb.SetTextMatrix(document.PageSize.Width - g_fSideMargin * 1.5 - fLen, g_fTopBottomMargin + 7)
                cb.ShowText(sTemp)

                'Add Position of Page Number Template in Page
                sTemp = "9999"
                fLen = bf.GetWidthPoint(sTemp, g_fFooterFontSize)
                cb.EndText()
                Dim xPos As Double
                Dim yPos As Double
                xPos = document.PageSize.Width - g_fSideMargin * 1.5 - fLen
                yPos = g_fTopBottomMargin + 7
                cb.AddTemplate(FooterTemplate, xPos, yPos)

                'Move the pointer And draw line to separate header section from rest of page
                cb.SetLineWidth(2.0)
                cb.MoveTo(g_fSideMargin, document.PageSize.Height - g_fTopBottomMargin)
                cb.LineTo(document.PageSize.Width - g_fSideMargin, document.PageSize.Height - g_fTopBottomMargin)
                cb.LineTo(document.PageSize.Width - g_fSideMargin, g_fTopBottomMargin)
                cb.LineTo(g_fSideMargin, g_fTopBottomMargin)
                cb.LineTo(g_fSideMargin, document.PageSize.Height - g_fTopBottomMargin)
                cb.Stroke()

                Dim oBodyHeaderTable As PdfPTable = New PdfPTable(g_oColList.Count)
                oBodyHeaderTable.TotalWidth = document.PageSize.Width - 3 * g_fSideMargin
                oBodyHeaderTable.WidthPercentage = 90
                oBodyHeaderTable.HorizontalAlignment = Element.ALIGN_CENTER

                Dim nCol As Integer
                Dim sColWidths(g_oColList.Count - 1) As Single
                For nCol = 0 To g_oColList.Count - 1
                    sColWidths(nCol) = g_oColList(nCol).m_sColWidth
                Next
                oBodyHeaderTable.SetWidths(sColWidths)

                Dim nH1Cols As Integer = g_oColList.Count
                For nCol = 0 To g_oColList.Count - 1
                    nH1Cols = nH1Cols - g_oColList(nCol).m_nColMerge
                Next
                Dim oBodyHeaderTable2 As PdfPTable = New PdfPTable(nH1Cols)
                oBodyHeaderTable2.TotalWidth = document.PageSize.Width - 3 * g_fSideMargin
                oBodyHeaderTable2.WidthPercentage = 90
                oBodyHeaderTable2.HorizontalAlignment = Element.ALIGN_CENTER

                ' LogError(nH1Cols.ToString())
                Dim sColWidths2(nH1Cols - 1) As Single
                nH1Cols = 0
                For nCol = 0 To g_oColList.Count - 1
                    Dim sTemp1 As Single = 0
                    For nMerge = 0 To g_oColList(nCol).m_nColMerge
                        sTemp1 += g_oColList(nCol + nMerge).m_sColWidth
                    Next
                    sColWidths2(nH1Cols) = sTemp1
                    nCol += g_oColList(nCol).m_nColMerge
                    nH1Cols += 1
                Next
                oBodyHeaderTable2.SetWidths(sColWidths2)



                If g_nReportType = ReportType.DataReport Then
                    For nCol = 0 To g_oColList.Count - 1


                        Dim oColHeader As PdfPCell = New PdfPCell(New Phrase(g_oColList(nCol).m_sColType, g_oBodyHeaderFont))
                        oColHeader.PaddingBottom = g_nBodyPad
                        oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                        If g_oColList(nCol).m_nColJust = ColJust.Left Then
                            oColHeader.HorizontalAlignment = Element.ALIGN_LEFT
                        ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                            oColHeader.HorizontalAlignment = Element.ALIGN_RIGHT
                        Else
                            oColHeader.HorizontalAlignment = Element.ALIGN_CENTER
                        End If

                        oColHeader.VerticalAlignment = Element.ALIGN_MIDDLE

                        oBodyHeaderTable2.AddCell(oColHeader)
                        nCol += g_oColList(nCol).m_nColMerge

                    Next
                End If
                oBodyHeaderTable2.WriteSelectedRows(0, -1, g_fSideMargin * 1.5, nBodyDeaderYPos, writer.DirectContent)
                nBodyDeaderYPos -= oBodyHeaderTable2.TotalHeight

                For nCol = 0 To g_oColList.Count - 1
                    Dim oColHeader As PdfPCell
                    oColHeader = New PdfPCell(New Paragraph(g_oColList(nCol).m_sColTitle, g_oBodyHeaderFont))

                    oColHeader.PaddingBottom = g_nBodyPad
                    oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    If g_oColList(nCol).m_nColJust = ColJust.Left Then
                        oColHeader.HorizontalAlignment = Element.ALIGN_LEFT
                    ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                        oColHeader.HorizontalAlignment = Element.ALIGN_RIGHT
                    Else
                        oColHeader.HorizontalAlignment = Element.ALIGN_CENTER
                    End If

                    oColHeader.VerticalAlignment = Element.ALIGN_MIDDLE
                    oBodyHeaderTable.AddCell(oColHeader)
                Next
                oBodyHeaderTable.WriteSelectedRows(0, -1, g_fSideMargin * 1.5, nBodyDeaderYPos, writer.DirectContent)



                'Write Footer Table
                Dim oFooterTable As PdfPTable = New PdfPTable(3)
                oFooterTable.TotalWidth = document.PageSize.Width - 3 * g_fSideMargin
                oFooterTable.HorizontalAlignment = Element.ALIGN_CENTER

                Dim oFooterCell As PdfPCell

                For nCol = 0 To g_oFooterRowList.Count - 1
                    oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol1, g_oFooterFont))
                    oFooterCell.PaddingTop = g_nFooterPad
                    oFooterCell.PaddingBottom = g_nFooterPad
                    If g_oFooterRowList(nCol).m_bHeader Then
                        oFooterCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY
                    End If
                    oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oFooterTable.AddCell(oFooterCell)

                    oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol2, g_oFooterFont))
                    oFooterCell.PaddingTop = g_nFooterPad
                    oFooterCell.PaddingBottom = g_nFooterPad
                    If g_oFooterRowList(nCol).m_bHeader Then
                        oFooterCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY
                    End If
                    oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oFooterTable.AddCell(oFooterCell)

                    oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol3, g_oFooterFont))
                    oFooterCell.PaddingTop = g_nFooterPad
                    oFooterCell.PaddingBottom = g_nFooterPad
                    If g_oFooterRowList(nCol).m_bHeader Then
                        oFooterCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY
                    End If
                    oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oFooterTable.AddCell(oFooterCell)
                Next

                oFooterTable.WriteSelectedRows(0, -1, g_fSideMargin * 1.5, g_fTopBottomMargin + oFooterTable.TotalHeight + 19, writer.DirectContent)

            Catch ex As Exception

            End Try

        End Sub
        Public Overrides Sub OnCloseDocument(writer As PdfWriter, document As Document)
            MyBase.OnCloseDocument(writer, document)
            Try
                Dim oFont As BaseFont
                oFont = BaseFont.CreateFont(g_sReportFontName, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

                FooterTemplate.BeginText() ' comnnaded For footer
                FooterTemplate.SetFontAndSize(oFont, g_fFooterFontSize)
                FooterTemplate.SetTextMatrix(0, 0)
                FooterTemplate.ShowText((writer.PageNumber - 1).ToString())
                FooterTemplate.EndText()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


    End Class


    Public Sub ReadReportConfiguration(ByVal nReportID As Integer)
        g_nReportID = nReportID
        g_nHeaderCount = 2

        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim nTemplateID As Integer = 0

        g_bHeader1 = True
        g_bHeader2 = True
        g_bHeader3 = False

        If g_bHeaderAddress Then
            g_nHeaderCount += 1
        End If

        Try
            sQuery = "SELECT * FROM TBL_ReportsConfiguration WHERE ReportID=" + g_nReportID.ToString
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader()
            If oReader.Read() Then
                nTemplateID = oReader("TemplateID")
                g_sReportTitle = oReader("ReportTitle")
                g_sReportTitle = g_sReportTitle.Replace(":", "_")
                g_sReportTitle = g_sReportTitle.Replace(" ", "_")
                g_sReportTitle = g_sReportTitle.Replace("&", "_")
                Try
                    g_nReportType = oReader("ReportType")
                Catch ex As Exception
                    g_nReportType = ReportType.DataReport
                End Try

                Try
                    If g_nReportType = ReportType.AlarmReport Then
                        g_nAlmGroupID = oReader("AlmGroupID")
                    Else
                        g_nAlmGroupID = 0
                    End If
                Catch ex As Exception
                    g_nAlmGroupID = 0
                End Try


                Try
                    g_sHeader2 = oReader("ReportTitle")
                    g_sHeader2.Trim()
                Catch ex As Exception
                    g_sHeader2 = "Report Title Not Defined"
                End Try


                Try
                    g_sHeader3 = oReader("ReportHeader")
                    g_sHeader3.Trim()
                Catch ex As Exception
                    g_sHeader3 = ""
                End Try
                If g_sHeader3 <> "" Then
                    g_bHeader3 = True
                    g_nHeaderCount += 1
                End If

                Try
                    g_bGeneratedTime = oReader("GeneratedTime")
                Catch ex As Exception
                    g_bGeneratedTime = False
                End Try
                Try
                    g_bGeneratedBy = oReader("GeneratedBy")
                Catch ex As Exception
                    g_bGeneratedBy = False
                End Try

                Try
                    g_bFRomToDatesPrinted = oReader("FromToDatesPrinted")
                Catch ex As Exception
                    g_bGeneratedBy = False
                End Try

                g_sDataTableName = oReader("DataTablename")

                Try
                    g_nTimeIntervalMin = oReader("TimeIntervalInMin")
                Catch ex As Exception
                    g_nTimeIntervalMin = 1
                End Try
                Try
                    If g_nReportType = ReportType.DataReport And g_nTimeIntervalMin > 1 Then
                        g_nDataAgg = oReader("DataAggregationType")
                    Else
                        g_nDataAgg = DataAgg.Instance
                    End If
                Catch ex As Exception
                    g_nDataAgg = DataAgg.Instance
                End Try

            End If

            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ReadReportTemplateConfiguration(nTemplateID)

        ReadReportColumnConfiguration(nReportID)

        g_oH1Font = New iTextSharp.text.Font(g_oReportFontName, g_fH1FontSize, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)
        g_oH2Font = New iTextSharp.text.Font(g_oReportFontName, g_fH2FontSize, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)
        g_oHFont = New iTextSharp.text.Font(g_oReportFontName, g_fHFontSize, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)

        'Body Font
        g_oBodyFont = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)
        g_oBodyFontLow = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)
        g_oBodyFontHigh = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.Color.RED)
        g_oBodyHeaderFont = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)

        'Footer Font
        g_oFooterFont = New iTextSharp.text.Font(g_oReportFontName, g_fFooterFontSize, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)


    End Sub

    Private Sub ReadReportTemplateConfiguration(ByRef nTemplateID As Integer)
        g_oFooterRowList.Clear()
        Try

            Dim sQuery As String
            Dim oReader As OdbcDataReader
            Dim sTemp As String


            sQuery = "SELECT * FROM TBL_ReportTemplates WHERE TemplateID=" + nTemplateID.ToString()

            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader

            If oReader.Read() Then
                Dim oCol As New ReportColumn
                oCol.m_nID = oReader("TemplateID")
                g_bLandScape = oReader("LandScape")
                g_bIconNeeded = oReader("IsIconNeeded")

                Dim oFooterRow As FooterRow
                oFooterRow = New FooterRow(True, oReader("FooterTableCol1"), oReader("FooterTableCol2"), oReader("FooterTableCol3"))
                g_oFooterRowList.Add(oFooterRow)

                sTemp = oReader("Footer1")
                sTemp = sTemp.Trim()
                If sTemp.Length > 0 Then
                    oFooterRow = New FooterRow(sTemp)
                    g_oFooterRowList.Add(oFooterRow)
                End If
                sTemp = oReader("Footer2")
                sTemp = sTemp.Trim()
                If sTemp.Length > 0 Then
                    oFooterRow = New FooterRow(sTemp)
                    g_oFooterRowList.Add(oFooterRow)
                End If
                sTemp = oReader("Footer3")
                sTemp = sTemp.Trim()
                If sTemp.Length > 0 Then
                    oFooterRow = New FooterRow(sTemp)
                    g_oFooterRowList.Add(oFooterRow)
                End If
                sTemp = oReader("Footer4")
                sTemp = sTemp.Trim()
                If sTemp.Length > 0 Then
                    oFooterRow = New FooterRow(sTemp)
                    g_oFooterRowList.Add(oFooterRow)
                End If



                g_fTopBottomMargin = oReader("TopBottomMargin")
                g_fSideMargin = oReader("SideMargin")
                g_fSideFactor = oReader("SideFactor")

                g_fH1FontSize = oReader("H1FontSize")
                g_fH2FontSize = oReader("H2FontSize")
                g_fHFontSize = oReader("HFontSize")
                g_fBodyFontSize = oReader("BodyFontSize")
                g_fBodyHeaderFontSize = oReader("BodyHeaderFontSize")
                g_fFooterFontSize = oReader("FooterFontSize")
                g_oReportFontName = oReader("FontName")

                g_nHeaderPad = oReader("HeaderPadding")
                g_nBodyHeaderPad = oReader("BodyHeaderPadding")
                g_nBodyPad = oReader("BodyPadding")
                g_nFooterPad = oReader("FooterPadding")

                If g_oReportFontName = MyFontFamily.COURIER Then
                    g_sReportFontName = BaseFont.COURIER
                ElseIf g_oReportFontName = MyFontFamily.HELVETICA Then
                    g_sReportFontName = BaseFont.HELVETICA
                Else
                    g_oReportFontName = MyFontFamily.TIMES_ROMAN
                    g_sReportFontName = BaseFont.TIMES_ROMAN
                End If

                Try
                    g_oReportFontName = Convert.ToInt32(g_sReportFontName)

                Catch ex As Exception

                End Try


                g_oH1Font = New iTextSharp.text.Font(g_oReportFontName, g_fH1FontSize, iTextSharp.text.Font.BOLD, Color.BLACK)
                g_oH2Font = New iTextSharp.text.Font(g_oReportFontName, g_fH2FontSize, iTextSharp.text.Font.BOLD, Color.BLACK)
                g_oHFont = New iTextSharp.text.Font(g_oReportFontName, g_fHFontSize, iTextSharp.text.Font.BOLD, Color.BLACK)

                'Body Font
                g_oBodyFont = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.NORMAL, Color.BLACK)
                g_oBodyFontLow = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.BOLD, Color.RED)
                g_oBodyFontHigh = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.BOLDITALIC, Color.RED)
                g_oBodyHeaderFont = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.NORMAL, Color.BLACK)

                'Footer Font
                g_oFooterFont = New iTextSharp.text.Font(g_oReportFontName, g_fFooterFontSize, iTextSharp.text.Font.NORMAL, Color.BLACK)

            End If
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReadReportColumnConfiguration(ByRef nReportID As Integer)
        g_oColList.Clear()
        Try
            Dim sQuery As String
            Dim oReader As OdbcDataReader

            If g_nReportType = ReportType.DataReport Then
                sQuery = "SELECT * FROM TBL_ReportColumns WHERE ReportID=" + nReportID.ToString() + " ORDER BY ColSeq"
            ElseIf g_nReportType = ReportType.EventReport Then
                sQuery = "SELECT * FROM TBL_ReportColumns WHERE ReportID=-1 ORDER BY ColSeq"
            ElseIf g_nReportType = ReportType.AlarmReport Then
                sQuery = "SELECT * FROM TBL_ReportColumns WHERE ReportID=-2 ORDER BY ColSeq"
            Else
                Exit Sub
            End If
            Dim oConnection As New OdbcConnection(g_sConString)
            oConnection.Open()
            Dim oCmd As New OdbcCommand(sQuery, oConnection)
            oReader = oCmd.ExecuteReader

            While oReader.Read()
                Dim oCol As New ReportColumn
                oCol.m_nID = oReader("ColumnID")

                If g_nReportType = ReportType.DataReport Then
                    Try
                        oCol.m_nColMerge = oReader("ColMerge")
                    Catch ex As Exception
                        oCol.m_nColMerge = 0
                    End Try
                Else
                    oCol.m_nColMerge = 0
                End If

                oCol.m_nColType = oReader("ColType")
                Try
                    oCol.m_sColType = oReader("coltitle")
                Catch ex As Exception
                    oCol.m_sColType = ""
                End Try
                If oCol.m_sColType = "" Then
                    If oCol.m_nColType = ColType.DateTime Then
                        oCol.m_sColType = "Date Time"
                    ElseIf oCol.m_nColType = ColType.Temperature Then
                        oCol.m_sColType = "Temperature"
                    ElseIf oCol.m_nColType = ColType.Humidity Then
                        oCol.m_sColType = "RH"
                    ElseIf oCol.m_nColType = ColType.DP Then
                        oCol.m_sColType = "Diffrential Pressure"
                    Else
                        oCol.m_sColType = "Other"
                    End If
                End If
                Try
                    oCol.m_sColFormat = oReader("ColFormat")
                Catch ex As Exception
                    oCol.m_sColFormat = ""
                End Try

                Try
                    oCol.m_sColTitle = oReader("ColHeader")
                Catch ex As Exception
                    oCol.m_sColTitle = ""
                End Try

                Try
                    oCol.m_sColWidth = oReader("ColWidth")
                Catch ex As Exception
                    oCol.m_sColWidth = 1.0
                End Try

                Try
                    oCol.m_nColJust = oReader("ColJust")
                Catch ex As Exception
                    oCol.m_nColJust = 0
                End Try
                Try
                    oCol.m_sColumnNameinTable = oReader("ColNameInDB")
                Catch ex As Exception
                    oCol.m_sColumnNameinTable = ""
                End Try

                Try
                    oCol.m_bLowCheck = oReader("LowCheck")
                    If oCol.m_bLowCheck Then
                        oCol.m_fLow = oReader("LowCheckValue")
                    Else
                        oCol.m_fLow = 0
                    End If
                Catch ex As Exception
                    oCol.m_bLowCheck = False
                    oCol.m_fLow = 0
                End Try

                Try
                    oCol.m_bHighCheck = oReader("HighCheck")
                    If oCol.m_bHighCheck Then
                        oCol.m_fHigh = oReader("HighCheckValue")
                    Else
                        oCol.m_fHigh = 0
                    End If
                Catch ex As Exception
                    oCol.m_bHighCheck = False
                    oCol.m_fHigh = 0
                End Try


                If oCol.m_nColType = ColType.DateTime Or oCol.m_nColType = ColType.Other Then
                    oCol.m_bLowCheck = False
                    oCol.m_bHighCheck = False
                End If

                Try
                    oCol.m_nEnumID = oReader("enumid")
                Catch ex As Exception
                    oCol.m_nEnumID = 0
                End Try




                g_oColList.Add(oCol)
            End While




            oReader.Close()
            oConnection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function GenerateTrendReport(ByRef nReportStatusID As Long, ByVal dtFrom As Date, ByVal dtTo As Date, ByRef sOutFileName As String, ByRef nTimeInterval As Integer) As Boolean

        GenerateTrendReport = False
        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0

        'Dim oChart As New Chart()

        'oChart.Series.Add()


        'Dim oSeries As DataVisualization.Charting.Series
        'oChart.Series.Clear()
        'For nIndex = 0 To oGroup.m_oPointIndexList.Count - 1
        '    oPoint = g_oPointList(oGroup.m_oPointIndexList(nIndex))

        '    sQuery += "P" + oPoint.m_nID.ToString + ","

        '    oSeries = oTrendChart.Series.Add(oPoint.m_sTag)
        '    oSeries.ChartType = DataVisualization.Charting.SeriesChartType.Line
        '    oSeries.ChartArea = "ChartArea1"
        '    oSeries.BorderWidth = 3
        '    oSeries.BorderColor = System.Drawing.Color.DarkBlue
        '    oSeries.XValueType = DataVisualization.Charting.ChartValueType.DateTime
        '    oSeries.YValueType = DataVisualization.Charting.ChartValueType.Single

        'Next
        'For nIndex = 0 To oGroup.m_oPointIndexList.Count - 1
        '    oPoint = g_oPointList(oGroup.m_oPointIndexList(nIndex))
        '    Dim DtEMP As Single
        '    Dim fTemp(0) As Double
        '    oSeries = oTrendChart.Series.Item(oPoint.m_sTag)
        '    Try
        '        sTemp = "P" + oPoint.m_nID.ToString
        '        DtEMP = oReader(sTemp)
        '        fTemp(0) = Convert.ToDouble(DtEMP)

        '        oSeries.Points.AddXY(oTime, fTemp(0))

        '    Catch ex As Exception

        '    End Try
        '    Application.DoEvents()
        'Next

        Try

            Using FS As New FileStream(sOutFileName, FileMode.Create, FileAccess.Write, FileShare.None)

                g_oDoc = New Document(PageSize.A4)
                If g_bLandScape Then
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                Else
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4)
                End If

                Dim Writer As PdfWriter = PdfWriter.GetInstance(g_oDoc, FS)
                ''//Bind our PDF object to the physical file using a PdfWriter
                '  Using Writer As PdfWriter = PdfWriter.GetInstance(g_oDoc, FS)
                ''//Open our document for writing
                Dim oPageEvent As New IEntryExitReportEvents
                SetPageEventParameters(oPageEvent)
                Writer.PageEvent = oPageEvent

                CalcualteTopBottomBodyMargins(nTopMargin, nBottomMargin)
                g_oDoc.SetMargins(0.0F, 0, nTopMargin, nBottomMargin)
                g_oDoc.Open()

                Dim oTable = New PdfPTable(g_oColList.Count)
                oTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin

                oTable.WidthPercentage = g_fSideFactor

                oTable.HorizontalAlignment = Element.ALIGN_CENTER

                Dim nCol As Integer
                Dim sColWidths(g_oColList.Count - 1) As Single
                For nCol = 0 To g_oColList.Count - 1
                    sColWidths(nCol) = g_oColList(nCol).m_sColWidth
                Next
                oTable.SetWidths(sColWidths)

                Dim bResult As Boolean

                Dim oTime As DateTime = dtFrom
                oTime = oTime.AddMilliseconds(-oTime.Millisecond)
                oTime = oTime.AddSeconds(-oTime.Second)
                While oTime <= dtTo
                    If nTimeInterval = 1 Or g_nDataAgg = DataAgg.Instance Then
                        bResult = GetColInstanceValues(oTime)
                    Else
                        bResult = GetColAverageMinMaxValues(oTime, nTimeInterval)
                    End If

                    If bResult = True Or (bResult = False And g_bEanbleErrorTextPrint = True) Then
                        For nCol = 0 To g_oColList.Count - 1
                            Dim oPdfCel As PdfPCell
                            If g_oColList(nCol).m_bError Then
                                oPdfCel = New PdfPCell(New Paragraph(g_oColList(nCol).m_sValue, g_oBodyFontLow))
                            Else
                                oPdfCel = New PdfPCell(New Paragraph(g_oColList(nCol).m_sValue, g_oBodyFont))
                            End If
                            If g_oColList(nCol).m_nColJust = ColJust.Left Then
                                oPdfCel.HorizontalAlignment = Element.ALIGN_LEFT
                            ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                                oPdfCel.HorizontalAlignment = Element.ALIGN_RIGHT
                            Else
                                oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                            End If
                            oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                            oPdfCel.PaddingBottom = g_nBodyPad

                            oTable.AddCell(oPdfCel)
                        Next
                    End If

                    oTime = oTime.AddMinutes(nTimeInterval)
                    UpdateReportProgress(nReportStatusID, dtFrom, dtTo, oTime)
                End While

                g_oDoc.Add(oTable)

                PrintEndOfReport(dtFrom, dtTo)
                g_oDoc.Close()
                GenerateTrendReport = True
                UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
            End Using


        Catch ex As Exception
            UpdateExceptionInDatabase(nReportStatusID, ex.Message)
        Finally

        End Try
        UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
    End Function

    Private Function GetColInstanceValues(ByRef oTime As Date) As Boolean
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        GetColInstanceValues = False

        Dim sTimeField As String
        sTimeField = g_oColList(0).m_sColumnNameinTable
        sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE " + sTimeField + " = ?"

        Using oConnection As New OdbcConnection(g_sEMSDbConString)
            Dim cmd As New OdbcCommand(sQuery, oConnection)
            oConnection.Open()
            cmd.Parameters.Add(GetTimeODBCParam("@0", oTime))

            Try

                Dim fTemp As Single

                oReader = cmd.ExecuteReader()
                If oReader.Read() Then
                    GetColInstanceValues = True
                    For nCol = 0 To g_oColList.Count - 1

                        g_oColList(nCol).m_sValue = ""
                        g_oColList(nCol).m_bError = False


                        If g_oColList(nCol).m_nColType = ColType.DateTime Then
                            g_oColList(nCol).m_sValue = oTime.ToString(g_oColList(nCol).m_sColFormat)
                        ElseIf g_oColList(nCol).m_nColType = ColType.Other Then
                            g_oColList(nCol).m_sValue = oReader(g_oColList(nCol).m_sColumnNameinTable)
                        ElseIf g_oColList(nCol).m_nColType = ColType.Enumtype Then
                            Try
                                Dim nValue As Integer
                                nValue = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                g_oColList(nCol).m_sValue = GetEnumStringFromValue(g_oColList(nCol).m_nEnumID, nValue)
                            Catch ex As Exception
                                g_oColList(nCol).m_sValue = g_sErrorText
                                g_oColList(nCol).m_bError = True
                            End Try
                        Else
                            fTemp = oReader(g_oColList(nCol).m_sColumnNameinTable)
                            g_oColList(nCol).m_sValue = fTemp.ToString(g_oColList(nCol).m_sColFormat)

                            If g_oColList(nCol).m_bLowCheck And g_oColList(nCol).m_fLow <> 0 Then
                                If fTemp <= g_oColList(nCol).m_fLow Then
                                    g_oColList(nCol).m_bError = True
                                End If
                            ElseIf g_oColList(nCol).m_bHighCheck And g_oColList(nCol).m_fHigh <> 0 Then
                                If fTemp >= g_oColList(nCol).m_fHigh Then
                                    g_oColList(nCol).m_bError = True
                                End If
                            End If
                        End If
                    Next
                Else
                    For nCol = 0 To g_oColList.Count - 1
                        g_oColList(nCol).m_sValue = ""
                        g_oColList(nCol).m_bError = True
                        If g_oColList(nCol).m_nColType = ColType.DateTime Then
                            g_oColList(nCol).m_sValue = oTime.ToString(g_oColList(nCol).m_sColFormat)
                        Else
                            g_oColList(nCol).m_sValue = g_sErrorText
                        End If
                    Next
                End If
                oReader.Close()
            Catch ex As Exception

            End Try
            oConnection.Close()
        End Using

    End Function

    Private Function GetColAverageMinMaxValues(ByRef oTime As Date, ByRef nTimeIntervalMin As Integer) As Boolean
        GetColAverageMinMaxValues = False
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim oToTime As Date
        Dim nRecords As Integer = 0


        Try

            oToTime = oTime.AddMinutes(nTimeIntervalMin)
            oToTime = oToTime.AddSeconds(-2)

            Dim sTimeField As String
            sTimeField = g_oColList(0).m_sColumnNameinTable

            For nCol = 0 To g_oColList.Count - 1
                g_oColList(nCol).m_bError = False
                g_oColList(nCol).m_fValue = 0
                g_oColList(nCol).m_fMax = -10000
                g_oColList(nCol).m_fMin = 10000
            Next


            sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE " + sTimeField + " >= ? AND " + sTimeField + " < ?"
            Using oConnection As New OdbcConnection(g_sEMSDbConString)
                Dim cmd As New OdbcCommand(sQuery, oConnection)
                oConnection.Open()
                cmd.Parameters.Add(GetTimeODBCParam("@0", oTime))
                cmd.Parameters.Add(GetTimeODBCParam("@1", oToTime))

                oReader = cmd.ExecuteReader()
                While oReader.Read()
                    GetColAverageMinMaxValues = True
                    For nCol = 0 To g_oColList.Count - 1

                        If g_oColList(nCol).m_nColType = ColType.Temperature Or g_oColList(nCol).m_nColType = ColType.Humidity Or g_oColList(nCol).m_nColType = ColType.DP Then
                            Dim fTemp = oReader(g_oColList(nCol).m_sColumnNameinTable)
                            If fTemp < g_oColList(nCol).m_fMin Then
                                g_oColList(nCol).m_fMin = fTemp
                            End If
                            If fTemp > g_oColList(nCol).m_fMax Then
                                g_oColList(nCol).m_fMax = fTemp
                            End If
                            g_oColList(nCol).m_fValue = g_oColList(nCol).m_fValue + fTemp
                        ElseIf g_oColList(nCol).m_nColType = ColType.Enumtype Then
                            Try
                                Dim nValue As Integer
                                nValue = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                g_oColList(nCol).m_sValue = GetEnumStringFromValue(g_oColList(nCol).m_nEnumID, nValue)
                            Catch ex As Exception
                                g_oColList(nCol).m_sValue = g_sErrorText
                                g_oColList(nCol).m_bError = True
                            End Try
                        ElseIf g_oColList(nCol).m_nColType = ColType.DateTime And nRecords = 0 Then
                            g_oColList(nCol).m_sValue = oTime.ToString(g_oColList(nCol).m_sColFormat)
                        ElseIf nRecords = 0 Then
                            g_oColList(nCol).m_sValue = oReader(g_oColList(nCol).m_sColumnNameinTable)
                        End If
                    Next
                    nRecords = nRecords + 1
                End While
                oReader.Close()
                oConnection.Close()
                If nRecords = 0 Then
                    For nCol = 0 To g_oColList.Count - 1
                        If g_oColList(nCol).m_nColType <> ColType.DateTime Then
                            g_oColList(nCol).m_fValue = 0
                            g_oColList(nCol).m_bError = True
                            g_oColList(nCol).m_sValue = g_sErrorText
                        Else
                            g_oColList(nCol).m_sValue = oTime.ToString(g_oColList(nCol).m_sColFormat)
                        End If

                    Next
                Else
                    For nCol = 0 To g_oColList.Count - 1
                        If g_oColList(nCol).m_nColType = ColType.Temperature Or g_oColList(nCol).m_nColType = ColType.Humidity Or g_oColList(nCol).m_nColType = ColType.DP Then
                            g_oColList(nCol).m_fValue = g_oColList(nCol).m_fValue / nRecords
                            If g_oColList(nCol).m_bLowCheck And g_oColList(nCol).m_fValue <= g_oColList(nCol).m_fLow Then
                                g_oColList(nCol).m_bError = True
                            ElseIf g_oColList(nCol).m_bHighCheck And g_oColList(nCol).m_fValue >= g_oColList(nCol).m_fHigh Then
                                g_oColList(nCol).m_bError = True
                            End If
                            If g_nDataAgg = DataAgg.AverageMinMax Then
                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_fMin.ToString(g_oColList(nCol).m_sColFormat)
                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + g_oColList(nCol).m_fValue.ToString(g_oColList(nCol).m_sColFormat)
                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + g_oColList(nCol).m_fMax.ToString(g_oColList(nCol).m_sColFormat)
                            ElseIf g_nDataAgg = DataAgg.AverageMin Then
                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_fMin.ToString(g_oColList(nCol).m_sColFormat)
                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + g_oColList(nCol).m_fValue.ToString(g_oColList(nCol).m_sColFormat)

                            ElseIf g_nDataAgg = DataAgg.AverageMax Then

                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_fValue.ToString(g_oColList(nCol).m_sColFormat)
                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + g_oColList(nCol).m_fMax.ToString(g_oColList(nCol).m_sColFormat)
                            Else
                                g_oColList(nCol).m_sValue = g_oColList(nCol).m_fValue.ToString(g_oColList(nCol).m_sColFormat)
                            End If

                        End If
                    Next
                End If

            End Using

        Catch ex As Exception

        End Try



    End Function

    Public Function GenerateEventReport(ByRef nReportStatusID As Long, ByVal dtFrom As Date, ByVal dtTo As Date, ByRef sOutFileName As String) As Boolean
        GenerateEventReport = False

        Dim oReader As OdbcDataReader
        Dim sQuery As String
        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0



        Try

            Using FS As New FileStream(sOutFileName, FileMode.Create, FileAccess.Write, FileShare.None)

                g_oDoc = New Document(PageSize.A4)
                If g_bLandScape Then
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                Else
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4)
                End If


                'Using g_oDoc
                ''//Bind our PDF object to the physical file using a PdfWriter
                Dim Writer As PdfWriter = PdfWriter.GetInstance(g_oDoc, FS)
                ''//Open our document for writing

                Dim oPageEvent As New IEntryExitReportEvents
                SetPageEventParameters(oPageEvent)
                Writer.PageEvent = oPageEvent

                CalcualteTopBottomBodyMargins(nTopMargin, nBottomMargin)
                g_oDoc.SetMargins(0.0F, 0, nTopMargin, nBottomMargin)
                g_oDoc.Open()

                Dim oTable = New PdfPTable(g_oColList.Count)

                oTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
                'If g_bLandScape Then
                '    oTable.WidthPercentage = 85.7
                'Else
                '    oTable.WidthPercentage = 79.9
                'End If
                oTable.WidthPercentage = g_fSideFactor

                oTable.HorizontalAlignment = Element.ALIGN_CENTER
                Dim nCol As Integer
                Dim sColWidths(g_oColList.Count - 1) As Single
                For nCol = 0 To g_oColList.Count - 1
                    sColWidths(nCol) = g_oColList(nCol).m_sColWidth
                Next
                oTable.SetWidths(sColWidths)


                Dim sTimeField As String
                sTimeField = g_oColList(0).m_sColumnNameinTable

                sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE " + sTimeField + " >= ? AND " + sTimeField + " <= ? ORDER BY " + sTimeField + ""

                Using oConnection As New OdbcConnection(g_sEMSDbConString)
                    Dim cmd As New OdbcCommand(sQuery, oConnection)
                    oConnection.Open()
                    cmd.Parameters.Add(GetTimeODBCParam("@0", dtFrom))
                    cmd.Parameters.Add(GetTimeODBCParam("@1", dtTo))
                    Try

                        Dim fTemp As Single
                        Dim sValue As String
                        Dim bLow As Boolean
                        Dim bHigh As Boolean
                        Dim oDate As DateTime

                        oReader = cmd.ExecuteReader()
                        While oReader.Read()

                            For nCol = 0 To g_oColList.Count - 1
                                sValue = ""
                                bLow = False
                                bHigh = False
                                If g_oColList(nCol).m_nColType = ColType.DateTime Then
                                    oDate = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                    sValue = oDate.ToString(g_oColList(nCol).m_sColFormat)
                                ElseIf g_oColList(nCol).m_nColType = ColType.Other Then
                                    sValue = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                Else
                                    fTemp = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                    sValue = fTemp.ToString(g_oColList(nCol).m_sColFormat)

                                    If g_oColList(nCol).m_bLowCheck And g_oColList(nCol).m_fLow <> 0 Then
                                        If fTemp <= g_oColList(nCol).m_fLow Then
                                            bLow = True
                                        End If
                                    ElseIf g_oColList(nCol).m_bHighCheck And g_oColList(nCol).m_fHigh <> 0 Then
                                        If fTemp >= g_oColList(nCol).m_fHigh Then
                                            bHigh = True
                                        End If
                                    End If
                                End If

                                Dim oPdfCel As PdfPCell
                                If bLow Then
                                    oPdfCel = New PdfPCell(New Paragraph(sValue, g_oBodyFontLow))
                                ElseIf bHigh Then
                                    oPdfCel = New PdfPCell(New Paragraph(sValue, g_oBodyFontHigh))
                                Else
                                    oPdfCel = New PdfPCell(New Paragraph(sValue, g_oBodyFont))
                                End If
                                If g_oColList(nCol).m_nColJust = ColJust.Left Then
                                    oPdfCel.HorizontalAlignment = Element.ALIGN_LEFT
                                ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                                    oPdfCel.HorizontalAlignment = Element.ALIGN_RIGHT
                                Else
                                    oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                                End If

                                oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                                oPdfCel.PaddingBottom = g_nBodyPad
                                oTable.AddCell(oPdfCel)
                            Next
                            UpdateReportProgress(nReportStatusID, dtFrom, dtTo, oDate)
                        End While
                        oReader.Close()
                    Catch ex As Exception

                    End Try
                    oConnection.Close()
                End Using
                g_oDoc.Add(oTable)
                PrintEndOfReport(dtFrom, dtTo)
                g_oDoc.Close()
                UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
            End Using
            '    End Using
            'End Using
            GenerateEventReport = True
        Catch ex As Exception
            UpdateExceptionInDatabase(nReportStatusID, ex.Message)
        Finally

        End Try
        UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)

    End Function


    Public Function GenerateAlarmReport(ByRef nReportStatusID As Long, ByVal dtFrom As Date, ByVal dtTo As Date, ByRef sOutFileName As String) As Boolean

        GenerateAlarmReport = False

        Dim sAlmGrpColName As String = ""
        If GetPlantConfigParamValue("AlarmGroupColName", sAlmGrpColName) = False Then
            sOutFileName = "AlarmGroupColName Field Not Defined in the TBL_ReportAppConfig Table"
            Exit Function
        End If

        Dim oReader As OdbcDataReader
        Dim sQuery As String
        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0

        Try

            Using FS As New FileStream(sOutFileName, FileMode.Create, FileAccess.Write, FileShare.None)

                g_oDoc = New Document(PageSize.A4)
                If g_bLandScape Then
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                Else
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4)
                End If


                ' Using g_oDoc
                ''//Bind our PDF object to the physical file using a PdfWriter
                Dim Writer As PdfWriter = PdfWriter.GetInstance(g_oDoc, FS)
                ''//Open our document for writing
                Dim oPageEvent As New IEntryExitReportEvents
                SetPageEventParameters(oPageEvent)
                Writer.PageEvent = oPageEvent


                CalcualteTopBottomBodyMargins(nTopMargin, nBottomMargin)
                g_oDoc.SetMargins(0.0F, 0, nTopMargin, nBottomMargin)
                g_oDoc.Open()

                Dim oTable = New PdfPTable(g_oColList.Count)

                oTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
                oTable.WidthPercentage = g_fSideFactor

                oTable.HorizontalAlignment = Element.ALIGN_CENTER
                Dim nCol As Integer
                Dim sColWidths(g_oColList.Count - 1) As Single
                For nCol = 0 To g_oColList.Count - 1
                    sColWidths(nCol) = g_oColList(nCol).m_sColWidth
                Next
                oTable.SetWidths(sColWidths)


                Dim sTimeField As String
                sTimeField = g_oColList(0).m_sColumnNameinTable

                sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE " + sTimeField + " >= ? AND " + sTimeField + " <= ? AND " + sAlmGrpColName + " =? ORDER BY " + sTimeField + ""

                Using oConnection As New OdbcConnection(g_sEMSDbConString)
                    Dim cmd As New OdbcCommand(sQuery, oConnection)
                    oConnection.Open()
                    cmd.Parameters.Add(GetTimeODBCParam("@0", dtFrom))
                    cmd.Parameters.Add(GetTimeODBCParam("@1", dtTo))
                    cmd.Parameters.Add("@2", OdbcType.Int).Value = g_nAlmGroupID
                    Try

                        Dim fTemp As Single
                        Dim sValue As String
                        Dim bLow As Boolean
                        Dim bHigh As Boolean
                        Dim oDate As DateTime

                        oReader = cmd.ExecuteReader()
                        While oReader.Read()

                            For nCol = 0 To g_oColList.Count - 1
                                sValue = ""
                                bLow = False
                                bHigh = False
                                If g_oColList(nCol).m_nColType = ColType.DateTime Then
                                    Try
                                        oDate = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                        sValue = oDate.ToString(g_oColList(nCol).m_sColFormat)
                                    Catch ex As Exception
                                        sValue = ""
                                    End Try

                                ElseIf g_oColList(nCol).m_nColType = ColType.Other Then
                                    Try
                                        sValue = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                    Catch ex As Exception
                                        sValue = ""
                                    End Try

                                Else
                                    Try
                                        fTemp = oReader(g_oColList(nCol).m_sColumnNameinTable)
                                        sValue = fTemp.ToString(g_oColList(nCol).m_sColFormat)
                                    Catch ex As Exception
                                        sValue = ""
                                    End Try


                                    If g_oColList(nCol).m_bLowCheck And g_oColList(nCol).m_fLow <> 0 Then
                                        If fTemp <= g_oColList(nCol).m_fLow Then
                                            bLow = True
                                        End If
                                    ElseIf g_oColList(nCol).m_bHighCheck And g_oColList(nCol).m_fHigh <> 0 Then
                                        If fTemp >= g_oColList(nCol).m_fHigh Then
                                            bHigh = True
                                        End If
                                    End If
                                End If

                                Dim oPdfCel As PdfPCell
                                If bLow Then
                                    oPdfCel = New PdfPCell(New Paragraph(sValue, g_oBodyFontLow))
                                ElseIf bHigh Then
                                    oPdfCel = New PdfPCell(New Paragraph(sValue, g_oBodyFontHigh))
                                Else
                                    oPdfCel = New PdfPCell(New Paragraph(sValue, g_oBodyFont))
                                End If
                                If g_oColList(nCol).m_nColJust = ColJust.Left Then
                                    oPdfCel.HorizontalAlignment = Element.ALIGN_LEFT
                                ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                                    oPdfCel.HorizontalAlignment = Element.ALIGN_RIGHT
                                Else
                                    oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                                End If

                                oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                                oPdfCel.PaddingBottom = g_nBodyPad
                                oTable.AddCell(oPdfCel)
                            Next
                            UpdateReportProgress(nReportStatusID, dtFrom, dtTo, oDate)
                        End While
                        oReader.Close()
                    Catch ex As Exception
                        Dim c1 As New Chunk(ex.Message)
                        g_oDoc.Add(c1)
                    End Try
                    oConnection.Close()

                End Using


                g_oDoc.Add(oTable)

                PrintEndOfReport(dtFrom, dtTo)
                g_oDoc.Close()
                UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
            End Using

            GenerateAlarmReport = True
        Catch ex As Exception
            UpdateExceptionInDatabase(nReportStatusID, ex.Message)
        Finally

        End Try
        UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)

    End Function

    Private Sub SetPageEventParameters(ByRef oPageEvent As IEntryExitReportEvents)
        oPageEvent.g_oFooterFont = g_oFooterFont

        oPageEvent.g_oH1Font = g_oH1Font
        oPageEvent.g_oH2Font = g_oH2Font
        oPageEvent.g_oHFont = g_oHFont
        oPageEvent.g_bIconNeeded = g_bIconNeeded
        oPageEvent.g_bGeneratedTime = g_bGeneratedTime
        oPageEvent.g_bGeneratedBy = g_bGeneratedBy
        oPageEvent.g_fSideMargin = g_fSideMargin
        oPageEvent.g_fTopBottomMargin = g_fTopBottomMargin
        oPageEvent.g_fSideFactor = g_fSideFactor
        oPageEvent.g_nHeaderPad = g_nHeaderPad
        oPageEvent.g_nFooterPad = g_nFooterPad
        oPageEvent.g_nBodyPad = g_nBodyPad
        oPageEvent.g_nBodyHeaderPad = g_nBodyHeaderPad
        oPageEvent.g_sGeneratedUserName = g_sGeneratedUserName
        oPageEvent.g_bLandScape = g_bLandScape
        oPageEvent.g_oBodyHeaderFont = g_oBodyHeaderFont
        oPageEvent.g_oFooterRowList = g_oFooterRowList
        oPageEvent.g_sReportFontName = g_sReportFontName
        oPageEvent.g_nReportType = g_nReportType
    End Sub

    Private Sub PrintEndOfReport(ByRef oStartTime As Date, ByRef oEndTime As Date)

        If g_bFRomToDatesPrinted Then

            Dim oTable As New PdfPTable(1)
            oTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin


            Dim oPdfCel As PdfPCell = New PdfPCell(New Paragraph("           ", g_oHFont))
            oPdfCel.Border = 0
            oTable.AddCell(oPdfCel)

            Dim sTemp As String
            sTemp = "End Of Report :  From " + oStartTime.ToString(g_sTimeFormatIndian, CultureInfo.InvariantCulture) + "  To " + oEndTime.ToString(g_sTimeFormatIndian, CultureInfo.InvariantCulture)

            oPdfCel = New PdfPCell(New Paragraph(sTemp, g_oFooterFont))
            oPdfCel.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY
            oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
            oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
            oPdfCel.PaddingBottom = g_nBodyPad
            oPdfCel.ExtraParagraphSpace = 5
            oTable.AddCell(oPdfCel)
            g_oDoc.Add(oTable)
        End If

    End Sub

    Private Sub CalcualteTopBottomBodyMargins(ByRef nTopMargin As Integer, ByRef nBottomMargin As Integer)
        Dim oHeaderTable As PdfPTable
        If g_bIconNeeded Then
            Try
                oHeaderTable = New PdfPTable(2)
                oHeaderTable.TotalWidth = g_oDoc.PageSize.Width - 2 * g_fSideMargin
                Dim widths2 = {0.25F, 0.75F}
                oHeaderTable.SetWidths(widths2)
                Dim oImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(g_sInFileDir + "\\Images\\ReportLogo.png")
                Dim oImageCell As PdfPCell = New PdfPCell(oImage)
                oImageCell.Rowspan = g_nHeaderCount
                oImageCell.HorizontalAlignment = Element.ALIGN_CENTER
                oImageCell.VerticalAlignment = Element.ALIGN_MIDDLE
                oHeaderTable.AddCell(oImageCell)
            Catch ex As Exception
                oHeaderTable = New PdfPTable(1)
                oHeaderTable.TotalWidth = g_oDoc.PageSize.Width - 2 * g_fSideMargin
            End Try

        Else
            oHeaderTable = New PdfPTable(1)
            oHeaderTable.TotalWidth = g_oDoc.PageSize.Width - 2 * g_fSideMargin
        End If

        If g_bHeader1 Then
            Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader1, g_oH1Font))
            oHeaderCell.PaddingTop = g_nHeaderPad
            oHeaderCell.PaddingBottom = g_nHeaderPad
            oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
            oHeaderCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oHeaderTable.AddCell(oHeaderCell)
        End If
        If g_bHeaderAddress Then
            Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeaderAddress, g_oBodyHeaderFont))
            oHeaderCell.PaddingTop = g_nBodyPad
            oHeaderCell.PaddingBottom = g_nBodyPad
            oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
            oHeaderCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oHeaderTable.AddCell(oHeaderCell)
        End If

        If g_bHeader2 Then
            Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader2, g_oH2Font))
            oHeaderCell.PaddingTop = g_nHeaderPad
            oHeaderCell.PaddingBottom = g_nHeaderPad
            oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
            oHeaderCell.VerticalAlignment = Element.ALIGN_CENTER
            oHeaderTable.AddCell(oHeaderCell)
        End If
        If g_bHeader3 Then
            Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader3, g_oHFont))
            oHeaderCell.PaddingTop = g_nHeaderPad
            oHeaderCell.PaddingBottom = g_nHeaderPad
            oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
            oHeaderCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oHeaderTable.AddCell(oHeaderCell)
        End If

        nTopMargin = oHeaderTable.TotalHeight




        Dim oBodyHeaderTable As PdfPTable = New PdfPTable(g_oColList.Count)
        oBodyHeaderTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
        oBodyHeaderTable.WidthPercentage = 90
        oBodyHeaderTable.HorizontalAlignment = Element.ALIGN_CENTER

        Dim nCol As Integer
        Dim sColWidths(g_oColList.Count - 1) As Single
        For nCol = 0 To g_oColList.Count - 1
            sColWidths(nCol) = g_oColList(nCol).m_sColWidth
        Next
        oBodyHeaderTable.SetWidths(sColWidths)

        Dim nH1Cols As Integer = g_oColList.Count
        For nCol = 0 To g_oColList.Count - 1
            nH1Cols = nH1Cols - g_oColList(nCol).m_nColMerge
        Next
        Dim oBodyHeaderTable2 As PdfPTable = New PdfPTable(nH1Cols)
        oBodyHeaderTable2.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
        oBodyHeaderTable2.WidthPercentage = 90
        oBodyHeaderTable2.HorizontalAlignment = Element.ALIGN_CENTER

        ' LogError(nH1Cols.ToString())
        Dim sColWidths2(nH1Cols - 1) As Single
        nH1Cols = 0
        For nCol = 0 To g_oColList.Count - 1
            Dim sTemp1 As Single = 0
            For nMerge = 0 To g_oColList(nCol).m_nColMerge
                sTemp1 += g_oColList(nCol + nMerge).m_sColWidth
            Next
            sColWidths2(nH1Cols) = sTemp1
            nCol += g_oColList(nCol).m_nColMerge
            nH1Cols += 1
        Next
        oBodyHeaderTable2.SetWidths(sColWidths2)



        If g_nReportType = ReportType.DataReport Then
            For nCol = 0 To g_oColList.Count - 1


                Dim oColHeader As PdfPCell = New PdfPCell(New Phrase(g_oColList(nCol).m_sColType, g_oBodyHeaderFont))
                oColHeader.PaddingBottom = g_nBodyPad
                oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                If g_oColList(nCol).m_nColJust = ColJust.Left Then
                    oColHeader.HorizontalAlignment = Element.ALIGN_LEFT
                ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                    oColHeader.HorizontalAlignment = Element.ALIGN_RIGHT
                Else
                    oColHeader.HorizontalAlignment = Element.ALIGN_CENTER
                End If

                oColHeader.VerticalAlignment = Element.ALIGN_MIDDLE

                oBodyHeaderTable2.AddCell(oColHeader)
                nCol += g_oColList(nCol).m_nColMerge

            Next
        End If


        For nCol = 0 To g_oColList.Count - 1
            Dim oColHeader As PdfPCell
            oColHeader = New PdfPCell(New Paragraph(g_oColList(nCol).m_sColTitle, g_oBodyHeaderFont))

            oColHeader.PaddingBottom = g_nBodyPad
            oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
            oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
            If g_oColList(nCol).m_nColJust = ColJust.Left Then
                oColHeader.HorizontalAlignment = Element.ALIGN_LEFT
            ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                oColHeader.HorizontalAlignment = Element.ALIGN_RIGHT
            Else
                oColHeader.HorizontalAlignment = Element.ALIGN_CENTER
            End If

            oColHeader.VerticalAlignment = Element.ALIGN_MIDDLE
            oBodyHeaderTable.AddCell(oColHeader)
        Next




        nTopMargin = nTopMargin + oBodyHeaderTable.TotalHeight + oBodyHeaderTable2.TotalHeight + 3 + g_fTopBottomMargin

        'Write Footer Table
        Dim oFooterTable As PdfPTable = New PdfPTable(3)
        oFooterTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
        oFooterTable.HorizontalAlignment = Element.ALIGN_CENTER

        Dim oFooterCell As PdfPCell
        For nCol = 0 To g_oFooterRowList.Count - 1
            oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol1, g_oFooterFont))
            oFooterCell.PaddingTop = g_nFooterPad
            oFooterCell.PaddingBottom = g_nFooterPad
            If g_oFooterRowList(nCol).m_bHeader Then
                oFooterCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY
            End If
            oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
            oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oFooterTable.AddCell(oFooterCell)

            oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol2, g_oFooterFont))
            oFooterCell.PaddingTop = g_nFooterPad
            oFooterCell.PaddingBottom = g_nFooterPad
            If g_oFooterRowList(nCol).m_bHeader Then
                oFooterCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY
            End If
            oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
            oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oFooterTable.AddCell(oFooterCell)

            oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol3, g_oFooterFont))
            oFooterCell.PaddingTop = g_nFooterPad
            oFooterCell.PaddingBottom = g_nFooterPad
            If g_oFooterRowList(nCol).m_bHeader Then
                oFooterCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY
            End If
            oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
            oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oFooterTable.AddCell(oFooterCell)
        Next


        nBottomMargin = oFooterTable.TotalHeight + g_fTopBottomMargin + 20

    End Sub


End Class
