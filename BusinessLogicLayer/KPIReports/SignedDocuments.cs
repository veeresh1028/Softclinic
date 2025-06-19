using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class SignedDocuments
    {
        public static List<BusinessEntities.EMR.SignedDocuments> SearchSignedDocumentsReport(BusinessEntities.KPIReports.VitalSignsReportSearch _filters)
        {
            try
            {
                List<BusinessEntities.EMR.SignedDocuments> reports = new List<BusinessEntities.EMR.SignedDocuments>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.KPIReports.SignedDocuments.SearchSignedDocumentsReport(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.EMR.SignedDocuments report = new BusinessEntities.EMR.SignedDocuments();
                        report.visit_date = Convert.ToDateTime(dr["app_fdate"]);
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.emp_name = dr["emp_name"].ToString();
                        report.emp_dept_name = dr["emp_dept_name"].ToString();
                        report.psbId = Convert.ToInt32(dr["psbId"]);
                        report.psb_appId = Convert.ToInt32(dr["psb_appId"]);
                        report.psb_file = dr["psb_file"].ToString();
                        report.psb_formlink = dr["psb_formlink"].ToString();
                        report.psb_date_created = Convert.ToDateTime(dr["psb_date_created"].ToString());
                        report.psb_status = dr["psb_status"].ToString();
                        reports.Add(report);
                    }
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CommonDDL> GetPatientsBySignedDocumentsReport(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.SignedDocuments.GetPatientsBySignedDocumentsReport(_data);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }
    }
}
