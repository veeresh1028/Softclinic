using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class DentalHistory
    {
        #region  Dental History (Page Load)
        public static List<BusinessEntities.EMR.DentalHistory> GetAllDentalHistory(int? appId, int? pdId)
        {
            List<BusinessEntities.EMR.DentalHistory> sclist = new List<BusinessEntities.EMR.DentalHistory>();
            DataTable dt = DataAccessLayer.EMR.DentalHistory.GetAllDentalHistory(appId, pdId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DentalHistory
                {
                    pdId = Convert.ToInt32(dr["pdId"]),
                    pd_appId = Convert.ToInt32(dr["pd_appId"]),
                    pd_medicaltreat = dr["pd_medicaltreat"].ToString(),
                    pd_hospitalized = dr["pd_hospitalized"].ToString(),
                    pd_medications = dr["pd_medications"].ToString(),
                    pd_medicationsyes = dr["pd_medicationsyes"].ToString(),
                    pd_tobacco = dr["pd_tobacco"].ToString(),
                    pd_gums = dr["pd_gums"].ToString(),
                    pd_hotcold = dr["pd_hotcold"].ToString(),
                    pd_sweetsour = dr["pd_sweetsour"].ToString(),
                    pd_teethpain = dr["pd_teethpain"].ToString(),
                    pd_soresjumps = dr["pd_soresjumps"].ToString(),
                    pd_headinjuries = dr["pd_headinjuries"].ToString(),
                    pd_clicking = dr["pd_clicking"].ToString(),
                    pd_pain = dr["pd_pain"].ToString(),
                    pd_openingclosing = dr["pd_openingclosing"].ToString(),
                    pd_chewing = dr["pd_chewing"].ToString(),
                    pd_clench = dr["pd_clench"].ToString(),
                    pd_bitelips = dr["pd_bitelips"].ToString(),
                    pd_difficultextract = dr["pd_difficultextract"].ToString(),
                    pd_prolonged = dr["pd_prolonged"].ToString(),
                    pd_gems = dr["pd_gems"].ToString(),
                    pd_filling = dr["pd_filling"].ToString(),
                    pd_w_medicaltreat = dr["pd_w_medicaltreat"].ToString(),
                    pd_w_hospitalized = dr["pd_w_hospitalized"].ToString(),
                    pd_w_medications = dr["pd_w_medications"].ToString(),
                    pd_w_amenorrhoea = dr["pd_w_amenorrhoea"].ToString(),
                    pd_last_dental_exam = string.IsNullOrEmpty(dr["pd_last_dental_exam"].ToString()) ? string.Empty : Convert.ToDateTime(dr["pd_last_dental_exam"].ToString()).ToString(),
                    pd_status = dr["pd_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.DentalHistory> GetAllPreDentalHistory(int appId, int patId)
        {
            List<BusinessEntities.EMR.DentalHistory> sclist = new List<BusinessEntities.EMR.DentalHistory>();
            DataTable dt = DataAccessLayer.EMR.DentalHistory.GetAllPreDentalHistory(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DentalHistory
                {
                    pdId = Convert.ToInt32(dr["pdId"]),
                    pd_appId = Convert.ToInt32(dr["pd_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Dental History (Page Load)
        #region  Dental History CRUD Operations
        public static bool InsertUpdateDentalHistory(BusinessEntities.EMR.DentalHistory data)
        {
            data.pd_medicaltreat = string.IsNullOrEmpty(data.pd_medicaltreat) ? string.Empty : data.pd_medicaltreat;
            data.pd_hospitalized = string.IsNullOrEmpty(data.pd_hospitalized) ? string.Empty : data.pd_hospitalized;
            data.pd_medications = string.IsNullOrEmpty(data.pd_medications) ? string.Empty : data.pd_medications;
            data.pd_medicationsyes = string.IsNullOrEmpty(data.pd_medicationsyes) ? string.Empty : data.pd_medicationsyes;
            data.pd_tobacco = string.IsNullOrEmpty(data.pd_tobacco) ? string.Empty : data.pd_tobacco;
            data.pd_gums = string.IsNullOrEmpty(data.pd_gums) ? string.Empty : data.pd_gums;
            data.pd_hotcold = string.IsNullOrEmpty(data.pd_hotcold) ? string.Empty : data.pd_hotcold;
            data.pd_sweetsour = string.IsNullOrEmpty(data.pd_sweetsour) ? string.Empty : data.pd_sweetsour;
            data.pd_teethpain = string.IsNullOrEmpty(data.pd_teethpain) ? string.Empty : data.pd_teethpain;
            data.pd_soresjumps = string.IsNullOrEmpty(data.pd_soresjumps) ? string.Empty : data.pd_soresjumps;
            data.pd_headinjuries = string.IsNullOrEmpty(data.pd_headinjuries) ? string.Empty : data.pd_headinjuries;
            data.pd_clicking = string.IsNullOrEmpty(data.pd_clicking) ? string.Empty : data.pd_clicking;
            data.pd_pain = string.IsNullOrEmpty(data.pd_pain) ? string.Empty : data.pd_pain;
            data.pd_openingclosing = string.IsNullOrEmpty(data.pd_openingclosing) ? string.Empty : data.pd_openingclosing;
            data.pd_chewing = string.IsNullOrEmpty(data.pd_chewing) ? string.Empty : data.pd_chewing;
            data.pd_clench = string.IsNullOrEmpty(data.pd_clench) ? string.Empty : data.pd_clench;
            data.pd_bitelips = string.IsNullOrEmpty(data.pd_bitelips) ? string.Empty : data.pd_bitelips;
            data.pd_difficultextract = string.IsNullOrEmpty(data.pd_difficultextract) ? string.Empty : data.pd_difficultextract;
            data.pd_prolonged = string.IsNullOrEmpty(data.pd_prolonged) ? string.Empty : data.pd_prolonged;
            data.pd_gems = string.IsNullOrEmpty(data.pd_gems) ? string.Empty : data.pd_gems;
            data.pd_filling = string.IsNullOrEmpty(data.pd_filling) ? string.Empty : data.pd_filling;
            data.pd_w_medicaltreat = string.IsNullOrEmpty(data.pd_w_medicaltreat) ? string.Empty : data.pd_w_medicaltreat;
            data.pd_w_hospitalized = string.IsNullOrEmpty(data.pd_w_hospitalized) ? string.Empty : data.pd_w_hospitalized;
            data.pd_w_medications = string.IsNullOrEmpty(data.pd_w_medications) ? string.Empty : data.pd_w_medications;
            data.pd_w_amenorrhoea = string.IsNullOrEmpty(data.pd_w_amenorrhoea) ? string.Empty : data.pd_w_amenorrhoea;
            data.pd_last_dental_exam = (data.pd_last_dental_exam == "Invalid date") ? string.Empty : data.pd_last_dental_exam;


            return DataAccessLayer.EMR.DentalHistory.InsertUpdateDentalHistory(data);
        }

        public static int DeleteDentalHistory(int pdId, int pd_madeby)
        {
            return DataAccessLayer.EMR.DentalHistory.DeleteDentalHistory(pdId, pd_madeby);
        }
        #endregion  Dental History CRUD Operations

        #region  Medical History (Page Load)
        public static List<BusinessEntities.EMR.MedicalHistory> GetAllMedicalHistory(int? appId, int? oeId)
        {
            List<BusinessEntities.EMR.MedicalHistory> sclist = new List<BusinessEntities.EMR.MedicalHistory>();
            DataTable dt = DataAccessLayer.EMR.DentalHistory.GetAllMedicalHistory(appId, oeId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MedicalHistory
                {
                    oeId = Convert.ToInt32(dr["oeId"]),
                    oe_appId = Convert.ToInt32(dr["oe_appId"]),
                    oe_present_ill = dr["oe_present_ill"].ToString(),
                    oe_pain = dr["oe_pain"].ToString(),
                    oe_duration = dr["oe_duration"].ToString(),
                    oe_infecious = dr["oe_infecious"].ToString(),
                    oe_infecious_other = dr["oe_infecious_other"].ToString(),
                    oe_systemic = dr["oe_systemic"].ToString(),
                    oe_systemic_other = dr["oe_systemic_other"].ToString(),
                    oe_past_med = dr["oe_past_med"].ToString(),
                    oe_past_med_other = dr["oe_past_med_other"].ToString(),
                    oe_fall_risk = dr["oe_fall_risk"].ToString(),
                    oe_fall_risk_other = dr["oe_fall_risk_other"].ToString(),
                    oe_fall_risk_type = dr["oe_fall_risk_type"].ToString(),
                    oe_notes = dr["oe_notes"].ToString(),
                    oe_extra_oral = dr["oe_extra_oral"].ToString(),
                    oe_intra_oral = dr["oe_intra_oral"].ToString(),
                    oe_oral_notes = dr["oe_oral_notes"].ToString(),
                    oe_status = dr["oe_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.MedicalHistory> GetAllPreMedicalHistory(int appId, int patId)
        {
            List<BusinessEntities.EMR.MedicalHistory> sclist = new List<BusinessEntities.EMR.MedicalHistory>();
            DataTable dt = DataAccessLayer.EMR.DentalHistory.GetAllPreMedicalHistory(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MedicalHistory
                {
                    oeId = Convert.ToInt32(dr["oeId"]),
                    oe_appId = Convert.ToInt32(dr["oe_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Medical History (Page Load)


        #region  Medical History CRUD Operations
        public static bool InsertUpdateMedicalHistory(BusinessEntities.EMR.MedicalHistory data)
        {
            data.oe_present_ill = string.IsNullOrEmpty(data.oe_present_ill) ? string.Empty : data.oe_present_ill;
            data.oe_pain = string.IsNullOrEmpty(data.oe_pain) ? string.Empty : data.oe_pain;
            data.oe_duration = string.IsNullOrEmpty(data.oe_duration) ? string.Empty : data.oe_duration;
            data.oe_infecious = string.IsNullOrEmpty(data.oe_infecious) ? string.Empty : data.oe_infecious;
            data.oe_infecious_other = string.IsNullOrEmpty(data.oe_infecious_other) ? string.Empty : data.oe_infecious_other;
            data.oe_systemic = string.IsNullOrEmpty(data.oe_systemic) ? string.Empty : data.oe_systemic;
            data.oe_systemic_other = string.IsNullOrEmpty(data.oe_systemic_other) ? string.Empty : data.oe_systemic_other;
            data.oe_past_med = string.IsNullOrEmpty(data.oe_past_med) ? string.Empty : data.oe_past_med;
            data.oe_past_med_other = string.IsNullOrEmpty(data.oe_past_med_other) ? string.Empty : data.oe_past_med_other;
            data.oe_fall_risk = string.IsNullOrEmpty(data.oe_fall_risk) ? string.Empty : data.oe_fall_risk;
            data.oe_fall_risk_other = string.IsNullOrEmpty(data.oe_fall_risk_other) ? string.Empty : data.oe_fall_risk_other;
            data.oe_fall_risk_type = string.IsNullOrEmpty(data.oe_fall_risk_type) ? string.Empty : data.oe_fall_risk_type;
            data.oe_notes = string.IsNullOrEmpty(data.oe_notes) ? string.Empty : data.oe_notes;
            data.oe_extra_oral = string.IsNullOrEmpty(data.oe_extra_oral) ? string.Empty : data.oe_extra_oral;
            data.oe_intra_oral = string.IsNullOrEmpty(data.oe_intra_oral) ? string.Empty : data.oe_intra_oral;
            data.oe_oral_notes = string.IsNullOrEmpty(data.oe_oral_notes) ? string.Empty : data.oe_oral_notes;


            return DataAccessLayer.EMR.DentalHistory.InsertUpdateMedicalHistory(data);
        }

        public static int DeleteMedicalHistory(int oeId, int oe_madeby)
        {
            return DataAccessLayer.EMR.DentalHistory.DeleteMedicalHistory(oeId, oe_madeby);
        }
        #endregion  Medical History CRUD Operations

        #region  DMF Index (Page Load)
        public static List<BusinessEntities.EMR.DMFIndex> GetAllDMFIndex(int? appId, int? dmfId)
        {
            List<BusinessEntities.EMR.DMFIndex> sclist = new List<BusinessEntities.EMR.DMFIndex>();
            DataTable dt = DataAccessLayer.EMR.DentalHistory.GetAllDMFIndex(appId, dmfId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DMFIndex
                {
                    dmfId = Convert.ToInt32(dr["dmfId"]),
                    dmf_appId = Convert.ToInt32(dr["dmf_appId"]),
                    dmf_index = dr["dmf_index"].ToString(),
                    dmf_other = dr["dmf_other"].ToString(),                   

                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.DMFIndex> GetAllPreDMFIndex(int appId, int patId)
        {
            List<BusinessEntities.EMR.DMFIndex> sclist = new List<BusinessEntities.EMR.DMFIndex>();
            DataTable dt = DataAccessLayer.EMR.DentalHistory.GetAllPreDMFIndex(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.DMFIndex
                {
                    dmfId = Convert.ToInt32(dr["dmfId"]),
                    dmf_appId = Convert.ToInt32(dr["dmf_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  DMF Index (Page Load)
        #region  DMF Index CRUD Operations
        public static bool InsertUpdateDMFIndex(BusinessEntities.EMR.DMFIndex data)
        {
            data.dmf_index = string.IsNullOrEmpty(data.dmf_index) ? string.Empty : data.dmf_index;
            data.dmf_other = string.IsNullOrEmpty(data.dmf_other) ? string.Empty : data.dmf_other;
           
            return DataAccessLayer.EMR.DentalHistory.InsertUpdateDMFIndex(data);
        }
        public static int DeleteDMFIndex(int dmfId, int dmf_madeby)
        {
            return DataAccessLayer.EMR.DentalHistory.DeleteDMFIndex(dmfId, dmf_madeby);
        }
        #endregion  DMF Index CRUD Operations

        public static int GenerateCrownOrderNo()
        {
            return DataAccessLayer.EMR.DentalHistory.GenerateCrownOrderNo();
        }

    }
}
