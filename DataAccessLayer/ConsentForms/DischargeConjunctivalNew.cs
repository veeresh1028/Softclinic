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
    public class DischargeConjunctivalNew
    {
        public static DataTable GetDischargeConjunctivalNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Conjunctival_Cyst_Excision_New_Select");

                db.AddInParameter(dbCommand, "dscce_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveDischargeConjunctivalNew(BusinessEntities.ConsentForms.DischargeConjunctivalNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Conjunctival_Cyst_Excision_New_Insert");

                db.AddInParameter(dbCommand, "dscce_appId", DbType.Int32, discharge.dscce_appId);
                db.AddInParameter(dbCommand, "dscce_1", DbType.String, string.IsNullOrEmpty(discharge.dscce_1) ? "" : discharge.dscce_1);
                db.AddInParameter(dbCommand, "dscce_2", DbType.String, string.IsNullOrEmpty(discharge.dscce_2) ? "" : discharge.dscce_2);
                db.AddInParameter(dbCommand, "dscce_3", DbType.String, string.IsNullOrEmpty(discharge.dscce_3) ? "" : discharge.dscce_3);
                db.AddInParameter(dbCommand, "dscce_4", DbType.String, string.IsNullOrEmpty(discharge.dscce_4) ? "" : discharge.dscce_4);
                db.AddInParameter(dbCommand, "dscce_5", DbType.String, string.IsNullOrEmpty(discharge.dscce_5) ? "" : discharge.dscce_5);
                db.AddInParameter(dbCommand, "dscce_6", DbType.String, string.IsNullOrEmpty(discharge.dscce_6) ? "" : discharge.dscce_6);
                db.AddInParameter(dbCommand, "dscce_7", DbType.String, string.IsNullOrEmpty(discharge.dscce_7) ? "" : discharge.dscce_7);
                db.AddInParameter(dbCommand, "dscce_8", DbType.String, string.IsNullOrEmpty(discharge.dscce_8) ? "" : discharge.dscce_8);
                db.AddInParameter(dbCommand, "dscce_9", DbType.String, string.IsNullOrEmpty(discharge.dscce_9) ? "" : discharge.dscce_9);
                db.AddInParameter(dbCommand, "dscce_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dscceId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dscceId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dscceId"));
                return _dscceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeConjunctivalNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Conjunctival_Cyst_Excision_New_Delete");

                db.AddInParameter(dbCommand, "dscce_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dscce_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand,"dscce_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dscce_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dscce_output"));

                return _dscce_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeConjunctivalNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Conjunctival_Cyst_Excision_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dscce_appId", DbType.Int32, appId);
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
