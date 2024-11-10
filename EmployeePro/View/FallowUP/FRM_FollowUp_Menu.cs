using DevExpress.XtraEditors;
using SajaProjectV2.Controller;
using SajaProjectV2.View.DataForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SajaProjectV2.View.FallowUP
{
    public partial class FRM_FollowUp_Menu : DevExpress.XtraEditors.XtraForm
    {
        CmdProjectInformation _cmdProjectInformation = new CmdProjectInformation();
        int _projectId;
    
        public FRM_FollowUp_Menu(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
     
            RetrieveData(projectId);
        }

        private void RetrieveData(int id)
        {
            Cursor.Current = Cursors.WaitCursor;
            var projects = _cmdProjectInformation.GetProjectById(id);
            Cursor.Current = Cursors.Default;
            if (projects != null && projects.Count > 0 && projects[0] != null)
            {
                var project = projects[0];
                txtDetails.Text = Convert.ToString(project.Details) ?? string.Empty;
                txtLocation.Text = project.Location ?? string.Empty;
                txtOwnerName.Text = project.OwnerName ?? string.Empty;
                txtPenalties.Text = project.Penalties ?? string.Empty;
                txtValue.Text = project.Value ?? string.Empty;
                txtProjectName.Text = project.ProjectName ?? string.Empty;
                dtStart.Text = project.StartDate.ToString();
                dtFinsh.Text = project.FinishDate.ToString();
            }
            else
            {
                XtraMessageBox.Show("Project information could not be retrieved.");
            }
        }

        private void sbMaterial_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_MaterialsFollow_up(_projectId).Show();
        }

        private void sbLabor_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_LaborFollowUp(_projectId).Show();
        }

        private void sbMachinesData_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_MachinesFollowUp(_projectId).Show();
        }

        private void sbItemData_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_WorkProgressData(_projectId).Show();
        }

        private void sbBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_Show_All_Projects().Show();
        }
    }
}