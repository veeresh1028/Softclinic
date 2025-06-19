using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ThreadLift

    {
        public static List<BusinessEntities.ConsentForms.ThreadLift> GetThreadLiftData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ThreadLift.GetThreadLiftData(appId);
            List<BusinessEntities.ConsentForms.ThreadLift> list = new List<BusinessEntities.ConsentForms.ThreadLift>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ThreadLift
                {
                    tlcId = Convert.ToInt32(dr["tlcId"]),
                    tlc_appId = Convert.ToInt32(dr["tlc_appId"]),
                    tlc_1 = dr["tlc_1"].ToString(),
                    tlc_2 = dr["tlc_2"].ToString(),
                    tlc_3 = dr["tlc_3"].ToString(),
                    tlc_4 = dr["tlc_4"].ToString(),
                    tlc_5 = dr["tlc_5"].ToString(),
                    tlc_6 = dr["tlc_6"].ToString(),
                    tlc_7 = dr["tlc_7"].ToString(),
                    tlc_8 = dr["tlc_8"].ToString(),
                    tlc_status = dr["tlc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveThreadLift(BusinessEntities.ConsentForms.ThreadLift thread, int madeby)
        {
            return DataAccessLayer.ConsentForms.ThreadLift.SaveThreadLift(thread, madeby);
        }

        public static int DeleteThreadLift(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ThreadLift.DeleteThreadLift(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetThreadLiftPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ThreadLift.GetThreadLiftPreviousHistory(appId);
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
