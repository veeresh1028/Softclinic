using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxFractionalLaser
    {
        public static List<BusinessEntities.ConsentForms.DmaxFractionalLaser> GetDmaxFractionalLaserData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxFractionalLaser.GetDmaxFractionalLaserData(appId);
            List<BusinessEntities.ConsentForms.DmaxFractionalLaser> list = new List<BusinessEntities.ConsentForms.DmaxFractionalLaser>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxFractionalLaser
                {
                    dfcId = Convert.ToInt32(dr["dfcId"]),
                    dfc_appId = Convert.ToInt32(dr["dfc_appId"]),
                    dfc_1 = dr["dfc_1"].ToString(),
                    dfc_status = dr["dfc_status"].ToString(),
                    dfc_date_modified = Convert.ToDateTime(dr["dfc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxFractionalLaser(BusinessEntities.ConsentForms.DmaxFractionalLaser dmax, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxFractionalLaser.SaveDmaxFractionalLaser(dmax, madeby);
        }
        public static int DeleteDmaxFractionalLaser(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxFractionalLaser.DeleteDmaxFractionalLaser(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxFractionalLaserPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxFractionalLaser.GetDmaxFractionalLaserPreviousHistory(appId);
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
