using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PrpConsentDerma
    {
        public static List<BusinessEntities.ConsentForms.PrpConsentDerma> GetPrpConsentDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpConsentDerma.GetPrpConsentDermaData(appId);
            List<BusinessEntities.ConsentForms.PrpConsentDerma> list = new List<BusinessEntities.ConsentForms.PrpConsentDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PrpConsentDerma
                {
                    prpId = Convert.ToInt32(dr["prpId"]),
                    prp_appId = Convert.ToInt32(dr["prp_appId"]),
                    prp_status = dr["prp_status"].ToString(),
                    prp_date_modified = Convert.ToDateTime(dr["prp_date_modified"].ToString()),

                });
            }
            return list;
        }


        public static int SavePrpConsentDerma(BusinessEntities.ConsentForms.PrpConsentDerma prp, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpConsentDerma.SavePrpConsentDerma(prp, madeby);
        }


        public static int DeletePrpConsentDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpConsentDerma.DeletePrpConsentDerma(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPrpConsentDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpConsentDerma.GetPrpConsentDermaPreviousHistory(appId);
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
