using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class NasPrescriptionClaim
    {
        public static List<BusinessEntities.InsuranceForms.NasPrescriptionClaim> GetNasPrescriptionClaimData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NasPrescriptionClaim.GetNasPrescriptionClaimData(appId);
            List<BusinessEntities.InsuranceForms.NasPrescriptionClaim> list = new List<BusinessEntities.InsuranceForms.NasPrescriptionClaim>();

            foreach (DataRow dr in dt.Rows)
            {

                list.Add(new BusinessEntities.InsuranceForms.NasPrescriptionClaim
                {
                    npcId = Convert.ToInt32(dr["npcId"]),
                    npc_appId = Convert.ToInt32(dr["npc_appId"]),

                    npc_1 = dr["npc_1"].ToString(),
                    npc_chk = dr["npc_chk"].ToString(),
                    
                    npc_status = dr["npc_status"].ToString(),
                    npc_date_modified = Convert.ToDateTime(dr["npc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveNasPrescriptionClaim(BusinessEntities.InsuranceForms.NasPrescriptionClaim medical, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NasPrescriptionClaim.SaveNasPrescriptionClaim(medical, madeby);
        }
        public static int DeleteNasPrescriptionClaim(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.NasPrescriptionClaim.DeleteNasPrescriptionClaim(appId, madeby);
        }
        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetNasPrescriptionClaimPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.NasPrescriptionClaim.GetNasPrescriptionClaimPreviousHistory(appId);
            List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> list = new List<BusinessEntities.InsuranceForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.ConcentPreviousHistory
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
