using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SajaProjectV2.Controller;
using SajaProjectV2.Model;

namespace SajaProjectV2.View.DataForms
{
    public partial class FRM_GeneralProjectInformation : XtraForm
    {
        private readonly CmdProjectInformation _cmdProjectInformation = new CmdProjectInformation();
        private bool _isUpdate;
        private int _projectId;

        public FRM_GeneralProjectInformation()
        {
            InitializeComponent();
            _isUpdate = false;

            this._projectId =  _cmdProjectInformation.getNewId();
        }

        public FRM_GeneralProjectInformation(int projectId) : this()
        {
            _isUpdate = true;
            _projectId = projectId;
            RetrieveData(projectId);
            EnableButton(true);
            btnApply.Text = "Update";
        }

        private void RetrieveData(int id)
        {
            var projects = _cmdProjectInformation.GetProjectById(id);
            if (projects != null && projects.Count > 0 && projects[0] != null)
            {
                var project = projects[0];
                txtDetails.Text = project.Details ?? string.Empty;
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
            };
            _cmdProjectInformation.AddProject(projectInformation);
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
            new FRM_ContractingData(_projectId).ShowDialog();
        }

        private void sbLabor_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_LaborData().ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_MachinesData().ShowDialog();
        }

        private void sbM_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_MaterialsData().ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_Project_Item_Data().ShowDialog();
        }

        private void EnableButton(bool flag)
        {
            var controls = new[] { sbLabor, sbItemData, sbMachinesData, sbMaterial, sbContract, btnApply };
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

        private void FRM_GeniralProjectInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sbBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_BasicProjectData().Show();
        }
    }
}