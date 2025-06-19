using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeUltralasikTreatmentNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeUltralasikTreatmentNew> GetDischargeUltralasikTreatmentNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeUltralasikTreatmentNew.GetDischargeUltralasikTreatmentNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeUltralasikTreatmentNew> list = new List<BusinessEntities.ConsentForms.DischargeUltralasikTreatmentNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeUltralasikTreatmentNew
                {
                    dsutId = Convert.ToInt32(dr["dsutId"]),
                    dsut_appId = Convert.ToInt32(dr["dsut_appId"]),
                    dsut_1 = dr["dsut_1"].ToString(),
                    dsut_2 = dr["dsut_2"].ToString(),
                    dsut_3 = dr["dsut_3"].ToString(),
                    dsut_4 = dr["dsut_4"].ToString(),
                    dsut_5 = dr["dsut_5"].ToString(),
                    dsut_6 = dr["dsut_6"].ToString(),
                    dsut_status = dr["dsut_status"].ToString(),
                    dsut_date_modified = Convert.ToDateTime(dr["dsut_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveDischargeUltralasikTreatmentNew(BusinessEntities.ConsentForms.DischargeUltralasikTreatmentNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeUltralasikTreatmentNew.SaveDischargeUltralasikTreatmentNew(discharge, madeby);
        }


        public static int DeleteDischargeUltralasikTreatmentNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeUltralasikTreatmentNew.DeleteDischargeUltralasikTreatmentNew(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeUltralasikTreatmentNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeUltralasikTreatmentNew.GetDischargeUltralasikTreatmentNewPreviousHistory(appId);
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
