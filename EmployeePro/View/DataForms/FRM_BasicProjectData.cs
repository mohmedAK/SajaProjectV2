using DevExpress.XtraEditors;
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
        }

        private void sbNewProject_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_GeneralProjectInformation fRM_GeniralProjectInformation = new FRM_GeneralProjectInformation();
            fRM_GeniralProjectInformation.Show();
        }

        private void sbShowProjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_Show_All_Projects fRM_Show_All_Projects = new FRM_Show_All_Projects();
            fRM_Show_All_Projects.Show();
        }

        private void FRM_BasicProjectData_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}