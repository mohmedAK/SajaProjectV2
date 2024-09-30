using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdLaborFallow
    {
        Repository<CLS_LaborFallow> cmd = new Repository<CLS_LaborFallow>();

        // Get all Labor Fallow records
        public List<CLS_LaborFallow> GetAllLaborFallow()
        {
            try
            {
                return cmd.GetAll("SELECT Id, WorkItem, LaborType, NumLabor, WorkDay, CurrentDate, ProjectIdFk FROM LaborFallow").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new Labor Fallow record
        public void AddLaborFallow(CLS_LaborFallow laborFallow)
        {
            try
            {
                // Insert new Labor Fallow record into the LaborFallow table
                cmd.ExecuteParam("INSERT INTO LaborFallow (WorkItem, LaborType, NumLabor, WorkDay, CurrentDate, ProjectIdFk) VALUES (@WorkItem, @LaborType, @NumLabor, @WorkDay, @CurrentDate, @ProjectIdFk)", laborFallow);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing Labor Fallow record
        public bool EditLaborFallow(CLS_LaborFallow laborFallow)
        {
            try
            {
                // Update existing Labor Fallow record
                cmd.ExecuteParam("UPDATE LaborFallow SET WorkItem = @WorkItem, LaborType = @LaborType, NumLabor = @NumLabor, WorkDay = @WorkDay, CurrentDate = @CurrentDate, ProjectIdFk = @ProjectIdFk WHERE Id = @Id", laborFallow);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a Labor Fallow record by ID
        public bool RemoveLaborFallow(int id)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM LaborFallow WHERE Id = @Id", new CLS_LaborFallow { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get a new ID for a Labor Fallow record (increment from the max Id)
        public int GetNewId()
        {
            List<CLS_LaborFallow> laborFallow = cmd.GetAll("SELECT Id FROM LaborFallow WHERE Id = (SELECT MAX(Id) FROM LaborFallow)").ToList();
            if (laborFallow.Count > 0)
            {
                return laborFallow[0].Id + 1;
            }
            return 1;
        }
    }
}
