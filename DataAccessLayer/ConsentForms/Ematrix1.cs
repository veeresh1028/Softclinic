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
    public class Ematrix1
    {
        public static DataTable GetEmatrix1Data(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form1_Select");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveEmatrix1(BusinessEntities.ConsentForms.Ematrix1 ematrix, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form1_Insert");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, ematrix.cef_appId);
                db.AddInParameter(dbCommand, "cef_1", DbType.String, string.IsNullOrEmpty(ematrix.cef_1) ? "" : ematrix.cef_1);
                db.AddInParameter(dbCommand, "cef_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cefId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cefId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cefId"));
                return _cefId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteEmatrix1(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form1_Delete");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cef_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cef_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cef_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cef_output"));

                return _cef_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetEmatrix1PreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ematrix_Form1_PreviousHistory");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, appId);
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
