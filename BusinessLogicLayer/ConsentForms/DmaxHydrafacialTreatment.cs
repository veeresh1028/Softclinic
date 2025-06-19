using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxHydrafacialTreatment
    {
        public static List<BusinessEntities.ConsentForms.DmaxHydrafacialTreatment> GetDmaxHydrafacialTreatmentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxHydrafacialTreatment.GetDmaxHydrafacialTreatmentData(appId);
            List<BusinessEntities.ConsentForms.DmaxHydrafacialTreatment> list = new List<BusinessEntities.ConsentForms.DmaxHydrafacialTreatment>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxHydrafacialTreatment
                {
                    dhtId = Convert.ToInt32(dr["dhtId"]),
                    dht_appId = Convert.ToInt32(dr["dht_appId"]),
                    dht_1 = dr["dht_1"].ToString(),
                    dht_status = dr["dht_status"].ToString(),
                    dht_date_modified = Convert.ToDateTime(dr["dht_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxHydrafacialTreatment(BusinessEntities.ConsentForms.DmaxHydrafacialTreatment dmax, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxHydrafacialTreatment.SaveDmaxHydrafacialTreatment(dmax, madeby);
        }
        public static int DeleteDmaxHydrafacialTreatment(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxHydrafacialTreatment.DeleteDmaxHydrafacialTreatment(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxHydrafacialTreatmentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxHydrafacialTreatment.GetDmaxHydrafacialTreatmentPreviousHistory(appId);
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
