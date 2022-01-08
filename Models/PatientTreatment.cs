using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicatia_2.Models
{
    public class PatientTreatment
    {
        public int PatientTreatmentID { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int TreatmentID { get; set; }
        public Treatment Treatment { get; set; }
    }
}
