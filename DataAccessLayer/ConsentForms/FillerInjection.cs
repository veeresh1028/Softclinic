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
    public class FillerInjection
    {
        public static DataTable GetFillerInjectionData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Injection_Form_Select");

                db.AddInParameter(dbCommand, "fif_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveFillerInjection(BusinessEntities.ConsentForms.FillerInjection derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Injection_Form_Insert");

                db.AddInParameter(dbCommand, "fif_appId", DbType.Int32, derma.fif_appId);
                db.AddInParameter(dbCommand, "fif_1", DbType.String, string.IsNullOrEmpty(derma.fif_1) ? "" : derma.fif_1);
                db.AddInParameter(dbCommand, "fif_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "fifId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _fifId = Convert.ToInt32(db.GetParameterValue(dbCommand, "fifId"));
                return _fifId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteFillerInjection(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Injection_Form_Delete");

                db.AddInParameter(dbCommand, "fif_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "fif_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "fif_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _fif_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "fif_output"));

                return _fif_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFillerInjectionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Injection_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "fif_appId", DbType.Int32, appId);
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
