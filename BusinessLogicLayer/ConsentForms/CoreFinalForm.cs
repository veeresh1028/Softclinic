using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class CoreFinalForm
    {
        public static List<BusinessEntities.ConsentForms.CoreFinalForm> GetCoreFinalFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CoreFinalForm.GetCoreFinalFormData(appId);
            List<BusinessEntities.ConsentForms.CoreFinalForm> list = new List<BusinessEntities.ConsentForms.CoreFinalForm>();

            foreach (DataRow dr in dt.Rows)
            {
                double total = 0;
                double.TryParse(dr["ccf_total"].ToString(), out total);

                list.Add(new BusinessEntities.ConsentForms.CoreFinalForm
                {
                    ccfId = Convert.ToInt32(dr["ccfId"]),
                    ccf_appId = Convert.ToInt32(dr["ccf_appId"]),
                    ccf_chk1 = dr["ccf_chk1"].ToString(),
                    ccf_chk2 = dr["ccf_chk2"].ToString(),
                    ccf_chk3 = dr["ccf_chk3"].ToString(),
                    ccf_chk4 = dr["ccf_chk4"].ToString(),
                    ccf_chk5 = dr["ccf_chk5"].ToString(),
                    ccf_chk6 = dr["ccf_chk6"].ToString(),
                    ccf_chk7 = dr["ccf_chk7"].ToString(),
                    ccf_chk8 = dr["ccf_chk8"].ToString(),
                    ccf_chk9 = dr["ccf_chk9"].ToString(),
                    ccf_chk10 = dr["ccf_chk10"].ToString(),
                    ccf_total = total,
                    ccf_status = dr["ccf_status"].ToString(),
                    ccf_date_modified = Convert.ToDateTime(dr["ccf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveCoreFinalForm(BusinessEntities.ConsentForms.CoreFinalForm maple, int madeby)
        {
            return DataAccessLayer.ConsentForms.CoreFinalForm.SaveCoreFinalForm(maple, madeby);
        }
        public static int DeleteCoreFinalForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.CoreFinalForm.DeleteCoreFinalForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetCoreFinalFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CoreFinalForm.GetCoreFinalFormPreviousHistory(appId);
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
