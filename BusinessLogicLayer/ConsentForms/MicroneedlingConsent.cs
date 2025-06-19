using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MicroneedlingConsent
    {
        public static List<BusinessEntities.ConsentForms.MicroneedlingConsent> GetMicroneedlingConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MicroneedlingConsent.GetMicroneedlingConsentData(appId);
            List<BusinessEntities.ConsentForms.MicroneedlingConsent> list = new List<BusinessEntities.ConsentForms.MicroneedlingConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MicroneedlingConsent
                {
                    mcfId = Convert.ToInt32(dr["mcfId"]),
                    mcf_appId = Convert.ToInt32(dr["mcf_appId"]),
                    mcf_1 = dr["mcf_1"].ToString(),
                    mcf_status = dr["mcf_status"].ToString(),
                    mcf_date_modified = Convert.ToDateTime(dr["mcf_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveMicroneedlingConsent(BusinessEntities.ConsentForms.MicroneedlingConsent micro, int madeby)
        {
            return DataAccessLayer.ConsentForms.MicroneedlingConsent.SaveMicroneedlingConsent(micro, madeby);
        }


        public static int DeleteMicroneedlingConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MicroneedlingConsent.DeleteMicroneedlingConsent(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetMicroneedlingConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MicroneedlingConsent.GetMicroneedlingConsentPreviousHistory(appId);
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
