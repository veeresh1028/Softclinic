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
    public class EyeForm2
    {
        public static DataTable GetEyeForm2Data(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form2_New_Select");

                db.AddInParameter(dbCommand, "efn2_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEyeForm2(BusinessEntities.ConsentForms.EyeForm2 ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form2_New_Insert");

                db.AddInParameter(dbCommand, "efn2_appId", DbType.Int32, ophtha.efn2_appId);
                db.AddInParameter(dbCommand, "efn2_1", DbType.String, string.IsNullOrEmpty(ophtha.efn2_1) ? "" : ophtha.efn2_1);
                db.AddInParameter(dbCommand, "efn2_doc", DbType.String, ophtha.image);

                db.AddInParameter(dbCommand, "efn2_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "efn2Id", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _efn2Id = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn2Id"));
                return _efn2Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEyeForm2(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form2_New_Delete");

                db.AddInParameter(dbCommand, "efn2_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "efn2_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "efn2_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _efn2_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "efn2_output"));

                return _efn2_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEyeForm2PreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Eye_Form2_New_PreviousHistory");

                db.AddInParameter(dbCommand, "efn2_appId", DbType.Int32, appId);
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
