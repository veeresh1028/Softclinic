using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeChalazionIncisionNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeChalazionIncisionNew> GetDischargeChalazionIncisionNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeChalazionIncisionNew.GetDischargeChalazionIncisionNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeChalazionIncisionNew> list = new List<BusinessEntities.ConsentForms.DischargeChalazionIncisionNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeChalazionIncisionNew
                {
                    dciId = Convert.ToInt32(dr["dciId"]),
                    dci_appId = Convert.ToInt32(dr["dci_appId"]),
                    dci_1 = dr["dci_1"].ToString(),
                    dci_2 = dr["dci_2"].ToString(),
                    dci_3 = dr["dci_3"].ToString(),
                    dci_4 = dr["dci_4"].ToString(),
                    dci_5 = dr["dci_5"].ToString(),
                    dci_6 = dr["dci_6"].ToString(),
                    dci_7 = dr["dci_7"].ToString(),
                    dci_status = dr["dci_status"].ToString(),
                    dci_date_modified = Convert.ToDateTime(dr["dci_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeChalazionIncisionNew(BusinessEntities.ConsentForms.DischargeChalazionIncisionNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeChalazionIncisionNew.SaveDischargeChalazionIncisionNew(discharge, madeby);
        }


        public static int DeleteDischargeChalazionIncisionNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeChalazionIncisionNew.DeleteDischargeChalazionIncisionNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeChalazionIncisionNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeChalazionIncisionNew.GetDischargeChalazionIncisionNewPreviousHistory(appId);
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
