using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public  class LaserAssessment
    {
        public static List<BusinessEntities.ConsentForms.LaserAssessment> GetLaserAssessmentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserAssessment.GetLaserAssessmentData(appId);
            List<BusinessEntities.ConsentForms.LaserAssessment> list = new List<BusinessEntities.ConsentForms.LaserAssessment>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserAssessment
                {
                    lacId = Convert.ToInt32(dr["lacId"]),
                    lac_appId = Convert.ToInt32(dr["lac_appId"]),
                    lac_1 = dr["lac_1"].ToString(),
                    lac_2 = dr["lac_2"].ToString(),
                    lac_3 = dr["lac_3"].ToString(),
                    lac_4 = dr["lac_4"].ToString(),
                    lac_5 = dr["lac_5"].ToString(),
                    lac_6 = dr["lac_6"].ToString(),
                    lac_7 = dr["lac_7"].ToString(),
                    lac_8 = dr["lac_8"].ToString(),
                    lac_9 = dr["lac_9"].ToString(),
                    lac_10 = dr["lac_10"].ToString(),
                    lac_11 = dr["lac_11"].ToString(),
                    lac_12 = dr["lac_12"].ToString(),
                    lac_13 = dr["lac_13"].ToString(),
                    lac_14 = dr["lac_14"].ToString(),
                    lac_15 = dr["lac_15"].ToString(),
                    lac_16 = dr["lac_16"].ToString(),
                    lac_17 = dr["lac_17"].ToString(),
                    lac_18 = dr["lac_18"].ToString(),
                    lac_19 = dr["lac_19"].ToString(),
                    lac_20 = dr["lac_20"].ToString(),
                    lac_21 = dr["lac_21"].ToString(),
                    lac_22 = dr["lac_22"].ToString(),
                    lac_23 = dr["lac_23"].ToString(),
                    lac_24 = dr["lac_24"].ToString(),
                    lac_25 = dr["lac_25"].ToString(),
                    lac_26 = dr["lac_26"].ToString(),
                    lac_27 = dr["lac_27"].ToString(),
                    lac_28 = dr["lac_28"].ToString(),
                    lac_29 = dr["lac_29"].ToString(),
                    lac_30 = dr["lac_30"].ToString(),
                    lac_31 = dr["lac_31"].ToString(),
                    lac_32 = dr["lac_32"].ToString(),
                    lac_33 = dr["lac_33"].ToString(),
                    lac_34 = dr["lac_34"].ToString(),
                    lac_35 = dr["lac_35"].ToString(),
                    lac_36 = dr["lac_36"].ToString(),
                    lac_status = dr["lac_status"].ToString(),
                    lac_date_modified = Convert.ToDateTime(dr["lac_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveLaserAssessment(BusinessEntities.ConsentForms.LaserAssessment hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserAssessment.SaveLaserAssessment(hijama, madeby);
        }
        public static int DeleteLaserAssessment(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserAssessment.DeleteLaserAssessment(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLaserAssessmentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserAssessment.GetLaserAssessmentPreviousHistory(appId);
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
