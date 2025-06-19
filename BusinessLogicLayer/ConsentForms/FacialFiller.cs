using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FacialFiller
    {
        public static List<BusinessEntities.ConsentForms.FacialFiller> GetFacialFillerData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialFiller.GetFacialFillerData(appId);
            List<BusinessEntities.ConsentForms.FacialFiller> list = new List<BusinessEntities.ConsentForms.FacialFiller>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FacialFiller
                {
                    ffcId = Convert.ToInt32(dr["ffcId"]),
                    ffc_appId = Convert.ToInt32(dr["ffc_appId"]),
                    ffc_1 = dr["ffc_1"].ToString(),
                    ffc_status = dr["ffc_status"].ToString(),
                    ffc_date_modified = Convert.ToDateTime(dr["ffc_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveFacialFiller(BusinessEntities.ConsentForms.FacialFiller hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialFiller.SaveFacialFiller(hijama, madeby);
        }
        public static int DeleteFacialFiller(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialFiller.DeleteFacialFiller(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetFacialFillerPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialFiller.GetFacialFillerPreviousHistory(appId);
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
