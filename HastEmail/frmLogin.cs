using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HastEmail.Src;

namespace HastEmail
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        private void Frm_FormClosed(object sender, FormClosedEventArgs e) => Close();

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            
            // Check if the id/psw submitted, are in the correct format => (no null, no empty)
            if (string.IsNullOrEmpty(txtUser.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("You must insert a valid user/password format", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thanks to it, the user know that the log-in process is working in background and the gui is not freezing
            pbLogin.Visible = true;

            //Getting ID + Password
            Client client = new Client(txtUser.Text, txtPassword.Text);

            // login a user, through an async task
            bool loginSucess = false;

            await Task.Run(() =>
            {
                try
                {
                    loginSucess = client.user.Login();
                }
                catch (Exception ex)
                {
                    // eccezione generica ?
                    Debug.WriteLine("ECCEZIONE: " + ex);
                    MessageBox.Show(ex.ToString(), "Eccezione");
                }
            });

            if (loginSucess)
            {
                //se il login va a buon fine
                frmMain frm = new frmMain(client);           // Creating a new instance of frmMain
                frm.Show();                            // Showing the frmMain
                Hide();                                // Hiding log-in form
                frm.FormClosed += Frm_FormClosed;
            }
            else
            {
                lblLoginFail.Visible = true;
                pbLogin.Visible = false;
            }
        }
    }
}
