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
    public class DischargeUltralasikTreatmentNew
    {
        public static DataTable GetDischargeUltralasikTreatmentNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasik_Treatment_New_Select");

                db.AddInParameter(dbCommand, "dsut_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeUltralasikTreatmentNew(BusinessEntities.ConsentForms.DischargeUltralasikTreatmentNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasik_Treatment_New_Insert");

                db.AddInParameter(dbCommand, "dsut_appId", DbType.Int32, discharge.dsut_appId);
                db.AddInParameter(dbCommand, "dsut_1", DbType.String, string.IsNullOrEmpty(discharge.dsut_1) ? "" : discharge.dsut_1);
                db.AddInParameter(dbCommand, "dsut_2", DbType.String, string.IsNullOrEmpty(discharge.dsut_2) ? "" : discharge.dsut_2);
                db.AddInParameter(dbCommand, "dsut_3", DbType.String, string.IsNullOrEmpty(discharge.dsut_3) ? "" : discharge.dsut_3);
                db.AddInParameter(dbCommand, "dsut_4", DbType.String, string.IsNullOrEmpty(discharge.dsut_4) ? "" : discharge.dsut_4);
                db.AddInParameter(dbCommand, "dsut_5", DbType.String, string.IsNullOrEmpty(discharge.dsut_5) ? "" : discharge.dsut_5);
                db.AddInParameter(dbCommand, "dsut_6", DbType.String, string.IsNullOrEmpty(discharge.dsut_6) ? "" : discharge.dsut_6);
                db.AddInParameter(dbCommand, "dsut_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dsutId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dsutId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dsutId"));
                return _dsutId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeUltralasikTreatmentNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasik_Treatment_New_Delete");

                db.AddInParameter(dbCommand, "dsut_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dsut_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dsut_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dsut_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dsut_output"));

                return _dsut_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeUltralasikTreatmentNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Ultralasik_Treatment_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dsut_appId", DbType.Int32, appId);
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
