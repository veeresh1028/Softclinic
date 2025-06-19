using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class AdnicClaim
    {
        public static List<BusinessEntities.InsuranceForms.AdnicClaim> GetAdnicClaimData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicClaim.GetAdnicClaimData(appId);
            List<BusinessEntities.InsuranceForms.AdnicClaim> list = new List<BusinessEntities.InsuranceForms.AdnicClaim>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.AdnicClaim
                {
                    acId = Convert.ToInt32(dr["acId"]),
                    ac_appId = Convert.ToInt32(dr["ac_appId"]),
                    ac_voucher = dr["ac_voucher"].ToString(),
                    ac_rel = dr["ac_rel"].ToString(),
                    ac_ins = dr["ac_ins"].ToString(),
                    ac_acc = dr["ac_acc"].ToString(),
                    ac_acc_details = dr["ac_acc_details"].ToString(),
                    ac_cond = dr["ac_cond"].ToString(),
                    ac_groupname = dr["ac_groupname"].ToString(),
                    ac_employer = dr["ac_employer"].ToString(),
                    ac_set = dr["ac_set"].ToString(),
                    ac_status = dr["ac_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveAdnicClaim(BusinessEntities.InsuranceForms.AdnicClaim claim, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicClaim.SaveAdnicClaim(claim, madeby);
        }
        public static int DeleteAdnicClaim(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicClaim.DeleteAdnicClaim(appId, madeby);
        }

        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetAdnicClaimPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicClaim.GetAdnicClaimPreviousHistory(appId);
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
