using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicatia_2.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Patient's First Name")]

        public string PatientFirstName { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Patient's Last Name")]

        public string PatientLastName { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        public string Disease { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        [Display(Name = " Treatment")]
        public ICollection<PatientTreatment> PatientTreatments{ get; set; }
    }
}
