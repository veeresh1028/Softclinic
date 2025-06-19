using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class DentalCharting
    {
        #region DentalCharting (Page Load)


        //GET DentalCharting
        public static List<BusinessEntities.EMR.DentalCharting> GetDentalChart(int? appId, int? cdcId)
        {
            try
            {
                DataTable dt = DataAccessLayer.EMR.DentalCharting.GetDentalChart(appId, cdcId);

                List<BusinessEntities.EMR.DentalCharting> list = new List<BusinessEntities.EMR.DentalCharting>();


                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.EMR.DentalCharting a = new BusinessEntities.EMR.DentalCharting();
                    a.cdc_appId = Convert.ToInt32(dr["cdc_appId"]);
                    a.cdcId = Convert.ToInt32(dr["cdcId"]);
                    a.cdc_patId = Convert.ToInt32(dr["cdc_patId"]);
                    a.cdc_note = dr["cdc_note"].ToString();
                    a.cdc_date_created = Convert.ToDateTime(dr["cdc_date_created"]);
                    if (!string.IsNullOrEmpty(dr["cdc_chartname"].ToString()))
                    {
                        a.cdc_chartname = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + dr["cdc_chartname"].ToString();
                    }
                    else
                    {

                        a.cdc_chartname = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/tooth_chart/CHART.PNG";

                    }


                    list.Add(a);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusinessEntities.EMR.DentalCharting> GetAllPreDentalCharts(int appId, int patId)
        {
            List<BusinessEntities.EMR.DentalCharting> sclist = new List<BusinessEntities.EMR.DentalCharting>();
            DataTable dt = DataAccessLayer.EMR.DentalCharting.GetAllPreDentalCharts(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DentalCharting
                {
                    cdcId = Convert.ToInt32(dr["cdcId"]),
                    cdc_appId = Convert.ToInt32(dr["cdc_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion DentalCharting (Page Load)
        #region DentalCharting  CRUD Operations
        //upload DentalCharting
        public static bool UploadDentalChart(BusinessEntities.EMR.DentalCharting data, int empId)
        {
            return DataAccessLayer.EMR.DentalCharting.UploadDentalChart(data, empId);
        }
        public static int DeleteDentalChart(int cdcId, int cdc_madeby)
        {
            return DataAccessLayer.EMR.DentalCharting.DeleteDentalChart(cdcId, cdc_madeby);
        }

        #endregion DentalCharting  CRUD Operations

        #region Perio Chart (Page Load)
        public static BusinessEntities.EMR.Dental_PerioChart GetPerioChart(int? appId, int? perioId)
        {
            DataTable dt = DataAccessLayer.EMR.DentalCharting.GetPerioChart(appId, perioId);


            List<BusinessEntities.EMR.PerioChartDetails> list = new List<BusinessEntities.EMR.PerioChartDetails>();
            BusinessEntities.EMR.Dental_PerioChart perio = new BusinessEntities.EMR.Dental_PerioChart();
            PerioChart info = new PerioChart();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info.perioId = Convert.ToInt32(dr["perioId"]);
                info.perio_appId = Convert.ToInt32(dr["perio_appId"]);
                info.perio_tooths = dr["perio_tooths"].ToString();
                info.perio_status = dr["perio_status"].ToString();
            }
            if (info.perioId > 0)
            {
                DataTable dt1 = DataAccessLayer.EMR.DentalCharting.GetPerioChartDetails(info.perio_appId, 0);
                foreach (DataRow dr1 in dt1.Rows)
                {


                    PerioChartDetails details = new PerioChartDetails();
                    details.pchdId = Convert.ToInt32(dr1["pchdId"]);
                    details.pchd_appId = Convert.ToInt32(dr1["pchd_appId"]);
                    details.pchd_tooth = Convert.ToInt32(dr1["pchd_tooth"]);
                    details.pchd_plaque = dr1["pchd_plaque"].ToString();
                    details.pchd_mobility = dr1["pchd_mobility"].ToString();
                    details.pchd_boneloss = dr1["pchd_boneloss"].ToString();
                    details.pchd_mgd = dr1["pchd_mgd"].ToString();
                    details.pchd_calt1 = Convert.ToInt32(dr1["pchd_calt1"].ToString());
                    details.pchd_calt2 = Convert.ToInt32(dr1["pchd_calt2"].ToString());
                    details.pchd_calt3 = Convert.ToInt32(dr1["pchd_calt3"].ToString());
                    details.pchd_gmt1 = Convert.ToInt32(dr1["pchd_gmt1"].ToString());
                    details.pchd_gmt2 = Convert.ToInt32(dr1["pchd_gmt2"].ToString());
                    details.pchd_gmt3 = Convert.ToInt32(dr1["pchd_gmt3"].ToString());
                    details.pchd_pdt1 = Convert.ToInt32(dr1["pchd_pdt1"].ToString());
                    details.pchd_pdt2 = Convert.ToInt32(dr1["pchd_pdt2"].ToString());
                    details.pchd_pdt3 = Convert.ToInt32(dr1["pchd_pdt3"].ToString());
                    details.pchd_t1 = dr1["pchd_t1"].ToString();
                    details.pchd_t2 = dr1["pchd_t2"].ToString();
                    details.pchd_t3 = dr1["pchd_t3"].ToString();
                    details.pchd_t4 = dr1["pchd_t4"].ToString();
                    details.pchd_t5 = dr1["pchd_t5"].ToString();
                    details.pchd_t6 = dr1["pchd_t6"].ToString();
                    details.pchd_pdb1 = Convert.ToInt32(dr1["pchd_pdb1"].ToString());
                    details.pchd_pdb2 = Convert.ToInt32(dr1["pchd_pdb2"].ToString());
                    details.pchd_pdb3 = Convert.ToInt32(dr1["pchd_pdb3"].ToString());
                    details.pchd_gmb1 = Convert.ToInt32(dr1["pchd_gmb1"].ToString());
                    details.pchd_gmb2 = Convert.ToInt32(dr1["pchd_gmb2"].ToString());
                    details.pchd_gmb3 = Convert.ToInt32(dr1["pchd_gmb3"].ToString());
                    details.pchd_calb1 = Convert.ToInt32(dr1["pchd_calb1"].ToString());
                    details.pchd_calb2 = Convert.ToInt32(dr1["pchd_calb2"].ToString());
                    details.pchd_calb3 = Convert.ToInt32(dr1["pchd_calb3"].ToString());
                    details.pchd_status = dr1["pchd_status"].ToString();
                    list.Add(details);
                }
            }

            perio.dental_perio = info;
            perio.dental_perio_details = list;

            return perio;

        }
        public static DataTable GetPerioCharts(int? appId)
        {
            return DataAccessLayer.EMR.DentalCharting.GetPerioChart(appId, 0);
        }


        public static List<BusinessEntities.EMR.PerioChartDetails> GetPerioChartDetails(int? appId, int? id)
        {
            List<BusinessEntities.EMR.PerioChartDetails> sclist = new List<BusinessEntities.EMR.PerioChartDetails>();
            DataTable dt = DataAccessLayer.EMR.DentalCharting.GetPerioChartDetails(appId, id);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PerioChartDetails
                {
                    pchdId = Convert.ToInt32(dr["pchdId"]),
                    pchd_appId = Convert.ToInt32(dr["pchd_appId"]),
                    pchd_tooth = Convert.ToInt32(dr["pchd_tooth"]),
                    pchd_plaque = dr["pchd_plaque"].ToString(),
                    pchd_mobility = dr["pchd_mobility"].ToString(),
                    pchd_boneloss = dr["pchd_boneloss"].ToString(),
                    pchd_mgd = dr["pchd_mgd"].ToString(),
                    pchd_calt1 = Convert.ToInt32(dr["pchd_calt1"].ToString()),
                    pchd_calt2 = Convert.ToInt32(dr["pchd_calt2"].ToString()),
                    pchd_calt3 = Convert.ToInt32(dr["pchd_calt3"].ToString()),
                    pchd_gmt1 = Convert.ToInt32(dr["pchd_gmt1"].ToString()),
                    pchd_gmt2 = Convert.ToInt32(dr["pchd_gmt2"].ToString()),
                    pchd_gmt3 = Convert.ToInt32(dr["pchd_gmt3"].ToString()),
                    pchd_pdt1 = Convert.ToInt32(dr["pchd_pdt1"].ToString()),
                    pchd_pdt2 = Convert.ToInt32(dr["pchd_pdt2"].ToString()),
                    pchd_pdt3 = Convert.ToInt32(dr["pchd_pdt3"].ToString()),
                    pchd_t1 = dr["pchd_t1"].ToString(),
                    pchd_t2 = dr["pchd_t2"].ToString(),
                    pchd_t3 = dr["pchd_t3"].ToString(),
                    pchd_t4 = dr["pchd_t4"].ToString(),
                    pchd_t5 = dr["pchd_t5"].ToString(),
                    pchd_t6 = dr["pchd_t6"].ToString(),
                    pchd_pdb1 = Convert.ToInt32(dr["pchd_pdb1"].ToString()),
                    pchd_pdb2 = Convert.ToInt32(dr["pchd_pdb2"].ToString()),
                    pchd_pdb3 = Convert.ToInt32(dr["pchd_pdb3"].ToString()),
                    pchd_gmb1 = Convert.ToInt32(dr["pchd_gmb1"].ToString()),
                    pchd_gmb2 = Convert.ToInt32(dr["pchd_gmb2"].ToString()),
                    pchd_gmb3 = Convert.ToInt32(dr["pchd_gmb3"].ToString()),
                    pchd_calb1 = Convert.ToInt32(dr["pchd_calb1"].ToString()),
                    pchd_calb2 = Convert.ToInt32(dr["pchd_calb2"].ToString()),
                    pchd_calb3 = Convert.ToInt32(dr["pchd_calb3"].ToString()),
                    pchd_status = dr["pchd_status"].ToString(),


                });
            }
            return sclist;
        }

        #endregion Perio Chart (Page Load)
        #region Perio Chart  CRUD Operations
        public static int InsertPerioChart(BusinessEntities.EMR.Dental_PerioChart data, int madeby)
        {
            return DataAccessLayer.EMR.DentalCharting.InsertPerioChart(data, madeby);

        }
        public static int DeletePerioChart(int perioId, int perio_madeby)
        {
            return DataAccessLayer.EMR.DentalCharting.DeletePerioChart(perioId, perio_madeby);
        }
        #endregion Perio Chart  CRUD Operations
    }
}
