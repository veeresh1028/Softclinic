using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeSummaryEylea
    {
        public static List<BusinessEntities.ConsentForms.DischargeSummaryEylea> GetDischargeSummaryEyleaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryEylea.GetDischargeSummaryEyleaData(appId);
            List<BusinessEntities.ConsentForms.DischargeSummaryEylea> list = new List<BusinessEntities.ConsentForms.DischargeSummaryEylea>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeSummaryEylea
                {
                    dsejId = Convert.ToInt32(dr["dsejId"]),
                    dsej_appId = Convert.ToInt32(dr["dsej_appId"]),
                    dsej_1 = dr["dsej_1"].ToString(),
                    dsej_2 = dr["dsej_2"].ToString(),
                    dsej_3 = dr["dsej_3"].ToString(),
                    dsej_4 = dr["dsej_4"].ToString(),
                    dsej_5 = dr["dsej_5"].ToString(),
                    dsej_6 = dr["dsej_6"].ToString(),
                    dsej_status = dr["dsej_status"].ToString(),
                    dsej_date_modified = Convert.ToDateTime(dr["dsej_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeSummaryEylea(BusinessEntities.ConsentForms.DischargeSummaryEylea discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryEylea.SaveDischargeSummaryEylea(discharge, madeby);
        }


        public static int DeleteDischargeSummaryEylea(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryEylea.DeleteDischargeSummaryEylea(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeSummaryEyleaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryEylea.GetDischargeSummaryEyleaPreviousHistory(appId);
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
