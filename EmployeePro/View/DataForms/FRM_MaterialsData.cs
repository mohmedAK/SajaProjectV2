using DevExpress.Data.Filtering.Helpers;
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
    public partial class FRM_MaterialsData : DevExpress.XtraEditors.XtraForm
    {
        CmdMaterialData cmdMaterialData = new CmdMaterialData();
        CmdWorkItem cmdWorkItem = new CmdWorkItem();

        private int _projectId;
      
        public FRM_MaterialsData(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            Cursor.Current = Cursors.WaitCursor;
            //get work items
            gcMaterialData.DataSource = cmdMaterialData.GetAllMaterialData(_projectId);

            SetComboBoxProperties();
            Cursor.Current = Cursors.Default;
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

            cbWorkItem.Properties.Items.AddRange(workItems.Where(x => x.contract == false).Select(x => x.Items).ToList());

        }
        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
            {
                XtraMessageBox.Show("Please fill all fields");
                return;
            }
            AddMaterialData();

            cbWorkItem.Text = string.Empty;
            cbMaterial.Text = string.Empty;
            txtDetails.Text = string.Empty;
            spPlanningQuntity.Value = 0;
            cbUnit.Text = string.Empty;
            spPrice.Value = 0;

        }

        private void AddMaterialData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var materialData = new CLS_MaterialData
                {
                    Id = cmdMaterialData.GetNewId(),
                    WorkItem = cbWorkItem.Text,
                    MaterialName = cbMaterial.Text,
                    PlanningQuantity = Convert.ToInt32(spPlanningQuntity.Text),
                    Unit = cbUnit.Text,
                    Price = Convert.ToDouble(spPrice.Value),
                    Details = txtDetails.Text,
                    ProjectIdFk = _projectId
                };

                cmdMaterialData.AddMaterialData(materialData);
                gcMaterialData.DataSource = cmdMaterialData.GetAllMaterialData(_projectId);
                Cursor.Current = Cursors.Default;
            }
        }

        
        private bool IsEmpty()
        {
            if ((string.IsNullOrEmpty(cbWorkItem.Text) ||
                string.IsNullOrEmpty(txtDetails.Text) ||
                string.IsNullOrEmpty(spPlanningQuntity.Text) ||
                string.IsNullOrEmpty(cbUnit.Text) ||
                string.IsNullOrEmpty(spPrice.Text))  )
            {
                return true;
            }



            return false;

        }

        private void cbMaterial_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cbMaterial.Text == "اخرى")
            //{
            //    txtNewMaterial.Enabled = true;
            //    return;
            //}
            //txtNewMaterial.Enabled = false;
        
        }

     

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvMaterialData.FocusedRowHandle;
            int id = Convert.ToInt32(gvMaterialData.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    cmdMaterialData.RemoveMaterialData(id);
                    gvMaterialData.DeleteRow(rowHandle);
                    gvMaterialData.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvMaterialData.DeleteRow(rowHandle);
                    gvMaterialData.RefreshData();
                }
            }
        }

        private void FRM_MaterialsData_FormClosing(object sender, FormClosingEventArgs e)
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