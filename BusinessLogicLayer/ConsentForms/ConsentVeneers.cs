using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class ConsentVeneers
    {
        public static List<BusinessEntities.ConcentForms.ConsentVeneers> GetConsentVeneersData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ConsentVeneers.GetConsentVeneersData(appId);

            List<BusinessEntities.ConcentForms.ConsentVeneers> list = new List<BusinessEntities.ConcentForms.ConsentVeneers>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConsentVeneers
                {
                    cicvId = Convert.ToInt32(dr["cicvId"]),
                    cicv_appId = Convert.ToInt32(dr["cicv_appId"]),
                    cicv_1 = dr["cicv_1"].ToString(),
                    cicv_status = dr["cicv_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveConsentVeneers(BusinessEntities.ConcentForms.ConsentVeneers veneers, int madeby)
        {
            return DataAccessLayer.ConcentForms.ConsentVeneers.SaveConsentVeneers(veneers, madeby);
        }

        public static int DeleteConsentVeneers(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.ConsentVeneers.DeleteConsentVeneers(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetConsentVeneersPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ConsentVeneers.GetConsentVeneersPreviousHistory(appId);
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
