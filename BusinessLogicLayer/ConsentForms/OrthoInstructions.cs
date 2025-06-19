using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class OrthoInstructions
    {

        public static List<BusinessEntities.ConcentForms.OrthoInstructions> GetOrthoInstructionsData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthoInstructions.GetOrthoInstructionsData(appId);
            List<BusinessEntities.ConcentForms.OrthoInstructions> list = new List<BusinessEntities.ConcentForms.OrthoInstructions>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.OrthoInstructions
                {
                    oiId = Convert.ToInt32(dr["oiId"]),
                    oi_appId = Convert.ToInt32(dr["oi_appId"]),
                    oi_status = dr["oi_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveOrthoInstructions(BusinessEntities.ConcentForms.OrthoInstructions tooth, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthoInstructions.SaveOrthoInstructions(tooth, madeby);
        }
        public static int DeleteOrthoInstructions(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthoInstructions.DeleteOrthoInstructions(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOrthoInstructionsPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthoInstructions.GetOrthoInstructionsPreviousHistory(appId);
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
