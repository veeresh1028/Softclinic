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
    public class SurgicalAct
    {
        public static DataTable GetSurgicalActData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgical_Act_Form_New_Select");

                db.AddInParameter(dbCommand, "saf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveSurgicalAct(BusinessEntities.ConsentForms.SurgicalAct ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgical_Act_Form_New_Insert");

                db.AddInParameter(dbCommand, "saf_appId", DbType.Int32, ophtha.saf_appId);
                db.AddInParameter(dbCommand, "saf_1", DbType.String, string.IsNullOrEmpty(ophtha.saf_1) ? "" : ophtha.saf_1);
                db.AddInParameter(dbCommand, "saf_2", DbType.String, string.IsNullOrEmpty(ophtha.saf_2) ? "" : ophtha.saf_2);
                db.AddInParameter(dbCommand, "saf_3", DbType.String, string.IsNullOrEmpty(ophtha.saf_3) ? "" : ophtha.saf_3);
                db.AddInParameter(dbCommand, "saf_4", DbType.String, string.IsNullOrEmpty(ophtha.saf_4) ? "" : ophtha.saf_4);
                db.AddInParameter(dbCommand, "saf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "safId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _safId = Convert.ToInt32(db.GetParameterValue(dbCommand, "safId"));
                return _safId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteSurgicalAct(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgical_Act_Form_New_Delete");

                db.AddInParameter(dbCommand, "saf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "saf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "saf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _saf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "saf_output"));

                return _saf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSurgicalActPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgical_Act_Form_New_PreviousHistory");

                db.AddInParameter(dbCommand, "saf_appId", DbType.Int32, appId);
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
