using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class OrthoElastic
    {
        public static List<BusinessEntities.ConcentForms.OrthoElastic> GetOrthoElasticData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthoElastic.GetOrthoElasticData(appId);
            List<BusinessEntities.ConcentForms.OrthoElastic> list = new List<BusinessEntities.ConcentForms.OrthoElastic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.OrthoElastic
                {
                    oeId = Convert.ToInt32(dr["oeId"]),
                    oe_appId = Convert.ToInt32(dr["oe_appId"]),
                    oe_status = dr["oe_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveOrthoElastic(BusinessEntities.ConcentForms.OrthoElastic tooth, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthoElastic.SaveOrthoElastic(tooth, madeby);
        }

        public static int DeleteOrthoElastic(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthoElastic.DeleteOrthoElastic(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOrthoElasticPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthoElastic.GetOrthoElasticPreviousHistory(appId);
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
