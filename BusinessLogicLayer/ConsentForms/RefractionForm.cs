using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class RefractionForm
    {
        public static List<BusinessEntities.ConsentForms.RefractionForm> GetRefractionFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RefractionForm.GetRefractionFormData(appId);
            List<BusinessEntities.ConsentForms.RefractionForm> list = new List<BusinessEntities.ConsentForms.RefractionForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.RefractionForm
                {
                    rfcId = Convert.ToInt32(dr["rfcId"]),
                    rfc_appId = Convert.ToInt32(dr["rfc_appId"]),
                    rfc_type = dr["rfc_type"].ToString(),
                    rfc_odselecttype1 = dr["rfc_odselecttype1"].ToString(),
                    rfc_odselecttype2 = dr["rfc_odselecttype2"].ToString(),
                    rfc_osselecttype1 = dr["rfc_osselecttype1"].ToString(),
                    rfc_osselecttype2 = dr["rfc_osselecttype2"].ToString(),
                    rfc_phselecttype1 = dr["rfc_phselecttype1"].ToString(),
                    rfc_phselecttype2 = dr["rfc_phselecttype2"].ToString(),
                    rfc_phselecttype3 = dr["rfc_phselecttype3"].ToString(),
                    rfc_phselecttype4 = dr["rfc_phselecttype4"].ToString(),
                    rfc_glsselecttype1 = dr["rfc_glsselecttype1"].ToString(),
                    rfc_glsselecttype2 = dr["rfc_glsselecttype2"].ToString(),
                    rfc_glsselecttype3 = dr["rfc_glsselecttype3"].ToString(),
                    rfc_glsselecttype4 = dr["rfc_glsselecttype4"].ToString(),
                    rfc_clselecttype1 = dr["rfc_clselecttype1"].ToString(),
                    rfc_clselecttype2 = dr["rfc_clselecttype2"].ToString(),
                    rfc_clselecttype3 = dr["rfc_clselecttype3"].ToString(),
                    rfc_clselecttype4 = dr["rfc_clselecttype4"].ToString(),
                    rfc_od1 = dr["rfc_od1"].ToString(),
                    rfc_os1 = dr["rfc_os1"].ToString(),
                    rfc_glass1doc = dr["rfc_glass1doc"].ToString(),
                    rfc_glass2doc = dr["rfc_glass2doc"].ToString(),
                    rfc_chk = dr["rfc_chk"].ToString(),
                    rfc_date1 = dr["rfc_date1"].ToString(),
                    rfc_subodsph1 = dr["rfc_subodsph1"].ToString(),
                    rfc_subodsph2 = dr["rfc_subodsph2"].ToString(),
                    rfc_subcyl1 = dr["rfc_subcyl1"].ToString(),
                    rfc_subcyl2 = dr["rfc_subcyl2"].ToString(),
                    rfc_subaxs1 = dr["rfc_subaxs1"].ToString(),
                    rfc_subaxs2 = dr["rfc_subaxs2"].ToString(),
                    rfc_subva1 = dr["rfc_subcyl1"].ToString(),
                    rfc_subva2 = dr["rfc_subva2"].ToString(),
                    rfc_subva3 = dr["rfc_subva3"].ToString(),
                    rfc_subva4 = dr["rfc_subva4"].ToString(),
                    rfc_subadd1 = dr["rfc_subadd1"].ToString(),
                    rfc_subadd2 = dr["rfc_subadd2"].ToString(),
                    rfc_subva5 = dr["rfc_subva5"].ToString(),
                    rfc_subva6 = dr["rfc_subva6"].ToString(),
                    rfc_subva7 = dr["rfc_subva7"].ToString(),
                    rfc_subva8 = dr["rfc_subva8"].ToString(),
                    rfc_subph1 = dr["rfc_subph1"].ToString(),
                    rfc_subph2 = dr["rfc_subph2"].ToString(),
                    rfc_subph3 = dr["rfc_subph3"].ToString(),
                    rfc_subph4 = dr["rfc_subph4"].ToString(),
                    rfc_sub1 = dr["rfc_sub1"].ToString(),
                    rfc_sub2 = dr["rfc_sub2"].ToString(),
                    rfc_sub3 = dr["rfc_sub3"].ToString(),
                    rfc_date2 = dr["rfc_date2"].ToString(),
                    rfc_cycloodsph1 = dr["rfc_cycloodsph1"].ToString(),
                    rfc_cycloodsph2 = dr["rfc_cycloodsph2"].ToString(),
                    rfc_cyclocyl1 = dr["rfc_cyclocyl1"].ToString(),
                    rfc_cyclocyl2 = dr["rfc_cyclocyl2"].ToString(),
                    rfc_cycloaxs1 = dr["rfc_cycloaxs1"].ToString(),
                    rfc_cycloaxs2 = dr["rfc_cycloaxs2"].ToString(),
                    rfc_cyclova1 = dr["rfc_cyclova1"].ToString(),
                    rfc_cyclova2 = dr["rfc_cyclova2"].ToString(),
                    rfc_cyclova3 = dr["rfc_cyclova3"].ToString(),
                    rfc_cyclova4 = dr["rfc_cyclova4"].ToString(),
                    rfc_cycloadd1 = dr["rfc_cycloadd1"].ToString(),
                    rfc_cycloadd2 = dr["rfc_cycloadd2"].ToString(),
                    rfc_cyclova5 = dr["rfc_cyclova5"].ToString(),
                    rfc_cyclova6 = dr["rfc_cyclova6"].ToString(),
                    rfc_cyclova7 = dr["rfc_cyclova7"].ToString(),
                    rfc_cyclova8 = dr["rfc_cyclova8"].ToString(),
                    rfc_cycloph1 = dr["rfc_cycloph1"].ToString(),
                    rfc_cycloph2 = dr["rfc_cycloph2"].ToString(),
                    rfc_cycloph3 = dr["rfc_cycloph3"].ToString(),
                    rfc_cycloph4 = dr["rfc_cycloph4"].ToString(),
                    rfc_cyclo1 = dr["rfc_cyclo1"].ToString(),
                    rfc_cyclo2 = dr["rfc_cyclo2"].ToString(),
                    rfc_cyclo3 = dr["rfc_cyclo3"].ToString(),
                    rfc_date3 = dr["rfc_date3"].ToString(),
                    rfc_dryodsph1 = dr["rfc_dryodsph1"].ToString(),
                    rfc_dryodsph2 = dr["rfc_dryodsph2"].ToString(),
                    rfc_drycyl1 = dr["rfc_drycyl1"].ToString(),
                    rfc_drycyl2 = dr["rfc_drycyl2"].ToString(),
                    rfc_dryaxs1 = dr["rfc_dryaxs1"].ToString(),
                    rfc_dryaxs2 = dr["rfc_dryaxs2"].ToString(),
                    rfc_dryva1 = dr["rfc_dryva1"].ToString(),
                    rfc_dryva2 = dr["rfc_dryva2"].ToString(),
                    rfc_dryva3 = dr["rfc_dryva3"].ToString(),
                    rfc_dryva4 = dr["rfc_dryva4"].ToString(),
                    rfc_dryadd1 = dr["rfc_dryadd1"].ToString(),
                    rfc_dryadd2 = dr["rfc_dryadd2"].ToString(),
                    rfc_dryva5 = dr["rfc_dryva5"].ToString(),
                    rfc_dryva6 = dr["rfc_dryva6"].ToString(),
                    rfc_dryva7 = dr["rfc_dryva7"].ToString(),
                    rfc_dryva8 = dr["rfc_dryva8"].ToString(),
                    rfc_dryph1 = dr["rfc_dryph1"].ToString(),
                    rfc_dryph2 = dr["rfc_dryph2"].ToString(),
                    rfc_dryph3 = dr["rfc_dryph3"].ToString(),
                    rfc_dryph4 = dr["rfc_dryph4"].ToString(),
                    rfc_dry1 = dr["rfc_dry1"].ToString(),
                    rfc_dry2 = dr["rfc_dry2"].ToString(),
                    rfc_dry3 = dr["rfc_dry3"].ToString(),
                    rfc_autodoc = dr["rfc_autodoc"].ToString(),
                    rfc_cyclodoc = dr["rfc_cyclodoc"].ToString(),
                    rfc_drydoc = dr["rfc_drydoc"].ToString(),
                    rfc_status = dr["rfc_status"].ToString(),
                    rfc_date_modified = Convert.ToDateTime(dr["rfc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveRefractionForm(BusinessEntities.ConsentForms.RefractionForm refraction, int madeby)
        {
            return DataAccessLayer.ConsentForms.RefractionForm.SaveRefractionForm(refraction, madeby);
        }
        public static int DeleteRefractionForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.RefractionForm.DeleteRefractionForm(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetRefractionFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RefractionForm.GetRefractionFormPreviousHistory(appId);
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
