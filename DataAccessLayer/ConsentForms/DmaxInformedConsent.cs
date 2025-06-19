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
    public class DmaxInformedConsent
    {
        public static DataTable GetDmaxInformedConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Informed_Consent_Select");

                db.AddInParameter(dbCommand, "dic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxInformedConsent(BusinessEntities.ConsentForms.DmaxInformedConsent dmax, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Informed_Consent_Insert");

                db.AddInParameter(dbCommand, "dic_appId", DbType.Int32, dmax.dic_appId);
                db.AddInParameter(dbCommand, "dic_1", DbType.String, string.IsNullOrEmpty(dmax.dic_1) ? "" : dmax.dic_1);
                db.AddInParameter(dbCommand, "dic_2", DbType.String, string.IsNullOrEmpty(dmax.dic_2) ? "" : dmax.dic_2);
                db.AddInParameter(dbCommand, "dic_date", DbType.String, string.IsNullOrEmpty(dmax.dic_date) ? "" : dmax.dic_date);
                db.AddInParameter(dbCommand, "dic_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dicId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dicId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dicId"));
                return _dicId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxInformedConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Informed_Consent_Delete");

                db.AddInParameter(dbCommand, "dic_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dic_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dic_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dic_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dic_output"));

                return _dic_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxInformedConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Informed_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "dic_appId", DbType.Int32, appId);
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
