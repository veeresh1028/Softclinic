using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class PDC
    {     
        #region PDC Receivables
        public static List<BusinessEntities.Accounts.Accounting.PDCReceivable> GetPDCReceivables(PDCReceivablesFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.PDC.GetPDCReceivables(filter);
            List<BusinessEntities.Accounts.Accounting.PDCReceivable> _chq = new List<BusinessEntities.Accounts.Accounting.PDCReceivable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _chq.Add(new BusinessEntities.Accounts.Accounting.PDCReceivable
                    {
                        recId = DataValidation.isIntValid(dr["recId"].ToString()),
                        rec_patient = DataValidation.isIntValid(dr["rec_patient"].ToString()),
                        rec_code = dr["rec_code"].ToString(),
                        rec_type = dr["rec_type"].ToString(),
                        rec_date = DataValidation.isDateValid(dr["rec_date"].ToString()),
                        rec_chq_date = DataValidation.isDateValid(dr["rec_chq_date"].ToString()),
                        rec_chq = DataValidation.isDecimalValid(dr["rec_chq"].ToString()),
                        rec_chq_no = dr["rec_chq_no"].ToString(),
                        rec_chq_bank = dr["rec_chq_bank"].ToString(),
                        rec_status = dr["rec_status"].ToString(),
                        rec_status2 = dr["rec_status2"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        rec_branch = DataValidation.isIntValid(dr["rec_branch"].ToString()),
                        pat_name = dr["pat_name"].ToString(),
                        pat_code = dr["pat_code"].ToString(),
                        pat_mob = dr["pat_mob"].ToString()                        
                    });
                }
            }
            return _chq;
        }
        public static bool ChangePDCReceivablesStatus(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.PDC.ChangePDCReceivablesStatus(data, status, empId);

        }
        public static bool PostToAccountPDCReceivables(string data, string status, string acc_code,  int empId)
        {
            return DataAccessLayer.Accounts.Accounting.PDC.PostToAccountPDCReceivables(data, status, acc_code, empId);

        }

        #endregion

        #region PDC Payables
        public static List<BusinessEntities.Accounts.Accounting.PDCPayables> GetPDCPayables(PDCPayablesFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.PDC.GetPDCPayables(filter);
            List<BusinessEntities.Accounts.Accounting.PDCPayables> _chq = new List<BusinessEntities.Accounts.Accounting.PDCPayables>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _chq.Add(new BusinessEntities.Accounts.Accounting.PDCPayables
                    {
                        payId = DataValidation.isIntValid(dr["payId"].ToString()),
                        pay_supplier = DataValidation.isIntValid(dr["pay_supplier"].ToString()),
                        pay_code = dr["pay_code"].ToString(),
                        pay_type = dr["pay_type"].ToString(),
                        pay_date = DataValidation.isDateValid(dr["pay_date"].ToString()),
                        pay_chq_date = DataValidation.isDateValid(dr["pay_chq_date"].ToString()),
                        pay_chq = DataValidation.isDecimalValid(dr["pay_chq"].ToString()),
                        pay_chq_no = dr["pay_chq_no"].ToString(),
                        pay_chq_bank = dr["pay_chq_bank"].ToString(),
                        pay_status = dr["pay_status"].ToString(),
                        pay_status2 = dr["pay_status2"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        pay_branch = DataValidation.isIntValid(dr["pay_branch"].ToString()),
                        sup_name = dr["sup_name"].ToString(),
                        sup_code = dr["sup_code"].ToString(),
                        sup_mob = dr["sup_mob"].ToString()
                    });
                }
            }
            return _chq;
        }
        public static bool ChangePDCPayablesStatus(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.PDC.ChangePDCPayablesStatus(data, status, empId);

        }
        public static bool PostToAccountPDCPayables(string data, string status, string acc_code, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.PDC.PostToAccountPDCPayables(data, status, acc_code, empId);

        }
        #endregion


    }
}
