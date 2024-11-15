﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_MaterialFallow
    {
 
        public int Id { get; set; }
        public string WorkItem { get; set; }
        public string MaterialName { get; set; }
        public int ActualQuantity { get; set; }
        public double MaterialCost { get; set; }
      
        public double ActualCost
        {
            get
            {
                return ActualQuantity * MaterialCost;

            }
        }
        public DateTime CurrentDate { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key

    
    }

}
