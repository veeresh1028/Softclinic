using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Tab
{
    public class Feedback
    {
        public int cpfId { get; set; }
        public int cpf_appId { get; set; }
        public string cpf_text { get; set; }
        public string cpf_rating { get; set; }
        public string cpf_status { get; set; }
        public DateTime cpf_date_modified { get; set; }
    }
}