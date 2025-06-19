using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OperativeUltralasikNew
    {
        public static List<BusinessEntities.ConsentForms.OperativeUltralasikNew> GetOperativeUltralasikNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeUltralasikNew.GetOperativeUltralasikNewData(appId);
            List<BusinessEntities.ConsentForms.OperativeUltralasikNew> list = new List<BusinessEntities.ConsentForms.OperativeUltralasikNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OperativeUltralasikNew
                {
                    oriuId = Convert.ToInt32(dr["oriuId"]),
                    oriu_appId = Convert.ToInt32(dr["oriu_appId"]),
                    oriu_1 = dr["oriu_1"].ToString(),
                    oriu_2 = dr["oriu_2"].ToString(),
                    oriu_3 = dr["oriu_3"].ToString(),
                    oriu_4 = dr["oriu_4"].ToString(),
                    oriu_5 = dr["oriu_5"].ToString(),
                    oriu_6 = dr["oriu_6"].ToString(),
                    oriu_status = dr["oriu_status"].ToString(),
                    oriu_date_modified = Convert.ToDateTime(dr["oriu_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveOperativeUltralasikNew(BusinessEntities.ConsentForms.OperativeUltralasikNew operative, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeUltralasikNew.SaveOperativeUltralasikNew(operative, madeby);
        }

        public static int DeleteOperativeUltralasikNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeUltralasikNew.DeleteOperativeUltralasikNew(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOperativeUltralasikNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeUltralasikNew.GetOperativeUltralasikNewPreviousHistory(appId);
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
