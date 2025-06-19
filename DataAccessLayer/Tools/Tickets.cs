using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Tools;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Tools
{
    public class Tickets
    {
        //Ticket
        public static int ComposeTicket(ComposeTickets data)
        {
            int rtrn = 0;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKETS_INSERT_UPDATE");

                db.AddInParameter(dbCommand, "ticketId", DbType.Int32, data.ticketId);
                db.AddInParameter(dbCommand, "ticket_date", DbType.String, data.ticket_date);
                db.AddInParameter(dbCommand, "ticket_code", DbType.Int32, data.ticket_code);
                db.AddInParameter(dbCommand, "ticket_branch", DbType.Int32, data.ticket_branch);
                db.AddInParameter(dbCommand, "ticket_subject", DbType.String, data.ticket_subject);
                db.AddInParameter(dbCommand, "ticket_to_dept", DbType.String, data.ticket_department);
                db.AddInParameter(dbCommand, "ticket_priority", DbType.String, data.ticket_priority);
                db.AddInParameter(dbCommand, "ticket_description", DbType.String, data.ticket_description);
                db.AddInParameter(dbCommand, "ticket_madeby", DbType.Int32, data.ticket_madeby);
                db.AddOutParameter(dbCommand, "tid_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                rtrn = int.Parse(db.GetParameterValue(dbCommand, "tid_out").ToString());
                return rtrn;
            }
            catch
            {
                throw;
            }

        }
        public static DataTable TicketSenderDetail(int empid)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_SENDER_INFO");

                db.AddInParameter(dbCommand, "empid", DbType.Int32, empid);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch
            {
                throw;
            }

        }
        public static DataTable GetTicketsDetail(TicketsFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKETS_SELECT_INFO");

                if (filter.ticketId > 0)
                    db.AddInParameter(dbCommand, "ticketId", DbType.Int32, filter.ticketId);

                if (filter.ticket_code > 0)
                    db.AddInParameter(dbCommand, "ticket_code", DbType.Int32, filter.ticket_code);

                if (filter.ticket_branch > 0)
                    db.AddInParameter(dbCommand, "ticket_branch", DbType.Int32, filter.ticket_branch);

                if (filter.ticket_madeby > 0)
                    db.AddInParameter(dbCommand, "ticket_madeby", DbType.Int32, filter.ticket_madeby);

                if (!string.IsNullOrEmpty(filter.ticket_subject))
                    db.AddInParameter(dbCommand, "ticket_subject", DbType.String, filter.ticket_subject);

                if (!string.IsNullOrEmpty(filter.ticket_date_from) && (!string.IsNullOrEmpty(filter.ticket_date_to)))
                {
                    db.AddInParameter(dbCommand, "ticket_date_from", DbType.String, filter.ticket_date_from);
                    db.AddInParameter(dbCommand, "ticket_date_to", DbType.String, filter.ticket_date_to);
                }

                if (!string.IsNullOrEmpty(filter.ticket_status))
                {
                    string ticket__status = string.Join(",", filter.ticket_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "ticket_status ", DbType.String, ticket__status);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool TicketStatus(string data, string status, int empId, string statusby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKETS_UPDATE_STATUS");
                db.AddInParameter(dbCommand, "ticket_code", DbType.String, data);
                db.AddInParameter(dbCommand, "ticket_status", DbType.String, status);
                db.AddInParameter(dbCommand, "ticket_statusby", DbType.String, statusby);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddOutParameter(dbCommand, "tId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int result = int.Parse(db.GetParameterValue(dbCommand, "tId_out").ToString());

                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Ticket Reminder
        public static DataTable GetTicketReminders(int trId, int code)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_REMINDERS_SELECT_INFO");

                if (trId > 0)
                    db.AddInParameter(dbCommand, "trId", DbType.Int32, trId);

                db.AddInParameter(dbCommand, "tr_ticket_code", DbType.Int32, code);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch
            {
                throw;
            }

        }        
        public static int SendTicketReminder(TicketReminder data)
        {
            int rtrn = 0;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_REMINDERS_INSERT_UPDATE");

                db.AddInParameter(dbCommand, "trId", DbType.Int32, data.trId);
                db.AddInParameter(dbCommand, "tr_ticket_code", DbType.Int32, data.tr_ticket_code);
                db.AddInParameter(dbCommand, "tr_message", DbType.String, data.tr_message);
                db.AddInParameter(dbCommand, "tr_madeby", DbType.Int32, data.tr_madeby);
                db.AddOutParameter(dbCommand, "tr_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                rtrn = int.Parse(db.GetParameterValue(dbCommand, "tr_out").ToString());
                return rtrn;
            }
            catch
            {
                throw;
            }

        }

        //Ticket Support Docs
        public static int UploadDocument(TicketDocuments doc)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_DOCUMENTS_INSERT");

                db.AddInParameter(dbCommand, "tdoc_ticket_code", DbType.Int32, doc.tdoc_ticket_code);
                db.AddInParameter(dbCommand, "tdoc_name", DbType.String, doc.tdoc_name);
                db.AddInParameter(dbCommand, "tdoc_path", DbType.String, doc.tdoc_path);
                db.AddInParameter(dbCommand, "tdoc_uploadedby", DbType.Int32, doc.tdoc_uploadedby);
                db.AddOutParameter(dbCommand, "tdoc_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int rtrn = int.Parse(db.GetParameterValue(dbCommand, "tdoc_out").ToString());

                return rtrn;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetDocumentsById(int id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_DOCUMENTS_SELECT_INFO");

                db.AddInParameter(dbCommand, "tdoc_ticket_code", DbType.Int32, id);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool DeleteDocuments(int docId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_DOCUMENTS_Delete");

                db.AddInParameter(dbCommand, "tdocId", DbType.Int32, docId);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetFilePathDownload(int id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_DOCUMENTS_Download");

                db.AddInParameter(dbCommand, "tdocId", DbType.Int32, id);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Ticket Comments
        public static bool InsertComment(TicketComments data)
        {
            int result = 0;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_COMMENTS_INSERT");

                db.AddInParameter(dbCommand, "tc_ticketCode", DbType.Int32, data.tc_ticketCode);
                db.AddInParameter(dbCommand, "tc_commnet", DbType.String, data.tc_commnet);
                db.AddInParameter(dbCommand, "tc_commnetby", DbType.String, data.tc_commnetby);
                db.AddInParameter(dbCommand, "tc_source", DbType.String, data.tc_source);
                db.AddInParameter(dbCommand, "tc_status", DbType.String, data.tc_status);
                db.AddInParameter(dbCommand, "tc_commnetby_ID", DbType.Int32, data.tc_commnetby_ID);
                db.AddOutParameter(dbCommand, "tc_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                result = int.Parse(db.GetParameterValue(dbCommand, "tc_out").ToString());

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }

        }
        public static DataTable GetTicketComments(int Code)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TICKET_COMMENTS_SELECT_INFO");
                
                db.AddInParameter(dbCommand, "tc_ticketCode", DbType.Int32, Code);
;
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
