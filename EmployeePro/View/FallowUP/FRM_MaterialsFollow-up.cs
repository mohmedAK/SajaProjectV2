using DevExpress.Schedule;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FRM_MaterialsFollow_up : DevExpress.XtraEditors.XtraForm
    {
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
         CmdMaterialFallow cmdMaterialFallow = new CmdMaterialFallow();
        CmdMaterialData cmdMaterialData = new CmdMaterialData();
        int _projectId;
 
        public FRM_MaterialsFollow_up(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;

            Cursor.Current = Cursors.WaitCursor;
            gcMaterialFallow.DataSource = cmdMaterialFallow.GetAllMaterialFallow(_projectId);
            SetComboBoxProperties();
            Cursor.Current = Cursors.Default;

            //// Create a new column
            //GridColumn newColumn = new GridColumn
            //{
            //    Caption = "New Column", // The text displayed in the column header
            //    FieldName = "NewField", // The field name in the data source
            //    Visible = true, // Make the column visible
            //    VisibleIndex = gvMaterialFallow.Columns.Count // Position the column at the end
            //};

            //// Add the column to the GridView
            //gvMaterialFallow.Columns.Add(newColumn);

            //// Optionally, you can set additional properties
            //newColumn.OptionsColumn.AllowEdit = false; // Make the column read-only
            //newColumn.Width = 100; // Set the column width
        }

        private void SetComboBoxProperties()
        {
            cbWorkItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;          
            cbMaterialName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
           
            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);
            if (workItems != null)
            {

                cbWorkItem.Properties.Items.AddRange(workItems.Where(x => x.contract == false).Select(x => x.Items).ToList());
            }
        }

        private void cbWorkItem_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cbWorkItem_SelectedValueChanged(object sender, EventArgs e)
        {
            cbMaterialName.Properties.Items.Clear();
            seMaterialCost.Text = "";
            cbMaterialName.Text = "";
            string workItem = cbWorkItem.Text;
            List<CLS_MaterialData> materialData = cmdMaterialData.GetAllMaterialDataWithWorkItem(_projectId, workItem);
            if (materialData != null)
            {
                cbMaterialName.Properties.Items.Clear();
                cbMaterialName.Properties.Items.AddRange(materialData.Select(x => x.MaterialName).ToList());
            }
            
        }

        private void cbMaterialName_SelectedValueChanged(object sender, EventArgs e)
        {
            seMaterialCost.Text = "";
            string workItem = cbWorkItem.Text;
            List<CLS_MaterialData> materialData = cmdMaterialData.GetAllMaterialDataWithWorkItem(_projectId, workItem);
            if (materialData != null)
            {

                CLS_MaterialData material = materialData.Where(x => x.MaterialName == cbMaterialName.Text).FirstOrDefault();
                if (material != null)
                {
                    seMaterialCost.Text = material.Price.ToString();                 
                }
            }
        }


        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(cbWorkItem.Text) ||
                string.IsNullOrEmpty(cbMaterialName.Text) ||
                string.IsNullOrEmpty(seMaterialCost.Text) ||
                string.IsNullOrEmpty(seActualQuntity.Text) ||
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
                var itemData = new CLS_MaterialFallow
                {
                    Id = Convert.ToInt32(gvMaterialFallow.GetRowCellValue(gvMaterialFallow.FocusedRowHandle, "Id")),
                    WorkItem = cbWorkItem.Text,
                    MaterialName = cbMaterialName.Text,
                    ActualQuantity = Convert.ToInt32(seActualQuntity.Text),
                    MaterialCost = Convert.ToDouble(seMaterialCost.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId
                };
                


                cmdMaterialFallow.EditMaterialFallow(itemData);
                gcMaterialFallow.DataSource = cmdMaterialFallow.GetAllMaterialFallow(_projectId);
                btnSave.Text = "Save";
                Cursor.Current = Cursors.Default;
            }
            else
            {
                AddMaterialFallowlData();
            }


            cbWorkItem.Text = string.Empty;
            cbMaterialName.Text = string.Empty;
            seActualQuntity.Value = 0;
            seMaterialCost.Text = string.Empty;
            dtCurrent.Text = string.Empty;
        }


        private void AddMaterialFallowlData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var itemData = new CLS_MaterialFallow
                {
                    Id = cmdMaterialFallow.GetNewId(),
                    WorkItem = cbWorkItem.Text,
                    MaterialName = cbMaterialName.Text,
                    ActualQuantity = Convert.ToInt32(seActualQuntity.Text),
                    MaterialCost = Convert.ToDouble(seMaterialCost.Text),
                    CurrentDate = dtCurrent.DateTime,
                    ProjectIdFk = _projectId
                };
                cmdMaterialFallow.AddMaterialFallow(itemData);
                gcMaterialFallow.DataSource = cmdMaterialFallow.GetAllMaterialFallow(_projectId);
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            int rowHandle = gvMaterialFallow.FocusedRowHandle;
            cbWorkItem.Text = gvMaterialFallow.GetRowCellValue(rowHandle, "WorkItem").ToString();
            cbMaterialName.Text = gvMaterialFallow.GetRowCellValue(rowHandle, "MaterialName").ToString();
            seActualQuntity.Text = gvMaterialFallow.GetRowCellValue(rowHandle, "ActualQuantity").ToString();
            seMaterialCost.Text = gvMaterialFallow.GetRowCellValue(rowHandle, "MaterialCost").ToString();
            dtCurrent.Text = gvMaterialFallow.GetRowCellValue(rowHandle, "CurrentDate").ToString();
            btnSave.Text = "Update";


        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvMaterialFallow.FocusedRowHandle;
            int id = Convert.ToInt32(gvMaterialFallow.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    cmdMaterialFallow.RemoveMaterialFallow(id);
                    gvMaterialFallow.DeleteRow(rowHandle);
                    gvMaterialFallow.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvMaterialFallow.DeleteRow(rowHandle);
                    gvMaterialFallow.RefreshData();
                }
            }
        }

        private void FRM_MaterialsFollow_up_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_FollowUp_Menu(_projectId).Show();
        }
    }
}