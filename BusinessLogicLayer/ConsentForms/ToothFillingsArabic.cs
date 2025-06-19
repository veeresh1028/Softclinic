using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ToothFillingsArabic
    {
        public static List<BusinessEntities.ConsentForms.ToothFillingsArabic> GetToothFillingsArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ToothFillingsArabic.GetToothFillingsArabicData(appId);
            List<BusinessEntities.ConsentForms.ToothFillingsArabic> list = new List<BusinessEntities.ConsentForms.ToothFillingsArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ToothFillingsArabic
                {
                    itfaId = Convert.ToInt32(dr["itfaId"]),
                    itfa_appId = Convert.ToInt32(dr["itfa_appId"]),
                    itfa_1 = dr["itfa_1"].ToString(),
                    itfa_2 = dr["itfa_2"].ToString(),
                    itfa_status = dr["itfa_status"].ToString(),
                });
            }
            return list;
        }


        public static int SaveToothFillingsArabic(BusinessEntities.ConsentForms.ToothFillingsArabic fillings, int madeby)
        {
            return DataAccessLayer.ConsentForms.ToothFillingsArabic.SaveToothFillingsArabic(fillings, madeby);
        }

        public static int DeleteToothFillingsArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ToothFillingsArabic.DeleteToothFillingsArabic(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetToothFillingsArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ToothFillingsArabic.GetToothFillingsArabicPreviousHistory(appId);
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
