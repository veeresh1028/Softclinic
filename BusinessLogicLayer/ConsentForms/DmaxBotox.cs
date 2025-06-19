using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxBotox
    {
        public static List<BusinessEntities.ConsentForms.DmaxBotox> GetDmaxBotoxData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxBotox.GetDmaxBotoxData(appId);
            List<BusinessEntities.ConsentForms.DmaxBotox> list = new List<BusinessEntities.ConsentForms.DmaxBotox>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxBotox
                {
                    cdbId = Convert.ToInt32(dr["cdbId"]),
                    cdb_appId = Convert.ToInt32(dr["cdb_appId"]),
                    cdb_1 = dr["cdb_1"].ToString(),
                    cdb_status = dr["cdb_status"].ToString(),
                    cdb_date_modified = Convert.ToDateTime(dr["cdb_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxBotox(BusinessEntities.ConsentForms.DmaxBotox derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxBotox.SaveDmaxBotox(derma, madeby);
        }
        public static int DeleteDmaxBotox(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxBotox.DeleteDmaxBotox(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxBotoxPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxBotox.GetDmaxBotoxPreviousHistory(appId);
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
