using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.Tools
{
    public class Ticket
    {
        public static bool isValidTicket(BusinessEntities.Tools.ComposeTickets data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {                
                if (string.IsNullOrEmpty(data.ticket_date))
                {
                    errors.Add("ticketdate", "Ticket Date is not valid.");
                }
                else
                {
                    if (!DateTime.TryParse(data.ticket_date.ToString(), out DateTime _out))
                        errors.Add("ticketdate", "Ticket Date is not in Correct Format.");
                }
                if (string.IsNullOrEmpty(data.ticket_subject))
                {
                    errors.Add("ticket_subject", "Enter Ticket Subject.");
                }
                if (string.IsNullOrEmpty(data.ticket_department))
                {
                    errors.Add("ticket_to_dept", "Select To Department.");
                }                
                if (string.IsNullOrEmpty(data.ticket_description))
                {
                    errors.Add("ticket_description", "Enter Ticket Description.");
                }
                if (string.IsNullOrEmpty(data.ticket_clientId))
                {
                    errors.Add("ticket_clientId", "Clinic License No. is not valid. Add in Clinic Setting.");
                }
                if (string.IsNullOrEmpty(data.ticket_clientName))
                {
                    errors.Add("ticket_client_name", "Clinic Name is  not valid. Add in Clinic Setting.");
                }
                if (string.IsNullOrEmpty(data.ticket_senderName))
                {
                    errors.Add("ticket_sender_name", "Sender Info not Valid.");
                }
                if (string.IsNullOrEmpty(data.ticket_senderDesig))
                {
                    errors.Add("ticket_sender_desig", "Sender Info not Valid.");
                }
                if (string.IsNullOrEmpty(data.ticket_priority))
                {
                    data.ticket_priority = "Low";
                }
            }
            else
            {
                errors.Add("ticketdate", "Ticket Date is not valid.");
                errors.Add("ticket_subject", "Enter Ticket Subject.");
                errors.Add("ticket_to_dept", "Select To Department.");
                errors.Add("ticket_description", "Enter Ticket Description.");
                errors.Add("ticket_clientId", "Clinic License No. is not valid. Add in Clinic Setting.");
                errors.Add("ticket_client_name", "Clinic Name is  not valid. Add in Clinic Setting.");
                errors.Add("ticket_sender_name", "Sender Info not Valid.");
                errors.Add("ticket_sender_desig", "Sender Info not Valid.");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
