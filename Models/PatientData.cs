using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicatia_2.Models
{
    public class PatientData
    {
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }
        public IEnumerable<PatientTreatment> PatientTreatments { get; set; }
    }
}
