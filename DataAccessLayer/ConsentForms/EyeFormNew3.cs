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
    public class EyeFormNew3
    {
        public static DataTable GetEyeFormNew3Data(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form3_New_Select");

                db.AddInParameter(dbCommand, "efn3_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEyeFormNew3(BusinessEntities.ConsentForms.EyeFormNew3 eye, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form3_New_Insert");

                db.AddInParameter(dbCommand, "efn3_appId", DbType.Int32, eye.efn3_appId);
                db.AddInParameter(dbCommand, "efn3_1", DbType.String, string.IsNullOrEmpty(eye.efn3_1) ? "" : eye.efn3_1);
                db.AddInParameter(dbCommand, "efn3_doc", DbType.String, eye.image);
                db.AddInParameter(dbCommand, "efn3_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "efn3Id", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _efn3Id = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn3Id"));
                return _efn3Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEyeFormNew3(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form3_New_Delete");

                db.AddInParameter(dbCommand, "efn3_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "efn3_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "efn3_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _efn3_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn3_output"));

                return _efn3_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEyeFormNew3PreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form3_New_PreviousHistory");

                db.AddInParameter(dbCommand, "efn3_appId", DbType.Int32, appId);
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
