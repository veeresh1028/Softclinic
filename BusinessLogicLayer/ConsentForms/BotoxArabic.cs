using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class BotoxArabic
    {
        public static List<BusinessEntities.ConsentForms.BotoxArabic> GetBotoxArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BotoxArabic.GetBotoxArabicData(appId);
            List<BusinessEntities.ConsentForms.BotoxArabic> list = new List<BusinessEntities.ConsentForms.BotoxArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.BotoxArabic
                {
                    bafId = Convert.ToInt32(dr["bafId"]),
                    baf_appId = Convert.ToInt32(dr["baf_appId"]),
                    baf_1 = dr["baf_1"].ToString(),
                    baf_status = dr["baf_status"].ToString(),
                    baf_date_modified = Convert.ToDateTime(dr["baf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveBotoxArabic(BusinessEntities.ConsentForms.BotoxArabic derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.BotoxArabic.SaveBotoxArabic(derma, madeby);
        }
        public static int DeleteBotoxArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.BotoxArabic.DeleteBotoxArabic(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetBotoxArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BotoxArabic.GetBotoxArabicPreviousHistory(appId);
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
