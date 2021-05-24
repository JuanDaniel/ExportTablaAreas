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
    public class UpdateHome : IExternalCommand
    {
        private UIApplication application;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            application = commandData.Application;

            try
            {
                Document document = application.ActiveUIDocument.Document;

                if (Core.ValidTemplate(document)) // Activar actualización no pasiva. Para el caso de proyectos antiguos recuperar mediante una interfaz los parámetros
                {
                    if (Core.ContainsRoomsOrAreaSHO(document, true))
                    {
                        if (Core.UpdateHome(document))
                        {
                            MessageBox.Show("The home values were updated.", "Update Home", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("It was impossible to Update Home.", "Update Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There's nothing to update.", "Update Home", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The document was not created with the BBI template.", "Invalid template", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;

                return Result.Failed;
            }

            return Result.Succeeded;
        }
    }
}
