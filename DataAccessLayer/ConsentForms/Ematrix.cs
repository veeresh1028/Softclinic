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
    public class Ematrix
    {
        public static DataTable GetEmatrixData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form_Select");

                db.AddInParameter(dbCommand, "ecf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveEmatrix(BusinessEntities.ConsentForms.Ematrix ematrix, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form_Insert");

                db.AddInParameter(dbCommand, "ecf_appId", DbType.Int32, ematrix.ecf_appId);
                db.AddInParameter(dbCommand, "ecf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ecfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ecfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ecfId"));
                return _ecfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteEmatrix(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form_Delete");

                db.AddInParameter(dbCommand, "ecf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ecf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ecf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ecf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ecf_output"));

                return _ecf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmatrixPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "ecf_appId", DbType.Int32, appId);
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
