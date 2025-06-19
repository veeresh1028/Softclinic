using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DermatologyGeneral
    {
        public static List<BusinessEntities.ConsentForms.DermatologyGeneral> GetDermatologyGeneralData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DermatologyGeneral.GetDermatologyGeneralData(appId);
            List<BusinessEntities.ConsentForms.DermatologyGeneral> list = new List<BusinessEntities.ConsentForms.DermatologyGeneral>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DermatologyGeneral
                {
                    dgcId = Convert.ToInt32(dr["dgcId"]),
                    dgc_appId = Convert.ToInt32(dr["dgc_appId"]),
                    dgc_1 = dr["dgc_1"].ToString(),
                    dgc_2 = dr["dgc_2"].ToString(),
                    dgc_3 = dr["dgc_3"].ToString(),
                    dgc_status = dr["dgc_status"].ToString(),
                    dgc_date_modified = Convert.ToDateTime(dr["dgc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDermatologyGeneral(BusinessEntities.ConsentForms.DermatologyGeneral hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.DermatologyGeneral.SaveDermatologyGeneral(hijama, madeby);
        }
        public static int DeleteDermatologyGeneral(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DermatologyGeneral.DeleteDermatologyGeneral(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDermatologyGeneralPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DermatologyGeneral.GetDermatologyGeneralPreviousHistory(appId);
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
