using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class DiagnosisFavourites
    {
       
            public int pdfId { get; set; }
            public int pdf_empId { get; set; }
            public string pdf_status { get; set; }
            public int pdf_madeby { get; set; }
            public string emp_license { get; set; }
            public DateTime app_fdate { get; set; }
            public string doctor_name { get; set; }
            public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

            public string diag_name { get; set; }
            public string diag_code { get; set; }
            public string pdf_notes { get; set; }
            public string pad_notes { get; set; }
            public string diag_class { get; set; }
            public string pad_ftype { get; set; }
            public string pad_fcategory { get; set; }
            public int pdf_diagnosis { get; set; }
            public int pad_diagnosis { get; set; }
           
    }
}
