using DevExpress.XtraEditors;
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
    public partial class FRM_BasicProjectData : DevExpress.XtraEditors.XtraForm
    {
   
   
        public FRM_BasicProjectData()
        {
            InitializeComponent();
           
            

            if (CLS_UsereSession.Role == "Admin" || CLS_UsereSession.Role == "SuperAdmin")
            {
                btnUsers.Visible = true;
            }
        }

    

        private void sbNewProject_Click(object sender, EventArgs e)
        {
            this.Hide();
          new FRM_GeneralProjectInformation().Show(); 
           
        }

        private void sbShowProjects_Click(object sender, EventArgs e)
        {
            this.Hide();
             new FRM_Show_All_Projects().Show();
        }



        private void FRM_BasicProjectData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_Users().Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_Login().Show();
        }
    }
}