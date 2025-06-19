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
    public class DmaxTooth
    {
        public static DataTable GetDmaxToothData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Tooth_Select");

                db.AddInParameter(dbCommand, "cdt_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxTooth(BusinessEntities.ConsentForms.DmaxTooth derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Tooth_Insert");

                db.AddInParameter(dbCommand, "cdt_appId", DbType.Int32, derma.cdt_appId);
                db.AddInParameter(dbCommand, "cdt_1", DbType.String, string.IsNullOrEmpty(derma.cdt_1) ? "" : derma.cdt_1);
                db.AddInParameter(dbCommand, "cdt_2", DbType.String, string.IsNullOrEmpty(derma.cdt_2) ? "" : derma.cdt_2);
                db.AddInParameter(dbCommand, "cdt_3", DbType.String, string.IsNullOrEmpty(derma.cdt_3) ? "" : derma.cdt_3);
                db.AddInParameter(dbCommand, "cdt_4", DbType.String, string.IsNullOrEmpty(derma.cdt_4) ? "" : derma.cdt_4);
                db.AddInParameter(dbCommand, "cdt_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdtId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdtId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdtId"));
                return _cdtId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxTooth(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Tooth_Delete");

                db.AddInParameter(dbCommand, "cdt_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cdt_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cdt_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cdt_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdt_output"));

                return _cdt_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxToothPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Tooth_PreviousHistory");

                db.AddInParameter(dbCommand, "cdt_appId", DbType.Int32, appId);
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
