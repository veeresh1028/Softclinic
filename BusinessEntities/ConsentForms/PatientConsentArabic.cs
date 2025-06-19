using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class PatientConsentArabic
    {
        public int pcaId { get; set; }
        public int pca_appId { get; set; }
        public string pca_1 { get; set; }
        public string pca_2 { get; set; }
        public string pca_3 { get; set; }
        public string pca_4 { get; set; }
        public string pca_5 { get; set; }
        public string pca_6 { get; set; }
        public string pca_7 { get; set; }
        public string pca_status { get; set; }
    }
    public class ConsentArabicPreviousHistory
    {
        public int formId { get; set; }
        public int appId { get; set; }
        public string emp_license { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string app_fdate { get; set; }

    }
}
