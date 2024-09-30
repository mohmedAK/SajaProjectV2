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
using SajaProjectV2.Controller;
using SajaProjectV2.Model;
 

namespace SajaProjectV2.View.DataForms
{
    public partial class FRM_GeniralProjectInformation : DevExpress.XtraEditors.XtraForm
    {
        CmdProjectInformation CmdProjectInformation = new CmdProjectInformation();
        public FRM_GeniralProjectInformation()
        {
            InitializeComponent();
        }

        void AddProjectInfo()
        {
            CLS_ProjectInformation projectInformation = new CLS_ProjectInformation()
            {
                ProjectName = txtProjectName.Text,
                Value = txtValue.Text,
                Location = txtLocation.Text,
                OwnerName = txtOwnerName.Text,
                Penalties = txtPenalties.Text,
                Details = txtDetails.Text,
                StartDate = dtStart.DateTime,
                FinishDate = dtFinsh.DateTime,
            };
            CmdProjectInformation.AddProject(projectInformation);
        }




        private void sbContract_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_ContractingData fRM_ContractingData = new FRM_ContractingData();
            fRM_ContractingData.Show();
        }

        private void sbLabor_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_LaborData fRM_labor = new FRM_LaborData();
            fRM_labor.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_MachinesData fRM_MachinesData = new FRM_MachinesData();
            fRM_MachinesData.Show();
        }

        private void sbM_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_MaterialsData fRM_MaterialsData = new FRM_MaterialsData();
            fRM_MaterialsData.Show();
             
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_Project_Item_Data fRM_Project_Item = new FRM_Project_Item_Data();
            fRM_Project_Item.Show();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (checkIsNull())
            {
                XtraMessageBox.Show("Please Fill All Fields");
            }
            else
            {
                if(XtraMessageBox.Show("Are you sure from data ","Warining",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    AddProjectInfo();
                    enableButton(true);
                }
               
            }

        }


        void enableButton(bool flag)
        {
            if (flag)
            {
                this.sbLabor.Enabled = true;
                this.sbItemData.Enabled = true;
                this.sbMachinesData.Enabled = true;
                this.sbMaterial.Enabled = true;
                this.sbContract.Enabled = true;

                btnApply.Enabled = false;

                txtLocation.Enabled = false;
                txtOwnerName.Enabled = false;
                txtProjectName.Enabled = false;
                txtPenalties.Enabled = false;
                txtDetails.Enabled = false;
                txtValue.Enabled = false;
                dtFinsh.Enabled = false;
                dtStart.Enabled = false;


            }
            else
            {
                this.sbLabor.Enabled = false;
                this.sbItemData.Enabled = false;
                this.sbMachinesData.Enabled = false;
                this.sbMaterial.Enabled = false;
                this.sbContract.Enabled = false;

                btnApply.Enabled = true;
                txtLocation.Enabled = true;
                txtOwnerName.Enabled = true;
                txtProjectName.Enabled = true;
                txtPenalties.Enabled = true;
                txtDetails.Enabled = true;
                txtValue.Enabled = true;
                dtFinsh.Enabled = true;
                dtStart.Enabled = true;
            }
          
        }


        bool checkIsNull()
        {
            if (string.IsNullOrEmpty(txtLocation.Text) ||
                string.IsNullOrEmpty(txtOwnerName.Text) ||
                string.IsNullOrEmpty(txtProjectName.Text) ||
                string.IsNullOrEmpty(txtPenalties.Text) ||
                string.IsNullOrEmpty(txtDetails.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FRM_GeniralProjectInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sbBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_BasicProjectData fRM_BasicProjectData = new FRM_BasicProjectData();
            fRM_BasicProjectData.Show();
        }
    }
}