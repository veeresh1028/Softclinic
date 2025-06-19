using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxEndodontic
    {
        public static List<BusinessEntities.ConsentForms.DmaxEndodontic> GetDmaxEndodonticData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxEndodontic.GetDmaxEndodonticData(appId);
            List<BusinessEntities.ConsentForms.DmaxEndodontic> list = new List<BusinessEntities.ConsentForms.DmaxEndodontic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxEndodontic
                {
                    cdeId = Convert.ToInt32(dr["cdeId"]),
                    cde_appId = Convert.ToInt32(dr["cde_appId"]),
                    cde_1 = dr["cde_1"].ToString(),
                    cde_2 = dr["cde_2"].ToString(),
                    cde_3 = dr["cde_3"].ToString(),
                    cde_status = dr["cde_status"].ToString(),
                    cde_date_modified = Convert.ToDateTime(dr["cde_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxEndodontic(BusinessEntities.ConsentForms.DmaxEndodontic derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxEndodontic.SaveDmaxEndodontic(derma, madeby);
        }
        public static int DeleteDmaxEndodontic(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxEndodontic.DeleteDmaxEndodontic(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxEndodonticPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxEndodontic.GetDmaxEndodonticPreviousHistory(appId);
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
