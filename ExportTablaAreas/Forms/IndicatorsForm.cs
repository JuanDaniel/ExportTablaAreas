using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBI.JD.Forms
{
    public partial class IndicatorsForm : System.Windows.Forms.Form
    {
        private UIApplication application;
        private UIDocument uiDoc;
        private Document document;

        public IndicatorsForm(UIApplication application)
        {
            InitializeComponent();

            this.application = application;
            uiDoc = application.ActiveUIDocument;
            document = uiDoc.Document;
        }

        private void IndicatorsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private string GetTiTleForm()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            return string.Format("{0} ({1}.{2}.{3}.{4})", "Indicators", version.Major, version.Minor, version.Build, version.Revision);
        }

        private void LoadData() {
            int nivelesTipicos = 1;
            double porcientoBD = 1;

            if (ExistNTPBDEmpty())
            {
                MessageBox.Show("There are empty NivelesTipicos and PorcientoBD.\nFor this reason it was assigned:\n   NivelesTipicos = 1\n   PorcientoBD = 1", "Empty NivelesTipicos and PorcientoBD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            List<SpatialElement> rooms = Core.GetData(document, ElementType.ROOM, false, new ElementValue[] { ElementValue.PLACED }).OfType<SpatialElement>().ToList();

            // Filter only S.H.O. Area
            List<SpatialElement> areas = Core.GetData(document, ElementType.AREA, false, new ElementValue[] { ElementValue.PLACED }).OfType<SpatialElement>().Where(x => Core.GetAreaSchemaNameFromArea(document, (Area)x).Equals(Core.AREA_NAME)).ToList();

            var grouped = from element in rooms
                          group element by GetLevelName(element.Level) into grp
                          select new
                          {
                              Level = grp.Key,
                              AreaRoom = grp.Sum(x => x.Area),
                              SupUtil = grp.Sum(x => x.Area * NivelesTipicos(x, nivelesTipicos)),
                              SupUtilComputada = grp.Sum(x => x.Area * NivelesTipicos(x, nivelesTipicos) * PorcientoBD(x, porcientoBD))
                          };

            var grouped1 = from element in areas
                           group element by GetLevelName(element.Level) into grp
                           select new
                           {
                               Level = grp.Key,
                               AreaSHO = grp.Sum(x => x.Area),
                               SupConstruidaSHO = grp.Sum(x => x.Area * NivelesTipicos(x, nivelesTipicos))
                           };

            dataGridView1.Rows.Clear();

            foreach (var grp in grouped)
            {
                List<object> row = new List<object>();

                double areaSHO = 0;
                double supConstruidaSHO = 0;

                row.Add(grp.Level); // Level
                row.Add(UnitUtils.ConvertFromInternalUnits(grp.AreaRoom, DisplayUnitType.DUT_SQUARE_METERS)); // AreaRoom

                var grp1 = grouped1.FirstOrDefault(x => x.Level == grp.Level);

                if (grp1 != null)
                {
                    areaSHO = grp1.AreaSHO;
                    supConstruidaSHO = grp1.SupConstruidaSHO;
                }

                row.Add(UnitUtils.ConvertFromInternalUnits(areaSHO, DisplayUnitType.DUT_SQUARE_METERS)); // AreaSHO
                row.Add(UnitUtils.ConvertFromInternalUnits(grp.SupUtil, DisplayUnitType.DUT_SQUARE_METERS)); // Sup. Útil = AreaRoom * NivelesTipicosRoom
                row.Add(UnitUtils.ConvertFromInternalUnits(grp.SupUtilComputada, DisplayUnitType.DUT_SQUARE_METERS)); // Sup. Útil Computada = AreaRoom * NivelesTipicosRoom * PorcientoBD
                row.Add(UnitUtils.ConvertFromInternalUnits(supConstruidaSHO, DisplayUnitType.DUT_SQUARE_METERS)); // Sup. Construida (S.H.O) = AreaSHO * NivelesTipicosSHO

                if (grp.AreaRoom > 0)
                {
                    row.Add(areaSHO / grp.AreaRoom); // Coeficiente SC/SU = AreaSHO / AreaRoom
                }
                else
                {
                    row.Add(0); // Coeficiente SC/SU
                }

                dataGridView1.Rows.Add(row.ToArray());
            }
        }

        private bool ExistNTPBDEmpty()
        {
            Dictionary<string, int> result = Core.GetCountValueEmpty(document, ElementType.ROOM, Core.PARAMETER_NIVELES_TIPICOS, false);

            if (result.Sum(x => x.Value) != 0)
            {
                return true;
            }

            result = Core.GetCountValueEmpty(document, ElementType.AREA, Core.PARAMETER_NIVELES_TIPICOS, false);

            if (result.Sum(x => x.Value) != 0)
            {
                return true;
            }

            result = Core.GetCountValueEmpty(document, ElementType.ROOM, Core.PARAMETER_PORCIENTO_BD, false);

            if (result.Sum(x => x.Value) != 0)
            {
                return true;
            }

            return false;
        }

        private string GetLevelName(Level level)
        {
            if (level != null)
            {
                return level.Name;
            }

            return string.Empty;
        }

        private int NivelesTipicos(Element element, int defaultValue = 0) {
            int value = defaultValue;

            Parameter parameter = element.LookupParameter(Core.PARAMETER_NIVELES_TIPICOS);

            if (parameter != null)
            {
                if (parameter.HasValue)
                {
                    value = int.Parse(parameter.AsValueString());
                }
            }

            return value;
        }

        private double PorcientoBD(Element element, double defaultValue = 0)
        {
            double value = defaultValue;

            Parameter parameter = element.LookupParameter(Core.PARAMETER_PORCIENTO_BD);

            if (parameter != null)
            {
                if (parameter.HasValue)
                {
                    Core.ParseDoubleValue(document, parameter.AsValueString(), out value);
                }
            }

            return value;
        }
    }
}
