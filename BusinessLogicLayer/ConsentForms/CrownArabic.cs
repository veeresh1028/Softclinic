using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class CrownArabic
    {
        public static List<BusinessEntities.ConcentForms.CrownArabic> GetCrownArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.CrownArabic.GetCrownArabicData(appId);
            List<BusinessEntities.ConcentForms.CrownArabic> list = new List<BusinessEntities.ConcentForms.CrownArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.CrownArabic
                {
                    iccaId = Convert.ToInt32(dr["iccaId"]),
                    icca_appId = Convert.ToInt32(dr["icca_appId"]),
                    icca_1 = dr["icca_1"].ToString(),
                    icca_2 = dr["icca_2"].ToString(),
                    icca_3 = dr["icca_3"].ToString(),
                    icca_4 = dr["icca_4"].ToString(),
                    icca_status = dr["icca_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveCrownArabic(BusinessEntities.ConcentForms.CrownArabic crown, int madeby)
        {
            return DataAccessLayer.ConcentForms.CrownArabic.SaveCrownArabic(crown, madeby);
        }
        public static int DeleteCrownArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.CrownArabic.DeleteCrownArabic(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetCrownArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.CrownArabic.GetCrownArabicPreviousHistory(appId);
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
