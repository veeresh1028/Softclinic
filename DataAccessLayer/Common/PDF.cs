using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Common
{
    public class PDF
    {
        public static bool UploadPDF(BusinessEntities.Common.PDF pdf)
        {
            try
            {
                string file_path = HttpContext.Current.Server.MapPath("~/");

                if (pdf.pdfPath.StartsWith(file_path))
                {
                    pdf.pdfPath = pdf.pdfPath.Replace(file_path, "");
                }

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SaveConcentFormPDF");

                db.AddInParameter(dbCommand, "pdfAppId", DbType.Int32, pdf.pdfAppId);
                db.AddInParameter(dbCommand, "pdfForm", DbType.String, pdf.pdfForm);
                db.AddInParameter(dbCommand, "pdfPath", DbType.String, pdf.pdfPath);
                db.AddInParameter(dbCommand, "pdfFileName", DbType.String, pdf.pdfFileName);
                db.AddInParameter(dbCommand, "pdfUploadedBy", DbType.Int32, pdf.pdfUploadedBy);
                db.AddOutParameter(dbCommand, "pdfId_output", DbType.Int32, 100);
                int result = db.ExecuteNonQuery(dbCommand);

                int value = Convert.ToInt32(db.GetParameterValue(dbCommand, "pdfId_output"));

                if (value > 0)
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
                throw ex;
            }
        }

        public static DataTable GetConsentPDFByAppId(int app_id, string form_name)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetConcentFormPDF");

                db.AddInParameter(dbCommand, "pdfAppId", DbType.Int32, app_id);
                db.AddInParameter(dbCommand, "pdfForm", DbType.String, form_name);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetHeaderFooterByBranch(int setId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetHeaderFooterByBranch");

                db.AddInParameter(dbCommand, "setId", DbType.Int32, setId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateClinicalDocs(int appId, string tittle, string pdfPath, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_clinical_nabidh_docs_insert");
                db.AddInParameter(dbCommand, "cnd_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cnd_doc", DbType.String, pdfPath);
                db.AddInParameter(dbCommand, "cnd_name", DbType.String, tittle);
                db.AddInParameter(dbCommand, "cnd_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
