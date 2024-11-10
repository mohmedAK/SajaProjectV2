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
        public List<CLS_WorkProgressFallow> GetAllWorkProgressFallow(int projectId)
        {
            try
            {
                return cmd.GetAll($"SELECT * FROM work_progress_fallow where ProjectIdFk = {projectId}").ToList();
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
                cmd.ExecuteParam("INSERT INTO work_progress_fallow (Id, WorkItem, ActualQuantity, CurrentDate, ProjectIdFk,PlaningQuantity,PlaningCost,ActualCost,PlaningDuration,ActualDuration,A,P) VALUES (@Id, @WorkItem, @ActualQuantity, @CurrentDate, @ProjectIdFk,@PlaningQuantity,@PlaningCost,@ActualCost,@PlaningDuration,@ActualDuration,@A,@P)", progress);
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
                cmd.ExecuteParam("UPDATE work_progress_fallow SET WorkItem = @WorkItem, ActualQuantity = @ActualQuantity, CurrentDate = @CurrentDate, ProjectIdFk = @ProjectIdFk ,PlaningQuantity = @PlaningQuantity,PlaningCost = @PlaningCost ,ActualCost = @ActualCost ,PlaningDuration = @PlaningDuration ,ActualDuration = @ActualDuration , A = @A,P = @P WHERE Id = @Id", progress);
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
                cmd.ExecuteParam("DELETE FROM work_progress_fallow WHERE Id = @Id", new CLS_WorkProgressFallow { Id = id });
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
            List<CLS_WorkProgressFallow> progress = cmd.GetAll("SELECT Id FROM work_progress_fallow WHERE Id = (SELECT MAX(Id) FROM work_progress_fallow)").ToList();
            if (progress.Count > 0)
            {
                return progress[0].Id + 1;
            }
            return 1;
        }
    }
}
