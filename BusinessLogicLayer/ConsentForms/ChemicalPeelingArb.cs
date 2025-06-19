using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ChemicalPeelingArb
    {
        public static List<BusinessEntities.ConsentForms.ChemicalPeelingArb> GetChemicalPeelingArbData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ChemicalPeelingArb.GetChemicalPeelingArbData(appId);
            List<BusinessEntities.ConsentForms.ChemicalPeelingArb> list = new List<BusinessEntities.ConsentForms.ChemicalPeelingArb>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ChemicalPeelingArb
                {
                    cpfaId = Convert.ToInt32(dr["cpfaId"]),
                    cpfa_appId = Convert.ToInt32(dr["cpfa_appId"]),
                    cpfa_1 = dr["cpfa_1"].ToString(),
                    cpfa_status = dr["cpfa_status"].ToString(),
                    cpfa_date_modified = Convert.ToDateTime(dr["cpfa_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveChemicalPeelingArb(BusinessEntities.ConsentForms.ChemicalPeelingArb derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.ChemicalPeelingArb.SaveChemicalPeelingArb(derma, madeby);
        }
        public static int DeleteChemicalPeelingArb(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ChemicalPeelingArb.DeleteChemicalPeelingArb(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetChemicalPeelingArbPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ChemicalPeelingArb.GetChemicalPeelingArbPreviousHistory(appId);
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
