using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.Documentation
{
    public class CoderQueries
    {
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public int qaId { get; set; }
        public int app_doctor { get; set; }
        public int qa_branch { get; set; }
        public string qa_branch_name { get; set; }
        public string qa_subject { get; set; }
        public string pat_name_code { get; set; }
        public string qa_date_display { get; set; }
        public string qa_from_name { get; set; }
        public string qa_to_name { get; set; }
        public string qa_type_name { get; set; }
        [AllowHtml]
        public string qa_query { get; set; }
        public string qa_screen { get; set; }
        [AllowHtml]
        public string response { get; set; }
        public string qa_status { get; set; }
        public int qa_appId { get; set; }
        public int qa_from { get; set; }
        public int qa_to { get; set; }
        public DateTime qa_date { get; set; }
        public int qa_type { get; set; }
        public int qa_close { get; set; }
        public DateTime qa_close_date { get; set; }
        public int qa_madeby { get; set; }
        public List<string> DocumentPaths { get; set; }
        public DateTime qa_date_created { get; set; }
        public DateTime qa_date_modified { get; set; }
        public string DocumentName { get; set; }
        public string Documentpath { get; set; }
        public string emp_photo { get; set; }
        public FileInfo file { get; set; }
        public List<CoderQueryItem> Items { get; set; }
    }

    public class FileInformation
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int CoderQueryId { get; set; }
    }

    public class CoderQueryItem
    {
        public int Id { get; set; }
        public string qa_from { get; set; }
        public string qa_query { get; set; }
        public DateTime qa_date_created { get; set; }
    }
}