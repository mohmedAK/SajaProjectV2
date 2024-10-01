using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
 
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdProjectInformation
    {
        Repository<CLS_ProjectInformation> cmd = new Repository<CLS_ProjectInformation>();

        // Get all projects from the ProjectInformation table
        public List<CLS_ProjectInformation> GetAllProjects()
        {
            try
            {
                return cmd.GetAll("SELECT Id, ProjectName, Location, OwnerName, Penalties, StartDate, FinishDate, Details,Value FROM projects_information").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new project
        public void AddProject(CLS_ProjectInformation project)
        {
            try
            {
                // Insert a new project into projects_information table
                cmd.ExecuteParam("INSERT INTO projects_information ( ProjectName, Location, OwnerName, Penalties, StartDate, FinishDate, Details,Value) VALUES ( @ProjectName, @Location, @OwnerName, @Penalties, @StartDate, @FinishDate, @Details,@Value)", project);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing project
        public bool EditProject(CLS_ProjectInformation project)
        {
            try
            {
                // Update project details based on project ID
                cmd.ExecuteParam("UPDATE projects_information SET ProjectName = @ProjectName, Location = @Location, OwnerName = @OwnerName, Penalties = @Penalties, StartDate = @StartDate, FinishDate = @FinishDate, Details = @Details,Value = @Value WHERE Id = @Id", project);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a project by ID
        public bool RemoveProject(int projectId)
        {
            try
            {
                // Delete project by ID
                cmd.ExecuteParam("DELETE FROM projects_information WHERE Id = @Id", new CLS_ProjectInformation { Id = projectId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CLS_ProjectInformation> GetProjectById(int projectId)
        {
            try
            {
                // Get project by ID
                return cmd.GetById("Select * FROM projects_information WHERE Id = @Id", new CLS_ProjectInformation { Id = projectId }).ToList(); 
               
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Get a new project ID (increments by 1 from the max Id)
        public int getNewId()
        {
            List<CLS_ProjectInformation> projects = cmd.GetAll("SELECT Id FROM projects_information WHERE Id = (SELECT MAX(Id) FROM projects_information)").ToList();
            if (projects.Count > 0)
            {
                return projects[0].Id + 1;
            }
            return 1;
        }
    }
}
