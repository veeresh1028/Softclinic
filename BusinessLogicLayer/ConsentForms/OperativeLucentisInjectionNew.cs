using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OperativeLucentisInjectionNew
    {
        public static List<BusinessEntities.ConsentForms.OperativeLucentisInjectionNew> GetOperativeLucentisInjectionNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeLucentisInjectionNew.GetOperativeLucentisInjectionNewData(appId);
            List<BusinessEntities.ConsentForms.OperativeLucentisInjectionNew> list = new List<BusinessEntities.ConsentForms.OperativeLucentisInjectionNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OperativeLucentisInjectionNew
                {
                    oliId = Convert.ToInt32(dr["oliId"]),
                    oli_appId = Convert.ToInt32(dr["oli_appId"]),
                    oli_1 = dr["oli_1"].ToString(),
                    oli_2 = dr["oli_2"].ToString(),
                    oli_3 = dr["oli_3"].ToString(),
                    oli_4 = dr["oli_4"].ToString(),
                    oli_5 = dr["oli_5"].ToString(),
                    oli_6 = dr["oli_6"].ToString(),
                    oli_status = dr["oli_status"].ToString(),
                    oli_date_modified = Convert.ToDateTime(dr["oli_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveOperativeLucentisInjectionNew(BusinessEntities.ConsentForms.OperativeLucentisInjectionNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeLucentisInjectionNew.SaveOperativeLucentisInjectionNew(discharge, madeby);
        }

        public static int DeleteOperativeLucentisInjectionNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeLucentisInjectionNew.DeleteOperativeLucentisInjectionNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOperativeLucentisInjectionNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeLucentisInjectionNew.GetOperativeLucentisInjectionNewPreviousHistory(appId);
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
