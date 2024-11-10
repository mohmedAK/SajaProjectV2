using DevExpress.Utils.Html.Internal;
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
    public partial class FRM_MachinesData : DevExpress.XtraEditors.XtraForm
    {
        CmdMachineData cmdMachineData = new CmdMachineData();
        int _projectId;
     
        public FRM_MachinesData(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;

            Cursor.Current = Cursors.WaitCursor;
            SetComboBoxProperties();
            gcMachineData.DataSource = cmdMachineData.GetAllMachineData(_projectId);
            Cursor.Current = Cursors.Default;
        }

        private void SetComboBoxProperties()
        {
            cbOwnerShip.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
            {
                XtraMessageBox.Show("Please fill all fields");
                return;
            }

            if(btnAddMachine.Text == "Update")
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_MachineData
                {
                    Id = Convert.ToInt32(gvMachineData.GetRowCellValue(gvMachineData.FocusedRowHandle, "Id")),
                    MachineName = txtMachine.Text,
                    MachineNumber = txtMachineNumber.Text,
                    WageRent = Convert.ToDouble(sbWageRent.Value),
                    WageMaintenance = Convert.ToDouble(sbWageOperation.Value),
                    ProjectIdFk = _projectId,
                };
                cmdMachineData.EditMachineData(itemData);
                gcMachineData.DataSource = cmdMachineData.GetAllMachineData(_projectId);
                btnAddMachine.Text = "Save And Add Machine";
                txtMachine.Text = string.Empty;
                txtMachine.Text = string.Empty;
                cbOwnerShip.Text = string.Empty;
                txtMachineNumber.Text = string.Empty;
                sbWageOperation.Value = 0;
                sbWageRent.Text = string.Empty;
                sbWageRent.Enabled = false;
                sbWageOperation.Enabled = false;
                Cursor.Current = Cursors.Default;
                return;
            }
            AddMaterialData();

            txtMachine.Text = string.Empty;
            txtMachine.Text = string.Empty;
            cbOwnerShip.Text = string.Empty;
            txtMachineNumber.Text = string.Empty;
            sbWageOperation.Value = 0;
            sbWageRent.Text = string.Empty;
            sbWageRent.Enabled = false;
            sbWageOperation.Enabled = false;
         
        }

        private void AddMaterialData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var machine = new CLS_MachineData
                {
                    Id = cmdMachineData.GetNewId(),
                    MachineName = txtMachine.Text,
                    MachineNumber = txtMachineNumber.Text,
                    WageRent = Convert.ToDouble(sbWageRent.Value),
                    WageMaintenance = Convert.ToDouble(sbWageOperation.Value),
                    ProjectIdFk = _projectId
                };
               

                cmdMachineData.AddMachineData(machine);
                gcMachineData.DataSource = cmdMachineData.GetAllMachineData(_projectId);
                Cursor.Current = Cursors.Default;
            }
        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            int rowHandle = gvMachineData.FocusedRowHandle;
            txtMachine.Text = gvMachineData.GetRowCellValue(rowHandle, "MachineName").ToString();
            txtMachineNumber.Text = gvMachineData.GetRowCellValue(rowHandle, "MachineNumber").ToString();
            sbWageRent.Text = gvMachineData.GetRowCellValue(rowHandle, "WageRent").ToString();
            sbWageOperation.Text = gvMachineData.GetRowCellValue(rowHandle, "WageMaintenance").ToString();
          
            btnAddMachine.Text = "Update";

            if(sbWageOperation.Text != "0")
            {
                sbWageOperation.Enabled = true;
                sbWageRent.Enabled = false;
                cbOwnerShip.SelectedItem = "Own";
            }
            else
            {
                sbWageRent.Enabled = true;
                sbWageOperation.Enabled = false;
                cbOwnerShip.SelectedItem = "Rent";
            }
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvMachineData.FocusedRowHandle;
            int id = Convert.ToInt32(gvMachineData.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    cmdMachineData.RemoveMachineData(id);
                    gvMachineData.DeleteRow(rowHandle);
                    gvMachineData.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvMachineData.DeleteRow(rowHandle);
                    gvMachineData.RefreshData();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_GeneralProjectInformation(_projectId,  true).Show();
        }

        private void FRM_MachinesData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_GeneralProjectInformation(_projectId,  true).Show();
        }

        private bool IsEmpty()
        {
            if ((string.IsNullOrEmpty(txtMachine.Text) ||
                string.IsNullOrEmpty(txtMachineNumber.Text) ||
                string.IsNullOrEmpty(cbOwnerShip.Text) )         
                ) 
            {
                return true;
            }
            return false;

        }

        private void cbOwnerShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOwnerShip.Text == "Rent" && !string.IsNullOrEmpty(sbWageRent.Text))
            {
                sbWageRent.Enabled = true;
                sbWageOperation.Enabled = false;
                sbWageOperation.Text = "0";

            }

            if (cbOwnerShip.Text == "Own" && !string.IsNullOrEmpty(sbWageOperation.Text))
            {
                sbWageOperation.Enabled = true;
                sbWageRent.Enabled = false;
                sbWageRent.Text = "0";
            }    
        }
    }
}