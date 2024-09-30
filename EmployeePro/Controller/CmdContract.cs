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
        public List<CLS_Contract> GetAllContracts()
        {
            try
            {
                return cmd.GetAll("SELECT Id, ContractorName, CompanyName, StartDate, FinishDate, Details, ProjectIdFk FROM Contract").ToList();
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
                cmd.ExecuteParam("INSERT INTO Contract (Id, ContractorName, CompanyName, StartDate, FinishDate, Details, ProjectIdFk) " +
                                 "VALUES (@Id, @ContractorName, @CompanyName, @StartDate, @FinishDate, @Details, @ProjectIdFk)", contract);
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
                cmd.ExecuteParam("UPDATE Contract SET ContractorName = @ContractorName, CompanyName = @CompanyName, StartDate = @StartDate, " +
                                 "FinishDate = @FinishDate, Details = @Details, ProjectIdFk = @ProjectIdFk WHERE Id = @Id", contract);
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
                cmd.ExecuteParam("DELETE FROM Contract WHERE Id = @Id", new CLS_Contract { Id = contractId });
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
            List<CLS_Contract> contract = cmd.GetAll("SELECT Id FROM Contract WHERE Id = (SELECT MAX(Id) FROM Contract)").ToList();
            if (contract.Count > 0)
            {
                return contract[0].Id + 1;
            }
            return 1;
        }
    }
}
