namespace BBI.JD.Forms
{
    partial class CheckResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckResult));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Show = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "report_32x32.png");
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(70, 57);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(275, 20);
            this.txt_Email.TabIndex = 11;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(25, 104);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 12;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_Show
            // 
            this.btn_Show.Location = new System.Drawing.Point(171, 104);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(75, 23);
            this.btn_Show.TabIndex = 13;
            this.btn_Show.Text = "Show";
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(317, 104);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 14;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(48, 11);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(344, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "The project did not pass the rules to which it was submitted. Take a look to repo" +
    "rt.";
            // 
            // label2
            // 
            this.label2.ImageKey = "report_32x32.png";
            this.label2.ImageList = this.imageList1;
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 46);
            this.label2.TabIndex = 15;
            // 
            // CheckResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(414, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 178);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 178);
            this.Name = "CheckResult";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check result";
            this.Load += new System.EventHandler(this.CheckResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}