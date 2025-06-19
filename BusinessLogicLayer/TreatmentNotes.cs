using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TreatmentNotes
    {
        #region Treatment Notes Master (Page Load)
        public static List<BusinessEntities.Masters.TreatmentNotes> GetTreatmentNotes(int? tdnId, int? tdn_doctor)
        {
            List<BusinessEntities.Masters.TreatmentNotes> noteslist = new List<BusinessEntities.Masters.TreatmentNotes>();

            DataTable dt = DataAccessLayer.Masters.TreatmentNotes.GetTreatmentNotes(tdnId, tdn_doctor);

            foreach (DataRow dr in dt.Rows)
            {
                noteslist.Add(new BusinessEntities.Masters.TreatmentNotes
                {
                    tdnId = Convert.ToInt32(dr["tdnId"]),
                    tdn_code = dr["tdn_code"].ToString(),
                    tdn_notes = dr["tdn_notes"].ToString(),
                    tdn_doctor = Convert.ToInt32(dr["tdn_doctor"].ToString()),
                    tdn_status = dr["tdn_status"].ToString()
                });
            }
            return noteslist;
        }
        #endregion

        #region Treatment Notes CRUD Operations
        public static bool InsertUpdateTreatmentNote(BusinessEntities.Masters.TreatmentNotes treatmentNotes)
        {
            return DataAccessLayer.Masters.TreatmentNotes.InsertUpdateTreatmentNote(treatmentNotes);
        }

        public static int UpdateTreatmentNoteStatus(int tdnId, string tdn_status)
        {
            return DataAccessLayer.Masters.TreatmentNotes.UpdateTreatmentNoteStatus(tdnId, tdn_status);
        }
        #endregion
    }
}