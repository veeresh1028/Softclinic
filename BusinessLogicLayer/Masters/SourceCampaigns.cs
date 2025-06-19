using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class SourceCampaigns
    {
        #region Sources
        public static List<BusinessEntities.Masters.SourceCampaigns> GetSourceCampaigns(int? eqcId)
        {
            List<BusinessEntities.Masters.SourceCampaigns> sclist = new List<BusinessEntities.Masters.SourceCampaigns>();

            DataTable dt = DataAccessLayer.Masters.SourceCampaigns.GetSourceCampaigns(eqcId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.Masters.SourceCampaigns
                {
                    eqcId = Convert.ToInt32(dr["eqcId"]),
                    eqc_slno = Convert.ToInt32(dr["eqc_slno"]),
                    eqc_code = dr["eqc_code"].ToString(),
                    eqc_title = dr["eqc_title"].ToString(),
                    eqc_status = dr["eqc_status"].ToString(),
                    eqc_madeby_name = dr["eqc_madeby_name"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                });
            }
            return sclist;
        }

        public static bool InsertUpdateSource(BusinessEntities.Masters.SourceCampaigns source, out int sourceId)
        {
            return DataAccessLayer.Masters.SourceCampaigns.InsertUpdateSource(source, out sourceId);
        }

        public static int UpdateSourceCampaignstatus(int tgId, string tg_status, int eqc_madeby)
        {
            return DataAccessLayer.Masters.SourceCampaigns.UpdateSourceCampaignstatus(tgId, tg_status, eqc_madeby);
        }

        public static string GenerateSourceCode()
        {
            return DataAccessLayer.Masters.SourceCampaigns.GenerateSourceCode();
        }
        #endregion

        #region Sourcewise Campaigns
        public static List<BusinessEntities.Masters.SourcewiseCampaigns> GetCampaigns(int escId)
        {
            List<BusinessEntities.Masters.SourcewiseCampaigns> sclist = new List<BusinessEntities.Masters.SourcewiseCampaigns>();

            DataTable dt = DataAccessLayer.Masters.SourceCampaigns.GetCampaigns(escId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.Masters.SourcewiseCampaigns
                {
                    escId = Convert.ToInt32(dr["escId"]),
                    eqcId = Convert.ToInt32(dr["eqcId"]),
                    esc_eqcId = Convert.ToInt32(dr["esc_eqcId"]),
                    esc_title = dr["esc_title"].ToString(),
                    esc_desc = dr["esc_desc"].ToString(),
                    esc_status = dr["esc_status"].ToString(),
                    esc_madeby_name = dr["esc_madeby_name"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    esc_start_date = Convert.ToDateTime(dr["esc_start_date"]),
                    esc_end_date = Convert.ToDateTime(dr["esc_end_date"]),
                });
            }
            return sclist;
        }

        public static List<BusinessEntities.Masters.SourcewiseCampaigns> GetCampaignsById(int escId)
        {
            List<BusinessEntities.Masters.SourcewiseCampaigns> sclist = new List<BusinessEntities.Masters.SourcewiseCampaigns>();

            DataTable dt = DataAccessLayer.Masters.SourceCampaigns.GetCampaignsById(escId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.Masters.SourcewiseCampaigns
                {
                    escId = Convert.ToInt32(dr["escId"]),
                    esc_eqcId = Convert.ToInt32(dr["esc_eqcId"]),
                    esc_title = dr["esc_title"].ToString(),
                    esc_desc = dr["esc_desc"].ToString(),
                    esc_status = dr["esc_status"].ToString(),
                    esc_start_date = Convert.ToDateTime(dr["esc_start_date"]),
                    esc_end_date = Convert.ToDateTime(dr["esc_end_date"]),
                });
            }
            return sclist;
        }

        public static bool InsertUpdateCampaign(BusinessEntities.Masters.SourcewiseCampaigns campaign)
        {
            campaign.esc_desc = (campaign.esc_desc == "") ? string.Empty : campaign.esc_desc;

            return DataAccessLayer.Masters.SourceCampaigns.InsertUpdateCampaign(campaign);
        }

        public static int UpdateCampaignStatus(int tgId, string tg_status, int esc_madeby)
        {
            return DataAccessLayer.Masters.SourceCampaigns.UpdateCampaignStatus(tgId, tg_status, esc_madeby);
        }
        #endregion
    }
}