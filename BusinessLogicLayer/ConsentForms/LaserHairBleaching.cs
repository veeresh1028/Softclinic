using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserHairBleaching
    {
        public static List<BusinessEntities.ConsentForms.LaserHairBleaching> GetLaserHairBleachingData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHairBleaching.GetLaserHairBleachingData(appId);
            List<BusinessEntities.ConsentForms.LaserHairBleaching> list = new List<BusinessEntities.ConsentForms.LaserHairBleaching>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserHairBleaching
                {
                    clhId = Convert.ToInt32(dr["clhId"]),
                    clh_appId = Convert.ToInt32(dr["clh_appId"]),
                    clh_status = dr["clh_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveLaserHairBleaching(BusinessEntities.ConsentForms.LaserHairBleaching tooth, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHairBleaching.SaveLaserHairBleaching(tooth, madeby);
        }
        public static int DeleteLaserHairBleaching(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHairBleaching.DeleteLaserHairBleaching(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLaserHairBleachingPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHairBleaching.GetLaserHairBleachingPreviousHistory(appId);
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
