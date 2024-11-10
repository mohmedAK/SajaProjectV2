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
        public List<CLS_MachineFallow> GetAllMachineFallows(int projectId)
        {
            try
            {
                return cmd.GetAll($"SELECT Id, WorkItem, MachineName,  RentDays, OperationDays, CurrentDate, ProjectIdFk,RentPrice,OperationPrice,MachineNumber FROM machine_fallow where ProjectIdFk = {projectId}").ToList();
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
                cmd.ExecuteParam("INSERT INTO machine_fallow (Id, WorkItem, MachineName,  RentDays, OperationDays, CurrentDate, ProjectIdFk,RentPrice,OperationPrice,MachineNumber) " +
                                 "VALUES (@Id, @WorkItem, @MachineName,  @RentDays, @OperationDays, @CurrentDate, @ProjectIdFk,@RentPrice,@OperationPrice,@MachineNumber)", machineFallow);
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
                cmd.ExecuteParam("UPDATE machine_fallow SET WorkItem = @WorkItem, MachineName = @MachineName,  " +
                                 "RentDays = @RentDays, OperationDays = @OperationDays, CurrentDate = @CurrentDate, ProjectIdFk = @ProjectIdFk ,RentPrice = @RentPrice,OperationPrice = @OperationPrice,MachineNumber = @MachineNumber WHERE Id = @Id",
                                  machineFallow);
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
                cmd.ExecuteParam("DELETE FROM machine_fallow WHERE Id = @Id", new CLS_MachineFallow { Id = id });
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
            List<CLS_MachineFallow> machineFallows = cmd.GetAll("SELECT Id FROM machine_fallow WHERE Id = (SELECT MAX(Id) FROM machine_fallow)").ToList();
            if (machineFallows.Count > 0)
            {
                return machineFallows[0].Id + 1;
            }
            return 1;
        }
    }
}
