using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_Totals
    {
        public  int Id { get; set; }
        public string WorkItem { get; set; }

        public double ContractCost { get; set; }

        public double LaborCost { get; set; }

        public double MachineCost { get; set; }

        public double MaterialCost { get; set; }

        public double TotalCost
        {
            get
            {
                return ContractCost + LaborCost + MachineCost + MaterialCost;
            }
        }
    }
}
