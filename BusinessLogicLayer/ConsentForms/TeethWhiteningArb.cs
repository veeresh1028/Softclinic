using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class TeethWhiteningArb
    {
        public static List<BusinessEntities.ConsentForms.TeethWhiteningArb> GetTeethWhiteningArbData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TeethWhiteningArb.GetTeethWhiteningArbData(appId);
            List<BusinessEntities.ConsentForms.TeethWhiteningArb> list = new List<BusinessEntities.ConsentForms.TeethWhiteningArb>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.TeethWhiteningArb
                {
                    ctwaId = Convert.ToInt32(dr["ctwaId"]),
                    ctwa_appId = Convert.ToInt32(dr["ctwa_appId"]),
                    ctwa_1 = dr["ctwa_1"].ToString(),
                    ctwa_status = dr["ctwa_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveTeethWhiteningArb(BusinessEntities.ConsentForms.TeethWhiteningArb dental, int madeby)
        {
            return DataAccessLayer.ConsentForms.TeethWhiteningArb.SaveTeethWhiteningArb(dental, madeby);
        }
        public static int DeleteTeethWhiteningArb(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.TeethWhiteningArb.DeleteTeethWhiteningArb(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetTeethWhiteningArbPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TeethWhiteningArb.GetTeethWhiteningArbPreviousHistory(appId);
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
