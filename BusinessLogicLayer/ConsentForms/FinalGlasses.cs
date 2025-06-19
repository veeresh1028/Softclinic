using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FinalGlasses
    {
        public static List<BusinessEntities.ConsentForms.FinalGlasses> GetFinalGlassesData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FinalGlasses.GetFinalGlassesData(appId);
            List<BusinessEntities.ConsentForms.FinalGlasses> list = new List<BusinessEntities.ConsentForms.FinalGlasses>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FinalGlasses
                {
                    fgnId = Convert.ToInt32(dr["fgnId"]),
                    fgn_appId = Convert.ToInt32(dr["fgn_appId"]),
                    fgn_1 = dr["fgn_1"].ToString(),
                    fgn_2 = dr["fgn_2"].ToString(),
                    fgn_3 = dr["fgn_3"].ToString(),
                    fgn_4 = dr["fgn_4"].ToString(),
                    fgn_5 = dr["fgn_5"].ToString(),
                    fgn_6 = dr["fgn_6"].ToString(),
                    fgn_7 = dr["fgn_7"].ToString(),
                    fgn_8 = dr["fgn_8"].ToString(),
                    fgn_9 = dr["fgn_9"].ToString(),
                    fgn_10 = dr["fgn_10"].ToString(),
                    fgn_11 = dr["fgn_11"].ToString(),
                    fgn_12 = dr["fgn_12"].ToString(),
                    fgn_13 = dr["fgn_13"].ToString(),
                    fgn_14 = dr["fgn_14"].ToString(),
                    fgn_15 = dr["fgn_15"].ToString(),
                    fgn_16 = dr["fgn_16"].ToString(),
                    fgn_17 = dr["fgn_17"].ToString(),
                    fgn_18 = dr["fgn_18"].ToString(),
                    fgn_19 = dr["fgn_19"].ToString(),
                    fgn_20 = dr["fgn_20"].ToString(),
                    fgn_21 = dr["fgn_21"].ToString(),
                    fgn_22 = dr["fgn_22"].ToString(),
                    fgn_23 = dr["fgn_23"].ToString(),
                    fgn_24 = dr["fgn_24"].ToString(),
                    fgn_25 = dr["fgn_25"].ToString(),
                    fgn_26 = dr["fgn_26"].ToString(),
                    fgn_27 = dr["fgn_27"].ToString(),
                    fgn_28 = dr["fgn_28"].ToString(),
                    fgn_29 = dr["fgn_29"].ToString(),
                    fgn_30 = dr["fgn_30"].ToString(),
                    fgn_status = dr["fgn_status"].ToString(),
                    fgn_date_modified = Convert.ToDateTime(dr["fgn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveFinalGlasses(BusinessEntities.ConsentForms.FinalGlasses ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.FinalGlasses.SaveFinalGlasses(ophtha, madeby);
        }
        public static int DeleteFinalGlasses(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FinalGlasses.DeleteFinalGlasses(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetFinalGlassesPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FinalGlasses.GetFinalGlassesPreviousHistory(appId);
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
