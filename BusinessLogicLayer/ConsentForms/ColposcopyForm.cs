using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ColposcopyForm
    {
        public static List<BusinessEntities.ConsentForms.ColposcopyForm> GetColposcopyFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ColposcopyForm.GetColposcopyFormData(appId);
            List<BusinessEntities.ConsentForms.ColposcopyForm> list = new List<BusinessEntities.ConsentForms.ColposcopyForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ColposcopyForm
                {
                    ccfId = Convert.ToInt32(dr["ccfId"]),
                    ccf_appId = Convert.ToInt32(dr["ccf_appId"]),
                    ccf_1 = dr["ccf_1"].ToString(),
                    ccf_2 = dr["ccf_2"].ToString(),
                    ccf_3 = dr["ccf_3"].ToString(),
                    ccf_4 = dr["ccf_4"].ToString(),
                    ccf_5 = dr["ccf_5"].ToString(),
                    ccf_6 = dr["ccf_6"].ToString(),
                    ccf_7 = dr["ccf_7"].ToString(),
                    ccf_8 = dr["ccf_8"].ToString(),
                    ccf_9 = dr["ccf_9"].ToString(),
                    ccf_10 = dr["ccf_10"].ToString(),
                    ccf_11 = dr["ccf_11"].ToString(),
                    ccf_12 = dr["ccf_12"].ToString(),
                    ccf_13 = dr["ccf_13"].ToString(),
                    ccf_14 = dr["ccf_14"].ToString(),
                    ccf_15 = dr["ccf_15"].ToString(),
                    ccf_16 = dr["ccf_16"].ToString(),
                    ccf_17 = dr["ccf_17"].ToString(),
                    ccf_18 = dr["ccf_18"].ToString(),
                    ccf_19 = dr["ccf_19"].ToString(),
                    ccf_20 = dr["ccf_20"].ToString(),
                    ccf_21 = dr["ccf_21"].ToString(),
                    ccf_22 = dr["ccf_22"].ToString(),
                    ccf_chk1 = dr["ccf_chk1"].ToString(),
                    ccf_radio1 = dr["ccf_radio1"].ToString(),
                    ccf_radio2 = dr["ccf_radio2"].ToString(),
                    ccf_radio3 = dr["ccf_radio3"].ToString(),
                    ccf_radio4 = dr["ccf_radio4"].ToString(),
                    ccf_date1 = dr["ccf_date1"].ToString(),
                    ccf_date2 = dr["ccf_date2"].ToString(),
                    ccf_doc = dr["ccf_doc"].ToString(),
                    ccf_status = dr["ccf_status"].ToString(),
                    ccf_date_modified = Convert.ToDateTime(dr["ccf_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveColposcopyForm(BusinessEntities.ConsentForms.ColposcopyForm colposcopy, int madeby)
        {
            return DataAccessLayer.ConsentForms.ColposcopyForm.SaveColposcopyForm(colposcopy, madeby);
        }
        public static int DeleteColposcopyForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ColposcopyForm.DeleteColposcopyForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetColposcopyFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ColposcopyForm.GetColposcopyFormPreviousHistory(appId);
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
