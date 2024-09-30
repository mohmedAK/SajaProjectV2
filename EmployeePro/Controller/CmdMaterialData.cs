using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdMaterialData
    {
        Repository<CLS_MaterialData> cmd = new Repository<CLS_MaterialData>();

        // Get all materials
        public List<CLS_MaterialData> GetAllMaterialData()
        {
            try
            {
                return cmd.GetAll("SELECT Id, WorkItem, MaterialName, PlanningQuantity, Unit, Price, Details, ProjectIdFk FROM MaterialData").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add new material data
        public void AddMaterialData(CLS_MaterialData materialData)
        {
            try
            {
                cmd.ExecuteParam("INSERT INTO MaterialData (Id, WorkItem, MaterialName, PlanningQuantity, Unit, Price, Details, ProjectIdFk) VALUES (@Id, @WorkItem, @MaterialName, @PlanningQuantity, @Unit, @Price, @Details, @ProjectIdFk)", materialData);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit existing material data
        public bool EditMaterialData(CLS_MaterialData materialData)
        {
            try
            {
                cmd.ExecuteParam("UPDATE MaterialData SET WorkItem = @WorkItem, MaterialName = @MaterialName, PlanningQuantity = @PlanningQuantity, Unit = @Unit, Price = @Price, Details = @Details, ProjectIdFk = @ProjectIdFk WHERE Id = @Id", materialData);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove material data by ID
        public bool RemoveMaterialData(int id)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM MaterialData WHERE Id = @Id", new CLS_MaterialData { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get a new material data ID (increments by 1 from the max Id)
        public int GetNewId()
        {
            List<CLS_MaterialData> materials = cmd.GetAll("SELECT Id FROM MaterialData WHERE Id = (SELECT MAX(Id) FROM MaterialData)").ToList();
            if (materials.Count > 0)
            {
                return materials[0].Id + 1;
            }
            return 1;
        }
    }
}
