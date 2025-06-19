using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserHairArbDerma
    {
        public static List<BusinessEntities.ConsentForms.LaserHairArbDerma> GetLaserHairArbDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHairArbDerma.GetLaserHairArbDermaData(appId);
            List<BusinessEntities.ConsentForms.LaserHairArbDerma> list = new List<BusinessEntities.ConsentForms.LaserHairArbDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserHairArbDerma
                {
                    lhaId = Convert.ToInt32(dr["lhaId"]),
                    lha_appId = Convert.ToInt32(dr["lha_appId"]),
                    lha_status = dr["lha_status"].ToString(),
                    lha_date_modified = Convert.ToDateTime(dr["lha_date_modified"].ToString()),
                });
            }
            return list;
        }



        public static int SaveLaserHairArbDerma(BusinessEntities.ConsentForms.LaserHairArbDerma laser, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHairArbDerma.SaveLaserHairArbDerma(laser, madeby);
        }


        public static int DeleteLaserHairArbDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHairArbDerma.DeleteLaserHairArbDerma(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetLaserHairArbDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHairArbDerma.GetLaserHairArbDermaPreviousHistory(appId);
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
