using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class VascularConsent
    {
        public static List<BusinessEntities.ConsentForms.VascularConsent> GetVascularConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.VascularConsent.GetVascularConsentData(appId);
            List<BusinessEntities.ConsentForms.VascularConsent> list = new List<BusinessEntities.ConsentForms.VascularConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.VascularConsent
                {
                    picId = Convert.ToInt32(dr["picId"]),
                    pic_appId = Convert.ToInt32(dr["pic_appId"]),
                    pic_1 = dr["pic_1"].ToString(),
                    pic_2 = dr["pic_2"].ToString(),
                    pic_3 = dr["pic_3"].ToString(),
                    pic_status = dr["pic_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveVascularConsent(BusinessEntities.ConsentForms.VascularConsent crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.VascularConsent.SaveVascularConsent(crown, madeby);
        }
        public static int DeleteVascularConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.VascularConsent.DeleteVascularConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetVascularConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.VascularConsent.GetVascularConsentPreviousHistory(appId);
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
