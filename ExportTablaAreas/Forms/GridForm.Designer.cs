namespace BBI.JD.Forms
{
    partial class GridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridForm));
            this.cmb_Value = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Highlight = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.cmb_Type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_IncludeLinks = new System.Windows.Forms.CheckBox();
            this.btn_Select = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Value
            // 
            this.cmb_Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Value.Enabled = false;
            this.cmb_Value.FormattingEnabled = true;
            this.cmb_Value.Items.AddRange(new object[] {
            "NOT_PLACED",
            "NOT_ENCLOSED",
            "REDUNDANT"});
            this.cmb_Value.Location = new System.Drawing.Point(286, 13);
            this.cmb_Value.Name = "cmb_Value";
            this.cmb_Value.Size = new System.Drawing.Size(151, 21);
            this.cmb_Value.TabIndex = 2;
            this.cmb_Value.SelectedIndexChanged += new System.EventHandler(this.cmb_Value_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 77);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(778, 361);
            this.dataGridView1.TabIndex = 7;
            // 
            // btn_Highlight
            // 
            this.btn_Highlight.Enabled = false;
            this.btn_Highlight.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_Highlight.Location = new System.Drawing.Point(630, 11);
            this.btn_Highlight.Name = "btn_Highlight";
            this.btn_Highlight.Size = new System.Drawing.Size(75, 23);
            this.btn_Highlight.TabIndex = 4;
            this.btn_Highlight.Text = "Highlight";
            this.btn_Highlight.UseVisualStyleBackColor = true;
            this.btn_Highlight.Click += new System.EventHandler(this.btn_Highlight_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_Delete.Location = new System.Drawing.Point(721, 11);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // cmb_Type
            // 
            this.cmb_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Type.FormattingEnabled = true;
            this.cmb_Type.Items.AddRange(new object[] {
            "ROOM",
            "AREA"});
            this.cmb_Type.Location = new System.Drawing.Point(61, 13);
            this.cmb_Type.Name = "cmb_Type";
            this.cmb_Type.Size = new System.Drawing.Size(151, 21);
            this.cmb_Type.TabIndex = 1;
            this.cmb_Type.SelectedIndexChanged += new System.EventHandler(this.cmb_Type_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type";
            // 
            // chk_IncludeLinks
            // 
            this.chk_IncludeLinks.AutoSize = true;
            this.chk_IncludeLinks.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.chk_IncludeLinks.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chk_IncludeLinks.Location = new System.Drawing.Point(612, 53);
            this.chk_IncludeLinks.Name = "chk_IncludeLinks";
            this.chk_IncludeLinks.Size = new System.Drawing.Size(184, 18);
            this.chk_IncludeLinks.TabIndex = 6;
            this.chk_IncludeLinks.Text = "Include elements of the links";
            this.chk_IncludeLinks.UseVisualStyleBackColor = true;
            this.chk_IncludeLinks.CheckedChanged += new System.EventHandler(this.chk_IncludeLinks_CheckedChanged);
            // 
            // btn_Select
            // 
            this.btn_Select.Enabled = false;
            this.btn_Select.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_Select.Location = new System.Drawing.Point(539, 11);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 3;
            this.btn_Select.Text = "Select";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 451);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.chk_IncludeLinks);
            this.Controls.Add(this.cmb_Type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Highlight);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmb_Value);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(831, 490);
            this.MinimumSize = new System.Drawing.Size(831, 490);
            this.Name = "GridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = GetTiTleForm();
            this.Load += new System.EventHandler(this.GridForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_Value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Highlight;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ComboBox cmb_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_IncludeLinks;
        private System.Windows.Forms.Button btn_Select;
    }
}