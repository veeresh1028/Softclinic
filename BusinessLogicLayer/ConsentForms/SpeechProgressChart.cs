using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class SpeechProgressChart
    {
        public static List<BusinessEntities.ConsentForms.SpeechProgressChart> GetSpeechProgressChartData(int appId, int? spcId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SpeechProgressChart.GetSpeechProgressChartData(appId, spcId);
            List<BusinessEntities.ConsentForms.SpeechProgressChart> list = new List<BusinessEntities.ConsentForms.SpeechProgressChart>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SpeechProgressChart
                {
                    spcId = Convert.ToInt32(dr["spcId"]),
                    spc_appId = Convert.ToInt32(dr["spc_appId"]),
                    spc_date1 = dr["spc_date1"].ToString(),
                    spc_1 = dr["spc_1"].ToString(),
                    spc_color = dr["spc_color"].ToString(),
                    spc_2 = dr["spc_2"].ToString(),
                    spc_status = dr["spc_status"].ToString(),
                    spc_date_modified = Convert.ToDateTime(dr["spc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveSpeechProgressChart(BusinessEntities.ConsentForms.SpeechProgressChart speech, int madeby)
        {
            return DataAccessLayer.ConsentForms.SpeechProgressChart.SaveSpeechProgressChart(speech, madeby);
        }
        public static int DeleteSpeechProgressChart(int spcId, int madeby)
        {
            return DataAccessLayer.ConsentForms.SpeechProgressChart.DeleteSpeechProgressChart(spcId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetSpeechProgressChartPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SpeechProgressChart.GetSpeechProgressChartPreviousHistory(appId);
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
