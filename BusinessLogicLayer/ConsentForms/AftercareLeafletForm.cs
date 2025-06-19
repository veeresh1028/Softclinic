using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class AftercareLeafletForm
    {
        public static List<BusinessEntities.ConsentForms.AftercareLeafletForm> GetAftercareLeafletFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AftercareLeafletForm.GetAftercareLeafletFormData(appId);
            List<BusinessEntities.ConsentForms.AftercareLeafletForm> list = new List<BusinessEntities.ConsentForms.AftercareLeafletForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.AftercareLeafletForm
                {
                    alfId = Convert.ToInt32(dr["alfId"]),
                    alf_appId = Convert.ToInt32(dr["alf_appId"]),
                    alf_status = dr["alf_status"].ToString(),
                    alf_date_modified = Convert.ToDateTime(dr["alf_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveAftercareLeafletForm(BusinessEntities.ConsentForms.AftercareLeafletForm after, int madeby)
        {
            return DataAccessLayer.ConsentForms.AftercareLeafletForm.SaveAftercareLeafletForm(after, madeby);
        }
        public static int DeleteAftercareLeafletForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.AftercareLeafletForm.DeleteAftercareLeafletForm(appId, madeby);
        }
        
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetAftercareLeafletFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AftercareLeafletForm.GetAftercareLeafletFormPreviousHistroy(appId);
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
