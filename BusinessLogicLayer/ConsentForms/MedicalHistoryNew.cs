using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MedicalHistoryNew
    {
        public static List<BusinessEntities.ConsentForms.MedicalHistoryNew> GetMedicalHistoryNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MedicalHistoryNew.GetMedicalHistoryNewData(appId);
            List<BusinessEntities.ConsentForms.MedicalHistoryNew> list = new List<BusinessEntities.ConsentForms.MedicalHistoryNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MedicalHistoryNew
                {
                    mhnId = Convert.ToInt32(dr["mhnId"]),
                    mhn_appId = Convert.ToInt32(dr["mhn_appId"]),
                    mhn_1 = dr["mhn_1"].ToString(),
                    mhn_2 = dr["mhn_2"].ToString(),
                    mhn_3 = dr["mhn_3"].ToString(),
                    mhn_4 = dr["mhn_4"].ToString(),
                    mhn_5 = dr["mhn_5"].ToString(),
                    mhn_6 = dr["mhn_6"].ToString(),
                    mhn_7 = dr["mhn_7"].ToString(),
                    mhn_8 = dr["mhn_8"].ToString(),
                    mhn_9 = dr["mhn_9"].ToString(),
                    mhn_10 = dr["mhn_10"].ToString(),
                    mhn_11 = dr["mhn_11"].ToString(),
                    mhn_12 = dr["mhn_12"].ToString(),
                    mhn_13 = dr["mhn_13"].ToString(),
                    
                    mhn_radio1 = dr["mhn_radio1"].ToString(),
                    mhn_radio2 = dr["mhn_radio2"].ToString(),
                    mhn_radio3 = dr["mhn_radio3"].ToString(),
                    mhn_radio4 = dr["mhn_radio4"].ToString(),
                    mhn_radio5 = dr["mhn_radio5"].ToString(),
                    mhn_radio6 = dr["mhn_radio6"].ToString(),
                    mhn_radio7 = dr["mhn_radio7"].ToString(),
                    mhn_radio8 = dr["mhn_radio8"].ToString(),
                    mhn_radio9 = dr["mhn_radio9"].ToString(),
                    mhn_radio10 = dr["mhn_radio10"].ToString(),
                    mhn_radio11 = dr["mhn_radio11"].ToString(),
                    mhn_radio12 = dr["mhn_radio12"].ToString(),

                    mhn_status = dr["mhn_status"].ToString(),
                    mhn_date_modified = Convert.ToDateTime(dr["mhn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveMedicalHistoryNew(BusinessEntities.ConsentForms.MedicalHistoryNew derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.MedicalHistoryNew.SaveMedicalHistoryNew(derma, madeby);
        }
        public static int DeleteMedicalHistoryNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MedicalHistoryNew.DeleteMedicalHistoryNew(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetMedicalHistoryNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MedicalHistoryNew.GetMedicalHistoryNewPreviousHistory(appId);
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
