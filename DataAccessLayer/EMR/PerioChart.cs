using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class PerioChart
    {
        public static int InsertPerioChart(BusinessEntities.EMR.PerioChart data, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_PERIO_CHART_INSERT_UPDATE");
                if (data.perioId > 0)
                {
                    db.AddInParameter(dbCommand, "perioId", DbType.Int32, data.perioId);
                }
                db.AddInParameter(dbCommand, "perio_appId", DbType.Int32, data.perio_appId);
                db.AddInParameter(dbCommand, "perio_tooths", DbType.String, data.perio_tooths);
                db.AddInParameter(dbCommand, "perio_madeby", DbType.Int32, madeby);


                return Convert.ToInt32(db.ExecuteNonQuery(dbCommand));
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static int InsertPerioChartDetails(BusinessEntities.EMR.PerioChartDetails data, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENTAL_PERIO_CHART_DETAIL_INSERT_UPDATE");
                if (data.pchdId > 0)
                {
                    db.AddInParameter(dbCommand, "pchdId", DbType.Int32, data.pchdId);
                }
                db.AddInParameter(dbCommand, "pchd_appId", DbType.Int32, data.pchd_appId);
                db.AddInParameter(dbCommand, "pchd_tooth", DbType.Int32, data.pchd_tooth);
                db.AddInParameter(dbCommand, "pchd_plaque", DbType.String, data.pchd_plaque);
                db.AddInParameter(dbCommand, "pchd_mobility", DbType.String, data.pchd_mobility);
                db.AddInParameter(dbCommand, "pchd_boneloss", DbType.String, data.pchd_boneloss);
                db.AddInParameter(dbCommand, "pchd_mgd", DbType.String, data.pchd_mgd);
                db.AddInParameter(dbCommand, "pchd_calt1", DbType.Int32, data.pchd_calt1);
                db.AddInParameter(dbCommand, "pchd_calt2", DbType.Int32, data.pchd_calt2);
                db.AddInParameter(dbCommand, "pchd_calt3", DbType.Int32, data.pchd_calt3);
                db.AddInParameter(dbCommand, "pchd_gmt1", DbType.Int32, data.pchd_gmt1);
                db.AddInParameter(dbCommand, "pchd_gmt2", DbType.Int32, data.pchd_gmt2);
                db.AddInParameter(dbCommand, "pchd_gmt3", DbType.Int32, data.pchd_gmt3);
                db.AddInParameter(dbCommand, "pchd_pdt1", DbType.Int32, data.pchd_pdt1);
                db.AddInParameter(dbCommand, "pchd_pdt2", DbType.Int32, data.pchd_pdt2);
                db.AddInParameter(dbCommand, "pchd_pdt3", DbType.Int32, data.pchd_pdt3);
                db.AddInParameter(dbCommand, "pchd_t1", DbType.String, data.pchd_t1);
                db.AddInParameter(dbCommand, "pchd_t2", DbType.String, data.pchd_t2);
                db.AddInParameter(dbCommand, "pchd_t3", DbType.String, data.pchd_t3);
                db.AddInParameter(dbCommand, "pchd_t4", DbType.String, data.pchd_t4);
                db.AddInParameter(dbCommand, "pchd_t5", DbType.String, data.pchd_t5);
                db.AddInParameter(dbCommand, "pchd_t6", DbType.String, data.pchd_t6);
                db.AddInParameter(dbCommand, "pchd_pdb1", DbType.Int32, data.pchd_pdb1);
                db.AddInParameter(dbCommand, "pchd_pdb2", DbType.Int32, data.pchd_pdb2);
                db.AddInParameter(dbCommand, "pchd_pdb3", DbType.Int32, data.pchd_pdb3);
                db.AddInParameter(dbCommand, "pchd_gmb1", DbType.Int32, data.pchd_gmb1);
                db.AddInParameter(dbCommand, "pchd_gmb2", DbType.Int32, data.pchd_gmb2);
                db.AddInParameter(dbCommand, "pchd_gmb3", DbType.Int32, data.pchd_gmb3);
                db.AddInParameter(dbCommand, "pchd_calb1", DbType.Int32, data.pchd_calb1);
                db.AddInParameter(dbCommand, "pchd_calb2", DbType.Int32, data.pchd_calb2);
                db.AddInParameter(dbCommand, "pchd_calb3", DbType.Int32, data.pchd_calb3);

                db.AddInParameter(dbCommand, "pchd_madeby", DbType.Int32, madeby);


                return Convert.ToInt32(db.ExecuteNonQuery(dbCommand));
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
