using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserSession
    {
        public static List<BusinessEntities.ConsentForms.LaserSession> GetLaserSessionData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserSession.GetLaserSessionData(appId);
            List<BusinessEntities.ConsentForms.LaserSession> list = new List<BusinessEntities.ConsentForms.LaserSession>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserSession
                {
                    lsrId = Convert.ToInt32(dr["lsrId"]),
                    lsr_appId = Convert.ToInt32(dr["lsr_appId"]),
                    lsr_1 = dr["lsr_1"].ToString(),
                    lsr_2 = dr["lsr_2"].ToString(),
                    lsr_3 = dr["lsr_3"].ToString(),
                    lsr_4 = dr["lsr_4"].ToString(),
                    lsr_5 = dr["lsr_5"].ToString(),
                    lsr_6 = dr["lsr_6"].ToString(),
                    lsr_7 = dr["lsr_7"].ToString(),
                    lsr_8 = dr["lsr_8"].ToString(),
                    lsr_9 = dr["lsr_9"].ToString(),
                    lsr_10 = dr["lsr_10"].ToString(),
                    lsr_11 = dr["lsr_11"].ToString(),
                    lsr_doc = dr["lsr_doc"].ToString(),
                    lsr_status = dr["lsr_status"].ToString(),
                    lsr_date_modified = Convert.ToDateTime(dr["lsr_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveLaserSession(BusinessEntities.ConsentForms.LaserSession laser, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserSession.SaveLaserSession(laser, madeby);
        }
        public static int DeleteLaserSession(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserSession.DeleteLaserSession(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLaserSessionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserSession.GetLaserSessionPreviousHistory(appId);
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
