using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace DataAccessLayer.ConsentForms
{
    public class EyeForm1
    {
        public static DataTable GetEyeForm1Data(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form1_New_Select");

                db.AddInParameter(dbCommand, "efn1_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEyeForm1(BusinessEntities.ConsentForms.EyeForm1 ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form1_New_Insert");

                db.AddInParameter(dbCommand, "efn1_appId", DbType.Int32, ophtha.efn1_appId);
                db.AddInParameter(dbCommand, "efn1_1", DbType.String, string.IsNullOrEmpty(ophtha.efn1_1) ? "" : ophtha.efn1_1);
                db.AddInParameter(dbCommand, "efn1_doc", DbType.String, ophtha.image);

                db.AddInParameter(dbCommand, "efn1_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "efn1Id", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _efn1Id = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn1Id"));
                return _efn1Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEyeForm1(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form1_New_Delete");

                db.AddInParameter(dbCommand, "efn1_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "efn1_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "efn1_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _efn1_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn1_output"));

                return _efn1_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEyeForm1PreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form1_New_PreviousHistory");

                db.AddInParameter(dbCommand, "efn1_appId", DbType.Int32, appId);
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
