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
    public partial class GridForm : System.Windows.Forms.Form
    {
        private UIApplication application;
        private UIDocument uiDoc;
        private Document document;
        private ElementValue value;
        private ElementType type;
        private DataTable table;

        public GridForm(UIApplication application, ElementValue value)
        {
            InitializeComponent();

            this.application = application;
            this.value = value;
            uiDoc = application.ActiveUIDocument;
            document = uiDoc.Document;
        }

        private void GridForm_Load(object sender, EventArgs e)
        {
            cmb_Type.SelectedIndex = 0;
            cmb_Value.SelectedIndex = (int)value;

            btn_Select.Enabled = value != ElementValue.NOT_PLACED;
            btn_Highlight.Enabled = value != ElementValue.NOT_PLACED;
            btn_Delete.Enabled = value == ElementValue.NOT_PLACED;
        }

        private void cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = (ElementType)cmb_Type.SelectedIndex;

            LoadData();
            ActiveValueFilter();
        }

        private void cmb_Value_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveValueFilter();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DataRow row = GetCurrentRow();
            int id = int.Parse((string)row["Id"]);
            ElementId elementId = new ElementId(id);

            uiDoc.Selection.SetElementIds(new List<ElementId>() { elementId });

            Close();
        }

        private void btn_Highlight_Click(object sender, EventArgs e)
        {
            DataRow row = GetCurrentRow();
            int id = int.Parse((string)row["Id"]);
            ElementId elementId = new ElementId(id);

            uiDoc.Selection.SetElementIds(new List<ElementId>() { elementId });
            uiDoc.ShowElements(new List<ElementId>() { elementId });
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DataTable dt = table.DefaultView.ToTable();

            List<ElementId> elementIds = new List<ElementId>();

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse((string)row["Id"]);
                elementIds.Add(new ElementId(id));
            }

            if (elementIds.Count > 0)
            {
                if (Core.DeleteElements(document, elementIds))
                {
                    LoadData();
                    ActiveValueFilter();

                    MessageBox.Show("The elements were removed correctly.", "Delete elements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The elements were not removed.", "Delete elements", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chk_IncludeLinks_CheckedChanged(object sender, EventArgs e)
        {
            btn_Select.Enabled = value != ElementValue.NOT_PLACED && !chk_IncludeLinks.Checked;
            btn_Highlight.Enabled = value != ElementValue.NOT_PLACED && !chk_IncludeLinks.Checked;
            btn_Delete.Enabled = value == ElementValue.NOT_PLACED && !chk_IncludeLinks.Checked;

            LoadData();
            ActiveValueFilter();
        }

        private string GetTiTleForm()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            return string.Format("{0} ({1}.{2}.{3}.{4})", "Find elements", version.Major, version.Minor, version.Build, version.Revision);
        }

        private void LoadData()
        {
            table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Name");
            table.Columns.Add("Level");
            table.Columns.Add("Value");
            table.Columns.Add("File");

            List<List<object>> data = Core.GetFormatedData(document, type, chk_IncludeLinks.Checked);

            foreach (var row in data)
            {
                table.Rows.Add(row.ToArray());
            }

            dataGridView1.DataSource = table;
        }

        private void ActiveValueFilter()
        {
            table.DefaultView.RowFilter = $"Value = '{cmb_Value.Text}'";
        }

        private DataRow GetCurrentRow()
        {
            BindingManagerBase bm = dataGridView1.BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];

            return ((DataRowView)bm.Current).Row;
        }
    }
}
