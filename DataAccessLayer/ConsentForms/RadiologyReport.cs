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
    public class RadiologyReport
    {
        public static DataTable GetRadiologyReportData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Radiology_Report_Form_Select");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveRadiologyReport(BusinessEntities.ConsentForms.RadiologyReport ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Radiology_Report_Form_Insert");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, ophtha.rrf_appId);

                db.AddInParameter(dbCommand, "rrf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "rrfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _rrfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "rrfId"));
                return _rrfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteRadiologyReport(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Radiology_Report_Form_Delete");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "rrf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "rrf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _rrf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "rrf_output"));

                return _rrf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetRadiologyReportPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Radiology_Report_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "rrf_appId", DbType.Int32, appId);
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
