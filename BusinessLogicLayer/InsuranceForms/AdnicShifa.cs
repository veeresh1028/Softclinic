using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class AdnicShifa
    {
        public static List<BusinessEntities.InsuranceForms.AdnicShifa> GetAdnicShifaData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicShifa.GetAdnicShifaData(appId);
            List<BusinessEntities.InsuranceForms.AdnicShifa> list = new List<BusinessEntities.InsuranceForms.AdnicShifa>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.AdnicShifa
                {
                    adsId = Convert.ToInt32(dr["adsId"]),
                    ads_appId = Convert.ToInt32(dr["ads_appId"]),
                    ads_voucher = dr["ads_voucher"].ToString(),
                    ads_group_mem = dr["ads_group_mem"].ToString(),
                    ads_type_plan = dr["ads_type_plan"].ToString(),
                    ads_reason = dr["ads_reason"].ToString(),
                    ads_reason_other = dr["ads_reason_other"].ToString(),
                    ads_condition = dr["ads_condition"].ToString(),
                    ads_visit = dr["ads_visit"].ToString(),
                    ads_treat_details = dr["ads_treat_details"].ToString(),
                    ads_addr1 = dr["ads_addr1"].ToString(),
                    ads_bill1 = dr["ads_bill1"].ToString(),
                    ads_tdate1 = dr["ads_tdate1"].ToString(),
                    ads_desc1 = dr["ads_desc1"].ToString(),
                    ads_amt1 = dr["ads_amt1"].ToString(),
                    ads_addr2 = dr["ads_addr2"].ToString(),
                    ads_bill2 = dr["ads_bill2"].ToString(),
                    ads_tdate2 = dr["ads_tdate2"].ToString(),
                    ads_desc2 = dr["ads_desc2"].ToString(),
                    ads_amt2 = dr["ads_amt2"].ToString(),
                    ads_addr3 = dr["ads_addr3"].ToString(),
                    ads_bill3 = dr["ads_bill3"].ToString(),
                    ads_tdate3 = dr["ads_tdate3"].ToString(),
                    ads_desc3 = dr["ads_desc3"].ToString(),
                    ads_amt3 = dr["ads_amt3"].ToString(),
                    ads_addr4 = dr["ads_addr4"].ToString(),
                    ads_bill4 = dr["ads_bill4"].ToString(),
                    ads_tdate4 = dr["ads_tdate4"].ToString(),
                    ads_desc4 = dr["ads_desc4"].ToString(),
                    ads_amt4 = dr["ads_amt4"].ToString(),
                    ads_addr5 = dr["ads_addr5"].ToString(),
                    ads_bill5 = dr["ads_bill5"].ToString(),
                    ads_tdate5 = dr["ads_tdate5"].ToString(),
                    ads_desc5 = dr["ads_desc5"].ToString(),
                    ads_amt5 = dr["ads_amt5"].ToString(),
                    ads_total = dr["ads_total"].ToString(),
                    ads_oth_above = dr["ads_oth_above"].ToString(),
                    ads_oth_above_det = dr["ads_oth_above_det"].ToString(),
                    ads_oth_claim = dr["ads_oth_claim"].ToString(),
                    ads_oth_claim_det = dr["ads_oth_claim_det"].ToString(),
                    ads_onset = dr["ads_onset"].ToString(),
                    ads_bank = dr["ads_bank"].ToString(),
                    ads_account = dr["ads_account"].ToString(),
                    ads_bname = dr["ads_bname"].ToString(),
                    ads_baddress = dr["ads_baddress"].ToString(),
                    ads_bcurrency = dr["ads_bcurrency"].ToString(),
                    ads_bswiftcode = dr["ads_bswiftcode"].ToString(),
                    ads_witnessname = dr["ads_witnessname"].ToString(),
                    ads_contact = dr["ads_contact"].ToString(),
                    ads_status = dr["ads_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveAdnicShifa(BusinessEntities.InsuranceForms.AdnicShifa Shifa, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicShifa.SaveAdnicShifa(Shifa, madeby);
        }

        public static int DeleteAdnicShifa(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicShifa.DeleteAdnicShifa(appId, madeby);
        }

        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetAdnicShifaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicShifa.GetAdnicShifaPreviousHistory(appId);
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
