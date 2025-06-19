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
    public class SpeechProgressChart
    {
        public static DataTable GetSpeechProgressChartData(int appId, int? spcId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Speech_Progress_Chart_Select");
                if (spcId > 0)
                {
                    db.AddInParameter(dbCommand, "spcId", DbType.Int32, spcId);
                }
                db.AddInParameter(dbCommand, "spc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveSpeechProgressChart(BusinessEntities.ConsentForms.SpeechProgressChart speech, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Speech_Progress_Chart_Insert");

                db.AddInParameter(dbCommand, "spc_appId", DbType.Int32, speech.spc_appId);
                db.AddInParameter(dbCommand, "spcIds", DbType.Int32, speech.spcId);
                db.AddInParameter(dbCommand, "spc_date1", DbType.String, string.IsNullOrEmpty(speech.spc_date1) ? "" : speech.spc_date1);
                db.AddInParameter(dbCommand, "spc_1", DbType.String, string.IsNullOrEmpty(speech.spc_1) ? "" : speech.spc_1);
                db.AddInParameter(dbCommand, "spc_color", DbType.String, string.IsNullOrEmpty(speech.spc_color) ? "" : speech.spc_color);
                db.AddInParameter(dbCommand, "spc_2", DbType.String, string.IsNullOrEmpty(speech.spc_2) ? "" : speech.spc_2);
                db.AddInParameter(dbCommand, "spc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "spcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _spcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "spcId"));
                return _spcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteSpeechProgressChart(int spcId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Speech_Progress_Chart_Delete");

                db.AddInParameter(dbCommand, "spcId", DbType.Int32, spcId);
                db.AddInParameter(dbCommand, "spc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "spc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _spc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "spc_output"));

                return _spc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSpeechProgressChartPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Speech_Progress_Chart_PreviousHistory");

                db.AddInParameter(dbCommand, "spc_appId", DbType.Int32, appId);
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
