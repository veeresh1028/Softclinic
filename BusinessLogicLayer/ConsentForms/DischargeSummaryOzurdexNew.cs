using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeSummaryOzurdexNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeSummaryOzurdexNew> GetDischargeSummaryOzurdexNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryOzurdexNew.GetDischargeSummaryOzurdexNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeSummaryOzurdexNew> list = new List<BusinessEntities.ConsentForms.DischargeSummaryOzurdexNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeSummaryOzurdexNew
                {
                    doiId = Convert.ToInt32(dr["doiId"]),
                    doi_appId = Convert.ToInt32(dr["doi_appId"]),
                    doi_1 = dr["doi_1"].ToString(),
                    doi_2 = dr["doi_2"].ToString(),
                    doi_3 = dr["doi_3"].ToString(),
                    doi_4 = dr["doi_4"].ToString(),
                    doi_5 = dr["doi_5"].ToString(),
                    doi_6 = dr["doi_6"].ToString(),
                    doi_status = dr["doi_status"].ToString(),
                    doi_date_modified = Convert.ToDateTime(dr["doi_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeSummaryOzurdexNew(BusinessEntities.ConsentForms.DischargeSummaryOzurdexNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryOzurdexNew.SaveDischargeSummaryOzurdexNew(discharge, madeby);
        }

        public static int DeleteDischargeSummaryOzurdexNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryOzurdexNew.DeleteDischargeSummaryOzurdexNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeSummaryOzurdexNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryOzurdexNew.GetDischargeSummaryOzurdexNewPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistory
                {
                    formId = Convert.ToInt32(dr["formId"]),
                    appId = Convert.ToInt32(dr["appId"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_name = dr["emp_name"].ToString() + " " + dr["emp_lname"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString()
                });
            }
            return list;
        }




    }
}
