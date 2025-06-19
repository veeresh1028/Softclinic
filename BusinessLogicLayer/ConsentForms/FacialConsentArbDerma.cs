using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FacialConsentArbDerma
    {
        public static List<BusinessEntities.ConsentForms.FacialConsentArbDerma> GetFacialConsentArbDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialConsentArbDerma.GetFacialConsentArbDermaData(appId);
            List<BusinessEntities.ConsentForms.FacialConsentArbDerma> list = new List<BusinessEntities.ConsentForms.FacialConsentArbDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FacialConsentArbDerma
                {
                    ftfaId = Convert.ToInt32(dr["ftfaId"]),
                    ftfa_appId = Convert.ToInt32(dr["ftfa_appId"]),
                    ftfa_1 = dr["ftfa_1"].ToString(),
                    ftfa_2 = dr["ftfa_2"].ToString(),
                    ftfa_3 = dr["ftfa_3"].ToString(),
                    ftfa_4 = dr["ftfa_4"].ToString(),
                    ftfa_5 = dr["ftfa_5"].ToString(),
                    ftfa_6 = dr["ftfa_6"].ToString(),
                    ftfa_7 = dr["ftfa_7"].ToString(),
                    ftfa_8 = dr["ftfa_8"].ToString(),
                    ftfa_9 = dr["ftfa_9"].ToString(),
                    ftfa_10 = dr["ftfa_10"].ToString(),
                    ftfa_11 = dr["ftfa_11"].ToString(),
                    ftfa_12 = dr["ftfa_12"].ToString(),
                    ftfa_13 = dr["ftfa_13"].ToString(),
                    ftfa_14 = dr["ftfa_14"].ToString(),
                    ftfa_15 = dr["ftfa_15"].ToString(),
                    ftfa_16 = dr["ftfa_16"].ToString(),
                    ftfa_17 = dr["ftfa_17"].ToString(),
                    ftfa_18 = dr["ftfa_18"].ToString(),
                    ftfa_19 = dr["ftfa_19"].ToString(),
                    ftfa_20 = dr["ftfa_20"].ToString(),
                    ftfa_21 = dr["ftfa_21"].ToString(),
                    ftfa_22 = dr["ftfa_22"].ToString(),
                    ftfa_23 = dr["ftfa_23"].ToString(),
                    ftfa_24 = dr["ftfa_24"].ToString(),
                    ftfa_25 = dr["ftfa_25"].ToString(),
                    ftfa_26 = dr["ftfa_26"].ToString(),
                    ftfa_27 = dr["ftfa_27"].ToString(),
                    ftfa_28 = dr["ftfa_28"].ToString(),
                    ftfa_29 = dr["ftfa_29"].ToString(),
                    ftfa_30 = dr["ftfa_30"].ToString(),
                    ftfa_status = dr["ftfa_status"].ToString(),
                    ftfa_date_modified = Convert.ToDateTime(dr["ftfa_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveFacialConsentArbDerma(BusinessEntities.ConsentForms.FacialConsentArbDerma facial, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialConsentArbDerma.SaveFacialConsentArbDerma(facial, madeby);
        }

        public static int DeleteFacialConsentArbDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialConsentArbDerma.DeleteFacialConsentArbDerma(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetFacialConsentArbDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialConsentArbDerma.GetFacialConsentArbDermaPreviousHistory(appId);
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
