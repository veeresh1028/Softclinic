using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PhysiotherapyAssessment
    {
        public static List<BusinessEntities.ConsentForms.PhysiotherapyAssessment> GetPhysiotherapyAssessmentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhysiotherapyAssessment.GetPhysiotherapyAssessmentData(appId);
            List<BusinessEntities.ConsentForms.PhysiotherapyAssessment> list = new List<BusinessEntities.ConsentForms.PhysiotherapyAssessment>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PhysiotherapyAssessment
                {
                    pafId = Convert.ToInt32(dr["pafId"]),
                    paf_appId = Convert.ToInt32(dr["paf_appId"]),
                    paf_1 = dr["paf_1"].ToString(),
                    paf_2 = dr["paf_2"].ToString(),
                    paf_3 = dr["paf_3"].ToString(),
                    paf_4 = dr["paf_4"].ToString(),
                    paf_5 = dr["paf_5"].ToString(),
                    paf_6 = dr["paf_6"].ToString(),
                    paf_7 = dr["paf_7"].ToString(),
                    paf_8 = dr["paf_8"].ToString(),
                    paf_9 = dr["paf_9"].ToString(),
                    paf_10 = dr["paf_10"].ToString(),
                    paf_11 = dr["paf_11"].ToString(),
                    paf_12 = dr["paf_12"].ToString(),
                    paf_13 = dr["paf_13"].ToString(),
                    paf_14 = dr["paf_14"].ToString(),
                    paf_15 = dr["paf_15"].ToString(),
                    paf_16 = dr["paf_16"].ToString(),
                    paf_17 = dr["paf_17"].ToString(),
                    paf_18 = dr["paf_18"].ToString(),
                    paf_19 = dr["paf_19"].ToString(),
                    paf_20 = dr["paf_20"].ToString(),
                    paf_21 = dr["paf_21"].ToString(),
                    paf_22 = dr["paf_22"].ToString(),
                    paf_23 = dr["paf_23"].ToString(),
                    paf_24 = dr["paf_24"].ToString(),
                    paf_25 = dr["paf_25"].ToString(),
                    paf_26 = dr["paf_26"].ToString(),
                    paf_doc = dr["paf_doc"].ToString(),
                    paf_status = dr["paf_status"].ToString(),
                    paf_date_modified = Convert.ToDateTime(dr["paf_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SavePhysiotherapyAssessment(BusinessEntities.ConsentForms.PhysiotherapyAssessment physiotherapy, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhysiotherapyAssessment.SavePhysiotherapyAssessment(physiotherapy, madeby);
        }



        public static int DeletePhysiotherapyAssessment(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PhysiotherapyAssessment.DeletePhysiotherapyAssessment(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPhysiotherapyAssessmentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PhysiotherapyAssessment.GetPhysiotherapyAssessmentPreviousHistory(appId);
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
