using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class InfertilityForm
    {
        public static List<BusinessEntities.ConsentForms.InfertilityForm> GetInfertilityFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InfertilityForm.GetInfertilityFormData(appId);
            List<BusinessEntities.ConsentForms.InfertilityForm> list = new List<BusinessEntities.ConsentForms.InfertilityForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.InfertilityForm
                {
                    ifnId = Convert.ToInt32(dr["ifnId"]),
                    ifn_appId = Convert.ToInt32(dr["ifn_appId"]),
                    ifn_1 = dr["ifn_1"].ToString(),
                    ifn_2 = dr["ifn_2"].ToString(),
                    ifn_3 = dr["ifn_3"].ToString(),
                    ifn_4 = dr["ifn_4"].ToString(),
                    ifn_5 = dr["ifn_5"].ToString(),
                    ifn_6 = dr["ifn_6"].ToString(),
                    ifn_7 = dr["ifn_7"].ToString(),
                    ifn_8 = dr["ifn_8"].ToString(),
                    ifn_9 = dr["ifn_9"].ToString(),
                    ifn_10 = dr["ifn_10"].ToString(),
                    ifn_11 = dr["ifn_11"].ToString(),
                    ifn_12 = dr["ifn_12"].ToString(),
                    ifn_13 = dr["ifn_13"].ToString(),
                    ifn_14 = dr["ifn_14"].ToString(),
                    ifn_15 = dr["ifn_15"].ToString(),
                    ifn_16 = dr["ifn_16"].ToString(),
                    ifn_17 = dr["ifn_17"].ToString(),
                    ifn_18 = dr["ifn_18"].ToString(),
                    ifn_19 = dr["ifn_19"].ToString(),
                    ifn_20 = dr["ifn_20"].ToString(),
                    ifn_21 = dr["ifn_21"].ToString(),
                    ifn_22 = dr["ifn_22"].ToString(),
                    ifn_23 = dr["ifn_23"].ToString(),
                    ifn_24 = dr["ifn_24"].ToString(),
                    ifn_25 = dr["ifn_25"].ToString(),
                    ifn_26 = dr["ifn_26"].ToString(),
                    ifn_27 = dr["ifn_27"].ToString(),
                    ifn_28 = dr["ifn_28"].ToString(),
                    ifn_29 = dr["ifn_29"].ToString(),
                    ifn_30 = dr["ifn_30"].ToString(),
                    ifn_31 = dr["ifn_31"].ToString(),
                    ifn_32 = dr["ifn_32"].ToString(),
                    ifn_33 = dr["ifn_33"].ToString(),
                    ifn_34 = dr["ifn_34"].ToString(),
                    ifn_35 = dr["ifn_35"].ToString(),
                    ifn_36 = dr["ifn_36"].ToString(),
                    ifn_37 = dr["ifn_37"].ToString(),
                    ifn_38 = dr["ifn_38"].ToString(),
                    ifn_39 = dr["ifn_39"].ToString(),
                    ifn_40 = dr["ifn_40"].ToString(),
                    ifn_41 = dr["ifn_41"].ToString(),
                    ifn_42 = dr["ifn_42"].ToString(),
                    ifn_43 = dr["ifn_43"].ToString(),
                    ifn_44 = dr["ifn_44"].ToString(),
                    ifn_45 = dr["ifn_45"].ToString(),
                    ifn_46 = dr["ifn_46"].ToString(),
                    ifn_47 = dr["ifn_47"].ToString(),
                    ifn_48 = dr["ifn_48"].ToString(),
                    ifn_49 = dr["ifn_49"].ToString(),
                    ifn_50 = dr["ifn_50"].ToString(),
                    ifn_51 = dr["ifn_51"].ToString(),

                    ifn_status = dr["ifn_status"].ToString(),
                    ifn_date_modified = Convert.ToDateTime(dr["ifn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveInfertilityForm(BusinessEntities.ConsentForms.InfertilityForm gyna, int madeby)
        {
            return DataAccessLayer.ConsentForms.InfertilityForm.SaveInfertilityForm(gyna, madeby);
        }
        public static int DeleteInfertilityForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.InfertilityForm.DeleteInfertilityForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetInfertilityFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InfertilityForm.GetInfertilityFormPreviousHistory(appId);
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
