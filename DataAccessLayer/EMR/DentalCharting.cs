using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Invoice;
using BusinessEntities.EMR;

namespace DataAccessLayer.EMR
{
    public class DentalCharting
    {


        #region DentalCharting (Page Load)
        public static DataTable GetAllPreDentalCharts(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_CHART_PREVIOUS");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Get eSignature
        public static DataTable GetDentalChart(int? appId, int? cdcId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_CHART_Select");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "cdc_appId", DbType.Int32, appId);
                }
                if (cdcId > 0)
                {
                    db.AddInParameter(dbCommand, "cdcId", DbType.Int32, cdcId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion DentalCharting (Page Load)
        #region DentalCharting  CRUD Operations
        //upload DentalCharting
        public static bool UploadDentalChart(BusinessEntities.EMR.DentalCharting data, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_CHART_INSERT_UPDATE");
                if (data.cdcId > 0)
                {
                    db.AddInParameter(dbCommand, "cdcId", DbType.Int32, data.cdcId);
                }
                db.AddInParameter(dbCommand, "cdc_appId", DbType.Int32, data.cdc_appId);
                db.AddInParameter(dbCommand, "cdc_patId", DbType.Int32, data.cdc_patId);
                db.AddInParameter(dbCommand, "cdc_madeby", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "cdc_chartname", DbType.String, data.image);
                db.AddInParameter(dbCommand, "cdc_note", DbType.String, data.cdc_note);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int DeleteDentalChart(int cdcId, int cdc_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_CHART_delete");

                db.AddInParameter(dbCommand, "cdcId", DbType.Int32, cdcId);
                db.AddInParameter(dbCommand, "cdc_madeby", DbType.String, cdc_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion DentalCharting  CRUD Operations

        #region Perio Chart (Page Load)
        public static DataTable GetPerioChart(int? perio_appId, int? perioId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_PERIO_CHART_select_all_info");
                if (perioId > 0)
                {
                    db.AddInParameter(dbCommand, "perioId", DbType.Int32, perioId);
                }
                if (perio_appId > 0)
                {
                    db.AddInParameter(dbCommand, "perio_appId", DbType.Int32, perio_appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPerioChartDetails(int? perio_appId, int? id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_PERIO_CHART_DETAIL_select_all_info");
                if (id > 0)
                {
                    db.AddInParameter(dbCommand, "pchdId", DbType.Int32, id);
                }
                if (perio_appId > 0)
                {
                    db.AddInParameter(dbCommand, "pchd_appId", DbType.Int32, perio_appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Perio Chart (Page Load)

        #region Perio Chart  CRUD Operations
        public static int InsertPerioChart(BusinessEntities.EMR.Dental_PerioChart perio, int madeby)
        {
            int count = 0;
            int perioId = 0;

            List<PerioChartDetails> list = perio.dental_perio_details;

            //Patient datas
            foreach (PerioChartDetails i in list)
            {
                BusinessEntities.EMR.PerioChartDetails data = new BusinessEntities.EMR.PerioChartDetails();
                data.pchd_appId = perio.dental_perio.perio_appId;
                data.pchdId = i.pchdId;
                data.pchd_tooth = i.pchd_tooth;
                data.pchd_plaque = string.IsNullOrEmpty(i.pchd_plaque) ? string.Empty : i.pchd_plaque.ToString();
                data.pchd_mobility = string.IsNullOrEmpty(i.pchd_mobility) ? string.Empty : i.pchd_mobility.ToString();
                data.pchd_boneloss = string.IsNullOrEmpty(i.pchd_boneloss) ? string.Empty : i.pchd_boneloss.ToString();
                data.pchd_mgd = string.IsNullOrEmpty(i.pchd_mgd) ? string.Empty : i.pchd_mgd.ToString();
                data.pchd_calt1 = i.pchd_calt1;
                data.pchd_calt2 = i.pchd_calt2;
                data.pchd_calt3 = i.pchd_calt3;
                data.pchd_gmt1 = i.pchd_gmt1;
                data.pchd_gmt2 = i.pchd_gmt2;
                data.pchd_gmt3 = i.pchd_gmt3;
                data.pchd_pdt1 = i.pchd_pdt1;
                data.pchd_pdt2 = i.pchd_pdt2;
                data.pchd_pdt3 = i.pchd_pdt3;
                data.pchd_t1 = string.IsNullOrEmpty(i.pchd_t1) ? string.Empty : i.pchd_t1.ToString();
                data.pchd_t2 = string.IsNullOrEmpty(i.pchd_t2) ? string.Empty : i.pchd_t2.ToString();
                data.pchd_t3 = string.IsNullOrEmpty(i.pchd_t3) ? string.Empty : i.pchd_t3.ToString();
                data.pchd_t4 = string.IsNullOrEmpty(i.pchd_t4) ? string.Empty : i.pchd_t4.ToString();
                data.pchd_t5 = string.IsNullOrEmpty(i.pchd_t5) ? string.Empty : i.pchd_t5.ToString();
                data.pchd_t6 = string.IsNullOrEmpty(i.pchd_t6) ? string.Empty : i.pchd_t6.ToString();
                data.pchd_pdb1 = i.pchd_pdb1;
                data.pchd_pdb2 = i.pchd_pdb2;
                data.pchd_pdb3 = i.pchd_pdb3;
                data.pchd_gmb1 = i.pchd_gmb1;
                data.pchd_gmb2 = i.pchd_gmb2;
                data.pchd_gmb3 = i.pchd_gmb3;
                data.pchd_calb1 = i.pchd_calb1;
                data.pchd_calb2 = i.pchd_calb2;
                data.pchd_calb3 = i.pchd_calb3;

                int val = DataAccessLayer.EMR.PerioChart.InsertPerioChartDetails(data, madeby);

                if (val > 0)
                {
                    count++;
                }


            }

            //Invoice
            if (count > 0)
            {
                BusinessEntities.EMR.PerioChart _Perio = new BusinessEntities.EMR.PerioChart();
                _Perio.perioId = perio.dental_perio.perioId;
                _Perio.perio_appId = perio.dental_perio.perio_appId;
                _Perio.perio_tooths = perio.dental_perio.perio_tooths;

                perioId = DataAccessLayer.EMR.PerioChart.InsertPerioChart(_Perio, madeby);
            }

            return perioId;

        }

        public static int DeletePerioChart(int perioId, int perio_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_PERIO_CHART_DELETE");

                db.AddInParameter(dbCommand, "perioId", DbType.Int32, perioId);
                db.AddInParameter(dbCommand, "perio_madeby", DbType.String, perio_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Perio Chart  CRUD Operations

    }
}
