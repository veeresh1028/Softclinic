using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeConjunctivalNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeConjunctivalNew> GetDischargeConjunctivalNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeConjunctivalNew.GetDischargeConjunctivalNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeConjunctivalNew> list = new List<BusinessEntities.ConsentForms.DischargeConjunctivalNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeConjunctivalNew
                {
                    dscceId = Convert.ToInt32(dr["dscceId"]),
                    dscce_appId = Convert.ToInt32(dr["dscce_appId"]),
                    dscce_1 = dr["dscce_1"].ToString(),
                    dscce_2 = dr["dscce_2"].ToString(),
                    dscce_3 = dr["dscce_3"].ToString(),
                    dscce_4 = dr["dscce_4"].ToString(),
                    dscce_5 = dr["dscce_5"].ToString(),
                    dscce_6 = dr["dscce_6"].ToString(),
                    dscce_7 = dr["dscce_7"].ToString(),
                    dscce_8 = dr["dscce_8"].ToString(),
                    dscce_9 = dr["dscce_9"].ToString(),
                    dscce_status = dr["dscce_status"].ToString(),
                    dscce_date_modified = Convert.ToDateTime(dr["dscce_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeConjunctivalNew(BusinessEntities.ConsentForms.DischargeConjunctivalNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeConjunctivalNew.SaveDischargeConjunctivalNew(discharge, madeby);
        }


        public static int DeleteDischargeConjunctivalNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeConjunctivalNew.DeleteDischargeConjunctivalNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeConjunctivalNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeConjunctivalNew.GetDischargeConjunctivalNewPreviousHistory(appId);
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
