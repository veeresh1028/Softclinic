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
    public class DoctorTreatmentTypewiseReport
    {
        public static List<BusinessEntities.Reports.DoctorTreatmentTypewiseReport> GetTreatmentTypewiseReport(DoctorTreatmentTypewiseSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.DoctorTreatmentTypewiseReport> reports = new List<BusinessEntities.Reports.DoctorTreatmentTypewiseReport>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.DoctorTreatmentTypewiseReport.GetDoctorsCollectionsReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.DoctorTreatmentTypewiseReport report = new BusinessEntities.Reports.DoctorTreatmentTypewiseReport();
                        report.doc_name = dr["emp_name"].ToString();
                        report.patients = DataValidation.isIntValid(dr["total_inv_app"].ToString());
                        report.total_consulatation = DataValidation.isDecimalValid(dr["total_cc"].ToString());
                        report.total_procedure = DataValidation.isDecimalValid(dr["total_pc"].ToString());
                        report.total_laboratory = DataValidation.isDecimalValid(dr["total_lab"].ToString());
                        report.total_radiology = DataValidation.isDecimalValid(dr["total_rad"].ToString());
                        report.total_pharmacy = DataValidation.isDecimalValid(dr["total_pha"].ToString());
                        report.total_vat = DataValidation.isDecimalValid(dr["total_vat"].ToString());
                        report.total_income = report.total_consulatation + report.total_procedure + report.total_laboratory + report.total_radiology + report.total_pharmacy;

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
    }
}