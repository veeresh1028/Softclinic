using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class HijjamaTherapy
    {
        public static List<BusinessEntities.ConsentForms.HijjamaTherapy> GetHijjamaTherapyData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HijjamaTherapy.GetHijjamaTherapyData(appId);
            List<BusinessEntities.ConsentForms.HijjamaTherapy> list = new List<BusinessEntities.ConsentForms.HijjamaTherapy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.HijjamaTherapy
                {
                    htcId = Convert.ToInt32(dr["htcId"]),
                    htc_appId = Convert.ToInt32(dr["htc_appId"]),
                    htc_1 = dr["htc_1"].ToString(),
                    htc_status = dr["htc_status"].ToString(),
                    htc_date_modified = Convert.ToDateTime(dr["htc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveHijjamaTherapy(BusinessEntities.ConsentForms.HijjamaTherapy hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.HijjamaTherapy.SaveHijjamaTherapy(hijama, madeby);
        }
        public static int DeleteHijjamaTherapy(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.HijjamaTherapy.DeleteHijjamaTherapy(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetHijjamaTherapyPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HijjamaTherapy.GetHijjamaTherapyPreviousHistory(appId);
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
