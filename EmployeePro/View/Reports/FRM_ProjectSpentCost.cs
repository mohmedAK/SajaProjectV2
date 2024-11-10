using DevExpress.XtraEditors;
using SajaProjectV2.Controller;
using SajaProjectV2.Model;
using SajaProjectV2.View.DataForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SajaProjectV2.View.Reports
{
    public partial class FRM_ProjectSpentCost : DevExpress.XtraEditors.XtraForm
    {
        CmdContract cmdContract = new CmdContract();
        CmdWorkItem cmdWorkItem = new CmdWorkItem();
        CmdLaborDate cmdLaborDate = new CmdLaborDate();
        CmdLaborFallow cmdLaborFallow = new CmdLaborFallow();
        CmdMachineFallow cmdMachineFallow = new CmdMachineFallow();
        CmdMaterialData cmdMaterialData = new CmdMaterialData();
 

        int _projectId;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        public FRM_ProjectSpentCost(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadProjectData(_projectId);

        }

        private void LoadProjectData(int projectId)
        {
            
            var laborFallows = cmdLaborFallow.GetAllLaborFallow(_projectId);
            var laborDates = cmdLaborDate.GetAllLaborDate(_projectId);
            var contracts = cmdContract.GetAllContracts(_projectId);
            var materialData = cmdMaterialData.GetAllMaterialData(_projectId);
            var machineFallows = cmdMachineFallow.GetAllMachineFallows(_projectId);
            List<CLS_WorkItem> workItems = cmdWorkItem.GetAllWorkItems(_projectId);

            var laborCombinedData = from fallow in laborFallows
                                    join date in laborDates on fallow.LaborType equals date.LaborType
                                    group new { fallow.WorkItem, TotalCost = fallow.NumLabor * date.Wage } by fallow.WorkItem into grouped
                                    select new
                                    {
                                        WorkItem = grouped.Key,
                                        TotalCost = grouped.Sum(x => x.TotalCost)
                                    };

            var contractWorkItemAndCost = contracts.Select(contract => new
            {
                contract.WorkItem,
                contract.ContractCost
            }).ToList();

            var laborWorkItemAndTotalCost = laborCombinedData.ToList();

            var machineWorkItemAndTotalCost = machineFallows.GroupBy(machineFallow => machineFallow.WorkItem)
                                                            .Select(group => new
                                                            {
                                                                WorkItem = group.Key,
                                                                TotalCost = group.Sum(machineFallow => machineFallow.TotalCost)
                                                            }).ToList();

            var materialWorkItemAndTotalCost = materialData.GroupBy(material => material.WorkItem)
                                                           .Select(group => new
                                                           {
                                                               WorkItem = group.Key,
                                                               TotalCost = group.Sum(material => material.TotalCost)
                                                           }).ToList();

            List<CLS_Totals> cLS_Totals = (from workItem in workItems
                                           join contract in contractWorkItemAndCost on workItem.Items equals contract.WorkItem into contractGroup
                                           from contract in contractGroup.DefaultIfEmpty()
                                           join labor in laborWorkItemAndTotalCost on workItem.Items equals labor.WorkItem into laborGroup
                                           from labor in laborGroup.DefaultIfEmpty()
                                           join machine in machineWorkItemAndTotalCost on workItem.Items equals machine.WorkItem into machineGroup
                                           from machine in machineGroup.DefaultIfEmpty()
                                           join material in materialWorkItemAndTotalCost on workItem.Items equals material.WorkItem into materialGroup
                                           from material in materialGroup.DefaultIfEmpty()
                                           select new CLS_Totals
                                           {
                                               WorkItem = workItem.Items,
                                               MaterialCost = material?.TotalCost ?? 0,
                                               MachineCost = machine?.TotalCost ?? 0,
                                               LaborCost = labor?.TotalCost ?? 0,
                                               ContractCost = double.TryParse(contract?.ContractCost, out double contractCost) ? contractCost : 0
                                           }).ToList();

            gcLaborData.DataSource = cLS_Totals;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new FRM_Show_All_Projects().Show();
        }

        private void FRM_ProjectSpentCost_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new FRM_Show_All_Projects().Show();
        }
    }
}