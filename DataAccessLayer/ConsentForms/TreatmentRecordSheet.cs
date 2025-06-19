using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConsentForms
{
    public class TreatmentRecordSheet
    {
        public static DataTable GetTreatmentRecordSheetData(int appId, int? trsId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Treatment_Record_Sheet_Select");
                if (trsId > 0)
                {
                    db.AddInParameter(dbCommand, "trsId", DbType.Int32, trsId);
                }
                db.AddInParameter(dbCommand, "trs_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveTreatmentRecordSheet(BusinessEntities.ConsentForms.TreatmentRecordSheet treatment, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Treatment_Record_Sheet_Insert");

                db.AddInParameter(dbCommand, "trs_appId", DbType.Int32, treatment.trs_appId);
                db.AddInParameter(dbCommand, "trsIds", DbType.Int32, treatment.trsId);
                db.AddInParameter(dbCommand, "trs_treat", DbType.String, string.IsNullOrEmpty(treatment.trs_treat) ? "" : treatment.trs_treat);
                db.AddInParameter(dbCommand, "trs_1", DbType.String, string.IsNullOrEmpty(treatment.trs_1) ? "" : treatment.trs_1);
                db.AddInParameter(dbCommand, "trs_date1", DbType.String, string.IsNullOrEmpty(treatment.trs_date1) ? "" : treatment.trs_date1);
                db.AddInParameter(dbCommand, "trs_notes", DbType.String, string.IsNullOrEmpty(treatment.trs_notes) ? "" : treatment.trs_notes);
                db.AddInParameter(dbCommand, "trs_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "trsId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _trsId = Convert.ToInt32(db.GetParameterValue(dbCommand, "trsId"));
                return _trsId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteTreatmentRecordSheet(int trsId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Treatment_Record_Sheet_Delete");

                db.AddInParameter(dbCommand, "trsId", DbType.Int32, trsId);
                db.AddInParameter(dbCommand, "trs_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "trs_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _trs_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "trs_output"));

                return _trs_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetTreatmentRecordSheetPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Treatment_Record_Sheet_PreviousHistory");

                db.AddInParameter(dbCommand, "trs_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
