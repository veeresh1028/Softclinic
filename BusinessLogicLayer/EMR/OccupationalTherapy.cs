using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class OccupationalTherapy
    {
        #region  Approval Revision Request (Page Load)
        public static List<BusinessEntities.EMR.RevisionRequest> GetAllApprovalRevisionRequest(int? appId, int? carr_Id)
        {
            List<BusinessEntities.EMR.RevisionRequest> sclist = new List<BusinessEntities.EMR.RevisionRequest>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllApprovalRevisionRequest(appId, carr_Id);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.RevisionRequest
                {
                    carr_Id = Convert.ToInt32(dr["carr_Id"]),
                    carr_appId = Convert.ToInt32(dr["carr_appId"]),
                    carr_e1 = dr["carr_e1"].ToString(),
                    carr_e2 = dr["carr_e2"].ToString(),
                    carr_e3 = dr["carr_e3"].ToString(),
                    carr_e4 = dr["carr_e4"].ToString(),
                    carr_e5 = dr["carr_e5"].ToString(),
                    carr_e6 = dr["carr_e6"].ToString(),
                    carr_e7 = dr["carr_e7"].ToString(),
                    carr_checkbox = dr["carr_checkbox"].ToString(),
                    carr_other = dr["carr_other"].ToString(),
                    carr_date = Convert.ToDateTime(dr["carr_date"].ToString()),
                    carr_date_created = Convert.ToDateTime(dr["carr_date_created"].ToString()),
                    carr_status = dr["carr_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.RevisionRequest> GetAllPreApprovalRevisionRequest(int appId, int patId)
        {
            List<BusinessEntities.EMR.RevisionRequest> sclist = new List<BusinessEntities.EMR.RevisionRequest>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllPreApprovalRevisionRequest(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.RevisionRequest
                {
                    carr_Id = Convert.ToInt32(dr["carr_Id"]),
                    carr_appId = Convert.ToInt32(dr["carr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Approval Revision Request (Page Load)
        #region  Approval Revision Request CRUD Operations
        public static bool InsertUpdateApprovalRevisionRequest(BusinessEntities.EMR.RevisionRequest data)
        {
            data.carr_e1 = string.IsNullOrEmpty(data.carr_e1) ? "0" : data.carr_e1;
            data.carr_e2 = string.IsNullOrEmpty(data.carr_e2) ? string.Empty : data.carr_e2;
            data.carr_e3 = (data.carr_e3 == "Invalid date") ? string.Empty : data.carr_e3;
            data.carr_e4 = (data.carr_e4 == "Invalid date") ? string.Empty : data.carr_e4;
            data.carr_e5 = string.IsNullOrEmpty(data.carr_e5) ? "0" : data.carr_e5;
            data.carr_e6 = string.IsNullOrEmpty(data.carr_e6) ? "0" : data.carr_e6;
            data.carr_e7 = string.IsNullOrEmpty(data.carr_e7) ? "0" : data.carr_e7;
            data.carr_checkbox = string.IsNullOrEmpty(data.carr_checkbox) ? string.Empty : data.carr_checkbox;
            data.carr_other = string.IsNullOrEmpty(data.carr_other) ? string.Empty : data.carr_other;
            DateTime? carr_date_ = data.carr_date; // Assuming data.car_d1 is of type DateTime?            
            if (data.carr_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.carr_date = carr_date_.HasValue ? carr_date_.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.carr_date = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.OccupationalTherapy.InsertUpdateApprovalRevisionRequest(data);
        }

        public static int DeleteApprovalRevisionRequest(int carr_Id, int carr_madeby)
        {
            return DataAccessLayer.EMR.OccupationalTherapy.DeleteApprovalRevisionRequest(carr_Id, carr_madeby);
        }
        #endregion  Approval Revision Request CRUD Operations

        #region  FIM Instrument (Page Load)
        public static List<BusinessEntities.EMR.FIMInstrument> GetAllFIMInstrument(int? appId, int? cfim_Id)
        {
            List<BusinessEntities.EMR.FIMInstrument> sclist = new List<BusinessEntities.EMR.FIMInstrument>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllFIMInstrument(appId, cfim_Id);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.FIMInstrument
                {
                    cfim_Id = Convert.ToInt32(dr["cfim_Id"]),
                    cfim_appId = Convert.ToInt32(dr["cfim_appId"]),
                    
                    cfim_a1 = dr["cfim_a1"].ToString(),
                    cfim_a2 = dr["cfim_a2"].ToString(),
                    cfim_a3 = dr["cfim_a3"].ToString(),
                    cfim_b1 = dr["cfim_b1"].ToString(),
                    cfim_b2 = dr["cfim_b2"].ToString(),
                    cfim_b3 = dr["cfim_b3"].ToString(),
                    cfim_c1 = dr["cfim_c1"].ToString(),
                    cfim_c2 = dr["cfim_c2"].ToString(),
                    cfim_c3 = dr["cfim_c3"].ToString(),
                    cfim_d1 = dr["cfim_d1"].ToString(),
                    cfim_d2 = dr["cfim_d2"].ToString(),
                    cfim_d3 = dr["cfim_d3"].ToString(),
                    cfim_e1 = dr["cfim_e1"].ToString(),
                    cfim_e2 = dr["cfim_e2"].ToString(),
                    cfim_e3 = dr["cfim_e3"].ToString(),
                    cfim_f1 = dr["cfim_f1"].ToString(),
                    cfim_f2 = dr["cfim_f2"].ToString(),
                    cfim_f3 = dr["cfim_f3"].ToString(),
                    cfim_g1 = dr["cfim_g1"].ToString(),
                    cfim_g2 = dr["cfim_g2"].ToString(),
                    cfim_g3 = dr["cfim_g3"].ToString(),
                    cfim_h1 = dr["cfim_h1"].ToString(),
                    cfim_h2 = dr["cfim_h2"].ToString(),
                    cfim_h3 = dr["cfim_h3"].ToString(),
                    cfim_i1 = dr["cfim_i1"].ToString(),
                    cfim_i2 = dr["cfim_i2"].ToString(),
                    cfim_i3 = dr["cfim_i3"].ToString(),
                    cfim_j1 = dr["cfim_j1"].ToString(),
                    cfim_j2 = dr["cfim_j2"].ToString(),
                    cfim_j3 = dr["cfim_j3"].ToString(),
                    cfim_k1 = dr["cfim_k1"].ToString(),
                    cfim_k2 = dr["cfim_k2"].ToString(),
                    cfim_k3 = dr["cfim_k3"].ToString(),
                    cfim_l1 = dr["cfim_l1"].ToString(),
                    cfim_l2 = dr["cfim_l2"].ToString(),
                    cfim_l3 = dr["cfim_l3"].ToString(),
                    cfim_m1 = dr["cfim_m1"].ToString(),
                    cfim_m2 = dr["cfim_m2"].ToString(),
                    cfim_m3 = dr["cfim_m3"].ToString(),
                    cfim_n1 = dr["cfim_n1"].ToString(),
                    cfim_n2 = dr["cfim_n2"].ToString(),
                    cfim_n3 = dr["cfim_n3"].ToString(),
                    cfim_o1 = dr["cfim_o1"].ToString(),
                    cfim_o2 = dr["cfim_o2"].ToString(),
                    cfim_o3 = dr["cfim_o3"].ToString(),
                    cfim_p1 = dr["cfim_p1"].ToString(),
                    cfim_p2 = dr["cfim_p2"].ToString(),
                    cfim_p3 = dr["cfim_p3"].ToString(),
                    cfim_q1 = dr["cfim_q1"].ToString(),
                    cfim_q2 = dr["cfim_q2"].ToString(),
                    cfim_q3 = dr["cfim_q3"].ToString(),
                    cfim_r1 = dr["cfim_r1"].ToString(),
                    cfim_r2 = dr["cfim_r2"].ToString(),
                    cfim_r3 = dr["cfim_r3"].ToString(),
                    cfim_mss1 = dr["cfim_mss1"].ToString(),
                    cfim_mss2 = dr["cfim_mss2"].ToString(),
                    cfim_mss3 = dr["cfim_mss3"].ToString(),
                    cfim_css1 = dr["cfim_css1"].ToString(),
                    cfim_css2 = dr["cfim_css2"].ToString(),
                    cfim_css3 = dr["cfim_css3"].ToString(),
                    cfim_tfs1 = dr["cfim_tfs1"].ToString(),
                    cfim_tfs2 = dr["cfim_tfs2"].ToString(),
                    cfim_tfs3 = dr["cfim_tfs3"].ToString(),
                    cfim_witness = dr["cfim_witness"].ToString(),
                    cfim_comments = dr["cfim_comments"].ToString(),
                    cfim_date = Convert.ToDateTime(dr["cfim_date"].ToString()),
                    cfim_date_created = Convert.ToDateTime(dr["cfim_date_created"].ToString()),
                    cfim_status = dr["cfim_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.FIMInstrument> GetAllPreFIMInstrument(int appId, int patId)
        {
            List<BusinessEntities.EMR.FIMInstrument> sclist = new List<BusinessEntities.EMR.FIMInstrument>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllPreFIMInstrument(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.FIMInstrument
                {
                    cfim_Id = Convert.ToInt32(dr["cfim_Id"]),
                    cfim_appId = Convert.ToInt32(dr["cfim_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  FIM Instrument (Page Load)
        #region  FIM Instrument CRUD Operations
        public static bool InsertUpdateFIMInstrument(BusinessEntities.EMR.FIMInstrument data)
        {

            data.cfim_a1 = string.IsNullOrEmpty(data.cfim_a1) ? "0" : data.cfim_a1;
            data.cfim_a2 = string.IsNullOrEmpty(data.cfim_a2) ? "0" : data.cfim_a2;
            data.cfim_a3 = string.IsNullOrEmpty(data.cfim_a3) ? "0" : data.cfim_a3;
            data.cfim_b1 = string.IsNullOrEmpty(data.cfim_b1) ? "0" : data.cfim_b1;
            data.cfim_b2 = string.IsNullOrEmpty(data.cfim_b2) ? "0" : data.cfim_b2;
            data.cfim_b3 = string.IsNullOrEmpty(data.cfim_b3) ? "0" : data.cfim_b3;
            data.cfim_c1 = string.IsNullOrEmpty(data.cfim_c1) ? "0" : data.cfim_c1;
            data.cfim_c2 = string.IsNullOrEmpty(data.cfim_c2) ? "0" : data.cfim_c2;
            data.cfim_c3 = string.IsNullOrEmpty(data.cfim_c3) ? "0" : data.cfim_c3;
            data.cfim_d1 = string.IsNullOrEmpty(data.cfim_d1) ? "0" : data.cfim_d1;
            data.cfim_d2 = string.IsNullOrEmpty(data.cfim_d2) ? "0" : data.cfim_d2;
            data.cfim_d3 = string.IsNullOrEmpty(data.cfim_d3) ? "0" : data.cfim_d3;
            data.cfim_e1 = string.IsNullOrEmpty(data.cfim_e1) ? "0" : data.cfim_e1;
            data.cfim_e2 = string.IsNullOrEmpty(data.cfim_e2) ? "0" : data.cfim_e2;
            data.cfim_e3 = string.IsNullOrEmpty(data.cfim_e3) ? "0" : data.cfim_e3;
            data.cfim_f1 = string.IsNullOrEmpty(data.cfim_f1) ? "0" : data.cfim_f1;
            data.cfim_f2 = string.IsNullOrEmpty(data.cfim_f2) ? "0" : data.cfim_f2;
            data.cfim_f3 = string.IsNullOrEmpty(data.cfim_f3) ? "0" : data.cfim_f3;
            data.cfim_g1 = string.IsNullOrEmpty(data.cfim_g1) ? "0" : data.cfim_g1;
            data.cfim_g2 = string.IsNullOrEmpty(data.cfim_g2) ? "0" : data.cfim_g2;
            data.cfim_g3 = string.IsNullOrEmpty(data.cfim_g3) ? "0" : data.cfim_g3;
            data.cfim_h1 = string.IsNullOrEmpty(data.cfim_h1) ? "0" : data.cfim_h1;
            data.cfim_h2 = string.IsNullOrEmpty(data.cfim_h2) ? "0" : data.cfim_h2;
            data.cfim_h3 = string.IsNullOrEmpty(data.cfim_h3) ? "0" : data.cfim_h3;
            data.cfim_i1 = string.IsNullOrEmpty(data.cfim_i1) ? "0" : data.cfim_i1;
            data.cfim_i2 = string.IsNullOrEmpty(data.cfim_i2) ? "0" : data.cfim_i2;
            data.cfim_i3 = string.IsNullOrEmpty(data.cfim_i3) ? "0" : data.cfim_i3;
            data.cfim_j1 = string.IsNullOrEmpty(data.cfim_j1) ? "0" : data.cfim_j1;
            data.cfim_j2 = string.IsNullOrEmpty(data.cfim_j2) ? "0" : data.cfim_j2;
            data.cfim_j3 = string.IsNullOrEmpty(data.cfim_j3) ? "0" : data.cfim_j3;
            data.cfim_k1 = string.IsNullOrEmpty(data.cfim_k1) ? "0" : data.cfim_k1;
            data.cfim_k2 = string.IsNullOrEmpty(data.cfim_k2) ? "0" : data.cfim_k2;
            data.cfim_k3 = string.IsNullOrEmpty(data.cfim_k3) ? "0" : data.cfim_k3;
            data.cfim_l1 = string.IsNullOrEmpty(data.cfim_l1) ? "0" : data.cfim_l1;
            data.cfim_l2 = string.IsNullOrEmpty(data.cfim_l2) ? "0" : data.cfim_l2;
            data.cfim_l3 = string.IsNullOrEmpty(data.cfim_l3) ? "0" : data.cfim_l3;
            data.cfim_m1 = string.IsNullOrEmpty(data.cfim_m1) ? "0" : data.cfim_m1;
            data.cfim_m2 = string.IsNullOrEmpty(data.cfim_m2) ? "0" : data.cfim_m2;
            data.cfim_m3 = string.IsNullOrEmpty(data.cfim_m3) ? "0" : data.cfim_m3;
            data.cfim_n1 = string.IsNullOrEmpty(data.cfim_n1) ? "0" : data.cfim_n1;
            data.cfim_n2 = string.IsNullOrEmpty(data.cfim_n2) ? "0" : data.cfim_n2;
            data.cfim_n3 = string.IsNullOrEmpty(data.cfim_n3) ? "0" : data.cfim_n3;
            data.cfim_o1 = string.IsNullOrEmpty(data.cfim_o1) ? "0" : data.cfim_o1;
            data.cfim_o2 = string.IsNullOrEmpty(data.cfim_o2) ? "0" : data.cfim_o2;
            data.cfim_o3 = string.IsNullOrEmpty(data.cfim_o3) ? "0" : data.cfim_o3;
            data.cfim_p1 = string.IsNullOrEmpty(data.cfim_p1) ? "0" : data.cfim_p1;
            data.cfim_p2 = string.IsNullOrEmpty(data.cfim_p2) ? "0" : data.cfim_p2;
            data.cfim_p3 = string.IsNullOrEmpty(data.cfim_p3) ? "0" : data.cfim_p3;
            data.cfim_q1 = string.IsNullOrEmpty(data.cfim_q1) ? "0" : data.cfim_q1;
            data.cfim_q2 = string.IsNullOrEmpty(data.cfim_q2) ? "0" : data.cfim_q2;
            data.cfim_q3 = string.IsNullOrEmpty(data.cfim_q3) ? "0" : data.cfim_q3;
            data.cfim_r1 = string.IsNullOrEmpty(data.cfim_r1) ? "0" : data.cfim_r1;
            data.cfim_r2 = string.IsNullOrEmpty(data.cfim_r2) ? "0" : data.cfim_r2;
            data.cfim_r3 = string.IsNullOrEmpty(data.cfim_r3) ? "0" : data.cfim_r3;
            data.cfim_mss1 = string.IsNullOrEmpty(data.cfim_mss1) ? "0" : data.cfim_mss1;
            data.cfim_mss2 = string.IsNullOrEmpty(data.cfim_mss2) ? "0" : data.cfim_mss2;
            data.cfim_mss3 = string.IsNullOrEmpty(data.cfim_mss3) ? "0" : data.cfim_mss3;
            data.cfim_css1 = string.IsNullOrEmpty(data.cfim_css1) ? "0" : data.cfim_css1;
            data.cfim_css2 = string.IsNullOrEmpty(data.cfim_css2) ? "0" : data.cfim_css2;
            data.cfim_css3 = string.IsNullOrEmpty(data.cfim_css3) ? "0" : data.cfim_css3;
            data.cfim_tfs1 = string.IsNullOrEmpty(data.cfim_tfs1) ? "0" : data.cfim_tfs1;
            data.cfim_tfs2 = string.IsNullOrEmpty(data.cfim_tfs2) ? "0" : data.cfim_tfs2;
            data.cfim_tfs3 = string.IsNullOrEmpty(data.cfim_tfs3) ? "0" : data.cfim_tfs3;
            data.cfim_witness = string.IsNullOrEmpty(data.cfim_witness) ? string.Empty : data.cfim_witness;
            data.cfim_comments = string.IsNullOrEmpty(data.cfim_comments) ? string.Empty : data.cfim_comments;
            DateTime? cfim_date_ = data.cfim_date; // Assuming data.car_d1 is of type DateTime?            
            if (data.cfim_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cfim_date = cfim_date_.HasValue ? cfim_date_.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cfim_date = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.OccupationalTherapy.InsertUpdateFIMInstrument(data);
        }

        public static int DeleteFIMInstrument(int cfim_Id, int cfim_madeby)
        {
            return DataAccessLayer.EMR.OccupationalTherapy.DeleteFIMInstrument(cfim_Id, cfim_madeby);
        }
        #endregion  FIM Instrument CRUD Operations


        #region  Monthly Evaluation (Page Load)
        public static List<BusinessEntities.EMR.MonthlyEvaluation> GetAllMonthlyEvaluation(int? appId, int? cme_Id)
        {
            List<BusinessEntities.EMR.MonthlyEvaluation> sclist = new List<BusinessEntities.EMR.MonthlyEvaluation>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllMonthlyEvaluation(appId, cme_Id);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MonthlyEvaluation
                {
                    cme_Id = Convert.ToInt32(dr["cme_Id"]),
                    cme_appId = Convert.ToInt32(dr["cme_appId"]),
                    cme_Imp = dr["cme_Imp"].ToString(),
                    cme_gmsCmt = dr["cme_gmsCmt"].ToString(),
                    cme_fmsCmt = dr["cme_fmsCmt"].ToString(),
                    cme_pmiCmt = dr["cme_pmiCmt"].ToString(),
                    cme_wsCmt = dr["cme_wsCmt"].ToString(),
                    cme_csCmt = dr["cme_csCmt"].ToString(),
                    cme_sisCmt = dr["cme_sisCmt"].ToString(),
                    cme_checkbox = dr["cme_checkbox"].ToString(),
                    cme_bssCmt = dr["cme_bssCmt"].ToString(),
                    cme_adlCmt = dr["cme_adlCmt"].ToString(),
                    cme_g1 = dr["cme_g1"].ToString(),
                    cme_p1 = dr["cme_p1"].ToString(),
                    cme_g2 = dr["cme_g2"].ToString(),
                    cme_p2 = dr["cme_p2"].ToString(),
                    cme_g3 = dr["cme_g3"].ToString(),
                    cme_p3 = dr["cme_p3"].ToString(),
                    cme_g4 = dr["cme_g4"].ToString(),
                    cme_p4 = dr["cme_p4"].ToString(),
                    cme_date = Convert.ToDateTime(dr["cme_date"].ToString()),
                    cme_date_created = Convert.ToDateTime(dr["cme_date_created"].ToString()),
                    cme_status = dr["cme_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.MonthlyEvaluation> GetAllPreMonthlyEvaluation(int appId, int patId)
        {
            List<BusinessEntities.EMR.MonthlyEvaluation> sclist = new List<BusinessEntities.EMR.MonthlyEvaluation>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllPreMonthlyEvaluation(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MonthlyEvaluation
                {
                    cme_Id = Convert.ToInt32(dr["cme_Id"]),
                    cme_appId = Convert.ToInt32(dr["cme_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Monthly Evaluation (Page Load)
        #region  Monthly Evaluation CRUD Operations
        public static bool InsertUpdateMonthlyEvaluation(BusinessEntities.EMR.MonthlyEvaluation data)
        {
            data.cme_checkbox = string.IsNullOrEmpty(data.cme_checkbox) ? string.Empty : data.cme_checkbox;
            data.cme_Imp = string.IsNullOrEmpty(data.cme_Imp) ? string.Empty : data.cme_Imp;
            data.cme_gmsCmt = string.IsNullOrEmpty(data.cme_gmsCmt) ?string.Empty : data.cme_gmsCmt;
            data.cme_fmsCmt = string.IsNullOrEmpty(data.cme_fmsCmt) ? string.Empty : data.cme_fmsCmt;
            data.cme_pmiCmt = string.IsNullOrEmpty(data.cme_pmiCmt) ? string.Empty : data.cme_pmiCmt;
            data.cme_checkbox = string.IsNullOrEmpty(data.cme_checkbox) ? string.Empty : data.cme_checkbox;
            data.cme_wsCmt = string.IsNullOrEmpty(data.cme_wsCmt) ? string.Empty : data.cme_wsCmt;
            data.cme_csCmt = string.IsNullOrEmpty(data.cme_csCmt) ? string.Empty : data.cme_csCmt;
            data.cme_sisCmt = string.IsNullOrEmpty(data.cme_sisCmt) ? string.Empty : data.cme_sisCmt;
            data.cme_bssCmt = string.IsNullOrEmpty(data.cme_bssCmt) ? string.Empty : data.cme_bssCmt;
            data.cme_adlCmt = string.IsNullOrEmpty(data.cme_adlCmt) ? string.Empty : data.cme_adlCmt;
            data.cme_g1 = string.IsNullOrEmpty(data.cme_g1) ? string.Empty : data.cme_g1;
            data.cme_p1 = string.IsNullOrEmpty(data.cme_p1) ? string.Empty : data.cme_p1;
            data.cme_g2 = string.IsNullOrEmpty(data.cme_g2) ? string.Empty : data.cme_g2;
            data.cme_p2 = string.IsNullOrEmpty(data.cme_p2) ? string.Empty : data.cme_p2;
            data.cme_g3 = string.IsNullOrEmpty(data.cme_g3) ? string.Empty : data.cme_g3;
            data.cme_p3 = string.IsNullOrEmpty(data.cme_p3) ? string.Empty : data.cme_p3;
            data.cme_g4 = string.IsNullOrEmpty(data.cme_g4) ? string.Empty : data.cme_g4;
            data.cme_p4 = string.IsNullOrEmpty(data.cme_p4) ? string.Empty : data.cme_p4;
            DateTime? cme_date_ = data.cme_date; // Assuming data.car_d1 is of type DateTime?            
            if (data.cme_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cme_date = cme_date_.HasValue ? cme_date_.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cme_date = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.OccupationalTherapy.InsertUpdateMonthlyEvaluation(data);
        }

        public static int DeleteMonthlyEvaluation(int cme_Id, int cme_madeby)
        {
            return DataAccessLayer.EMR.OccupationalTherapy.DeleteMonthlyEvaluation(cme_Id, cme_madeby);
        }

        #endregion  Monthly Evaluation CRUD Operations

        #region  Initial Therapy Screening (Page Load)
        public static List<BusinessEntities.EMR.InitialTherapyScreening> GetAllInitialTherapyScreening(int? appId, int? cot_Id)
        {
            List<BusinessEntities.EMR.InitialTherapyScreening> sclist = new List<BusinessEntities.EMR.InitialTherapyScreening>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllInitialTherapyScreening(appId, cot_Id);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.InitialTherapyScreening
                {
                    cot_Id = Convert.ToInt32(dr["cot_Id"]),
                    cot_appId = Convert.ToInt32(dr["cot_appId"]),
                    cot_txt_sib = dr["cot_txt_sib"].ToString(),
                    cot_txt_inf = dr["cot_txt_inf"].ToString(),
                    cot_txt1 = dr["cot_txt1"].ToString(),
                    cot_txt2 = dr["cot_txt2"].ToString(),
                    cot_txt3 = dr["cot_txt3"].ToString(),
                    cot_txt4 = dr["cot_txt4"].ToString(),
                    cot_txt5 = dr["cot_txt5"].ToString(),
                    cot_checkbox = dr["cot_checkbox"].ToString(),
                    cot_txt6 = dr["cot_txt6"].ToString(),
                    cot_txt7 = dr["cot_txt7"].ToString(),
                    cot_txt8 = dr["cot_txt8"].ToString(),
                    cot_txt9 = dr["cot_txt9"].ToString(),
                    cot_txt10 = dr["cot_txt10"].ToString(),
                    cot_txt11 = dr["cot_txt11"].ToString(),
                    cot_txt12 = dr["cot_txt12"].ToString(),
                    cot_txt13 = dr["cot_txt13"].ToString(),
                    cot_txt14 = dr["cot_txt14"].ToString(),
                    cot_txt15 = dr["cot_txt15"].ToString(),
                    cot_txt16 = dr["cot_txt16"].ToString(),
                    cot_txt17 = dr["cot_txt17"].ToString(),
                    cot_txt18 = dr["cot_txt18"].ToString(),
                    cot_date = Convert.ToDateTime(dr["cot_date"].ToString()),
                    cot_date_created = Convert.ToDateTime(dr["cot_date_created"].ToString()),
                    cot_status = dr["cot_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.InitialTherapyScreening> GetAllPreInitialTherapyScreening(int appId, int patId)
        {
            List<BusinessEntities.EMR.InitialTherapyScreening> sclist = new List<BusinessEntities.EMR.InitialTherapyScreening>();
            DataTable dt = DataAccessLayer.EMR.OccupationalTherapy.GetAllPreInitialTherapyScreening(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.InitialTherapyScreening
                {
                    cot_Id = Convert.ToInt32(dr["cot_Id"]),
                    cot_appId = Convert.ToInt32(dr["cot_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Initial Therapy Screening (Page Load)
        #region  Initial Therapy Screening CRUD Operations
        public static bool InsertUpdateInitialTherapyScreening(BusinessEntities.EMR.InitialTherapyScreening data)
        {
            data.cot_checkbox = string.IsNullOrEmpty(data.cot_checkbox) ? string.Empty : data.cot_checkbox;
            data.cot_txt_sib = string.IsNullOrEmpty(data.cot_txt_sib) ? string.Empty : data.cot_txt_sib;
            data.cot_txt_inf = string.IsNullOrEmpty(data.cot_txt_inf) ? string.Empty : data.cot_txt_inf;
            data.cot_txt1 = string.IsNullOrEmpty(data.cot_txt1) ? string.Empty : data.cot_txt1;
            data.cot_txt2 = string.IsNullOrEmpty(data.cot_txt2) ? string.Empty : data.cot_txt2;
            data.cot_txt3 = string.IsNullOrEmpty(data.cot_txt3) ? string.Empty : data.cot_txt3;
            data.cot_txt4 = string.IsNullOrEmpty(data.cot_txt4) ? string.Empty : data.cot_txt4;
            data.cot_txt5 = string.IsNullOrEmpty(data.cot_txt5) ? string.Empty : data.cot_txt5;
            data.cot_txt6 = string.IsNullOrEmpty(data.cot_txt6) ? string.Empty : data.cot_txt6;
            data.cot_txt7 = string.IsNullOrEmpty(data.cot_txt7) ? string.Empty : data.cot_txt7;
            data.cot_txt8 = string.IsNullOrEmpty(data.cot_txt8) ? string.Empty : data.cot_txt8;
            data.cot_txt9 = string.IsNullOrEmpty(data.cot_txt9) ? string.Empty : data.cot_txt9;
            data.cot_txt10 = string.IsNullOrEmpty(data.cot_txt10) ? string.Empty : data.cot_txt10;
            data.cot_txt11 = string.IsNullOrEmpty(data.cot_txt11) ? string.Empty : data.cot_txt11;
            data.cot_txt12 = string.IsNullOrEmpty(data.cot_txt12) ? string.Empty : data.cot_txt12;
            data.cot_txt13 = string.IsNullOrEmpty(data.cot_txt13) ? string.Empty : data.cot_txt13;
            data.cot_txt14 = string.IsNullOrEmpty(data.cot_txt14) ? string.Empty : data.cot_txt14;
            data.cot_txt15 = string.IsNullOrEmpty(data.cot_txt15) ? string.Empty : data.cot_txt15;
            data.cot_txt16 = string.IsNullOrEmpty(data.cot_txt16) ? string.Empty : data.cot_txt16;
            data.cot_txt17 = string.IsNullOrEmpty(data.cot_txt17) ? string.Empty : data.cot_txt17;
            data.cot_txt18 = string.IsNullOrEmpty(data.cot_txt18) ? string.Empty : data.cot_txt18;
            DateTime? cot_date_ = data.cot_date; // Assuming data.car_d1 is of type DateTime?            
            if (data.cot_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cot_date = cot_date_.HasValue ? cot_date_.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cot_date = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.OccupationalTherapy.InsertUpdateInitialTherapyScreening(data);
        }

        public static int DeleteInitialTherapyScreening(int cot_Id, int cot_madeby)
        {
            return DataAccessLayer.EMR.OccupationalTherapy.DeleteInitialTherapyScreening(cot_Id, cot_madeby);
        }

        #endregion  Initial Therapy Screening CRUD Operations

    }
}
