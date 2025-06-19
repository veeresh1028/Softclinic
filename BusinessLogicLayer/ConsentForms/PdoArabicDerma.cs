using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PdoArabicDerma
    {
        public static List<BusinessEntities.ConsentForms.PdoArabicDerma> GetPdoArabicDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PdoArabicDerma.GetPdoArabicDermaData(appId);
            List<BusinessEntities.ConsentForms.PdoArabicDerma> list = new List<BusinessEntities.ConsentForms.PdoArabicDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PdoArabicDerma
                {
                    pdoaId = Convert.ToInt32(dr["pdoaId"]),
                    pdoa_appId = Convert.ToInt32(dr["pdoa_appId"]),
                    pdoa_status = dr["pdoa_status"].ToString(),
                    pdoa_date_modified = Convert.ToDateTime(dr["pdoa_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SavePdoArabicDerma(BusinessEntities.ConsentForms.PdoArabicDerma pdo, int madeby)
        {
            return DataAccessLayer.ConsentForms.PdoArabicDerma.SavePdoArabicDerma(pdo, madeby);
        }


        public static int DeletePdoArabicDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PdoArabicDerma.DeletePdoArabicDerma(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPdoArabicDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PdoArabicDerma.GetPdoArabicDermaPreviousHistory(appId);
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
