using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ElectroArabicDerma
    {
        public static List<BusinessEntities.ConsentForms.ElectroArabicDerma> GetElectroArabicDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ElectroArabicDerma.GetElectroArabicDermaData(appId);
            List<BusinessEntities.ConsentForms.ElectroArabicDerma> list = new List<BusinessEntities.ConsentForms.ElectroArabicDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ElectroArabicDerma
                {
                    elecaId = Convert.ToInt32(dr["elecaId"]),
                    eleca_appId = Convert.ToInt32(dr["eleca_appId"]),
                    eleca_status = dr["eleca_status"].ToString(),
                    eleca_date_modified = Convert.ToDateTime(dr["eleca_date_modified"].ToString()),
                });
            }
            return list;
        }



        public static int SaveElectroArabicDerma(BusinessEntities.ConsentForms.ElectroArabicDerma electro, int madeby)
        {
            return DataAccessLayer.ConsentForms.ElectroArabicDerma.SaveElectroArabicDerma(electro, madeby);
        }



        public static int DeleteElectroArabicDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ElectroArabicDerma.DeleteElectroArabicDerma(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetElectroArabicDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ElectroArabicDerma.GetElectroArabicDermaPreviousHistory(appId);
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
