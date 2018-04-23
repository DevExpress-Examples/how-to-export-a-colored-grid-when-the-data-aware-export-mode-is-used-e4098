@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "gvProducts"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartialProducts"}

            settings.KeyFieldName = "ProductID"

            settings.Columns.Add("ProductID")
            settings.Columns.Add("ProductName")
            settings.Columns.Add("UnitPrice")

            settings.HtmlDataCellPrepared = Function(sender, e)
                                                    If e.DataColumn.FieldName = "UnitPrice" Then
                                                        If Convert.ToInt32(e.CellValue) > 15 Then
                                                            e.Cell.BackColor = System.Drawing.Color.Yellow
                                                        Else
                                                            e.Cell.BackColor = System.Drawing.Color.Green
                                                        End If
                                                    End If

                                            End Function

    End Sub).Bind(Model).GetHtml()