using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class SurveyGraphicalCharts
    {
        public List<SurveyQuestionnaireChart> questionnaireCharts = new List<SurveyQuestionnaireChart>();
        public List<SurveyQuestionnaireChart> customerServices = new List<SurveyQuestionnaireChart>();
        public List<SurveyQuestionnaireChart> professionalManners = new List<SurveyQuestionnaireChart>();
        public List<SurveyQuestionnaireChart> recommendOthers = new List<SurveyQuestionnaireChart>();
        public List<SurveyQuestionnaireChart> shareFeedbacks = new List<SurveyQuestionnaireChart>();
    }

    public class SurveyGraphicalChartSearch
    {
        public DateTime date_from { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public DateTime date_to { get; set; } = DateTime.Parse(DateTime.Now.AddDays(1).ToString());
    }

    public class SurveyEmojisChart
    {
        public string labels { get; set; }
        public int total { get; set; }
    }

    public class SurveyRatingsChart
    {
        public string labels { get; set; }
        public int total { get; set; }
    }

    public class SurveyQuestionnaireChart
    {
        public string labels { get; set; }
        public int total { get; set; }
    }
}
