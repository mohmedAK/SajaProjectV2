using DevExpress.XtraEditors;
using SajaProjectV2.Controller;
using SajaProjectV2.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SajaProjectV2.View.DataForms
{
    public partial class FRM_GeneralProjectInformation : XtraForm
    {
        private readonly CmdProjectInformation _cmdProjectInformation = new CmdProjectInformation();
        private bool _isUpdate;
        private int _projectId;
    


        public FRM_GeneralProjectInformation( int projectId=0 ,bool is_update =false) 
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            if (is_update)
            {
                _isUpdate = is_update;
                _projectId = projectId;
             
                RetrieveData(projectId);
                EnableButton(true);
                btnApply.Text = "Update";
                return;
            }

            _projectId = _cmdProjectInformation.getNewId();
            _isUpdate = is_update;
            Cursor.Current = Cursors.Default;
        }

        private void RetrieveData(int id)
        {
            var projects = _cmdProjectInformation.GetProjectById(id);
            if (projects != null && projects.Count > 0 && projects[0] != null)
            {
                var project = projects[0];
                txtDetails.Text =Convert.ToString( project.Details) ?? string.Empty;
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

        private void AddProjectInfo()
        {
            Cursor.Current = Cursors.WaitCursor;
            var projectInformation = new CLS_ProjectInformation
            {
                Id = _cmdProjectInformation.getNewId(),
                ProjectName = txtProjectName.Text,
                Value = txtValue.Text,
                Location = txtLocation.Text,
                OwnerName = txtOwnerName.Text,
                Penalties = txtPenalties.Text,
                Details = txtDetails.Text,
                StartDate = dtStart.DateTime,
                FinishDate = dtFinsh.DateTime,
                userIdFk = CLS_UsereSession.userId
            };
            _cmdProjectInformation.AddProject(projectInformation);
            Cursor.Current = Cursors.Default;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (CheckIsNull())
            {
                XtraMessageBox.Show("Please Fill All Fields");
                return;
            }

            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_isUpdate)
                {
                    var projectInformation = new CLS_ProjectInformation
                    {
                        Id = _projectId,
                        ProjectName = txtProjectName.Text,
                        Value = txtValue.Text,
                        Location = txtLocation.Text,
                        OwnerName = txtOwnerName.Text,
                        Penalties = txtPenalties.Text,
                        Details = txtDetails.Text,
                        StartDate = dtStart.DateTime,
                        FinishDate = dtFinsh.DateTime,
                        userIdFk = CLS_UsereSession.userId
                    };
                    _cmdProjectInformation.EditProject(projectInformation);
                }
                else
                {
                    AddProjectInfo();
                }
                EnableButton(true);
            }
        }

        private void sbContract_Click(object sender, EventArgs e)
        {
            Hide();
            if (_isUpdate)
            {
                new FRM_ContractingData(_projectId,  true).Show();
            }
            else
            {
                new FRM_ContractingData(_projectId ).Show();
            }
           
        }

        private void sbLabor_Click(object sender, EventArgs e)
        {
           

            Hide();
            if (_isUpdate)
            {
                new FRM_LaborData(_projectId,  true).Show();
            }
            else
            {
                new FRM_LaborData(_projectId ).Show();
            }
        }

        private void sbM_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_MaterialsData(_projectId).Show();
        }

        private void sbMachinesData_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_MachinesData(_projectId).Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_Project_Item_Data(_projectId).Show();
        }

        private void EnableButton(bool flag)
        {
            var controls = new[] { sbLabor, sbItemData, sbMachinesData, sbMaterial, sbContract, btnApply,btnWorkItem };
            foreach (var control in controls)
            {
                control.Enabled = flag;
            }
        }

        private bool CheckIsNull()
        {
            var controlsToCheck = new[] {txtLocation, txtOwnerName, txtProjectName, txtPenalties, txtDetails, txtValue, dtFinsh, dtStart };
            return controlsToCheck.Any(control => string.IsNullOrEmpty(control?.Text));
        }

    

        private void sbBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_Show_All_Projects( ).Show();
        }

        private void FRM_GeneralProjectInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_Show_All_Projects( ).Show();
        }

        private void btnWorkItem_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_WorkItem(_projectId).Show();
        }
    }
}