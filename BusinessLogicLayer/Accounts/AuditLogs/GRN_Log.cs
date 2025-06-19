using BusinessEntities.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.AuditLogs
{
    public class GRN_Log
    {
        public static BusinessEntities.Accounts.AuditLogs.GRN_Log_list GetgrnAuditLogs(int prId)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.GRN_Log.GetgrnAuditLogs(prId);
            BusinessEntities.Accounts.AuditLogs.GRN_Log_list _grnLog_list = new BusinessEntities.Accounts.AuditLogs.GRN_Log_list();
            List<BusinessEntities.Accounts.AuditLogs.GRN_Log> _grnLogs = new List<BusinessEntities.Accounts.AuditLogs.GRN_Log>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _grnLogs.Add(new BusinessEntities.Accounts.AuditLogs.GRN_Log
                    {
                        praId = DataValidation.isIntValid(dr["praId"].ToString()),
                        pra_prId = DataValidation.isIntValid(dr["pra_prId"].ToString()),
                        pra_PurchaseOrder = DataValidation.isIntValid(dr["pra_PurchaseOrder"].ToString()),
                        pra_supplier = DataValidation.isIntValid(dr["pra_supplier"].ToString()),
                        pra_code = dr["pra_code"].ToString(),
                        pra_supplier_inv = dr["pra_supplier_inv"].ToString(),
                        pra_date = DataValidation.isDateValid(dr["pra_date"].ToString()),
                        pra_total = DataValidation.isDecimalValid(dr["pra_total"].ToString()),
                        pra_discount = DataValidation.isDecimalValid(dr["pra_discount"].ToString()),
                        pra_net = DataValidation.isDecimalValid(dr["pra_net"].ToString()),
                        pra_vat = DataValidation.isDecimalValid(dr["pra_vat"].ToString()),
                        pra_netvat = DataValidation.isDecimalValid(dr["pra_netvat"].ToString()),
                        pra_status = dr["pra_status"].ToString(),
                        pra_notes = dr["pra_notes"].ToString(),
                        purchase_order = dr["purchase_order"].ToString(),
                        pra_branch = DataValidation.isIntValid(dr["pra_branch"].ToString()),
                        pra_madeby = DataValidation.isIntValid(dr["pra_madeby"].ToString()),
                        supplier_name = dr["supplier_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        pra_operation = dr["pra_operation"].ToString(),
                        pra_date_created = dr["pra_date_created"].ToString(),
                        madeby = dr["madeby"].ToString()
                    });
                }
            }
            _grnLog_list._grn_log = _grnLogs;
            return _grnLog_list;
        }

    }
}
