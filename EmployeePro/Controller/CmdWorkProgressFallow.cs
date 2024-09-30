using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdWorkProgressFallow
    {
        // Instantiate a repository for the CLS_WorkProgressFallow model
        Repository<CLS_WorkProgressFallow> cmd = new Repository<CLS_WorkProgressFallow>();

        // Retrieve all records from the WorkProgressFallow table
        public List<CLS_WorkProgressFallow> GetAllWorkProgressFallow()
        {
            try
            {
                return cmd.GetAll("SELECT Id, WorkItem, ActualQuantity, CurrentDate, ProjectIdFk FROM WorkProgressFallow").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new record to the WorkProgressFallow table
        public void AddWorkProgressFallow(CLS_WorkProgressFallow progress)
        {
            try
            {
                cmd.ExecuteParam("INSERT INTO WorkProgressFallow (Id, WorkItem, ActualQuantity, CurrentDate, ProjectIdFk) VALUES (@Id, @WorkItem, @ActualQuantity, @CurrentDate, @ProjectIdFk)", progress);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing record in the WorkProgressFallow table
        public bool EditWorkProgressFallow(CLS_WorkProgressFallow progress)
        {
            try
            {
                cmd.ExecuteParam("UPDATE WorkProgressFallow SET WorkItem = @WorkItem, ActualQuantity = @ActualQuantity, CurrentDate = @CurrentDate, ProjectIdFk = @ProjectIdFk WHERE Id = @Id", progress);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a record from the WorkProgressFallow table by Id
        public bool RemoveWorkProgressFallow(int id)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM WorkProgressFallow WHERE Id = @Id", new CLS_WorkProgressFallow { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get the next Id for a new entry in the WorkProgressFallow table
        public int GetNewId()
        {
            List<CLS_WorkProgressFallow> progress = cmd.GetAll("SELECT Id FROM WorkProgressFallow WHERE Id = (SELECT MAX(Id) FROM WorkProgressFallow)").ToList();
            if (progress.Count > 0)
            {
                return progress[0].Id + 1;
            }
            return 1;
        }
    }
}
