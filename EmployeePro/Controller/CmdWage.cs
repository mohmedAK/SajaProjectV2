using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
     class CmdWage
    {
        Repository<CLS_Wage> cmd = new Repository<CLS_Wage>();
       public List<CLS_Wage> GetAllWage()
        {
            try
            {
                return cmd.GetAll("SP_AllWage").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CLS_Wage> GetWageById(int empId)
        {
            try
            {
                return cmd.GetById("SP_ByIdWage @EmpId", new CLS_Wage { EmpId = empId }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
       public bool AddWage(CLS_Wage wage)
        {
            try
            {                
               // cmd.ExecuteParam("SP_InsertWage @EmpId,@EntryDate,@Salary,@Discount,@Total", wage);
                cmd.ExecuteParam(" INSERT INTO [dbo].[Wage] ([EntryDate] ,[Salary] ,[Discount] ,[Total] ,[EmpId]) VALUES (@EntryDate ,@Salary ,@Discount ,@Total ,@EmpId) ", wage);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditWage(CLS_Wage wage)
        {
            try
            {
                cmd.ExecuteParam("UPDATE [dbo].[Wage] SET [EntryDate] = @EntryDate ,[Salary] = @Salary ,[Discount] = @Discount ,[Total] = @Total ,[EmpId] = @EmpId WHERE EmpId = @EmpId", wage);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
