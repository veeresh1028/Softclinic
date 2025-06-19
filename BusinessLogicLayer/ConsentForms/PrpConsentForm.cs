using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PrpConsentForm
    {
        public static List<BusinessEntities.ConsentForms.PrpConsentForm> GetPrpConsentFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpConsentForm.GetPrpConsentFormData(appId);
            List<BusinessEntities.ConsentForms.PrpConsentForm> list = new List<BusinessEntities.ConsentForms.PrpConsentForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PrpConsentForm
                {
                    pcfId = Convert.ToInt32(dr["pcfId"]),
                    pcf_appId = Convert.ToInt32(dr["pcf_appId"]),
                    pcf_witness = dr["pcf_witness"].ToString(),
                    pcf_status = dr["pcf_status"].ToString(),
                    pcf_date_modified = Convert.ToDateTime(dr["pcf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SavePrpConsentForm(BusinessEntities.ConsentForms.PrpConsentForm prp, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpConsentForm.SavePrpConsentForm(prp, madeby);
        }
        public static int DeletePrpConsentForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpConsentForm.DeletePrpConsentForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetPrpConsentFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpConsentForm.GetPrpConsentFormPreviousHistory(appId);
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
