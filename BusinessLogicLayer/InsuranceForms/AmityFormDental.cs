using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class AmityFormDental
    {
        public static List<BusinessEntities.InsuranceForms.AmityFormDental> GetAmityFormDentalData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AmityFormDental.GetAmityFormDentalData(appId);
            List<BusinessEntities.InsuranceForms.AmityFormDental> list = new List<BusinessEntities.InsuranceForms.AmityFormDental>();

            foreach (DataRow dr in dt.Rows)
            {


                list.Add(new BusinessEntities.InsuranceForms.AmityFormDental
                {
                    mpdId = Convert.ToInt32(dr["mpdId"]),
                    mpd_appId = Convert.ToInt32(dr["mpd_appId"]),

                    mpd_medications = dr["mpd_medications"].ToString(),
                    mpd_pathalogy = dr["mpd_pathalogy"].ToString(),
                    mpd_radiology = dr["mpd_radiology"].ToString(),
                    mpd_radio1 = dr["mpd_radio1"].ToString(),
                    mpd_radio2 = dr["mpd_radio2"].ToString(),
                    mpd_pre = dr["mpd_pre"].ToString(),

                    mpd_status = dr["mpd_status"].ToString(),
                    mpd_date_modified = Convert.ToDateTime(dr["mpd_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveAmityFormDental(BusinessEntities.InsuranceForms.AmityFormDental dental, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AmityFormDental.SaveAmityFormDental(dental, madeby);
        }
        public static int DeleteAmityFormDental(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.AmityFormDental.DeleteAmityFormDental(appId, madeby);
        }
        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetAmityFormDentalPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.AmityFormDental.GetAmityFormDentalPreviousHistory(appId);
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
