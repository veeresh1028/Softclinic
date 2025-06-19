using BusinessEntities.Appointment;
using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class DailyCollectionsReport
    {
        public static List<BusinessEntities.Reports.DailyCollectionsReport> SearchDailyCollectionsReports(DailyCollectionsReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.DailyCollectionsReport> reports = new List<BusinessEntities.Reports.DailyCollectionsReport>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now.Date;
                    search.date_to = DateTime.Now.Date;
                }

                DataTable dt = DataAccessLayer.Reports.DailyCollectionsReport.SearchDailyCollectionsReports(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.DailyCollectionsReport report = new BusinessEntities.Reports.DailyCollectionsReport();
                        report.recId = Convert.ToInt32(dr["recId"].ToString());
                        report.rec_patient = Convert.ToInt32(dr["rec_patient"].ToString());
                        report.inv_appId = Convert.ToInt32(dr["inv_appId"].ToString());
                        report.rec_type = dr["rec_type"].ToString();
                        report.rec_code = dr["rec_code"].ToString();
                        report.rec_notes = dr["rec_notes"].ToString();
                        report.tr_name = dr["tr_name"].ToString();
                        report.rec_cash = DataValidation.isDecimalValid(dr["rec_cash"].ToString());
                        report.rec_tabby = DataValidation.isDecimalValid(dr["rec_tabby"].ToString());
                        report.rec_tamara = DataValidation.isDecimalValid(dr["rec_tamara"].ToString());
                        report.rec_self = DataValidation.isDecimalValid(dr["rec_self"].ToString());
                        report.rec_spoti = DataValidation.isDecimalValid(dr["rec_spoti"].ToString());
                        report.rec_group = DataValidation.isDecimalValid(dr["rec_group"].ToString());
                        report.rec_cob = DataValidation.isDecimalValid(dr["rec_cob"].ToString());
                        report.rec_cc = DataValidation.isDecimalValid(dr["rec_cc"].ToString());
                        report.rec_cc2 = DataValidation.isDecimalValid(dr["rec_cc2"].ToString());
                        report.rec_chq = DataValidation.isDecimalValid(dr["rec_chq"].ToString());
                        report.rec_cc_charges2 = DataValidation.isDecimalValid(dr["rec_cc_charges2"].ToString());
                        report.rec_bt = DataValidation.isDecimalValid(dr["rec_bt"].ToString());
                        report.rec_debit = DataValidation.isDecimalValid(dr["rec_debit"].ToString());
                        report.rec_allocated = DataValidation.isDecimalValid(dr["rec_allocated"].ToString());
                        report.rec_balance = DataValidation.isDecimalValid(dr["rec_balance"].ToString());
                        report.received_total = DataValidation.isDecimalValid(dr["received_total"].ToString());
                        report.rec_chq_date = DataValidation.isDateTimeValid(dr["rec_chq_date"].ToString());
                        report.rec_date = DataValidation.isDateTimeValid(dr["rec_date"].ToString());
                        report.inv_date = DataValidation.isDateTimeValid(dr["inv_date"].ToString());
                        report.inv_no = dr["inv_no"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.madeby_name = dr["madeby_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.pat_code = dr["pat_code"].ToString();

                        reports.Add(report);
                    }
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CommonDDL> GetPatientsForDropdown(string query)
        {
            DataTable dt = DataAccessLayer.Reports.DailyCollectionsReport.GetPatientsForDropdown(query);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = Convert.ToInt32(dr["rec_patient"].ToString());
                    _data.text = dr["pat_details"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
    }
}