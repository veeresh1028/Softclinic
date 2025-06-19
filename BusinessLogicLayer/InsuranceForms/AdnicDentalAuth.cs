using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class AdnicDentalAuth
    {
        public static List<BusinessEntities.InsuranceForms.AdnicDentalAuth> GetAdnicDentalAuthData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicDentalAuth.GetAdnicDentalAuthData(appId);
            List<BusinessEntities.InsuranceForms.AdnicDentalAuth> list = new List<BusinessEntities.InsuranceForms.AdnicDentalAuth>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.AdnicDentalAuth
                {
                    adaId = Convert.ToInt32(dr["adaId"]),
                    ada_appId = Convert.ToInt32(dr["ada_appId"]),
                    ada_diags1 = dr["ada_diags1"].ToString(),
                    ada_ser1 = dr["ada_ser1"].ToString(),
                    ada_tooth1 = dr["ada_tooth1"].ToString(),
                    ada_code1 = dr["ada_code1"].ToString(),
                    ada_cost1 = dr["ada_cost1"].ToString(),
                    ada_diags2 = dr["ada_diags2"].ToString(),
                    ada_ser2 = dr["ada_ser2"].ToString(),
                    ada_tooth2 = dr["ada_tooth2"].ToString(),
                    ada_code2 = dr["ada_code2"].ToString(),
                    ada_cost2 = dr["ada_cost2"].ToString(),
                    ada_diags3 = dr["ada_diags3"].ToString(),
                    ada_ser3 = dr["ada_ser3"].ToString(),
                    ada_tooth3 = dr["ada_tooth3"].ToString(),
                    ada_code3 = dr["ada_code3"].ToString(),
                    ada_cost3 = dr["ada_cost3"].ToString(),
                    ada_diags4 = dr["ada_diags4"].ToString(),
                    ada_ser4 = dr["ada_ser4"].ToString(),
                    ada_code4 = dr["ada_code4"].ToString(),
                    ada_cost4 = dr["ada_cost4"].ToString(),
                    ada_diags5 = dr["ada_diags5"].ToString(),
                    ada_ser5 = dr["ada_ser5"].ToString(),
                    ada_tooth5 = dr["ada_tooth5"].ToString(),
                    ada_code5 = dr["ada_code5"].ToString(),
                    ada_cost5 = dr["ada_cost5"].ToString(),
                    ada_diags6 = dr["ada_diags6"].ToString(),
                    ada_ser6 = dr["ada_ser6"].ToString(),
                    ada_tooth6 = dr["ada_tooth6"].ToString(),
                    ada_code6 = dr["ada_code6"].ToString(),
                    ada_cost6 = dr["ada_cost6"].ToString(),
                    ada_treat_tot = dr["ada_treat_tot"].ToString(),
                    ada_doc_no = dr["ada_doc_no"].ToString(),
                    ada_status = dr["ada_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveAdnicDentalAuth(BusinessEntities.InsuranceForms.AdnicDentalAuth Dental, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicDentalAuth.SaveAdnicDentalAuth(Dental, madeby);
        }

        public static int DeleteAdnicDentalAuth(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AdnicDentalAuth.DeleteAdnicDentalAuth(appId, madeby);
        }

        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetAdnicDentalAuthPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AdnicDentalAuth.GetAdnicDentalAuthPreviousHistory(appId);
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
