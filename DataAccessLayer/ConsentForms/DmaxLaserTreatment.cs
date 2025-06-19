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
    public class DmaxLaserTreatment
    {
        public static DataTable GetDmaxLaserTreatmentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Laser_Treatment_Select");

                db.AddInParameter(dbCommand, "dlt_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxLaserTreatment(BusinessEntities.ConsentForms.DmaxLaserTreatment dmax, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Laser_Treatment_Insert");

                db.AddInParameter(dbCommand, "dlt_appId", DbType.Int32, dmax.dlt_appId);
                db.AddInParameter(dbCommand, "dlt_1", DbType.String, string.IsNullOrEmpty(dmax.dlt_1) ? "" : dmax.dlt_1);
                db.AddInParameter(dbCommand, "dlt_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dltId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dltId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dltId"));
                return _dltId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxLaserTreatment(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Laser_Treatment_Delete");

                db.AddInParameter(dbCommand, "dlt_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dlt_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dlt_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dlt_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dlt_output"));

                return _dlt_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxLaserTreatmentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Laser_Treatment_PreviousHistory");

                db.AddInParameter(dbCommand, "dlt_appId", DbType.Int32, appId);
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
