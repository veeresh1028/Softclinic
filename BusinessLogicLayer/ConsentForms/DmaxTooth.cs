using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxTooth
    {
        public static List<BusinessEntities.ConsentForms.DmaxTooth> GetDmaxToothData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxTooth.GetDmaxToothData(appId);
            List<BusinessEntities.ConsentForms.DmaxTooth> list = new List<BusinessEntities.ConsentForms.DmaxTooth>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxTooth
                {
                    cdtId = Convert.ToInt32(dr["cdtId"]),
                    cdt_appId = Convert.ToInt32(dr["cdt_appId"]),
                    cdt_1 = dr["cdt_1"].ToString(),
                    cdt_2 = dr["cdt_2"].ToString(),
                    cdt_3 = dr["cdt_3"].ToString(),
                    cdt_4 = dr["cdt_4"].ToString(),
                    cdt_status = dr["cdt_status"].ToString(),
                    cdt_date_modified = Convert.ToDateTime(dr["cdt_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxTooth(BusinessEntities.ConsentForms.DmaxTooth derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxTooth.SaveDmaxTooth(derma, madeby);
        }
        public static int DeleteDmaxTooth(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxTooth.DeleteDmaxTooth(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxToothPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxTooth.GetDmaxToothPreviousHistory(appId);
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
