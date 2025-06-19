using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DentalImplantConsentArabic
    {
        public static List<BusinessEntities.ConsentForms.DentalImplantConsentArabic> GetDentalImplantConsentArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DentalImplantConsentArabic.GetDentalImplantConsentArabicData(appId);
            List<BusinessEntities.ConsentForms.DentalImplantConsentArabic> list = new List<BusinessEntities.ConsentForms.DentalImplantConsentArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DentalImplantConsentArabic
                {
                    dicaId = Convert.ToInt32(dr["dicaId"]),
                    dica_appId = Convert.ToInt32(dr["dica_appId"]),
                    dica_1 = dr["dica_1"].ToString(),
                    dica_2 = dr["dica_2"].ToString(),
                    dica_3 = dr["dica_3"].ToString(),
                    dica_status = dr["dica_status"].ToString(),
                });
            }
            return list;
        }


        public static int SaveDentalImplantConsentArabic(BusinessEntities.ConsentForms.DentalImplantConsentArabic surgery, int madeby)
        {
            return DataAccessLayer.ConsentForms.DentalImplantConsentArabic.SaveDentalImplantConsentArabic(surgery, madeby);
        }

        public static int DeleteDentalImplantConsentArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DentalImplantConsentArabic.DeleteDentalImplantConsentArabic(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetDentalImplantConsentArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DentalImplantConsentArabic.GetDentalImplantConsentArabicPreviousHistory(appId);
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
