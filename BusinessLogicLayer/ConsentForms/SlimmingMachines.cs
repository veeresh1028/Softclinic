using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class SlimmingMachines
    {
        public static List<BusinessEntities.ConsentForms.SlimmingMachines> GetSlimmingMachinesData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SlimmingMachines.GetSlimmingMachinesData(appId);
            List<BusinessEntities.ConsentForms.SlimmingMachines> list = new List<BusinessEntities.ConsentForms.SlimmingMachines>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SlimmingMachines
                {
                    smfId = Convert.ToInt32(dr["smfId"]),
                    smf_appId = Convert.ToInt32(dr["smf_appId"]),
                    smf_1 = dr["smf_1"].ToString(),
                    smf_status = dr["smf_status"].ToString(),
                    smf_date_modified = Convert.ToDateTime(dr["smf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveSlimmingMachines(BusinessEntities.ConsentForms.SlimmingMachines ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.SlimmingMachines.SaveSlimmingMachines(ophtha, madeby);
        }
        public static int DeleteSlimmingMachines(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.SlimmingMachines.DeleteSlimmingMachines(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetSlimmingMachinesPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SlimmingMachines.GetSlimmingMachinesPreviousHistory(appId);
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
