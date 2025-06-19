using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Tools
{
    public class ComposeTickets
    {
        public int ticketId { get; set; }
        public string ticket_date { get; set; }
        public int ticket_code { get; set; }
        public int ticket_branch { get; set; }
        public string ticket_subject { get; set; }
        public string ticket_department { get; set; }
        public string ticket_priority { get; set; }
        public string ticket_status { get; set; }
        public int ticket_madeby { get; set; }
        public string ticket_description { get; set; }
        public string ticket_clientId { get; set; }
        public string ticket_clientName { get; set; }
        public string ticket_senderName { get; set; }
        public int ticket_senderId { get; set; }
        public string ticket_senderDesig { get; set; }
        public string ticket_from { get; set; }

    }
    public class TicketsList
    {
        public List<TicketsDetail> ticketList { get; set; }
    }

    public class TicketsFilter
    {
        public int ticketId { get; set; }
        public string ticket_date_from { get; set; }
        public string ticket_date_to { get; set; }
        public string ticket_clientId { get; set; }
        public int ticket_code { get; set; }
        public int ticket_branch { get; set; }
        public string ticket_subject { get; set; }
        public string ticket_to_dept { get; set; }
        public string ticket_priority { get; set; }
        public string ticket_status { get; set; }
        public int ticket_madeby { get; set; }
        public int empId { get; set; }
    }
    public class TicketsDetail
    {
        public int ticketId { get; set; }
        public string ticket_date { get; set; }
        public int ticket_code { get; set; }
        public int ticket_branch { get; set; }
        public string ticket_subject { get; set; }
        public string ticket_to_dept { get; set; }
        public string ticket_priority { get; set; }
        public string ticket_status { get; set; }
        public int ticket_madeby { get; set; }
        public string ticket_description { get; set; }
        public string ticket_clientId { get; set; }
        public string ticket_client_name { get; set; }
        public string ticket_sender_name { get; set; }
        public int ticket_sender_id { get; set; }
        public string ticket_sender_desig { get; set; }
        public string ticket_datemodified { get; set; }
        public string ticket_statusby { get; set; }
        public string ticket_reminder_date { get; set; }
        public string ticket_reminder_message { get; set; }
        public string madeby { get; set; }
        public string ticket_closed { get; set; }
        public string ticket_closedby { get; set; }
        public string ticket_datecreated { get; set; }
        public int open_ticket { get; set; }
        public int progress_ticket { get; set; }
        public int hold_ticket { get; set; }
        public int closed_ticket { get; set; }
        public int cancelled_ticket { get; set; }
        public int reminder_count { get; set; }

    }

    public class TicketReminder
    {
        public int trId { get; set; }
        public int tr_ticket_code { get; set; }
        public string tr_message { get; set; }
        public int tr_madeby { get; set; }
        public string madeby { get; set; }
        public string tr_status { get; set; }
        public string tr_datecreated { get; set; }
    }
    public class TicketReminderList
    {
        public string request_id { get; set; }
        public int ticket_code { get; set; }
        public int code { get; set; }
        public string error_message { get; set; }
        public List<TicketReminder> ticketReminderList { get; set; }        
    }

    public class TicketDocuments
    {
        public int tdocId { get; set;}
        public int tdoc_ticket_code { get; set;}
        public string tdoc_name { get; set;}
        public string tdoc_path { get; set;}
        public int tdoc_uploadedby { get; set;}
        public string tdoc_status { get; set;}
        public string tdoc_datecreated { get; set;}
        public string madeby { get; set;}
        public FileInfo file { get; set; }
    }
    public class TicketResponse
    {
        public string request_id { get; set; }
        public int ticket_code { get; set; }
        public int code { get; set; }
        public string error_message { get; set; }
    }
    public class TicketMedia
    {
        public int ticket_code { get; set; }
        public int tdocId { get; set; }
        public string Data { get; set; }
        public string file_name { get; set; }
        public string uploadedby { get; set; }
    }
    public class TicketComments
    {
        public int tcId { get; set; }
        public int tc_ticketCode { get; set; }
        public string tc_commnet { get; set; }
        public string tc_status { get; set; }
        public string tc_commnetby { get; set; }
        public string tc_source { get; set; }
        public string tc_datecreated { get; set; }
        public string emp_photo { get; set; }
        public int tc_commnetby_ID { get; set; }
    }
    public class TicketCommentsResponse
    {
        public string request_id { get; set; }
        public int ticket_code { get; set; }
        public int code { get; set; }
        public string error_message { get; set; }
        public List<TicketComments>  ticketCommentsList { get; set; }
    }
    public class TicketsListResponse
    {
        public string request_id { get; set; }
        public int ticket_code { get; set; }
        public int code { get; set; }
        public string error_message { get; set; }
        public TicketsList ticket_List { get; set; }
    }
}
