using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserLightening
    {
        public static List<BusinessEntities.ConsentForms.LaserLightening> GetLaserLighteningData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserLightening.GetLaserLighteningData(appId);
            List<BusinessEntities.ConsentForms.LaserLightening> list = new List<BusinessEntities.ConsentForms.LaserLightening>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserLightening
                {
                    cllId = Convert.ToInt32(dr["cllId"]),
                    cll_appId = Convert.ToInt32(dr["cll_appId"]),
                    cll_status = dr["cll_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveLaserLightening(BusinessEntities.ConsentForms.LaserLightening laser, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserLightening.SaveLaserLightening(laser, madeby);
        }

        public static int DeleteLaserLightening(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserLightening.DeleteLaserLightening(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetLaserLighteningPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserLightening.GetLaserLighteningPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
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
