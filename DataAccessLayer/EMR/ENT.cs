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
    public class ENT
    {
        #region  Audiology Note (Page Load)
        public static DataTable GetAllAudiologyNote(int? appId, int? audId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AUDIOLOGY_select_all_info");
                if (audId > 0)
                {
                    db.AddInParameter(dbCommand, "audId", DbType.Int32, audId);
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

        public static DataTable GetAllPreAudiologyNote(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AUDIOLOGY_PREVIOUS");
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
        #endregion  Audiology Note (Page Load)

        #region  Audiology Note CRUD Operations
        public static bool InsertUpdateAudiologyNote(BusinessEntities.EMR.AudiologyNote data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AUDIOLOGY_INSERT_UPDATE");
                if (data.audId > 0)
                {
                    db.AddInParameter(dbCommand, "audId", DbType.Int32, data.audId);
                }
                db.AddInParameter(dbCommand, "aud_appId", DbType.Int32, data.aud_appId);
                db.AddInParameter(dbCommand, "aud_clinic", DbType.String, data.aud_clinic);
                db.AddInParameter(dbCommand, "aud_ampli", DbType.String, data.aud_ampli);
                db.AddInParameter(dbCommand, "aud_style", DbType.String, data.aud_style);
                db.AddInParameter(dbCommand, "aud_needs", DbType.String, data.aud_needs);
                db.AddInParameter(dbCommand, "aud_tests", DbType.String, data.aud_tests);
                db.AddInParameter(dbCommand, "aud_results", DbType.String, data.aud_results);
                db.AddInParameter(dbCommand, "aud_manage", DbType.String, data.aud_manage);
                db.AddInParameter(dbCommand, "aud_madeby", DbType.Int32, data.aud_madeby);

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

        public static int DeleteAudiologyNote(int audId, int aud_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AUDIOLOGY_delete");

                db.AddInParameter(dbCommand, "audId", DbType.Int32, audId);
                db.AddInParameter(dbCommand, "aud_madeby", DbType.String, aud_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Audiology Note CRUD Operations
        #region  Vestibular (Page Load)
        public static DataTable GetAllVestibular(int? appId, int? eeId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_EAR_select_all_info");
                if (eeId > 0)
                {
                    db.AddInParameter(dbCommand, "eeId", DbType.Int32, eeId);
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

        public static DataTable GetAllPreVestibular(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_EAR_PREVIOUS");
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
        #endregion  Vestibular (Page Load)

        #region  Vestibular CRUD Operations
        public static bool InsertUpdateVestibular(BusinessEntities.EMR.Vestibular data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_EAR_INSERT_UPDATE");
                if (data.eeId > 0)
                {
                    db.AddInParameter(dbCommand, "eeId", DbType.Int32, data.eeId);
                }
                db.AddInParameter(dbCommand, "ee_appId", DbType.Int32, data.ee_appId);
                db.AddInParameter(dbCommand, "ee_pinr", DbType.String, data.ee_pinr);
                db.AddInParameter(dbCommand, "ee_pinl", DbType.String, data.ee_pinl);
                db.AddInParameter(dbCommand, "ee_pregr", DbType.String, data.ee_pregr);
                db.AddInParameter(dbCommand, "ee_pregl", DbType.String, data.ee_pregl);
                db.AddInParameter(dbCommand, "ee_postr", DbType.String, data.ee_postr);
                db.AddInParameter(dbCommand, "ee_postl", DbType.String, data.ee_postl);
                db.AddInParameter(dbCommand, "ee_eacr", DbType.String, data.ee_eacr);
                db.AddInParameter(dbCommand, "ee_eacl", DbType.String, data.ee_eacl);
                db.AddInParameter(dbCommand, "ee_tympr", DbType.String, data.ee_tympr);
                db.AddInParameter(dbCommand, "ee_tympl", DbType.String, data.ee_tympl);
                db.AddInParameter(dbCommand, "ee_masr", DbType.String, data.ee_masr);
                db.AddInParameter(dbCommand, "ee_masl", DbType.String, data.ee_masl);
                db.AddInParameter(dbCommand, "ee_facr", DbType.String, data.ee_facr);
                db.AddInParameter(dbCommand, "ee_facl", DbType.String, data.ee_facl);
                db.AddInParameter(dbCommand, "ee_nysr", DbType.String, data.ee_nysr);
                db.AddInParameter(dbCommand, "ee_nysl", DbType.String, data.ee_nysl);
                db.AddInParameter(dbCommand, "ee_eustr", DbType.String, data.ee_eustr);
                db.AddInParameter(dbCommand, "ee_eustl", DbType.String, data.ee_eustl);
                db.AddInParameter(dbCommand, "ee_notes", DbType.String, data.ee_notes);
                db.AddInParameter(dbCommand, "ee_madeby", DbType.Int32, data.ee_madeby);

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

        public static int DeleteVestibular(int eeId, int ee_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_EAR_delete");

                db.AddInParameter(dbCommand, "eeId", DbType.Int32, eeId);
                db.AddInParameter(dbCommand, "ee_madeby", DbType.String, ee_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Vestibular CRUD Operations
        #region  Ear Microscopy Report (Page Load)
        public static DataTable GetAllEarMicroscopy(int? appId, int? emrId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EAR_MICROSCOPY_REPORT_select_all_info");
                if (emrId > 0)
                {
                    db.AddInParameter(dbCommand, "emrId", DbType.Int32, emrId);
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

        public static DataTable GetAllPreEarMicroscopy(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EAR_MICROSCOPY_REPORT_PREVIOUS");
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
        #endregion  Ear Microscopy Report (Page Load)

        #region  Ear Microscopy Report CRUD Operations
        public static bool InsertUpdateEarMicroscopy(BusinessEntities.EMR.EarMicroscopy data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EAR_MICROSCOPY_REPORT_INSERT_UPDATE");
                if (data.emrId > 0)
                {
                    db.AddInParameter(dbCommand, "emrId", DbType.Int32, data.emrId);
                }
                db.AddInParameter(dbCommand, "emr_appId", DbType.Int32, data.emr_appId);
                db.AddInParameter(dbCommand, "emr_notes", DbType.String, data.emr_notes);
                db.AddInParameter(dbCommand, "emr_madeby", DbType.Int32, data.emr_madeby);

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

        public static int DeleteEarMicroscopy(int emrId, int emr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EAR_MICROSCOPY_REPORT_delete");

                db.AddInParameter(dbCommand, "emrId", DbType.Int32, emrId);
                db.AddInParameter(dbCommand, "emr_madeby", DbType.String, emr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Ear Microscopy Report CRUD Operations
        #region  Nasal Endoscopy Report (Page Load)
        public static DataTable GetAllNasalEndoscopy(int? appId, int? nerId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NASAL_ENDOSCOPY_REPORT_select_all_info");
                if (nerId > 0)
                {
                    db.AddInParameter(dbCommand, "nerId", DbType.Int32, nerId);
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

        public static DataTable GetAllPreNasalEndoscopy(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NASAL_ENDOSCOPY_REPORT_PREVIOUS");
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
        #endregion  Nasal Endoscopy Report (Page Load)

        #region  Nasal Endoscopy Report CRUD Operations
        public static bool InsertUpdateNasalEndoscopy(BusinessEntities.EMR.NasalEndoscopy data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NASAL_ENDOSCOPY_REPORT_INSERT_UPDATE");
                if (data.nerId > 0)
                {
                    db.AddInParameter(dbCommand, "nerId", DbType.Int32, data.nerId);
                }
                db.AddInParameter(dbCommand, "ner_appId", DbType.Int32, data.ner_appId);
                db.AddInParameter(dbCommand, "ner_notes", DbType.String, data.ner_notes);
                db.AddInParameter(dbCommand, "ner_madeby", DbType.Int32, data.ner_madeby);

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

        public static int DeleteNasalEndoscopy(int nerId, int ner_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NASAL_ENDOSCOPY_REPORT_delete");

                db.AddInParameter(dbCommand, "nerId", DbType.Int32, nerId);
                db.AddInParameter(dbCommand, "ner_madeby", DbType.String, ner_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Nasal Endoscopy Report CRUD Operations
        #region  Fibroptic Laryngoscopy Report (Page Load)
        public static DataTable GetAllFibropticLaryngoscopy(int? appId, int? flrId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIBREOPTIC_LARYNGOSCOPY_REPORT_select_all_info");
                if (flrId > 0)
                {
                    db.AddInParameter(dbCommand, "flrId", DbType.Int32, flrId);
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

        public static DataTable GetAllPreFibropticLaryngoscopy(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIBREOPTIC_LARYNGOSCOPY_REPORT_PREVIOUS");
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
        #endregion  Fibroptic Laryngoscopy Report (Page Load)

        #region  Fibroptic Laryngoscopy Report CRUD Operations
        public static bool InsertUpdateFibropticLaryngoscopy(BusinessEntities.EMR.FibropticLaryngoscopy data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIBREOPTIC_LARYNGOSCOPY_REPORT_INSERT_UPDATE");
                if (data.flrId > 0)
                {
                    db.AddInParameter(dbCommand, "flrId", DbType.Int32, data.flrId);
                }
                db.AddInParameter(dbCommand, "flr_appId", DbType.Int32, data.flr_appId);
                db.AddInParameter(dbCommand, "flr_notes", DbType.String, data.flr_notes);
                db.AddInParameter(dbCommand, "flr_madeby", DbType.Int32, data.flr_madeby);

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

        public static int DeleteFibropticLaryngoscopy(int flrId, int flr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FIBREOPTIC_LARYNGOSCOPY_REPORT_delete");

                db.AddInParameter(dbCommand, "flrId", DbType.Int32, flrId);
                db.AddInParameter(dbCommand, "flr_madeby", DbType.String, flr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Fibroptic Laryngoscopy Report CRUD Operations

        #region  ENT Examination Throat (Page Load)
        public static DataTable GetAllENTExamThroat(int? appId, int? etId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_THROAT_select_all_info");
                if (etId > 0)
                {
                    db.AddInParameter(dbCommand, "etId", DbType.Int32, etId);
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

        public static DataTable GetAllPreENTExamThroat(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_THROAT_PREVIOUS");
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
        #endregion  ENT Examination Throat (Page Load)

        #region  ENT Examination Throat CRUD Operations
        public static bool InsertUpdateENTExamThroat(BusinessEntities.EMR.ENTExamThroat data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_THROAT_INSERT_UPDATE");
                if (data.etId > 0)
                {
                    db.AddInParameter(dbCommand, "etId", DbType.Int32, data.etId);
                }
                db.AddInParameter(dbCommand, "et_appId", DbType.Int32, data.et_appId);
                db.AddInParameter(dbCommand, "et_lip", DbType.String, data.et_lip);
                db.AddInParameter(dbCommand, "et_base", DbType.String, data.et_base);
                db.AddInParameter(dbCommand, "et_vest", DbType.String, data.et_vest);
                db.AddInParameter(dbCommand, "et_valle", DbType.String, data.et_valle);
                db.AddInParameter(dbCommand, "et_teeth", DbType.String, data.et_teeth);
                db.AddInParameter(dbCommand, "et_epig", DbType.String, data.et_epig);
                db.AddInParameter(dbCommand, "et_oral", DbType.String, data.et_oral);
                db.AddInParameter(dbCommand, "et_false", DbType.String, data.et_false);
                db.AddInParameter(dbCommand, "et_hard", DbType.String, data.et_hard);
                db.AddInParameter(dbCommand, "et_vent", DbType.String, data.et_vent);
                db.AddInParameter(dbCommand, "et_tong", DbType.String, data.et_tong);
                db.AddInParameter(dbCommand, "et_aryt", DbType.String, data.et_aryt);
                db.AddInParameter(dbCommand, "et_retro", DbType.String, data.et_retro);
                db.AddInParameter(dbCommand, "et_arye", DbType.String, data.et_arye);
                db.AddInParameter(dbCommand, "et_tons", DbType.String, data.et_tons);
                db.AddInParameter(dbCommand, "et_vocal", DbType.String, data.et_vocal);
                db.AddInParameter(dbCommand, "et_apill", DbType.String, data.et_apill);
                db.AddInParameter(dbCommand, "et_acomm", DbType.String, data.et_acomm);
                db.AddInParameter(dbCommand, "et_ppill", DbType.String, data.et_ppill);
                db.AddInParameter(dbCommand, "et_pcomm", DbType.String, data.et_pcomm);
                db.AddInParameter(dbCommand, "et_orop", DbType.String, data.et_orop);
                db.AddInParameter(dbCommand, "et_subg", DbType.String, data.et_subg);
                db.AddInParameter(dbCommand, "et_pyrif", DbType.String, data.et_pyrif);
                db.AddInParameter(dbCommand, "et_paro", DbType.String, data.et_paro);
                db.AddInParameter(dbCommand, "et_postc", DbType.String, data.et_postc);
                db.AddInParameter(dbCommand, "et_postp", DbType.String, data.et_postp);
                db.AddInParameter(dbCommand, "et_thy", DbType.String, data.et_thy);
                db.AddInParameter(dbCommand, "et_trac", DbType.String, data.et_trac);
                db.AddInParameter(dbCommand, "et_lary", DbType.String, data.et_lary);
                db.AddInParameter(dbCommand, "et_lymp", DbType.String, data.et_lymp);
                db.AddInParameter(dbCommand, "et_others", DbType.String, data.et_others);
                db.AddInParameter(dbCommand, "et_notes", DbType.String, data.et_notes);
                db.AddInParameter(dbCommand, "et_madeby", DbType.Int32, data.et_madeby);

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

        public static int DeleteENTExamThroat(int etId, int et_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_THROAT_delete");

                db.AddInParameter(dbCommand, "etId", DbType.Int32, etId);
                db.AddInParameter(dbCommand, "et_madeby", DbType.String, et_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  ENT Examination Throat CRUD Operations

        #region  ENT Examination Nose (Page Load)
        public static DataTable GetAllENTExamNose(int? appId, int? enId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_Nose_select_all_info");
                if (enId > 0)
                {
                    db.AddInParameter(dbCommand, "enId", DbType.Int32, enId);
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

        public static DataTable GetAllPreENTExamNose(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_Nose_PREVIOUS");
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
        #endregion  ENT Examination Nose (Page Load)

        #region  ENT Examination Nose CRUD Operations
        public static bool InsertUpdateENTExamNose(BusinessEntities.EMR.ENTExamNose data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_Nose_INSERT_UPDATE");
                if (data.enId > 0)
                {
                    db.AddInParameter(dbCommand, "enId", DbType.Int32, data.enId);
                }
                db.AddInParameter(dbCommand, "en_appId", DbType.Int32, data.en_appId);
                db.AddInParameter(dbCommand, "en_ext", DbType.String, data.en_ext);
                db.AddInParameter(dbCommand, "en_vest", DbType.String, data.en_vest);
                db.AddInParameter(dbCommand, "en_floor", DbType.String, data.en_floor);
                db.AddInParameter(dbCommand, "en_sept", DbType.String, data.en_sept);
                db.AddInParameter(dbCommand, "en_nasal", DbType.String, data.en_nasal);
                db.AddInParameter(dbCommand, "en_imear", DbType.String, data.en_imear);
                db.AddInParameter(dbCommand, "en_imeal", DbType.String, data.en_imeal);
                db.AddInParameter(dbCommand, "en_iturbr", DbType.String, data.en_iturbr);
                db.AddInParameter(dbCommand, "en_iturbl", DbType.String, data.en_iturbl);
                db.AddInParameter(dbCommand, "en_mmear", DbType.String, data.en_mmear);
                db.AddInParameter(dbCommand, "en_mmeal", DbType.String, data.en_mmeal);
                db.AddInParameter(dbCommand, "en_mturbr", DbType.String, data.en_mturbr);
                db.AddInParameter(dbCommand, "en_mturbl", DbType.String, data.en_mturbl);
                db.AddInParameter(dbCommand, "en_smear", DbType.String, data.en_smear);
                db.AddInParameter(dbCommand, "en_smeal", DbType.String, data.en_smeal);
                db.AddInParameter(dbCommand, "en_sturbr", DbType.String, data.en_sturbr);
                db.AddInParameter(dbCommand, "en_sturbl", DbType.String, data.en_sturbl);
                db.AddInParameter(dbCommand, "en_choane", DbType.String, data.en_choane);
                db.AddInParameter(dbCommand, "en_nasop", DbType.String, data.en_nasop);
                db.AddInParameter(dbCommand, "en_eust", DbType.String, data.en_eust);
                db.AddInParameter(dbCommand, "en_rose", DbType.String, data.en_rose);
                db.AddInParameter(dbCommand, "en_lymp", DbType.String, data.en_lymp);
                db.AddInParameter(dbCommand, "en_other", DbType.String, data.en_other);
                db.AddInParameter(dbCommand, "en_frontr", DbType.String, data.en_frontr);
                db.AddInParameter(dbCommand, "en_frontl", DbType.String, data.en_frontl);
                db.AddInParameter(dbCommand, "en_maxilr", DbType.String, data.en_maxilr);
                db.AddInParameter(dbCommand, "en_maxill", DbType.String, data.en_maxill);
                db.AddInParameter(dbCommand, "en_ethmr", DbType.String, data.en_ethmr);
                db.AddInParameter(dbCommand, "en_ethml", DbType.String, data.en_ethml);
                db.AddInParameter(dbCommand, "en_notes", DbType.String, data.en_notes);
                db.AddInParameter(dbCommand, "en_madeby", DbType.Int32, data.en_madeby);

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

        public static int DeleteENTExamNose(int enId, int en_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ENT_Nose_delete");

                db.AddInParameter(dbCommand, "enId", DbType.Int32, enId);
                db.AddInParameter(dbCommand, "en_madeby", DbType.String, en_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  ENT Examination Nose CRUD Operations
    }
}
