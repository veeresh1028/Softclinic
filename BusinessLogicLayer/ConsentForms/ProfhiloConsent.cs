using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ProfhiloConsent
    {
        public static List<BusinessEntities.ConsentForms.ProfhiloConsent> GetProfhiloConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ProfhiloConsent.GetProfhiloConsentData(appId);
            List<BusinessEntities.ConsentForms.ProfhiloConsent> list = new List<BusinessEntities.ConsentForms.ProfhiloConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ProfhiloConsent
                {
                    pcfId = Convert.ToInt32(dr["pcfId"]),
                    pcf_appId = Convert.ToInt32(dr["pcf_appId"]),
                    pcf_1 = dr["pcf_1"].ToString(),
                    pcf_status = dr["pcf_status"].ToString(),
                    pcf_date_modified = Convert.ToDateTime(dr["pcf_date_modified"].ToString()),
                });
            }
            return list;
        }



        public static int SaveProfhiloConsent(BusinessEntities.ConsentForms.ProfhiloConsent profhilo, int madeby)
        {
            return DataAccessLayer.ConsentForms.ProfhiloConsent.SaveProfhiloConsent(profhilo, madeby);
        }


        public static int DeleteProfhiloConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ProfhiloConsent.DeleteProfhiloConsent(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetProfhiloConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ProfhiloConsent.GetProfhiloConsentPreviousHistory(appId);
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
