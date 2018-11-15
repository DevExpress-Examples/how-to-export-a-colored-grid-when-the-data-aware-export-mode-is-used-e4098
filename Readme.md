<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Model.cs](./CS/Models/Model.cs) (VB: [Model.vb](./VB/Models/Model.vb))
* [GridViewPartialProducts.cshtml](./CS/Views/Home/GridViewPartialProducts.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# How to export a colored grid when the Data Aware export mode is used


<p><strong>UPDATED:</strong><br><br>Starting with version v2015 vol 2 (v15.2), this functionality is available out of the box. Use <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_FormatConditionstopic">GridViewSettings.FormatConditions</a> rules to define conditional formatting in Browse Mode and keep the applied appearance in the Exported Document. Please refer to the <a href="https://community.devexpress.com/blogs/aspnet/archive/2015/11/10/asp-net-grid-view-data-range-filter-adaptivity-and-more-coming-soon-in-v15-2.aspx">ASP.NET Grid View - Data Range Filter, Adaptivity and More (Coming soon in v15.2)</a> blog post and the <a href="http://demos.devexpress.com/MVCxGridViewDemos/Exporting/ExportWithFormatConditions">Export with Format Conditions</a> demo for more information.<br>If you have version v15.2+ available, consider using the built-in functionality instead of the approach detailed below.<br><br>If you need to apply custom appearance in the Exported Document only or define fine tuned complex appearance (for instance, based on some runtime calculated values, custom business rules, etc.), use the CsvExportOptionsEx / XlsExportOptionsEx / XlsxExportOptionsEx <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPrintingXlsxExportOptionsEx_CustomizeCelltopic">CustomizeCell</a> event in the <strong>Data Aware</strong> export mode.<br><br><strong>See Also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T334596">T334596: How to export colored GridView</a></p>

<br/>


