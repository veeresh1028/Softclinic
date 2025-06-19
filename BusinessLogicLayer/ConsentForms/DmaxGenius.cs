using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxGenius
    {
        public static List<BusinessEntities.ConsentForms.DmaxGenius> GetDmaxGeniusData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxGenius.GetDmaxGeniusData(appId);
            List<BusinessEntities.ConsentForms.DmaxGenius> list = new List<BusinessEntities.ConsentForms.DmaxGenius>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxGenius
                {
                    cdgId = Convert.ToInt32(dr["cdgId"]),
                    cdg_appId = Convert.ToInt32(dr["cdg_appId"]),
                    cdg_1 = dr["cdg_1"].ToString(),
                    cdg_status = dr["cdg_status"].ToString(),
                    cdg_date_modified = Convert.ToDateTime(dr["cdg_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxGenius(BusinessEntities.ConsentForms.DmaxGenius derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxGenius.SaveDmaxGenius(derma, madeby);
        }
        public static int DeleteDmaxGenius(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxGenius.DeleteDmaxGenius(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxGeniusPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxGenius.GetDmaxGeniusPreviousHistory(appId);
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
