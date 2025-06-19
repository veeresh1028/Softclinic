using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PregnancyForm
    {
        public static List<BusinessEntities.ConsentForms.PregnancyForm> GetPregnancyFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PregnancyForm.GetPregnancyFormData(appId);
            List<BusinessEntities.ConsentForms.PregnancyForm> list = new List<BusinessEntities.ConsentForms.PregnancyForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PregnancyForm
                {
                    ptfId = Convert.ToInt32(dr["ptfId"]),
                    ptf_appId = Convert.ToInt32(dr["ptf_appId"]),
                    ptf_1 = dr["ptf_1"].ToString(),
                    ptf_2 = dr["ptf_2"].ToString(),
                    ptf_3 = dr["ptf_3"].ToString(),
                    ptf_4 = dr["ptf_4"].ToString(),
                    ptf_5 = dr["ptf_5"].ToString(),
                    ptf_6 = dr["ptf_6"].ToString(),
                    ptf_7 = dr["ptf_7"].ToString(),
                    ptf_8 = dr["ptf_8"].ToString(),
                    ptf_9 = dr["ptf_9"].ToString(),
                    ptf_10 = dr["ptf_10"].ToString(),
                    ptf_11 = dr["ptf_11"].ToString(),
                    ptf_12 = dr["ptf_12"].ToString(),
                    ptf_13 = dr["ptf_13"].ToString(),
                    ptf_14 = dr["ptf_14"].ToString(),
                    ptf_15 = dr["ptf_15"].ToString(),
                    ptf_16 = dr["ptf_16"].ToString(),
                    ptf_17 = dr["ptf_17"].ToString(),
                    ptf_18 = dr["ptf_18"].ToString(),
                    ptf_19 = dr["ptf_19"].ToString(),
                    ptf_20 = dr["ptf_20"].ToString(),
                    ptf_21 = dr["ptf_21"].ToString(),
                    ptf_22 = dr["ptf_22"].ToString(),
                    ptf_23 = dr["ptf_23"].ToString(),
                    ptf_24 = dr["ptf_24"].ToString(),
                    ptf_25 = dr["ptf_25"].ToString(),
                    ptf_26 = dr["ptf_26"].ToString(),
                    ptf_27 = dr["ptf_27"].ToString(),
                    ptf_28 = dr["ptf_28"].ToString(),
                    ptf_29 = dr["ptf_29"].ToString(),
                    ptf_30 = dr["ptf_30"].ToString(),
                    ptf_31 = dr["ptf_31"].ToString(),
                    ptf_32 = dr["ptf_32"].ToString(),
                    ptf_33 = dr["ptf_33"].ToString(),
                    ptf_34 = dr["ptf_34"].ToString(),
                    ptf_35 = dr["ptf_35"].ToString(),
                    ptf_36 = dr["ptf_36"].ToString(),
                    ptf_37 = dr["ptf_37"].ToString(),
                    ptf_38 = dr["ptf_38"].ToString(),
                    ptf_39 = dr["ptf_39"].ToString(),
                    ptf_40 = dr["ptf_40"].ToString(),
                    ptf_41 = dr["ptf_41"].ToString(),
                    ptf_42 = dr["ptf_42"].ToString(),
                    ptf_43 = dr["ptf_43"].ToString(),
                    ptf_44 = dr["ptf_44"].ToString(),
                    ptf_45 = dr["ptf_45"].ToString(),
                    ptf_46 = dr["ptf_46"].ToString(),
                    ptf_47 = dr["ptf_47"].ToString(),
                    ptf_48 = dr["ptf_48"].ToString(),
                    ptf_49 = dr["ptf_49"].ToString(),
                    ptf_50 = dr["ptf_50"].ToString(),
                    ptf_51 = dr["ptf_51"].ToString(),
                    ptf_52 = dr["ptf_52"].ToString(),

                    ptf_radio1 = dr["ptf_radio1"].ToString(),
                    ptf_radio2 = dr["ptf_radio2"].ToString(),
                    ptf_radio3 = dr["ptf_radio3"].ToString(),
                    ptf_radio4 = dr["ptf_radio4"].ToString(),
                    ptf_radio5 = dr["ptf_radio5"].ToString(),
                    ptf_radio6 = dr["ptf_radio6"].ToString(),

                    ptf_date1 = dr["ptf_date1"].ToString(),
                    ptf_date2 = dr["ptf_date2"].ToString(),

                    ptf_status = dr["ptf_status"].ToString(),
                    ptf_date_modified = Convert.ToDateTime(dr["ptf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SavePregnancyForm(BusinessEntities.ConsentForms.PregnancyForm gyna, int madeby)
        {
            return DataAccessLayer.ConsentForms.PregnancyForm.SavePregnancyForm(gyna, madeby);
        }
        public static int DeletePregnancyForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PregnancyForm.DeletePregnancyForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetPregnancyFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PregnancyForm.GetPregnancyFormPreviousHistory(appId);
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
