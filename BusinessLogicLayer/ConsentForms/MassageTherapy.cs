using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MassageTherapy
    {
        public static List<BusinessEntities.ConsentForms.MassageTherapy> GetMassageTherapyData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MassageTherapy.GetMassageTherapyData(appId);
            List<BusinessEntities.ConsentForms.MassageTherapy> list = new List<BusinessEntities.ConsentForms.MassageTherapy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MassageTherapy
                {
                    mtcId = Convert.ToInt32(dr["mtcId"]),
                    mtc_appId = Convert.ToInt32(dr["mtc_appId"]),
                    mtc_1 = dr["mtc_1"].ToString(),
                    mtc_status = dr["mtc_status"].ToString(),
                    mtc_date_modified = Convert.ToDateTime(dr["mtc_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveMassageTherapy(BusinessEntities.ConsentForms.MassageTherapy hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.MassageTherapy.SaveMassageTherapy(hijama, madeby);
        }
        public static int DeleteMassageTherapy(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MassageTherapy.DeleteMassageTherapy(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetMassageTherapyPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MassageTherapy.GetMassageTherapyPreviousHistory(appId);
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
