using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Common;
using BusinessEntities.Tools;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Tools
{
    public class Tickets
    {
        //Ticket
        public static int ComposeTicket(BusinessEntities.Tools.ComposeTickets data)
        {
            return DataAccessLayer.Tools.Tickets.ComposeTicket(data);
        }
        public static DataTable TicketSenderDetail(int empid)
        {
            return DataAccessLayer.Tools.Tickets.TicketSenderDetail(empid);
        }
        public static List<BusinessEntities.Tools.TicketsDetail> GetTicketsDetail(BusinessEntities.Tools.TicketsFilter filter)
        {
            DataTable dt = DataAccessLayer.Tools.Tickets.GetTicketsDetail(filter);
            List<BusinessEntities.Tools.TicketsDetail> _tickets = new List<BusinessEntities.Tools.TicketsDetail>();
            int _open_ticket = 0;
            int _progress_ticket = 0;
            int _hold_ticket = 0;
            int _closed_ticket = 0;
            int _cancelled_ticket = 0;
            if (dt.Rows.Count > 0)
            {
                _open_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "Open");
                _progress_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "In Progress");
                _hold_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "On Hold");
                _closed_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "Closed");
                _cancelled_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "Cancelled");

                foreach (DataRow dr in dt.Rows)
                {
                    _tickets.Add(new BusinessEntities.Tools.TicketsDetail
                    {
                        ticketId = DataValidation.isIntValid(dr["ticketId"].ToString()),
                        ticket_code = DataValidation.isIntValid(dr["ticket_code"].ToString()),
                        ticket_branch = DataValidation.isIntValid(dr["ticket_branch"].ToString()),
                        ticket_subject = dr["ticket_subject"].ToString(),
                        ticket_to_dept = dr["ticket_to_dept"].ToString(),
                        ticket_priority = dr["ticket_priority"].ToString(),
                        ticket_date = DataValidation.isDateValid(dr["ticket_date"].ToString()),
                        ticket_datemodified = DataValidation.isDateValid(dr["ticket_datemodified"].ToString()),
                        ticket_status = dr["ticket_status"].ToString(),
                        ticket_description = dr["ticket_description"].ToString(),
                        ticket_statusby = dr["ticket_statusby"].ToString(),
                        ticket_madeby = DataValidation.isIntValid(dr["ticket_madeby"].ToString()),
                        ticket_reminder_date = dr["ticket_reminder_date"].ToString(),
                        ticket_reminder_message = dr["ticket_reminder_message"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        ticket_closed = dr["ticket_closed"].ToString(),
                        ticket_closedby = dr["ticket_closedby"].ToString(),
                        ticket_datecreated = dr["ticket_datecreated"].ToString(),
                        open_ticket = _open_ticket,
                        progress_ticket = _progress_ticket,
                        hold_ticket = _hold_ticket,
                        closed_ticket = _closed_ticket,
                        cancelled_ticket = _cancelled_ticket,
                        reminder_count = DataValidation.isIntValid(dr["reminder_count"].ToString()),
                    });

                }
            }
            return _tickets;
        }
        public static bool TicketStatus(string data, string status, int empId, string statusby)
        {
            return DataAccessLayer.Tools.Tickets.TicketStatus(data, status, empId, statusby);

        }
        public static TicketsList ViewTicketDetail(TicketsFilter filter)
        {
            DataTable dt = DataAccessLayer.Tools.Tickets.GetTicketsDetail(filter);
            TicketsList list = new TicketsList();
            List<BusinessEntities.Tools.TicketsDetail> _tickets = new List<BusinessEntities.Tools.TicketsDetail>();
            int _open_ticket = 0;
            int _progress_ticket = 0;
            int _hold_ticket = 0;
            int _closed_ticket = 0;
            int _cancelled_ticket = 0;
            if (dt.Rows.Count > 0)
            {
                _open_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "Open");
                _progress_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "In Progress");
                _hold_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "On Hold");
                _closed_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "Closed");
                _cancelled_ticket = dt.Rows.Cast<DataRow>().Count(dr => dr["ticket_status"].ToString() == "Cancelled");

                foreach (DataRow dr in dt.Rows)
                {
                    _tickets.Add(new BusinessEntities.Tools.TicketsDetail
                    {
                        ticketId = DataValidation.isIntValid(dr["ticketId"].ToString()),
                        ticket_code = DataValidation.isIntValid(dr["ticket_code"].ToString()),
                        ticket_branch = DataValidation.isIntValid(dr["ticket_branch"].ToString()),
                        ticket_subject = dr["ticket_subject"].ToString(),
                        ticket_to_dept = dr["ticket_to_dept"].ToString(),
                        ticket_priority = dr["ticket_priority"].ToString(),
                        ticket_date = DataValidation.isDateValid(dr["ticket_date"].ToString()),
                        ticket_datemodified = DataValidation.isDateValid(dr["ticket_datemodified"].ToString()),
                        ticket_status = dr["ticket_status"].ToString(),
                        ticket_description = dr["ticket_description"].ToString(),
                        ticket_statusby = dr["ticket_statusby"].ToString(),
                        ticket_madeby = DataValidation.isIntValid(dr["ticket_madeby"].ToString()),
                        ticket_reminder_date = dr["ticket_reminder_date"].ToString(),
                        ticket_reminder_message = dr["ticket_reminder_message"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        ticket_closed = dr["ticket_closed"].ToString(),
                        open_ticket = _open_ticket,
                        progress_ticket = _progress_ticket,
                        hold_ticket = _hold_ticket,
                        closed_ticket = _closed_ticket,
                        cancelled_ticket = _cancelled_ticket,
                    });
                }
            }
            list.ticketList = _tickets;

            return list;
        }

        //Ticket Reminder
        public static TicketReminderList GetTicketReminders(int trId, int code)
        {
            DataTable dt = DataAccessLayer.Tools.Tickets.GetTicketReminders(trId,  code);
            List<BusinessEntities.Tools.TicketReminder> _reminders = new List<BusinessEntities.Tools.TicketReminder>();  
            TicketReminderList list = new TicketReminderList();
            if (dt.Rows.Count > 0)
            {               
                foreach (DataRow dr in dt.Rows)
                {
                    _reminders.Add(new BusinessEntities.Tools.TicketReminder
                    {
                        trId = DataValidation.isIntValid(dr["trId"].ToString()),
                        tr_ticket_code = DataValidation.isIntValid(dr["tr_ticket_code"].ToString()),
                        tr_message = dr["tr_message"].ToString(),
                        tr_status = dr["tr_status"].ToString(),
                        tr_datecreated = dr["tr_datecreated"].ToString(),                        
                        tr_madeby = DataValidation.isIntValid(dr["tr_madeby"].ToString()),                       
                        madeby = dr["madeby"].ToString()                        
                    });

                }
            }
            list.ticketReminderList = _reminders;
            return list;
        }
        public static int SendTicketReminder(TicketReminder data)
        {
            return DataAccessLayer.Tools.Tickets.SendTicketReminder(data);
        }

        //Ticket Support Docs
        public static int UploadDocument(TicketDocuments doc)
        {
            return DataAccessLayer.Tools.Tickets.UploadDocument(doc);
        }
        public static List<TicketDocuments> GetDocumentsById(int id, string http_path, string folder)
        {
            List<TicketDocuments> documents = new List<TicketDocuments>();

            DataTable dt = DataAccessLayer.Tools.Tickets.GetDocumentsById(id);

            foreach (DataRow d in dt.Rows)
            {
                TicketDocuments _d = new TicketDocuments();
                _d.tdocId = int.Parse(d["tdocId"].ToString());
                _d.tdoc_ticket_code = int.Parse(d["tdoc_ticket_code"].ToString());
                _d.tdoc_name = d["tdoc_name"].ToString();

                string[] path = d["tdoc_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/TicketsAttachments/" }, StringSplitOptions.None);

                _d.tdoc_path = http_path.Trim().ToString() + "images/TicketsAttachments/" + path[1].Trim().ToString();
                _d.tdoc_status = d["tdoc_status"].ToString();
                _d.tdoc_datecreated = d["tdoc_datecreated"].ToString();
                _d.madeby = d["madeby"].ToString();
                documents.Add(_d);
            }

            return documents;
        }
        public static bool DeleteDocuments(int docId)
        {
            return DataAccessLayer.Tools.Tickets.DeleteDocuments(docId);
        }
        public static DataTable GetFilePathDownload(int id)
        {
            return DataAccessLayer.Tools.Tickets.GetFilePathDownload(id);
        }

        // Ticket Comments
        public static bool InsertComment(BusinessEntities.Tools.TicketComments data)
        {
            return DataAccessLayer.Tools.Tickets.InsertComment(data);
        }
        public static TicketCommentsResponse GetTicketComments(int Code, int empId)
        {
            DataTable dt = DataAccessLayer.Tools.Tickets.GetTicketComments(Code);
            TicketCommentsResponse list = new TicketCommentsResponse();
            List<BusinessEntities.Tools.TicketComments> _commnets = new List<BusinessEntities.Tools.TicketComments>();
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _commnets.Add(new BusinessEntities.Tools.TicketComments
                    {
                        tcId = DataValidation.isIntValid(dr["tcId"].ToString()),
                        tc_ticketCode = DataValidation.isIntValid(dr["tc_ticketCode"].ToString()),
                        tc_commnet = dr["tc_commnet"].ToString(),
                        tc_status = dr["tc_status"].ToString(),
                        tc_commnetby = dr["tc_commnetby"].ToString(),
                        tc_source = dr["tc_source"].ToString(),
                        emp_photo = string.IsNullOrEmpty(dt.Rows[0]["emp_photo"].ToString()) ? "" : dt.Rows[0]["emp_photo"].ToString(),
                        tc_datecreated = dr["tc_datecreated"].ToString()                        
                    });
                }
            }
            else
            {
                DataTable _dt = BusinessLogicLayer.Tools.Tickets.TicketSenderDetail(empId);
                if (_dt.Rows.Count > 0)
                {
                    _commnets.Add(new BusinessEntities.Tools.TicketComments
                    {
                        tcId = 0,
                        tc_ticketCode = Code,
                        tc_commnet = "",
                        tc_status = "",
                        tc_commnetby = string.IsNullOrEmpty(_dt.Rows[0]["emp_name"].ToString()) ? "" : _dt.Rows[0]["emp_name"].ToString(),
                        tc_source = "",
                        tc_datecreated = "",
                        emp_photo = string.IsNullOrEmpty(_dt.Rows[0]["emp_photo"].ToString()) ? "" : _dt.Rows[0]["emp_photo"].ToString(),
                    });                    
                }
                else {
                    _commnets.Add(new BusinessEntities.Tools.TicketComments
                    {
                        tcId = 0,
                        tc_ticketCode = Code,
                        tc_commnet = "",
                        tc_status = "",
                        tc_commnetby =  "" ,
                        tc_source = "",
                        tc_datecreated = "",
                        emp_photo = "" ,
                    });
                }
            }
            list.ticketCommentsList = _commnets;

            return list;
        }
    }
}
