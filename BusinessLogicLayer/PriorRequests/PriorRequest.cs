using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using BusinessEntities.PriorRequests;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.PriorRequests
{
    public class PriorRequest
    {
        public static List<PriorAppointmentList> SearchPriorAppointments(PriorAppointmentSearch data, out PriorAppointmentCount Priorapp_count, out PriorAppointmentStatusColor Prioraps_color)
        {
            Priorapp_count = new PriorAppointmentCount();
            Prioraps_color = new PriorAppointmentStatusColor();
            List<PriorAppointmentList> PriorappointmentList = new List<PriorAppointmentList>();

            if (data.search_type == 0)
            {
                data.date_from = DateTime.Now.Date;
                data.date_to = DateTime.Now.Date.AddDays(1);
            }

            DataTable dt = DataAccessLayer.PriorRequests.PriorRequest.SearchPriorAppointments(data);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PriorAppointmentList app = new PriorAppointmentList();
                    app.appId = Convert.ToInt32(dr["appId"]);
                    app.app_pat_code = dr["app_pat_code"].ToString();
                    app.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                    app.app_status = dr["app_status"].ToString();
                    app.app_type = dr["app_type"].ToString();
                    app.app_doc_ftime = dr["app_doc_ftime"].ToString();
                    app.app_doc_ttime = dr["app_doc_ttime"].ToString();
                    app.app_resnforvisit = dr["app_resnforvisit"].ToString();
                    app.app_branch = Convert.ToInt32(dr["app_branch"]);
                    app.app_inout = dr["app_inout"].ToString();
                    app.app_doctor = Convert.ToInt32(dr["app_doctor"]);
                    app.app_emergency = dr["app_emergency"].ToString();
                    app.app_room = Convert.ToInt32(dr["app_room"]);
                    app.app_ftime = dr["app_ftime"].ToString();
                    app.app_ttime = dr["app_ttime"].ToString();
                    app.app_ins = Convert.ToInt32(dr["app_ins"]);
                    app.app_eligibility = dr["app_eligibility"].ToString();
                    app.app_po = Convert.ToInt32(dr["app_po"]);
                    app.app_service = Convert.ToInt32(dr["app_service"]);
                    app.app_patient = Convert.ToInt32(dr["app_patient"]);
                    app.app_comments = dr["app_comments"].ToString();
                    app.app_comments = dr["app_comments"].ToString();
                    app.app_category = dr["app_category"].ToString();
                    app.set_emr_lock = dr["set_emr_lock"].ToString();
                    app.app_AuthStatus = dr["app_AuthStatus"].ToString();

                    app.patId = Convert.ToInt32(dr["patId"].ToString());
                    app.pat_gender = dr["pat_gender"].ToString();
                    app.pat_dob = Convert.ToDateTime(dr["pat_dob"].ToString());
                    app.pat_name = dr["pat_name"].ToString();
                    app.pat_emirateid = dr["pat_emirateid"].ToString();
                    app.pat_mob = dr["pat_mob"].ToString();
                    app.pat_class = dr["pat_class"].ToString();
                    app.pat_referal = Convert.ToInt32(dr["pat_referal"].ToString());
                    app.pat_email = dr["pat_email"].ToString();
                    app.id_card_edate = Convert.ToDateTime(dr["id_card_edate"].ToString());

                    app.empId = Convert.ToInt32(dr["empId"].ToString());
                    app.emp_name = dr["emp_name"].ToString();
                    app.emp_dept_name = dr["emp_dept_name"].ToString();
                    app.emp_license = dr["emp_license"].ToString();
                    app.emp_color = dr["emp_color"].ToString();

                    app.aps_color = dr["aps_color"].ToString();
                    app.room = dr["room"].ToString();
                    app.nationality = dr["nationality"].ToString();

                    app.ins_exp = dr["ins_exp"].ToString();

                    app.pendings = Convert.ToInt32(dr["pendings"]);
                    app.date_arrived = Convert.ToDateTime(dr["date_arrived"].ToString());
                    app.date_invoiced = Convert.ToDateTime(dr["date_invoiced"].ToString());
                    //app.app_ae_date = DataValidation.isDateValid(dr["app_ae_date"].ToString());


                    if (!string.IsNullOrEmpty(dr["pat_photo"].ToString()))
                    {
                        app.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pat_photo"].ToString();
                    }
                    else
                    {
                        if (app.pat_gender.ToLower().StartsWith("f"))
                        {
                            app.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                        }
                        else
                        {
                            app.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                        }
                    }

                    PriorappointmentList.Add(app);
                }
            }

            // Prior Requests Appointment Status Count
            Priorapp_count.PriorRequest = dt.Select("app_AuthStatus = 'Prior Requests'").Count();
            Priorapp_count.InReview = dt.Select("app_AuthStatus = 'InReview'").Count();
            Priorapp_count.ReadytoSubmit = dt.Select("app_AuthStatus = 'ReadytoSubmit'").Count();
            Priorapp_count.SubmittedforApproval = dt.Select("app_AuthStatus = 'SubmittedforApproval'").Count();
            Priorapp_count.Approved = dt.Select("app_AuthStatus = 'Approved'").Count();
            Priorapp_count.PartlyApproved = dt.Select("app_AuthStatus = 'PartlyApproved'").Count();
            Priorapp_count.Rejected = dt.Select("app_AuthStatus = 'Rejected'").Count();
            Priorapp_count.Cancelled = dt.Select("app_AuthStatus = 'Cancelled'").Count();
            Priorapp_count.Resubmitted = dt.Select("app_AuthStatus = 'Resubmitted'").Count();
            Priorapp_count.Total = Priorapp_count.PriorRequest + Priorapp_count.InReview + Priorapp_count.ReadytoSubmit + Priorapp_count.Cancelled + Priorapp_count.Approved + Priorapp_count.PartlyApproved + Priorapp_count.Rejected + Priorapp_count.Cancelled + Priorapp_count.Resubmitted;

            // Prior Requests Appointment Status Color
            Prioraps_color.PriorRequest = (Priorapp_count.PriorRequest > 0) ? dt.Select("app_AuthStatus = 'Prior Requests'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.InReview = (Priorapp_count.InReview > 0) ? dt.Select("app_AuthStatus = 'InReview'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.ReadytoSubmit = (Priorapp_count.ReadytoSubmit > 0) ? dt.Select("app_AuthStatus = 'ReadytoSubmit'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.SubmittedforApproval = (Priorapp_count.SubmittedforApproval > 0) ? dt.Select("app_AuthStatus = 'SubmittedforApproval'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.Approved = (Priorapp_count.Approved > 0) ? dt.Select("app_AuthStatus = 'Approved'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.PartlyApproved = (Priorapp_count.PartlyApproved > 0) ? dt.Select("app_AuthStatus = 'PartlyApproved'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.Rejected = (Priorapp_count.Rejected > 0) ? dt.Select("app_AuthStatus = 'Rejected'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.Cancelled = (Priorapp_count.Cancelled > 0) ? dt.Select("app_AuthStatus = 'Cancelled'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
            Prioraps_color.Resubmitted = (Priorapp_count.Resubmitted > 0) ? dt.Select("app_AuthStatus = 'Resubmitted'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";

            return PriorappointmentList;
        }
        public static List<PriorReqDownloadList> GetPriorReqDownloadList(PriorAppointmentSearch data)
        {
            List<PriorReqDownloadList> PriorReqDownloadList = new List<PriorReqDownloadList>();
            if (data.search_type == 0)
            {
                data.date_from = DateTime.Now.Date;
                data.date_to = DateTime.Now.Date.AddDays(1);
            }
            DataTable dt = DataAccessLayer.PriorRequests.PriorRequest.GetPriorReqDownloadList(data);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PriorReqDownloadList app = new PriorReqDownloadList();
                    app.ID = Convert.ToInt32(dr["ID"]);
                    app.XMLFile = dr["XMLFile"].ToString();
                    app.pxd_senderId_name = dr["pxd_senderId_name"].ToString();
                    app.XML_type = dr["XML_type"].ToString();
                    app.pxd_TransactionDate = dr["pxd_TransactionDate"].ToString();
                    app.pxd_Result = dr["pxd_Result"].ToString();
                    app.pxd_IDPayer = dr["pxd_IDPayer"].ToString();
                    app.pxd_Start = dr["pxd_Start"].ToString();
                    app.pxd_End = dr["pxd_End"].ToString();
                    app.pxd_DenialCode_desc = dr["pxd_DenialCode_desc"].ToString();
                    app.pxd_Comments = dr["pxd_Comments"].ToString();

                    PriorReqDownloadList.Add(app);
                }
            }
            return PriorReqDownloadList;
        }

        #region Prior Requests JqueryDatatable Miscellaneous Actions
        public static List<CommonDDL> GetProceduresAlert(int appId)
        {
            List<CommonDDL> pendinglist = new List<CommonDDL>();

            DataSet dt = DataAccessLayer.PriorRequests.PriorRequest.GetProceduresAlert(appId);

            //foreach (DataRow dr in dt.Rows.)
            //{
            //    pendinglist.Add(new CommonDDL
            //    {
            //        id = Convert.ToInt32(dr["emr_actId"]),
            //        text = dr["emr_act_name"].ToString()
            //    });
            //}
            return pendinglist;
        }

        public static string DeletePriorRequests(int appId, int app_madeby)
        {
            return DataAccessLayer.PriorRequests.PriorRequest.DeletePriorRequest(appId, app_madeby);
        }

        public static string ChangeStatusPriorRequest(int appId, string app_AuthStatus, int app_madeby)
        {
            return DataAccessLayer.PriorRequests.PriorRequest.ChangeStatusPriorRequest(appId, app_AuthStatus, app_madeby);
        }
        //public static int PRIOR_AUTH_XML_Insert(string filePath, string extractedPath, string s_status)
        //{
        //    return DataAccessLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Insert(filePath, extractedPath, s_status);
        //}
        //public static int PRIOR_AUTH_XML_Details_Insert(PriorAuthXMLDetails px, int pxda_madeby_name)
        //{
        //    return DataAccessLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(px, pxda_madeby_name);
        //}

        //public static int PRIOR_AUTH_XML_Insert_Single(BusinessEntities.PriorRequests.PriorAuthXML PriorAuthXML)
        //{
        //    return DataAccessLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Insert_Single(PriorAuthXML);
        //}

        public static int PRIOR_AUTH_XML_Insert(List<BusinessEntities.PriorRequests.PriorAuthXML> PriorAuthXML)
        {


            DataTable dt = new DataTable();
            dt.Columns.Add("XMLData", typeof(string));
            dt.Columns.Add("XMLFile", typeof(string));
            dt.Columns.Add("XML_type", typeof(string));

            if (PriorAuthXML.Count > 0)
            {
                foreach (BusinessEntities.PriorRequests.PriorAuthXML px in PriorAuthXML)
                {
                    DataRow dr = dt.NewRow();
                    dr["XMLData"] = px.XMLData;
                    dr["XMLFile"] = px.XMLFile;
                    dr["XML_type"] = px.XML_type;
                    dt.Rows.Add(dr);
                }
            }
            return DataAccessLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_BulkInsert(dt);
        }

        public static int PRIOR_AUTH_XML_Details_Insert(List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> PriorAuth, int pxda_madeby)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("pxd_SenderID", typeof(string));
            dt.Columns.Add("pxd_ReceiverID", typeof(string));
            dt.Columns.Add("pxd_TransactionDate", typeof(string));
            dt.Columns.Add("pxd_Result", typeof(string));
            dt.Columns.Add("pxd_ID", typeof(string));
            dt.Columns.Add("pxd_IDPayer", typeof(string));
            dt.Columns.Add("pxd_DenialCode", typeof(string));
            dt.Columns.Add("pxd_Start", typeof(string));
            dt.Columns.Add("pxd_End", typeof(string));
            dt.Columns.Add("pxd_Comments", typeof(string));
            dt.Columns.Add("pxd_ActID", typeof(string));
            dt.Columns.Add("pxd_Atype", typeof(string));
            dt.Columns.Add("pxd_ACode", typeof(string));
            dt.Columns.Add("pxd_AQty", typeof(string));
            dt.Columns.Add("pxd_Net", typeof(string));

            dt.Columns.Add("pxd_Share", typeof(string));
            dt.Columns.Add("pxd_Apay", typeof(string));
            dt.Columns.Add("pxd_xmlfile", typeof(string));
            dt.Columns.Add("pxd_ptcomments", typeof(string));

            if (PriorAuth.Count > 0)
            {
                foreach (BusinessEntities.PriorRequests.PriorAuthXMLDetails px in PriorAuth)
                {
                    DataRow dr = dt.NewRow();
                    dr["pxd_SenderID"] = px.pxd_SenderID;
                    dr["pxd_ReceiverID"] = px.pxd_ReceiverID;
                    dr["pxd_TransactionDate"] = px.pxd_TransactionDate;
                    dr["pxd_Result"] = px.pxd_Result;
                    dr["pxd_ID"] = px.pxd_ID;
                    dr["pxd_IDPayer"] = px.pxd_IDPayer;
                    dr["pxd_DenialCode"] = px.pxd_DenialCode;
                    dr["pxd_Start"] = px.pxd_Start;
                    dr["pxd_End"] = px.pxd_End;
                    dr["pxd_Comments"] = px.pxd_Comments;
                    dr["pxd_ActID"] = px.pxd_ActID;
                    dr["pxd_Atype"] = px.pxd_Atype;
                    dr["pxd_ACode"] = px.pxd_ACode;
                    dr["pxd_AQty"] = px.pxd_AQty;
                    dr["pxd_Net"] = px.pxd_Net;
                    dr["pxd_Share"] = px.pxd_Share;
                    dr["pxd_Apay"] = px.pxd_Apay;
                    dr["pxd_xmlfile"] = px.pxd_xmlfile;
                    dr["pxd_ptcomments"] = px.pxd_ptcomments;
                    dt.Rows.Add(dr);
                }
            }
            return DataAccessLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_BulkInsert(dt, pxda_madeby);
        }

        public static DataSet GetByID(int appId, int empId)
        {
            return DataAccessLayer.PriorRequests.PriorRequest.GetByID(appId, empId);
        }
        public static int UPDATE_INS_ELIGIBILITY_DATA_IN_APPOINTMENT(string file_name, int empId)
        {
            return DataAccessLayer.PriorRequests.PriorRequest.UPDATE_INS_ELIGIBILITY_DATA_IN_APPOINTMENT(file_name, empId);
        }

        public static bool IS_ALREADY_INSERTED_IN_TABLE(string XMLFile)
        {
            int IsInserted = DataAccessLayer.PriorRequests.PriorRequest.IS_ALREADY_INSERTED_IN_TABLE(XMLFile);

            if (IsInserted == 1) return true;
            else return false;
        }

        public static DataTable GetBranchesForPriorReq()
        {
            return DataAccessLayer.PriorRequests.PriorRequest.GetBranchesForPriorReq();
        }
        #endregion
    }
}
