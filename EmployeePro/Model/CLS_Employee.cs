using DevExpress.Printing.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaProjectV2.Model
{
    class CLS_Employee
    {
        public int EmpId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public byte[] Image  { get; set; }
        public double FinalTotal { get; set; }

    }
}
