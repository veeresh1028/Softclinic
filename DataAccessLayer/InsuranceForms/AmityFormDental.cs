using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer.InsuranceForms
{
    public class AmityFormDental
    {
        public static DataTable GetAmityFormDentalData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Provider_Dental_Select");

                db.AddInParameter(dbCommand, "mpd_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAmityFormDental(BusinessEntities.InsuranceForms.AmityFormDental dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Provider_Dental_Insert");

                db.AddInParameter(dbCommand, "mpd_appId", DbType.Int32, dental.mpd_appId);
                db.AddInParameter(dbCommand, "mpd_radio1", DbType.String, string.IsNullOrEmpty(dental.mpd_radio1) ? "" : dental.mpd_radio1);
                db.AddInParameter(dbCommand, "mpd_radio2", DbType.String, string.IsNullOrEmpty(dental.mpd_radio2) ? "" : dental.mpd_radio2);
                db.AddInParameter(dbCommand, "mpd_medications", DbType.String, string.IsNullOrEmpty(dental.mpd_medications) ? "" : dental.mpd_medications);
                db.AddInParameter(dbCommand, "mpd_pathalogy", DbType.String, string.IsNullOrEmpty(dental.mpd_pathalogy) ? "" : dental.mpd_pathalogy);
                db.AddInParameter(dbCommand, "mpd_radiology", DbType.String, string.IsNullOrEmpty(dental.mpd_radiology) ? "" : dental.mpd_radiology);
                db.AddInParameter(dbCommand, "mpd_pre", DbType.String, string.IsNullOrEmpty(dental.mpd_pre) ? "" : dental.mpd_pre);
                db.AddInParameter(dbCommand, "mpd_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@mpdId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _mpdId = db.ExecuteNonQuery(dbCommand);

                return _mpdId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAmityFormDental(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Provider_Dental_Delete");

                db.AddInParameter(dbCommand, "mpd_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mpd_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAmityFormDentalPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Provider_Dental_PreviousHistory");

                db.AddInParameter(dbCommand, "mpd_appId", DbType.Int32, appId);
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
