namespace BBI.JD.Forms
{
    partial class IndicatorsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndicatorsForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaSHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupUtil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupUtilComputada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupConstruidaSHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coeficiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Level,
            this.AreaRoom,
            this.AreaSHO,
            this.SupUtil,
            this.SupUtilComputada,
            this.SupConstruidaSHO,
            this.Coeficiente});
            this.dataGridView1.Location = new System.Drawing.Point(11, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(822, 439);
            this.dataGridView1.TabIndex = 9;
            // 
            // Level
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Level.DefaultCellStyle = dataGridViewCellStyle1;
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            // 
            // AreaRoom
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.AreaRoom.DefaultCellStyle = dataGridViewCellStyle2;
            this.AreaRoom.HeaderText = "Area Room [m²]";
            this.AreaRoom.Name = "AreaRoom";
            this.AreaRoom.ReadOnly = true;
            // 
            // AreaSHO
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.AreaSHO.DefaultCellStyle = dataGridViewCellStyle3;
            this.AreaSHO.HeaderText = "Area S.H.O. [m²]";
            this.AreaSHO.Name = "AreaSHO";
            this.AreaSHO.ReadOnly = true;
            // 
            // SupUtil
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.SupUtil.DefaultCellStyle = dataGridViewCellStyle4;
            this.SupUtil.HeaderText = "Sup. Útil [m²]";
            this.SupUtil.Name = "SupUtil";
            this.SupUtil.ReadOnly = true;
            this.SupUtil.ToolTipText = "= AreaRoom * NivelesTipicosRoom";
            // 
            // SupUtilComputada
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.SupUtilComputada.DefaultCellStyle = dataGridViewCellStyle5;
            this.SupUtilComputada.HeaderText = "Sup. Útil Computada [m²]";
            this.SupUtilComputada.Name = "SupUtilComputada";
            this.SupUtilComputada.ReadOnly = true;
            this.SupUtilComputada.ToolTipText = "= AreaRoom * NivelesTipicosRoom * PorcientoBD";
            // 
            // SupConstruidaSHO
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.SupConstruidaSHO.DefaultCellStyle = dataGridViewCellStyle6;
            this.SupConstruidaSHO.HeaderText = "Sup. Construida S.H.O. [m²]";
            this.SupConstruidaSHO.Name = "SupConstruidaSHO";
            this.SupConstruidaSHO.ReadOnly = true;
            this.SupConstruidaSHO.ToolTipText = "= AreaSHO * NivelesTipicosSHO";
            // 
            // Coeficiente
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Coeficiente.DefaultCellStyle = dataGridViewCellStyle7;
            this.Coeficiente.HeaderText = "Coeficiente SC/SU";
            this.Coeficiente.Name = "Coeficiente";
            this.Coeficiente.ReadOnly = true;
            this.Coeficiente.ToolTipText = "= AreaSHO / AreaRoom";
            // 
            // IndicatorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 463);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(861, 502);
            this.MinimumSize = new System.Drawing.Size(861, 502);
            this.Name = "IndicatorsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = GetTiTleForm();
            this.Load += new System.EventHandler(this.IndicatorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaSHO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupUtil;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupUtilComputada;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupConstruidaSHO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coeficiente;
    }
}