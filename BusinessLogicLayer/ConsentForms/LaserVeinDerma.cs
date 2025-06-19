using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserVeinDerma
    {
        public static List<BusinessEntities.ConsentForms.LaserVeinDerma> GetLaserVeinDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserVeinDerma.GetLaserVeinDermaData(appId);
            List<BusinessEntities.ConsentForms.LaserVeinDerma> list = new List<BusinessEntities.ConsentForms.LaserVeinDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserVeinDerma
                {
                    lvcId = Convert.ToInt32(dr["lvcId"]),
                    lvc_appId = Convert.ToInt32(dr["lvc_appId"]),
                    lvc_1 = dr["lvc_1"].ToString(),
                    lvc_2 = dr["lvc_2"].ToString(),
                    lvc_status = dr["lvc_status"].ToString(),
                });
            }
            return list;
        }



        public static int SaveLaserVeinDerma(BusinessEntities.ConsentForms.LaserVeinDerma laser, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserVeinDerma.SaveLaserVeinDerma(laser, madeby);
        }


        public static int DeleteLaserVeinDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserVeinDerma.DeleteLaserVeinDerma(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetLaserVeinDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserVeinDerma.GetLaserVeinDermaPreviousHistory(appId);
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
