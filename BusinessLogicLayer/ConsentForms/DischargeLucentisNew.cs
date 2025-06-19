using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeLucentisNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeLucentisNew> GetDischargeLucentisNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeLucentisNew.GetDischargeLucentisNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeLucentisNew> list = new List<BusinessEntities.ConsentForms.DischargeLucentisNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeLucentisNew
                {
                    dliId = Convert.ToInt32(dr["dliId"]),
                    dli_appId = Convert.ToInt32(dr["dli_appId"]),
                    dli_1 = dr["dli_1"].ToString(),
                    dli_2 = dr["dli_2"].ToString(),
                    dli_3 = dr["dli_3"].ToString(),
                    dli_4 = dr["dli_4"].ToString(),
                    dli_5 = dr["dli_5"].ToString(),
                    dli_6 = dr["dli_6"].ToString(),
                    dli_status = dr["dli_status"].ToString(),
                    dli_date_modified = Convert.ToDateTime(dr["dli_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeLucentisNew(BusinessEntities.ConsentForms.DischargeLucentisNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeLucentisNew.SaveDischargeLucentisNew(discharge, madeby);
        }


        public static int DeleteDischargeLucentisNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeLucentisNew.DeleteDischargeLucentisNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeLucentisNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeLucentisNew.GetDischargeLucentisNewPreviousHistory(appId);
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
