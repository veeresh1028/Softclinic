using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class GenitoUrinary
    {
        #region GenitoUrinary
        public static DataTable GetAllGenitoUrinary(int? appId, int? genId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENITO_URINARY_select_all_info");
                if (genId > 0)
                {
                    db.AddInParameter(dbCommand, "genId", DbType.Int32, genId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreGenitoUrinary(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENITO_URINARY_PREVIOUS_History");
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

        public static bool InsertUpdateGenitoUrinary(BusinessEntities.EMR.GenitoUrinary data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENITO_URINARY_INSERT_UPDATE");
                if (data.genId > 0)
                {
                    db.AddInParameter(dbCommand, "genId", DbType.Int32, data.genId);
                }
                db.AddInParameter(dbCommand, "gen_appId", DbType.Int32, data.gen_appId);
                db.AddInParameter(dbCommand, "gen_1", DbType.String, data.gen_1);
                db.AddInParameter(dbCommand, "gen_2", DbType.String, data.gen_2);
                db.AddInParameter(dbCommand, "gen_1_type", DbType.String, data.gen_1_type);
                db.AddInParameter(dbCommand, "gen_2_type", DbType.String, data.gen_2_type);
                db.AddInParameter(dbCommand, "gen_madeby", DbType.Int32, data.gen_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteGenitoUrinary(int genId, int gen_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENITO_URINARY_delete");

                db.AddInParameter(dbCommand, "genId", DbType.Int32, genId);
                db.AddInParameter(dbCommand, "gen_madeby", DbType.String, gen_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GenitoUrinary
    }
}
