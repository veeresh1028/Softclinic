using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public  class DripTherapy
    {
        public static List<BusinessEntities.ConsentForms.DripTherapy> GetDripTherapyData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DripTherapy.GetDripTherapyData(appId);
            List<BusinessEntities.ConsentForms.DripTherapy> list = new List<BusinessEntities.ConsentForms.DripTherapy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DripTherapy
                {
                    dtcId = Convert.ToInt32(dr["dtcId"]),
                    dtc_appId = Convert.ToInt32(dr["dtc_appId"]),
                    dtc_1 = dr["dtc_1"].ToString(),
                    dtc_status = dr["dtc_status"].ToString(),
                    dtc_date_modified = Convert.ToDateTime(dr["dtc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDripTherapy(BusinessEntities.ConsentForms.DripTherapy hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.DripTherapy.SaveDripTherapy(hijama, madeby);
        }
        public static int DeleteDripTherapy(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DripTherapy.DeleteDripTherapy(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDripTherapyPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DripTherapy.GetDripTherapyPreviousHistory(appId);
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
