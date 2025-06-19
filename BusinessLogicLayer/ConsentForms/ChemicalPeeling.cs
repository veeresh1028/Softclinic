using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ChemicalPeeling
    {
        public static List<BusinessEntities.ConsentForms.ChemicalPeeling> GetChemicalPeelingData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ChemicalPeeling.GetChemicalPeelingData(appId);
            List<BusinessEntities.ConsentForms.ChemicalPeeling> list = new List<BusinessEntities.ConsentForms.ChemicalPeeling>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ChemicalPeeling
                {
                    cpfId = Convert.ToInt32(dr["cpfId"]),
                    cpf_appId = Convert.ToInt32(dr["cpf_appId"]),
                    cpf_1 = dr["cpf_1"].ToString(),
                    cpf_status = dr["cpf_status"].ToString(),
                    cpf_date_modified = Convert.ToDateTime(dr["cpf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveChemicalPeeling(BusinessEntities.ConsentForms.ChemicalPeeling derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.ChemicalPeeling.SaveChemicalPeeling(derma, madeby);
        }
        public static int DeleteChemicalPeeling(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ChemicalPeeling.DeleteChemicalPeeling(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetChemicalPeelingPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ChemicalPeeling.GetChemicalPeelingPreviousHistory(appId);
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
