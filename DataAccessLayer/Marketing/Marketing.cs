using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Marketing;

namespace DataAccessLayer.Marketing
{
    public class Marketing
    {
        #region Page Load & Search
        public static DataTable SearchMarketing(MarketingSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_MARKETING");

                if (!string.IsNullOrEmpty(filters.branch_ids))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.branch_ids);
                }

                if (!string.IsNullOrEmpty(filters.dept_ids))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filters.dept_ids);
                }

                if (!string.IsNullOrEmpty(filters.doc_ids))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, filters.doc_ids);
                }

                if (!string.IsNullOrEmpty(filters.nats_ids))
                {
                    db.AddInParameter(dbCommand, "select_nat", DbType.String, filters.nats_ids);
                }

                if (!string.IsNullOrEmpty(filters.status))
                {
                    string app_status = string.Join(",", filters.status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_status", DbType.String, app_status);
                }

                if (!string.IsNullOrEmpty(filters.handledby))
                {
                    db.AddInParameter(dbCommand, "select_madeby", DbType.String, filters.handledby);
                }

                if (filters.patient > 0)
                {
                    db.AddInParameter(dbCommand, "select_patient", DbType.Int32, filters.patient);
                }

                if (!string.IsNullOrEmpty(filters.sources))
                {
                    db.AddInParameter(dbCommand, "select_source", DbType.String, filters.sources);
                }
                
                if (!string.IsNullOrEmpty(filters.campaigns))
                {
                    db.AddInParameter(dbCommand, "select_campaign", DbType.String, filters.campaigns);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Marketing Advanced Filters
        public static DataTable GetEmployees()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_HANDLED_BY_EMPLOYEES");

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCampaignsBySources(string sourceIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_CAMPAIGNS_BY_SOURCES");

                if (!string.IsNullOrEmpty(sourceIds))
                {
                    db.AddInParameter(dbCommand, "sourceIds", DbType.String, sourceIds);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Marketing CRUD Operations
        public static bool InsertCampaign(BusinessEntities.Masters.SourcewiseCampaigns campaign, out int campId)
        {
            try
            {
                campId = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENQ_SOURCE_CAMPAIGN_INSERT");

                db.AddInParameter(dbCommand, "esc_eqcId", DbType.Int32, campaign.esc_eqcId);
                db.AddInParameter(dbCommand, "esc_title", DbType.String, campaign.esc_title);
                db.AddInParameter(dbCommand, "esc_start_date", DbType.DateTime, campaign.esc_start_date);
                db.AddInParameter(dbCommand, "esc_end_date", DbType.DateTime, campaign.esc_end_date);
                db.AddInParameter(dbCommand, "esc_desc", DbType.String, campaign.esc_desc);
                db.AddInParameter(dbCommand, "esc_madeby", DbType.String, campaign.esc_madeby);
                db.AddOutParameter(dbCommand, "camp_output", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);

                campId = Convert.ToInt32(db.GetParameterValue(dbCommand, "camp_output"));

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
                throw ex;
            }
        }        

        public static int InsertEnquiry(BusinessEntities.Marketing.Enquiry enquiry)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Appointment_Insert");

                db.AddOutParameter(dbCommand, "appId", DbType.Int32, 100);
                db.AddInParameter(dbCommand, "app_room", DbType.Int32, enquiry.app_room);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, enquiry.app_fdate);
                db.AddInParameter(dbCommand, "app_tdate", DbType.DateTime, enquiry.app_tdate);
                db.AddInParameter(dbCommand, "app_ftime", DbType.Int32, enquiry.app_ftime);
                db.AddInParameter(dbCommand, "app_ttime", DbType.Int32, enquiry.app_ttime);
                db.AddInParameter(dbCommand, "app_ins", DbType.Int32, enquiry.app_ins);
                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, enquiry.app_doctor);
                db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, enquiry.app_madeby);
                db.AddInParameter(dbCommand, "app_type", DbType.String, enquiry.app_type);
                db.AddInParameter(dbCommand, "app_status", DbType.String, enquiry.app_status);
                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, enquiry.app_branch);
                db.AddInParameter(dbCommand, "app_inout", DbType.String, enquiry.app_inout);
                db.AddInParameter(dbCommand, "app_duplicate", DbType.Int32, enquiry.app_duplicate);
                db.AddInParameter(dbCommand, "app_rappId", DbType.Int32, enquiry.app_rappId);
                db.AddInParameter(dbCommand, "app_emergency", DbType.String, enquiry.app_emergency);
                db.AddInParameter(dbCommand, "app_source", DbType.Int32, enquiry.app_source);
                db.AddInParameter(dbCommand, "app_campaign", DbType.Int32, enquiry.app_campaign);
                db.AddInParameter(dbCommand, "app_status2", DbType.String, enquiry.app_status2);
                db.AddInParameter(dbCommand, "app_eligibility", DbType.String, enquiry.app_eligibility);
                db.AddInParameter(dbCommand, "app_po", DbType.Int32, enquiry.app_po);
                db.AddInParameter(dbCommand, "app_Comments", DbType.String, enquiry.app_comments);
                db.AddInParameter(dbCommand, "app_service", DbType.Int32, enquiry.app_service);
                db.AddInParameter(dbCommand, "app_category", DbType.String, "Cash");


                int data = db.ExecuteNonQuery(dbCommand);

                int _appId = Convert.ToInt32(db.GetParameterValue(dbCommand, "appId"));

                return _appId;
            }
            catch (Exception ex)
            {
                throw  ex;
            }
        }

        public static DataTable GetInquiryById(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_BY_ID");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateEnquiry(BusinessEntities.Marketing.Enquiry enquiry)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Appointment_update");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, enquiry.appId);
                db.AddInParameter(dbCommand, "app_room", DbType.Int32, enquiry.app_room);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, enquiry.app_fdate);
                db.AddInParameter(dbCommand, "app_tdate", DbType.DateTime, enquiry.app_tdate);
                db.AddInParameter(dbCommand, "app_ftime", DbType.Int32, enquiry.app_ftime);
                db.AddInParameter(dbCommand, "app_ttime", DbType.Int32, enquiry.app_ttime);
                db.AddInParameter(dbCommand, "app_ins", DbType.Int32, enquiry.app_ins);
                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, enquiry.app_doctor);
                db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, enquiry.app_madeby);
                db.AddInParameter(dbCommand, "app_type", DbType.String, enquiry.app_type);
                db.AddInParameter(dbCommand, "app_status", DbType.String, enquiry.app_status);
                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, enquiry.app_branch);
                db.AddInParameter(dbCommand, "app_inout", DbType.String, enquiry.app_inout);
                db.AddInParameter(dbCommand, "app_duplicate", DbType.Int32, enquiry.app_duplicate);
                db.AddInParameter(dbCommand, "app_emergency", DbType.String, enquiry.app_emergency);
                db.AddInParameter(dbCommand, "app_source", DbType.Int32, enquiry.app_source);
                db.AddInParameter(dbCommand, "app_campaign", DbType.Int32, enquiry.app_campaign);
                db.AddInParameter(dbCommand, "app_status2", DbType.String, enquiry.app_status2);
                db.AddInParameter(dbCommand, "app_eligibility", DbType.String, enquiry.app_eligibility);
                db.AddInParameter(dbCommand, "app_po", DbType.Int32, enquiry.app_po);
                db.AddInParameter(dbCommand, "app_Comments", DbType.String, enquiry.app_comments);
                db.AddInParameter(dbCommand, "app_service", DbType.Int32, enquiry.app_service);

                int data = db.ExecuteNonQuery(dbCommand);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
