namespace BBI.JD.Forms
{
    partial class TextToNumeric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextToNumeric));
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_TextParameter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_NumericParameter = new System.Windows.Forms.ComboBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lst_Relation = new System.Windows.Forms.ListView();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.chk_Overwrite = new System.Windows.Forms.CheckBox();
            this.chk_UpdateControl = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_SetType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "Text parameter";
            // 
            // cmb_TextParameter
            // 
            this.cmb_TextParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TextParameter.FormattingEnabled = true;
            this.cmb_TextParameter.Location = new System.Drawing.Point(17, 97);
            this.cmb_TextParameter.Name = "cmb_TextParameter";
            this.cmb_TextParameter.Size = new System.Drawing.Size(162, 21);
            this.cmb_TextParameter.Sorted = true;
            this.cmb_TextParameter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numeric parameter";
            // 
            // cmb_NumericParameter
            // 
            this.cmb_NumericParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NumericParameter.FormattingEnabled = true;
            this.cmb_NumericParameter.Location = new System.Drawing.Point(234, 97);
            this.cmb_NumericParameter.Name = "cmb_NumericParameter";
            this.cmb_NumericParameter.Size = new System.Drawing.Size(162, 21);
            this.cmb_NumericParameter.Sorted = true;
            this.cmb_NumericParameter.TabIndex = 3;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_Add.Location = new System.Drawing.Point(449, 97);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lst_Relation
            // 
            this.lst_Relation.CheckBoxes = true;
            this.lst_Relation.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lst_Relation.FullRowSelect = true;
            this.lst_Relation.HideSelection = false;
            this.lst_Relation.Location = new System.Drawing.Point(59, 180);
            this.lst_Relation.MultiSelect = false;
            this.lst_Relation.Name = "lst_Relation";
            this.lst_Relation.Size = new System.Drawing.Size(394, 143);
            this.lst_Relation.TabIndex = 5;
            this.lst_Relation.UseCompatibleStateImageBehavior = false;
            this.lst_Relation.View = System.Windows.Forms.View.List;
            // 
            // btn_Remove
            // 
            this.btn_Remove.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_Remove.Location = new System.Drawing.Point(378, 329);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_Remove.TabIndex = 6;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_Ok.Location = new System.Drawing.Point(361, 407);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 9;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // chk_Overwrite
            // 
            this.chk_Overwrite.AutoSize = true;
            this.chk_Overwrite.Checked = true;
            this.chk_Overwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Overwrite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Overwrite.Location = new System.Drawing.Point(17, 360);
            this.chk_Overwrite.Name = "chk_Overwrite";
            this.chk_Overwrite.Size = new System.Drawing.Size(184, 18);
            this.chk_Overwrite.TabIndex = 7;
            this.chk_Overwrite.Text = "Overwrite previous values";
            this.chk_Overwrite.UseVisualStyleBackColor = true;
            // 
            // chk_UpdateControl
            // 
            this.chk_UpdateControl.AutoSize = true;
            this.chk_UpdateControl.Checked = true;
            this.chk_UpdateControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UpdateControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_UpdateControl.Location = new System.Drawing.Point(17, 386);
            this.chk_UpdateControl.Name = "chk_UpdateControl";
            this.chk_UpdateControl.Size = new System.Drawing.Size(256, 18);
            this.chk_UpdateControl.TabIndex = 8;
            this.chk_UpdateControl.Text = "Update Control Programa parameters";
            this.chk_UpdateControl.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Rooms";
            // 
            // cmb_SetType
            // 
            this.cmb_SetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SetType.FormattingEnabled = true;
            this.cmb_SetType.Items.AddRange(new object[] {
            "Rooms in the file",
            "Rooms in the view",
            "Rooms in the selection"});
            this.cmb_SetType.Location = new System.Drawing.Point(17, 32);
            this.cmb_SetType.Name = "cmb_SetType";
            this.cmb_SetType.Size = new System.Drawing.Size(336, 21);
            this.cmb_SetType.TabIndex = 1;
            this.cmb_SetType.SelectedIndexChanged += new System.EventHandler(this.cmb_SetType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(359, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "#";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_Cancel.Location = new System.Drawing.Point(449, 407);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(172, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "Parameters list to operate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.24F);
            this.label5.Location = new System.Drawing.Point(222, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Read-only parameters were excluded";
            // 
            // TextToNumeric
            // 
            this.AcceptButton = this.btn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(539, 442);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_SetType);
            this.Controls.Add(this.chk_UpdateControl);
            this.Controls.Add(this.chk_Overwrite);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.lst_Relation);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_NumericParameter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmb_TextParameter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(555, 481);
            this.MinimumSize = new System.Drawing.Size(555, 481);
            this.Name = "TextToNumeric";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = GetTiTleForm();
            this.Load += new System.EventHandler(this.TextToNumeric_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_TextParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_NumericParameter;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListView lst_Relation;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.CheckBox chk_Overwrite;
        private System.Windows.Forms.CheckBox chk_UpdateControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_SetType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}