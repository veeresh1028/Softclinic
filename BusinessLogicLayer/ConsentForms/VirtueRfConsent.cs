using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class VirtueRfConsent
    {
        public static List<BusinessEntities.ConsentForms.VirtueRfConsent> GetVirtueRfConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.VirtueRfConsent.GetVirtueRfConsentData(appId);
            List<BusinessEntities.ConsentForms.VirtueRfConsent> list = new List<BusinessEntities.ConsentForms.VirtueRfConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.VirtueRfConsent
                {
                    vrcId = Convert.ToInt32(dr["vrcId"]),
                    vrc_appId = Convert.ToInt32(dr["vrc_appId"]),
                    vrc_1 = dr["vrc_1"].ToString(),
                    vrc_status = dr["vrc_status"].ToString(),
                    vrc_date_modified = Convert.ToDateTime(dr["vrc_date_modified"].ToString()),


                });
            }
            return list;
        }


        public static int SaveVirtueRfConsent(BusinessEntities.ConsentForms.VirtueRfConsent virtue, int madeby)
        {
            return DataAccessLayer.ConsentForms.VirtueRfConsent.SaveVirtueRfConsent(virtue, madeby);
        }


        public static int DeleteVirtueRfConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.VirtueRfConsent.DeleteVirtueRfConsent(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetVirtueRfConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.VirtueRfConsent.GetVirtueRfConsentPreviousHistory(appId);
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
