using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class BotoxConstantForm
    {
        public static List<BusinessEntities.ConsentForms.BotoxConstantForm> GetBotoxConstantFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BotoxConstantForm.GetBotoxConstantFormData(appId);
            List<BusinessEntities.ConsentForms.BotoxConstantForm> list = new List<BusinessEntities.ConsentForms.BotoxConstantForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.BotoxConstantForm
                {
                    bcfId = Convert.ToInt32(dr["bcfId"]),
                    bcf_appId = Convert.ToInt32(dr["bcf_appId"]),
                    bcf_1 = dr["bcf_1"].ToString(),
                    bcf_2 = dr["bcf_2"].ToString(),
                    bcf_3 = dr["bcf_3"].ToString(),
                    bcf_chk = dr["bcf_chk"].ToString(),
                    bcf_status = dr["bcf_status"].ToString(),
                    bcf_date_modified = Convert.ToDateTime(dr["bcf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveBotoxConstantForm(BusinessEntities.ConsentForms.BotoxConstantForm botox, int madeby)
        {
            return DataAccessLayer.ConsentForms.BotoxConstantForm.SaveBotoxConstantForm(botox, madeby);
        }
        public static int DeleteBotoxConstantForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.BotoxConstantForm.DeleteBotoxConstantForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetBotoxConstantFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BotoxConstantForm.GetBotoxConstantFormPreviousHistory(appId);
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
