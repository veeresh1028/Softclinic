using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NurseStation
{
    public class InjectionAdministration
    {
        #region  Justification Letter (Page Load)
        public static DataTable GetAllInjectionAdministration(int? appId, int? mrfId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medication_Report_Form_select_all_info");
                if (mrfId > 0)
                {
                    db.AddInParameter(dbCommand, "mrfId", DbType.Int32, mrfId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAllPreInjectionAdministration(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory(); 
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medication_Report_Form_Previous");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion  Justification Letter (Page Load)

        #region  Justification Letter CRUD Operations
        public static bool InsertUpdateInjectionAdministration(BusinessEntities.NurseStation.InjectionAdministration data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medication_Report_Form_Insert_Update");
                if (data.mrfId > 0)
                {
                    db.AddInParameter(dbCommand, "mrfId", DbType.Int32, data.mrfId);
                }
                db.AddInParameter(dbCommand, "mrf_appId", DbType.Int32, data.mrf_appId);
                db.AddInParameter(dbCommand, "mrf_1", DbType.String, data.mrf_1);
                db.AddInParameter(dbCommand, "mrf_2", DbType.String, data.mrf_2);
                db.AddInParameter(dbCommand, "mrf_3", DbType.String, data.mrf_3);
                db.AddInParameter(dbCommand, "mrf_4", DbType.String, data.mrf_4);
                db.AddInParameter(dbCommand, "mrf_5", DbType.DateTime, data.mrf_5);
                db.AddInParameter(dbCommand, "mrf_madeby", DbType.Int32, data.mrf_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteInjectionAdministration(int mrfId, int mrf_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medication_Report_Form_delete");

                db.AddInParameter(dbCommand, "mrfId", DbType.Int32, mrfId);
                db.AddInParameter(dbCommand, "mrf_madeby", DbType.String, mrf_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion  Justification Letter CRUD Operations
    }
}
