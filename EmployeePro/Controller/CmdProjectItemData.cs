using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdProjectItemData
    {
        Repository<CLS_ProjectItemData> cmd = new Repository<CLS_ProjectItemData>();

        // Get all project items from the ProjectItemData table
        public List<CLS_ProjectItemData> GetAllProjectItems(int projectId)
        {
            try
            {
                return cmd.GetAll($"SELECT * FROM project_item_data  where ProjectIdFk = {projectId}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CLS_ProjectItemData> GetAllProjectDataWithWorkItem(int projectId, string workItem)
        {
            try
            {
                return cmd.GetAll($"SELECT * FROM project_item_data where ProjectIdFk = {projectId} and WorkItem = '{workItem}'").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new project item
        public void AddProjectItem(CLS_ProjectItemData projectItem)
        {
            try
            {
                cmd.ExecuteParam("INSERT INTO project_item_data (Id, WorkItem, PlanningQuantity, Unit, Price, StartDate, FinishDate, Details, ProjectIdFk) VALUES (@Id, @WorkItem, @PlanningQuantity, @Unit, @Price, @StartDate, @FinishDate, @Details, @ProjectIdFk)", projectItem);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing project item
        public bool EditProjectItem(CLS_ProjectItemData projectItem)
        {
            try
            {
                cmd.ExecuteParam("UPDATE project_item_data SET WorkItem = @WorkItem, PlanningQuantity = @PlanningQuantity, Unit = @Unit, Price = @Price, StartDate = @StartDate, FinishDate = @FinishDate, Details = @Details WHERE Id = @Id", projectItem);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a project item by ID
        public bool RemoveProjectItem(int id)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM project_item_data WHERE Id = @Id", new CLS_ProjectItemData { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get the next available ID (increments by 1 from the max Id)
        public int GetNewId()
        {
            List<CLS_ProjectItemData> items = cmd.GetAll("SELECT Id FROM project_item_data WHERE Id = (SELECT MAX(Id) FROM project_item_data)").ToList();
            if (items.Count > 0)
            {
                return items[0].Id + 1;
            }
            return 1;
        }
    }
}
