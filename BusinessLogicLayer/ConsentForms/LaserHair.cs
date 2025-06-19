using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserHair
    {
        public static List<BusinessEntities.ConsentForms.LaserHair> GetLaserHairData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHair.GetLaserHairData(appId);
            List<BusinessEntities.ConsentForms.LaserHair> list = new List<BusinessEntities.ConsentForms.LaserHair>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserHair
                {
                    lrccId = Convert.ToInt32(dr["lrccId"]),
                    lrcc_appId = Convert.ToInt32(dr["lrcc_appId"]),
                    lrcc_1 = dr["lrcc_1"].ToString(),
                    lrcc_status = dr["lrcc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveLaserHair(BusinessEntities.ConsentForms.LaserHair laser, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHair.SaveLaserHair(laser, madeby);
        }

        public static int DeleteLaserHair(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHair.DeleteLaserHair(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetLaserHairPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHair.GetLaserHairPreviousHistory(appId);
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
