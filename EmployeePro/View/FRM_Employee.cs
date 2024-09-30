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
using SajaProjectV2.Controller;
using SajaProjectV2.Model;
using System.Data.SqlClient;

namespace SajaProjectV2.View
{
    public partial class FRM_Employee : DevExpress.XtraEditors.XtraForm
    {
        CmdEmployee cmdEmployee = new CmdEmployee();
        CmdWage cmdWage = new CmdWage();
        public FRM_Employee()
        {
            InitializeComponent();
            HelperClass.NotEnableControls(tableLayoutWage);
            btnAddwage.Enabled = false;
            txtId.Text = cmdEmployee.getNewId().ToString();
            txtId.Enabled = false;
           
            
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtId.Text) ||string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || 
                string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtFinalTotal.Text) || pictureEdit2.Image == null)
            {
                XtraMessageBox.Show("Please fill all Fields");
            }
            else if (btnAddEmployee.Text == "Add Employee")
            {
                AddEmployee();
                HelperClass.EnableControls(tableLayoutWage);
                btnAddwage.Enabled = true;
                XtraMessageBox.Show("Add Done");
            }
            else if (btnAddEmployee.Text == "Edit Employee")
            {
                EditEmployee();             
                XtraMessageBox.Show("Edit Done");
                HelperClass.NotEnableControls(tableLayoutEmployee);
                btnAddEmployee.Enabled = false;
                btnAddEmployee.Text = "Add Employee";
                HelperClass.NotEnableControls(tableLayoutWage);
                btnAddwage.Enabled = false;
                btnAddwage.Text = "Add Wage";
                HelperClass.ClearValue(tableLayoutWage);

            }
        }
        //Add newId
        void getNewId()
        {
            txtId.Text = cmdEmployee.getNewId().ToString();
            txtId.Enabled = false;
        }

        //Add Employee
         void AddEmployee()
        {  
            byte[] image = HelperClass.SaveImage(pictureEdit2);

            CLS_Employee emp = new CLS_Employee()

            {
                EmpId = int.Parse(txtId.Text),
                FName = txtFirstName.Text,
                LName = txtLastName.Text,
                Address = txtAddress.Text,
                Image = image,
                FinalTotal = double.Parse(txtFinalTotal.Text)

            };
             cmdEmployee.AddEmployee(emp);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureEdit2.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        //Edit Employee
        void EditEmployee()
        {
            byte[] image = HelperClass.SaveImage(pictureEdit2);
            CLS_Employee emp = new CLS_Employee()

            {
                FName = txtFirstName.Text,
                LName = txtLastName.Text,
                Address = txtAddress.Text,
                Image = image,
                FinalTotal = double.Parse(txtFinalTotal.Text),
                EmpId = int.Parse(txtId.Text)
        };

            cmdEmployee.EditEmployee(emp);
        }
        private void btnAddwage_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDate.Text) || string.IsNullOrWhiteSpace(txtSalary.Text) || string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                XtraMessageBox.Show("يرجى مليء جميع الحقول");
            }
            else if (btnAddwage.Text == "Add Wage")
            {
                AddWage();
                loadWage();
                HelperClass.ClearValue(tableLayoutWage);
            }
            else if (btnAddwage.Text == "Edit Wage")
            {
                EditWage();
                loadWage();
                HelperClass.ClearValue(tableLayoutWage);
                HelperClass.NotEnableControls(tableLayoutWage);
                btnAddwage.Enabled = false;
                btnAddwage.Text = "Add Wage";
            }
        }
       public void loadWage()
        {
            
            List<CLS_Wage> wages = cmdWage.GetWageById(int.Parse(txtId.Text));
            gcWage.DataSource = wages;

        }

        //AddWage//
        void AddWage()
        {
            
                double total = double.Parse(txtSalary.Text) - double.Parse(txtDiscount.Text);
                CLS_Wage wage = new CLS_Wage()
                {                                        
                        EmpId = int.Parse(txtId.Text),
                        EntryDate = txtDate.DateTime,
                        Salary =double.Parse(txtSalary.Text),
                        Discount = double.Parse(txtDiscount.Text),
                        Total = total
                    
                };
            if (cmdWage.AddWage(wage))

                {
                    XtraMessageBox.Show("تمت الاضافة بنجاح");
                }
                else
                {
                    XtraMessageBox.Show("لم تتم الاضافة بنجاح");
                }
            
        }

        //EditWage
        void EditWage()
        {
            double total = double.Parse(txtSalary.Text) - double.Parse(txtDiscount.Text);

            CLS_Wage wage = new CLS_Wage()
            {


                EmpId = int.Parse(txtId.Text),
                EntryDate = txtDate.DateTime,
                Salary = double.Parse(txtSalary.Text),
                Discount = double.Parse(txtDiscount.Text),
                Total = total

            };

            if (cmdWage.EditWage(wage))
            {
                XtraMessageBox.Show("تمت  التعديل بنجاح");
            }
            else
            {
                XtraMessageBox.Show("لم تتم التعديل بنجاح");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_Statment frm = new FRM_Statment();
            frm.Show();
        }

        private void barButtonHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            FRM_Statment frm = new FRM_Statment();
            frm.Show();
        }

        private void repEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtDate.Text = gvWage.GetFocusedRowCellValue("EntryDate").ToString();
            txtSalary.Text = gvWage.GetFocusedRowCellValue("Salary").ToString();
            txtDiscount.Text = gvWage.GetFocusedRowCellValue("Discount").ToString();
            btnAddwage.Text = "Edit Wage";
            HelperClass.EnableControls(tableLayoutWage);
            btnAddwage.Enabled = true;
        }

        private void barButtonEditEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   
            btnAddEmployee.Text = "Edit Employee";
            HelperClass.EnableControls(tableLayoutEmployee);
            btnAddEmployee.Enabled = true;
            HelperClass.NotEnableControls(tableLayoutWage);
            btnAddwage.Enabled = false;            
            btnAddwage.Text = "Add Wage";
            HelperClass.ClearValue(tableLayoutWage);


        }

        private void barButtonAddWage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            HelperClass.EnableControls(tableLayoutWage);
            btnAddwage.Enabled = true;
        }

        private void barButtonAddEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            
            HelperClass.EnableControls(tableLayoutEmployee);
            getNewId();

            btnAddEmployee.Enabled = true;
            barButtonAddWage.Enabled = false;
            barButtonEditEmployee.Enabled = false;
            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtAddress.Text = null;
            txtFinalTotal.Text = null;

           // HelperClass.ClearValue(tableLayoutEmployee);
            pictureEdit2.Image = null;


        }

    }
}