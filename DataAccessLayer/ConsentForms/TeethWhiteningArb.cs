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
    public class TeethWhiteningArb
    {
        public static DataTable GetTeethWhiteningArbData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Arb_Select");

                db.AddInParameter(dbCommand, "ctwa_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveTeethWhiteningArb(BusinessEntities.ConsentForms.TeethWhiteningArb dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Arb_Insert");

                db.AddInParameter(dbCommand, "ctwa_appId", DbType.Int32, dental.ctwa_appId);
                db.AddInParameter(dbCommand, "ctwa_1", DbType.String, dental.ctwa_1);
                db.AddInParameter(dbCommand, "ctwa_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ctwaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ctwaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ctwaId"));
                return _ctwaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteTeethWhiteningArb(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Arb_Delete");

                db.AddInParameter(dbCommand, "ctwa_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ctwa_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ctwa_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ctwa_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ctwa_output"));

                return _ctwa_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetTeethWhiteningArbPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Arb_PreviousHistory");

                db.AddInParameter(dbCommand, "ctwa_appId", DbType.Int32, appId);
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
