using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdLaborDate
    {
        // Use repository for database operations
        Repository<CLS_LaborDate> cmd = new Repository<CLS_LaborDate>();

        // Method to get all labor date records
        public List<CLS_LaborDate> GetAllLaborDate(int projectId)
        {
            try
            {
                // Fetch all labor date records from the LaborDate table
                return cmd.GetAll($"SELECT Id, LaborType, Occupation, Wage, ProjectIdFk FROM labor_date where ProjectIdFk = {projectId}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<CLS_LaborDate> GetContractById(int projectId)
        {
            try
            {
                return cmd.GetById("SELECT * FROM labor_date WHERE ProjectIdFk = @ProjectIdFk", new CLS_LaborDate { ProjectIdFk = projectId }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Method to add a new labor date record
        public void AddLaborDate(CLS_LaborDate laborDate)
        {
            try
            {
                // Insert a new record into the LaborDate table
                cmd.ExecuteParam("INSERT INTO labor_date (Id,  LaborType, Occupation, Wage, ProjectIdFk) VALUES (@Id,  @LaborType, @Occupation, @Wage, @ProjectIdFk)", laborDate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Method to edit an existing labor date record
        public bool EditLaborDate(CLS_LaborDate laborDate)
        {
            try
            {
                // Update the record in the LaborDate table
                cmd.ExecuteParam("UPDATE labor_date SET  LaborType = @LaborType, Occupation = @Occupation, Wage = @Wage, ProjectIdFk = @ProjectIdFk WHERE Id = @Id", laborDate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Method to remove a labor date record by ID
        public bool RemoveLaborDate(int laborDateId)
        {
            try
            {
                // Delete the labor date record by its ID
                cmd.ExecuteParam("DELETE FROM labor_date WHERE Id = @Id", new CLS_LaborDate { Id = laborDateId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Method to get the next available ID for a new labor date record
        public int GetNewId()
        {
            List<CLS_LaborDate> laborDates = cmd.GetAll("SELECT Id FROM labor_date WHERE Id = (SELECT MAX(Id) FROM labor_date)").ToList();
            if (laborDates.Count > 0)
            {
                return laborDates[0].Id + 1;
            }
            return 1;
        }
    }
}
