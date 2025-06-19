using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PhysicalExamForm
    {
        public static List<BusinessEntities.ConsentForms.PhysicalExamForm> GetPhysicalExamFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhysicalExamForm.GetPhysicalExamFormData(appId);
            List<BusinessEntities.ConsentForms.PhysicalExamForm> list = new List<BusinessEntities.ConsentForms.PhysicalExamForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PhysicalExamForm
                {
                    pefId = Convert.ToInt32(dr["pefId"]),
                    pef_appId = Convert.ToInt32(dr["pef_appId"]),
                    pef_1 = dr["pef_1"].ToString(),
                    pef_2 = dr["pef_2"].ToString(),
                    pef_3 = dr["pef_3"].ToString(),
                    pef_4 = dr["pef_4"].ToString(),
                    pef_5 = dr["pef_5"].ToString(),
                    pef_6 = dr["pef_6"].ToString(),
                    pef_7 = dr["pef_7"].ToString(),
                    pef_8 = dr["pef_8"].ToString(),
                    pef_9 = dr["pef_9"].ToString(),
                    pef_10 = dr["pef_10"].ToString(),
                    pef_11 = dr["pef_11"].ToString(),
                    pef_12 = dr["pef_12"].ToString(),
                    pef_13 = dr["pef_13"].ToString(),
                    pef_14 = dr["pef_14"].ToString(),
                    pef_15 = dr["pef_15"].ToString(),
                    pef_16 = dr["pef_16"].ToString(),
                    pef_17 = dr["pef_17"].ToString(),
                    pef_18 = dr["pef_18"].ToString(),
                    pef_19 = dr["pef_19"].ToString(),
                    pef_20 = dr["pef_20"].ToString(),
                    pef_21 = dr["pef_21"].ToString(),
                    pef_22 = dr["pef_22"].ToString(),
                    pef_23 = dr["pef_23"].ToString(),
                    pef_24 = dr["pef_24"].ToString(),
                    pef_25 = dr["pef_25"].ToString(),
                    pef_26 = dr["pef_26"].ToString(),
                    pef_27 = dr["pef_27"].ToString(),
                    pef_28 = dr["pef_28"].ToString(),
                    pef_29 = dr["pef_29"].ToString(),
                    pef_30 = dr["pef_30"].ToString(),
                    pef_31 = dr["pef_31"].ToString(),
                    pef_32 = dr["pef_32"].ToString(),
                    pef_33 = dr["pef_33"].ToString(),
                    pef_34 = dr["pef_34"].ToString(),
                    pef_35 = dr["pef_35"].ToString(),
                    pef_36 = dr["pef_36"].ToString(),
                    pef_chk1 = dr["pef_chk1"].ToString(),
                    pef_doc = dr["pef_doc"].ToString(),
                    pef_status = dr["pef_status"].ToString(),
                    pef_date_modified = Convert.ToDateTime(dr["pef_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SavePhysicalExamForm(BusinessEntities.ConsentForms.PhysicalExamForm physical, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhysicalExamForm.SavePhysicalExamForm(physical, madeby);
        }
        public static int DeletePhysicalExamForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhysicalExamForm.DeletePhysicalExamForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPhysicalExamFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhysicalExamForm.GetPhysicalExamFormPreviousHistory(appId);
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
