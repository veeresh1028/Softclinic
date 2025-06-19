using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class Laboratory
    {
        public static bool UploadDocument(BusinessEntities.EMR.Laboratory Rad)
        {
            return DataAccessLayer.EMR.Laboratory.UploadDocument(Rad);
        }
        public static int CreateReportResults(BusinessEntities.EMR.ReportResults item, int madeby)
        {
            return DataAccessLayer.EMR.Laboratory.CreateReportResults(item, madeby);
        }

        public static List<BusinessEntities.EMR.ReportResults> GetReportResults(int appId, int ptId)
        {
            try
            {
                List<BusinessEntities.EMR.ReportResults> documents = new List<BusinessEntities.EMR.ReportResults>();

                DataTable dt = DataAccessLayer.EMR.Laboratory.GetReportResults(appId, ptId);

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
    }
}
