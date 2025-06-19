using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class RevisionRequestForm
    {
        public static List<BusinessEntities.ConsentForms.RevisionRequestForm> GetRevisionRequestFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RevisionRequestForm.GetRevisionRequestFormData(appId);
            List<BusinessEntities.ConsentForms.RevisionRequestForm> list = new List<BusinessEntities.ConsentForms.RevisionRequestForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.RevisionRequestForm
                {
                    rrfId = Convert.ToInt32(dr["rrfId"]),
                    rrf_appId = Convert.ToInt32(dr["rrf_appId"]),
                    rrf_date1 = dr["rrf_date1"].ToString(),
                    rrf_date2 = dr["rrf_date2"].ToString(),
                    rrf_date3 = dr["rrf_date3"].ToString(),
                    rrf_1 = dr["rrf_1"].ToString(),
                    rrf_2 = dr["rrf_2"].ToString(),
                    rrf_3 = dr["rrf_3"].ToString(),
                    rrf_4 = dr["rrf_4"].ToString(),
                    rrf_5 = dr["rrf_5"].ToString(),
                    rrf_6 = dr["rrf_6"].ToString(),
                    rrf_7 = dr["rrf_7"].ToString(),
                    rrf_status = dr["rrf_status"].ToString(),
                    rrf_date_modified = Convert.ToDateTime(dr["rrf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveRevisionRequestForm(BusinessEntities.ConsentForms.RevisionRequestForm revision, int madeby)
        {
            return DataAccessLayer.ConsentForms.RevisionRequestForm.SaveRevisionRequestForm(revision, madeby);
        }
        public static int DeleteRevisionRequestForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.RevisionRequestForm.DeleteRevisionRequestForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetRevisionRequestFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RevisionRequestForm.GetRevisionRequestFormPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
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
