using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer.InsuranceForms
{
    public class NasAdviceForm
    {
        public static DataTable GetNasAdviceFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Advice_Form_Select");

                db.AddInParameter(dbCommand, "naf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveNasAdviceForm(BusinessEntities.InsuranceForms.NasAdviceForm medical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Advice_Form_Insert");

                db.AddInParameter(dbCommand, "naf_appId", DbType.Int32, medical.naf_appId);
                db.AddInParameter(dbCommand, "naf_1", DbType.String, string.IsNullOrEmpty(medical.naf_1) ? "" : medical.naf_1);
                db.AddInParameter(dbCommand, "naf_chk", DbType.String, string.IsNullOrEmpty(medical.naf_chk) ? "" : medical.naf_chk);

                db.AddInParameter(dbCommand, "naf_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@nafId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _nafId = db.ExecuteNonQuery(dbCommand);

                return _nafId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteNasAdviceForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Advice_Form_Delete");

                db.AddInParameter(dbCommand, "naf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "naf_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetNasAdviceFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Advice_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "naf_appId", DbType.Int32, appId);
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
