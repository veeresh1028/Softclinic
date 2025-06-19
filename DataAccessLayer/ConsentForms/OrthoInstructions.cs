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
    public class OrthoInstructions
    {
        public static DataTable GetOrthoInstructionsData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Instr_Select");

                db.AddInParameter(dbCommand, "oi_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveOrthoInstructions(BusinessEntities.ConcentForms.OrthoInstructions tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Instr_Insert");

                db.AddInParameter(dbCommand, "oi_appId", DbType.Int32, tooth.oi_appId);
                db.AddInParameter(dbCommand, "oi_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "oiId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _oiId = Convert.ToInt32(db.GetParameterValue(dbCommand, "oiId"));
                return _oiId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteOrthoInstructions(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Instr_Delete");

                db.AddInParameter(dbCommand, "oi_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oi_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oi_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oi_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oi_output"));

                return _oi_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOrthoInstructionsPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Instr_PreviousHistory");

                db.AddInParameter(dbCommand, "oi_appId", DbType.Int32, appId);
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
