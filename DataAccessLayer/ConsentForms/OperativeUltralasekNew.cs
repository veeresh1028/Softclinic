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
    public class OperativeUltralasekNew
    {
        public static DataTable GetOperativeUltralasekNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasek_Treatment_New_Select");

                db.AddInParameter(dbCommand, "oreu_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveOperativeUltralasekNew(BusinessEntities.ConsentForms.OperativeUltralasekNew operative, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasek_Treatment_New_Insert");

                db.AddInParameter(dbCommand, "oreu_appId", DbType.Int32, operative.oreu_appId);
                db.AddInParameter(dbCommand, "oreu_1", DbType.String, string.IsNullOrEmpty(operative.oreu_1) ? "" : operative.oreu_1);
                db.AddInParameter(dbCommand, "oreu_2", DbType.String, string.IsNullOrEmpty(operative.oreu_2) ? "" : operative.oreu_2);
                db.AddInParameter(dbCommand, "oreu_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "oreuId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _oreuId = Convert.ToInt32(db.GetParameterValue(dbCommand, "oreuId"));
                return _oreuId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteOperativeUltralasekNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasek_Treatment_New_Delete");

                db.AddInParameter(dbCommand, "oreu_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oreu_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oreu_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oreu_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oreu_output"));

                return _oreu_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOperativeUltralasekNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ultralasek_Treatment_New_PreviousHistory");

                db.AddInParameter(dbCommand, "oreu_appId", DbType.Int32, appId);
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
