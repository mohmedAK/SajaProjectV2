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
    public partial class FRM_Project_Item_Data : DevExpress.XtraEditors.XtraForm
    {
        CmdProjectItemData cmdProjectItemData = new CmdProjectItemData();
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        int _projectId;
     
        public FRM_Project_Item_Data(int projectId  )
        {
            InitializeComponent();
            _projectId = projectId;

            Cursor.Current = Cursors.WaitCursor;
            gcItemData.DataSource = cmdProjectItemData.GetAllProjectItems(_projectId);
            //fill comboboxes
            SetComboBoxProperties();
            Cursor.Current = Cursors.Default;
        }


        private void SetComboBoxProperties()
        {
            cbWorkItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // cbMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
            if (workItems == null)
            {
                return;
            }
            cbWorkItem.Properties.Items.AddRange(workItems.Where(x => x.contract == false).Select(x => x.Items).ToList());

        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            int rowHandle = gvItemData.FocusedRowHandle;
      
            cbWorkItem.Text = Convert.ToString(gvItemData.GetRowCellValue(rowHandle, "WorkItem"));
            txtDetails.Text = Convert.ToString(gvItemData.GetRowCellValue(rowHandle, "Details"));
            spPlanningQuantity.Value = Convert.ToInt32(gvItemData.GetRowCellValue(rowHandle, "PlanningQuantity"));
            cbUnit.Text = Convert.ToString(gvItemData.GetRowCellValue(rowHandle, "Unit"));
            spPrice.Value = Convert.ToDecimal(gvItemData.GetRowCellValue(rowHandle, "Price"));
            dtStart.Text = Convert.ToString(gvItemData.GetRowCellValue(rowHandle, "StartDate"));
            dtFinsh.Text = Convert.ToString(gvItemData.GetRowCellValue(rowHandle, "FinishDate"));
            btnAddProjectItem.Text = "Update";
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvItemData.FocusedRowHandle;
            int id = Convert.ToInt32(gvItemData.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    cmdProjectItemData.RemoveProjectItem(id);
                    gvItemData.DeleteRow(rowHandle);
                    gvItemData.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvItemData.DeleteRow(rowHandle);
                    gvItemData.RefreshData();
                }
            }
        }

  

        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(cbWorkItem.Text) ||
                string.IsNullOrEmpty(spPlanningQuantity.Text)||
                string.IsNullOrEmpty(txtDetails.Text) ||
                string.IsNullOrEmpty(spPrice.Text) ||
                string.IsNullOrEmpty(cbUnit.Text) ||
                string.IsNullOrEmpty(dtStart.Text) || 
                string.IsNullOrEmpty(dtFinsh.Text))
            {
                return true;
            }
            return false;
        }


        private void AddMaterialData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_ProjectItemData
                {
                    Id = cmdProjectItemData.GetNewId(),
                    WorkItem = cbWorkItem.Text,
                    PlanningQuantity = Convert.ToInt32(spPlanningQuantity.Text),
                    Unit = cbUnit.Text,
                    Price = Convert.ToDouble(spPrice.Value),
                    Details = txtDetails.Text,
                    ProjectIdFk = _projectId,
                    FinishDate = dtFinsh.DateTime,
                    StartDate = dtStart.DateTime
                };

                cmdProjectItemData.AddProjectItem(itemData);
                gcItemData.DataSource = cmdProjectItemData.GetAllProjectItems(_projectId);

                Cursor.Current = Cursors.Default;
            }
        }

        private void btnAddProjectItem_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
            {
                XtraMessageBox.Show("Please fill all fields");
                return;
            }

            if(btnAddProjectItem.Text == "Update")
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_ProjectItemData
                {
                    Id = Convert.ToInt32(gvItemData.GetRowCellValue(gvItemData.FocusedRowHandle, "Id")),
                    WorkItem = cbWorkItem.Text,
                    PlanningQuantity = Convert.ToInt32(spPlanningQuantity.Text),
                    Unit = cbUnit.Text,
                    Price = Convert.ToDouble(spPrice.Value),
                    Details = txtDetails.Text,
                    ProjectIdFk = _projectId,
                    FinishDate = dtFinsh.DateTime,
                    StartDate = dtStart.DateTime
                };

                cmdProjectItemData.EditProjectItem(itemData);
                gcItemData.DataSource = cmdProjectItemData.GetAllProjectItems(_projectId);
                btnAddProjectItem.Text = "Add";
                Cursor.Current = Cursors.Default;
                return;
            }

            AddMaterialData();

            cbWorkItem.Text = string.Empty;
            txtDetails.Text = string.Empty;
            spPlanningQuantity.Value = 0;
            cbUnit.Text = string.Empty;
            spPrice.Value = 0;
            dtStart.Text = string.Empty;
            dtFinsh.Text = string.Empty;
        }

        private void sbBack_Click(object sender, EventArgs e)
        {
            Hide();
        new FRM_GeneralProjectInformation(_projectId, true).Show();
        }

        private void FRM_Project_Item_Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_GeneralProjectInformation(_projectId, true).Show();
        }
    }
}