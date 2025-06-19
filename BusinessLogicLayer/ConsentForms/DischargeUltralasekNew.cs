using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeUltralasekNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeUltralasekNew> GetDischargeUltralasekNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeUltralasekNew.GetDischargeUltralasekNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeUltralasekNew> list = new List<BusinessEntities.ConsentForms.DischargeUltralasekNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeUltralasekNew
                {
                    dutId = Convert.ToInt32(dr["dutId"]),
                    dut_appId = Convert.ToInt32(dr["dut_appId"]),
                    dut_1 = dr["dut_1"].ToString(),
                    dut_2 = dr["dut_2"].ToString(),
                    dut_3 = dr["dut_3"].ToString(),
                    dut_4 = dr["dut_4"].ToString(),
                    dut_5 = dr["dut_5"].ToString(),
                    dut_6 = dr["dut_6"].ToString(),
                    dut_status = dr["dut_status"].ToString(),
                    dut_date_modified = Convert.ToDateTime(dr["dut_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveDischargeUltralasekNew(BusinessEntities.ConsentForms.DischargeUltralasekNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeUltralasekNew.SaveDischargeUltralasekNew(discharge, madeby);
        }


        public static int DeleteDischargeUltralasekNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeUltralasekNew.DeleteDischargeUltralasekNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeUltralasekNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeUltralasekNew.GetDischargeUltralasekNewPreviousHistory(appId);
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
