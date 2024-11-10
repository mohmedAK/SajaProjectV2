using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdWorkItem
    {
        Repository<CLS_WorkItem> cmd = new Repository<CLS_WorkItem>();

        // Get all work items from the WorkItem table
        public List<CLS_WorkItem> GetAllWorkItems(int projectId)
        {
            try
            {
                return cmd.GetAll($"SELECT * FROM work_item WHERE ProjectIdFk = {projectId}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<CLS_WorkItem> GetWorkItemsById(int ProjectIdFk)
        {
            try
            {
                return cmd.GetById("SELECT * FROM work_item WHERE ProjectIdFk = @ProjectIdFk", new CLS_WorkItem { ProjectIdFk = ProjectIdFk }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new work item
        public void AddWorkItem(CLS_WorkItem workItem)
        {
            try
            {
                cmd.ExecuteParam("INSERT INTO work_item (Id, Items, ItemCost, ProjectIdFk) VALUES (@Id, @Items, @ItemCost, @ProjectIdFk)", workItem);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing work item
        public bool EditWorkItem(CLS_WorkItem workItem)
        {
            try
            {
                cmd.ExecuteParam("UPDATE work_item SET Item = @Item, ItemCost = @ItemCost, ProjectIdFk = @ProjectIdFk WHERE Id = @Id", workItem);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a work item by ID
        public bool RemoveWorkItem(int id)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM work_item WHERE Id = @Id", new CLS_WorkItem { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool RemoveAllWorkItem(int ContractId)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM work_item WHERE ProjectIdFk = @ProjectIdFk", new CLS_WorkItem { ProjectIdFk = ContractId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Get a new work item ID (increments by 1 from the max Id)
        public int GetNewId()
        {
            List<CLS_WorkItem> workItems = cmd.GetAll("SELECT Id FROM work_item WHERE Id = (SELECT MAX(Id) FROM work_item)").ToList();
            if (workItems.Count > 0)
            {
                return workItems[0].Id + 1;
            }
            return 1;
        }

        // Update the contract field to true for a specific work item
        public bool UpdateContractFlag(int workItemId,bool flag)
        {
            try
            {
                cmd.ExecuteParam($"UPDATE work_item SET contract = {flag} WHERE Id = @Id", new CLS_WorkItem { Id = workItemId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
