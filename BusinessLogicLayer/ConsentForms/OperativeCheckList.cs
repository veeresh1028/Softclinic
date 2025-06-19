using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OperativeCheckList
    {
        public static List<BusinessEntities.ConsentForms.OperativeCheckList> GetOperativeCheckListData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeCheckList.GetOperativeCheckListData(appId);
            List<BusinessEntities.ConsentForms.OperativeCheckList> list = new List<BusinessEntities.ConsentForms.OperativeCheckList>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OperativeCheckList
                {
                    ocnId = Convert.ToInt32(dr["ocnId"]),
                    ocn_appId = Convert.ToInt32(dr["ocn_appId"]),
                    ocn_1 = dr["ocn_1"].ToString(),
                    ocn_2 = dr["ocn_2"].ToString(),
                    ocn_3 = dr["ocn_3"].ToString(),
                    ocn_4 = dr["ocn_4"].ToString(),
                    ocn_5 = dr["ocn_5"].ToString(),
                    ocn_6 = dr["ocn_6"].ToString(),
                    ocn_7 = dr["ocn_7"].ToString(),
                    ocn_8 = dr["ocn_8"].ToString(),
                    ocn_9 = dr["ocn_9"].ToString(),
                    ocn_10 = dr["ocn_10"].ToString(),
                    ocn_11 = dr["ocn_11"].ToString(),
                    ocn_12 = dr["ocn_12"].ToString(),
                    ocn_13 = dr["ocn_13"].ToString(),
                    ocn_14 = dr["ocn_14"].ToString(),
                    ocn_15 = dr["ocn_15"].ToString(),
                    ocn_16 = dr["ocn_16"].ToString(),
                    ocn_17 = dr["ocn_17"].ToString(),
                    ocn_18 = dr["ocn_18"].ToString(),
                    ocn_19 = dr["ocn_19"].ToString(),
                    ocn_20 = dr["ocn_20"].ToString(),
                    ocn_21 = dr["ocn_21"].ToString(),
                    ocn_22 = dr["ocn_22"].ToString(),
                    ocn_23 = dr["ocn_23"].ToString(),
                    ocn_24 = dr["ocn_24"].ToString(),
                    ocn_25 = dr["ocn_25"].ToString(),
                    ocn_26 = dr["ocn_26"].ToString(),
                    ocn_27 = dr["ocn_27"].ToString(),
                    ocn_28 = dr["ocn_28"].ToString(),
                    ocn_29 = dr["ocn_29"].ToString(),
                    ocn_status = dr["ocn_status"].ToString(),
                    ocn_date_modified = Convert.ToDateTime(dr["ocn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveOperativeCheckList(BusinessEntities.ConsentForms.OperativeCheckList ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeCheckList.SaveOperativeCheckList(ophtha, madeby);
        }
        public static int DeleteOperativeCheckList(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeCheckList.DeleteOperativeCheckList(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOperativeCheckListPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeCheckList.GetOperativeCheckListPreviousHistory(appId);
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
