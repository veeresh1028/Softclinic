using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ColposcopyReferral
    {
        public static List<BusinessEntities.ConsentForms.ColposcopyReferral> GetColposcopyReferralData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ColposcopyReferral.GetColposcopyReferralData(appId);
            List<BusinessEntities.ConsentForms.ColposcopyReferral> list = new List<BusinessEntities.ConsentForms.ColposcopyReferral>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ColposcopyReferral
                {
                    crnId = Convert.ToInt32(dr["crnId"]),
                    crn_appId = Convert.ToInt32(dr["crn_appId"]),
                    crn_1 = dr["crn_1"].ToString(),
                    crn_2 = dr["crn_2"].ToString(),
                    crn_3 = dr["crn_3"].ToString(),
                    crn_radio1 = dr["crn_radio1"].ToString(),

                    crn_date1 = dr["crn_date1"].ToString(),
                    crn_date2 = dr["crn_date2"].ToString(),
                    crn_date3 = dr["crn_date3"].ToString(),
                    crn_date4 = dr["crn_date4"].ToString(),
                    crn_date5 = dr["crn_date5"].ToString(),
                    crn_date6 = dr["crn_date6"].ToString(),
                    crn_date7 = dr["crn_date7"].ToString(),
                    crn_date8 = dr["crn_date8"].ToString(),
                    crn_date9 = dr["crn_date9"].ToString(),

                    crn_time1 = Convert.ToDateTime(dr["crn_time1"].ToString()).ToString("HH:mm"),
                   
                    crn_status = dr["crn_status"].ToString(),
                    crn_date_modified = Convert.ToDateTime(dr["crn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveColposcopyReferral(BusinessEntities.ConsentForms.ColposcopyReferral gyna, int madeby)
        {
            return DataAccessLayer.ConsentForms.ColposcopyReferral.SaveColposcopyReferral(gyna, madeby);
        }
        public static int DeleteColposcopyReferral(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ColposcopyReferral.DeleteColposcopyReferral(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetColposcopyReferralPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ColposcopyReferral.GetColposcopyReferralPreviousHistory(appId);
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
