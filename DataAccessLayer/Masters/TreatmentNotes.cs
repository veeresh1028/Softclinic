using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class TreatmentNotes
    {
        #region Designations Master (Page Load)
        public static DataTable GetTreatmentNotes(int? tdnId, int? tdn_doctor)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_DOCTOR_NOTES_select_all_info");

                if (tdnId > 0)
                {
                    db.AddInParameter(dbCommand, "tdnId", DbType.Int32, tdnId);
                }

                if (tdn_doctor > 0)
                {
                    db.AddInParameter(dbCommand, "tdn_doctor", DbType.Int32, tdn_doctor);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Designations CRUD Operations
        public static bool InsertUpdateTreatmentNote(BusinessEntities.Masters.TreatmentNotes treamtnetNotes)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_DOCTOR_NOTES_insert");

                if (treamtnetNotes.tdnId > 0)
                {
                    db.AddInParameter(dbCommand, "tdnId", DbType.Int32, treamtnetNotes.tdnId);
                }

                db.AddInParameter(dbCommand, "tdn_code", DbType.String, treamtnetNotes.tdn_code);
                db.AddInParameter(dbCommand, "tdn_doctor", DbType.Int32, treamtnetNotes.tdn_doctor);
                db.AddInParameter(dbCommand, "tdn_notes", DbType.String, treamtnetNotes.tdn_notes);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateTreatmentNoteStatus(int tdnId, string tdn_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_DOCTOR_NOTES_update_status");

                db.AddInParameter(dbCommand, "tdnId", DbType.Int32, tdnId);
                db.AddInParameter(dbCommand, "tdn_status", DbType.String, tdn_status);
                
                db.AddOutParameter(dbCommand, "tdn_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "tdn_output").ToString());

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}