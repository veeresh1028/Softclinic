using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessEntities.Reports.Resubmission;

namespace BusinessLogicLayer.Reports
{
    public class Resubmission
    {
        public static DataSet GetResubmissFilters()
        {
            return DataAccessLayer.Reports.Resubmission.GetResubmissFilters();
        }
        public static List<TransactionClaimActivtyDetail> GetTransactionClaimsActivityData(filesdownload_filter filter)
        {
            try
            {
                if (filter.claim_type == "Submission")
                {
                    DataTable dt = DataAccessLayer.Reports.Resubmission.GetTransactionClaimsActivityData(filter);
                    List<TransactionClaimActivtyDetail> list = new List<TransactionClaimActivtyDetail>();

                    
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            TransactionClaimActivtyDetail r = new TransactionClaimActivtyDetail();
                            r.Claim_SystemId = int.Parse(dr["Claim_SystemId"].ToString());
                            r.ClaimId = dr["ClaimId"].ToString();
                            r.Claim_Type = dr["Claim_Type"].ToString();
                            r.SenderID = dr["SenderID"].ToString();
                            r.ReceiverID = dr["ReceiverID"].ToString();
                            r.TransactionDate = dr["TransactionDate"].ToString();
                            r.SubmissionDate = dr["Start"].ToString();
                            r.doc_license = dr["doc_license"].ToString();
                            r.doctor_name = dr["doctor_name"].ToString();
                            r.DenialCode = dr["DenialCode"].ToString();
                            r.PaymentReference = dr["PaymentReference"].ToString();
                            r.ActivityID = dr["ActivityID"].ToString();
                            r.Gross = decimal.Parse(dr["Gross"].ToString());


                            r.RecordCount = int.Parse(dr["RecordCount"].ToString());

                            r.net = decimal.Parse(dr["net"].ToString());
                            r.PaymentAmount = decimal.Parse(dr["PaymentAmount"].ToString());

                            if ((r.net - r.PaymentAmount) > 0)
                                r.RejectedAmount = r.net - r.PaymentAmount;
                            else
                                r.RejectedAmount = 0;

                            r.PaymentAmount = decimal.Parse(dr["PaymentAmount"].ToString());
                            r.Flag = dr["Flag"].ToString();

                           

                            list.Add(r);
                        }
                    }

                    return list;
                }
                else
                {

                    DataTable dt = DataAccessLayer.Reports.Resubmission.GetTransactionResubmissionClaimsActivityData(filter);
                    List<TransactionClaimActivtyDetail> list = new List<TransactionClaimActivtyDetail>();

                   
                    string oldClaimId = "";
                    int count_record = 0;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            TransactionClaimActivtyDetail r = new TransactionClaimActivtyDetail();
                            r.Claim_SystemId = int.Parse(dr["Claim_SystemId"].ToString());
                            r.ClaimId = dr["ClaimId"].ToString();

                            if (oldClaimId != r.ClaimId)
                            {
                                count_record = 0;
                            }
                            else
                            {
                                oldClaimId = dr["ClaimId"].ToString();
                            }
                            count_record++;


                            r.Claim_Type = dr["Claim_Type"].ToString();
                            r.SenderID = dr["SenderID"].ToString();
                            r.ReceiverID = dr["ReceiverID"].ToString();
                            r.TransactionDate = dr["TransactionDate"].ToString();
                            r.ActivityID = dr["ActivityID"].ToString();

                            r.SubmissionDate = dr["Start"].ToString();
                            r.doc_license = dr["doc_license"].ToString();
                            r.doctor_name = dr["doctor_name"].ToString();
                            r.DenialCode = dr["DenialCode"].ToString();
                            r.PaymentReference = dr["PaymentReference"].ToString();
                            r.Gross = decimal.Parse(dr["Gross"].ToString());

                            r.RecordCount = int.Parse(dr["RecordCount"].ToString());


                            if (count_record == 1)
                            {
                                r.net = decimal.Parse(dr["net2"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount2"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }
                            else if (count_record == 2)
                            {
                                r.net = decimal.Parse(dr["net3"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount3"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }
                            else if (count_record == 3)
                            {
                                r.net = decimal.Parse(dr["net4"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount4"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }
                            else if (count_record == 4)
                            {
                                r.net = decimal.Parse(dr["net5"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount5"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }



                            r.Flag = dr["Flag"].ToString();

                            

                            list.Add(r);

                        }
                    }
                    return list;
                }
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
        public static List<downloadFilesDetail> GetDownloadClaimsData(filesdownload_filter filter)
        {
            try
            {
                if (filter.claim_type == "Submission")
                {
                    DataTable dt = Resubmission.GetDownloadSubmissionClaimsData(filter);
                    List<downloadFilesDetail> list = new List<downloadFilesDetail>();

                    string file_path = ConfigurationManager.AppSettings["filepatah"] + "filepath";
                    string fullPath = "";
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            downloadFilesDetail r = new downloadFilesDetail();
                            r.Claim_SystemId = int.Parse(dr["Claim_SystemId"].ToString());
                            r.ClaimId = dr["ClaimId"].ToString();
                            r.Claim_Type = dr["Claim_Type"].ToString();
                            r.SenderID = dr["SenderID"].ToString();
                            r.ReceiverID = dr["ReceiverID"].ToString();
                            r.TransactionDate = dr["TransactionDate"].ToString();


                            r.RecordCount = int.Parse(dr["RecordCount"].ToString());
                            r.net = decimal.Parse(dr["net"].ToString());
                            r.PaymentAmount = decimal.Parse(dr["PaymentAmount"].ToString());
                            if ((r.net - r.PaymentAmount) > 0)
                                r.RejectedAmount = r.net - r.PaymentAmount;
                            else
                                r.RejectedAmount = 0;

                            r.PaymentAmount = decimal.Parse(dr["PaymentAmount"].ToString());
                            r.Flag = dr["Flag"].ToString();

                            r.FileName = dr["FileName"].ToString();
                            r.FilePath = dr["FilePath"].ToString();

                            if (!fullPath.Contains(".json") && !fullPath.Contains(".xml"))
                                fullPath = Path.Combine(dr["FilePath"].ToString(), dr["FileName"].ToString());
                            else
                                fullPath = dr["FilePath"].ToString();

                            if (!string.IsNullOrEmpty(fullPath))
                            {
                                if (fullPath.Contains("filepath"))
                                {
                                    string[] _sub_file = fullPath.Split(new string[] { "filepath" }, StringSplitOptions.None);
                                    r.FilePath = file_path + _sub_file[1].Replace('\\', '/');
                                }
                            }
                            else
                            {
                                r.FilePath = "";
                            }

                            list.Add(r);
                        }
                    }

                    return list;
                }
                else
                {
                    DataTable dt = Resubmission.GetDownloadResubmissionClaimsData(filter);
                    List<downloadFilesDetail> list = new List<downloadFilesDetail>();

                    string file_path = ConfigurationManager.AppSettings["filepatah"] + "filepath";
                    string fullPath = "";
                    string oldClaimId = "";
                    int count_record = 0;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            downloadFilesDetail r = new downloadFilesDetail();
                            r.Claim_SystemId = int.Parse(dr["Claim_SystemId"].ToString());
                            r.ClaimId = dr["ClaimId"].ToString();

                            if (oldClaimId != r.ClaimId)
                            {
                                count_record = 0;
                            }
                            else
                            {
                                oldClaimId = dr["ClaimId"].ToString();
                            }
                            count_record++;


                            r.Claim_Type = dr["Claim_Type"].ToString();
                            r.SenderID = dr["SenderID"].ToString();
                            r.ReceiverID = dr["ReceiverID"].ToString();
                            r.TransactionDate = dr["TransactionDate"].ToString();

                            r.RecordCount = int.Parse(dr["RecordCount"].ToString());


                            if (count_record == 1)
                            {
                                r.net = decimal.Parse(dr["net2"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount2"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }
                            else if (count_record == 2)
                            {
                                r.net = decimal.Parse(dr["net3"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount3"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }
                            else if (count_record == 3)
                            {
                                r.net = decimal.Parse(dr["net4"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount4"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }
                            else if (count_record == 4)
                            {
                                r.net = decimal.Parse(dr["net5"].ToString());
                                r.PaymentAmount = decimal.Parse(dr["PaymentAmount5"].ToString());

                                if ((r.net - r.PaymentAmount) > 0)
                                    r.RejectedAmount = r.net - r.PaymentAmount;
                                else
                                    r.RejectedAmount = 0;
                            }



                            r.Flag = dr["Flag"].ToString();

                            r.FileName = dr["FileName"].ToString();
                            if (!(dr["FilePath"].ToString()).Contains(".json") && !(dr["FilePath"].ToString()).Contains(".xml"))
                                fullPath = Path.Combine(dr["FilePath"].ToString(), dr["FileName"].ToString());
                            else
                                fullPath = dr["FilePath"].ToString();

                            if (!string.IsNullOrEmpty(fullPath))
                            {
                                if (fullPath.Contains("filepath"))
                                {
                                    string[] _sub_file = fullPath.Split(new string[] { "filepath" }, StringSplitOptions.None);
                                    r.FilePath = file_path + _sub_file[1].Replace('\\', '/');
                                }
                            }
                            else
                            {
                                r.FilePath = "";
                            }

                            list.Add(r);

                        }
                    }
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDownloadResubmissionClaimsData(filesdownload_filter filter)
        {
            try
            {

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create("RCMDB");
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Downloading_Resubmission_Claims_Detail");

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
        public static DataTable GetDownloadSubmissionClaimsData(filesdownload_filter filter)
        {
            try
            {

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
               Database db = factory.Create("RCMDB");
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Downloading_Submission_Claims_Detail");

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
