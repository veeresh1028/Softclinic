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
    public class LucentisInjection
    {
        public static DataTable GetLucentisInjectionData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lucentis_Injection_Procedure_New_Select");

                db.AddInParameter(dbCommand, "lip_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLucentisInjection(BusinessEntities.ConsentForms.LucentisInjection ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lucentis_Injection_Procedure_New_Insert");

                db.AddInParameter(dbCommand, "lip_appId", DbType.Int32, ophtha.lip_appId);
                db.AddInParameter(dbCommand, "lip_1", DbType.String, string.IsNullOrEmpty(ophtha.lip_1) ? "" : ophtha.lip_1);
                db.AddInParameter(dbCommand, "lip_2", DbType.String, string.IsNullOrEmpty(ophtha.lip_2) ? "" : ophtha.lip_2);
                db.AddInParameter(dbCommand, "lip_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lipId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lipId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lipId"));
                return _lipId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLucentisInjection(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lucentis_Injection_Procedure_New_Delete");

                db.AddInParameter(dbCommand, "lip_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lip_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lip_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lip_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lip_output"));

                return _lip_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLucentisInjectionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lucentis_Injection_Procedure_New_PreviousHistory");

                db.AddInParameter(dbCommand, "lip_appId", DbType.Int32, appId);
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
