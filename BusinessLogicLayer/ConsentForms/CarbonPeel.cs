using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class CarbonPeel
    {
        public static List<BusinessEntities.ConsentForms.CarbonPeel> GetCarbonPeelData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CarbonPeel.GetCarbonPeelData(appId);
            List<BusinessEntities.ConsentForms.CarbonPeel> list = new List<BusinessEntities.ConsentForms.CarbonPeel>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.CarbonPeel
                {
                    cpcId = Convert.ToInt32(dr["cpcId"]),
                    cpc_appId = Convert.ToInt32(dr["cpc_appId"]),
                    cpc_status = dr["cpc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveCarbonPeel(BusinessEntities.ConsentForms.CarbonPeel tooth, int madeby)
        {
            return DataAccessLayer.ConsentForms.CarbonPeel.SaveCarbonPeel(tooth, madeby);
        }
        public static int DeleteCarbonPeel(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.CarbonPeel.DeleteCarbonPeel(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetCarbonPeelPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CarbonPeel.GetCarbonPeelPreviousHistory(appId);
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
