using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_MachineFallow
    {
        public int Id { get; set; }
        public string WorkItem { get; set; }
        public string MachineName { get; set; }

        public string MachineNumber { get; set; }
        public double RentPrice { get; set; }
        public int OperationDays { get; set; }
        public double OperationPrice { get; set; }
        public int RentDays { get; set; }   
        public DateTime CurrentDate { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key

        public double TotalRentPrice => RentPrice * RentDays;

        public double TotalOperationPrice => OperationPrice * OperationDays;

        public double TotalCost => TotalRentPrice + TotalOperationPrice;
    }

}
