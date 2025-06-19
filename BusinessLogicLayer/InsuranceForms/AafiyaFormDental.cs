using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class AafiyaFormDental
    {
        public static List<BusinessEntities.InsuranceForms.AafiyaFormDental> GetAafiyaFormDentalData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AafiyaFormDental.GetAafiyaFormDentalData(appId);
            List<BusinessEntities.InsuranceForms.AafiyaFormDental> list = new List<BusinessEntities.InsuranceForms.AafiyaFormDental>();

            foreach (DataRow dr in dt.Rows)
            {

                decimal cost = 0;
                decimal.TryParse(dr["mcd_cost"].ToString(), out cost);

                list.Add(new BusinessEntities.InsuranceForms.AafiyaFormDental
                {
                    mcdId = Convert.ToInt32(dr["mcdId"]),
                    mcd_appId = Convert.ToInt32(dr["mcd_appId"]),

                    mcd_referral = dr["mcd_referral"].ToString(),
                    mcd_radio = dr["mcd_radio"].ToString(),
                    mcd_investigation = dr["mcd_investigation"].ToString(),
                    mcd_prescription = dr["mcd_prescription"].ToString(),
                    mcd_cost = cost,

                    mcd_status = dr["mcd_status"].ToString(),
                    mcd_date_modified = Convert.ToDateTime(dr["mcd_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveAafiyaFormDental(BusinessEntities.InsuranceForms.AafiyaFormDental dental, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AafiyaFormDental.SaveAafiyaFormDental(dental, madeby);
        }
        public static int DeleteAafiyaFormDental(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AafiyaFormDental.DeleteAafiyaFormDental(appId, madeby);
        }
        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetAafiyaFormDentalPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AafiyaFormDental.GetAafiyaFormDentalPreviousHistory(appId);
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
