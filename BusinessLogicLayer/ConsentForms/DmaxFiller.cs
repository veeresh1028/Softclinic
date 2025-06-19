using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxFiller
    {
        public static List<BusinessEntities.ConsentForms.DmaxFiller> GetDmaxFillerData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxFiller.GetDmaxFillerData(appId);
            List<BusinessEntities.ConsentForms.DmaxFiller> list = new List<BusinessEntities.ConsentForms.DmaxFiller>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxFiller
                {
                    cdfId = Convert.ToInt32(dr["cdfId"]),
                    cdf_appId = Convert.ToInt32(dr["cdf_appId"]),
                    cdf_1 = dr["cdf_1"].ToString(),
                    cdf_status = dr["cdf_status"].ToString(),
                    cdf_date_modified = Convert.ToDateTime(dr["cdf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxFiller(BusinessEntities.ConsentForms.DmaxFiller derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxFiller.SaveDmaxFiller(derma, madeby);
        }
        public static int DeleteDmaxFiller(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxFiller.DeleteDmaxFiller(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxFillerPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxFiller.GetDmaxFillerPreviousHistory(appId);
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
