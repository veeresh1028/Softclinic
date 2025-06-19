using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PrpPeelingConsent
    {
        public static List<BusinessEntities.ConsentForms.PrpPeelingConsent> GetPrpPeelingConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpPeelingConsent.GetPrpPeelingConsentData(appId);
            List<BusinessEntities.ConsentForms.PrpPeelingConsent> list = new List<BusinessEntities.ConsentForms.PrpPeelingConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PrpPeelingConsent
                {
                    ppcId = Convert.ToInt32(dr["ppcId"]),
                    ppc_appId = Convert.ToInt32(dr["ppc_appId"]),
                    ppc_1 = dr["ppc_1"].ToString(),
                    ppc_status = dr["ppc_status"].ToString(),
                    ppc_date_modified = Convert.ToDateTime(dr["ppc_date_modified"].ToString()),

                });
            }
            return list;
        }


        public static int SavePrpPeelingConsent(BusinessEntities.ConsentForms.PrpPeelingConsent peelingConsent, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpPeelingConsent.SavePrpPeelingConsent(peelingConsent, madeby);
        }


        public static int DeletePrpPeelingConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpPeelingConsent.DeletePrpPeelingConsent(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPrpPeelingConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpPeelingConsent.GetPrpPeelingConsentPreviousHistory(appId);
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
