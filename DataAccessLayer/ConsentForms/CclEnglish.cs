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
    public class CclEnglish
    {
        public static DataTable GetCclEnglishData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ccl_English_Form_New_Select");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveCclEnglish(BusinessEntities.ConsentForms.CclEnglish ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ccl_English_Form_New_Insert");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, ophtha.cef_appId);
                db.AddInParameter(dbCommand, "cef_1", DbType.String, string.IsNullOrEmpty(ophtha.cef_1) ? "" : ophtha.cef_1);
                db.AddInParameter(dbCommand, "cef_2", DbType.String, string.IsNullOrEmpty(ophtha.cef_2) ? "" : ophtha.cef_2);
                db.AddInParameter(dbCommand, "cef_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cefId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cefId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cefId"));
                return _cefId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteCclEnglish(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ccl_English_Form_New_Delete");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cef_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cef_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cef_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cef_output"));

                return _cef_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCclEnglishPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ccl_English_Form_New_PreviousHistory");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, appId);
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
