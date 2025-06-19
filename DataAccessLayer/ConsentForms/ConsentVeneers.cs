using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class ConsentVeneers
    {
        public static DataTable GetConsentVeneersData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Veneers_Select");

                db.AddInParameter(dbCommand, "cicv_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveConsentVeneers(BusinessEntities.ConcentForms.ConsentVeneers veneers, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Veneers_Insert");

                db.AddInParameter(dbCommand, "cicv_appId", DbType.Int32, veneers.cicv_appId);
                db.AddInParameter(dbCommand, "cicv_1", DbType.String, veneers.cicv_1);
                db.AddInParameter(dbCommand, "cicv_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cicvId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cicvId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cicvId"));
                return _cicvId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteConsentVeneers(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Veneers_Delete");

                db.AddInParameter(dbCommand, "cicv_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cicv_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cicv_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cicv_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cicv_output"));

                return _cicv_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetConsentVeneersPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Veneers_PreviousHistory");

                db.AddInParameter(dbCommand, "cicv_appId", DbType.Int32, appId);
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

