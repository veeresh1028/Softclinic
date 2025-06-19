using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ConsentBlephrotomy
    {
        public static List<BusinessEntities.ConsentForms.ConsentBlephrotomy> GetConsentBlephrotomyData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentBlephrotomy.GetConsentBlephrotomyData(appId);
            List<BusinessEntities.ConsentForms.ConsentBlephrotomy> list = new List<BusinessEntities.ConsentForms.ConsentBlephrotomy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ConsentBlephrotomy
                {
                    cbnId = Convert.ToInt32(dr["cbnId"]),
                    cbn_appId = Convert.ToInt32(dr["cbn_appId"]),
                    cbn_status = dr["cbn_status"].ToString(),
                    cbn_date_modified = Convert.ToDateTime(dr["cbn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveConsentBlephrotomy(BusinessEntities.ConsentForms.ConsentBlephrotomy ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentBlephrotomy.SaveConsentBlephrotomy(ophtha, madeby);
        }
        public static int DeleteConsentBlephrotomy(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentBlephrotomy.DeleteConsentBlephrotomy(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetConsentBlephrotomyPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentBlephrotomy.GetConsentBlephrotomyPreviousHistory(appId);
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
