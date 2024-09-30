using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaProjectV2.Model
{
    public class CLS_MaterialFallow
    {
        public int Id { get; set; }
        public string WorkItem { get; set; }
        public int ActualQuantity { get; set; }
        public DateTime CurrentDate { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key
    }

}
