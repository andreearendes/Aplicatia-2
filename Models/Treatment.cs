using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Aplicatia_2.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        [Display(Name = "Treatment's Name")]

        public string TreatmentName { get; set; }
        public ICollection<PatientTreatment> PatientTreatments  { get; set; }
    }
}
