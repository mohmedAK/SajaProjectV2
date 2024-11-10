using DevExpress.Utils.Html.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Export.Pdf;
using DevExpress.XtraScheduler.Printing.Native;
using SajaProjectV2.Controller;
using SajaProjectV2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SajaProjectV2.View.DataForms
{
    public partial class FRM_ContractingData : DevExpress.XtraEditors.XtraForm
    {
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        CmdContract cmdContract = new CmdContract();
        private int _projectId;
  
    
        private int _workItemId;
        private bool _isUpdate = false;
        public FRM_ContractingData(int projectId,  bool isUpdate = false)
        {
            InitializeComponent();

            _projectId = projectId;
         

            List<CLS_Contract> contractData = cmdContract.GetAllContracts(_projectId);
            gcContract.DataSource = contractData;

       
            SetComboBoxProperties();
        }

        private void SetComboBoxProperties()
        {
            cbWorkItem.Clear();
            cbWorkItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // cbMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
           // cbUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
            if (workItems == null)
            {
                return;
            }

            cbWorkItem.Properties.Items.AddRange(workItems.Where(x => x.contract == false) .Select(x => x.Items).ToList());

        }

        private void sbSaveContract_Click(object sender, EventArgs e)
        {

            if (CheckIsNull())
            {
                XtraMessageBox.Show("Please Fill All Fields");
                return;
            }
           
            if (btnSaveContract.Text == "Update")
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_Contract
                {
                    Id = Convert.ToInt32(gvContract.GetRowCellValue(gvContract.FocusedRowHandle, "Id")),
                    WorkItem = cbWorkItem.Text,
                    ContractorName = txtContractorName.Text,
                    CompanyName = txtCompanyName.Text,
                    StartDate = Convert.ToDateTime(dtStart.Text),
                    FinishDate = Convert.ToDateTime(dtFinsh.Text),
                    Details = txtDetails.Text,
                    ContractCost = txtContractCost.Text,
                    ProjectIdFk = _projectId


                };
                List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
                // Filter work items where Items equals a specific work item
                var workItemId = workItems.Where(x => x.Items == cbWorkItem.Text).Select(x => x.Id).FirstOrDefault();
                cmdWorkItem.UpdateContractFlag(workItemId,true);

                cmdContract.EditContract(itemData);
                gcContract.DataSource = cmdContract.GetAllContracts(_projectId);
                btnSaveContract.Text = "Save";
                cbWorkItem.Text = "";
                txtContractCost.Text = "";
                txtCompanyName.Text = "";
                txtContractorName.Text = "";
                txtDetails.Text = "";
                dtFinsh.Text = "";
                dtStart.Text = "";

                SetComboBoxProperties();
                Cursor.Current = Cursors.Default;
                return;
            }
            AddContractData();

            txtContractCost.Text = "";
            txtCompanyName.Text = "";
            txtContractorName.Text = "";
            txtDetails.Text = "";
            dtFinsh.Text = "";
            dtStart.Text = "";
            cbWorkItem.Text = "";
            SetComboBoxProperties();


        }




        private void AddContractData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var laborData = new CLS_Contract
                {
                    Id = cmdContract.GetNewId(),
                    WorkItem = cbWorkItem.Text,
                    ContractorName = txtContractorName.Text,
                    CompanyName = txtCompanyName.Text,
                    StartDate = Convert.ToDateTime(dtStart.Text),
                    FinishDate = Convert.ToDateTime(dtFinsh.Text),
                    ContractCost = txtContractCost.Text,
                    Details = txtDetails.Text,
                    ProjectIdFk = _projectId
                };
              

                cmdContract.AddContract(laborData);
                List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
                // Filter work items where Items equals a specific work item
                var workItemId = workItems.Where(x => x.Items == cbWorkItem.Text).Select(x => x.Id).FirstOrDefault();
                cmdWorkItem.UpdateContractFlag(workItemId, true);

                List<CLS_Contract> laborDates = cmdContract.GetAllContracts(_projectId);
                gcContract.DataSource = laborDates;
                Cursor.Current = Cursors.Default;
            }
        }


        private void btnAddWorkItem_Click(object sender, EventArgs e)
        {
           

            
        }

    

     

    






        //private void EnableButton(bool enable)
        //{
        //    txtCompanyName.Enabled = enable;
        //    txtContractorName.Enabled = enable;
        //    txtDetails.Enabled = enable;
        //    dtFinsh.Enabled = enable;
        //    dtStart.Enabled = enable;
        //    txtItem.Enabled = enable;
        //    txtItemCost.Enabled = enable;
        //    btnAddWorkItem.Enabled = enable;
        //    btnSaveContract.Enabled = enable;
        //}

        private bool CheckIsNull(bool is_update =false)
        {
           if(string.IsNullOrEmpty(txtCompanyName.Text) ||
                string.IsNullOrEmpty(txtContractorName.Text) || 
                string.IsNullOrEmpty(txtDetails.Text) ||
                string.IsNullOrEmpty(dtFinsh.Text) ||
                string.IsNullOrEmpty(dtStart.Text)||
                string.IsNullOrEmpty(txtContractCost.Text) )
            {
                return true;
            }
            return false;
        }

        private void sbBack_Click(object sender, EventArgs e)
        {
            Hide();
        new FRM_GeneralProjectInformation(_projectId, true).Show();
        }

        private void FRM_ContractingData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_GeneralProjectInformation(_projectId, true).Show();
        }

        private void repEditCon_Click(object sender, EventArgs e)
        {
            int rowHandle = gvContract.FocusedRowHandle;
            cbWorkItem.Text = gvContract.GetRowCellValue(rowHandle, "WorkItem").ToString();
            txtContractCost.Text = gvContract.GetRowCellValue(rowHandle, "ContractCost").ToString();
            txtCompanyName.Text = gvContract.GetRowCellValue(rowHandle, "CompanyName").ToString();
            txtContractorName.Text = gvContract.GetRowCellValue(rowHandle, "ContractorName").ToString();
            txtDetails.Text = gvContract.GetRowCellValue(rowHandle, "Details").ToString();
            dtFinsh.Text = gvContract.GetRowCellValue(rowHandle, "StartDate").ToString();
            dtStart.Text = gvContract.GetRowCellValue(rowHandle, "FinishDate").ToString();



            btnSaveContract.Text = "Update";

           
        }

        private void repDeleteCon_Click(object sender, EventArgs e)
        {
            int rowHandle = gvContract.FocusedRowHandle;
            int workItemId = Convert.ToInt32(gvContract.GetRowCellValue(rowHandle, "Id"));
            string workItem = Convert.ToString(gvContract.GetRowCellValue(rowHandle, "WorkItem"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (workItemId != 0)
                {
                    cmdContract.RemoveContract(workItemId);
                    gvContract.DeleteRow(rowHandle);
                    gvContract.RefreshData();

                    List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
                    // Filter work items where Items equals a specific work item
                    var work = workItems.Where(x => x.Items == workItem).Select(x => x.Id).FirstOrDefault();
                    cmdWorkItem.UpdateContractFlag(work,false);

                    SetComboBoxProperties();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvContract.DeleteRow(rowHandle);
                    gvContract.RefreshData();
                }
            }
        }
    }
}
