using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FillerInjection
    {
        public static List<BusinessEntities.ConsentForms.FillerInjection> GetFillerInjectionData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerInjection.GetFillerInjectionData(appId);
            List<BusinessEntities.ConsentForms.FillerInjection> list = new List<BusinessEntities.ConsentForms.FillerInjection>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FillerInjection
                {
                    fifId = Convert.ToInt32(dr["fifId"]),
                    fif_appId = Convert.ToInt32(dr["fif_appId"]),
                    fif_1 = dr["fif_1"].ToString(),
                    fif_status = dr["fif_status"].ToString(),
                    fif_date_modified = Convert.ToDateTime(dr["fif_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveFillerInjection(BusinessEntities.ConsentForms.FillerInjection derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerInjection.SaveFillerInjection(derma, madeby);
        }
        public static int DeleteFillerInjection(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerInjection.DeleteFillerInjection(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetFillerInjectionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerInjection.GetFillerInjectionPreviousHistory(appId);
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
