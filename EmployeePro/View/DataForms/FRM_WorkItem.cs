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
  
    public partial class FRM_WorkItem : DevExpress.XtraEditors.XtraForm
    {
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        private int _projectId;
     
        public FRM_WorkItem(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;

            Cursor.Current = Cursors.WaitCursor;
            List<CLS_WorkItem> workItems = cmdWorkItem.GetWorkItemsById(_projectId);
            gcWorkItem.DataSource = workItems;
            Cursor.Current = Cursors.Default;
        }

        private void btnAddWorkItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem.Text) || string.IsNullOrEmpty(txtItemCost.Text))
            {
                XtraMessageBox.Show("Please Fill Item and Item Cost Fields", "Notice");
                return;
            }
            //change mouse to reload
          
            AddWorkItemData();

            txtItem.Text = "";
            txtItemCost.Text = "";

           
        }

        private void AddWorkItemData()
        {
            if (XtraMessageBox.Show("Are you sure from Work Items", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
             Cursor.Current = Cursors.WaitCursor;

                var laborData = new CLS_WorkItem
                {
                    Id = cmdWorkItem.GetNewId(),
                    Items = txtItem.Text,
                    ItemCost = Convert.ToDouble(txtItemCost.Text),
                    ProjectIdFk = _projectId
                };
                cmdWorkItem.AddWorkItem(laborData);

                List<CLS_WorkItem> laborDates = cmdWorkItem.GetAllWorkItems(_projectId);
                gcWorkItem.DataSource = laborDates;
                Cursor.Current = Cursors.Default;
            }
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvWorkItem.FocusedRowHandle;
            int workItemId = Convert.ToInt32(gvWorkItem.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (workItemId != 0)
                {
                    cmdWorkItem.RemoveWorkItem(workItemId);
                    gvWorkItem.DeleteRow(rowHandle);
                    gvWorkItem.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvWorkItem.DeleteRow(rowHandle);
                    gvWorkItem.RefreshData();
                }
            }
        }

        private void FRM_WorkItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_GeneralProjectInformation(_projectId, true).Show();
        }

        private void sbBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_GeneralProjectInformation(_projectId, true).Show();

        }
    }
}