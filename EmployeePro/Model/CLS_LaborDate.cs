using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaProjectV2.Model
{
    public class CLS_LaborDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LaborType { get; set; }
        public string Occupation { get; set; }
        public double Wage { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key
    }

}
