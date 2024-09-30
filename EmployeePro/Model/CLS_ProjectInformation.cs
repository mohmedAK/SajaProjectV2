using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Model
{
    public class CLS_ProjectInformation
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string Value { get; set; }
        public string OwnerName { get; set; }
        public string Penalties { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Details { get; set; }
    }

}
