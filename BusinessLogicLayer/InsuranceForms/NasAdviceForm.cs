using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class NasAdviceForm
    {
        public static List<BusinessEntities.InsuranceForms.NasAdviceForm> GetNasAdviceFormData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NasAdviceForm.GetNasAdviceFormData(appId);
            List<BusinessEntities.InsuranceForms.NasAdviceForm> list = new List<BusinessEntities.InsuranceForms.NasAdviceForm>();

            foreach (DataRow dr in dt.Rows)
            {

                list.Add(new BusinessEntities.InsuranceForms.NasAdviceForm
                {
                    nafId = Convert.ToInt32(dr["nafId"]),
                    naf_appId = Convert.ToInt32(dr["naf_appId"]),

                    naf_1 = dr["naf_1"].ToString(),
                    naf_chk = dr["naf_chk"].ToString(),

                    naf_status = dr["naf_status"].ToString(),
                    naf_date_modified = Convert.ToDateTime(dr["naf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveNasAdviceForm(BusinessEntities.InsuranceForms.NasAdviceForm medical, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NasAdviceForm.SaveNasAdviceForm(medical, madeby);
        }
        public static int DeleteNasAdviceForm(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NasAdviceForm.DeleteNasAdviceForm(appId, madeby);
        }
        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetNasAdviceFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NasAdviceForm.GetNasAdviceFormPreviousHistory(appId);
            List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> list = new List<BusinessEntities.InsuranceForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.ConcentPreviousHistory
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
