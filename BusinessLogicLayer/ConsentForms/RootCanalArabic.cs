using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class RootCanalArabic
    {
        public static List<BusinessEntities.ConsentForms.RootCanalArabic> GetRootCanalArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RootCanalArabic.GetRootCanalArabicData(appId);
            List<BusinessEntities.ConsentForms.RootCanalArabic> list = new List<BusinessEntities.ConsentForms.RootCanalArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.RootCanalArabic
                {
                    crctaId = Convert.ToInt32(dr["crctaId"]),
                    crcta_appId = Convert.ToInt32(dr["crcta_appId"]),
                    crcta_1 = dr["crcta_1"].ToString(),
                    crcta_2 = dr["crcta_2"].ToString(),
                    crcta_3 = dr["crcta_3"].ToString(),
                    crcta_4 = dr["crcta_4"].ToString(),
                    crcta_status = dr["crcta_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveRootCanalArabic(BusinessEntities.ConsentForms.RootCanalArabic canal, int madeby)
        {
            return DataAccessLayer.ConsentForms.RootCanalArabic.SaveRootCanalArabic(canal, madeby);
        }

        public static int DeleteRootCanalArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.RootCanalArabic.DeleteRootCanalArabic(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetRootCanalArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RootCanalArabic.GetRootCanalArabicPreviousHistory(appId);
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
