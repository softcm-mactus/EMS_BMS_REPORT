Imports System.Data.Odbc
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class NewInduSoftReport
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
    Private g_nbodyheadermargin = 0

    Private g_nTimeIntervalMin As Integer
    Private g_nDataAgg As DataAgg
    Private g_bLandScape As Boolean
    Private g_bPrintAlarmSpRows As Boolean
    Private g_bPrintMinMaxRows As Boolean

    Private g_bFRomToDatesPrinted As Boolean
    Private g_sDataTableName As String
    Private g_sGeneratedUserName As String
    Private g_oFooterRowList As New List(Of FooterRow)


    'Body Font
    Private g_oBodyFont As iTextSharp.text.Font
    Private g_oBodyFontLow As iTextSharp.text.Font
    Private g_oBodyFontHigh As iTextSharp.text.Font
    Private g_oBodyHeaderFont As iTextSharp.text.Font
    Private g_oBodyHeaderFont2 As iTextSharp.text.Font
    Private g_oNoAlarmBoxFont As iTextSharp.text.Font
    Private g_oNextPageFont As iTextSharp.text.Font

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
        Public g_oBodyHeaderFont2 As iTextSharp.text.Font
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
                If g_bHeader3 Then
                    Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader3, g_oHFont))
                    oHeaderCell.PaddingTop = g_nHeaderPad
                    oHeaderCell.PaddingBottom = g_nHeaderPad
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

                oHeaderTable.WriteSelectedRows(0, -1, g_fSideMargin + fTemp, document.PageSize.Height - g_fTopBottomMargin, writer.DirectContent)

                Dim xtemp, ytemp As Single
                If g_bIconNeeded Then
                    Dim oImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(g_sInFileDir + "\\Images\\ReportLogo.PNG")

                    xtemp = g_fSideMargin + ((fTemp - oImage.Width) * 0.5)
                    ytemp = document.PageSize.Height - g_fTopBottomMargin - oImage.Height - (oHeaderTable.TotalHeight - oImage.Height) * 0.5
                    oImage.SetAbsolutePosition(xtemp, ytemp)
                    document.Add(oImage)

                    ytemp = document.PageSize.Height - g_fTopBottomMargin - oHeaderTable.TotalHeight
                    cb.SetLineWidth(0.5)
                    cb.MoveTo(g_fSideMargin, ytemp)
                    cb.LineTo(g_fSideMargin + fTemp, ytemp)
                    cb.Stroke()

                End If

                Dim nBodyDeaderYPos As Integer
                nBodyDeaderYPos = document.PageSize.Height - g_fTopBottomMargin - oHeaderTable.TotalHeight '-3

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
                        sTemp = sTemp + g_sLSpace + g_sLSpace + g_sGeneratedTime + Now.ToString(g_sTimeFormatIndian)
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

                Dim oBodyHeaderTable As PdfPTable
                Dim oBodyHeaderTable2 As PdfPTable

                If g_nReportType <> ReportType.DataChartReport Then

                    If g_nReportType = ReportType.AlarmReport Or g_nReportType = ReportType.EventReport Then
                        Dim nAlarmColCount As Integer = 0

                        For nCol = 0 To g_oColList.Count - 1
                            If g_oColList(nCol).m_bshowAlarmCol Then
                                nAlarmColCount = nAlarmColCount + 1
                            End If
                        Next

                        oBodyHeaderTable = New PdfPTable(nAlarmColCount)
                        oBodyHeaderTable.TotalWidth = document.PageSize.Width - 3 * g_fSideMargin
                        oBodyHeaderTable.WidthPercentage = 90
                        oBodyHeaderTable.HorizontalAlignment = Element.ALIGN_CENTER


                        Dim sColWidths(nAlarmColCount - 1) As Single
                        nAlarmColCount = 0

                        For nCol = 0 To g_oColList.Count - 1
                            If g_oColList(nCol).m_bshowAlarmCol Then
                                sColWidths(nAlarmColCount) = g_oColList(nCol).m_sColWidth
                                nAlarmColCount = nAlarmColCount + 1
                            End If
                        Next
                        oBodyHeaderTable.SetWidths(sColWidths)

                        For nCol = 0 To g_oColList.Count - 1
                            If g_oColList(nCol).m_bshowAlarmCol Then

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
                            End If
                        Next
                        oBodyHeaderTable.WriteSelectedRows(0, -1, g_fSideMargin * 1.5, nBodyDeaderYPos, writer.DirectContent)
                        'ElseIf g_nReportType = ReportType.DataTrendAlarmReport Then
                        '    Dim nAlarmColCount As Integer = 6



                        '    oBodyHeaderTable = New PdfPTable(nAlarmColCount)
                        '    oBodyHeaderTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
                        '    oBodyHeaderTable.WidthPercentage = 90
                        '    oBodyHeaderTable.HorizontalAlignment = Element.ALIGN_CENTER


                        '    Dim sColWidths(nAlarmColCount - 1) As Single
                        '    nAlarmColCount = 0

                        '    For nCol = 0 To g_oColList.Count - 1
                        '        If g_oColList(nCol).m_bshowAlarmCol Then
                        '            sColWidths(nAlarmColCount) = g_oColList(nCol).m_sColWidth
                        '            nAlarmColCount = nAlarmColCount + 1
                        '        End If
                        '    Next
                        '    oBodyHeaderTable.SetWidths(sColWidths)
                        '    Dim sColumName As String() = {"Date Time", "Alarm Message", "Alarm Normalized time", "Acknowledge Data Time", "User ID", "User Comments"}
                        '    For nCol = 0 To 6 - 1

                        '        Dim oColHeader As PdfPCell
                        '        oColHeader = New PdfPCell(New Paragraph(sColumName(nCol).ToString, g_oBodyHeaderFont))

                        '        oColHeader.PaddingBottom = g_nBodyPad
                        '        oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                        '        oColHeader.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                        '        'If g_oColList(nCol).m_nColJust = ColJust.Left Then
                        '        '    oColHeader.HorizontalAlignment = Element.ALIGN_LEFT
                        '        'ElseIf g_oColList(nCol).m_nColJust = ColJust.Right Then
                        '        '    oColHeader.HorizontalAlignment = Element.ALIGN_RIGHT
                        '        'Else
                        '        '    oColHeader.HorizontalAlignment = Element.ALIGN_CENTER
                        '        'End If

                        '        oColHeader.VerticalAlignment = Element.ALIGN_MIDDLE
                        '        oBodyHeaderTable.AddCell(oColHeader)

                        '    Next
                        '    oBodyHeaderTable.WriteSelectedRows(0, -1, g_fSideMargin * 1.5, nBodyDeaderYPos, writer.DirectContent)

                    Else

                        oBodyHeaderTable = New PdfPTable(g_oColList.Count)
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
                        oBodyHeaderTable2 = New PdfPTable(nH1Cols)
                        oBodyHeaderTable2.TotalWidth = document.PageSize.Width - 3 * g_fSideMargin
                        oBodyHeaderTable2.WidthPercentage = 90
                        oBodyHeaderTable2.HorizontalAlignment = Element.ALIGN_CENTER

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


                    End If
                End If

                If g_bPrintReviewTableEveryPage = True Then

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
                End If

            Catch ex As Exception
                MsgBox("OnEndPage" + ex.Message)
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
                    If g_nReportType = ReportType.DataReport Then
                        g_nDataAgg = oReader("DataAggregationType")
                    Else
                        g_nDataAgg = DataAgg.Instance
                    End If
                Catch ex As Exception
                    g_nDataAgg = DataAgg.Instance
                End Try

                Try
                    g_bPrintAlarmSpRows = oReader("PrintAlarmSpRows")
                Catch ex As Exception
                    g_bPrintAlarmSpRows = False
                End Try

                Try
                    g_bPrintMinMaxRows = oReader("PrintMinMaxRows")
                Catch ex As Exception
                    g_bPrintMinMaxRows = False
                End Try
            End If

            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            UpdateExceptionInDatabase(nReportID, ex.Message)
            LogError("NewIndusoftReport.vb", "ReadReportConfiguration()", ex.Message)
            Exit Sub
        End Try

        ReadReportTemplateConfiguration(nTemplateID)

        ReadReportColumnConfiguration(nReportID)
        Try
            g_oH1Font = New iTextSharp.text.Font(g_oReportFontName, g_fH1FontSize, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)
            g_oH2Font = New iTextSharp.text.Font(g_oReportFontName, g_fH2FontSize, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)
            g_oHFont = New iTextSharp.text.Font(g_oReportFontName, g_fHFontSize, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)

            'Body Font
            g_oBodyFont = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)
            g_oBodyFontLow = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.RED)
            g_oBodyFontHigh = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.RED)
            g_oBodyHeaderFont = New iTextSharp.text.Font(g_oReportFontName, g_fBodyFontSize, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)
            g_oNoAlarmBoxFont = New iTextSharp.text.Font(g_oReportFontName, 30, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLUE)
            g_oNextPageFont = New iTextSharp.text.Font(g_oReportFontName, 20, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLUE)

            'Footer Font
            g_oFooterFont = New iTextSharp.text.Font(g_oReportFontName, g_fFooterFontSize, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)


        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "ReadReportColumnConfiguration()", ex.Message)
        End Try

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

                Try
                    sTemp = oReader("Footer1")
                Catch ex As Exception
                    sTemp = ""
                End Try
                sTemp = sTemp.Trim()
                If sTemp.Length > 0 Then
                    oFooterRow = New FooterRow(sTemp)
                    g_oFooterRowList.Add(oFooterRow)
                End If

                Try
                    sTemp = oReader("Footer2")
                Catch ex As Exception
                    sTemp = ""
                End Try
                sTemp = sTemp.Trim()
                If sTemp.Length > 0 Then
                    oFooterRow = New FooterRow(sTemp)
                    g_oFooterRowList.Add(oFooterRow)
                End If

                Try
                    sTemp = oReader("Footer3")
                Catch ex As Exception
                    sTemp = ""
                End Try

                sTemp = sTemp.Trim()
                If sTemp.Length > 0 Then
                    oFooterRow = New FooterRow(sTemp)
                    g_oFooterRowList.Add(oFooterRow)
                End If

                Try
                    sTemp = oReader("Footer4")
                Catch ex As Exception
                    sTemp = ""
                End Try

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

                Try
                    g_nbodyheadermargin = oReader("bodyheadermargin")
                Catch ex As Exception
                    g_nbodyheadermargin = 0
                End Try

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

            End If
            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "ReadReportTemplateConfiguration()", ex.Message)

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

                Try
                    oCol.m_nColType = oReader("ColType")
                Catch ex As Exception
                    oCol.m_nColType = ColType.Other
                End Try

                Try
                    oCol.m_sColType = oReader("coltitle")
                Catch ex As Exception
                    oCol.m_sColType = ""
                End Try

                oCol.m_nDataChartSeiries = 0

                If oCol.m_sColType = "" Then
                    If oCol.m_nColType = ColType.DateTime Then
                        oCol.m_sColType = "Date Time"
                    ElseIf oCol.m_nColType = ColType.Temperature Then
                        oCol.m_sColType = "Temperature"
                    ElseIf oCol.m_nColType = ColType.Humidity Then
                        oCol.m_sColType = "RH"
                    ElseIf oCol.m_nColType = ColType.DP Then
                        oCol.m_sColType = "Diffrential Pressure"
                    ElseIf oCol.m_nColType = ColType.Frequency Then
                        oCol.m_sColType = "Frequency"
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
                Catch ex As Exception
                    oCol.m_bLowCheck = False
                End Try
                Try
                    oCol.m_nLowCheckType = oReader("LowCheckType")
                Catch ex As Exception
                    oCol.m_bLowCheck = False
                    oCol.m_nLowCheckType = 0
                End Try

                Try
                    oCol.m_fLow = oReader("LowCheckValue")
                Catch ex As Exception
                    oCol.m_bLowCheck = False
                    oCol.m_fLow = 0
                End Try

                If oCol.m_nLowCheckType = 1 Then
                    oCol.m_sLowCheckPointName = GetPointName(CInt(oCol.m_fLow))
                    If oCol.m_sLowCheckPointName = "" Then
                        oCol.m_nLowCheckType = 0
                    End If
                End If

                Try
                    oCol.m_bHighCheck = oReader("HighCheck")
                Catch ex As Exception
                    oCol.m_bHighCheck = False
                End Try

                Try
                    oCol.m_nHighCheckType = oReader("HighCheckType")
                Catch ex As Exception
                    oCol.m_bHighCheck = False
                    oCol.m_nHighCheckType = 0
                End Try

                Try
                    oCol.m_fHigh = oReader("HighCheckValue")
                Catch ex As Exception
                    oCol.m_fHigh = 0.0
                    oCol.m_bHighCheck = False
                    oCol.m_nHighCheckType = 0
                End Try

                If oCol.m_nHighCheckType = 1 Then
                    oCol.m_sHighCheckPointName = GetPointName(CInt(oCol.m_fHigh))
                    'If oCol.m_sHighCheckPointName IsNot Nothing Then
                    Try
                        If oCol.m_sHighCheckPointName = "" Then
                            oCol.m_nHighCheckType = 0
                        End If
                    Catch ex As Exception
                        oCol.m_nHighCheckType = 0
                    End Try

                    'Else
                    'oCol.m_nHighCheckType = 0
                    'End If
                End If


                Try
                    oCol.m_bSPCheck = oReader("SetPointCheck")
                Catch ex As Exception
                    oCol.m_bSPCheck = False
                End Try

                Try
                    oCol.m_nSPCheckType = oReader("SetPointType")
                Catch ex As Exception
                    oCol.m_bHighCheck = False
                    oCol.m_nSPCheckType = 0
                End Try

                Try
                    oCol.m_fSP = oReader("SetPointValue")
                Catch ex As Exception
                    oCol.m_bSPCheck = False
                    oCol.m_fSP = 0
                End Try

                If oCol.m_nSPCheckType = 1 Then
                    oCol.m_sSPCheckPointName = GetPointName(CInt(oCol.m_fSP))
                    If oCol.m_sHighCheckPointName.Length <= 0 Then
                        oCol.m_bSPCheck = False
                        oCol.m_fSP = 0
                    End If
                End If


                If oCol.m_nColType = ColType.DateTime Or oCol.m_nColType = ColType.Other Then
                    oCol.m_bLowCheck = False
                    oCol.m_bHighCheck = False
                End If

                Try
                    oCol.m_nEnumID = oReader("enumid")
                Catch ex As Exception
                    oCol.m_nEnumID = 0
                End Try


                oCol.m_fReportMax = -9999.0
                oCol.m_fReportMin = 9999.0
                oCol.m_bReportMinAdded = False
                oCol.m_bReportMaxAdded = False
                oCol.m_dKMT = 0.0
                oCol.m_nKMTCount = 0


                If g_nReportType = ReportType.AlarmReport Or g_nReportType = ReportType.EventReport Then
                    If oCol.m_nEnumID = 1 Then
                        oCol.m_bshowAlarmCol = True
                    Else
                        oCol.m_bshowAlarmCol = False
                    End If
                Else
                    oCol.m_bshowAlarmCol = True
                End If
                g_oColList.Add(oCol)

            End While




            oReader.Close()
            oConnection.Close()
        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "ReadReportColumnConfiguration()", ex.Message)
        End Try
    End Sub


    Public Sub FormatCharts(ByRef oTrendChartList As List(Of Charting.Chart), ByRef oFromDate As Date, ByRef oToDate As Date, ByRef sAreaName As String)

        Try

            For nCol = 0 To g_oColList.Count - 1
                Dim oChart As New Charting.Chart

                Dim oTitle As Charting.Title
                oTitle = oChart.Titles.Add(g_oColList(nCol).m_sColType + " : " + g_oColList(nCol).m_sColTitle)
                oTitle.Font = New Drawing.Font(FontFamily.GenericSansSerif, 14)
                oTitle.Alignment = ContentAlignment.TopCenter

                Dim oPoint As Point
                Dim oSize As Size

                oPoint.X = 10
                oPoint.Y = 10
                oChart.Location = oPoint

                oSize.Width = 400 * 1.414
                oSize.Height = 400
                oChart.Size = oSize
                oChart.BackColor = System.Drawing.Color.LightBlue
                oChart.Visible = True

                oChart.BorderlineColor = System.Drawing.Color.Black
                oChart.BorderlineWidth = 2
                oChart.BorderlineDashStyle = Charting.ChartDashStyle.Solid

                Dim oArea As Charting.ChartArea
                Try
                    oArea = oChart.ChartAreas(0)
                Catch ex As Exception
                    oArea = oChart.ChartAreas.Add("Area")
                End Try

                Dim oLegend As New Charting.Legend
                oLegend.Name = "Legend"
                oLegend.Enabled = True
                oLegend.BorderDashStyle = Charting.ChartDashStyle.Solid
                oLegend.BorderWidth = 2
                oLegend.BorderColor = System.Drawing.Color.LightGreen
                oLegend.ForeColor = System.Drawing.Color.Black
                oLegend.Position.Auto = False
                oLegend.Position.X = 60.0
                oLegend.Position.Y = 10.0

                oChart.Legends.Add(oLegend)

                oArea.BorderColor = System.Drawing.Color.Red
                oArea.BorderDashStyle = Charting.ChartDashStyle.Solid
                oArea.BorderWidth = 1
                oArea.BackColor = System.Drawing.Color.White

                oArea.AxisX.LabelStyle.Angle = 90
                oArea.AxisX.LabelStyle.Format = "HH:mm"
                oArea.AxisX.MajorGrid.Enabled = True
                oArea.AxisX.Interval = 2 / 24
                oArea.AxisX.IntervalAutoMode = False
                oArea.AxisX.MinorGrid.Enabled = False
                oArea.AxisX.MinorGrid.LineWidth = 1
                oArea.AxisX.MinorGrid.LineColor = Drawing.Color.LightGray
                oArea.AxisX.LabelStyle.Font = New System.Drawing.Font(FontFamily.GenericSansSerif, 10)

                oArea.AxisY.LabelStyle.Font = New System.Drawing.Font(FontFamily.GenericSansSerif, 10)
                oArea.AxisY.IntervalAutoMode = True
                oArea.AxisY.MajorGrid.Enabled = False
                oArea.AxisY.IsStartedFromZero = False

                sAreaName = oArea.Name


                If g_bIsGMTTime Then
                    oArea.AxisX.Minimum = oFromDate.ToLocalTime.AddMinutes(-60).ToOADate
                    oArea.AxisX.Maximum = oToDate.ToLocalTime.AddMinutes(60).ToOADate
                Else
                    oArea.AxisX.Minimum = oFromDate.AddMinutes(-60).ToOADate
                    oArea.AxisX.Maximum = oToDate.AddMinutes(60).ToOADate
                End If


                Dim oSeries As Charting.Series

                oSeries = oChart.Series.Add("Value")
                oSeries.ChartArea = oArea.Name
                oSeries.ChartType = Charting.SeriesChartType.Line
                oSeries.LegendText = "Value"
                oSeries.IsVisibleInLegend = False
                oSeries.Color = System.Drawing.Color.DarkBlue
                oSeries.BorderDashStyle = Charting.ChartDashStyle.Solid
                oSeries.BorderWidth = 2
                oSeries.XValueType = Charting.ChartValueType.DateTime
                oSeries.Legend = "Legend"
                oSeries.IsVisibleInLegend = True

                Dim oLSeries As Charting.Series

                oLSeries = oChart.Series.Add("High Limit")
                oLSeries.ChartArea = oArea.Name
                oLSeries.ChartType = Charting.SeriesChartType.Line
                oLSeries.LegendText = "Low Limit"
                oLSeries.IsVisibleInLegend = False
                oLSeries.Color = System.Drawing.Color.DarkRed
                oLSeries.BorderDashStyle = Charting.ChartDashStyle.Dash
                oLSeries.BorderWidth = 1
                oLSeries.Legend = "Legend"
                oLSeries.IsVisibleInLegend = True

                Dim oHSeries As Charting.Series

                oHSeries = oChart.Series.Add("Low Limit")
                oHSeries.ChartArea = oArea.Name
                oHSeries.ChartType = Charting.SeriesChartType.Line
                oHSeries.LegendText = "High Limit"
                oHSeries.IsVisibleInLegend = False
                oHSeries.Color = System.Drawing.Color.DarkCyan
                oHSeries.BorderDashStyle = Charting.ChartDashStyle.Dot
                oHSeries.BorderWidth = 1
                oHSeries.Legend = "Legend"
                oHSeries.IsVisibleInLegend = True

                oTrendChartList.Add(oChart)

            Next

        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "FormatCharts()", ex.Message)
        End Try
    End Sub


    Public Function GenerateTrendChartReport(ByVal nReportStatusID As Integer, ByVal dtFrom As Date, ByVal dtTo As Date, ByRef sOutFileName As String, ByRef nTimeInterval As Integer) As Boolean

        GenerateTrendChartReport = False

        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0
        Dim sAreaName As String = ""

        g_nReportType = ReportType.DataChartReport

        Dim oTrendChartList As New List(Of Charting.Chart)

        FormatCharts(oTrendChartList, dtFrom, dtTo, sAreaName)

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

                CalcualteTopBottomBodyMargins(nTopMargin, nBottomMargin, g_nReportType)


                g_oDoc.SetMargins(0.0F, 0, nTopMargin, nBottomMargin)
                g_oDoc.Open()




                Dim oTime As DateTime = dtFrom
                Dim oPrintTime As DateTime
                oTime = oTime.AddMilliseconds(-oTime.Millisecond)
                oTime = oTime.AddSeconds(-oTime.Second)
                Dim nCounter As Integer = 0
                Dim bDataFound As Boolean = False

                While oTime <= dtTo
                    If g_bIsGMTTime Then
                        oPrintTime = oTime.ToLocalTime()
                    Else
                        oPrintTime = oTime
                    End If
                    For nCol = 1 To g_oColList.Count - 1
                        If g_oColList(nCol).m_nColType = ColType.DP Or g_oColList(nCol).m_nColType = ColType.Temperature Or g_oColList(nCol).m_nColType = ColType.Humidity Then
                            Dim nPointID As Integer
                            Dim fValue As Single = 0.0

                            'nPointID = CInt()
                            If GetPointNameValue(g_oColList(nCol).m_sColumnNameinTable, oTime, g_oColList(nCol).m_sColFormat, fValue, True) Then
                                bDataFound = True
                                Try
                                    oTrendChartList(nCol).Series(g_oColList(nCol).m_nDataChartSeiries).Points.AddXY(oPrintTime, fValue)
                                Catch ex As Exception
                                    LogError("NewIndusoftReport.vb", "GenerateTrendChartReport()", ex.Message)
                                End Try


                            ElseIf bDataFound = True Then
                                Try
                                    bDataFound = False
                                    Dim oSeries As Charting.Series
                                    Dim sChartName As String

                                    sChartName = "Value" + g_oColList(nCol).m_nDataChartSeiries.ToString()

                                    oSeries = oTrendChartList(nCol).Series.Add(sChartName)
                                    oSeries.ChartArea = sAreaName
                                    oSeries.ChartType = Charting.SeriesChartType.Line
                                    oSeries.LegendText = "Value"
                                    oSeries.Color = System.Drawing.Color.DarkBlue
                                    oSeries.BorderDashStyle = Charting.ChartDashStyle.Solid
                                    oSeries.BorderWidth = 2
                                    oSeries.XValueType = Charting.ChartValueType.DateTime
                                    oSeries.Legend = "Legend"
                                    oSeries.IsVisibleInLegend = True
                                    g_oColList(nCol).m_nDataChartSeiries = oTrendChartList(nCol).Series.Count - 1
                                Catch ex As Exception
                                    LogError("NewIndusoftReport.vb", "GenerateTrendChartReport()", ex.Message)
                                End Try

                            End If

                            If g_oColList(nCol).m_bHighCheck And nCounter = 0 Then
                                If g_oColList(nCol).m_nHighCheckType = 1 Then

                                    GetPointNameValue(g_oColList(nCol).m_sHighCheckPointName, oTime, g_oColList(nCol).m_sColFormat, fValue, False)
                                Else
                                    fValue = g_oColList(nCol).m_fHigh
                                End If
                                oTrendChartList(nCol).Series(1).Points.AddXY(oPrintTime, fValue)
                            End If

                            If g_oColList(nCol).m_bLowCheck And nCounter = 0 Then
                                If g_oColList(nCol).m_nLowCheckType = 1 Then
                                    nPointID = CInt(g_oColList(nCol).m_fLow)
                                    GetPointNameValue(g_oColList(nCol).m_sLowCheckPointName, oTime, g_oColList(nCol).m_sColFormat, fValue, False)
                                Else
                                    fValue = g_oColList(nCol).m_fLow
                                End If
                                oTrendChartList(nCol).Series(2).Points.AddXY(oPrintTime, fValue)
                            End If
                        End If
                        nCounter = nCounter + 1
                        If nCounter > 60 Then
                            nCounter = 0
                        End If
                    Next


                    oTime = oTime.AddMinutes(nTimeInterval)
                    UpdateReportProgress(nReportStatusID, dtFrom, dtTo, oTime)
                End While

                For ncol = 1 To oTrendChartList.Count - 1
                    Try
                        Dim sImageFile As String
                        sImageFile = g_sInFileDir + "\images\temp" + ncol.ToString() + ".png"
                        oTrendChartList(ncol).SaveImage(sImageFile, Charting.ChartImageFormat.Png)


                        Dim oImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(sImageFile)

                        AddAlarmTableAndImageToDocument(ncol, dtFrom, dtTo, oImage, nTopMargin, Writer)

                    Catch ex As Exception
                        AddDebugMessageToReport(g_oDoc, ex.Message)
                    End Try
                Next

                PrintEndOfReport(dtFrom, dtTo)
                g_oDoc.Close()
                GenerateTrendChartReport = True
            End Using

        Catch ex As Exception

            UpdateExceptionInDatabase(nReportStatusID, ex.Message)
            UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
        Finally
            UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
            Try
                g_oDoc.Close()
            Catch ex As Exception

            End Try
        End Try


    End Function

    Public Sub GetPointAlarmList(ByRef sPointName As String, ByRef oFrom As Date, ByRef oToDate As Date, ByRef oAlamList As List(Of AlarmInfo))

        Dim oReader As OdbcDataReader
        Dim sQuery As String

        Try

            sQuery = "SELECT * FROM ALARMHISTORY  WHERE Al_Tag='" + sPointName + "' AND Al_Start_Time >= ? AND Al_Start_Time <=?  ORDER BY Al_Start_Time"


            Using oConnection As New OdbcConnection(g_sEMSDbConString)
                Dim cmd As New OdbcCommand(sQuery, oConnection)
                oConnection.Open()

                cmd.Parameters.Add(GetTimeODBCParam("@0", oFrom))
                cmd.Parameters.Add(GetTimeODBCParam("@1", oToDate))

                Try

                    Dim oAlmTime As Date
                    'Dim oAlarmAckTime As Date
                    Dim oAlmRtnTime As Date
                    'Dim bACKDOne As Boolean
                    Dim bAlmRtn As Boolean
                    Dim sValues(10) As String

                    For nIndex = 1 To 10
                        sValues(nIndex) = "Not Assigned"
                    Next

                    oReader = cmd.ExecuteReader()
                    While oReader.Read()

                        Try
                            oAlmTime = oReader("Al_Start_Time")
                            If g_bIsGMTTime Then
                                sValues(0) = FormatTimeToString(oAlmTime.ToLocalTime, g_oColList(0).m_sColFormat)
                            Else
                                sValues(0) = FormatTimeToString(oAlmTime, g_oColList(0).m_sColFormat)
                            End If
                        Catch ex As Exception
                            LogError("NewIndusoftReport.vb", "GetPointAlarmList()", ex.Message)
                        End Try
                        Try
                            sValues(1) = oReader("Al_Message")
                        Catch ex As Exception
                            sValues(1) = ""
                        End Try
                        ' sAlmText = oAlarmGUID.ToString()
                        Try
                            sValues(2) = ""
                        Catch ex As Exception
                            sValues(2) = ""
                        End Try

                        sValues(5) = ""
                        sValues(6) = ""

                        'If Alarm Text is NULL...Then...Don't Print the same
                        If sValues(1) <> "" Then
                            Dim oAlmInfo As New AlarmInfo

                            'Try
                            '    oAlarmAckTime = oReader("Al_Ack_Time")
                            '    sValues(5) = oReader("Al_User_Full")
                            '    sValues(6) = oReader("Al_User_Comment")
                            '    bACKDOne = True
                            'Catch ex As Exception
                            '    bACKDOne = False
                            'End Try

                            Try
                                oAlmRtnTime = oReader("Al_Norm_Time")
                                bAlmRtn = True
                            Catch ex As Exception
                                bAlmRtn = False
                            End Try

                            oAlmInfo.m_sStartTime = sValues(0)

                            If bAlmRtn Then
                                oAlmInfo.m_sDuration = GetDurationString(oAlmTime, oAlmRtnTime)

                                If g_bIsGMTTime Then
                                    oAlmInfo.m_sEndTime = FormatTimeToString(oAlmRtnTime.ToLocalTime, g_oColList(0).m_sColFormat)
                                Else
                                    oAlmInfo.m_sEndTime = FormatTimeToString(oAlmRtnTime, g_oColList(0).m_sColFormat)
                                End If
                            Else
                                oAlmInfo.m_sDuration = "Active"
                            End If

                            oAlamList.Add(oAlmInfo)

                        End If




                    End While
                    oReader.Close()

                Catch ex As Exception
                    LogError("NewIndusoftReport.vb", "GetPointAlarmList()", ex.Message)
                End Try
                oConnection.Close()

            End Using

        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "GetPointAlarmList()", ex.Message)
        Finally

        End Try

    End Sub


    Public Sub AddAlarmTableAndImageToDocument(ByRef ncol As Integer, ByRef oFrom As Date, ByRef oToDate As Date, ByRef oImage As iTextSharp.text.Image, ByRef nTopMargin As Integer, ByRef Writer As PdfWriter)

        Dim sPointName As String
        Dim nPointID As Integer
        Dim xtemp, ytemp As Single


        xtemp = g_fSideMargin + 10
        ytemp = g_oDoc.PageSize.Height - oImage.Height * 1 - nTopMargin - 30


        Try
            nPointID = CInt(g_oColList(ncol).m_sColumnNameinTable)
            sPointName = GetPointName(nPointID)
        Catch ex As Exception
            sPointName = ""
        End Try


        Dim oAlamList As New List(Of AlarmInfo)

        GetPointAlarmList(sPointName, oFrom, oToDate, oAlamList)


        If oAlamList.Count <= 0 Then
            Dim oTable = New PdfPTable(1)
            oTable.TotalWidth = 220
            Dim sColWidths(0) As Single
            sColWidths(0) = 1.0
            oTable.SetWidths(sColWidths)

            Dim oPdfCel As PdfPCell
            oPdfCel = New PdfPCell(New Paragraph("No Alarms Initiated In Selected Time Period", g_oNoAlarmBoxFont))
            oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
            oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
            oPdfCel.Padding = g_nBodyPad * 2
            oPdfCel.BorderWidth = 1.0F
            oPdfCel.BorderColor = iTextSharp.text.Color.BLACK

            oTable.AddCell(oPdfCel)
            oTable.WriteSelectedRows(0, -1, 600.0, 495.0, Writer.DirectContent)

            oImage.SetAbsolutePosition(xtemp, ytemp)
            g_oDoc.Add(oImage)
            g_oDoc.NewPage()
        Else



            Dim oTable As PdfPTable
            Dim oPdfCel As PdfPCell
            oTable = New PdfPTable(3)
            oTable.TotalWidth = 220
            Dim sColWidths() As Single = {1.0, 0.5, 0.5}
            oTable.SetWidths(sColWidths)


            Dim nCount As Integer = 0
            For nIndex = 0 To oAlamList.Count - 1
                If nCount = 0 Then
                    oTable = New PdfPTable(3)
                    oTable.TotalWidth = 220
                    oTable.SetWidths(sColWidths)

                    oPdfCel = New PdfPCell(New Paragraph("Alarm Start Time", g_oBodyFont))
                    oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                    oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                    oPdfCel.BorderWidth = 1.0F
                    oPdfCel.BorderColor = iTextSharp.text.Color.BLACK
                    oPdfCel.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oTable.AddCell(oPdfCel)

                    oPdfCel = New PdfPCell(New Paragraph("Duration", g_oBodyFont))
                    oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                    oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                    oPdfCel.BorderWidth = 1.0F
                    oPdfCel.BorderColor = iTextSharp.text.Color.BLACK
                    oPdfCel.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oTable.AddCell(oPdfCel)

                    oPdfCel = New PdfPCell(New Paragraph("Type", g_oBodyFont))
                    oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                    oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                    oPdfCel.BorderWidth = 1.0F
                    oPdfCel.BorderColor = iTextSharp.text.Color.BLACK
                    oPdfCel.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oTable.AddCell(oPdfCel)

                End If
                oPdfCel = New PdfPCell(New Paragraph(oAlamList(nIndex).m_sStartTime, g_oBodyFont))
                oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                oPdfCel.BorderWidth = 1.0F
                oPdfCel.BorderColor = iTextSharp.text.Color.BLACK
                oTable.AddCell(oPdfCel)

                oPdfCel = New PdfPCell(New Paragraph(oAlamList(nIndex).m_sDuration, g_oBodyFont))
                oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                oPdfCel.BorderWidth = 1.0F
                oPdfCel.BorderColor = iTextSharp.text.Color.BLACK
                oTable.AddCell(oPdfCel)

                oPdfCel = New PdfPCell(New Paragraph(oAlamList(nIndex).m_sType, g_oBodyFont))
                oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
                oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
                oPdfCel.BorderWidth = 1.0F
                oPdfCel.BorderColor = iTextSharp.text.Color.BLACK
                oTable.AddCell(oPdfCel)
                nCount = nCount + 1
                If nCount > 30 Then
                    oImage.SetAbsolutePosition(xtemp, ytemp)
                    g_oDoc.Add(oImage)
                    oTable.WriteSelectedRows(0, -1, 600.0, 495.0, Writer.DirectContent)

                    If nIndex < oAlamList.Count - 1 Then
                        'Add Marker To Next Page

                        Dim oTable1 = New PdfPTable(1)
                        oTable1.TotalWidth = 220
                        Dim sColWidths1(0) As Single
                        sColWidths1(0) = 1.0
                        oTable1.SetWidths(sColWidths1)

                        Dim oPdfCel1 As PdfPCell
                        oPdfCel1 = New PdfPCell(New Paragraph("Continued To Next Page", g_oNextPageFont))
                        oPdfCel1.HorizontalAlignment = Element.ALIGN_CENTER
                        oPdfCel1.VerticalAlignment = Element.ALIGN_MIDDLE
                        oPdfCel1.Padding = g_nBodyPad * 2
                        oPdfCel1.BorderWidth = 1.0F
                        oPdfCel1.BorderColor = iTextSharp.text.Color.BLACK

                        oTable1.AddCell(oPdfCel1)
                        oTable1.WriteSelectedRows(0, -1, 600.0, 70.0, Writer.DirectContent)
                    End If

                    g_oDoc.NewPage()
                    nCount = 0
                End If
            Next

            If nCount > 0 Then
                oImage.SetAbsolutePosition(xtemp, ytemp)
                g_oDoc.Add(oImage)
                oTable.WriteSelectedRows(0, -1, 600.0, 495.0, Writer.DirectContent)
                g_oDoc.NewPage()
                nCount = 0
            End If

        End If

    End Sub


    Public Function GenerateTrendReport(ByVal nReportStatusID As Integer, ByVal dtFrom As Date, ByVal dtTo As Date, ByRef sOutFileName As String, ByRef nTimeInterval As Integer) As Boolean

        GenerateTrendReport = False
        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0
        g_Current_MinVal = 999.0
        g_Current_MaxVal = -999.0


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

                CalcualteTopBottomBodyMargins(nTopMargin, nBottomMargin, ReportType.DataReport)

                g_oDoc.SetMargins(0.0F, 0, nTopMargin, nBottomMargin)
                g_oDoc.Open()

                PrintLimitSetPointRows(dtFrom, dtTo)

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

                            Try

                                'get min value of each column And assign to m_freportmin
                                If g_oColList(nCol).m_nColType = ColType.Temperature Or g_oColList(nCol).m_nColType = ColType.Humidity Or g_oColList(nCol).m_nColType = ColType.DP Then
                                    If g_oColList(nCol).m_sValue = "****" Then

                                    Else
                                        If g_oColList(nCol).m_sValue <= g_oColList(nCol).m_fReportMin Then
                                            g_oColList(nCol).m_fReportMin = g_oColList(nCol).m_sValue
                                            'g_Current_MinVal = g_oColList(nCol).m_fValue
                                            g_oColList(nCol).m_bReportMinAdded = True
                                        End If
                                        ' get max value of each column and assign to m_freportmin
                                        If g_oColList(nCol).m_sValue >= g_oColList(nCol).m_fReportMax Then
                                            g_oColList(nCol).m_fReportMax = g_oColList(nCol).m_sValue
                                            'g_Current_MaxVal = g_oColList(nCol).m_fValue
                                            g_oColList(nCol).m_bReportMaxAdded = True
                                        End If
                                    End If

                                End If
                            Catch ex As Exception

                            End Try

                        Next
                        g_oDoc.Add(oTable)
                    End If

                    oTime = oTime.AddMinutes(nTimeInterval)

                    UpdateReportProgress(nReportStatusID, dtFrom, dtTo, oTime)
                End While

                If g_bPrintMinMaxRows Then
                    PrintMinMaxRows(dtFrom, dtTo)
                End If

                PrintKMT()

                PrintEndOfReport(dtFrom, dtTo)

                g_oDoc.Close()
                GenerateTrendReport = True
            End Using


        Catch ex As Exception
            UpdateExceptionInDatabase(nReportStatusID, ex.Message)
            UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
        Finally
            UpdateReportProgress(nReportStatusID, dtFrom, dtTo, dtTo)
            Try
                g_oDoc.Close()
            Catch ex As Exception
                UpdateExceptionInDatabase(nReportStatusID, ex.Message)
            End Try
        End Try


    End Function

    Public Sub AddDebugMessageToReport(ByRef oDoc As Document, ByRef sMessage As String)
        Try
            Dim oExTable = New PdfPTable(1)

            oExTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
            oExTable.WidthPercentage = g_fSideFactor

            oExTable.HorizontalAlignment = Element.ALIGN_CENTER
            Dim oPdfCel As PdfPCell

            oPdfCel = New PdfPCell(New Paragraph(sMessage, g_oBodyFontHigh))
            oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
            oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
            oPdfCel.PaddingBottom = g_nBodyPad
            oExTable.AddCell(oPdfCel)
            oDoc.Add(oExTable)

        Catch ex As Exception

        End Try
    End Sub
    Public Sub AddNoRecordsTable(ByRef sMessage As String)
        Try
            Dim oExTable = New PdfPTable(1)

            oExTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
            oExTable.WidthPercentage = g_fSideFactor
            oExTable.SpacingBefore = 20

            oExTable.HorizontalAlignment = Element.ALIGN_CENTER
            Dim oPdfCel As PdfPCell

            oPdfCel = New PdfPCell(New Paragraph(sMessage, g_oBodyFontHigh))
            oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
            oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
            oPdfCel.PaddingBottom = g_nBodyPad
            oExTable.AddCell(oPdfCel)
            g_oDoc.Add(oExTable)


        Catch ex As Exception

        End Try
    End Sub


    Public Sub AddExceptionToReport(ByRef oDoc As Document, ByRef sMessage As String)
        Try
            Dim oExTable = New PdfPTable(1)

            oExTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
            oExTable.WidthPercentage = g_fSideFactor

            oExTable.HorizontalAlignment = Element.ALIGN_CENTER
            Dim oPdfCel As PdfPCell

            oPdfCel = New PdfPCell(New Paragraph(sMessage, g_oBodyFontHigh))
            oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
            oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
            oPdfCel.PaddingBottom = g_nBodyPad
            oExTable.AddCell(oPdfCel)
            oDoc.Add(oExTable)

            oDoc.Close()
        Catch ex As Exception

        End Try
    End Sub

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
                                If g_oColList(nCol).m_nColType = ColType.Temperature Then
                                    If g_oColList(nCol).m_sValue < g_oColList(nCol).m_fLow Then
                                        g_oColList(nCol).m_bError = True
                                    End If
                                Else
                                    If g_oColList(nCol).m_sValue < g_oColList(nCol).m_fLow Then
                                        g_oColList(nCol).m_bError = True
                                    End If
                                End If


                            End If
                            If g_oColList(nCol).m_bHighCheck And g_oColList(nCol).m_fHigh <> 0 Then
                                If g_oColList(nCol).m_nColType = ColType.Temperature Then
                                    If g_oColList(nCol).m_sValue > g_oColList(nCol).m_fHigh Then
                                        g_oColList(nCol).m_bError = True
                                    End If
                                Else
                                    If g_oColList(nCol).m_sValue > g_oColList(nCol).m_fHigh Then
                                        g_oColList(nCol).m_bError = True
                                    End If
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
                LogError("NewIndusoftReport.vb", "GetColInstanceValues()", ex.Message)
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
                g_Current_MinVal = 999.0
                g_Current_MaxVal = -999.0
                'g_oColList(nCol).m_fReportMin = 999
                'g_oColList(nCol).m_fReportMax = -999
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
                            If g_oColList(nCol).m_bLowCheck And g_oColList(nCol).m_fValue < g_oColList(nCol).m_fLow Then
                                g_oColList(nCol).m_bError = True
                            ElseIf g_oColList(nCol).m_bHighCheck And g_oColList(nCol).m_fValue > g_oColList(nCol).m_fHigh Then
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
            LogError("NewIndusoftReport.vb", "GetColAverageMinMaxValues()", ex.Message)
        End Try



    End Function

    Public Function GetSelectedEventIDs() As String
        GetSelectedEventIDs = ""
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Try
            sQuery = "SELECT * FROM tbl_reportedevents where eventid is not NULL"
            Using oConnection As New OdbcConnection(g_sConString)
                oConnection.Open()
                Dim oCmd As New OdbcCommand(sQuery, oConnection)
                oReader = oCmd.ExecuteReader()
                While oReader.Read()
                    If GetSelectedEventIDs.Length() < 1 Then
                        GetSelectedEventIDs += " AND (systemeventid=" + oReader("eventid").ToString()
                    Else
                        GetSelectedEventIDs += " OR systemeventid=" + oReader("eventid").ToString()
                    End If

                End While
                GetSelectedEventIDs += " ) "
                oConnection.Close()
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

                CalcualteTopBottomBodyMargins(nTopMargin, nBottomMargin, ReportType.EventReport)
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
                                        If fTemp < g_oColList(nCol).m_fLow Then
                                            bLow = True
                                        End If
                                    ElseIf g_oColList(nCol).m_bHighCheck And g_oColList(nCol).m_fHigh <> 0 Then
                                        If fTemp > g_oColList(nCol).m_fHigh Then
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


                CalcualteTopBottomBodyMargins(nTopMargin, nBottomMargin, ReportType.AlarmReport)
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

                sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE " + sTimeField + " >= ? AND " + sTimeField + " <= ? AND " + sAlmGrpColName + " =? ORDER BY " + sTimeField + ",Al_Norm_Time"

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
        Try
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
        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "SetPageEventParameters()", ex.Message)
        End Try

    End Sub

    Private Sub PrintEndOfReport(ByVal oStartTime As Date, ByVal oEndTime As Date)

        Try
            If g_bIsGMTTime Then
                oStartTime = oStartTime.ToLocalTime()
                oEndTime = oEndTime.ToLocalTime()
            End If

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

            If g_bPrintReviewTableEveryPage = False Then

                Dim oTable As New PdfPTable(1)
                oTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin

                Dim oPdfCel As PdfPCell = New PdfPCell(New Paragraph("           ", g_oHFont))
                oPdfCel.Border = 0
                oTable.AddCell(oPdfCel)
                g_oDoc.Add(oTable)

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
                g_oDoc.Add(oFooterTable)
            End If
        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "PrintEndOfReport()", ex.Message)
        End Try


    End Sub

    Private Sub PrintMinMaxRows(ByVal oStartDate As Date, ByVal oEndDate As Date)

        Try
            Dim oCell As PdfPCell
            Dim sTemp As String

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


            sTemp = "Min Value"
            oCell = New PdfPCell(New Phrase(sTemp, g_oBodyHeaderFont))
            oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
            oCell.PaddingTop = g_nBodyPad
            oCell.PaddingBottom = g_nBodyPad
            oCell.HorizontalAlignment = Element.ALIGN_CENTER
            oCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oTable.AddCell(oCell)



            For nIndex = 1 To g_oColList.Count - 1

                sTemp = ""
                If g_oColList(nIndex).m_nColType = ColType.DP Or g_oColList(nIndex).m_nColType = ColType.Temperature Or g_oColList(nIndex).m_nColType = ColType.Humidity Then
                    If g_oColList(nIndex).m_bReportMinAdded = True Then
                        sTemp = g_oColList(nIndex).m_fReportMin.ToString(g_oColList(nIndex).m_sColFormat)
                    Else
                        sTemp = g_sErrorText
                    End If
                End If

                oCell = New PdfPCell(New Phrase(sTemp, g_oBodyHeaderFont))
                oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                oCell.PaddingTop = g_nBodyPad
                oCell.PaddingBottom = g_nBodyPad
                oCell.HorizontalAlignment = Element.ALIGN_CENTER
                oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                oTable.AddCell(oCell)

            Next

            oCell = New PdfPCell(New Phrase("Max Value", g_oBodyHeaderFont))
            oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
            oCell.PaddingTop = g_nBodyPad
            oCell.PaddingBottom = g_nBodyPad
            oCell.HorizontalAlignment = Element.ALIGN_CENTER
            oCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oTable.AddCell(oCell)

            For nIndex = 1 To g_oColList.Count - 1

                sTemp = ""
                If g_oColList(nIndex).m_nColType = ColType.DP Or g_oColList(nIndex).m_nColType = ColType.Temperature Or g_oColList(nIndex).m_nColType = ColType.Humidity Then
                    If g_oColList(nIndex).m_bReportMaxAdded = True Then
                        sTemp = g_oColList(nIndex).m_fReportMax.ToString(g_oColList(nIndex).m_sColFormat)
                    Else
                        sTemp = g_sErrorText
                    End If
                End If

                oCell = New PdfPCell(New Phrase(sTemp, g_oBodyHeaderFont))
                oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                oCell.PaddingTop = g_nBodyPad
                oCell.PaddingBottom = g_nBodyPad
                oCell.HorizontalAlignment = Element.ALIGN_CENTER
                oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                oTable.AddCell(oCell)
            Next


            g_oDoc.Add(oTable)
        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "PrintMinMaxRows()", ex.Message)
        End Try

    End Sub


    Private Sub PrintKMT()

        Try
            If g_bAddMeanKineticTempRow Then

                Dim oCell As PdfPCell
                Dim sTemp As String


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

                oCell = New PdfPCell(New Phrase("MKT Value", g_oBodyHeaderFont))
                oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                oCell.PaddingTop = g_nBodyPad
                oCell.PaddingBottom = g_nBodyPad
                oCell.HorizontalAlignment = Element.ALIGN_CENTER
                oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                oTable.AddCell(oCell)

                For nIndex = 1 To g_oColList.Count - 1

                    sTemp = ""
                    If g_oColList(nIndex).m_nColType = ColType.Temperature Then
                        If g_oColList(nIndex).m_nKMTCount > 0 Then
                            Dim dTemp As Double
                            dTemp = g_oColList(nIndex).m_dKMT / g_oColList(nIndex).m_nKMTCount
                            dTemp = Math.Log(dTemp) * -1
                            dTemp = 10000 / dTemp
                            dTemp = dTemp - 273.15

                            sTemp = dTemp.ToString(g_oColList(nIndex).m_sColFormat)
                        Else
                            sTemp = "No Records"
                        End If
                    End If

                    oCell = New PdfPCell(New Phrase(sTemp, g_oBodyHeaderFont))
                    oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oCell.PaddingTop = g_nBodyPad
                    oCell.PaddingBottom = g_nBodyPad
                    oCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oTable.AddCell(oCell)
                Next
                g_oDoc.Add(oTable)
            End If

        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "PrintKMT()", ex.Message)
        End Try




    End Sub

    Private Sub PrintLimitSetPointRows(ByRef oStartDate As Date, ByRef oEndDate As Date)

        Try

            Dim bAddTable As Boolean = False
            Dim oCell As PdfPCell
            Dim sTemp As String


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



            sTemp = "Alarm Low Limit"
            oCell = New PdfPCell(New Paragraph(sTemp, g_oBodyHeaderFont))
            oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
            oCell.PaddingTop = g_nBodyPad
            oCell.PaddingBottom = g_nBodyPad
            oCell.HorizontalAlignment = Element.ALIGN_CENTER
            oCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oTable.AddCell(oCell)

            If g_bPrintMinMaxRows = True Then
                For nIndex = 1 To g_oColList.Count - 1

                    sTemp = ""
                    If g_oColList(nIndex).m_bLowCheck Then
                        If g_oColList(nIndex).m_nLowCheckType = 1 Then
                            Try
                                If GetPointNameValue(g_oColList(nIndex).m_sLowCheckPointName, oStartDate, g_oColList(nIndex).m_sColFormat, g_oColList(nIndex).m_fLow, False) = True Then
                                    sTemp = g_oColList(nIndex).m_fLow.ToString(g_oColList(nIndex).m_sColFormat)
                                End If
                            Catch ex As Exception

                            End Try
                        Else
                            sTemp = g_oColList(nIndex).m_fLow.ToString(g_oColList(nIndex).m_sColFormat)
                        End If
                    End If

                    oCell = New PdfPCell(New Phrase(sTemp, g_oBodyHeaderFont))
                    oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oCell.PaddingTop = g_nBodyPad
                    oCell.PaddingBottom = g_nBodyPad
                    oCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oTable.AddCell(oCell)
                Next
            End If

            If g_bPrintAlarmSpRows = True Then

                oCell = New PdfPCell(New Paragraph("Set Value", g_oBodyHeaderFont))
                oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                oCell.PaddingTop = g_nBodyPad
                oCell.PaddingBottom = g_nBodyPad
                oCell.HorizontalAlignment = Element.ALIGN_CENTER
                oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                oTable.AddCell(oCell)

                For nIndex = 1 To g_oColList.Count - 1

                    sTemp = ""

                    If g_oColList(nIndex).m_bSPCheck Then
                        If g_oColList(nIndex).m_nSPCheckType = 1 Then
                            Try
                                If GetPointNameValue(g_oColList(nIndex).m_sSPCheckPointName, oStartDate, g_oColList(nIndex).m_sColFormat, g_oColList(nIndex).m_fSP, False) Then
                                    sTemp = g_oColList(nIndex).m_fSP.ToString(g_oColList(nIndex).m_sColFormat)
                                End If
                            Catch ex As Exception

                            End Try
                        Else
                            sTemp = g_oColList(nIndex).m_fSP.ToString(g_oColList(nIndex).m_sColFormat)
                        End If
                    End If

                    oCell = New PdfPCell(New Phrase(sTemp, g_oBodyHeaderFont))
                    oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oCell.PaddingTop = g_nBodyPad
                    oCell.PaddingBottom = g_nBodyPad
                    oCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oTable.AddCell(oCell)
                Next
            End If

            oCell = New PdfPCell(New Paragraph("Alarm High Limit", g_oBodyHeaderFont))
            oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
            oCell.PaddingTop = g_nBodyPad
            oCell.PaddingBottom = g_nBodyPad
            oCell.HorizontalAlignment = Element.ALIGN_CENTER
            oCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oTable.AddCell(oCell)


            If g_bPrintMinMaxRows = True Then
                For nIndex = 1 To g_oColList.Count - 1
                    sTemp = ""
                    If g_oColList(nIndex).m_bHighCheck Then
                        If g_oColList(nIndex).m_nHighCheckType = 1 Then
                            Try
                                If GetPointNameValue(g_oColList(nIndex).m_sHighCheckPointName, oStartDate, g_oColList(nIndex).m_sColFormat, g_oColList(nIndex).m_fHigh, False) = True Then
                                    sTemp = g_oColList(nIndex).m_fHigh.ToString(g_oColList(nIndex).m_sColFormat)
                                End If
                            Catch ex As Exception

                            End Try
                        Else
                            sTemp = g_oColList(nIndex).m_fHigh.ToString(g_oColList(nIndex).m_sColFormat)
                        End If
                    End If

                    oCell = New PdfPCell(New Phrase(sTemp, g_oBodyHeaderFont))
                    oCell.BackgroundColor = New iTextSharp.text.Color(90, 190, 243)
                    oCell.PaddingTop = g_nBodyPad
                    oCell.PaddingBottom = g_nBodyPad
                    oCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oTable.AddCell(oCell)
                Next

            End If

            g_oDoc.Add(oTable)
        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "PrintLimitSetPointRows()", ex.Message)
        End Try

    End Sub

    Public Function GetPointNameValue(ByRef sPointName As String, ByRef oStartDate As Date, ByRef sFormat As String, ByRef fValue As Single, ByRef bIsPoint As Boolean) As Boolean
        Try
            GetPointNameValue = False
            Dim oFromDate As Date
            Dim sQuery As String
            Dim oReader As OdbcDataReader

            oFromDate = oStartDate.AddSeconds(-30)
            If bIsPoint = True Then
                sQuery = "SELECT TOP(1) " + sPointName + " FROM TREND001 WHERE Time_Stamp > ? AND  Time_Stamp < ?  AND " + sPointName + " IS NOT NULL  order by Time_Stamp"
            Else
                sQuery = "SELECT TOP(1) " + sPointName + " FROM TREND001 WHERE Time_Stamp > ? AND " + sPointName + " IS NOT NULL order by Time_Stamp"
            End If

            Using oConnection As New OdbcConnection(g_sEMSDbConString)
                Dim cmd As New OdbcCommand(sQuery, oConnection)
                oConnection.Open()
                cmd.Parameters.Add(GetTimeODBCParam("@0", oFromDate))
                If bIsPoint = True Then
                    cmd.Parameters.Add(GetTimeODBCParam("@1", oFromDate.AddDays(1)))
                End If
                Try
                    oReader = cmd.ExecuteReader()
                    If oReader.Read() Then
                        Try
                            fValue = Convert.ToSingle(oReader(sPointName))
                            If fValue < 0 Then
                                fValue = 0
                                GetPointNameValue = False
                            Else
                                GetPointNameValue = True
                            End If
                        Catch ex As Exception
                            fValue = 0.0
                            GetPointNameValue = False
                        End Try
                    End If
                    oReader.Close()
                Catch ex As Exception
                    AddDebugMessageToReport(g_oDoc, ex.Message)
                End Try
                oConnection.Close()
            End Using

        Catch ex As Exception

            LogError("NewIndusoftReport.vb", "GetPointNameValue()", ex.Message)
            Return GetPointNameValue
        End Try

    End Function


    Private Sub CalcualteTopBottomBodyMargins(ByRef nTopMargin As Integer, ByRef nBottomMargin As Integer, ByRef nReporttype As ReportType)

        Try
            Dim nBodyDeaderYPos As Integer

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
                oHeaderCell.PaddingTop = g_nBodyPad
                oHeaderCell.PaddingBottom = g_nBodyPad
                oHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER
                oHeaderCell.VerticalAlignment = Element.ALIGN_MIDDLE
                oHeaderTable.AddCell(oHeaderCell)
            End If
            If g_bHeaderAddress Then
                Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeaderAddress, g_oBodyHeaderFont))
                oHeaderCell.PaddingTop = g_nHeaderPad
                oHeaderCell.PaddingBottom = g_nHeaderPad
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


            Dim oBodyHeaderTable As PdfPTable
            Dim oBodyHeaderTable2 As PdfPTable

            If g_nReportType <> ReportType.DataChartReport Then

                If g_nReportType = ReportType.AlarmReport Or g_nReportType = ReportType.EventReport Then
                    Dim nAlarmColCount As Integer = 0

                    For nCol = 0 To g_oColList.Count - 1
                        If g_oColList(nCol).m_bshowAlarmCol Then
                            nAlarmColCount = nAlarmColCount + 1
                        End If
                    Next

                    oBodyHeaderTable = New PdfPTable(nAlarmColCount)
                    oBodyHeaderTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
                    oBodyHeaderTable.WidthPercentage = 90
                    oBodyHeaderTable.HorizontalAlignment = Element.ALIGN_CENTER


                    Dim sColWidths(nAlarmColCount - 1) As Single
                    nAlarmColCount = 0

                    For nCol = 0 To g_oColList.Count - 1
                        If g_oColList(nCol).m_bshowAlarmCol Then
                            sColWidths(nAlarmColCount) = g_oColList(nCol).m_sColWidth
                            nAlarmColCount = nAlarmColCount + 1
                        End If
                    Next
                    oBodyHeaderTable.SetWidths(sColWidths)

                    For nCol = 0 To g_oColList.Count - 1
                        If g_oColList(nCol).m_bshowAlarmCol Then

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
                        End If
                    Next
                    '  oBodyHeaderTable.WriteSelectedRows(0, -1, g_fSideMargin * 1.5, nBodyDeaderYPos, writer.DirectContent)
                    nTopMargin = nTopMargin + oBodyHeaderTable.TotalHeight + g_fTopBottomMargin + g_nFooterPad
                Else

                    oBodyHeaderTable = New PdfPTable(g_oColList.Count)
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
                    oBodyHeaderTable2 = New PdfPTable(nH1Cols)
                    oBodyHeaderTable2.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin
                    oBodyHeaderTable2.WidthPercentage = 90
                    oBodyHeaderTable2.HorizontalAlignment = Element.ALIGN_CENTER

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
                    '      oBodyHeaderTable2.WriteSelectedRows(0, -1, g_fSideMargin * 1.5, nBodyDeaderYPos, writer.DirectContent)
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
                    nTopMargin = nTopMargin + oBodyHeaderTable.TotalHeight + oBodyHeaderTable2.TotalHeight + g_fTopBottomMargin + g_nFooterPad


                End If

            End If

            nTopMargin = nTopMargin + g_nbodyheadermargin

            If g_bPrintReviewTableEveryPage = True Then

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
            Else
                nBottomMargin = g_fTopBottomMargin + 20
            End If

        Catch ex As Exception
            LogError("NewIndusoftReport.vb", "CalcualteTopBottomBodyMargins()", ex.Message)
        End Try

    End Sub


End Class
