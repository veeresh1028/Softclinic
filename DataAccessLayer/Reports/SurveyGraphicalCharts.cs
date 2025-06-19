using BusinessEntities.Reports;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reports
{
    public class SurveyGraphicalCharts
    {
        public static DataTable SearchSurveyEmojisChart(SurveyGraphicalChartSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_SURVEY_EMOJIS_GRAPHICAL_CHART");

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable SearchSurveyRatingsChart(SurveyGraphicalChartSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_SURVEY_RATINGS_GRAPHICAL_CHART");

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet SearchSurveyQuestionnaireChart(SurveyGraphicalChartSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_SURVEY_QUESTIONNAIRE_GRAPHICAL_CHART");

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}