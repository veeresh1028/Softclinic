using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMRForms
{
    public class Adnic
    {
        #region Adnic (Page Load)
        public static List<BusinessEntities.EMRForms.Adnic> GetAllAdnic(int appId)
        {
            List<BusinessEntities.EMRForms.Adnic> sclist = new List<BusinessEntities.EMRForms.Adnic>();
            DataTable dt = DataAccessLayer.EMRForms.Adnic.GetAllAdnic(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Adnic
                {
                    adsId = Convert.ToInt32(dr["adsId"]),
                    ads_appId = Convert.ToInt32(dr["ads_appId"]),
                    ads_voucher = dr["ads_voucher"].ToString(),
                    ads_group_mem = dr["ads_group_mem"].ToString(),
                    ads_type_plan = dr["ads_type_plan"].ToString(),
                    ads_reason = dr["ads_reason"].ToString(),
                    ads_reason_other = dr["ads_reason_other"].ToString(),
                    ads_visit = dr["ads_visit"].ToString(),
                    ads_condition = dr["ads_condition"].ToString(),
                    ads_treat_details = dr["ads_treat_details"].ToString(),
                    ads_addr1 = dr["ads_addr1"].ToString(),
                    ads_bill1 = dr["ads_bill1"].ToString(),
                    ads_tdate1 = dr["ads_tdate1"].ToString(),
                    ads_desc1 = dr["ads_desc1"].ToString(),
                    ads_amt1 = dr["ads_amt1"].ToString(),
                    ads_addr2 = dr["ads_addr2"].ToString(),
                    ads_bill2 = dr["ads_bill2"].ToString(),
                    ads_tdate2 = dr["ads_tdate2"].ToString(),
                    ads_desc2 = dr["ads_desc2"].ToString(),
                    ads_amt2 = dr["ads_amt2"].ToString(),
                    ads_addr3 = dr["ads_addr3"].ToString(),
                    ads_bill3 = dr["ads_bill3"].ToString(),
                    ads_tdate3 = dr["ads_tdate3"].ToString(),
                    ads_desc3 = dr["ads_desc3"].ToString(),
                    ads_amt3 = dr["ads_amt3"].ToString(),
                    ads_addr4 = dr["ads_addr4"].ToString(),
                    ads_bill4 = dr["ads_bill4"].ToString(),
                    ads_tdate4 = dr["ads_tdate4"].ToString(),
                    ads_desc4 = dr["ads_desc4"].ToString(),
                    ads_amt4 = dr["ads_amt4"].ToString(),
                    ads_addr5 = dr["ads_addr5"].ToString(),
                    ads_bill5 = dr["ads_bill5"].ToString(),
                    ads_tdate5 = dr["ads_tdate5"].ToString(),
                    ads_desc5 = dr["ads_desc5"].ToString(),
                    ads_amt5 = dr["ads_amt5"].ToString(),
                    ads_total = dr["ads_total"].ToString(),
                    ads_oth_above = dr["ads_oth_above"].ToString(),
                    ads_oth_claim = dr["ads_oth_claim"].ToString(),
                    //pat_sign_date_time = dr["ads_date_created"].ToString(),               
                    ads_oth_above_det = dr["ads_oth_above_det"].ToString(),
                    ads_oth_claim_det = dr["ads_oth_claim_det"].ToString(),
                    ads_onset_duration = dr["ads_onset"].ToString(),
                    ads_bankDetails = dr["ads_bank"].ToString(),
                    ads_account_holder = dr["ads_account"].ToString(),
                    ads_bank_name = dr["ads_bname"].ToString(),
                    ads_bank_address = dr["ads_baddress"].ToString(),
                    ads_bank_currency = dr["ads_bcurrency"].ToString(),
                    ads_bank_swiftcode = dr["ads_bswiftcode"].ToString(),
                    ads_witnessname = dr["ads_witnessname"].ToString(),
                    ads_contact = dr["ads_contact"].ToString(),
                    ads_date_created = Convert.ToDateTime(dr["ads_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Adnic> GetAllPreAdnic(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Adnic> sclist = new List<BusinessEntities.EMRForms.Adnic>();
            DataTable dt = DataAccessLayer.EMRForms.Adnic.GetAllPreAdnic(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Adnic
                {
                    adsId = Convert.ToInt32(dr["adsId"]),
                    ads_appId = Convert.ToInt32(dr["ads_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMRForms.Adnic> GetAllPatientTreatments(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Adnic> sclist = new List<BusinessEntities.EMRForms.Adnic>();
            DataTable dt = DataAccessLayer.EMRForms.Adnic.GetAllPatientTreatments(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Adnic
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    tr_code = dr["tr_code"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    pt_qty = dr["pt_qty"].ToString(),
                    tr_type = dr["tr_type"].ToString(),
                    tr_price = float.Parse(dr["tr_price"].ToString()).ToString("N2"),
                    pt_auth_code = dr["pt_auth_code"].ToString(),
                    pt_auth_adate = dr["pt_auth_adate"].ToString(),
                    pt_auth_edate = dr["pt_auth_edate"].ToString(),
                    pt_date_collected = Convert.ToDateTime(dr["pt_date_collected"].ToString()),
                    pt_date_received = Convert.ToDateTime(dr["pt_date_received"].ToString()),
                    pt_teeth = dr["pt_teeth"].ToString(),
                    pt_sur = dr["pt_sur"].ToString(),
                    pt_notes = dr["pt_notes"].ToString(),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Adnic> Get_Patient_Signs(int appId)
        {
            List<BusinessEntities.EMRForms.Adnic> sclist = new List<BusinessEntities.EMRForms.Adnic>();
            DataTable dt = DataAccessLayer.EMRForms.Adnic.Get_Patient_Signs(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Adnic
                {
                    sign_bp = dr["sign_bp"].ToString(),
                    sign_pulse = dr["sign_pulse"].ToString(),
                    sign_temp = dr["sign_temp"].ToString(),
                    sign_notes = dr["sign_notes"].ToString(),

                });
            }
            return sclist;
        }

        //Get Complaints
        public static List<BusinessEntities.EMRForms.Adnic> Get_Patient_Complaints(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Adnic> sclist = new List<BusinessEntities.EMRForms.Adnic>();
            DataTable dt = DataAccessLayer.EMRForms.Adnic.Get_Patient_Complaints(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Adnic
                {

                    complaints = dr["complaints"].ToString(),

                });
            }
            return sclist;
        }

        //Get Treatments
        public static List<BusinessEntities.EMRForms.Adnic> Get_Patient_Treatment(int appId)
        {
            List<BusinessEntities.EMRForms.Adnic> sclist = new List<BusinessEntities.EMRForms.Adnic>();
            DataTable dt = DataAccessLayer.EMRForms.Adnic.Get_Patient_Treatment(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Adnic
                {

                    treatments = dr["treatments"].ToString(),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Adnic> GetPrintAdnic(int? adsId)
        {
            List<BusinessEntities.EMRForms.Adnic> sclist = new List<BusinessEntities.EMRForms.Adnic>();
            DataTable dt = DataAccessLayer.EMRForms.Adnic.GetPrintAdnic(adsId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Adnic
                    {
                        adsId = Convert.ToInt32(dr["adsId"]),
                        ads_appId = Convert.ToInt32(dr["ads_appId"]),
                        ads_voucher = dr["ads_voucher"].ToString(),
                        ads_group_mem = dr["ads_group_mem"].ToString(),
                        ads_type_plan = dr["ads_type_plan"].ToString(),
                        ads_reason = dr["ads_reason"].ToString(),
                        ads_reason_other = dr["ads_reason_other"].ToString(),
                        ads_visit = dr["ads_visit"].ToString(),
                        ads_condition = dr["ads_condition"].ToString(),
                        ads_treat_details = dr["ads_treat_details"].ToString(),
                        ads_addr1 = dr["ads_addr1"].ToString(),
                        ads_bill1 = dr["ads_bill1"].ToString(),
                        ads_tdate1 = dr["ads_tdate1"].ToString(),
                        ads_desc1 = dr["ads_desc1"].ToString(),
                        ads_amt1 = dr["ads_amt1"].ToString(),
                        ads_addr2 = dr["ads_addr2"].ToString(),
                        ads_bill2 = dr["ads_bill2"].ToString(),
                        ads_tdate2 = dr["ads_tdate2"].ToString(),
                        ads_desc2 = dr["ads_desc2"].ToString(),
                        ads_amt2 = dr["ads_amt2"].ToString(),
                        ads_addr3 = dr["ads_addr3"].ToString(),
                        ads_bill3 = dr["ads_bill3"].ToString(),
                        ads_tdate3 = dr["ads_tdate3"].ToString(),
                        ads_desc3 = dr["ads_desc3"].ToString(),
                        ads_amt3 = dr["ads_amt3"].ToString(),
                        ads_addr4 = dr["ads_addr4"].ToString(),
                        ads_bill4 = dr["ads_bill4"].ToString(),
                        ads_tdate4 = dr["ads_tdate4"].ToString(),
                        ads_desc4 = dr["ads_desc4"].ToString(),
                        ads_amt4 = dr["ads_amt4"].ToString(),
                        ads_addr5 = dr["ads_addr5"].ToString(),
                        ads_bill5 = dr["ads_bill5"].ToString(),
                        ads_tdate5 = dr["ads_tdate5"].ToString(),
                        ads_desc5 = dr["ads_desc5"].ToString(),
                        ads_amt5 = dr["ads_amt5"].ToString(),
                        ads_total = dr["ads_total"].ToString(),
                        ads_oth_above = dr["ads_oth_above"].ToString(),
                        ads_oth_claim = dr["ads_oth_claim"].ToString(),
                        //pat_sign_date_time = dr["ads_date_created"].ToString(),               
                        ads_oth_above_det = dr["ads_oth_above_det"].ToString(),
                        ads_oth_claim_det = dr["ads_oth_claim_det"].ToString(),
                        ads_onset_duration = dr["ads_onset"].ToString(),
                        ads_bankDetails = dr["ads_bank"].ToString(),
                        ads_account_holder = dr["ads_account"].ToString(),
                        ads_bank_name = dr["ads_bname"].ToString(),
                        ads_bank_address = dr["ads_baddress"].ToString(),
                        ads_bank_currency = dr["ads_bcurrency"].ToString(),
                        ads_bank_swiftcode = dr["ads_bswiftcode"].ToString(),
                        ads_witnessname = dr["ads_witnessname"].ToString(),
                        ads_contact = dr["ads_contact"].ToString(),
                        ads_date_created = Convert.ToDateTime(dr["ads_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Adnic a = new BusinessEntities.EMRForms.Adnic();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Adnic (Page Load)
        #region Adnic (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAdnic(BusinessEntities.EMRForms.Adnic data)
        {
            data.ads_reason = string.IsNullOrEmpty(data.ads_reason) ? string.Empty : data.ads_reason;
            data.ads_voucher = string.IsNullOrEmpty(data.ads_voucher) ? string.Empty : data.ads_voucher;
            data.ads_group_mem = string.IsNullOrEmpty(data.ads_group_mem) ? string.Empty : data.ads_group_mem;
            data.ads_type_plan = string.IsNullOrEmpty(data.ads_type_plan) ? string.Empty : data.ads_type_plan;
            data.ads_reason_other = string.IsNullOrEmpty(data.ads_reason_other) ? string.Empty : data.ads_reason_other;
            data.ads_condition = string.IsNullOrEmpty(data.ads_condition) ? string.Empty : data.ads_condition;
            data.ads_visit = string.IsNullOrEmpty(data.ads_visit) ? string.Empty : data.ads_visit;
            data.ads_treat_details = string.IsNullOrEmpty(data.ads_treat_details) ? string.Empty : data.ads_treat_details;
            data.ads_addr1 = string.IsNullOrEmpty(data.ads_addr1) ? string.Empty : data.ads_addr1;
            data.ads_bill1 = string.IsNullOrEmpty(data.ads_bill1) ? string.Empty : data.ads_bill1;
            data.ads_tdate1 = string.IsNullOrEmpty(data.ads_tdate1) ? string.Empty : data.ads_tdate1;
            data.ads_desc1 = string.IsNullOrEmpty(data.ads_desc1) ? string.Empty : data.ads_desc1;
            data.ads_amt1 = string.IsNullOrEmpty(data.ads_amt1) ? string.Empty : data.ads_amt1;

            data.ads_addr2 = string.IsNullOrEmpty(data.ads_addr2) ? string.Empty : data.ads_addr2;
            data.ads_bill2 = string.IsNullOrEmpty(data.ads_bill2) ? string.Empty : data.ads_bill2;
            data.ads_tdate2 = string.IsNullOrEmpty(data.ads_tdate2) ? string.Empty : data.ads_tdate2;
            data.ads_desc2 = string.IsNullOrEmpty(data.ads_desc2) ? string.Empty : data.ads_desc2;
            data.ads_amt2 = string.IsNullOrEmpty(data.ads_amt2) ? string.Empty : data.ads_amt2;

            data.ads_addr3 = string.IsNullOrEmpty(data.ads_addr3) ? string.Empty : data.ads_addr3;
            data.ads_bill3 = string.IsNullOrEmpty(data.ads_bill3) ? string.Empty : data.ads_bill3;
            data.ads_tdate3 = string.IsNullOrEmpty(data.ads_tdate3) ? string.Empty : data.ads_tdate3;
            data.ads_desc3 = string.IsNullOrEmpty(data.ads_desc3) ? string.Empty : data.ads_desc3;
            data.ads_amt3 = string.IsNullOrEmpty(data.ads_amt3) ? string.Empty : data.ads_amt3;

            data.ads_addr4 = string.IsNullOrEmpty(data.ads_addr4) ? string.Empty : data.ads_addr4;
            data.ads_bill4 = string.IsNullOrEmpty(data.ads_bill4) ? string.Empty : data.ads_bill4;
            data.ads_tdate4 = string.IsNullOrEmpty(data.ads_tdate4) ? string.Empty : data.ads_tdate4;
            data.ads_desc4 = string.IsNullOrEmpty(data.ads_desc4) ? string.Empty : data.ads_desc4;
            data.ads_amt4 = string.IsNullOrEmpty(data.ads_amt4) ? string.Empty : data.ads_amt4;
            data.ads_total = string.IsNullOrEmpty(data.ads_total) ? string.Empty : data.ads_total;

            data.ads_addr5 = string.IsNullOrEmpty(data.ads_addr5) ? string.Empty : data.ads_addr5;
            data.ads_bill5 = string.IsNullOrEmpty(data.ads_bill5) ? string.Empty : data.ads_bill5;
            data.ads_tdate5 = string.IsNullOrEmpty(data.ads_tdate5) ? string.Empty : data.ads_tdate5;
            data.ads_desc5 = string.IsNullOrEmpty(data.ads_desc5) ? string.Empty : data.ads_desc5;
            data.ads_amt5 = string.IsNullOrEmpty(data.ads_amt5) ? string.Empty : data.ads_amt5;
            data.ads_oth_above = string.IsNullOrEmpty(data.ads_oth_above) ? string.Empty : data.ads_oth_above;
            data.ads_oth_claim = string.IsNullOrEmpty(data.ads_oth_claim) ? string.Empty : data.ads_oth_claim;
            data.ads_oth_claim_det = string.IsNullOrEmpty(data.ads_oth_claim_det) ? string.Empty : data.ads_oth_claim_det;
            data.ads_oth_above_det = string.IsNullOrEmpty(data.ads_oth_above_det) ? string.Empty : data.ads_oth_above_det;
            data.ads_onset = string.IsNullOrEmpty(data.ads_onset) ? string.Empty : data.ads_onset;
            data.ads_bank = string.IsNullOrEmpty(data.ads_bank) ? string.Empty : data.ads_bank;
            data.ads_account = string.IsNullOrEmpty(data.ads_account) ? string.Empty : data.ads_account;
            data.ads_bname = string.IsNullOrEmpty(data.ads_bname) ? string.Empty : data.ads_bname;
            data.ads_baddress = string.IsNullOrEmpty(data.ads_baddress) ? string.Empty : data.ads_baddress;
            data.ads_bcurrency = string.IsNullOrEmpty(data.ads_bcurrency) ? string.Empty : data.ads_bcurrency;
            data.ads_bswiftcode = string.IsNullOrEmpty(data.ads_bswiftcode) ? string.Empty : data.ads_bswiftcode;
            data.ads_witnessname = string.IsNullOrEmpty(data.ads_witnessname) ? string.Empty : data.ads_witnessname;
            data.ads_contact = string.IsNullOrEmpty(data.ads_contact) ? string.Empty : data.ads_contact;

            return DataAccessLayer.EMRForms.Adnic.InsertUpdateAdnic(data);
        }

        //Delete
        public static int DeleteAdnic(int adsId, int ads_madeby)
        {
            return DataAccessLayer.EMRForms.Adnic.DeleteAdnic(adsId, ads_madeby);
        }
        #endregion Adnic (CRUD Operations)

    }
    public class Aetna
    {
        #region Aetna (Page Load)
        public static List<BusinessEntities.EMRForms.Aetna> GetAllAetna(int appId)
        {
            List<BusinessEntities.EMRForms.Aetna> sclist = new List<BusinessEntities.EMRForms.Aetna>();
            DataTable dt = DataAccessLayer.EMRForms.Aetna.GetAllAetna(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Aetna
                {
                    car_Id = Convert.ToInt32(dr["car_Id"]),
                    car_appId = Convert.ToInt32(dr["car_appId"]),
                    car_checkbox = dr["car_checkbox"].ToString(),
                    car_r1 = dr["car_r1"].ToString(),
                    car_r2 = dr["car_r2"].ToString(),
                    car_r3 = dr["car_r3"].ToString(),
                    car_r4 = dr["car_r4"].ToString(),
                    car_r5 = dr["car_r5"].ToString(),
                    car_r6 = dr["car_r6"].ToString(),
                    car_r7 = dr["car_r7"].ToString(),
                    car_r8 = dr["car_r8"].ToString(),
                    car_r9 = dr["car_r9"].ToString(),
                    car_r10 = dr["car_r10"].ToString(),
                    car_r11 = dr["car_r11"].ToString(),
                    car_r12 = dr["car_r12"].ToString(),
                    car_r13 = string.IsNullOrEmpty(dr["car_r13"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r13"].ToString()).ToString(),
                    car_r14 = string.IsNullOrEmpty(dr["car_r14"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r14"].ToString()).ToString(),
                    car_r15 = dr["car_r15"].ToString(),
                    car_r16 = dr["car_r16"].ToString(),
                    car_r17 = dr["car_r17"].ToString(),
                    car_r18 = string.IsNullOrEmpty(dr["car_r18"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r18"].ToString()).ToString(),
                    car_r19 = string.IsNullOrEmpty(dr["car_r19"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r19"].ToString()).ToString(),
                    car_r20 = dr["car_r20"].ToString(),
                    car_r21 = dr["car_r21"].ToString(),
                    car_r22 = dr["car_r22"].ToString(),
                    car_r23 = string.IsNullOrEmpty(dr["car_r23"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r23"].ToString()).ToString(),
                    car_r24 = string.IsNullOrEmpty(dr["car_r24"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r24"].ToString()).ToString(),
                    car_r25 = dr["car_r25"].ToString(),
                    car_r26 = dr["car_r26"].ToString(),
                    car_r27 = dr["car_r27"].ToString(),
                    car_r28 = string.IsNullOrEmpty(dr["car_r28"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r28"].ToString()).ToString(),
                    car_r29 = string.IsNullOrEmpty(dr["car_r29"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r29"].ToString()).ToString(),
                    car_r30 = dr["car_r30"].ToString(),
                    car_r31 = dr["car_r31"].ToString(),
                    car_r32 = dr["car_r32"].ToString(),
                    car_r33 = string.IsNullOrEmpty(dr["car_r33"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r33"].ToString()).ToString(),
                    car_r34 = string.IsNullOrEmpty(dr["car_r34"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r34"].ToString()).ToString(),
                    car_r35 = dr["car_r35"].ToString(),
                    car_r36 = dr["car_r36"].ToString(),
                    car_r37 = dr["car_r37"].ToString(),
                    car_r38 = string.IsNullOrEmpty(dr["car_r38"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r38"].ToString()).ToString(),
                    car_r39 = string.IsNullOrEmpty(dr["car_r39"].ToString()) ? string.Empty : Convert.ToDateTime(dr["car_r39"].ToString()).ToString(),
                    car_r40 = dr["car_r40"].ToString(),
                    car_r41 = dr["car_r41"].ToString(),
                    car_r42 = dr["car_r42"].ToString(),
                    car_r43 = dr["car_r43"].ToString(),
                    car_r44 = dr["car_r44"].ToString(),
                    car_r45 = dr["car_r45"].ToString(),
                    car_r46 = dr["car_r46"].ToString(),
                    car_r47 = dr["car_r47"].ToString(),
                    car_r48 = dr["car_r48"].ToString(),
                    car_r49 = dr["car_r49"].ToString(),
                    car_r50 = dr["car_r50"].ToString(),
                    car_r51 = dr["car_r51"].ToString(),
                    car_r52 = dr["car_r52"].ToString(),
                    car_r53 = dr["car_r53"].ToString(),
                    car_r54 = dr["car_r54"].ToString(),
                    car_r55 = dr["car_r55"].ToString(),
                    car_r56 = dr["car_r56"].ToString(),
                    car_r57 = dr["car_r57"].ToString(),
                    car_r58 = dr["car_r58"].ToString(),
                    car_r59 = dr["car_r59"].ToString(),
                    car_r60 = dr["car_r60"].ToString(),
                    car_r61 = dr["car_r61"].ToString(),
                    car_r62 = dr["car_r62"].ToString(),
                    car_r63 = dr["car_r63"].ToString(),
                    car_r64 = dr["car_r64"].ToString(),
                    car_r65 = dr["car_r65"].ToString(),
                    car_r66 = dr["car_r66"].ToString(),
                    car_r67 = dr["car_r67"].ToString(),
                    car_r68 = dr["car_r68"].ToString(),
                    car_r69 = dr["car_r69"].ToString(),
                    car_r70 = dr["car_r70"].ToString(),
                    car_r71 = dr["car_r71"].ToString(),
                    car_r72 = dr["car_r72"].ToString(),
                    car_r73 = dr["car_r73"].ToString(),
                    car_r74 = dr["car_r74"].ToString(),
                    car_r75 = dr["car_r75"].ToString(),
                    car_d1 = Convert.ToDateTime(dr["car_d1"].ToString()),
                    car_d2 = Convert.ToDateTime(dr["car_d2"].ToString()),
                    car_d3 = Convert.ToDateTime(dr["car_d3"].ToString()),
                    car_d4 = Convert.ToDateTime(dr["car_d4"].ToString()),
                    car_d5 = Convert.ToDateTime(dr["car_d5"].ToString()),
                    car_d6 = Convert.ToDateTime(dr["car_d6"].ToString()),
                    car_d7 = Convert.ToDateTime(dr["car_d7"].ToString()),
                    car_d8 = Convert.ToDateTime(dr["car_d8"].ToString()),
                    car_date_created = Convert.ToDateTime(dr["car_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Aetna> GetAllPreAetna(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Aetna> sclist = new List<BusinessEntities.EMRForms.Aetna>();
            DataTable dt = DataAccessLayer.EMRForms.Aetna.GetAllPreAetna(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Aetna
                {
                    car_Id = Convert.ToInt32(dr["car_Id"]),
                    car_appId = Convert.ToInt32(dr["car_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //Get Diagnosis
        public static List<BusinessEntities.EMRForms.Aetna> Get_Patient_Diagnosis(int appId)
        {
            List<BusinessEntities.EMRForms.Aetna> sclist = new List<BusinessEntities.EMRForms.Aetna>();
            DataTable dt = DataAccessLayer.EMRForms.Aetna.Get_Patient_Diagnosis(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Aetna
                {
                    diag_names = dr["diag_names"].ToString(),
                    diag_codes = dr["diag_codes"].ToString(),

                });
            }
            return sclist;
        }
        //Get Lab Treatments
        public static List<BusinessEntities.EMRForms.Aetna> Get_Patient_Lab_Treatment(int appId)
        {
            List<BusinessEntities.EMRForms.Aetna> sclist = new List<BusinessEntities.EMRForms.Aetna>();
            DataTable dt = DataAccessLayer.EMRForms.Aetna.Get_Patient_Lab_Treatment(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Aetna
                {

                    lab_treatments = dr["treatments"].ToString(),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.Aetna> GetPrintAetna(int? car_Id)
        {
            List<BusinessEntities.EMRForms.Aetna> sclist = new List<BusinessEntities.EMRForms.Aetna>();
            DataTable dt = DataAccessLayer.EMRForms.Aetna.GetPrintAetna(car_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Aetna
                    {
                        car_Id = Convert.ToInt32(dr["car_Id"]),
                        car_appId = Convert.ToInt32(dr["car_appId"]),
                        car_checkbox = dr["car_checkbox"].ToString(),
                        car_r1 = dr["car_r1"].ToString(),
                        car_r2 = dr["car_r2"].ToString(),
                        car_r3 = dr["car_r3"].ToString(),
                        car_r4 = dr["car_r4"].ToString(),
                        car_r5 = dr["car_r5"].ToString(),
                        car_r6 = dr["car_r6"].ToString(),
                        car_r7 = dr["car_r7"].ToString(),
                        car_r8 = dr["car_r8"].ToString(),
                        car_r9 = dr["car_r9"].ToString(),
                        car_r10 = dr["car_r10"].ToString(),
                        car_r11 = dr["car_r11"].ToString(),
                        car_r12 = dr["car_r12"].ToString(),
                        car_r13 = dr["car_r13"].ToString(),
                        car_r14 = dr["car_r14"].ToString(),
                        car_r15 = dr["car_r15"].ToString(),
                        car_r16 = dr["car_r16"].ToString(),
                        car_r17 = dr["car_r17"].ToString(),
                        car_r18 = dr["car_r18"].ToString(),
                        car_r19 = dr["car_r19"].ToString(),
                        car_r20 = dr["car_r20"].ToString(),
                        car_r21 = dr["car_r21"].ToString(),
                        car_r22 = dr["car_r22"].ToString(),
                        car_r23 = dr["car_r23"].ToString(),
                        car_r24 = dr["car_r24"].ToString(),
                        car_r25 = dr["car_r25"].ToString(),
                        car_r26 = dr["car_r26"].ToString(),
                        car_r27 = dr["car_r27"].ToString(),
                        car_r28 = dr["car_r28"].ToString(),
                        car_r29 = dr["car_r29"].ToString(),
                        car_r30 = dr["car_r30"].ToString(),
                        car_r31 = dr["car_r31"].ToString(),
                        car_r32 = dr["car_r32"].ToString(),
                        car_r33 = dr["car_r33"].ToString(),
                        car_r34 = dr["car_r34"].ToString(),
                        car_r35 = dr["car_r35"].ToString(),
                        car_r36 = dr["car_r36"].ToString(),
                        car_r37 = dr["car_r37"].ToString(),
                        car_r38 = dr["car_r38"].ToString(),
                        car_r39 = dr["car_r39"].ToString(),
                        car_r40 = dr["car_r40"].ToString(),
                        car_r41 = dr["car_r41"].ToString(),
                        car_r42 = dr["car_r42"].ToString(),
                        car_r43 = dr["car_r43"].ToString(),
                        car_r44 = dr["car_r44"].ToString(),
                        car_r45 = dr["car_r45"].ToString(),
                        car_r46 = dr["car_r46"].ToString(),
                        car_r47 = dr["car_r47"].ToString(),
                        car_r48 = dr["car_r48"].ToString(),
                        car_r49 = dr["car_r49"].ToString(),
                        car_r50 = dr["car_r50"].ToString(),
                        car_r51 = dr["car_r51"].ToString(),
                        car_r52 = dr["car_r52"].ToString(),
                        car_r53 = dr["car_r53"].ToString(),
                        car_r54 = dr["car_r54"].ToString(),
                        car_r55 = dr["car_r55"].ToString(),
                        car_r56 = dr["car_r56"].ToString(),
                        car_r57 = dr["car_r57"].ToString(),
                        car_r58 = dr["car_r58"].ToString(),
                        car_r59 = dr["car_r59"].ToString(),
                        car_r60 = dr["car_r60"].ToString(),
                        car_r61 = dr["car_r61"].ToString(),
                        car_r62 = dr["car_r62"].ToString(),
                        car_r63 = dr["car_r63"].ToString(),
                        car_r64 = dr["car_r64"].ToString(),
                        car_r65 = dr["car_r65"].ToString(),
                        car_r66 = dr["car_r66"].ToString(),
                        car_r67 = dr["car_r67"].ToString(),
                        car_r68 = dr["car_r68"].ToString(),
                        car_r69 = dr["car_r69"].ToString(),
                        car_r70 = dr["car_r70"].ToString(),
                        car_r71 = dr["car_r71"].ToString(),
                        car_r72 = dr["car_r72"].ToString(),
                        car_r73 = dr["car_r73"].ToString(),
                        car_r74 = dr["car_r74"].ToString(),
                        car_r75 = dr["car_r75"].ToString(),
                        car_dd1 = dr["car_d1"].ToString(),
                        car_dd2 = dr["car_d2"].ToString(),
                        car_dd3 = dr["car_d3"].ToString(),
                        car_dd4 = dr["car_d4"].ToString(),
                        car_dd5 = dr["car_d5"].ToString(),
                        car_dd6 = dr["car_d6"].ToString(),
                        car_dd7 = dr["car_d7"].ToString(),
                        car_dd8 = dr["car_d8"].ToString(),
                        car_date_created = Convert.ToDateTime(dr["car_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Aetna a = new BusinessEntities.EMRForms.Aetna();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Aetna (Page Load)

        #region Aetna (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAetna(BusinessEntities.EMRForms.Aetna data)
        {
            data.car_checkbox = string.IsNullOrEmpty(data.car_checkbox) ? string.Empty : data.car_checkbox;
            data.car_r1 = string.IsNullOrEmpty(data.car_r1) ? string.Empty : data.car_r1;
            data.car_r2 = string.IsNullOrEmpty(data.car_r2) ? string.Empty : data.car_r2;
            data.car_r3 = string.IsNullOrEmpty(data.car_r3) ? string.Empty : data.car_r3;
            data.car_r4 = string.IsNullOrEmpty(data.car_r4) ? string.Empty : data.car_r4;
            data.car_r5 = string.IsNullOrEmpty(data.car_r5) ? string.Empty : data.car_r5;
            data.car_r6 = string.IsNullOrEmpty(data.car_r6) ? string.Empty : data.car_r6;
            data.car_r7 = string.IsNullOrEmpty(data.car_r7) ? string.Empty : data.car_r7;
            data.car_r8 = string.IsNullOrEmpty(data.car_r8) ? string.Empty : data.car_r8;
            data.car_r9 = string.IsNullOrEmpty(data.car_r9) ? string.Empty : data.car_r9;
            data.car_r10 = string.IsNullOrEmpty(data.car_r10) ? string.Empty : data.car_r10;
            data.car_r11 = string.IsNullOrEmpty(data.car_r11) ? string.Empty : data.car_r11;
            data.car_r12 = string.IsNullOrEmpty(data.car_r12) ? string.Empty : data.car_r12;
            data.car_r13 = (data.car_r13 == "Invalid date") ? string.Empty : data.car_r13;
            data.car_r14 = (data.car_r14 == "Invalid date") ? string.Empty : data.car_r14;
            data.car_r15 = string.IsNullOrEmpty(data.car_r15) ? string.Empty : data.car_r15;
            data.car_r16 = string.IsNullOrEmpty(data.car_r16) ? string.Empty : data.car_r16;
            data.car_r17 = string.IsNullOrEmpty(data.car_r17) ? string.Empty : data.car_r17;
            data.car_r18 = (data.car_r18 == "Invalid date") ? string.Empty : data.car_r18;
            data.car_r19 = (data.car_r19 == "Invalid date") ? string.Empty : data.car_r19;
            data.car_r20 = string.IsNullOrEmpty(data.car_r20) ? string.Empty : data.car_r20;
            data.car_r21 = string.IsNullOrEmpty(data.car_r21) ? string.Empty : data.car_r21;
            data.car_r22 = string.IsNullOrEmpty(data.car_r22) ? string.Empty : data.car_r22;
            data.car_r23 = (data.car_r23 == "Invalid date") ? string.Empty : data.car_r23;
            data.car_r24 = (data.car_r24 == "Invalid date") ? string.Empty : data.car_r24;
            data.car_r25 = string.IsNullOrEmpty(data.car_r25) ? string.Empty : data.car_r25;
            data.car_r26 = string.IsNullOrEmpty(data.car_r26) ? string.Empty : data.car_r26;
            data.car_r27 = string.IsNullOrEmpty(data.car_r27) ? string.Empty : data.car_r27;
            data.car_r28 = (data.car_r28 == "Invalid date") ? string.Empty : data.car_r28;
            data.car_r29 = (data.car_r29 == "Invalid date") ? string.Empty : data.car_r29;
            data.car_r30 = string.IsNullOrEmpty(data.car_r30) ? string.Empty : data.car_r30;
            data.car_r31 = string.IsNullOrEmpty(data.car_r31) ? string.Empty : data.car_r31;
            data.car_r32 = string.IsNullOrEmpty(data.car_r32) ? string.Empty : data.car_r32;
            data.car_r33 = (data.car_r33 == "Invalid date") ? string.Empty : data.car_r33;
            data.car_r34 = (data.car_r34 == "Invalid date") ? string.Empty : data.car_r34;
            data.car_r35 = string.IsNullOrEmpty(data.car_r35) ? string.Empty : data.car_r35;
            data.car_r36 = string.IsNullOrEmpty(data.car_r36) ? string.Empty : data.car_r36;
            data.car_r37 = string.IsNullOrEmpty(data.car_r37) ? string.Empty : data.car_r37;
            data.car_r38 = (data.car_r38 == "Invalid date") ? string.Empty : data.car_r38;
            data.car_r39 = (data.car_r39 == "Invalid date") ? string.Empty : data.car_r39;
            data.car_r40 = string.IsNullOrEmpty(data.car_r40) ? string.Empty : data.car_r40;
            data.car_r41 = string.IsNullOrEmpty(data.car_r41) ? string.Empty : data.car_r41;
            data.car_r42 = string.IsNullOrEmpty(data.car_r42) ? string.Empty : data.car_r42;
            data.car_r43 = string.IsNullOrEmpty(data.car_r43) ? string.Empty : data.car_r43;
            data.car_r44 = string.IsNullOrEmpty(data.car_r44) ? string.Empty : data.car_r44;
            data.car_r45 = string.IsNullOrEmpty(data.car_r45) ? string.Empty : data.car_r45;
            data.car_r46 = string.IsNullOrEmpty(data.car_r46) ? string.Empty : data.car_r46;
            data.car_r47 = string.IsNullOrEmpty(data.car_r47) ? string.Empty : data.car_r47;
            data.car_r48 = string.IsNullOrEmpty(data.car_r48) ? string.Empty : data.car_r48;
            data.car_r49 = string.IsNullOrEmpty(data.car_r49) ? string.Empty : data.car_r49;
            data.car_r50 = string.IsNullOrEmpty(data.car_r50) ? string.Empty : data.car_r50;
            data.car_r51 = string.IsNullOrEmpty(data.car_r51) ? string.Empty : data.car_r51;
            data.car_r52 = string.IsNullOrEmpty(data.car_r52) ? string.Empty : data.car_r52;
            data.car_r53 = string.IsNullOrEmpty(data.car_r53) ? string.Empty : data.car_r53;
            data.car_r54 = string.IsNullOrEmpty(data.car_r54) ? string.Empty : data.car_r54;
            data.car_r55 = string.IsNullOrEmpty(data.car_r55) ? string.Empty : data.car_r55;
            data.car_r56 = string.IsNullOrEmpty(data.car_r56) ? string.Empty : data.car_r56;
            data.car_r57 = string.IsNullOrEmpty(data.car_r57) ? string.Empty : data.car_r57;
            data.car_r58 = string.IsNullOrEmpty(data.car_r58) ? string.Empty : data.car_r58;
            data.car_r59 = string.IsNullOrEmpty(data.car_r59) ? string.Empty : data.car_r59;
            data.car_r60 = string.IsNullOrEmpty(data.car_r60) ? string.Empty : data.car_r60;
            data.car_r61 = string.IsNullOrEmpty(data.car_r61) ? string.Empty : data.car_r61;
            data.car_r62 = string.IsNullOrEmpty(data.car_r62) ? string.Empty : data.car_r62;
            data.car_r63 = string.IsNullOrEmpty(data.car_r63) ? string.Empty : data.car_r63;
            data.car_r64 = string.IsNullOrEmpty(data.car_r64) ? string.Empty : data.car_r64;
            data.car_r65 = string.IsNullOrEmpty(data.car_r65) ? string.Empty : data.car_r65;
            data.car_r66 = string.IsNullOrEmpty(data.car_r66) ? string.Empty : data.car_r66;
            data.car_r67 = string.IsNullOrEmpty(data.car_r67) ? string.Empty : data.car_r67;
            data.car_r68 = string.IsNullOrEmpty(data.car_r68) ? string.Empty : data.car_r68;
            data.car_r69 = string.IsNullOrEmpty(data.car_r69) ? string.Empty : data.car_r69;
            data.car_r70 = string.IsNullOrEmpty(data.car_r70) ? string.Empty : data.car_r70;
            data.car_r71 = string.IsNullOrEmpty(data.car_r71) ? string.Empty : data.car_r71;
            data.car_r72 = string.IsNullOrEmpty(data.car_r72) ? string.Empty : data.car_r72;
            data.car_r73 = string.IsNullOrEmpty(data.car_r73) ? string.Empty : data.car_r73;
            data.car_r74 = string.IsNullOrEmpty(data.car_r74) ? string.Empty : data.car_r74;
            data.car_r75 = string.IsNullOrEmpty(data.car_r75) ? string.Empty : data.car_r75;
            DateTime? card1 = data.car_d1; // Assuming data.car_d1 is of type DateTime?            
            DateTime? card2 = data.car_d2; // Assuming data.car_d2 is of type DateTime?
            DateTime? card3 = data.car_d3; // Assuming data.car_d3 is of type DateTime?
            DateTime? card4 = data.car_d4; // Assuming data.car_d4 is of type DateTime?
            DateTime? card5 = data.car_d5; // Assuming data.car_d5 is of type DateTime?
            DateTime? card6 = data.car_d6; // Assuming data.car_d6 is of type DateTime?
            DateTime? card7 = data.car_d7; // Assuming data.car_d7 is of type DateTime?
            DateTime? card8 = data.car_d8; // Assuming data.car_d8 is of type DateTime?
            if (data.car_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d1 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d2 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d3 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d4 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d4 = card4.HasValue ? card4.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d4 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d5 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d5 = card5.HasValue ? card5.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d5 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d6 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d6 = card6.HasValue ? card6.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d6 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d7 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d7 = card7.HasValue ? card7.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d7 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d8 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d8 = card8.HasValue ? card8.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d8 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.Aetna.InsertUpdateAetna(data);
        }
        //Delete
        public static int DeleteAetna(int car_Id, int car_madeby)
        {
            return DataAccessLayer.EMRForms.Aetna.DeleteAetna(car_Id, car_madeby);
        }
        #endregion Aetna (CRUD Operations)
    }
    public class Amity
    {
        #region Amity (Page Load)
        public static List<BusinessEntities.EMRForms.Amity> GetAllAmity(int appId)
        {
            List<BusinessEntities.EMRForms.Amity> sclist = new List<BusinessEntities.EMRForms.Amity>();
            DataTable dt = DataAccessLayer.EMRForms.Amity.GetAllAmity(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Amity
                {
                    car_Id = Convert.ToInt32(dr["car_Id"]),
                    car_appId = Convert.ToInt32(dr["car_appId"]),
                    car_checkbox = dr["car_checkbox"].ToString(),
                    car_e1 = dr["car_e1"].ToString(),
                    car_e2 = dr["car_e2"].ToString(),
                    car_e3 = dr["car_e3"].ToString(),
                    car_e4 = dr["car_e4"].ToString(),
                    car_e5 = dr["car_e5"].ToString(),
                    car_e6 = dr["car_e6"].ToString(),
                    car_e7 = dr["car_e7"].ToString(),
                    car_e8 = dr["car_e8"].ToString(),
                    car_e9 = dr["car_e9"].ToString(),
                    car_e10 = dr["car_e10"].ToString(),
                    car_e11 = dr["car_e11"].ToString(),
                    car_e12 = dr["car_e12"].ToString(),
                    car_e13 = dr["car_e13"].ToString(),
                    car_d1 = Convert.ToDateTime(dr["car_d1"].ToString()),
                    car_d2 = Convert.ToDateTime(dr["car_d2"].ToString()),
                    car_date_created = Convert.ToDateTime(dr["car_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Amity> GetAllPreAmity(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Amity> sclist = new List<BusinessEntities.EMRForms.Amity>();
            DataTable dt = DataAccessLayer.EMRForms.Amity.GetAllPreAmity(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Amity
                {
                    car_Id = Convert.ToInt32(dr["car_Id"]),
                    car_appId = Convert.ToInt32(dr["car_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //Get Diagnosis
        //print
        public static List<BusinessEntities.EMRForms.Amity> GetPrintAmity(int? car_Id)
        {
            List<BusinessEntities.EMRForms.Amity> sclist = new List<BusinessEntities.EMRForms.Amity>();
            DataTable dt = DataAccessLayer.EMRForms.Amity.GetPrintAmity(car_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Amity
                    {
                        car_Id = Convert.ToInt32(dr["car_Id"]),
                        car_appId = Convert.ToInt32(dr["car_appId"]),
                        car_checkbox = dr["car_checkbox"].ToString(),
                        car_e1 = dr["car_e1"].ToString(),
                        car_e2 = dr["car_e2"].ToString(),
                        car_e3 = dr["car_e3"].ToString(),
                        car_e4 = dr["car_e4"].ToString(),
                        car_e5 = dr["car_e5"].ToString(),
                        car_e6 = dr["car_e6"].ToString(),
                        car_e7 = dr["car_e7"].ToString(),
                        car_e8 = dr["car_e8"].ToString(),
                        car_e9 = dr["car_e9"].ToString(),
                        car_e10 = dr["car_e10"].ToString(),
                        car_e11 = dr["car_e11"].ToString(),
                        car_e12 = dr["car_e12"].ToString(),
                        car_e13 = dr["car_e13"].ToString(),
                        car_dd1 = dr["car_d1"].ToString(),
                        car_dd2 = dr["car_d2"].ToString(),
                        car_date_created = Convert.ToDateTime(dr["car_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Amity a = new BusinessEntities.EMRForms.Amity();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Amity (Page Load)

        #region Amity (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAmity(BusinessEntities.EMRForms.Amity data)
        {
            data.car_checkbox = string.IsNullOrEmpty(data.car_checkbox) ? string.Empty : data.car_checkbox;
            data.car_e1 = string.IsNullOrEmpty(data.car_e1) ? string.Empty : data.car_e1;
            data.car_e2 = string.IsNullOrEmpty(data.car_e2) ? string.Empty : data.car_e2;
            data.car_e3 = string.IsNullOrEmpty(data.car_e3) ? string.Empty : data.car_e3;
            data.car_e4 = string.IsNullOrEmpty(data.car_e4) ? string.Empty : data.car_e4;
            data.car_e5 = string.IsNullOrEmpty(data.car_e5) ? string.Empty : data.car_e5;
            data.car_e6 = string.IsNullOrEmpty(data.car_e6) ? string.Empty : data.car_e6;
            data.car_e7 = string.IsNullOrEmpty(data.car_e7) ? string.Empty : data.car_e7;
            data.car_e8 = string.IsNullOrEmpty(data.car_e8) ? string.Empty : data.car_e8;
            data.car_e9 = string.IsNullOrEmpty(data.car_e9) ? string.Empty : data.car_e9;
            data.car_e10 = string.IsNullOrEmpty(data.car_e10) ? string.Empty : data.car_e10;
            data.car_e11 = string.IsNullOrEmpty(data.car_e11) ? string.Empty : data.car_e11;
            data.car_e12 = string.IsNullOrEmpty(data.car_e12) ? string.Empty : data.car_e12;
            data.car_e13 = string.IsNullOrEmpty(data.car_e13) ? string.Empty : data.car_e13;
            DateTime? card1 = data.car_d1; // Assuming data.car_d1 is of type DateTime?            
            DateTime? card2 = data.car_d2; // Assuming data.car_d2 is of type DateTime?            
            if (data.car_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d1 = DateTime.Parse("01/01/1950");
            }
            if (data.car_d2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.car_d2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.car_d2 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.Amity.InsertUpdateAmity(data);
        }
        //Delete
        public static int DeleteAmity(int car_Id, int car_madeby)
        {
            return DataAccessLayer.EMRForms.Amity.DeleteAmity(car_Id, car_madeby);
        }
        #endregion Amity (CRUD Operations)
    }
    public class Alico
    {
        #region Alico (Page Load)
        public static List<BusinessEntities.EMRForms.Alico> GetAllAlico(int appId)
        {
            List<BusinessEntities.EMRForms.Alico> sclist = new List<BusinessEntities.EMRForms.Alico>();
            DataTable dt = DataAccessLayer.EMRForms.Alico.GetAllAlico(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Alico
                {
                    aliId = Convert.ToInt32(dr["aliId"]),
                    ali_appId = Convert.ToInt32(dr["ali_appId"]),
                    ali_checkbox = dr["ali_checkbox"].ToString(),
                    ali_ins1 = dr["ali_ins1"].ToString(),
                    ali_ins2 = dr["ali_ins2"].ToString(),
                    ali_ins3 = dr["ali_ins3"].ToString(),
                    ali_ins4 = dr["ali_ins4"].ToString(),
                    ali_ins5 = dr["ali_ins5"].ToString(),
                    ali_ins6 = dr["ali_ins6"].ToString(),
                    ali_ins7 = dr["ali_ins7"].ToString(),
                    ali_ins8 = dr["ali_ins8"].ToString(),
                    ali_ins9 = dr["ali_ins9"].ToString(),
                    ali_ins10 = dr["ali_ins10"].ToString(),
                    ali_ins11 = dr["ali_ins11"].ToString(),
                    ali_ins12 = dr["ali_ins12"].ToString(),
                    ali_ins13 = dr["ali_ins13"].ToString(),
                    ali_ins14 = dr["ali_ins14"].ToString(),
                    ali_date_created = Convert.ToDateTime(dr["ali_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Alico> GetAllPreAlico(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Alico> sclist = new List<BusinessEntities.EMRForms.Alico>();
            DataTable dt = DataAccessLayer.EMRForms.Alico.GetAllPreAlico(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Alico
                {
                    aliId = Convert.ToInt32(dr["aliId"]),
                    ali_appId = Convert.ToInt32(dr["ali_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.Alico> GetPrintAlico(int? aliId)
        {
            List<BusinessEntities.EMRForms.Alico> sclist = new List<BusinessEntities.EMRForms.Alico>();
            DataTable dt = DataAccessLayer.EMRForms.Alico.GetPrintAlico(aliId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Alico
                    {
                        aliId = Convert.ToInt32(dr["aliId"]),
                        ali_appId = Convert.ToInt32(dr["ali_appId"]),
                        ali_checkbox = dr["ali_checkbox"].ToString(),
                        ali_ins1 = dr["ali_ins1"].ToString(),
                        ali_ins2 = dr["ali_ins2"].ToString(),
                        ali_ins3 = dr["ali_ins3"].ToString(),
                        ali_ins4 = dr["ali_ins4"].ToString(),
                        ali_ins5 = dr["ali_ins5"].ToString(),
                        ali_ins6 = dr["ali_ins6"].ToString(),
                        ali_ins7 = dr["ali_ins7"].ToString(),
                        ali_ins8 = dr["ali_ins8"].ToString(),
                        ali_ins9 = dr["ali_ins9"].ToString(),
                        ali_ins10 = dr["ali_ins10"].ToString(),
                        ali_ins11 = dr["ali_ins11"].ToString(),
                        ali_ins12 = dr["ali_ins12"].ToString(),
                        ali_ins13 = dr["ali_ins13"].ToString(),
                        ali_ins14 = dr["ali_ins14"].ToString(),
                        ali_date_created = Convert.ToDateTime(dr["ali_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Alico a = new BusinessEntities.EMRForms.Alico();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Alico (Page Load)

        #region Alico (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAlico(BusinessEntities.EMRForms.Alico data)
        {
            data.ali_checkbox = string.IsNullOrEmpty(data.ali_checkbox) ? string.Empty : data.ali_checkbox;
            data.ali_ins1 = string.IsNullOrEmpty(data.ali_ins1) ? string.Empty : data.ali_ins1;
            data.ali_ins2 = string.IsNullOrEmpty(data.ali_ins2) ? string.Empty : data.ali_ins2;
            data.ali_ins3 = string.IsNullOrEmpty(data.ali_ins3) ? string.Empty : data.ali_ins3;
            data.ali_ins4 = string.IsNullOrEmpty(data.ali_ins4) ? string.Empty : data.ali_ins4;
            data.ali_ins5 = string.IsNullOrEmpty(data.ali_ins5) ? string.Empty : data.ali_ins5;
            data.ali_ins6 = string.IsNullOrEmpty(data.ali_ins6) ? string.Empty : data.ali_ins6;
            data.ali_ins7 = string.IsNullOrEmpty(data.ali_ins7) ? string.Empty : data.ali_ins7;
            data.ali_ins8 = string.IsNullOrEmpty(data.ali_ins8) ? string.Empty : data.ali_ins8;
            data.ali_ins9 = string.IsNullOrEmpty(data.ali_ins9) ? string.Empty : data.ali_ins9;
            data.ali_ins10 = string.IsNullOrEmpty(data.ali_ins10) ? string.Empty : data.ali_ins10;
            data.ali_ins11 = string.IsNullOrEmpty(data.ali_ins11) ? string.Empty : data.ali_ins11;
            data.ali_ins12 = string.IsNullOrEmpty(data.ali_ins12) ? string.Empty : data.ali_ins12;
            data.ali_ins13 = string.IsNullOrEmpty(data.ali_ins13) ? string.Empty : data.ali_ins13;
            data.ali_ins14 = string.IsNullOrEmpty(data.ali_ins14) ? string.Empty : data.ali_ins14;
            return DataAccessLayer.EMRForms.Alico.InsertUpdateAlico(data);
        }
        //Delete
        public static int DeleteAlico(int aliId, int ali_madeby)
        {
            return DataAccessLayer.EMRForms.Alico.DeleteAlico(aliId, ali_madeby);
        }
        #endregion Alico (CRUD Operations)
    }
    public class Allianz
    {
        #region Allianz (Page Load)
        public static List<BusinessEntities.EMRForms.Allianz> GetAllAllianz(int appId)
        {
            List<BusinessEntities.EMRForms.Allianz> sclist = new List<BusinessEntities.EMRForms.Allianz>();
            DataTable dt = DataAccessLayer.EMRForms.Allianz.GetAllAllianz(appId);
            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Allianz
                {
                    allId = Convert.ToInt32(dr["allId"]),
                    all_appId = Convert.ToInt32(dr["all_appId"]),
                    all_1 = dr["all_1"].ToString(),
                    all_2 = dr["all_2"].ToString(),
                    all_3 = dr["all_3"].ToString(),
                    all_4 = dr["all_4"].ToString(),
                    all_5 = dr["all_5"].ToString(),
                    all_6 = dr["all_6"].ToString(),
                    all_7 = dr["all_7"].ToString(),
                    all_8 = dr["all_8"].ToString(),
                    all_9 = dr["all_9"].ToString(),
                    all_10 = dr["all_10"].ToString(),
                    all_11 = dr["all_11"].ToString(),
                    all_12 = dr["all_12"].ToString(),
                    all_13 = Convert.ToDateTime(dr["all_13"].ToString()),
                    all_14 = Convert.ToDateTime(dr["all_14"].ToString()),
                    all_15 = Convert.ToDateTime(dr["all_15"].ToString()),
                    all_date_created = Convert.ToDateTime(dr["all_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Allianz> GetAllPreAllianz(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Allianz> sclist = new List<BusinessEntities.EMRForms.Allianz>();
            DataTable dt = DataAccessLayer.EMRForms.Allianz.GetAllPreAllianz(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Allianz
                {
                    allId = Convert.ToInt32(dr["allId"]),
                    all_appId = Convert.ToInt32(dr["all_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.Allianz> GetPrintAllianz(int? allId)
        {
            List<BusinessEntities.EMRForms.Allianz> sclist = new List<BusinessEntities.EMRForms.Allianz>();
            DataTable dt = DataAccessLayer.EMRForms.Allianz.GetPrintAllianz(allId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Allianz
                    {
                        allId = Convert.ToInt32(dr["allId"]),
                        all_appId = Convert.ToInt32(dr["all_appId"]),
                        all_1 = dr["all_1"].ToString(),
                        all_2 = dr["all_2"].ToString(),
                        all_3 = dr["all_3"].ToString(),
                        all_4 = dr["all_4"].ToString(),
                        all_5 = dr["all_5"].ToString(),
                        all_6 = dr["all_6"].ToString(),
                        all_7 = dr["all_7"].ToString(),
                        all_8 = dr["all_8"].ToString(),
                        all_9 = dr["all_9"].ToString(),
                        all_10 = dr["all_10"].ToString(),
                        all_11 = dr["all_11"].ToString(),
                        all_12 = dr["all_12"].ToString(),
                        all_13 = Convert.ToDateTime(dr["all_13"].ToString()),
                        all_14 = Convert.ToDateTime(dr["all_14"].ToString()),
                        all_15 = Convert.ToDateTime(dr["all_15"].ToString()),
                        all_date_created = Convert.ToDateTime(dr["all_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Allianz a = new BusinessEntities.EMRForms.Allianz();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Allianz (Page Load)

        #region Allianz (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAllianz(BusinessEntities.EMRForms.Allianz data)
        {
            data.all_1 = string.IsNullOrEmpty(data.all_1) ? string.Empty : data.all_1;
            data.all_2 = string.IsNullOrEmpty(data.all_2) ? string.Empty : data.all_2;
            data.all_3 = string.IsNullOrEmpty(data.all_3) ? string.Empty : data.all_3;
            data.all_4 = string.IsNullOrEmpty(data.all_4) ? string.Empty : data.all_4;
            data.all_5 = string.IsNullOrEmpty(data.all_5) ? string.Empty : data.all_5;
            data.all_6 = string.IsNullOrEmpty(data.all_6) ? string.Empty : data.all_6;
            data.all_7 = string.IsNullOrEmpty(data.all_7) ? string.Empty : data.all_7;
            data.all_8 = string.IsNullOrEmpty(data.all_8) ? string.Empty : data.all_8;
            data.all_9 = string.IsNullOrEmpty(data.all_9) ? string.Empty : data.all_9;
            data.all_10 = string.IsNullOrEmpty(data.all_10) ? string.Empty : data.all_10;
            data.all_11 = string.IsNullOrEmpty(data.all_11) ? string.Empty : data.all_11;
            data.all_12 = string.IsNullOrEmpty(data.all_12) ? string.Empty : data.all_12;
            DateTime? all13 = data.all_13; // Assuming data.all_13 is of type DateTime?            
            DateTime? all14 = data.all_14; // Assuming data.all_14 is of type DateTime?
            DateTime? all15 = data.all_15; // Assuming data.all_15 is of type DateTime?

            if (data.all_13 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.all_13 = all13.HasValue ? all13.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.all_13 = DateTime.Parse("01/01/1950");
            }
            if (data.all_14 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.all_14 = all14.HasValue ? all14.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.all_14 = DateTime.Parse("01/01/1950");
            }
            if (data.all_15 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.all_15 = all15.HasValue ? all15.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.all_15 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.Allianz.InsertUpdateAllianz(data);
        }
        //Delete
        public static int DeleteAllianz(int allId, int all_madeby)
        {
            return DataAccessLayer.EMRForms.Allianz.DeleteAllianz(allId, all_madeby);
        }
        #endregion Allianz (CRUD Operations)
    }
    public class Axa
    {
        #region Axa (Page Load)
        public static List<BusinessEntities.EMRForms.Axa> GetAllAxa(int appId)
        {
            List<BusinessEntities.EMRForms.Axa> sclist = new List<BusinessEntities.EMRForms.Axa>();
            DataTable dt = DataAccessLayer.EMRForms.Axa.GetAllAxa(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Axa
                {
                    carfId = Convert.ToInt32(dr["carfId"]),
                    carf_appId = Convert.ToInt32(dr["carf_appId"]),
                    carf_1 = dr["carf_1"].ToString(),
                    carf_2 = dr["carf_2"].ToString(),
                    carf_3 = dr["carf_3"].ToString(),
                    carf_4 = dr["carf_4"].ToString(),
                    carf_5 = dr["carf_5"].ToString(),
                    carf_6 = dr["carf_6"].ToString(),
                    carf_7 = dr["carf_7"].ToString(),
                    carf_8 = dr["carf_8"].ToString(),
                    carf_9 = dr["carf_9"].ToString(),
                    carf_10 = dr["carf_10"].ToString(),
                    carf_11 = dr["carf_11"].ToString(),
                    carf_12 = dr["carf_12"].ToString(),
                    carf_13 = dr["carf_13"].ToString(),
                    carf_14 = dr["carf_14"].ToString(),
                    carf_15 = dr["carf_15"].ToString(),
                    carf_16 = dr["carf_16"].ToString(),
                    carf_17 = dr["carf_17"].ToString(),
                    carf_18 = dr["carf_18"].ToString(),
                    carf_19 = dr["carf_19"].ToString(),
                    carf_20 = dr["carf_20"].ToString(),
                    carf_21 = Convert.ToDateTime(dr["carf_21"].ToString()),
                    carf_22 = Convert.ToDateTime(dr["carf_22"].ToString()),
                    carf_23 = Convert.ToDateTime(dr["carf_23"].ToString()),
                    carf_24 = Convert.ToDateTime(dr["carf_24"].ToString()),
                    carf_25 = Convert.ToDateTime(dr["carf_25"].ToString()),
                    carf_26 = Convert.ToDateTime(dr["carf_26"].ToString()),
                    carf_date_created = Convert.ToDateTime(dr["carf_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Axa> GetAllPreAxa(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Axa> sclist = new List<BusinessEntities.EMRForms.Axa>();
            DataTable dt = DataAccessLayer.EMRForms.Axa.GetAllPreAxa(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Axa
                {
                    carfId = Convert.ToInt32(dr["carfId"]),
                    carf_appId = Convert.ToInt32(dr["carf_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //Diagnosis
        public static List<BusinessEntities.EMRForms.Axa> GetAllPatientDiagnosis(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Axa> sclist = new List<BusinessEntities.EMRForms.Axa>();
            DataTable dt = DataAccessLayer.EMRForms.Axa.GetAllPatientDiagnosis(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Axa
                {
                    Diagnosis = dr["Diagnosis"].ToString(),

                });
            }
            return sclist;
        }
        //Drugs
        public static List<BusinessEntities.EMRForms.Axa> GetAllPatientDrugs(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Axa> sclist = new List<BusinessEntities.EMRForms.Axa>();
            DataTable dt = DataAccessLayer.EMRForms.Axa.GetAllPatientDrugs(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Axa
                {
                    Prescriptions = dr["Prescriptions"].ToString(),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Axa> GetPrintAxa(int? carfId)
        {
            List<BusinessEntities.EMRForms.Axa> sclist = new List<BusinessEntities.EMRForms.Axa>();
            DataTable dt = DataAccessLayer.EMRForms.Axa.GetPrintAxa(carfId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Axa
                    {
                        carfId = Convert.ToInt32(dr["carfId"]),
                        carf_appId = Convert.ToInt32(dr["carf_appId"]),
                        carf_1 = dr["carf_1"].ToString(),
                        carf_2 = dr["carf_2"].ToString(),
                        carf_3 = dr["carf_3"].ToString(),
                        carf_4 = dr["carf_4"].ToString(),
                        carf_5 = dr["carf_5"].ToString(),
                        carf_6 = dr["carf_6"].ToString(),
                        carf_7 = dr["carf_7"].ToString(),
                        carf_8 = dr["carf_8"].ToString(),
                        carf_9 = dr["carf_9"].ToString(),
                        carf_10 = dr["carf_10"].ToString(),
                        carf_11 = dr["carf_11"].ToString(),
                        carf_12 = dr["carf_12"].ToString(),
                        carf_13 = dr["carf_13"].ToString(),
                        carf_14 = dr["carf_14"].ToString(),
                        carf_15 = dr["carf_15"].ToString(),
                        carf_16 = dr["carf_16"].ToString(),
                        carf_17 = dr["carf_17"].ToString(),
                        carf_18 = dr["carf_18"].ToString(),
                        carf_19 = dr["carf_19"].ToString(),
                        carf_20 = dr["carf_20"].ToString(),

                        carf_d21 = (dt.Rows[0]["carf_21"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["carf_21"].ToString(),
                        carf_d22 = (dt.Rows[0]["carf_22"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["carf_22"].ToString(),
                        carf_d23 = (dt.Rows[0]["carf_23"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["carf_23"].ToString(),
                        carf_d24 = (dt.Rows[0]["carf_24"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["carf_24"].ToString(),
                        carf_d25 = (dt.Rows[0]["carf_25"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["carf_25"].ToString(),
                        carf_d26 = (dt.Rows[0]["carf_26"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["carf_26"].ToString(),
                        carf_date_created = Convert.ToDateTime(dr["carf_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Axa a = new BusinessEntities.EMRForms.Axa();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Axa (Page Load)

        #region Axa (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAxa(BusinessEntities.EMRForms.Axa data)
        {
            data.carf_1 = string.IsNullOrEmpty(data.carf_1) ? string.Empty : data.carf_1;
            data.carf_2 = string.IsNullOrEmpty(data.carf_2) ? string.Empty : data.carf_2;
            data.carf_3 = string.IsNullOrEmpty(data.carf_3) ? string.Empty : data.carf_3;
            data.carf_4 = string.IsNullOrEmpty(data.carf_4) ? string.Empty : data.carf_4;
            data.carf_5 = string.IsNullOrEmpty(data.carf_5) ? string.Empty : data.carf_5;
            data.carf_6 = string.IsNullOrEmpty(data.carf_6) ? string.Empty : data.carf_6;
            data.carf_7 = string.IsNullOrEmpty(data.carf_7) ? string.Empty : data.carf_7;
            data.carf_8 = string.IsNullOrEmpty(data.carf_8) ? string.Empty : data.carf_8;
            data.carf_9 = string.IsNullOrEmpty(data.carf_9) ? string.Empty : data.carf_9;
            data.carf_10 = string.IsNullOrEmpty(data.carf_10) ? string.Empty : data.carf_10;
            data.carf_11 = string.IsNullOrEmpty(data.carf_11) ? string.Empty : data.carf_11;
            data.carf_12 = string.IsNullOrEmpty(data.carf_12) ? string.Empty : data.carf_12;
            data.carf_13 = string.IsNullOrEmpty(data.carf_13) ? string.Empty : data.carf_13;
            data.carf_14 = string.IsNullOrEmpty(data.carf_14) ? string.Empty : data.carf_14;
            data.carf_15 = string.IsNullOrEmpty(data.carf_15) ? string.Empty : data.carf_15;
            data.carf_16 = string.IsNullOrEmpty(data.carf_16) ? string.Empty : data.carf_16;
            data.carf_17 = string.IsNullOrEmpty(data.carf_17) ? string.Empty : data.carf_17;
            data.carf_18 = string.IsNullOrEmpty(data.carf_18) ? string.Empty : data.carf_18;
            data.carf_19 = string.IsNullOrEmpty(data.carf_19) ? string.Empty : data.carf_19;
            data.carf_20 = string.IsNullOrEmpty(data.carf_20) ? string.Empty : data.carf_20;
            DateTime? card21 = data.carf_21; // Assuming data.carf_d1 is of type DateTime?            
            DateTime? card22 = data.carf_22; // Assuming data.carf_d2 is of type DateTime?
            DateTime? card23 = data.carf_23; // Assuming data.carf_d3 is of type DateTime?
            DateTime? card24 = data.carf_24; // Assuming data.carf_d4 is of type DateTime?
            DateTime? card25 = data.carf_25; // Assuming data.carf_d5 is of type DateTime?
            DateTime? card26 = data.carf_26; // Assuming data.carf_d6 is of type DateTime?
            if (data.carf_21 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.carf_21 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.carf_21 = DateTime.Parse("01/01/1950");
            }
            if (data.carf_22 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.carf_22 = card22.HasValue ? card22.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.carf_22 = DateTime.Parse("01/01/1950");
            }
            if (data.carf_23 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.carf_23 = card23.HasValue ? card23.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.carf_23 = DateTime.Parse("01/01/1950");
            }
            if (data.carf_24 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.carf_24 = card24.HasValue ? card24.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.carf_24 = DateTime.Parse("01/01/1950");
            }
            if (data.carf_25 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.carf_25 = card25.HasValue ? card25.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.carf_25 = DateTime.Parse("01/01/1950");
            }
            if (data.carf_26 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.carf_26 = card26.HasValue ? card26.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.carf_26 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.Axa.InsertUpdateAxa(data);
        }
        //Delete
        public static int DeleteAxa(int carfId, int carf_madeby)
        {
            return DataAccessLayer.EMRForms.Axa.DeleteAxa(carfId, carf_madeby);
        }
        #endregion Axa (CRUD Operations)
    }
    public class MSH
    {
        #region MSH (Page Load)
        public static List<BusinessEntities.EMRForms.MSH> GetAllMSH(int appId)
        {
            List<BusinessEntities.EMRForms.MSH> sclist = new List<BusinessEntities.EMRForms.MSH>();
            DataTable dt = DataAccessLayer.EMRForms.MSH.GetAllMSH(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.MSH
                {
                    cmr_Id = Convert.ToInt32(dr["cmr_Id"]),
                    cmr_appId = Convert.ToInt32(dr["cmr_appId"]),
                    cmr_checkbox = dr["cmr_checkbox"].ToString(),
                    cmr_groupname = dr["cmr_groupname"].ToString(),
                    cmr_health = dr["cmr_health"].ToString(),
                    cmr_dental = dr["cmr_dental"].ToString(),
                    cmr_amount = dr["cmr_amount"].ToString(),
                    cmr_total = dr["cmr_total"].ToString(),
                    cmr_date_created = Convert.ToDateTime(dr["cmr_date_created"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.MSH> GetAllPreMSH(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.MSH> sclist = new List<BusinessEntities.EMRForms.MSH>();
            DataTable dt = DataAccessLayer.EMRForms.MSH.GetAllPreMSH(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.MSH
                {
                    cmr_Id = Convert.ToInt32(dr["cmr_Id"]),
                    cmr_appId = Convert.ToInt32(dr["cmr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.MSH> GetPrintMSH(int? cmr_Id)
        {
            List<BusinessEntities.EMRForms.MSH> sclist = new List<BusinessEntities.EMRForms.MSH>();
            DataTable dt = DataAccessLayer.EMRForms.MSH.GetPrintMSH(cmr_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.MSH
                    {
                        cmr_Id = Convert.ToInt32(dr["cmr_Id"]),
                        cmr_appId = Convert.ToInt32(dr["cmr_appId"]),
                        cmr_checkbox = dr["cmr_checkbox"].ToString(),
                        cmr_groupname = dr["cmr_groupname"].ToString(),
                        cmr_health = dr["cmr_health"].ToString(),
                        cmr_dental = dr["cmr_dental"].ToString(),
                        cmr_amount = dr["cmr_amount"].ToString(),
                        cmr_total = dr["cmr_total"].ToString(),
                        cmr_date_created = Convert.ToDateTime(dr["cmr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.MSH a = new BusinessEntities.EMRForms.MSH();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion MSH (Page Load)

        #region MSH (CRUD Operations)
        //insert&update
        public static bool InsertUpdateMSH(BusinessEntities.EMRForms.MSH data)
        {
            data.cmr_checkbox = string.IsNullOrEmpty(data.cmr_checkbox) ? string.Empty : data.cmr_checkbox;
            data.cmr_groupname = string.IsNullOrEmpty(data.cmr_groupname) ? string.Empty : data.cmr_groupname;
            data.cmr_health = string.IsNullOrEmpty(data.cmr_health) ? string.Empty : data.cmr_health;
            data.cmr_dental = string.IsNullOrEmpty(data.cmr_dental) ? string.Empty : data.cmr_dental;
            data.cmr_amount = string.IsNullOrEmpty(data.cmr_amount) ? string.Empty : data.cmr_amount;
            data.cmr_total = string.IsNullOrEmpty(data.cmr_total) ? string.Empty : data.cmr_total;
            return DataAccessLayer.EMRForms.MSH.InsertUpdateMSH(data);
        }
        //Delete
        public static int DeleteMSH(int cmr_Id, int cmr_madeby)
        {
            return DataAccessLayer.EMRForms.MSH.DeleteMSH(cmr_Id, cmr_madeby);
        }
        #endregion MSH (CRUD Operations)
    }
    public class Dubaicare
    {
        #region Dubaicare (Page Load)
        public static List<BusinessEntities.EMRForms.Dubaicare> GetAllDubaicare(int appId)
        {
            List<BusinessEntities.EMRForms.Dubaicare> sclist = new List<BusinessEntities.EMRForms.Dubaicare>();
            DataTable dt = DataAccessLayer.EMRForms.Dubaicare.GetAllDubaicare(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Dubaicare
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    cdr_name = dr["cdr_name"].ToString(),
                    cdr_address = dr["cdr_address"].ToString(),
                    cdr_account = dr["cdr_account"].ToString(),
                    cdr_iban = dr["cdr_iban"].ToString(),
                    cdr_scode = dr["cdr_scode"].ToString(),
                    cdr_bank = dr["cdr_bank"].ToString(),
                    cdr_branch = dr["cdr_branch"].ToString(),
                    cdr_phy_find = dr["cdr_phy_find"].ToString(),
                    cdr_invest = dr["cdr_invest"].ToString(),
                    cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Dubaicare> GetAllPreDubaicare(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Dubaicare> sclist = new List<BusinessEntities.EMRForms.Dubaicare>();
            DataTable dt = DataAccessLayer.EMRForms.Dubaicare.GetAllPreDubaicare(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Dubaicare
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Dubaicare> GetPrintDubaicare(int? cdr_Id)
        {
            List<BusinessEntities.EMRForms.Dubaicare> sclist = new List<BusinessEntities.EMRForms.Dubaicare>();
            DataTable dt = DataAccessLayer.EMRForms.Dubaicare.GetPrintDubaicare(cdr_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Dubaicare
                    {
                        cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                        cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                        cdr_name = dr["cdr_name"].ToString(),
                        cdr_address = dr["cdr_address"].ToString(),
                        cdr_account = dr["cdr_account"].ToString(),
                        cdr_iban = dr["cdr_iban"].ToString(),
                        cdr_scode = dr["cdr_scode"].ToString(),
                        cdr_bank = dr["cdr_bank"].ToString(),
                        cdr_branch = dr["cdr_branch"].ToString(),
                        cdr_phy_find = dr["cdr_phy_find"].ToString(),
                        cdr_invest = dr["cdr_invest"].ToString(),
                        cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Dubaicare a = new BusinessEntities.EMRForms.Dubaicare();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Dubaicare (Page Load)

        #region Dubaicare (CRUD Operations)
        //insert&update
        public static bool InsertUpdateDubaicare(BusinessEntities.EMRForms.Dubaicare data)
        {
            data.cdr_name = string.IsNullOrEmpty(data.cdr_name) ? string.Empty : data.cdr_name;
            data.cdr_address = string.IsNullOrEmpty(data.cdr_address) ? string.Empty : data.cdr_address;
            data.cdr_account = string.IsNullOrEmpty(data.cdr_account) ? string.Empty : data.cdr_account;
            data.cdr_iban = string.IsNullOrEmpty(data.cdr_iban) ? string.Empty : data.cdr_iban;
            data.cdr_scode = string.IsNullOrEmpty(data.cdr_scode) ? string.Empty : data.cdr_scode;
            data.cdr_bank = string.IsNullOrEmpty(data.cdr_bank) ? string.Empty : data.cdr_bank;
            data.cdr_branch = string.IsNullOrEmpty(data.cdr_branch) ? string.Empty : data.cdr_branch;
            data.cdr_phy_find = string.IsNullOrEmpty(data.cdr_phy_find) ? string.Empty : data.cdr_phy_find;
            data.cdr_invest = string.IsNullOrEmpty(data.cdr_invest) ? string.Empty : data.cdr_invest;
            return DataAccessLayer.EMRForms.Dubaicare.InsertUpdateDubaicare(data);
        }
        //Delete
        public static int DeleteDubaicare(int cdr_Id, int cdr_madeby)
        {
            return DataAccessLayer.EMRForms.Dubaicare.DeleteDubaicare(cdr_Id, cdr_madeby);
        }
        #endregion Dubaicare (CRUD Operations)
    }
    public class Emirates
    {
        #region Emirates (Page Load)
        public static List<BusinessEntities.EMRForms.Emirates> GetAllEmirates(int appId)
        {
            List<BusinessEntities.EMRForms.Emirates> sclist = new List<BusinessEntities.EMRForms.Emirates>();
            DataTable dt = DataAccessLayer.EMRForms.Emirates.GetAllEmirates(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Emirates
                {
                    cer_Id = Convert.ToInt32(dr["cer_Id"]),
                    cer_appId = Convert.ToInt32(dr["cer_appId"]),
                    cer_checkbox = dr["cer_checkbox"].ToString(),
                    cer_processor = dr["cer_processor"].ToString(),
                    cer_payable = dr["cer_payable"].ToString(),
                    cer_nonpayable = dr["cer_nonpayable"].ToString(),
                    cer_date_created = Convert.ToDateTime(dr["cer_date_created"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Emirates> GetAllPreEmirates(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Emirates> sclist = new List<BusinessEntities.EMRForms.Emirates>();
            DataTable dt = DataAccessLayer.EMRForms.Emirates.GetAllPreEmirates(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Emirates
                {
                    cer_Id = Convert.ToInt32(dr["cer_Id"]),
                    cer_appId = Convert.ToInt32(dr["cer_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Emirates> GetPrintEmirates(int? cer_Id)
        {
            List<BusinessEntities.EMRForms.Emirates> sclist = new List<BusinessEntities.EMRForms.Emirates>();
            DataTable dt = DataAccessLayer.EMRForms.Emirates.GetPrintEmirates(cer_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Emirates
                    {
                        cer_Id = Convert.ToInt32(dr["cer_Id"]),
                        cer_appId = Convert.ToInt32(dr["cer_appId"]),
                        cer_checkbox = dr["cer_checkbox"].ToString(),
                        cer_processor = dr["cer_processor"].ToString(),
                        cer_payable = dr["cer_payable"].ToString(),
                        cer_nonpayable = dr["cer_nonpayable"].ToString(),
                        cer_date_created = Convert.ToDateTime(dr["cer_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Emirates a = new BusinessEntities.EMRForms.Emirates();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Emirates (Page Load)

        #region Emirates (CRUD Operations)
        //insert&update
        public static bool InsertUpdateEmirates(BusinessEntities.EMRForms.Emirates data)
        {
            data.cer_checkbox = string.IsNullOrEmpty(data.cer_checkbox) ? string.Empty : data.cer_checkbox;
            data.cer_processor = string.IsNullOrEmpty(data.cer_processor) ? string.Empty : data.cer_processor;
            data.cer_payable = string.IsNullOrEmpty(data.cer_payable) ? string.Empty : data.cer_payable;
            data.cer_nonpayable = string.IsNullOrEmpty(data.cer_nonpayable) ? string.Empty : data.cer_nonpayable;
            return DataAccessLayer.EMRForms.Emirates.InsertUpdateEmirates(data);
        }
        //Delete
        public static int DeleteEmirates(int cer_Id, int cer_madeby)
        {
            return DataAccessLayer.EMRForms.Emirates.DeleteEmirates(cer_Id, cer_madeby);
        }
        #endregion Emirates (CRUD Operations)
    }
    public class FMC
    {
        #region FMC (Page Load)
        public static List<BusinessEntities.EMRForms.FMC> GetAllFMC(int appId)
        {
            List<BusinessEntities.EMRForms.FMC> sclist = new List<BusinessEntities.EMRForms.FMC>();
            DataTable dt = DataAccessLayer.EMRForms.FMC.GetAllFMC(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.FMC
                {
                    fcId = Convert.ToInt32(dr["fcId"]),
                    fc_appId = Convert.ToInt32(dr["fc_appId"]),
                    fc_symptoms_date = Convert.ToDateTime(dr["fc_symptoms_date"].ToString()),
                    fc_visit = dr["fc_visit"].ToString(),
                    fc_diag = dr["fc_diag"].ToString(),
                    fc_date_created = Convert.ToDateTime(dr["fc_date_created"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.FMC> GetAllPreFMC(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.FMC> sclist = new List<BusinessEntities.EMRForms.FMC>();
            DataTable dt = DataAccessLayer.EMRForms.FMC.GetAllPreFMC(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.FMC
                {
                    fcId = Convert.ToInt32(dr["fcId"]),
                    fc_appId = Convert.ToInt32(dr["fc_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.FMC> GetPrintFMC(int? fcId)
        {
            List<BusinessEntities.EMRForms.FMC> sclist = new List<BusinessEntities.EMRForms.FMC>();
            DataTable dt = DataAccessLayer.EMRForms.FMC.GetPrintFMC(fcId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.FMC
                    {
                        fcId = Convert.ToInt32(dr["fcId"]),
                        fc_appId = Convert.ToInt32(dr["fc_appId"]),
                        fc_date = dr["fc_symptoms_date"].ToString(),
                        fc_visit = dr["fc_visit"].ToString(),
                        fc_diag = dr["fc_diag"].ToString(),
                        fc_date_created = Convert.ToDateTime(dr["fc_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.FMC a = new BusinessEntities.EMRForms.FMC();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion FMC (Page Load)

        #region FMC (CRUD Operations)
        //insert&update
        public static bool InsertUpdateFMC(BusinessEntities.EMRForms.FMC data)
        {
            DateTime? fcd1 = data.fc_symptoms_date; // Assuming data.fc_symptoms_date is of type DateTime?
            if (data.fc_symptoms_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.fc_symptoms_date = fcd1.HasValue ? fcd1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.fc_symptoms_date = DateTime.Parse("01/01/1950");
            }
            data.fc_visit = string.IsNullOrEmpty(data.fc_visit) ? string.Empty : data.fc_visit;
            data.fc_diag = string.IsNullOrEmpty(data.fc_diag) ? string.Empty : data.fc_diag;
            return DataAccessLayer.EMRForms.FMC.InsertUpdateFMC(data);
        }
        //Delete
        public static int DeleteFMC(int fcId, int fc_madeby)
        {
            return DataAccessLayer.EMRForms.FMC.DeleteFMC(fcId, fc_madeby);
        }
        #endregion FMC (CRUD Operations)
    }
    public class Neuron
    {
        #region Neuron (Page Load)
        public static List<BusinessEntities.EMRForms.Neuron> GetAllNeuron(int appId)
        {
            List<BusinessEntities.EMRForms.Neuron> sclist = new List<BusinessEntities.EMRForms.Neuron>();
            DataTable dt = DataAccessLayer.EMRForms.Neuron.GetAllNeuron(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Neuron
                {
                    nrId = Convert.ToInt32(dr["nrId"]),
                    nr_appId = Convert.ToInt32(dr["nr_appId"]),
                    nr_his = dr["nr_his"].ToString(),
                    nr_1= dr["nr_1"].ToString(),
                    nr_2= dr["nr_2"].ToString(),
                    nr_date1 = Convert.ToDateTime(dr["nr_date1"].ToString()),
                    nr_date2 = Convert.ToDateTime(dr["nr_date2"].ToString()),
                    nr_date_created = Convert.ToDateTime(dr["nr_date_created"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Neuron> GetAllPreNeuron(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Neuron> sclist = new List<BusinessEntities.EMRForms.Neuron>();
            DataTable dt = DataAccessLayer.EMRForms.Neuron.GetAllPreNeuron(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Neuron
                {
                    nrId = Convert.ToInt32(dr["nrId"]),
                    nr_appId = Convert.ToInt32(dr["nr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Neuron> GetPrintNeuron(int? nrId)
        {
            List<BusinessEntities.EMRForms.Neuron> sclist = new List<BusinessEntities.EMRForms.Neuron>();
            DataTable dt = DataAccessLayer.EMRForms.Neuron.GetPrintNeuron(nrId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Neuron
                    {
                        nrId = Convert.ToInt32(dr["nrId"]),
                        nr_appId = Convert.ToInt32(dr["nr_appId"]),
                        nr_his = dr["nr_his"].ToString(),
                        nr_1 = dr["nr_1"].ToString(),
                        nr_2 = dr["nr_2"].ToString(),
                        nr_d1 = dr["nr_date1"].ToString(),
                        nr_d2 = dr["nr_date2"].ToString(),
                        nr_date_created = Convert.ToDateTime(dr["nr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Neuron a = new BusinessEntities.EMRForms.Neuron();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Neuron (Page Load)

        #region Neuron (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNeuron(BusinessEntities.EMRForms.Neuron data)
        {            
            data.nr_his = string.IsNullOrEmpty(data.nr_his) ? string.Empty : data.nr_his;
            data.nr_1 = string.IsNullOrEmpty(data.nr_1) ? string.Empty : data.nr_1;
            data.nr_2 = string.IsNullOrEmpty(data.nr_2) ? string.Empty : data.nr_2;

            DateTime? nrd1 = data.nr_date1; // Assuming data.nr_symptoms_date is of type DateTime?
            if (data.nr_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.nr_date1 = nrd1.HasValue ? nrd1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.nr_date1 = DateTime.Parse("01/01/1950");
            }

            DateTime? nrd2 = data.nr_date2; // Assuming data.nr_symptoms_date is of type DateTime?
            if (data.nr_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.nr_date2= nrd2.HasValue ? nrd2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.nr_date2 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.Neuron.InsertUpdateNeuron(data);
        }
        //Delete
        public static int DeleteNeuron(int nrId, int nr_madeby)
        {
            return DataAccessLayer.EMRForms.Neuron.DeleteNeuron(nrId, nr_madeby);
        }
        #endregion Neuron (CRUD Operations)
    }
    public class Starwell
    {
        #region Starwell (Page Load)
        public static List<BusinessEntities.EMRForms.Starwell> GetAllStarwell(int appId)
        {
            List<BusinessEntities.EMRForms.Starwell> sclist = new List<BusinessEntities.EMRForms.Starwell>();
            DataTable dt = DataAccessLayer.EMRForms.Starwell.GetAllStarwell(appId);
            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Starwell
                {
                    swId = Convert.ToInt32(dr["swId"]),
                    sw_appId = Convert.ToInt32(dr["sw_appId"]),
                    sw_type = dr["sw_type"].ToString(),
                    sw_pappr = dr["sw_pappr"].ToString(),
                    sw_pamount = Convert.ToDecimal(dr["sw_pamount"].ToString()),
                    sw_comments = dr["sw_comments"].ToString(),                    
                    sw_pdate = Convert.ToDateTime(dr["sw_pdate"].ToString()),
                    sw_date_created = Convert.ToDateTime(dr["sw_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Starwell> GetAllPreStarwell(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Starwell> sclist = new List<BusinessEntities.EMRForms.Starwell>();
            DataTable dt = DataAccessLayer.EMRForms.Starwell.GetAllPreStarwell(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Starwell
                {
                    swId = Convert.ToInt32(dr["swId"]),
                    sw_appId = Convert.ToInt32(dr["sw_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.Starwell> GetPrintStarwell(int? swId)
        {
            List<BusinessEntities.EMRForms.Starwell> sclist = new List<BusinessEntities.EMRForms.Starwell>();
            DataTable dt = DataAccessLayer.EMRForms.Starwell.GetPrintStarwell(swId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Starwell
                    {
                        swId = Convert.ToInt32(dr["swId"]),
                        sw_appId = Convert.ToInt32(dr["sw_appId"]),
                        sw_type = dr["sw_type"].ToString(),
                        sw_pappr = dr["sw_pappr"].ToString(),
                        sw_pamount = Convert.ToDecimal(dr["sw_pamount"].ToString()),
                        sw_comments = dr["sw_comments"].ToString(),                       
                        sw_pdate = Convert.ToDateTime(dr["sw_pdate"].ToString()),
                        sw_date_created = Convert.ToDateTime(dr["sw_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Starwell a = new BusinessEntities.EMRForms.Starwell();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Starwell (Page Load)

        #region Starwell (CRUD Operations)
        //insert&update
        public static bool InsertUpdateStarwell(BusinessEntities.EMRForms.Starwell data)
        {
            data.sw_type = string.IsNullOrEmpty(data.sw_type) ? string.Empty : data.sw_type;
            data.sw_pappr = string.IsNullOrEmpty(data.sw_pappr) ? string.Empty : data.sw_pappr;
            data.sw_pamount = string.IsNullOrEmpty(data.sw_pamount.ToString()) ? 0 : data.sw_pamount;
            data.sw_comments = string.IsNullOrEmpty(data.sw_comments) ? string.Empty : data.sw_comments;           
            DateTime? all13 = data.sw_pdate; // Assuming data.sw_pdate is of type DateTime?   
            if (data.sw_pdate != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.sw_pdate = all13.HasValue ? all13.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.sw_pdate = DateTime.Parse("01/01/1950");
            }
           
            return DataAccessLayer.EMRForms.Starwell.InsertUpdateStarwell(data);
        }
        //Delete
        public static int DeleteStarwell(int swId, int sw_madeby)
        {
            return DataAccessLayer.EMRForms.Starwell.DeleteStarwell(swId, sw_madeby);
        }
        #endregion Starwell (CRUD Operations)
    }
    public class NGI
    {
        #region NGI (Page Load)
        public static List<BusinessEntities.EMRForms.NGI> GetAllNGI(int appId)
        {
            List<BusinessEntities.EMRForms.NGI> sclist = new List<BusinessEntities.EMRForms.NGI>();
            DataTable dt = DataAccessLayer.EMRForms.NGI.GetAllNGI(appId);
            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NGI
                {
                    ngId = Convert.ToInt32(dr["ngId"]),
                    ng_appId = Convert.ToInt32(dr["ng_appId"]),
                    ng_1 = dr["ng_1"].ToString(),
                    ng_2 = dr["ng_2"].ToString(),
                    ng_5 = dr["ng_5"].ToString(),
                    ng_3 = Convert.ToDateTime(dr["ng_3"].ToString()),
                    ng_no = Convert.ToInt32(dr["ng_no"].ToString()),
                    ng_on = dr["ng_on"].ToString(),
                    ng_eti = dr["ng_eti"].ToString(),
                    ng_comments = dr["ng_comments"].ToString(),
                    ng_4 = Convert.ToDateTime(dr["ng_4"].ToString()),
                    ng_date_created = Convert.ToDateTime(dr["ng_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NGI> GetEmrInfo(int appId)
        {
            List<BusinessEntities.EMRForms.NGI> sclist = new List<BusinessEntities.EMRForms.NGI>();
            DataTable dt = DataAccessLayer.EMRForms.NGI.GetEmrInfo(appId);
            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NGI
                {
                    inv_net = float.Parse(dr["inv_net"].ToString()).ToString("N2"),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    past = dr["past"].ToString(),
                    diag_names = dr["diag_names"].ToString(),
                    diag_codes = dr["diag_codes"].ToString(),
                    complaints = dr["complaints"].ToString(),
                    lab_treatments = dr["lab_treatments"].ToString(),
                    rad_treatments = dr["rad_treatments"].ToString(),
                    other_treatments = dr["other_treatments"].ToString(),
                    diagnosis = dr["diagnosis"].ToString(),
                    treatments = dr["treatments"].ToString(),    
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NGI> GetAllPreNGI(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NGI> sclist = new List<BusinessEntities.EMRForms.NGI>();
            DataTable dt = DataAccessLayer.EMRForms.NGI.GetAllPreNGI(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NGI
                {
                    ngId = Convert.ToInt32(dr["ngId"]),
                    ng_appId = Convert.ToInt32(dr["ng_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.NGI> GetPrintNGI(int? ngId)
        {
            List<BusinessEntities.EMRForms.NGI> sclist = new List<BusinessEntities.EMRForms.NGI>();
            DataTable dt = DataAccessLayer.EMRForms.NGI.GetPrintNGI(ngId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NGI
                    {
                        ngId = Convert.ToInt32(dr["ngId"]),
                        ng_appId = Convert.ToInt32(dr["ng_appId"]),
                        ng_1 = dr["ng_1"].ToString(),
                        ng_2 = dr["ng_2"].ToString(),
                        ng_5 = dr["ng_5"].ToString(),
                        ng_no = Convert.ToInt32(dr["ng_no"].ToString()),
                        ng_on = dr["ng_on"].ToString(),
                        ng_eti = dr["ng_eti"].ToString(),
                        ng_comments = dr["ng_comments"].ToString(),
                        ng_d4 = dr["ng_4"].ToString(),
                        ng_d3 = dr["ng_3"].ToString(),
                        ng_date_created = Convert.ToDateTime(dr["ng_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NGI a = new BusinessEntities.EMRForms.NGI();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion NGI (Page Load)

        #region NGI (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNGI(BusinessEntities.EMRForms.NGI data)
        {
            data.ng_1 = string.IsNullOrEmpty(data.ng_1) ? string.Empty : data.ng_1;
            data.ng_2 = string.IsNullOrEmpty(data.ng_2) ? string.Empty : data.ng_2;
            data.ng_5 = string.IsNullOrEmpty(data.ng_5) ? string.Empty : data.ng_5;
            data.ng_on = string.IsNullOrEmpty(data.ng_on) ? string.Empty : data.ng_on;
            data.ng_eti = string.IsNullOrEmpty(data.ng_eti) ? string.Empty : data.ng_eti;
            data.ng_no = string.IsNullOrEmpty(data.ng_no.ToString()) ? 0 : data.ng_no;
            data.ng_comments = string.IsNullOrEmpty(data.ng_comments) ? string.Empty : data.ng_comments;
            DateTime? all13 = data.ng_4; // Assuming data.ng_4 is of type DateTime?   
            if (data.ng_4 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.ng_4 = all13.HasValue ? all13.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.ng_4 = DateTime.Parse("01/01/1950");
            }
            DateTime? all3 = data.ng_3; // Assuming data.ng_3 is of type DateTime?   
            if (data.ng_3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.ng_3 = all3.HasValue ? all3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.ng_3 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.NGI.InsertUpdateNGI(data);
        }
        //Delete
        public static int DeleteNGI(int ngId, int ng_madeby)
        {
            return DataAccessLayer.EMRForms.NGI.DeleteNGI(ngId, ng_madeby);
        }
        #endregion NGI (CRUD Operations)
    }
    public class Inayah
    {
        #region Inayah (Page Load)
        public static List<BusinessEntities.EMRForms.Inayah> GetAllInayah(int appId)
        {
            List<BusinessEntities.EMRForms.Inayah> sclist = new List<BusinessEntities.EMRForms.Inayah>();
            DataTable dt = DataAccessLayer.EMRForms.Inayah.GetAllInayah(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Inayah
                {
                    cir_Id = Convert.ToInt32(dr["cir_Id"]),
                    cir_appId = Convert.ToInt32(dr["cir_appId"]),
                    cir_checkbox = dr["cir_checkbox"].ToString(),
                    cir_details = dr["cir_details"].ToString(),
                    cir_claim = dr["cir_claim"].ToString(),
                    cir_total = dr["cir_total"].ToString(),
                    cir_medicines = dr["cir_medicines"].ToString(),
                    cir_expenses = dr["cir_expenses"].ToString(),
                    cir_grand = dr["cir_grand"].ToString(),
                    cir_d1 = Convert.ToDateTime(dr["cir_d1"].ToString()),
                    cir_date_created = Convert.ToDateTime(dr["cir_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Inayah> GetAllPreInayah(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Inayah> sclist = new List<BusinessEntities.EMRForms.Inayah>();
            DataTable dt = DataAccessLayer.EMRForms.Inayah.GetAllPreInayah(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Inayah
                {
                    cir_Id = Convert.ToInt32(dr["cir_Id"]),
                    cir_appId = Convert.ToInt32(dr["cir_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
      
        //print
        public static List<BusinessEntities.EMRForms.Inayah> GetPrintInayah(int? cir_Id)
        {
            List<BusinessEntities.EMRForms.Inayah> sclist = new List<BusinessEntities.EMRForms.Inayah>();
            DataTable dt = DataAccessLayer.EMRForms.Inayah.GetPrintInayah(cir_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Inayah
                    {
                        cir_Id = Convert.ToInt32(dr["cir_Id"]),
                        cir_appId = Convert.ToInt32(dr["cir_appId"]),
                        cir_checkbox = dr["cir_checkbox"].ToString(),
                        cir_details = dr["cir_details"].ToString(),
                        cir_claim = dr["cir_claim"].ToString(),
                        cir_total = dr["cir_total"].ToString(),
                        cir_medicines = dr["cir_medicines"].ToString(),
                        cir_expenses = dr["cir_expenses"].ToString(),
                        cir_grand = dr["cir_grand"].ToString(),                   

                        cir_date1 = (dt.Rows[0]["cir_d1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cir_d1"].ToString(),
                        cir_date_created = Convert.ToDateTime(dr["cir_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Inayah a = new BusinessEntities.EMRForms.Inayah();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Inayah (Page Load)

        #region Inayah (CRUD Operations)
        //insert&update
        public static bool InsertUpdateInayah(BusinessEntities.EMRForms.Inayah data)
        {
            data.cir_checkbox = string.IsNullOrEmpty(data.cir_checkbox) ? string.Empty : data.cir_checkbox;
            data.cir_details = string.IsNullOrEmpty(data.cir_details) ? string.Empty : data.cir_details;
            data.cir_claim = string.IsNullOrEmpty(data.cir_claim) ? string.Empty : data.cir_claim;
            data.cir_total = string.IsNullOrEmpty(data.cir_total) ? string.Empty : data.cir_total;
            data.cir_medicines = string.IsNullOrEmpty(data.cir_medicines) ? string.Empty : data.cir_medicines;
            data.cir_expenses = string.IsNullOrEmpty(data.cir_expenses) ? string.Empty : data.cir_expenses;
            data.cir_grand = string.IsNullOrEmpty(data.cir_grand) ? string.Empty : data.cir_grand;
            
            DateTime? card21 = data.cir_d1; // Assuming data.cir_d1 is of type DateTime?            
            
            if (data.cir_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cir_d1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cir_d1 = DateTime.Parse("01/01/1950");
            }            

            return DataAccessLayer.EMRForms.Inayah.InsertUpdateInayah(data);
        }
        //Delete
        public static int DeleteInayah(int cir_Id, int cir_madeby)
        {
            return DataAccessLayer.EMRForms.Inayah.DeleteInayah(cir_Id, cir_madeby);
        }
        #endregion Inayah (CRUD Operations)
    }
    public class Healthnet
    {
        #region Healthnet (Page Load)
        public static List<BusinessEntities.EMRForms.Healthnet> GetAllHealthnet(int appId)
        {
            List<BusinessEntities.EMRForms.Healthnet> sclist = new List<BusinessEntities.EMRForms.Healthnet>();
            DataTable dt = DataAccessLayer.EMRForms.Healthnet.GetAllHealthnet(appId);
            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Healthnet
                {
                    chr_Id = Convert.ToInt32(dr["chr_Id"]),
                    chr_appId = Convert.ToInt32(dr["chr_appId"]),
                    chr_1 = dr["chr_1"].ToString(),
                    chr_2 = dr["chr_2"].ToString(),
                    chr_checkbox = dr["chr_checkbox"].ToString(),
                    chr_amount = dr["chr_amount"].ToString(),
                    chr_symptom = dr["chr_symptom"].ToString(),
                    chr_condition = dr["chr_condition"].ToString(),
                    chr_history = dr["chr_history"].ToString(),
                    chr_etiology = dr["chr_etiology"].ToString(),
                    chr_lab = dr["chr_lab"].ToString(),
                    chr_radiology = dr["chr_radiology"].ToString(),
                    chr_remarks = dr["chr_remarks"].ToString(),
                    chr_d1 = Convert.ToDateTime(dr["chr_d1"].ToString()),
                    chr_d2 = Convert.ToDateTime(dr["chr_d2"].ToString()),
                    chr_date_created = Convert.ToDateTime(dr["chr_date_created"].ToString()),
                });
            }
            return sclist;
        }
        
        public static List<BusinessEntities.EMRForms.Healthnet> GetAllPreHealthnet(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Healthnet> sclist = new List<BusinessEntities.EMRForms.Healthnet>();
            DataTable dt = DataAccessLayer.EMRForms.Healthnet.GetAllPreHealthnet(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Healthnet
                {
                    chr_Id = Convert.ToInt32(dr["chr_Id"]),
                    chr_appId = Convert.ToInt32(dr["chr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.Healthnet> GetPrintHealthnet(int? chr_Id)
        {
            List<BusinessEntities.EMRForms.Healthnet> sclist = new List<BusinessEntities.EMRForms.Healthnet>();
            DataTable dt = DataAccessLayer.EMRForms.Healthnet.GetPrintHealthnet(chr_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Healthnet
                    {
                        chr_Id = Convert.ToInt32(dr["chr_Id"]),
                        chr_appId = Convert.ToInt32(dr["chr_appId"]),
                        chr_1 = dr["chr_1"].ToString(),
                        chr_2 = dr["chr_2"].ToString(),
                        chr_checkbox = dr["chr_checkbox"].ToString(),
                        chr_amount = dr["chr_amount"].ToString(),
                        chr_symptom = dr["chr_symptom"].ToString(),
                        chr_condition = dr["chr_condition"].ToString(),
                        chr_history = dr["chr_history"].ToString(),
                        chr_etiology = dr["chr_etiology"].ToString(),
                        chr_lab = dr["chr_lab"].ToString(),
                        chr_radiology = dr["chr_radiology"].ToString(),
                        chr_remarks = dr["chr_remarks"].ToString(),
                        chr_date1 = dr["chr_d1"].ToString(),
                        chr_date2 = dr["chr_d2"].ToString(),
                        chr_date_created = Convert.ToDateTime(dr["chr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Healthnet a = new BusinessEntities.EMRForms.Healthnet();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Healthnet (Page Load)

        #region Healthnet (CRUD Operations)
        //insert&update
        public static bool InsertUpdateHealthnet(BusinessEntities.EMRForms.Healthnet data)
        {
            data.chr_1 = string.IsNullOrEmpty(data.chr_1) ? string.Empty : data.chr_1;
            data.chr_2 = string.IsNullOrEmpty(data.chr_2) ? string.Empty : data.chr_2;
            data.chr_checkbox = string.IsNullOrEmpty(data.chr_checkbox) ? string.Empty : data.chr_checkbox;
            data.chr_amount = string.IsNullOrEmpty(data.chr_amount) ? string.Empty : data.chr_amount;
            data.chr_symptom = string.IsNullOrEmpty(data.chr_symptom) ? string.Empty : data.chr_symptom;
            data.chr_history = string.IsNullOrEmpty(data.chr_history) ? string.Empty : data.chr_history;
            data.chr_etiology = string.IsNullOrEmpty(data.chr_etiology) ? string.Empty : data.chr_etiology;
            data.chr_condition = string.IsNullOrEmpty(data.chr_condition) ? string.Empty : data.chr_condition;
            data.chr_lab = string.IsNullOrEmpty(data.chr_lab) ? string.Empty : data.chr_lab;
            data.chr_radiology = string.IsNullOrEmpty(data.chr_radiology) ? string.Empty : data.chr_radiology;
            data.chr_remarks = string.IsNullOrEmpty(data.chr_remarks) ? string.Empty : data.chr_remarks;
            DateTime? all13 = data.chr_d1; // Assuming data.chr_d1 is of type DateTime?   
            if (data.chr_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.chr_d1 = all13.HasValue ? all13.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.chr_d1 = DateTime.Parse("01/01/1950");
            }
            DateTime? all3 = data.chr_d2; // Assuming data.chr_d2 is of type DateTime?   
            if (data.chr_d2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.chr_d2 = all3.HasValue ? all3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.chr_d2 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.Healthnet.InsertUpdateHealthnet(data);
        }
        //Delete
        public static int DeleteHealthnet(int chr_Id, int chr_madeby)
        {
            return DataAccessLayer.EMRForms.Healthnet.DeleteHealthnet(chr_Id, chr_madeby);
        }
        #endregion Healthnet (CRUD Operations)
    }
    public class Daman
    {
        #region Daman (Page Load)
        public static List<BusinessEntities.EMRForms.Daman> GetAllDaman(int appId)
        {
            List<BusinessEntities.EMRForms.Daman> sclist = new List<BusinessEntities.EMRForms.Daman>();
            DataTable dt = DataAccessLayer.EMRForms.Daman.GetAllDaman(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Daman
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    cdr_checkbox = dr["cdr_checkbox"].ToString(),
                    cdr_e1 = dr["cdr_e1"].ToString(),
                    cdr_e2 = dr["cdr_e2"].ToString(),
                    cdr_e3 = dr["cdr_e3"].ToString(),
                    cdr_e4 = dr["cdr_e4"].ToString(),
                    cdr_e5 = dr["cdr_e5"].ToString(),
                    cdr_e6 = dr["cdr_e6"].ToString(),
                    cdr_e7 = dr["cdr_e7"].ToString(),
                    cdr_e8 = dr["cdr_e8"].ToString(),
                    cdr_e9 = dr["cdr_e9"].ToString(),
                    cdr_e10 = dr["cdr_e10"].ToString(),
                    cdr_e11 = dr["cdr_e11"].ToString(),
                    cdr_e12 = dr["cdr_e12"].ToString(),
                    cdr_e13 = dr["cdr_e13"].ToString(),

                    cdr_d1 = Convert.ToDateTime(dr["cdr_d1"].ToString()),
                    cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Daman> GetAllPreDaman(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Daman> sclist = new List<BusinessEntities.EMRForms.Daman>();
            DataTable dt = DataAccessLayer.EMRForms.Daman.GetAllPreDaman(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Daman
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
       
        //print
        public static List<BusinessEntities.EMRForms.Daman> GetPrintDaman(int? cdr_Id)
        {
            List<BusinessEntities.EMRForms.Daman> sclist = new List<BusinessEntities.EMRForms.Daman>();
            DataTable dt = DataAccessLayer.EMRForms.Daman.GetPrintDaman(cdr_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Daman
                    {
                        cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                        cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                        cdr_checkbox = dr["cdr_checkbox"].ToString(),
                        cdr_e1 = dr["cdr_e1"].ToString(),
                        cdr_e2 = dr["cdr_e2"].ToString(),
                        cdr_e3 = dr["cdr_e3"].ToString(),
                        cdr_e4 = dr["cdr_e4"].ToString(),
                        cdr_e5 = dr["cdr_e5"].ToString(),
                        cdr_e6 = dr["cdr_e6"].ToString(),
                        cdr_e7 = dr["cdr_e7"].ToString(),
                        cdr_e8 = dr["cdr_e8"].ToString(),
                        cdr_e9 = dr["cdr_e9"].ToString(),
                        cdr_e10 = dr["cdr_e10"].ToString(),
                        cdr_e11 = dr["cdr_e11"].ToString(),
                        cdr_e12 = dr["cdr_e12"].ToString(),
                        cdr_e13 = dr["cdr_e13"].ToString(),                        
                        cdr_dd1 = dr["cdr_d1"].ToString(),
                        cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Daman a = new BusinessEntities.EMRForms.Daman();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Daman (Page Load)

        #region Daman (CRUD Operations)
        //insert&update
        public static bool InsertUpdateDaman(BusinessEntities.EMRForms.Daman data)
        {
            data.cdr_checkbox = string.IsNullOrEmpty(data.cdr_checkbox) ? string.Empty : data.cdr_checkbox;
            data.cdr_e1 = string.IsNullOrEmpty(data.cdr_e1) ? string.Empty : data.cdr_e1;
            data.cdr_e2 = string.IsNullOrEmpty(data.cdr_e2) ? string.Empty : data.cdr_e2;
            data.cdr_e3 = string.IsNullOrEmpty(data.cdr_e3) ? string.Empty : data.cdr_e3;
            data.cdr_e4 = string.IsNullOrEmpty(data.cdr_e4) ? string.Empty : data.cdr_e4;
            data.cdr_e5 = string.IsNullOrEmpty(data.cdr_e5) ? string.Empty : data.cdr_e5;
            data.cdr_e6 = string.IsNullOrEmpty(data.cdr_e6) ? string.Empty : data.cdr_e6;
            data.cdr_e7 = string.IsNullOrEmpty(data.cdr_e7) ? string.Empty : data.cdr_e7;
            data.cdr_e8 = string.IsNullOrEmpty(data.cdr_e8) ? string.Empty : data.cdr_e8;
            data.cdr_e9 = string.IsNullOrEmpty(data.cdr_e9) ? string.Empty : data.cdr_e9;
            data.cdr_e10 = string.IsNullOrEmpty(data.cdr_e10) ? string.Empty : data.cdr_e10;
            data.cdr_e11 = string.IsNullOrEmpty(data.cdr_e11) ? string.Empty : data.cdr_e11;
            data.cdr_e12 = string.IsNullOrEmpty(data.cdr_e12) ? string.Empty : data.cdr_e12;
            data.cdr_e13 = string.IsNullOrEmpty(data.cdr_e12) ? string.Empty : data.cdr_e13;
            DateTime? card1 = data.cdr_d1; // Assuming data.cdr_d1 is of type DateTime?            
           
            if (data.cdr_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cdr_d1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cdr_d1 = DateTime.Parse("01/01/1950");
            }
           
            return DataAccessLayer.EMRForms.Daman.InsertUpdateDaman(data);
        }
        //Delete
        public static int DeleteDaman(int cdr_Id, int cdr_madeby)
        {
            return DataAccessLayer.EMRForms.Daman.DeleteDaman(cdr_Id, cdr_madeby);
        }
        #endregion Daman (CRUD Operations)
    }
    public class DamanArabic
    {
        #region DamanArabic (Page Load)
        public static List<BusinessEntities.EMRForms.DamanArabic> GetAllDamanArabic(int appId)
        {
            List<BusinessEntities.EMRForms.DamanArabic> sclist = new List<BusinessEntities.EMRForms.DamanArabic>();
            DataTable dt = DataAccessLayer.EMRForms.DamanArabic.GetAllDamanArabic(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.DamanArabic
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    cdr_checkbox = dr["cdr_checkbox"].ToString(),
                    cdr_e1 = dr["cdr_e1"].ToString(),
                    cdr_e2 = dr["cdr_e2"].ToString(),
                    cdr_e3 = dr["cdr_e3"].ToString(),
                    cdr_e4 = dr["cdr_e4"].ToString(),
                    cdr_e5 = dr["cdr_e5"].ToString(),
                    cdr_e6 = dr["cdr_e6"].ToString(),
                    cdr_e7 = dr["cdr_e7"].ToString(),
                    cdr_e8 = dr["cdr_e8"].ToString(),
                    cdr_e9 = dr["cdr_e9"].ToString(),
                    cdr_e10 = dr["cdr_e10"].ToString(),
                    cdr_e11 = dr["cdr_e11"].ToString(),
                    cdr_e12 = dr["cdr_e12"].ToString(),
                    cdr_e13 = dr["cdr_e13"].ToString(),

                    cdr_d1 = Convert.ToDateTime(dr["cdr_d1"].ToString()),
                    cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.DamanArabic> GetAllPreDamanArabic(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.DamanArabic> sclist = new List<BusinessEntities.EMRForms.DamanArabic>();
            DataTable dt = DataAccessLayer.EMRForms.DamanArabic.GetAllPreDamanArabic(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.DamanArabic
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.DamanArabic> GetPrintDamanArabic(int? cdr_Id)
        {
            List<BusinessEntities.EMRForms.DamanArabic> sclist = new List<BusinessEntities.EMRForms.DamanArabic>();
            DataTable dt = DataAccessLayer.EMRForms.DamanArabic.GetPrintDamanArabic(cdr_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.DamanArabic
                    {
                        cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                        cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                        cdr_checkbox = dr["cdr_checkbox"].ToString(),
                        cdr_e1 = dr["cdr_e1"].ToString(),
                        cdr_e2 = dr["cdr_e2"].ToString(),
                        cdr_e3 = dr["cdr_e3"].ToString(),
                        cdr_e4 = dr["cdr_e4"].ToString(),
                        cdr_e5 = dr["cdr_e5"].ToString(),
                        cdr_e6 = dr["cdr_e6"].ToString(),
                        cdr_e7 = dr["cdr_e7"].ToString(),
                        cdr_e8 = dr["cdr_e8"].ToString(),
                        cdr_e9 = dr["cdr_e9"].ToString(),
                        cdr_e10 = dr["cdr_e10"].ToString(),
                        cdr_e11 = dr["cdr_e11"].ToString(),
                        cdr_e12 = dr["cdr_e12"].ToString(),
                        cdr_e13 = dr["cdr_e13"].ToString(),
                        cdr_dd1 = dr["cdr_d1"].ToString(),
                        cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.DamanArabic a = new BusinessEntities.EMRForms.DamanArabic();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion DamanArabic (Page Load)

        #region DamanArabic (CRUD Operations)
        //insert&update
        public static bool InsertUpdateDamanArabic(BusinessEntities.EMRForms.DamanArabic data)
        {
            data.cdr_checkbox = string.IsNullOrEmpty(data.cdr_checkbox) ? string.Empty : data.cdr_checkbox;
            data.cdr_e1 = string.IsNullOrEmpty(data.cdr_e1) ? string.Empty : data.cdr_e1;
            data.cdr_e2 = string.IsNullOrEmpty(data.cdr_e2) ? string.Empty : data.cdr_e2;
            data.cdr_e3 = string.IsNullOrEmpty(data.cdr_e3) ? string.Empty : data.cdr_e3;
            data.cdr_e4 = string.IsNullOrEmpty(data.cdr_e4) ? string.Empty : data.cdr_e4;
            data.cdr_e5 = string.IsNullOrEmpty(data.cdr_e5) ? string.Empty : data.cdr_e5;
            data.cdr_e6 = string.IsNullOrEmpty(data.cdr_e6) ? string.Empty : data.cdr_e6;
            data.cdr_e7 = string.IsNullOrEmpty(data.cdr_e7) ? string.Empty : data.cdr_e7;
            data.cdr_e8 = string.IsNullOrEmpty(data.cdr_e8) ? string.Empty : data.cdr_e8;
            data.cdr_e9 = string.IsNullOrEmpty(data.cdr_e9) ? string.Empty : data.cdr_e9;
            data.cdr_e10 = string.IsNullOrEmpty(data.cdr_e10) ? string.Empty : data.cdr_e10;
            data.cdr_e11 = string.IsNullOrEmpty(data.cdr_e11) ? string.Empty : data.cdr_e11;
            data.cdr_e12 = string.IsNullOrEmpty(data.cdr_e12) ? string.Empty : data.cdr_e12;
            data.cdr_e13 = string.IsNullOrEmpty(data.cdr_e12) ? string.Empty : data.cdr_e13;
            DateTime? card1 = data.cdr_d1; // Assuming data.cdr_d1 is of type DateTime?            

            if (data.cdr_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cdr_d1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cdr_d1 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.DamanArabic.InsertUpdateDamanArabic(data);
        }
        //Delete
        public static int DeleteDamanArabic(int cdr_Id, int cdr_madeby)
        {
            return DataAccessLayer.EMRForms.DamanArabic.DeleteDamanArabic(cdr_Id, cdr_madeby);
        }
        #endregion DamanArabic (CRUD Operations)
    }

    public class DamanWT
    {
        #region DamanWT (Page Load)
        public static List<BusinessEntities.EMRForms.DamanWT> GetAllDamanWT(int appId)
        {
            List<BusinessEntities.EMRForms.DamanWT> sclist = new List<BusinessEntities.EMRForms.DamanWT>();
            DataTable dt = DataAccessLayer.EMRForms.DamanWT.GetAllDamanWT(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.DamanWT
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    cdr_checkbox = dr["cdr_checkbox"].ToString(),
                    cdr_e1 = dr["cdr_e1"].ToString(),
                    cdr_e2 = dr["cdr_e2"].ToString(),
                    cdr_e3 = dr["cdr_e3"].ToString(),
                    cdr_e4 = dr["cdr_e4"].ToString(),
                    cdr_e5 = dr["cdr_e5"].ToString(),
                    cdr_e6 = dr["cdr_e6"].ToString(),
                    cdr_e7 = dr["cdr_e7"].ToString(),
                    cdr_e8 = dr["cdr_e8"].ToString(),
                    cdr_e9 = dr["cdr_e9"].ToString(),
                    cdr_e10 = dr["cdr_e10"].ToString(),
                    cdr_e11 = dr["cdr_e11"].ToString(),
                    cdr_e12 = dr["cdr_e12"].ToString(),

                    cdr_d1 = Convert.ToDateTime(dr["cdr_d1"].ToString()),
                    cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.DamanWT> GetAllPreDamanWT(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.DamanWT> sclist = new List<BusinessEntities.EMRForms.DamanWT>();
            DataTable dt = DataAccessLayer.EMRForms.DamanWT.GetAllPreDamanWT(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.DamanWT
                {
                    cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                    cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
         public static List<BusinessEntities.EMRForms.DamanWT> getDataDaman(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.DamanWT> sclist = new List<BusinessEntities.EMRForms.DamanWT>();
            DataTable dt = DataAccessLayer.EMRForms.DamanWT.getDataDaman(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.DamanWT
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    set_company = dr["set_company"].ToString(),
                    pt_invno = dr["pt_invno"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    pt_net = float.Parse(dr["pt_net"].ToString()).ToString("N2"),
                    pt_date = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.DamanWT> GetPrintDamanWT(int? cdr_Id)
        {
            List<BusinessEntities.EMRForms.DamanWT> sclist = new List<BusinessEntities.EMRForms.DamanWT>();
            DataTable dt = DataAccessLayer.EMRForms.DamanWT.GetPrintDamanWT(cdr_Id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.DamanWT
                    {
                        cdr_Id = Convert.ToInt32(dr["cdr_Id"]),
                        cdr_appId = Convert.ToInt32(dr["cdr_appId"]),
                        cdr_checkbox = dr["cdr_checkbox"].ToString(),
                        cdr_e1 = dr["cdr_e1"].ToString(),
                        cdr_e2 = dr["cdr_e2"].ToString(),
                        cdr_e3 = dr["cdr_e3"].ToString(),
                        cdr_e4 = dr["cdr_e4"].ToString(),
                        cdr_e5 = dr["cdr_e5"].ToString(),
                        cdr_e6 = dr["cdr_e6"].ToString(),
                        cdr_e7 = dr["cdr_e7"].ToString(),
                        cdr_e8 = dr["cdr_e8"].ToString(),
                        cdr_e9 = dr["cdr_e9"].ToString(),
                        cdr_e10 = dr["cdr_e10"].ToString(),
                        cdr_e11 = dr["cdr_e11"].ToString(),
                        cdr_e12 = dr["cdr_e12"].ToString(),
                        cdr_dd1 = dr["cdr_d1"].ToString(),
                        cdr_date_created = Convert.ToDateTime(dr["cdr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.DamanWT a = new BusinessEntities.EMRForms.DamanWT();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion DamanWT (Page Load)

        #region DamanWT (CRUD Operations)
        //insert&update
        public static bool InsertUpdateDamanWT(BusinessEntities.EMRForms.DamanWT data)
        {
            data.cdr_checkbox = string.IsNullOrEmpty(data.cdr_checkbox) ? string.Empty : data.cdr_checkbox;
            data.cdr_e1 = string.IsNullOrEmpty(data.cdr_e1) ? string.Empty : data.cdr_e1;
            data.cdr_e2 = string.IsNullOrEmpty(data.cdr_e2) ? string.Empty : data.cdr_e2;
            data.cdr_e3 = string.IsNullOrEmpty(data.cdr_e3) ? string.Empty : data.cdr_e3;
            data.cdr_e4 = string.IsNullOrEmpty(data.cdr_e4) ? string.Empty : data.cdr_e4;
            data.cdr_e5 = string.IsNullOrEmpty(data.cdr_e5) ? string.Empty : data.cdr_e5;
            data.cdr_e6 = string.IsNullOrEmpty(data.cdr_e6) ? string.Empty : data.cdr_e6;
            data.cdr_e7 = string.IsNullOrEmpty(data.cdr_e7) ? string.Empty : data.cdr_e7;
            data.cdr_e8 = string.IsNullOrEmpty(data.cdr_e8) ? string.Empty : data.cdr_e8;
            data.cdr_e9 = string.IsNullOrEmpty(data.cdr_e9) ? string.Empty : data.cdr_e9;
            data.cdr_e10 = string.IsNullOrEmpty(data.cdr_e10) ? string.Empty : data.cdr_e10;
            data.cdr_e11 = string.IsNullOrEmpty(data.cdr_e11) ? string.Empty : data.cdr_e11;
            data.cdr_e12 = string.IsNullOrEmpty(data.cdr_e12) ? string.Empty : data.cdr_e12;
            DateTime? card1 = data.cdr_d1; // Assuming data.cdr_d1 is of type DateTime?            

            if (data.cdr_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cdr_d1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cdr_d1 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.DamanWT.InsertUpdateDamanWT(data);
        }
        //Delete
        public static int DeleteDamanWT(int cdr_Id, int cdr_madeby)
        {
            return DataAccessLayer.EMRForms.DamanWT.DeleteDamanWT(cdr_Id, cdr_madeby);
        }
        #endregion DamanWT (CRUD Operations)
    }

    public class NAS
    {
        #region NAS (Page Load)
        public static List<BusinessEntities.EMRForms.NAS> GetAllNAS(int appId)
        {
            List<BusinessEntities.EMRForms.NAS> sclist = new List<BusinessEntities.EMRForms.NAS>();
            DataTable dt = DataAccessLayer.EMRForms.NAS.GetAllNAS(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NAS
                {
                    nasnId = Convert.ToInt32(dr["nasnId"]),
                    nasn_appId = Convert.ToInt32(dr["nasn_appId"]),
                    nasn_1 = dr["nasn_1"].ToString(),
                    nasn_2 = dr["nasn_2"].ToString(),
                    nasn_3 = dr["nasn_3"].ToString(),
                    nasn_4 = dr["nasn_4"].ToString(),
                    nasn_5 = dr["nasn_5"].ToString(),
                    nasn_6 = dr["nasn_6"].ToString(),
                    nasn_7 = dr["nasn_7"].ToString(),
                    nasn_8 = dr["nasn_8"].ToString(),
                    nasn_9 = dr["nasn_9"].ToString(),
                    nasn_10 = dr["nasn_10"].ToString(),
                    nasn_11 = dr["nasn_11"].ToString(),
                    nasn_12 = dr["nasn_12"].ToString(),
                    nasn_13 = dr["nasn_13"].ToString(),
                    nasn_14 = dr["nasn_14"].ToString(),
                    nasn_15 = dr["nasn_15"].ToString(),
                    nasn_16 = dr["nasn_16"].ToString(),
                    nasn_17 = dr["nasn_17"].ToString(),
                    nasn_18 = dr["nasn_18"].ToString(),
                    nasn_date1 = Convert.ToDateTime(dr["nasn_date1"].ToString()),
                    nasn_date_created = Convert.ToDateTime(dr["nasn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NAS> GetAllPreNAS(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NAS> sclist = new List<BusinessEntities.EMRForms.NAS>();
            DataTable dt = DataAccessLayer.EMRForms.NAS.GetAllPreNAS(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NAS
                {
                    nasnId = Convert.ToInt32(dr["nasnId"]),
                    nasn_appId = Convert.ToInt32(dr["nasn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

       
        //print
        public static List<BusinessEntities.EMRForms.NAS> GetPrintNAS(int? nasnId)
        {
            List<BusinessEntities.EMRForms.NAS> sclist = new List<BusinessEntities.EMRForms.NAS>();
            DataTable dt = DataAccessLayer.EMRForms.NAS.GetPrintNAS(nasnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NAS
                    {
                        nasnId = Convert.ToInt32(dr["nasnId"]),
                        nasn_appId = Convert.ToInt32(dr["nasn_appId"]),
                        nasn_1 = dr["nasn_1"].ToString(),
                        nasn_2 = dr["nasn_2"].ToString(),
                        nasn_3 = dr["nasn_3"].ToString(),
                        nasn_4 = dr["nasn_4"].ToString(),
                        nasn_5 = dr["nasn_5"].ToString(),
                        nasn_6 = dr["nasn_6"].ToString(),
                        nasn_7 = dr["nasn_7"].ToString(),
                        nasn_8 = dr["nasn_8"].ToString(),
                        nasn_9 = dr["nasn_9"].ToString(),
                        nasn_10 = dr["nasn_10"].ToString(),
                        nasn_11 = dr["nasn_11"].ToString(),
                        nasn_12 = dr["nasn_12"].ToString(),
                        nasn_13 = dr["nasn_13"].ToString(),
                        nasn_14 = dr["nasn_14"].ToString(),
                        nasn_15 = dr["nasn_15"].ToString(),
                        nasn_16 = dr["nasn_16"].ToString(),
                        nasn_17 = dr["nasn_17"].ToString(),
                        nasn_18 = dr["nasn_18"].ToString(),

                        nasn_d1 = (dt.Rows[0]["nasn_date1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["nasn_date1"].ToString(),
                        nasn_date_created = Convert.ToDateTime(dr["nasn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NAS a = new BusinessEntities.EMRForms.NAS();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion NAS (Page Load)

        #region NAS (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNAS(BusinessEntities.EMRForms.NAS data)
        {
            data.nasn_1 = string.IsNullOrEmpty(data.nasn_1) ? string.Empty : data.nasn_1;
            data.nasn_2 = string.IsNullOrEmpty(data.nasn_2) ? string.Empty : data.nasn_2;
            data.nasn_3 = string.IsNullOrEmpty(data.nasn_3) ? string.Empty : data.nasn_3;
            data.nasn_4 = string.IsNullOrEmpty(data.nasn_4) ? string.Empty : data.nasn_4;
            data.nasn_5 = string.IsNullOrEmpty(data.nasn_5) ? string.Empty : data.nasn_5;
            data.nasn_6 = string.IsNullOrEmpty(data.nasn_6) ? string.Empty : data.nasn_6;
            data.nasn_7 = string.IsNullOrEmpty(data.nasn_7) ? string.Empty : data.nasn_7;
            data.nasn_8 = string.IsNullOrEmpty(data.nasn_8) ? string.Empty : data.nasn_8;
            data.nasn_9 = string.IsNullOrEmpty(data.nasn_9) ? string.Empty : data.nasn_9;
            data.nasn_10 = string.IsNullOrEmpty(data.nasn_10) ? string.Empty : data.nasn_10;
            data.nasn_11 = string.IsNullOrEmpty(data.nasn_11) ? string.Empty : data.nasn_11;
            data.nasn_12 = string.IsNullOrEmpty(data.nasn_12) ? string.Empty : data.nasn_12;
            data.nasn_13 = string.IsNullOrEmpty(data.nasn_13) ? string.Empty : data.nasn_13;
            data.nasn_14 = string.IsNullOrEmpty(data.nasn_14) ? string.Empty : data.nasn_14;
            data.nasn_15 = string.IsNullOrEmpty(data.nasn_15) ? string.Empty : data.nasn_15;
            data.nasn_16 = string.IsNullOrEmpty(data.nasn_16) ? string.Empty : data.nasn_16;
            data.nasn_17 = string.IsNullOrEmpty(data.nasn_17) ? string.Empty : data.nasn_17;
            data.nasn_18 = string.IsNullOrEmpty(data.nasn_18) ? string.Empty : data.nasn_18;
            DateTime? card21 = data.nasn_date1; // Assuming data.nasn_d1 is of type DateTime? 
            if (data.nasn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.nasn_date1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.nasn_date1 = DateTime.Parse("01/01/1950");
            }           

            return DataAccessLayer.EMRForms.NAS.InsertUpdateNAS(data);
        }
        //Delete
        public static int DeleteNAS(int nasnId, int nasn_madeby)
        {
            return DataAccessLayer.EMRForms.NAS.DeleteNAS(nasnId, nasn_madeby);
        }
        #endregion NAS (CRUD Operations)
    }

    public class Metlife
    {
        #region Metlife (Page Load)
        public static List<BusinessEntities.EMRForms.Metlife> GetAllMetlife(int appId)
        {
            List<BusinessEntities.EMRForms.Metlife> sclist = new List<BusinessEntities.EMRForms.Metlife>();
            DataTable dt = DataAccessLayer.EMRForms.Metlife.GetAllMetlife(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Metlife
                {
                    metId = Convert.ToInt32(dr["metId"]),
                    met_appId = Convert.ToInt32(dr["met_appId"]),
                    met_1 = dr["met_1"].ToString(),
                    met_2 = dr["met_2"].ToString(),
                    met_3 = dr["met_3"].ToString(),
                    met_check = dr["met_check"].ToString(),
                    met_claim_amount = dr["met_claim_amount"].ToString(),
                    met_currency = dr["met_currency"].ToString(),
                    met_4 = Convert.ToDateTime(dr["met_4"].ToString()),
                    met_date_created = Convert.ToDateTime(dr["met_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Metlife> GetAllPreMetlife(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Metlife> sclist = new List<BusinessEntities.EMRForms.Metlife>();
            DataTable dt = DataAccessLayer.EMRForms.Metlife.GetAllPreMetlife(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Metlife
                {
                    metId = Convert.ToInt32(dr["metId"]),
                    met_appId = Convert.ToInt32(dr["met_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }


        //print
        public static List<BusinessEntities.EMRForms.Metlife> GetPrintMetlife(int? metId)
        {
            List<BusinessEntities.EMRForms.Metlife> sclist = new List<BusinessEntities.EMRForms.Metlife>();
            DataTable dt = DataAccessLayer.EMRForms.Metlife.GetPrintMetlife(metId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Metlife
                    {
                        metId = Convert.ToInt32(dr["metId"]),
                        met_appId = Convert.ToInt32(dr["met_appId"]),
                        met_1 = dr["met_1"].ToString(),
                        met_2 = dr["met_2"].ToString(),
                        met_3 = dr["met_3"].ToString(),
                        met_check = dr["met_check"].ToString(),
                        met_claim_amount = dr["met_claim_amount"].ToString(),
                        met_currency = dr["met_currency"].ToString(),
                        met_4 = Convert.ToDateTime(dr["met_4"].ToString()),
                        met_date_created = Convert.ToDateTime(dr["met_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Metlife a = new BusinessEntities.EMRForms.Metlife();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Metlife (Page Load)

        #region Metlife (CRUD Operations)
        //insert&update
        public static bool InsertUpdateMetlife(BusinessEntities.EMRForms.Metlife data)
        {
            data.met_1 = string.IsNullOrEmpty(data.met_1) ? string.Empty : data.met_1;
            data.met_2 = string.IsNullOrEmpty(data.met_2) ? string.Empty : data.met_2;
            data.met_3 = string.IsNullOrEmpty(data.met_3) ? string.Empty : data.met_3;
            DateTime? card1 = data.met_4; // Assuming data.cdr_d1 is of type DateTime?            

            if (data.met_4 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.met_4 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.met_4 = DateTime.Parse("01/01/1950");
            }
            data.met_check = string.IsNullOrEmpty(data.met_check) ? string.Empty : data.met_check;
            data.met_claim_amount = string.IsNullOrEmpty(data.met_claim_amount) ? string.Empty : data.met_claim_amount;
            data.met_currency = string.IsNullOrEmpty(data.met_currency) ? string.Empty : data.met_currency;

            return DataAccessLayer.EMRForms.Metlife.InsertUpdateMetlife(data);
        }
        //Delete
        public static int DeleteMetlife(int metId, int met_madeby)
        {
            return DataAccessLayer.EMRForms.Metlife.DeleteMetlife(metId, met_madeby);
        }
        #endregion Metlife (CRUD Operations)
    }

    public class Mednet
    {
        #region Mednet (Page Load)
        public static List<BusinessEntities.EMRForms.Mednet> GetAllMednet(int appId)
        {
            List<BusinessEntities.EMRForms.Mednet> sclist = new List<BusinessEntities.EMRForms.Mednet>();
            DataTable dt = DataAccessLayer.EMRForms.Mednet.GetAllMednet(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Mednet
                {
                    cmcnId = Convert.ToInt32(dr["cmcnId"]),
                    cmcn_appId = Convert.ToInt32(dr["cmcn_appId"]),
                    cmcn_1 = dr["cmcn_1"].ToString(),
                    cmcn_2 = dr["cmcn_2"].ToString(),
                    cmcn_3 = dr["cmcn_3"].ToString(),
                    cmcn_4 = dr["cmcn_4"].ToString(),
                    cmcn_5 = dr["cmcn_5"].ToString(),
                    cmcn_6 = dr["cmcn_6"].ToString(),
                    cmcn_7 = dr["cmcn_7"].ToString(),
                    cmcn_chk = dr["cmcn_chk"].ToString(),
                    cmcn_date1 = Convert.ToDateTime(dr["cmcn_date1"].ToString()),
                    cmcn_date2 = Convert.ToDateTime(dr["cmcn_date2"].ToString()),
                    cmcn_date3 = Convert.ToDateTime(dr["cmcn_date3"].ToString()),
                    cmcn_date_created = Convert.ToDateTime(dr["cmcn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Mednet> GetAllPreMednet(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Mednet> sclist = new List<BusinessEntities.EMRForms.Mednet>();
            DataTable dt = DataAccessLayer.EMRForms.Mednet.GetAllPreMednet(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Mednet
                {
                    cmcnId = Convert.ToInt32(dr["cmcnId"]),
                    cmcn_appId = Convert.ToInt32(dr["cmcn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

       
        //print
        public static List<BusinessEntities.EMRForms.Mednet> GetPrintMednet(int? cmcnId)
        {
            List<BusinessEntities.EMRForms.Mednet> sclist = new List<BusinessEntities.EMRForms.Mednet>();
            DataTable dt = DataAccessLayer.EMRForms.Mednet.GetPrintMednet(cmcnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Mednet
                    {
                        cmcnId = Convert.ToInt32(dr["cmcnId"]),
                        cmcn_appId = Convert.ToInt32(dr["cmcn_appId"]),
                        cmcn_1 = dr["cmcn_1"].ToString(),
                        cmcn_2 = dr["cmcn_2"].ToString(),
                        cmcn_3 = dr["cmcn_3"].ToString(),
                        cmcn_4 = dr["cmcn_4"].ToString(),
                        cmcn_5 = dr["cmcn_5"].ToString(),
                        cmcn_6 = dr["cmcn_6"].ToString(),
                        cmcn_7 = dr["cmcn_7"].ToString(),
                        cmcn_chk = dr["cmcn_chk"].ToString(),
                        cmcn_d21 = (dt.Rows[0]["cmcn_date1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cmcn_date1"].ToString(),
                        cmcn_d22 = (dt.Rows[0]["cmcn_date2"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cmcn_date2"].ToString(),
                        cmcn_d23 = (dt.Rows[0]["cmcn_date3"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cmcn_date3"].ToString(),
                        cmcn_date_created = Convert.ToDateTime(dr["cmcn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),
                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Mednet a = new BusinessEntities.EMRForms.Mednet();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Mednet (Page Load)

        #region Mednet (CRUD Operations)
        //insert&update
        public static bool InsertUpdateMednet(BusinessEntities.EMRForms.Mednet data)
        {
            data.cmcn_1 = string.IsNullOrEmpty(data.cmcn_1) ? string.Empty : data.cmcn_1;
            data.cmcn_2 = string.IsNullOrEmpty(data.cmcn_2) ? string.Empty : data.cmcn_2;
            data.cmcn_3 = string.IsNullOrEmpty(data.cmcn_3) ? string.Empty : data.cmcn_3;
            data.cmcn_4 = string.IsNullOrEmpty(data.cmcn_4) ? string.Empty : data.cmcn_4;
            data.cmcn_5 = string.IsNullOrEmpty(data.cmcn_5) ? string.Empty : data.cmcn_5;
            data.cmcn_6 = string.IsNullOrEmpty(data.cmcn_6) ? string.Empty : data.cmcn_6;
            data.cmcn_7 = string.IsNullOrEmpty(data.cmcn_7) ? string.Empty : data.cmcn_7;
            data.cmcn_chk = string.IsNullOrEmpty(data.cmcn_chk) ? string.Empty : data.cmcn_chk;
            DateTime? card21 = data.cmcn_date1; // Assuming data.cmcn_d1 is of type DateTime?            
            DateTime? card22 = data.cmcn_date2; // Assuming data.cmcn_d2 is of type DateTime?
            DateTime? card23 = data.cmcn_date3; // Assuming data.cmcn_d3 is of type DateTime?
            if (data.cmcn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cmcn_date1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cmcn_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cmcn_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cmcn_date2 = card22.HasValue ? card22.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cmcn_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.cmcn_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cmcn_date3 = card23.HasValue ? card23.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cmcn_date3 = DateTime.Parse("01/01/1950");
            }
            

            return DataAccessLayer.EMRForms.Mednet.InsertUpdateMednet(data);
        }
        //Delete
        public static int DeleteMednet(int cmcnId, int cmcn_madeby)
        {
            return DataAccessLayer.EMRForms.Mednet.DeleteMednet(cmcnId, cmcn_madeby);
        }
        #endregion Mednet (CRUD Operations)
    }

    public class Nextcare
    {
        #region Nextcare (Page Load)
        public static List<BusinessEntities.EMRForms.Nextcare> GetAllNextcare(int appId)
        {
            List<BusinessEntities.EMRForms.Nextcare> sclist = new List<BusinessEntities.EMRForms.Nextcare>();
            DataTable dt = DataAccessLayer.EMRForms.Nextcare.GetAllNextcare(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Nextcare
                {
                    cncnId = Convert.ToInt32(dr["cncnId"]),
                    cncn_appId = Convert.ToInt32(dr["cncn_appId"]),
                    cncn_1 = dr["cncn_1"].ToString(),
                    cncn_2 = dr["cncn_2"].ToString(),
                    cncn_3 = dr["cncn_3"].ToString(),
                    cncn_4 = dr["cncn_4"].ToString(),
                    cncn_5 = dr["cncn_5"].ToString(),
                    cncn_6 = dr["cncn_6"].ToString(),
                    cncn_7 = dr["cncn_7"].ToString(),
                    cncn_8 = dr["cncn_8"].ToString(),
                    cncn_9 = dr["cncn_9"].ToString(),
                    cncn_10 = dr["cncn_10"].ToString(),
                    cncn_11 = dr["cncn_11"].ToString(),
                    cncn_12 = dr["cncn_12"].ToString(),
                    cncn_13 = dr["cncn_13"].ToString(),
                    cncn_14 = dr["cncn_14"].ToString(),
                    cncn_15 = dr["cncn_15"].ToString(),
                    cncn_chk = dr["cncn_chk"].ToString(),
                    cncn_date1 = Convert.ToDateTime(dr["cncn_date1"].ToString()),
                    cncn_date2 = Convert.ToDateTime(dr["cncn_date2"].ToString()),
                    cncn_date_created = Convert.ToDateTime(dr["cncn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Nextcare> GetAllPreNextcare(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Nextcare> sclist = new List<BusinessEntities.EMRForms.Nextcare>();
            DataTable dt = DataAccessLayer.EMRForms.Nextcare.GetAllPreNextcare(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Nextcare
                {
                    cncnId = Convert.ToInt32(dr["cncnId"]),
                    cncn_appId = Convert.ToInt32(dr["cncn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }       

        //print
        public static List<BusinessEntities.EMRForms.Nextcare> GetPrintNextcare(int? cncnId)
        {
            List<BusinessEntities.EMRForms.Nextcare> sclist = new List<BusinessEntities.EMRForms.Nextcare>();
            DataTable dt = DataAccessLayer.EMRForms.Nextcare.GetPrintNextcare(cncnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Nextcare
                    {
                        cncnId = Convert.ToInt32(dr["cncnId"]),
                        cncn_appId = Convert.ToInt32(dr["cncn_appId"]),
                        cncn_1 = dr["cncn_1"].ToString(),
                        cncn_2 = dr["cncn_2"].ToString(),
                        cncn_3 = dr["cncn_3"].ToString(),
                        cncn_4 = dr["cncn_4"].ToString(),
                        cncn_5 = dr["cncn_5"].ToString(),
                        cncn_6 = dr["cncn_6"].ToString(),
                        cncn_7 = dr["cncn_7"].ToString(),
                        cncn_8 = dr["cncn_8"].ToString(),
                        cncn_9 = dr["cncn_9"].ToString(),
                        cncn_10 = dr["cncn_10"].ToString(),
                        cncn_11 = dr["cncn_11"].ToString(),
                        cncn_12 = dr["cncn_12"].ToString(),
                        cncn_13 = dr["cncn_13"].ToString(),
                        cncn_14 = dr["cncn_14"].ToString(),
                        cncn_15 = dr["cncn_15"].ToString(),
                        cncn_chk = dr["cncn_chk"].ToString(),

                        cncn_d1 = (dt.Rows[0]["cncn_date1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cncn_date1"].ToString(),
                        cncn_d2 = (dt.Rows[0]["cncn_date2"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cncn_date2"].ToString(),
                        cncn_date_created = Convert.ToDateTime(dr["cncn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Nextcare a = new BusinessEntities.EMRForms.Nextcare();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Nextcare (Page Load)

        #region Nextcare (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNextcare(BusinessEntities.EMRForms.Nextcare data)
        {
            data.cncn_1 = string.IsNullOrEmpty(data.cncn_1) ? string.Empty : data.cncn_1;
            data.cncn_2 = string.IsNullOrEmpty(data.cncn_2) ? string.Empty : data.cncn_2;
            data.cncn_3 = string.IsNullOrEmpty(data.cncn_3) ? string.Empty : data.cncn_3;
            data.cncn_4 = string.IsNullOrEmpty(data.cncn_4) ? string.Empty : data.cncn_4;
            data.cncn_5 = string.IsNullOrEmpty(data.cncn_5) ? string.Empty : data.cncn_5;
            data.cncn_6 = string.IsNullOrEmpty(data.cncn_6) ? string.Empty : data.cncn_6;
            data.cncn_7 = string.IsNullOrEmpty(data.cncn_7) ? string.Empty : data.cncn_7;
            data.cncn_8 = string.IsNullOrEmpty(data.cncn_8) ? string.Empty : data.cncn_8;
            data.cncn_9 = string.IsNullOrEmpty(data.cncn_9) ? string.Empty : data.cncn_9;
            data.cncn_10 = string.IsNullOrEmpty(data.cncn_10) ? string.Empty : data.cncn_10;
            data.cncn_11 = string.IsNullOrEmpty(data.cncn_11) ? string.Empty : data.cncn_11;
            data.cncn_12 = string.IsNullOrEmpty(data.cncn_12) ? string.Empty : data.cncn_12;
            data.cncn_13 = string.IsNullOrEmpty(data.cncn_13) ? string.Empty : data.cncn_13;
            data.cncn_14 = string.IsNullOrEmpty(data.cncn_14) ? string.Empty : data.cncn_14;
            data.cncn_15 = string.IsNullOrEmpty(data.cncn_15) ? string.Empty : data.cncn_15;
            data.cncn_chk = string.IsNullOrEmpty(data.cncn_chk) ? string.Empty : data.cncn_chk;
            DateTime? card21 = data.cncn_date1; // Assuming data.cncn_d1 is of type DateTime?            
            DateTime? card22 = data.cncn_date2; // Assuming data.cncn_d2 is of type DateTime?
          
            if (data.cncn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cncn_date1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cncn_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cncn_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cncn_date2 = card22.HasValue ? card22.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cncn_date2 = DateTime.Parse("01/01/1950");
            }
            
            return DataAccessLayer.EMRForms.Nextcare.InsertUpdateNextcare(data);
        }
        //Delete
        public static int DeleteNextcare(int cncnId, int cncn_madeby)
        {
            return DataAccessLayer.EMRForms.Nextcare.DeleteNextcare(cncnId, cncn_madeby);
        }
        #endregion Nextcare (CRUD Operations)
    }

    public class Alkhazna
    {
        #region Alkhazna (Page Load)
        public static List<BusinessEntities.EMRForms.Alkhazna> GetAllAlkhazna(int appId)
        {
            List<BusinessEntities.EMRForms.Alkhazna> sclist = new List<BusinessEntities.EMRForms.Alkhazna>();
            DataTable dt = DataAccessLayer.EMRForms.Alkhazna.GetAllAlkhazna(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Alkhazna
                {
                    ckneId = Convert.ToInt32(dr["ckneId"]),
                    ckne_appId = Convert.ToInt32(dr["ckne_appId"]),
                    ckne_chk = dr["ckne_chk"].ToString(),
                    ckne_1 = dr["ckne_1"].ToString(),
                    ckne_2 = dr["ckne_2"].ToString(),
                    ckne_3 = dr["ckne_3"].ToString(),
                    ckne_4 = dr["ckne_4"].ToString(),
                    ckne_5 = dr["ckne_5"].ToString(),
                    ckne_6 = dr["ckne_6"].ToString(),
                    ckne_7 = dr["ckne_7"].ToString(),
                    ckne_8 = dr["ckne_8"].ToString(),
                    ckne_9 = dr["ckne_9"].ToString(),
                    ckne_10 = dr["ckne_10"].ToString(),
                    ckne_11 = dr["ckne_11"].ToString(),
                    ckne_12 = dr["ckne_12"].ToString(),
                    ckne_13 = dr["ckne_13"].ToString(),
                    ckne_14 = dr["ckne_14"].ToString(),
                    ckne_15 = dr["ckne_15"].ToString(),
                    ckne_16 = dr["ckne_16"].ToString(),
                    ckne_17 = dr["ckne_17"].ToString(),
                    ckne_18 = dr["ckne_18"].ToString(),
                    ckne_19 = dr["ckne_19"].ToString(),
                    ckne_20 = dr["ckne_20"].ToString(),
                    ckne_21 = dr["ckne_21"].ToString(),
                    ckne_22 = dr["ckne_22"].ToString(),
                    ckne_23 = dr["ckne_23"].ToString(),
                    ckne_24 = dr["ckne_24"].ToString(),
                    ckne_25 = dr["ckne_25"].ToString(),
                    ckne_26 = dr["ckne_26"].ToString(),
                    ckne_27 = dr["ckne_27"].ToString(),
                    ckne_28 = dr["ckne_28"].ToString(),
                    ckne_29 = dr["ckne_29"].ToString(),
                    ckne_30 = dr["ckne_30"].ToString(),
                    ckne_31 = dr["ckne_31"].ToString(),
                    ckne_32 = dr["ckne_32"].ToString(),
                    ckne_33 = dr["ckne_33"].ToString(),
                    ckne_34 = dr["ckne_34"].ToString(),
                    ckne_35 = dr["ckne_35"].ToString(),                    
                    ckne_date1 = Convert.ToDateTime(dr["ckne_date1"].ToString()),
                    ckne_date2 = Convert.ToDateTime(dr["ckne_date2"].ToString()),
                    ckne_date_created = Convert.ToDateTime(dr["ckne_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Alkhazna> GetAllPreAlkhazna(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Alkhazna> sclist = new List<BusinessEntities.EMRForms.Alkhazna>();
            DataTable dt = DataAccessLayer.EMRForms.Alkhazna.GetAllPreAlkhazna(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Alkhazna
                {
                    ckneId = Convert.ToInt32(dr["ckneId"]),
                    ckne_appId = Convert.ToInt32(dr["ckne_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        
        //print
        public static List<BusinessEntities.EMRForms.Alkhazna> GetPrintAlkhazna(int? ckneId)
        {
            List<BusinessEntities.EMRForms.Alkhazna> sclist = new List<BusinessEntities.EMRForms.Alkhazna>();
            DataTable dt = DataAccessLayer.EMRForms.Alkhazna.GetPrintAlkhazna(ckneId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Alkhazna
                    {
                        ckneId = Convert.ToInt32(dr["ckneId"]),
                        ckne_appId = Convert.ToInt32(dr["ckne_appId"]),
                        ckne_chk = dr["ckne_chk"].ToString(),
                        ckne_1 = dr["ckne_1"].ToString(),
                        ckne_2 = dr["ckne_2"].ToString(),
                        ckne_3 = dr["ckne_3"].ToString(),
                        ckne_4 = dr["ckne_4"].ToString(),
                        ckne_5 = dr["ckne_5"].ToString(),
                        ckne_6 = dr["ckne_6"].ToString(),
                        ckne_7 = dr["ckne_7"].ToString(),
                        ckne_8 = dr["ckne_8"].ToString(),
                        ckne_9 = dr["ckne_9"].ToString(),
                        ckne_10 = dr["ckne_10"].ToString(),
                        ckne_11 = dr["ckne_11"].ToString(),
                        ckne_12 = dr["ckne_12"].ToString(),
                        ckne_13 = dr["ckne_13"].ToString(),
                        ckne_14 = dr["ckne_14"].ToString(),
                        ckne_15 = dr["ckne_15"].ToString(),
                        ckne_16 = dr["ckne_16"].ToString(),
                        ckne_17 = dr["ckne_17"].ToString(),
                        ckne_18 = dr["ckne_18"].ToString(),
                        ckne_19 = dr["ckne_19"].ToString(),
                        ckne_20 = dr["ckne_20"].ToString(),
                        ckne_21 = dr["ckne_21"].ToString(),
                        ckne_22 = dr["ckne_22"].ToString(),
                        ckne_23 = dr["ckne_23"].ToString(),
                        ckne_24 = dr["ckne_24"].ToString(),
                        ckne_25 = dr["ckne_25"].ToString(),
                        ckne_26 = dr["ckne_26"].ToString(),
                        ckne_27 = dr["ckne_27"].ToString(),
                        ckne_28 = dr["ckne_28"].ToString(),
                        ckne_29 = dr["ckne_29"].ToString(),
                        ckne_30 = dr["ckne_30"].ToString(),
                        ckne_31 = dr["ckne_31"].ToString(),
                        ckne_32 = dr["ckne_32"].ToString(),
                        ckne_33 = dr["ckne_33"].ToString(),
                        ckne_34 = dr["ckne_34"].ToString(),
                        ckne_35 = dr["ckne_35"].ToString(),
                        ckne_dd1 = dr["ckne_date1"].ToString(),
                        ckne_dd2 = dr["ckne_date2"].ToString(),
                        ckne_date_created = Convert.ToDateTime(dr["ckne_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Alkhazna a = new BusinessEntities.EMRForms.Alkhazna();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Alkhazna (Page Load)

        #region Alkhazna (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAlkhazna(BusinessEntities.EMRForms.Alkhazna data)
        {
            data.ckne_chk = string.IsNullOrEmpty(data.ckne_chk) ? string.Empty : data.ckne_chk;
            data.ckne_1 = string.IsNullOrEmpty(data.ckne_1) ? string.Empty : data.ckne_1;
            data.ckne_2 = string.IsNullOrEmpty(data.ckne_2) ? string.Empty : data.ckne_2;
            data.ckne_3 = string.IsNullOrEmpty(data.ckne_3) ? string.Empty : data.ckne_3;
            data.ckne_4 = string.IsNullOrEmpty(data.ckne_4) ? string.Empty : data.ckne_4;
            data.ckne_5 = string.IsNullOrEmpty(data.ckne_5) ? string.Empty : data.ckne_5;
            data.ckne_6 = string.IsNullOrEmpty(data.ckne_6) ? string.Empty : data.ckne_6;
            data.ckne_7 = string.IsNullOrEmpty(data.ckne_7) ? string.Empty : data.ckne_7;
            data.ckne_8 = string.IsNullOrEmpty(data.ckne_8) ? string.Empty : data.ckne_8;
            data.ckne_9 = string.IsNullOrEmpty(data.ckne_9) ? string.Empty : data.ckne_9;
            data.ckne_10 = string.IsNullOrEmpty(data.ckne_10) ? string.Empty : data.ckne_10;
            data.ckne_11 = string.IsNullOrEmpty(data.ckne_11) ? string.Empty : data.ckne_11;
            data.ckne_12 = string.IsNullOrEmpty(data.ckne_12) ? string.Empty : data.ckne_12;
            data.ckne_13 = string.IsNullOrEmpty(data.ckne_13) ? string.Empty : data.ckne_13;
            data.ckne_14 = string.IsNullOrEmpty(data.ckne_14) ? string.Empty : data.ckne_14;
            data.ckne_15 = string.IsNullOrEmpty(data.ckne_15) ? string.Empty : data.ckne_15;
            data.ckne_16 = string.IsNullOrEmpty(data.ckne_16) ? string.Empty : data.ckne_16;
            data.ckne_17 = string.IsNullOrEmpty(data.ckne_17) ? string.Empty : data.ckne_17;
            data.ckne_18 = string.IsNullOrEmpty(data.ckne_18) ? string.Empty : data.ckne_18;
            data.ckne_19 = string.IsNullOrEmpty(data.ckne_19) ? string.Empty : data.ckne_19;
            data.ckne_20 = string.IsNullOrEmpty(data.ckne_20) ? string.Empty : data.ckne_20;
            data.ckne_21 = string.IsNullOrEmpty(data.ckne_21) ? string.Empty : data.ckne_21;
            data.ckne_22 = string.IsNullOrEmpty(data.ckne_22) ? string.Empty : data.ckne_22;
            data.ckne_23 = string.IsNullOrEmpty(data.ckne_23) ? string.Empty : data.ckne_23;
            data.ckne_24 = string.IsNullOrEmpty(data.ckne_24) ? string.Empty : data.ckne_24;
            data.ckne_25 = string.IsNullOrEmpty(data.ckne_25) ? string.Empty : data.ckne_25;
            data.ckne_26 = string.IsNullOrEmpty(data.ckne_26) ? string.Empty : data.ckne_26;
            data.ckne_27 = string.IsNullOrEmpty(data.ckne_27) ? string.Empty : data.ckne_27;
            data.ckne_28 = string.IsNullOrEmpty(data.ckne_28) ? string.Empty : data.ckne_28;
            data.ckne_29 = string.IsNullOrEmpty(data.ckne_29) ? string.Empty : data.ckne_29;
            data.ckne_30 = string.IsNullOrEmpty(data.ckne_30) ? string.Empty : data.ckne_30;
            data.ckne_31 = string.IsNullOrEmpty(data.ckne_31) ? string.Empty : data.ckne_31;
            data.ckne_32 = string.IsNullOrEmpty(data.ckne_32) ? string.Empty : data.ckne_32;
            data.ckne_33 = string.IsNullOrEmpty(data.ckne_33) ? string.Empty : data.ckne_33;
            data.ckne_34 = string.IsNullOrEmpty(data.ckne_34) ? string.Empty : data.ckne_34;
            data.ckne_35 = string.IsNullOrEmpty(data.ckne_35) ? string.Empty : data.ckne_35;
            DateTime? card1 = data.ckne_date1; // Assuming data.ckne_date1 is of type DateTime?            
            DateTime? card2 = data.ckne_date2; // Assuming data.ckne_date2 is of type DateTime?
            if (data.ckne_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.ckne_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.ckne_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.ckne_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.ckne_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.ckne_date2 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.Alkhazna.InsertUpdateAlkhazna(data);
        }
        //Delete
        public static int DeleteAlkhazna(int ckneId, int ckne_madeby)
        {
            return DataAccessLayer.EMRForms.Alkhazna.DeleteAlkhazna(ckneId, ckne_madeby);
        }
        #endregion Alkhazna (CRUD Operations)
    }

    public class ArabOrient
    {
        #region ArabOrient (Page Load)
        public static List<BusinessEntities.EMRForms.ArabOrient> GetAllArabOrient(int appId)
        {
            List<BusinessEntities.EMRForms.ArabOrient> sclist = new List<BusinessEntities.EMRForms.ArabOrient>();
            DataTable dt = DataAccessLayer.EMRForms.ArabOrient.GetAllArabOrient(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.ArabOrient
                {
                    caonId = Convert.ToInt32(dr["caonId"]),
                    caon_appId = Convert.ToInt32(dr["caon_appId"]),
                    caon_chk = dr["caon_chk"].ToString(),
                    caon_1 = dr["caon_1"].ToString(),
                    caon_2 = dr["caon_2"].ToString(),
                    caon_3 = dr["caon_3"].ToString(),
                    caon_4 = dr["caon_4"].ToString(),
                    caon_5 = dr["caon_5"].ToString(),
                    caon_6 = dr["caon_6"].ToString(),
                    caon_7 = dr["caon_7"].ToString(),
                    caon_8 = dr["caon_8"].ToString(),
                    caon_9 = dr["caon_9"].ToString(),
                    caon_10 = dr["caon_10"].ToString(),
                    caon_11 = dr["caon_11"].ToString(),
                    caon_12 = dr["caon_12"].ToString(),
                    caon_13 = dr["caon_13"].ToString(),
                    caon_14 = dr["caon_14"].ToString(),
                    caon_15 = dr["caon_15"].ToString(),
                    caon_16 = dr["caon_16"].ToString(),
                    caon_17 = dr["caon_17"].ToString(),
                    caon_18 = dr["caon_18"].ToString(),
                    caon_19 = dr["caon_19"].ToString(),
                    caon_20 = dr["caon_20"].ToString(),
                    caon_21 = dr["caon_21"].ToString(),
                    caon_22 = Convert.ToDateTime(dr["caon_22"].ToString()),
                    caon_date_created = Convert.ToDateTime(dr["caon_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.ArabOrient> GetAllPreArabOrient(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.ArabOrient> sclist = new List<BusinessEntities.EMRForms.ArabOrient>();
            DataTable dt = DataAccessLayer.EMRForms.ArabOrient.GetAllPreArabOrient(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.ArabOrient
                {
                    caonId = Convert.ToInt32(dr["caonId"]),
                    caon_appId = Convert.ToInt32(dr["caon_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.ArabOrient> GetPrintArabOrient(int? caonId)
        {
            List<BusinessEntities.EMRForms.ArabOrient> sclist = new List<BusinessEntities.EMRForms.ArabOrient>();
            DataTable dt = DataAccessLayer.EMRForms.ArabOrient.GetPrintArabOrient(caonId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.ArabOrient
                    {
                        caonId = Convert.ToInt32(dr["caonId"]),
                        caon_appId = Convert.ToInt32(dr["caon_appId"]),
                        caon_chk = dr["caon_chk"].ToString(),
                        caon_1 = dr["caon_1"].ToString(),
                        caon_2 = dr["caon_2"].ToString(),
                        caon_3 = dr["caon_3"].ToString(),
                        caon_4 = dr["caon_4"].ToString(),
                        caon_5 = dr["caon_5"].ToString(),
                        caon_6 = dr["caon_6"].ToString(),
                        caon_7 = dr["caon_7"].ToString(),
                        caon_8 = dr["caon_8"].ToString(),
                        caon_9 = dr["caon_9"].ToString(),
                        caon_10 = dr["caon_10"].ToString(),
                        caon_11 = dr["caon_11"].ToString(),
                        caon_12 = dr["caon_12"].ToString(),
                        caon_13 = dr["caon_13"].ToString(),
                        caon_14 = dr["caon_14"].ToString(),
                        caon_15 = dr["caon_15"].ToString(),
                        caon_16 = dr["caon_16"].ToString(),
                        caon_17 = dr["caon_17"].ToString(),
                        caon_18 = dr["caon_18"].ToString(),
                        caon_19 = dr["caon_19"].ToString(),
                        caon_20 = dr["caon_20"].ToString(),
                        caon_21 = dr["caon_21"].ToString(),
                        caon_dd22 = dr["caon_22"].ToString(),
                        caon_date_created = Convert.ToDateTime(dr["caon_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.ArabOrient a = new BusinessEntities.EMRForms.ArabOrient();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion ArabOrient (Page Load)

        #region ArabOrient (CRUD Operations)
        //insert&update
        public static bool InsertUpdateArabOrient(BusinessEntities.EMRForms.ArabOrient data)
        {
            data.caon_chk = string.IsNullOrEmpty(data.caon_chk) ? string.Empty : data.caon_chk;
            data.caon_1 = string.IsNullOrEmpty(data.caon_1) ? string.Empty : data.caon_1;
            data.caon_2 = string.IsNullOrEmpty(data.caon_2) ? string.Empty : data.caon_2;
            data.caon_3 = string.IsNullOrEmpty(data.caon_3) ? string.Empty : data.caon_3;
            data.caon_4 = string.IsNullOrEmpty(data.caon_4) ? string.Empty : data.caon_4;
            data.caon_5 = string.IsNullOrEmpty(data.caon_5) ? string.Empty : data.caon_5;
            data.caon_6 = string.IsNullOrEmpty(data.caon_6) ? string.Empty : data.caon_6;
            data.caon_7 = string.IsNullOrEmpty(data.caon_7) ? string.Empty : data.caon_7;
            data.caon_8 = string.IsNullOrEmpty(data.caon_8) ? string.Empty : data.caon_8;
            data.caon_9 = string.IsNullOrEmpty(data.caon_9) ? string.Empty : data.caon_9;
            data.caon_10 = string.IsNullOrEmpty(data.caon_10) ? string.Empty : data.caon_10;
            data.caon_11 = string.IsNullOrEmpty(data.caon_11) ? string.Empty : data.caon_11;
            data.caon_12 = string.IsNullOrEmpty(data.caon_12) ? string.Empty : data.caon_12;
            data.caon_13 = string.IsNullOrEmpty(data.caon_13) ? string.Empty : data.caon_13;
            data.caon_14 = string.IsNullOrEmpty(data.caon_14) ? string.Empty : data.caon_14;
            data.caon_15 = string.IsNullOrEmpty(data.caon_15) ? string.Empty : data.caon_15;
            data.caon_16 = string.IsNullOrEmpty(data.caon_16) ? string.Empty : data.caon_16;
            data.caon_17 = string.IsNullOrEmpty(data.caon_17) ? string.Empty : data.caon_17;
            data.caon_18 = string.IsNullOrEmpty(data.caon_18) ? string.Empty : data.caon_18;
            data.caon_19 = string.IsNullOrEmpty(data.caon_19) ? string.Empty : data.caon_19;
            data.caon_20 = string.IsNullOrEmpty(data.caon_20) ? string.Empty : data.caon_20;
            data.caon_21 = string.IsNullOrEmpty(data.caon_21) ? string.Empty : data.caon_21;
            DateTime? card1 = data.caon_22; // Assuming data.caon_date1 is of type DateTime?    
            if (data.caon_22 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.caon_22 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.caon_22 = DateTime.Parse("01/01/1950");
            }
           
            return DataAccessLayer.EMRForms.ArabOrient.InsertUpdateArabOrient(data);
        }
        //Delete
        public static int DeleteArabOrient(int caonId, int caon_madeby)
        {
            return DataAccessLayer.EMRForms.ArabOrient.DeleteArabOrient(caonId, caon_madeby);
        }
        #endregion ArabOrient (CRUD Operations)
    }

    public class EmiratesDental
    {
        #region EmiratesDental (Page Load)
        public static List<BusinessEntities.EMRForms.EmiratesDental> GetAllEmiratesDental(int appId)
        {
            List<BusinessEntities.EMRForms.EmiratesDental> sclist = new List<BusinessEntities.EMRForms.EmiratesDental>();
            DataTable dt = DataAccessLayer.EMRForms.EmiratesDental.GetAllEmiratesDental(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.EmiratesDental
                {
                    emdnId = Convert.ToInt32(dr["emdnId"]),
                    emdn_appId = Convert.ToInt32(dr["emdn_appId"]),
                    emdn_chk = dr["emdn_chk"].ToString(),
                    emdn_1 = dr["emdn_1"].ToString(),
                    emdn_2 = dr["emdn_2"].ToString(),
                    emdn_3 = dr["emdn_3"].ToString(),
                    emdn_4 = dr["emdn_4"].ToString(),
                    emdn_5 = dr["emdn_5"].ToString(),
                    emdn_6 = dr["emdn_6"].ToString(),
                    emdn_7 = dr["emdn_7"].ToString(),
                    emdn_8 = dr["emdn_8"].ToString(),
                    emdn_9 = dr["emdn_9"].ToString(),
                    emdn_10 = dr["emdn_10"].ToString(),
                    emdn_11 = dr["emdn_11"].ToString(),
                    emdn_12 = dr["emdn_12"].ToString(),
                    emdn_13 = dr["emdn_13"].ToString(),
                    emdn_14 = dr["emdn_14"].ToString(),
                    emdn_15 = dr["emdn_15"].ToString(),
                    emdn_16 = dr["emdn_16"].ToString(),
                    emdn_17 = dr["emdn_17"].ToString(),
                    emdn_18 = dr["emdn_18"].ToString(),
                    emdn_19 = dr["emdn_19"].ToString(),
                    emdn_20 = dr["emdn_20"].ToString(),
                    emdn_21 = dr["emdn_21"].ToString(),
                    emdn_22 = dr["emdn_22"].ToString(),
                    emdn_23 = dr["emdn_23"].ToString(),
                    emdn_24 = dr["emdn_24"].ToString(),
                    emdn_25 = dr["emdn_25"].ToString(),
                    emdn_26 = dr["emdn_26"].ToString(),
                    emdn_27 = dr["emdn_27"].ToString(),
                    emdn_28 = dr["emdn_28"].ToString(),
                    emdn_29 = dr["emdn_29"].ToString(),
                    emdn_30 = dr["emdn_30"].ToString(),
                    emdn_31 = dr["emdn_31"].ToString(),
                    emdn_32 = dr["emdn_32"].ToString(),
                    emdn_33 = dr["emdn_33"].ToString(),
                    emdn_34 = dr["emdn_34"].ToString(),
                    emdn_35 = dr["emdn_35"].ToString(),
                    emdn_date_created = Convert.ToDateTime(dr["emdn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.EmiratesDental> GetAllPreEmiratesDental(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.EmiratesDental> sclist = new List<BusinessEntities.EMRForms.EmiratesDental>();
            DataTable dt = DataAccessLayer.EMRForms.EmiratesDental.GetAllPreEmiratesDental(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.EmiratesDental
                {
                    emdnId = Convert.ToInt32(dr["emdnId"]),
                    emdn_appId = Convert.ToInt32(dr["emdn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.EmiratesDental> GetPrintEmiratesDental(int? emdnId)
        {
            List<BusinessEntities.EMRForms.EmiratesDental> sclist = new List<BusinessEntities.EMRForms.EmiratesDental>();
            DataTable dt = DataAccessLayer.EMRForms.EmiratesDental.GetPrintEmiratesDental(emdnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.EmiratesDental
                    {
                        emdnId = Convert.ToInt32(dr["emdnId"]),
                        emdn_appId = Convert.ToInt32(dr["emdn_appId"]),
                        emdn_chk = dr["emdn_chk"].ToString(),
                        emdn_1 = dr["emdn_1"].ToString(),
                        emdn_2 = dr["emdn_2"].ToString(),
                        emdn_3 = dr["emdn_3"].ToString(),
                        emdn_4 = dr["emdn_4"].ToString(),
                        emdn_5 = dr["emdn_5"].ToString(),
                        emdn_6 = dr["emdn_6"].ToString(),
                        emdn_7 = dr["emdn_7"].ToString(),
                        emdn_8 = dr["emdn_8"].ToString(),
                        emdn_9 = dr["emdn_9"].ToString(),
                        emdn_10 = dr["emdn_10"].ToString(),
                        emdn_11 = dr["emdn_11"].ToString(),
                        emdn_12 = dr["emdn_12"].ToString(),
                        emdn_13 = dr["emdn_13"].ToString(),
                        emdn_14 = dr["emdn_14"].ToString(),
                        emdn_15 = dr["emdn_15"].ToString(),
                        emdn_16 = dr["emdn_16"].ToString(),
                        emdn_17 = dr["emdn_17"].ToString(),
                        emdn_18 = dr["emdn_18"].ToString(),
                        emdn_19 = dr["emdn_19"].ToString(),
                        emdn_20 = dr["emdn_20"].ToString(),
                        emdn_21 = dr["emdn_21"].ToString(),
                        emdn_22 = dr["emdn_22"].ToString(),
                        emdn_23 = dr["emdn_23"].ToString(),
                        emdn_24 = dr["emdn_24"].ToString(),
                        emdn_25 = dr["emdn_25"].ToString(),
                        emdn_26 = dr["emdn_26"].ToString(),
                        emdn_27 = dr["emdn_27"].ToString(),
                        emdn_28 = dr["emdn_28"].ToString(),
                        emdn_29 = dr["emdn_29"].ToString(),
                        emdn_30 = dr["emdn_30"].ToString(),
                        emdn_31 = dr["emdn_31"].ToString(),
                        emdn_32 = dr["emdn_32"].ToString(),
                        emdn_33 = dr["emdn_33"].ToString(),
                        emdn_34 = dr["emdn_34"].ToString(),
                        emdn_35 = dr["emdn_35"].ToString(),
                        emdn_date_created = Convert.ToDateTime(dr["emdn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.EmiratesDental a = new BusinessEntities.EMRForms.EmiratesDental();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion EmiratesDental (Page Load)

        #region EmiratesDental (CRUD Operations)
        //insert&update
        public static bool InsertUpdateEmiratesDental(BusinessEntities.EMRForms.EmiratesDental data)
        {
            data.emdn_chk = string.IsNullOrEmpty(data.emdn_chk) ? string.Empty : data.emdn_chk;
            data.emdn_1 = string.IsNullOrEmpty(data.emdn_1) ? string.Empty : data.emdn_1;
            data.emdn_2 = string.IsNullOrEmpty(data.emdn_2) ? string.Empty : data.emdn_2;
            data.emdn_3 = string.IsNullOrEmpty(data.emdn_3) ? string.Empty : data.emdn_3;
            data.emdn_4 = string.IsNullOrEmpty(data.emdn_4) ? string.Empty : data.emdn_4;
            data.emdn_5 = string.IsNullOrEmpty(data.emdn_5) ? string.Empty : data.emdn_5;
            data.emdn_6 = string.IsNullOrEmpty(data.emdn_6) ? string.Empty : data.emdn_6;
            data.emdn_7 = string.IsNullOrEmpty(data.emdn_7) ? string.Empty : data.emdn_7;
            data.emdn_8 = string.IsNullOrEmpty(data.emdn_8) ? string.Empty : data.emdn_8;
            data.emdn_9 = string.IsNullOrEmpty(data.emdn_9) ? string.Empty : data.emdn_9;
            data.emdn_10 = string.IsNullOrEmpty(data.emdn_10) ? string.Empty : data.emdn_10;
            data.emdn_11 = string.IsNullOrEmpty(data.emdn_11) ? string.Empty : data.emdn_11;
            data.emdn_12 = string.IsNullOrEmpty(data.emdn_12) ? string.Empty : data.emdn_12;
            data.emdn_13 = string.IsNullOrEmpty(data.emdn_13) ? string.Empty : data.emdn_13;
            data.emdn_14 = string.IsNullOrEmpty(data.emdn_14) ? string.Empty : data.emdn_14;
            data.emdn_15 = string.IsNullOrEmpty(data.emdn_15) ? string.Empty : data.emdn_15;
            data.emdn_16 = string.IsNullOrEmpty(data.emdn_16) ? string.Empty : data.emdn_16;
            data.emdn_17 = string.IsNullOrEmpty(data.emdn_17) ? string.Empty : data.emdn_17;
            data.emdn_18 = string.IsNullOrEmpty(data.emdn_18) ? string.Empty : data.emdn_18;
            data.emdn_19 = string.IsNullOrEmpty(data.emdn_19) ? string.Empty : data.emdn_19;
            data.emdn_20 = string.IsNullOrEmpty(data.emdn_20) ? string.Empty : data.emdn_20;
            data.emdn_21 = string.IsNullOrEmpty(data.emdn_21) ? string.Empty : data.emdn_21;
            data.emdn_22 = string.IsNullOrEmpty(data.emdn_22) ? string.Empty : data.emdn_22;
            data.emdn_23 = string.IsNullOrEmpty(data.emdn_23) ? string.Empty : data.emdn_23;
            data.emdn_24 = string.IsNullOrEmpty(data.emdn_24) ? string.Empty : data.emdn_24;
            data.emdn_25 = string.IsNullOrEmpty(data.emdn_25) ? string.Empty : data.emdn_25;
            data.emdn_26 = string.IsNullOrEmpty(data.emdn_26) ? string.Empty : data.emdn_26;
            data.emdn_27 = string.IsNullOrEmpty(data.emdn_27) ? string.Empty : data.emdn_27;
            data.emdn_28 = string.IsNullOrEmpty(data.emdn_28) ? string.Empty : data.emdn_28;
            data.emdn_29 = string.IsNullOrEmpty(data.emdn_29) ? string.Empty : data.emdn_29;
            data.emdn_30 = string.IsNullOrEmpty(data.emdn_30) ? string.Empty : data.emdn_30;
            data.emdn_31 = string.IsNullOrEmpty(data.emdn_31) ? string.Empty : data.emdn_31;
            data.emdn_32 = string.IsNullOrEmpty(data.emdn_32) ? string.Empty : data.emdn_32;
            data.emdn_33 = string.IsNullOrEmpty(data.emdn_33) ? string.Empty : data.emdn_33;
            data.emdn_34 = string.IsNullOrEmpty(data.emdn_34) ? string.Empty : data.emdn_34;
            data.emdn_35 = string.IsNullOrEmpty(data.emdn_35) ? string.Empty : data.emdn_35;
           
            return DataAccessLayer.EMRForms.EmiratesDental.InsertUpdateEmiratesDental(data);
        }
        //Delete
        public static int DeleteEmiratesDental(int emdnId, int emdn_madeby)
        {
            return DataAccessLayer.EMRForms.EmiratesDental.DeleteEmiratesDental(emdnId, emdn_madeby);
        }
        #endregion EmiratesDental (CRUD Operations)
    }
    public class MednetTakaful
    {
        #region MednetTakaful (Page Load)
        public static List<BusinessEntities.EMRForms.MednetTakaful> GetAllMednetTakaful(int appId)
        {
            List<BusinessEntities.EMRForms.MednetTakaful> sclist = new List<BusinessEntities.EMRForms.MednetTakaful>();
            DataTable dt = DataAccessLayer.EMRForms.MednetTakaful.GetAllMednetTakaful(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.MednetTakaful
                {
                    cmtnId = Convert.ToInt32(dr["cmtnId"]),
                    cmtn_appId = Convert.ToInt32(dr["cmtn_appId"]),
                    cmtn_1 = dr["cmtn_1"].ToString(),
                    cmtn_2 = dr["cmtn_2"].ToString(),
                    cmtn_3 = dr["cmtn_3"].ToString(),
                    cmtn_4 = dr["cmtn_4"].ToString(),
                    cmtn_5 = dr["cmtn_5"].ToString(),
                    cmtn_6 = dr["cmtn_6"].ToString(),
                    cmtn_7 = dr["cmtn_7"].ToString(),
                    cmtn_chk = dr["cmtn_chk"].ToString(),
                    cmtn_date1 = Convert.ToDateTime(dr["cmtn_date1"].ToString()),
                    cmtn_date2 = Convert.ToDateTime(dr["cmtn_date2"].ToString()),
                    cmtn_date3 = Convert.ToDateTime(dr["cmtn_date3"].ToString()),
                    cmtn_date_created = Convert.ToDateTime(dr["cmtn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.MednetTakaful> GetAllPreMednetTakaful(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.MednetTakaful> sclist = new List<BusinessEntities.EMRForms.MednetTakaful>();
            DataTable dt = DataAccessLayer.EMRForms.MednetTakaful.GetAllPreMednetTakaful(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.MednetTakaful
                {
                    cmtnId = Convert.ToInt32(dr["cmtnId"]),
                    cmtn_appId = Convert.ToInt32(dr["cmtn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }


        //print
        public static List<BusinessEntities.EMRForms.MednetTakaful> GetPrintMednetTakaful(int? cmtnId)
        {
            List<BusinessEntities.EMRForms.MednetTakaful> sclist = new List<BusinessEntities.EMRForms.MednetTakaful>();
            DataTable dt = DataAccessLayer.EMRForms.MednetTakaful.GetPrintMednetTakaful(cmtnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.MednetTakaful
                    {
                        cmtnId = Convert.ToInt32(dr["cmtnId"]),
                        cmtn_appId = Convert.ToInt32(dr["cmtn_appId"]),
                        cmtn_1 = dr["cmtn_1"].ToString(),
                        cmtn_2 = dr["cmtn_2"].ToString(),
                        cmtn_3 = dr["cmtn_3"].ToString(),
                        cmtn_4 = dr["cmtn_4"].ToString(),
                        cmtn_5 = dr["cmtn_5"].ToString(),
                        cmtn_6 = dr["cmtn_6"].ToString(),
                        cmtn_7 = dr["cmtn_7"].ToString(),
                        cmtn_chk = dr["cmtn_chk"].ToString(),
                        cmtn_d21 = (dt.Rows[0]["cmtn_date1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cmtn_date1"].ToString(),
                        cmtn_d22 = (dt.Rows[0]["cmtn_date2"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cmtn_date2"].ToString(),
                        cmtn_d23 = (dt.Rows[0]["cmtn_date3"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["cmtn_date3"].ToString(),
                        cmtn_date_created = Convert.ToDateTime(dr["cmtn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),
                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.MednetTakaful a = new BusinessEntities.EMRForms.MednetTakaful();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion MednetTakaful (Page Load)

        #region MednetTakaful (CRUD Operations)
        //insert&update
        public static bool InsertUpdateMednetTakaful(BusinessEntities.EMRForms.MednetTakaful data)
        {
            data.cmtn_1 = string.IsNullOrEmpty(data.cmtn_1) ? string.Empty : data.cmtn_1;
            data.cmtn_2 = string.IsNullOrEmpty(data.cmtn_2) ? string.Empty : data.cmtn_2;
            data.cmtn_3 = string.IsNullOrEmpty(data.cmtn_3) ? string.Empty : data.cmtn_3;
            data.cmtn_4 = string.IsNullOrEmpty(data.cmtn_4) ? string.Empty : data.cmtn_4;
            data.cmtn_5 = string.IsNullOrEmpty(data.cmtn_5) ? string.Empty : data.cmtn_5;
            data.cmtn_6 = string.IsNullOrEmpty(data.cmtn_6) ? string.Empty : data.cmtn_6;
            data.cmtn_7 = string.IsNullOrEmpty(data.cmtn_7) ? string.Empty : data.cmtn_7;
            data.cmtn_chk = string.IsNullOrEmpty(data.cmtn_chk) ? string.Empty : data.cmtn_chk;
            DateTime? card21 = data.cmtn_date1; // Assuming data.cmtn_d1 is of type DateTime?            
            DateTime? card22 = data.cmtn_date2; // Assuming data.cmtn_d2 is of type DateTime?
            DateTime? card23 = data.cmtn_date3; // Assuming data.cmtn_d3 is of type DateTime?
            if (data.cmtn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cmtn_date1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cmtn_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cmtn_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cmtn_date2 = card22.HasValue ? card22.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cmtn_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.cmtn_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cmtn_date3 = card23.HasValue ? card23.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cmtn_date3 = DateTime.Parse("01/01/1950");
            }


            return DataAccessLayer.EMRForms.MednetTakaful.InsertUpdateMednetTakaful(data);
        }
        //Delete
        public static int DeleteMednetTakaful(int cmtnId, int cmtn_madeby)
        {
            return DataAccessLayer.EMRForms.MednetTakaful.DeleteMednetTakaful(cmtnId, cmtn_madeby);
        }
        #endregion MednetTakaful (CRUD Operations)
    }

    public class NASQIC
    {
        #region NASQIC (Page Load)
        public static List<BusinessEntities.EMRForms.NASQIC> GetAllNASQIC(int appId)
        {
            List<BusinessEntities.EMRForms.NASQIC> sclist = new List<BusinessEntities.EMRForms.NASQIC>();
            DataTable dt = DataAccessLayer.EMRForms.NASQIC.GetAllNASQIC(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NASQIC
                {
                    nasqId = Convert.ToInt32(dr["nasqId"]),
                    nasq_appId = Convert.ToInt32(dr["nasq_appId"]),
                    nasq_1 = dr["nasq_1"].ToString(),
                    nasq_2 = dr["nasq_2"].ToString(),
                    nasq_3 = dr["nasq_3"].ToString(),
                    nasq_4 = dr["nasq_4"].ToString(),
                    nasq_5 = dr["nasq_5"].ToString(),
                    nasq_6 = dr["nasq_6"].ToString(),
                    nasq_7 = dr["nasq_7"].ToString(),
                    nasq_8 = dr["nasq_8"].ToString(),
                    nasq_9 = dr["nasq_9"].ToString(),
                    nasq_10 = dr["nasq_10"].ToString(),
                    nasq_11 = dr["nasq_11"].ToString(),
                    nasq_12 = dr["nasq_12"].ToString(),
                    nasq_13 = dr["nasq_13"].ToString(),
                    nasq_14 = dr["nasq_14"].ToString(),
                    nasq_15 = dr["nasq_15"].ToString(),
                    nasq_16 = dr["nasq_16"].ToString(),
                    nasq_17 = dr["nasq_17"].ToString(),
                    nasq_18 = dr["nasq_18"].ToString(),
                    nasq_date1 = Convert.ToDateTime(dr["nasq_date1"].ToString()),
                    nasq_date_created = Convert.ToDateTime(dr["nasq_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NASQIC> GetAllPreNASQIC(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NASQIC> sclist = new List<BusinessEntities.EMRForms.NASQIC>();
            DataTable dt = DataAccessLayer.EMRForms.NASQIC.GetAllPreNASQIC(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NASQIC
                {
                    nasqId = Convert.ToInt32(dr["nasqId"]),
                    nasq_appId = Convert.ToInt32(dr["nasq_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }


        //print
        public static List<BusinessEntities.EMRForms.NASQIC> GetPrintNASQIC(int? nasqId)
        {
            List<BusinessEntities.EMRForms.NASQIC> sclist = new List<BusinessEntities.EMRForms.NASQIC>();
            DataTable dt = DataAccessLayer.EMRForms.NASQIC.GetPrintNASQIC(nasqId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NASQIC
                    {
                        nasqId = Convert.ToInt32(dr["nasqId"]),
                        nasq_appId = Convert.ToInt32(dr["nasq_appId"]),
                        nasq_1 = dr["nasq_1"].ToString(),
                        nasq_2 = dr["nasq_2"].ToString(),
                        nasq_3 = dr["nasq_3"].ToString(),
                        nasq_4 = dr["nasq_4"].ToString(),
                        nasq_5 = dr["nasq_5"].ToString(),
                        nasq_6 = dr["nasq_6"].ToString(),
                        nasq_7 = dr["nasq_7"].ToString(),
                        nasq_8 = dr["nasq_8"].ToString(),
                        nasq_9 = dr["nasq_9"].ToString(),
                        nasq_10 = dr["nasq_10"].ToString(),
                        nasq_11 = dr["nasq_11"].ToString(),
                        nasq_12 = dr["nasq_12"].ToString(),
                        nasq_13 = dr["nasq_13"].ToString(),
                        nasq_14 = dr["nasq_14"].ToString(),
                        nasq_15 = dr["nasq_15"].ToString(),
                        nasq_16 = dr["nasq_16"].ToString(),
                        nasq_17 = dr["nasq_17"].ToString(),
                        nasq_18 = dr["nasq_18"].ToString(),

                        nasq_d1 = (dt.Rows[0]["nasq_date1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["nasq_date1"].ToString(),
                        nasq_date_created = Convert.ToDateTime(dr["nasq_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NASQIC a = new BusinessEntities.EMRForms.NASQIC();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion NASQIC (Page Load)

        #region NASQIC (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNASQIC(BusinessEntities.EMRForms.NASQIC data)
        {
            data.nasq_1 = string.IsNullOrEmpty(data.nasq_1) ? string.Empty : data.nasq_1;
            data.nasq_2 = string.IsNullOrEmpty(data.nasq_2) ? string.Empty : data.nasq_2;
            data.nasq_3 = string.IsNullOrEmpty(data.nasq_3) ? string.Empty : data.nasq_3;
            data.nasq_4 = string.IsNullOrEmpty(data.nasq_4) ? string.Empty : data.nasq_4;
            data.nasq_5 = string.IsNullOrEmpty(data.nasq_5) ? string.Empty : data.nasq_5;
            data.nasq_6 = string.IsNullOrEmpty(data.nasq_6) ? string.Empty : data.nasq_6;
            data.nasq_7 = string.IsNullOrEmpty(data.nasq_7) ? string.Empty : data.nasq_7;
            data.nasq_8 = string.IsNullOrEmpty(data.nasq_8) ? string.Empty : data.nasq_8;
            data.nasq_9 = string.IsNullOrEmpty(data.nasq_9) ? string.Empty : data.nasq_9;
            data.nasq_10 = string.IsNullOrEmpty(data.nasq_10) ? string.Empty : data.nasq_10;
            data.nasq_11 = string.IsNullOrEmpty(data.nasq_11) ? string.Empty : data.nasq_11;
            data.nasq_12 = string.IsNullOrEmpty(data.nasq_12) ? string.Empty : data.nasq_12;
            data.nasq_13 = string.IsNullOrEmpty(data.nasq_13) ? string.Empty : data.nasq_13;
            data.nasq_14 = string.IsNullOrEmpty(data.nasq_14) ? string.Empty : data.nasq_14;
            data.nasq_15 = string.IsNullOrEmpty(data.nasq_15) ? string.Empty : data.nasq_15;
            data.nasq_16 = string.IsNullOrEmpty(data.nasq_16) ? string.Empty : data.nasq_16;
            data.nasq_17 = string.IsNullOrEmpty(data.nasq_17) ? string.Empty : data.nasq_17;
            data.nasq_18 = string.IsNullOrEmpty(data.nasq_18) ? string.Empty : data.nasq_18;
            DateTime? card21 = data.nasq_date1; // Assuming data.nasq_d1 is of type DateTime? 
            if (data.nasq_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.nasq_date1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.nasq_date1 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.NASQIC.InsertUpdateNASQIC(data);
        }
        //Delete
        public static int DeleteNASQIC(int nasqId, int nasq_madeby)
        {
            return DataAccessLayer.EMRForms.NASQIC.DeleteNASQIC(nasqId, nasq_madeby);
        }
        #endregion NASQIC (CRUD Operations)
    }
    public class SAICO
    {
        #region SAICO (Page Load)
        public static List<BusinessEntities.EMRForms.SAICO> GetAllSAICO(int appId)
        {
            List<BusinessEntities.EMRForms.SAICO> sclist = new List<BusinessEntities.EMRForms.SAICO>();
            DataTable dt = DataAccessLayer.EMRForms.SAICO.GetAllSAICO(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.SAICO
                {
                    sacnId = Convert.ToInt32(dr["sacnId"]),
                    sacn_appId = Convert.ToInt32(dr["sacn_appId"]),
                    sacn_checkbox = dr["sacn_checkbox"].ToString(),
                    sacn_1 = dr["sacn_1"].ToString(),
                    sacn_2 = dr["sacn_2"].ToString(),
                    sacn_3 = dr["sacn_3"].ToString(),
                    sacn_4 = dr["sacn_4"].ToString(),
                    sacn_5 = dr["sacn_5"].ToString(),
                    sacn_6 = dr["sacn_6"].ToString(),
                    sacn_7 = dr["sacn_7"].ToString(),
                    sacn_8 = dr["sacn_8"].ToString(),
                    sacn_9 = dr["sacn_9"].ToString(),
                    sacn_10 = dr["sacn_10"].ToString(),
                    sacn_11 = dr["sacn_11"].ToString(),
                    sacn_12 = dr["sacn_12"].ToString(),
                    sacn_13 = dr["sacn_13"].ToString(),
                    sacn_14 = dr["sacn_14"].ToString(),
                    sacn_15 = dr["sacn_15"].ToString(),
                    sacn_16 = dr["sacn_16"].ToString(),
                    sacn_17 = dr["sacn_17"].ToString(),
                    sacn_18 = dr["sacn_18"].ToString(),
                    sacn_19 = dr["sacn_19"].ToString(),
                    
                    sacn_d1 = Convert.ToDateTime(dr["sacn_d1"].ToString()),
                    sacn_d2 = Convert.ToDateTime(dr["sacn_d2"].ToString()),
                    sacn_d3 = Convert.ToDateTime(dr["sacn_d3"].ToString()),
                    sacn_d4 = Convert.ToDateTime(dr["sacn_d4"].ToString()),
                    sacn_d5 = Convert.ToDateTime(dr["sacn_d5"].ToString()),
                    sacn_d6 = Convert.ToDateTime(dr["sacn_d6"].ToString()),
                    sacn_date_created = Convert.ToDateTime(dr["sacn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.SAICO> GetAllPreSAICO(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.SAICO> sclist = new List<BusinessEntities.EMRForms.SAICO>();
            DataTable dt = DataAccessLayer.EMRForms.SAICO.GetAllPreSAICO(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.SAICO
                {
                    sacnId = Convert.ToInt32(dr["sacnId"]),
                    sacn_appId = Convert.ToInt32(dr["sacn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
       
        //print
        public static List<BusinessEntities.EMRForms.SAICO> GetPrintSAICO(int? sacnId)
        {
            List<BusinessEntities.EMRForms.SAICO> sclist = new List<BusinessEntities.EMRForms.SAICO>();
            DataTable dt = DataAccessLayer.EMRForms.SAICO.GetPrintSAICO(sacnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.SAICO
                    {
                        sacnId = Convert.ToInt32(dr["sacnId"]),
                        sacn_appId = Convert.ToInt32(dr["sacn_appId"]),
                        sacn_checkbox = dr["sacn_checkbox"].ToString(),
                        sacn_1 = dr["sacn_1"].ToString(),
                        sacn_2 = dr["sacn_2"].ToString(),
                        sacn_3 = dr["sacn_3"].ToString(),
                        sacn_4 = dr["sacn_4"].ToString(),
                        sacn_5 = dr["sacn_5"].ToString(),
                        sacn_6 = dr["sacn_6"].ToString(),
                        sacn_7 = dr["sacn_7"].ToString(),
                        sacn_8 = dr["sacn_8"].ToString(),
                        sacn_9 = dr["sacn_9"].ToString(),
                        sacn_10 = dr["sacn_10"].ToString(),
                        sacn_11 = dr["sacn_11"].ToString(),
                        sacn_12 = dr["sacn_12"].ToString(),
                        sacn_13 = dr["sacn_13"].ToString(),
                        sacn_14 = dr["sacn_14"].ToString(),
                        sacn_15 = dr["sacn_15"].ToString(),
                        sacn_16 = dr["sacn_16"].ToString(),
                        sacn_17 = dr["sacn_17"].ToString(),
                        sacn_18 = dr["sacn_18"].ToString(),
                        sacn_19 = dr["sacn_19"].ToString(),
                        sacn_dd1 = dr["sacn_d1"].ToString(),
                        sacn_dd2 = dr["sacn_d2"].ToString(),
                        sacn_dd3 = dr["sacn_d3"].ToString(),
                        sacn_dd4 = dr["sacn_d4"].ToString(),
                        sacn_dd5 = dr["sacn_d5"].ToString(),
                        sacn_dd6 = dr["sacn_d6"].ToString(),
                        sacn_date_created = Convert.ToDateTime(dr["sacn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.SAICO a = new BusinessEntities.EMRForms.SAICO();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion SAICO (Page Load)

        #region SAICO (CRUD Operations)
        //insert&update
        public static bool InsertUpdateSAICO(BusinessEntities.EMRForms.SAICO data)
        {
            data.sacn_checkbox = string.IsNullOrEmpty(data.sacn_checkbox) ? string.Empty : data.sacn_checkbox;
            data.sacn_1 = string.IsNullOrEmpty(data.sacn_1) ? string.Empty : data.sacn_1;
            data.sacn_2 = string.IsNullOrEmpty(data.sacn_2) ? string.Empty : data.sacn_2;
            data.sacn_3 = string.IsNullOrEmpty(data.sacn_3) ? string.Empty : data.sacn_3;
            data.sacn_4 = string.IsNullOrEmpty(data.sacn_4) ? string.Empty : data.sacn_4;
            data.sacn_5 = string.IsNullOrEmpty(data.sacn_5) ? string.Empty : data.sacn_5;
            data.sacn_6 = string.IsNullOrEmpty(data.sacn_6) ? string.Empty : data.sacn_6;
            data.sacn_7 = string.IsNullOrEmpty(data.sacn_7) ? string.Empty : data.sacn_7;
            data.sacn_8 = string.IsNullOrEmpty(data.sacn_8) ? string.Empty : data.sacn_8;
            data.sacn_9 = string.IsNullOrEmpty(data.sacn_9) ? string.Empty : data.sacn_9;
            data.sacn_10 = string.IsNullOrEmpty(data.sacn_10) ? string.Empty : data.sacn_10;
            data.sacn_11 = string.IsNullOrEmpty(data.sacn_11) ? string.Empty : data.sacn_11;
            data.sacn_12 = string.IsNullOrEmpty(data.sacn_12) ? string.Empty : data.sacn_12;
            data.sacn_13 = string.IsNullOrEmpty(data.sacn_13) ? string.Empty : data.sacn_13;
            data.sacn_14 = string.IsNullOrEmpty(data.sacn_14) ? string.Empty : data.sacn_14;
            data.sacn_15 = string.IsNullOrEmpty(data.sacn_15) ? string.Empty : data.sacn_15;
            data.sacn_16 = string.IsNullOrEmpty(data.sacn_16) ? string.Empty : data.sacn_16;
            data.sacn_17 = string.IsNullOrEmpty(data.sacn_17) ? string.Empty : data.sacn_17;
            data.sacn_18 = string.IsNullOrEmpty(data.sacn_18) ? string.Empty : data.sacn_18;
            data.sacn_19 = string.IsNullOrEmpty(data.sacn_19) ? string.Empty : data.sacn_19;
            DateTime? sacnd1 = data.sacn_d1; // Assuming data.sacn_d1 is of type DateTime?            
            DateTime? sacnd2 = data.sacn_d2; // Assuming data.sacn_d2 is of type DateTime?
            DateTime? sacnd3 = data.sacn_d3; // Assuming data.sacn_d3 is of type DateTime?
            DateTime? sacnd4 = data.sacn_d4; // Assuming data.sacn_d4 is of type DateTime?
            DateTime? sacnd5 = data.sacn_d5; // Assuming data.sacn_d5 is of type DateTime?
            DateTime? sacnd6 = data.sacn_d6; // Assuming data.sacn_d6 is of type DateTime?
            if (data.sacn_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.sacn_d1 = sacnd1.HasValue ? sacnd1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.sacn_d1 = DateTime.Parse("01/01/1950");
            }
            if (data.sacn_d2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.sacn_d2 = sacnd2.HasValue ? sacnd2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.sacn_d2 = DateTime.Parse("01/01/1950");
            }
            if (data.sacn_d3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.sacn_d3 = sacnd3.HasValue ? sacnd3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.sacn_d3 = DateTime.Parse("01/01/1950");
            }
            if (data.sacn_d4 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.sacn_d4 = sacnd4.HasValue ? sacnd4.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.sacn_d4 = DateTime.Parse("01/01/1950");
            }
            if (data.sacn_d5 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.sacn_d5 = sacnd5.HasValue ? sacnd5.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.sacn_d5 = DateTime.Parse("01/01/1950");
            }
            if (data.sacn_d6 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.sacn_d6 = sacnd6.HasValue ? sacnd6.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.sacn_d6 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.SAICO.InsertUpdateSAICO(data);
        }
        //Delete
        public static int DeleteSAICO(int sacnId, int sacn_madeby)
        {
            return DataAccessLayer.EMRForms.SAICO.DeleteSAICO(sacnId, sacn_madeby);
        }
        #endregion SAICO (CRUD Operations)

        
    }
    public class Wamped
    {
        #region Wamped (Page Load)
        public static List<BusinessEntities.EMRForms.Wamped> GetAllWamped(int appId)
        {
            List<BusinessEntities.EMRForms.Wamped> sclist = new List<BusinessEntities.EMRForms.Wamped>();
            DataTable dt = DataAccessLayer.EMRForms.Wamped.GetAllWamped(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Wamped
                {
                    wapnId = Convert.ToInt32(dr["wapnId"]),
                    wapn_appId = Convert.ToInt32(dr["wapn_appId"]),
                    wapn_checkbox = dr["wapn_checkbox"].ToString(),
                    wapn_1 = dr["wapn_1"].ToString(),
                    wapn_2 = dr["wapn_2"].ToString(),
                    wapn_3 = dr["wapn_3"].ToString(),
                    wapn_4 = dr["wapn_4"].ToString(),
                    wapn_5 = dr["wapn_5"].ToString(),
                    wapn_6 = dr["wapn_6"].ToString(),
                    wapn_7 = dr["wapn_7"].ToString(),
                    wapn_8 = dr["wapn_8"].ToString(),
                    wapn_9 = dr["wapn_9"].ToString(),
                    wapn_10 = dr["wapn_10"].ToString(),
                    wapn_11 = dr["wapn_11"].ToString(),
                    wapn_12 = dr["wapn_12"].ToString(),
                    wapn_13 = dr["wapn_13"].ToString(),
                    wapn_14 = dr["wapn_14"].ToString(),
                    wapn_15 = dr["wapn_15"].ToString(),
                    wapn_16 = dr["wapn_16"].ToString(),
                    wapn_17 = dr["wapn_17"].ToString(),
                    wapn_18 = dr["wapn_18"].ToString(),
                    wapn_19 = dr["wapn_19"].ToString(),
                    wapn_20 = dr["wapn_20"].ToString(),
                    wapn_21 = dr["wapn_21"].ToString(),
                    wapn_22 = dr["wapn_22"].ToString(),
                    wapn_23 = dr["wapn_23"].ToString(),
                    wapn_24 = dr["wapn_24"].ToString(),
                    wapn_25 = dr["wapn_25"].ToString(),
                    wapn_26 = dr["wapn_26"].ToString(),
                    wapn_27 = dr["wapn_27"].ToString(),
                    wapn_28 = dr["wapn_28"].ToString(),
                    wapn_29 = dr["wapn_29"].ToString(),
                    wapn_30 = dr["wapn_30"].ToString(),
                    wapn_31 = dr["wapn_31"].ToString(),
                    wapn_32 = dr["wapn_32"].ToString(),
                    wapn_33 = dr["wapn_33"].ToString(),
                    wapn_34 = dr["wapn_34"].ToString(),
                    wapn_35 = dr["wapn_35"].ToString(),
                    wapn_36 = dr["wapn_36"].ToString(),
                    wapn_37 = dr["wapn_37"].ToString(),
                    wapn_38 = dr["wapn_38"].ToString(),
                    wapn_39 = dr["wapn_39"].ToString(),
                    wapn_40 = dr["wapn_40"].ToString(),
                    wapn_41 = dr["wapn_41"].ToString(),
                    wapn_42 = dr["wapn_42"].ToString(),
                    wapn_43 = dr["wapn_43"].ToString(),
                    wapn_44 = dr["wapn_44"].ToString(),
                    wapn_45 = dr["wapn_45"].ToString(),
                    wapn_d1 = Convert.ToDateTime(dr["wapn_d1"].ToString()),
                    wapn_d2 = Convert.ToDateTime(dr["wapn_d2"].ToString()),
                    wapn_d3 = Convert.ToDateTime(dr["wapn_d3"].ToString()),
                    wapn_date_created = Convert.ToDateTime(dr["wapn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Wamped> GetAllPreWamped(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Wamped> sclist = new List<BusinessEntities.EMRForms.Wamped>();
            DataTable dt = DataAccessLayer.EMRForms.Wamped.GetAllPreWamped(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Wamped
                {
                    wapnId = Convert.ToInt32(dr["wapnId"]),
                    wapn_appId = Convert.ToInt32(dr["wapn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Wamped> GetPrintWamped(int? wapnId)
        {
            List<BusinessEntities.EMRForms.Wamped> sclist = new List<BusinessEntities.EMRForms.Wamped>();
            DataTable dt = DataAccessLayer.EMRForms.Wamped.GetPrintWamped(wapnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Wamped
                    {
                        wapnId = Convert.ToInt32(dr["wapnId"]),
                        wapn_appId = Convert.ToInt32(dr["wapn_appId"]),
                        wapn_checkbox = dr["wapn_checkbox"].ToString(),
                        wapn_1 = dr["wapn_1"].ToString(),
                        wapn_2 = dr["wapn_2"].ToString(),
                        wapn_3 = dr["wapn_3"].ToString(),
                        wapn_4 = dr["wapn_4"].ToString(),
                        wapn_5 = dr["wapn_5"].ToString(),
                        wapn_6 = dr["wapn_6"].ToString(),
                        wapn_7 = dr["wapn_7"].ToString(),
                        wapn_8 = dr["wapn_8"].ToString(),
                        wapn_9 = dr["wapn_9"].ToString(),
                        wapn_10 = dr["wapn_10"].ToString(),
                        wapn_11 = dr["wapn_11"].ToString(),
                        wapn_12 = dr["wapn_12"].ToString(),
                        wapn_13 = dr["wapn_13"].ToString(),
                        wapn_14 = dr["wapn_14"].ToString(),
                        wapn_15 = dr["wapn_15"].ToString(),
                        wapn_16 = dr["wapn_16"].ToString(),
                        wapn_17 = dr["wapn_17"].ToString(),
                        wapn_18 = dr["wapn_18"].ToString(),
                        wapn_19 = dr["wapn_19"].ToString(),
                        wapn_20 = dr["wapn_20"].ToString(),
                        wapn_21 = dr["wapn_21"].ToString(),
                        wapn_22 = dr["wapn_22"].ToString(),
                        wapn_23 = dr["wapn_23"].ToString(),
                        wapn_24 = dr["wapn_24"].ToString(),
                        wapn_25 = dr["wapn_25"].ToString(),
                        wapn_26 = dr["wapn_26"].ToString(),
                        wapn_27 = dr["wapn_27"].ToString(),
                        wapn_28 = dr["wapn_28"].ToString(),
                        wapn_29 = dr["wapn_29"].ToString(),
                        wapn_30 = dr["wapn_30"].ToString(),
                        wapn_31 = dr["wapn_31"].ToString(),
                        wapn_32 = dr["wapn_32"].ToString(),
                        wapn_33 = dr["wapn_33"].ToString(),
                        wapn_34 = dr["wapn_34"].ToString(),
                        wapn_35 = dr["wapn_35"].ToString(),
                        wapn_36 = dr["wapn_36"].ToString(),
                        wapn_37 = dr["wapn_37"].ToString(),
                        wapn_38 = dr["wapn_38"].ToString(),
                        wapn_39 = dr["wapn_39"].ToString(),
                        wapn_40 = dr["wapn_40"].ToString(),
                        wapn_41 = dr["wapn_41"].ToString(),
                        wapn_42 = dr["wapn_42"].ToString(),
                        wapn_43 = dr["wapn_43"].ToString(),
                        wapn_44 = dr["wapn_44"].ToString(),
                        wapn_45 = dr["wapn_45"].ToString(),
                        wapn_dd1 = dr["wapn_d1"].ToString(),
                        wapn_dd2 = dr["wapn_d2"].ToString(),
                        wapn_dd3 = dr["wapn_d3"].ToString(),

                        wapn_date_created = Convert.ToDateTime(dr["wapn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Wamped a = new BusinessEntities.EMRForms.Wamped();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Wamped (Page Load)

        #region Wamped (CRUD Operations)
        //insert&update
        public static bool InsertUpdateWamped(BusinessEntities.EMRForms.Wamped data)
        {
            data.wapn_checkbox = string.IsNullOrEmpty(data.wapn_checkbox) ? string.Empty : data.wapn_checkbox;
            data.wapn_1 = string.IsNullOrEmpty(data.wapn_1) ? string.Empty : data.wapn_1;
            data.wapn_2 = string.IsNullOrEmpty(data.wapn_2) ? string.Empty : data.wapn_2;
            data.wapn_3 = string.IsNullOrEmpty(data.wapn_3) ? string.Empty : data.wapn_3;
            data.wapn_4 = string.IsNullOrEmpty(data.wapn_4) ? string.Empty : data.wapn_4;
            data.wapn_5 = string.IsNullOrEmpty(data.wapn_5) ? string.Empty : data.wapn_5;
            data.wapn_6 = string.IsNullOrEmpty(data.wapn_6) ? string.Empty : data.wapn_6;
            data.wapn_7 = string.IsNullOrEmpty(data.wapn_7) ? string.Empty : data.wapn_7;
            data.wapn_8 = string.IsNullOrEmpty(data.wapn_8) ? string.Empty : data.wapn_8;
            data.wapn_9 = string.IsNullOrEmpty(data.wapn_9) ? string.Empty : data.wapn_9;
            data.wapn_10 = string.IsNullOrEmpty(data.wapn_10) ? string.Empty : data.wapn_10;
            data.wapn_11 = string.IsNullOrEmpty(data.wapn_11) ? string.Empty : data.wapn_11;
            data.wapn_12 = string.IsNullOrEmpty(data.wapn_12) ? string.Empty : data.wapn_12;
            data.wapn_13 = string.IsNullOrEmpty(data.wapn_13) ? string.Empty : data.wapn_13;
            data.wapn_14 = string.IsNullOrEmpty(data.wapn_14) ? string.Empty : data.wapn_14;
            data.wapn_15 = string.IsNullOrEmpty(data.wapn_15) ? string.Empty : data.wapn_15;
            data.wapn_16 = string.IsNullOrEmpty(data.wapn_16) ? string.Empty : data.wapn_16;
            data.wapn_17 = string.IsNullOrEmpty(data.wapn_17) ? string.Empty : data.wapn_17;
            data.wapn_18 = string.IsNullOrEmpty(data.wapn_18) ? string.Empty : data.wapn_18;
            data.wapn_19 = string.IsNullOrEmpty(data.wapn_19) ? string.Empty : data.wapn_19;
            data.wapn_20 = string.IsNullOrEmpty(data.wapn_20) ? string.Empty : data.wapn_20;
            data.wapn_21 = string.IsNullOrEmpty(data.wapn_21) ? string.Empty : data.wapn_21;
            data.wapn_22 = string.IsNullOrEmpty(data.wapn_22) ? string.Empty : data.wapn_22;
            data.wapn_23 = string.IsNullOrEmpty(data.wapn_23) ? string.Empty : data.wapn_23;
            data.wapn_24 = string.IsNullOrEmpty(data.wapn_24) ? string.Empty : data.wapn_24;
            data.wapn_25 = string.IsNullOrEmpty(data.wapn_25) ? string.Empty : data.wapn_25;
            data.wapn_26 = string.IsNullOrEmpty(data.wapn_26) ? string.Empty : data.wapn_26;
            data.wapn_27 = string.IsNullOrEmpty(data.wapn_27) ? string.Empty : data.wapn_27;
            data.wapn_28 = string.IsNullOrEmpty(data.wapn_28) ? string.Empty : data.wapn_28;
            data.wapn_29 = string.IsNullOrEmpty(data.wapn_29) ? string.Empty : data.wapn_29;
            data.wapn_30 = string.IsNullOrEmpty(data.wapn_30) ? string.Empty : data.wapn_30;
            data.wapn_31 = string.IsNullOrEmpty(data.wapn_31) ? string.Empty : data.wapn_31;
            data.wapn_32 = string.IsNullOrEmpty(data.wapn_32) ? string.Empty : data.wapn_32;
            data.wapn_33 = string.IsNullOrEmpty(data.wapn_33) ? string.Empty : data.wapn_33;
            data.wapn_34 = string.IsNullOrEmpty(data.wapn_34) ? string.Empty : data.wapn_34;
            data.wapn_35 = string.IsNullOrEmpty(data.wapn_35) ? string.Empty : data.wapn_35;
            data.wapn_36 = string.IsNullOrEmpty(data.wapn_36) ? string.Empty : data.wapn_36;
            data.wapn_37 = string.IsNullOrEmpty(data.wapn_37) ? string.Empty : data.wapn_37;
            data.wapn_38 = string.IsNullOrEmpty(data.wapn_38) ? string.Empty : data.wapn_38;
            data.wapn_39 = string.IsNullOrEmpty(data.wapn_39) ? string.Empty : data.wapn_39;
            data.wapn_40 = string.IsNullOrEmpty(data.wapn_40) ? string.Empty : data.wapn_40;
            data.wapn_41 = string.IsNullOrEmpty(data.wapn_41) ? string.Empty : data.wapn_41;
            data.wapn_42 = string.IsNullOrEmpty(data.wapn_42) ? string.Empty : data.wapn_42;
            data.wapn_43 = string.IsNullOrEmpty(data.wapn_43) ? string.Empty : data.wapn_43;
            data.wapn_44 = string.IsNullOrEmpty(data.wapn_44) ? string.Empty : data.wapn_44;
            data.wapn_45 = string.IsNullOrEmpty(data.wapn_45) ? string.Empty : data.wapn_45;
            DateTime? card1 = data.wapn_d1; // Assuming data.wapn_d1 is of type DateTime?            
            DateTime? card2 = data.wapn_d2; // Assuming data.wapn_d2 is of type DateTime?
            DateTime? card3 = data.wapn_d3; // Assuming data.wapn_d3 is of type DateTime?
            if (data.wapn_d1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.wapn_d1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.wapn_d1 = DateTime.Parse("01/01/1950");
            }
            if (data.wapn_d2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.wapn_d2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.wapn_d2 = DateTime.Parse("01/01/1950");
            }
            if (data.wapn_d3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.wapn_d3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.wapn_d3 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.Wamped.InsertUpdateWamped(data);
        }
        //Delete
        public static int DeleteWamped(int wapnId, int wapn_madeby)
        {
            return DataAccessLayer.EMRForms.Wamped.DeleteWamped(wapnId, wapn_madeby);
        }
        #endregion Wamped (CRUD Operations)
    }
    public class Orient
    {
        #region Orient (Page Load)
        public static List<BusinessEntities.EMRForms.Orient> GetAllOrient(int appId)
        {
            List<BusinessEntities.EMRForms.Orient> sclist = new List<BusinessEntities.EMRForms.Orient>();
            DataTable dt = DataAccessLayer.EMRForms.Orient.GetAllOrient(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Orient
                {
                    orntId = Convert.ToInt32(dr["orntId"]),
                    ornt_appId = Convert.ToInt32(dr["ornt_appId"]),
                    ornt_1 = dr["ornt_1"].ToString(),
                    ornt_2 = dr["ornt_2"].ToString(),
                    ornt_3 = dr["ornt_3"].ToString(),
                    ornt_4 = dr["ornt_4"].ToString(),
                    ornt_5 = dr["ornt_5"].ToString(),
                    ornt_6 = dr["ornt_6"].ToString(),
                    ornt_7 = dr["ornt_7"].ToString(),
                    ornt_chk = dr["ornt_chk"].ToString(),
                    ornt_date1 = Convert.ToDateTime(dr["ornt_date1"].ToString()),
                    ornt_date2 = Convert.ToDateTime(dr["ornt_date2"].ToString()),
                    ornt_date3 = Convert.ToDateTime(dr["ornt_date3"].ToString()),
                    ornt_date_created = Convert.ToDateTime(dr["ornt_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Orient> GetAllPreOrient(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Orient> sclist = new List<BusinessEntities.EMRForms.Orient>();
            DataTable dt = DataAccessLayer.EMRForms.Orient.GetAllPreOrient(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Orient
                {
                    orntId = Convert.ToInt32(dr["orntId"]),
                    ornt_appId = Convert.ToInt32(dr["ornt_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.Orient> GetPrintOrient(int? orntId)
        {
            List<BusinessEntities.EMRForms.Orient> sclist = new List<BusinessEntities.EMRForms.Orient>();
            DataTable dt = DataAccessLayer.EMRForms.Orient.GetPrintOrient(orntId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Orient
                    {
                        orntId = Convert.ToInt32(dr["orntId"]),
                        ornt_appId = Convert.ToInt32(dr["ornt_appId"]),
                        ornt_1 = dr["ornt_1"].ToString(),
                        ornt_2 = dr["ornt_2"].ToString(),
                        ornt_3 = dr["ornt_3"].ToString(),
                        ornt_4 = dr["ornt_4"].ToString(),
                        ornt_5 = dr["ornt_5"].ToString(),
                        ornt_6 = dr["ornt_6"].ToString(),
                        ornt_7 = dr["ornt_7"].ToString(),
                        ornt_chk = dr["ornt_chk"].ToString(),
                        ornt_d21 = (dt.Rows[0]["ornt_date1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["ornt_date1"].ToString(),
                        ornt_d22 = (dt.Rows[0]["ornt_date2"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["ornt_date2"].ToString(),
                        ornt_d23 = (dt.Rows[0]["ornt_date3"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["ornt_date3"].ToString(),
                        ornt_date_created = Convert.ToDateTime(dr["ornt_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),
                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Orient a = new BusinessEntities.EMRForms.Orient();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Orient (Page Load)
        
        #region Orient (CRUD Operations)
        //insert&update
        public static bool InsertUpdateOrient(BusinessEntities.EMRForms.Orient data)
        {
            data.ornt_1 = string.IsNullOrEmpty(data.ornt_1) ? string.Empty : data.ornt_1;
            data.ornt_2 = string.IsNullOrEmpty(data.ornt_2) ? string.Empty : data.ornt_2;
            data.ornt_3 = string.IsNullOrEmpty(data.ornt_3) ? string.Empty : data.ornt_3;
            data.ornt_4 = string.IsNullOrEmpty(data.ornt_4) ? string.Empty : data.ornt_4;
            data.ornt_5 = string.IsNullOrEmpty(data.ornt_5) ? string.Empty : data.ornt_5;
            data.ornt_6 = string.IsNullOrEmpty(data.ornt_6) ? string.Empty : data.ornt_6;
            data.ornt_7 = string.IsNullOrEmpty(data.ornt_7) ? string.Empty : data.ornt_7;
            data.ornt_chk = string.IsNullOrEmpty(data.ornt_chk) ? string.Empty : data.ornt_chk;
            DateTime? card21 = data.ornt_date1; // Assuming data.ornt_d1 is of type DateTime?            
            DateTime? card22 = data.ornt_date2; // Assuming data.ornt_d2 is of type DateTime?
            DateTime? card23 = data.ornt_date3; // Assuming data.ornt_d3 is of type DateTime?
            if (data.ornt_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.ornt_date1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.ornt_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.ornt_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.ornt_date2 = card22.HasValue ? card22.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.ornt_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.ornt_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.ornt_date3 = card23.HasValue ? card23.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.ornt_date3 = DateTime.Parse("01/01/1950");
            }


            return DataAccessLayer.EMRForms.Orient.InsertUpdateOrient(data);
        }
        //Delete
        public static int DeleteOrient(int orntId, int ornt_madeby)
        {
            return DataAccessLayer.EMRForms.Orient.DeleteOrient(orntId, ornt_madeby);
        }
        #endregion Orient (CRUD Operations)
    }
    public class QICNAS
    {
        #region QICNAS (Page Load)
        public static List<BusinessEntities.EMRForms.QICNAS> GetAllQICNAS(int appId)
        {
            List<BusinessEntities.EMRForms.QICNAS> sclist = new List<BusinessEntities.EMRForms.QICNAS>();
            DataTable dt = DataAccessLayer.EMRForms.QICNAS.GetAllQICNAS(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.QICNAS
                {
                    qnasId = Convert.ToInt32(dr["qnasId"]),
                    qnas_appId = Convert.ToInt32(dr["qnas_appId"]),
                    qnas_1 = dr["qnas_1"].ToString(),
                    qnas_2 = dr["qnas_2"].ToString(),
                    qnas_3 = dr["qnas_3"].ToString(),
                    qnas_4 = dr["qnas_4"].ToString(),
                    qnas_5 = dr["qnas_5"].ToString(),
                    qnas_6 = dr["qnas_6"].ToString(),
                    qnas_7 = dr["qnas_7"].ToString(),
                    qnas_8 = dr["qnas_8"].ToString(),
                    qnas_9 = dr["qnas_9"].ToString(),
                    qnas_10 = dr["qnas_10"].ToString(),
                    qnas_11 = dr["qnas_11"].ToString(),
                    qnas_12 = dr["qnas_12"].ToString(),
                    qnas_13 = dr["qnas_13"].ToString(),
                    qnas_14 = dr["qnas_14"].ToString(),
                    qnas_15 = dr["qnas_15"].ToString(),
                    qnas_16 = dr["qnas_16"].ToString(),
                    qnas_17 = dr["qnas_17"].ToString(),
                    qnas_18 = dr["qnas_18"].ToString(),
                    qnas_19 = dr["qnas_19"].ToString(),
                    qnas_20 = dr["qnas_20"].ToString(),
                    qnas_21 = dr["qnas_21"].ToString(),
                    qnas_date1 = Convert.ToDateTime(dr["qnas_date1"].ToString()),
                    qnas_date_created = Convert.ToDateTime(dr["qnas_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.QICNAS> GetAllPreQICNAS(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.QICNAS> sclist = new List<BusinessEntities.EMRForms.QICNAS>();
            DataTable dt = DataAccessLayer.EMRForms.QICNAS.GetAllPreQICNAS(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.QICNAS
                {
                    qnasId = Convert.ToInt32(dr["qnasId"]),
                    qnas_appId = Convert.ToInt32(dr["qnas_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.QICNAS> GetPrintQICNAS(int? qnasId)
        {
            List<BusinessEntities.EMRForms.QICNAS> sclist = new List<BusinessEntities.EMRForms.QICNAS>();
            DataTable dt = DataAccessLayer.EMRForms.QICNAS.GetPrintQICNAS(qnasId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.QICNAS
                    {
                        qnasId = Convert.ToInt32(dr["qnasId"]),
                        qnas_appId = Convert.ToInt32(dr["qnas_appId"]),
                        qnas_1 = dr["qnas_1"].ToString(),
                        qnas_2 = dr["qnas_2"].ToString(),
                        qnas_3 = dr["qnas_3"].ToString(),
                        qnas_4 = dr["qnas_4"].ToString(),
                        qnas_5 = dr["qnas_5"].ToString(),
                        qnas_6 = dr["qnas_6"].ToString(),
                        qnas_7 = dr["qnas_7"].ToString(),
                        qnas_8 = dr["qnas_8"].ToString(),
                        qnas_9 = dr["qnas_9"].ToString(),
                        qnas_10 = dr["qnas_10"].ToString(),
                        qnas_11 = dr["qnas_11"].ToString(),
                        qnas_12 = dr["qnas_12"].ToString(),
                        qnas_13 = dr["qnas_13"].ToString(),
                        qnas_14 = dr["qnas_14"].ToString(),
                        qnas_15 = dr["qnas_15"].ToString(),
                        qnas_16 = dr["qnas_16"].ToString(),
                        qnas_17 = dr["qnas_17"].ToString(),
                        qnas_18 = dr["qnas_18"].ToString(),
                        qnas_19 = dr["qnas_19"].ToString(),
                        qnas_20 = dr["qnas_20"].ToString(),
                        qnas_21 = dr["qnas_21"].ToString(),
                        qnas_d1 = dr["qnas_date1"].ToString(),

                        qnas_date_created = Convert.ToDateTime(dr["qnas_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.QICNAS a = new BusinessEntities.EMRForms.QICNAS();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion QICNAS (Page Load)

        #region QICNAS (CRUD Operations)
        //insert&update
        public static bool InsertUpdateQICNAS(BusinessEntities.EMRForms.QICNAS data)
        {
            data.qnas_1 = string.IsNullOrEmpty(data.qnas_1) ? string.Empty : data.qnas_1;
            data.qnas_2 = string.IsNullOrEmpty(data.qnas_2) ? string.Empty : data.qnas_2;
            data.qnas_3 = string.IsNullOrEmpty(data.qnas_3) ? string.Empty : data.qnas_3;
            data.qnas_4 = string.IsNullOrEmpty(data.qnas_4) ? string.Empty : data.qnas_4;
            data.qnas_5 = string.IsNullOrEmpty(data.qnas_5) ? string.Empty : data.qnas_5;
            data.qnas_6 = string.IsNullOrEmpty(data.qnas_6) ? string.Empty : data.qnas_6;
            data.qnas_7 = string.IsNullOrEmpty(data.qnas_7) ? string.Empty : data.qnas_7;
            data.qnas_8 = string.IsNullOrEmpty(data.qnas_8) ? string.Empty : data.qnas_8;
            data.qnas_9 = string.IsNullOrEmpty(data.qnas_9) ? string.Empty : data.qnas_9;
            data.qnas_10 = string.IsNullOrEmpty(data.qnas_10) ? string.Empty : data.qnas_10;
            data.qnas_11 = string.IsNullOrEmpty(data.qnas_11) ? string.Empty : data.qnas_11;
            data.qnas_12 = string.IsNullOrEmpty(data.qnas_12) ? string.Empty : data.qnas_12;
            data.qnas_13 = string.IsNullOrEmpty(data.qnas_13) ? string.Empty : data.qnas_13;
            data.qnas_14 = string.IsNullOrEmpty(data.qnas_14) ? string.Empty : data.qnas_14;
            data.qnas_15 = string.IsNullOrEmpty(data.qnas_15) ? string.Empty : data.qnas_15;
            data.qnas_16 = string.IsNullOrEmpty(data.qnas_16) ? string.Empty : data.qnas_16;
            data.qnas_17 = string.IsNullOrEmpty(data.qnas_17) ? string.Empty : data.qnas_17;
            data.qnas_18 = string.IsNullOrEmpty(data.qnas_18) ? string.Empty : data.qnas_18;
            data.qnas_19 = string.IsNullOrEmpty(data.qnas_19) ? string.Empty : data.qnas_19;
            data.qnas_20 = string.IsNullOrEmpty(data.qnas_20) ? string.Empty : data.qnas_20;
            data.qnas_21 = string.IsNullOrEmpty(data.qnas_21) ? string.Empty : data.qnas_21;
            DateTime? card1 = data.qnas_date1; // Assuming data.qnas_d1 is of type DateTime?  
            if (data.qnas_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.qnas_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.qnas_date1 = DateTime.Parse("01/01/1950");
            }           
            return DataAccessLayer.EMRForms.QICNAS.InsertUpdateQICNAS(data);
        }
        //Delete
        public static int DeleteQICNAS(int qnasId, int qnas_madeby)
        {
            return DataAccessLayer.EMRForms.QICNAS.DeleteQICNAS(qnasId, qnas_madeby);
        }
        #endregion QICNAS (CRUD Operations)
    }
    public class Gulfcare
    {
        #region Gulfcare (Page Load)
        public static List<BusinessEntities.EMRForms.Gulfcare> GetAllGulfcare(int appId)
        {
            List<BusinessEntities.EMRForms.Gulfcare> sclist = new List<BusinessEntities.EMRForms.Gulfcare>();
            DataTable dt = DataAccessLayer.EMRForms.Gulfcare.GetAllGulfcare(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Gulfcare
                {
                    gucnId = Convert.ToInt32(dr["gucnId"]),
                    gucn_appId = Convert.ToInt32(dr["gucn_appId"]),
                    gucn_checkbox = dr["gucn_checkbox"].ToString(),
                    gucn_1 = dr["gucn_1"].ToString(),
                    gucn_2 = dr["gucn_2"].ToString(),
                    gucn_3 = dr["gucn_3"].ToString(),
                    gucn_4 = dr["gucn_4"].ToString(),
                    gucn_5 = dr["gucn_5"].ToString(),
                    gucn_6 = dr["gucn_6"].ToString(),
                    gucn_7 = dr["gucn_7"].ToString(),
                    gucn_8 = dr["gucn_8"].ToString(),
                    gucn_9 = dr["gucn_9"].ToString(),
                    gucn_10 = dr["gucn_10"].ToString(),
                    gucn_11 = dr["gucn_11"].ToString(),
                    gucn_12 = dr["gucn_12"].ToString(),
                    gucn_13 = dr["gucn_13"].ToString(),
                    gucn_14 = dr["gucn_14"].ToString(),
                    gucn_15 = dr["gucn_15"].ToString(),
                    gucn_16 = dr["gucn_16"].ToString(),
                    gucn_17 = dr["gucn_17"].ToString(),
                    gucn_18 = dr["gucn_18"].ToString(),
                    gucn_19 = dr["gucn_19"].ToString(),
                    gucn_20 = dr["gucn_20"].ToString(),
                    gucn_21 = dr["gucn_21"].ToString(),
                    gucn_22 = dr["gucn_22"].ToString(),
                    gucn_23 = dr["gucn_23"].ToString(),
                    gucn_24 = dr["gucn_24"].ToString(),
                    gucn_25 = dr["gucn_25"].ToString(),
                    gucn_26 = dr["gucn_26"].ToString(),
                    gucn_27 = dr["gucn_27"].ToString(),
                    gucn_28 = dr["gucn_28"].ToString(),
                    gucn_29 = dr["gucn_29"].ToString(),
                    gucn_30 = dr["gucn_30"].ToString(),
                    gucn_31 = dr["gucn_31"].ToString(),
                    gucn_32 = dr["gucn_32"].ToString(),
                    gucn_33 = dr["gucn_33"].ToString(),
                    gucn_34 = dr["gucn_34"].ToString(),
                    gucn_35 = dr["gucn_35"].ToString(),
                    gucn_36 = dr["gucn_36"].ToString(),
                    gucn_37 = dr["gucn_37"].ToString(),
                    gucn_38 = dr["gucn_38"].ToString(),
                    gucn_39 = dr["gucn_39"].ToString(),
                    gucn_40 = dr["gucn_40"].ToString(),
                    gucn_41 = dr["gucn_41"].ToString(),
                    gucn_42 = dr["gucn_42"].ToString(),
                    gucn_43 = dr["gucn_43"].ToString(),                   
                    gucn_date_created = Convert.ToDateTime(dr["gucn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Gulfcare> GetAllPreGulfcare(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Gulfcare> sclist = new List<BusinessEntities.EMRForms.Gulfcare>();
            DataTable dt = DataAccessLayer.EMRForms.Gulfcare.GetAllPreGulfcare(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Gulfcare
                {
                    gucnId = Convert.ToInt32(dr["gucnId"]),
                    gucn_appId = Convert.ToInt32(dr["gucn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Gulfcare> GetPrintGulfcare(int? gucnId)
        {
            List<BusinessEntities.EMRForms.Gulfcare> sclist = new List<BusinessEntities.EMRForms.Gulfcare>();
            DataTable dt = DataAccessLayer.EMRForms.Gulfcare.GetPrintGulfcare(gucnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Gulfcare
                    {
                        gucnId = Convert.ToInt32(dr["gucnId"]),
                        gucn_appId = Convert.ToInt32(dr["gucn_appId"]),
                        gucn_checkbox = dr["gucn_checkbox"].ToString(),
                        gucn_1 = dr["gucn_1"].ToString(),
                        gucn_2 = dr["gucn_2"].ToString(),
                        gucn_3 = dr["gucn_3"].ToString(),
                        gucn_4 = dr["gucn_4"].ToString(),
                        gucn_5 = dr["gucn_5"].ToString(),
                        gucn_6 = dr["gucn_6"].ToString(),
                        gucn_7 = dr["gucn_7"].ToString(),
                        gucn_8 = dr["gucn_8"].ToString(),
                        gucn_9 = dr["gucn_9"].ToString(),
                        gucn_10 = dr["gucn_10"].ToString(),
                        gucn_11 = dr["gucn_11"].ToString(),
                        gucn_12 = dr["gucn_12"].ToString(),
                        gucn_13 = dr["gucn_13"].ToString(),
                        gucn_14 = dr["gucn_14"].ToString(),
                        gucn_15 = dr["gucn_15"].ToString(),
                        gucn_16 = dr["gucn_16"].ToString(),
                        gucn_17 = dr["gucn_17"].ToString(),
                        gucn_18 = dr["gucn_18"].ToString(),
                        gucn_19 = dr["gucn_19"].ToString(),
                        gucn_20 = dr["gucn_20"].ToString(),
                        gucn_21 = dr["gucn_21"].ToString(),
                        gucn_22 = dr["gucn_22"].ToString(),
                        gucn_23 = dr["gucn_23"].ToString(),
                        gucn_24 = dr["gucn_24"].ToString(),
                        gucn_25 = dr["gucn_25"].ToString(),
                        gucn_26 = dr["gucn_26"].ToString(),
                        gucn_27 = dr["gucn_27"].ToString(),
                        gucn_28 = dr["gucn_28"].ToString(),
                        gucn_29 = dr["gucn_29"].ToString(),
                        gucn_30 = dr["gucn_30"].ToString(),
                        gucn_31 = dr["gucn_31"].ToString(),
                        gucn_32 = dr["gucn_32"].ToString(),
                        gucn_33 = dr["gucn_33"].ToString(),
                        gucn_34 = dr["gucn_34"].ToString(),
                        gucn_35 = dr["gucn_35"].ToString(),
                        gucn_36 = dr["gucn_36"].ToString(),
                        gucn_37 = dr["gucn_37"].ToString(),
                        gucn_38 = dr["gucn_38"].ToString(),
                        gucn_39 = dr["gucn_39"].ToString(),
                        gucn_40 = dr["gucn_40"].ToString(),
                        gucn_41 = dr["gucn_41"].ToString(),
                        gucn_42 = dr["gucn_42"].ToString(),
                        gucn_43 = dr["gucn_43"].ToString(),

                        gucn_date_created = Convert.ToDateTime(dr["gucn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Gulfcare a = new BusinessEntities.EMRForms.Gulfcare();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Gulfcare (Page Load)

        #region Gulfcare (CRUD Operations)
        //insert&update
        public static bool InsertUpdateGulfcare(BusinessEntities.EMRForms.Gulfcare data)
        {
            data.gucn_checkbox = string.IsNullOrEmpty(data.gucn_checkbox) ? string.Empty : data.gucn_checkbox;
            data.gucn_1 = string.IsNullOrEmpty(data.gucn_1) ? string.Empty : data.gucn_1;
            data.gucn_2 = string.IsNullOrEmpty(data.gucn_2) ? string.Empty : data.gucn_2;
            data.gucn_3 = string.IsNullOrEmpty(data.gucn_3) ? string.Empty : data.gucn_3;
            data.gucn_4 = string.IsNullOrEmpty(data.gucn_4) ? string.Empty : data.gucn_4;
            data.gucn_5 = string.IsNullOrEmpty(data.gucn_5) ? string.Empty : data.gucn_5;
            data.gucn_6 = string.IsNullOrEmpty(data.gucn_6) ? string.Empty : data.gucn_6;
            data.gucn_7 = string.IsNullOrEmpty(data.gucn_7) ? string.Empty : data.gucn_7;
            data.gucn_8 = string.IsNullOrEmpty(data.gucn_8) ? string.Empty : data.gucn_8;
            data.gucn_9 = string.IsNullOrEmpty(data.gucn_9) ? string.Empty : data.gucn_9;
            data.gucn_10 = string.IsNullOrEmpty(data.gucn_10) ? string.Empty : data.gucn_10;
            data.gucn_11 = string.IsNullOrEmpty(data.gucn_11) ? string.Empty : data.gucn_11;
            data.gucn_12 = string.IsNullOrEmpty(data.gucn_12) ? string.Empty : data.gucn_12;
            data.gucn_13 = string.IsNullOrEmpty(data.gucn_13) ? string.Empty : data.gucn_13;
            data.gucn_14 = string.IsNullOrEmpty(data.gucn_14) ? string.Empty : data.gucn_14;
            data.gucn_15 = string.IsNullOrEmpty(data.gucn_15) ? string.Empty : data.gucn_15;
            data.gucn_16 = string.IsNullOrEmpty(data.gucn_16) ? string.Empty : data.gucn_16;
            data.gucn_17 = string.IsNullOrEmpty(data.gucn_17) ? string.Empty : data.gucn_17;
            data.gucn_18 = string.IsNullOrEmpty(data.gucn_18) ? string.Empty : data.gucn_18;
            data.gucn_19 = string.IsNullOrEmpty(data.gucn_19) ? string.Empty : data.gucn_19;
            data.gucn_20 = string.IsNullOrEmpty(data.gucn_20) ? string.Empty : data.gucn_20;
            data.gucn_21 = string.IsNullOrEmpty(data.gucn_21) ? string.Empty : data.gucn_21;
            data.gucn_22 = string.IsNullOrEmpty(data.gucn_22) ? string.Empty : data.gucn_22;
            data.gucn_23 = string.IsNullOrEmpty(data.gucn_23) ? string.Empty : data.gucn_23;
            data.gucn_24 = string.IsNullOrEmpty(data.gucn_24) ? string.Empty : data.gucn_24;
            data.gucn_25 = string.IsNullOrEmpty(data.gucn_25) ? string.Empty : data.gucn_25;
            data.gucn_26 = string.IsNullOrEmpty(data.gucn_26) ? string.Empty : data.gucn_26;
            data.gucn_27 = string.IsNullOrEmpty(data.gucn_27) ? string.Empty : data.gucn_27;
            data.gucn_28 = string.IsNullOrEmpty(data.gucn_28) ? string.Empty : data.gucn_28;
            data.gucn_29 = string.IsNullOrEmpty(data.gucn_29) ? string.Empty : data.gucn_29;
            data.gucn_30 = string.IsNullOrEmpty(data.gucn_30) ? string.Empty : data.gucn_30;
            data.gucn_31 = string.IsNullOrEmpty(data.gucn_31) ? string.Empty : data.gucn_31;
            data.gucn_32 = string.IsNullOrEmpty(data.gucn_32) ? string.Empty : data.gucn_32;
            data.gucn_33 = string.IsNullOrEmpty(data.gucn_33) ? string.Empty : data.gucn_33;
            data.gucn_34 = string.IsNullOrEmpty(data.gucn_34) ? string.Empty : data.gucn_34;
            data.gucn_35 = string.IsNullOrEmpty(data.gucn_35) ? string.Empty : data.gucn_35;
            data.gucn_36 = string.IsNullOrEmpty(data.gucn_36) ? string.Empty : data.gucn_36;
            data.gucn_37 = string.IsNullOrEmpty(data.gucn_37) ? string.Empty : data.gucn_37;
            data.gucn_38 = string.IsNullOrEmpty(data.gucn_38) ? string.Empty : data.gucn_38;
            data.gucn_39 = string.IsNullOrEmpty(data.gucn_39) ? string.Empty : data.gucn_39;
            data.gucn_40 = string.IsNullOrEmpty(data.gucn_40) ? string.Empty : data.gucn_40;
            data.gucn_41 = string.IsNullOrEmpty(data.gucn_41) ? string.Empty : data.gucn_41;
            data.gucn_42 = string.IsNullOrEmpty(data.gucn_42) ? string.Empty : data.gucn_42;
            data.gucn_43 = string.IsNullOrEmpty(data.gucn_43) ? string.Empty : data.gucn_43;
            return DataAccessLayer.EMRForms.Gulfcare.InsertUpdateGulfcare(data);
        }
        //Delete
        public static int DeleteGulfcare(int gucnId, int gucn_madeby)
        {
            return DataAccessLayer.EMRForms.Gulfcare.DeleteGulfcare(gucnId, gucn_madeby);
        }
        #endregion Gulfcare (CRUD Operations)
    }
    public class Goldstar
    {
        #region Goldstar (Page Load)
        public static List<BusinessEntities.EMRForms.Goldstar> GetAllGoldstar(int appId)
        {
            List<BusinessEntities.EMRForms.Goldstar> sclist = new List<BusinessEntities.EMRForms.Goldstar>();
            DataTable dt = DataAccessLayer.EMRForms.Goldstar.GetAllGoldstar(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Goldstar
                {
                    cgsnId = Convert.ToInt32(dr["cgsnId"]),
                    cgsn_appId = Convert.ToInt32(dr["cgsn_appId"]),
                    cgsn_checkbox = dr["cgsn_checkbox"].ToString(),
                    cgsn_1 = dr["cgsn_1"].ToString(),
                    cgsn_2 = dr["cgsn_2"].ToString(),
                    cgsn_3 = dr["cgsn_3"].ToString(),
                    cgsn_4 = dr["cgsn_4"].ToString(),
                    cgsn_5 = dr["cgsn_5"].ToString(),
                    cgsn_6 = dr["cgsn_6"].ToString(),
                    cgsn_7 = dr["cgsn_7"].ToString(),
                    cgsn_8 = dr["cgsn_8"].ToString(),
                    cgsn_9 = dr["cgsn_9"].ToString(),
                    cgsn_10 = dr["cgsn_10"].ToString(),
                    cgsn_11 = dr["cgsn_11"].ToString(),
                    cgsn_12 = dr["cgsn_12"].ToString(),
                    cgsn_13 = dr["cgsn_13"].ToString(),
                    cgsn_14 = dr["cgsn_14"].ToString(),
                    cgsn_15 = dr["cgsn_15"].ToString(),
                    cgsn_16 = dr["cgsn_16"].ToString(),
                    cgsn_17 = dr["cgsn_17"].ToString(),
                    cgsn_18 = dr["cgsn_18"].ToString(),
                    cgsn_19 = dr["cgsn_19"].ToString(),
                    cgsn_20 = dr["cgsn_20"].ToString(),
                    cgsn_21 = dr["cgsn_21"].ToString(),
                    cgsn_22 = dr["cgsn_22"].ToString(),
                    cgsn_23 = dr["cgsn_23"].ToString(),
                    cgsn_24 = dr["cgsn_24"].ToString(),
                    cgsn_25 = dr["cgsn_25"].ToString(),
                    cgsn_26 = dr["cgsn_26"].ToString(),
                    cgsn_27 = dr["cgsn_27"].ToString(),
                    cgsn_28 = dr["cgsn_28"].ToString(),
                    cgsn_29 = dr["cgsn_29"].ToString(),
                    cgsn_30 = dr["cgsn_30"].ToString(),
                    cgsn_31 = dr["cgsn_31"].ToString(),
                    cgsn_date_created = Convert.ToDateTime(dr["cgsn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Goldstar> GetAllPreGoldstar(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Goldstar> sclist = new List<BusinessEntities.EMRForms.Goldstar>();
            DataTable dt = DataAccessLayer.EMRForms.Goldstar.GetAllPreGoldstar(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Goldstar
                {
                    cgsnId = Convert.ToInt32(dr["cgsnId"]),
                    cgsn_appId = Convert.ToInt32(dr["cgsn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.Goldstar> GetPrintGoldstar(int? cgsnId)
        {
            List<BusinessEntities.EMRForms.Goldstar> sclist = new List<BusinessEntities.EMRForms.Goldstar>();
            DataTable dt = DataAccessLayer.EMRForms.Goldstar.GetPrintGoldstar(cgsnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Goldstar
                    {
                        cgsnId = Convert.ToInt32(dr["cgsnId"]),
                        cgsn_appId = Convert.ToInt32(dr["cgsn_appId"]),
                        cgsn_checkbox = dr["cgsn_checkbox"].ToString(),
                        cgsn_1 = dr["cgsn_1"].ToString(),
                        cgsn_2 = dr["cgsn_2"].ToString(),
                        cgsn_3 = dr["cgsn_3"].ToString(),
                        cgsn_4 = dr["cgsn_4"].ToString(),
                        cgsn_5 = dr["cgsn_5"].ToString(),
                        cgsn_6 = dr["cgsn_6"].ToString(),
                        cgsn_7 = dr["cgsn_7"].ToString(),
                        cgsn_8 = dr["cgsn_8"].ToString(),
                        cgsn_9 = dr["cgsn_9"].ToString(),
                        cgsn_10 = dr["cgsn_10"].ToString(),
                        cgsn_11 = dr["cgsn_11"].ToString(),
                        cgsn_12 = dr["cgsn_12"].ToString(),
                        cgsn_13 = dr["cgsn_13"].ToString(),
                        cgsn_14 = dr["cgsn_14"].ToString(),
                        cgsn_15 = dr["cgsn_15"].ToString(),
                        cgsn_16 = dr["cgsn_16"].ToString(),
                        cgsn_17 = dr["cgsn_17"].ToString(),
                        cgsn_18 = dr["cgsn_18"].ToString(),
                        cgsn_19 = dr["cgsn_19"].ToString(),
                        cgsn_20 = dr["cgsn_20"].ToString(),
                        cgsn_21 = dr["cgsn_21"].ToString(),
                        cgsn_22 = dr["cgsn_22"].ToString(),
                        cgsn_23 = dr["cgsn_23"].ToString(),
                        cgsn_24 = dr["cgsn_24"].ToString(),
                        cgsn_25 = dr["cgsn_25"].ToString(),
                        cgsn_26 = dr["cgsn_26"].ToString(),
                        cgsn_27 = dr["cgsn_27"].ToString(),
                        cgsn_28 = dr["cgsn_28"].ToString(),
                        cgsn_29 = dr["cgsn_29"].ToString(),
                        cgsn_30 = dr["cgsn_30"].ToString(),
                        cgsn_31 = dr["cgsn_31"].ToString(),

                        cgsn_date_created = Convert.ToDateTime(dr["cgsn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Goldstar a = new BusinessEntities.EMRForms.Goldstar();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Goldstar (Page Load)

        #region Goldstar (CRUD Operations)
        //insert&update
        public static bool InsertUpdateGoldstar(BusinessEntities.EMRForms.Goldstar data)
        {
            data.cgsn_checkbox = string.IsNullOrEmpty(data.cgsn_checkbox) ? string.Empty : data.cgsn_checkbox;
            data.cgsn_1 = string.IsNullOrEmpty(data.cgsn_1) ? string.Empty : data.cgsn_1;
            data.cgsn_2 = string.IsNullOrEmpty(data.cgsn_2) ? string.Empty : data.cgsn_2;
            data.cgsn_3 = string.IsNullOrEmpty(data.cgsn_3) ? string.Empty : data.cgsn_3;
            data.cgsn_4 = string.IsNullOrEmpty(data.cgsn_4) ? string.Empty : data.cgsn_4;
            data.cgsn_5 = string.IsNullOrEmpty(data.cgsn_5) ? string.Empty : data.cgsn_5;
            data.cgsn_6 = string.IsNullOrEmpty(data.cgsn_6) ? string.Empty : data.cgsn_6;
            data.cgsn_7 = string.IsNullOrEmpty(data.cgsn_7) ? string.Empty : data.cgsn_7;
            data.cgsn_8 = string.IsNullOrEmpty(data.cgsn_8) ? string.Empty : data.cgsn_8;
            data.cgsn_9 = string.IsNullOrEmpty(data.cgsn_9) ? string.Empty : data.cgsn_9;
            data.cgsn_10 = string.IsNullOrEmpty(data.cgsn_10) ? string.Empty : data.cgsn_10;
            data.cgsn_11 = string.IsNullOrEmpty(data.cgsn_11) ? string.Empty : data.cgsn_11;
            data.cgsn_12 = string.IsNullOrEmpty(data.cgsn_12) ? string.Empty : data.cgsn_12;
            data.cgsn_13 = string.IsNullOrEmpty(data.cgsn_13) ? string.Empty : data.cgsn_13;
            data.cgsn_14 = string.IsNullOrEmpty(data.cgsn_14) ? string.Empty : data.cgsn_14;
            data.cgsn_15 = string.IsNullOrEmpty(data.cgsn_15) ? string.Empty : data.cgsn_15;
            data.cgsn_16 = string.IsNullOrEmpty(data.cgsn_16) ? string.Empty : data.cgsn_16;
            data.cgsn_17 = string.IsNullOrEmpty(data.cgsn_17) ? string.Empty : data.cgsn_17;
            data.cgsn_18 = string.IsNullOrEmpty(data.cgsn_18) ? string.Empty : data.cgsn_18;
            data.cgsn_19 = string.IsNullOrEmpty(data.cgsn_19) ? string.Empty : data.cgsn_19;
            data.cgsn_20 = string.IsNullOrEmpty(data.cgsn_20) ? string.Empty : data.cgsn_20;
            data.cgsn_21 = string.IsNullOrEmpty(data.cgsn_21) ? string.Empty : data.cgsn_21;
            data.cgsn_22 = string.IsNullOrEmpty(data.cgsn_22) ? string.Empty : data.cgsn_22;
            data.cgsn_23 = string.IsNullOrEmpty(data.cgsn_23) ? string.Empty : data.cgsn_23;
            data.cgsn_24 = string.IsNullOrEmpty(data.cgsn_24) ? string.Empty : data.cgsn_24;
            data.cgsn_25 = string.IsNullOrEmpty(data.cgsn_25) ? string.Empty : data.cgsn_25;
            data.cgsn_26 = string.IsNullOrEmpty(data.cgsn_26) ? string.Empty : data.cgsn_26;
            data.cgsn_27 = string.IsNullOrEmpty(data.cgsn_27) ? string.Empty : data.cgsn_27;
            data.cgsn_28 = string.IsNullOrEmpty(data.cgsn_28) ? string.Empty : data.cgsn_28;
            data.cgsn_29 = string.IsNullOrEmpty(data.cgsn_29) ? string.Empty : data.cgsn_29;
            data.cgsn_30 = string.IsNullOrEmpty(data.cgsn_30) ? string.Empty : data.cgsn_30;
            data.cgsn_31 = string.IsNullOrEmpty(data.cgsn_31) ? string.Empty : data.cgsn_31;
            return DataAccessLayer.EMRForms.Goldstar.InsertUpdateGoldstar(data);
        }
        //Delete
        public static int DeleteGoldstar(int cgsnId, int cgsn_madeby)
        {
            return DataAccessLayer.EMRForms.Goldstar.DeleteGoldstar(cgsnId, cgsn_madeby);
        }
        #endregion Goldstar (CRUD Operations)
    }
    public class HealthInternational
    {
        #region HealthInternational (Page Load)
        public static List<BusinessEntities.EMRForms.HealthInternational> GetAllHealthInternational(int appId)
        {
            List<BusinessEntities.EMRForms.HealthInternational> sclist = new List<BusinessEntities.EMRForms.HealthInternational>();
            DataTable dt = DataAccessLayer.EMRForms.HealthInternational.GetAllHealthInternational(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.HealthInternational
                {
                    chinId = Convert.ToInt32(dr["chinId"]),
                    chin_appId = Convert.ToInt32(dr["chin_appId"]),
                    chin_checkbox = dr["chin_checkbox"].ToString(),
                    chin_1 = dr["chin_1"].ToString(),
                    chin_2 = dr["chin_2"].ToString(),
                    chin_3 = dr["chin_3"].ToString(),
                    chin_4 = dr["chin_4"].ToString(),
                    chin_5 = dr["chin_5"].ToString(),
                    chin_6 = dr["chin_6"].ToString(),
                    chin_7 = dr["chin_7"].ToString(),
                    chin_8 = dr["chin_8"].ToString(),
                    chin_9 = dr["chin_9"].ToString(),
                    chin_10 = dr["chin_10"].ToString(),
                    chin_11 = dr["chin_11"].ToString(),
                    chin_date1 = Convert.ToDateTime(dr["chin_date1"].ToString()),
                    chin_date2 = Convert.ToDateTime(dr["chin_date2"].ToString()),
                    chin_date3 = Convert.ToDateTime(dr["chin_date3"].ToString()),
                    chin_date_created = Convert.ToDateTime(dr["chin_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.HealthInternational> GetAllPreHealthInternational(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.HealthInternational> sclist = new List<BusinessEntities.EMRForms.HealthInternational>();
            DataTable dt = DataAccessLayer.EMRForms.HealthInternational.GetAllPreHealthInternational(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.HealthInternational
                {
                    chinId = Convert.ToInt32(dr["chinId"]),
                    chin_appId = Convert.ToInt32(dr["chin_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.HealthInternational> GetPrintHealthInternational(int? chinId)
        {
            List<BusinessEntities.EMRForms.HealthInternational> sclist = new List<BusinessEntities.EMRForms.HealthInternational>();
            DataTable dt = DataAccessLayer.EMRForms.HealthInternational.GetPrintHealthInternational(chinId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.HealthInternational
                    {
                        chinId = Convert.ToInt32(dr["chinId"]),
                        chin_appId = Convert.ToInt32(dr["chin_appId"]),
                        chin_checkbox = dr["chin_checkbox"].ToString(),
                        chin_1 = dr["chin_1"].ToString(),
                        chin_2 = dr["chin_2"].ToString(),
                        chin_3 = dr["chin_3"].ToString(),
                        chin_4 = dr["chin_4"].ToString(),
                        chin_5 = dr["chin_5"].ToString(),
                        chin_6 = dr["chin_6"].ToString(),
                        chin_7 = dr["chin_7"].ToString(),
                        chin_8 = dr["chin_8"].ToString(),
                        chin_9 = dr["chin_9"].ToString(),
                        chin_10 = dr["chin_10"].ToString(),
                        chin_11 = dr["chin_11"].ToString(),
                        chin_dd1 = dr["chin_date1"].ToString(),
                        chin_dd2 = dr["chin_date2"].ToString(),
                        chin_dd3 = dr["chin_date3"].ToString(),

                        chin_date_created = Convert.ToDateTime(dr["chin_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.HealthInternational a = new BusinessEntities.EMRForms.HealthInternational();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion HealthInternational (Page Load)

        #region HealthInternational (CRUD Operations)
        //insert&update
        public static bool InsertUpdateHealthInternational(BusinessEntities.EMRForms.HealthInternational data)
        {
            data.chin_checkbox = string.IsNullOrEmpty(data.chin_checkbox) ? string.Empty : data.chin_checkbox;
            data.chin_1 = string.IsNullOrEmpty(data.chin_1) ? string.Empty : data.chin_1;
            data.chin_2 = string.IsNullOrEmpty(data.chin_2) ? string.Empty : data.chin_2;
            data.chin_3 = string.IsNullOrEmpty(data.chin_3) ? string.Empty : data.chin_3;
            data.chin_4 = string.IsNullOrEmpty(data.chin_4) ? string.Empty : data.chin_4;
            data.chin_5 = string.IsNullOrEmpty(data.chin_5) ? string.Empty : data.chin_5;
            data.chin_6 = string.IsNullOrEmpty(data.chin_6) ? string.Empty : data.chin_6;
            data.chin_7 = string.IsNullOrEmpty(data.chin_7) ? string.Empty : data.chin_7;
            data.chin_8 = string.IsNullOrEmpty(data.chin_8) ? string.Empty : data.chin_8;
            data.chin_9 = string.IsNullOrEmpty(data.chin_9) ? string.Empty : data.chin_9;
            data.chin_10 = string.IsNullOrEmpty(data.chin_10) ? string.Empty : data.chin_10;
            data.chin_11 = string.IsNullOrEmpty(data.chin_11) ? string.Empty : data.chin_11;
            DateTime? card1 = data.chin_date1; // Assuming data.chin_date1 is of type DateTime?            
            DateTime? card2 = data.chin_date2; // Assuming data.chin_date2 is of type DateTime?
            DateTime? card3 = data.chin_date3; // Assuming data.chin_date3 is of type DateTime?
            if (data.chin_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.chin_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.chin_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.chin_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.chin_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.chin_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.chin_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.chin_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.chin_date3 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.HealthInternational.InsertUpdateHealthInternational(data);
        }
        //Delete
        public static int DeleteHealthInternational(int chinId, int chin_madeby)
        {
            return DataAccessLayer.EMRForms.HealthInternational.DeleteHealthInternational(chinId, chin_madeby);
        }
        #endregion HealthInternational (CRUD Operations)
    }

    public class NasDental
    {
        #region NasDental (Page Load)
        public static List<BusinessEntities.EMRForms.NasDental> GetAllNasDental(int appId)
        {
            List<BusinessEntities.EMRForms.NasDental> sclist = new List<BusinessEntities.EMRForms.NasDental>();
            DataTable dt = DataAccessLayer.EMRForms.NasDental.GetAllNasDental(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NasDental
                {
                    cndnId = Convert.ToInt32(dr["cndnId"]),
                    cndn_appId = Convert.ToInt32(dr["cndn_appId"]),
                    cndn_chk = dr["cndn_chk"].ToString(),
                    cndn_1 = dr["cndn_1"].ToString(),
                    cndn_2 = dr["cndn_2"].ToString(),
                    cndn_3 = dr["cndn_3"].ToString(),
                    cndn_4 = dr["cndn_4"].ToString(),
                    cndn_5 = dr["cndn_5"].ToString(),
                    cndn_6 = dr["cndn_6"].ToString(),
                    cndn_7 = dr["cndn_7"].ToString(),
                    cndn_date_created = Convert.ToDateTime(dr["cndn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NasDental> GetAllPreNasDental(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NasDental> sclist = new List<BusinessEntities.EMRForms.NasDental>();
            DataTable dt = DataAccessLayer.EMRForms.NasDental.GetAllPreNasDental(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NasDental
                {
                    cndnId = Convert.ToInt32(dr["cndnId"]),
                    cndn_appId = Convert.ToInt32(dr["cndn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.NasDental> GetPrintNasDental(int? cndnId)
        {
            List<BusinessEntities.EMRForms.NasDental> sclist = new List<BusinessEntities.EMRForms.NasDental>();
            DataTable dt = DataAccessLayer.EMRForms.NasDental.GetPrintNasDental(cndnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NasDental
                    {
                        cndnId = Convert.ToInt32(dr["cndnId"]),
                        cndn_appId = Convert.ToInt32(dr["cndn_appId"]),
                        cndn_chk = dr["cndn_chk"].ToString(),
                        cndn_1 = dr["cndn_1"].ToString(),
                        cndn_2 = dr["cndn_2"].ToString(),
                        cndn_3 = dr["cndn_3"].ToString(),
                        cndn_4 = dr["cndn_4"].ToString(),
                        cndn_5 = dr["cndn_5"].ToString(),
                        cndn_6 = dr["cndn_6"].ToString(),
                        cndn_7 = dr["cndn_7"].ToString(),

                        cndn_date_created = Convert.ToDateTime(dr["cndn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NasDental a = new BusinessEntities.EMRForms.NasDental();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion NasDental (Page Load)

        #region NasDental (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNasDental(BusinessEntities.EMRForms.NasDental data)
        {
            data.cndn_chk = string.IsNullOrEmpty(data.cndn_chk) ? string.Empty : data.cndn_chk;
            data.cndn_1 = string.IsNullOrEmpty(data.cndn_1) ? string.Empty : data.cndn_1;
            data.cndn_2 = string.IsNullOrEmpty(data.cndn_2) ? string.Empty : data.cndn_2;
            data.cndn_3 = string.IsNullOrEmpty(data.cndn_3) ? string.Empty : data.cndn_3;
            data.cndn_4 = string.IsNullOrEmpty(data.cndn_4) ? string.Empty : data.cndn_4;
            data.cndn_5 = string.IsNullOrEmpty(data.cndn_5) ? string.Empty : data.cndn_5;
            data.cndn_6 = string.IsNullOrEmpty(data.cndn_6) ? string.Empty : data.cndn_6;
            data.cndn_7 = string.IsNullOrEmpty(data.cndn_7) ? string.Empty : data.cndn_7;
            return DataAccessLayer.EMRForms.NasDental.InsertUpdateNasDental(data);
        }
        //Delete
        public static int DeleteNasDental(int cndnId, int cndn_madeby)
        {
            return DataAccessLayer.EMRForms.NasDental.DeleteNasDental(cndnId, cndn_madeby);
        }
        #endregion NasDental (CRUD Operations)
    }
    public class NasPrescription
    {
        #region NasPrescription (Page Load)
        public static List<BusinessEntities.EMRForms.NasPrescription> GetAllNasPrescription(int appId)
        {
            List<BusinessEntities.EMRForms.NasPrescription> sclist = new List<BusinessEntities.EMRForms.NasPrescription>();
            DataTable dt = DataAccessLayer.EMRForms.NasPrescription.GetAllNasPrescription(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NasPrescription
                {
                    cnrnId = Convert.ToInt32(dr["cnrnId"]),
                    cnrn_appId = Convert.ToInt32(dr["cnrn_appId"]),
                    cnrn_chk = dr["cnrn_chk"].ToString(),
                    cnrn_1 = dr["cnrn_1"].ToString(),
                    cnrn_2 = dr["cnrn_2"].ToString(),
                    cnrn_3 = dr["cnrn_3"].ToString(),
                    cnrn_4 = dr["cnrn_4"].ToString(),
                    cnrn_5 = dr["cnrn_5"].ToString(),
                    cnrn_6 = dr["cnrn_6"].ToString(),
                    cnrn_date_created = Convert.ToDateTime(dr["cnrn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NasPrescription> GetAllPreNasPrescription(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NasPrescription> sclist = new List<BusinessEntities.EMRForms.NasPrescription>();
            DataTable dt = DataAccessLayer.EMRForms.NasPrescription.GetAllPreNasPrescription(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NasPrescription
                {
                    cnrnId = Convert.ToInt32(dr["cnrnId"]),
                    cnrn_appId = Convert.ToInt32(dr["cnrn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.NasPrescription> GetPrintNasPrescription(int? cnrnId)
        {
            List<BusinessEntities.EMRForms.NasPrescription> sclist = new List<BusinessEntities.EMRForms.NasPrescription>();
            DataTable dt = DataAccessLayer.EMRForms.NasPrescription.GetPrintNasPrescription(cnrnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NasPrescription
                    {
                        cnrnId = Convert.ToInt32(dr["cnrnId"]),
                        cnrn_appId = Convert.ToInt32(dr["cnrn_appId"]),
                        cnrn_chk = dr["cnrn_chk"].ToString(),
                        cnrn_1 = dr["cnrn_1"].ToString(),
                        cnrn_2 = dr["cnrn_2"].ToString(),
                        cnrn_3 = dr["cnrn_3"].ToString(),
                        cnrn_4 = dr["cnrn_4"].ToString(),
                        cnrn_5 = dr["cnrn_5"].ToString(),
                        cnrn_6 = dr["cnrn_6"].ToString(),

                        cnrn_date_created = Convert.ToDateTime(dr["cnrn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NasPrescription a = new BusinessEntities.EMRForms.NasPrescription();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion NasPrescription (Page Load)

        #region NasPrescription (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNasPrescription(BusinessEntities.EMRForms.NasPrescription data)
        {
            data.cnrn_chk = string.IsNullOrEmpty(data.cnrn_chk) ? string.Empty : data.cnrn_chk;
            data.cnrn_1 = string.IsNullOrEmpty(data.cnrn_1) ? string.Empty : data.cnrn_1;
            data.cnrn_2 = string.IsNullOrEmpty(data.cnrn_2) ? string.Empty : data.cnrn_2;
            data.cnrn_3 = string.IsNullOrEmpty(data.cnrn_3) ? string.Empty : data.cnrn_3;
            data.cnrn_4 = string.IsNullOrEmpty(data.cnrn_4) ? string.Empty : data.cnrn_4;
            data.cnrn_5 = string.IsNullOrEmpty(data.cnrn_5) ? string.Empty : data.cnrn_5;
            data.cnrn_6 = string.IsNullOrEmpty(data.cnrn_6) ? string.Empty : data.cnrn_6;
            return DataAccessLayer.EMRForms.NasPrescription.InsertUpdateNasPrescription(data);
        }
        //Delete
        public static int DeleteNasPrescription(int cnrnId, int cnrn_madeby)
        {
            return DataAccessLayer.EMRForms.NasPrescription.DeleteNasPrescription(cnrnId, cnrn_madeby);
        }
        #endregion NasPrescription (CRUD Operations)
    }

    public class OmanDental
    {
        #region OmanDental (Page Load)
        public static List<BusinessEntities.EMRForms.OmanDental> GetAllOmanDental(int appId)
        {
            List<BusinessEntities.EMRForms.OmanDental> sclist = new List<BusinessEntities.EMRForms.OmanDental>();
            DataTable dt = DataAccessLayer.EMRForms.OmanDental.GetAllOmanDental(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.OmanDental
                {
                    codnId = Convert.ToInt32(dr["codnId"]),
                    codn_appId = Convert.ToInt32(dr["codn_appId"]),
                    codn_checkbox = dr["codn_checkbox"].ToString(),
                    codn_1 = dr["codn_1"].ToString(),
                    codn_2 = dr["codn_2"].ToString(),
                    codn_3 = dr["codn_3"].ToString(),
                    codn_4 = dr["codn_4"].ToString(),
                    codn_5 = dr["codn_5"].ToString(),
                    codn_6 = dr["codn_6"].ToString(),
                    codn_7 = dr["codn_7"].ToString(),
                    codn_8 = dr["codn_8"].ToString(),
                    codn_9 = dr["codn_9"].ToString(),
                    codn_10 = dr["codn_10"].ToString(),
                    codn_11 = dr["codn_11"].ToString(),
                    codn_12 = dr["codn_12"].ToString(),
                    codn_13 = dr["codn_13"].ToString(),
                    codn_14 = dr["codn_14"].ToString(),
                    codn_15 = dr["codn_15"].ToString(),
                    codn_16 = dr["codn_16"].ToString(),
                    codn_17 = dr["codn_17"].ToString(),
                    codn_18 = dr["codn_18"].ToString(),
                    codn_19 = dr["codn_19"].ToString(),
                    codn_20 = dr["codn_20"].ToString(),
                    codn_21 = dr["codn_21"].ToString(),
                    codn_22 = dr["codn_22"].ToString(),
                    codn_23 = dr["codn_23"].ToString(),
                    codn_24 = dr["codn_24"].ToString(),
                    codn_25 = dr["codn_25"].ToString(),
                    codn_26 = dr["codn_26"].ToString(),
                    codn_27 = dr["codn_27"].ToString(),
                    codn_28 = dr["codn_28"].ToString(),
                    codn_29 = dr["codn_29"].ToString(),
                    codn_30 = dr["codn_30"].ToString(),
                    codn_31 = dr["codn_31"].ToString(),
                    codn_32 = dr["codn_32"].ToString(),
                    codn_33 = dr["codn_33"].ToString(),
                    codn_34 = dr["codn_34"].ToString(),
                    codn_35 = dr["codn_35"].ToString(),
                    codn_36 = dr["codn_36"].ToString(),
                    codn_37 = dr["codn_37"].ToString(),
                    codn_38 = dr["codn_38"].ToString(),
                    codn_39 = dr["codn_39"].ToString(),
                    codn_40 = dr["codn_40"].ToString(),
                    codn_41 = dr["codn_41"].ToString(),
                    codn_42 = dr["codn_42"].ToString(),
                    codn_43 = dr["codn_43"].ToString(),
                    codn_44 = dr["codn_44"].ToString(),
                    codn_45 = dr["codn_45"].ToString(),
                    codn_46 = dr["codn_46"].ToString(),
                    codn_47 = dr["codn_47"].ToString(),
                    codn_48 = dr["codn_48"].ToString(),
                    codn_49 = dr["codn_49"].ToString(),
                    codn_50 = dr["codn_50"].ToString(),
                    codn_51 = dr["codn_51"].ToString(),
                    codn_52 = dr["codn_52"].ToString(),
                    codn_53 = dr["codn_53"].ToString(),
                    codn_54 = dr["codn_54"].ToString(),
                    codn_55 = dr["codn_55"].ToString(),
                    codn_56 = dr["codn_56"].ToString(),
                    codn_57 = dr["codn_57"].ToString(),
                    codn_58 = dr["codn_58"].ToString(),
                    codn_59 = dr["codn_59"].ToString(),
                    codn_60 = dr["codn_60"].ToString(),
                    codn_61 = dr["codn_61"].ToString(),
                    codn_62 = dr["codn_62"].ToString(),
                    codn_63 = dr["codn_63"].ToString(),
                    codn_64 = dr["codn_64"].ToString(),
                    codn_65 = dr["codn_65"].ToString(),
                    codn_66 = dr["codn_66"].ToString(),
                    codn_67 = dr["codn_67"].ToString(),
                    codn_date1 = Convert.ToDateTime(dr["codn_date1"].ToString()),
                    codn_date_created = Convert.ToDateTime(dr["codn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.OmanDental> GetAllPreOmanDental(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.OmanDental> sclist = new List<BusinessEntities.EMRForms.OmanDental>();
            DataTable dt = DataAccessLayer.EMRForms.OmanDental.GetAllPreOmanDental(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.OmanDental
                {
                    codnId = Convert.ToInt32(dr["codnId"]),
                    codn_appId = Convert.ToInt32(dr["codn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        
        //print
        public static List<BusinessEntities.EMRForms.OmanDental> GetPrintOmanDental(int? codnId)
        {
            List<BusinessEntities.EMRForms.OmanDental> sclist = new List<BusinessEntities.EMRForms.OmanDental>();
            DataTable dt = DataAccessLayer.EMRForms.OmanDental.GetPrintOmanDental(codnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.OmanDental
                    {
                        codnId = Convert.ToInt32(dr["codnId"]),
                        codn_appId = Convert.ToInt32(dr["codn_appId"]),
                        codn_checkbox = dr["codn_checkbox"].ToString(),
                        codn_1 = dr["codn_1"].ToString(),
                        codn_2 = dr["codn_2"].ToString(),
                        codn_3 = dr["codn_3"].ToString(),
                        codn_4 = dr["codn_4"].ToString(),
                        codn_5 = dr["codn_5"].ToString(),
                        codn_6 = dr["codn_6"].ToString(),
                        codn_7 = dr["codn_7"].ToString(),
                        codn_8 = dr["codn_8"].ToString(),
                        codn_9 = dr["codn_9"].ToString(),
                        codn_10 = dr["codn_10"].ToString(),
                        codn_11 = dr["codn_11"].ToString(),
                        codn_12 = dr["codn_12"].ToString(),
                        codn_13 = dr["codn_13"].ToString(),
                        codn_14 = dr["codn_14"].ToString(),
                        codn_15 = dr["codn_15"].ToString(),
                        codn_16 = dr["codn_16"].ToString(),
                        codn_17 = dr["codn_17"].ToString(),
                        codn_18 = dr["codn_18"].ToString(),
                        codn_19 = dr["codn_19"].ToString(),
                        codn_20 = dr["codn_20"].ToString(),
                        codn_21 = dr["codn_21"].ToString(),
                        codn_22 = dr["codn_22"].ToString(),
                        codn_23 = dr["codn_23"].ToString(),
                        codn_24 = dr["codn_24"].ToString(),
                        codn_25 = dr["codn_25"].ToString(),
                        codn_26 = dr["codn_26"].ToString(),
                        codn_27 = dr["codn_27"].ToString(),
                        codn_28 = dr["codn_28"].ToString(),
                        codn_29 = dr["codn_29"].ToString(),
                        codn_30 = dr["codn_30"].ToString(),
                        codn_31 = dr["codn_31"].ToString(),
                        codn_32 = dr["codn_32"].ToString(),
                        codn_33 = dr["codn_33"].ToString(),
                        codn_34 = dr["codn_34"].ToString(),
                        codn_35 = dr["codn_35"].ToString(),
                        codn_36 = dr["codn_36"].ToString(),
                        codn_37 = dr["codn_37"].ToString(),
                        codn_38 = dr["codn_38"].ToString(),
                        codn_39 = dr["codn_39"].ToString(),
                        codn_40 = dr["codn_40"].ToString(),
                        codn_41 = dr["codn_41"].ToString(),
                        codn_42 = dr["codn_42"].ToString(),
                        codn_43 = dr["codn_43"].ToString(),
                        codn_44 = dr["codn_44"].ToString(),
                        codn_45 = dr["codn_45"].ToString(),
                        codn_46 = dr["codn_46"].ToString(),
                        codn_47 = dr["codn_47"].ToString(),
                        codn_48 = dr["codn_48"].ToString(),
                        codn_49 = dr["codn_49"].ToString(),
                        codn_50 = dr["codn_50"].ToString(),
                        codn_51 = dr["codn_51"].ToString(),
                        codn_52 = dr["codn_52"].ToString(),
                        codn_53 = dr["codn_53"].ToString(),
                        codn_54 = dr["codn_54"].ToString(),
                        codn_55 = dr["codn_55"].ToString(),
                        codn_56 = dr["codn_56"].ToString(),
                        codn_57 = dr["codn_57"].ToString(),
                        codn_58 = dr["codn_58"].ToString(),
                        codn_59 = dr["codn_59"].ToString(),
                        codn_60 = dr["codn_60"].ToString(),
                        codn_61 = dr["codn_61"].ToString(),
                        codn_62 = dr["codn_62"].ToString(),
                        codn_63 = dr["codn_63"].ToString(),
                        codn_64 = dr["codn_64"].ToString(),
                        codn_65 = dr["codn_65"].ToString(),
                        codn_66 = dr["codn_66"].ToString(),
                        codn_67 = dr["codn_67"].ToString(),
                        codn_dd1 = dr["codn_date1"].ToString(),
                        codn_date_created = Convert.ToDateTime(dr["codn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.OmanDental a = new BusinessEntities.EMRForms.OmanDental();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion OmanDental (Page Load)

        #region OmanDental (CRUD Operations)
        //insert&update
        public static bool InsertUpdateOmanDental(BusinessEntities.EMRForms.OmanDental data)
        {
            data.codn_checkbox = string.IsNullOrEmpty(data.codn_checkbox) ? string.Empty : data.codn_checkbox;
            data.codn_1 = string.IsNullOrEmpty(data.codn_1) ? string.Empty : data.codn_1;
            data.codn_2 = string.IsNullOrEmpty(data.codn_2) ? string.Empty : data.codn_2;
            data.codn_3 = string.IsNullOrEmpty(data.codn_3) ? string.Empty : data.codn_3;
            data.codn_4 = string.IsNullOrEmpty(data.codn_4) ? string.Empty : data.codn_4;
            data.codn_5 = string.IsNullOrEmpty(data.codn_5) ? string.Empty : data.codn_5;
            data.codn_6 = string.IsNullOrEmpty(data.codn_6) ? string.Empty : data.codn_6;
            data.codn_7 = string.IsNullOrEmpty(data.codn_7) ? string.Empty : data.codn_7;
            data.codn_8 = string.IsNullOrEmpty(data.codn_8) ? string.Empty : data.codn_8;
            data.codn_9 = string.IsNullOrEmpty(data.codn_9) ? string.Empty : data.codn_9;
            data.codn_10 = string.IsNullOrEmpty(data.codn_10) ? string.Empty : data.codn_10;
            data.codn_11 = string.IsNullOrEmpty(data.codn_11) ? string.Empty : data.codn_11;
            data.codn_12 = string.IsNullOrEmpty(data.codn_12) ? string.Empty : data.codn_12;
            data.codn_13 = string.IsNullOrEmpty(data.codn_13) ? string.Empty : data.codn_13;
            data.codn_14 = string.IsNullOrEmpty(data.codn_14) ? string.Empty : data.codn_14;
            data.codn_15 = string.IsNullOrEmpty(data.codn_15) ? string.Empty : data.codn_15;
            data.codn_16 = string.IsNullOrEmpty(data.codn_16) ? string.Empty : data.codn_16;
            data.codn_17 = string.IsNullOrEmpty(data.codn_17) ? string.Empty : data.codn_17;
            data.codn_18 = string.IsNullOrEmpty(data.codn_18) ? string.Empty : data.codn_18;
            data.codn_19 = string.IsNullOrEmpty(data.codn_19) ? string.Empty : data.codn_19;
            data.codn_20 = string.IsNullOrEmpty(data.codn_20) ? string.Empty : data.codn_20;
            data.codn_21 = string.IsNullOrEmpty(data.codn_21) ? string.Empty : data.codn_21;
            data.codn_22 = string.IsNullOrEmpty(data.codn_22) ? string.Empty : data.codn_22;
            data.codn_23 = string.IsNullOrEmpty(data.codn_23) ? string.Empty : data.codn_23;
            data.codn_24 = string.IsNullOrEmpty(data.codn_24) ? string.Empty : data.codn_24;
            data.codn_25 = string.IsNullOrEmpty(data.codn_25) ? string.Empty : data.codn_25;
            data.codn_26 = string.IsNullOrEmpty(data.codn_26) ? string.Empty : data.codn_26;
            data.codn_27 = string.IsNullOrEmpty(data.codn_27) ? string.Empty : data.codn_27;
            data.codn_28 = string.IsNullOrEmpty(data.codn_28) ? string.Empty : data.codn_28;
            data.codn_29 = string.IsNullOrEmpty(data.codn_29) ? string.Empty : data.codn_29;
            data.codn_30 = string.IsNullOrEmpty(data.codn_30) ? string.Empty : data.codn_30;
            data.codn_31 = string.IsNullOrEmpty(data.codn_31) ? string.Empty : data.codn_31;
            data.codn_32 = string.IsNullOrEmpty(data.codn_32) ? string.Empty : data.codn_32;
            data.codn_33 = string.IsNullOrEmpty(data.codn_33) ? string.Empty : data.codn_33;
            data.codn_34 = string.IsNullOrEmpty(data.codn_34) ? string.Empty : data.codn_34;
            data.codn_35 = string.IsNullOrEmpty(data.codn_35) ? string.Empty : data.codn_35;
            data.codn_36 = string.IsNullOrEmpty(data.codn_36) ? string.Empty : data.codn_36;
            data.codn_37 = string.IsNullOrEmpty(data.codn_37) ? string.Empty : data.codn_37;
            data.codn_38 = string.IsNullOrEmpty(data.codn_38) ? string.Empty : data.codn_38;
            data.codn_39 = string.IsNullOrEmpty(data.codn_39) ? string.Empty : data.codn_39;
            data.codn_40 = string.IsNullOrEmpty(data.codn_40) ? string.Empty : data.codn_40;
            data.codn_41 = string.IsNullOrEmpty(data.codn_41) ? string.Empty : data.codn_41;
            data.codn_42 = string.IsNullOrEmpty(data.codn_42) ? string.Empty : data.codn_42;
            data.codn_43 = string.IsNullOrEmpty(data.codn_43) ? string.Empty : data.codn_43;
            data.codn_44 = string.IsNullOrEmpty(data.codn_44) ? string.Empty : data.codn_44;
            data.codn_45 = string.IsNullOrEmpty(data.codn_45) ? string.Empty : data.codn_45;
            data.codn_46 = string.IsNullOrEmpty(data.codn_46) ? string.Empty : data.codn_46;
            data.codn_47 = string.IsNullOrEmpty(data.codn_47) ? string.Empty : data.codn_47;
            data.codn_48 = string.IsNullOrEmpty(data.codn_48) ? string.Empty : data.codn_48;
            data.codn_49 = string.IsNullOrEmpty(data.codn_49) ? string.Empty : data.codn_49;
            data.codn_50 = string.IsNullOrEmpty(data.codn_50) ? string.Empty : data.codn_50;
            data.codn_51 = string.IsNullOrEmpty(data.codn_51) ? string.Empty : data.codn_51;
            data.codn_52 = string.IsNullOrEmpty(data.codn_52) ? string.Empty : data.codn_52;
            data.codn_53 = string.IsNullOrEmpty(data.codn_53) ? string.Empty : data.codn_53;
            data.codn_54 = string.IsNullOrEmpty(data.codn_54) ? string.Empty : data.codn_54;
            data.codn_55 = string.IsNullOrEmpty(data.codn_55) ? string.Empty : data.codn_55;
            data.codn_56 = string.IsNullOrEmpty(data.codn_56) ? string.Empty : data.codn_56;
            data.codn_57 = string.IsNullOrEmpty(data.codn_57) ? string.Empty : data.codn_57;
            data.codn_58 = string.IsNullOrEmpty(data.codn_58) ? string.Empty : data.codn_58;
            data.codn_59 = string.IsNullOrEmpty(data.codn_59) ? string.Empty : data.codn_59;
            data.codn_60 = string.IsNullOrEmpty(data.codn_60) ? string.Empty : data.codn_60;
            data.codn_61 = string.IsNullOrEmpty(data.codn_61) ? string.Empty : data.codn_61;
            data.codn_62 = string.IsNullOrEmpty(data.codn_62) ? string.Empty : data.codn_62;
            data.codn_63 = string.IsNullOrEmpty(data.codn_63) ? string.Empty : data.codn_63;
            data.codn_64 = string.IsNullOrEmpty(data.codn_64) ? string.Empty : data.codn_64;
            data.codn_65 = string.IsNullOrEmpty(data.codn_65) ? string.Empty : data.codn_65;
            data.codn_66 = string.IsNullOrEmpty(data.codn_66) ? string.Empty : data.codn_66;
            data.codn_67 = string.IsNullOrEmpty(data.codn_67) ? string.Empty : data.codn_67;
            DateTime? codnd1 = data.codn_date1; // Assuming data.codn_date1 is of type DateTime?  
            if (data.codn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.codn_date1 = codnd1.HasValue ? codnd1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.codn_date1 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.OmanDental.InsertUpdateOmanDental(data);
        }
        //Delete
        public static int DeleteOmanDental(int codnId, int codn_madeby)
        {
            return DataAccessLayer.EMRForms.OmanDental.DeleteOmanDental(codnId, codn_madeby);
        }
        #endregion OmanDental (CRUD Operations)
    }

    public class NasDarAlTakaful
    {
        #region NasDarAlTakaful (Page Load)
        public static List<BusinessEntities.EMRForms.NasDarAlTakaful> GetAllNasDarAlTakaful(int appId)
        {
            List<BusinessEntities.EMRForms.NasDarAlTakaful> sclist = new List<BusinessEntities.EMRForms.NasDarAlTakaful>();
            DataTable dt = DataAccessLayer.EMRForms.NasDarAlTakaful.GetAllNasDarAlTakaful(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NasDarAlTakaful
                {
                    ndtnId = Convert.ToInt32(dr["ndtnId"]),
                    ndtn_appId = Convert.ToInt32(dr["ndtn_appId"]),
                    ndtn_checkbox = dr["ndtn_checkbox"].ToString(),
                    ndtn_1 = dr["ndtn_1"].ToString(),
                    ndtn_2 = dr["ndtn_2"].ToString(),
                    ndtn_3 = dr["ndtn_3"].ToString(),
                    ndtn_4 = dr["ndtn_4"].ToString(),
                    ndtn_5 = dr["ndtn_5"].ToString(),
                    ndtn_6 = dr["ndtn_6"].ToString(),
                    ndtn_7 = dr["ndtn_7"].ToString(),
                    ndtn_8 = dr["ndtn_8"].ToString(),
                    ndtn_9 = dr["ndtn_9"].ToString(),
                    ndtn_10 = dr["ndtn_10"].ToString(),
                    ndtn_11 = dr["ndtn_11"].ToString(),
                    ndtn_12 = dr["ndtn_12"].ToString(),
                    ndtn_13 = dr["ndtn_13"].ToString(),
                    ndtn_14 = dr["ndtn_14"].ToString(),
                    ndtn_15 = dr["ndtn_15"].ToString(),
                    ndtn_16 = dr["ndtn_16"].ToString(),
                    ndtn_17 = dr["ndtn_17"].ToString(),
                    ndtn_18 = dr["ndtn_18"].ToString(),
                    ndtn_19 = dr["ndtn_19"].ToString(),
                    ndtn_20 = dr["ndtn_20"].ToString(),
                    ndtn_21 = dr["ndtn_21"].ToString(),
                    ndtn_22 = dr["ndtn_22"].ToString(),
                    ndtn_23 = dr["ndtn_23"].ToString(),
                    ndtn_24 = dr["ndtn_24"].ToString(),
                    ndtn_25 = dr["ndtn_25"].ToString(),
                    ndtn_26 = dr["ndtn_26"].ToString(),
                    ndtn_27 = dr["ndtn_27"].ToString(),
                    ndtn_28 = dr["ndtn_28"].ToString(),
                    ndtn_29 = dr["ndtn_29"].ToString(),
                    ndtn_30 = dr["ndtn_30"].ToString(),
                    ndtn_31 = dr["ndtn_31"].ToString(),
                    ndtn_32 = dr["ndtn_32"].ToString(),
                    ndtn_33 = dr["ndtn_33"].ToString(),
                    ndtn_34 = dr["ndtn_34"].ToString(),
                    ndtn_35 = dr["ndtn_35"].ToString(),
                    ndtn_36 = dr["ndtn_36"].ToString(),
                    ndtn_37 = dr["ndtn_37"].ToString(),
                    ndtn_38 = dr["ndtn_38"].ToString(),
                    ndtn_39 = dr["ndtn_39"].ToString(),
                    ndtn_40 = dr["ndtn_40"].ToString(),
                    ndtn_41 = dr["ndtn_41"].ToString(),
                    ndtn_42 = dr["ndtn_42"].ToString(),
                    ndtn_43 = dr["ndtn_43"].ToString(),
                    ndtn_date_created = Convert.ToDateTime(dr["ndtn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NasDarAlTakaful> GetAllPreNasDarAlTakaful(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NasDarAlTakaful> sclist = new List<BusinessEntities.EMRForms.NasDarAlTakaful>();
            DataTable dt = DataAccessLayer.EMRForms.NasDarAlTakaful.GetAllPreNasDarAlTakaful(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NasDarAlTakaful
                {
                    ndtnId = Convert.ToInt32(dr["ndtnId"]),
                    ndtn_appId = Convert.ToInt32(dr["ndtn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.NasDarAlTakaful> GetPrintNasDarAlTakaful(int? ndtnId)
        {
            List<BusinessEntities.EMRForms.NasDarAlTakaful> sclist = new List<BusinessEntities.EMRForms.NasDarAlTakaful>();
            DataTable dt = DataAccessLayer.EMRForms.NasDarAlTakaful.GetPrintNasDarAlTakaful(ndtnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NasDarAlTakaful
                    {
                        ndtnId = Convert.ToInt32(dr["ndtnId"]),
                        ndtn_appId = Convert.ToInt32(dr["ndtn_appId"]),
                        ndtn_checkbox = dr["ndtn_checkbox"].ToString(),
                        ndtn_1 = dr["ndtn_1"].ToString(),
                        ndtn_2 = dr["ndtn_2"].ToString(),
                        ndtn_3 = dr["ndtn_3"].ToString(),
                        ndtn_4 = dr["ndtn_4"].ToString(),
                        ndtn_5 = dr["ndtn_5"].ToString(),
                        ndtn_6 = dr["ndtn_6"].ToString(),
                        ndtn_7 = dr["ndtn_7"].ToString(),
                        ndtn_8 = dr["ndtn_8"].ToString(),
                        ndtn_9 = dr["ndtn_9"].ToString(),
                        ndtn_10 = dr["ndtn_10"].ToString(),
                        ndtn_11 = dr["ndtn_11"].ToString(),
                        ndtn_12 = dr["ndtn_12"].ToString(),
                        ndtn_13 = dr["ndtn_13"].ToString(),
                        ndtn_14 = dr["ndtn_14"].ToString(),
                        ndtn_15 = dr["ndtn_15"].ToString(),
                        ndtn_16 = dr["ndtn_16"].ToString(),
                        ndtn_17 = dr["ndtn_17"].ToString(),
                        ndtn_18 = dr["ndtn_18"].ToString(),
                        ndtn_19 = dr["ndtn_19"].ToString(),
                        ndtn_20 = dr["ndtn_20"].ToString(),
                        ndtn_21 = dr["ndtn_21"].ToString(),
                        ndtn_22 = dr["ndtn_22"].ToString(),
                        ndtn_23 = dr["ndtn_23"].ToString(),
                        ndtn_24 = dr["ndtn_24"].ToString(),
                        ndtn_25 = dr["ndtn_25"].ToString(),
                        ndtn_26 = dr["ndtn_26"].ToString(),
                        ndtn_27 = dr["ndtn_27"].ToString(),
                        ndtn_28 = dr["ndtn_28"].ToString(),
                        ndtn_29 = dr["ndtn_29"].ToString(),
                        ndtn_30 = dr["ndtn_30"].ToString(),
                        ndtn_31 = dr["ndtn_31"].ToString(),
                        ndtn_32 = dr["ndtn_32"].ToString(),
                        ndtn_33 = dr["ndtn_33"].ToString(),
                        ndtn_34 = dr["ndtn_34"].ToString(),
                        ndtn_35 = dr["ndtn_35"].ToString(),
                        ndtn_36 = dr["ndtn_36"].ToString(),
                        ndtn_37 = dr["ndtn_37"].ToString(),
                        ndtn_38 = dr["ndtn_38"].ToString(),
                        ndtn_39 = dr["ndtn_39"].ToString(),
                        ndtn_40 = dr["ndtn_40"].ToString(),
                        ndtn_41 = dr["ndtn_41"].ToString(),
                        ndtn_42 = dr["ndtn_42"].ToString(),
                        ndtn_43 = dr["ndtn_43"].ToString(),

                        ndtn_date_created = Convert.ToDateTime(dr["ndtn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NasDarAlTakaful a = new BusinessEntities.EMRForms.NasDarAlTakaful();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion NasDarAlTakaful (Page Load)

        #region NasDarAlTakaful (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNasDarAlTakaful(BusinessEntities.EMRForms.NasDarAlTakaful data)
        {
            data.ndtn_checkbox = string.IsNullOrEmpty(data.ndtn_checkbox) ? string.Empty : data.ndtn_checkbox;
            data.ndtn_1 = string.IsNullOrEmpty(data.ndtn_1) ? string.Empty : data.ndtn_1;
            data.ndtn_2 = string.IsNullOrEmpty(data.ndtn_2) ? string.Empty : data.ndtn_2;
            data.ndtn_3 = string.IsNullOrEmpty(data.ndtn_3) ? string.Empty : data.ndtn_3;
            data.ndtn_4 = string.IsNullOrEmpty(data.ndtn_4) ? string.Empty : data.ndtn_4;
            data.ndtn_5 = string.IsNullOrEmpty(data.ndtn_5) ? string.Empty : data.ndtn_5;
            data.ndtn_6 = string.IsNullOrEmpty(data.ndtn_6) ? string.Empty : data.ndtn_6;
            data.ndtn_7 = string.IsNullOrEmpty(data.ndtn_7) ? string.Empty : data.ndtn_7;
            data.ndtn_8 = string.IsNullOrEmpty(data.ndtn_8) ? string.Empty : data.ndtn_8;
            data.ndtn_9 = string.IsNullOrEmpty(data.ndtn_9) ? string.Empty : data.ndtn_9;
            data.ndtn_10 = string.IsNullOrEmpty(data.ndtn_10) ? string.Empty : data.ndtn_10;
            data.ndtn_11 = string.IsNullOrEmpty(data.ndtn_11) ? string.Empty : data.ndtn_11;
            data.ndtn_12 = string.IsNullOrEmpty(data.ndtn_12) ? string.Empty : data.ndtn_12;
            data.ndtn_13 = string.IsNullOrEmpty(data.ndtn_13) ? string.Empty : data.ndtn_13;
            data.ndtn_14 = string.IsNullOrEmpty(data.ndtn_14) ? string.Empty : data.ndtn_14;
            data.ndtn_15 = string.IsNullOrEmpty(data.ndtn_15) ? string.Empty : data.ndtn_15;
            data.ndtn_16 = string.IsNullOrEmpty(data.ndtn_16) ? string.Empty : data.ndtn_16;
            data.ndtn_17 = string.IsNullOrEmpty(data.ndtn_17) ? string.Empty : data.ndtn_17;
            data.ndtn_18 = string.IsNullOrEmpty(data.ndtn_18) ? string.Empty : data.ndtn_18;
            data.ndtn_19 = string.IsNullOrEmpty(data.ndtn_19) ? string.Empty : data.ndtn_19;
            data.ndtn_20 = string.IsNullOrEmpty(data.ndtn_20) ? string.Empty : data.ndtn_20;
            data.ndtn_21 = string.IsNullOrEmpty(data.ndtn_21) ? string.Empty : data.ndtn_21;
            data.ndtn_22 = string.IsNullOrEmpty(data.ndtn_22) ? string.Empty : data.ndtn_22;
            data.ndtn_23 = string.IsNullOrEmpty(data.ndtn_23) ? string.Empty : data.ndtn_23;
            data.ndtn_24 = string.IsNullOrEmpty(data.ndtn_24) ? string.Empty : data.ndtn_24;
            data.ndtn_25 = string.IsNullOrEmpty(data.ndtn_25) ? string.Empty : data.ndtn_25;
            data.ndtn_26 = string.IsNullOrEmpty(data.ndtn_26) ? string.Empty : data.ndtn_26;
            data.ndtn_27 = string.IsNullOrEmpty(data.ndtn_27) ? string.Empty : data.ndtn_27;
            data.ndtn_28 = string.IsNullOrEmpty(data.ndtn_28) ? string.Empty : data.ndtn_28;
            data.ndtn_29 = string.IsNullOrEmpty(data.ndtn_29) ? string.Empty : data.ndtn_29;
            data.ndtn_30 = string.IsNullOrEmpty(data.ndtn_30) ? string.Empty : data.ndtn_30;
            data.ndtn_31 = string.IsNullOrEmpty(data.ndtn_31) ? string.Empty : data.ndtn_31;
            data.ndtn_32 = string.IsNullOrEmpty(data.ndtn_32) ? string.Empty : data.ndtn_32;
            data.ndtn_33 = string.IsNullOrEmpty(data.ndtn_33) ? string.Empty : data.ndtn_33;
            data.ndtn_34 = string.IsNullOrEmpty(data.ndtn_34) ? string.Empty : data.ndtn_34;
            data.ndtn_35 = string.IsNullOrEmpty(data.ndtn_35) ? string.Empty : data.ndtn_35;
            data.ndtn_36 = string.IsNullOrEmpty(data.ndtn_36) ? string.Empty : data.ndtn_36;
            data.ndtn_37 = string.IsNullOrEmpty(data.ndtn_37) ? string.Empty : data.ndtn_37;
            data.ndtn_38 = string.IsNullOrEmpty(data.ndtn_38) ? string.Empty : data.ndtn_38;
            data.ndtn_39 = string.IsNullOrEmpty(data.ndtn_39) ? string.Empty : data.ndtn_39;
            data.ndtn_40 = string.IsNullOrEmpty(data.ndtn_40) ? string.Empty : data.ndtn_40;
            data.ndtn_41 = string.IsNullOrEmpty(data.ndtn_41) ? string.Empty : data.ndtn_41;
            data.ndtn_42 = string.IsNullOrEmpty(data.ndtn_42) ? string.Empty : data.ndtn_42;
            data.ndtn_43 = string.IsNullOrEmpty(data.ndtn_43) ? string.Empty : data.ndtn_43;
            return DataAccessLayer.EMRForms.NasDarAlTakaful.InsertUpdateNasDarAlTakaful(data);
        }
        //Delete
        public static int DeleteNasDarAlTakaful(int ndtnId, int ndtn_madeby)
        {
            return DataAccessLayer.EMRForms.NasDarAlTakaful.DeleteNasDarAlTakaful(ndtnId, ndtn_madeby);
        }
        #endregion NasDarAlTakaful (CRUD Operations)
    } 

    public class OmanInsurance
    {
        #region OmanInsurance (Page Load)
        public static List<BusinessEntities.EMRForms.OmanInsurance> GetAllOmanInsurance(int appId)
        {
            List<BusinessEntities.EMRForms.OmanInsurance> sclist = new List<BusinessEntities.EMRForms.OmanInsurance>();
            DataTable dt = DataAccessLayer.EMRForms.OmanInsurance.GetAllOmanInsurance(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.OmanInsurance
                {
                    cornId = Convert.ToInt32(dr["cornId"]),
                    corn_appId = Convert.ToInt32(dr["corn_appId"]),
                    corn_checkbox = dr["corn_checkbox"].ToString(),
                    corn_1 = dr["corn_1"].ToString(),
                    corn_2 = dr["corn_2"].ToString(),
                    corn_3 = dr["corn_3"].ToString(),
                    corn_4 = dr["corn_4"].ToString(),
                    corn_5 = dr["corn_5"].ToString(),
                    corn_6 = dr["corn_6"].ToString(),
                    corn_7 = dr["corn_7"].ToString(),
                    corn_8 = dr["corn_8"].ToString(),
                    corn_9 = dr["corn_9"].ToString(),
                    corn_10 = dr["corn_10"].ToString(),
                    corn_11 = dr["corn_11"].ToString(),
                    corn_12 = dr["corn_12"].ToString(),
                    corn_13 = dr["corn_13"].ToString(),
                    corn_14 = dr["corn_14"].ToString(),
                    corn_15 = dr["corn_15"].ToString(),
                    corn_16 = dr["corn_16"].ToString(),
                    corn_17 = dr["corn_17"].ToString(),
                    corn_18 = dr["corn_18"].ToString(),
                    corn_19 = dr["corn_19"].ToString(),
                    corn_20 = dr["corn_20"].ToString(),
                    corn_21 = dr["corn_21"].ToString(),
                    corn_22 = dr["corn_22"].ToString(),
                    corn_23 = dr["corn_23"].ToString(),
                    corn_24 = dr["corn_24"].ToString(),
                    corn_25 = dr["corn_25"].ToString(),
                    corn_26 = dr["corn_26"].ToString(),
                    corn_27 = dr["corn_27"].ToString(),
                    corn_28 = dr["corn_28"].ToString(),
                    corn_29 = dr["corn_29"].ToString(),
                    corn_30 = dr["corn_30"].ToString(),
                    corn_31 = dr["corn_31"].ToString(),
                    corn_32 = dr["corn_32"].ToString(),
                    corn_33 = dr["corn_33"].ToString(),
                    corn_34 = dr["corn_34"].ToString(),
                    corn_35 = dr["corn_35"].ToString(),
                    corn_36 = dr["corn_36"].ToString(),
                    corn_37 = dr["corn_37"].ToString(),
                    corn_38 = dr["corn_38"].ToString(),
                    corn_39 = dr["corn_39"].ToString(),
                    corn_40 = dr["corn_40"].ToString(),
                    corn_41 = dr["corn_41"].ToString(),
                    corn_42 = dr["corn_42"].ToString(),
                    corn_43 = dr["corn_43"].ToString(),
                    corn_44 = dr["corn_44"].ToString(),
                    corn_45 = dr["corn_45"].ToString(),
                    corn_46 = dr["corn_46"].ToString(),
                    corn_47 = dr["corn_47"].ToString(),
                    corn_48 = dr["corn_48"].ToString(),
                    corn_49 = dr["corn_49"].ToString(),
                    corn_50 = dr["corn_50"].ToString(),
                    corn_51 = dr["corn_51"].ToString(),
                    corn_52 = dr["corn_52"].ToString(),
                    corn_53 = dr["corn_53"].ToString(),
                    corn_54 = dr["corn_54"].ToString(),
                    corn_55 = dr["corn_55"].ToString(),
                    corn_56 = dr["corn_56"].ToString(),
                    corn_57 = dr["corn_57"].ToString(),
                    corn_58 = dr["corn_58"].ToString(),
                    corn_59 = dr["corn_59"].ToString(),
                    corn_60 = dr["corn_60"].ToString(),
                    corn_61 = dr["corn_61"].ToString(),
                    corn_62 = dr["corn_62"].ToString(),
                    corn_63 = dr["corn_63"].ToString(),
                    corn_64 = dr["corn_64"].ToString(),
                    corn_65 = dr["corn_65"].ToString(),
                    corn_66 = dr["corn_66"].ToString(),
                    corn_67 = dr["corn_67"].ToString(),
                    corn_date1 = Convert.ToDateTime(dr["corn_date1"].ToString()),
                    corn_date_created = Convert.ToDateTime(dr["corn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.OmanInsurance> GetAllPreOmanInsurance(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.OmanInsurance> sclist = new List<BusinessEntities.EMRForms.OmanInsurance>();
            DataTable dt = DataAccessLayer.EMRForms.OmanInsurance.GetAllPreOmanInsurance(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.OmanInsurance
                {
                    cornId = Convert.ToInt32(dr["cornId"]),
                    corn_appId = Convert.ToInt32(dr["corn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        //print
        public static List<BusinessEntities.EMRForms.OmanInsurance> GetPrintOmanInsurance(int? cornId)
        {
            List<BusinessEntities.EMRForms.OmanInsurance> sclist = new List<BusinessEntities.EMRForms.OmanInsurance>();
            DataTable dt = DataAccessLayer.EMRForms.OmanInsurance.GetPrintOmanInsurance(cornId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.OmanInsurance
                    {
                        cornId = Convert.ToInt32(dr["cornId"]),
                        corn_appId = Convert.ToInt32(dr["corn_appId"]),
                        corn_checkbox = dr["corn_checkbox"].ToString(),
                        corn_1 = dr["corn_1"].ToString(),
                        corn_2 = dr["corn_2"].ToString(),
                        corn_3 = dr["corn_3"].ToString(),
                        corn_4 = dr["corn_4"].ToString(),
                        corn_5 = dr["corn_5"].ToString(),
                        corn_6 = dr["corn_6"].ToString(),
                        corn_7 = dr["corn_7"].ToString(),
                        corn_8 = dr["corn_8"].ToString(),
                        corn_9 = dr["corn_9"].ToString(),
                        corn_10 = dr["corn_10"].ToString(),
                        corn_11 = dr["corn_11"].ToString(),
                        corn_12 = dr["corn_12"].ToString(),
                        corn_13 = dr["corn_13"].ToString(),
                        corn_14 = dr["corn_14"].ToString(),
                        corn_15 = dr["corn_15"].ToString(),
                        corn_16 = dr["corn_16"].ToString(),
                        corn_17 = dr["corn_17"].ToString(),
                        corn_18 = dr["corn_18"].ToString(),
                        corn_19 = dr["corn_19"].ToString(),
                        corn_20 = dr["corn_20"].ToString(),
                        corn_21 = dr["corn_21"].ToString(),
                        corn_22 = dr["corn_22"].ToString(),
                        corn_23 = dr["corn_23"].ToString(),
                        corn_24 = dr["corn_24"].ToString(),
                        corn_25 = dr["corn_25"].ToString(),
                        corn_26 = dr["corn_26"].ToString(),
                        corn_27 = dr["corn_27"].ToString(),
                        corn_28 = dr["corn_28"].ToString(),
                        corn_29 = dr["corn_29"].ToString(),
                        corn_30 = dr["corn_30"].ToString(),
                        corn_31 = dr["corn_31"].ToString(),
                        corn_32 = dr["corn_32"].ToString(),
                        corn_33 = dr["corn_33"].ToString(),
                        corn_34 = dr["corn_34"].ToString(),
                        corn_35 = dr["corn_35"].ToString(),
                        corn_36 = dr["corn_36"].ToString(),
                        corn_37 = dr["corn_37"].ToString(),
                        corn_38 = dr["corn_38"].ToString(),
                        corn_39 = dr["corn_39"].ToString(),
                        corn_40 = dr["corn_40"].ToString(),
                        corn_41 = dr["corn_41"].ToString(),
                        corn_42 = dr["corn_42"].ToString(),
                        corn_43 = dr["corn_43"].ToString(),
                        corn_44 = dr["corn_44"].ToString(),
                        corn_45 = dr["corn_45"].ToString(),
                        corn_46 = dr["corn_46"].ToString(),
                        corn_47 = dr["corn_47"].ToString(),
                        corn_48 = dr["corn_48"].ToString(),
                        corn_49 = dr["corn_49"].ToString(),
                        corn_50 = dr["corn_50"].ToString(),
                        corn_51 = dr["corn_51"].ToString(),
                        corn_52 = dr["corn_52"].ToString(),
                        corn_53 = dr["corn_53"].ToString(),
                        corn_54 = dr["corn_54"].ToString(),
                        corn_55 = dr["corn_55"].ToString(),
                        corn_56 = dr["corn_56"].ToString(),
                        corn_57 = dr["corn_57"].ToString(),
                        corn_58 = dr["corn_58"].ToString(),
                        corn_59 = dr["corn_59"].ToString(),
                        corn_60 = dr["corn_60"].ToString(),
                        corn_61 = dr["corn_61"].ToString(),
                        corn_62 = dr["corn_62"].ToString(),
                        corn_63 = dr["corn_63"].ToString(),
                        corn_64 = dr["corn_64"].ToString(),
                        corn_65 = dr["corn_65"].ToString(),
                        corn_66 = dr["corn_66"].ToString(),
                        corn_67 = dr["corn_67"].ToString(),
                        corn_dd1 = dr["corn_date1"].ToString(),
                        corn_date_created = Convert.ToDateTime(dr["corn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.OmanInsurance a = new BusinessEntities.EMRForms.OmanInsurance();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion OmanInsurance (Page Load)

        #region OmanInsurance (CRUD Operations)
        //insert&update
        public static bool InsertUpdateOmanInsurance(BusinessEntities.EMRForms.OmanInsurance data)
        {
            data.corn_checkbox = string.IsNullOrEmpty(data.corn_checkbox) ? string.Empty : data.corn_checkbox;
            data.corn_1 = string.IsNullOrEmpty(data.corn_1) ? string.Empty : data.corn_1;
            data.corn_2 = string.IsNullOrEmpty(data.corn_2) ? string.Empty : data.corn_2;
            data.corn_3 = string.IsNullOrEmpty(data.corn_3) ? string.Empty : data.corn_3;
            data.corn_4 = string.IsNullOrEmpty(data.corn_4) ? string.Empty : data.corn_4;
            data.corn_5 = string.IsNullOrEmpty(data.corn_5) ? string.Empty : data.corn_5;
            data.corn_6 = string.IsNullOrEmpty(data.corn_6) ? string.Empty : data.corn_6;
            data.corn_7 = string.IsNullOrEmpty(data.corn_7) ? string.Empty : data.corn_7;
            data.corn_8 = string.IsNullOrEmpty(data.corn_8) ? string.Empty : data.corn_8;
            data.corn_9 = string.IsNullOrEmpty(data.corn_9) ? string.Empty : data.corn_9;
            data.corn_10 = string.IsNullOrEmpty(data.corn_10) ? string.Empty : data.corn_10;
            data.corn_11 = string.IsNullOrEmpty(data.corn_11) ? string.Empty : data.corn_11;
            data.corn_12 = string.IsNullOrEmpty(data.corn_12) ? string.Empty : data.corn_12;
            data.corn_13 = string.IsNullOrEmpty(data.corn_13) ? string.Empty : data.corn_13;
            data.corn_14 = string.IsNullOrEmpty(data.corn_14) ? string.Empty : data.corn_14;
            data.corn_15 = string.IsNullOrEmpty(data.corn_15) ? string.Empty : data.corn_15;
            data.corn_16 = string.IsNullOrEmpty(data.corn_16) ? string.Empty : data.corn_16;
            data.corn_17 = string.IsNullOrEmpty(data.corn_17) ? string.Empty : data.corn_17;
            data.corn_18 = string.IsNullOrEmpty(data.corn_18) ? string.Empty : data.corn_18;
            data.corn_19 = string.IsNullOrEmpty(data.corn_19) ? string.Empty : data.corn_19;
            data.corn_20 = string.IsNullOrEmpty(data.corn_20) ? string.Empty : data.corn_20;
            data.corn_21 = string.IsNullOrEmpty(data.corn_21) ? string.Empty : data.corn_21;
            data.corn_22 = string.IsNullOrEmpty(data.corn_22) ? string.Empty : data.corn_22;
            data.corn_23 = string.IsNullOrEmpty(data.corn_23) ? string.Empty : data.corn_23;
            data.corn_24 = string.IsNullOrEmpty(data.corn_24) ? string.Empty : data.corn_24;
            data.corn_25 = string.IsNullOrEmpty(data.corn_25) ? string.Empty : data.corn_25;
            data.corn_26 = string.IsNullOrEmpty(data.corn_26) ? string.Empty : data.corn_26;
            data.corn_27 = string.IsNullOrEmpty(data.corn_27) ? string.Empty : data.corn_27;
            data.corn_28 = string.IsNullOrEmpty(data.corn_28) ? string.Empty : data.corn_28;
            data.corn_29 = string.IsNullOrEmpty(data.corn_29) ? string.Empty : data.corn_29;
            data.corn_30 = string.IsNullOrEmpty(data.corn_30) ? string.Empty : data.corn_30;
            data.corn_31 = string.IsNullOrEmpty(data.corn_31) ? string.Empty : data.corn_31;
            data.corn_32 = string.IsNullOrEmpty(data.corn_32) ? string.Empty : data.corn_32;
            data.corn_33 = string.IsNullOrEmpty(data.corn_33) ? string.Empty : data.corn_33;
            data.corn_34 = string.IsNullOrEmpty(data.corn_34) ? string.Empty : data.corn_34;
            data.corn_35 = string.IsNullOrEmpty(data.corn_35) ? string.Empty : data.corn_35;
            data.corn_36 = string.IsNullOrEmpty(data.corn_36) ? string.Empty : data.corn_36;
            data.corn_37 = string.IsNullOrEmpty(data.corn_37) ? string.Empty : data.corn_37;
            data.corn_38 = string.IsNullOrEmpty(data.corn_38) ? string.Empty : data.corn_38;
            data.corn_39 = string.IsNullOrEmpty(data.corn_39) ? string.Empty : data.corn_39;
            data.corn_40 = string.IsNullOrEmpty(data.corn_40) ? string.Empty : data.corn_40;
            data.corn_41 = string.IsNullOrEmpty(data.corn_41) ? string.Empty : data.corn_41;
            data.corn_42 = string.IsNullOrEmpty(data.corn_42) ? string.Empty : data.corn_42;
            data.corn_43 = string.IsNullOrEmpty(data.corn_43) ? string.Empty : data.corn_43;
            data.corn_44 = string.IsNullOrEmpty(data.corn_44) ? string.Empty : data.corn_44;
            data.corn_45 = string.IsNullOrEmpty(data.corn_45) ? string.Empty : data.corn_45;
            data.corn_46 = string.IsNullOrEmpty(data.corn_46) ? string.Empty : data.corn_46;
            data.corn_47 = string.IsNullOrEmpty(data.corn_47) ? string.Empty : data.corn_47;
            data.corn_48 = string.IsNullOrEmpty(data.corn_48) ? string.Empty : data.corn_48;
            data.corn_49 = string.IsNullOrEmpty(data.corn_49) ? string.Empty : data.corn_49;
            data.corn_50 = string.IsNullOrEmpty(data.corn_50) ? string.Empty : data.corn_50;
            data.corn_51 = string.IsNullOrEmpty(data.corn_51) ? string.Empty : data.corn_51;
            data.corn_52 = string.IsNullOrEmpty(data.corn_52) ? string.Empty : data.corn_52;
            data.corn_53 = string.IsNullOrEmpty(data.corn_53) ? string.Empty : data.corn_53;
            data.corn_54 = string.IsNullOrEmpty(data.corn_54) ? string.Empty : data.corn_54;
            data.corn_55 = string.IsNullOrEmpty(data.corn_55) ? string.Empty : data.corn_55;
            data.corn_56 = string.IsNullOrEmpty(data.corn_56) ? string.Empty : data.corn_56;
            data.corn_57 = string.IsNullOrEmpty(data.corn_57) ? string.Empty : data.corn_57;
            data.corn_58 = string.IsNullOrEmpty(data.corn_58) ? string.Empty : data.corn_58;
            data.corn_59 = string.IsNullOrEmpty(data.corn_59) ? string.Empty : data.corn_59;
            data.corn_60 = string.IsNullOrEmpty(data.corn_60) ? string.Empty : data.corn_60;
            data.corn_61 = string.IsNullOrEmpty(data.corn_61) ? string.Empty : data.corn_61;
            data.corn_62 = string.IsNullOrEmpty(data.corn_62) ? string.Empty : data.corn_62;
            data.corn_63 = string.IsNullOrEmpty(data.corn_63) ? string.Empty : data.corn_63;
            data.corn_64 = string.IsNullOrEmpty(data.corn_64) ? string.Empty : data.corn_64;
            data.corn_65 = string.IsNullOrEmpty(data.corn_65) ? string.Empty : data.corn_65;
            data.corn_66 = string.IsNullOrEmpty(data.corn_66) ? string.Empty : data.corn_66;
            data.corn_67 = string.IsNullOrEmpty(data.corn_67) ? string.Empty : data.corn_67;
            DateTime? cornd1 = data.corn_date1; // Assuming data.corn_date1 is of type DateTime?  
            if (data.corn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.corn_date1 = cornd1.HasValue ? cornd1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.corn_date1 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.OmanInsurance.InsertUpdateOmanInsurance(data);
        }
        //Delete
        public static int DeleteOmanInsurance(int cornId, int corn_madeby)
        {
            return DataAccessLayer.EMRForms.OmanInsurance.DeleteOmanInsurance(cornId, corn_madeby);
        }
        #endregion OmanInsurance (CRUD Operations)
    }

    public class Union
    {
        #region Union (Page Load)
            public static List<BusinessEntities.EMRForms.Union> GetAllUnion(int appId)
            {
                List<BusinessEntities.EMRForms.Union> sclist = new List<BusinessEntities.EMRForms.Union>();
                DataTable dt = DataAccessLayer.EMRForms.Union.GetAllUnion(appId);

                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Union
                    {
                        curnId = Convert.ToInt32(dr["curnId"]),
                        curn_appId = Convert.ToInt32(dr["curn_appId"]),
                        curn_checkbox = dr["curn_checkbox"].ToString(),
                        curn_1 = dr["curn_1"].ToString(),
                        curn_2 = dr["curn_2"].ToString(),
                        curn_3 = dr["curn_3"].ToString(),
                        curn_4 = dr["curn_4"].ToString(),
                        curn_5 = dr["curn_5"].ToString(),
                        curn_6 = dr["curn_6"].ToString(),
                        curn_7 = dr["curn_7"].ToString(),
                        curn_8 = dr["curn_8"].ToString(),
                        curn_9 = dr["curn_9"].ToString(),
                        curn_10 = dr["curn_10"].ToString(),
                        curn_11 = dr["curn_11"].ToString(),
                        curn_12 = dr["curn_12"].ToString(),
                        curn_13 = dr["curn_13"].ToString(),
                        curn_14 = dr["curn_14"].ToString(),
                        curn_15 = dr["curn_15"].ToString(),
                        curn_16 = dr["curn_16"].ToString(),
                        curn_17 = dr["curn_17"].ToString(),
                        curn_18 = dr["curn_18"].ToString(),
                        curn_19 = dr["curn_19"].ToString(),
                        curn_20 = dr["curn_20"].ToString(),
                        curn_21 = dr["curn_21"].ToString(),
                        curn_22 = dr["curn_22"].ToString(),
                        curn_23 = dr["curn_23"].ToString(),
                        curn_24 = dr["curn_24"].ToString(),
                        curn_25 = dr["curn_25"].ToString(),
                        curn_26 = dr["curn_26"].ToString(),
                        curn_27 = dr["curn_27"].ToString(),
                        curn_28 = dr["curn_28"].ToString(),
                        curn_29 = dr["curn_29"].ToString(),
                        curn_30 = dr["curn_30"].ToString(),
                        curn_31 = dr["curn_31"].ToString(),
                        curn_32 = dr["curn_32"].ToString(),
                        curn_33 = dr["curn_33"].ToString(),
                        curn_34 = dr["curn_34"].ToString(),
                        curn_35 = dr["curn_35"].ToString(),
                        curn_36 = dr["curn_36"].ToString(),
                        curn_37 = dr["curn_37"].ToString(),
                        curn_38 = dr["curn_38"].ToString(),
                        curn_39 = dr["curn_39"].ToString(),
                        curn_40 = dr["curn_40"].ToString(),
                        curn_date1 = Convert.ToDateTime(dr["curn_date1"].ToString()),
                        curn_date2 = Convert.ToDateTime(dr["curn_date2"].ToString()),
                        curn_date3 = Convert.ToDateTime(dr["curn_date3"].ToString()),
                        curn_date_created = Convert.ToDateTime(dr["curn_date_created"].ToString()),
                    });
                }
                return sclist;
            }
            public static List<BusinessEntities.EMRForms.Union> GetAllPreUnion(int appId, int patId)
            {
                List<BusinessEntities.EMRForms.Union> sclist = new List<BusinessEntities.EMRForms.Union>();
                DataTable dt = DataAccessLayer.EMRForms.Union.GetAllPreUnion(appId, patId);

                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Union
                    {
                        curnId = Convert.ToInt32(dr["curnId"]),
                        curn_appId = Convert.ToInt32(dr["curn_appId"]),
                        doctor_name = dr["doctor_name"].ToString(),
                        app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                    });
                }
                return sclist;
            }           
            public static List<BusinessEntities.EMRForms.Union> GetPrintUnion(int? curnId)
        {
            List<BusinessEntities.EMRForms.Union> sclist = new List<BusinessEntities.EMRForms.Union>();
            DataTable dt = DataAccessLayer.EMRForms.Union.GetPrintUnion(curnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Union
                    {
                        curnId = Convert.ToInt32(dr["curnId"]),
                        curn_appId = Convert.ToInt32(dr["curn_appId"]),
                        curn_checkbox = dr["curn_checkbox"].ToString(),
                        curn_1 = dr["curn_1"].ToString(),
                        curn_2 = dr["curn_2"].ToString(),
                        curn_3 = dr["curn_3"].ToString(),
                        curn_4 = dr["curn_4"].ToString(),
                        curn_5 = dr["curn_5"].ToString(),
                        curn_6 = dr["curn_6"].ToString(),
                        curn_7 = dr["curn_7"].ToString(),
                        curn_8 = dr["curn_8"].ToString(),
                        curn_9 = dr["curn_9"].ToString(),
                        curn_10 = dr["curn_10"].ToString(),
                        curn_11 = dr["curn_11"].ToString(),
                        curn_12 = dr["curn_12"].ToString(),
                        curn_13 = dr["curn_13"].ToString(),
                        curn_14 = dr["curn_14"].ToString(),
                        curn_15 = dr["curn_15"].ToString(),
                        curn_16 = dr["curn_16"].ToString(),
                        curn_17 = dr["curn_17"].ToString(),
                        curn_18 = dr["curn_18"].ToString(),
                        curn_19 = dr["curn_19"].ToString(),
                        curn_20 = dr["curn_20"].ToString(),
                        curn_21 = dr["curn_21"].ToString(),
                        curn_22 = dr["curn_22"].ToString(),
                        curn_23 = dr["curn_23"].ToString(),
                        curn_24 = dr["curn_24"].ToString(),
                        curn_25 = dr["curn_25"].ToString(),
                        curn_26 = dr["curn_26"].ToString(),
                        curn_27 = dr["curn_27"].ToString(),
                        curn_28 = dr["curn_28"].ToString(),
                        curn_29 = dr["curn_29"].ToString(),
                        curn_30 = dr["curn_30"].ToString(),
                        curn_31 = dr["curn_31"].ToString(),
                        curn_32 = dr["curn_32"].ToString(),
                        curn_33 = dr["curn_33"].ToString(),
                        curn_34 = dr["curn_34"].ToString(),
                        curn_35 = dr["curn_35"].ToString(),
                        curn_36 = dr["curn_36"].ToString(),
                        curn_37 = dr["curn_37"].ToString(),
                        curn_38 = dr["curn_38"].ToString(),
                        curn_39 = dr["curn_39"].ToString(),
                        curn_40 = dr["curn_40"].ToString(),
                        curn_dd1 = dr["curn_date1"].ToString(),
                        curn_dd2 = dr["curn_date2"].ToString(),
                        curn_dd3 = dr["curn_date3"].ToString(),

                        curn_date_created = Convert.ToDateTime(dr["curn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Union a = new BusinessEntities.EMRForms.Union();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region Union (CRUD Operations)
            public static bool InsertUpdateUnion(BusinessEntities.EMRForms.Union data)
            {
                data.curn_checkbox = string.IsNullOrEmpty(data.curn_checkbox) ? string.Empty : data.curn_checkbox;
                data.curn_1 = string.IsNullOrEmpty(data.curn_1) ? string.Empty : data.curn_1;
                data.curn_2 = string.IsNullOrEmpty(data.curn_2) ? string.Empty : data.curn_2;
                data.curn_3 = string.IsNullOrEmpty(data.curn_3) ? string.Empty : data.curn_3;
                data.curn_4 = string.IsNullOrEmpty(data.curn_4) ? string.Empty : data.curn_4;
                data.curn_5 = string.IsNullOrEmpty(data.curn_5) ? string.Empty : data.curn_5;
                data.curn_6 = string.IsNullOrEmpty(data.curn_6) ? string.Empty : data.curn_6;
                data.curn_7 = string.IsNullOrEmpty(data.curn_7) ? string.Empty : data.curn_7;
                data.curn_8 = string.IsNullOrEmpty(data.curn_8) ? string.Empty : data.curn_8;
                data.curn_9 = string.IsNullOrEmpty(data.curn_9) ? string.Empty : data.curn_9;
                data.curn_10 = string.IsNullOrEmpty(data.curn_10) ? string.Empty : data.curn_10;
                data.curn_11 = string.IsNullOrEmpty(data.curn_11) ? string.Empty : data.curn_11;
                data.curn_12 = string.IsNullOrEmpty(data.curn_12) ? string.Empty : data.curn_12;
                data.curn_13 = string.IsNullOrEmpty(data.curn_13) ? string.Empty : data.curn_13;
                data.curn_14 = string.IsNullOrEmpty(data.curn_14) ? string.Empty : data.curn_14;
                data.curn_15 = string.IsNullOrEmpty(data.curn_15) ? string.Empty : data.curn_15;
                data.curn_16 = string.IsNullOrEmpty(data.curn_16) ? string.Empty : data.curn_16;
                data.curn_17 = string.IsNullOrEmpty(data.curn_17) ? string.Empty : data.curn_17;
                data.curn_18 = string.IsNullOrEmpty(data.curn_18) ? string.Empty : data.curn_18;
                data.curn_19 = string.IsNullOrEmpty(data.curn_19) ? string.Empty : data.curn_19;
                data.curn_20 = string.IsNullOrEmpty(data.curn_20) ? string.Empty : data.curn_20;
                data.curn_21 = string.IsNullOrEmpty(data.curn_21) ? string.Empty : data.curn_21;
                data.curn_22 = string.IsNullOrEmpty(data.curn_22) ? string.Empty : data.curn_22;
                data.curn_23 = string.IsNullOrEmpty(data.curn_23) ? string.Empty : data.curn_23;
                data.curn_24 = string.IsNullOrEmpty(data.curn_24) ? string.Empty : data.curn_24;
                data.curn_25 = string.IsNullOrEmpty(data.curn_25) ? string.Empty : data.curn_25;
                data.curn_26 = string.IsNullOrEmpty(data.curn_26) ? string.Empty : data.curn_26;
                data.curn_27 = string.IsNullOrEmpty(data.curn_27) ? string.Empty : data.curn_27;
                data.curn_28 = string.IsNullOrEmpty(data.curn_28) ? string.Empty : data.curn_28;
                data.curn_29 = string.IsNullOrEmpty(data.curn_29) ? string.Empty : data.curn_29;
                data.curn_30 = string.IsNullOrEmpty(data.curn_30) ? string.Empty : data.curn_30;
                data.curn_31 = string.IsNullOrEmpty(data.curn_31) ? string.Empty : data.curn_31;
                data.curn_32 = string.IsNullOrEmpty(data.curn_32) ? string.Empty : data.curn_32;
                data.curn_33 = string.IsNullOrEmpty(data.curn_33) ? string.Empty : data.curn_33;
                data.curn_34 = string.IsNullOrEmpty(data.curn_34) ? string.Empty : data.curn_34;
                data.curn_35 = string.IsNullOrEmpty(data.curn_35) ? string.Empty : data.curn_35;
                data.curn_36 = string.IsNullOrEmpty(data.curn_36) ? string.Empty : data.curn_36;
                data.curn_37 = string.IsNullOrEmpty(data.curn_37) ? string.Empty : data.curn_37;
                data.curn_38 = string.IsNullOrEmpty(data.curn_38) ? string.Empty : data.curn_38;
                data.curn_39 = string.IsNullOrEmpty(data.curn_39) ? string.Empty : data.curn_39;
                data.curn_40 = string.IsNullOrEmpty(data.curn_40) ? string.Empty : data.curn_40;
                DateTime? card1 = data.curn_date1; // Assuming data.curn_date1 is of type DateTime?            
                DateTime? card2 = data.curn_date2; // Assuming data.curn_date2 is of type DateTime?
                DateTime? card3 = data.curn_date3; // Assuming data.curn_date3 is of type DateTime?
                if (data.curn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
                {
                    data.curn_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
                }
                else
                {
                    data.curn_date1 = DateTime.Parse("01/01/1950");
                }
                if (data.curn_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
                {
                    data.curn_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
                }
                else
                {
                    data.curn_date2 = DateTime.Parse("01/01/1950");
                }
                if (data.curn_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
                {
                    data.curn_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
                }
                else
                {
                    data.curn_date3 = DateTime.Parse("01/01/1950");
                }
                return DataAccessLayer.EMRForms.Union.InsertUpdateUnion(data);
            }
            public static int DeleteUnion(int curnId, int curn_madeby)
        {
            return DataAccessLayer.EMRForms.Union.DeleteUnion(curnId, curn_madeby);
        }
        #endregion
    }
    public class NextcareOrient
    {
        #region NextcareOrient (Page Load)
        public static List<BusinessEntities.EMRForms.NextcareOrient> GetAllNextcareOrient(int appId)
        {
            List<BusinessEntities.EMRForms.NextcareOrient> sclist = new List<BusinessEntities.EMRForms.NextcareOrient>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareOrient.GetAllNextcareOrient(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NextcareOrient
                {
                    cnonId = Convert.ToInt32(dr["cnonId"]),
                    cnon_appId = Convert.ToInt32(dr["cnon_appId"]),
                    cnon_checkbox = dr["cnon_checkbox"].ToString(),
                    cnon_1 = dr["cnon_1"].ToString(),
                    cnon_2 = dr["cnon_2"].ToString(),
                    cnon_3 = dr["cnon_3"].ToString(),
                    cnon_4 = dr["cnon_4"].ToString(),
                    cnon_5 = dr["cnon_5"].ToString(),
                    cnon_6 = dr["cnon_6"].ToString(),
                    cnon_7 = dr["cnon_7"].ToString(),
                    cnon_8 = dr["cnon_8"].ToString(),
                    cnon_9 = dr["cnon_9"].ToString(),
                    cnon_10 = dr["cnon_10"].ToString(),
                    cnon_11 = dr["cnon_11"].ToString(),
                    cnon_12 = dr["cnon_12"].ToString(),
                    cnon_13 = dr["cnon_13"].ToString(),
                    cnon_14 = dr["cnon_14"].ToString(),
                    cnon_15 = dr["cnon_15"].ToString(),
                    cnon_16 = dr["cnon_16"].ToString(),
                    cnon_17 = dr["cnon_17"].ToString(),
                    cnon_18 = dr["cnon_18"].ToString(),
                    cnon_19 = dr["cnon_19"].ToString(),
                    cnon_20 = dr["cnon_20"].ToString(),
                    cnon_21 = dr["cnon_21"].ToString(),
                    cnon_22 = dr["cnon_22"].ToString(),
                    cnon_23 = dr["cnon_23"].ToString(),
                    cnon_24 = dr["cnon_24"].ToString(),
                    cnon_25 = dr["cnon_25"].ToString(),
                    cnon_26 = dr["cnon_26"].ToString(),
                    cnon_27 = dr["cnon_27"].ToString(),
                    cnon_28 = dr["cnon_28"].ToString(),
                    cnon_29 = dr["cnon_29"].ToString(),
                    cnon_30 = dr["cnon_30"].ToString(),
                    cnon_31 = dr["cnon_31"].ToString(),
                    cnon_32 = dr["cnon_32"].ToString(),
                    cnon_33 = dr["cnon_33"].ToString(),
                    cnon_34 = dr["cnon_34"].ToString(),
                    cnon_35 = dr["cnon_35"].ToString(),
                    cnon_36 = dr["cnon_36"].ToString(),
                    cnon_37 = dr["cnon_37"].ToString(),
                    cnon_38 = dr["cnon_38"].ToString(),
                    cnon_39 = dr["cnon_39"].ToString(),
                    cnon_40 = dr["cnon_40"].ToString(),
                    cnon_41 = dr["cnon_41"].ToString(),
                    cnon_date1 = Convert.ToDateTime(dr["cnon_date1"].ToString()),
                    cnon_date2 = Convert.ToDateTime(dr["cnon_date2"].ToString()),
                    cnon_date3 = Convert.ToDateTime(dr["cnon_date3"].ToString()),
                    cnon_date_created = Convert.ToDateTime(dr["cnon_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NextcareOrient> GetAllPreNextcareOrient(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NextcareOrient> sclist = new List<BusinessEntities.EMRForms.NextcareOrient>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareOrient.GetAllPreNextcareOrient(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NextcareOrient
                {
                    cnonId = Convert.ToInt32(dr["cnonId"]),
                    cnon_appId = Convert.ToInt32(dr["cnon_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NextcareOrient> GetPrintNextcareOrient(int? cnonId)
        {
            List<BusinessEntities.EMRForms.NextcareOrient> sclist = new List<BusinessEntities.EMRForms.NextcareOrient>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareOrient.GetPrintNextcareOrient(cnonId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NextcareOrient
                    {
                        cnonId = Convert.ToInt32(dr["cnonId"]),
                        cnon_appId = Convert.ToInt32(dr["cnon_appId"]),
                        cnon_checkbox = dr["cnon_checkbox"].ToString(),
                        cnon_1 = dr["cnon_1"].ToString(),
                        cnon_2 = dr["cnon_2"].ToString(),
                        cnon_3 = dr["cnon_3"].ToString(),
                        cnon_4 = dr["cnon_4"].ToString(),
                        cnon_5 = dr["cnon_5"].ToString(),
                        cnon_6 = dr["cnon_6"].ToString(),
                        cnon_7 = dr["cnon_7"].ToString(),
                        cnon_8 = dr["cnon_8"].ToString(),
                        cnon_9 = dr["cnon_9"].ToString(),
                        cnon_10 = dr["cnon_10"].ToString(),
                        cnon_11 = dr["cnon_11"].ToString(),
                        cnon_12 = dr["cnon_12"].ToString(),
                        cnon_13 = dr["cnon_13"].ToString(),
                        cnon_14 = dr["cnon_14"].ToString(),
                        cnon_15 = dr["cnon_15"].ToString(),
                        cnon_16 = dr["cnon_16"].ToString(),
                        cnon_17 = dr["cnon_17"].ToString(),
                        cnon_18 = dr["cnon_18"].ToString(),
                        cnon_19 = dr["cnon_19"].ToString(),
                        cnon_20 = dr["cnon_20"].ToString(),
                        cnon_21 = dr["cnon_21"].ToString(),
                        cnon_22 = dr["cnon_22"].ToString(),
                        cnon_23 = dr["cnon_23"].ToString(),
                        cnon_24 = dr["cnon_24"].ToString(),
                        cnon_25 = dr["cnon_25"].ToString(),
                        cnon_26 = dr["cnon_26"].ToString(),
                        cnon_27 = dr["cnon_27"].ToString(),
                        cnon_28 = dr["cnon_28"].ToString(),
                        cnon_29 = dr["cnon_29"].ToString(),
                        cnon_30 = dr["cnon_30"].ToString(),
                        cnon_31 = dr["cnon_31"].ToString(),
                        cnon_32 = dr["cnon_32"].ToString(),
                        cnon_33 = dr["cnon_33"].ToString(),
                        cnon_34 = dr["cnon_34"].ToString(),
                        cnon_35 = dr["cnon_35"].ToString(),
                        cnon_36 = dr["cnon_36"].ToString(),
                        cnon_37 = dr["cnon_37"].ToString(),
                        cnon_38 = dr["cnon_38"].ToString(),
                        cnon_39 = dr["cnon_39"].ToString(),
                        cnon_40 = dr["cnon_40"].ToString(),
                        cnon_41 = dr["cnon_41"].ToString(),
                        cnon_dd1 = dr["cnon_date1"].ToString(),
                        cnon_dd2 = dr["cnon_date2"].ToString(),
                        cnon_dd3 = dr["cnon_date3"].ToString(),

                        cnon_date_created = Convert.ToDateTime(dr["cnon_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NextcareOrient a = new BusinessEntities.EMRForms.NextcareOrient();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region NextcareOrient (CRUD Operations)
        public static bool InsertUpdateNextcareOrient(BusinessEntities.EMRForms.NextcareOrient data)
        {
            data.cnon_checkbox = string.IsNullOrEmpty(data.cnon_checkbox) ? string.Empty : data.cnon_checkbox;
            data.cnon_1 = string.IsNullOrEmpty(data.cnon_1) ? string.Empty : data.cnon_1;
            data.cnon_2 = string.IsNullOrEmpty(data.cnon_2) ? string.Empty : data.cnon_2;
            data.cnon_3 = string.IsNullOrEmpty(data.cnon_3) ? string.Empty : data.cnon_3;
            data.cnon_4 = string.IsNullOrEmpty(data.cnon_4) ? string.Empty : data.cnon_4;
            data.cnon_5 = string.IsNullOrEmpty(data.cnon_5) ? string.Empty : data.cnon_5;
            data.cnon_6 = string.IsNullOrEmpty(data.cnon_6) ? string.Empty : data.cnon_6;
            data.cnon_7 = string.IsNullOrEmpty(data.cnon_7) ? string.Empty : data.cnon_7;
            data.cnon_8 = string.IsNullOrEmpty(data.cnon_8) ? string.Empty : data.cnon_8;
            data.cnon_9 = string.IsNullOrEmpty(data.cnon_9) ? string.Empty : data.cnon_9;
            data.cnon_10 = string.IsNullOrEmpty(data.cnon_10) ? string.Empty : data.cnon_10;
            data.cnon_11 = string.IsNullOrEmpty(data.cnon_11) ? string.Empty : data.cnon_11;
            data.cnon_12 = string.IsNullOrEmpty(data.cnon_12) ? string.Empty : data.cnon_12;
            data.cnon_13 = string.IsNullOrEmpty(data.cnon_13) ? string.Empty : data.cnon_13;
            data.cnon_14 = string.IsNullOrEmpty(data.cnon_14) ? string.Empty : data.cnon_14;
            data.cnon_15 = string.IsNullOrEmpty(data.cnon_15) ? string.Empty : data.cnon_15;
            data.cnon_16 = string.IsNullOrEmpty(data.cnon_16) ? string.Empty : data.cnon_16;
            data.cnon_17 = string.IsNullOrEmpty(data.cnon_17) ? string.Empty : data.cnon_17;
            data.cnon_18 = string.IsNullOrEmpty(data.cnon_18) ? string.Empty : data.cnon_18;
            data.cnon_19 = string.IsNullOrEmpty(data.cnon_19) ? string.Empty : data.cnon_19;
            data.cnon_20 = string.IsNullOrEmpty(data.cnon_20) ? string.Empty : data.cnon_20;
            data.cnon_21 = string.IsNullOrEmpty(data.cnon_21) ? string.Empty : data.cnon_21;
            data.cnon_22 = string.IsNullOrEmpty(data.cnon_22) ? string.Empty : data.cnon_22;
            data.cnon_23 = string.IsNullOrEmpty(data.cnon_23) ? string.Empty : data.cnon_23;
            data.cnon_24 = string.IsNullOrEmpty(data.cnon_24) ? string.Empty : data.cnon_24;
            data.cnon_25 = string.IsNullOrEmpty(data.cnon_25) ? string.Empty : data.cnon_25;
            data.cnon_26 = string.IsNullOrEmpty(data.cnon_26) ? string.Empty : data.cnon_26;
            data.cnon_27 = string.IsNullOrEmpty(data.cnon_27) ? string.Empty : data.cnon_27;
            data.cnon_28 = string.IsNullOrEmpty(data.cnon_28) ? string.Empty : data.cnon_28;
            data.cnon_29 = string.IsNullOrEmpty(data.cnon_29) ? string.Empty : data.cnon_29;
            data.cnon_30 = string.IsNullOrEmpty(data.cnon_30) ? string.Empty : data.cnon_30;
            data.cnon_31 = string.IsNullOrEmpty(data.cnon_31) ? string.Empty : data.cnon_31;
            data.cnon_32 = string.IsNullOrEmpty(data.cnon_32) ? string.Empty : data.cnon_32;
            data.cnon_33 = string.IsNullOrEmpty(data.cnon_33) ? string.Empty : data.cnon_33;
            data.cnon_34 = string.IsNullOrEmpty(data.cnon_34) ? string.Empty : data.cnon_34;
            data.cnon_35 = string.IsNullOrEmpty(data.cnon_35) ? string.Empty : data.cnon_35;
            data.cnon_36 = string.IsNullOrEmpty(data.cnon_36) ? string.Empty : data.cnon_36;
            data.cnon_37 = string.IsNullOrEmpty(data.cnon_37) ? string.Empty : data.cnon_37;
            data.cnon_38 = string.IsNullOrEmpty(data.cnon_38) ? string.Empty : data.cnon_38;
            data.cnon_39 = string.IsNullOrEmpty(data.cnon_39) ? string.Empty : data.cnon_39;
            data.cnon_40 = string.IsNullOrEmpty(data.cnon_40) ? string.Empty : data.cnon_40;
            data.cnon_41 = string.IsNullOrEmpty(data.cnon_41) ? string.Empty : data.cnon_41;
            DateTime? card1 = data.cnon_date1; // Assuming data.cnon_date1 is of type DateTime?            
            DateTime? card2 = data.cnon_date2; // Assuming data.cnon_date2 is of type DateTime?
            DateTime? card3 = data.cnon_date3; // Assuming data.cnon_date3 is of type DateTime?
            if (data.cnon_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnon_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnon_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cnon_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnon_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnon_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.cnon_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnon_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnon_date3 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.NextcareOrient.InsertUpdateNextcareOrient(data);
        }
        public static int DeleteNextcareOrient(int cnonId, int cnon_madeby)
        {
            return DataAccessLayer.EMRForms.NextcareOrient.DeleteNextcareOrient(cnonId, cnon_madeby);
        }
        #endregion
    }

    public class NextcareMajid
    {
        #region NextcareMajid (Page Load)
        public static List<BusinessEntities.EMRForms.NextcareMajid> GetAllNextcareMajid(int appId)
        {
            List<BusinessEntities.EMRForms.NextcareMajid> sclist = new List<BusinessEntities.EMRForms.NextcareMajid>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareMajid.GetAllNextcareMajid(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NextcareMajid
                {
                    cnmnId = Convert.ToInt32(dr["cnmnId"]),
                    cnmn_appId = Convert.ToInt32(dr["cnmn_appId"]),
                    cnmn_checkbox = dr["cnmn_checkbox"].ToString(),
                    cnmn_1 = dr["cnmn_1"].ToString(),
                    cnmn_2 = dr["cnmn_2"].ToString(),
                    cnmn_3 = dr["cnmn_3"].ToString(),
                    cnmn_4 = dr["cnmn_4"].ToString(),
                    cnmn_5 = dr["cnmn_5"].ToString(),
                    cnmn_6 = dr["cnmn_6"].ToString(),
                    cnmn_7 = dr["cnmn_7"].ToString(),
                    cnmn_8 = dr["cnmn_8"].ToString(),
                    cnmn_9 = dr["cnmn_9"].ToString(),
                    cnmn_10 = dr["cnmn_10"].ToString(),
                    cnmn_11 = dr["cnmn_11"].ToString(),
                    cnmn_12 = dr["cnmn_12"].ToString(),
                    cnmn_13 = dr["cnmn_13"].ToString(),
                    cnmn_14 = dr["cnmn_14"].ToString(),
                    cnmn_15 = dr["cnmn_15"].ToString(),
                    cnmn_16 = dr["cnmn_16"].ToString(),
                    cnmn_17 = dr["cnmn_17"].ToString(),
                    cnmn_18 = dr["cnmn_18"].ToString(),
                    cnmn_19 = dr["cnmn_19"].ToString(),
                    cnmn_20 = dr["cnmn_20"].ToString(),
                    cnmn_21 = dr["cnmn_21"].ToString(),
                    cnmn_22 = dr["cnmn_22"].ToString(),
                    cnmn_23 = dr["cnmn_23"].ToString(),
                    cnmn_24 = dr["cnmn_24"].ToString(),
                    cnmn_25 = dr["cnmn_25"].ToString(),
                    cnmn_26 = dr["cnmn_26"].ToString(),
                    cnmn_27 = dr["cnmn_27"].ToString(),
                    cnmn_28 = dr["cnmn_28"].ToString(),
                    cnmn_29 = dr["cnmn_29"].ToString(),
                    cnmn_30 = dr["cnmn_30"].ToString(),
                    cnmn_31 = dr["cnmn_31"].ToString(),
                    cnmn_32 = dr["cnmn_32"].ToString(),
                    cnmn_33 = dr["cnmn_33"].ToString(),
                    cnmn_34 = dr["cnmn_34"].ToString(),
                    cnmn_35 = dr["cnmn_35"].ToString(),
                    cnmn_36 = dr["cnmn_36"].ToString(),
                    cnmn_37 = dr["cnmn_37"].ToString(),
                    cnmn_38 = dr["cnmn_38"].ToString(),
                    cnmn_39 = dr["cnmn_39"].ToString(),
                    cnmn_40 = dr["cnmn_40"].ToString(),
                    cnmn_41 = dr["cnmn_41"].ToString(),
                    cnmn_date1 = Convert.ToDateTime(dr["cnmn_date1"].ToString()),
                    cnmn_date2 = Convert.ToDateTime(dr["cnmn_date2"].ToString()),
                    cnmn_date3 = Convert.ToDateTime(dr["cnmn_date3"].ToString()),
                    cnmn_date_created = Convert.ToDateTime(dr["cnmn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NextcareMajid> GetAllPreNextcareMajid(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NextcareMajid> sclist = new List<BusinessEntities.EMRForms.NextcareMajid>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareMajid.GetAllPreNextcareMajid(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NextcareMajid
                {
                    cnmnId = Convert.ToInt32(dr["cnmnId"]),
                    cnmn_appId = Convert.ToInt32(dr["cnmn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NextcareMajid> GetPrintNextcareMajid(int? cnmnId)
        {
            List<BusinessEntities.EMRForms.NextcareMajid> sclist = new List<BusinessEntities.EMRForms.NextcareMajid>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareMajid.GetPrintNextcareMajid(cnmnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NextcareMajid
                    {
                        cnmnId = Convert.ToInt32(dr["cnmnId"]),
                        cnmn_appId = Convert.ToInt32(dr["cnmn_appId"]),
                        cnmn_checkbox = dr["cnmn_checkbox"].ToString(),
                        cnmn_1 = dr["cnmn_1"].ToString(),
                        cnmn_2 = dr["cnmn_2"].ToString(),
                        cnmn_3 = dr["cnmn_3"].ToString(),
                        cnmn_4 = dr["cnmn_4"].ToString(),
                        cnmn_5 = dr["cnmn_5"].ToString(),
                        cnmn_6 = dr["cnmn_6"].ToString(),
                        cnmn_7 = dr["cnmn_7"].ToString(),
                        cnmn_8 = dr["cnmn_8"].ToString(),
                        cnmn_9 = dr["cnmn_9"].ToString(),
                        cnmn_10 = dr["cnmn_10"].ToString(),
                        cnmn_11 = dr["cnmn_11"].ToString(),
                        cnmn_12 = dr["cnmn_12"].ToString(),
                        cnmn_13 = dr["cnmn_13"].ToString(),
                        cnmn_14 = dr["cnmn_14"].ToString(),
                        cnmn_15 = dr["cnmn_15"].ToString(),
                        cnmn_16 = dr["cnmn_16"].ToString(),
                        cnmn_17 = dr["cnmn_17"].ToString(),
                        cnmn_18 = dr["cnmn_18"].ToString(),
                        cnmn_19 = dr["cnmn_19"].ToString(),
                        cnmn_20 = dr["cnmn_20"].ToString(),
                        cnmn_21 = dr["cnmn_21"].ToString(),
                        cnmn_22 = dr["cnmn_22"].ToString(),
                        cnmn_23 = dr["cnmn_23"].ToString(),
                        cnmn_24 = dr["cnmn_24"].ToString(),
                        cnmn_25 = dr["cnmn_25"].ToString(),
                        cnmn_26 = dr["cnmn_26"].ToString(),
                        cnmn_27 = dr["cnmn_27"].ToString(),
                        cnmn_28 = dr["cnmn_28"].ToString(),
                        cnmn_29 = dr["cnmn_29"].ToString(),
                        cnmn_30 = dr["cnmn_30"].ToString(),
                        cnmn_31 = dr["cnmn_31"].ToString(),
                        cnmn_32 = dr["cnmn_32"].ToString(),
                        cnmn_33 = dr["cnmn_33"].ToString(),
                        cnmn_34 = dr["cnmn_34"].ToString(),
                        cnmn_35 = dr["cnmn_35"].ToString(),
                        cnmn_36 = dr["cnmn_36"].ToString(),
                        cnmn_37 = dr["cnmn_37"].ToString(),
                        cnmn_38 = dr["cnmn_38"].ToString(),
                        cnmn_39 = dr["cnmn_39"].ToString(),
                        cnmn_40 = dr["cnmn_40"].ToString(),
                        cnmn_41 = dr["cnmn_41"].ToString(),
                        cnmn_dd1 = dr["cnmn_date1"].ToString(),
                        cnmn_dd2 = dr["cnmn_date2"].ToString(),
                        cnmn_dd3 = dr["cnmn_date3"].ToString(),

                        cnmn_date_created = Convert.ToDateTime(dr["cnmn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NextcareMajid a = new BusinessEntities.EMRForms.NextcareMajid();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region NextcareMajid (CRUD Operations)
        public static bool InsertUpdateNextcareMajid(BusinessEntities.EMRForms.NextcareMajid data)
        {
            data.cnmn_checkbox = string.IsNullOrEmpty(data.cnmn_checkbox) ? string.Empty : data.cnmn_checkbox;
            data.cnmn_1 = string.IsNullOrEmpty(data.cnmn_1) ? string.Empty : data.cnmn_1;
            data.cnmn_2 = string.IsNullOrEmpty(data.cnmn_2) ? string.Empty : data.cnmn_2;
            data.cnmn_3 = string.IsNullOrEmpty(data.cnmn_3) ? string.Empty : data.cnmn_3;
            data.cnmn_4 = string.IsNullOrEmpty(data.cnmn_4) ? string.Empty : data.cnmn_4;
            data.cnmn_5 = string.IsNullOrEmpty(data.cnmn_5) ? string.Empty : data.cnmn_5;
            data.cnmn_6 = string.IsNullOrEmpty(data.cnmn_6) ? string.Empty : data.cnmn_6;
            data.cnmn_7 = string.IsNullOrEmpty(data.cnmn_7) ? string.Empty : data.cnmn_7;
            data.cnmn_8 = string.IsNullOrEmpty(data.cnmn_8) ? string.Empty : data.cnmn_8;
            data.cnmn_9 = string.IsNullOrEmpty(data.cnmn_9) ? string.Empty : data.cnmn_9;
            data.cnmn_10 = string.IsNullOrEmpty(data.cnmn_10) ? string.Empty : data.cnmn_10;
            data.cnmn_11 = string.IsNullOrEmpty(data.cnmn_11) ? string.Empty : data.cnmn_11;
            data.cnmn_12 = string.IsNullOrEmpty(data.cnmn_12) ? string.Empty : data.cnmn_12;
            data.cnmn_13 = string.IsNullOrEmpty(data.cnmn_13) ? string.Empty : data.cnmn_13;
            data.cnmn_14 = string.IsNullOrEmpty(data.cnmn_14) ? string.Empty : data.cnmn_14;
            data.cnmn_15 = string.IsNullOrEmpty(data.cnmn_15) ? string.Empty : data.cnmn_15;
            data.cnmn_16 = string.IsNullOrEmpty(data.cnmn_16) ? string.Empty : data.cnmn_16;
            data.cnmn_17 = string.IsNullOrEmpty(data.cnmn_17) ? string.Empty : data.cnmn_17;
            data.cnmn_18 = string.IsNullOrEmpty(data.cnmn_18) ? string.Empty : data.cnmn_18;
            data.cnmn_19 = string.IsNullOrEmpty(data.cnmn_19) ? string.Empty : data.cnmn_19;
            data.cnmn_20 = string.IsNullOrEmpty(data.cnmn_20) ? string.Empty : data.cnmn_20;
            data.cnmn_21 = string.IsNullOrEmpty(data.cnmn_21) ? string.Empty : data.cnmn_21;
            data.cnmn_22 = string.IsNullOrEmpty(data.cnmn_22) ? string.Empty : data.cnmn_22;
            data.cnmn_23 = string.IsNullOrEmpty(data.cnmn_23) ? string.Empty : data.cnmn_23;
            data.cnmn_24 = string.IsNullOrEmpty(data.cnmn_24) ? string.Empty : data.cnmn_24;
            data.cnmn_25 = string.IsNullOrEmpty(data.cnmn_25) ? string.Empty : data.cnmn_25;
            data.cnmn_26 = string.IsNullOrEmpty(data.cnmn_26) ? string.Empty : data.cnmn_26;
            data.cnmn_27 = string.IsNullOrEmpty(data.cnmn_27) ? string.Empty : data.cnmn_27;
            data.cnmn_28 = string.IsNullOrEmpty(data.cnmn_28) ? string.Empty : data.cnmn_28;
            data.cnmn_29 = string.IsNullOrEmpty(data.cnmn_29) ? string.Empty : data.cnmn_29;
            data.cnmn_30 = string.IsNullOrEmpty(data.cnmn_30) ? string.Empty : data.cnmn_30;
            data.cnmn_31 = string.IsNullOrEmpty(data.cnmn_31) ? string.Empty : data.cnmn_31;
            data.cnmn_32 = string.IsNullOrEmpty(data.cnmn_32) ? string.Empty : data.cnmn_32;
            data.cnmn_33 = string.IsNullOrEmpty(data.cnmn_33) ? string.Empty : data.cnmn_33;
            data.cnmn_34 = string.IsNullOrEmpty(data.cnmn_34) ? string.Empty : data.cnmn_34;
            data.cnmn_35 = string.IsNullOrEmpty(data.cnmn_35) ? string.Empty : data.cnmn_35;
            data.cnmn_36 = string.IsNullOrEmpty(data.cnmn_36) ? string.Empty : data.cnmn_36;
            data.cnmn_37 = string.IsNullOrEmpty(data.cnmn_37) ? string.Empty : data.cnmn_37;
            data.cnmn_38 = string.IsNullOrEmpty(data.cnmn_38) ? string.Empty : data.cnmn_38;
            data.cnmn_39 = string.IsNullOrEmpty(data.cnmn_39) ? string.Empty : data.cnmn_39;
            data.cnmn_40 = string.IsNullOrEmpty(data.cnmn_40) ? string.Empty : data.cnmn_40;
            data.cnmn_41 = string.IsNullOrEmpty(data.cnmn_41) ? string.Empty : data.cnmn_41;
            DateTime? card1 = data.cnmn_date1; // Assuming data.cnmn_date1 is of type DateTime?            
            DateTime? card2 = data.cnmn_date2; // Assuming data.cnmn_date2 is of type DateTime?
            DateTime? card3 = data.cnmn_date3; // Assuming data.cnmn_date3 is of type DateTime?
            if (data.cnmn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnmn_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnmn_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cnmn_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnmn_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnmn_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.cnmn_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnmn_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnmn_date3 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.NextcareMajid.InsertUpdateNextcareMajid(data);
        }
        public static int DeleteNextcareMajid(int cnmnId, int cnmn_madeby)
        {
            return DataAccessLayer.EMRForms.NextcareMajid.DeleteNextcareMajid(cnmnId, cnmn_madeby);
        }
        #endregion
    }
    public class NextcareAsnic
    {
        #region NextcareAsnic (Page Load)
        public static List<BusinessEntities.EMRForms.NextcareAsnic> GetAllNextcareAsnic(int appId)
        {
            List<BusinessEntities.EMRForms.NextcareAsnic> sclist = new List<BusinessEntities.EMRForms.NextcareAsnic>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareAsnic.GetAllNextcareAsnic(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NextcareAsnic
                {
                    cnanId = Convert.ToInt32(dr["cnanId"]),
                    cnan_appId = Convert.ToInt32(dr["cnan_appId"]),
                    cnan_checkbox = dr["cnan_checkbox"].ToString(),
                    cnan_1 = dr["cnan_1"].ToString(),
                    cnan_2 = dr["cnan_2"].ToString(),
                    cnan_3 = dr["cnan_3"].ToString(),
                    cnan_4 = dr["cnan_4"].ToString(),
                    cnan_5 = dr["cnan_5"].ToString(),
                    cnan_6 = dr["cnan_6"].ToString(),
                    cnan_7 = dr["cnan_7"].ToString(),
                    cnan_8 = dr["cnan_8"].ToString(),
                    cnan_9 = dr["cnan_9"].ToString(),
                    cnan_10 = dr["cnan_10"].ToString(),
                    cnan_11 = dr["cnan_11"].ToString(),
                    cnan_12 = dr["cnan_12"].ToString(),
                    cnan_13 = dr["cnan_13"].ToString(),
                    cnan_14 = dr["cnan_14"].ToString(),
                    cnan_15 = dr["cnan_15"].ToString(),
                    cnan_16 = dr["cnan_16"].ToString(),
                    cnan_17 = dr["cnan_17"].ToString(),
                    cnan_18 = dr["cnan_18"].ToString(),
                    cnan_19 = dr["cnan_19"].ToString(),
                    cnan_20 = dr["cnan_20"].ToString(),
                    cnan_21 = dr["cnan_21"].ToString(),
                    cnan_22 = dr["cnan_22"].ToString(),
                    cnan_23 = dr["cnan_23"].ToString(),
                    cnan_24 = dr["cnan_24"].ToString(),
                    cnan_25 = dr["cnan_25"].ToString(),
                    cnan_26 = dr["cnan_26"].ToString(),
                    cnan_27 = dr["cnan_27"].ToString(),
                    cnan_28 = dr["cnan_28"].ToString(),
                    cnan_29 = dr["cnan_29"].ToString(),
                    cnan_30 = dr["cnan_30"].ToString(),
                    cnan_31 = dr["cnan_31"].ToString(),
                    cnan_32 = dr["cnan_32"].ToString(),
                    cnan_33 = dr["cnan_33"].ToString(),
                    cnan_34 = dr["cnan_34"].ToString(),
                    cnan_35 = dr["cnan_35"].ToString(),
                    cnan_36 = dr["cnan_36"].ToString(),
                    cnan_37 = dr["cnan_37"].ToString(),
                    cnan_38 = dr["cnan_38"].ToString(),
                    cnan_39 = dr["cnan_39"].ToString(),
                    cnan_40 = dr["cnan_40"].ToString(),
                    cnan_41 = dr["cnan_41"].ToString(),
                    cnan_date1 = Convert.ToDateTime(dr["cnan_date1"].ToString()),
                    cnan_date2 = Convert.ToDateTime(dr["cnan_date2"].ToString()),
                    cnan_date3 = Convert.ToDateTime(dr["cnan_date3"].ToString()),
                    cnan_date_created = Convert.ToDateTime(dr["cnan_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NextcareAsnic> GetAllPreNextcareAsnic(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NextcareAsnic> sclist = new List<BusinessEntities.EMRForms.NextcareAsnic>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareAsnic.GetAllPreNextcareAsnic(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NextcareAsnic
                {
                    cnanId = Convert.ToInt32(dr["cnanId"]),
                    cnan_appId = Convert.ToInt32(dr["cnan_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NextcareAsnic> GetPrintNextcareAsnic(int? cnanId)
        {
            List<BusinessEntities.EMRForms.NextcareAsnic> sclist = new List<BusinessEntities.EMRForms.NextcareAsnic>();
            DataTable dt = DataAccessLayer.EMRForms.NextcareAsnic.GetPrintNextcareAsnic(cnanId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NextcareAsnic
                    {
                        cnanId = Convert.ToInt32(dr["cnanId"]),
                        cnan_appId = Convert.ToInt32(dr["cnan_appId"]),
                        cnan_checkbox = dr["cnan_checkbox"].ToString(),
                        cnan_1 = dr["cnan_1"].ToString(),
                        cnan_2 = dr["cnan_2"].ToString(),
                        cnan_3 = dr["cnan_3"].ToString(),
                        cnan_4 = dr["cnan_4"].ToString(),
                        cnan_5 = dr["cnan_5"].ToString(),
                        cnan_6 = dr["cnan_6"].ToString(),
                        cnan_7 = dr["cnan_7"].ToString(),
                        cnan_8 = dr["cnan_8"].ToString(),
                        cnan_9 = dr["cnan_9"].ToString(),
                        cnan_10 = dr["cnan_10"].ToString(),
                        cnan_11 = dr["cnan_11"].ToString(),
                        cnan_12 = dr["cnan_12"].ToString(),
                        cnan_13 = dr["cnan_13"].ToString(),
                        cnan_14 = dr["cnan_14"].ToString(),
                        cnan_15 = dr["cnan_15"].ToString(),
                        cnan_16 = dr["cnan_16"].ToString(),
                        cnan_17 = dr["cnan_17"].ToString(),
                        cnan_18 = dr["cnan_18"].ToString(),
                        cnan_19 = dr["cnan_19"].ToString(),
                        cnan_20 = dr["cnan_20"].ToString(),
                        cnan_21 = dr["cnan_21"].ToString(),
                        cnan_22 = dr["cnan_22"].ToString(),
                        cnan_23 = dr["cnan_23"].ToString(),
                        cnan_24 = dr["cnan_24"].ToString(),
                        cnan_25 = dr["cnan_25"].ToString(),
                        cnan_26 = dr["cnan_26"].ToString(),
                        cnan_27 = dr["cnan_27"].ToString(),
                        cnan_28 = dr["cnan_28"].ToString(),
                        cnan_29 = dr["cnan_29"].ToString(),
                        cnan_30 = dr["cnan_30"].ToString(),
                        cnan_31 = dr["cnan_31"].ToString(),
                        cnan_32 = dr["cnan_32"].ToString(),
                        cnan_33 = dr["cnan_33"].ToString(),
                        cnan_34 = dr["cnan_34"].ToString(),
                        cnan_35 = dr["cnan_35"].ToString(),
                        cnan_36 = dr["cnan_36"].ToString(),
                        cnan_37 = dr["cnan_37"].ToString(),
                        cnan_38 = dr["cnan_38"].ToString(),
                        cnan_39 = dr["cnan_39"].ToString(),
                        cnan_40 = dr["cnan_40"].ToString(),
                        cnan_41 = dr["cnan_41"].ToString(),
                        cnan_dd1 = dr["cnan_date1"].ToString(),
                        cnan_dd2 = dr["cnan_date2"].ToString(),
                        cnan_dd3 = dr["cnan_date3"].ToString(),

                        cnan_date_created = Convert.ToDateTime(dr["cnan_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NextcareAsnic a = new BusinessEntities.EMRForms.NextcareAsnic();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region NextcareAsnic (CRUD Operations)
        public static bool InsertUpdateNextcareAsnic(BusinessEntities.EMRForms.NextcareAsnic data)
        {
            data.cnan_checkbox = string.IsNullOrEmpty(data.cnan_checkbox) ? string.Empty : data.cnan_checkbox;
            data.cnan_1 = string.IsNullOrEmpty(data.cnan_1) ? string.Empty : data.cnan_1;
            data.cnan_2 = string.IsNullOrEmpty(data.cnan_2) ? string.Empty : data.cnan_2;
            data.cnan_3 = string.IsNullOrEmpty(data.cnan_3) ? string.Empty : data.cnan_3;
            data.cnan_4 = string.IsNullOrEmpty(data.cnan_4) ? string.Empty : data.cnan_4;
            data.cnan_5 = string.IsNullOrEmpty(data.cnan_5) ? string.Empty : data.cnan_5;
            data.cnan_6 = string.IsNullOrEmpty(data.cnan_6) ? string.Empty : data.cnan_6;
            data.cnan_7 = string.IsNullOrEmpty(data.cnan_7) ? string.Empty : data.cnan_7;
            data.cnan_8 = string.IsNullOrEmpty(data.cnan_8) ? string.Empty : data.cnan_8;
            data.cnan_9 = string.IsNullOrEmpty(data.cnan_9) ? string.Empty : data.cnan_9;
            data.cnan_10 = string.IsNullOrEmpty(data.cnan_10) ? string.Empty : data.cnan_10;
            data.cnan_11 = string.IsNullOrEmpty(data.cnan_11) ? string.Empty : data.cnan_11;
            data.cnan_12 = string.IsNullOrEmpty(data.cnan_12) ? string.Empty : data.cnan_12;
            data.cnan_13 = string.IsNullOrEmpty(data.cnan_13) ? string.Empty : data.cnan_13;
            data.cnan_14 = string.IsNullOrEmpty(data.cnan_14) ? string.Empty : data.cnan_14;
            data.cnan_15 = string.IsNullOrEmpty(data.cnan_15) ? string.Empty : data.cnan_15;
            data.cnan_16 = string.IsNullOrEmpty(data.cnan_16) ? string.Empty : data.cnan_16;
            data.cnan_17 = string.IsNullOrEmpty(data.cnan_17) ? string.Empty : data.cnan_17;
            data.cnan_18 = string.IsNullOrEmpty(data.cnan_18) ? string.Empty : data.cnan_18;
            data.cnan_19 = string.IsNullOrEmpty(data.cnan_19) ? string.Empty : data.cnan_19;
            data.cnan_20 = string.IsNullOrEmpty(data.cnan_20) ? string.Empty : data.cnan_20;
            data.cnan_21 = string.IsNullOrEmpty(data.cnan_21) ? string.Empty : data.cnan_21;
            data.cnan_22 = string.IsNullOrEmpty(data.cnan_22) ? string.Empty : data.cnan_22;
            data.cnan_23 = string.IsNullOrEmpty(data.cnan_23) ? string.Empty : data.cnan_23;
            data.cnan_24 = string.IsNullOrEmpty(data.cnan_24) ? string.Empty : data.cnan_24;
            data.cnan_25 = string.IsNullOrEmpty(data.cnan_25) ? string.Empty : data.cnan_25;
            data.cnan_26 = string.IsNullOrEmpty(data.cnan_26) ? string.Empty : data.cnan_26;
            data.cnan_27 = string.IsNullOrEmpty(data.cnan_27) ? string.Empty : data.cnan_27;
            data.cnan_28 = string.IsNullOrEmpty(data.cnan_28) ? string.Empty : data.cnan_28;
            data.cnan_29 = string.IsNullOrEmpty(data.cnan_29) ? string.Empty : data.cnan_29;
            data.cnan_30 = string.IsNullOrEmpty(data.cnan_30) ? string.Empty : data.cnan_30;
            data.cnan_31 = string.IsNullOrEmpty(data.cnan_31) ? string.Empty : data.cnan_31;
            data.cnan_32 = string.IsNullOrEmpty(data.cnan_32) ? string.Empty : data.cnan_32;
            data.cnan_33 = string.IsNullOrEmpty(data.cnan_33) ? string.Empty : data.cnan_33;
            data.cnan_34 = string.IsNullOrEmpty(data.cnan_34) ? string.Empty : data.cnan_34;
            data.cnan_35 = string.IsNullOrEmpty(data.cnan_35) ? string.Empty : data.cnan_35;
            data.cnan_36 = string.IsNullOrEmpty(data.cnan_36) ? string.Empty : data.cnan_36;
            data.cnan_37 = string.IsNullOrEmpty(data.cnan_37) ? string.Empty : data.cnan_37;
            data.cnan_38 = string.IsNullOrEmpty(data.cnan_38) ? string.Empty : data.cnan_38;
            data.cnan_39 = string.IsNullOrEmpty(data.cnan_39) ? string.Empty : data.cnan_39;
            data.cnan_40 = string.IsNullOrEmpty(data.cnan_40) ? string.Empty : data.cnan_40;
            data.cnan_41 = string.IsNullOrEmpty(data.cnan_41) ? string.Empty : data.cnan_41;
            DateTime? card1 = data.cnan_date1; // Assuming data.cnan_date1 is of type DateTime?            
            DateTime? card2 = data.cnan_date2; // Assuming data.cnan_date2 is of type DateTime?
            DateTime? card3 = data.cnan_date3; // Assuming data.cnan_date3 is of type DateTime?
            if (data.cnan_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnan_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnan_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cnan_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnan_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnan_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.cnan_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cnan_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cnan_date3 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.NextcareAsnic.InsertUpdateNextcareAsnic(data);
        }
        public static int DeleteNextcareAsnic(int cnanId, int cnan_madeby)
        {
            return DataAccessLayer.EMRForms.NextcareAsnic.DeleteNextcareAsnic(cnanId, cnan_madeby);
        }
        #endregion
    }
    public class Maxcare
    {
        #region Maxcare (Page Load)
        public static List<BusinessEntities.EMRForms.Maxcare> GetAllMaxcare(int appId)
        {
            List<BusinessEntities.EMRForms.Maxcare> sclist = new List<BusinessEntities.EMRForms.Maxcare>();
            DataTable dt = DataAccessLayer.EMRForms.Maxcare.GetAllMaxcare(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Maxcare
                {
                    maxnId = Convert.ToInt32(dr["maxnId"]),
                    maxn_appId = Convert.ToInt32(dr["maxn_appId"]),
                    maxn_checkbox = dr["maxn_checkbox"].ToString(),
                    maxn_1 = dr["maxn_1"].ToString(),
                    maxn_2 = dr["maxn_2"].ToString(),
                    maxn_3 = dr["maxn_3"].ToString(),
                    maxn_4 = dr["maxn_4"].ToString(),
                    maxn_5 = dr["maxn_5"].ToString(),
                    maxn_6 = dr["maxn_6"].ToString(),
                    maxn_7 = dr["maxn_7"].ToString(),
                    maxn_8 = dr["maxn_8"].ToString(),
                    maxn_9 = dr["maxn_9"].ToString(),
                    maxn_10 = dr["maxn_10"].ToString(),
                    maxn_11 = dr["maxn_11"].ToString(),
                    maxn_12 = dr["maxn_12"].ToString(),
                    maxn_13 = dr["maxn_13"].ToString(),
                    maxn_14 = dr["maxn_14"].ToString(),
                    maxn_15 = dr["maxn_15"].ToString(),
                    maxn_16 = dr["maxn_16"].ToString(),
                    maxn_17 = dr["maxn_17"].ToString(),
                    maxn_18 = dr["maxn_18"].ToString(),
                    maxn_19 = dr["maxn_19"].ToString(),
                    maxn_20 = dr["maxn_20"].ToString(),
                    maxn_21 = dr["maxn_21"].ToString(),
                    maxn_22 = dr["maxn_22"].ToString(),
                    maxn_23 = dr["maxn_23"].ToString(),
                    maxn_24 = dr["maxn_24"].ToString(),
                    maxn_25 = dr["maxn_25"].ToString(),
                    maxn_26 = dr["maxn_26"].ToString(),
                    maxn_27 = dr["maxn_27"].ToString(),
                    maxn_28 = dr["maxn_28"].ToString(),
                    maxn_29 = dr["maxn_29"].ToString(),
                    maxn_30 = dr["maxn_30"].ToString(),
                    maxn_31 = dr["maxn_31"].ToString(),
                    maxn_32 = dr["maxn_32"].ToString(),
                    maxn_33 = dr["maxn_33"].ToString(),
                    maxn_34 = dr["maxn_34"].ToString(),
                    maxn_35 = dr["maxn_35"].ToString(),
                    maxn_36 = dr["maxn_36"].ToString(),
                    maxn_37 = dr["maxn_37"].ToString(),
                    maxn_38 = dr["maxn_38"].ToString(),
                    maxn_39 = dr["maxn_39"].ToString(),
                    maxn_40 = dr["maxn_40"].ToString(),
                    maxn_41 = dr["maxn_41"].ToString(),
                    maxn_date1 = Convert.ToDateTime(dr["maxn_date1"].ToString()),
                    maxn_date2 = Convert.ToDateTime(dr["maxn_date2"].ToString()),
                    maxn_date3 = Convert.ToDateTime(dr["maxn_date3"].ToString()),
                    maxn_date_created = Convert.ToDateTime(dr["maxn_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Maxcare> GetAllPreMaxcare(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Maxcare> sclist = new List<BusinessEntities.EMRForms.Maxcare>();
            DataTable dt = DataAccessLayer.EMRForms.Maxcare.GetAllPreMaxcare(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Maxcare
                {
                    maxnId = Convert.ToInt32(dr["maxnId"]),
                    maxn_appId = Convert.ToInt32(dr["maxn_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Maxcare> GetPrintMaxcare(int? maxnId)
        {
            List<BusinessEntities.EMRForms.Maxcare> sclist = new List<BusinessEntities.EMRForms.Maxcare>();
            DataTable dt = DataAccessLayer.EMRForms.Maxcare.GetPrintMaxcare(maxnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Maxcare
                    {
                        maxnId = Convert.ToInt32(dr["maxnId"]),
                        maxn_appId = Convert.ToInt32(dr["maxn_appId"]),
                        maxn_checkbox = dr["maxn_checkbox"].ToString(),
                        maxn_1 = dr["maxn_1"].ToString(),
                        maxn_2 = dr["maxn_2"].ToString(),
                        maxn_3 = dr["maxn_3"].ToString(),
                        maxn_4 = dr["maxn_4"].ToString(),
                        maxn_5 = dr["maxn_5"].ToString(),
                        maxn_6 = dr["maxn_6"].ToString(),
                        maxn_7 = dr["maxn_7"].ToString(),
                        maxn_8 = dr["maxn_8"].ToString(),
                        maxn_9 = dr["maxn_9"].ToString(),
                        maxn_10 = dr["maxn_10"].ToString(),
                        maxn_11 = dr["maxn_11"].ToString(),
                        maxn_12 = dr["maxn_12"].ToString(),
                        maxn_13 = dr["maxn_13"].ToString(),
                        maxn_14 = dr["maxn_14"].ToString(),
                        maxn_15 = dr["maxn_15"].ToString(),
                        maxn_16 = dr["maxn_16"].ToString(),
                        maxn_17 = dr["maxn_17"].ToString(),
                        maxn_18 = dr["maxn_18"].ToString(),
                        maxn_19 = dr["maxn_19"].ToString(),
                        maxn_20 = dr["maxn_20"].ToString(),
                        maxn_21 = dr["maxn_21"].ToString(),
                        maxn_22 = dr["maxn_22"].ToString(),
                        maxn_23 = dr["maxn_23"].ToString(),
                        maxn_24 = dr["maxn_24"].ToString(),
                        maxn_25 = dr["maxn_25"].ToString(),
                        maxn_26 = dr["maxn_26"].ToString(),
                        maxn_27 = dr["maxn_27"].ToString(),
                        maxn_28 = dr["maxn_28"].ToString(),
                        maxn_29 = dr["maxn_29"].ToString(),
                        maxn_30 = dr["maxn_30"].ToString(),
                        maxn_31 = dr["maxn_31"].ToString(),
                        maxn_32 = dr["maxn_32"].ToString(),
                        maxn_33 = dr["maxn_33"].ToString(),
                        maxn_34 = dr["maxn_34"].ToString(),
                        maxn_35 = dr["maxn_35"].ToString(),
                        maxn_36 = dr["maxn_36"].ToString(),
                        maxn_37 = dr["maxn_37"].ToString(),
                        maxn_38 = dr["maxn_38"].ToString(),
                        maxn_39 = dr["maxn_39"].ToString(),
                        maxn_40 = dr["maxn_40"].ToString(),
                        maxn_41 = dr["maxn_41"].ToString(),
                        maxn_dd1 = dr["maxn_date1"].ToString(),
                        maxn_dd2 = dr["maxn_date2"].ToString(),
                        maxn_dd3 = dr["maxn_date3"].ToString(),

                        maxn_date_created = Convert.ToDateTime(dr["maxn_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Maxcare a = new BusinessEntities.EMRForms.Maxcare();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region Maxcare (CRUD Operations)
        public static bool InsertUpdateMaxcare(BusinessEntities.EMRForms.Maxcare data)
        {
            data.maxn_checkbox = string.IsNullOrEmpty(data.maxn_checkbox) ? string.Empty : data.maxn_checkbox;
            data.maxn_1 = string.IsNullOrEmpty(data.maxn_1) ? string.Empty : data.maxn_1;
            data.maxn_2 = string.IsNullOrEmpty(data.maxn_2) ? string.Empty : data.maxn_2;
            data.maxn_3 = string.IsNullOrEmpty(data.maxn_3) ? string.Empty : data.maxn_3;
            data.maxn_4 = string.IsNullOrEmpty(data.maxn_4) ? string.Empty : data.maxn_4;
            data.maxn_5 = string.IsNullOrEmpty(data.maxn_5) ? string.Empty : data.maxn_5;
            data.maxn_6 = string.IsNullOrEmpty(data.maxn_6) ? string.Empty : data.maxn_6;
            data.maxn_7 = string.IsNullOrEmpty(data.maxn_7) ? string.Empty : data.maxn_7;
            data.maxn_8 = string.IsNullOrEmpty(data.maxn_8) ? string.Empty : data.maxn_8;
            data.maxn_9 = string.IsNullOrEmpty(data.maxn_9) ? string.Empty : data.maxn_9;
            data.maxn_10 = string.IsNullOrEmpty(data.maxn_10) ? string.Empty : data.maxn_10;
            data.maxn_11 = string.IsNullOrEmpty(data.maxn_11) ? string.Empty : data.maxn_11;
            data.maxn_12 = string.IsNullOrEmpty(data.maxn_12) ? string.Empty : data.maxn_12;
            data.maxn_13 = string.IsNullOrEmpty(data.maxn_13) ? string.Empty : data.maxn_13;
            data.maxn_14 = string.IsNullOrEmpty(data.maxn_14) ? string.Empty : data.maxn_14;
            data.maxn_15 = string.IsNullOrEmpty(data.maxn_15) ? string.Empty : data.maxn_15;
            data.maxn_16 = string.IsNullOrEmpty(data.maxn_16) ? string.Empty : data.maxn_16;
            data.maxn_17 = string.IsNullOrEmpty(data.maxn_17) ? string.Empty : data.maxn_17;
            data.maxn_18 = string.IsNullOrEmpty(data.maxn_18) ? string.Empty : data.maxn_18;
            data.maxn_19 = string.IsNullOrEmpty(data.maxn_19) ? string.Empty : data.maxn_19;
            data.maxn_20 = string.IsNullOrEmpty(data.maxn_20) ? string.Empty : data.maxn_20;
            data.maxn_21 = string.IsNullOrEmpty(data.maxn_21) ? string.Empty : data.maxn_21;
            data.maxn_22 = string.IsNullOrEmpty(data.maxn_22) ? string.Empty : data.maxn_22;
            data.maxn_23 = string.IsNullOrEmpty(data.maxn_23) ? string.Empty : data.maxn_23;
            data.maxn_24 = string.IsNullOrEmpty(data.maxn_24) ? string.Empty : data.maxn_24;
            data.maxn_25 = string.IsNullOrEmpty(data.maxn_25) ? string.Empty : data.maxn_25;
            data.maxn_26 = string.IsNullOrEmpty(data.maxn_26) ? string.Empty : data.maxn_26;
            data.maxn_27 = string.IsNullOrEmpty(data.maxn_27) ? string.Empty : data.maxn_27;
            data.maxn_28 = string.IsNullOrEmpty(data.maxn_28) ? string.Empty : data.maxn_28;
            data.maxn_29 = string.IsNullOrEmpty(data.maxn_29) ? string.Empty : data.maxn_29;
            data.maxn_30 = string.IsNullOrEmpty(data.maxn_30) ? string.Empty : data.maxn_30;
            data.maxn_31 = string.IsNullOrEmpty(data.maxn_31) ? string.Empty : data.maxn_31;
            data.maxn_32 = string.IsNullOrEmpty(data.maxn_32) ? string.Empty : data.maxn_32;
            data.maxn_33 = string.IsNullOrEmpty(data.maxn_33) ? string.Empty : data.maxn_33;
            data.maxn_34 = string.IsNullOrEmpty(data.maxn_34) ? string.Empty : data.maxn_34;
            data.maxn_35 = string.IsNullOrEmpty(data.maxn_35) ? string.Empty : data.maxn_35;
            data.maxn_36 = string.IsNullOrEmpty(data.maxn_36) ? string.Empty : data.maxn_36;
            data.maxn_37 = string.IsNullOrEmpty(data.maxn_37) ? string.Empty : data.maxn_37;
            data.maxn_38 = string.IsNullOrEmpty(data.maxn_38) ? string.Empty : data.maxn_38;
            data.maxn_39 = string.IsNullOrEmpty(data.maxn_39) ? string.Empty : data.maxn_39;
            data.maxn_40 = string.IsNullOrEmpty(data.maxn_40) ? string.Empty : data.maxn_40;
            data.maxn_41 = string.IsNullOrEmpty(data.maxn_41) ? string.Empty : data.maxn_41;
            DateTime? card1 = data.maxn_date1; // Assuming data.maxn_date1 is of type DateTime?            
            DateTime? card2 = data.maxn_date2; // Assuming data.maxn_date2 is of type DateTime?
            DateTime? card3 = data.maxn_date3; // Assuming data.maxn_date3 is of type DateTime?
            if (data.maxn_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.maxn_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.maxn_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.maxn_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.maxn_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.maxn_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.maxn_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.maxn_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.maxn_date3 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.Maxcare.InsertUpdateMaxcare(data);
        }
        public static int DeleteMaxcare(int maxnId, int maxn_madeby)
        {
            return DataAccessLayer.EMRForms.Maxcare.DeleteMaxcare(maxnId, maxn_madeby);
        }
        #endregion
    }
    public class Cowan
    {
        #region Cowan (Page Load)
        public static List<BusinessEntities.EMRForms.Cowan> GetAllCowan(int appId)
        {
            List<BusinessEntities.EMRForms.Cowan> sclist = new List<BusinessEntities.EMRForms.Cowan>();
            DataTable dt = DataAccessLayer.EMRForms.Cowan.GetAllCowan(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Cowan
                {
                    cownId = Convert.ToInt32(dr["cownId"]),
                    cown_appId = Convert.ToInt32(dr["cown_appId"]),
                    cown_chk = dr["cown_chk"].ToString(),
                    cown_1 = dr["cown_1"].ToString(),
                    cown_2 = dr["cown_2"].ToString(),
                    cown_3 = dr["cown_3"].ToString(),
                    cown_4 = dr["cown_4"].ToString(),
                    cown_5 = dr["cown_5"].ToString(),
                    cown_6 = dr["cown_6"].ToString(),
                    cown_7 = dr["cown_7"].ToString(),
                    cown_8 = dr["cown_8"].ToString(),
                    cown_9 = dr["cown_9"].ToString(),
                    cown_10 = dr["cown_10"].ToString(),
                    cown_11 = dr["cown_11"].ToString(),
                    cown_12 = dr["cown_12"].ToString(),
                    cown_13 = dr["cown_13"].ToString(),
                    cown_14 = dr["cown_14"].ToString(),
                    cown_15 = dr["cown_15"].ToString(),
                    cown_16 = dr["cown_16"].ToString(),
                    cown_17 = dr["cown_17"].ToString(),
                    cown_18 = dr["cown_18"].ToString(),
                    cown_19 = dr["cown_19"].ToString(),
                    cown_20 = dr["cown_20"].ToString(),
                    cown_21 = dr["cown_21"].ToString(),
                    cown_22 = dr["cown_22"].ToString(),
                    cown_23 = dr["cown_23"].ToString(),
                    cown_24 = dr["cown_24"].ToString(),
                    cown_25 = dr["cown_25"].ToString(),
                    cown_26 = dr["cown_26"].ToString(),
                    cown_27 = dr["cown_27"].ToString(),
                    cown_28 = dr["cown_28"].ToString(),
                    cown_29 = dr["cown_29"].ToString(),
                    cown_30 = dr["cown_30"].ToString(),
                    cown_31 = dr["cown_31"].ToString(),
                    cown_32 = dr["cown_32"].ToString(),
                    cown_33 = dr["cown_33"].ToString(),
                    cown_34 = dr["cown_34"].ToString(),
                    cown_35 = dr["cown_35"].ToString(),
                    cown_36 = dr["cown_36"].ToString(),
                    cown_37 = dr["cown_37"].ToString(),
                    cown_38 = dr["cown_38"].ToString(),
                    cown_39 = dr["cown_39"].ToString(),
                    cown_40 = dr["cown_40"].ToString(),
                    cown_41 = dr["cown_41"].ToString(),
                    cown_42 = dr["cown_42"].ToString(),
                    cown_43 = dr["cown_43"].ToString(),
                    cown_44 = dr["cown_44"].ToString(),
                    cown_45 = dr["cown_45"].ToString(),
                    cown_46 = dr["cown_46"].ToString(),
                    cown_47 = dr["cown_47"].ToString(),
                    cown_48 = dr["cown_48"].ToString(),
                    cown_49 = dr["cown_49"].ToString(),
                    cown_50 = dr["cown_50"].ToString(),
                    cown_51 = dr["cown_51"].ToString(),
                    cown_52 = dr["cown_52"].ToString(),
                    cown_53 = dr["cown_53"].ToString(),
                    cown_54 = dr["cown_54"].ToString(),
                    cown_55 = dr["cown_55"].ToString(),
                    cown_56 = dr["cown_56"].ToString(),
                    cown_57 = dr["cown_57"].ToString(),
                    cown_58 = dr["cown_58"].ToString(),
                    cown_59 = dr["cown_59"].ToString(),
                    cown_60 = dr["cown_60"].ToString(),
                    cown_61 = dr["cown_61"].ToString(),
                    cown_62 = dr["cown_62"].ToString(),
                    cown_63 = dr["cown_63"].ToString(),
                    cown_64 = dr["cown_64"].ToString(),
                    cown_65 = dr["cown_65"].ToString(),
                    cown_66 = dr["cown_66"].ToString(),
                    cown_67 = dr["cown_67"].ToString(),
                    cown_68 = dr["cown_68"].ToString(),
                    cown_69 = dr["cown_69"].ToString(),
                    cown_70 = dr["cown_70"].ToString(),
                    cown_71 = dr["cown_71"].ToString(),
                    cown_date1 = Convert.ToDateTime(dr["cown_date1"].ToString()),
                    cown_date2 = Convert.ToDateTime(dr["cown_date2"].ToString()),
                    cown_date3 = Convert.ToDateTime(dr["cown_date3"].ToString()),
                    cown_date4 = Convert.ToDateTime(dr["cown_date4"].ToString()),
                    cown_date5 = Convert.ToDateTime(dr["cown_date5"].ToString()),
                    cown_date6 = Convert.ToDateTime(dr["cown_date6"].ToString()),
                    cown_date7 = Convert.ToDateTime(dr["cown_date7"].ToString()),
                    cown_date8 = Convert.ToDateTime(dr["cown_date8"].ToString()),
                    cown_date9 = Convert.ToDateTime(dr["cown_date9"].ToString()),
                    cown_date10 = Convert.ToDateTime(dr["cown_date10"].ToString()),
                    cown_date11 = Convert.ToDateTime(dr["cown_date11"].ToString()),
                    cown_date12 = Convert.ToDateTime(dr["cown_date12"].ToString()),
                    cown_date_created = Convert.ToDateTime(dr["cown_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Cowan> GetAllPreCowan(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Cowan> sclist = new List<BusinessEntities.EMRForms.Cowan>();
            DataTable dt = DataAccessLayer.EMRForms.Cowan.GetAllPreCowan(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Cowan
                {
                    cownId = Convert.ToInt32(dr["cownId"]),
                    cown_appId = Convert.ToInt32(dr["cown_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        
        //print
        public static List<BusinessEntities.EMRForms.Cowan> GetPrintCowan(int? cownId)
        {
            List<BusinessEntities.EMRForms.Cowan> sclist = new List<BusinessEntities.EMRForms.Cowan>();
            DataTable dt = DataAccessLayer.EMRForms.Cowan.GetPrintCowan(cownId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Cowan
                    {
                        cownId = Convert.ToInt32(dr["cownId"]),
                        cown_appId = Convert.ToInt32(dr["cown_appId"]),
                        cown_chk = dr["cown_chk"].ToString(),
                        cown_1 = dr["cown_1"].ToString(),
                        cown_2 = dr["cown_2"].ToString(),
                        cown_3 = dr["cown_3"].ToString(),
                        cown_4 = dr["cown_4"].ToString(),
                        cown_5 = dr["cown_5"].ToString(),
                        cown_6 = dr["cown_6"].ToString(),
                        cown_7 = dr["cown_7"].ToString(),
                        cown_8 = dr["cown_8"].ToString(),
                        cown_9 = dr["cown_9"].ToString(),
                        cown_10 = dr["cown_10"].ToString(),
                        cown_11 = dr["cown_11"].ToString(),
                        cown_12 = dr["cown_12"].ToString(),
                        cown_13 = dr["cown_13"].ToString(),
                        cown_14 = dr["cown_14"].ToString(),
                        cown_15 = dr["cown_15"].ToString(),
                        cown_16 = dr["cown_16"].ToString(),
                        cown_17 = dr["cown_17"].ToString(),
                        cown_18 = dr["cown_18"].ToString(),
                        cown_19 = dr["cown_19"].ToString(),
                        cown_20 = dr["cown_20"].ToString(),
                        cown_21 = dr["cown_21"].ToString(),
                        cown_22 = dr["cown_22"].ToString(),
                        cown_23 = dr["cown_23"].ToString(),
                        cown_24 = dr["cown_24"].ToString(),
                        cown_25 = dr["cown_25"].ToString(),
                        cown_26 = dr["cown_26"].ToString(),
                        cown_27 = dr["cown_27"].ToString(),
                        cown_28 = dr["cown_28"].ToString(),
                        cown_29 = dr["cown_29"].ToString(),
                        cown_30 = dr["cown_30"].ToString(),
                        cown_31 = dr["cown_31"].ToString(),
                        cown_32 = dr["cown_32"].ToString(),
                        cown_33 = dr["cown_33"].ToString(),
                        cown_34 = dr["cown_34"].ToString(),
                        cown_35 = dr["cown_35"].ToString(),
                        cown_36 = dr["cown_36"].ToString(),
                        cown_37 = dr["cown_37"].ToString(),
                        cown_38 = dr["cown_38"].ToString(),
                        cown_39 = dr["cown_39"].ToString(),
                        cown_40 = dr["cown_40"].ToString(),
                        cown_41 = dr["cown_41"].ToString(),
                        cown_42 = dr["cown_42"].ToString(),
                        cown_43 = dr["cown_43"].ToString(),
                        cown_44 = dr["cown_44"].ToString(),
                        cown_45 = dr["cown_45"].ToString(),
                        cown_46 = dr["cown_46"].ToString(),
                        cown_47 = dr["cown_47"].ToString(),
                        cown_48 = dr["cown_48"].ToString(),
                        cown_49 = dr["cown_49"].ToString(),
                        cown_50 = dr["cown_50"].ToString(),
                        cown_51 = dr["cown_51"].ToString(),
                        cown_52 = dr["cown_52"].ToString(),
                        cown_53 = dr["cown_53"].ToString(),
                        cown_54 = dr["cown_54"].ToString(),
                        cown_55 = dr["cown_55"].ToString(),
                        cown_56 = dr["cown_56"].ToString(),
                        cown_57 = dr["cown_57"].ToString(),
                        cown_58 = dr["cown_58"].ToString(),
                        cown_59 = dr["cown_59"].ToString(),
                        cown_60 = dr["cown_60"].ToString(),
                        cown_61 = dr["cown_61"].ToString(),
                        cown_62 = dr["cown_62"].ToString(),
                        cown_63 = dr["cown_63"].ToString(),
                        cown_64 = dr["cown_64"].ToString(),
                        cown_65 = dr["cown_65"].ToString(),
                        cown_66 = dr["cown_66"].ToString(),
                        cown_67 = dr["cown_67"].ToString(),
                        cown_68 = dr["cown_68"].ToString(),
                        cown_69 = dr["cown_69"].ToString(),
                        cown_70 = dr["cown_70"].ToString(),
                        cown_71 = dr["cown_71"].ToString(),
                        cown_dd1 = dr["cown_date1"].ToString(),
                        cown_dd2 = dr["cown_date2"].ToString(),
                        cown_dd3 = dr["cown_date3"].ToString(),
                        cown_dd4 = dr["cown_date4"].ToString(),
                        cown_dd5 = dr["cown_date5"].ToString(),
                        cown_dd6 = dr["cown_date6"].ToString(),
                        cown_dd7 = dr["cown_date7"].ToString(),
                        cown_dd8 = dr["cown_date8"].ToString(),
                        cown_dd9 = dr["cown_date9"].ToString(),
                        cown_dd10 = dr["cown_date10"].ToString(),
                        cown_dd11 = dr["cown_date11"].ToString(),
                        cown_dd12 = dr["cown_date12"].ToString(),
                        cown_date_created = Convert.ToDateTime(dr["cown_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Cowan a = new BusinessEntities.EMRForms.Cowan();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion Cowan (Page Load)

        #region Cowan (CRUD Operations)
        //insert&update
        public static bool InsertUpdateCowan(BusinessEntities.EMRForms.Cowan data)
        {
            data.cown_chk = string.IsNullOrEmpty(data.cown_chk) ? string.Empty : data.cown_chk;
            data.cown_1 = string.IsNullOrEmpty(data.cown_1) ? string.Empty : data.cown_1;
            data.cown_2 = string.IsNullOrEmpty(data.cown_2) ? string.Empty : data.cown_2;
            data.cown_3 = string.IsNullOrEmpty(data.cown_3) ? string.Empty : data.cown_3;
            data.cown_4 = string.IsNullOrEmpty(data.cown_4) ? string.Empty : data.cown_4;
            data.cown_5 = string.IsNullOrEmpty(data.cown_5) ? string.Empty : data.cown_5;
            data.cown_6 = string.IsNullOrEmpty(data.cown_6) ? string.Empty : data.cown_6;
            data.cown_7 = string.IsNullOrEmpty(data.cown_7) ? string.Empty : data.cown_7;
            data.cown_8 = string.IsNullOrEmpty(data.cown_8) ? string.Empty : data.cown_8;
            data.cown_9 = string.IsNullOrEmpty(data.cown_9) ? string.Empty : data.cown_9;
            data.cown_10 = string.IsNullOrEmpty(data.cown_10) ? string.Empty : data.cown_10;
            data.cown_11 = string.IsNullOrEmpty(data.cown_11) ? string.Empty : data.cown_11;
            data.cown_12 = string.IsNullOrEmpty(data.cown_12) ? string.Empty : data.cown_12;
            data.cown_13 = string.IsNullOrEmpty(data.cown_13) ? string.Empty : data.cown_13;
            data.cown_14 = string.IsNullOrEmpty(data.cown_14) ? string.Empty : data.cown_14;
            data.cown_15 = string.IsNullOrEmpty(data.cown_15) ? string.Empty : data.cown_15;
            data.cown_16 = string.IsNullOrEmpty(data.cown_16) ? string.Empty : data.cown_16;
            data.cown_17 = string.IsNullOrEmpty(data.cown_17) ? string.Empty : data.cown_17;
            data.cown_18 = string.IsNullOrEmpty(data.cown_18) ? string.Empty : data.cown_18;
            data.cown_19 = string.IsNullOrEmpty(data.cown_19) ? string.Empty : data.cown_19;
            data.cown_20 = string.IsNullOrEmpty(data.cown_20) ? string.Empty : data.cown_20;
            data.cown_21 = string.IsNullOrEmpty(data.cown_21) ? string.Empty : data.cown_21;
            data.cown_22 = string.IsNullOrEmpty(data.cown_22) ? string.Empty : data.cown_22;
            data.cown_23 = string.IsNullOrEmpty(data.cown_23) ? string.Empty : data.cown_23;
            data.cown_24 = string.IsNullOrEmpty(data.cown_24) ? string.Empty : data.cown_24;
            data.cown_25 = string.IsNullOrEmpty(data.cown_25) ? string.Empty : data.cown_25;
            data.cown_26 = string.IsNullOrEmpty(data.cown_26) ? string.Empty : data.cown_26;
            data.cown_27 = string.IsNullOrEmpty(data.cown_27) ? string.Empty : data.cown_27;
            data.cown_28 = string.IsNullOrEmpty(data.cown_28) ? string.Empty : data.cown_28;
            data.cown_29 = string.IsNullOrEmpty(data.cown_29) ? string.Empty : data.cown_29;
            data.cown_30 = string.IsNullOrEmpty(data.cown_30) ? string.Empty : data.cown_30;
            data.cown_31 = string.IsNullOrEmpty(data.cown_31) ? string.Empty : data.cown_31;
            data.cown_32 = string.IsNullOrEmpty(data.cown_32) ? string.Empty : data.cown_32;
            data.cown_33 = string.IsNullOrEmpty(data.cown_33) ? string.Empty : data.cown_33;
            data.cown_34 = string.IsNullOrEmpty(data.cown_34) ? string.Empty : data.cown_34;
            data.cown_35 = string.IsNullOrEmpty(data.cown_35) ? string.Empty : data.cown_35;
            data.cown_36 = string.IsNullOrEmpty(data.cown_36) ? string.Empty : data.cown_36;
            data.cown_37 = string.IsNullOrEmpty(data.cown_37) ? string.Empty : data.cown_37;
            data.cown_38 = string.IsNullOrEmpty(data.cown_38) ? string.Empty : data.cown_38;
            data.cown_39 = string.IsNullOrEmpty(data.cown_39) ? string.Empty : data.cown_39;
            data.cown_40 = string.IsNullOrEmpty(data.cown_40) ? string.Empty : data.cown_40;
            data.cown_41 = string.IsNullOrEmpty(data.cown_41) ? string.Empty : data.cown_41;
            data.cown_42 = string.IsNullOrEmpty(data.cown_42) ? string.Empty : data.cown_42;
            data.cown_43 = string.IsNullOrEmpty(data.cown_43) ? string.Empty : data.cown_43;
            data.cown_44 = string.IsNullOrEmpty(data.cown_44) ? string.Empty : data.cown_44;
            data.cown_45 = string.IsNullOrEmpty(data.cown_45) ? string.Empty : data.cown_45;
            data.cown_46 = string.IsNullOrEmpty(data.cown_46) ? string.Empty : data.cown_46;
            data.cown_47 = string.IsNullOrEmpty(data.cown_47) ? string.Empty : data.cown_47;
            data.cown_48 = string.IsNullOrEmpty(data.cown_48) ? string.Empty : data.cown_48;
            data.cown_49 = string.IsNullOrEmpty(data.cown_49) ? string.Empty : data.cown_49;
            data.cown_50 = string.IsNullOrEmpty(data.cown_50) ? string.Empty : data.cown_50;
            data.cown_51 = string.IsNullOrEmpty(data.cown_51) ? string.Empty : data.cown_51;
            data.cown_52 = string.IsNullOrEmpty(data.cown_52) ? string.Empty : data.cown_52;
            data.cown_53 = string.IsNullOrEmpty(data.cown_53) ? string.Empty : data.cown_53;
            data.cown_54 = string.IsNullOrEmpty(data.cown_54) ? string.Empty : data.cown_54;
            data.cown_55 = string.IsNullOrEmpty(data.cown_55) ? string.Empty : data.cown_55;
            data.cown_56 = string.IsNullOrEmpty(data.cown_56) ? string.Empty : data.cown_56;
            data.cown_57 = string.IsNullOrEmpty(data.cown_57) ? string.Empty : data.cown_57;
            data.cown_58 = string.IsNullOrEmpty(data.cown_58) ? string.Empty : data.cown_58;
            data.cown_59 = string.IsNullOrEmpty(data.cown_59) ? string.Empty : data.cown_59;
            data.cown_60 = string.IsNullOrEmpty(data.cown_60) ? string.Empty : data.cown_60;
            data.cown_61 = string.IsNullOrEmpty(data.cown_61) ? string.Empty : data.cown_61;
            data.cown_62 = string.IsNullOrEmpty(data.cown_62) ? string.Empty : data.cown_62;
            data.cown_63 = string.IsNullOrEmpty(data.cown_63) ? string.Empty : data.cown_63;
            data.cown_64 = string.IsNullOrEmpty(data.cown_64) ? string.Empty : data.cown_64;
            data.cown_65 = string.IsNullOrEmpty(data.cown_65) ? string.Empty : data.cown_65;
            data.cown_66 = string.IsNullOrEmpty(data.cown_66) ? string.Empty : data.cown_66;
            data.cown_67 = string.IsNullOrEmpty(data.cown_67) ? string.Empty : data.cown_67;
            data.cown_68 = string.IsNullOrEmpty(data.cown_68) ? string.Empty : data.cown_68;
            data.cown_69 = string.IsNullOrEmpty(data.cown_69) ? string.Empty : data.cown_69;
            data.cown_70 = string.IsNullOrEmpty(data.cown_70) ? string.Empty : data.cown_70;
            data.cown_71 = string.IsNullOrEmpty(data.cown_71) ? string.Empty : data.cown_71;
            DateTime? card1 = data.cown_date1; // Assuming data.cown_date1 is of type DateTime?            
            DateTime? card2 = data.cown_date2; // Assuming data.cown_date2 is of type DateTime?
            DateTime? card3 = data.cown_date3; // Assuming data.cown_date3 is of type DateTime?
            DateTime? card4 = data.cown_date4; // Assuming data.cown_date4 is of type DateTime?
            DateTime? card5 = data.cown_date5; // Assuming data.cown_date5 is of type DateTime?
            DateTime? card6 = data.cown_date6; // Assuming data.cown_date6 is of type DateTime?
            DateTime? card7 = data.cown_date7; // Assuming data.cown_date7 is of type DateTime?
            DateTime? card8 = data.cown_date8; // Assuming data.cown_date8 is of type DateTime?
            DateTime? card9 = data.cown_date9; // Assuming data.cown_date9 is of type DateTime?
            DateTime? card10 = data.cown_date10; // Assuming data.cown_date10 is of type DateTime?
            DateTime? card11 = data.cown_date11; // Assuming data.cown_date11 is of type DateTime?
            DateTime? card12 = data.cown_date12; // Assuming data.cown_date12 is of type DateTime?
            if (data.cown_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date3 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date4 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date4 = card4.HasValue ? card4.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date4 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date5 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date5 = card5.HasValue ? card5.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date5 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date6 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date6 = card6.HasValue ? card6.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date6 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date7 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date7 = card7.HasValue ? card7.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date7 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date8 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date8 = card8.HasValue ? card8.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date8 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date9 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date9 = card9.HasValue ? card9.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date9 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date10 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date10 = card10.HasValue ? card10.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date10 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date11 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date11 = card11.HasValue ? card11.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date11 = DateTime.Parse("01/01/1950");
            }
            if (data.cown_date12 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cown_date12 = card12.HasValue ? card12.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cown_date12 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.Cowan.InsertUpdateCowan(data);
        }
        //Delete
        public static int DeleteCowan(int cownId, int cown_madeby)
        {
            return DataAccessLayer.EMRForms.Cowan.DeleteCowan(cownId, cown_madeby);
        }
        #endregion Cowan (CRUD Operations)
    }
    public class NASNLGIC
    {
        #region NASNLGIC (Page Load)
        public static List<BusinessEntities.EMRForms.NASNLGIC> GetAllNASNLGIC(int appId)
        {
            List<BusinessEntities.EMRForms.NASNLGIC> sclist = new List<BusinessEntities.EMRForms.NASNLGIC>();
            DataTable dt = DataAccessLayer.EMRForms.NASNLGIC.GetAllNASNLGIC(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NASNLGIC
                {
                    nalnId = Convert.ToInt32(dr["nalnId"]),
                    naln_appId = Convert.ToInt32(dr["naln_appId"]),
                    naln_1 = dr["naln_1"].ToString(),
                    naln_2 = dr["naln_2"].ToString(),
                    naln_3 = dr["naln_3"].ToString(),
                    naln_4 = dr["naln_4"].ToString(),
                    naln_5 = dr["naln_5"].ToString(),
                    naln_6 = dr["naln_6"].ToString(),
                    naln_7 = dr["naln_7"].ToString(),
                    naln_8 = dr["naln_8"].ToString(),
                    naln_9 = dr["naln_9"].ToString(),
                    naln_10 = dr["naln_10"].ToString(),
                    naln_11 = dr["naln_11"].ToString(),
                    naln_12 = dr["naln_12"].ToString(),
                    naln_13 = dr["naln_13"].ToString(),
                    naln_14 = dr["naln_14"].ToString(),
                    naln_15 = dr["naln_15"].ToString(),
                    naln_16 = dr["naln_16"].ToString(),
                    naln_17 = dr["naln_17"].ToString(),
                    naln_18 = dr["naln_18"].ToString(),
                    naln_date1 = Convert.ToDateTime(dr["naln_date1"].ToString()),
                    naln_date_created = Convert.ToDateTime(dr["naln_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.NASNLGIC> GetAllPreNASNLGIC(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.NASNLGIC> sclist = new List<BusinessEntities.EMRForms.NASNLGIC>();
            DataTable dt = DataAccessLayer.EMRForms.NASNLGIC.GetAllPreNASNLGIC(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.NASNLGIC
                {
                    nalnId = Convert.ToInt32(dr["nalnId"]),
                    naln_appId = Convert.ToInt32(dr["naln_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.NASNLGIC> GetPrintNASNLGIC(int? nalnId)
        {
            List<BusinessEntities.EMRForms.NASNLGIC> sclist = new List<BusinessEntities.EMRForms.NASNLGIC>();
            DataTable dt = DataAccessLayer.EMRForms.NASNLGIC.GetPrintNASNLGIC(nalnId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.NASNLGIC
                    {
                        nalnId = Convert.ToInt32(dr["nalnId"]),
                        naln_appId = Convert.ToInt32(dr["naln_appId"]),
                        naln_1 = dr["naln_1"].ToString(),
                        naln_2 = dr["naln_2"].ToString(),
                        naln_3 = dr["naln_3"].ToString(),
                        naln_4 = dr["naln_4"].ToString(),
                        naln_5 = dr["naln_5"].ToString(),
                        naln_6 = dr["naln_6"].ToString(),
                        naln_7 = dr["naln_7"].ToString(),
                        naln_8 = dr["naln_8"].ToString(),
                        naln_9 = dr["naln_9"].ToString(),
                        naln_10 = dr["naln_10"].ToString(),
                        naln_11 = dr["naln_11"].ToString(),
                        naln_12 = dr["naln_12"].ToString(),
                        naln_13 = dr["naln_13"].ToString(),
                        naln_14 = dr["naln_14"].ToString(),
                        naln_15 = dr["naln_15"].ToString(),
                        naln_16 = dr["naln_16"].ToString(),
                        naln_17 = dr["naln_17"].ToString(),
                        naln_18 = dr["naln_18"].ToString(),

                        naln_d1 = (dt.Rows[0]["naln_date1"].ToString() == "1-January-1950") ? "" : dt.Rows[0]["naln_date1"].ToString(),
                        naln_date_created = Convert.ToDateTime(dr["naln_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.NASNLGIC a = new BusinessEntities.EMRForms.NASNLGIC();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion NASNLGIC (Page Load)

        #region NASNLGIC (CRUD Operations)
        //insert&update
        public static bool InsertUpdateNASNLGIC(BusinessEntities.EMRForms.NASNLGIC data)
        {
            data.naln_1 = string.IsNullOrEmpty(data.naln_1) ? string.Empty : data.naln_1;
            data.naln_2 = string.IsNullOrEmpty(data.naln_2) ? string.Empty : data.naln_2;
            data.naln_3 = string.IsNullOrEmpty(data.naln_3) ? string.Empty : data.naln_3;
            data.naln_4 = string.IsNullOrEmpty(data.naln_4) ? string.Empty : data.naln_4;
            data.naln_5 = string.IsNullOrEmpty(data.naln_5) ? string.Empty : data.naln_5;
            data.naln_6 = string.IsNullOrEmpty(data.naln_6) ? string.Empty : data.naln_6;
            data.naln_7 = string.IsNullOrEmpty(data.naln_7) ? string.Empty : data.naln_7;
            data.naln_8 = string.IsNullOrEmpty(data.naln_8) ? string.Empty : data.naln_8;
            data.naln_9 = string.IsNullOrEmpty(data.naln_9) ? string.Empty : data.naln_9;
            data.naln_10 = string.IsNullOrEmpty(data.naln_10) ? string.Empty : data.naln_10;
            data.naln_11 = string.IsNullOrEmpty(data.naln_11) ? string.Empty : data.naln_11;
            data.naln_12 = string.IsNullOrEmpty(data.naln_12) ? string.Empty : data.naln_12;
            data.naln_13 = string.IsNullOrEmpty(data.naln_13) ? string.Empty : data.naln_13;
            data.naln_14 = string.IsNullOrEmpty(data.naln_14) ? string.Empty : data.naln_14;
            data.naln_15 = string.IsNullOrEmpty(data.naln_15) ? string.Empty : data.naln_15;
            data.naln_16 = string.IsNullOrEmpty(data.naln_16) ? string.Empty : data.naln_16;
            data.naln_17 = string.IsNullOrEmpty(data.naln_17) ? string.Empty : data.naln_17;
            data.naln_18 = string.IsNullOrEmpty(data.naln_18) ? string.Empty : data.naln_18;
            DateTime? card21 = data.naln_date1; // Assuming data.naln_d1 is of type DateTime? 
            if (data.naln_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.naln_date1 = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.naln_date1 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.NASNLGIC.InsertUpdateNASNLGIC(data);
        }
        //Delete
        public static int DeleteNASNLGIC(int nalnId, int naln_madeby)
        {
            return DataAccessLayer.EMRForms.NASNLGIC.DeleteNASNLGIC(nalnId, naln_madeby);
        }
        #endregion NASNLGIC (CRUD Operations)
    }

    public class EmiratesInsurance
    {
        #region EmiratesInsurance (Page Load)
        public static List<BusinessEntities.EMRForms.EmiratesInsurance> GetAllEmiratesInsurance(int appId)
        {
            List<BusinessEntities.EMRForms.EmiratesInsurance> sclist = new List<BusinessEntities.EMRForms.EmiratesInsurance>();
            DataTable dt = DataAccessLayer.EMRForms.EmiratesInsurance.GetAllEmiratesInsurance(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.EmiratesInsurance
                {
                    cceId = Convert.ToInt32(dr["cceId"]),
                    cce_appId = Convert.ToInt32(dr["cce_appId"]),
                    cce_chk = dr["cce_chk"].ToString(),
                    cce_1 = dr["cce_1"].ToString(),
                    cce_2 = dr["cce_2"].ToString(),
                    cce_3 = dr["cce_3"].ToString(),
                    cce_4 = dr["cce_4"].ToString(),
                    cce_5 = dr["cce_5"].ToString(),
                    cce_6 = dr["cce_6"].ToString(),
                    cce_7 = dr["cce_7"].ToString(),
                    cce_8 = dr["cce_8"].ToString(),
                    cce_9 = dr["cce_9"].ToString(),
                    cce_10 = dr["cce_10"].ToString(),
                    cce_11 = dr["cce_11"].ToString(),
                    cce_12 = dr["cce_12"].ToString(),
                    cce_13 = dr["cce_13"].ToString(),
                    cce_14 = dr["cce_14"].ToString(),
                    cce_15 = dr["cce_15"].ToString(),
                    cce_16 = dr["cce_16"].ToString(),
                    cce_17 = dr["cce_17"].ToString(),
                    cce_18 = dr["cce_18"].ToString(),
                    cce_19 = dr["cce_19"].ToString(),
                    cce_20 = dr["cce_20"].ToString(),
                    cce_21 = dr["cce_21"].ToString(),
                    cce_date1 = Convert.ToDateTime(dr["cce_date1"].ToString()),
                    cce_date2 = Convert.ToDateTime(dr["cce_date2"].ToString()),
                    cce_date3 = Convert.ToDateTime(dr["cce_date3"].ToString()),
                    cce_date4 = Convert.ToDateTime(dr["cce_date4"].ToString()),
                    cce_date5 = Convert.ToDateTime(dr["cce_date5"].ToString()),
                    cce_date6 = Convert.ToDateTime(dr["cce_date6"].ToString()),
                    cce_date7 = Convert.ToDateTime(dr["cce_date7"].ToString()),
                    cce_date_created = Convert.ToDateTime(dr["cce_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.EmiratesInsurance> GetAllPreEmiratesInsurance(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.EmiratesInsurance> sclist = new List<BusinessEntities.EMRForms.EmiratesInsurance>();
            DataTable dt = DataAccessLayer.EMRForms.EmiratesInsurance.GetAllPreEmiratesInsurance(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.EmiratesInsurance
                {
                    cceId = Convert.ToInt32(dr["cceId"]),
                    cce_appId = Convert.ToInt32(dr["cce_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.EmiratesInsurance> GetPrintEmiratesInsurance(int? cceId)
        {
            List<BusinessEntities.EMRForms.EmiratesInsurance> sclist = new List<BusinessEntities.EMRForms.EmiratesInsurance>();
            DataTable dt = DataAccessLayer.EMRForms.EmiratesInsurance.GetPrintEmiratesInsurance(cceId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.EmiratesInsurance
                    {
                        cceId = Convert.ToInt32(dr["cceId"]),
                        cce_appId = Convert.ToInt32(dr["cce_appId"]),
                        cce_chk = dr["cce_chk"].ToString(),
                        cce_1 = dr["cce_1"].ToString(),
                        cce_2 = dr["cce_2"].ToString(),
                        cce_3 = dr["cce_3"].ToString(),
                        cce_4 = dr["cce_4"].ToString(),
                        cce_5 = dr["cce_5"].ToString(),
                        cce_6 = dr["cce_6"].ToString(),
                        cce_7 = dr["cce_7"].ToString(),
                        cce_8 = dr["cce_8"].ToString(),
                        cce_9 = dr["cce_9"].ToString(),
                        cce_10 = dr["cce_10"].ToString(),
                        cce_11 = dr["cce_11"].ToString(),
                        cce_12 = dr["cce_12"].ToString(),
                        cce_13 = dr["cce_13"].ToString(),
                        cce_14 = dr["cce_14"].ToString(),
                        cce_15 = dr["cce_15"].ToString(),
                        cce_16 = dr["cce_16"].ToString(),
                        cce_17 = dr["cce_17"].ToString(),
                        cce_18 = dr["cce_18"].ToString(),
                        cce_19 = dr["cce_19"].ToString(),
                        cce_20 = dr["cce_20"].ToString(),
                        cce_21 = dr["cce_21"].ToString(),
                        cce_dd1 = dr["cce_date1"].ToString(),
                        cce_dd2 = dr["cce_date2"].ToString(),
                        cce_dd3 = dr["cce_date3"].ToString(),
                        cce_dd4 = dr["cce_date4"].ToString(),
                        cce_dd5 = dr["cce_date5"].ToString(),
                        cce_dd6 = dr["cce_date6"].ToString(),
                        cce_dd7 = dr["cce_date7"].ToString(),
                        cce_date_created = Convert.ToDateTime(dr["cce_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.EmiratesInsurance a = new BusinessEntities.EMRForms.EmiratesInsurance();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region EmiratesInsurance (CRUD Operations)
        //insert&update
        public static bool InsertUpdateEmiratesInsurance(BusinessEntities.EMRForms.EmiratesInsurance data)
        {
            data.cce_chk = string.IsNullOrEmpty(data.cce_chk) ? string.Empty : data.cce_chk;
            data.cce_1 = string.IsNullOrEmpty(data.cce_1) ? string.Empty : data.cce_1;
            data.cce_2 = string.IsNullOrEmpty(data.cce_2) ? string.Empty : data.cce_2;
            data.cce_3 = string.IsNullOrEmpty(data.cce_3) ? string.Empty : data.cce_3;
            data.cce_4 = string.IsNullOrEmpty(data.cce_4) ? string.Empty : data.cce_4;
            data.cce_5 = string.IsNullOrEmpty(data.cce_5) ? string.Empty : data.cce_5;
            data.cce_6 = string.IsNullOrEmpty(data.cce_6) ? string.Empty : data.cce_6;
            data.cce_7 = string.IsNullOrEmpty(data.cce_7) ? string.Empty : data.cce_7;
            data.cce_8 = string.IsNullOrEmpty(data.cce_8) ? string.Empty : data.cce_8;
            data.cce_9 = string.IsNullOrEmpty(data.cce_9) ? string.Empty : data.cce_9;
            data.cce_10 = string.IsNullOrEmpty(data.cce_10) ? string.Empty : data.cce_10;
            data.cce_11 = string.IsNullOrEmpty(data.cce_11) ? string.Empty : data.cce_11;
            data.cce_12 = string.IsNullOrEmpty(data.cce_12) ? string.Empty : data.cce_12;
            data.cce_13 = string.IsNullOrEmpty(data.cce_13) ? string.Empty : data.cce_13;
            data.cce_14 = string.IsNullOrEmpty(data.cce_14) ? string.Empty : data.cce_14;
            data.cce_15 = string.IsNullOrEmpty(data.cce_15) ? string.Empty : data.cce_15;
            data.cce_16 = string.IsNullOrEmpty(data.cce_16) ? string.Empty : data.cce_16;
            data.cce_17 = string.IsNullOrEmpty(data.cce_17) ? string.Empty : data.cce_17;
            data.cce_18 = string.IsNullOrEmpty(data.cce_18) ? string.Empty : data.cce_18;
            data.cce_19 = string.IsNullOrEmpty(data.cce_19) ? string.Empty : data.cce_19;
            data.cce_20 = string.IsNullOrEmpty(data.cce_20) ? string.Empty : data.cce_20;
            data.cce_21 = string.IsNullOrEmpty(data.cce_21) ? string.Empty : data.cce_21;
            DateTime? card1 = data.cce_date1; // Assuming data.cce_date1 is of type DateTime?            
            DateTime? card2 = data.cce_date2; // Assuming data.cce_date2 is of type DateTime?
            DateTime? card3 = data.cce_date3; // Assuming data.cce_date3 is of type DateTime?
            DateTime? card4 = data.cce_date4; // Assuming data.cce_date4 is of type DateTime?
            DateTime? card5 = data.cce_date5; // Assuming data.cce_date5 is of type DateTime?
            DateTime? card6 = data.cce_date6; // Assuming data.cce_date6 is of type DateTime?
            DateTime? card7 = data.cce_date7; // Assuming data.cce_date7 is of type DateTime?
            if (data.cce_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cce_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cce_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.cce_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cce_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cce_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.cce_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cce_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cce_date3 = DateTime.Parse("01/01/1950");
            }
            if (data.cce_date4 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cce_date4 = card4.HasValue ? card4.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cce_date4 = DateTime.Parse("01/01/1950");
            }
            if (data.cce_date5 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cce_date5 = card5.HasValue ? card5.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cce_date5 = DateTime.Parse("01/01/1950");
            }
            if (data.cce_date6 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cce_date6 = card6.HasValue ? card6.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cce_date6 = DateTime.Parse("01/01/1950");
            }
            if (data.cce_date7 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cce_date7 = card7.HasValue ? card7.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cce_date7 = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMRForms.EmiratesInsurance.InsertUpdateEmiratesInsurance(data);
        }
        //Delete
        public static int DeleteEmiratesInsurance(int cceId, int cce_madeby)
        {
            return DataAccessLayer.EMRForms.EmiratesInsurance.DeleteEmiratesInsurance(cceId, cce_madeby);
        }
        #endregion
    }
    public class Mapfre
    {
        #region Mapfre (Page Load)
        public static List<BusinessEntities.EMRForms.Mapfre> GetAllMapfre(int appId)
        {
            List<BusinessEntities.EMRForms.Mapfre> sclist = new List<BusinessEntities.EMRForms.Mapfre>();
            DataTable dt = DataAccessLayer.EMRForms.Mapfre.GetAllMapfre(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Mapfre
                {
                    maprId = Convert.ToInt32(dr["maprId"]),
                    mapr_appId = Convert.ToInt32(dr["mapr_appId"]),
                    mapr_chk = dr["mapr_chk"].ToString(),
                    mapr_1 = dr["mapr_1"].ToString(),
                    mapr_2 = dr["mapr_2"].ToString(),
                    mapr_3 = dr["mapr_3"].ToString(),
                    mapr_4 = dr["mapr_4"].ToString(),
                    mapr_5 = dr["mapr_5"].ToString(),
                    mapr_6 = dr["mapr_6"].ToString(),
                    mapr_7 = dr["mapr_7"].ToString(),
                    mapr_8 = dr["mapr_8"].ToString(),
                    mapr_9 = dr["mapr_9"].ToString(),
                    mapr_10 = dr["mapr_10"].ToString(),
                    mapr_11 = dr["mapr_11"].ToString(),
                    mapr_12 = dr["mapr_12"].ToString(),
                    mapr_13 = dr["mapr_13"].ToString(),
                    mapr_14 = dr["mapr_14"].ToString(),
                    mapr_15 = dr["mapr_15"].ToString(),
                    mapr_16 = dr["mapr_16"].ToString(),
                    mapr_17 = dr["mapr_17"].ToString(),
                    mapr_18 = dr["mapr_18"].ToString(),
                    mapr_19 = dr["mapr_19"].ToString(),
                    mapr_20 = dr["mapr_20"].ToString(),
                    mapr_date1 = Convert.ToDateTime(dr["mapr_date1"].ToString()),
                    mapr_date2 = Convert.ToDateTime(dr["mapr_date2"].ToString()),
                    mapr_date3 = Convert.ToDateTime(dr["mapr_date3"].ToString()),
                    mapr_date4 = Convert.ToDateTime(dr["mapr_date4"].ToString()),
                    mapr_date5 = Convert.ToDateTime(dr["mapr_date5"].ToString()),
                    mapr_date6 = Convert.ToDateTime(dr["mapr_date6"].ToString()),
                    mapr_date7 = Convert.ToDateTime(dr["mapr_date7"].ToString()),
                    mapr_date8 = Convert.ToDateTime(dr["mapr_date8"].ToString()),
                    mapr_date_created = Convert.ToDateTime(dr["mapr_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.Mapfre> GetAllPreMapfre(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.Mapfre> sclist = new List<BusinessEntities.EMRForms.Mapfre>();
            DataTable dt = DataAccessLayer.EMRForms.Mapfre.GetAllPreMapfre(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.Mapfre
                {
                    maprId = Convert.ToInt32(dr["maprId"]),
                    mapr_appId = Convert.ToInt32(dr["mapr_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.Mapfre> GetPrintMapfre(int? maprId)
        {
            List<BusinessEntities.EMRForms.Mapfre> sclist = new List<BusinessEntities.EMRForms.Mapfre>();
            DataTable dt = DataAccessLayer.EMRForms.Mapfre.GetPrintMapfre(maprId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.Mapfre
                    {
                        maprId = Convert.ToInt32(dr["maprId"]),
                        mapr_appId = Convert.ToInt32(dr["mapr_appId"]),
                        mapr_chk = dr["mapr_chk"].ToString(),
                        mapr_1 = dr["mapr_1"].ToString(),
                        mapr_2 = dr["mapr_2"].ToString(),
                        mapr_3 = dr["mapr_3"].ToString(),
                        mapr_4 = dr["mapr_4"].ToString(),
                        mapr_5 = dr["mapr_5"].ToString(),
                        mapr_6 = dr["mapr_6"].ToString(),
                        mapr_7 = dr["mapr_7"].ToString(),
                        mapr_8 = dr["mapr_8"].ToString(),
                        mapr_9 = dr["mapr_9"].ToString(),
                        mapr_10 = dr["mapr_10"].ToString(),
                        mapr_11 = dr["mapr_11"].ToString(),
                        mapr_12 = dr["mapr_12"].ToString(),
                        mapr_13 = dr["mapr_13"].ToString(),
                        mapr_14 = dr["mapr_14"].ToString(),
                        mapr_15 = dr["mapr_15"].ToString(),
                        mapr_16 = dr["mapr_16"].ToString(),
                        mapr_17 = dr["mapr_17"].ToString(),
                        mapr_18 = dr["mapr_18"].ToString(),
                        mapr_19 = dr["mapr_19"].ToString(),
                        mapr_20 = dr["mapr_20"].ToString(),
                        mapr_dd1 = dr["mapr_date1"].ToString(),
                        mapr_dd2 = dr["mapr_date2"].ToString(),
                        mapr_dd3 = dr["mapr_date3"].ToString(),
                        mapr_dd4 = dr["mapr_date4"].ToString(),
                        mapr_dd5 = dr["mapr_date5"].ToString(),
                        mapr_dd6 = dr["mapr_date6"].ToString(),
                        mapr_dd7 = dr["mapr_date7"].ToString(),
                        mapr_dd8 = dr["mapr_date8"].ToString(),
                        mapr_date_created = Convert.ToDateTime(dr["mapr_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.Mapfre a = new BusinessEntities.EMRForms.Mapfre();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region Mapfre (CRUD Operations)
        //insert&update
        public static bool InsertUpdateMapfre(BusinessEntities.EMRForms.Mapfre data)
        {
            data.mapr_chk = string.IsNullOrEmpty(data.mapr_chk) ? string.Empty : data.mapr_chk;
            data.mapr_1 = string.IsNullOrEmpty(data.mapr_1) ? string.Empty : data.mapr_1;
            data.mapr_2 = string.IsNullOrEmpty(data.mapr_2) ? string.Empty : data.mapr_2;
            data.mapr_3 = string.IsNullOrEmpty(data.mapr_3) ? string.Empty : data.mapr_3;
            data.mapr_4 = string.IsNullOrEmpty(data.mapr_4) ? string.Empty : data.mapr_4;
            data.mapr_5 = string.IsNullOrEmpty(data.mapr_5) ? string.Empty : data.mapr_5;
            data.mapr_6 = string.IsNullOrEmpty(data.mapr_6) ? string.Empty : data.mapr_6;
            data.mapr_7 = string.IsNullOrEmpty(data.mapr_7) ? string.Empty : data.mapr_7;
            data.mapr_8 = string.IsNullOrEmpty(data.mapr_8) ? string.Empty : data.mapr_8;
            data.mapr_9 = string.IsNullOrEmpty(data.mapr_9) ? string.Empty : data.mapr_9;
            data.mapr_10 = string.IsNullOrEmpty(data.mapr_10) ? string.Empty : data.mapr_10;
            data.mapr_11 = string.IsNullOrEmpty(data.mapr_11) ? string.Empty : data.mapr_11;
            data.mapr_12 = string.IsNullOrEmpty(data.mapr_12) ? string.Empty : data.mapr_12;
            data.mapr_13 = string.IsNullOrEmpty(data.mapr_13) ? string.Empty : data.mapr_13;
            data.mapr_14 = string.IsNullOrEmpty(data.mapr_14) ? string.Empty : data.mapr_14;
            data.mapr_15 = string.IsNullOrEmpty(data.mapr_15) ? string.Empty : data.mapr_15;
            data.mapr_16 = string.IsNullOrEmpty(data.mapr_16) ? string.Empty : data.mapr_16;
            data.mapr_17 = string.IsNullOrEmpty(data.mapr_17) ? string.Empty : data.mapr_17;
            data.mapr_18 = string.IsNullOrEmpty(data.mapr_18) ? string.Empty : data.mapr_18;
            data.mapr_19 = string.IsNullOrEmpty(data.mapr_19) ? string.Empty : data.mapr_19;
            data.mapr_20 = string.IsNullOrEmpty(data.mapr_20) ? string.Empty : data.mapr_20;
            DateTime? card1 = data.mapr_date1; // Assuming data.mapr_date1 is of type DateTime?            
            DateTime? card2 = data.mapr_date2; // Assuming data.mapr_date2 is of type DateTime?
            DateTime? card3 = data.mapr_date3; // Assuming data.mapr_date3 is of type DateTime?
            DateTime? card4 = data.mapr_date4; // Assuming data.mapr_date4 is of type DateTime?
            DateTime? card5 = data.mapr_date5; // Assuming data.mapr_date5 is of type DateTime?
            DateTime? card6 = data.mapr_date6; // Assuming data.mapr_date6 is of type DateTime?
            DateTime? card7 = data.mapr_date7; // Assuming data.mapr_date7 is of type DateTime?
            DateTime? card8 = data.mapr_date8; // Assuming data.mapr_date7 is of type DateTime?
            if (data.mapr_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date1 = DateTime.Parse("01/01/1950");
            }
            if (data.mapr_date2 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date2 = card2.HasValue ? card2.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date2 = DateTime.Parse("01/01/1950");
            }
            if (data.mapr_date3 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date3 = card3.HasValue ? card3.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date3 = DateTime.Parse("01/01/1950");
            }
            if (data.mapr_date4 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date4 = card4.HasValue ? card4.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date4 = DateTime.Parse("01/01/1950");
            }
            if (data.mapr_date5 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date5 = card5.HasValue ? card5.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date5 = DateTime.Parse("01/01/1950");
            }
            if (data.mapr_date6 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date6 = card6.HasValue ? card6.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date6 = DateTime.Parse("01/01/1950");
            }
            if (data.mapr_date7 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date7 = card7.HasValue ? card7.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date7 = DateTime.Parse("01/01/1950");
            }
            if (data.mapr_date8 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.mapr_date8 = card8.HasValue ? card8.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.mapr_date8 = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMRForms.Mapfre.InsertUpdateMapfre(data);
        }
        //Delete
        public static int DeleteMapfre(int maprId, int mapr_madeby)
        {
            return DataAccessLayer.EMRForms.Mapfre.DeleteMapfre(maprId, mapr_madeby);
        }
        #endregion
    }

    public class AAFIYA
    {
        #region AAFIYA (Page Load)
        public static List<BusinessEntities.EMRForms.AAFIYA> GetAllAAFIYA(int appId)
        {
            List<BusinessEntities.EMRForms.AAFIYA> sclist = new List<BusinessEntities.EMRForms.AAFIYA>();
            DataTable dt = DataAccessLayer.EMRForms.AAFIYA.GetAllAAFIYA(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.AAFIYA
                {
                    ccaId = Convert.ToInt32(dr["ccaId"]),
                    cca_appId = Convert.ToInt32(dr["cca_appId"]),
                    cca_chk = dr["cca_chk"].ToString(),
                    cca_1 = dr["cca_1"].ToString(),
                    cca_2 = dr["cca_2"].ToString(),
                    cca_3 = dr["cca_3"].ToString(),
                    cca_4 = dr["cca_4"].ToString(),
                    cca_5 = dr["cca_5"].ToString(),
                    cca_6 = dr["cca_6"].ToString(),
                    cca_7 = dr["cca_7"].ToString(),
                    cca_8 = dr["cca_8"].ToString(),
                    cca_9 = dr["cca_9"].ToString(),
                    cca_10 = dr["cca_10"].ToString(),
                    cca_11 = dr["cca_11"].ToString(),
                    cca_12 = dr["cca_12"].ToString(),
                    cca_13 = dr["cca_13"].ToString(),
                    cca_14 = dr["cca_14"].ToString(),
                    cca_15 = dr["cca_15"].ToString(),
                    cca_16 = dr["cca_16"].ToString(),
                    cca_17 = dr["cca_17"].ToString(),
                    cca_18 = dr["cca_18"].ToString(),
                    cca_19 = dr["cca_19"].ToString(),
                    cca_20 = dr["cca_20"].ToString(),
                    cca_date1 = Convert.ToDateTime(dr["cca_date1"].ToString()),
                    cca_date_created = Convert.ToDateTime(dr["cca_date_created"].ToString()),
                });
            }
            return sclist;
        }
        public static List<BusinessEntities.EMRForms.AAFIYA> GetAllPreAAFIYA(int appId, int patId)
        {
            List<BusinessEntities.EMRForms.AAFIYA> sclist = new List<BusinessEntities.EMRForms.AAFIYA>();
            DataTable dt = DataAccessLayer.EMRForms.AAFIYA.GetAllPreAAFIYA(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMRForms.AAFIYA
                {
                    ccaId = Convert.ToInt32(dr["ccaId"]),
                    cca_appId = Convert.ToInt32(dr["cca_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        //print
        public static List<BusinessEntities.EMRForms.AAFIYA> GetPrintAAFIYA(int? ccaId)
        {
            List<BusinessEntities.EMRForms.AAFIYA> sclist = new List<BusinessEntities.EMRForms.AAFIYA>();
            DataTable dt = DataAccessLayer.EMRForms.AAFIYA.GetPrintAAFIYA(ccaId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sclist.Add(new BusinessEntities.EMRForms.AAFIYA
                    {
                        ccaId = Convert.ToInt32(dr["ccaId"]),
                        cca_appId = Convert.ToInt32(dr["cca_appId"]),
                        cca_chk = dr["cca_chk"].ToString(),
                        cca_1 = dr["cca_1"].ToString(),
                        cca_2 = dr["cca_2"].ToString(),
                        cca_3 = dr["cca_3"].ToString(),
                        cca_4 = dr["cca_4"].ToString(),
                        cca_5 = dr["cca_5"].ToString(),
                        cca_6 = dr["cca_6"].ToString(),
                        cca_7 = dr["cca_7"].ToString(),
                        cca_8 = dr["cca_8"].ToString(),
                        cca_9 = dr["cca_9"].ToString(),
                        cca_10 = dr["cca_10"].ToString(),
                        cca_11 = dr["cca_11"].ToString(),
                        cca_12 = dr["cca_12"].ToString(),
                        cca_13 = dr["cca_13"].ToString(),
                        cca_14 = dr["cca_14"].ToString(),
                        cca_15 = dr["cca_15"].ToString(),
                        cca_16 = dr["cca_16"].ToString(),
                        cca_17 = dr["cca_17"].ToString(),
                        cca_18 = dr["cca_18"].ToString(),
                        cca_19 = dr["cca_19"].ToString(),
                        cca_20 = dr["cca_20"].ToString(),
                        cca_dd1 = dr["cca_date1"].ToString(),
                        cca_date_created = Convert.ToDateTime(dr["cca_date_created"].ToString()),
                        doctor_name = dr["doctor_name"].ToString(),

                        doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dr["emp_sign"].ToString()),
                        doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_STAMPS", dr["emp_stamp"].ToString()),

                    });
                }
            }
            else
            {
                BusinessEntities.EMRForms.AAFIYA a = new BusinessEntities.EMRForms.AAFIYA();
                a.doc_sign = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                a.doc_stamp = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg";
                sclist.Add(a);
            }
            return sclist;
        }
        #endregion

        #region AAFIYA (CRUD Operations)
        //insert&update
        public static bool InsertUpdateAAFIYA(BusinessEntities.EMRForms.AAFIYA data)
        {
            data.cca_chk = string.IsNullOrEmpty(data.cca_chk) ? string.Empty : data.cca_chk;
            data.cca_1 = string.IsNullOrEmpty(data.cca_1) ? string.Empty : data.cca_1;
            data.cca_2 = string.IsNullOrEmpty(data.cca_2) ? string.Empty : data.cca_2;
            data.cca_3 = string.IsNullOrEmpty(data.cca_3) ? string.Empty : data.cca_3;
            data.cca_4 = string.IsNullOrEmpty(data.cca_4) ? string.Empty : data.cca_4;
            data.cca_5 = string.IsNullOrEmpty(data.cca_5) ? string.Empty : data.cca_5;
            data.cca_6 = string.IsNullOrEmpty(data.cca_6) ? string.Empty : data.cca_6;
            data.cca_7 = string.IsNullOrEmpty(data.cca_7) ? string.Empty : data.cca_7;
            data.cca_8 = string.IsNullOrEmpty(data.cca_8) ? string.Empty : data.cca_8;
            data.cca_9 = string.IsNullOrEmpty(data.cca_9) ? string.Empty : data.cca_9;
            data.cca_10 = string.IsNullOrEmpty(data.cca_10) ? string.Empty : data.cca_10;
            data.cca_11 = string.IsNullOrEmpty(data.cca_11) ? string.Empty : data.cca_11;
            data.cca_12 = string.IsNullOrEmpty(data.cca_12) ? string.Empty : data.cca_12;
            data.cca_13 = string.IsNullOrEmpty(data.cca_13) ? string.Empty : data.cca_13;
            data.cca_14 = string.IsNullOrEmpty(data.cca_14) ? string.Empty : data.cca_14;
            data.cca_15 = string.IsNullOrEmpty(data.cca_15) ? string.Empty : data.cca_15;
            data.cca_16 = string.IsNullOrEmpty(data.cca_16) ? string.Empty : data.cca_16;
            data.cca_17 = string.IsNullOrEmpty(data.cca_17) ? string.Empty : data.cca_17;
            data.cca_18 = string.IsNullOrEmpty(data.cca_18) ? string.Empty : data.cca_18;
            data.cca_19 = string.IsNullOrEmpty(data.cca_19) ? string.Empty : data.cca_19;
            data.cca_20 = string.IsNullOrEmpty(data.cca_20) ? string.Empty : data.cca_20;
            DateTime? card1 = data.cca_date1;    
            if (data.cca_date1 != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.cca_date1 = card1.HasValue ? card1.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.cca_date1 = DateTime.Parse("01/01/1950");
            }


            return DataAccessLayer.EMRForms.AAFIYA.InsertUpdateAAFIYA(data);
        }
        //Delete
        public static int DeleteAAFIYA(int ccaId, int cca_madeby)
        {
            return DataAccessLayer.EMRForms.AAFIYA.DeleteAAFIYA(ccaId, cca_madeby);
        }
        #endregion
    }
}
