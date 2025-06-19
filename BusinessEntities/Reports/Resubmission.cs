using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class Resubmission
    {
        public class filesdownload_filter
        {
            public string branch { get; set; }
            public string type { get; set; }
            public string claimId { get; set; }
            public string claim_type { get; set; }
            public string date_From { get; set; }
            public string date_To { get; set; }
        }
        public class TransactionClaimActivtyDetail
        {
            public int Claim_SystemId { get; set; }
            public string ClaimId { get; set; }
            public string Claim_Type { get; set; }
            public string SenderID { get; set; }
            public string ReceiverID { get; set; }
            public string TransactionDate { get; set; }
            public string SubmissionDate { get; set; }
            public int RecordCount { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string Flag { get; set; }
            public decimal net { get; set; }
            public decimal RejectedAmount { get; set; }
            public decimal PaymentAmount { get; set; }
            public decimal Gross { get; set; }
            public string doc_license { get; set; }
            public string doctor_name { get; set; }
            public string DenialCode { get; set; }
            public string PaymentReference { get; set; }
            public string ActivityID { get; set; }
        }
        public class downloadFilesDetail
        {
            public int Claim_SystemId { get; set; }
            public string ClaimId { get; set; }
            public string Claim_Type { get; set; }
            public string SenderID { get; set; }
            public string ReceiverID { get; set; }
            public string TransactionDate { get; set; }
            public int RecordCount { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string Flag { get; set; }
            public decimal net { get; set; }
            public decimal RejectedAmount { get; set; }
            public decimal PaymentAmount { get; set; }
        }
    }
}
