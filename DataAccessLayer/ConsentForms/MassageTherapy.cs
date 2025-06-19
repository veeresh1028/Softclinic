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
    public class MassageTherapy
    {
        public static DataTable GetMassageTherapyData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Massage_Therapy_Consent_Select");

                db.AddInParameter(dbCommand, "mtc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMassageTherapy(BusinessEntities.ConsentForms.MassageTherapy hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Massage_Therapy_Consent_Insert");

                db.AddInParameter(dbCommand, "mtc_appId", DbType.Int32, hijama.mtc_appId);
                db.AddInParameter(dbCommand, "mtc_1", DbType.String, string.IsNullOrEmpty(hijama.mtc_1) ? "" : hijama.mtc_1);
                db.AddInParameter(dbCommand, "mtc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mtcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mtcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mtcId"));
                return _mtcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMassageTherapy(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Massage_Therapy_Consent_Delete");

                db.AddInParameter(dbCommand, "mtc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mtc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mtc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mtc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mtc_output"));

                return _mtc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMassageTherapyPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Massage_Therapy_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "mtc_appId", DbType.Int32, appId);
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
