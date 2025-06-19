using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class MedicationReport
    {
        public static List<BusinessEntities.KPIReports.MedicationReport> SearchMedicationReport(BusinessEntities.KPIReports.MedicationReportSearch _filters)
        {
            try
            {
                List<BusinessEntities.KPIReports.MedicationReport> reports = new List<BusinessEntities.KPIReports.MedicationReport>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.KPIReports.MedicationReport.SearchMedicationReport(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.KPIReports.MedicationReport report = new BusinessEntities.KPIReports.MedicationReport();
                        report.pre_appId = Convert.ToInt32(dr["pre_appId"]);
                        report.visit_date = Convert.ToDateTime(dr["app_fdate"]);
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_file_no = dr["pat_code"].ToString();
                        report.pat_mobile = dr["pat_mob"].ToString();
                        report.ic_type = dr["ic_name"].ToString();
                        report.payer_name = dr["ip_name"].ToString();
                        report.doctor_name = dr["emp_name"].ToString();
                        report.department_name = dr["emp_dept_name"].ToString();
                        report.item_code = dr["item_code"].ToString();
                        report.item_name = dr["item_name"].ToString();
                        report.item_brand = dr["item_brand"].ToString();
                        report.item_dosage = dr["item_dosage"].ToString();
                        report.item_strength = dr["item_strength"].ToString();
                        report.pre_temp3 = Convert.ToInt32(dr["pre_temp3"]);
                        report.pre_temp4 = Convert.ToInt32(dr["pre_temp4"]);
                        report.pre_temp5 = dr["pre_temp5"].ToString();
                        report.pre_duration = Convert.ToInt32(dr["pre_duration"]);
                        report.pre_qty_type = Convert.ToInt32(dr["pre_qty_type"]);
                        report.pre_instr = dr["pre_instr"].ToString();
                        report.pre_eRxRefNo = dr["pre_eRxRefNo"].ToString();
                        report.ra_code_desc = dr["ra_code_desc"].ToString();

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

        public static List<CommonDDL> GetPatientsByPrescriptions(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.MedicationReport.GetPatientsByPrescriptions(_data);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }

        public static List<PrescriptionsDDL> GetPrescriptions(SearchQuery medication)
        {
            DataTable dt = DataAccessLayer.KPIReports.MedicationReport.GetPrescriptions(medication);

            List<PrescriptionsDDL> data = new List<PrescriptionsDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new PrescriptionsDDL
                    {
                        id = dr["id"].ToString(),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }
    }
}