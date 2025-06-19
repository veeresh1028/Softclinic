using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class TreatmentRecordSheet
    {
        public static List<BusinessEntities.ConsentForms.TreatmentRecordSheet> GetTreatmentRecordSheetData(int appId, int? trsId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TreatmentRecordSheet.GetTreatmentRecordSheetData(appId, trsId);
            List<BusinessEntities.ConsentForms.TreatmentRecordSheet> list = new List<BusinessEntities.ConsentForms.TreatmentRecordSheet>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.TreatmentRecordSheet
                {
                    trsId = Convert.ToInt32(dr["trsId"]),
                    trs_appId = Convert.ToInt32(dr["trs_appId"]),
                    trs_treat = dr["trs_treat"].ToString(),
                    trs_treat_name = dr["trs_treat_name"].ToString(),
                    trs_1 = dr["trs_1"].ToString(),
                    trs_date1 = dr["trs_date1"].ToString(),
                    trs_notes = dr["trs_notes"].ToString(),
                    trs_status = dr["trs_status"].ToString(),
                    trs_date_modified = Convert.ToDateTime(dr["trs_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveTreatmentRecordSheet(BusinessEntities.ConsentForms.TreatmentRecordSheet treatment, int madeby)
        {
            return DataAccessLayer.ConsentForms.TreatmentRecordSheet.SaveTreatmentRecordSheet(treatment, madeby);
        }
        public static int DeleteTreatmentRecordSheet(int trsId, int madeby)
        {
            return DataAccessLayer.ConsentForms.TreatmentRecordSheet.DeleteTreatmentRecordSheet(trsId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetTreatmentRecordSheetPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TreatmentRecordSheet.GetTreatmentRecordSheetPreviousHistory(appId);
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
