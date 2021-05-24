using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBI.JD.Commands
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Indicators : IExternalCommand
    {
        private UIApplication application;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            application = commandData.Application;

            try
            {
                ShowForm();
            }
            catch (Exception ex)
            {
                message = ex.Message;

                return Result.Failed;
            }

            return Result.Succeeded;
        }

        private void ShowForm()
        {
            if (!Core.ValidTemplate(application.ActiveUIDocument.Document))
            {
                MessageBox.Show("The document was not created with the BBI template.", "Invalid template", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            using (var form = new Forms.IndicatorsForm(application))
            {
                form.ShowDialog();
            }
        }
    }
}
