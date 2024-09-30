using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdMachineFallow
    {
        Repository<CLS_MachineFallow> cmd = new Repository<CLS_MachineFallow>();

        // Get all Machine Fallows
        public List<CLS_MachineFallow> GetAllMachineFallows()
        {
            try
            {
                return cmd.GetAll("SELECT Id, WorkItem, MachineName, Ownership, RentDays, OperationDays, CurrentDate, ProjectIdFk FROM MachineFallow").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new Machine Fallow
        public void AddMachineFallow(CLS_MachineFallow machineFallow)
        {
            try
            {
                // Insert a new Machine Fallow
                cmd.ExecuteParam("INSERT INTO MachineFallow (Id, WorkItem, MachineName, Ownership, RentDays, OperationDays, CurrentDate, ProjectIdFk) " +
                                 "VALUES (@Id, @WorkItem, @MachineName, @Ownership, @RentDays, @OperationDays, @CurrentDate, @ProjectIdFk)", machineFallow);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing Machine Fallow
        public bool EditMachineFallow(CLS_MachineFallow machineFallow)
        {
            try
            {
                // Update the machine fallow
                cmd.ExecuteParam("UPDATE MachineFallow SET WorkItem = @WorkItem, MachineName = @MachineName, Ownership = @Ownership, " +
                                 "RentDays = @RentDays, OperationDays = @OperationDays, CurrentDate = @CurrentDate, ProjectIdFk = @ProjectIdFk " +
                                 "WHERE Id = @Id", machineFallow);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a Machine Fallow by ID
        public bool RemoveMachineFallow(int id)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM MachineFallow WHERE Id = @Id", new CLS_MachineFallow { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get a new ID for Machine Fallow (Auto-incrementing by 1 from the max)
        public int getNewId()
        {
            List<CLS_MachineFallow> machineFallows = cmd.GetAll("SELECT Id FROM MachineFallow WHERE Id = (SELECT MAX(Id) FROM MachineFallow)").ToList();
            if (machineFallows.Count > 0)
            {
                return machineFallows[0].Id + 1;
            }
            return 1;
        }
    }
}
