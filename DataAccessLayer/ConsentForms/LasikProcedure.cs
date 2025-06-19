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
    public class LasikProcedure
    {
        public static DataTable GetLasikProcedureData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lasik_Procedure_Form_New_Select");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLasikProcedure(BusinessEntities.ConsentForms.LasikProcedure ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lasik_Procedure_Form_New_Insert");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, ophtha.lpf_appId);
                db.AddInParameter(dbCommand, "lpf_1", DbType.String, string.IsNullOrEmpty(ophtha.lpf_1) ? "" : ophtha.lpf_1);
                db.AddInParameter(dbCommand, "lpf_2", DbType.String, string.IsNullOrEmpty(ophtha.lpf_2) ? "" : ophtha.lpf_2);
                db.AddInParameter(dbCommand, "lpf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lpfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lpfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lpfId"));
                return _lpfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLasikProcedure(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lasik_Procedure_Form_New_Delete");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lpf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lpf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lpf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lpf_output"));

                return _lpf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLasikProcedurePreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lasik_Procedure_Form_New_PreviousHistory");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, appId);
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
