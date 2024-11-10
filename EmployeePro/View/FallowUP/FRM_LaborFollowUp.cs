using DevExpress.Utils.Html.Internal;
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
    public partial class FRM_LaborFollowUp : DevExpress.XtraEditors.XtraForm
    {
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        CmdLaborDate cmdLaborDate = new CmdLaborDate();
        CmdLaborFallow cmdLaborFallow = new CmdLaborFallow();
        int _projectId;
  
        public FRM_LaborFollowUp(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            Cursor.Current = Cursors.WaitCursor;
            var laborFallows = cmdLaborFallow.GetAllLaborFallow(_projectId);
            var laborDates = cmdLaborDate.GetAllLaborDate(_projectId);

            var combinedData = from fallow in laborFallows
                               join date in laborDates on fallow.LaborType equals date.LaborType
                               select new
                               {
                                   fallow.Id,
                                   fallow.WorkItem,
                                   fallow.LaborType,
                                   fallow.NumLabor,
                                   fallow.WorkDay,
                                   fallow.CurrentDate,
                                   fallow.ProjectIdFk,
                                   date.Wage
                               };

            gcLaborFallow.DataSource = combinedData.ToList();
            Cursor.Current = Cursors.Default;
            gridColumns();
            SetComboBoxProperties();
        }

        void gridColumns()
        {
            GridColumn totalPriceColumn = new GridColumn
            {
                Caption = "Total Price", // The text displayed in the column header
                UnboundType = DevExpress.Data.UnboundColumnType.Decimal, // The data type of the column
                Visible = true, // Make the column visible
                VisibleIndex = 3 // Position the column at the end
            };

            // Add the column to the GridView
            gvLaborFallow.Columns.Add(totalPriceColumn);

            // Set the field name for the unbound column
            totalPriceColumn.FieldName = "TotalPrice";
 
        }

        private void SetComboBoxProperties()
        {
            cbWorkItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbLaborType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // cbMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // cbUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
            if (workItems != null)
            {
                cbWorkItem.Properties.Items.AddRange(workItems.Where(x => x.contract == false).Select(x => x.Items).ToList());
            }
            

            List<CLS_LaborDate> laborTypes = cmdLaborDate.GetAllLaborDate(_projectId);
            if (laborTypes != null)
            {
                cbLaborType.Properties.Items.AddRange(laborTypes.Select(x => x.LaborType).ToList());
            }
           


        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            int rowHandle = gvLaborFallow.FocusedRowHandle;

            cbWorkItem.Text = Convert.ToString(gvLaborFallow.GetRowCellValue(rowHandle, "WorkItem"));
            cbLaborType.Text = Convert.ToString(gvLaborFallow.GetRowCellValue(rowHandle, "LaborType"));
            seNumOfLabor.Value = Convert.ToInt32(gvLaborFallow.GetRowCellValue(rowHandle, "NumLabor"));
            seWorkDay.Value = Convert.ToInt32(gvLaborFallow.GetRowCellValue(rowHandle, "WorkDay"));
            dtCurrent.Text = Convert.ToString(gvLaborFallow.GetRowCellValue(rowHandle, "CurrentDate"));
            btnSave.Text = "Update";
            
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvLaborFallow.FocusedRowHandle;
            int id = Convert.ToInt32(gvLaborFallow.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    cmdLaborFallow.RemoveLaborFallow(id);
                    gvLaborFallow.DeleteRow(rowHandle);
                    gvLaborFallow.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvLaborFallow.DeleteRow(rowHandle);
                    gvLaborFallow.RefreshData();
                }
            }
        }


        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(cbWorkItem.Text) ||
                string.IsNullOrEmpty(cbLaborType.Text) ||
                string.IsNullOrEmpty(seNumOfLabor.Text) ||
                string.IsNullOrEmpty(seWorkDay.Text) ||
                string.IsNullOrEmpty(dtCurrent.Text))
            {
                return true;
            }
            return false;
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
                var itemData = new CLS_LaborFallow
                {
                    Id = Convert.ToInt32(gvLaborFallow.GetRowCellValue(gvLaborFallow.FocusedRowHandle, "Id")),
                    WorkItem = cbWorkItem.Text,
                    LaborType = cbLaborType.Text,
                    NumLabor = Convert.ToInt32(seNumOfLabor.Text),
                    WorkDay = Convert.ToInt32(seWorkDay.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId
                };


                cmdLaborFallow.EditLaborFallow(itemData);
                gcLaborFallow.DataSource = cmdLaborFallow.GetAllLaborFallow(_projectId);
                btnSave.Text = "Save";
                Cursor.Current = Cursors.Default;

            }
            else
            {

                AddLaborFallowlData();
            }


            cbWorkItem.Text = string.Empty;
            cbLaborType.Text = string.Empty;
            seNumOfLabor.Value = 0;
            seWorkDay.Text = string.Empty;
            dtCurrent.Text = string.Empty;
            
        }

        private void AddLaborFallowlData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_LaborFallow
                {
                    Id = cmdLaborFallow.GetNewId(),
                    WorkItem = cbWorkItem.Text,
                    LaborType = cbLaborType.Text,
                    NumLabor = Convert.ToInt32(seNumOfLabor.Text),
                    WorkDay = Convert.ToInt32(seWorkDay.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId
                };
                

                cmdLaborFallow.AddLaborFallow(itemData);
               
                var laborFallows = cmdLaborFallow.GetAllLaborFallow(_projectId);
                var laborDates = cmdLaborDate.GetAllLaborDate(_projectId);

                var combinedData = from fallow in laborFallows
                                   join date in laborDates on fallow.LaborType equals date.LaborType
                                   select new
                                   {
                                       fallow.Id,
                                       fallow.WorkItem,
                                       fallow.LaborType,
                                       fallow.NumLabor,
                                       fallow.WorkDay,
                                       fallow.CurrentDate,
                                       fallow.ProjectIdFk,
                                       date.Wage
                                   };

                gcLaborFallow.DataSource = combinedData.ToList();
                Cursor.Current = Cursors.Default;
               
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }

        private void FRM_LaborFollowUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }

        private void gvLaborFallow_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "TotalPrice" && e.IsGetData)
            {
                // Get the price and quantity from the data source
                var Wage = Convert.ToDouble(gvLaborFallow.GetListSourceRowCellValue(e.ListSourceRowIndex, "Wage"));
                var NumLabor = Convert.ToInt32(gvLaborFallow.GetListSourceRowCellValue(e.ListSourceRowIndex, "NumLabor"));

                // Calculate the total price
                e.Value = Wage * NumLabor;
            }
        }
    }
}