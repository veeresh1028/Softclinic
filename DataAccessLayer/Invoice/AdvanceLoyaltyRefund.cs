using BusinessEntities.Invoice;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Invoice
{
    public class AdvanceLoyaltyRefund
    {
        public static DataTable GetAdvanceLoyaltyRefund(ReceiptSearch rec)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetAdvanceLoyaltyRefundReceipts");

                string sDate = string.Empty;
                string eDate = string.Empty;

                sDate = (rec.rec_date_from.Year > 2000) ? rec.rec_date_from.ToString("yyyy-MM-dd HH:mm:ss") : "";
                eDate = (rec.rec_date_to.Year > 2000) ? rec.rec_date_to.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") : "";


                string csDate = string.Empty;
                string ceDate = string.Empty;

                csDate = (rec.chq_date_from.Year > 2000) ? rec.chq_date_from.ToString("yyyy-MM-dd HH:mm:ss") : "";
                ceDate = (rec.chq_date_to.Year > 2000) ? rec.chq_date_to.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") : "";

                
                if (!string.IsNullOrEmpty(rec.branch_ids))
                {
                    db.AddInParameter(dbCommand, "branch_ids", DbType.String, rec.branch_ids);
                }
                if (!string.IsNullOrEmpty(rec.doctor))
                {
                    db.AddInParameter(dbCommand, "doctor", DbType.String, rec.doctor);
                }
                if (!string.IsNullOrEmpty(rec.rec_code))
                {
                    db.AddInParameter(dbCommand, "rec_code", DbType.String, rec.rec_code);
                }

                if (!string.IsNullOrEmpty(rec.type_ids))
                {
                    db.AddInParameter(dbCommand, "type_ids", DbType.String, rec.type_ids);
                }
                
                if (!string.IsNullOrEmpty(sDate))
                {
                    db.AddInParameter(dbCommand, "rec_date_from", DbType.String, sDate);
                }

                if (!string.IsNullOrEmpty(eDate))
                {
                    db.AddInParameter(dbCommand, "rec_date_to", DbType.String, eDate);
                }

                if (rec.patient > 0)
                {
                    db.AddInParameter(dbCommand, "patient", DbType.Int32, rec.patient);
                }
                if (!string.IsNullOrEmpty(csDate))
                {
                    db.AddInParameter(dbCommand, "chq_date_from", DbType.String, csDate);
                }

                if (!string.IsNullOrEmpty(ceDate))
                {
                    db.AddInParameter(dbCommand, "chq_date_to", DbType.String, ceDate);
                }

                if (!string.IsNullOrEmpty(rec.rec_statuses))
                {
                    string inv_statuses = string.Join(",", rec.rec_statuses.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "rec_statuses", DbType.String, inv_statuses);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchPatients(string query, int search_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Search_AdvReceipt_Patients");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "search_type", DbType.Int32, search_type);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable RefundInvoiceByPatId(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RefundInvoiceByPatient");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int PostToAccountReceipt(ReceiptsBulkStatus data, int madeby)
        {
            try
            {
                int count = 0;
                int index = 0;
                string[] type = data.rec_type.ToArray();

                foreach (int recId in data.recIds)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    string proc_name = "";

                    if (type[index] == "Advance")
                        proc_name = "SP_Adavance_Received_Post_To_Account";
                    else
                        proc_name = "SP_Receipt_Refunced_Post_To_Account";

                    DbCommand dbCommand = db.GetStoredProcCommand(proc_name);
                    db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, madeby);
                    if (type[index] != "Advance")
                        db.AddInParameter(dbCommand, "type", DbType.String, type[index]);

                    db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, madeby);

                    db.ExecuteNonQuery(dbCommand);

                    int id = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());
                    index++;
                    if (id > 0) { count++; }
                }

                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
