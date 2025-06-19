using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DentalSurgeryArabic
    {
        public static List<BusinessEntities.ConcentForms.DentalSurgeryArabic> GetDentalSurgeryArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.DentalSurgeryArabic.GetDentalSurgeryArabicData(appId);
            List<BusinessEntities.ConcentForms.DentalSurgeryArabic> list = new List<BusinessEntities.ConcentForms.DentalSurgeryArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.DentalSurgeryArabic
                {
                    pdsaId = Convert.ToInt32(dr["pdsaId"]),
                    pdsa_appId = Convert.ToInt32(dr["pdsa_appId"]),
                    pdsa_1 = dr["pdsa_1"].ToString(),
                    pdsa_2 = dr["pdsa_2"].ToString(),
                    pdsa_3 = dr["pdsa_3"].ToString(),
                    pdsa_status = dr["pdsa_status"].ToString(),
                });
            }
            return list;
        }


        public static int SaveDentalSurgeryArabic(BusinessEntities.ConcentForms.DentalSurgeryArabic surgery, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalSurgeryArabic.SaveDentalSurgeryArabic(surgery, madeby);
        }

        public static int DeleteDentalSurgeryArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalSurgeryArabic.DeleteDentalSurgeryArabic(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetDentalSurgeryArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.DentalSurgeryArabic.GetDentalSurgeryArabicPreviousHistory(appId);
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
