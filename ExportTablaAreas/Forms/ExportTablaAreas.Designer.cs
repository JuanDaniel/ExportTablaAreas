namespace BBI.JD.Forms
{
    partial class ExportTablaAreas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportTablaAreas));
            this.btn_Check = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Main = new System.Windows.Forms.TabPage();
            this.chk_UpdHome = new System.Windows.Forms.CheckBox();
            this.chk_UpdNumericParameters = new System.Windows.Forms.CheckBox();
            this.chk_CheckBeforeExport = new System.Windows.Forms.CheckBox();
            this.chk_ExecuteRulesLink = new System.Windows.Forms.CheckBox();
            this.grp_Rules = new System.Windows.Forms.GroupBox();
            this.chk_Rule_9 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_8 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_7 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_3 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_6 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_1 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_2 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_5 = new System.Windows.Forms.CheckBox();
            this.chk_Rule_4 = new System.Windows.Forms.CheckBox();
            this.grp_Tasks = new System.Windows.Forms.GroupBox();
            this.chk_Task_6 = new System.Windows.Forms.CheckBox();
            this.chk_Task_3 = new System.Windows.Forms.CheckBox();
            this.chk_Task_2 = new System.Windows.Forms.CheckBox();
            this.chk_Task_7 = new System.Windows.Forms.CheckBox();
            this.chk_Task_1 = new System.Windows.Forms.CheckBox();
            this.chk_Task_5 = new System.Windows.Forms.CheckBox();
            this.chk_Task_4 = new System.Windows.Forms.CheckBox();
            this.tab_Config = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chk_UpdateHome = new System.Windows.Forms.CheckBox();
            this.chk_UpdateNumericParameters = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_ParameterCapHab = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_ParameterSHO = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_ParameterSupUtil = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_ScheduleCapHab = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_ScheduleAreaConst = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_ScheduleAreaUtil = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_ParameterPorcientoBD = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_ParameterNivelesTipicos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.btn_ExcelTemplate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Schedules = new System.Windows.Forms.ComboBox();
            this.txt_ExcelTemplate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.grp_Rules.SuspendLayout();
            this.grp_Tasks.SuspendLayout();
            this.tab_Config.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Check
            // 
            this.btn_Check.Font = new System.Drawing.Font("Tahoma", 9.2F);
            this.btn_Check.Location = new System.Drawing.Point(208, 512);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(75, 35);
            this.btn_Check.TabIndex = 17;
            this.btn_Check.Text = "Check";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Tahoma", 9.2F);
            this.btn_Export.Location = new System.Drawing.Point(334, 512);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 35);
            this.btn_Export.TabIndex = 18;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Main);
            this.tabControl1.Controls.Add(this.tab_Config);
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 488);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.chk_UpdHome);
            this.tab_Main.Controls.Add(this.chk_UpdNumericParameters);
            this.tab_Main.Controls.Add(this.chk_CheckBeforeExport);
            this.tab_Main.Controls.Add(this.chk_ExecuteRulesLink);
            this.tab_Main.Controls.Add(this.grp_Rules);
            this.tab_Main.Controls.Add(this.grp_Tasks);
            this.tab_Main.Location = new System.Drawing.Point(4, 22);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Main.Size = new System.Drawing.Size(616, 462);
            this.tab_Main.TabIndex = 0;
            this.tab_Main.Text = "Main";
            this.tab_Main.UseVisualStyleBackColor = true;
            // 
            // chk_UpdHome
            // 
            this.chk_UpdHome.AutoSize = true;
            this.chk_UpdHome.Checked = true;
            this.chk_UpdHome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UpdHome.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_UpdHome.Location = new System.Drawing.Point(323, 349);
            this.chk_UpdHome.Name = "chk_UpdHome";
            this.chk_UpdHome.Size = new System.Drawing.Size(102, 18);
            this.chk_UpdHome.TabIndex = 18;
            this.chk_UpdHome.Text = "Update Home";
            this.chk_UpdHome.UseVisualStyleBackColor = true;
            // 
            // chk_UpdNumericParameters
            // 
            this.chk_UpdNumericParameters.AutoSize = true;
            this.chk_UpdNumericParameters.Checked = true;
            this.chk_UpdNumericParameters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UpdNumericParameters.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_UpdNumericParameters.Location = new System.Drawing.Point(323, 321);
            this.chk_UpdNumericParameters.Name = "chk_UpdNumericParameters";
            this.chk_UpdNumericParameters.Size = new System.Drawing.Size(178, 18);
            this.chk_UpdNumericParameters.TabIndex = 17;
            this.chk_UpdNumericParameters.Text = "Update numeric parameters";
            this.chk_UpdNumericParameters.UseVisualStyleBackColor = true;
            // 
            // chk_CheckBeforeExport
            // 
            this.chk_CheckBeforeExport.AutoSize = true;
            this.chk_CheckBeforeExport.Checked = true;
            this.chk_CheckBeforeExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_CheckBeforeExport.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_CheckBeforeExport.Location = new System.Drawing.Point(323, 377);
            this.chk_CheckBeforeExport.Name = "chk_CheckBeforeExport";
            this.chk_CheckBeforeExport.Size = new System.Drawing.Size(139, 18);
            this.chk_CheckBeforeExport.TabIndex = 19;
            this.chk_CheckBeforeExport.Text = "Check before export";
            this.chk_CheckBeforeExport.UseVisualStyleBackColor = true;
            // 
            // chk_ExecuteRulesLink
            // 
            this.chk_ExecuteRulesLink.AutoSize = true;
            this.chk_ExecuteRulesLink.Checked = true;
            this.chk_ExecuteRulesLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ExecuteRulesLink.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_ExecuteRulesLink.Location = new System.Drawing.Point(26, 384);
            this.chk_ExecuteRulesLink.Name = "chk_ExecuteRulesLink";
            this.chk_ExecuteRulesLink.Size = new System.Drawing.Size(169, 18);
            this.chk_ExecuteRulesLink.TabIndex = 10;
            this.chk_ExecuteRulesLink.Text = "Execute rules on each link";
            this.chk_ExecuteRulesLink.UseVisualStyleBackColor = true;
            // 
            // grp_Rules
            // 
            this.grp_Rules.Controls.Add(this.chk_Rule_9);
            this.grp_Rules.Controls.Add(this.chk_Rule_8);
            this.grp_Rules.Controls.Add(this.chk_Rule_7);
            this.grp_Rules.Controls.Add(this.chk_Rule_3);
            this.grp_Rules.Controls.Add(this.chk_Rule_6);
            this.grp_Rules.Controls.Add(this.chk_Rule_1);
            this.grp_Rules.Controls.Add(this.chk_Rule_2);
            this.grp_Rules.Controls.Add(this.chk_Rule_5);
            this.grp_Rules.Controls.Add(this.chk_Rule_4);
            this.grp_Rules.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.grp_Rules.Location = new System.Drawing.Point(26, 14);
            this.grp_Rules.Name = "grp_Rules";
            this.grp_Rules.Size = new System.Drawing.Size(281, 360);
            this.grp_Rules.TabIndex = 0;
            this.grp_Rules.TabStop = false;
            this.grp_Rules.Text = "Rules to check";
            // 
            // chk_Rule_9
            // 
            this.chk_Rule_9.AutoSize = true;
            this.chk_Rule_9.Checked = true;
            this.chk_Rule_9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_9.Location = new System.Drawing.Point(17, 313);
            this.chk_Rule_9.Name = "chk_Rule_9";
            this.chk_Rule_9.Size = new System.Drawing.Size(139, 18);
            this.chk_Rule_9.TabIndex = 9;
            this.chk_Rule_9.Text = "Decimal format point";
            this.chk_Rule_9.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_8
            // 
            this.chk_Rule_8.AutoSize = true;
            this.chk_Rule_8.Checked = true;
            this.chk_Rule_8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_8.Location = new System.Drawing.Point(17, 279);
            this.chk_Rule_8.Name = "chk_Rule_8";
            this.chk_Rule_8.Size = new System.Drawing.Size(252, 18);
            this.chk_Rule_8.TabIndex = 8;
            this.chk_Rule_8.Text = "Coeficiente SC/SU value between 1 - 1.2";
            this.chk_Rule_8.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_7
            // 
            this.chk_Rule_7.AutoSize = true;
            this.chk_Rule_7.Checked = true;
            this.chk_Rule_7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_7.Location = new System.Drawing.Point(17, 245);
            this.chk_Rule_7.Name = "chk_Rule_7";
            this.chk_Rule_7.Size = new System.Drawing.Size(109, 18);
            this.chk_Rule_7.TabIndex = 7;
            this.chk_Rule_7.Text = "Updated Home";
            this.chk_Rule_7.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_3
            // 
            this.chk_Rule_3.AutoSize = true;
            this.chk_Rule_3.Checked = true;
            this.chk_Rule_3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_3.Location = new System.Drawing.Point(17, 109);
            this.chk_Rule_3.Name = "chk_Rule_3";
            this.chk_Rule_3.Size = new System.Drawing.Size(184, 18);
            this.chk_Rule_3.TabIndex = 3;
            this.chk_Rule_3.Text = "Redundant (Room and Area)";
            this.chk_Rule_3.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_6
            // 
            this.chk_Rule_6.AutoSize = true;
            this.chk_Rule_6.Checked = true;
            this.chk_Rule_6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_6.Location = new System.Drawing.Point(17, 211);
            this.chk_Rule_6.Name = "chk_Rule_6";
            this.chk_Rule_6.Size = new System.Drawing.Size(178, 18);
            this.chk_Rule_6.TabIndex = 6;
            this.chk_Rule_6.Text = "Decimal format PorcientoBD";
            this.chk_Rule_6.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_1
            // 
            this.chk_Rule_1.AutoSize = true;
            this.chk_Rule_1.Checked = true;
            this.chk_Rule_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_1.Location = new System.Drawing.Point(17, 41);
            this.chk_Rule_1.Name = "chk_Rule_1";
            this.chk_Rule_1.Size = new System.Drawing.Size(183, 18);
            this.chk_Rule_1.TabIndex = 1;
            this.chk_Rule_1.Text = "Not Placed (Room and Area)";
            this.chk_Rule_1.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_2
            // 
            this.chk_Rule_2.AutoSize = true;
            this.chk_Rule_2.Checked = true;
            this.chk_Rule_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_2.Location = new System.Drawing.Point(17, 75);
            this.chk_Rule_2.Name = "chk_Rule_2";
            this.chk_Rule_2.Size = new System.Drawing.Size(196, 18);
            this.chk_Rule_2.TabIndex = 2;
            this.chk_Rule_2.Text = "Not Enclosed (Room and Area)";
            this.chk_Rule_2.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_5
            // 
            this.chk_Rule_5.AutoSize = true;
            this.chk_Rule_5.Checked = true;
            this.chk_Rule_5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Rule_5.Location = new System.Drawing.Point(17, 177);
            this.chk_Rule_5.Name = "chk_Rule_5";
            this.chk_Rule_5.Size = new System.Drawing.Size(132, 18);
            this.chk_Rule_5.TabIndex = 5;
            this.chk_Rule_5.Text = "Empty PorcientoBD";
            this.chk_Rule_5.UseVisualStyleBackColor = true;
            // 
            // chk_Rule_4
            // 
            this.chk_Rule_4.AutoSize = true;
            this.chk_Rule_4.Checked = true;
            this.chk_Rule_4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Rule_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Rule_4.Location = new System.Drawing.Point(17, 143);
            this.chk_Rule_4.Name = "chk_Rule_4";
            this.chk_Rule_4.Size = new System.Drawing.Size(237, 18);
            this.chk_Rule_4.TabIndex = 4;
            this.chk_Rule_4.Text = "Empty NivelesTipicos (Room and Area)";
            this.chk_Rule_4.UseVisualStyleBackColor = true;
            // 
            // grp_Tasks
            // 
            this.grp_Tasks.Controls.Add(this.chk_Task_6);
            this.grp_Tasks.Controls.Add(this.chk_Task_3);
            this.grp_Tasks.Controls.Add(this.chk_Task_2);
            this.grp_Tasks.Controls.Add(this.chk_Task_7);
            this.grp_Tasks.Controls.Add(this.chk_Task_1);
            this.grp_Tasks.Controls.Add(this.chk_Task_5);
            this.grp_Tasks.Controls.Add(this.chk_Task_4);
            this.grp_Tasks.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.grp_Tasks.Location = new System.Drawing.Point(323, 14);
            this.grp_Tasks.Name = "grp_Tasks";
            this.grp_Tasks.Size = new System.Drawing.Size(265, 297);
            this.grp_Tasks.TabIndex = 0;
            this.grp_Tasks.TabStop = false;
            this.grp_Tasks.Text = "Tasks to export";
            // 
            // chk_Task_6
            // 
            this.chk_Task_6.AutoSize = true;
            this.chk_Task_6.Checked = true;
            this.chk_Task_6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Task_6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Task_6.Location = new System.Drawing.Point(22, 211);
            this.chk_Task_6.Name = "chk_Task_6";
            this.chk_Task_6.Size = new System.Drawing.Size(222, 18);
            this.chk_Task_6.TabIndex = 15;
            this.chk_Task_6.Text = "Change decimal format PorcientoBD";
            this.chk_Task_6.UseVisualStyleBackColor = true;
            // 
            // chk_Task_3
            // 
            this.chk_Task_3.AutoSize = true;
            this.chk_Task_3.Checked = true;
            this.chk_Task_3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Task_3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Task_3.Location = new System.Drawing.Point(22, 109);
            this.chk_Task_3.Name = "chk_Task_3";
            this.chk_Task_3.Size = new System.Drawing.Size(132, 18);
            this.chk_Task_3.TabIndex = 12;
            this.chk_Task_3.Text = "Exclude Redundant";
            this.chk_Task_3.UseVisualStyleBackColor = true;
            // 
            // chk_Task_2
            // 
            this.chk_Task_2.AutoSize = true;
            this.chk_Task_2.Checked = true;
            this.chk_Task_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Task_2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Task_2.Location = new System.Drawing.Point(22, 75);
            this.chk_Task_2.Name = "chk_Task_2";
            this.chk_Task_2.Size = new System.Drawing.Size(144, 18);
            this.chk_Task_2.TabIndex = 11;
            this.chk_Task_2.Text = "Exclude Not Enclosed";
            this.chk_Task_2.UseVisualStyleBackColor = true;
            // 
            // chk_Task_7
            // 
            this.chk_Task_7.AutoSize = true;
            this.chk_Task_7.Checked = true;
            this.chk_Task_7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Task_7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Task_7.Location = new System.Drawing.Point(22, 245);
            this.chk_Task_7.Name = "chk_Task_7";
            this.chk_Task_7.Size = new System.Drawing.Size(140, 18);
            this.chk_Task_7.TabIndex = 16;
            this.chk_Task_7.Text = "Format decimal point";
            this.chk_Task_7.UseVisualStyleBackColor = true;
            // 
            // chk_Task_1
            // 
            this.chk_Task_1.AutoSize = true;
            this.chk_Task_1.Checked = true;
            this.chk_Task_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Task_1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Task_1.Location = new System.Drawing.Point(22, 41);
            this.chk_Task_1.Name = "chk_Task_1";
            this.chk_Task_1.Size = new System.Drawing.Size(131, 18);
            this.chk_Task_1.TabIndex = 10;
            this.chk_Task_1.Text = "Exclude Not Placed";
            this.chk_Task_1.UseVisualStyleBackColor = true;
            // 
            // chk_Task_5
            // 
            this.chk_Task_5.AutoSize = true;
            this.chk_Task_5.Checked = true;
            this.chk_Task_5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Task_5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_Task_5.Location = new System.Drawing.Point(22, 177);
            this.chk_Task_5.Name = "chk_Task_5";
            this.chk_Task_5.Size = new System.Drawing.Size(199, 18);
            this.chk_Task_5.TabIndex = 14;
            this.chk_Task_5.Text = "Set by default PorcientoBD = 1";
            this.chk_Task_5.UseVisualStyleBackColor = true;
            // 
            // chk_Task_4
            // 
            this.chk_Task_4.AutoSize = true;
            this.chk_Task_4.Checked = true;
            this.chk_Task_4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Task_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Task_4.Location = new System.Drawing.Point(22, 143);
            this.chk_Task_4.Name = "chk_Task_4";
            this.chk_Task_4.Size = new System.Drawing.Size(206, 18);
            this.chk_Task_4.TabIndex = 13;
            this.chk_Task_4.Text = "Set by default NivelesTipicos = 1";
            this.chk_Task_4.UseVisualStyleBackColor = true;
            // 
            // tab_Config
            // 
            this.tab_Config.Controls.Add(this.groupBox4);
            this.tab_Config.Controls.Add(this.groupBox3);
            this.tab_Config.Controls.Add(this.groupBox2);
            this.tab_Config.Controls.Add(this.groupBox1);
            this.tab_Config.Controls.Add(this.label4);
            this.tab_Config.Controls.Add(this.txt_Email);
            this.tab_Config.Controls.Add(this.btn_ExcelTemplate);
            this.tab_Config.Controls.Add(this.label3);
            this.tab_Config.Controls.Add(this.cmb_Schedules);
            this.tab_Config.Controls.Add(this.txt_ExcelTemplate);
            this.tab_Config.Controls.Add(this.label2);
            this.tab_Config.Location = new System.Drawing.Point(4, 22);
            this.tab_Config.Name = "tab_Config";
            this.tab_Config.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Config.Size = new System.Drawing.Size(616, 462);
            this.tab_Config.TabIndex = 1;
            this.tab_Config.Text = "Configuration";
            this.tab_Config.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chk_UpdateHome);
            this.groupBox4.Controls.Add(this.chk_UpdateNumericParameters);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox4.Location = new System.Drawing.Point(12, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(589, 68);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Startup";
            // 
            // chk_UpdateHome
            // 
            this.chk_UpdateHome.AutoSize = true;
            this.chk_UpdateHome.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chk_UpdateHome.Location = new System.Drawing.Point(249, 29);
            this.chk_UpdateHome.Name = "chk_UpdateHome";
            this.chk_UpdateHome.Size = new System.Drawing.Size(109, 18);
            this.chk_UpdateHome.TabIndex = 11;
            this.chk_UpdateHome.Text = "Update Home";
            this.chk_UpdateHome.UseVisualStyleBackColor = true;
            // 
            // chk_UpdateNumericParameters
            // 
            this.chk_UpdateNumericParameters.AutoSize = true;
            this.chk_UpdateNumericParameters.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chk_UpdateNumericParameters.Location = new System.Drawing.Point(12, 29);
            this.chk_UpdateNumericParameters.Name = "chk_UpdateNumericParameters";
            this.chk_UpdateNumericParameters.Size = new System.Drawing.Size(195, 18);
            this.chk_UpdateNumericParameters.TabIndex = 10;
            this.chk_UpdateNumericParameters.Text = "Update numeric parameters";
            this.chk_UpdateNumericParameters.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmb_ParameterCapHab);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cmb_ParameterSHO);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.cmb_ParameterSupUtil);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox3.Location = new System.Drawing.Point(213, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 185);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters (Project)";
            // 
            // cmb_ParameterCapHab
            // 
            this.cmb_ParameterCapHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParameterCapHab.FormattingEnabled = true;
            this.cmb_ParameterCapHab.Location = new System.Drawing.Point(12, 137);
            this.cmb_ParameterCapHab.Name = "cmb_ParameterCapHab";
            this.cmb_ParameterCapHab.Size = new System.Drawing.Size(162, 22);
            this.cmb_ParameterCapHab.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 14);
            this.label13.TabIndex = 11;
            this.label13.Text = "Capacidad Habitacional";
            // 
            // cmb_ParameterSHO
            // 
            this.cmb_ParameterSHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParameterSHO.FormattingEnabled = true;
            this.cmb_ParameterSHO.Location = new System.Drawing.Point(12, 90);
            this.cmb_ParameterSHO.Name = "cmb_ParameterSHO";
            this.cmb_ParameterSHO.Size = new System.Drawing.Size(162, 22);
            this.cmb_ParameterSHO.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 14);
            this.label11.TabIndex = 9;
            this.label11.Text = "S.H.O";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 14);
            this.label12.TabIndex = 7;
            this.label12.Text = "Sup. Útil";
            // 
            // cmb_ParameterSupUtil
            // 
            this.cmb_ParameterSupUtil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParameterSupUtil.FormattingEnabled = true;
            this.cmb_ParameterSupUtil.Location = new System.Drawing.Point(12, 43);
            this.cmb_ParameterSupUtil.Name = "cmb_ParameterSupUtil";
            this.cmb_ParameterSupUtil.Size = new System.Drawing.Size(162, 22);
            this.cmb_ParameterSupUtil.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_ScheduleCapHab);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmb_ScheduleAreaConst);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmb_ScheduleAreaUtil);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 185);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Schedules";
            // 
            // cmb_ScheduleCapHab
            // 
            this.cmb_ScheduleCapHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ScheduleCapHab.FormattingEnabled = true;
            this.cmb_ScheduleCapHab.Location = new System.Drawing.Point(12, 142);
            this.cmb_ScheduleCapHab.Name = "cmb_ScheduleCapHab";
            this.cmb_ScheduleCapHab.Size = new System.Drawing.Size(162, 22);
            this.cmb_ScheduleCapHab.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 14);
            this.label10.TabIndex = 11;
            this.label10.Text = "Capacidad Habitacional";
            // 
            // cmb_ScheduleAreaConst
            // 
            this.cmb_ScheduleAreaConst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ScheduleAreaConst.FormattingEnabled = true;
            this.cmb_ScheduleAreaConst.Location = new System.Drawing.Point(12, 93);
            this.cmb_ScheduleAreaConst.Name = "cmb_ScheduleAreaConst";
            this.cmb_ScheduleAreaConst.Size = new System.Drawing.Size(162, 22);
            this.cmb_ScheduleAreaConst.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 14);
            this.label8.TabIndex = 9;
            this.label8.Text = "Área Const. Total [m2]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "Área Útil Total [m2]";
            // 
            // cmb_ScheduleAreaUtil
            // 
            this.cmb_ScheduleAreaUtil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ScheduleAreaUtil.FormattingEnabled = true;
            this.cmb_ScheduleAreaUtil.Location = new System.Drawing.Point(12, 44);
            this.cmb_ScheduleAreaUtil.Name = "cmb_ScheduleAreaUtil";
            this.cmb_ScheduleAreaUtil.Size = new System.Drawing.Size(162, 22);
            this.cmb_ScheduleAreaUtil.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_ParameterPorcientoBD);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmb_ParameterNivelesTipicos);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox1.Location = new System.Drawing.Point(414, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 185);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters (Room)";
            // 
            // cmb_ParameterPorcientoBD
            // 
            this.cmb_ParameterPorcientoBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParameterPorcientoBD.FormattingEnabled = true;
            this.cmb_ParameterPorcientoBD.Location = new System.Drawing.Point(12, 93);
            this.cmb_ParameterPorcientoBD.Name = "cmb_ParameterPorcientoBD";
            this.cmb_ParameterPorcientoBD.Size = new System.Drawing.Size(162, 22);
            this.cmb_ParameterPorcientoBD.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "PorcientoBD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "NivelesTipicos";
            // 
            // cmb_ParameterNivelesTipicos
            // 
            this.cmb_ParameterNivelesTipicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParameterNivelesTipicos.FormattingEnabled = true;
            this.cmb_ParameterNivelesTipicos.Location = new System.Drawing.Point(12, 44);
            this.cmb_ParameterNivelesTipicos.Name = "cmb_ParameterNivelesTipicos";
            this.cmb_ParameterNivelesTipicos.Size = new System.Drawing.Size(162, 22);
            this.cmb_ParameterNivelesTipicos.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email to send report";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(12, 367);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(275, 20);
            this.txt_Email.TabIndex = 12;
            // 
            // btn_ExcelTemplate
            // 
            this.btn_ExcelTemplate.Location = new System.Drawing.Point(577, 420);
            this.btn_ExcelTemplate.Name = "btn_ExcelTemplate";
            this.btn_ExcelTemplate.Size = new System.Drawing.Size(27, 23);
            this.btn_ExcelTemplate.TabIndex = 14;
            this.btn_ExcelTemplate.Text = "...";
            this.btn_ExcelTemplate.UseVisualStyleBackColor = true;
            this.btn_ExcelTemplate.Click += new System.EventHandler(this.btn_ExcelTemplate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Excel file template";
            // 
            // cmb_Schedules
            // 
            this.cmb_Schedules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Schedules.FormattingEnabled = true;
            this.cmb_Schedules.Location = new System.Drawing.Point(12, 29);
            this.cmb_Schedules.Name = "cmb_Schedules";
            this.cmb_Schedules.Size = new System.Drawing.Size(311, 21);
            this.cmb_Schedules.TabIndex = 1;
            this.cmb_Schedules.SelectedIndexChanged += new System.EventHandler(this.cmb_Schedules_SelectedIndexChanged);
            // 
            // txt_ExcelTemplate
            // 
            this.txt_ExcelTemplate.Location = new System.Drawing.Point(12, 423);
            this.txt_ExcelTemplate.Name = "txt_ExcelTemplate";
            this.txt_ExcelTemplate.ReadOnly = true;
            this.txt_ExcelTemplate.Size = new System.Drawing.Size(559, 20);
            this.txt_ExcelTemplate.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Schedule to export";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Spreadsheets|*.xls;*.xlsx";
            this.openFileDialog1.Title = "Select Excel file template";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CreatePrompt = true;
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Filter = "Spreadsheets|*.xls;*.xlsx";
            // 
            // ExportTablaAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_Check);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(665, 600);
            this.MinimumSize = new System.Drawing.Size(665, 600);
            this.Name = "ExportTablaAreas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = GetTiTleForm();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportTablaAreas_FormClosing);
            this.Load += new System.EventHandler(this.ExportTablaAreas_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            this.tab_Main.PerformLayout();
            this.grp_Rules.ResumeLayout(false);
            this.grp_Rules.PerformLayout();
            this.grp_Tasks.ResumeLayout(false);
            this.grp_Tasks.PerformLayout();
            this.tab_Config.ResumeLayout(false);
            this.tab_Config.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Main;
        private System.Windows.Forms.TabPage tab_Config;
        private System.Windows.Forms.Button btn_ExcelTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Schedules;
        private System.Windows.Forms.TextBox txt_ExcelTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.ComboBox cmb_ParameterNivelesTipicos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_ParameterPorcientoBD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_ScheduleAreaConst;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_ScheduleAreaUtil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_ScheduleCapHab;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmb_ParameterSHO;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_ParameterSupUtil;
        private System.Windows.Forms.ComboBox cmb_ParameterCapHab;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grp_Tasks;
        private System.Windows.Forms.CheckBox chk_Task_7;
        private System.Windows.Forms.CheckBox chk_Task_1;
        private System.Windows.Forms.CheckBox chk_Task_5;
        private System.Windows.Forms.CheckBox chk_Task_4;
        private System.Windows.Forms.GroupBox grp_Rules;
        private System.Windows.Forms.CheckBox chk_Rule_1;
        private System.Windows.Forms.CheckBox chk_Rule_2;
        private System.Windows.Forms.CheckBox chk_Rule_6;
        private System.Windows.Forms.CheckBox chk_Rule_5;
        private System.Windows.Forms.CheckBox chk_Rule_4;
        private System.Windows.Forms.CheckBox chk_Rule_9;
        private System.Windows.Forms.CheckBox chk_Rule_8;
        private System.Windows.Forms.CheckBox chk_Rule_7;
        private System.Windows.Forms.CheckBox chk_Rule_3;
        private System.Windows.Forms.CheckBox chk_ExecuteRulesLink;
        private System.Windows.Forms.CheckBox chk_UpdateHome;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chk_Task_3;
        private System.Windows.Forms.CheckBox chk_Task_2;
        private System.Windows.Forms.CheckBox chk_Task_6;
        private System.Windows.Forms.CheckBox chk_CheckBeforeExport;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chk_UpdateNumericParameters;
        private System.Windows.Forms.CheckBox chk_UpdNumericParameters;
        private System.Windows.Forms.CheckBox chk_UpdHome;
    }
}