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
    public class PastHistory
    {
        #region PastHistory
        public static DataTable GetAllPastHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAST_FAMILY_HISTORY_select_all_info");
                
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPrePastHistory(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAST_FAMILY_HISTORY_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int InsertUpdatePastHistory(BusinessEntities.NurseStation.PastHistory data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAST_FAMILY_HISTORY_INSERT_UPDATE");
                if (data.pfId > 0)
                {
                    db.AddInParameter(dbCommand, "pfId", DbType.Int32, data.pfId);
                }
                db.AddInParameter(dbCommand, "pf_appId", DbType.Int32, data.pf_appId);
                db.AddInParameter(dbCommand, "pf_past", DbType.String, data.pf_past);
                db.AddInParameter(dbCommand, "pf_family", DbType.String, data.pf_family);
                db.AddInParameter(dbCommand, "pf_other", DbType.String, data.pf_other);
                db.AddInParameter(dbCommand, "pf_smok", DbType.String, data.pf_smok);
                db.AddInParameter(dbCommand, "pf_smok_details", DbType.String, data.pf_smok_details);
                db.AddInParameter(dbCommand, "pf_alco", DbType.String, data.pf_alco);
                db.AddInParameter(dbCommand, "pf_alco_details", DbType.String, data.pf_alco_details);
                db.AddInParameter(dbCommand, "pf_drug", DbType.String, data.pf_drug);
                db.AddInParameter(dbCommand, "pf_drug_details", DbType.String, data.pf_drug_details);
                db.AddInParameter(dbCommand, "pf_surgical", DbType.String, data.pf_surgical);
                db.AddInParameter(dbCommand, "pf_smok_habit", DbType.String, data.pf_smok_habit);
                db.AddInParameter(dbCommand, "pf_alco_habit", DbType.String, data.pf_alco_habit);
                db.AddInParameter(dbCommand, "pf_drug_habit", DbType.String, data.pf_drug_habit);
                db.AddInParameter(dbCommand, "pf_madeby", DbType.Int32, data.pf_madeby);
                db.AddInParameter(dbCommand, "pf_modifyby", DbType.Int32, data.pf_madeby);
                db.AddOutParameter(dbCommand, "pf_Id", DbType.Int32, 100);
                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pf_Id").ToString());

                //if (result > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeletePastHistory(int pfId,  int pf_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAST_FAMILY_HISTORY_delete");

                db.AddInParameter(dbCommand, "pfId", DbType.Int32, pfId);
                db.AddInParameter(dbCommand, "pf_modifyby", DbType.String, pf_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion PastHistory

    }
}
