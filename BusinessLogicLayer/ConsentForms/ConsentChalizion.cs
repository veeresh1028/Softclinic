using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ConsentChalizion
    {
        public static List<BusinessEntities.ConsentForms.ConsentChalizion> GetConsentChalizionData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentChalizion.GetConsentChalizionData(appId);
            List<BusinessEntities.ConsentForms.ConsentChalizion> list = new List<BusinessEntities.ConsentForms.ConsentChalizion>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ConsentChalizion
                {
                    ccnId = Convert.ToInt32(dr["ccnId"]),
                    ccn_appId = Convert.ToInt32(dr["ccn_appId"]),
                    ccn_status = dr["ccn_status"].ToString(),
                    ccn_date_modified = Convert.ToDateTime(dr["ccn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveConsentChalizion(BusinessEntities.ConsentForms.ConsentChalizion ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentChalizion.SaveConsentChalizion(ophtha, madeby);
        }
        public static int DeleteConsentChalizion(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentChalizion.DeleteConsentChalizion(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetConsentChalizionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentChalizion.GetConsentChalizionPreviousHistory(appId);
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
