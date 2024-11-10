using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdContract
    {
        Repository<CLS_Contract> cmd = new Repository<CLS_Contract>();

        // Get all contracts from the Contract table
        public List<CLS_Contract> GetAllContracts(int projectId)
        {
            try
            {
                return cmd.GetAll($"SELECT * FROM contract where ProjectIdFk = {projectId}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<CLS_Contract> GetContractById(int projectId)
        {
            try
            {
                return cmd.GetById("SELECT * FROM contract WHERE ProjectIdFk = @ProjectIdFk", new CLS_Contract { ProjectIdFk = projectId }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        // Add a new contract
        public void AddContract(CLS_Contract contract)
        {
            try
            {
                cmd.ExecuteParam("INSERT INTO contract (Id, ContractorName, CompanyName, StartDate, FinishDate, Details, ProjectIdFk,ContractCost,WorkItem) " +
                                 "VALUES (@Id, @ContractorName, @CompanyName, @StartDate, @FinishDate, @Details, @ProjectIdFk,@ContractCost,@WorkItem)", contract);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Edit an existing contract
        public bool EditContract(CLS_Contract contract)
        {
            try
            {
                cmd.ExecuteParam("UPDATE contract SET ContractorName = @ContractorName, CompanyName = @CompanyName, StartDate = @StartDate, " +
                                 "FinishDate = @FinishDate, Details = @Details, ProjectIdFk = @ProjectIdFk, ContractCost = @ContractCost, WorkItem = @WorkItem WHERE Id = @Id", contract);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a contract by ID
        public bool RemoveContract(int contractId)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM contract WHERE Id = @Id", new CLS_Contract { Id = contractId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get a new contract ID (increments by 1 from the max Id)
        public int GetNewId()
        {
            List<CLS_Contract> contract = cmd.GetAll("SELECT Id FROM contract WHERE Id = (SELECT MAX(Id) FROM contract)").ToList();
            if (contract.Count > 0)
            {
                return contract[0].Id + 1;
            }
            return 1;
        }
    }
}
