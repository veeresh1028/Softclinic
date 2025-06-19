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
    public class BotoxConstantForm
    {
        public static DataTable GetBotoxConstantFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Constant_Form_Select");

                db.AddInParameter(dbCommand, "bcf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveBotoxConstantForm(BusinessEntities.ConsentForms.BotoxConstantForm botox, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Constant_Form_Insert");

                db.AddInParameter(dbCommand, "bcf_appId", DbType.Int32, botox.bcf_appId);
                db.AddInParameter(dbCommand, "bcf_1", DbType.String, string.IsNullOrEmpty(botox.bcf_1) ? "" : botox.bcf_1);
                db.AddInParameter(dbCommand, "bcf_2", DbType.String, string.IsNullOrEmpty(botox.bcf_2) ? "" : botox.bcf_2);
                db.AddInParameter(dbCommand, "bcf_3", DbType.String, string.IsNullOrEmpty(botox.bcf_3) ? "" : botox.bcf_3);
                db.AddInParameter(dbCommand, "bcf_chk", DbType.String, string.IsNullOrEmpty(botox.bcf_chk) ? "" : botox.bcf_chk);
                db.AddInParameter(dbCommand, "bcf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "bcfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _bcfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "bcfId"));
                return _bcfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteBotoxConstantForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Constant_Form_Delete");

                db.AddInParameter(dbCommand, "bcf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "bcf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "bcf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _bcf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "bcf_output"));

                return _bcf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetBotoxConstantFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Constant_Form_PreviousHistroy");

                db.AddInParameter(dbCommand, "bcf_appId", DbType.Int32, appId);
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
