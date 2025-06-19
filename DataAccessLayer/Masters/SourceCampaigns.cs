using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.Masters
{
    public class SourceCampaigns
    {
        #region Source
        public static DataTable GetSourceCampaigns(int? eqcId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_select_all_info");

                if (eqcId > 0)
                {
                    db.AddInParameter(dbCommand, "eqcId", DbType.Int32, eqcId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateSource(BusinessEntities.Masters.SourceCampaigns source, out int sourceId)
        {
            try
            {
                sourceId = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_INSERT_UPDATE");

                if (source.eqcId > 0)
                {
                    db.AddInParameter(dbCommand, "eqcId", DbType.Int32, source.eqcId);
                }

                db.AddInParameter(dbCommand, "eqc_code", DbType.String, source.eqc_code);
                db.AddInParameter(dbCommand, "eqc_title", DbType.String, source.eqc_title);
                db.AddInParameter(dbCommand, "eqc_madeby", DbType.String, source.eqc_madeby);

                db.AddOutParameter(dbCommand, "esc_output", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);

                sourceId = Convert.ToInt32(db.GetParameterValue(dbCommand, "esc_output"));

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

        public static int UpdateSourceCampaignstatus(int eqcId, string eqc_status, int eqc_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_update_status");

                db.AddInParameter(dbCommand, "eqcId", DbType.Int32, eqcId);
                db.AddInParameter(dbCommand, "eqc_status", DbType.String, eqc_status);
                db.AddInParameter(dbCommand, "eqc_madeby", DbType.Int32, eqc_madeby);
                db.AddOutParameter(dbCommand, "eqc_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "eqc_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string GenerateSourceCode()
        {
            try
            {
                string scode_output = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GenerateSourceCode");

                db.AddOutParameter(dbCommand, "scode_output", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                scode_output = db.GetParameterValue(dbCommand, "scode_output").ToString();

                return scode_output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Sourcewise Campaigns
        public static DataTable GetCampaigns(int? escId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_CAMPAIGN_select_all_info");

                if (escId > 0)
                {
                    db.AddInParameter(dbCommand, "escId", DbType.Int32, escId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetCampaignsById(int escId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_CAMPAIGN_BYID");

                db.AddInParameter(dbCommand, "escId", DbType.Int32, escId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateCampaignStatus(int escId, string esc_status, int esc_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_CAMPAIGN_update_status");

                db.AddInParameter(dbCommand, "escId", DbType.Int32, escId);
                db.AddInParameter(dbCommand, "esc_status", DbType.String, esc_status);
                db.AddInParameter(dbCommand, "esc_madeby", DbType.Int32, esc_madeby);
                db.AddOutParameter(dbCommand, "esc_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "esc_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateCampaign(BusinessEntities.Masters.SourcewiseCampaigns campaign)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_CAMPAIGN_INSERT_UPDATE");

                if (campaign.escId > 0)
                {
                    db.AddInParameter(dbCommand, "escId", DbType.Int32, campaign.escId);
                }

                db.AddInParameter(dbCommand, "esc_eqcId", DbType.Int32, campaign.esc_eqcId);
                db.AddInParameter(dbCommand, "esc_title", DbType.String, campaign.esc_title);
                db.AddInParameter(dbCommand, "esc_desc", DbType.String, campaign.esc_desc);
                db.AddInParameter(dbCommand, "esc_start_date", DbType.DateTime, campaign.esc_start_date);
                db.AddInParameter(dbCommand, "esc_end_date", DbType.DateTime, campaign.esc_end_date);
                db.AddInParameter(dbCommand, "esc_madeby", DbType.String, campaign.esc_madeby);

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
        #endregion
    }
}