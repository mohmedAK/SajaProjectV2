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
    public partial class FRM_Show_All_Projects : DevExpress.XtraEditors.XtraForm
    {
        CmdProjectInformation cmdProjectInformation = new CmdProjectInformation();
        public FRM_Show_All_Projects()
        {
            InitializeComponent();

            List<CLS_ProjectInformation> projectsInformation = cmdProjectInformation.GetAllProjects();
            gcProjectInformation.DataSource = projectsInformation;
        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvProjectInformation.GetFocusedRowCellValue("Id"));
            FRM_GeneralProjectInformation frm = new FRM_GeneralProjectInformation(id);
            frm.ShowDialog();
            List<CLS_ProjectInformation> projectsInformation = cmdProjectInformation.GetAllProjects();
            gcProjectInformation.DataSource = projectsInformation;
        }

        private void repDelete_Click(object sender, EventArgs e)
        {

        }
    }
}