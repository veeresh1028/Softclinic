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
    public class ConjunctivalCystExcisionNew
    {
        public static DataTable GetConjunctivalCystExcisionNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Conjunctival_Cyst_Excision_New_Select");

                db.AddInParameter(dbCommand, "occce_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveConjunctivalCystExcisionNew(BusinessEntities.ConsentForms.ConjunctivalCystExcisionNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Conjunctival_Cyst_Excision_New_Insert");

                db.AddInParameter(dbCommand, "occce_appId", DbType.Int32, discharge.occce_appId);
                db.AddInParameter(dbCommand, "occce_1", DbType.String, string.IsNullOrEmpty(discharge.occce_1) ? "" : discharge.occce_1);
                db.AddInParameter(dbCommand, "occce_2", DbType.String, string.IsNullOrEmpty(discharge.occce_2) ? "" : discharge.occce_2);
                db.AddInParameter(dbCommand, "occce_3", DbType.String, string.IsNullOrEmpty(discharge.occce_3) ? "" : discharge.occce_3);
                db.AddInParameter(dbCommand, "occce_4", DbType.String, string.IsNullOrEmpty(discharge.occce_4) ? "" : discharge.occce_4);
                db.AddInParameter(dbCommand, "occce_5", DbType.String, string.IsNullOrEmpty(discharge.occce_5) ? "" : discharge.occce_5);
                db.AddInParameter(dbCommand, "occce_6", DbType.String, string.IsNullOrEmpty(discharge.occce_6) ? "" : discharge.occce_6);
                db.AddInParameter(dbCommand, "occce_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "occceId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _occceId = Convert.ToInt32(db.GetParameterValue(dbCommand, "occceId"));
                return _occceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteConjunctivalCystExcisionNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Conjunctival_Cyst_Excision_New_Delete");

                db.AddInParameter(dbCommand, "occce_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "occce_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "occce_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _occce_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "occce_output"));

                return _occce_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetConjunctivalCystExcisionNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Conjunctival_Cyst_Excision_New_PreviousHistory");

                db.AddInParameter(dbCommand, "occce_appId", DbType.Int32, appId);
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
