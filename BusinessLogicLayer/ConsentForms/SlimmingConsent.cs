using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class SlimmingConsent
    {
        public static List<BusinessEntities.ConsentForms.SlimmingConsent> GetSlimmingConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SlimmingConsent.GetSlimmingConsentData(appId);
            List<BusinessEntities.ConsentForms.SlimmingConsent> list = new List<BusinessEntities.ConsentForms.SlimmingConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SlimmingConsent
                {
                    sscId = Convert.ToInt32(dr["sscId"]),
                    ssc_appId = Convert.ToInt32(dr["ssc_appId"]),
                    ssc_1 = dr["ssc_1"].ToString(),
                    ssc_2 = dr["ssc_2"].ToString(),
                    ssc_3 = dr["ssc_3"].ToString(),
                    ssc_4 = dr["ssc_4"].ToString(),
                    ssc_5 = dr["ssc_5"].ToString(),
                    ssc_6 = dr["ssc_6"].ToString(),
                    ssc_7 = dr["ssc_7"].ToString(),
                    ssc_doc = dr["ssc_doc"].ToString(),
                    ssc_status = dr["ssc_status"].ToString(),
                    ssc_date_modified = Convert.ToDateTime(dr["ssc_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static List<BusinessEntities.ConsentForms.SlimmingConsent> GetAllSlimming(int appId, int? sscId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SlimmingConsent.GetAllSlimming(appId, sscId);
            List<BusinessEntities.ConsentForms.SlimmingConsent> list = new List<BusinessEntities.ConsentForms.SlimmingConsent>();


            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SlimmingConsent
                {
                    sscId = Convert.ToInt32(dr["sscId"]),
                    ssc_appId = Convert.ToInt32(dr["ssc_appId"]),
                    ssc_1 = dr["ssc_1"].ToString(),
                    ssc_2 = dr["ssc_2"].ToString(),
                    ssc_3 = dr["ssc_3"].ToString(),
                    ssc_4 = dr["ssc_4"].ToString(),
                    ssc_5 = dr["ssc_5"].ToString(),
                    ssc_6 = dr["ssc_6"].ToString(),
                    ssc_7 = dr["ssc_7"].ToString(),
                    ssc_status = dr["ssc_status"].ToString(),
                    ssc_date_modified = Convert.ToDateTime(dr["ssc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static List<CommonDDL> GetSlimmingSheetDropdownData(string query)
        {
            List<CommonDDL> roomlist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.ConsentForms.SlimmingConsent.GetSlimmingSheetDropdownData(query);

            foreach (DataRow dr in dt.Rows)
            {
                roomlist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["ssdId"]),
                    text = dr["ssd_text"].ToString(),
                });
            }
            return roomlist;
        }


        public static int SaveSlimmingConsent(BusinessEntities.ConsentForms.Slimming_Consent slimming, int madeby)
        {
            return DataAccessLayer.ConsentForms.SlimmingConsent.SaveSlimmingConsent(slimming, madeby);
        }



        public static int DeleteSlimmingConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.SlimmingConsent.DeleteSlimmingConsent(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetSlimmingConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SlimmingConsent.GetSlimmingConsentPreviousHistory(appId);
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
