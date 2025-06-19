using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessEntities.Appointment;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities.EMRForms
{
    public class Adnic
    {
        public int adsId { get; set; }
        public int ads_appId { get; set; }
        public string ads_status { get; set; }
        public int ads_madeby { get; set; }
        public string ads_witness { get; set; }
        public DateTime ads_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
        public string ads_voucher { get; set; }
        public string ads_group_mem { get; set; }
        public string ads_onset_duration { get; set; }
        public string ads_bankDetails { get; set; }
        public string ads_account_holder { get; set; }
        public string ads_bank_name { get; set; }
        public string ads_bank_address { get; set; }
        public string ads_bank_currency { get; set; }
        public string ads_bank_swiftcode { get; set; }
        public string ads_witnessname { get; set; }
        public string ads_contact { get; set; }
        public string ads_type_plan { get; set; }
        public string ads_reason { get; set; }
        public string ads_reason_other { get; set; }
        public string ads_condition { get; set; }
        public string ads_visit { get; set; }
        public string ads_treat_details { get; set; }
        public string ads_addr1 { get; set; }
        public string ads_bill1 { get; set; }
        public string ads_tdate1 { get; set; }
        public string ads_desc1 { get; set; }
        public string ads_amt1 { get; set; }
        public string ads_addr2 { get; set; }
        public string ads_bill2 { get; set; }
        public string ads_tdate2 { get; set; }
        public string ads_desc2 { get; set; }
        public string ads_amt2 { get; set; }
        public string ads_addr3 { get; set; }
        public string ads_bill3 { get; set; }
        public string ads_tdate3 { get; set; }
        public string ads_desc3 { get; set; }
        public string ads_amt3 { get; set; }
        public string ads_addr4 { get; set; }
        public string ads_bill4 { get; set; }
        public string ads_tdate4 { get; set; }
        public string ads_desc4 { get; set; }
        public string ads_amt4 { get; set; }
        public string ads_addr5 { get; set; }
        public string ads_bill5 { get; set; }
        public string ads_tdate5 { get; set; }
        public string ads_desc5 { get; set; }
        public string ads_amt5 { get; set; }
        public string ads_total { get; set; }
        public string ads_oth_above { get; set; }
        public string ads_oth_above_det { get; set; }
        public string ads_oth_claim { get; set; }
        public string ads_oth_claim_det { get; set; }
        public string complaints { get; set; }
        public string treatments { get; set; }

        public string sign_bp { get; set; }
        public string sign_pulse { get; set; }
        public string sign_temp { get; set; }
        public string sign_notes { get; set; }

        public int ptId { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string tr_type { get; set; }
        public string tr_price { get; set; }
        public string pt_auth_code { get; set; }
        public string pt_auth_adate { get; set; }
        public string pt_auth_edate { get; set; }
        public string pt_qty { get; set; }
        public DateTime pt_date_collected { get; set; }
        public DateTime pt_date_received { get; set; }
        public string pt_teeth { get; set; }
        public string pt_sur { get; set; }
        public string pt_notes { get; set; }

        public string ads_onset { get; set; }
        public string ads_bank { get; set; }
        public string ads_account { get; set; }
        public string ads_bname { get; set; }
        public string ads_baddress { get; set; }
        public string ads_bcurrency { get; set; }
        public string ads_bswiftcode { get; set; }
    }
    public class Aetna
    {
        public int car_Id { get; set; }
        public int car_appId { get; set; }
        public string car_status { get; set; }
        public int car_madeby { get; set; }
        public string car_witness { get; set; }
        public DateTime car_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string complaints { get; set; }
        public string treatments { get; set; }
        public string lab_treatments { get; set; }
        public string diag_names { get; set; }
        public string diag_codes { get; set; }
        public string app_complaints { get; set; }

        public int ptId { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string tr_type { get; set; }
        public string tr_price { get; set; }
        public string pt_auth_code { get; set; }
        public string pt_auth_adate { get; set; }
        public string pt_auth_edate { get; set; }
        public string car_checkbox { get; set; }
        public string car_r1 { get; set; }
        public string car_r2 { get; set; }
        public string car_r3 { get; set; }
        public string car_r4 { get; set; }
        public string car_r5 { get; set; }
        public string car_r6 { get; set; }
        public string car_r7 { get; set; }
        public string car_r8 { get; set; }
        public string car_r9 { get; set; }
        public string car_r10 { get; set; }
        public string car_r11 { get; set; }
        public string car_r12 { get; set; }
        public string car_r13 { get; set; }
        public string car_r14 { get; set; }
        public string car_r15 { get; set; }
        public string car_r16 { get; set; }
        public string car_r17 { get; set; }
        public string car_r18 { get; set; }
        public string car_r19 { get; set; }
        public string car_r20 { get; set; }
        public string car_r21 { get; set; }
        public string car_r22 { get; set; }
        public string car_r23 { get; set; }
        public string car_r24 { get; set; }
        public string car_r25 { get; set; }
        public string car_r26 { get; set; }
        public string car_r27 { get; set; }
        public string car_r28 { get; set; }
        public string car_r29 { get; set; }
        public string car_r30 { get; set; }
        public string car_r31 { get; set; }
        public string car_r32 { get; set; }
        public string car_r33 { get; set; }
        public string car_r34 { get; set; }
        public string car_r35 { get; set; }
        public string car_r36 { get; set; }
        public string car_r37 { get; set; }
        public string car_r38 { get; set; }
        public string car_r39 { get; set; }
        public string car_r40 { get; set; }
        public string car_r41 { get; set; }
        public string car_r42 { get; set; }
        public string car_r43 { get; set; }
        public string car_r44 { get; set; }
        public string car_r45 { get; set; }
        public string car_r46 { get; set; }
        public string car_r47 { get; set; }
        public string car_r48 { get; set; }
        public string car_r49 { get; set; }
        public string car_r50 { get; set; }
        public string car_r51 { get; set; }
        public string car_r52 { get; set; }
        public string car_r53 { get; set; }
        public string car_r54 { get; set; }
        public string car_r55 { get; set; }
        public string car_r56 { get; set; }
        public string car_r57 { get; set; }
        public string car_r58 { get; set; }
        public string car_r59 { get; set; }
        public string car_r60 { get; set; }
        public string car_r61 { get; set; }
        public string car_r62 { get; set; }
        public string car_r63 { get; set; }
        public string car_r64 { get; set; }
        public string car_r65 { get; set; }
        public string car_r66 { get; set; }
        public string car_r67 { get; set; }
        public string car_r68 { get; set; }
        public string car_r69 { get; set; }
        public string car_r70 { get; set; }
        public string car_r71 { get; set; }
        public string car_r72 { get; set; }
        public string car_r73 { get; set; }
        public string car_r74 { get; set; }
        public string car_r75 { get; set; }
        public DateTime car_d1 { get; set; }
        public DateTime car_d2 { get; set; }
        public DateTime car_d3 { get; set; }
        public DateTime car_d4 { get; set; }
        public DateTime car_d5 { get; set; }
        public DateTime car_d6 { get; set; }
        public DateTime car_d7 { get; set; }
        public DateTime car_d8 { get; set; }

        public string car_dd1 { get; set; }
        public string car_dd2 { get; set; }
        public string car_dd3 { get; set; }
        public string car_dd4 { get; set; }
        public string car_dd5 { get; set; }
        public string car_dd6 { get; set; }
        public string car_dd7 { get; set; }
        public string car_dd8 { get; set; }


    }
    public class Amity
    {
        public int car_Id { get; set; }
        public int car_appId { get; set; }
        public string car_status { get; set; }
        public int car_madeby { get; set; }
        public string car_witness { get; set; }
        public DateTime car_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string complaints { get; set; }
        public string treatments { get; set; }
        public string lab_treatments { get; set; }
        public string diag_names { get; set; }
        public string diag_codes { get; set; }
        public string app_complaints { get; set; }

        public int ptId { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string tr_type { get; set; }
        public string tr_price { get; set; }
        public string pt_auth_code { get; set; }
        public string pt_auth_adate { get; set; }
        public string pt_auth_edate { get; set; }

        public string car_checkbox { get; set; }
        public string car_e1 { get; set; }
        public string car_e2 { get; set; }
        public string car_e3 { get; set; }
        public string car_e4 { get; set; }
        public string car_e5 { get; set; }
        public string car_e6 { get; set; }
        public string car_e7 { get; set; }
        public string car_e8 { get; set; }
        public string car_e9 { get; set; }
        public string car_e10 { get; set; }
        public string car_e11 { get; set; }
        public string car_e12 { get; set; }
        public string car_e13 { get; set; }
        public DateTime car_d1 { get; set; }
        public DateTime car_d2 { get; set; }
        public string car_dd1 { get; set; }
        public string car_dd2 { get; set; }

    }
    public class Alico
    {
        public int aliId { get; set; }
        public int ali_appId { get; set; }
        public string ali_status { get; set; }
        public int ali_madeby { get; set; }
        public string ali_witness { get; set; }
        public DateTime ali_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }        
        public string ali_checkbox { get; set; }
        public string ali_ins1 { get; set; }
        public string ali_ins2 { get; set; }
        public string ali_ins3 { get; set; }
        public string ali_ins4 { get; set; }
        public string ali_ins5 { get; set; }
        public string ali_ins6 { get; set; }
        public string ali_ins7 { get; set; }
        public string ali_ins8 { get; set; }
        public string ali_ins9 { get; set; }
        public string ali_ins10 { get; set; }
        public string ali_ins11 { get; set; }
        public string ali_ins12 { get; set; }
        public string ali_ins13 { get; set; }
        public string ali_ins14 { get; set; }


    }
    public class Allianz
    {
        public int allId { get; set; }
        public int all_appId { get; set; }
        public string all_status { get; set; }
        public int all_madeby { get; set; }
        public string all_witness { get; set; }
        public DateTime all_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
        public string all_1 { get; set; }
        public string all_2 { get; set; }
        public string all_3 { get; set; }
        public string all_4 { get; set; }
        public string all_5 { get; set; }
        public string all_6 { get; set; }
        public string all_7 { get; set; }
        public string all_8 { get; set; }
        public string all_9 { get; set; }
        public string all_10 { get; set; }
        public string all_11 { get; set; }
        public string all_12 { get; set; }
        public DateTime all_13 { get; set; }
        public DateTime all_14 { get; set; }
        public DateTime all_15 { get; set; }


    }
    public class Axa
    {
        public int carfId { get; set; }
        public int carf_appId { get; set; }
        public string carf_status { get; set; }
        public int carf_madeby { get; set; }
        public string carf_witness { get; set; }
        public DateTime carf_date_created { get; set; }

        public string carf_1 { get; set; }
        public string carf_2 { get; set; }
        public string carf_3 { get; set; }
        public string carf_4 { get; set; }
        public string carf_5 { get; set; }
        public string carf_6 { get; set; }
        public string carf_7 { get; set; }
        public string carf_8 { get; set; }
        public string carf_9 { get; set; }
        public string carf_10 { get; set; }
        public string carf_11 { get; set; }
        public string carf_12 { get; set; }
        public string carf_13 { get; set; }
        public string carf_14 { get; set; }
        public string carf_15 { get; set; }
        public string carf_16 { get; set; }
        public string carf_17 { get; set; }
        public string carf_18 { get; set; }
        public string carf_19 { get; set; }
        public string carf_20 { get; set; }
        public DateTime carf_21 { get; set; }
        public DateTime carf_22 { get; set; }
        public DateTime carf_23 { get; set; }
        public DateTime carf_24 { get; set; }
        public DateTime carf_25 { get; set; }
        public DateTime carf_26 { get; set; }

        public string carf_d21 { get; set; }
        public string carf_d22 { get; set; }
        public string carf_d23 { get; set; }
        public string carf_d24 { get; set; }
        public string carf_d25 { get; set; }
        public string carf_d26 { get; set; }

        public int padId { get; set; }
        public string Diagnosis { get; set; }
        public string Prescriptions { get; set; }
        public int preId { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class MSH
    {
        public int cmr_Id { get; set; }
        public int cmr_appId { get; set; }
        public string cmr_status { get; set; }
        public int cmr_madeby { get; set; }
        public string cmr_witness { get; set; }
        public DateTime cmr_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string form_header_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cmr_checkbox { get; set; }
        public string cmr_groupname { get; set; }
        public string cmr_health { get; set; }
        public string cmr_dental { get; set; }
        public string cmr_amount { get; set; }
        public string cmr_total { get; set; }
    }
    public class Dubaicare
    {
        public int cdr_Id { get; set; }
        public int cdr_appId { get; set; }
        public string cdr_status { get; set; }
        public int cdr_madeby { get; set; }
        public string cdr_witness { get; set; }
        public DateTime cdr_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string form_header_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cdr_name { get; set; }
        public string cdr_address { get; set; }
        public string cdr_account { get; set; }
        public string cdr_iban { get; set; }
        public string cdr_scode { get; set; }
        public string cdr_bank { get; set; }
        public string cdr_branch { get; set; }
        public string cdr_phy_find { get; set; }
        public string cdr_invest { get; set; }
    }
    public class Emirates
    {
        public int cer_Id { get; set; }
        public int cer_appId { get; set; }
        public string cer_status { get; set; }
        public int cer_madeby { get; set; }
        public string cer_witness { get; set; }
        public DateTime cer_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string form_header_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public string cer_checkbox { get; set; }
        public string cer_processor { get; set; }
        public string cer_payable { get; set; }
        public string cer_nonpayable { get; set; }
    }
    public class FMC
    {
        public int fcId { get; set; }
        public int fc_appId { get; set; }
        public string fc_status { get; set; }
        public int fc_madeby { get; set; }
        public string fc_witness { get; set; }
        public DateTime fc_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string form_header_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public DateTime fc_symptoms_date { get; set; }
        public string fc_visit { get; set; }
        public string fc_diag { get; set; }
        public string fc_date { get; set; }
    }
    public class Neuron
    {
        public int nrId { get; set; }
        public int nr_appId { get; set; }
        public string nr_status { get; set; }
        public int nr_madeby { get; set; }
        public string nr_witness { get; set; }
        public DateTime nr_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string form_header_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public DateTime nr_date1 { get; set; }
        public DateTime nr_date2 { get; set; }
        public string nr_his { get; set; }
        public string nr_1 { get; set; }
        public string nr_2 { get; set; }
        public string nr_d1 { get; set; }
        public string nr_d2 { get; set; }
    }
    public class Starwell
    {
        public int swId { get; set; }
        public int sw_appId { get; set; }
        public string sw_status { get; set; }
        public int sw_madeby { get; set; }
        public string sw_witness { get; set; }
        public DateTime sw_date_created { get; set; }

        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string sw_type { get; set; }
        public string sw_pappr { get; set; }
        public decimal sw_pamount { get; set; }
        public string sw_comments { get; set; }
        public DateTime sw_pdate { get; set; }


    }
    public class NGI
    {
        public int ngId { get; set; }
        public int ng_appId { get; set; }
        public string ng_status { get; set; }
        public int ng_madeby { get; set; }
        public string ng_witness { get; set; }
        public DateTime ng_date_created { get; set; }

        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string ng_1 { get; set; }
        public string ng_2 { get; set; }
        public string ng_5 { get; set; }
        public DateTime ng_3 { get; set; }
        public int ng_no { get; set; }
        public string ng_on { get; set; }
        public string ng_eti { get; set; }
        public string ng_comments { get; set; }
        public DateTime ng_4 { get; set; }
        public string ng_d4 { get; set; }
        public string ng_d3 { get; set; }

        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string inv_net { get; set; }
        public string past { get; set; }
        public string diag_names { get; set; }
        public string diag_codes { get; set; }
        public string complaints { get; set; }
        public string lab_treatments { get; set; }
        public string rad_treatments { get; set; }
        public string other_treatments { get; set; }
        public string treatments { get; set; }
        public string diagnosis { get; set; }
    }
    public class Inayah
    {
        public int cir_Id { get; set; }
        public int cir_appId { get; set; }
        public string cir_status { get; set; }
        public int cir_madeby { get; set; }
        public string cir_witness { get; set; }
        public DateTime cir_date_created { get; set; }

        public string cir_checkbox { get; set; }
        public string cir_details { get; set; }
        public string cir_claim { get; set; }
        public string cir_total { get; set; }
        public string cir_medicines { get; set; }
        public string cir_expenses { get; set; }
        public string cir_grand { get; set; }
        public DateTime cir_d1 { get; set; }
        public string cir_date1 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }



    }
    public class Healthnet
    {
        public int chr_Id { get; set; }
        public int chr_appId { get; set; }
        public string chr_status { get; set; }
        public int chr_madeby { get; set; }
        public string chr_witness { get; set; }
        public DateTime chr_date_created { get; set; }

        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string chr_1 { get; set; }
        public string chr_2 { get; set; }
        public string chr_checkbox { get; set; }
        public string chr_amount { get; set; }
        public string chr_symptom { get; set; }
        public string chr_condition { get; set; }
        public string chr_history { get; set; }
        public string chr_etiology { get; set; }
        public string chr_lab { get; set; }
        public string chr_radiology { get; set; }
        public string chr_remarks { get; set; }
        public DateTime chr_d1 { get; set; }
        public DateTime chr_d2 { get; set; }
        public string chr_date1 { get; set; }
        public string chr_date2 { get; set; }

      


    }
    public class Daman
    {
        public int cdr_Id { get; set; }
        public int cdr_appId { get; set; }
        public string cdr_status { get; set; }
        public int cdr_madeby { get; set; }
        public string cdr_witness { get; set; }
        public DateTime cdr_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

       
        public string cdr_checkbox { get; set; }
        public string cdr_e1 { get; set; }
        public string cdr_e2 { get; set; }
        public string cdr_e3 { get; set; }
        public string cdr_e4 { get; set; }
        public string cdr_e5 { get; set; }
        public string cdr_e6 { get; set; }
        public string cdr_e7 { get; set; }
        public string cdr_e8 { get; set; }
        public string cdr_e9 { get; set; }
        public string cdr_e10 { get; set; }
        public string cdr_e11 { get; set; }
        public string cdr_e12 { get; set; }
        public string cdr_e13 { get; set; }
        public DateTime cdr_d1 { get; set; }

        public string cdr_dd1 { get; set; }
    }
    public class DamanArabic
    {
        public int cdr_Id { get; set; }
        public int cdr_appId { get; set; }
        public string cdr_status { get; set; }
        public int cdr_madeby { get; set; }
        public string cdr_witness { get; set; }
        public DateTime cdr_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public string cdr_checkbox { get; set; }
        public string cdr_e1 { get; set; }
        public string cdr_e2 { get; set; }
        public string cdr_e3 { get; set; }
        public string cdr_e4 { get; set; }
        public string cdr_e5 { get; set; }
        public string cdr_e6 { get; set; }
        public string cdr_e7 { get; set; }
        public string cdr_e8 { get; set; }
        public string cdr_e9 { get; set; }
        public string cdr_e10 { get; set; }
        public string cdr_e11 { get; set; }
        public string cdr_e12 { get; set; }
        public string cdr_e13 { get; set; }
        public DateTime cdr_d1 { get; set; }

        public string cdr_dd1 { get; set; }
    }
    public class DamanWT
    {
        public int cdr_Id { get; set; }
        public int cdr_appId { get; set; }
        public string cdr_status { get; set; }
        public int cdr_madeby { get; set; }
        public string cdr_witness { get; set; }
        public DateTime cdr_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public string cdr_checkbox { get; set; }
        public string cdr_e1 { get; set; }
        public string cdr_e2 { get; set; }
        public string cdr_e3 { get; set; }
        public string cdr_e4 { get; set; }
        public string cdr_e5 { get; set; }
        public string cdr_e6 { get; set; }
        public string cdr_e7 { get; set; }
        public string cdr_e8 { get; set; }
        public string cdr_e9 { get; set; }
        public string cdr_e10 { get; set; }
        public string cdr_e11 { get; set; }
        public string cdr_e12 { get; set; }
        public DateTime cdr_d1 { get; set; }

        public string cdr_dd1 { get; set; }

        public string set_company { get; set; }
        public string pt_invno { get; set; }
        public string pt_tr_name { get; set; }
        public string pt_net { get; set; }
        public int ptId { get; set; }
        public DateTime pt_date { get; set; }
    }
    public class NAS
    {
        public int nasnId { get; set; }
        public int nasn_appId { get; set; }
        public string nasn_status { get; set; }
        public int nasn_madeby { get; set; }
        public string nasn_witness { get; set; }
        public DateTime nasn_date_created { get; set; }

        public string nasn_1 { get; set; }
        public string nasn_2 { get; set; }
        public string nasn_3 { get; set; }
        public string nasn_4 { get; set; }
        public string nasn_5 { get; set; }
        public string nasn_6 { get; set; }
        public string nasn_7 { get; set; }
        public string nasn_8 { get; set; }
        public string nasn_9 { get; set; }
        public string nasn_10 { get; set; }
        public string nasn_11 { get; set; }
        public string nasn_12 { get; set; }
        public string nasn_13 { get; set; }
        public string nasn_14 { get; set; }
        public string nasn_15 { get; set; }
        public string nasn_16 { get; set; }
        public string nasn_17 { get; set; }
        public string nasn_18 { get; set; }
        public DateTime nasn_date1 { get; set; }
        public string nasn_d1 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class Metlife
    {
        public int metId { get; set; }
        public int met_appId { get; set; }
        public string met_status { get; set; }
        public int met_madeby { get; set; }
        public string met_witness { get; set; }
        public DateTime met_date_created { get; set; }

        public string met_1 { get; set; }
        public string met_2 { get; set; }
        public string met_3 { get; set; }
        public DateTime met_4 { get; set; }
        public string met_check { get; set; }
        public string met_claim_amount { get; set; }
        public string met_currency { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class Mednet
    {
        public int cmcnId { get; set; }
        public int cmcn_appId { get; set; }
        public string cmcn_status { get; set; }
        public int cmcn_madeby { get; set; }
        public string cmcn_witness { get; set; }
        public DateTime cmcn_date_created { get; set; }

        public string cmcn_1 { get; set; }
        public string cmcn_2 { get; set; }
        public string cmcn_3 { get; set; }
        public string cmcn_4 { get; set; }
        public string cmcn_5 { get; set; }
        public string cmcn_6 { get; set; }
        public string cmcn_7 { get; set; }
        public string cmcn_chk { get; set; }
        public DateTime cmcn_date1 { get; set; }
        public DateTime cmcn_date2 { get; set; }
        public DateTime cmcn_date3 { get; set; }
        public string cmcn_d21 { get; set; }
        public string cmcn_d22 { get; set; }
        public string cmcn_d23 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class Nextcare
    {
        public int cncnId { get; set; }
        public int cncn_appId { get; set; }
        public string cncn_status { get; set; }
        public int cncn_madeby { get; set; }
        public string cncn_witness { get; set; }
        public DateTime cncn_date_created { get; set; }

        public string cncn_1 { get; set; }
        public string cncn_2 { get; set; }
        public string cncn_3 { get; set; }
        public string cncn_4 { get; set; }
        public string cncn_5 { get; set; }
        public string cncn_6 { get; set; }
        public string cncn_7 { get; set; }
        public string cncn_8 { get; set; }
        public string cncn_9 { get; set; }
        public string cncn_10 { get; set; }
        public string cncn_11 { get; set; }
        public string cncn_12 { get; set; }
        public string cncn_13 { get; set; }
        public string cncn_14 { get; set; }
        public string cncn_15 { get; set; }
        public string cncn_chk { get; set; }
        public DateTime cncn_date1 { get; set; }
        public DateTime cncn_date2 { get; set; }

        public string cncn_d1 { get; set; }
        public string cncn_d2 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class Alkhazna
    {
        public int ckneId { get; set; }
        public int ckne_appId { get; set; }
        public string ckne_status { get; set; }
        public int ckne_madeby { get; set; }
        public string ckne_witness { get; set; }
        public DateTime ckne_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }       

        public string ckne_chk { get; set; }
        public string ckne_1 { get; set; }
        public string ckne_2 { get; set; }
        public string ckne_3 { get; set; }
        public string ckne_4 { get; set; }
        public string ckne_5 { get; set; }
        public string ckne_6 { get; set; }
        public string ckne_7 { get; set; }
        public string ckne_8 { get; set; }
        public string ckne_9 { get; set; }
        public string ckne_10 { get; set; }
        public string ckne_11 { get; set; }
        public string ckne_12 { get; set; }
        public string ckne_13 { get; set; }
        public string ckne_14 { get; set; }
        public string ckne_15 { get; set; }
        public string ckne_16 { get; set; }
        public string ckne_17 { get; set; }
        public string ckne_18 { get; set; }
        public string ckne_19 { get; set; }
        public string ckne_20 { get; set; }
        public string ckne_21 { get; set; }
        public string ckne_22 { get; set; }
        public string ckne_23 { get; set; }
        public string ckne_24 { get; set; }
        public string ckne_25 { get; set; }
        public string ckne_26 { get; set; }
        public string ckne_27 { get; set; }
        public string ckne_28 { get; set; }
        public string ckne_29 { get; set; }
        public string ckne_30 { get; set; }
        public string ckne_31 { get; set; }
        public string ckne_32 { get; set; }
        public string ckne_33 { get; set; }
        public string ckne_34 { get; set; }
        public string ckne_35 { get; set; }
        public DateTime ckne_date1 { get; set; }
        public DateTime ckne_date2 { get; set; }

        public string ckne_dd1 { get; set; }
        public string ckne_dd2 { get; set; }


    }
    public class ArabOrient
    {
        public int caonId { get; set; }
        public int caon_appId { get; set; }
        public string caon_status { get; set; }
        public int caon_madeby { get; set; }
        public string caon_witness { get; set; }
        public DateTime caon_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string caon_chk { get; set; }
        public string caon_1 { get; set; }
        public string caon_2 { get; set; }
        public string caon_3 { get; set; }
        public string caon_4 { get; set; }
        public string caon_5 { get; set; }
        public string caon_6 { get; set; }
        public string caon_7 { get; set; }
        public string caon_8 { get; set; }
        public string caon_9 { get; set; }
        public string caon_10 { get; set; }
        public string caon_11 { get; set; }
        public string caon_12 { get; set; }
        public string caon_13 { get; set; }
        public string caon_14 { get; set; }
        public string caon_15 { get; set; }
        public string caon_16 { get; set; }
        public string caon_17 { get; set; }
        public string caon_18 { get; set; }
        public string caon_19 { get; set; }
        public string caon_20 { get; set; }
        public string caon_21 { get; set; }
        public DateTime caon_22 { get; set; }

        public string caon_dd22 { get; set; }


    }
    public class EmiratesDental
    {
        public int emdnId { get; set; }
        public int emdn_appId { get; set; }
        public string emdn_status { get; set; }
        public int emdn_madeby { get; set; }
        public string emdn_witness { get; set; }
        public DateTime emdn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string emdn_chk { get; set; }
        public string emdn_1 { get; set; }
        public string emdn_2 { get; set; }
        public string emdn_3 { get; set; }
        public string emdn_4 { get; set; }
        public string emdn_5 { get; set; }
        public string emdn_6 { get; set; }
        public string emdn_7 { get; set; }
        public string emdn_8 { get; set; }
        public string emdn_9 { get; set; }
        public string emdn_10 { get; set; }
        public string emdn_11 { get; set; }
        public string emdn_12 { get; set; }
        public string emdn_13 { get; set; }
        public string emdn_14 { get; set; }
        public string emdn_15 { get; set; }
        public string emdn_16 { get; set; }
        public string emdn_17 { get; set; }
        public string emdn_18 { get; set; }
        public string emdn_19 { get; set; }
        public string emdn_20 { get; set; }
        public string emdn_21 { get; set; }
        public string emdn_22 { get; set; }
        public string emdn_23 { get; set; }
        public string emdn_24 { get; set; }
        public string emdn_25 { get; set; }
        public string emdn_26 { get; set; }
        public string emdn_27 { get; set; }
        public string emdn_28 { get; set; }
        public string emdn_29 { get; set; }
        public string emdn_30 { get; set; }
        public string emdn_31 { get; set; }
        public string emdn_32 { get; set; }
        public string emdn_33 { get; set; }
        public string emdn_34 { get; set; }
        public string emdn_35 { get; set; }
    }
    public class MednetTakaful
    {
        public int cmtnId { get; set; }
        public int cmtn_appId { get; set; }
        public string cmtn_status { get; set; }
        public int cmtn_madeby { get; set; }
        public string cmtn_witness { get; set; }
        public DateTime cmtn_date_created { get; set; }

        public string cmtn_1 { get; set; }
        public string cmtn_2 { get; set; }
        public string cmtn_3 { get; set; }
        public string cmtn_4 { get; set; }
        public string cmtn_5 { get; set; }
        public string cmtn_6 { get; set; }
        public string cmtn_7 { get; set; }
        public string cmtn_chk { get; set; }
        public DateTime cmtn_date1 { get; set; }
        public DateTime cmtn_date2 { get; set; }
        public DateTime cmtn_date3 { get; set; }
        public string cmtn_d21 { get; set; }
        public string cmtn_d22 { get; set; }
        public string cmtn_d23 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class NASQIC
    {
        public int nasqId { get; set; }
        public int nasq_appId { get; set; }
        public string nasq_status { get; set; }
        public int nasq_madeby { get; set; }
        public string nasq_witness { get; set; }
        public DateTime nasq_date_created { get; set; }

        public string nasq_1 { get; set; }
        public string nasq_2 { get; set; }
        public string nasq_3 { get; set; }
        public string nasq_4 { get; set; }
        public string nasq_5 { get; set; }
        public string nasq_6 { get; set; }
        public string nasq_7 { get; set; }
        public string nasq_8 { get; set; }
        public string nasq_9 { get; set; }
        public string nasq_10 { get; set; }
        public string nasq_11 { get; set; }
        public string nasq_12 { get; set; }
        public string nasq_13 { get; set; }
        public string nasq_14 { get; set; }
        public string nasq_15 { get; set; }
        public string nasq_16 { get; set; }
        public string nasq_17 { get; set; }
        public string nasq_18 { get; set; }
        public DateTime nasq_date1 { get; set; }
        public string nasq_d1 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class SAICO
    {
        public int sacnId { get; set; }
        public int sacn_appId { get; set; }
        public string sacn_status { get; set; }
        public int sacn_madeby { get; set; }
        public string sacn_witness { get; set; }
        public DateTime sacn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string complaints { get; set; }
        public string treatments { get; set; }
        public string lab_treatments { get; set; }
        public string diag_names { get; set; }
        public string diag_codes { get; set; }
        public string app_complaints { get; set; }

        
        public string sacn_checkbox { get; set; }
        public string sacn_1 { get; set; }
        public string sacn_2 { get; set; }
        public string sacn_3 { get; set; }
        public string sacn_4 { get; set; }
        public string sacn_5 { get; set; }
        public string sacn_6 { get; set; }
        public string sacn_7 { get; set; }
        public string sacn_8 { get; set; }
        public string sacn_9 { get; set; }
        public string sacn_10 { get; set; }
        public string sacn_11 { get; set; }
        public string sacn_12 { get; set; }
        public string sacn_13 { get; set; }
        public string sacn_14 { get; set; }
        public string sacn_15 { get; set; }
        public string sacn_16 { get; set; }
        public string sacn_17 { get; set; }
        public string sacn_18 { get; set; }
        public string sacn_19 { get; set; }
       
        public DateTime sacn_d1 { get; set; }
        public DateTime sacn_d2 { get; set; }
        public DateTime sacn_d3 { get; set; }
        public DateTime sacn_d4 { get; set; }
        public DateTime sacn_d5 { get; set; }
        public DateTime sacn_d6 { get; set; }       

        public string sacn_dd1 { get; set; }
        public string sacn_dd2 { get; set; }
        public string sacn_dd3 { get; set; }
        public string sacn_dd4 { get; set; }
        public string sacn_dd5 { get; set; }
        public string sacn_dd6 { get; set; }

    }
    public class Wamped
    {
        public int wapnId { get; set; }
        public int wapn_appId { get; set; }
        public string wapn_status { get; set; }
        public int wapn_madeby { get; set; }
        public string wapn_witness { get; set; }
        public DateTime wapn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
       
        public string wapn_checkbox { get; set; }
        public string wapn_1 { get; set; }
        public string wapn_2 { get; set; }
        public string wapn_3 { get; set; }
        public string wapn_4 { get; set; }
        public string wapn_5 { get; set; }
        public string wapn_6 { get; set; }
        public string wapn_7 { get; set; }
        public string wapn_8 { get; set; }
        public string wapn_9 { get; set; }
        public string wapn_10 { get; set; }
        public string wapn_11 { get; set; }
        public string wapn_12 { get; set; }
        public string wapn_13 { get; set; }
        public string wapn_14 { get; set; }
        public string wapn_15 { get; set; }
        public string wapn_16 { get; set; }
        public string wapn_17 { get; set; }
        public string wapn_18 { get; set; }
        public string wapn_19 { get; set; }
        public string wapn_20 { get; set; }
        public string wapn_21 { get; set; }
        public string wapn_22 { get; set; }
        public string wapn_23 { get; set; }
        public string wapn_24 { get; set; }
        public string wapn_25 { get; set; }
        public string wapn_26 { get; set; }
        public string wapn_27 { get; set; }
        public string wapn_28 { get; set; }
        public string wapn_29 { get; set; }
        public string wapn_30 { get; set; }
        public string wapn_31 { get; set; }
        public string wapn_32 { get; set; }
        public string wapn_33 { get; set; }
        public string wapn_34 { get; set; }
        public string wapn_35 { get; set; }
        public string wapn_36 { get; set; }
        public string wapn_37 { get; set; }
        public string wapn_38 { get; set; }
        public string wapn_39 { get; set; }
        public string wapn_40 { get; set; }
        public string wapn_41 { get; set; }
        public string wapn_42 { get; set; }
        public string wapn_43 { get; set; }
        public string wapn_44 { get; set; }
        public string wapn_45 { get; set; }
        public DateTime wapn_d1 { get; set; }
        public DateTime wapn_d2 { get; set; }
        public DateTime wapn_d3 { get; set; }

        public string wapn_dd1 { get; set; }
        public string wapn_dd2 { get; set; }
        public string wapn_dd3 { get; set; }
    }
    public class Orient
    {
        public int orntId { get; set; }
        public int ornt_appId { get; set; }
        public string ornt_status { get; set; }
        public int ornt_madeby { get; set; }
        public string ornt_witness { get; set; }
        public DateTime ornt_date_created { get; set; }

        public string ornt_1 { get; set; }
        public string ornt_2 { get; set; }
        public string ornt_3 { get; set; }
        public string ornt_4 { get; set; }
        public string ornt_5 { get; set; }
        public string ornt_6 { get; set; }
        public string ornt_7 { get; set; }
        public string ornt_chk { get; set; }
        public DateTime ornt_date1 { get; set; }
        public DateTime ornt_date2 { get; set; }
        public DateTime ornt_date3 { get; set; }
        public string ornt_d21 { get; set; }
        public string ornt_d22 { get; set; }
        public string ornt_d23 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class QICNAS
    {
        public int qnasId { get; set; }
        public int qnas_appId { get; set; }
        public string qnas_status { get; set; }
        public int qnas_madeby { get; set; }
        public string qnas_witness { get; set; }
        public DateTime qnas_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

       
        public string qnas_1 { get; set; }
        public string qnas_2 { get; set; }
        public string qnas_3 { get; set; }
        public string qnas_4 { get; set; }
        public string qnas_5 { get; set; }
        public string qnas_6 { get; set; }
        public string qnas_7 { get; set; }
        public string qnas_8 { get; set; }
        public string qnas_9 { get; set; }
        public string qnas_10 { get; set; }
        public string qnas_11 { get; set; }
        public string qnas_12 { get; set; }
        public string qnas_13 { get; set; }
        public string qnas_14 { get; set; }
        public string qnas_15 { get; set; }
        public string qnas_16 { get; set; }
        public string qnas_17 { get; set; }
        public string qnas_18 { get; set; }
        public string qnas_19 { get; set; }
        public string qnas_20 { get; set; }
        public string qnas_21 { get; set; }
        public DateTime qnas_date1 { get; set; }
        public string qnas_d1 { get; set; }
    }
    public class Gulfcare
    {
        public int gucnId { get; set; }
        public int gucn_appId { get; set; }
        public string gucn_status { get; set; }
        public int gucn_madeby { get; set; }
        public string gucn_witness { get; set; }
        public DateTime gucn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

       
        public string gucn_checkbox { get; set; }
        public string gucn_1 { get; set; }
        public string gucn_2 { get; set; }
        public string gucn_3 { get; set; }
        public string gucn_4 { get; set; }
        public string gucn_5 { get; set; }
        public string gucn_6 { get; set; }
        public string gucn_7 { get; set; }
        public string gucn_8 { get; set; }
        public string gucn_9 { get; set; }
        public string gucn_10 { get; set; }
        public string gucn_11 { get; set; }
        public string gucn_12 { get; set; }
        public string gucn_13 { get; set; }
        public string gucn_14 { get; set; }
        public string gucn_15 { get; set; }
        public string gucn_16 { get; set; }
        public string gucn_17 { get; set; }
        public string gucn_18 { get; set; }
        public string gucn_19 { get; set; }
        public string gucn_20 { get; set; }
        public string gucn_21 { get; set; }
        public string gucn_22 { get; set; }
        public string gucn_23 { get; set; }
        public string gucn_24 { get; set; }
        public string gucn_25 { get; set; }
        public string gucn_26 { get; set; }
        public string gucn_27 { get; set; }
        public string gucn_28 { get; set; }
        public string gucn_29 { get; set; }
        public string gucn_30 { get; set; }
        public string gucn_31 { get; set; }
        public string gucn_32 { get; set; }
        public string gucn_33 { get; set; }
        public string gucn_34 { get; set; }
        public string gucn_35 { get; set; }
        public string gucn_36 { get; set; }
        public string gucn_37 { get; set; }
        public string gucn_38 { get; set; }
        public string gucn_39 { get; set; }
        public string gucn_40 { get; set; }
        public string gucn_41 { get; set; }
        public string gucn_42 { get; set; }
        public string gucn_43 { get; set; }
    }
    public class Goldstar
    {
        public int cgsnId { get; set; }
        public int cgsn_appId { get; set; }
        public string cgsn_status { get; set; }
        public int cgsn_madeby { get; set; }
        public string cgsn_witness { get; set; }
        public DateTime cgsn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public string cgsn_checkbox { get; set; }
        public string cgsn_1 { get; set; }
        public string cgsn_2 { get; set; }
        public string cgsn_3 { get; set; }
        public string cgsn_4 { get; set; }
        public string cgsn_5 { get; set; }
        public string cgsn_6 { get; set; }
        public string cgsn_7 { get; set; }
        public string cgsn_8 { get; set; }
        public string cgsn_9 { get; set; }
        public string cgsn_10 { get; set; }
        public string cgsn_11 { get; set; }
        public string cgsn_12 { get; set; }
        public string cgsn_13 { get; set; }
        public string cgsn_14 { get; set; }
        public string cgsn_15 { get; set; }
        public string cgsn_16 { get; set; }
        public string cgsn_17 { get; set; }
        public string cgsn_18 { get; set; }
        public string cgsn_19 { get; set; }
        public string cgsn_20 { get; set; }
        public string cgsn_21 { get; set; }
        public string cgsn_22 { get; set; }
        public string cgsn_23 { get; set; }
        public string cgsn_24 { get; set; }
        public string cgsn_25 { get; set; }
        public string cgsn_26 { get; set; }
        public string cgsn_27 { get; set; }
        public string cgsn_28 { get; set; }
        public string cgsn_29 { get; set; }
        public string cgsn_30 { get; set; }
        public string cgsn_31 { get; set; }
    }
    public class HealthInternational
    {
        public int chinId { get; set; }
        public int chin_appId { get; set; }
        public string chin_status { get; set; }
        public int chin_madeby { get; set; }
        public string chin_witness { get; set; }
        public DateTime chin_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string chin_checkbox { get; set; }
        public string chin_1 { get; set; }
        public string chin_2 { get; set; }
        public string chin_3 { get; set; }
        public string chin_4 { get; set; }
        public string chin_5 { get; set; }
        public string chin_6 { get; set; }
        public string chin_7 { get; set; }
        public string chin_8 { get; set; }
        public string chin_9 { get; set; }
        public string chin_10 { get; set; }
        public string chin_11 { get; set; }
        public DateTime chin_date1 { get; set; }
        public DateTime chin_date2 { get; set; }
        public DateTime chin_date3 { get; set; }

        public string chin_dd1 { get; set; }
        public string chin_dd2 { get; set; }
        public string chin_dd3 { get; set; }
    }
    public class NasDental
    {
        public int cndnId { get; set; }
        public int cndn_appId { get; set; }
        public string cndn_status { get; set; }
        public int cndn_madeby { get; set; }
        public string cndn_witness { get; set; }
        public DateTime cndn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public string cndn_chk { get; set; }
        public string cndn_1 { get; set; }
        public string cndn_2 { get; set; }
        public string cndn_3 { get; set; }
        public string cndn_4 { get; set; }
        public string cndn_5 { get; set; }
        public string cndn_6 { get; set; }
        public string cndn_7 { get; set; }
    }

    public class NasPrescription
    {
        public int cnrnId { get; set; }
        public int cnrn_appId { get; set; }
        public string cnrn_status { get; set; }
        public int cnrn_madeby { get; set; }
        public string cnrn_witness { get; set; }
        public DateTime cnrn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public string cnrn_chk { get; set; }
        public string cnrn_1 { get; set; }
        public string cnrn_2 { get; set; }
        public string cnrn_3 { get; set; }
        public string cnrn_4 { get; set; }
        public string cnrn_5 { get; set; }
        public string cnrn_6 { get; set; }
    }

    public class OmanDental
    {
        public int codnId { get; set; }
        public int codn_appId { get; set; }
        public string codn_status { get; set; }
        public int codn_madeby { get; set; }
        public string codn_witness { get; set; }
        public DateTime codn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
        
        public string codn_checkbox { get; set; }
        public string codn_1 { get; set; }
        public string codn_2 { get; set; }
        public string codn_3 { get; set; }
        public string codn_4 { get; set; }
        public string codn_5 { get; set; }
        public string codn_6 { get; set; }
        public string codn_7 { get; set; }
        public string codn_8 { get; set; }
        public string codn_9 { get; set; }
        public string codn_10 { get; set; }
        public string codn_11 { get; set; }
        public string codn_12 { get; set; }
        public string codn_13 { get; set; }
        public string codn_14 { get; set; }
        public string codn_15 { get; set; }
        public string codn_16 { get; set; }
        public string codn_17 { get; set; }
        public string codn_18 { get; set; }
        public string codn_19 { get; set; }
        public string codn_20 { get; set; }
        public string codn_21 { get; set; }
        public string codn_22 { get; set; }
        public string codn_23 { get; set; }
        public string codn_24 { get; set; }
        public string codn_25 { get; set; }
        public string codn_26 { get; set; }
        public string codn_27 { get; set; }
        public string codn_28 { get; set; }
        public string codn_29 { get; set; }
        public string codn_30 { get; set; }
        public string codn_31 { get; set; }
        public string codn_32 { get; set; }
        public string codn_33 { get; set; }
        public string codn_34 { get; set; }
        public string codn_35 { get; set; }
        public string codn_36 { get; set; }
        public string codn_37 { get; set; }
        public string codn_38 { get; set; }
        public string codn_39 { get; set; }
        public string codn_40 { get; set; }
        public string codn_41 { get; set; }
        public string codn_42 { get; set; }
        public string codn_43 { get; set; }
        public string codn_44 { get; set; }
        public string codn_45 { get; set; }
        public string codn_46 { get; set; }
        public string codn_47 { get; set; }
        public string codn_48 { get; set; }
        public string codn_49 { get; set; }
        public string codn_50 { get; set; }
        public string codn_51 { get; set; }
        public string codn_52 { get; set; }
        public string codn_53 { get; set; }
        public string codn_54 { get; set; }
        public string codn_55 { get; set; }
        public string codn_56 { get; set; }
        public string codn_57 { get; set; }
        public string codn_58 { get; set; }
        public string codn_59 { get; set; }
        public string codn_60 { get; set; }
        public string codn_61 { get; set; }
        public string codn_62 { get; set; }
        public string codn_63 { get; set; }
        public string codn_64 { get; set; }
        public string codn_65 { get; set; }
        public string codn_66 { get; set; }
        public string codn_67 { get; set; }
        public DateTime codn_date1 { get; set; }

        public string codn_dd1 { get; set; }

    }
    public class ReimbursementFormsMain
    {
        public string SelectedOption { get; set; }
        // Other properties if needed
        // Reimbursement Forms Dropdowns
        [NotMapped]
        public List<CommonDDLFORMS> SelectedOptionList { get; set; }
    }

    public class NasDarAlTakaful
    {
        public int ndtnId { get; set; }
        public int ndtn_appId { get; set; }
        public string ndtn_status { get; set; }
        public int ndtn_madeby { get; set; }
        public string ndtn_witness { get; set; }
        public DateTime ndtn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }


        public string ndtn_checkbox { get; set; }
        public string ndtn_1 { get; set; }
        public string ndtn_2 { get; set; }
        public string ndtn_3 { get; set; }
        public string ndtn_4 { get; set; }
        public string ndtn_5 { get; set; }
        public string ndtn_6 { get; set; }
        public string ndtn_7 { get; set; }
        public string ndtn_8 { get; set; }
        public string ndtn_9 { get; set; }
        public string ndtn_10 { get; set; }
        public string ndtn_11 { get; set; }
        public string ndtn_12 { get; set; }
        public string ndtn_13 { get; set; }
        public string ndtn_14 { get; set; }
        public string ndtn_15 { get; set; }
        public string ndtn_16 { get; set; }
        public string ndtn_17 { get; set; }
        public string ndtn_18 { get; set; }
        public string ndtn_19 { get; set; }
        public string ndtn_20 { get; set; }
        public string ndtn_21 { get; set; }
        public string ndtn_22 { get; set; }
        public string ndtn_23 { get; set; }
        public string ndtn_24 { get; set; }
        public string ndtn_25 { get; set; }
        public string ndtn_26 { get; set; }
        public string ndtn_27 { get; set; }
        public string ndtn_28 { get; set; }
        public string ndtn_29 { get; set; }
        public string ndtn_30 { get; set; }
        public string ndtn_31 { get; set; }
        public string ndtn_32 { get; set; }
        public string ndtn_33 { get; set; }
        public string ndtn_34 { get; set; }
        public string ndtn_35 { get; set; }
        public string ndtn_36 { get; set; }
        public string ndtn_37 { get; set; }
        public string ndtn_38 { get; set; }
        public string ndtn_39 { get; set; }
        public string ndtn_40 { get; set; }
        public string ndtn_41 { get; set; }
        public string ndtn_42 { get; set; }
        public string ndtn_43 { get; set; }
    }

    public class OmanInsurance
    {
        public int cornId { get; set; }
        public int corn_appId { get; set; }
        public string corn_status { get; set; }
        public int corn_madeby { get; set; }
        public string corn_witness { get; set; }
        public DateTime corn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string corn_checkbox { get; set; }
        public string corn_1 { get; set; }
        public string corn_2 { get; set; }
        public string corn_3 { get; set; }
        public string corn_4 { get; set; }
        public string corn_5 { get; set; }
        public string corn_6 { get; set; }
        public string corn_7 { get; set; }
        public string corn_8 { get; set; }
        public string corn_9 { get; set; }
        public string corn_10 { get; set; }
        public string corn_11 { get; set; }
        public string corn_12 { get; set; }
        public string corn_13 { get; set; }
        public string corn_14 { get; set; }
        public string corn_15 { get; set; }
        public string corn_16 { get; set; }
        public string corn_17 { get; set; }
        public string corn_18 { get; set; }
        public string corn_19 { get; set; }
        public string corn_20 { get; set; }
        public string corn_21 { get; set; }
        public string corn_22 { get; set; }
        public string corn_23 { get; set; }
        public string corn_24 { get; set; }
        public string corn_25 { get; set; }
        public string corn_26 { get; set; }
        public string corn_27 { get; set; }
        public string corn_28 { get; set; }
        public string corn_29 { get; set; }
        public string corn_30 { get; set; }
        public string corn_31 { get; set; }
        public string corn_32 { get; set; }
        public string corn_33 { get; set; }
        public string corn_34 { get; set; }
        public string corn_35 { get; set; }
        public string corn_36 { get; set; }
        public string corn_37 { get; set; }
        public string corn_38 { get; set; }
        public string corn_39 { get; set; }
        public string corn_40 { get; set; }
        public string corn_41 { get; set; }
        public string corn_42 { get; set; }
        public string corn_43 { get; set; }
        public string corn_44 { get; set; }
        public string corn_45 { get; set; }
        public string corn_46 { get; set; }
        public string corn_47 { get; set; }
        public string corn_48 { get; set; }
        public string corn_49 { get; set; }
        public string corn_50 { get; set; }
        public string corn_51 { get; set; }
        public string corn_52 { get; set; }
        public string corn_53 { get; set; }
        public string corn_54 { get; set; }
        public string corn_55 { get; set; }
        public string corn_56 { get; set; }
        public string corn_57 { get; set; }
        public string corn_58 { get; set; }
        public string corn_59 { get; set; }
        public string corn_60 { get; set; }
        public string corn_61 { get; set; }
        public string corn_62 { get; set; }
        public string corn_63 { get; set; }
        public string corn_64 { get; set; }
        public string corn_65 { get; set; }
        public string corn_66 { get; set; }
        public string corn_67 { get; set; }
        public DateTime corn_date1 { get; set; }

        public string corn_dd1 { get; set; }

    }

    public class Union
    {
        public int curnId { get; set; }
        public int curn_appId { get; set; }
        public string curn_status { get; set; }
        public int curn_madeby { get; set; }
        public string curn_witness { get; set; }
        public DateTime curn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string curn_checkbox { get; set; }
        public string curn_1 { get; set; }
        public string curn_2 { get; set; }
        public string curn_3 { get; set; }
        public string curn_4 { get; set; }
        public string curn_5 { get; set; }
        public string curn_6 { get; set; }
        public string curn_7 { get; set; }
        public string curn_8 { get; set; }
        public string curn_9 { get; set; }
        public string curn_10 { get; set; }
        public string curn_11 { get; set; }
        public string curn_12 { get; set; }
        public string curn_13 { get; set; }
        public string curn_14 { get; set; }
        public string curn_15 { get; set; }
        public string curn_16 { get; set; }
        public string curn_17 { get; set; }
        public string curn_18 { get; set; }
        public string curn_19 { get; set; }
        public string curn_20 { get; set; }
        public string curn_21 { get; set; }
        public string curn_22 { get; set; }
        public string curn_23 { get; set; }
        public string curn_24 { get; set; }
        public string curn_25 { get; set; }
        public string curn_26 { get; set; }
        public string curn_27 { get; set; }
        public string curn_28 { get; set; }
        public string curn_29 { get; set; }
        public string curn_30 { get; set; }
        public string curn_31 { get; set; }
        public string curn_32 { get; set; }
        public string curn_33 { get; set; }
        public string curn_34 { get; set; }
        public string curn_35 { get; set; }
        public string curn_36 { get; set; }
        public string curn_37 { get; set; }
        public string curn_38 { get; set; }
        public string curn_39 { get; set; }
        public string curn_40 { get; set; }
        public DateTime curn_date1 { get; set; }
        public DateTime curn_date2 { get; set; }
        public DateTime curn_date3 { get; set; }

        public string curn_dd1 { get; set; }
        public string curn_dd2 { get; set; }
        public string curn_dd3 { get; set; }
    }
    public class NextcareOrient
    {
        public int cnonId { get; set; }
        public int cnon_appId { get; set; }
        public string cnon_status { get; set; }
        public int cnon_madeby { get; set; }
        public string cnon_witness { get; set; }
        public DateTime cnon_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cnon_checkbox { get; set; }
        public string cnon_1 { get; set; }
        public string cnon_2 { get; set; }
        public string cnon_3 { get; set; }
        public string cnon_4 { get; set; }
        public string cnon_5 { get; set; }
        public string cnon_6 { get; set; }
        public string cnon_7 { get; set; }
        public string cnon_8 { get; set; }
        public string cnon_9 { get; set; }
        public string cnon_10 { get; set; }
        public string cnon_11 { get; set; }
        public string cnon_12 { get; set; }
        public string cnon_13 { get; set; }
        public string cnon_14 { get; set; }
        public string cnon_15 { get; set; }
        public string cnon_16 { get; set; }
        public string cnon_17 { get; set; }
        public string cnon_18 { get; set; }
        public string cnon_19 { get; set; }
        public string cnon_20 { get; set; }
        public string cnon_21 { get; set; }
        public string cnon_22 { get; set; }
        public string cnon_23 { get; set; }
        public string cnon_24 { get; set; }
        public string cnon_25 { get; set; }
        public string cnon_26 { get; set; }
        public string cnon_27 { get; set; }
        public string cnon_28 { get; set; }
        public string cnon_29 { get; set; }
        public string cnon_30 { get; set; }
        public string cnon_31 { get; set; }
        public string cnon_32 { get; set; }
        public string cnon_33 { get; set; }
        public string cnon_34 { get; set; }
        public string cnon_35 { get; set; }
        public string cnon_36 { get; set; }
        public string cnon_37 { get; set; }
        public string cnon_38 { get; set; }
        public string cnon_39 { get; set; }
        public string cnon_40 { get; set; }
        public string cnon_41 { get; set; }
        public DateTime cnon_date1 { get; set; }
        public DateTime cnon_date2 { get; set; }
        public DateTime cnon_date3 { get; set; }

        public string cnon_dd1 { get; set; }
        public string cnon_dd2 { get; set; }
        public string cnon_dd3 { get; set; }
    }
    public class NextcareMajid
    {
        public int cnmnId { get; set; }
        public int cnmn_appId { get; set; }
        public string cnmn_status { get; set; }
        public int cnmn_madeby { get; set; }
        public string cnmn_witness { get; set; }
        public DateTime cnmn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cnmn_checkbox { get; set; }
        public string cnmn_1 { get; set; }
        public string cnmn_2 { get; set; }
        public string cnmn_3 { get; set; }
        public string cnmn_4 { get; set; }
        public string cnmn_5 { get; set; }
        public string cnmn_6 { get; set; }
        public string cnmn_7 { get; set; }
        public string cnmn_8 { get; set; }
        public string cnmn_9 { get; set; }
        public string cnmn_10 { get; set; }
        public string cnmn_11 { get; set; }
        public string cnmn_12 { get; set; }
        public string cnmn_13 { get; set; }
        public string cnmn_14 { get; set; }
        public string cnmn_15 { get; set; }
        public string cnmn_16 { get; set; }
        public string cnmn_17 { get; set; }
        public string cnmn_18 { get; set; }
        public string cnmn_19 { get; set; }
        public string cnmn_20 { get; set; }
        public string cnmn_21 { get; set; }
        public string cnmn_22 { get; set; }
        public string cnmn_23 { get; set; }
        public string cnmn_24 { get; set; }
        public string cnmn_25 { get; set; }
        public string cnmn_26 { get; set; }
        public string cnmn_27 { get; set; }
        public string cnmn_28 { get; set; }
        public string cnmn_29 { get; set; }
        public string cnmn_30 { get; set; }
        public string cnmn_31 { get; set; }
        public string cnmn_32 { get; set; }
        public string cnmn_33 { get; set; }
        public string cnmn_34 { get; set; }
        public string cnmn_35 { get; set; }
        public string cnmn_36 { get; set; }
        public string cnmn_37 { get; set; }
        public string cnmn_38 { get; set; }
        public string cnmn_39 { get; set; }
        public string cnmn_40 { get; set; }
        public string cnmn_41 { get; set; }
        public DateTime cnmn_date1 { get; set; }
        public DateTime cnmn_date2 { get; set; }
        public DateTime cnmn_date3 { get; set; }

        public string cnmn_dd1 { get; set; }
        public string cnmn_dd2 { get; set; }
        public string cnmn_dd3 { get; set; }
    }

    public class NextcareAsnic
    {
        public int cnanId { get; set; }
        public int cnan_appId { get; set; }
        public string cnan_status { get; set; }
        public int cnan_madeby { get; set; }
        public string cnan_witness { get; set; }
        public DateTime cnan_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cnan_checkbox { get; set; }
        public string cnan_1 { get; set; }
        public string cnan_2 { get; set; }
        public string cnan_3 { get; set; }
        public string cnan_4 { get; set; }
        public string cnan_5 { get; set; }
        public string cnan_6 { get; set; }
        public string cnan_7 { get; set; }
        public string cnan_8 { get; set; }
        public string cnan_9 { get; set; }
        public string cnan_10 { get; set; }
        public string cnan_11 { get; set; }
        public string cnan_12 { get; set; }
        public string cnan_13 { get; set; }
        public string cnan_14 { get; set; }
        public string cnan_15 { get; set; }
        public string cnan_16 { get; set; }
        public string cnan_17 { get; set; }
        public string cnan_18 { get; set; }
        public string cnan_19 { get; set; }
        public string cnan_20 { get; set; }
        public string cnan_21 { get; set; }
        public string cnan_22 { get; set; }
        public string cnan_23 { get; set; }
        public string cnan_24 { get; set; }
        public string cnan_25 { get; set; }
        public string cnan_26 { get; set; }
        public string cnan_27 { get; set; }
        public string cnan_28 { get; set; }
        public string cnan_29 { get; set; }
        public string cnan_30 { get; set; }
        public string cnan_31 { get; set; }
        public string cnan_32 { get; set; }
        public string cnan_33 { get; set; }
        public string cnan_34 { get; set; }
        public string cnan_35 { get; set; }
        public string cnan_36 { get; set; }
        public string cnan_37 { get; set; }
        public string cnan_38 { get; set; }
        public string cnan_39 { get; set; }
        public string cnan_40 { get; set; }
        public string cnan_41 { get; set; }
        public DateTime cnan_date1 { get; set; }
        public DateTime cnan_date2 { get; set; }
        public DateTime cnan_date3 { get; set; }

        public string cnan_dd1 { get; set; }
        public string cnan_dd2 { get; set; }
        public string cnan_dd3 { get; set; }
    }
    public class Maxcare
    {
        public int maxnId { get; set; }
        public int maxn_appId { get; set; }
        public string maxn_status { get; set; }
        public int maxn_madeby { get; set; }
        public string maxn_witness { get; set; }
        public DateTime maxn_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string maxn_checkbox { get; set; }
        public string maxn_1 { get; set; }
        public string maxn_2 { get; set; }
        public string maxn_3 { get; set; }
        public string maxn_4 { get; set; }
        public string maxn_5 { get; set; }
        public string maxn_6 { get; set; }
        public string maxn_7 { get; set; }
        public string maxn_8 { get; set; }
        public string maxn_9 { get; set; }
        public string maxn_10 { get; set; }
        public string maxn_11 { get; set; }
        public string maxn_12 { get; set; }
        public string maxn_13 { get; set; }
        public string maxn_14 { get; set; }
        public string maxn_15 { get; set; }
        public string maxn_16 { get; set; }
        public string maxn_17 { get; set; }
        public string maxn_18 { get; set; }
        public string maxn_19 { get; set; }
        public string maxn_20 { get; set; }
        public string maxn_21 { get; set; }
        public string maxn_22 { get; set; }
        public string maxn_23 { get; set; }
        public string maxn_24 { get; set; }
        public string maxn_25 { get; set; }
        public string maxn_26 { get; set; }
        public string maxn_27 { get; set; }
        public string maxn_28 { get; set; }
        public string maxn_29 { get; set; }
        public string maxn_30 { get; set; }
        public string maxn_31 { get; set; }
        public string maxn_32 { get; set; }
        public string maxn_33 { get; set; }
        public string maxn_34 { get; set; }
        public string maxn_35 { get; set; }
        public string maxn_36 { get; set; }
        public string maxn_37 { get; set; }
        public string maxn_38 { get; set; }
        public string maxn_39 { get; set; }
        public string maxn_40 { get; set; }
        public string maxn_41 { get; set; }
        public DateTime maxn_date1 { get; set; }
        public DateTime maxn_date2 { get; set; }
        public DateTime maxn_date3 { get; set; }

        public string maxn_dd1 { get; set; }
        public string maxn_dd2 { get; set; }
        public string maxn_dd3 { get; set; }
    }
    public class Cowan
    {
        public int cownId { get; set; }
        public int cown_appId { get; set; }
        public string cown_status { get; set; }
        public int cown_madeby { get; set; }
        public string cown_witness { get; set; }
        public DateTime cown_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cown_chk { get; set; }
        public string cown_1 { get; set; }
        public string cown_2 { get; set; }
        public string cown_3 { get; set; }
        public string cown_4 { get; set; }
        public string cown_5 { get; set; }
        public string cown_6 { get; set; }
        public string cown_7 { get; set; }
        public string cown_8 { get; set; }
        public string cown_9 { get; set; }
        public string cown_10 { get; set; }
        public string cown_11 { get; set; }
        public string cown_12 { get; set; }
        public string cown_13 { get; set; }
        public string cown_14 { get; set; }
        public string cown_15 { get; set; }
        public string cown_16 { get; set; }
        public string cown_17 { get; set; }
        public string cown_18 { get; set; }
        public string cown_19 { get; set; }
        public string cown_20 { get; set; }
        public string cown_21 { get; set; }
        public string cown_22 { get; set; }
        public string cown_23 { get; set; }
        public string cown_24 { get; set; }
        public string cown_25 { get; set; }
        public string cown_26 { get; set; }
        public string cown_27 { get; set; }
        public string cown_28 { get; set; }
        public string cown_29 { get; set; }
        public string cown_30 { get; set; }
        public string cown_31 { get; set; }
        public string cown_32 { get; set; }
        public string cown_33 { get; set; }
        public string cown_34 { get; set; }
        public string cown_35 { get; set; }
        public string cown_36 { get; set; }
        public string cown_37 { get; set; }
        public string cown_38 { get; set; }
        public string cown_39 { get; set; }
        public string cown_40 { get; set; }
        public string cown_41 { get; set; }
        public string cown_42 { get; set; }
        public string cown_43 { get; set; }
        public string cown_44 { get; set; }
        public string cown_45 { get; set; }
        public string cown_46 { get; set; }
        public string cown_47 { get; set; }
        public string cown_48 { get; set; }
        public string cown_49 { get; set; }
        public string cown_50 { get; set; }
        public string cown_51 { get; set; }
        public string cown_52 { get; set; }
        public string cown_53 { get; set; }
        public string cown_54 { get; set; }
        public string cown_55 { get; set; }
        public string cown_56 { get; set; }
        public string cown_57 { get; set; }
        public string cown_58 { get; set; }
        public string cown_59 { get; set; }
        public string cown_60 { get; set; }
        public string cown_61 { get; set; }
        public string cown_62 { get; set; }
        public string cown_63 { get; set; }
        public string cown_64 { get; set; }
        public string cown_65 { get; set; }
        public string cown_66 { get; set; }
        public string cown_67 { get; set; }
        public string cown_68 { get; set; }
        public string cown_69 { get; set; }
        public string cown_70 { get; set; }
        public string cown_71 { get; set; }
        public DateTime cown_date1 { get; set; }
        public DateTime cown_date2 { get; set; }
        public DateTime cown_date3 { get; set; }
        public DateTime cown_date4 { get; set; }
        public DateTime cown_date5 { get; set; }
        public DateTime cown_date6 { get; set; }
        public DateTime cown_date7 { get; set; }
        public DateTime cown_date8 { get; set; }
        public DateTime cown_date9 { get; set; }
        public DateTime cown_date10 { get; set; }
        public DateTime cown_date11 { get; set; }
        public DateTime cown_date12 { get; set; }

        public string cown_dd1 { get; set; }
        public string cown_dd2 { get; set; }
        public string cown_dd3 { get; set; }
        public string cown_dd4 { get; set; }
        public string cown_dd5 { get; set; }
        public string cown_dd6 { get; set; }
        public string cown_dd7 { get; set; }
        public string cown_dd8 { get; set; }
        public string cown_dd9 { get; set; }
        public string cown_dd10 { get; set; }
        public string cown_dd11 { get; set; }
        public string cown_dd12 { get; set; }


    }
    public class NASNLGIC
    {
        public int nalnId { get; set; }
        public int naln_appId { get; set; }
        public string naln_status { get; set; }
        public int naln_madeby { get; set; }
        public string naln_witness { get; set; }
        public DateTime naln_date_created { get; set; }

        public string naln_1 { get; set; }
        public string naln_2 { get; set; }
        public string naln_3 { get; set; }
        public string naln_4 { get; set; }
        public string naln_5 { get; set; }
        public string naln_6 { get; set; }
        public string naln_7 { get; set; }
        public string naln_8 { get; set; }
        public string naln_9 { get; set; }
        public string naln_10 { get; set; }
        public string naln_11 { get; set; }
        public string naln_12 { get; set; }
        public string naln_13 { get; set; }
        public string naln_14 { get; set; }
        public string naln_15 { get; set; }
        public string naln_16 { get; set; }
        public string naln_17 { get; set; }
        public string naln_18 { get; set; }
        public DateTime naln_date1 { get; set; }
        public string naln_d1 { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
    public class EmiratesInsurance
    {
        public int cceId { get; set; }
        public int cce_appId { get; set; }
        public string cce_status { get; set; }
        public int cce_madeby { get; set; }
        public string cce_witness { get; set; }
        public DateTime cce_date_created { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cce_chk { get; set; }
        public string cce_1 { get; set; }
        public string cce_2 { get; set; }
        public string cce_3 { get; set; }
        public string cce_4 { get; set; }
        public string cce_5 { get; set; }
        public string cce_6 { get; set; }
        public string cce_7 { get; set; }
        public string cce_8 { get; set; }
        public string cce_9 { get; set; }
        public string cce_10 { get; set; }
        public string cce_11 { get; set; }
        public string cce_12 { get; set; }
        public string cce_13 { get; set; }
        public string cce_14 { get; set; }
        public string cce_15 { get; set; }
        public string cce_16 { get; set; }
        public string cce_17 { get; set; }
        public string cce_18 { get; set; }
        public string cce_19 { get; set; }
        public string cce_20 { get; set; }
        public string cce_21 { get; set; }
        public DateTime cce_date1 { get; set; }
        public DateTime cce_date2 { get; set; }
        public DateTime cce_date3 { get; set; }
        public DateTime cce_date4 { get; set; }
        public DateTime cce_date5 { get; set; }
        public DateTime cce_date6 { get; set; }
        public DateTime cce_date7 { get; set; }

        public string cce_dd1 { get; set; }
        public string cce_dd2 { get; set; }
        public string cce_dd3 { get; set; }
        public string cce_dd4 { get; set; }
        public string cce_dd5 { get; set; }
        public string cce_dd6 { get; set; }
        public string cce_dd7 { get; set; }
    }
    public class Mapfre
    {
        public int maprId { get; set; }
        public int mapr_appId { get; set; }
        public string mapr_status { get; set; }
        public int mapr_madeby { get; set; }
        public string mapr_witness { get; set; }
        public DateTime mapr_date_created { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string mapr_chk { get; set; }
        public string mapr_1 { get; set; }
        public string mapr_2 { get; set; }
        public string mapr_3 { get; set; }
        public string mapr_4 { get; set; }
        public string mapr_5 { get; set; }
        public string mapr_6 { get; set; }
        public string mapr_7 { get; set; }
        public string mapr_8 { get; set; }
        public string mapr_9 { get; set; }
        public string mapr_10 { get; set; }
        public string mapr_11 { get; set; }
        public string mapr_12 { get; set; }
        public string mapr_13 { get; set; }
        public string mapr_14 { get; set; }
        public string mapr_15 { get; set; }
        public string mapr_16 { get; set; }
        public string mapr_17 { get; set; }
        public string mapr_18 { get; set; }
        public string mapr_19 { get; set; }
        public string mapr_20 { get; set; }
        public DateTime mapr_date1 { get; set; }
        public DateTime mapr_date2 { get; set; }
        public DateTime mapr_date3 { get; set; }
        public DateTime mapr_date4 { get; set; }
        public DateTime mapr_date5 { get; set; }
        public DateTime mapr_date6 { get; set; }
        public DateTime mapr_date7 { get; set; }
        public DateTime mapr_date8 { get; set; }

        public string mapr_dd1 { get; set; }
        public string mapr_dd2 { get; set; }
        public string mapr_dd3 { get; set; }
        public string mapr_dd4 { get; set; }
        public string mapr_dd5 { get; set; }
        public string mapr_dd6 { get; set; }
        public string mapr_dd7 { get; set; }
        public string mapr_dd8 { get; set; }
    }

    public class AAFIYA
    {
        public int ccaId { get; set; }
        public int cca_appId { get; set; }
        public string cca_status { get; set; }
        public int cca_madeby { get; set; }
        public string cca_witness { get; set; }
        public DateTime cca_date_created { get; set; }

        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }

        public string cca_chk { get; set; }
        public string cca_1 { get; set; }
        public string cca_2 { get; set; }
        public string cca_3 { get; set; }
        public string cca_4 { get; set; }
        public string cca_5 { get; set; }
        public string cca_6 { get; set; }
        public string cca_7 { get; set; }
        public string cca_8 { get; set; }
        public string cca_9 { get; set; }
        public string cca_10 { get; set; }
        public string cca_11 { get; set; }
        public string cca_12 { get; set; }
        public string cca_13 { get; set; }
        public string cca_14 { get; set; }
        public string cca_15 { get; set; }
        public string cca_16 { get; set; }
        public string cca_17 { get; set; }
        public string cca_18 { get; set; }
        public string cca_19 { get; set; }
        public string cca_20 { get; set; }
        public DateTime cca_date1 { get; set; }

        public string cca_dd1 { get; set; }
    }
}
