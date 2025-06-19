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
    public class ParsPlana
    {
        public static DataTable GetParsPlanaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pars_Plana_Vitrectomy_New_Select");

                db.AddInParameter(dbCommand, "ppv_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveParsPlana(BusinessEntities.ConsentForms.ParsPlana ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pars_Plana_Vitrectomy_New_Insert");

                db.AddInParameter(dbCommand, "ppv_appId", DbType.Int32, ophtha.ppv_appId);
                db.AddInParameter(dbCommand, "ppv_1", DbType.String, string.IsNullOrEmpty(ophtha.ppv_1) ? "" : ophtha.ppv_1);
                db.AddInParameter(dbCommand, "ppv_2", DbType.String, string.IsNullOrEmpty(ophtha.ppv_2) ? "" : ophtha.ppv_2);
                db.AddInParameter(dbCommand, "ppv_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ppvId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ppvId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ppvId"));
                return _ppvId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteParsPlana(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pars_Plana_Vitrectomy_New_Delete");

                db.AddInParameter(dbCommand, "ppv_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ppv_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ppv_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ppv_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ppv_output"));

                return _ppv_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetParsPlanaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pars_Plana_Vitrectomy_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ppv_appId", DbType.Int32, appId);
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
