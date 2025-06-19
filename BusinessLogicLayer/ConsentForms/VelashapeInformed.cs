using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class VelashapeInformed
    {
        public static List<BusinessEntities.ConsentForms.VelashapeInformed> GetVelashapeInformedData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.VelashapeInformed.GetVelashapeInformedData(appId);
            List<BusinessEntities.ConsentForms.VelashapeInformed> list = new List<BusinessEntities.ConsentForms.VelashapeInformed>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.VelashapeInformed
                {
                    vicId = Convert.ToInt32(dr["vicId"]),
                    vic_appId = Convert.ToInt32(dr["vic_appId"]),
                    vic_1 = dr["vic_1"].ToString(),
                    vic_status = dr["vic_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveVelashapeInformed(BusinessEntities.ConsentForms.VelashapeInformed velashape, int madeby)
        {
            return DataAccessLayer.ConsentForms.VelashapeInformed.SaveVelashapeInformed(velashape, madeby);
        }

        public static int DeleteVelashapeInformed(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.VelashapeInformed.DeleteVelashapeInformed(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetVelashapeInformedPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.VelashapeInformed.GetVelashapeInformedPreviousHistory(appId);
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
