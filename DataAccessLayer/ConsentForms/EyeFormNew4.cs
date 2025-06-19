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
    public class EyeFormNew4
    {
        public static DataTable GetEyeFormNew4Data(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form4_New_Select");

                db.AddInParameter(dbCommand, "efn4_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEyeFormNew4(BusinessEntities.ConsentForms.EyeFormNew4 eye, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form4_New_Insert");

                db.AddInParameter(dbCommand, "efn4_appId", DbType.Int32, eye.efn4_appId);
                db.AddInParameter(dbCommand, "efn4_1", DbType.String, string.IsNullOrEmpty(eye.efn4_1) ? "" : eye.efn4_1);
                db.AddInParameter(dbCommand, "efn4_doc", DbType.String, eye.image);
                db.AddInParameter(dbCommand, "efn4_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "efn4Id", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _efn4Id = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn4Id"));
                return _efn4Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEyeFormNew4(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form4_New_Delete");

                db.AddInParameter(dbCommand, "efn4_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "efn4_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "efn4_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _efn4_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn4_output"));

                return _efn4_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEyeFormNew4PreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form4_New_PreviousHistory");

                db.AddInParameter(dbCommand, "efn4_appId", DbType.Int32, appId);
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
