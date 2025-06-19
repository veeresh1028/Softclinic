using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ConsentOrthoArb
    {
        public static List<BusinessEntities.ConsentForms.ConsentOrthoArb> GetConsentOrthoArbData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentOrthoArb.GetConsentOrthoArbData(appId);
            List<BusinessEntities.ConsentForms.ConsentOrthoArb> list = new List<BusinessEntities.ConsentForms.ConsentOrthoArb>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ConsentOrthoArb
                {
                    cpcoId = Convert.ToInt32(dr["cpcoId"]),
                    cpco_appId = Convert.ToInt32(dr["cpco_appId"]),
                    cpco_1 = dr["cpco_1"].ToString(),
                    cpco_2 = dr["cpco_2"].ToString(),
                    cpco_status = dr["cpco_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveConsentOrthoArb(BusinessEntities.ConsentForms.ConsentOrthoArb ortho, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentOrthoArb.SaveConsentOrthoArb(ortho, madeby);
        }
        public static int DeleteConsentOrthoArb(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentOrthoArb.DeleteConsentOrthoArb(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetConsentOrthoArbPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentOrthoArb.GetConsentOrthoArbPreviousHistory(appId);
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
