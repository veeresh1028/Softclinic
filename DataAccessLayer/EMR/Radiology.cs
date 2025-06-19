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
    public class Radiology
    {
        public static bool UploadDocument(BusinessEntities.EMR.Radiology rad)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lab_Results_insert");

                db.AddInParameter(dbCommand, "lr_test", DbType.Int32, rad.lr_test);
                db.AddInParameter(dbCommand, "lr_appId", DbType.Int32, rad.lr_appId);
                db.AddInParameter(dbCommand, "lr_from", DbType.String, rad.lr_from);
                db.AddInParameter(dbCommand, "lr_lab_name", DbType.String, rad.lr_lab_name);
                db.AddInParameter(dbCommand, "lr_result", DbType.String, "Radiology");
                db.AddInParameter(dbCommand, "lr_image1", DbType.String, rad.lr_image1);
                db.AddInParameter(dbCommand, "lr_madeby", DbType.Int32, rad.lr_madeby);
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

        public static DataTable GetPDFDocuments(int appId, int ptId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetpdfDocumentsById");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetReportResults(int appId, int ptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetReportResults");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "radr_type", DbType.String, "Radiology");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateReportResults(BusinessEntities.EMR.ReportResults item, int madeby)
        {
            try
            {
                int radrId = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Radiology_Reports_insert");
                db.AddInParameter(dbCommand, "radr_appId", DbType.Int32, item.radr_appId);
                db.AddInParameter(dbCommand, "radr_ptId", DbType.Int32, item.radr_ptId);
                db.AddInParameter(dbCommand, "radr_title", DbType.String, item.radr_title);
                db.AddInParameter(dbCommand, "radr_report", DbType.String, item.radr_report);
                db.AddInParameter(dbCommand, "radr_type", DbType.String, "Radiology");
                db.AddInParameter(dbCommand, "radr_madeby", DbType.Int32, madeby);
                //db.AddOutParameter(dbCommand, "radrId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                // radrId = Convert.ToInt32(db.GetParameterValue(dbCommand, "radrId").ToString());
                return val;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static int UpdateReportResultstatus(int radrId, string status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ReportResults_update_status");
                db.AddOutParameter(dbCommand, "radrId", DbType.Int32, radrId);
                db.AddInParameter(dbCommand, "radr_status", DbType.String, status);
                db.AddOutParameter(dbCommand, "radr_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "radr_output").ToString());


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
