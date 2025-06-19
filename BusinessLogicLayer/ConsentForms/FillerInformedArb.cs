using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FillerInformedArb
    {
        public static List<BusinessEntities.ConsentForms.FillerInformedArb> GetFillerInformedArbData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerInformedArb.GetFillerInformedArbData(appId);
            List<BusinessEntities.ConsentForms.FillerInformedArb> list = new List<BusinessEntities.ConsentForms.FillerInformedArb>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FillerInformedArb
                {
                    ficaId = Convert.ToInt32(dr["ficaId"]),
                    fica_appId = Convert.ToInt32(dr["fica_appId"]),
                    fica_1 = dr["fica_1"].ToString(),
                    fica_status = dr["fica_status"].ToString(),
                    fica_date_modified = Convert.ToDateTime(dr["fica_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveFillerInformedArb(BusinessEntities.ConsentForms.FillerInformedArb derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerInformedArb.SaveFillerInformedArb(derma, madeby);
        }
        public static int DeleteFillerInformedArb(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerInformedArb.DeleteFillerInformedArb(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetFillerInformedArbPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerInformedArb.GetFillerInformedArbPreviousHistory(appId);
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
