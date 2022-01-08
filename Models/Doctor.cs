using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicatia_2.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Doctor's First Name")]

        public string DoctorFirstName { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = " Doctor's Last Name")]
        public string DoctorLastName { get; set; }
        public string Rank { get; set; }
        public string Specialization { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
