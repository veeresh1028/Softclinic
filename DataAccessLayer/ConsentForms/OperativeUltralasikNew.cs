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
    public class OperativeUltralasikNew
    {
        public static DataTable GetOperativeUltralasikNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasik_Treatment_New_Select");

                db.AddInParameter(dbCommand, "oriu_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveOperativeUltralasikNew(BusinessEntities.ConsentForms.OperativeUltralasikNew operative, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasik_Treatment_New_Insert");

                db.AddInParameter(dbCommand, "oriu_appId", DbType.Int32, operative.oriu_appId);
                db.AddInParameter(dbCommand, "oriu_1", DbType.String, string.IsNullOrEmpty(operative.oriu_1) ? "" : operative.oriu_1);
                db.AddInParameter(dbCommand, "oriu_2", DbType.String, string.IsNullOrEmpty(operative.oriu_2) ? "" : operative.oriu_2);
                db.AddInParameter(dbCommand, "oriu_3", DbType.String, string.IsNullOrEmpty(operative.oriu_3) ? "" : operative.oriu_3);
                db.AddInParameter(dbCommand, "oriu_4", DbType.String, string.IsNullOrEmpty(operative.oriu_4) ? "" : operative.oriu_4);
                db.AddInParameter(dbCommand, "oriu_5", DbType.String, string.IsNullOrEmpty(operative.oriu_5) ? "" : operative.oriu_5);
                db.AddInParameter(dbCommand, "oriu_6", DbType.String, string.IsNullOrEmpty(operative.oriu_6) ? "" : operative.oriu_6);
                db.AddInParameter(dbCommand, "oriu_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "oriuId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _oriuId = Convert.ToInt32(db.GetParameterValue(dbCommand, "oriuId"));
                return _oriuId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteOperativeUltralasikNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasik_Treatment_New_Delete");

                db.AddInParameter(dbCommand, "oriu_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oriu_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oriu_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oriu_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oriu_output"));

                return _oriu_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOperativeUltralasikNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasik_Treatment_New_PreviousHistory");

                db.AddInParameter(dbCommand, "oriu_appId", DbType.Int32, appId);
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
