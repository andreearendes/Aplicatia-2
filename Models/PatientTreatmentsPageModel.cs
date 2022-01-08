using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicatia_2.Data;

namespace Aplicatia_2.Models
{
    public class PatientTreatmentsPageModel : PageModel
    {
        public List<AssignedTreatmentData> AssignedTreatmentDataList;
        public void PopulateAssignedTreatmentData(Aplicatia_2Context context, Patient patient)
        {
            var allTreatments = context.Treatment;
            var patientTreatments = new HashSet<int>(
            patient.PatientTreatments.Select(t => t.TreatmentID)); //
            AssignedTreatmentDataList = new List<AssignedTreatmentData>();
            foreach (var tre in allTreatments)
            {
                AssignedTreatmentDataList.Add(new AssignedTreatmentData
                {
                    TreatmentID = tre.TreatmentID,
                    Name = tre.TreatmentName,
                    Assigned = patientTreatments.Contains(tre.TreatmentID)
                });
            }
        }
        public void UpdatePatientTreatments(Aplicatia_2Context context,
        string[] selectedTreatments, Patient patientToUpdate)
        {
            if (selectedTreatments == null)
            {
                patientToUpdate.PatientTreatments = new List<PatientTreatment>();
                return;
            }
            var selectedTreatmentsHS = new HashSet<string>(selectedTreatments);
            var patientTreatments = new HashSet<int>
            (patientToUpdate.PatientTreatments.Select(t => t.Treatment.TreatmentID));
            foreach (var tre in context.Treatment)
            {
                if (selectedTreatmentsHS.Contains(tre.TreatmentID.ToString()))
                {
                    if (!patientTreatments.Contains(tre.TreatmentID))
                    {
                        patientToUpdate.PatientTreatments.Add(
                        new PatientTreatment
                        {
                            PatientID = patientToUpdate.PatientID,
                            TreatmentID = tre.TreatmentID
                        });
                    }
                }
                else
                {
                    if (patientTreatments.Contains(tre.TreatmentID))
                    {
                        PatientTreatment courseToRemove
                        = patientToUpdate
                        .PatientTreatments
                       .SingleOrDefault(i => i.TreatmentID == tre.TreatmentID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
