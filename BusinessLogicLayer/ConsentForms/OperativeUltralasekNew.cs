using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OperativeUltralasekNew
    {
        public static List<BusinessEntities.ConsentForms.OperativeUltralasekNew> GetOperativeUltralasekNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeUltralasekNew.GetOperativeUltralasekNewData(appId);
            List<BusinessEntities.ConsentForms.OperativeUltralasekNew> list = new List<BusinessEntities.ConsentForms.OperativeUltralasekNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OperativeUltralasekNew
                {
                    oreuId = Convert.ToInt32(dr["oreuId"]),
                    oreu_appId = Convert.ToInt32(dr["oreu_appId"]),
                    oreu_1 = dr["oreu_1"].ToString(),
                    oreu_2 = dr["oreu_2"].ToString(),
                    oreu_status = dr["oreu_status"].ToString(),
                    oreu_date_modified = Convert.ToDateTime(dr["oreu_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveOperativeUltralasekNew(BusinessEntities.ConsentForms.OperativeUltralasekNew operative, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeUltralasekNew.SaveOperativeUltralasekNew(operative, madeby);
        }


        public static int DeleteOperativeUltralasekNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OperativeUltralasekNew.DeleteOperativeUltralasekNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOperativeUltralasekNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OperativeUltralasekNew.GetOperativeUltralasekNewPreviousHistory(appId);
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
