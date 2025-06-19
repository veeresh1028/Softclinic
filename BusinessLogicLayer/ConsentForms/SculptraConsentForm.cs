using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class SculptraConsentForm
    {
        public static List<BusinessEntities.ConsentForms.SculptraConsentForm> GetSculptraConsentFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SculptraConsentForm.GetSculptraConsentFormData(appId);
            List<BusinessEntities.ConsentForms.SculptraConsentForm> list = new List<BusinessEntities.ConsentForms.SculptraConsentForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SculptraConsentForm
                {
                    scfId = Convert.ToInt32(dr["scfId"]),
                    scf_appId = Convert.ToInt32(dr["scf_appId"]),
                    scf_witness = dr["scf_witness"].ToString(),
                    scf_status = dr["scf_status"].ToString(),
                    scf_date_modified = Convert.ToDateTime(dr["scf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveSculptraConsentForm(BusinessEntities.ConsentForms.SculptraConsentForm sculptra, int madeby)
        {
            return DataAccessLayer.ConsentForms.SculptraConsentForm.SaveSculptraConsentForm(sculptra, madeby);
        }
        public static int DeleteSculptraConsentForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.SculptraConsentForm.DeleteSculptraConsentForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetSculptraConsentFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SculptraConsentForm.GetSculptraConsentFormPreviousHistory(appId);
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
