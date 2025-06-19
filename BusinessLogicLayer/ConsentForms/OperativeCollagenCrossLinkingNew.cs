using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OperativeCollagenCrossLinkingNew
    {
        public static List<BusinessEntities.ConsentForms.OperativeCollagenCrossLinkingNew> GetOperativeCollagenCrossLinkingNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeCollagenCrossLinkingNew.GetOperativeCollagenCrossLinkingNewData(appId);
            List<BusinessEntities.ConsentForms.OperativeCollagenCrossLinkingNew> list = new List<BusinessEntities.ConsentForms.OperativeCollagenCrossLinkingNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OperativeCollagenCrossLinkingNew
                {
                    occlId = Convert.ToInt32(dr["occlId"]),
                    occl_appId = Convert.ToInt32(dr["occl_appId"]),
                    occl_1 = dr["occl_1"].ToString(),
                    occl_2 = dr["occl_2"].ToString(),
                    occl_3 = dr["occl_3"].ToString(),
                    occl_4 = dr["occl_4"].ToString(),
                    occl_status = dr["occl_status"].ToString(),
                    occl_date_modified = Convert.ToDateTime(dr["occl_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveOperativeCollagenCrossLinkingNew(BusinessEntities.ConsentForms.OperativeCollagenCrossLinkingNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeCollagenCrossLinkingNew.SaveOperativeCollagenCrossLinkingNew(discharge, madeby);
        }


        public static int DeleteOperativeCollagenCrossLinkingNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeCollagenCrossLinkingNew.DeleteOperativeCollagenCrossLinkingNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOperativeCollagenCrossLinkingNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeCollagenCrossLinkingNew.GetOperativeCollagenCrossLinkingNewPreviousHistory(appId);
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
