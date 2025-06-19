using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Accounts
    {
        public static bool isValidAccountPeriod(AccountPeriod items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (items != null)
            {
                int index = 0;
                index++;

                if (string.IsNullOrEmpty(items.ap_name))
                {
                    errors.Add("ap_name", "Enter Account Period Name.");
                }

                if (string.IsNullOrEmpty(items.ap_fdate.ToString()))
                {
                    errors.Add("ap_fdate", "Select Account Period From Date.");
                }
                else
                {
                    if (!DateTime.TryParse(items.ap_fdate.ToString(), out DateTime _out3))
                        errors.Add("ap_fdate", "Account Period From Date is Not Valid.");
                }

                if (string.IsNullOrEmpty(items.ap_tdate.ToString()))
                {
                    errors.Add("ap_tdate", "Select Account Period To Date.");
                }
                else
                {
                    if (!DateTime.TryParse(items.ap_tdate.ToString(), out DateTime _out4))
                        errors.Add("ap_tdate", "Account Period To Date is Not Valid.");
                }
            }
            else
            {
                errors.Add("ap_name", "Enter Account Period Name");
                errors.Add("ap_fdate", "Select Account Period From Date");
                errors.Add("ap_tdate", "Select Account Period To Date");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidAccountGroup(AccountGroup group, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (group != null)
            {
                int index = 0;
                index++;

                if (string.IsNullOrEmpty(group.ag_group))
                {
                    errors.Add("ag_group", "Enter Account Group Name");
                }

                if (string.IsNullOrEmpty(group.ag_period))
                {
                    errors.Add("ag_period", "Select Account Period");
                }

                if (string.IsNullOrEmpty(group.ag_type))
                {
                    errors.Add("ag_type", "Select Account Type");
                }

                if (!(group.ag_branch > 0))
                {
                    errors.Add("ag_branch", "Select Account Branch");
                }
            }
            else
            {
                errors.Add("ag_group", "Enter Account Group Name");
                errors.Add("ag_branch", "Select Account Branch");
                errors.Add("ag_period", "Select Account Period");
                errors.Add("ag_type", "Select Account Type");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidAccountGroupUpdate(AccountGroup group, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (group != null)
            {
                int index = 0;
                index++;

                if (string.IsNullOrEmpty(group.ag_group))
                {
                    errors.Add("uag_group", "Enter Account Group Name");
                }

                if (string.IsNullOrEmpty(group.ag_period))
                {
                    errors.Add("uag_period", "Select Account Period");
                }

                if (string.IsNullOrEmpty(group.ag_type))
                {
                    errors.Add("uag_type", "Select Account Type");
                }

                if (!(group.ag_branch > 0))
                {
                    errors.Add("uag_branch", "Select Account Branch");
                }
            }
            else
            {
                errors.Add("uag_group", "Enter Account Group Name");
                errors.Add("uag_branch", "Select Account Branch");
                errors.Add("uag_period", "Select Account Period");
                errors.Add("uag_type", "Select Account Type");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidAccountCategory(AccountCategories category, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (category != null)
            {
                int index = 0;
                index++;

                if (string.IsNullOrEmpty(category.ac_group))
                {
                    errors.Add("ac_group", "Select Account Group");
                }

                if (string.IsNullOrEmpty(category.ac_period))
                {
                    errors.Add("ac_period", "Select Account Period");
                }

                if (string.IsNullOrEmpty(category.ac_category))
                {
                    errors.Add("ac_category", "Enter Account Category");
                }

                if (!(category.ac_branch > 0))
                {
                    errors.Add("ac_branch", "Select Account Branch");
                }
            }
            else
            {
                errors.Add("ac_group", "Select Account Group");
                errors.Add("ac_branch", "Select Account Branch");
                errors.Add("ac_period", "Select Account Period");
                errors.Add("ac_category", "Enter Account Category");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidAccountCategoryUpdate(AccountCategories category, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (category != null)
            {
                int index = 0;
                index++;

                if (string.IsNullOrEmpty(category.ac_group))
                {
                    errors.Add("uac_group", "Select Account Group");
                }

                if (string.IsNullOrEmpty(category.ac_period))
                {
                    errors.Add("uac_period", "Select Account Period");
                }

                if (string.IsNullOrEmpty(category.ac_category))
                {
                    errors.Add("uac_category", "Enter Account Category");
                }

                if (!(category.ac_branch > 0))
                {
                    errors.Add("uac_branch", "Select Account Branch");
                }
            }
            else
            {
                errors.Add("uac_group", "Select Account Group");
                errors.Add("uac_branch", "Select Account Branch");
                errors.Add("uac_period", "Select Account Period");
                errors.Add("uac_category", "Enter Account Category");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidChartOfAccount(ChartOfAccounts account, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (account != null)
            {
                int index = 0;
                index++;

                if (string.IsNullOrEmpty(account.acc_group))
                {
                    errors.Add("acc_group", "Select Account Group");
                }

                if (string.IsNullOrEmpty(account.acc_period))
                {
                    errors.Add("acc_period", "Select Account Period");
                }

                if (string.IsNullOrEmpty(account.acc_category))
                {
                    errors.Add("acc_category", "Enter Account Category");
                }

                if (string.IsNullOrEmpty(account.acc_name))
                {
                    errors.Add("acc_name", "Enter Account Name");
                }

                if (string.IsNullOrEmpty(account.acc_type))
                {
                    errors.Add("acc_type", "Select Account Type");
                }

                if (!(account.acc_branch > 0))
                {
                    errors.Add("acc_branch", "Select Account Branch");
                }
            }
            else
            {
                errors.Add("acc_group", "Select Account Group");
                errors.Add("acc_branch", "Select Account Branch");
                errors.Add("acc_period", "Select Account Period");
                errors.Add("acc_category", "Select Account Category");
                errors.Add("acc_name", "Enter Account Name");
                errors.Add("acc_type", "Select Account Type");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidChartOfAccountUpdate(ChartOfAccounts account, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (account != null)
            {
                int index = 0;
                index++;

                if (string.IsNullOrEmpty(account.acc_group))
                {
                    errors.Add("uacc_group", "Select Account Group");
                }

                if (string.IsNullOrEmpty(account.acc_period))
                {
                    errors.Add("uacc_period", "Select Account Period");
                }

                if (string.IsNullOrEmpty(account.acc_category))
                {
                    errors.Add("uacc_category", "Enter Account Category");
                }

                if (string.IsNullOrEmpty(account.acc_name))
                {
                    errors.Add("uacc_name", "Enter Account Name");
                }

                if (string.IsNullOrEmpty(account.acc_type))
                {
                    errors.Add("uacc_type", "Select Account Type");
                }

                if (!(account.acc_branch > 0))
                {
                    errors.Add("uacc_branch", "Select Account Branch");
                }
            }
            else
            {
                errors.Add("uacc_group", "Select Account Group");
                errors.Add("uacc_branch", "Select Account Branch");
                errors.Add("uacc_period", "Select Account Period");
                errors.Add("uacc_category", "Select Account Category");
                errors.Add("uacc_name", "Enter Account Name");
                errors.Add("uacc_type", "Select Account Type");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidJournals(JournalWithList data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (data.journalHeader != null)
                {
                    try
                    {
                        if (data.journalHeader.j_branch <= 0)
                        {
                            errors.Add("j_branch", "Selcet Branch.");
                        }

                        if (string.IsNullOrEmpty(data.journalHeader.j_type))
                        {
                            errors.Add("j_type", "Enter Journal Date.");
                        }
                        else
                        {
                            if (data.journalHeader.j_type == "Purchase")
                            {
                                if (data.journalHeader.j_supplier <= 0)
                                {
                                    errors.Add("j_supplier", "Selcet Supplier.");
                                }
                                if (string.IsNullOrEmpty(data.journalHeader.j_inv_no))
                                {
                                    errors.Add("j_inv_no", "Enter Purchase Invoice No.");
                                }
                                if (string.IsNullOrEmpty(data.journalHeader.j_inv_date))
                                {
                                    errors.Add("j_inv_date", "Enter Purchase Date.");
                                }

                            }
                            else if (data.journalHeader.j_type == "Payment")
                            {
                                if (data.journalHeader.j_supplier <= 0)
                                {
                                    errors.Add("j_supplier", "Selcet Supplier.");
                                }
                                if (string.IsNullOrEmpty(data.journalHeader.j_inv_no))
                                {
                                    errors.Add("j_inv_no", "Enter Payment Voucher No.");
                                }
                                if (string.IsNullOrEmpty(data.journalHeader.j_inv_date))
                                {
                                    errors.Add("j_inv_date", "Enter Payment Date.");
                                }

                            }
                            else
                            {
                                data.journalHeader.j_inv_no = string.Empty;
                                data.journalHeader.j_inv_date = string.Empty;
                                data.journalHeader.j_supplier = 0;

                            }
                        }

                        if (string.IsNullOrEmpty(data.journalHeader.j_acc_period))
                        {
                            errors.Add("j_acc_period", "Select Account Period.");
                        }

                        if (string.IsNullOrEmpty(data.journalHeader.j_date.ToString()))
                        {
                            errors.Add("j_date", "Enter Journal Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.journalHeader.j_date.ToString(), out DateTime _out))
                                errors.Add("j_date", "Journal Date is not in Correct Format.");
                        }


                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("j_branch", "Selcet Branch.");
                    errors.Add("j_type", "Enter Journal Date.");
                    errors.Add("j_acc_period", "Select Account Period.");
                    errors.Add("j_date", "Enter Journal Date.");
                }

                if (data.journalInserts != null)
                {
                    int index = 0;

                    foreach (JournalInsert items in data.journalInserts)
                    {
                        index++;

                        if (string.IsNullOrEmpty(items.j_date.ToString()))
                        {
                            errors.Add("pire_edate" + index, "Return Items Expiry Not Valid.");
                        }

                        if (string.IsNullOrEmpty(items.j_account))
                        {
                            errors.Add("j_account" + index, "Enter Transaction Account Name.");
                        }

                        if (!isValidDecimal(items.j_debit.ToString()))
                        {
                            errors.Add("j_debit" + index, "Enter Debit amount in Correct Format.");
                        }

                        if (!isValidDecimal(items.j_credit.ToString()))
                        {
                            errors.Add("j_credit" + index, "Enter Credit amount in Correct Format.");
                        }

                    }

                    if (index == 0)
                    {
                        errors.Add("form_poitems", "Journal Entries detail not available");
                    }
                }
                else
                    errors.Add("form_poitems", "Journal Entries detail not available");
            }
            else
            {
                errors.Add("pire_edate", "Return Items Expiry Not Valid.");
                errors.Add("j_account", "Enter Transaction Account Name.");
                errors.Add("j_debit", "Enter Debit amount in Correct Format.");
                errors.Add("j_credit", "Enter Credit amount in Correct Format.");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidFundsTransfer(FundsTransfer data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ft_acc_period))
                {
                    errors.Add("ft_acc_period", "Select Account Period");
                }

                if (string.IsNullOrEmpty(data.ft_refno))
                {
                    errors.Add("ft_refno", "Enter Refrancer");
                }

                if (string.IsNullOrEmpty(data.ft_to))
                {
                    errors.Add("ft_to", "Select Credit Account");
                }

                if (string.IsNullOrEmpty(data.ft_from))
                {
                    errors.Add("ft_from", "Select Debit Account");
                }

                if (!(data.ft_branch > 0))
                {
                    errors.Add("ag_branch", "Select Branch");
                }

                if (string.IsNullOrEmpty(data.ft_date.ToString()))
                {
                    errors.Add("ft_date", "Enter Transfer Date.");
                }
                else
                {
                    if (!DateTime.TryParse(data.ft_date.ToString(), out DateTime _out))
                        errors.Add("ft_date", "Transfer Date is not in Correct Format.");
                }

                if (!isValidDecimal(data.ft_amount.ToString()))
                {
                    errors.Add("ft_amount", "Enter transfer amount in Correct Format.");
                }
            }
            else
            {
                errors.Add("ft_acc_period", "Select Account Period");
                errors.Add("ft_refno", "Enter Refrancer");
                errors.Add("ft_to", "Select Credit Account");
                errors.Add("ft_from", "Select Debit Account");
                errors.Add("ag_branch", "Select Branch");
                errors.Add("ft_date", "Enter Transfer Date.");
                errors.Add("ft_amount", "Enter transfer amount in Correct Format.");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidFixedAssets(FixedAssets data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (!(data.fa_item > 0))
                {
                    errors.Add("fa_item", "Select item");
                }

                if (string.IsNullOrEmpty(data.fa_pdate.ToString()))
                {
                    errors.Add("fa_pdate", "Select purchase date");
                }
                else
                {
                    if (!DateTime.TryParse(data.fa_pdate.ToString(), out DateTime _out))
                        errors.Add("fa_pdate", "Purchase date is not in correct format");
                }

                if (!isValidDecimal(data.fa_price.ToString())  ||!(data.fa_price > 0))
                {
                    errors.Add("fa_price", "Enter purchase price more than 0");
                }
                
                if (!isValidDecimal(data.fa_residual_value.ToString())  || !(data.fa_residual_value > 0))
                {
                    errors.Add("fa_residual_value", "Enter residual value more than 0");
                }
                else
                {
                    if(data.fa_price > 0 && data.fa_residual_value > 0)
                    {
                        if(data.fa_residual_value > data.fa_price)
                            errors.Add("fa_residual_value", "Residual value should be less than purchase price");

                    }
                }

                if (string.IsNullOrEmpty(data.fa_method))
                {
                    errors.Add("fa_method", "Select depreciation method");
                }
                else
                {
                    if(data.fa_method == "Straight Line")
                    {
                        if (!isValidDecimal(data.fa_life_span.ToString()) || !(data.fa_life_span > 0))
                        {
                            errors.Add("fa_life_span", "Useful Life Span of Asset Should Be More Than 0 Months");
                        }
                    }
                    else
                    {
                        if (!isValidDecimal(data.fa_depreciation_per.ToString()) || !(data.fa_depreciation_per > 0))
                        {
                            errors.Add("fa_depreciation_per", "Monthly Depreciation Should Be More Than 0%");
                        }
                    }
                }
            }
            else
            {
                errors.Add("fa_item", "Select item");
                errors.Add("fa_pdate", "Select purchase date");
                errors.Add("fa_price", "Enter purchase price more than 0");
                errors.Add("fa_residual_value", "Enter residual value more than 0");
                errors.Add("fa_method", "Select depreciation method");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidDecimal(string val)
        {
            decimal out_val = 0;
            return decimal.TryParse(val, out out_val);

        }
    }

}