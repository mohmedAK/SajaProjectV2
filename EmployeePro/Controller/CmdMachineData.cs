using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdMachineData
    {
        Repository<CLS_MachineData> cmd = new Repository<CLS_MachineData>();

        // Get all machine data
        public List<CLS_MachineData> GetAllMachineData()
        {
            try
            {
                return cmd.GetAll("SELECT Id, MachineName, MachineNumber, WageRent, WageMaintenance, ProjectIdFk FROM MachineData").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add new machine data
        public void AddMachineData(CLS_MachineData machine)
        {
            try
            {
                // Insert new machine data into MachineData table
                cmd.ExecuteParam("INSERT INTO MachineData (MachineName, MachineNumber, WageRent, WageMaintenance, ProjectIdFk) VALUES (@MachineName, @MachineNumber, @WageRent, @WageMaintenance, @ProjectIdFk)", machine);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit existing machine data
        public bool EditMachineData(CLS_MachineData machine)
        {
            try
            {
                // Update machine data in MachineData table
                cmd.ExecuteParam("UPDATE MachineData SET MachineName = @MachineName, MachineNumber = @MachineNumber, WageRent = @WageRent, WageMaintenance = @WageMaintenance WHERE Id = @Id", machine);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove machine data by ID
        public bool RemoveMachineData(int machineId)
        {
            try
            {
                // Execute delete by machine Id
                cmd.ExecuteParam("DELETE FROM MachineData WHERE Id = @Id", new CLS_MachineData { Id = machineId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get a new machine data ID (increment by 1 from the max Id)
        public int GetNewId()
        {
            List<CLS_MachineData> machines = cmd.GetAll("SELECT Id FROM MachineData WHERE Id = (SELECT MAX(Id) FROM MachineData)").ToList();
            if (machines.Count > 0)
            {
                return machines[0].Id + 1;
            }
            return 1;
        }
    }
}
