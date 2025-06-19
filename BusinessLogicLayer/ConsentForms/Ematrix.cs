using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class Ematrix
    {
        public static List<BusinessEntities.ConsentForms.Ematrix> GetEmatrixData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Ematrix.GetEmatrixData(appId);
            List<BusinessEntities.ConsentForms.Ematrix> list = new List<BusinessEntities.ConsentForms.Ematrix>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.Ematrix
                {
                    ecfId = Convert.ToInt32(dr["ecfId"]),
                    ecf_appId = Convert.ToInt32(dr["ecf_appId"]),
                    ecf_status = dr["ecf_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveEmatrix(BusinessEntities.ConsentForms.Ematrix ematrix, int madeby)
        {
            return DataAccessLayer.ConsentForms.Ematrix.SaveEmatrix(ematrix, madeby);
        }

        public static int DeleteEmatrix(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.Ematrix.DeleteEmatrix(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetEmatrixPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Ematrix.GetEmatrixPreviousHistory(appId);
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
