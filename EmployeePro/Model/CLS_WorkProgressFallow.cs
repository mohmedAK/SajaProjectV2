using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_WorkProgressFallow
    {
        public int Id { get; set; }
        public string WorkItem { get; set; }
        public int PlaningQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public double PlaningCost { get; set; }
        public double ActualCost { get; set; }
        public double PlaningDuration { get; set; }
        public double ActualDuration { get; set; }

        public double A { get; set; }
        public double P { get; set; }

        public double EV { 
            get{
                return A * PlaningCost;
            } 
        }

        public double PV
        {
            get
            {
                return P * PlaningCost;
            }
        }

        public double SPI
        {
            get
            {
                return EV / PV;
            }
        }

        public double CPI
        {
            get
            {
                return EV / ActualCost;
            }
        }

        public double CSI
        {
            get
            {
                return SPI * CPI;
            }
        }




        public DateTime CurrentDate { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key


     
    }

}
