using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaProjectV2.Model
{
    public class CLS_MachineData
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string MachineNumber { get; set; }
        public double WageRent { get; set; }
        public double WageMaintenance { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key
    }

}
