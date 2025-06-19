using BusinessEntities.Reports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class SurveyGraphicalCharts
    {
        public static List<BusinessEntities.Reports.SurveyEmojisChart> SearchSurveyEmojisChart(SurveyGraphicalChartSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.SurveyEmojisChart> reports = new List<BusinessEntities.Reports.SurveyEmojisChart>();

                DataTable dt = DataAccessLayer.Reports.SurveyGraphicalCharts.SearchSurveyEmojisChart(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.SurveyEmojisChart report = new BusinessEntities.Reports.SurveyEmojisChart();
                        report.labels = dr["psm_emoji"].ToString();
                        report.total = Convert.ToInt32(dr["total"]);
                        reports.Add(report);
                    }
                }
                else
                {
                    BusinessEntities.Reports.SurveyEmojisChart report = new BusinessEntities.Reports.SurveyEmojisChart();
                    report.labels = "N/A";
                    report.total = 0;
                    reports.Add(report);
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusinessEntities.Reports.SurveyRatingsChart> SearchSurveyRatingsChart(SurveyGraphicalChartSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.SurveyRatingsChart> reports = new List<BusinessEntities.Reports.SurveyRatingsChart>();

                DataTable dt = DataAccessLayer.Reports.SurveyGraphicalCharts.SearchSurveyRatingsChart(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.SurveyRatingsChart report = new BusinessEntities.Reports.SurveyRatingsChart();

                        report.labels = (string.IsNullOrEmpty(dr["psm_emoji"].ToString()) ? "0 Star" : dr["psm_emoji"].ToString());
                        report.total = Convert.ToInt32(dr["total"]);
                        reports.Add(report);
                    }
                }
                else
                {
                    BusinessEntities.Reports.SurveyRatingsChart report = new BusinessEntities.Reports.SurveyRatingsChart();
                    report.labels = "N/A";
                    report.total = 0;
                    reports.Add(report);
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BusinessEntities.Reports.SurveyGraphicalCharts SearchSurveyQuestionnaireChart(SurveyGraphicalChartSearch search)
        {
            try
            {
                BusinessEntities.Reports.SurveyGraphicalCharts reports = new BusinessEntities.Reports.SurveyGraphicalCharts();

                List<BusinessEntities.Reports.SurveyQuestionnaireChart> surveyQuestions = new List<BusinessEntities.Reports.SurveyQuestionnaireChart>();
                List<BusinessEntities.Reports.SurveyQuestionnaireChart> customerServices = new List<BusinessEntities.Reports.SurveyQuestionnaireChart>();
                List<BusinessEntities.Reports.SurveyQuestionnaireChart> professionalManners = new List<BusinessEntities.Reports.SurveyQuestionnaireChart>();
                List<BusinessEntities.Reports.SurveyQuestionnaireChart> recommendOthers = new List<BusinessEntities.Reports.SurveyQuestionnaireChart>();
                List<BusinessEntities.Reports.SurveyQuestionnaireChart> shareFeedbacks = new List<BusinessEntities.Reports.SurveyQuestionnaireChart>();

                DataSet ds = DataAccessLayer.Reports.SurveyGraphicalCharts.SearchSurveyQuestionnaireChart(search);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();

                            report.labels = (string.IsNullOrEmpty(dr["pff_1"].ToString()) ? "0 Star" : dr["pff_1"].ToString());
                            report.total = Convert.ToInt32(dr["total"]);
                            surveyQuestions.Add(report);
                        }
                    }
                    else
                    {
                        BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();
                        report.labels = "N/A";
                        report.total = 0;
                        surveyQuestions.Add(report);
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();

                            report.labels = (string.IsNullOrEmpty(dr["pff_2"].ToString()) ? "0 Star" : dr["pff_2"].ToString());
                            report.total = Convert.ToInt32(dr["total"]);
                            customerServices.Add(report);
                        }
                    }
                    else
                    {
                        BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();
                        report.labels = "N/A";
                        report.total = 0;
                        customerServices.Add(report);
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();

                            report.labels = (string.IsNullOrEmpty(dr["pff_3"].ToString()) ? "0 Star" : dr["pff_3"].ToString());
                            report.total = Convert.ToInt32(dr["total"]);
                            professionalManners.Add(report);
                        }
                    }
                    else
                    {
                        BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();
                        report.labels = "N/A";
                        report.total = 0;
                        professionalManners.Add(report);
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[3].Rows)
                        {
                            BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();

                            report.labels = (string.IsNullOrEmpty(dr["pff_4"].ToString()) ? "0 Star" : dr["pff_4"].ToString());
                            report.total = Convert.ToInt32(dr["total"]);
                            recommendOthers.Add(report);
                        }
                    }
                    else
                    {
                        BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();
                        report.labels = "N/A";
                        report.total = 0;
                        recommendOthers.Add(report);
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[4].Rows)
                        {
                            BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();
                            report.labels = (string.IsNullOrEmpty(dr["pff_5"].ToString()) ? "0 Star" : dr["pff_5"].ToString());
                            report.total = Convert.ToInt32(dr["total"]);
                            shareFeedbacks.Add(report);
                        }
                    }
                    else
                    {
                        BusinessEntities.Reports.SurveyQuestionnaireChart report = new BusinessEntities.Reports.SurveyQuestionnaireChart();
                        report.labels = "N/A";
                        report.total = 0;
                        shareFeedbacks.Add(report);
                    }
                }

                reports.questionnaireCharts = surveyQuestions;
                reports.customerServices = customerServices;
                reports.professionalManners = professionalManners;
                reports.recommendOthers = recommendOthers;
                reports.shareFeedbacks = shareFeedbacks;

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}