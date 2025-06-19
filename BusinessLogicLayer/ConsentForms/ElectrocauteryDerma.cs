using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ElectrocauteryDerma
    {
        public static List<BusinessEntities.ConsentForms.ElectrocauteryDerma> GetElectrocauteryDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ElectrocauteryDerma.GetElectrocauteryDermaData(appId);
            List<BusinessEntities.ConsentForms.ElectrocauteryDerma> list = new List<BusinessEntities.ConsentForms.ElectrocauteryDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ElectrocauteryDerma
                {
                    elecId = Convert.ToInt32(dr["elecId"]),
                    elec_appId = Convert.ToInt32(dr["elec_appId"]),
                    elec_1 = dr["elec_1"].ToString(),
                    elec_2 = dr["elec_2"].ToString(),
                    elec_3 = dr["elec_3"].ToString(),
                    elec_status = dr["elec_status"].ToString(),
                    elec_date_modified = Convert.ToDateTime(dr["elec_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveElectrocauteryDerma(BusinessEntities.ConsentForms.ElectrocauteryDerma electro, int madeby)
        {
            return DataAccessLayer.ConsentForms.ElectrocauteryDerma.SaveElectrocauteryDerma(electro, madeby);
        }
        public static int DeleteElectrocauteryDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ElectrocauteryDerma.DeleteElectrocauteryDerma(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetElectrocauteryDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ElectrocauteryDerma.GetElectrocauteryDermaPreviousHistory(appId);
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
