using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class Mesotherapy
    {
        public static List<BusinessEntities.ConsentForms.Mesotherapy> GetMesotherapyData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Mesotherapy.GetMesotherapyData(appId);
            List<BusinessEntities.ConsentForms.Mesotherapy> list = new List<BusinessEntities.ConsentForms.Mesotherapy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.Mesotherapy
                {
                    cmcId = Convert.ToInt32(dr["cmcId"]),
                    cmc_appId = Convert.ToInt32(dr["cmc_appId"]),
                    cmc_1 = dr["cmc_1"].ToString(),
                    cmc_2 = dr["cmc_2"].ToString(),
                    cmc_3 = dr["cmc_3"].ToString(),
                    cmc_4 = dr["cmc_4"].ToString(),
                    cmc_5 = dr["cmc_5"].ToString(),
                    cmc_6 = dr["cmc_6"].ToString(),
                    cmc_7 = dr["cmc_7"].ToString(),
                    cmc_8 = dr["cmc_8"].ToString(),
                    cmc_9 = dr["cmc_9"].ToString(),
                    cmc_10 = dr["cmc_10"].ToString(),
                    cmc_11 = dr["cmc_11"].ToString(),
                    cmc_12 = dr["cmc_12"].ToString(),
                    cmc_13 = dr["cmc_13"].ToString(),
                    cmc_14 = dr["cmc_14"].ToString(),
                    cmc_15 = dr["cmc_15"].ToString(),
                    cmc_status = dr["cmc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveMesotherapy(BusinessEntities.ConsentForms.Mesotherapy meso, int madeby)
        {
            return DataAccessLayer.ConsentForms.Mesotherapy.SaveMesotherapy(meso, madeby);
        }

        public static int DeleteMesotherapy(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.Mesotherapy.DeleteMesotherapy(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetMesotherapyPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Mesotherapy.GetMesotherapyPreviousHistory(appId);
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
