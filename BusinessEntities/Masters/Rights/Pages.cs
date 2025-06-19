using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters.Rights
{
    public class Pages
    {
        public int L3Id { get; set; }
        public int L1Id { get; set; }
        public int L2Id { get; set; }
        public string L3_Value { get; set; }
        public string L3_Status { get; set; }
    }

    public class PageAccess
    {
        public int EmpId { get; set; }
        public int L3Id { get; set; }
        public bool isCreate { get; set; }
        public bool isUpdate { get; set; }
        public bool isRead { get; set; }
        public bool isDelete { get; set; }
        public bool isExport { get; set; }
        public bool isPrint { get; set; }
        public bool isAllChecked { get; set; }
    }

    public class DesignationPageAccess
    {
        public int DesiId { get; set; }
        public int L3Id { get; set; }
        public bool isCreate { get; set; }
        public bool isUpdate { get; set; }
        public bool isRead { get; set; }
        public bool isDelete { get; set; }
        public bool isExport { get; set; }
        public bool isPrint { get; set; }
        public bool isAllChecked { get; set; }
    }
}