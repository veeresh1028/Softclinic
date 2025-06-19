using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PhotoConsent
    {
        public static List<BusinessEntities.ConsentForms.PhotoConsent> GetPhotoConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhotoConsent.GetPhotoConsentData(appId);
            List<BusinessEntities.ConsentForms.PhotoConsent> list = new List<BusinessEntities.ConsentForms.PhotoConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PhotoConsent
                {
                    cpccId = Convert.ToInt32(dr["cpccId"]),
                    cpcc_appId = Convert.ToInt32(dr["cpcc_appId"]),
                    cpcc_status = dr["cpcc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SavePhotoConsent(BusinessEntities.ConsentForms.PhotoConsent photo, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhotoConsent.SavePhotoConsent(photo, madeby);
        }

        public static int DeletePhotoConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhotoConsent.DeletePhotoConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPhotoConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhotoConsent.GetPhotoConsentPreviousHistory(appId);
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
