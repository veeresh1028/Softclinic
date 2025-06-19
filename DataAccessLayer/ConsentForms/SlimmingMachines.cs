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
    public class SlimmingMachines
    {
        public static DataTable GetSlimmingMachinesData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Machines_Form_Select");

                db.AddInParameter(dbCommand, "smf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveSlimmingMachines(BusinessEntities.ConsentForms.SlimmingMachines ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Machines_Form_Insert");

                db.AddInParameter(dbCommand, "smf_appId", DbType.Int32, ophtha.smf_appId);
                db.AddInParameter(dbCommand, "smf_1", DbType.String, string.IsNullOrEmpty(ophtha.smf_1) ? "" : ophtha.smf_1);

                db.AddInParameter(dbCommand, "smf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "smfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _smfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "smfId"));
                return _smfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteSlimmingMachines(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Machines_Form_Delete");

                db.AddInParameter(dbCommand, "smf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "smf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "smf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _smf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "smf_output"));

                return _smf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSlimmingMachinesPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Machines_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "smf_appId", DbType.Int32, appId);
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
