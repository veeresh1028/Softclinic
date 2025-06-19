using BusinessEntities.Appointment;
using BusinessEntities.Marketing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Marketing
{
    public class Marketing
    {
        #region Page Load & Search
        public static List<BusinessEntities.Marketing.Marketing> SearchMarketing(MarketingSearch filters)
        {
            try
            {
                List<BusinessEntities.Marketing.Marketing> marketingList = new List<BusinessEntities.Marketing.Marketing>();

                if (filters.search_type == 0)
                {
                    filters.date_from = DateTime.Now.Date;
                    filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Marketing.Marketing.SearchMarketing(filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Marketing.Marketing mk = new BusinessEntities.Marketing.Marketing();

                        mk.appId = Convert.ToInt32(dr["appId"]);
                        mk.app_pat_code = dr["app_pat_code"].ToString();
                        mk.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        mk.app_date_created = Convert.ToDateTime(dr["app_date_created"]);
                        mk.app_status = dr["app_status"].ToString();
                        mk.app_status2 = dr["app_status2"].ToString();
                        mk.app_doc_ftime = dr["app_doc_ftime"].ToString();
                        mk.app_doc_ttime = dr["app_doc_ttime"].ToString();
                        mk.app_branch = Convert.ToInt32(dr["app_branch"]);
                        mk.app_source = Convert.ToInt32(dr["app_source"]);
                        mk.app_campaign = Convert.ToInt32(dr["app_campaign"]);
                        mk.app_doctor = Convert.ToInt32(dr["app_doctor"]);
                        mk.app_ins = Convert.ToInt32(dr["app_ins"]);
                        mk.app_patient = Convert.ToInt32(dr["app_patient"]);
                        mk.app_madeby_name = dr["app_madeby_name"].ToString();
                        mk.app_comments = dr["app_comments"].ToString();

                        mk.patId = Convert.ToInt32(dr["patId"].ToString());
                        mk.pat_name = dr["pat_name"].ToString();
                        mk.pat_mob = dr["pat_mob"].ToString();
                        mk.pat_class = dr["pat_class"].ToString();
                        mk.pat_email = dr["pat_email"].ToString();

                        mk.empId = Convert.ToInt32(dr["empId"].ToString());
                        mk.emp_name = dr["emp_name"].ToString();
                        mk.emp_dept_name = dr["emp_dept_name"].ToString();
                        mk.emp_license = dr["emp_license"].ToString();
                        mk.emp_color = dr["emp_color"].ToString();

                        mk.aps_color = dr["aps_color"].ToString();
                        mk.nationality = dr["nationality"].ToString();
                        mk.ar_fllowupdate = Convert.ToDateTime(dr["ar_fllowupdate"].ToString());
                        mk.ar_fllowtime = dr["ar_fllowtime"].ToString();
                        mk.source_details = dr["source_details"].ToString();
                        mk.campaign_details = dr["campaign_details"].ToString();

                        marketingList.Add(mk);
                    }
                }

                return marketingList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Marketing Advanced Filters
        public static List<CommonDDL> GetEmployees()
        {
            DataTable dt = DataAccessLayer.Marketing.Marketing.GetEmployees();

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

        public static List<CommonDDL> GetSources()
        {
            List<CommonDDL> sclist = new List<CommonDDL>();
            DataTable dt = DataAccessLayer.Masters.SourceCampaigns.GetSourceCampaigns(0);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["eqcId"]),
                    text = dr["eqc_title"].ToString()
                });
            }
            return sclist;
        }

        public static List<CommonDDL> GetCampaignsBySources(string sourceIds)
        {
            List<CommonDDL> sclist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Marketing.Marketing.GetCampaignsBySources(sourceIds);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["escId"]),
                    text = dr["esc_title"].ToString()
                });
            }
            return sclist;
        }
        #endregion

        #region Marketing CRUD Operations
        public static bool InsertCampaign(BusinessEntities.Masters.SourcewiseCampaigns campaign, out int campId)
        {
            return DataAccessLayer.Marketing.Marketing.InsertCampaign(campaign, out campId);
        }

        public static int InsertEnquiry(BusinessEntities.Marketing.Enquiry enquiry)
        {
            enquiry.app_doctor = 1;
            enquiry.app_ftime = 1;
            enquiry.app_ttime = 1;

            enquiry.app_emergency = "NO";
            enquiry.app_ins = enquiry.app_patient;
            enquiry.app_duplicate = (enquiry.app_duplicate == 0) ? 1 : enquiry.app_duplicate;
            enquiry.app_emergency = string.Empty;
            enquiry.app_tdate = enquiry.app_fdate;
            enquiry.app_inout = "Out Patient";
            enquiry.app_type = "First Time";
            enquiry.app_status = "Enquiry";
            enquiry.app_status2 = "Marketing";
            enquiry.app_status2 = "Marketing";

            return DataAccessLayer.Marketing.Marketing.InsertEnquiry(enquiry);
        }

        public static Enquiry GetInquiryById(int appId)
        {
            Enquiry enquiry = new Enquiry();

            DataTable dt = DataAccessLayer.Marketing.Marketing.GetInquiryById(appId);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                enquiry.appId = Convert.ToInt32(dr["appId"]);
                enquiry.app_branch = Convert.ToInt32(dr["app_branch"]);
                enquiry.app_source = Convert.ToInt32(dr["app_source"]);
                enquiry.app_campaign = Convert.ToInt32(dr["app_campaign"]);
                enquiry.app_ins = Convert.ToInt32(dr["app_ins"]);
                enquiry.app_patient = Convert.ToInt32(dr["app_patient"]);
                enquiry.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                enquiry.app_status = dr["app_status"].ToString();
                enquiry.app_comments = dr["app_comments"].ToString();
            }

            return enquiry;
        }

        public static int UpdateEnquiry(BusinessEntities.Marketing.Enquiry enquiry)
        {
            enquiry.app_doctor = 1;
            enquiry.app_ftime = 1;
            enquiry.app_ttime = 1;
            enquiry.app_tdate = enquiry.app_fdate;
            enquiry.app_ins = enquiry.app_patient;
            enquiry.app_duplicate = (enquiry.app_duplicate == 0) ? 1 : enquiry.app_duplicate;

            return DataAccessLayer.Marketing.Marketing.UpdateEnquiry(enquiry);
        }
        #endregion
    }
}