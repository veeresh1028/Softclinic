using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PtosisEvaluationNew
    {
        public static List<BusinessEntities.ConsentForms.PtosisEvaluationNew> GetPtosisEvaluationNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PtosisEvaluationNew.GetPtosisEvaluationNewData(appId);
            List<BusinessEntities.ConsentForms.PtosisEvaluationNew> list = new List<BusinessEntities.ConsentForms.PtosisEvaluationNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PtosisEvaluationNew
                {
                    peId = Convert.ToInt32(dr["peId"]),
                    pe_appId = Convert.ToInt32(dr["pe_appId"]),
                    pe_1 = dr["pe_1"].ToString(),
                    pe_2 = dr["pe_2"].ToString(),
                    pe_3 = dr["pe_3"].ToString(),
                    pe_4 = dr["pe_4"].ToString(),
                    pe_5 = dr["pe_5"].ToString(),
                    pe_6 = dr["pe_6"].ToString(),
                    pe_7 = dr["pe_7"].ToString(),
                    pe_8 = dr["pe_8"].ToString(),
                    pe_9 = dr["pe_9"].ToString(),
                    pe_10 = dr["pe_10"].ToString(),
                    pe_11 = dr["pe_11"].ToString(),
                    pe_12 = dr["pe_12"].ToString(),
                    pe_13 = dr["pe_13"].ToString(),
                    pe_14 = dr["pe_14"].ToString(),
                    pe_15 = dr["pe_15"].ToString(),
                    pe_status = dr["pe_status"].ToString(),
                    pe_date_modified = Convert.ToDateTime(dr["pe_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SavePtosisEvaluationNew(BusinessEntities.ConsentForms.PtosisEvaluationNew ptosis, int madeby)
        {
            return DataAccessLayer.ConsentForms.PtosisEvaluationNew.SavePtosisEvaluationNew(ptosis, madeby);
        }


        public static int DeletePtosisEvaluationNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PtosisEvaluationNew.DeletePtosisEvaluationNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetPtosisEvaluationNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PtosisEvaluationNew.GetPtosisEvaluationNewPreviousHistory(appId);
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
