using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_ProjectItemData
    {
        public int Id { get; set; }
        public string WorkItem { get; set; }
        public double PlanningQuantity { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Details { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key
    }

}
