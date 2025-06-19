using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OperativeOzurdexInjectionNew
    {
        public static List<BusinessEntities.ConsentForms.OperativeOzurdexInjectionNew> GetOperativeOzurdexInjectionNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeOzurdexInjectionNew.GetOperativeOzurdexInjectionNewData(appId);
            List<BusinessEntities.ConsentForms.OperativeOzurdexInjectionNew> list = new List<BusinessEntities.ConsentForms.OperativeOzurdexInjectionNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OperativeOzurdexInjectionNew
                {
                    ooiId = Convert.ToInt32(dr["ooiId"]),
                    ooi_appId = Convert.ToInt32(dr["ooi_appId"]),
                    ooi_1 = dr["ooi_1"].ToString(),
                    ooi_2 = dr["ooi_2"].ToString(),
                    ooi_3 = dr["ooi_3"].ToString(),
                    ooi_4 = dr["ooi_4"].ToString(),
                    ooi_5 = dr["ooi_5"].ToString(),
                    ooi_status = dr["ooi_status"].ToString(),
                    ooi_date_modified = Convert.ToDateTime(dr["ooi_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveOperativeOzurdexInjectionNew(BusinessEntities.ConsentForms.OperativeOzurdexInjectionNew operative, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeOzurdexInjectionNew.SaveOperativeOzurdexInjectionNew(operative, madeby);
        }

        public static int DeleteOperativeOzurdexInjectionNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeOzurdexInjectionNew.DeleteOperativeOzurdexInjectionNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOperativeOzurdexInjectionNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeOzurdexInjectionNew.GetOperativeOzurdexInjectionNewPreviousHistory(appId);
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
