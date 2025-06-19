using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MicroInformed
    {
        public static List<BusinessEntities.ConsentForms.MicroInformed> GetMicroInformedData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MicroInformed.GetMicroInformedData(appId);
            List<BusinessEntities.ConsentForms.MicroInformed> list = new List<BusinessEntities.ConsentForms.MicroInformed>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MicroInformed
                {
                    micId = Convert.ToInt32(dr["micId"]),
                    mic_appId = Convert.ToInt32(dr["mic_appId"]),
                    mic_1 = dr["mic_1"].ToString(),
                    mic_status = dr["mic_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveMicroInformed(BusinessEntities.ConsentForms.MicroInformed micro, int madeby)
        {
            return DataAccessLayer.ConsentForms.MicroInformed.SaveMicroInformed(micro, madeby);
        }

        public static int DeleteMicroInformed(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MicroInformed.DeleteMicroInformed(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetMicroInformedPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MicroInformed.GetMicroInformedPreviousHistory(appId);
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
