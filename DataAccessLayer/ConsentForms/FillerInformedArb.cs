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
    public class FillerInformedArb
    {
        public static DataTable GetFillerInformedArbData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "fica_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveFillerInformedArb(BusinessEntities.ConsentForms.FillerInformedArb derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "fica_appId", DbType.Int32, derma.fica_appId);
                db.AddInParameter(dbCommand, "fica_1", DbType.String, string.IsNullOrEmpty(derma.fica_1) ? "" : derma.fica_1);
                db.AddInParameter(dbCommand, "fica_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ficaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ficaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ficaId"));
                return _ficaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteFillerInformedArb(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "fica_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "fica_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "fica_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _fica_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "fica_output"));

                return _fica_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFillerInformedArbPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Informed_Consent_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "fica_appId", DbType.Int32, appId);
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
