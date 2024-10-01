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
        public List<CLS_WorkItem> GetAllWorkItems()
        {
            try
            {
                return cmd.GetAll("SELECT Id, Item, ItemCost, ContractIdFk FROM WorkItem").ToList();
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
                cmd.ExecuteParam("INSERT INTO WorkItem (Id, Item, ItemCost, ContractIdFk) VALUES (@Id, @Item, @ItemCost, @ContractIdFk)", workItem);
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
                cmd.ExecuteParam("UPDATE WorkItem SET Item = @Item, ItemCost = @ItemCost, ContractIdFk = @ContractIdFk WHERE Id = @Id", workItem);
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
                cmd.ExecuteParam("DELETE FROM WorkItem WHERE Id = @Id", new CLS_WorkItem { Id = id });
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
            List<CLS_WorkItem> workItems = cmd.GetAll("SELECT Id FROM WorkItem WHERE Id = (SELECT MAX(Id) FROM WorkItem)").ToList();
            if (workItems.Count > 0)
            {
                return workItems[0].Id + 1;
            }
            return 1;
        }
    }
}
