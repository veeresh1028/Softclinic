using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Common
{
    public class PDF
    {
        public static bool UploadDocument(BusinessEntities.Common.PDF pdf)
        {
            return DataAccessLayer.Common.PDF.UploadPDF(pdf);
        }

        public static List<BusinessEntities.Common.PDF> GetConsentPDFByAppId(int app_id, string form_name)
        {
            try
            {
                List<BusinessEntities.Common.PDF> documents = new List<BusinessEntities.Common.PDF>();

                DataTable dt = DataAccessLayer.Common.PDF.GetConsentPDFByAppId(app_id, form_name);

                foreach (DataRow d in dt.Rows)
                {
                    BusinessEntities.Common.PDF _d = new BusinessEntities.Common.PDF();
                    _d.pdfId = int.Parse(d["pdfId"].ToString());
                    _d.pdfAppId = int.Parse(d["pdfAppId"].ToString());
                    _d.pdfForm = d["pdfForm"].ToString();
                    _d.pdfPath = (d["pdfPath"].ToString().Trim().ToLower().StartsWith("documents/")) ? (ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + d["pdfPath"].ToString()) : d["pdfPath"].ToString();
                    _d.pdfFileName = d["pdfFileName"].ToString();
                    _d.pdfUploadedBy = int.Parse(d["pdfUploadedBy"].ToString());
                    _d.pdfUploadedTime = DateTime.Parse(d["pdfUploadedTime"].ToString());
                    documents.Add(_d);
                }

                return documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BusinessEntities.Common.PDFHeaderFooter GetHeaderFooterByBranch(int setid)
        {
            try
            {
                PDFHeaderFooter hf = new PDFHeaderFooter();

                DataTable dt = DataAccessLayer.Common.PDF.GetHeaderFooterByBranch(setid);

                if (dt.Rows.Count > 0)
                {
                    hf.header = dt.Rows[0]["set_header_image"].ToString();
                    hf.footer = dt.Rows[0]["set_footer_image"].ToString();
                }

                return hf;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CreateClinicalDocs(int appId, string title, string pdfPath, int madeby)
        {
            return DataAccessLayer.Common.PDF.CreateClinicalDocs(appId, title, pdfPath, madeby);
        }
    }
}
