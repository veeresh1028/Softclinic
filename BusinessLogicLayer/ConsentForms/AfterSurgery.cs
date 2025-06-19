using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class AfterSurgery
    {
        public static List<BusinessEntities.ConsentForms.AfterSurgery> GetAfterSurgeryData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AfterSurgery.GetAfterSurgeryData(appId);
            List<BusinessEntities.ConsentForms.AfterSurgery> list = new List<BusinessEntities.ConsentForms.AfterSurgery>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.AfterSurgery
                {
                    spId = Convert.ToInt32(dr["spId"]),
                    sp_appId = Convert.ToInt32(dr["sp_appId"]),
                    sp_status = dr["sp_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveAfterSurgery(BusinessEntities.ConsentForms.AfterSurgery tooth, int madeby)
        {
            return DataAccessLayer.ConsentForms.AfterSurgery.SaveAfterSurgery(tooth, madeby);
        }
        public static int DeleteAfterSurgery(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.AfterSurgery.DeleteAfterSurgery(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetAfterSurgeryPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AfterSurgery.GetAfterSurgeryPreviousHistory(appId);
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
