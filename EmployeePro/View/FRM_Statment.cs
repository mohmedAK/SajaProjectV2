using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SagaProjectV2.Controller;
using SagaProjectV2.Model;





namespace SagaProjectV2.View
{
    
    public partial class FRM_Statment: DevExpress.XtraEditors.XtraForm
    {
        CmdEmployee cmdEmployee = new CmdEmployee();
        public FRM_Statment()
        { 
            InitializeComponent();
            GetAllEmployee();
                        
        }

       void GetAllEmployee()
        {
            List<CLS_Employee> employees= cmdEmployee.GetAllEmployee();
            gcEmployee.DataSource = employees;
        }

        private void barButtonAddEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            FRM_Employee frm = new FRM_Employee();
            frm.barButtonAddWage.Enabled = false;
            frm.barButtonEditEmployee.Enabled = false;            
            frm.Show();
            this.Hide();



        }

        private void repPreview_Click(object sender, EventArgs e)
        {
           
        }

        private void repPreview_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void repPreview_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.Hide();
            FRM_Employee frm = new FRM_Employee();           
           
            frm.txtId.Text = gvEmployee.GetFocusedRowCellValue("EmpId").ToString();
            frm.txtFirstName.Text = gvEmployee.GetFocusedRowCellValue("FName").ToString();
            frm.txtLastName.Text = gvEmployee.GetFocusedRowCellValue("LName").ToString();
            frm.txtAddress.Text = gvEmployee.GetFocusedRowCellValue("Address").ToString();
            frm.txtFinalTotal.Text = gvEmployee.GetFocusedRowCellValue("FinalTotal").ToString();

            byte[] image = (byte[])gvEmployee.GetFocusedRowCellValue("Image");
            HelperClass.retrieveImage(image, frm.pictureEdit2);
            HelperClass.NotEnableControls(frm.tableLayoutEmployee);
            frm.btnAddEmployee.Enabled = false;
            frm.loadWage();
            frm.Show();
        }

        private void gcEmployee_Click(object sender, EventArgs e)
        {

        }
    }
}