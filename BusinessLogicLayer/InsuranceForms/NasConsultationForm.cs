using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class NasConsultationForm
    {
        public static List<BusinessEntities.InsuranceForms.NasConsultationForm> GetNasConsultationFormData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NasConsultationForm.GetNasConsultationFormData(appId);
            List<BusinessEntities.InsuranceForms.NasConsultationForm> list = new List<BusinessEntities.InsuranceForms.NasConsultationForm>();

            foreach (DataRow dr in dt.Rows)
            {

                list.Add(new BusinessEntities.InsuranceForms.NasConsultationForm
                {
                    ncfId = Convert.ToInt32(dr["ncfId"]),
                    ncf_appId = Convert.ToInt32(dr["ncf_appId"]),

                    ncf_1 = dr["ncf_1"].ToString(),
                    ncf_2 = dr["ncf_2"].ToString(),
                    ncf_3 = dr["ncf_3"].ToString(),
                    ncf_chk = dr["ncf_chk"].ToString(),
                    ncf_radio = dr["ncf_radio"].ToString(),

                    ncf_status = dr["ncf_status"].ToString(),
                    ncf_date_modified = Convert.ToDateTime(dr["ncf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveNasConsultationForm(BusinessEntities.InsuranceForms.NasConsultationForm medical, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NasConsultationForm.SaveNasConsultationForm(medical, madeby);
        }
        public static int DeleteNasConsultationForm(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NasConsultationForm.DeleteNasConsultationForm(appId, madeby);
        }
        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetNasConsultationFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NasConsultationForm.GetNasConsultationFormPreviousHistory(appId);
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
