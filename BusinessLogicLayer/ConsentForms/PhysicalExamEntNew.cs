using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PhysicalExamEntNew
    {
        public static List<BusinessEntities.ConsentForms.PhysicalExamEntNew> GetPhysicalExamEntNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhysicalExamEntNew.GetPhysicalExamEntNewData(appId);
            List<BusinessEntities.ConsentForms.PhysicalExamEntNew> list = new List<BusinessEntities.ConsentForms.PhysicalExamEntNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PhysicalExamEntNew
                {
                    peeId = Convert.ToInt32(dr["peeId"]),
                    pee_appId = Convert.ToInt32(dr["pee_appId"]),
                    pee_1 = dr["pee_1"].ToString(),
                    pee_2 = dr["pee_2"].ToString(),
                    pee_3 = dr["pee_3"].ToString(),
                    pee_4 = dr["pee_4"].ToString(),
                    pee_5 = dr["pee_5"].ToString(),
                    pee_6 = dr["pee_6"].ToString(),
                    pee_7 = dr["pee_7"].ToString(),
                    pee_chk1 = dr["pee_chk1"].ToString(),
                    pee_8 = dr["pee_8"].ToString(),
                    pee_9 = dr["pee_9"].ToString(),
                    pee_10 = dr["pee_10"].ToString(),
                    pee_11 = dr["pee_11"].ToString(),
                    pee_chk2 = dr["pee_chk2"].ToString(),
                    pee_chk3 = dr["pee_chk3"].ToString(),
                    pee_chk4 = dr["pee_chk4"].ToString(),
                    pee_12 = dr["pee_12"].ToString(),
                    pee_13 = dr["pee_13"].ToString(),
                    pee_14 = dr["pee_14"].ToString(),
                    pee_15 = dr["pee_15"].ToString(),
                    pee_16 = dr["pee_16"].ToString(),
                    pee_17 = dr["pee_17"].ToString(),
                    pee_chk5 = dr["pee_chk5"].ToString(),
                    pee_chk6 = dr["pee_chk6"].ToString(),
                    pee_18 = dr["pee_18"].ToString(),
                    pee_19 = dr["pee_19"].ToString(),
                    pee_20 = dr["pee_20"].ToString(),
                    pee_21 = dr["pee_21"].ToString(),
                    pee_chk7 = dr["pee_chk7"].ToString(),
                    pee_22 = dr["pee_22"].ToString(),
                    pee_23 = dr["pee_23"].ToString(),
                    pee_24 = dr["pee_24"].ToString(),
                    pee_25 = dr["pee_25"].ToString(),
                    pee_26 = dr["pee_26"].ToString(),
                    pee_27 = dr["pee_27"].ToString(),
                    pee_chk8 = dr["pee_chk8"].ToString(),
                    pee_chk9 = dr["pee_chk9"].ToString(),
                    pee_28 = dr["pee_28"].ToString(),
                    pee_29 = dr["pee_29"].ToString(),
                    pee_30 = dr["pee_30"].ToString(),
                    pee_31 = dr["pee_31"].ToString(),
                    pee_32 = dr["pee_32"].ToString(),
                    pee_33 = dr["pee_33"].ToString(),
                    pee_34 = dr["pee_34"].ToString(),
                    pee_doc1 = dr["pee_doc1"].ToString(),
                    pee_doc2 = dr["pee_doc2"].ToString(),
                    pee_doc3 = dr["pee_doc3"].ToString(),
                    pee_status = dr["pee_status"].ToString(),
                    pee_date_modified = Convert.ToDateTime(dr["pee_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SavePhysicalExamEntNew(BusinessEntities.ConsentForms.PhysicalExamEntNew physical, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhysicalExamEntNew.SavePhysicalExamEntNew(physical, madeby);
        }
        public static int DeletePhysicalExamEntNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhysicalExamEntNew.DeletePhysicalExamEntNew(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPhysicalExamEntNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhysicalExamEntNew.GetPhysicalExamEntNewPreviousHistory(appId);
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
