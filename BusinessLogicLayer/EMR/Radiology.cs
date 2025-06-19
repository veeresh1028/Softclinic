using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class Radiology
    {
        public static bool UploadDocument(BusinessEntities.EMR.Radiology Rad)
        {
            return DataAccessLayer.EMR.Radiology.UploadDocument(Rad);
        }
        public static List<BusinessEntities.EMR.Radiology> GetPDFDocuments(int appId, int ptId, string type)
        {
            try
            {
                List<BusinessEntities.EMR.Radiology> documents = new List<BusinessEntities.EMR.Radiology>();

                DataTable dt = DataAccessLayer.EMR.Radiology.GetPDFDocuments(appId, ptId, type);

                foreach (DataRow d in dt.Rows)
                {
                    BusinessEntities.EMR.Radiology _d = new BusinessEntities.EMR.Radiology();
                    _d.lrId = int.Parse(d["lrId"].ToString());
                    _d.lr_test = int.Parse(d["lr_test"].ToString());
                    _d.lr_appId = int.Parse(d["lr_appId"].ToString());
                    _d.lr_from = d["lr_from"].ToString();
                    _d.lr_lab_name = d["lr_lab_name"].ToString();
                    _d.lr_result = d["lr_result"].ToString();

                    string[] path;
                    path = d["lr_image1"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/Lab_Results" }, StringSplitOptions.None);


                    _d.lr_image1 = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString().Trim().ToString() + "images/Lab_Results" + path[1].Trim().ToString();
                    _d.lr_status = d["lr_status"].ToString();
                    _d.lr_date_created = DateTime.Parse(d["lr_date_created"].ToString());
                    _d.lr_madeby = int.Parse(d["lr_madeby"].ToString());
                    _d.lr_madeby_name = d["lr_madeby_name"].ToString();
                    documents.Add(_d);
                }

                return documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int CreateReportResults(BusinessEntities.EMR.ReportResults item, int madeby)
        {
            return DataAccessLayer.EMR.Radiology.CreateReportResults(item, madeby);
        }
        public static List<BusinessEntities.EMR.ReportResults> GetReportResults(int appId, int ptId)
        {
            try
            {
                List<BusinessEntities.EMR.ReportResults> documents = new List<BusinessEntities.EMR.ReportResults>();

                DataTable dt = DataAccessLayer.EMR.Radiology.GetReportResults(appId, ptId);

                foreach (DataRow d in dt.Rows)
                {
                    BusinessEntities.EMR.ReportResults _d = new BusinessEntities.EMR.ReportResults();
                    _d.radrId = int.Parse(d["radrId"].ToString());
                    _d.radr_ptId = int.Parse(d["radr_ptId"].ToString());
                    _d.radr_appId = int.Parse(d["radr_appId"].ToString());
                    _d.radr_title = d["radr_title"].ToString();
                    _d.radr_report = d["radr_report"].ToString();
                    _d.radr_status = d["radr_status"].ToString();
                    _d.radr_date_created = DateTime.Parse(d["radr_date_created"].ToString());
                    _d.radr_madeby = int.Parse(d["radr_madeby"].ToString());
                    _d.radr_madeby_name = d["radr_madeby_name"].ToString();
                    documents.Add(_d);
                }

                return documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateReportResultsStatus(int radrId, string status)
        {
            return DataAccessLayer.EMR.Radiology.UpdateReportResultstatus(radrId, status);
        }
    }
}
