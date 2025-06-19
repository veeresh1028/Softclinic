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
    public class SlipLamp
    {
        public static DataTable GetSlipLampData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slip_Lamp_New_Select");

                db.AddInParameter(dbCommand, "sln_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveSlipLamp(BusinessEntities.ConsentForms.SlipLamp ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slip_Lamp_New_Insert");

                db.AddInParameter(dbCommand, "sln_appId", DbType.Int32, ophtha.sln_appId);
                db.AddInParameter(dbCommand, "sln_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "slnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _slnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "slnId"));
                return _slnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteSlipLamp(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slip_Lamp_New_Delete");

                db.AddInParameter(dbCommand, "sln_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "sln_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "sln_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _sln_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "sln_output"));

                return _sln_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSlipLampPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slip_Lamp_New_PreviousHistory");

                db.AddInParameter(dbCommand, "sln_appId", DbType.Int32, appId);
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
