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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SajaProjectV2.View.DataForms
{
    public partial class FRM_LaborData : DevExpress.XtraEditors.XtraForm
    {
        CmdLaborDate cmdLaborDate = new CmdLaborDate();

        private int _projectId;
        private int _userId;

        public FRM_LaborData(int projectId, bool isUpdate = false)
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;
            _projectId = projectId;
         

            List<CLS_LaborDate> laborDates = cmdLaborDate.GetContractById(_projectId);

            gcLaborData.DataSource = laborDates;

            Cursor.Current = Cursors.Default;
        }


        private void btnAddLabor_Click(object sender, EventArgs e)
        {
            if (CheckIsNull())
            {
                XtraMessageBox.Show("Please fill all fields");
                return;
            }
            AddLaborData();

            txtLaborType.Text = string.Empty;
            txtOccuption.Text = string.Empty;
            spWage.Value = 0;

        }


        private void AddLaborData()
        {
            if (XtraMessageBox.Show("Are you sure from data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                var laborData = new CLS_LaborDate
                {
                    Id = cmdLaborDate.GetNewId(),
                    LaborType = txtLaborType.Text,
                    Occupation = txtOccuption.Text,
                    Wage = Convert.ToDouble(spWage.Value),
                    ProjectIdFk = _projectId
                };

                cmdLaborDate.AddLaborDate(laborData);

                List<CLS_LaborDate> laborDates = cmdLaborDate.GetContractById(_projectId);
                gcLaborData.DataSource = laborDates;
                Cursor.Current = Cursors.Default;
            }
        }

        private bool CheckIsNull()
        {
            var controlsToCheck = new[] { txtLaborType, txtOccuption, spWage };
            return controlsToCheck.Any(control => string.IsNullOrEmpty(control?.Text));
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            int rowHandle = gvLaborData.FocusedRowHandle;
            int workItemId = Convert.ToInt32(gvLaborData.GetRowCellValue(rowHandle, "Id"));
            if (XtraMessageBox.Show("Are you sure you want delete this item", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (workItemId != 0)
                {
                    cmdLaborDate.RemoveLaborDate(workItemId);
                    gvLaborData.DeleteRow(rowHandle);
                    gvLaborData.RefreshData();
                }
                else
                {
                    // Delete the selected row from the grid view
                    gvLaborData.DeleteRow(rowHandle);
                    gvLaborData.RefreshData();
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_GeneralProjectInformation(_projectId, true).Show();
        }

        private void FRM_LaborData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        new FRM_GeneralProjectInformation(_projectId, true).Show();
        }
    }
}