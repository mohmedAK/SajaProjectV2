using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_MaterialData
    {
        public int Id { get; set; }
        public string WorkItem { get; set; }
        public string MaterialName { get; set; }
        public int PlanningQuantity { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key

        public double TotalCost
        {
            get
            {
                return PlanningQuantity * Price;
            }
        }
    }

}
