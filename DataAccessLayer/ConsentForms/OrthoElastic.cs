using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class OrthoElastic
    {
        public static DataTable GetOrthoElasticData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Elastic_Select");

                db.AddInParameter(dbCommand, "oe_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveOrthoElastic(BusinessEntities.ConcentForms.OrthoElastic tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Elastic_Insert");

                db.AddInParameter(dbCommand, "oe_appId", DbType.Int32, tooth.oe_appId);
                db.AddInParameter(dbCommand, "oe_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "oeId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _oeId = Convert.ToInt32(db.GetParameterValue(dbCommand, "oeId"));
                return _oeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteOrthoElastic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Elastic_Delete");

                db.AddInParameter(dbCommand, "oe_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oe_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oe_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oe_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oe_output"));

                return _oe_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOrthoElasticPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Elastic_PreviousHistory");

                db.AddInParameter(dbCommand, "oe_appId", DbType.Int32, appId);
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
