using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.StringTemplate;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using SpreadsheetLight;
using System.Globalization;
using System.Threading;
using System.Security.Policy;
using System.Security;

namespace BBI.JD.Forms
{
    public partial class ExportTablaAreas : System.Windows.Forms.Form
    {
        private UIApplication application;
        private UIDocument uiDoc;
        private Document document;
        private List<ViewSchedule> viewSchedules;

        public ExportTablaAreas(UIApplication application)
        {
            InitializeComponent();

            this.application = application;
            uiDoc = application.ActiveUIDocument;
            document = uiDoc.Document;
        }

        private void ExportTablaAreas_Load(object sender, EventArgs e)
        {
            bool found;

            (viewSchedules, found) = LoadSchedules(cmb_Schedules, BuiltInCategory.OST_Rooms, Core.SCHEDULE_AREAS_DETALLE);

            cmb_Schedules_SelectedIndexChanged(cmb_Schedules, EventArgs.Empty);

            if (!found)
            {
                tabControl1.SelectTab(1);
            }

            LoadSchedules(cmb_ScheduleAreaUtil, BuiltInCategory.OST_Rooms, Core.SCHEDULE_AREA_UTIL);
            LoadSchedules(cmb_ScheduleAreaConst, BuiltInCategory.OST_Areas, Core.SCHEDULE_AREA_CONST);
            LoadSchedules(cmb_ScheduleCapHab, BuiltInCategory.OST_Rooms, Core.SCHEDULE_CAP_HAB);

            LoadProjectParameters(cmb_ParameterSupUtil, BuiltInParameterGroup.PG_CONSTRUCTION, Core.PARAMETER_SUP_UTIL);
            LoadProjectParameters(cmb_ParameterSHO, BuiltInParameterGroup.PG_CONSTRUCTION, Core.PARAMETER_SHO);
            LoadProjectParameters(cmb_ParameterCapHab, BuiltInParameterGroup.PG_IDENTITY_DATA, Core.PARAMETER_CAP_HAB);

            chk_UpdateHome.Checked = Config.Get("updateHome") == "True";
            chk_UpdateNumericParameters.Checked = Config.Get("updateNumericParameters") == "True";
            txt_Email.Text = Config.Get("emailDefaultAddress");
            txt_ExcelTemplate.Text = Config.Get("excelTemplate");
        }

        private void ExportTablaAreas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Set("updateHome", chk_UpdateHome.Checked ? "True" : "False");
            Config.Set("updateNumericParameters", chk_UpdateNumericParameters.Checked ? "True" : "False");
            Config.Set("emailDefaultAddress", txt_Email.Text);
            Config.Set("excelTemplate", txt_ExcelTemplate.Text);
        }

        private void cmb_Schedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadScheduleStructure(cmb_ParameterNivelesTipicos, Core.PARAMETER_NIVELES_TIPICOS);
            LoadScheduleStructure(cmb_ParameterPorcientoBD, Core.PARAMETER_PORCIENTO_BD);
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            if (!ValidConfig())
            {
                tabControl1.SelectTab(1);

                MessageBox.Show("The configuration is invalid.\nPlease check the errors.", "Invalid configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            bool result;
            bool[] rules;
            Dictionary<Rule, RuleReponse> report;

            (result, rules, report) = ExecuteRules(chk_ExecuteRulesLink.Checked);

            if (result)
            {
                MessageBox.Show("Congratulations !!!\nThe project passed all the rules to which it was submitted.", "Check result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Dictionary<string, object> paramsTemplate = PrepareParamsTemplate(result);

                string pathReport = WriteReport(rules, report, paramsTemplate);

                using (var form = new Forms.CheckResult(txt_Email.Text, pathReport, paramsTemplate))
                {
                    form.ShowDialog();
                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (!ValidConfig(true))
            {
                tabControl1.SelectTab(1);

                MessageBox.Show("The configuration is invalid.\nPlease check the errors.", "Invalid configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (chk_UpdNumericParameters.Checked)
            {
                Core.UpdateNumericParameter(document, ElementType.ROOM, Core.GetDefaultParametersRelation(), true);
            }
            
            if (chk_UpdHome.Checked)
            {
                Core.UpdateHome(document);
            }

            bool result;
            bool[] rules;
            Dictionary<Rule, RuleReponse> report;

            ViewSchedule schedule = viewSchedules[cmb_Schedules.SelectedIndex];

            DialogResult dialog;

            if (chk_CheckBeforeExport.Checked)
            {
                (result, rules, report) = ExecuteRules(schedule.Definition.IncludeLinkedFiles);

                if (!result)
                {
                    dialog = MessageBox.Show("The project did not pass the rules to which it was submitted.\nDo you want to continue?", "Check result", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (dialog == DialogResult.No)
                    {
                        Dictionary<string, object> paramsTemplate = PrepareParamsTemplate(result);

                        string pathReport = WriteReport(rules, report, paramsTemplate);

                        using (var form = new Forms.CheckResult(txt_Email.Text, pathReport, paramsTemplate))
                        {
                            form.ShowDialog();
                        }

                        return;
                    }
                }
            }

            if (schedule.Definition.GetFilterCount() > 0)
            {
                dialog = MessageBox.Show(
                    string.Format("The schedule « {0} » has active filters.\nAre you sure to continue?", schedule.Name), 
                    "Active filters", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning, 
                    MessageBoxDefaultButton.Button2
                );

                if (dialog == DialogResult.No)
                {
                    return;
                }
            }

            if (!schedule.Definition.IncludeLinkedFiles)
            {
                dialog = MessageBox.Show(
                    string.Format("The schedule « {0} » does not include the linked files.\nAre you sure to continue?", schedule.Name), 
                    "Not linked files", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning, 
                    MessageBoxDefaultButton.Button2
                );

                if (dialog == DialogResult.No)
                {
                    return;
                }
            }

            string fileName = string.Format(
                "{0}.D01.AREAS_{1}",
                Core.GetProjectParameter(document, BuiltInParameter.PROJECT_NUMBER).AsString(),
                DateTime.Now.ToString("yMMddHHmm")
            );

            saveFileDialog1.Title = "Export Tabla Áreas";
            saveFileDialog1.FileName = fileName;
            saveFileDialog1.Filter = "Spreadsheets|*.xls;*.xlsx";
            saveFileDialog1.DefaultExt = "xlsx";

            dialog = saveFileDialog1.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                try
                {
                    ExportExcel(saveFileDialog1.FileName);

                    MessageBox.Show("Tabla Áreas was exported successfully.", "Export Tabla Áreas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    File.Delete(saveFileDialog1.FileName);

                    MessageBox.Show(ex.Message, "Failed export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ExcelTemplate_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                txt_ExcelTemplate.Text = openFileDialog1.FileName;
            }
        }

        private string GetTiTleForm()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            return string.Format("{0} ({1}.{2}.{3}.{4})", "Export Tabla Áreas", version.Major, version.Minor, version.Build, version.Revision);
        }

        private (List<ViewSchedule>, bool) LoadSchedules(System.Windows.Forms.ComboBox combo, BuiltInCategory category, string select = null)
        {
            ElementId categoryId = new ElementId(category);

            List<ViewSchedule> viewSchedules = new FilteredElementCollector(document)
                        .OfClass(typeof(ViewSchedule))
                            .Cast<ViewSchedule>()
                                .Where(x => x.Definition.CategoryId == categoryId) // Get only Schedule by category given
                                    .OrderBy(x => x.Name)
                                        .ToList();
            bool found = false;

            combo.Items.Clear();

            foreach (var schedule in viewSchedules)
            {
                combo.Items.Add(schedule.Name);

                if (!found)
                {
                    if (found = schedule.Name.Contains(select))
                    {
                        combo.SelectedItem = schedule.Name;
                    }
                }
            }

            return (viewSchedules, found);
        }

        private void LoadProjectParameters(System.Windows.Forms.ComboBox combo, BuiltInParameterGroup group, string select = null) {
            BindingMap map = document.ParameterBindings;
            DefinitionBindingMapIterator it = map.ForwardIterator();

            it.Reset();
            combo.Items.Clear();

            while (it.MoveNext())
            {
                if (it.Key.ParameterGroup == group)
                {
                    combo.Items.Add(it.Key.Name);
                }
            }

            if (select != null)
            {
                combo.SelectedItem = select;
            }
        }

        private void LoadScheduleStructure(System.Windows.Forms.ComboBox combo, string select = null) {
            if (viewSchedules == null)
            {
                return;
            }

            ViewSchedule schedule = viewSchedules[cmb_Schedules.SelectedIndex];

            combo.Items.Clear();

            for (int i = 0; i < schedule.Definition.GetFieldCount(); i++)
            {
                combo.Items.Add(schedule.Definition.GetField(i).GetName());
            }

            if (select != null)
            {
                combo.SelectedItem = select;
            }
        }

        private bool ValidConfig(bool fullConfig = false)
        {
            ResetErrorsForm();

            bool valid = true;

            // Schedule to export
            if (cmb_Schedules.SelectedIndex == -1)
            {
                label2.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }

            // Schedules for home
            if (cmb_ScheduleAreaUtil.SelectedIndex == -1)
            {
                label9.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }
            if (cmb_ScheduleAreaConst.SelectedIndex == -1)
            {
                label8.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }
            if (cmb_ScheduleCapHab.SelectedIndex == -1)
            {
                label10.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }

            // Project's parameters
            if (cmb_ParameterSupUtil.SelectedIndex == -1)
            {
                label12.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }
            if (cmb_ParameterSHO.SelectedIndex == -1)
            {
                label11.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }
            if (cmb_ParameterCapHab.SelectedIndex == -1)
            {
                label13.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }

            // Room's parameters
            if (cmb_ParameterNivelesTipicos.SelectedIndex == -1)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }
            if (cmb_ParameterPorcientoBD.SelectedIndex == -1)
            {
                label7.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }

            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");

            if (!string.IsNullOrEmpty(txt_Email.Text) && !regex.IsMatch(txt_Email.Text))
            {
                label4.ForeColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (fullConfig)
            {
                if (!File.Exists(txt_ExcelTemplate.Text))
                {
                    label3.ForeColor = System.Drawing.Color.Red;
                    valid = false;
                }
            }

            return valid;
        }

        private void ResetErrorsForm()
        {
            label2.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label9.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label8.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label10.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label12.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label11.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label13.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label6.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label7.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label4.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
            label3.ForeColor = System.Drawing.Color.FromArgb(32, 31, 53);
        }

        private (bool, bool[] , Dictionary<Rule, RuleReponse>) ExecuteRules(bool fromLoadLinks)
        {
            /*
                Rules to check
                    1. Check Not Placed (Room & Area)
                    2. Check Not Enclosed (Room & Area)
                    3. Check Redundant (Room & Area)
                    4. Check empty NivelesTipicos (Room & Area)
                    5. Check empty PorcientoBD
                    6. Decimal format PorcientoBD
                    7. Updated Home (Sup. Útil & S.H.O & Capacidad Habitacional)
                    8. Check range Coeficiente SC/SU value (between 1 - 1.2)
                    9. Decimal format point
             */

            int total;
            bool valid;
            string[] subMessages;
            bool result = true;
            bool[] rules = new bool[9];
            Dictionary<Rule, RuleReponse> report = new Dictionary<Rule, RuleReponse>();

            // 1. Check Not Placed
            if (rules[0] = chk_Rule_1.Checked)
            {
                // (Room)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.NOT_PLACED_ROOM,
                    GetGroupedCount(
                        Core.GetFormatedData(document, ElementType.ROOM, fromLoadLinks, true, new ElementValue[] { ElementValue.NOT_PLACED }),
                        4
                    )
                );

                report.Add(Rule.NOT_PLACED_ROOM, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;

                // (Area)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.NOT_PLACED_AREA,
                    GetGroupedCount(
                        Core.GetFormatedData(document, ElementType.AREA, fromLoadLinks, true, new ElementValue[] { ElementValue.NOT_PLACED }),
                        4
                    )
                );

                report.Add(Rule.NOT_PLACED_AREA, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;
            }

            // 2. Check Not Enclosed
            if (rules[1] = chk_Rule_2.Checked)
            {
                // (Room)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.NOT_ENCLOSED_ROOM,
                    GetGroupedCount(
                        Core.GetFormatedData(document, ElementType.ROOM, fromLoadLinks, true, new ElementValue[] { ElementValue.NOT_ENCLOSED }),
                        4
                    )
                );

                report.Add(Rule.NOT_ENCLOSED_ROOM, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;

                // (Area)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.NOT_ENCLOSED_AREA,
                    GetGroupedCount(
                        Core.GetFormatedData(document, ElementType.AREA, fromLoadLinks, true, new ElementValue[] { ElementValue.NOT_ENCLOSED }),
                        4
                    )
                );

                report.Add(Rule.NOT_ENCLOSED_AREA, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;
            }

            // 3. Check Redundant
            if (rules[2] = chk_Rule_3.Checked)
            {
                // (Room)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.REDUNDANT_ROOM,
                    GetGroupedCount(
                        Core.GetFormatedData(document, ElementType.ROOM, fromLoadLinks, true, new ElementValue[] { ElementValue.REDUNDANT }),
                        4
                    )
                );

                report.Add(Rule.REDUNDANT_ROOM, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;

                // (Area)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.REDUNDANT_AREA,
                    GetGroupedCount(
                        Core.GetFormatedData(document, ElementType.AREA, fromLoadLinks, true, new ElementValue[] { ElementValue.REDUNDANT }),
                        4
                    )
                );

                report.Add(Rule.REDUNDANT_AREA, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;
            }

            // 4. Check empty NivelesTipicos
            if (rules[3] = chk_Rule_4.Checked)
            {
                // (Room)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.EMPTY_NIVELES_TIPICO_ROOM,
                    Core.GetCountValueEmpty(document, ElementType.ROOM, cmb_ParameterNivelesTipicos.Text, fromLoadLinks)
                );

                report.Add(Rule.EMPTY_NIVELES_TIPICO_ROOM, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;

                // (Area)
                (total, subMessages) = ProcessRuleResponse(
                    Rule.EMPTY_NIVELES_TIPICO_AREA,
                    Core.GetCountValueEmpty(document, ElementType.AREA, cmb_ParameterNivelesTipicos.Text, fromLoadLinks)
                );

                report.Add(Rule.EMPTY_NIVELES_TIPICO_AREA, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;
            }

            // 5. Check empty PorcientoBD
            if (rules[4] = chk_Rule_5.Checked)
            {
                (total, subMessages) = ProcessRuleResponse(
                    Rule.EMPTY_PORCIENTO_BD,
                    Core.GetCountValueEmpty(document, ElementType.ROOM, cmb_ParameterPorcientoBD.Text, fromLoadLinks)
                );

                report.Add(Rule.EMPTY_PORCIENTO_BD, new RuleReponse(total == 0, total.ToString(), subMessages));
                result &= total == 0;
            }

            // 6. Decimal format PorcientoBD
            if (rules[5] = chk_Rule_6.Checked)
            {
                valid = Core.ValidFormatPorcientoBD(document, cmb_ParameterPorcientoBD.Text, fromLoadLinks);
                report.Add(Rule.DECIMAL_FORMAT_POCIENTO_BD, new RuleReponse(valid, valid.ToString()));
                result &= valid;
            }

            // 7. Updated Home
            if (rules[6] = chk_Rule_7.Checked)
            {
                // (Sup. Útil)
                (valid, subMessages) = ProcessRuleResponse(
                    Core.EqualScheduleParameterValue(document, cmb_ScheduleAreaUtil.Text, BuiltInCategory.OST_Rooms, cmb_ParameterSupUtil.Text, fromLoadLinks)
                );

                report.Add(Rule.UPDATED_HOME_SUP_UTIL, new RuleReponse(valid, valid.ToString(), subMessages));
                result &= valid;

                // (S.H.O)
                (valid, subMessages) = ProcessRuleResponse(
                    Core.EqualScheduleParameterValue(document, cmb_ScheduleAreaConst.Text, BuiltInCategory.OST_Areas, cmb_ParameterSHO.Text, fromLoadLinks)
                );

                report.Add(Rule.UPDATED_HOME_SHO, new RuleReponse(valid, valid.ToString(), subMessages));
                result &= valid;

                // (Capacidad Habitacional)
                (valid, subMessages) = ProcessRuleResponse(
                    Core.EqualScheduleParameterValue(document, cmb_ScheduleCapHab.Text, BuiltInCategory.OST_Rooms, cmb_ParameterCapHab.Text, fromLoadLinks, false)
                );

                report.Add(Rule.UPDATED_HOME_CAP_HAB, new RuleReponse(valid, valid.ToString(), subMessages));
                result &= valid;
            }

            // 8. Check range Coeficiente SC/SU value (between 1 - 1.2)
            if (rules[7] = chk_Rule_8.Checked)
            {
                (valid, subMessages) = ProcessRuleResponse(
                    Core.ValidRangeCoeficiente(document, cmb_ParameterSHO.Text, cmb_ParameterSupUtil.Text, fromLoadLinks)
                );

                report.Add(Rule.RANGE_COEFICIENTE_SCSU, new RuleReponse(valid, valid.ToString(), subMessages));
                result &= valid;
            }

            // 9. Decimal format point
            if (rules[8] = chk_Rule_9.Checked)
            {
                valid = Core.ValidDecimalFormat(document, viewSchedules[cmb_Schedules.SelectedIndex]);
                report.Add(Rule.DECIMAL_FORMAT_POINT, new RuleReponse(valid, valid.ToString()));
                result &= valid;
            }

            return (result, rules, report);
        }

        private Dictionary<int, ScheduleExport> ExecuteTasks(Dictionary<int, ScheduleExport> values) {
            /*
                Tasks to export
                    1. Exclude Not Placed
                    2. Exclude Not Enclosed
                    3. Exclude Redundant
                    4. Set by default NivelesTipicos = 1
                    5. Set by default PorcientoBD = 1
                    6. Change decimal format PorcientoBD
                    7. Format decimal point
            */

            Dictionary<ElementValue, string[]> translates = new Dictionary<ElementValue, string[]>();
            translates.Add(ElementValue.NOT_PLACED, new string[] { "Not Placed", "Non placée", "Sin colocar" });
            translates.Add(ElementValue.NOT_ENCLOSED, new string[] { "Not Enclosed", "Non fermée", "No cerrado" });
            translates.Add(ElementValue.REDUNDANT, new string[] { "Redundant Room", "Pièce superflue", "Habitación redundante" });

            string[] decimalFields = new string[] { "COD 1", "Área del local [m²]", "PorcientoBD", "Coef. SC/SU" };
            string validDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string invalidDecimalSeparator = validDecimalSeparator == "." ? "," : ".";

            foreach (var item in values)
            {
                // 1. Exclude Not Placed
                if (chk_Task_1.Checked)
                {
                    if (item.Value.Field == "Área del local [m²]")
                    {
                        if (translates[ElementValue.NOT_PLACED].Contains(item.Value.Value))
                        {
                            return null;
                        }
                    }
                }

                // 2. Exclude Not Enclosed
                if (chk_Task_2.Checked)
                {
                    if (item.Value.Field == "Área del local [m²]")
                    {
                        if (translates[ElementValue.NOT_ENCLOSED].Contains(item.Value.Value))
                        {
                            return null;
                        }
                    }
                }

                // 3. Exclude Redundant
                if (chk_Task_3.Checked)
                {
                    if (item.Value.Field == "Área del local [m²]")
                    {
                        if (translates[ElementValue.REDUNDANT].Contains(item.Value.Value))
                        {
                            return null;
                        }
                    }
                }

                // 4. Set by default NivelesTipicos = 1
                if (chk_Task_4.Checked)
                {
                    if (item.Value.Field == "Niveles Tipicos")
                    {
                        if (string.IsNullOrEmpty(item.Value.Value))
                        {
                            item.Value.Value = "1";
                        }
                        else if (item.Value.Value == "0")
                        {
                            item.Value.Value = "1";
                        }
                    }
                }

                // 5. Set by default PorcientoBD = 1
                if (chk_Task_5.Checked)
                {
                    if (item.Value.Field == "PorcientoBD")
                    {
                        if (string.IsNullOrEmpty(item.Value.Value))
                        {
                            item.Value.Value = "1";
                        }
                        else if (item.Value.Value == "0")
                        {
                            item.Value.Value = "1";
                        }
                    }
                }

                // 6. Change decimal format PorcientoBD
                if (chk_Task_6.Checked)
                {
                    if (item.Value.Field == "PorcientoBD")
                    {
                        if (string.IsNullOrEmpty(item.Value.Value))
                        {
                            item.Value.Value = "1";
                        }
                        else
                        {
                            float value = 0;

                            if (float.TryParse(item.Value.Value, out value))
                            {
                                if (value > 1)
                                {
                                    item.Value.Value = (value / 100).ToString();
                                }
                                else
                                {
                                    item.Value.Value = value.ToString();
                                }
                            }
                        }
                    }
                }

                // 7. Format decimal point
                if (chk_Task_7.Checked)
                {
                    if (decimalFields.Contains(item.Value.Field))
                    {
                        item.Value.Value = item.Value.Value.Replace(invalidDecimalSeparator, validDecimalSeparator);
                    }
                }
            }

            return values;
        }

        private (int, string[]) ProcessRuleResponse(Rule rule, Dictionary<string, int> relation)
        {
            int total = 0;
            string message = string.Empty;
            List<string> subMessages = new List<string>();

            foreach (var item in relation)
            {
                total += item.Value;
                
                if (rule == Rule.EMPTY_NIVELES_TIPICO_ROOM)
                {
                    message = string.Format("There are {0} empty NivelesTipicos for Room in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.EMPTY_NIVELES_TIPICO_AREA)
                {
                    message = string.Format("There are {0} empty NivelesTipicos for Area in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.EMPTY_PORCIENTO_BD)
                {
                    message = string.Format("There are {0} empty PorcientoBD in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.NOT_PLACED_ROOM)
                {
                    message = string.Format("There are {0} Not Placed Room in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.NOT_PLACED_AREA)
                {
                    message = string.Format("There are {0} Not Placed Area in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.NOT_ENCLOSED_ROOM)
                {
                    message = string.Format("There are {0} Not Enclosed Room in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.NOT_ENCLOSED_AREA)
                {
                    message = string.Format("There are {0} Not Enclosed Area in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.REDUNDANT_ROOM)
                {
                    message = string.Format("There are {0} Redundant Room in « {1} »", item.Value, item.Key);
                }
                else if (rule == Rule.REDUNDANT_AREA)
                {
                    message = string.Format("There are {0} Redundant Area in « {1} »", item.Value, item.Key);
                }

                subMessages.Add(message);
            }

            return (total, subMessages.ToArray());
        }

        private (bool, string[]) ProcessRuleResponse(Dictionary<string, string> relation)
        {
            return (relation.Count == 0, relation.Values.ToArray());
        }

        private Dictionary<string, int> GetGroupedCount(List<List<object>> data, int keyToGroup = 0)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var grouped = from element in data
                          group element by element[keyToGroup] into grp
                          select new { File = grp.Key, Count = grp.Count() };


            foreach (var item in grouped)
            {
                result.Add(item.File.ToString(), item.Count);
            }

            return result;
        }

        private Dictionary<string, object> PrepareParamsTemplate(bool result)
        {
            Dictionary<string, object> paramsTemplate = new Dictionary<string, object>();

            string projectName = document.ProjectInformation.Name;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            paramsTemplate.Add("TITLE", string.Format("{0} - {1}", projectName, "Report Tabla Areas"));
            paramsTemplate.Add("PROJECT_NAME", projectName);
            paramsTemplate.Add("PROJECT_FILE", document.IsWorkshared && !document.IsDetached ? 
                ModelPathUtils.ConvertModelPathToUserVisiblePath(document.GetWorksharingCentralModelPath()) : 
                document.PathName
            );
            paramsTemplate.Add("CHECKED_LINKS", chk_ExecuteRulesLink.Checked);
            paramsTemplate.Add("REPORT_DATE", DateTime.Now);
            paramsTemplate.Add("REPORT_RESULT", result);
            paramsTemplate.Add("YEAR", DateTime.Now.Year);
            paramsTemplate.Add("VERSION", string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision));

            return paramsTemplate;
        }

        private string WriteReport(bool[] rules, Dictionary<Rule, RuleReponse> report, Dictionary<string, object> paramsTemplate)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string folder = new FileInfo(assemblyPath).Directory.FullName;
            string path = Path.Combine(folder, "template_report.st");

            Template template;

            FileInfo file = new FileInfo(path);

            using (StreamReader reader = file.OpenText())
            {
                template = new Template(reader.ReadToEnd(), '$', '$');
            }

            for (int i = 0; i < rules.Length; i++)
            {
                template.Add(string.Format("RULE_{0}", i + 1), rules[i]);
            }

            foreach (var item in report)
            {
                template.Add(item.Key.ToString(), item.Value);
            }

            foreach (var item in paramsTemplate)
            {
                template.Add(item.Key, item.Value);
            }

            string tempPath = Path.GetTempPath();
            path = Path.Combine(tempPath, string.Format("Report Tabla Áreas - {0}", DateTime.Now.ToString("yMMddHHmm")));
            string path1 = path;

            for (int i = 1; File.Exists(string.Format("{0}.html", path1)); i++)
            {
                path1 = string.Format("{0} ({1})", path, i);
            }

            path = string.Format("{0}.html", path1);
            
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(template.Render());
            }

            return path;
        }

        private void ExportExcel(string fileName)
        {
            File.Copy(txt_ExcelTemplate.Text, fileName, true);

            VerifySecurityEvidenceForIsolatedStorage(this.GetType().Assembly);

            SLDocument sl = new SLDocument(fileName);

            List<string> columns = new List<string>();

            sl.SelectWorksheet("Areas (Detalle)");

            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();

            // Clear previous data
            sl.DeleteRow(3, stats.EndRowIndex - 3);

            for (int i = 1; i <= stats.EndColumnIndex; i++)
            {
                string name = sl.GetCellValueAsString(1, i);

                if (!string.IsNullOrEmpty(name))
                {
                    columns.Add(name);
                }
            }

            Dictionary<string, ScheduleExport> excelSchedule = new Dictionary<string, ScheduleExport>();
            excelSchedule.Add("Desglose", new ScheduleExport("Desglose"));
            excelSchedule.Add("Objeto", new ScheduleExport("Objeto"));
            excelSchedule.Add("Edificio", new ScheduleExport("Edificio"));
            excelSchedule.Add("Tipo Edificio", new ScheduleExport("Tipo Edificio"));
            excelSchedule.Add("Nivel", new ScheduleExport("Nivel"));
            //excelSchedule.Add("Padre", new ScheduleExport("Contenedor", ParameterType.INT));
            //excelSchedule.Add("Nombre Padre", new ScheduleExport("Nombre Local"));
            excelSchedule.Add("Subsistema Tipo", new ScheduleExport("Subsistema Tipo"));
            excelSchedule.Add("Subsistema Area", new ScheduleExport("Subsistema Area"));
            excelSchedule.Add("Local Tipo", new ScheduleExport("Local Tipo"));
            excelSchedule.Add("COD 1", new ScheduleExport("COD 1"));
            excelSchedule.Add("COD 2", new ScheduleExport("COD 2"));
            excelSchedule.Add("RoomID", new ScheduleExport("RoomID", null, ParameterType.INT));
            excelSchedule.Add("NumeroUnico", new ScheduleExport("Nº Único"));
            excelSchedule.Add("NumeroLocal", new ScheduleExport("Nº Local"));
            excelSchedule.Add("Local", new ScheduleExport("Nombre"));
            excelSchedule.Add("Cantidad representativa", new ScheduleExport("Cantidad representativa", null, ParameterType.INT));
            excelSchedule.Add("Hab", new ScheduleExport("Habitacion", null, ParameterType.INT));
            excelSchedule.Add("Modulos", new ScheduleExport("Modulos", null, ParameterType.INT));
            excelSchedule.Add("Niveles Tipicos", new ScheduleExport("Niveles Tipicos", null, ParameterType.INT));
            excelSchedule.Add("Área del local [m²]", new ScheduleExport("Área del local [m²]", null, ParameterType.DOUBLE));
            excelSchedule.Add("% Base Diseño", new ScheduleExport("PorcientoBD", null, ParameterType.DOUBLE));
            excelSchedule.Add("Coef. SC/SU", new ScheduleExport("Coef. SC/SU", null, ParameterType.DOUBLE));
            //excelSchedule.Add("ID", new ScheduleExport("ID", ParameterType.INT));
            //excelSchedule.Add("Plazas", new ScheduleExport("Coef/Num.Habitaciones", ParameterType.DOUBLE));

            ViewSchedule schedule = viewSchedules[cmb_Schedules.SelectedIndex];

            if (!schedule.Definition.ShowHeaders)
            {
                throw new Exception(string.Format("The « {0} » schedule is not correct for export.", schedule.Name));
            }

            List<string> visibleFields = new List<string>();

            for (int i = 0, c = schedule.Definition.GetFieldCount(); i < c; i++)
            {
                ScheduleField field = schedule.Definition.GetField(i);

                if (!field.IsHidden)
                {
                    visibleFields.Add(field.ColumnHeading);
                }
            }

            TableData table = schedule.GetTableData();
            TableSectionData section = table.GetSectionData(SectionType.Body);

            for (int i = 1, cursor = 2; i < section.NumberOfRows; i++, cursor++)
            {
                Dictionary<int, ScheduleExport> values = new Dictionary<int, ScheduleExport>();

                for (int j = 0; j < columns.Count; j++)
                {
                    KeyValuePair<string, ScheduleExport> item = excelSchedule.FirstOrDefault(x => x.Key == columns[j]);

                    if (item.Key == null && item.Value == null)
                    {
                        continue;
                    }

                    int jj = visibleFields.FindIndex(x => x == item.Value.Field);

                    if (jj > -1)
                    {
                        item.Value.Value = schedule.GetCellText(SectionType.Body, i, jj);
                    }
                    else
                    {
                        item.Value.Value = string.Empty;
                    }

                    values.Add(j, item.Value);
                }

                values = ExecuteTasks(values);

                if (values == null)
                {
                    cursor--;
                    continue;
                }

                if (cursor > 2)
                {
                    sl.CopyRow(2, cursor);
                }

                foreach (var item in values)
                {
                    if (!string.IsNullOrEmpty(item.Value.Value))
                    {
                        try
                        {
                            if (item.Value.Type == ParameterType.INT)
                            {
                                sl.SetCellValue(cursor, item.Key + 1, int.Parse(item.Value.Value));
                            }
                            else if (item.Value.Type == ParameterType.DOUBLE)
                            {
                                sl.SetCellValue(cursor, item.Key + 1, double.Parse(item.Value.Value));
                            }
                            else if (item.Value.Type == ParameterType.BOOL)
                            {
                                sl.SetCellValue(cursor, item.Key + 1, bool.Parse(item.Value.Value));
                            }
                            else
                            {
                                sl.SetCellValue(cursor, item.Key + 1, item.Value.Value);
                            }
                        }
                        catch (Exception)
                        {
                            sl.SetCellValue(cursor, item.Key + 1, item.Value.Value);
                        }
                    }
                    else
                    {
                        // Clear cell
                        sl.SetCellValue(cursor, item.Key + 1, "");
                    }
                }
            }

            sl.SelectWorksheet("Indices Generales");

            sl.Save();
        }

        public static void VerifySecurityEvidenceForIsolatedStorage(Assembly assembly)
        {
            var isEvidenceFound = true;
            var initialAppDomainEvidence = Thread.GetDomain().Evidence;

            try
            {
                // this will fail when the current AppDomain Evidence is instantiated via COM or in PowerShell
                using (var usfdAttempt1 = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain())
                {
                }
            }
            catch (System.IO.IsolatedStorage.IsolatedStorageException e)
            {
                isEvidenceFound = false;
            }

            if (!isEvidenceFound)
            {
                initialAppDomainEvidence.AddHostEvidence(new Url(assembly.Location));
                initialAppDomainEvidence.AddHostEvidence(new Zone(SecurityZone.MyComputer));

                var currentAppDomain = Thread.GetDomain();
                var securityIdentityField = currentAppDomain.GetType().GetField("_SecurityIdentity", BindingFlags.Instance | BindingFlags.NonPublic);
                securityIdentityField.SetValue(currentAppDomain, initialAppDomainEvidence);

                var latestAppDomainEvidence = Thread.GetDomain().Evidence;
            }
        }
    }
}
