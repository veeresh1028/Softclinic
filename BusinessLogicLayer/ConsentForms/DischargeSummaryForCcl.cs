using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeSummaryForCcl
    {
        public static List<BusinessEntities.ConsentForms.DischargeSummaryForCcl> GetDischargeSummaryForCclData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryForCcl.GetDischargeSummaryForCclData(appId);
            List<BusinessEntities.ConsentForms.DischargeSummaryForCcl> list = new List<BusinessEntities.ConsentForms.DischargeSummaryForCcl>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeSummaryForCcl
                {
                    dsfcfId = Convert.ToInt32(dr["dsfcfId"]),
                    dsfcf_appId = Convert.ToInt32(dr["dsfcf_appId"]),
                    dsfcf_1 = dr["dsfcf_1"].ToString(),
                    dsfcf_2 = dr["dsfcf_2"].ToString(),
                    dsfcf_3 = dr["dsfcf_3"].ToString(),
                    dsfcf_4 = dr["dsfcf_4"].ToString(),
                    dsfcf_5 = dr["dsfcf_5"].ToString(),
                    dsfcf_6 = dr["dsfcf_6"].ToString(),
                    dsfcf_7 = dr["dsfcf_7"].ToString(),
                    dsfcf_status = dr["dsfcf_status"].ToString(),
                    dsfcf_date_modified = Convert.ToDateTime(dr["dsfcf_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeSummaryForCcl(BusinessEntities.ConsentForms.DischargeSummaryForCcl discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryForCcl.SaveDischargeSummaryForCcl(discharge, madeby);
        }


        public static int DeleteDischargeSummaryForCcl(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryForCcl.DeleteDischargeSummaryForCcl(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeSummaryForCclPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryForCcl.GetDischargeSummaryForCclPreviousHistory(appId);
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
