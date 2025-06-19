using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class TattoRemoval
    {
        public static List<BusinessEntities.ConsentForms.TattoRemoval> GetTattoRemovalData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TattoRemoval.GetTattoRemovalData(appId);
            List<BusinessEntities.ConsentForms.TattoRemoval> list = new List<BusinessEntities.ConsentForms.TattoRemoval>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.TattoRemoval
                {
                    trrId = Convert.ToInt32(dr["trrId"]),
                    trr_appId = Convert.ToInt32(dr["trr_appId"]),
                    trr_status = dr["trr_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveTattoRemoval(BusinessEntities.ConsentForms.TattoRemoval tatto, int madeby)
        {
            return DataAccessLayer.ConsentForms.TattoRemoval.SaveTattoRemoval(tatto, madeby);
        }

        public static int DeleteTattoRemoval(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.TattoRemoval.DeleteTattoRemoval(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetTattoRemovalPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.TattoRemoval.GetTattoRemovalPreviousHistory(appId);
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
