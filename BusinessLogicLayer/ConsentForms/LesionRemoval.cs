using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LesionRemoval
    {
        public static List<BusinessEntities.ConsentForms.LesionRemoval> GetLesionRemovalData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LesionRemoval.GetLesionRemovalData(appId);
            List<BusinessEntities.ConsentForms.LesionRemoval> list = new List<BusinessEntities.ConsentForms.LesionRemoval>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LesionRemoval
                {
                    lrcId = Convert.ToInt32(dr["lrcId"]),
                    lrc_appId = Convert.ToInt32(dr["lrc_appId"]),
                    lrc_1 = dr["lrc_1"].ToString(),
                    lrc_status = dr["lrc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveLesionRemoval(BusinessEntities.ConsentForms.LesionRemoval lesion, int madeby)
        {
            return DataAccessLayer.ConsentForms.LesionRemoval.SaveLesionRemoval(lesion, madeby);
        }

        public static int DeleteLesionRemoval(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LesionRemoval.DeleteLesionRemoval(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetLesionRemovalPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LesionRemoval.GetLesionRemovalPreviousHistory(appId);
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
