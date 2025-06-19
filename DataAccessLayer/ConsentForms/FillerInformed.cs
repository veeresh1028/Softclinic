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
    public class FillerInformed
    {
        public static DataTable GetFillerInformedData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Derma_Select");

                db.AddInParameter(dbCommand, "fic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveFillerInformed(BusinessEntities.ConsentForms.FillerInformed derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Derma_Insert");

                db.AddInParameter(dbCommand, "fic_appId", DbType.Int32, derma.fic_appId);
                db.AddInParameter(dbCommand, "fic_1", DbType.String, string.IsNullOrEmpty(derma.fic_1) ? "" : derma.fic_1);
                db.AddInParameter(dbCommand, "fic_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ficId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ficId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ficId"));
                return _ficId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteFillerInformed(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Derma_Delete");

                db.AddInParameter(dbCommand, "fic_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "fic_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "fic_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _fic_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "fic_output"));

                return _fic_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFillerInformedPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "fic_appId", DbType.Int32, appId);
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
