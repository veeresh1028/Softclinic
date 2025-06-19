using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Tab
{
    public class Feedback
    {
        public static DataTable GetFeedbackData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Feedback");

                db.AddInParameter(dbCommand, "cpf_appId", DbType.Int32, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int SaveFeedback(BusinessEntities.Tab.Feedback feed)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Feedback_Insert");

                db.AddInParameter(dbCommand, "cpf_appId", DbType.Int32, feed.cpf_appId);
                db.AddInParameter(dbCommand, "cpf_text", DbType.String, string.IsNullOrEmpty(feed.cpf_text) ? string.Empty : feed.cpf_text);
                db.AddInParameter(dbCommand, "cpf_rating", DbType.String, string.IsNullOrEmpty(feed.cpf_rating) ? string.Empty : feed.cpf_rating);

                db.AddOutParameter(dbCommand, "cpfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cpfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpfId"));

                return _cpfId;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}