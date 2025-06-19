using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class HydraFacial
    {
        public static List<BusinessEntities.ConsentForms.HydraFacial> GetHydraFacialData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HydraFacial.GetHydraFacialData(appId);
            List<BusinessEntities.ConsentForms.HydraFacial> list = new List<BusinessEntities.ConsentForms.HydraFacial>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.HydraFacial
                {
                    hfcId = Convert.ToInt32(dr["hfcId"]),
                    hfc_appId = Convert.ToInt32(dr["hfc_appId"]),
                    hfc_1 = dr["hfc_1"].ToString(),
                    hfc_status = dr["hfc_status"].ToString(),
                    hfc_date_modified = Convert.ToDateTime(dr["hfc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveHydraFacial(BusinessEntities.ConsentForms.HydraFacial hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.HydraFacial.SaveHydraFacial(hijama, madeby);
        }
        public static int DeleteHydraFacial(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.HydraFacial.DeleteHydraFacial(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetHydraFacialPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HydraFacial.GetHydraFacialPreviousHistory(appId);
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
