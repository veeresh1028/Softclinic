using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxCarbon
    {
        public static List<BusinessEntities.ConsentForms.DmaxCarbon> GetDmaxCarbonData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxCarbon.GetDmaxCarbonData(appId);
            List<BusinessEntities.ConsentForms.DmaxCarbon> list = new List<BusinessEntities.ConsentForms.DmaxCarbon>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxCarbon
                {
                    cdcId = Convert.ToInt32(dr["cdcId"]),
                    cdc_appId = Convert.ToInt32(dr["cdc_appId"]),
                    cdc_1 = dr["cdc_1"].ToString(),
                    cdc_status = dr["cdc_status"].ToString(),
                    cdc_date_modified = Convert.ToDateTime(dr["cdc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxCarbon(BusinessEntities.ConsentForms.DmaxCarbon derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxCarbon.SaveDmaxCarbon(derma, madeby);
        }
        public static int DeleteDmaxCarbon(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxCarbon.DeleteDmaxCarbon(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxCarbonPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxCarbon.GetDmaxCarbonPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistory
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
