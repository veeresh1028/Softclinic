using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class DubaiCareClaimDental
    {
        public static List<BusinessEntities.InsuranceForms.DubaiCareClaimDental> GetDubaiCareClaimDentalData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.DubaiCareClaimDental.GetDubaiCareClaimDentalData(appId);
            List<BusinessEntities.InsuranceForms.DubaiCareClaimDental> list = new List<BusinessEntities.InsuranceForms.DubaiCareClaimDental>();

            foreach (DataRow dr in dt.Rows)
            {

                list.Add(new BusinessEntities.InsuranceForms.DubaiCareClaimDental
                {
                    dcdId = Convert.ToInt32(dr["dcdId"]),
                    dcd_appId = Convert.ToInt32(dr["dcd_appId"]),

                    dcd_1 = dr["dcd_1"].ToString(),
                    dcd_2 = dr["dcd_2"].ToString(),
                    dcd_3 = dr["dcd_3"].ToString(),
                    dcd_4 = dr["dcd_4"].ToString(),
                    dcd_5 = dr["dcd_5"].ToString(),
                    dcd_6 = decimal.Parse(dr["dcd_6"].ToString()),

                    dcd_status = dr["dcd_status"].ToString(),
                    dcd_date_modified = Convert.ToDateTime(dr["dcd_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDubaiCareClaimDental(BusinessEntities.InsuranceForms.DubaiCareClaimDental medical, int madeby)
        {
            return DataAccessLayer.InsuranceForms.DubaiCareClaimDental.SaveDubaiCareClaimDental(medical, madeby);
        }
        public static int DeleteDubaiCareClaimDental(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.DubaiCareClaimDental.DeleteDubaiCareClaimDental(appId, madeby);
        }
        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetDubaiCareClaimDentalPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.DubaiCareClaimDental.GetDubaiCareClaimDentalPreviousHistory(appId);
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
