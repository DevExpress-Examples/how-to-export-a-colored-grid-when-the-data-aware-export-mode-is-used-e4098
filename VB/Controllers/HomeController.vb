Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.Web.Mvc

Public Class HomeController
    Inherits Controller

    Public Function Index() As ActionResult
        Return View(New MyViewModel With {.Products = MyModel.GetProducts()})
    End Function

    Public Function GridViewPartialProducts() As ActionResult
        Return PartialView(MyModel.GetProducts())
    End Function

    Public Function ExportTo() As ActionResult
      Return GridViewExtension.ExportToXlsx(GridViewHelper.ExportGridViewSettings, MyModel.GetProducts())

    End Function
End Class

Public NotInheritable Class GridViewHelper
    Private Sub New()
    End Sub
    Private Shared m_exportGridViewSettings As GridViewSettings

    Public Shared ReadOnly Property ExportGridViewSettings() As GridViewSettings
        Get
            If m_exportGridViewSettings Is Nothing Then
                m_exportGridViewSettings = CreateExportGridViewSettings()
            End If
            Return m_exportGridViewSettings
        End Get
    End Property

    Private Shared Function CreateExportGridViewSettings() As GridViewSettings
        Dim settings As New GridViewSettings()

        settings.Name = "gvProducts"
        settings.CallbackRouteValues = New With { _
         Key .Controller = "Home", _
         Key .Action = "GridViewPartialProducts" _
        }

        settings.KeyFieldName = "ProductID"
        settings.Settings.ShowFilterRow = True

        settings.Columns.Add("ProductID")
        settings.Columns.Add("ProductName")
        settings.Columns.Add("UnitPrice")

        settings.SettingsExport.RenderBrick = Function(sender, e)
                                                  If e.RowType <> GridViewRowType.Data Then
                                                      Exit Function
                                                  End If
                                                  If TryCast(e.Column, GridViewDataColumn).FieldName = "UnitPrice" AndAlso e.RowType <> GridViewRowType.Header Then
                                                      If Convert.ToInt32(e.TextValue) > 15 Then
                                                          e.BrickStyle.BackColor = System.Drawing.Color.Yellow
                                                      Else
                                                          e.BrickStyle.BackColor = System.Drawing.Color.Green
                                                      End If
                                                  End If
                                              End Function

        Return settings
    End Function
End Class
