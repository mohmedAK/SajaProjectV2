using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeePro.View.DataForms
{
    public partial class FRM_GeniralProjectInformation : DevExpress.XtraEditors.XtraForm
    {
        public FRM_GeniralProjectInformation()
        {
            InitializeComponent();
        }

        private void sbContract_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_ContractingData fRM_ContractingData = new FRM_ContractingData();
            fRM_ContractingData.Show();
        }

        private void sbLabor_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_LaborData fRM_labor = new FRM_LaborData();
            fRM_labor.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_MachinesData fRM_MachinesData = new FRM_MachinesData();
            fRM_MachinesData.Show();
        }

        private void sbM_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_MaterialsData fRM_MaterialsData = new FRM_MaterialsData();
            fRM_MaterialsData.Show();
             
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_Project_Item_Data fRM_Project_Item = new FRM_Project_Item_Data();
            fRM_Project_Item.Show();
        }
    }
}