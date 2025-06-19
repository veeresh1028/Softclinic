using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessEntities.Reports.Resubmission;

namespace DataAccessLayer.Reports
{
    public class Resubmission
    {
        public static DataSet GetResubmissFilters()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create("RCMDB");
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetResubmissionFilters");
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetBranchesPermit(string permits, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
               Database db = factory.Create("RCMDB");
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Branches_Permit");

                db.AddInParameter(dbCommand, "branches", DbType.String, permits);

                db.AddInParameter(dbCommand, "type", DbType.String, type);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetTransactionClaimsActivityData(filesdownload_filter filter)
        {
            try
            {

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
               Database db = factory.Create("RCMDB");
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Activity_Wise_Claims_Transactions");

                if (!string.IsNullOrEmpty(filter.type))
                {
                    string _branches = "";
                    string[] all_branches = filter.branch.Split(',');

                    if (filter.type == "MOH")
                    {
                        foreach (string all_br in all_branches)
                        {
                            DataTable _dt = GetBranchesPermit(all_br, "MOH");
                            if (_dt.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(_branches))
                                    _branches += "," + _dt.Rows[0]["set_url"].ToString();
                                else
                                    _branches = _dt.Rows[0]["set_url"].ToString();
                            }
                        }
                    }
                    else
                    {
                        foreach (string all_br in all_branches)
                        {
                            DataTable _dt = GetBranchesPermit(all_br, "DHA");
                            if (_dt.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(_branches))
                                    _branches += "," + _dt.Rows[0]["set_permit_no"].ToString();
                                else
                                    _branches = _dt.Rows[0]["set_permit_no"].ToString();
                            }
                        }
                    }

                    string branch = string.Join(",", _branches.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "branch", DbType.String, branch);
                }
                else
                {
                    string _branches = "";
                    if (!string.IsNullOrEmpty(filter.branch))
                    {
                        string[] all_branches = filter.branch.Split(',');
                        foreach (string all_br in all_branches)
                        {
                            DataTable _dt = GetBranchesPermit(all_br, "MOH,DHA");
                            if (_dt.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(_branches))
                                    _branches += "," + _dt.Rows[0]["set_permit_no"].ToString() + "," + _dt.Rows[0]["set_url"].ToString();
                                else
                                    _branches = _dt.Rows[0]["set_permit_no"].ToString() + "," + _dt.Rows[0]["set_url"].ToString();
                            }
                        }
                        string branch = string.Join(",", _branches.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                        db.AddInParameter(dbCommand, "Branch", DbType.String, branch);
                    }
                }

                if (!string.IsNullOrEmpty(filter.date_From))
                {
                    string remittedDate_From = DateTime.Parse(filter.date_From).ToString("yyyy-MM-dd HH:mm:ss");
                    db.AddInParameter(dbCommand, "date_From", DbType.String, remittedDate_From);
                }

                if (!string.IsNullOrEmpty(filter.date_To))
                {
                    string remittedDate_To = DateTime.Parse(filter.date_To).Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
                    db.AddInParameter(dbCommand, "date_to", DbType.String, remittedDate_To);
                }

                if (!string.IsNullOrEmpty(filter.claimId))
                {
                    db.AddInParameter(dbCommand, "claimId", DbType.String, filter.claimId);
                }

                if (!string.IsNullOrEmpty(filter.type))
                {
                    string type = string.Join(",", filter.type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "type", DbType.String, type);
                }

                if (!string.IsNullOrEmpty(filter.claim_type))
                {
                    db.AddInParameter(dbCommand, "claim_type", DbType.String, filter.claim_type);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetTransactionResubmissionClaimsActivityData(filesdownload_filter filter)
        {
            try
            {

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
               Database db = factory.Create("RCMDB");
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Transaction_Wise_Resubmission_Claims_Activty_Detail");

                if (!string.IsNullOrEmpty(filter.type))
                {
                    string _branches = "";
                    string[] all_branches = filter.branch.Split(',');

                    if (filter.type == "MOH")
                    {
                        foreach (string all_br in all_branches)
                        {
                            DataTable _dt = GetBranchesPermit(all_br, "MOH");
                            if (_dt.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(_branches))
                                    _branches += "," + _dt.Rows[0]["set_url"].ToString();
                                else
                                    _branches = _dt.Rows[0]["set_url"].ToString();
                            }
                        }
                    }
                    else
                    {
                        foreach (string all_br in all_branches)
                        {
                            DataTable _dt = GetBranchesPermit(all_br, "DHA");
                            if (_dt.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(_branches))
                                    _branches += "," + _dt.Rows[0]["set_permit_no"].ToString();
                                else
                                    _branches = _dt.Rows[0]["set_permit_no"].ToString();
                            }
                        }
                    }

                    string branch = string.Join(",", _branches.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "branch", DbType.String, branch);
                }
                else
                {
                    string _branches = "";
                    if (!string.IsNullOrEmpty(filter.branch))
                    {
                        string[] all_branches = filter.branch.Split(',');
                        foreach (string all_br in all_branches)
                        {
                            DataTable _dt = GetBranchesPermit(all_br, "MOH,DHA");
                            if (_dt.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(_branches))
                                    _branches += "," + _dt.Rows[0]["set_permit_no"].ToString() + "," + _dt.Rows[0]["set_url"].ToString();
                                else
                                    _branches = _dt.Rows[0]["set_permit_no"].ToString() + "," + _dt.Rows[0]["set_url"].ToString();
                            }
                        }
                        string branch = string.Join(",", _branches.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                        db.AddInParameter(dbCommand, "Branch", DbType.String, branch);
                    }
                }

                if (!string.IsNullOrEmpty(filter.date_From))
                {
                    string remittedDate_From = DateTime.Parse(filter.date_From).ToString("yyyy-MM-dd HH:mm:ss");
                    db.AddInParameter(dbCommand, "date_From", DbType.String, remittedDate_From);
                }

                if (!string.IsNullOrEmpty(filter.date_To))
                {
                    string remittedDate_To = DateTime.Parse(filter.date_To).Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
                    db.AddInParameter(dbCommand, "date_to", DbType.String, remittedDate_To);
                }

                if (!string.IsNullOrEmpty(filter.claimId))
                {
                    db.AddInParameter(dbCommand, "claimId", DbType.String, filter.claimId);
                }

                if (!string.IsNullOrEmpty(filter.type))
                {
                    string type = string.Join(",", filter.type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "type", DbType.String, type);
                }

                if (!string.IsNullOrEmpty(filter.claim_type))
                {
                    db.AddInParameter(dbCommand, "claim_type", DbType.String, filter.claim_type);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
