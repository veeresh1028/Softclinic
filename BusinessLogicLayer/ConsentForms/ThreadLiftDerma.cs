using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ThreadLiftDerma
    {
        public static List<BusinessEntities.ConsentForms.ThreadLiftDerma> GetThreadLiftDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ThreadLiftDerma.GetThreadLiftDermaData(appId);
            List<BusinessEntities.ConsentForms.ThreadLiftDerma> list = new List<BusinessEntities.ConsentForms.ThreadLiftDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ThreadLiftDerma
                {
                    tlfId = Convert.ToInt32(dr["tlfId"]),
                    tlf_appId = Convert.ToInt32(dr["tlf_appId"]),
                    tlf_1 = dr["tlf_1"].ToString(),
                    tlf_status = dr["tlf_status"].ToString(),
                    tlf_date_modified = Convert.ToDateTime(dr["tlf_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveThreadLiftDerma(BusinessEntities.ConsentForms.ThreadLiftDerma thread, int madeby)
        {
            return DataAccessLayer.ConsentForms.ThreadLiftDerma.SaveThreadLiftDerma(thread, madeby);
        }


        public static int DeleteThreadLiftDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ThreadLiftDerma.DeleteThreadLiftDerma(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetThreadLiftDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ThreadLiftDerma.GetThreadLiftDermaPreviousHistory(appId);
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
