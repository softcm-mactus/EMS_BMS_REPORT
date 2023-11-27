Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf



Public Class EMSRoomReport

    Private Class IEntryExitReportEvents
        Inherits PdfPageEventHelper

        'This Is the contentbyte object of the writer
        Dim cb As PdfContentByte
        'we will put the final number of pages in a template
        Dim FooterTemplate As PdfTemplate


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

                Dim oHeaderTable As PdfPTable
                If g_bIconNeeded Then
                    oHeaderTable = New PdfPTable(2)
                    oHeaderTable.TotalWidth = document.PageSize.Width - 2 * g_fSideMargin
                    Dim widths2 = {0.25F, 0.75F}
                    oHeaderTable.SetWidths(widths2)
                    Dim oImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(g_sInFileDir + "\\Images\\ReportLogo.jpg")
                    Dim oImageCell As PdfPCell = New PdfPCell(oImage)
                    oImageCell.Rowspan = g_nHeaderCount
                    oImageCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oImageCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oHeaderTable.AddCell(oImageCell)
                Else
                    oHeaderTable = New PdfPTable(1)
                    oHeaderTable.TotalWidth = document.PageSize.Width - 2 * g_fSideMargin
                End If

                If g_bHeader1 Then
                    Dim oHeaderCell As PdfPCell = New PdfPCell(New Phrase(g_sHeader1, g_oH1Font))
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
                oHeaderTable.WriteSelectedRows(0, -1, g_fSideMargin, document.PageSize.Height - g_fTopBottomMargin, writer.DirectContent)

                Dim nBodyDeaderYPos As Integer
                nBodyDeaderYPos = document.PageSize.Height - g_fTopBottomMargin - oHeaderTable.TotalHeight - 3

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
                cb.AddTemplate(FooterTemplate, document.PageSize.Width - g_fSideMargin * 1.5 - fLen, g_fTopBottomMargin + 7)

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



                If g_nReportType = ReportType.DataReport Then
                    For nCol = 0 To g_oColList.Count - 1
                        Dim oColHeader As PdfPCell = New PdfPCell(New Phrase(g_oColList(nCol).m_sColType, g_oBodyHeaderFont))

                        oColHeader.PaddingBottom = g_nBodyPad

                        oColHeader.BackgroundColor = New BaseColor(90, 190, 243)
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
                End If

                For nCol = 0 To g_oColList.Count - 1
                    Dim oColHeader As PdfPCell
                    oColHeader = New PdfPCell(New Paragraph(g_oColList(nCol).m_sColTitle, g_oBodyHeaderFont))

                    oColHeader.PaddingBottom = g_nBodyPad
                    oColHeader.BackgroundColor = New BaseColor(90, 190, 243)
                    oColHeader.BackgroundColor = New BaseColor(90, 190, 243)
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
                        oFooterCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    End If
                    oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oFooterTable.AddCell(oFooterCell)

                    oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol2, g_oFooterFont))
                    oFooterCell.PaddingTop = g_nFooterPad
                    oFooterCell.PaddingBottom = g_nFooterPad
                    If g_oFooterRowList(nCol).m_bHeader Then
                        oFooterCell.BackgroundColor = BaseColor.LIGHT_GRAY
                    End If
                    oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
                    oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    oFooterTable.AddCell(oFooterCell)

                    oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol3, g_oFooterFont))
                    oFooterCell.PaddingTop = g_nFooterPad
                    oFooterCell.PaddingBottom = g_nFooterPad
                    If g_oFooterRowList(nCol).m_bHeader Then
                        oFooterCell.BackgroundColor = BaseColor.LIGHT_GRAY
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

    Public Function GenerateTrendReport(ByRef sOutFileName As String, ByVal dtFrom As Date, ByVal dtTo As Date, ByVal sCurrentlyLoginID As String) As Boolean

        GenerateTrendReport = False
        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0

        g_sGeneratedUserName = sCurrentlyLoginID

        If g_oColList.Count = 0 Then
            MsgBox("No Columns Defined For This Report")
            Exit Function
        End If
        Try
            sOutFileName = fileNameDateStamp() + sOutFileName + ".pdf"
            sOutFileName = g_sOutputFileDir + "\" + sOutFileName
            Using FS As New FileStream(sOutFileName, FileMode.Create, FileAccess.Write, FileShare.None)

                g_oDoc = New Document(PageSize.A4)
                If g_bLandScape Then
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                Else
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4)
                End If


                Using g_oDoc
                    ''//Bind our PDF object to the physical file using a PdfWriter
                    Using Writer As PdfWriter = PdfWriter.GetInstance(g_oDoc, FS)
                        ''//Open our document for writing

                        Writer.PageEvent = New IEntryExitReportEvents

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


                        Dim oTime As DateTime = dtFrom
                        oTime = oTime.AddMilliseconds(-oTime.Millisecond)
                        oTime = oTime.AddSeconds(-oTime.Second)
                        While oTime <= dtTo
                            If g_nDataAgg = DataAgg.Instance Then
                                GetColInstanceValues(oTime)
                            Else
                                GetColAverageMinMaxValues(oTime, g_nTimeIntervalMin)
                            End If

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

                            oTime = oTime.AddMinutes(g_nTimeIntervalMin)

                        End While

                        g_oDoc.Add(oTable)

                        PrintEndOfReport(dtFrom, dtTo)
                        g_oDoc.Close()
                        GenerateTrendReport = True
                    End Using
                End Using
            End Using

        Catch ex As Exception

        Finally

        End Try

    End Function

    Public Sub GetColInstanceValues(ByRef oTime As Date)
        Dim sQuery As String
        Dim oReader As OdbcDataReader

        sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE Time_Stamp = ?"

        Using oConnection As New OdbcConnection(g_sEMSDbConString)
            Dim cmd As New OdbcCommand(sQuery, oConnection)
            oConnection.Open()
            cmd.Parameters.Add(GetTimeODBCParam("@0", oTime))

            Try

                Dim fTemp As Single

                oReader = cmd.ExecuteReader()
                If oReader.Read() Then
                    For nCol = 0 To g_oColList.Count - 1

                        g_oColList(nCol).m_sValue = ""
                        g_oColList(nCol).m_bError = False


                        If g_oColList(nCol).m_nColType = ColType.DateTime Then
                            g_oColList(nCol).m_sValue = oTime.ToString(g_oColList(nCol).m_sColFormat)
                        ElseIf g_oColList(nCol).m_nColType = ColType.Other Then
                            g_oColList(nCol).m_sValue = oReader(g_oColList(nCol).m_sColumnNameinTable)
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

    End Sub

    Public Sub GetColAverageMinMaxValues(ByRef oTime As Date, ByRef nTimeIntervalMin As Integer)
        Dim sQuery As String
        Dim oReader As OdbcDataReader
        Dim oToTime As Date
        Dim nRecords As Integer = 0


        Try

            oToTime = oTime.AddMinutes(nTimeIntervalMin)
            oToTime = oToTime.AddSeconds(-2)




            'Dim fAverage As Single
            'Dim fMin As Single
            'Dim fMax As Single
            'For nCol = 0 To g_oColList.Count - 1

            '    If g_oColList(nCol).m_nColType = ColType.Temperature Or g_oColList(nCol).m_nColType = ColType.Humidity Or g_oColList(nCol).m_nColType = ColType.DP Then
            '        sQuery = "SELECT AVG(" + g_oColList(nCol).m_sColumnNameinTable + ") As AvgValue, MIN(" + g_oColList(nCol).m_sColumnNameinTable
            '        sQuery = sQuery + ") As MinValue, Max(" + g_oColList(nCol).m_sColumnNameinTable + ") as MaxValue FROM " + g_sDataTableName
            '        sQuery = sQuery + " WHERE " + g_oColList(0).m_sColumnNameinTable + " >= ? AND " + g_oColList(0).m_sColumnNameinTable + " < ?"
            '        Using oConnection As New ODBCConnection(g_sEMSDbConString)
            '            Dim cmd As New odbcCommand(sQuery, oConnection)
            '            oConnection.Open()
            '            cmd.Parameters.Add(GetTimeODBCParam("@0", oTime))
            '            cmd.Parameters.Add(GetTimeODBCParam("@1", oToTime))
            '            oReader = cmd.ExecuteReader()
            '            If oReader.Read() Then
            '                Try
            '                    fAverage = oReader("AvgValue")
            '                    fMin = oReader("MinValue")
            '                    fMax = oReader("MaxValue")
            '                    g_oColList(nCol).m_bError = False
            '                    If g_oColList(nCol).m_bLowCheck And fAverage <= g_oColList(nCol).m_fLow Then
            '                        g_oColList(nCol).m_bError = True
            '                    ElseIf g_oColList(nCol).m_bHighCheck And fAverage >= g_oColList(nCol).m_fHigh Then
            '                        g_oColList(nCol).m_bError = True
            '                    End If

            '                    If g_nDataAgg = DataAgg.AverageMinMax Then
            '                        g_oColList(nCol).m_sValue = fMin.ToString(g_oColList(nCol).m_sColFormat)
            '                        g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + fAverage.ToString(g_oColList(nCol).m_sColFormat)
            '                        g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + fMax.ToString(g_oColList(nCol).m_sColFormat)
            '                    ElseIf g_nDataAgg = DataAgg.AverageMin Then
            '                        g_oColList(nCol).m_sValue = fMin.ToString(g_oColList(nCol).m_sColFormat)
            '                        g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + fAverage.ToString(g_oColList(nCol).m_sColFormat)

            '                    ElseIf g_nDataAgg = DataAgg.AverageMax Then

            '                        g_oColList(nCol).m_sValue = fAverage.ToString(g_oColList(nCol).m_sColFormat)
            '                        g_oColList(nCol).m_sValue = g_oColList(nCol).m_sValue + " - " + fMax.ToString(g_oColList(nCol).m_sColFormat)
            '                    Else
            '                        g_oColList(nCol).m_sValue = fAverage.ToString(g_oColList(nCol).m_sColFormat)
            '                    End If
            '                Catch ex As Exception
            '                    g_oColList(nCol).m_bError = True
            '                    g_oColList(nCol).m_sValue = g_sErrorText
            '                End Try
            '            Else
            '                g_oColList(nCol).m_bError = True
            '                g_oColList(nCol).m_sValue = g_sErrorText
            '            End If
            '        End Using
            '    ElseIf g_oColList(nCol).m_nColType = ColType.DateTime Then
            '        g_oColList(nCol).m_sValue = oTime.ToString(g_oColList(nCol).m_sColFormat)
            '        g_oColList(nCol).m_bError = False
            '    Else 'Neet to Implement the String Value
            '        sQuery = "SELECT " + g_oColList(nCol).m_sColumnNameinTable + ") As DataValue FROM " + g_sDataTableName + " WHERE " + g_oColList(0).m_sColumnNameinTable + " = ?"
            '        Using oConnection As New ODBCConnection(g_sEMSDbConString)
            '            Dim cmd As New odbcCommand(sQuery, oConnection)
            '            oConnection.Open()
            '            cmd.Parameters.Add(GetTimeODBCParam("@0", oTime))
            '            oReader = cmd.ExecuteReader()
            '            If oReader.Read() Then
            '                Try
            '                    g_oColList(nCol).m_sValue = oReader("DataValue").ToString
            '                    g_oColList(nCol).m_bError = False
            '                Catch ex As Exception
            '                    g_oColList(nCol).m_bError = True
            '                    g_oColList(nCol).m_sValue = g_sErrorText
            '                End Try

            '            Else
            '                g_oColList(nCol).m_bError = True
            '                g_oColList(nCol).m_sValue = g_sErrorText
            '            End If
            '        End Using

            '    End If
            'Next


            sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE Time_Stamp >= ? AND Time_Stamp < ?"
            For nCol = 0 To g_oColList.Count - 1
                g_oColList(nCol).m_bError = False
                g_oColList(nCol).m_fValue = 0
                g_oColList(nCol).m_fMax = -10000
                g_oColList(nCol).m_fMin = 10000
            Next


            Using oConnection As New OdbcConnection(g_sEMSDbConString)
                Dim cmd As New OdbcCommand(sQuery, oConnection)
                oConnection.Open()
                cmd.Parameters.Add(GetTimeODBCParam("@0", oTime))
                cmd.Parameters.Add(GetTimeODBCParam("@1", oToTime))

                oReader = cmd.ExecuteReader()
                While oReader.Read()
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



    End Sub

    Public Sub GenerateEventReport(ByRef sOutFileName As String, ByVal dtFrom As Date, ByVal dtTo As Date, ByVal sCurrentlyLoginID As String)


        Dim oReader As OdbcDataReader
        Dim sQuery As String
        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0

        g_sGeneratedUserName = sCurrentlyLoginID

        Try
            sOutFileName = fileNameDateStamp() + sOutFileName + ".pdf"
            sOutFileName = g_sOutputFileDir + "\" + sOutFileName
            Using FS As New FileStream(sOutFileName, FileMode.Create, FileAccess.Write, FileShare.None)

                g_oDoc = New Document(PageSize.A4)
                If g_bLandScape Then
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                Else
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4)
                End If


                Using g_oDoc
                    ''//Bind our PDF object to the physical file using a PdfWriter
                    Using Writer As PdfWriter = PdfWriter.GetInstance(g_oDoc, FS)
                        ''//Open our document for writing

                        Writer.PageEvent = New IEntryExitReportEvents


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
                                End While
                                oReader.Close()
                            Catch ex As Exception

                            End Try
                            oConnection.Close()
                        End Using
                        g_oDoc.Add(oTable)
                        PrintEndOfReport(dtFrom, dtTo)
                        g_oDoc.Close()
                    End Using
                End Using
            End Using

        Catch ex As Exception

        Finally

        End Try


    End Sub


    Public Sub GenerateAlarmReport(ByRef sOutFileName As String, ByVal nGroupID As Integer, ByVal dtFrom As Date, ByVal dtTo As Date, ByVal sCurrentlyLoginID As String)


        Dim oReader As OdbcDataReader
        Dim sQuery As String
        Dim nTopMargin As Integer = 0
        Dim nBottomMargin As Integer = 0

        g_sGeneratedUserName = sCurrentlyLoginID


        Try
            sOutFileName = fileNameDateStamp() + sOutFileName + ".pdf"
            sOutFileName = g_sOutputFileDir + "\" + sOutFileName
            Using FS As New FileStream(sOutFileName, FileMode.Create, FileAccess.Write, FileShare.None)

                g_oDoc = New Document(PageSize.A4)
                If g_bLandScape Then
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                Else
                    g_oDoc.SetPageSize(iTextSharp.text.PageSize.A4)
                End If


                Using g_oDoc
                    ''//Bind our PDF object to the physical file using a PdfWriter
                    Using Writer As PdfWriter = PdfWriter.GetInstance(g_oDoc, FS)
                        ''//Open our document for writing

                        Writer.PageEvent = New IEntryExitReportEvents


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

                        sQuery = "SELECT * FROM " + g_sDataTableName + " WHERE " + sTimeField + " >= ? AND " + sTimeField + " <= > AND Al_Group=? ORDER BY " + sTimeField + ""

                        Using oConnection As New OdbcConnection(g_sEMSDbConString)
                            Dim cmd As New OdbcCommand(sQuery, oConnection)
                            oConnection.Open()
                            cmd.Parameters.Add(GetTimeODBCParam("@0", dtFrom))
                            cmd.Parameters.Add(GetTimeODBCParam("@1", dtTo))
                            cmd.Parameters.Add("@2", OdbcType.Int).Value = nGroupID
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
                                End While
                                oReader.Close()
                            Catch ex As Exception

                            End Try
                            oConnection.Close()

                        End Using


                        g_oDoc.Add(oTable)

                        PrintEndOfReport(dtFrom, dtTo)
                        g_oDoc.Close()
                    End Using
                End Using
            End Using

        Catch ex As Exception
        Finally

        End Try


    End Sub


    Public Sub PrintEndOfReport(ByRef oStartTime As Date, ByRef oEndTime As Date)

        If g_bFRomToDatesPrinted Then

            Dim oTable As New PdfPTable(1)
            oTable.TotalWidth = g_oDoc.PageSize.Width - 3 * g_fSideMargin


            Dim oPdfCel As PdfPCell = New PdfPCell(New Paragraph("           ", g_oHFont))
            oPdfCel.Border = 0
            oTable.AddCell(oPdfCel)

            Dim sTemp As String
            sTemp = "End Of Report :  From " + oStartTime.ToString(g_sTimeFormatIndian, CultureInfo.InvariantCulture) + "  To " + oEndTime.ToString(g_sTimeFormatIndian, CultureInfo.InvariantCulture)

            oPdfCel = New PdfPCell(New Paragraph(sTemp, g_oFooterFont))
            oPdfCel.BackgroundColor = BaseColor.LIGHT_GRAY
            oPdfCel.HorizontalAlignment = Element.ALIGN_CENTER
            oPdfCel.VerticalAlignment = Element.ALIGN_MIDDLE
            oPdfCel.PaddingBottom = g_nBodyPad
            oPdfCel.ExtraParagraphSpace = 5
            oTable.AddCell(oPdfCel)
            g_oDoc.Add(oTable)
        End If

    End Sub

    Public Sub CalcualteTopBottomBodyMargins(ByRef nTopMargin As Integer, ByRef nBottomMargin As Integer)
        Dim oHeaderTable As PdfPTable
        If g_bIconNeeded Then
            oHeaderTable = New PdfPTable(2)
            oHeaderTable.TotalWidth = g_oDoc.PageSize.Width - 2 * g_fSideMargin
            Dim widths2 = {0.25F, 0.75F}
            oHeaderTable.SetWidths(widths2)
            Dim oImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(g_sInFileDir + "\\Images\\ReportLogo.jpg")
            Dim oImageCell As PdfPCell = New PdfPCell(oImage)
            oImageCell.Rowspan = g_nHeaderCount
            oImageCell.HorizontalAlignment = Element.ALIGN_CENTER
            oImageCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oHeaderTable.AddCell(oImageCell)
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
        oBodyHeaderTable.HorizontalAlignment = Element.ALIGN_CENTER

        Dim nCol As Integer

        If g_nReportType = ReportType.DataReport Then
            For nCol = 0 To g_oColList.Count - 1
                Dim oColHeader As PdfPCell = New PdfPCell(New Phrase(g_oColList(nCol).m_sColType, g_oBodyHeaderFont))

                oColHeader.PaddingBottom = g_nBodyPad

                oColHeader.BackgroundColor = New BaseColor(90, 190, 243)
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
        End If

        For nCol = 0 To g_oColList.Count - 1
            Dim oColHeader As PdfPCell
            oColHeader = New PdfPCell(New Paragraph(g_oColList(nCol).m_sColTitle, g_oBodyHeaderFont))

            oColHeader.PaddingBottom = g_nBodyPad
            oColHeader.BackgroundColor = BaseColor.LIGHT_GRAY
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
        nTopMargin = nTopMargin + oBodyHeaderTable.TotalHeight + 3 + g_fTopBottomMargin



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
                oFooterCell.BackgroundColor = BaseColor.LIGHT_GRAY
            End If
            oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
            oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oFooterTable.AddCell(oFooterCell)

            oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol2, g_oFooterFont))
            oFooterCell.PaddingTop = g_nFooterPad
            oFooterCell.PaddingBottom = g_nFooterPad
            If g_oFooterRowList(nCol).m_bHeader Then
                oFooterCell.BackgroundColor = BaseColor.LIGHT_GRAY
            End If
            oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
            oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oFooterTable.AddCell(oFooterCell)

            oFooterCell = New PdfPCell(New Phrase(g_oFooterRowList(nCol).m_sCol3, g_oFooterFont))
            oFooterCell.PaddingTop = g_nFooterPad
            oFooterCell.PaddingBottom = g_nFooterPad
            If g_oFooterRowList(nCol).m_bHeader Then
                oFooterCell.BackgroundColor = BaseColor.LIGHT_GRAY
            End If
            oFooterCell.HorizontalAlignment = Element.ALIGN_CENTER
            oFooterCell.VerticalAlignment = Element.ALIGN_MIDDLE
            oFooterTable.AddCell(oFooterCell)
        Next


        nBottomMargin = oFooterTable.TotalHeight + g_fTopBottomMargin + 20

    End Sub



End Class
