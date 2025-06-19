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
    public class VelashapeInformed
    {
        public static DataTable GetVelashapeInformedData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Velashape_Informed_Consent_Select");

                db.AddInParameter(dbCommand, "vic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveVelashapeInformed(BusinessEntities.ConsentForms.VelashapeInformed velashape, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Velashape_Informed_Consent_Insert");

                db.AddInParameter(dbCommand, "vic_appId", DbType.Int32, velashape.vic_appId);
                db.AddInParameter(dbCommand, "vic_1", DbType.String, string.IsNullOrEmpty(velashape.vic_1) ? "" : velashape.vic_1);
                db.AddInParameter(dbCommand, "vic_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "vicId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _vicId = Convert.ToInt32(db.GetParameterValue(dbCommand, "vicId"));
                return _vicId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteVelashapeInformed(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Velashape_Informed_Consent_Delete");

                db.AddInParameter(dbCommand, "vic_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "vic_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "vic_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _vic_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "vic_output"));

                return _vic_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetVelashapeInformedPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Velashape_Informed_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "vic_appId", DbType.Int32, appId);
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
