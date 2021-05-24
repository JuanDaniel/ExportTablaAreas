using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace BBI.JD
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class Command : IExternalCommand
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

            using (var form = new Forms.ExportTablaAreas(application))
            {
                form.ShowDialog();
            }
        }
    }

    public class CrtlApplication : IExternalApplication
    {
        private UIControlledApplication application;
        private string tabName = "BBI";

        public Result OnStartup(UIControlledApplication application)
        {
            this.application = application;

            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string folder = new FileInfo(assemblyPath).Directory.FullName;

            // Create a customm ribbon tab
            Autodesk.Windows.RibbonTab tab = CreateRibbonTab(application, tabName);

            // Add new ribbon panel
            string panelName = "Tabla Áreas";
            RibbonPanel ribbonPanel = CreateRibbonPanel(application, tab, panelName);

            // Create TextToNumeric button in the ribbon panel
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData(
                "TextToNumeric",
                "Text to Numeric",
                assemblyPath, "BBI.JD.Commands.TextToNumeric")) as PushButton;

            // Set the large image shown on button
            Uri uriImage = new Uri(string.Concat(folder, "/numeric_32x32.png"));
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            // Create Indicators button in the ribbon panel
            pushButton = ribbonPanel.AddItem(new PushButtonData(
                "Indicators",
                "Indicators",
                assemblyPath, "BBI.JD.Commands.Indicators")) as PushButton;

            // Set the large image shown on button
            uriImage = new Uri(string.Concat(folder, "/indicator_32x32.png"));
            largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            // Create UpdateHome button in the ribbon panel
            pushButton = ribbonPanel.AddItem(new PushButtonData(
                "UpdateHome",
                "Update Home",
                assemblyPath, "BBI.JD.Commands.UpdateHome")) as PushButton;

            // Set the large image shown on button
            uriImage = new Uri(string.Concat(folder, "/script_32x32.png"));
            largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            // Create Export button in the ribbon panel
            pushButton = ribbonPanel.AddItem(new PushButtonData(
                "ExportTablaAreas",
                "Export",
                assemblyPath, "BBI.JD.Command")) as PushButton;

            // Set the large image shown on button
            uriImage = new Uri(string.Concat(folder, "/icon_32x32.png"));
            largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            // Create shortcut buttons to filter Rooms
            ribbonPanel.AddStackedItems(
                new PushButtonData(
                    "NotPlacedCommand",
                    "Not Placed",
                    assemblyPath, "BBI.JD.Commands.NotPlaced"),
                new PushButtonData(
                    "NotEnclosedCommand",
                    "Not Enclosed",
                    assemblyPath, "BBI.JD.Commands.NotEnclosed"),
                new PushButtonData(
                    "RedundantCommand",
                    "Redundant",
                    assemblyPath, "BBI.JD.Commands.Redundant")
            );

            // Register events
            application.ControlledApplication.DocumentOpened += UpdateNumericParameter;
            application.ControlledApplication.DocumentOpened += UpdateHome;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // Unregister events
            application.ControlledApplication.DocumentOpened -= UpdateNumericParameter;
            application.ControlledApplication.DocumentOpened -= UpdateHome;

            return Result.Succeeded;
        }

        private void UpdateHome(object sender, DocumentOpenedEventArgs args)
        {
           if (Config.Get("updateHome") == "True")
           {
                Document document = args.Document;

                if (Core.ValidTemplate(document) && Core.ContainsRoomsOrAreaSHO(document, true))
                {
                    if (Core.UpdateHome(document))
                    {
                        if (document.IsWorkshared && !document.IsDetached)
                        {
                            TransactWithCentralOptions transOpts = new TransactWithCentralOptions();
                            //transOpts.SetLockCallback(new SynchLockCallback());

                            SynchronizeWithCentralOptions syncOpts = new SynchronizeWithCentralOptions();
                            syncOpts.SetRelinquishOptions(new RelinquishOptions(true));
                            syncOpts.Comment = "Changed Home";

                            try
                            {
                                document.SynchronizeWithCentral(transOpts, syncOpts);
                            }
                            catch (Exception ex)
                            {
                                TaskDialog td = new TaskDialog("Synchronize Home changes failed");

                                td.Title = "Synchronize Home changes failed";
                                td.MainContent = ex.Message;
                                td.FooterText = "BBI Tabla Áreas";
                                td.TitleAutoPrefix = false;
                                td.AllowCancellation = false;
                                td.CommonButtons = TaskDialogCommonButtons.Ok;

                                td.Show();
                            }
                        }
                        else
                        {
                            document.Save();
                        }
                    }
                    else
                    {
                        TaskDialog td = new TaskDialog("Update Home failed");

                        td.Title = "Update Home failed";
                        td.MainContent = "It was impossible to Update Home. The Project Information is blocked by another user.";
                        td.FooterText = "BBI Tabla Áreas";
                        td.TitleAutoPrefix = false;
                        td.AllowCancellation = false;
                        td.CommonButtons = TaskDialogCommonButtons.Ok;

                        td.Show();
                    }
                }
           }
        }

        private void UpdateNumericParameter(object sender, DocumentOpenedEventArgs args)
        {
            if (Config.Get("updateNumericParameters") == "True")
            {
                Document document = args.Document;

                if (Core.ValidTemplate(document) && Core.ContainsRoomsOrAreaSHO(document))
                {
                    if (Core.UpdateNumericParameter(document, ElementType.ROOM, Core.GetDefaultParametersRelation(), true))
                    {
                        if (document.IsWorkshared && !document.IsDetached)
                        {
                            TransactWithCentralOptions transOpts = new TransactWithCentralOptions();
                            //transOpts.SetLockCallback(new SynchLockCallback());

                            SynchronizeWithCentralOptions syncOpts = new SynchronizeWithCentralOptions();
                            syncOpts.SetRelinquishOptions(new RelinquishOptions(true));
                            syncOpts.Comment = "Updated Numeric Parameter";

                            try
                            {
                                document.SynchronizeWithCentral(transOpts, syncOpts);
                            }
                            catch (Exception ex)
                            {
                                TaskDialog td = new TaskDialog("Synchronize Numeric Parameter changes failed");

                                td.Title = "Synchronize Numeric Parameter changes failed";
                                td.MainContent = ex.Message;
                                td.FooterText = "BBI Tabla Áreas";
                                td.TitleAutoPrefix = false;
                                td.AllowCancellation = false;
                                td.CommonButtons = TaskDialogCommonButtons.Ok;

                                td.Show();
                            }
                        }
                        else
                        {
                            document.Save();
                        }
                    }
                    else
                    {
                        TaskDialog td = new TaskDialog("Update Numeric Parameter");

                        td.Title = "Update Numeric Parameter";
                        td.MainContent = "It was impossible to Update Numeric Parameter.";
                        td.FooterText = "BBI Tabla Áreas";
                        td.TitleAutoPrefix = false;
                        td.AllowCancellation = false;
                        td.CommonButtons = TaskDialogCommonButtons.Ok;

                        td.Show();
                    }
                }
            }
        }

        private Autodesk.Windows.RibbonTab CreateRibbonTab(UIControlledApplication application, string tabName)
        {
            Autodesk.Windows.RibbonTab tab = Autodesk.Windows.ComponentManager.Ribbon.Tabs.FirstOrDefault(x => x.Id == tabName);

            if (tab == null)
            {
                application.CreateRibbonTab(tabName);

                tab = Autodesk.Windows.ComponentManager.Ribbon.Tabs.FirstOrDefault(x => x.Id == tabName);
            }

            return tab;
        }

        private RibbonPanel CreateRibbonPanel(UIControlledApplication application, Autodesk.Windows.RibbonTab tab, string panelName)
        {
            RibbonPanel panel = application.GetRibbonPanels(tab.Name).FirstOrDefault(x => x.Name == panelName);

            if (panel == null)
            {
                panel = application.CreateRibbonPanel(tab.Name, panelName);
            }

            return panel;
        }
    }
}