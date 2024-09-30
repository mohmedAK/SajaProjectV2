using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SagaProjectV2.Factory;
using SagaProjectV2.Model;

namespace SagaProjectV2.Controller
{
   class CmdEmployee
    {
        Repository<CLS_Employee> cmd = new Repository<CLS_Employee>();

       public List<CLS_Employee> GetAllEmployee()
        {
            try
            {
                return cmd.GetAll("SELECT [EmpId],[FName],[LName],[Address],[Image],[FinalTotal] FROM [dbo].[Employee]").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
      public  void AddEmployee(CLS_Employee emp)
        {
            try
            {
                
               // cmd.ExecuteParam("SP_InsertEmployee @EmpId,@FName,@LName,@Address,@Image,@FinalTotal", emp);
                cmd.ExecuteParam("INSERT INTO [dbo].[Employee] ([EmpId],[FName],[LName],[Address],[Image],[FinalTotal]) VALUES (@EmpId, @FName, @LName, @Address, @Image, @FinalTotal)", emp);


            }
            catch (Exception e)
            {
                //throw e;
            }

            
        }
       public bool EditEmployee(CLS_Employee emp)
        {
            try
            {               
               // cmd.ExecuteParam("SP_UpdateEmployee @FName,@LName,@Address,@Image,@FinalTotal,@EmpId", emp);
                cmd.ExecuteParam("UPDATE [dbo].[Employee] SET,[FName] = @FName,[LName] = @LName,[Address] = @Address,[Image] = @Image,[FinalTotal] = @FinalTotal WHERE EmpId = @EmpId", emp);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            }
       public bool RemoveEmployee(int empId)
        {
            try
            {
                cmd.ExecuteParam("SP_DeleteEmployee @EmpId", new CLS_Employee { EmpId = empId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       public int getNewId()
        {
            List<CLS_Employee> emp = cmd.GetAll("select EmpId from Employee where EmpId IN (select max(EmpId) from dbo.Employee)").ToList();
            if (emp.Count > 0)
            {
                return emp[0].EmpId + 1;
            }
            return 1;
        }
    }
}
