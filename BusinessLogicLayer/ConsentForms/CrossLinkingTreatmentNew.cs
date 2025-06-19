using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class CrossLinkingTreatmentNew
    {
        public static List<BusinessEntities.ConsentForms.CrossLinkingTreatmentNew> GetCrossLinkingTreatmentNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CrossLinkingTreatmentNew.GetCrossLinkingTreatmentNewData(appId);
            List<BusinessEntities.ConsentForms.CrossLinkingTreatmentNew> list = new List<BusinessEntities.ConsentForms.CrossLinkingTreatmentNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.CrossLinkingTreatmentNew
                {
                    ocltId = Convert.ToInt32(dr["ocltId"]),
                    oclt_appId = Convert.ToInt32(dr["oclt_appId"]),
                    oclt_1 = dr["oclt_1"].ToString(),
                    oclt_2 = dr["oclt_2"].ToString(),
                    oclt_3 = dr["oclt_3"].ToString(),
                    oclt_4 = dr["oclt_4"].ToString(),
                    oclt_status = dr["oclt_status"].ToString(),
                    oclt_date_modified = Convert.ToDateTime(dr["oclt_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveCrossLinkingTreatmentNew(BusinessEntities.ConsentForms.CrossLinkingTreatmentNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.CrossLinkingTreatmentNew.SaveCrossLinkingTreatmentNew(discharge, madeby);
        }


        public static int DeleteCrossLinkingTreatmentNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.CrossLinkingTreatmentNew.DeleteCrossLinkingTreatmentNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetCrossLinkingTreatmentNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CrossLinkingTreatmentNew.GetCrossLinkingTreatmentNewPreviousHistory(appId);
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
