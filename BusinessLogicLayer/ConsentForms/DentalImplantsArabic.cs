using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
   public class DentalImplantsArabic
    {
        public static List<BusinessEntities.ConcentForms.DentalImplantsArabic> GetDentalImplantsArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.DentalImplantsArabic.GetDentalImplantsArabicData(appId);
            List<BusinessEntities.ConcentForms.DentalImplantsArabic> list = new List<BusinessEntities.ConcentForms.DentalImplantsArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.DentalImplantsArabic
                {
                    pcdaId = Convert.ToInt32(dr["pcdaId"]),
                    pcda_appId = Convert.ToInt32(dr["pcda_appId"]),
                    pcda_1 = dr["pcda_1"].ToString(),
                    pcda_2 = dr["pcda_2"].ToString(),
                    pcda_status = dr["pcda_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveDentalImplantsArabic(BusinessEntities.ConcentForms.DentalImplantsArabic dental, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalImplantsArabic.SaveDentalImplantsArabic(dental, madeby);
        }

        public static int DeleteDentalImplantsArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.DentalImplantsArabic.DeleteDentalImplantsArabic(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetDentalImplantsArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.DentalImplantsArabic.GetDentalImplantsArabicPreviousHistory(appId);
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
