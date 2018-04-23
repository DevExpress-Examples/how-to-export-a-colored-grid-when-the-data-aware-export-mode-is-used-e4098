@Using (Html.BeginForm(New With {.Controller = "Home", .Action = "ExportTo"}))
    @Html.Partial("GridViewPartialProducts", Model.Products)
    @<br />
    @Html.DevExpress().Button( _
        Sub(settings)
            settings.Name = "btnExport"
            settings.Text = "Export To XLSX"
            settings.UseSubmitBehavior = True
        End Sub).GetHtml()
End Using