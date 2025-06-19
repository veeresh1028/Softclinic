using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class KenakortInjectionNew
    {
        public static List<BusinessEntities.ConsentForms.KenakortInjectionNew> GetKenakortInjectionNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.KenakortInjectionNew.GetKenakortInjectionNewData(appId);
            List<BusinessEntities.ConsentForms.KenakortInjectionNew> list = new List<BusinessEntities.ConsentForms.KenakortInjectionNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.KenakortInjectionNew
                {
                    okiId = Convert.ToInt32(dr["okiId"]),
                    oki_appId = Convert.ToInt32(dr["oki_appId"]),
                    oki_1 = dr["oki_1"].ToString(),
                    oki_2 = dr["oki_2"].ToString(),
                    oki_3 = dr["oki_3"].ToString(),
                    oki_4 = dr["oki_4"].ToString(),
                    oki_5 = dr["oki_5"].ToString(),
                    oki_6 = dr["oki_6"].ToString(),
                    oki_status = dr["oki_status"].ToString(),
                    oki_date_modified = Convert.ToDateTime(dr["oki_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveKenakortInjectionNew(BusinessEntities.ConsentForms.KenakortInjectionNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.KenakortInjectionNew.SaveKenakortInjectionNew(discharge, madeby);
        }

        public static int DeleteKenakortInjectionNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.KenakortInjectionNew.DeleteKenakortInjectionNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetKenakortInjectionNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.KenakortInjectionNew.GetKenakortInjectionNewPreviousHistory(appId);
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
