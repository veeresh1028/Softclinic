using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class RootCanal
    {
        public static List<BusinessEntities.ConcentForms.RootCanal> GetRootCanalData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.RootCanal.GetRootCanalData(appId);

            List<BusinessEntities.ConcentForms.RootCanal> list = new List<BusinessEntities.ConcentForms.RootCanal>();

            foreach (DataRow dr in dt.Rows)
            {
                   list.Add(new BusinessEntities.ConcentForms.RootCanal
                   {
                    crctId = Convert.ToInt32(dr["crctId"]),
                    crct_appId = Convert.ToInt32(dr["crct_appId"]),
                    crct_1 = dr["crct_1"].ToString(),
                    crct_2 = dr["crct_2"].ToString(),
                    crct_3 = dr["crct_3"].ToString(),
                    crct_4 = dr["crct_4"].ToString(),
                    crct_status = dr["crct_status"].ToString(),

                   });
            }
            return list;
        }
        public static int SaveRootCanal(BusinessEntities.ConcentForms.RootCanal root, int madeby)
        {
            return DataAccessLayer.ConcentForms.RootCanal.SaveRootCanal(root, madeby);
        }
        public static int DeleteRootCanal(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.RootCanal.DeleteRootCanal(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetRootCanalPreviousHistroy(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.RootCanal.GetRootCanalPreviousHistroy(appId);

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
