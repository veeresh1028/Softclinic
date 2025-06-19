using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Patient.Treatments
{
    public class PatientTreatment
    {
        public static int CreatePatientTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            return DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);
        }

        public static int DeletePatientTreatments(List<int> ptIds, int madeby)
        {
            int val = 0;

            foreach (int ptId in ptIds)
            {
                val += DataAccessLayer.Patient.Treatments.PatientTreatment.DeletePatientTreatments(ptId, madeby);
            }

            return val;
        }
    }
}