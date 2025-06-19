using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class ToothFillings
    {
        public static List<BusinessEntities.ConcentForms.ToothFillings> GetToothFillingsData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ToothFillings.GetToothFillingsData(appId);
            List<BusinessEntities.ConcentForms.ToothFillings> list = new List<BusinessEntities.ConcentForms.ToothFillings>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ToothFillings
                {
                    itfId = Convert.ToInt32(dr["itfId"]),
                    itf_appId = Convert.ToInt32(dr["itf_appId"]),
                    itf_1 = dr["itf_1"].ToString(),
                    itf_2 = dr["itf_2"].ToString(),
                    itf_status = dr["itf_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveToothFillings(BusinessEntities.ConcentForms.ToothFillings tooth, int madeby)
        {
            return DataAccessLayer.ConcentForms.ToothFillings.SaveToothFillings(tooth, madeby);
        }

        public static int DeleteToothFillings(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.ToothFillings.DeleteToothFillings(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetToothFillingsPreviousHistroy(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.ToothFillings.GetToothFillingsPreviousHistroy(appId);
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
