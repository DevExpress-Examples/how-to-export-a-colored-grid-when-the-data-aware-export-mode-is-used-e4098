using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.Web.Mvc;
using CS.Model;
using DevExpress.Web.ASPxGridView;

namespace CS.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(new MyViewModel { Products = MyModel.GetProducts() });
        }

        public ActionResult GridViewPartialProducts() {
            return PartialView(MyModel.GetProducts());
        }

        public ActionResult ExportTo() {
            return GridViewExtension.ExportToXlsx(GridViewHelper.ExportGridViewSettings, MyModel.GetProducts());
        }

    }

}
public static class GridViewHelper {
    private static GridViewSettings exportGridViewSettings;

    public static GridViewSettings ExportGridViewSettings {
        get {
            if (exportGridViewSettings == null)
                exportGridViewSettings = CreateExportGridViewSettings();
            return exportGridViewSettings;
        }
    }

    private static GridViewSettings CreateExportGridViewSettings() {
        GridViewSettings settings = new GridViewSettings();

        settings.Name = "gvProducts";
        settings.CallbackRouteValues = new { Controller = "Home", Action = "GridViewPartialProducts" };

        settings.KeyFieldName = "ProductID";
        settings.Settings.ShowFilterRow = true;

        settings.Columns.Add("ProductID");
        settings.Columns.Add("ProductName");
        settings.Columns.Add("UnitPrice");

        settings.SettingsExport.RenderBrick = (sender, e) => {
            if (e.RowType != GridViewRowType.Data)
                return;
            if ((e.Column as GridViewDataColumn).FieldName == "UnitPrice" && e.RowType != GridViewRowType.Header) {
                if (Convert.ToInt32(e.TextValue) > 15)
                    e.BrickStyle.BackColor = System.Drawing.Color.Yellow;
                else
                    e.BrickStyle.BackColor = System.Drawing.Color.Green;
            }
        };

        return settings;
    }
}
