using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FillerInformed
    {
        public static List<BusinessEntities.ConsentForms.FillerInformed> GetFillerInformedData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerInformed.GetFillerInformedData(appId);
            List<BusinessEntities.ConsentForms.FillerInformed> list = new List<BusinessEntities.ConsentForms.FillerInformed>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FillerInformed
                {
                    ficId = Convert.ToInt32(dr["ficId"]),
                    fic_appId = Convert.ToInt32(dr["fic_appId"]),
                    fic_1 = dr["fic_1"].ToString(),
                    fic_status = dr["fic_status"].ToString(),
                    fic_date_modified = Convert.ToDateTime(dr["fic_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveFillerInformed(BusinessEntities.ConsentForms.FillerInformed derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerInformed.SaveFillerInformed(derma, madeby);
        }
        public static int DeleteFillerInformed(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerInformed.DeleteFillerInformed(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetFillerInformedPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerInformed.GetFillerInformedPreviousHistory(appId);
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
