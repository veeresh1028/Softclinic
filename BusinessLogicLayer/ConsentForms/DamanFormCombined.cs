using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DamanFormCombined
    {
        public static List<BusinessEntities.ConsentForms.DamanFormCombined> GetDamanFormCombinedData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DamanFormCombined.GetDamanFormCombinedData(appId);
            List<BusinessEntities.ConsentForms.DamanFormCombined> list = new List<BusinessEntities.ConsentForms.DamanFormCombined>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DamanFormCombined
                {
                    dfcId = Convert.ToInt32(dr["dfcId"]),
                    dfc_appId = Convert.ToInt32(dr["dfc_appId"]),
                    dfc_1 = dr["dfc_1"].ToString(),
                    dfc_2 = dr["dfc_2"].ToString(),
                    dfc_3 = dr["dfc_3"].ToString(),
                    dfc_4 = dr["dfc_4"].ToString(),
                    dfc_5 = dr["dfc_5"].ToString(),
                    dfc_6 = dr["dfc_6"].ToString(),
                    dfc_7 = dr["dfc_7"].ToString(),
                    dfc_8 = dr["dfc_8"].ToString(),
                    dfc_9 = dr["dfc_9"].ToString(),
                    dfc_10 = dr["dfc_10"].ToString(),
                    dfc_11 = dr["dfc_11"].ToString(),
                    dfc_12 = dr["dfc_12"].ToString(),
                    dfc_13 = dr["dfc_13"].ToString(),
                    dfc_14 = dr["dfc_14"].ToString(),
                    dfc_15 = dr["dfc_15"].ToString(),
                    dfc_16 = dr["dfc_16"].ToString(),
                    dfc_17 = dr["dfc_17"].ToString(),
                    dfc_18 = dr["dfc_18"].ToString(),
                    dfc_19 = dr["dfc_19"].ToString(),
                    dfc_20 = dr["dfc_20"].ToString(),
                    dfc_21 = dr["dfc_21"].ToString(),
                    dfc_22 = dr["dfc_22"].ToString(),
                    dfc_23 = dr["dfc_23"].ToString(),
                    dfc_24 = dr["dfc_24"].ToString(),
                    dfc_25 = dr["dfc_25"].ToString(),
                    dfc_26 = dr["dfc_26"].ToString(),
                    dfc_27 = dr["dfc_27"].ToString(),
                    dfc_28 = dr["dfc_28"].ToString(),
                    dfc_29 = dr["dfc_29"].ToString(),
                    dfc_30 = dr["dfc_30"].ToString(),
                    dfc_31 = dr["dfc_31"].ToString(),
                    dfc_32 = dr["dfc_32"].ToString(),
                    dfc_33 = dr["dfc_33"].ToString(),
                    dfc_34 = dr["dfc_34"].ToString(),
                    dfc_35 = dr["dfc_35"].ToString(),
                    dfc_36 = dr["dfc_36"].ToString(),
                    dfc_37 = dr["dfc_37"].ToString(),
                    dfc_38 = dr["dfc_38"].ToString(),
                    dfc_39 = dr["dfc_39"].ToString(),
                    dfc_40 = dr["dfc_40"].ToString(),
                    dfc_41 = dr["dfc_41"].ToString(),
                    dfc_42 = dr["dfc_42"].ToString(),
                    dfc_43 = dr["dfc_43"].ToString(),
                    dfc_44 = dr["dfc_44"].ToString(),
                    dfc_45 = dr["dfc_45"].ToString(),
                    dfc_46 = dr["dfc_46"].ToString(),
                    dfc_47 = dr["dfc_47"].ToString(),
                    dfc_48 = dr["dfc_48"].ToString(),
                    dfc_49 = dr["dfc_49"].ToString(),
                    dfc_50 = dr["dfc_50"].ToString(),
                    dfc_type_chart = dr["dfc_type_chart"].ToString(),
                    dfc_radio1 = dr["dfc_radio1"].ToString(),
                    dfc_radio2 = dr["dfc_radio2"].ToString(),
                    dfc_date1 = dr["dfc_date1"].ToString(),
                    dfc_date2 = dr["dfc_date2"].ToString(),
                    dfc_time1 = dr["dfc_time1"].ToString(),
                    dfc_time2 = dr["dfc_time2"].ToString(),
                    dfc_status = dr["dfc_status"].ToString(),
                    dfc_date_modified = Convert.ToDateTime(dr["dfc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDamanFormCombined(BusinessEntities.ConsentForms.DamanFormCombined daman, int madeby)
        {
            return DataAccessLayer.ConsentForms.DamanFormCombined.SaveDamanFormCombined(daman, madeby);
        }
        public static int DeleteDamanFormCombined(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DamanFormCombined.DeleteDamanFormCombined(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetDamanFormCombinedPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DamanFormCombined.GetDamanFormCombinedPreviousHistory(appId);
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
