using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class AdnicMemberConsent
    {
        public static List<BusinessEntities.InsuranceForms.AdnicMemberConsent> GetAdnicMemberConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicMemberConsent.GetAdnicMemberConsentData(appId);
            List<BusinessEntities.InsuranceForms.AdnicMemberConsent> list = new List<BusinessEntities.InsuranceForms.AdnicMemberConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.AdnicMemberConsent
                {
                    mcafId = Convert.ToInt32(dr["mcafId"]),
                    mcaf_appId = Convert.ToInt32(dr["mcaf_appId"]),
                    mcaf_mem_name = dr["mcaf_mem_name"].ToString(),
                    mcaf_pat_name = dr["mcaf_pat_name"].ToString(),
                    mcaf_pat_memno = dr["mcaf_pat_memno"].ToString(),
                    mcaf_relationship = dr["mcaf_relationship"].ToString(),
                    mcaf_pat_fileno = dr["mcaf_pat_fileno"].ToString(),
                    mcaf_pat_mob = dr["mcaf_pat_mob"].ToString(),
                    mcaf_auth = dr["mcaf_auth"].ToString(),
                    mcaf_auth1 = dr["mcaf_auth1"].ToString(),
                    mcaf_status = dr["mcaf_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveAdnicMemberConsent(BusinessEntities.InsuranceForms.AdnicMemberConsent member, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicMemberConsent.SaveAdnicMemberConsent(member, madeby);
        }

        public static int DeleteAdnicMemberConsent(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicMemberConsent.DeleteAdnicMemberConsent(appId, madeby);
        }

        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetAdnicMemberConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicMemberConsent.GetAdnicMemberConsentPreviousHistory(appId);
            List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> list = new List<BusinessEntities.InsuranceForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.ConcentPreviousHistory
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

