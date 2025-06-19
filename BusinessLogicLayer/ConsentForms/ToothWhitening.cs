using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class ToothWhitening
    {
        public static List<BusinessEntities.ConcentForms.ToothWhitening> GetToothWhiteningData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ToothWhitening.GetToothWhiteningData(appId);
            List<BusinessEntities.ConcentForms.ToothWhitening> list = new List<BusinessEntities.ConcentForms.ToothWhitening>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ToothWhitening
                {
                    ctwcId = Convert.ToInt32(dr["ctwcId"]),
                    ctwc_appId = Convert.ToInt32(dr["ctwc_appId"]),
                    ctwc_status = dr["ctwc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveToothWhitening(BusinessEntities.ConcentForms.ToothWhitening tooth, int madeby)
        {
            return DataAccessLayer.ConcentForms.ToothWhitening.SaveToothWhitening(tooth, madeby);
        }

        public static int DeleteToothWhitening(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.ToothWhitening.DeleteToothWhitening(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetToothWhiteningPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ToothWhitening.GetToothWhiteningPreviousHistory(appId);
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
