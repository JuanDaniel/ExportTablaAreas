using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using BBI.JD;
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
    public partial class TextToNumeric : System.Windows.Forms.Form
    {
        private UIApplication application;
        private UIDocument uiDoc;
        private Document document;
        private IList<Element> elements;
        private Dictionary<string, string> parametersRelation;

        public TextToNumeric(UIApplication application)
        {
            InitializeComponent();

            this.application = application;
            uiDoc = application.ActiveUIDocument;
            document = uiDoc.Document;
        }

        private void TextToNumeric_Load(object sender, EventArgs e)
        {
            FilteredElementCollector collector = new FilteredElementCollector(document);
            collector.WherePasses(new RoomFilter());

            elements = collector.ToElements();

            if (elements.Count > 0)
            {
                LoadRoomParameters();

                LoadDefaultRelation();

                cmb_SetType.SelectedIndex = 2;
            }
            else
            {
                btn_Ok.Enabled = false;

                MessageBox.Show("No Rooms was found in the file.", "No Rooms", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cmb_SetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilteredElementCollector collector = null;

            switch (cmb_SetType.SelectedIndex)
            {
                case 0:
                    collector = new FilteredElementCollector(document);
                    break;

                case 1:
                    collector = new FilteredElementCollector(document, document.ActiveView.Id);
                    break;

                case 2:
                    /*Selection selection = uiDoc.Selection;

                    IList<Element> rooms;

                    try
                    {
                        rooms = selection.PickElementsByRectangle(new RoomPickFilter());
                    }
                    catch (Exception)
                    {
                        rooms = new List<Element>();
                    }

                    List<ElementId> selectedIds = rooms.Select(x => x.Id).ToList();*/

                    var selectedIds = uiDoc.Selection.GetElementIds();

                    if (selectedIds.Count > 0)
                    {
                        collector = new FilteredElementCollector(document, selectedIds);
                    }
                    break;

                default:
                    collector = new FilteredElementCollector(document);
                    break;
            }

            if (collector != null)
            {
                collector.WherePasses(new RoomFilter());

                elements = collector.ToElements();
            }
            else
            {
                elements = new List<Element>();
            }

            label3.Text = elements.Count.ToString();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (cmb_TextParameter.SelectedIndex > -1 && cmb_NumericParameter.SelectedIndex > -1)
            {
                if (!parametersRelation.ContainsKey(cmb_TextParameter.Text) && !parametersRelation.ContainsValue(cmb_NumericParameter.Text))
                {
                    parametersRelation.Add(cmb_TextParameter.Text, cmb_NumericParameter.Text);

                    ListViewItem entry = new ListViewItem(string.Format("{0} -> {1}", cmb_TextParameter.Text, cmb_NumericParameter.Text));
                    entry.Checked = true;

                    lst_Relation.Items.Add(entry);

                    cmb_TextParameter.SelectedIndex = -1;
                    cmb_NumericParameter.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("The parameter relation has already been added.", "Parameter relation used", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("You must select both parameters.", "Select paramaters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (lst_Relation.CheckedItems.Count == 0)
            {
                MessageBox.Show("You must select the parameters you want to remove from the list above.", "Select paramaters", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            foreach (ListViewItem item in lst_Relation.CheckedItems)
            {
                int index = item.Index;
                KeyValuePair<string, string> keyValue = parametersRelation.ElementAt(index);

                lst_Relation.Items.RemoveAt(index);
                parametersRelation.Remove(keyValue.Key);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (elements.Count == 0)
            {
                MessageBox.Show("There are no Rooms in the collection.", "No Rooms", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            Dictionary<string, string> relation = new Dictionary<string, string>();

            foreach (ListViewItem item in lst_Relation.Items)
            {
                if (item.Checked)
                {
                    KeyValuePair<string, string> keyValue = parametersRelation.ElementAt(item.Index);

                    relation.Add(keyValue.Key, keyValue.Value);
                }
            }

            if (Core.UpdateNumericParameter(document, elements, relation, chk_Overwrite.Checked))
            {
                MessageBox.Show("The operation was successfully completed.", "Text parameter to numeric", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The operation was not completed.", "Text parameter to numeric", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (chk_UpdateControl.Checked)
            {
                if (Core.UpdateControlPrograma(document, elements))
                {
                    MessageBox.Show("The operation was successfully completed.", "Update Control Programa parameters", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The operation was not completed.", "Update Control Programa parameters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetTiTleForm()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            return string.Format("{0} ({1}.{2}.{3}.{4})", "Text parameter to Numeric", version.Major, version.Minor, version.Build, version.Revision);
        }

        private void LoadRoomParameters()
        {
            cmb_TextParameter.Items.Clear();
            cmb_NumericParameter.Items.Clear();

            Element room = elements.First();

            foreach (Parameter parameter in room.GetOrderedParameters())
            {
                if (parameter.StorageType == StorageType.String)
                {
                    cmb_TextParameter.Items.Add(parameter.Definition.Name);
                }
                else if (parameter.StorageType == StorageType.Double || parameter.StorageType == StorageType.Integer)
                {
                    if (!parameter.IsReadOnly)
                    {
                        cmb_NumericParameter.Items.Add(parameter.Definition.Name);
                    }
                }
            }
        }

        private void LoadDefaultRelation()
        {
            lst_Relation.Items.Clear();

            parametersRelation = Core.GetDefaultParametersRelation();

            foreach (var item in parametersRelation)
            {
                if (cmb_TextParameter.Items.Contains(item.Key) && cmb_NumericParameter.Items.Contains(item.Value))
                {
                    ListViewItem entry = new ListViewItem(string.Format("{0} -> {1}", item.Key, item.Value));
                    entry.Checked = true;

                    lst_Relation.Items.Add(entry);
                }
            }
        }
    }
}
