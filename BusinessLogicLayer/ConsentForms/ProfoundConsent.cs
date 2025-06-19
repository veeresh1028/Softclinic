using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ProfoundConsent
    {
        public static List<BusinessEntities.ConsentForms.ProfoundConsent> GetProfoundConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ProfoundConsent.GetProfoundConsentData(appId);
            List<BusinessEntities.ConsentForms.ProfoundConsent> list = new List<BusinessEntities.ConsentForms.ProfoundConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ProfoundConsent
                {
                    prfId = Convert.ToInt32(dr["prfId"]),
                    prf_appId = Convert.ToInt32(dr["prf_appId"]),
                    prf_1 = dr["prf_1"].ToString(),
                    prf_status = dr["prf_status"].ToString(),
                    prf_date_modified = Convert.ToDateTime(dr["prf_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveProfoundConsent(BusinessEntities.ConsentForms.ProfoundConsent profound, int madeby)
        {
            return DataAccessLayer.ConsentForms.ProfoundConsent.SaveProfoundConsent(profound, madeby);
        }


        public static int DeleteProfoundConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ProfoundConsent.DeleteProfoundConsent(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetProfoundConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ProfoundConsent.GetProfoundConsentPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
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
