using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class AudiologyNote
    {
        public int audId { get; set; }
        public int aud_appId { get; set; }
        public string aud_clinic { get; set; }
        public string aud_ampli { get; set; }
        public string aud_style { get; set; }
        public string aud_needs { get; set; }
        public string aud_tests { get; set; }
        public string aud_results { get; set; }
        public string aud_manage { get; set; }
        
        public string aud_status { get; set; }
        public int aud_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }

    }

    public class Vestibular
    {
        public int eeId { get; set; }
        public int ee_appId { get; set; }
        public string ee_pinr { get; set; }
        public string ee_pinl { get; set; }
        public string ee_pregr { get; set; }
        public string ee_pregl { get; set; }
        public string ee_postr { get; set; }
        public string ee_postl { get; set; }
        public string ee_eacr { get; set; }
        public string ee_eacl { get; set; }
        public string ee_tympr { get; set; }
        public string ee_tympl { get; set; }
        public string ee_masr { get; set; }
        public string ee_masl { get; set; }
        public string ee_facr { get; set; }
        public string ee_facl { get; set; }
        public string ee_nysr { get; set; }
        public string ee_nysl { get; set; }
        public string ee_eustr { get; set; }
        public string ee_eustl { get; set; }
        public string ee_notes { get; set; }

        public string ee_status { get; set; }
        public int ee_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }

    }
    public class EarMicroscopy
    {
        public int emrId { get; set; }
        public int emr_appId { get; set; }
        public string emr_notes { get; set; }
  
        public string emr_status { get; set; }
        public int emr_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }

    }
    public class NasalEndoscopy
    {
        public int nerId { get; set; }
        public int ner_appId { get; set; }
        public string ner_notes { get; set; }

        public string ner_status { get; set; }
        public int ner_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }

    }
    public class FibropticLaryngoscopy
    {
        public int flrId { get; set; }
        public int flr_appId { get; set; }
        public string flr_notes { get; set; }

        public string flr_status { get; set; }
        public int flr_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }

    }
    public class ENTExamThroat
    {
        public int etId { get; set; }
        public int et_appId { get; set; }
        public string et_lip { get; set; }
        public string et_base { get; set; }
        public string et_vest { get; set; }
        public string et_valle { get; set; }
        public string et_teeth { get; set; }
        public string et_epig { get; set; }
        public string et_oral { get; set; }
        public string et_false { get; set; }
        public string et_hard { get; set; }
        public string et_vent { get; set; }
        public string et_tong { get; set; }
        public string et_aryt { get; set; }
        public string et_retro { get; set; }
        public string et_arye { get; set; }
        public string et_tons { get; set; }
        public string et_vocal { get; set; }
        public string et_apill { get; set; }
        public string et_acomm { get; set; }
        public string et_ppill { get; set; }
        public string et_pcomm { get; set; }
        public string et_orop { get; set; }
        public string et_subg { get; set; }
        public string et_pyrif { get; set; }
        public string et_paro { get; set; }
        public string et_postc { get; set; }
        public string et_postp { get; set; }
        public string et_thy { get; set; }
        public string et_trac { get; set; }
        public string et_lary { get; set; }
        public string et_lymp { get; set; }
        public string et_others { get; set; }
        public string et_notes { get; set; }

        public string et_status { get; set; }
        public int et_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }

    }
    public class ENTExamNose
    {
        public int enId { get; set; }
        public int en_appId { get; set; }
        public string en_ext { get; set; }
        public string en_vest { get; set; }
        public string en_floor { get; set; }
        public string en_sept { get; set; }
        public string en_nasal { get; set; }
        public string en_imear { get; set; }
        public string en_imeal { get; set; }
        public string en_iturbr { get; set; }
        public string en_iturbl { get; set; }
        public string en_mmear { get; set; }
        public string en_mmeal { get; set; }
        public string en_mturbr { get; set; }
        public string en_mturbl { get; set; }
        public string en_smear { get; set; }
        public string en_smeal { get; set; }
        public string en_sturbr { get; set; }
        public string en_sturbl { get; set; }
        public string en_choane { get; set; }
        public string en_nasop { get; set; }
        public string en_eust { get; set; }
        public string en_rose { get; set; }
        public string en_lymp { get; set; }
        public string en_other { get; set; }
        public string en_frontr { get; set; }
        public string en_frontl { get; set; }
        public string en_maxilr { get; set; }
        public string en_maxill { get; set; }
        public string en_ethmr { get; set; }
        public string en_ethml { get; set; }
        public string en_notes { get; set; }
        
        public string en_status { get; set; }
        public int en_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }

    }
}
