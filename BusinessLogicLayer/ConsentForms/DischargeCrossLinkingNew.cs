using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeCrossLinkingNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeCrossLinkingNew> GetDischargeCrossLinkingNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeCrossLinkingNew.GetDischargeCrossLinkingNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeCrossLinkingNew> list = new List<BusinessEntities.ConsentForms.DischargeCrossLinkingNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeCrossLinkingNew
                {
                    dclId = Convert.ToInt32(dr["dclId"]),
                    dcl_appId = Convert.ToInt32(dr["dcl_appId"]),
                    dcl_1 = dr["dcl_1"].ToString(),
                    dcl_2 = dr["dcl_2"].ToString(),
                    dcl_3 = dr["dcl_3"].ToString(),
                    dcl_4 = dr["dcl_4"].ToString(),
                    dcl_5 = dr["dcl_5"].ToString(),
                    dcl_6 = dr["dcl_6"].ToString(),
                    dcl_status = dr["dcl_status"].ToString(),
                    dcl_date_modified = Convert.ToDateTime(dr["dcl_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeCrossLinkingNew(BusinessEntities.ConsentForms.DischargeCrossLinkingNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeCrossLinkingNew.SaveDischargeCrossLinkingNew(discharge, madeby);
        }


        public static int DeleteDischargeCrossLinkingNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeCrossLinkingNew.DeleteDischargeCrossLinkingNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeCrossLinkingNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeCrossLinkingNew.GetDischargeCrossLinkingNewPreviousHistory(appId);
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
