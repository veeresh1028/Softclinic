using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class IntimatePeel
    {
        public static List<BusinessEntities.ConsentForms.IntimatePeel> GetIntimatePeelData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.IntimatePeel.GetIntimatePeelData(appId);
            List<BusinessEntities.ConsentForms.IntimatePeel> list = new List<BusinessEntities.ConsentForms.IntimatePeel>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.IntimatePeel
                {
                    ciplId = Convert.ToInt32(dr["ciplId"]),
                    cipl_appId = Convert.ToInt32(dr["cipl_appId"]),
                    cipl_status = dr["cipl_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveIntimatePeel(BusinessEntities.ConsentForms.IntimatePeel tooth, int madeby)
        {
            return DataAccessLayer.ConsentForms.IntimatePeel.SaveIntimatePeel(tooth, madeby);
        }
        public static int DeleteIntimatePeel(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.IntimatePeel.DeleteIntimatePeel(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetIntimatePeelPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.IntimatePeel.GetIntimatePeelPreviousHistory(appId);
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
