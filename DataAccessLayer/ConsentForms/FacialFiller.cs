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
    public class FacialFiller
    {
        public static DataTable GetFacialFillerData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Filler_Consent_Select");

                db.AddInParameter(dbCommand, "ffc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveFacialFiller(BusinessEntities.ConsentForms.FacialFiller hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Filler_Consent_Insert");

                db.AddInParameter(dbCommand, "ffc_appId", DbType.Int32, hijama.ffc_appId);
                db.AddInParameter(dbCommand, "ffc_1", DbType.String, string.IsNullOrEmpty(hijama.ffc_1) ? "" : hijama.ffc_1);
                db.AddInParameter(dbCommand, "ffc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ffcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ffcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ffcId"));
                return _ffcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteFacialFiller(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Filler_Consent_Delete");

                db.AddInParameter(dbCommand, "ffc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ffc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ffc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ffc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ffc_output"));

                return _ffc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFacialFillerPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Filler_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "ffc_appId", DbType.Int32, appId);
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
