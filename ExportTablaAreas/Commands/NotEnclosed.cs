using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI.JD.Commands
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class NotEnclosed : IExternalCommand
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
            using (var form = new Forms.GridForm(application, ElementValue.NOT_ENCLOSED))
            {
                form.ShowDialog();
            }
        }
    }
}
