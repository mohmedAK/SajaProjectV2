using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_WorkItem
    {
        public int Id { get; set; }
        public string Items { get; set; }

        public double ItemCost { get; set; }

        public bool contract { get; set; }

        public int ProjectIdFk { get; set; } // Foreign Key
    }
}
