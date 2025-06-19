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
    public class ColorVisionNew
    {
        public static DataTable GetColorVisionNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Color_Vision_New_Select");

                db.AddInParameter(dbCommand, "cv_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveColorVisionNew(BusinessEntities.ConsentForms.ColorVisionNew color, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Color_Vision_New_Insert");

                db.AddInParameter(dbCommand, "cv_appId", DbType.Int32, color.cv_appId);
                db.AddInParameter(dbCommand, "cv_1", DbType.String, string.IsNullOrEmpty(color.cv_1) ? "" : color.cv_1);
                db.AddInParameter(dbCommand, "cv_2", DbType.String, string.IsNullOrEmpty(color.cv_2) ? "" : color.cv_2);
                db.AddInParameter(dbCommand, "cv_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cvId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cvId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cvId"));
                return _cvId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteColorVisionNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Color_Vision_New_Delete");

                db.AddInParameter(dbCommand, "cv_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cv_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cv_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cv_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cv_output"));

                return _cv_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetColorVisionNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Color_Vision_New_PreviousHistory");

                db.AddInParameter(dbCommand, "cv_appId", DbType.Int32, appId);
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
