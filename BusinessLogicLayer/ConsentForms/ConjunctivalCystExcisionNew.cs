using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ConjunctivalCystExcisionNew
    {
        public static List<BusinessEntities.ConsentForms.ConjunctivalCystExcisionNew> GetConjunctivalCystExcisionNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConjunctivalCystExcisionNew.GetConjunctivalCystExcisionNewData(appId);
            List<BusinessEntities.ConsentForms.ConjunctivalCystExcisionNew> list = new List<BusinessEntities.ConsentForms.ConjunctivalCystExcisionNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ConjunctivalCystExcisionNew
                {
                    occceId = Convert.ToInt32(dr["occceId"]),
                    occce_appId = Convert.ToInt32(dr["occce_appId"]),
                    occce_1 = dr["occce_1"].ToString(),
                    occce_2 = dr["occce_2"].ToString(),
                    occce_3 = dr["occce_3"].ToString(),
                    occce_4 = dr["occce_4"].ToString(),
                    occce_5 = dr["occce_5"].ToString(),
                    occce_6 = dr["occce_6"].ToString(),
                    occce_status = dr["occce_status"].ToString(),
                    occce_date_modified = Convert.ToDateTime(dr["occce_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveConjunctivalCystExcisionNew(BusinessEntities.ConsentForms.ConjunctivalCystExcisionNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConjunctivalCystExcisionNew.SaveConjunctivalCystExcisionNew(discharge, madeby);
        }


        public static int DeleteConjunctivalCystExcisionNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConjunctivalCystExcisionNew.DeleteConjunctivalCystExcisionNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetConjunctivalCystExcisionNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConjunctivalCystExcisionNew.GetConjunctivalCystExcisionNewPreviousHistory(appId);
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
