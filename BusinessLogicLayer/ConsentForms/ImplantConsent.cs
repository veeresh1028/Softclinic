using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class ImplantConsent
    {
        public static List<BusinessEntities.ConcentForms.ImplantConsent> GetImplantConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ImplantConsent.GetImplantConsentData(appId);
            List<BusinessEntities.ConcentForms.ImplantConsent> list = new List<BusinessEntities.ConcentForms.ImplantConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ImplantConsent
                {
                    imcId = Convert.ToInt32(dr["imcId"]),
                    imc_appId = Convert.ToInt32(dr["imc_appId"]),
                    imc_1 = dr["imc_1"].ToString(),
                    imc_2 = dr["imc_2"].ToString(),
                    imc_3 = dr["imc_3"].ToString(),
                    imc_status = dr["imc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveImplantConsent(BusinessEntities.ConcentForms.ImplantConsent implant, int madeby)
        {
            return DataAccessLayer.ConcentForms.ImplantConsent.SaveImplantConsent(implant, madeby);
        }

        public static int DeleteImplantConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.ImplantConsent.DeleteImplantConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetImplantConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ImplantConsent.GetImplantConsentPreviousHistory(appId);
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
