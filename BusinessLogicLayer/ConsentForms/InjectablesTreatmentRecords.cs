using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class InjectablesTreatmentRecords
    {
        public static List<BusinessEntities.ConsentForms.InjectablesTreatmentRecords> GetInjectablesTreatmentRecordsData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InjectablesTreatmentRecords.GetInjectablesTreatmentRecordsData(appId);
            List<BusinessEntities.ConsentForms.InjectablesTreatmentRecords> list = new List<BusinessEntities.ConsentForms.InjectablesTreatmentRecords>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.InjectablesTreatmentRecords
                {
                    itrId = Convert.ToInt32(dr["itrId"]),
                    itr_appId = Convert.ToInt32(dr["itr_appId"]),
                    itr_1 = dr["itr_1"].ToString(),
                    itr_doc = dr["itr_doc"].ToString(),
                    itr_status = dr["itr_status"].ToString(),
                    itr_date_modified = Convert.ToDateTime(dr["itr_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveInjectablesTreatmentRecords(BusinessEntities.ConsentForms.InjectablesTreatmentRecords injectables, int madeby)
        {
            return DataAccessLayer.ConsentForms.InjectablesTreatmentRecords.SaveInjectablesTreatmentRecords(injectables, madeby);
        }
        public static int DeleteInjectablesTreatmentRecords(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.InjectablesTreatmentRecords.DeleteInjectablesTreatmentRecords(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetInjectablesTreatmentRecordsPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InjectablesTreatmentRecords.GetInjectablesTreatmentRecordsPreviousHistroy(appId);
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
