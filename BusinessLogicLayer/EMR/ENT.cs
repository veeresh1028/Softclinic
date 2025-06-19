using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class ENT
    {
        #region  Audiology Note (Page Load)
        public static List<BusinessEntities.EMR.AudiologyNote> GetAllAudiologyNote(int? appId, int? audId)
        {
            List<BusinessEntities.EMR.AudiologyNote> sclist = new List<BusinessEntities.EMR.AudiologyNote>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllAudiologyNote(appId, audId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.AudiologyNote
                {
                    audId = Convert.ToInt32(dr["audId"]),
                    aud_appId = Convert.ToInt32(dr["aud_appId"]),
                    aud_clinic = dr["aud_clinic"].ToString(),
                    aud_ampli = dr["aud_ampli"].ToString(),
                    aud_style = dr["aud_style"].ToString(),
                    aud_needs = dr["aud_needs"].ToString(),
                    aud_tests = dr["aud_tests"].ToString(),
                    aud_results = dr["aud_results"].ToString(),
                    aud_manage = dr["aud_manage"].ToString(),
                    aud_status = dr["aud_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.AudiologyNote> GetAllPreAudiologyNote(int appId, int patId)
        {
            List<BusinessEntities.EMR.AudiologyNote> sclist = new List<BusinessEntities.EMR.AudiologyNote>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllPreAudiologyNote(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.AudiologyNote
                {
                    audId = Convert.ToInt32(dr["audId"]),
                    aud_appId = Convert.ToInt32(dr["aud_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Audiology Note (Page Load)
        #region  Audiology Note CRUD Operations
        public static bool InsertUpdateAudiologyNote(BusinessEntities.EMR.AudiologyNote data)
        {
            data.aud_clinic = string.IsNullOrEmpty(data.aud_clinic) ? string.Empty : data.aud_clinic;
            data.aud_ampli = string.IsNullOrEmpty(data.aud_ampli) ? string.Empty : data.aud_ampli;
            data.aud_style = string.IsNullOrEmpty(data.aud_ampli) ? string.Empty : data.aud_style;
            data.aud_needs = string.IsNullOrEmpty(data.aud_ampli) ? string.Empty : data.aud_needs;
            data.aud_tests = string.IsNullOrEmpty(data.aud_tests) ? string.Empty : data.aud_tests;
            data.aud_results = string.IsNullOrEmpty(data.aud_results) ? string.Empty : data.aud_results;
            data.aud_manage = string.IsNullOrEmpty(data.aud_manage) ? string.Empty : data.aud_manage;
            
            return DataAccessLayer.EMR.ENT.InsertUpdateAudiologyNote(data);
        }

        public static int DeleteAudiologyNote(int audId, int aud_madeby)
        {
            return DataAccessLayer.EMR.ENT.DeleteAudiologyNote(audId, aud_madeby);
        }
        #endregion  Audiology Note CRUD Operations

        #region  Vestibular (Page Load)
        public static List<BusinessEntities.EMR.Vestibular> GetAllVestibular(int? appId, int? eeId)
        {
            List<BusinessEntities.EMR.Vestibular> sclist = new List<BusinessEntities.EMR.Vestibular>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllVestibular(appId, eeId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Vestibular
                {
                    eeId = Convert.ToInt32(dr["eeId"]),
                    ee_appId = Convert.ToInt32(dr["ee_appId"]),
                    ee_pinr = dr["ee_pinr"].ToString(),
                    ee_pinl = dr["ee_pinl"].ToString(),
                    ee_pregr = dr["ee_pregr"].ToString(),
                    ee_pregl = dr["ee_pregl"].ToString(),
                    ee_postr = dr["ee_postr"].ToString(),
                    ee_postl = dr["ee_postl"].ToString(),
                    ee_eacr = dr["ee_eacr"].ToString(),
                    ee_eacl = dr["ee_eacl"].ToString(),
                    ee_tympr = dr["ee_tympr"].ToString(),
                    ee_tympl = dr["ee_tympl"].ToString(),
                    ee_masr = dr["ee_masr"].ToString(),
                    ee_masl = dr["ee_masl"].ToString(),
                    ee_facr = dr["ee_facr"].ToString(),
                    ee_facl = dr["ee_facl"].ToString(),
                    ee_nysr = dr["ee_nysr"].ToString(),
                    ee_nysl = dr["ee_nysl"].ToString(),
                    ee_eustr = dr["ee_eustr"].ToString(),
                    ee_eustl = dr["ee_eustl"].ToString(),
                    ee_notes = dr["ee_notes"].ToString(),
                    ee_status = dr["ee_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.Vestibular> GetAllPreVestibular(int appId, int patId)
        {
            List<BusinessEntities.EMR.Vestibular> sclist = new List<BusinessEntities.EMR.Vestibular>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllPreVestibular(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Vestibular
                {
                    eeId = Convert.ToInt32(dr["eeId"]),
                    ee_appId = Convert.ToInt32(dr["ee_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Vestibular (Page Load)
        #region  Vestibular CRUD Operations
        public static bool InsertUpdateVestibular(BusinessEntities.EMR.Vestibular data)
        {
            data.ee_pinr = string.IsNullOrEmpty(data.ee_pinr) ? string.Empty : data.ee_pinr;
            data.ee_pinl = string.IsNullOrEmpty(data.ee_pinl) ? string.Empty : data.ee_pinl;
            data.ee_pregr = string.IsNullOrEmpty(data.ee_pinl) ? string.Empty : data.ee_pregr;
            data.ee_pregl = string.IsNullOrEmpty(data.ee_pinl) ? string.Empty : data.ee_pregl;
            data.ee_postr = string.IsNullOrEmpty(data.ee_postr) ? string.Empty : data.ee_postr;
            data.ee_postl = string.IsNullOrEmpty(data.ee_postl) ? string.Empty : data.ee_postl;
            data.ee_eacr = string.IsNullOrEmpty(data.ee_eacr) ? string.Empty : data.ee_eacr;
            data.ee_eacl = string.IsNullOrEmpty(data.ee_eacl) ? string.Empty : data.ee_eacl;
            data.ee_tympr = string.IsNullOrEmpty(data.ee_tympr) ? string.Empty : data.ee_tympr;
            data.ee_tympl = string.IsNullOrEmpty(data.ee_tympl) ? string.Empty : data.ee_tympl;
            data.ee_masr = string.IsNullOrEmpty(data.ee_masr) ? string.Empty : data.ee_masr;
            data.ee_masl = string.IsNullOrEmpty(data.ee_masl) ? string.Empty : data.ee_masl;
            data.ee_facr = string.IsNullOrEmpty(data.ee_facr) ? string.Empty : data.ee_facr;
            data.ee_facl = string.IsNullOrEmpty(data.ee_facl) ? string.Empty : data.ee_facl;
            data.ee_nysr = string.IsNullOrEmpty(data.ee_nysr) ? string.Empty : data.ee_nysr;
            data.ee_nysl = string.IsNullOrEmpty(data.ee_nysl) ? string.Empty : data.ee_nysl;
            data.ee_eustr = string.IsNullOrEmpty(data.ee_eustr) ? string.Empty : data.ee_eustr;
            data.ee_eustl = string.IsNullOrEmpty(data.ee_eustl) ? string.Empty : data.ee_eustl;
            data.ee_notes = string.IsNullOrEmpty(data.ee_notes) ? string.Empty : data.ee_notes;

            return DataAccessLayer.EMR.ENT.InsertUpdateVestibular(data);
        }

        public static int DeleteVestibular(int eeId, int ee_madeby)
        {
            return DataAccessLayer.EMR.ENT.DeleteVestibular(eeId, ee_madeby);
        }
        #endregion  Vestibular CRUD Operations
        #region  Ear Microscopy Report (Page Load)
        public static List<BusinessEntities.EMR.EarMicroscopy> GetAllEarMicroscopy(int? appId, int? emrId)
        {
            List<BusinessEntities.EMR.EarMicroscopy> sclist = new List<BusinessEntities.EMR.EarMicroscopy>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllEarMicroscopy(appId, emrId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.EarMicroscopy
                {
                    emrId = Convert.ToInt32(dr["emrId"]),
                    emr_appId = Convert.ToInt32(dr["emr_appId"]),
                    emr_notes = dr["emr_notes"].ToString(),
                    emr_status = dr["emr_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.EarMicroscopy> GetAllPreEarMicroscopy(int appId, int patId)
        {
            List<BusinessEntities.EMR.EarMicroscopy> sclist = new List<BusinessEntities.EMR.EarMicroscopy>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllPreEarMicroscopy(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.EarMicroscopy
                {
                    emrId = Convert.ToInt32(dr["emrId"]),
                    emr_appId = Convert.ToInt32(dr["emr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Ear Microscopy Report (Page Load)
        #region  Ear Microscopy Report CRUD Operations
        public static bool InsertUpdateEarMicroscopy(BusinessEntities.EMR.EarMicroscopy data)
        {
            data.emr_notes = string.IsNullOrEmpty(data.emr_notes) ? string.Empty : data.emr_notes;
            return DataAccessLayer.EMR.ENT.InsertUpdateEarMicroscopy(data);
        }

        public static int DeleteEarMicroscopy(int emrId, int emr_madeby)
        {
            return DataAccessLayer.EMR.ENT.DeleteEarMicroscopy(emrId, emr_madeby);
        }
        #endregion  Ear Microscopy Report CRUD Operations
        #region  Nasal Endoscopy Report (Page Load)
        public static List<BusinessEntities.EMR.NasalEndoscopy> GetAllNasalEndoscopy(int? appId, int? nerId)
        {
            List<BusinessEntities.EMR.NasalEndoscopy> sclist = new List<BusinessEntities.EMR.NasalEndoscopy>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllNasalEndoscopy(appId, nerId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.NasalEndoscopy
                {
                    nerId = Convert.ToInt32(dr["nerId"]),
                    ner_appId = Convert.ToInt32(dr["ner_appId"]),
                    ner_notes = dr["ner_notes"].ToString(),
                    ner_status = dr["ner_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.NasalEndoscopy> GetAllPreNasalEndoscopy(int appId, int patId)
        {
            List<BusinessEntities.EMR.NasalEndoscopy> sclist = new List<BusinessEntities.EMR.NasalEndoscopy>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllPreNasalEndoscopy(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.NasalEndoscopy
                {
                    nerId = Convert.ToInt32(dr["nerId"]),
                    ner_appId = Convert.ToInt32(dr["ner_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Nasal Endoscopy Report (Page Load)
        #region  Nasal Endoscopy Report CRUD Operations
        public static bool InsertUpdateNasalEndoscopy(BusinessEntities.EMR.NasalEndoscopy data)
        {
            data.ner_notes = string.IsNullOrEmpty(data.ner_notes) ? string.Empty : data.ner_notes;
            return DataAccessLayer.EMR.ENT.InsertUpdateNasalEndoscopy(data);
        }

        public static int DeleteNasalEndoscopy(int nerId, int ner_madeby)
        {
            return DataAccessLayer.EMR.ENT.DeleteNasalEndoscopy(nerId, ner_madeby);
        }
        #endregion  Nasal Endoscopy Report CRUD Operations
        #region  Fibroptic Laryngoscopy Report (Page Load)
        public static List<BusinessEntities.EMR.FibropticLaryngoscopy> GetAllFibropticLaryngoscopy(int? appId, int? flrId)
        {
            List<BusinessEntities.EMR.FibropticLaryngoscopy> sclist = new List<BusinessEntities.EMR.FibropticLaryngoscopy>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllFibropticLaryngoscopy(appId, flrId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.FibropticLaryngoscopy
                {
                    flrId = Convert.ToInt32(dr["flrId"]),
                    flr_appId = Convert.ToInt32(dr["flr_appId"]),
                    flr_notes = dr["flr_notes"].ToString(),
                    flr_status = dr["flr_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.FibropticLaryngoscopy> GetAllPreFibropticLaryngoscopy(int appId, int patId)
        {
            List<BusinessEntities.EMR.FibropticLaryngoscopy> sclist = new List<BusinessEntities.EMR.FibropticLaryngoscopy>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllPreFibropticLaryngoscopy(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.FibropticLaryngoscopy
                {
                    flrId = Convert.ToInt32(dr["flrId"]),
                    flr_appId = Convert.ToInt32(dr["flr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Fibroptic Laryngoscopy Report (Page Load)
        #region  Fibroptic Laryngoscopy Report CRUD Operations
        public static bool InsertUpdateFibropticLaryngoscopy(BusinessEntities.EMR.FibropticLaryngoscopy data)
        {
            data.flr_notes = string.IsNullOrEmpty(data.flr_notes) ? string.Empty : data.flr_notes;
            return DataAccessLayer.EMR.ENT.InsertUpdateFibropticLaryngoscopy(data);
        }

        public static int DeleteFibropticLaryngoscopy(int flrId, int flr_madeby)
        {
            return DataAccessLayer.EMR.ENT.DeleteFibropticLaryngoscopy(flrId, flr_madeby);
        }
        #endregion  Fibroptic Laryngoscopy Report CRUD Operations

        #region  ENT Examination Throat (Page Load)
        public static List<BusinessEntities.EMR.ENTExamThroat> GetAllENTExamThroat(int? appId, int? etId)
        {
            List<BusinessEntities.EMR.ENTExamThroat> sclist = new List<BusinessEntities.EMR.ENTExamThroat>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllENTExamThroat(appId, etId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ENTExamThroat
                {
                    etId = Convert.ToInt32(dr["etId"]),
                    et_appId = Convert.ToInt32(dr["et_appId"]),
                    et_lip = dr["et_lip"].ToString(),
                    et_base = dr["et_base"].ToString(),
                    et_vest = dr["et_vest"].ToString(),
                    et_valle = dr["et_valle"].ToString(),
                    et_teeth = dr["et_teeth"].ToString(),
                    et_epig = dr["et_epig"].ToString(),
                    et_oral = dr["et_oral"].ToString(),
                    et_false = dr["et_false"].ToString(),
                    et_hard = dr["et_hard"].ToString(),
                    et_vent = dr["et_vent"].ToString(),
                    et_tong = dr["et_tong"].ToString(),
                    et_aryt = dr["et_aryt"].ToString(),
                    et_retro = dr["et_retro"].ToString(),
                    et_arye = dr["et_arye"].ToString(),
                    et_tons = dr["et_tons"].ToString(),
                    et_vocal = dr["et_vocal"].ToString(),
                    et_apill = dr["et_apill"].ToString(),
                    et_acomm = dr["et_acomm"].ToString(),
                    et_ppill = dr["et_ppill"].ToString(),
                    et_pcomm = dr["et_pcomm"].ToString(),
                    et_orop = dr["et_orop"].ToString(),
                    et_subg = dr["et_subg"].ToString(),
                    et_pyrif = dr["et_pyrif"].ToString(),
                    et_paro = dr["et_paro"].ToString(),
                    et_postc = dr["et_postc"].ToString(),
                    et_postp = dr["et_postp"].ToString(),
                    et_thy = dr["et_thy"].ToString(),
                    et_trac = dr["et_trac"].ToString(),
                    et_lary = dr["et_lary"].ToString(),
                    et_lymp = dr["et_lymp"].ToString(),
                    et_others = dr["et_others"].ToString(),
                    et_notes = dr["et_notes"].ToString(),
                    et_status = dr["et_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.ENTExamThroat> GetAllPreENTExamThroat(int appId, int patId)
        {
            List<BusinessEntities.EMR.ENTExamThroat> sclist = new List<BusinessEntities.EMR.ENTExamThroat>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllPreENTExamThroat(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ENTExamThroat
                {
                    etId = Convert.ToInt32(dr["etId"]),
                    et_appId = Convert.ToInt32(dr["et_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  ENT Examination Throat (Page Load)
        #region  ENT Examination Throat CRUD Operations
        public static bool InsertUpdateENTExamThroat(BusinessEntities.EMR.ENTExamThroat data)
        {
            data.et_lip = string.IsNullOrEmpty(data.et_lip) ? string.Empty : data.et_lip;
            data.et_base = string.IsNullOrEmpty(data.et_base) ? string.Empty : data.et_base;
            data.et_vest = string.IsNullOrEmpty(data.et_vest) ? string.Empty : data.et_vest;
            data.et_valle = string.IsNullOrEmpty(data.et_valle) ? string.Empty : data.et_valle;
            data.et_teeth = string.IsNullOrEmpty(data.et_teeth) ? string.Empty : data.et_teeth;
            data.et_epig = string.IsNullOrEmpty(data.et_epig) ? string.Empty : data.et_epig;
            data.et_oral = string.IsNullOrEmpty(data.et_oral) ? string.Empty : data.et_oral;
            data.et_false = string.IsNullOrEmpty(data.et_false) ? string.Empty : data.et_false;
            data.et_hard = string.IsNullOrEmpty(data.et_hard) ? string.Empty : data.et_hard;
            data.et_vent = string.IsNullOrEmpty(data.et_vent) ? string.Empty : data.et_vent;
            data.et_tong = string.IsNullOrEmpty(data.et_tong) ? string.Empty : data.et_tong;
            data.et_aryt = string.IsNullOrEmpty(data.et_aryt) ? string.Empty : data.et_aryt;
            data.et_retro = string.IsNullOrEmpty(data.et_retro) ? string.Empty : data.et_retro;
            data.et_arye = string.IsNullOrEmpty(data.et_arye) ? string.Empty : data.et_arye;
            data.et_tons = string.IsNullOrEmpty(data.et_tons) ? string.Empty : data.et_tons;
            data.et_vocal = string.IsNullOrEmpty(data.et_vocal) ? string.Empty : data.et_vocal;
            data.et_apill = string.IsNullOrEmpty(data.et_apill) ? string.Empty : data.et_apill;
            data.et_acomm = string.IsNullOrEmpty(data.et_acomm) ? string.Empty : data.et_acomm;
            data.et_pcomm = string.IsNullOrEmpty(data.et_pcomm) ? string.Empty : data.et_pcomm;
            data.et_orop = string.IsNullOrEmpty(data.et_orop) ? string.Empty : data.et_orop;
            data.et_subg = string.IsNullOrEmpty(data.et_subg) ? string.Empty : data.et_subg;
            data.et_pyrif = string.IsNullOrEmpty(data.et_pyrif) ? string.Empty : data.et_pyrif;
            data.et_paro = string.IsNullOrEmpty(data.et_paro) ? string.Empty : data.et_paro;
            data.et_postc = string.IsNullOrEmpty(data.et_postc) ? string.Empty : data.et_postc;
            data.et_postp = string.IsNullOrEmpty(data.et_postp) ? string.Empty : data.et_postp;
            data.et_thy = string.IsNullOrEmpty(data.et_thy) ? string.Empty : data.et_thy;
            data.et_trac = string.IsNullOrEmpty(data.et_trac) ? string.Empty : data.et_trac;
            data.et_lary = string.IsNullOrEmpty(data.et_lary) ? string.Empty : data.et_lary;
            data.et_lymp = string.IsNullOrEmpty(data.et_lymp) ? string.Empty : data.et_lymp;
            data.et_others = string.IsNullOrEmpty(data.et_others) ? string.Empty : data.et_others;
            data.et_notes = string.IsNullOrEmpty(data.et_notes) ? string.Empty : data.et_notes;
            

            return DataAccessLayer.EMR.ENT.InsertUpdateENTExamThroat(data);
        }

        public static int DeleteENTExamThroat(int etId, int et_madeby)
        {
            return DataAccessLayer.EMR.ENT.DeleteENTExamThroat(etId, et_madeby);
        }
        #endregion  ENT Examination Throat CRUD Operations

        #region  ENT Examination Nose (Page Load)
        public static List<BusinessEntities.EMR.ENTExamNose> GetAllENTExamNose(int? appId, int? enId)
        {
            List<BusinessEntities.EMR.ENTExamNose> sclist = new List<BusinessEntities.EMR.ENTExamNose>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllENTExamNose(appId, enId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ENTExamNose
                {
                    enId = Convert.ToInt32(dr["enId"]),
                    en_appId = Convert.ToInt32(dr["en_appId"]),
                    en_ext = dr["en_ext"].ToString(),
                    en_vest = dr["en_vest"].ToString(),
                    en_floor = dr["en_floor"].ToString(),
                    en_sept = dr["en_sept"].ToString(),
                    en_nasal = dr["en_nasal"].ToString(),
                    en_imear = dr["en_imear"].ToString(),
                    en_imeal = dr["en_imeal"].ToString(),
                    en_iturbr = dr["en_iturbr"].ToString(),
                    en_iturbl = dr["en_iturbl"].ToString(),
                    en_mmear = dr["en_mmear"].ToString(),
                    en_mmeal = dr["en_mmeal"].ToString(),
                    en_mturbr = dr["en_mturbr"].ToString(),
                    en_mturbl = dr["en_mturbl"].ToString(),
                    en_smear = dr["en_smear"].ToString(),
                    en_smeal = dr["en_smeal"].ToString(),
                    en_sturbr = dr["en_sturbr"].ToString(),
                    en_sturbl = dr["en_sturbl"].ToString(),
                    en_choane = dr["en_choane"].ToString(),
                    en_nasop = dr["en_nasop"].ToString(),
                    en_eust = dr["en_eust"].ToString(),
                    en_rose = dr["en_rose"].ToString(),
                    en_lymp = dr["en_lymp"].ToString(),
                    en_other = dr["en_other"].ToString(),
                    en_frontr = dr["en_frontr"].ToString(),
                    en_frontl = dr["en_frontl"].ToString(),
                    en_maxilr = dr["en_maxilr"].ToString(),
                    en_maxill = dr["en_maxill"].ToString(),
                    en_ethmr = dr["en_ethmr"].ToString(),
                    en_ethml = dr["en_ethml"].ToString(),
                    en_status = dr["en_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.ENTExamNose> GetAllPreENTExamNose(int appId, int patId)
        {
            List<BusinessEntities.EMR.ENTExamNose> sclist = new List<BusinessEntities.EMR.ENTExamNose>();
            DataTable dt = DataAccessLayer.EMR.ENT.GetAllPreENTExamNose(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ENTExamNose
                {
                    enId = Convert.ToInt32(dr["enId"]),
                    en_appId = Convert.ToInt32(dr["en_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  ENT Examination Nose (Page Load)
        #region  ENT Examination Nose CRUD Operations
        public static bool InsertUpdateENTExamNose(BusinessEntities.EMR.ENTExamNose data)
        {
            data.en_ext = string.IsNullOrEmpty(data.en_ext) ? string.Empty : data.en_ext;
            data.en_vest = string.IsNullOrEmpty(data.en_vest) ? string.Empty : data.en_vest;
            data.en_floor = string.IsNullOrEmpty(data.en_floor) ? string.Empty : data.en_floor;
            data.en_sept = string.IsNullOrEmpty(data.en_sept) ? string.Empty : data.en_sept;
            data.en_nasal = string.IsNullOrEmpty(data.en_nasal) ? string.Empty : data.en_nasal;
            data.en_imear = string.IsNullOrEmpty(data.en_imear) ? string.Empty : data.en_imear;
            data.en_imeal = string.IsNullOrEmpty(data.en_imeal) ? string.Empty : data.en_imeal;
            data.en_iturbr = string.IsNullOrEmpty(data.en_iturbr) ? string.Empty : data.en_iturbr;
            data.en_iturbl = string.IsNullOrEmpty(data.en_iturbl) ? string.Empty : data.en_iturbl;
            data.en_mmear = string.IsNullOrEmpty(data.en_mmear) ? string.Empty : data.en_mmear;
            data.en_mmeal = string.IsNullOrEmpty(data.en_mmeal) ? string.Empty : data.en_mmeal;
            data.en_mturbr = string.IsNullOrEmpty(data.en_mturbr) ? string.Empty : data.en_mturbr;
            data.en_mturbl = string.IsNullOrEmpty(data.en_mturbl) ? string.Empty : data.en_mturbl;
            data.en_smear = string.IsNullOrEmpty(data.en_smear) ? string.Empty : data.en_smear;
            data.en_smeal = string.IsNullOrEmpty(data.en_smeal) ? string.Empty : data.en_smeal;
            data.en_sturbr = string.IsNullOrEmpty(data.en_sturbr) ? string.Empty : data.en_sturbr;
            data.en_sturbl = string.IsNullOrEmpty(data.en_sturbl) ? string.Empty : data.en_sturbl;
            data.en_choane = string.IsNullOrEmpty(data.en_choane) ? string.Empty : data.en_choane;
            data.en_eust = string.IsNullOrEmpty(data.en_eust) ? string.Empty : data.en_eust;
            data.en_rose = string.IsNullOrEmpty(data.en_rose) ? string.Empty : data.en_rose;
            data.en_lymp = string.IsNullOrEmpty(data.en_lymp) ? string.Empty : data.en_lymp;
            data.en_other = string.IsNullOrEmpty(data.en_other) ? string.Empty : data.en_other;
            data.en_frontr = string.IsNullOrEmpty(data.en_frontr) ? string.Empty : data.en_frontr;
            data.en_frontl = string.IsNullOrEmpty(data.en_frontl) ? string.Empty : data.en_frontl;
            data.en_maxilr = string.IsNullOrEmpty(data.en_maxilr) ? string.Empty : data.en_maxilr;
            data.en_maxill = string.IsNullOrEmpty(data.en_maxill) ? string.Empty : data.en_maxill;
            data.en_ethmr = string.IsNullOrEmpty(data.en_ethmr) ? string.Empty : data.en_ethmr;
            data.en_ethml = string.IsNullOrEmpty(data.en_ethml) ? string.Empty : data.en_ethml;
            data.en_notes = string.IsNullOrEmpty(data.en_notes) ? string.Empty : data.en_notes;


            return DataAccessLayer.EMR.ENT.InsertUpdateENTExamNose(data);
        }

        public static int DeleteENTExamNose(int enId, int en_madeby)
        {
            return DataAccessLayer.EMR.ENT.DeleteENTExamNose(enId, en_madeby);
        }
        #endregion  ENT Examination Nose CRUD Operations
    }
}
