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
    public class DmaxEndodontic
    {
        public static DataTable GetDmaxEndodonticData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Endodontic_Select");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxEndodontic(BusinessEntities.ConsentForms.DmaxEndodontic derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Endodontic_Insert");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, derma.cde_appId);
                db.AddInParameter(dbCommand, "cde_1", DbType.String, string.IsNullOrEmpty(derma.cde_1) ? "" : derma.cde_1);
                db.AddInParameter(dbCommand, "cde_2", DbType.String, string.IsNullOrEmpty(derma.cde_2) ? "" : derma.cde_2);
                db.AddInParameter(dbCommand, "cde_3", DbType.String, string.IsNullOrEmpty(derma.cde_3) ? "" : derma.cde_3);
                db.AddInParameter(dbCommand, "cde_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdeId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdeId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdeId"));
                return _cdeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxEndodontic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Endodontic_Delete");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cde_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cde_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cde_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cde_output"));

                return _cde_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxEndodonticPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Endodontic_PreviousHistory");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, appId);
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
