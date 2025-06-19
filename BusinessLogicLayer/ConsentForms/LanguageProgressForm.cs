using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LanguageProgressForm
    {
        public static List<BusinessEntities.ConsentForms.LanguageProgressForm> GetLanguageProgressFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LanguageProgressForm.GetLanguageProgressFormData(appId);
            List<BusinessEntities.ConsentForms.LanguageProgressForm> list = new List<BusinessEntities.ConsentForms.LanguageProgressForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LanguageProgressForm
                {
                    lpfId = Convert.ToInt32(dr["lpfId"]),
                    lpf_appId = Convert.ToInt32(dr["lpf_appId"]),
                    lpf_1 = dr["lpf_1"].ToString(),
                    lpf_2 = dr["lpf_2"].ToString(),
                    lpf_date1 = dr["lpf_date1"].ToString(),
                    lpf_3 = dr["lpf_3"].ToString(),
                    lpf_4 = dr["lpf_4"].ToString(),
                    lpf_5 = dr["lpf_5"].ToString(),
                    lpf_chk1 = dr["lpf_chk1"].ToString(),
                    lpf_6 = dr["lpf_6"].ToString(),
                    lpf_7 = dr["lpf_7"].ToString(),
                    lpf_8 = dr["lpf_8"].ToString(),
                    lpf_9 = dr["lpf_9"].ToString(),
                    lpf_10 = dr["lpf_10"].ToString(),
                    lpf_11 = dr["lpf_11"].ToString(),
                    lpf_12 = dr["lpf_12"].ToString(),
                    lpf_13 = dr["lpf_13"].ToString(),
                    lpf_radio1 = dr["lpf_radio1"].ToString(),
                    lpf_radio2 = dr["lpf_radio2"].ToString(),
                    lpf_radio3 = dr["lpf_radio3"].ToString(),
                    lpf_radio4 = dr["lpf_radio4"].ToString(),
                    lpf_14 = dr["lpf_14"].ToString(),
                    lpf_15 = dr["lpf_15"].ToString(),
                    lpf_16 = dr["lpf_16"].ToString(),
                    lpf_17 = dr["lpf_17"].ToString(),
                    lpf_18 = dr["lpf_18"].ToString(),
                    lpf_19 = dr["lpf_19"].ToString(),
                    lpf_20 = dr["lpf_20"].ToString(),
                    lpf_21 = dr["lpf_21"].ToString(),
                    lpf_22 = dr["lpf_22"].ToString(),
                    lpf_23 = dr["lpf_23"].ToString(),
                    lpf_24 = dr["lpf_24"].ToString(),
                    lpf_25 = dr["lpf_25"].ToString(),
                    lpf_26 = dr["lpf_26"].ToString(),
                    lpf_27 = dr["lpf_27"].ToString(),
                    lpf_28 = dr["lpf_28"].ToString(),
                    lpf_29 = dr["lpf_29"].ToString(),
                    lpf_30 = dr["lpf_30"].ToString(),
                    lpf_31 = dr["lpf_31"].ToString(),
                    lpf_32 = dr["lpf_32"].ToString(),
                    lpf_status = dr["lpf_status"].ToString(),
                    lpf_date_modified = Convert.ToDateTime(dr["lpf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveLanguageProgressForm(BusinessEntities.ConsentForms.LanguageProgressForm language, int madeby)
        {
            return DataAccessLayer.ConsentForms.LanguageProgressForm.SaveLanguageProgressForm(language, madeby);
        }
        public static int DeleteLanguageProgressForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LanguageProgressForm.DeleteLanguageProgressForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetLanguageProgressFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LanguageProgressForm.GetLanguageProgressFormPreviousHistory(appId);
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
