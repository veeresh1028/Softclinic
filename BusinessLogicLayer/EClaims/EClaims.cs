using BusinessEntities.EClaims;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EClaims
{
    public class EClaims
    {
        public static List<BusinessEntities.EClaims.Submissions> GetInvoicesSubmissions(SubmissionsSearch inv)
        {
            DataTable dt = DataAccessLayer.EClaims.EClaims.GetInvoicesSubmissions(inv);
            List<BusinessEntities.EClaims.Submissions> list = new List<BusinessEntities.EClaims.Submissions>();

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.EClaims.Submissions i = new BusinessEntities.EClaims.Submissions();

                i.invId = int.Parse(dr["invId"].ToString());
                i.appId = int.Parse(dr["appId"].ToString());
                i.patId = int.Parse(dr["patId"].ToString());
                i.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                i.inv_remit_flag = dr["inv_remit_flag"].ToString();
                i.inv_ic_code = dr["inv_ic_code"].ToString();
                i.app_ip_code = dr["app_ip_code"].ToString();
                i.inv_pi_polocyno = dr["inv_pi_polocyno"].ToString();
                i.inv_pi_insno = dr["inv_pi_insno"].ToString();
                i.pt_auth_code = dr["pt_auth_code"].ToString();
                i.inv_insurance_name = dr["inv_insurance_name"].ToString();
                i.inv_payer = dr["inv_payer"].ToString();
                i.inv_insurance = dr["inv_insurance"].ToString();
                i.emp_name = dr["emp_name"].ToString();
                i.emp_dept_name = dr["emp_dept_name"].ToString();
                i.set_permit_no = dr["set_permit_no"].ToString();
                i.emp_color = dr["emp_color"].ToString();
                i.emp_license = dr["emp_license"].ToString();
                i.pat_code = dr["pat_code"].ToString();
                i.pat_name = dr["pat_name"].ToString();
                i.inv_no = dr["inv_no"].ToString();
                i.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                i.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                i.ic_share = decimal.Parse(dr["ic_share"].ToString());
                i.inv_estatus = dr["inv_estatus"].ToString();
                i.inv_status = dr["inv_status"].ToString();
                i.inv_status2 = dr["inv_status2"].ToString();
                i.inv_type = dr["inv_type"].ToString();
                i.inv_total = decimal.Parse(dr["inv_total"].ToString());
                i.inv_disc = decimal.Parse(dr["inv_disc"].ToString());
                i.pat_share = decimal.Parse(dr["pat_share"].ToString());
                i.inv_net = decimal.Parse(dr["inv_net"].ToString());
                i.pt_net = decimal.Parse(dr["pt_net"].ToString());
                if (decimal.Parse(dr["ic_share"].ToString()) > 0)
                {
                    i.ic_share_yes_no = "Yes";
                }
                else
                {
                    i.ic_share_yes_no = "No";
                }

                list.Add(i);
            }

            return list;
        }

        public static DataSet GetInvoiceDetailsForSubmission(string inv_ids, string s_flag)
        {
            return DataAccessLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
        }
        public static DataTable GetPatient_InsuranceTPAeClaim(int? icId)
        {
            return DataAccessLayer.EClaims.EClaims.GetPatient_InsuranceTPAeClaim(icId);
        }
        public static DataTable GetInvoicesSubmissionsFullXML(SubmissionsSearch inv)
        {
            return DataAccessLayer.EClaims.EClaims.GetInvoicesSubmissions(inv);
        }

        public static float GetInvoiceNet(int appId,int invId, int inv_insurance)
        {
            return DataAccessLayer.EClaims.EClaims.GetInvoiceNet(appId, invId, inv_insurance);
        }
        public static float GetTopupInvoiceNet(int appId, int inv_insurance)
        {
            return DataAccessLayer.EClaims.EClaims.GetTopupInvoiceNet(appId, inv_insurance);
        }
        public static DataTable Get_TreatmentsByAppointmentID(int appId,int invId, int inv_insurance)
        {
            return DataAccessLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(appId, invId, inv_insurance);
        }
        public static DataTable GetPrescriptions(int appId)
        {
            return DataAccessLayer.EClaims.EClaims.GetPrescriptions(appId);
        }
        public static DataTable GetLabResultsAppointmentID(int ptId)
        {
            return DataAccessLayer.EClaims.EClaims.GetLabResultsAppointmentID(ptId);
        }
        public static string SP_GetIcCode(string s_ic_id)
        {
            return DataAccessLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
        }
        public static int SP_UpdateInvoiceStatus(string inv_ids)
        {
            return DataAccessLayer.EClaims.EClaims.SP_UpdateInvoiceStatus(inv_ids);
        }
        public static int eClaim_Insert(string s_ic_id, DateTime s_date_from, DateTime s_date_to, string file_name, string xmlString, string eClaim_ErrorMessage)
        {
            return DataAccessLayer.EClaims.EClaims.eClaim_Insert(s_ic_id, s_date_from, s_date_to, file_name, xmlString, eClaim_ErrorMessage);
        }

        public static Boolean Check_Already_Submitted(string s_ic_id,DateTime s_date_from, DateTime s_date_to)
        {
            return DataAccessLayer.EClaims.EClaims.Check_Already_Submitted(s_ic_id, s_date_from, s_date_to);
        }
        public static int UpdateInvoiceeestatus(string inv_ids, string inv_estatus)
        {
            return DataAccessLayer.EClaims.EClaims.UpdateInvoiceeestatus(inv_ids, inv_estatus);

        }
    }
}
