using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class BodyWrap
    {
        public static List<BusinessEntities.ConsentForms.BodyWrap> GetBodyWrapData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BodyWrap.GetBodyWrapData(appId);
            List<BusinessEntities.ConsentForms.BodyWrap> list = new List<BusinessEntities.ConsentForms.BodyWrap>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.BodyWrap
                {
                    bwcId = Convert.ToInt32(dr["bwcId"]),
                    bwc_appId = Convert.ToInt32(dr["bwc_appId"]),
                    bwc_1 = dr["bwc_1"].ToString(),
                    bwc_status = dr["bwc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveBodyWrap(BusinessEntities.ConsentForms.BodyWrap crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.BodyWrap.SaveBodyWrap(crown, madeby);
        }
        public static int DeleteBodyWrap(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.BodyWrap.DeleteBodyWrap(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetBodyWrapPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BodyWrap.GetBodyWrapPreviousHistory(appId);
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
