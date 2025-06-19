using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OperativeEyleaInjectionNew
    {
        public static List<BusinessEntities.ConsentForms.OperativeEyleaInjectionNew> GetOperativeEyleaInjectionNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeEyleaInjectionNew.GetOperativeEyleaInjectionNewData(appId);
            List<BusinessEntities.ConsentForms.OperativeEyleaInjectionNew> list = new List<BusinessEntities.ConsentForms.OperativeEyleaInjectionNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OperativeEyleaInjectionNew
                {
                    oreiId = Convert.ToInt32(dr["oreiId"]),
                    orei_appId = Convert.ToInt32(dr["orei_appId"]),
                    orei_1 = dr["orei_1"].ToString(),
                    orei_2 = dr["orei_2"].ToString(),
                    orei_3 = dr["orei_3"].ToString(),
                    orei_4 = dr["orei_4"].ToString(),
                    orei_5 = dr["orei_5"].ToString(),
                    orei_6 = dr["orei_6"].ToString(),
                    orei_status = dr["orei_status"].ToString(),
                    orei_date_modified = Convert.ToDateTime(dr["orei_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveOperativeEyleaInjectionNew(BusinessEntities.ConsentForms.OperativeEyleaInjectionNew operative, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeEyleaInjectionNew.SaveOperativeEyleaInjectionNew(operative, madeby);
        }

        public static int DeleteOperativeEyleaInjectionNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeEyleaInjectionNew.DeleteOperativeEyleaInjectionNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOperativeEyleaInjectionNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeEyleaInjectionNew.GetOperativeEyleaInjectionNewPreviousHistory(appId);
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
