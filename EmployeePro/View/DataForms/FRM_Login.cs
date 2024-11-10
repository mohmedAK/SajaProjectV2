using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using SajaProjectV2.Controller;
using SajaProjectV2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SajaProjectV2.View.DataForms
{
    public partial class FRM_Login : DevExpress.XtraEditors.XtraForm
    {
        CmdUsers cmdUsers = new CmdUsers();
        public FRM_Login()
        {
            InitializeComponent();
        }

        private void FRM_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckIsNull())
            {
                XtraMessageBox.Show("Please fill all fields");
                return;
            }
            Login();

            
        }

        private void Login()
        {
            CLS_Users users = cmdUsers.GetUserByNameAndPass(txtUser.Text, txtPassword.Text).FirstOrDefault();
            if (users != null)
            {
                //add resorces to the project
               CLS_UsereSession.Role = users.Role;
                CLS_UsereSession.userId = users.Id;
                Hide();
                new FRM_BasicProjectData().Show();
            }
            else
            {
                XtraMessageBox.Show("Invalid username or password");
            }
        }


        private bool CheckIsNull()
        {
            var controlsToCheck = new[] { txtPassword, txtUser };
            return controlsToCheck.Any(control => string.IsNullOrEmpty(control?.Text));
        }
    }
}