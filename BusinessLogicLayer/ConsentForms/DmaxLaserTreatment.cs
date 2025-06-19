using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxLaserTreatment
    {
        public static List<BusinessEntities.ConsentForms.DmaxLaserTreatment> GetDmaxLaserTreatmentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxLaserTreatment.GetDmaxLaserTreatmentData(appId);
            List<BusinessEntities.ConsentForms.DmaxLaserTreatment> list = new List<BusinessEntities.ConsentForms.DmaxLaserTreatment>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxLaserTreatment
                {
                    dltId = Convert.ToInt32(dr["dltId"]),
                    dlt_appId = Convert.ToInt32(dr["dlt_appId"]),
                    dlt_1 = dr["dlt_1"].ToString(),
                    dlt_status = dr["dlt_status"].ToString(),
                    dlt_date_modified = Convert.ToDateTime(dr["dlt_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxLaserTreatment(BusinessEntities.ConsentForms.DmaxLaserTreatment dmax, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxLaserTreatment.SaveDmaxLaserTreatment(dmax, madeby);
        }
        public static int DeleteDmaxLaserTreatment(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxLaserTreatment.DeleteDmaxLaserTreatment(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxLaserTreatmentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxLaserTreatment.GetDmaxLaserTreatmentPreviousHistory(appId);
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
