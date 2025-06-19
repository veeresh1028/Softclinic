using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OrthoEvaluationNew
    {
        public static List<BusinessEntities.ConsentForms.OrthoEvaluationNew> GetOrthoEvaluationNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OrthoEvaluationNew.GetOrthoEvaluationNewData(appId);
            List<BusinessEntities.ConsentForms.OrthoEvaluationNew> list = new List<BusinessEntities.ConsentForms.OrthoEvaluationNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OrthoEvaluationNew
                {
                    moeId = Convert.ToInt32(dr["moeId"]),
                    moe_appId = Convert.ToInt32(dr["moe_appId"]),
                    moe_1 = dr["moe_1"].ToString(),
                    moe_2 = dr["moe_2"].ToString(),
                    moe_3 = dr["moe_3"].ToString(),
                    moe_4 = dr["moe_4"].ToString(),
                    moe_5 = dr["moe_5"].ToString(),
                    moe_6 = dr["moe_6"].ToString(),
                    moe_7 = dr["moe_7"].ToString(),
                    moe_8 = dr["moe_8"].ToString(),
                    moe_9 = dr["moe_9"].ToString(),
                    moe_10 = dr["moe_10"].ToString(),
                    moe_11 = dr["moe_11"].ToString(),
                    moe_12 = dr["moe_12"].ToString(),
                    moe_status = dr["moe_status"].ToString(),
                    moe_date_modified = Convert.ToDateTime(dr["moe_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveOrthoEvaluationNew(BusinessEntities.ConsentForms.OrthoEvaluationNew ortho, int madeby)
        {
            return DataAccessLayer.ConsentForms.OrthoEvaluationNew.SaveOrthoEvaluationNew(ortho, madeby);
        }



        public static int DeleteOrthoEvaluationNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OrthoEvaluationNew.DeleteOrthoEvaluationNew(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetOrthoEvaluationNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OrthoEvaluationNew.GetOrthoEvaluationNewPreviousHistory(appId);
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
