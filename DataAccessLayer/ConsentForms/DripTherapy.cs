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
    public  class DripTherapy
    {
        public static DataTable GetDripTherapyData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Drip_Therapy_Consent_Select");

                db.AddInParameter(dbCommand, "dtc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDripTherapy(BusinessEntities.ConsentForms.DripTherapy hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Drip_Therapy_Consent_Insert");

                db.AddInParameter(dbCommand, "dtc_appId", DbType.Int32, hijama.dtc_appId);
                db.AddInParameter(dbCommand, "dtc_1", DbType.String, string.IsNullOrEmpty(hijama.dtc_1) ? "" : hijama.dtc_1);
                db.AddInParameter(dbCommand, "dtc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dtcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dtcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dtcId"));
                return _dtcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDripTherapy(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Drip_Therapy_Consent_Delete");

                db.AddInParameter(dbCommand, "dtc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dtc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dtc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dtc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dtc_output"));

                return _dtc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDripTherapyPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Drip_Therapy_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "dtc_appId", DbType.Int32, appId);
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
