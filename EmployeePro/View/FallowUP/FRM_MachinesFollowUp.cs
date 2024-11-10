using DevExpress.XtraEditors;
using Mysqlx.Crud;
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

namespace SajaProjectV2.View.FallowUP
{
    
    public partial class FRM_MachinesFollowUp : DevExpress.XtraEditors.XtraForm
    {
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        CmdMachineFallow cmdMachineFallow = new CmdMachineFallow();
        CmdMachineData cmdMachineData = new CmdMachineData();
        int _projectId;
  
        public FRM_MachinesFollowUp(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            Cursor.Current = Cursors.WaitCursor;
            gcMachineFallow.DataSource = cmdMachineFallow.GetAllMachineFallows(_projectId);
          
            SetComboBoxProperties();
            Cursor.Current = Cursors.Default;
        }

        private void SetComboBoxProperties()
        {
            cbWorkItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbMachane.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbMachineNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
            if (workItems != null)
            {
                cbWorkItem.Properties.Items.AddRange(workItems.Where(x => x.contract == false).Select(x => x.Items).ToList());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
            {
                XtraMessageBox.Show("Please fill all fields");
                return;
            }

            if (btnSave.Text == "Update")
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_MachineFallow
                {
                    Id = Convert.ToInt32(gvMachineFallow.GetRowCellValue(gvMachineFallow.FocusedRowHandle, "Id")),
                    WorkItem = cbWorkItem.Text,
                    MachineName = cbMachane.Text,
                    MachineNumber = cbMachineNumber.Text,
                    OperationDays = Convert.ToInt32(seOperationOfDay.Text),
                    OperationPrice = Convert.ToDouble(seWageOperation.Text),
                    RentDays = Convert.ToInt32(seRentOfDays.Text),
                    RentPrice = Convert.ToDouble(seWageRent.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId
                };
                 


                cmdMachineFallow.EditMachineFallow(itemData);
                gcMachineFallow.DataSource = cmdMachineFallow.GetAllMachineFallows(_projectId);
                btnSave.Text = "Save";

                Cursor.Current = Cursors.Default;

            }
            else
            {
                AddMachineFallowlData();
            }


            cbWorkItem.Text = string.Empty;
            cbMachane.Text = string.Empty;
            cbMachineNumber.Text = string.Empty;
            seOperationOfDay.Text = string.Empty;
            seRentOfDays.Text = string.Empty;
            seWageOperation.Text = string.Empty;
            seWageRent.Text = string.Empty;
            dtCurrent.Text = string.Empty;
        }

        private void AddMachineFallowlData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_MachineFallow
                {
                    Id = cmdMachineFallow.getNewId(),
                    WorkItem = cbWorkItem.Text,
                    MachineName = cbMachane.Text,
                    MachineNumber = cbMachineNumber.Text,
                    OperationDays = Convert.ToInt32(seOperationOfDay.Text),
                    OperationPrice = Convert.ToDouble(seWageOperation.Text),
                    RentDays = Convert.ToInt32(seRentOfDays.Text),
                    RentPrice = Convert.ToDouble(seWageRent.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId
                };
                
                cmdMachineFallow.AddMachineFallow(itemData);
                gcMachineFallow.DataSource = cmdMachineFallow.GetAllMachineFallows(_projectId);
                Cursor.Current = Cursors.Default;
            }
        }
        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(cbWorkItem.Text) ||
                string.IsNullOrEmpty(cbMachane.Text) ||
                string.IsNullOrEmpty(seOperationOfDay.Text) ||
                string.IsNullOrEmpty(seWageOperation.Text) ||
                string.IsNullOrEmpty(dtCurrent.Text)||
                string.IsNullOrEmpty(seRentOfDays.Text)||
                string.IsNullOrEmpty(seWageRent.Text))
            {
                return true;
            }
            return false;
        }

        private void cbWorkItem_SelectedValueChanged(object sender, EventArgs e)
        {
            cbMachane.Properties.Items.Clear();
            seWageRent.Text = "";
            seWageOperation.Text = "";
            cbMachane.Text = "";
            string workItem = cbWorkItem.Text;
            List<CLS_MachineData> materialData = cmdMachineData.GetAllMachineData(_projectId);
            if (materialData != null)
            {
                cbMachane.Properties.Items.Clear();
                cbMachineNumber.Properties.Items.Clear();
                cbMachane.Properties.Items.AddRange(materialData.Select(x => x.MachineName).ToList());
                cbMachineNumber.Properties.Items.AddRange(materialData.Select(x => x.MachineNumber).ToList());
               
            }
        }

        private void cbMachane_SelectedValueChanged(object sender, EventArgs e)
        {
            string machineName = cbMachane.Text;
            string machineNumber = cbMachineNumber.Text;
            List<CLS_MachineData> machineData = cmdMachineData.GetAllMachineData(_projectId);
            if (machineData != null)
            {
                // Filter the list based on a condition, for example, by MachineName
                var filteredMachineData = machineData.Where(x => x.MachineName == cbMachane.Text && x.MachineNumber ==cbMachineNumber.Text).FirstOrDefault();

                if (filteredMachineData != null)
                {
                    seWageRent.Text = filteredMachineData.WageMaintenance.ToString();
                    seWageOperation.Text = filteredMachineData.WageRent.ToString();

                    if (filteredMachineData.WageMaintenance == 0)
                    {
                        seOperationOfDay.Enabled = true;
                        seRentOfDays.Enabled = false;
                    }
                    else
                    {
                        seOperationOfDay.Enabled = false;
                        seRentOfDays.Enabled = true;

                    }
                }

               
            }
        }

        private void cbMachineNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            string machineName = cbMachane.Text;
            string machineNumber = cbMachineNumber.Text;
            List<CLS_MachineData> machineData = cmdMachineData.GetAllMachineData(_projectId);
            if (machineData != null)
            {
                // Filter the list based on a condition, for example, by MachineName
                var filteredMachineData = machineData.Where(x => x.MachineName == cbMachane.Text && x.MachineNumber == cbMachineNumber.Text).FirstOrDefault();

                if (filteredMachineData != null)
                {
                    seWageRent.Text = filteredMachineData.WageMaintenance.ToString();
                    seWageOperation.Text = filteredMachineData.WageRent.ToString();

                    if (filteredMachineData.WageMaintenance == 0)
                    {
                        seOperationOfDay.Enabled = true;
                        seRentOfDays.Enabled = false;
                    }
                    else
                    {
                        seOperationOfDay.Enabled = false;
                        seRentOfDays.Enabled = true;
                       
                    }
                }

               
            }




        }

        private void FRM_MachinesFollowUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            
            int rowHandle = gvMachineFallow.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                cbWorkItem.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "WorkItem"));
                cbMachane.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "MachineName"));
                cbMachineNumber.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "MachineNumber"));
                seOperationOfDay.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "OperationDays"));
                seWageOperation.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "OperationPrice"));
                seRentOfDays.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "RentDays"));
                seWageRent.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "RentPrice"));
                dtCurrent.Text = Convert.ToString(gvMachineFallow.GetRowCellValue(rowHandle, "CurrentDate"));
                btnSave.Text = "Update";
            }

        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvMachineFallow.FocusedRowHandle;
            int id = Convert.ToInt32(gvMachineFallow.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    cmdMachineFallow.RemoveMachineFallow(id);
                    gvMachineFallow.DeleteRow(rowHandle);
                    gvMachineFallow.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvMachineFallow.DeleteRow(rowHandle);
                    gvMachineFallow.RefreshData();
                }
            }
        }
    }
}