using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class Colposcopy
    {
        public static List<BusinessEntities.ConsentForms.Colposcopy> GetColposcopyData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Colposcopy.GetColposcopyData(appId);
            List<BusinessEntities.ConsentForms.Colposcopy> list = new List<BusinessEntities.ConsentForms.Colposcopy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.Colposcopy
                {
                    ccnId = Convert.ToInt32(dr["ccnId"]),
                    ccn_appId = Convert.ToInt32(dr["ccn_appId"]),
                    ccn_1 = dr["ccn_1"].ToString(),
                    ccn_2 = dr["ccn_2"].ToString(),
                    ccn_status = dr["ccn_status"].ToString(),
                    ccn_date_modified = Convert.ToDateTime(dr["ccn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveColposcopy(BusinessEntities.ConsentForms.Colposcopy gyna, int madeby)
        {
            return DataAccessLayer.ConsentForms.Colposcopy.SaveColposcopy(gyna, madeby);
        }
        public static int DeleteColposcopy(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.Colposcopy.DeleteColposcopy(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetColposcopyPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Colposcopy.GetColposcopyPreviousHistory(appId);
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
