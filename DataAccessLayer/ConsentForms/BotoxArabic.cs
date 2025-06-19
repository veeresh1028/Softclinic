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
    public class BotoxArabic
    {
        public static DataTable GetBotoxArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Arabic_Form_Select");

                db.AddInParameter(dbCommand, "baf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveBotoxArabic(BusinessEntities.ConsentForms.BotoxArabic derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Arabic_Form_Insert");

                db.AddInParameter(dbCommand, "baf_appId", DbType.Int32, derma.baf_appId);
                db.AddInParameter(dbCommand, "baf_1", DbType.String, string.IsNullOrEmpty(derma.baf_1) ? "" : derma.baf_1);
                db.AddInParameter(dbCommand, "baf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "bafId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _bafId = Convert.ToInt32(db.GetParameterValue(dbCommand, "bafId"));
                return _bafId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteBotoxArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Arabic_Form_Delete");

                db.AddInParameter(dbCommand, "baf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "baf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "baf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _baf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "baf_output"));

                return _baf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetBotoxArabicPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Arabic_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "baf_appId", DbType.Int32, appId);
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
