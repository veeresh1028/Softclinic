using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DermalFillers
    {
        public static List<BusinessEntities.ConsentForms.DermalFillers> GetDermalFillersData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DermalFillers.GetDermalFillersData(appId);
            List<BusinessEntities.ConsentForms.DermalFillers> list = new List<BusinessEntities.ConsentForms.DermalFillers>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DermalFillers
                {
                    dffId = Convert.ToInt32(dr["dffId"]),
                    dff_appId = Convert.ToInt32(dr["dff_appId"]),
                    dff_1 = dr["dff_1"].ToString(),
                    dff_2 = dr["dff_2"].ToString(),
                    dff_chk = dr["dff_chk"].ToString(),
                    dff_status = dr["dff_status"].ToString(),
                    dff_date_modified = Convert.ToDateTime(dr["dff_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDermalFillers(BusinessEntities.ConsentForms.DermalFillers derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DermalFillers.SaveDermalFillers(derma, madeby);
        }
        public static int DeleteDermalFillers(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DermalFillers.DeleteDermalFillers(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDermalFillersPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DermalFillers.GetDermalFillersPreviousHistory(appId);
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
