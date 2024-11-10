using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdMaterialFallow
    {
        Repository<CLS_MaterialFallow> cmd = new Repository<CLS_MaterialFallow>();

        // Get all material fallow records from the MaterialFallow table
        public List<CLS_MaterialFallow> GetAllMaterialFallow(int projectId)
        {
            try
            {
                return cmd.GetAll($"SELECT Id, WorkItem,MaterialName,MaterialCost, ActualQuantity, CurrentDate, ProjectIdFk FROM material_fallow where ProjectIdFk = {projectId}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new material fallow record
        public void AddMaterialFallow(CLS_MaterialFallow materialFallow)
        {
            try
            {
                // Insert new record into MaterialFallow table
                cmd.ExecuteParam("INSERT INTO material_fallow (Id, WorkItem,MaterialName,MaterialCost, ActualQuantity, CurrentDate, ProjectIdFk) VALUES (@Id, @WorkItem,@MaterialName, @MaterialCost, @ActualQuantity, @CurrentDate, @ProjectIdFk)", materialFallow);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing material fallow record
        public bool EditMaterialFallow(CLS_MaterialFallow materialFallow)
        {
            try
            {
                // Update record in MaterialFallow table
                cmd.ExecuteParam("UPDATE material_fallow SET WorkItem = @WorkItem, MaterialName =@MaterialName ,MaterialCost =@MaterialCost ,ActualQuantity = @ActualQuantity, CurrentDate = @CurrentDate, ProjectIdFk = @ProjectIdFk WHERE Id = @Id", materialFallow);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a material fallow record by ID
        public bool RemoveMaterialFallow(int id)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM material_fallow WHERE Id = @Id", new CLS_MaterialFallow { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get a new material fallow ID (increments by 1 from the max Id)
        public int GetNewId()
        {
            List<CLS_MaterialFallow> materialFallowList = cmd.GetAll("SELECT Id FROM material_fallow WHERE Id = (SELECT MAX(Id) FROM material_fallow)").ToList();
            if (materialFallowList.Count > 0)
            {
                return materialFallowList[0].Id + 1;
            }
            return 1;
        }
    }
}
