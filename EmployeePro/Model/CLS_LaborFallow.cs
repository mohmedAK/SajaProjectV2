﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaProjectV2.Model
{
    public class CLS_LaborFallow
    {
        public int Id { get; set; }
        public string WorkItem { get; set; }
        public string LaborType { get; set; }
        public int NumLabor { get; set; }
        public int WorkDay { get; set; }
        public DateTime CurrentDate { get; set; }
        public int ProjectIdFk { get; set; } // Foreign Key
    }

}