using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ContactLens
    {
        public static List<BusinessEntities.ConsentForms.ContactLens> GetContactLensData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ContactLens.GetContactLensData(appId);
            List<BusinessEntities.ConsentForms.ContactLens> list = new List<BusinessEntities.ConsentForms.ContactLens>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ContactLens
                {
                    fclId = Convert.ToInt32(dr["fclId"]),
                    fcl_appId = Convert.ToInt32(dr["fcl_appId"]),
                    fcl_1 = dr["fcl_1"].ToString(),
                    fcl_2 = dr["fcl_2"].ToString(),
                    fcl_3 = dr["fcl_3"].ToString(),
                    fcl_4 = dr["fcl_4"].ToString(),
                    fcl_5 = dr["fcl_5"].ToString(),
                    fcl_6 = dr["fcl_6"].ToString(),
                    fcl_7 = dr["fcl_7"].ToString(),
                    fcl_8 = dr["fcl_8"].ToString(),
                    fcl_9 = dr["fcl_9"].ToString(),
                    fcl_status = dr["fcl_status"].ToString(),
                    fcl_date_modified = Convert.ToDateTime(dr["fcl_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveContactLens(BusinessEntities.ConsentForms.ContactLens ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.ContactLens.SaveContactLens(ophtha, madeby);
        }
        public static int DeleteContactLens(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ContactLens.DeleteContactLens(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetContactLensPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ContactLens.GetContactLensPreviousHistory(appId);
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
