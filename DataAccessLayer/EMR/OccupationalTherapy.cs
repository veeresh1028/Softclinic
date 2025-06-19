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
    public class OccupationalTherapy
    {
        #region  Approval Revision Request (Page Load)
        public static DataTable GetAllApprovalRevisionRequest(int? appId, int? carr_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARR_FORM_select_all_info");
                if (carr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "carr_Id", DbType.Int32, carr_Id);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreApprovalRevisionRequest(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARR_FORM_PREVIOUS");
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
        #endregion  Approval Revision Request (Page Load)

        #region  Approval Revision Request CRUD Operations
        public static bool InsertUpdateApprovalRevisionRequest(BusinessEntities.EMR.RevisionRequest data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARR_FORM_INSERT_UPDATE");
                if (data.carr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "carr_Id", DbType.Int32, data.carr_Id);
                }
                db.AddInParameter(dbCommand, "carr_appId", DbType.Int32, data.carr_appId);
                db.AddInParameter(dbCommand, "carr_e1", DbType.String, data.carr_e1);
                db.AddInParameter(dbCommand, "carr_e2", DbType.String, data.carr_e2);
                db.AddInParameter(dbCommand, "carr_e3", DbType.String, data.carr_e3);
                db.AddInParameter(dbCommand, "carr_e4", DbType.String, data.carr_e4);
                db.AddInParameter(dbCommand, "carr_e5", DbType.String, data.carr_e5);
                db.AddInParameter(dbCommand, "carr_e6", DbType.String, data.carr_e6);
                db.AddInParameter(dbCommand, "carr_e7", DbType.String, data.carr_e7);
                db.AddInParameter(dbCommand, "carr_checkbox", DbType.String, data.carr_checkbox);
                db.AddInParameter(dbCommand, "carr_other", DbType.String, data.carr_other);
                db.AddInParameter(dbCommand, "carr_date", DbType.DateTime, data.carr_date);
                db.AddInParameter(dbCommand, "carr_madeby", DbType.Int32, data.carr_madeby);

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

        public static int DeleteApprovalRevisionRequest(int carr_Id, int carr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARR_FORM_delete");

                db.AddInParameter(dbCommand, "carr_Id", DbType.Int32, carr_Id);
                db.AddInParameter(dbCommand, "carr_madeby", DbType.String, carr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Approval Revision Request CRUD Operations

        #region  FIM Instrument (Page Load)
        public static DataTable GetAllFIMInstrument(int? appId, int? cfim_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIM_FORM_select_all_info");
                if (cfim_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cfim_Id", DbType.Int32, cfim_Id);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreFIMInstrument(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIM_FORM_PREVIOUS");
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
        #endregion  FIM Instrument (Page Load)

        #region  FIM Instrument CRUD Operations
        public static bool InsertUpdateFIMInstrument(BusinessEntities.EMR.FIMInstrument data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIM_FORM_INSERT_UPDATE");
                if (data.cfim_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cfim_Id", DbType.Int32, data.cfim_Id);
                }
                db.AddInParameter(dbCommand, "cfim_appId", DbType.Int32, data.cfim_appId);
                db.AddInParameter(dbCommand, "cfim_a1", DbType.String, data.cfim_a1);
                db.AddInParameter(dbCommand, "cfim_a2", DbType.String, data.cfim_a2);
                db.AddInParameter(dbCommand, "cfim_a3", DbType.String, data.cfim_a3);
                db.AddInParameter(dbCommand, "cfim_b1", DbType.String, data.cfim_b1);
                db.AddInParameter(dbCommand, "cfim_b2", DbType.String, data.cfim_b2);
                db.AddInParameter(dbCommand, "cfim_b3", DbType.String, data.cfim_b3);
                db.AddInParameter(dbCommand, "cfim_c1", DbType.String, data.cfim_c1);
                db.AddInParameter(dbCommand, "cfim_c2", DbType.String, data.cfim_c2);
                db.AddInParameter(dbCommand, "cfim_c3", DbType.String, data.cfim_c3);
                db.AddInParameter(dbCommand, "cfim_d1", DbType.String, data.cfim_d1);
                db.AddInParameter(dbCommand, "cfim_d2", DbType.String, data.cfim_d2);
                db.AddInParameter(dbCommand, "cfim_d3", DbType.String, data.cfim_d3);
                db.AddInParameter(dbCommand, "cfim_e1", DbType.String, data.cfim_e1);
                db.AddInParameter(dbCommand, "cfim_e2", DbType.String, data.cfim_e2);
                db.AddInParameter(dbCommand, "cfim_e3", DbType.String, data.cfim_e3);
                db.AddInParameter(dbCommand, "cfim_f1", DbType.String, data.cfim_f1);
                db.AddInParameter(dbCommand, "cfim_f2", DbType.String, data.cfim_f2);
                db.AddInParameter(dbCommand, "cfim_f3", DbType.String, data.cfim_f3);
                db.AddInParameter(dbCommand, "cfim_g1", DbType.String, data.cfim_g1);
                db.AddInParameter(dbCommand, "cfim_g2", DbType.String, data.cfim_g2);
                db.AddInParameter(dbCommand, "cfim_g3", DbType.String, data.cfim_g3);
                db.AddInParameter(dbCommand, "cfim_h1", DbType.String, data.cfim_h1);
                db.AddInParameter(dbCommand, "cfim_h2", DbType.String, data.cfim_h2);
                db.AddInParameter(dbCommand, "cfim_h3", DbType.String, data.cfim_h3);
                db.AddInParameter(dbCommand, "cfim_i1", DbType.String, data.cfim_i1);
                db.AddInParameter(dbCommand, "cfim_i2", DbType.String, data.cfim_i2);
                db.AddInParameter(dbCommand, "cfim_i3", DbType.String, data.cfim_i3);
                db.AddInParameter(dbCommand, "cfim_j1", DbType.String, data.cfim_j1);
                db.AddInParameter(dbCommand, "cfim_j2", DbType.String, data.cfim_j2);
                db.AddInParameter(dbCommand, "cfim_j3", DbType.String, data.cfim_j3);
                db.AddInParameter(dbCommand, "cfim_k1", DbType.String, data.cfim_k1);
                db.AddInParameter(dbCommand, "cfim_k2", DbType.String, data.cfim_k2);
                db.AddInParameter(dbCommand, "cfim_k3", DbType.String, data.cfim_k3);
                db.AddInParameter(dbCommand, "cfim_l1", DbType.String, data.cfim_l1);
                db.AddInParameter(dbCommand, "cfim_l2", DbType.String, data.cfim_l2);
                db.AddInParameter(dbCommand, "cfim_l3", DbType.String, data.cfim_l3);
                db.AddInParameter(dbCommand, "cfim_m1", DbType.String, data.cfim_m1);
                db.AddInParameter(dbCommand, "cfim_m2", DbType.String, data.cfim_m2);
                db.AddInParameter(dbCommand, "cfim_m3", DbType.String, data.cfim_m3);
                db.AddInParameter(dbCommand, "cfim_n1", DbType.String, data.cfim_n1);
                db.AddInParameter(dbCommand, "cfim_n2", DbType.String, data.cfim_n2);
                db.AddInParameter(dbCommand, "cfim_n3", DbType.String, data.cfim_n3);
                db.AddInParameter(dbCommand, "cfim_o1", DbType.String, data.cfim_o1);
                db.AddInParameter(dbCommand, "cfim_o2", DbType.String, data.cfim_o2);
                db.AddInParameter(dbCommand, "cfim_o3", DbType.String, data.cfim_o3);
                db.AddInParameter(dbCommand, "cfim_p1", DbType.String, data.cfim_p1);
                db.AddInParameter(dbCommand, "cfim_p2", DbType.String, data.cfim_p2);
                db.AddInParameter(dbCommand, "cfim_p3", DbType.String, data.cfim_p3);
                db.AddInParameter(dbCommand, "cfim_q1", DbType.String, data.cfim_q1);
                db.AddInParameter(dbCommand, "cfim_q2", DbType.String, data.cfim_q2);
                db.AddInParameter(dbCommand, "cfim_q3", DbType.String, data.cfim_q3);
                db.AddInParameter(dbCommand, "cfim_r1", DbType.String, data.cfim_r1);
                db.AddInParameter(dbCommand, "cfim_r2", DbType.String, data.cfim_r2);
                db.AddInParameter(dbCommand, "cfim_r3", DbType.String, data.cfim_r3);
                db.AddInParameter(dbCommand, "cfim_mss1", DbType.String, data.cfim_mss1);
                db.AddInParameter(dbCommand, "cfim_mss2", DbType.String, data.cfim_mss2);
                db.AddInParameter(dbCommand, "cfim_mss3", DbType.String, data.cfim_mss3);
                db.AddInParameter(dbCommand, "cfim_css1", DbType.String, data.cfim_css1);
                db.AddInParameter(dbCommand, "cfim_css2", DbType.String, data.cfim_css2);
                db.AddInParameter(dbCommand, "cfim_css3", DbType.String, data.cfim_css3);
                db.AddInParameter(dbCommand, "cfim_tfs1", DbType.String, data.cfim_tfs1);
                db.AddInParameter(dbCommand, "cfim_tfs2", DbType.String, data.cfim_tfs2);
                db.AddInParameter(dbCommand, "cfim_tfs3", DbType.String, data.cfim_tfs3);
                db.AddInParameter(dbCommand, "cfim_comments", DbType.String, data.cfim_comments);
                db.AddInParameter(dbCommand, "cfim_witness", DbType.String, data.cfim_witness);
                db.AddInParameter(dbCommand, "cfim_date", DbType.DateTime, data.cfim_date);
                db.AddInParameter(dbCommand, "cfim_madeby", DbType.Int32, data.cfim_madeby);

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

        public static int DeleteFIMInstrument(int cfim_Id, int cfim_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIM_FORM_delete");

                db.AddInParameter(dbCommand, "cfim_Id", DbType.Int32, cfim_Id);
                db.AddInParameter(dbCommand, "cfim_madeby", DbType.String, cfim_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  FIM Instrument CRUD Operations

        #region  Monthly Evaluation (Page Load)
        public static DataTable GetAllMonthlyEvaluation(int? appId, int? cme_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ME_FORM_select_all_info");
                if (cme_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cme_Id", DbType.Int32, cme_Id);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreMonthlyEvaluation(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ME_FORM_PREVIOUS");
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
        #endregion  Monthly Evaluation (Page Load)

        #region  Monthly Evaluation CRUD Operations
        public static bool InsertUpdateMonthlyEvaluation(BusinessEntities.EMR.MonthlyEvaluation data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ME_FORM_INSERT_UPDATE");
                if (data.cme_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cme_Id", DbType.Int32, data.cme_Id);
                }
                db.AddInParameter(dbCommand, "cme_appId", DbType.Int32, data.cme_appId);
                db.AddInParameter(dbCommand, "cme_Imp", DbType.String, data.cme_Imp);
                db.AddInParameter(dbCommand, "cme_gmsCmt", DbType.String, data.cme_gmsCmt);
                db.AddInParameter(dbCommand, "cme_fmsCmt", DbType.String, data.cme_fmsCmt);
                db.AddInParameter(dbCommand, "cme_pmiCmt", DbType.String, data.cme_pmiCmt);
                db.AddInParameter(dbCommand, "cme_wsCmt", DbType.String, data.cme_wsCmt);
                db.AddInParameter(dbCommand, "cme_csCmt", DbType.String, data.cme_csCmt);
                db.AddInParameter(dbCommand, "cme_sisCmt", DbType.String, data.cme_sisCmt);
                db.AddInParameter(dbCommand, "cme_checkbox", DbType.String, data.cme_checkbox);
                db.AddInParameter(dbCommand, "cme_bssCmt", DbType.String, data.cme_bssCmt);
                db.AddInParameter(dbCommand, "cme_adlCmt", DbType.String, data.cme_adlCmt);
                db.AddInParameter(dbCommand, "cme_p1", DbType.String, data.cme_p1);
                db.AddInParameter(dbCommand, "cme_g1", DbType.String, data.cme_g1);
                db.AddInParameter(dbCommand, "cme_g2", DbType.String, data.cme_g2);
                db.AddInParameter(dbCommand, "cme_p2", DbType.String, data.cme_p2);
                db.AddInParameter(dbCommand, "cme_g3", DbType.String, data.cme_g3);
                db.AddInParameter(dbCommand, "cme_p3", DbType.String, data.cme_p3);
                db.AddInParameter(dbCommand, "cme_g4", DbType.String, data.cme_g4);
                db.AddInParameter(dbCommand, "cme_p4", DbType.String, data.cme_p4);
                db.AddInParameter(dbCommand, "cme_date", DbType.DateTime, data.cme_date);
                db.AddInParameter(dbCommand, "cme_madeby", DbType.Int32, data.cme_madeby);

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

        public static int DeleteMonthlyEvaluation(int cme_Id, int cme_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ME_FORM_delete");

                db.AddInParameter(dbCommand, "cme_Id", DbType.Int32, cme_Id);
                db.AddInParameter(dbCommand, "cme_madeby", DbType.String, cme_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Monthly Evaluation CRUD Operations

        #region  Initial Therapy Screening (Page Load)
        public static DataTable GetAllInitialTherapyScreening(int? appId, int? cot_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OT_FORM_select_all_info");
                if (cot_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cot_Id", DbType.Int32, cot_Id);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreInitialTherapyScreening(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OT_FORM_PREVIOUS");
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
        #endregion  Initial Therapy Screening (Page Load)

        #region  Initial Therapy Screening CRUD Operations
        public static bool InsertUpdateInitialTherapyScreening(BusinessEntities.EMR.InitialTherapyScreening data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OT_FORM_INSERT_UPDATE");
                if (data.cot_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cot_Id", DbType.Int32, data.cot_Id);
                }
                db.AddInParameter(dbCommand, "cot_appId", DbType.Int32, data.cot_appId);
                db.AddInParameter(dbCommand, "cot_txt_inf", DbType.String, data.cot_txt_inf);
                db.AddInParameter(dbCommand, "cot_txt_sib", DbType.String, data.cot_txt_sib);
                db.AddInParameter(dbCommand, "cot_txt1", DbType.String, data.cot_txt1);
                db.AddInParameter(dbCommand, "cot_txt2", DbType.String, data.cot_txt2);
                db.AddInParameter(dbCommand, "cot_checkbox", DbType.String, data.cot_checkbox);
                db.AddInParameter(dbCommand, "cot_txt3", DbType.String, data.cot_txt3);
                db.AddInParameter(dbCommand, "cot_txt4", DbType.String, data.cot_txt4);
                db.AddInParameter(dbCommand, "cot_txt5", DbType.String, data.cot_txt5);
                db.AddInParameter(dbCommand, "cot_txt6", DbType.String, data.cot_txt6);
                db.AddInParameter(dbCommand, "cot_txt7", DbType.String, data.cot_txt7);
                db.AddInParameter(dbCommand, "cot_txt8", DbType.String, data.cot_txt8);
                db.AddInParameter(dbCommand, "cot_txt9", DbType.String, data.cot_txt9);
                db.AddInParameter(dbCommand, "cot_txt10", DbType.String, data.cot_txt10);
                db.AddInParameter(dbCommand, "cot_txt11", DbType.String, data.cot_txt11);
                db.AddInParameter(dbCommand, "cot_txt12", DbType.String, data.cot_txt12);
                db.AddInParameter(dbCommand, "cot_txt13", DbType.String, data.cot_txt13);
                db.AddInParameter(dbCommand, "cot_txt14", DbType.String, data.cot_txt14);
                db.AddInParameter(dbCommand, "cot_txt15", DbType.String, data.cot_txt15);
                db.AddInParameter(dbCommand, "cot_txt16", DbType.String, data.cot_txt16);
                db.AddInParameter(dbCommand, "cot_txt17", DbType.String, data.cot_txt17);
                db.AddInParameter(dbCommand, "cot_txt18", DbType.String, data.cot_txt18);
                db.AddInParameter(dbCommand, "cot_date", DbType.DateTime, data.cot_date);
                db.AddInParameter(dbCommand, "cot_madeby", DbType.Int32, data.cot_madeby);

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

        public static int DeleteInitialTherapyScreening(int cot_Id, int cot_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OT_FORM_delete");

                db.AddInParameter(dbCommand, "cot_Id", DbType.Int32, cot_Id);
                db.AddInParameter(dbCommand, "cot_madeby", DbType.String, cot_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Initial Therapy Screening CRUD Operations

    }
}
