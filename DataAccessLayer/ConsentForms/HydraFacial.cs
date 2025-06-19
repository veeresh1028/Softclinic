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
    public class HydraFacial
    {
        public static DataTable GetHydraFacialData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hydra_Facial_Consent_Select");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveHydraFacial(BusinessEntities.ConsentForms.HydraFacial hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hydra_Facial_Consent_Insert");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, hijama.hfc_appId);
                db.AddInParameter(dbCommand, "hfc_1", DbType.String, string.IsNullOrEmpty(hijama.hfc_1) ? "" : hijama.hfc_1);
                db.AddInParameter(dbCommand, "hfc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "hfcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _hfcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "hfcId"));
                return _hfcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteHydraFacial(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hydra_Facial_Consent_Delete");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "hfc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "hfc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _hfc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "hfc_output"));

                return _hfc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetHydraFacialPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hydra_Facial_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, appId);
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
