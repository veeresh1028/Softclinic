using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Marketing.Reports
{
    public class GraphicalReport
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class GraphicalChartsData
    {
        public List<GraphicalManagedChart> mbChart { get; set; }
        public List<GraphicalSourceChart> sourceChart { get; set; }
        public List<GraphicalStatusChart> statusChart { get; set; }
    }

    public class GraphicalManagedChart
    {
        public string labels { get; set; }
        public int total { get; set; }
    }

    public class GraphicalSourceChart
    {
        public string labels { get; set; }
        public int total { get; set; }
    }
    
    public class GraphicalStatusChart
    {
        public string labels { get; set; }
        public int total { get; set; }
    }
}
