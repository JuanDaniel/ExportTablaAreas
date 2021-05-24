using Antlr4.StringTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBI.JD.Forms
{
    public partial class CheckResult : Form
    {
        private string email;
        private string pathReport;
        private Dictionary<string, object> paramsTemplate;

        public CheckResult(string email, string pathReport, Dictionary<string, object> paramsTemplate)
        {
            InitializeComponent();

            this.email = email;
            this.pathReport = pathReport;
            this.paramsTemplate = paramsTemplate;
        }

        private void CheckResult_Load(object sender, EventArgs e)
        {
            txt_Email.Text = email;
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = pathReport;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            Close();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            NetworkCredential networkCredential = new NetworkCredential(
                Config.Get("emailUser"),
                Config.Get("emailPassword"),
                Config.Get("domainServer")
            );
            
            MailAddress from = new MailAddress(
                Config.Get("emailAddress")
            );

            MailAddress to;

            try
            {
                to = new MailAddress(txt_Email.Text);

                Config.Set("emailDefaultAddress", txt_Email.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid email address", "Email address", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            SmtpClient client = new SmtpClient();

            client.Host = Config.Get("emailServer");
            client.UseDefaultCredentials = false;
            client.Credentials = networkCredential;
            client.Timeout = (6 * 5 * 1000);

            MailMessage message = new MailMessage();

            message.From = from;
            message.To.Add(to);
            message.Priority = MailPriority.High;
            message.Subject = "Report Tabla Áreas";
            message.IsBodyHtml = true;
            message.Attachments.Add(new Attachment(pathReport, "text/html"));
            message.Body = PrepareTemplate();

            try
            {
                client.Send(message);

                MessageBox.Show("The report was sent to the address indicated.", "Report was sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when sending the report.\nPlease contact to admin.", "Error to send", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PrepareTemplate()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string folder = new FileInfo(assemblyPath).Directory.FullName;
            string path = Path.Combine(folder, "template_email.st");

            Template template;

            FileInfo file = new FileInfo(path);

            using (StreamReader reader = file.OpenText())
            {
                template = new Template(reader.ReadToEnd(), '$', '$');
            }

            foreach (var item in paramsTemplate)
            {
                template.Add(item.Key, item.Value);
            }

            return template.Render();
        }
    }
}
