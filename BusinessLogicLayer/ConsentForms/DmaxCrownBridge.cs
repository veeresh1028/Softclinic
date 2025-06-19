using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxCrownBridge
    {
        public static List<BusinessEntities.ConsentForms.DmaxCrownBridge> GetDmaxCrownBridgeData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxCrownBridge.GetDmaxCrownBridgeData(appId);
            List<BusinessEntities.ConsentForms.DmaxCrownBridge> list = new List<BusinessEntities.ConsentForms.DmaxCrownBridge>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxCrownBridge
                {
                    cdcbId = Convert.ToInt32(dr["cdcbId"]),
                    cdcb_appId = Convert.ToInt32(dr["cdcb_appId"]),
                    cdcb_1 = dr["cdcb_1"].ToString(),
                    cdcb_2 = dr["cdcb_2"].ToString(),
                    cdcb_3 = dr["cdcb_3"].ToString(),
                    cdcb_4 = dr["cdcb_4"].ToString(),
                    cdcb_status = dr["cdcb_status"].ToString(),
                    cdcb_date_modified = Convert.ToDateTime(dr["cdcb_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxCrownBridge(BusinessEntities.ConsentForms.DmaxCrownBridge derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxCrownBridge.SaveDmaxCrownBridge(derma, madeby);
        }
        public static int DeleteDmaxCrownBridge(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxCrownBridge.DeleteDmaxCrownBridge(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxCrownBridgePreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxCrownBridge.GetDmaxCrownBridgePreviousHistory(appId);
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
