using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using HastEmail.Src;
using Newtonsoft.Json;
using MetroFramework;
using MetroFramework.Forms;

namespace HastEmail
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        Client client;
        public frmMain(Client _Client)
        {
            InitializeComponent();
            client = _Client;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!Client.IsEmailValid(txtcheck.Text))
                return;

            string sURL = Server.CheckURL + txtcheck.Text;

            lblCheck.Text = client.user.CheckEmail(sURL) ? "This email is present in the blacklist" :
                                                           "This email is NOT present in the blacklist";
            lblCheck.Visible = true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (!Client.IsEmailValid(txtadd.Text))
                return;

            string sURL = Server.AddURL + txtadd.Text;
            lblAdd.Text = client.user.AddEmail(client.user, sURL) ? "Ho aggiunto la mail" :
                                                                    "Questa mail è già esistente";
            lblAdd.Visible = true;
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (!Client.IsEmailValid(txtRemove.Text))
                return;

            string sURL = Server.RemoveURL + txtRemove.Text;
            lblRemove.Text = client.user.RemoveEmail(client.user, sURL) ? "Email Removed" :
                                                                          "Email not found!";
            lblRemove.Visible = true;
        }

        private async void btncheckall_Click(object sender, EventArgs e)
        {
            btncheckall.Text = "&Refresh";

            // Deserialize object, by using an async task
            //var list = client.user.GetList();
            BlackList.ListResult list = null;

            await Task.Run(() => {list = client.user.GetList();});
            
            // Check API response
            if (list != null)
            {
                txtlist.Text = string.Empty;

                // printing all blacklist field in to the text_list
                foreach (var entry in list.blacklist)
                    txtlist.Text += entry.email + Environment.NewLine;
            }
            else
            {
                MetroMessageBox.Show(this, "\nConnection error, please restart the application!", "No Internet Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            BlackList.ListResult list = null;

            await Task.Run(() => { list = client.user.GetList(); });

            SaveFileDialog ExportJson = new SaveFileDialog();
            ExportJson.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            ExportJson.FilterIndex = 1;
            ExportJson.RestoreDirectory = true;
            ExportJson.FileName = "Database_Export";

            if (ExportJson.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine($"File Path: {ExportJson.FileName}");
                string serialized = BlackList.ListResult.JsonSerialaized(list);
                bool write = BlackList.ListResult.WriteJson(ExportJson.FileName, serialized);

                if (write)
                {
                    MetroMessageBox.Show(this, "\nSaved!", "Database Exported", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, $"\nUnable to write into the file {ExportJson.FileName}", "Database Exported Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
