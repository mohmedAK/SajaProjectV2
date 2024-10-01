using DevExpress.XtraEditors;
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

namespace SajaProjectV2.View.DataForms
{
    public partial class FRM_ContractingData : DevExpress.XtraEditors.XtraForm
    {
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        CmdContract cmdContract = new CmdContract();
        private int _projectId;
        public FRM_ContractingData(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            gvWorkItem.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

         

        }

        private void gvWorkItem_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //Handle the InitNewRow event to initialize newly added rows. To initialize row cells use the SetRowCellValue method
      
                //GridView view = sender as GridView;
                //view.SetRowCellValue(e.RowHandle, view.Columns["RecordDate"], DateTime.Today); // Set the new row cell value
                //view.SetRowCellValue(e.RowHandle, view.Columns["Name"], "CustomName");
                //int newRowID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "ID")); // Obtain the new row cell value 
                //view.SetRowCellValue(e.RowHandle, view.Columns["Notes"], string.Format("Row ID: {0}", newRowID));
       
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            CLS_WorkItem workItem = new CLS_WorkItem()
            {
                Id = Convert.ToInt32(gvWorkItem.GetRowCellValue(gvWorkItem.FocusedRowHandle, "Id")),
                Item = gvWorkItem.GetRowCellValue(gvWorkItem.FocusedRowHandle, "Item").ToString(),
                ItemCost = Convert.ToDouble(gvWorkItem.GetRowCellValue(gvWorkItem.FocusedRowHandle, "ItemCost")),
                ContractIdFk = _projectId
            };
        }
    }
}