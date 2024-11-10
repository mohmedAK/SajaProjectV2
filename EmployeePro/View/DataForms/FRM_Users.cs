using DevExpress.XtraEditors;
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
    public partial class FRM_Users : DevExpress.XtraEditors.XtraForm
    {
        CmdUsers cmdUsers = new CmdUsers();
        private int _userId;
        public FRM_Users()
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            List<CLS_Users> userDates = cmdUsers.GetAllUsers();
            gcUsers.DataSource = userDates;
            cbRole.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            if (CLS_UsereSession.Role != "SuperAdmin")
            {
                cbRole.Enabled = false;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_BasicProjectData().Show();
        }

        private void FRM_Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_BasicProjectData().Show();
        }

        private bool CheckIsNull()
        {
            var controlsToCheck = new[] { txtPassword, txtUsername, cbRole };
            return controlsToCheck.Any(control => string.IsNullOrEmpty(control?.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckIsNull())
            {
                XtraMessageBox.Show("Please fill all fields");
                return;
            }
            AddUserData();

            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbRole.Text = string.Empty;
        }

        private void AddUserData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var userData = new CLS_Users
                {
                    Id = cmdUsers.getNewId(),
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    Role = cbRole.Text
                };
               

                cmdUsers.AddUser(userData);

                List<CLS_Users> userDates = cmdUsers.GetAllUsers();
                gcUsers.DataSource = userDates;
                Cursor.Current = Cursors.Default;
            }
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            if(CLS_UsereSession.Role == "SuperAdmin")
            {
                if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int userId = Convert.ToInt32(gvUsers.GetFocusedRowCellValue("Id"));
                    cmdUsers.RemoveUser(userId);
                    List<CLS_Users> userDates = cmdUsers.GetAllUsers();
                    gcUsers.DataSource = userDates;
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                XtraMessageBox.Show("You are not authorized to delete this user");
            }
        }
    }
}