using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaProjectV2.Model
{
    public class CLS_Contract
    {
        public int Id { get; set; }
        public string ContractorName { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Details { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key
    }

}
