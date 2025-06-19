using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class CrownBridge
    {
        public static List<BusinessEntities.ConsentForms.CrownBridge> GetCrownBridgeData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.CrownBridge.GetCrownBridgeData(appId);
            List<BusinessEntities.ConsentForms.CrownBridge> list = new List<BusinessEntities.ConsentForms.CrownBridge>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.CrownBridge
                {
                    iccId = Convert.ToInt32(dr["iccId"]),
                    icc_appId = Convert.ToInt32(dr["icc_appId"]),
                    icc_1 = dr["icc_1"].ToString(),
                    icc_2 = dr["icc_2"].ToString(),
                    icc_3 = dr["icc_3"].ToString(),
                    icc_4 = dr["icc_4"].ToString(),
                    icc_status = dr["icc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveCrownBridge(BusinessEntities.ConsentForms.CrownBridge crown, int madeby)
        {
            return DataAccessLayer.ConcentForms.CrownBridge.SaveCrownBridge(crown, madeby);
        }
        public static int DeleteCrownBridge(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.CrownBridge.DeleteCrownBridge(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetCrownBridgePreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.CrownBridge.GetCrownBridgePreviousHistory(appId);
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
