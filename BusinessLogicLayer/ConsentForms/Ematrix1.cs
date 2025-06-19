using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class Ematrix1
    {
        public static List<BusinessEntities.ConsentForms.Ematrix1> GetEmatrix1Data(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Ematrix1.GetEmatrix1Data(appId);
            List<BusinessEntities.ConsentForms.Ematrix1> list = new List<BusinessEntities.ConsentForms.Ematrix1>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.Ematrix1
                {
                    cefId = Convert.ToInt32(dr["cefId"]),
                    cef_appId = Convert.ToInt32(dr["cef_appId"]),
                    cef_1 = dr["cef_1"].ToString(),
                    cef_status = dr["cef_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveEmatrix1(BusinessEntities.ConsentForms.Ematrix1 ematrix, int madeby)
        {
            return DataAccessLayer.ConsentForms.Ematrix1.SaveEmatrix1(ematrix, madeby);
        }

        public static int DeleteEmatrix1(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.Ematrix1.DeleteEmatrix1(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetEmatrix1PreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Ematrix1.GetEmatrix1PreviousHistory(appId);
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
