using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using SajaProjectV2.Controller;
using SajaProjectV2.Model;
using SajaProjectV2.View.FallowUP;
using SajaProjectV2.View.Reports;
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
    public partial class FRM_Show_All_Projects : DevExpress.XtraEditors.XtraForm
    {
        CmdProjectInformation cmdProjectInformation = new CmdProjectInformation();
 //
        public FRM_Show_All_Projects()
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            if (CLS_UsereSession.Role == "Admin" || CLS_UsereSession.Role == "SuperAdmin")
            {
                // Step 1: Get the data from the query
                var projectsInformation = cmdProjectInformation.GetAllProjects(CLS_UsereSession.userId);

                // Step 2: Bind the result to the GridControl
                gcProjectInformation.DataSource = projectsInformation;

                // Step 3: Ensure the columns match the data source
                GridColumn userNameColumn = new GridColumn
                {
                    Caption = "UserName", // The text displayed in the column header
                    FieldName = "UserName", // This must match the field name in the data source
                    UnboundType = DevExpress.Data.UnboundColumnType.String, // Ensure the data type matches the data
                    Visible = true, // Make the column visible
                    VisibleIndex = 1, // Position it at the end
                                      //dont allow to edit the column
                    OptionsColumn = { AllowEdit = false , AllowFocus = false }
                    //dont allow to select the column
                    //OptionsColumn = { }

                };

                // Step 4: Add the column to the GridView
                gvProjectInformation.Columns.Add(userNameColumn);

                // Optional: Adjust the grid view to automatically resize columns
                gvProjectInformation.BestFitColumns();
            }
            else
            {
                List<CLS_ProjectInformation> projectsInformation = cmdProjectInformation.GetAllProjects(CLS_UsereSession.userId);

                gcProjectInformation.DataSource = projectsInformation;
            }
            Cursor.Current = Cursors.Default;

        }

        private void gvProjectInformation_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "User" && e.IsGetData)
            {
                // Get the price and quantity from the data source
                //var PlanningQuantity = Convert.ToDouble(gvProjectInformation.GetListSourceRowCellValue(e.ListSourceRowIndex, "PlaningQuantity"));
                //var ActualQuantity = Convert.ToInt32(gvProjectInformation.GetListSourceRowCellValue(e.ListSourceRowIndex, "ActualQuantity"));

                //// Calculate the total price
                //e.Value = PlanningQuantity - ActualQuantity;
            }
        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(gvProjectInformation.GetFocusedRowCellValue("Id"));
            Hide();
            new FRM_GeneralProjectInformation(projectId, true).Show();
          
           
            //List<CLS_ProjectInformation> projectsInformation = cmdProjectInformation.GetAllProjects();
            //gcProjectInformation.DataSource = projectsInformation;
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            if (CLS_UsereSession.Role == "Admin" || CLS_UsereSession.Role == "SuperAdmin")
            { 
                if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int projectId = Convert.ToInt32(gvProjectInformation.GetFocusedRowCellValue("Id"));
                    cmdProjectInformation.RemoveProject(projectId);
                    List<CLS_ProjectInformation> projectsInformation = cmdProjectInformation.GetAllProjects(CLS_UsereSession.userId);
                    gcProjectInformation.DataSource = projectsInformation;
                }
            }
            else
            {
                XtraMessageBox.Show("You are not authorized to delete this project");
            }

        }

        private void FRM_Show_All_Projects_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_BasicProjectData().Show();
        }

        private void repFallow_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(gvProjectInformation.GetFocusedRowCellValue("Id"));
            Hide();
            new FRM_FollowUp_Menu(projectId).Show();
        }

        private void repCosts_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(gvProjectInformation.GetFocusedRowCellValue("Id"));
            Hide();
            new FRM_ProjectSpentCost(projectId).Show();
        }

        private void gvProjectInformation_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
           
        }



   
    }
}