using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.AuditLogs
{
    public class SupplierLog
    {
        public static List<BusinessEntities.Accounts.AuditLogs.SupplierLog> GetSupplierAuditLogs(string supa_code)
        {
            List<BusinessEntities.Accounts.AuditLogs.SupplierLog> SupplierLoglist = new List<BusinessEntities.Accounts.AuditLogs.SupplierLog>();

            DataTable dt = DataAccessLayer.Accounts.AuditLogs.SupplierLog.GetSupplierAuditLogs(supa_code);
            foreach (DataRow dr in dt.Rows)
            {
                SupplierLoglist.Add(new BusinessEntities.Accounts.AuditLogs.SupplierLog
                {
                    supaId = Convert.ToInt32(dr["supaId"].ToString()),
                    supa_code = dr["supa_code"].ToString(),
                    supa_name = dr["supa_name"].ToString(),
                    supa_tel = dr["supa_tel"].ToString(),
                    supa_fax = dr["supa_fax"].ToString(),
                    supa_mob = dr["supa_mob"].ToString(),
                    supa_email = dr["supa_email"].ToString(),
                    supa_url = dr["supa_url"].ToString(),
                    supa_address = dr["supa_address"].ToString(),
                    supa_notes = dr["supa_notes"].ToString(),
                    supa_account = dr["supa_account"].ToString(),
                    supa_status = dr["supa_status"].ToString(),
                    supa_credit = int.Parse(dr["supa_credit"].ToString()),
                    supa_obal = decimal.Parse(dr["supa_obal"].ToString()),
                    supa_obal_type = dr["supa_obal_type"].ToString(),
                    supa_vat_regno = dr["supa_vat_regno"].ToString(),
                    supa_madeby_name = dr["supa_madeby_name"].ToString(),
                    supa_branch = int.Parse(dr["supa_branch"].ToString()),
                    supa_branch_name = dr["supa_branch_name"].ToString(),
                    supa_date_created = dr["supa_date_created"].ToString(),
                    supa_operation = dr["supa_operation"].ToString(),
                });
            }
            return SupplierLoglist;
        }

    }
}
