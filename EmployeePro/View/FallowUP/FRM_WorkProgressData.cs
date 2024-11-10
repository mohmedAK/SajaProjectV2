using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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
    public partial class FRM_WorkProgressData : DevExpress.XtraEditors.XtraForm
    {
 
        CmdWorkProgressFallow cmdWorkProgressFallow = new CmdWorkProgressFallow();
        CmdProjectItemData cmdProjectItem = new CmdProjectItemData();
        CmdContract cmdContract = new CmdContract();
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        CmdLaborDate cmdLaborDate = new CmdLaborDate();
        CmdLaborFallow cmdLaborFallow = new CmdLaborFallow();
        CmdMachineFallow cmdMachineFallow = new CmdMachineFallow();
        CmdMaterialData cmdMaterialData = new CmdMaterialData();
        int _projectId;
  
        List<CLS_Totals> totals;
        public FRM_WorkProgressData(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            Cursor.Current = Cursors.WaitCursor;
            totals =LoadProjectData();
            gcWorkProgressFallow.DataSource = cmdWorkProgressFallow.GetAllWorkProgressFallow(_projectId);


            List<CLS_ProjectItemData> projectItems = cmdProjectItem.GetAllProjectItems(_projectId);

            //var combinedData = from progress in workProgressFallows
            //                   join item in projectItems on progress.WorkItem equals item.WorkItem
            //                   select new
            //                   {
            //                       progress.Id,
            //                       progress.WorkItem,
            //                       progress.ActualQuantity,                                
            //                       progress.CurrentDate,
            //                       progress.ProjectIdFk,
            //                       item.Price,
            //                       item.PlanningQuantity,
            //                       item.Unit,
            //                       item.StartDate,
            //                       item.FinishDate,
            //                       item.Details
            //                   };

           
            gridColumns();
            SetComboBoxProperties();
            Cursor.Current = Cursors.Default;
        }
        private void SetComboBoxProperties()
        {
            cbWorkItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
            if (workItems != null)
            {
                cbWorkItem.Properties.Items.AddRange(workItems.Where(x => x.contract == false).Select(x => x.Items).ToList());
            }
        }


        void gridColumns()
        {
           


            GridColumn VaranceQColumn = new GridColumn
            {
                Caption = "Varance Q", // The text displayed in the column header
                UnboundType = DevExpress.Data.UnboundColumnType.Integer, // The data type of the column
                Visible = true, // Make the column visible
                VisibleIndex = 3 // Position the column at the end
            };

            // Add the column to the GridView
            gvWorkProgressFallow.Columns.Add(VaranceQColumn);

            // Set the field name for the unbound column
            VaranceQColumn.FieldName = "VaranceQ";

        }

        private void gvWorkProgressFallow_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

            if (e.Column.FieldName == "VaranceQ" && e.IsGetData)
            {
                // Get the price and quantity from the data source
                var PlanningQuantity = Convert.ToDouble(gvWorkProgressFallow.GetListSourceRowCellValue(e.ListSourceRowIndex, "PlaningQuantity"));
                var ActualQuantity = Convert.ToInt32(gvWorkProgressFallow.GetListSourceRowCellValue(e.ListSourceRowIndex, "ActualQuantity"));

                // Calculate the total price
                e.Value =   PlanningQuantity - ActualQuantity;
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
                var itemData = new CLS_WorkProgressFallow
                {
                    Id = Convert.ToInt32(gvWorkProgressFallow.GetRowCellValue(gvWorkProgressFallow.FocusedRowHandle, "Id")),
                    WorkItem = cbWorkItem.Text,
                    ActualQuantity = Convert.ToInt32(seActualQuntity.Text),
                    ActualDuration = Convert.ToDouble(seActualDuration.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId,
                    PlaningCost = Convert.ToDouble(sePlaningCost.Text),
                    PlaningDuration = Convert.ToDouble(sePlaningDuration.Text),
                    PlaningQuantity = Convert.ToInt32(sePlaningQuntity.Text),
                    A = Convert.ToDouble(seA.Value),
                    P = Convert.ToDouble(seP.Value),
                    ActualCost = Convert.ToDouble(seActualCost.Text)
                    
                };
                


                cmdWorkProgressFallow.EditWorkProgressFallow(itemData);
                gcWorkProgressFallow.DataSource = cmdWorkProgressFallow.GetAllWorkProgressFallow(_projectId);
                btnSave.Text = "Save";
                Cursor.Current = Cursors.Default;



            }
            else
            {
                AddWorkProgressData();
            }


            cbWorkItem.Text = string.Empty;
            seActualQuntity.Text = string.Empty;
            seActualCost.Text = string.Empty;
            dtCurrent.Text = string.Empty;
            sePlaningDuration.Text = string.Empty;
            seActualDuration.Text = string.Empty;
            sePlaningCost.Text = string.Empty;
            sePlaningQuntity.Text = string.Empty;
            seActualCost.Text = string.Empty;
            seActualQuntity.Text = string.Empty;
            seA.Value = 0;
            seP.Value = 0;
            seEV.Value = 0;
            sePV.Value = 0;
            seSPI.Value = 0;
            seCPI.Value = 0;
            seCSI.Value = 0;
        }

        private void AddWorkProgressData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_WorkProgressFallow
                {
                    WorkItem = cbWorkItem.Text,
                    ActualQuantity = Convert.ToInt32(seActualQuntity.Text),
                    ActualCost = Convert.ToDouble(seActualCost.Text),
                    ActualDuration = Convert.ToDouble(seActualDuration.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId,
                    PlaningCost = Convert.ToDouble(sePlaningCost.Text),
                    PlaningDuration = Convert.ToDouble(sePlaningDuration.Text),
                    PlaningQuantity = Convert.ToInt32(sePlaningQuntity.Text),
                    A = Convert.ToDouble(seA.Value),
                    P = Convert.ToDouble(seP.Value),
                };

                cmdWorkProgressFallow.AddWorkProgressFallow(itemData);
                gcWorkProgressFallow.DataSource = cmdWorkProgressFallow.GetAllWorkProgressFallow(_projectId);

                Cursor.Current = Cursors.Default;
            }
        }

    

        private void repEdit_Click(object sender, EventArgs e)
        {
            int rowHandle = gvWorkProgressFallow.FocusedRowHandle;
            cbWorkItem.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "WorkItem").ToString();
            seActualQuntity.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "ActualQuantity").ToString();
            seActualCost.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "ActualCost").ToString();
            dtCurrent.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "CurrentDate").ToString();
            sePlaningCost.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "PlaningCost").ToString();
            sePlaningDuration.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "PlaningDuration").ToString();
            seActualDuration.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "ActualDuration").ToString();
            sePlaningQuntity.Text = gvWorkProgressFallow.GetRowCellValue(rowHandle, "PlaningQuantity").ToString();
            seA.Value = Convert.ToDecimal(gvWorkProgressFallow.GetRowCellValue(rowHandle, "A"));
            seP.Value = Convert.ToDecimal(gvWorkProgressFallow.GetRowCellValue(rowHandle, "P"));

            btnSave.Text = "Update";


        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvWorkProgressFallow.FocusedRowHandle;
            int id = Convert.ToInt32(gvWorkProgressFallow.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    cmdWorkProgressFallow.RemoveWorkProgressFallow(id);
                    gvWorkProgressFallow.DeleteRow(rowHandle);
                    gvWorkProgressFallow.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvWorkProgressFallow.DeleteRow(rowHandle);
                    gvWorkProgressFallow.RefreshData();
                }
            }
        }

        private void cbWorkItem_SelectedValueChanged(object sender, EventArgs e)
        {
           
            string workItem = cbWorkItem.Text;

            double PlaningCost = totals.Where(x => x.WorkItem == workItem).Select(x => x.TotalCost).FirstOrDefault();

            sePlaningCost.Text = PlaningCost.ToString();


            List<CLS_ProjectItemData> itemData = cmdProjectItem.GetAllProjectDataWithWorkItem(_projectId, workItem);
            if (itemData != null)
            {
                sePlaningDuration.Text = itemData.Select(x => x.PlaningDuration).FirstOrDefault().ToString();
               
                sePlaningQuntity.Text = itemData.Select(x => x.PlanningQuantity).FirstOrDefault().ToString();

                seActualCost.Text = itemData.Select(x => x.Price).FirstOrDefault().ToString();             
            }

           
        }



        private List<CLS_Totals> LoadProjectData()
        {

            var laborFallows = cmdLaborFallow.GetAllLaborFallow(_projectId);
            var laborDates = cmdLaborDate.GetAllLaborDate(_projectId);
            var contracts = cmdContract.GetAllContracts(_projectId);
            var materialData = cmdMaterialData.GetAllMaterialData(_projectId);
            var machineFallows = cmdMachineFallow.GetAllMachineFallows(_projectId);
            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);

            var laborCombinedData = from fallow in laborFallows
                                    join date in laborDates on fallow.LaborType equals date.LaborType
                                    group new { fallow.WorkItem, TotalCost = fallow.NumLabor * date.Wage } by fallow.WorkItem into grouped
                                    select new
                                    {
                                        WorkItem = grouped.Key,
                                        TotalCost = grouped.Sum(x => x.TotalCost)
                                    };

            var contractWorkItemAndCost = contracts.Select(contract => new
            {
                contract.WorkItem,
                contract.ContractCost
            }).ToList();

            var laborWorkItemAndTotalCost = laborCombinedData.ToList();

            var machineWorkItemAndTotalCost = machineFallows.GroupBy(machineFallow => machineFallow.WorkItem)
                                                            .Select(group => new
                                                            {
                                                                WorkItem = group.Key,
                                                                TotalCost = group.Sum(machineFallow => machineFallow.TotalCost)
                                                            }).ToList();

            var materialWorkItemAndTotalCost = materialData.GroupBy(material => material.WorkItem)
                                                           .Select(group => new
                                                           {
                                                               WorkItem = group.Key,
                                                               TotalCost = group.Sum(material => material.TotalCost)
                                                           }).ToList();

            List<CLS_Totals> cLS_Totals = (from workItem in workItems
                                           join contract in contractWorkItemAndCost on workItem.Items equals contract.WorkItem into contractGroup
                                           from contract in contractGroup.DefaultIfEmpty()
                                           join labor in laborWorkItemAndTotalCost on workItem.Items equals labor.WorkItem into laborGroup
                                           from labor in laborGroup.DefaultIfEmpty()
                                           join machine in machineWorkItemAndTotalCost on workItem.Items equals machine.WorkItem into machineGroup
                                           from machine in machineGroup.DefaultIfEmpty()
                                           join material in materialWorkItemAndTotalCost on workItem.Items equals material.WorkItem into materialGroup
                                           from material in materialGroup.DefaultIfEmpty()
                                           select new CLS_Totals
                                           {
                                               WorkItem = workItem.Items,
                                               MaterialCost = material?.TotalCost ?? 0,
                                               MachineCost = machine?.TotalCost ?? 0,
                                               LaborCost = labor?.TotalCost ?? 0,
                                               ContractCost = double.TryParse(contract?.ContractCost, out double contractCost) ? contractCost : 0
                                           }).ToList();

            return cLS_Totals;
        }

        private void FRM_WorkProgressData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void seA_EditValueChanged(object sender, EventArgs e)
        {
            if (seA.Value != 0 && seP.Value != 0)
            {
                // Calculate EV and set the value of seEv
                seEV.Value = Convert.ToDecimal(Convert.ToDouble(seA.Value) * Convert.ToDouble(sePlaningCost.Value));

                // Calculate PV and set the value of seEv
                sePV.Value = Convert.ToDecimal(Convert.ToDouble(seP.Value) * Convert.ToDouble(sePlaningCost.Value));


                seSPI.Value = Convert.ToDecimal(seEV.Value / sePV.Value);

                seCPI.Value = Convert.ToDecimal(Convert.ToDouble(seEV.Value) / Convert.ToDouble(seActualCost.Value));

                seCSI.Value = Convert.ToDecimal(Convert.ToDouble(seSPI.Value) * Convert.ToDouble(seCPI.Value));
            }
        }

        private void seP_EditValueChanged(object sender, EventArgs e)
        {
            if (seA.Value != 0 && seP.Value != 0)
            {
                // Calculate EV and set the value of seEv
                seEV.Value = Convert.ToDecimal(Convert.ToDouble(seA.Value) * Convert.ToDouble(sePlaningCost.Value));

                // Calculate PV and set the value of seEv
                sePV.Value = Convert.ToDecimal(Convert.ToDouble(seP.Value) * Convert.ToDouble(sePlaningCost.Value));


                seSPI.Value = Convert.ToDecimal(seEV.Value / sePV.Value);

                seCPI.Value = Convert.ToDecimal(Convert.ToDouble(seEV.Value) / Convert.ToDouble(seActualCost.Value));

                seCSI.Value = Convert.ToDecimal(Convert.ToDouble(seSPI.Value) * Convert.ToDouble(seCPI.Value));
            }


        }

        private void seSPI_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

            

            if (seA.Value != 0 || sePlaningCost.Value != 0)
            {
                // Calculate EV and set the value of seEv
                seEV.Value = Convert.ToDecimal(Convert.ToDouble(seA.Value) * Convert.ToDouble(sePlaningCost.Value));

                // Calculate PV and set the value of seEv
                sePV.Value = Convert.ToDecimal(Convert.ToDouble(seP.Value) * Convert.ToDouble(sePlaningCost.Value));


                seSPI.Value = Convert.ToDecimal(seEV.Value / sePV.Value);

                seCPI.Value = Convert.ToDecimal(Convert.ToDouble(seEV.Value) / Convert.ToDouble(seActualCost.Value));

                seCSI.Value = Convert.ToDecimal(Convert.ToDouble(seSPI.Value) * Convert.ToDouble(seCPI.Value));
            }
            
        }

        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(cbWorkItem.Text) ||
                string.IsNullOrEmpty(seActualCost.Text) ||
                string.IsNullOrEmpty(seActualQuntity.Text) ||
                string.IsNullOrEmpty(dtCurrent.Text) 
               
               )
            {
                return true;
            }
            return false;
        }

    }
}