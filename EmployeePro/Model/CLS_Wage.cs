using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePro.Model
{
    class CLS_Wage
    {
        public int EmpId { get; set; }
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public double Salary { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
    }
}
