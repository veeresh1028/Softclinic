using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class RevisionRequest
    {
        public int carr_Id { get; set; }
        public int carr_appId { get; set; }
        public string carr_e1 { get; set; }
        public string carr_e2 { get; set; }
        public string carr_e3 { get; set; }
        public string carr_e4 { get; set; }
        public string carr_e5 { get; set; }
        public string carr_e6 { get; set; }
        public string carr_e7 { get; set; }
        public string carr_checkbox { get; set; }
        public string carr_other { get; set; }
        public DateTime carr_date { get; set; }
        public DateTime carr_date_created { get; set; }
        public string carr_status { get; set; }
        public int carr_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
    public class FIMInstrument
    {
        public int cfim_Id { get; set; }
        public int cfim_appId { get; set; }
        public string cfim_a1 { get; set; } = "0";
        public string cfim_a2 { get; set; } = "0";
        public string cfim_a3 { get; set; } = "0";
        public string cfim_b1 { get; set; } = "0";
        public string cfim_b2 { get; set; } = "0";
        public string cfim_b3 { get; set; } = "0";
        public string cfim_c1 { get; set; } = "0";
        public string cfim_c2 { get; set; } = "0";
        public string cfim_c3 { get; set; } = "0";
        public string cfim_d1 { get; set; } = "0";
        public string cfim_d2 { get; set; } = "0";
        public string cfim_d3 { get; set; } = "0";
        public string cfim_e1 { get; set; } = "0";
        public string cfim_e2 { get; set; } = "0";
        public string cfim_e3 { get; set; } = "0";
        public string cfim_f1 { get; set; } = "0";
        public string cfim_f2 { get; set; } = "0";
        public string cfim_f3 { get; set; } = "0";
        public string cfim_g1 { get; set; } = "0";
        public string cfim_g2 { get; set; } = "0";
        public string cfim_g3 { get; set; } = "0";
        public string cfim_h1 { get; set; } = "0";
        public string cfim_h2 { get; set; } = "0";
        public string cfim_h3 { get; set; } = "0";
        public string cfim_i1 { get; set; } = "0";
        public string cfim_i2 { get; set; } = "0";
        public string cfim_i3 { get; set; } = "0";
        public string cfim_j1 { get; set; } = "0";
        public string cfim_j2 { get; set; } = "0";
        public string cfim_j3 { get; set; } = "0";
        public string cfim_k1 { get; set; } = "0";
        public string cfim_k2 { get; set; } = "0";
        public string cfim_k3 { get; set; } = "0";
        public string cfim_l1 { get; set; } = "0";
        public string cfim_l2 { get; set; } = "0";
        public string cfim_l3 { get; set; } = "0";
        public string cfim_m1 { get; set; } = "0";
        public string cfim_m2 { get; set; } = "0";
        public string cfim_m3 { get; set; } = "0";
        public string cfim_n1 { get; set; } = "0";
        public string cfim_n2 { get; set; } = "0";
        public string cfim_n3 { get; set; } = "0";
        public string cfim_o1 { get; set; } = "0";
        public string cfim_o2 { get; set; } = "0";
        public string cfim_o3 { get; set; } = "0";
        public string cfim_p1 { get; set; } = "0";
        public string cfim_p2 { get; set; } = "0";
        public string cfim_p3 { get; set; } = "0";
        public string cfim_q1 { get; set; } = "0";
        public string cfim_q2 { get; set; } = "0";
        public string cfim_q3 { get; set; } = "0";
        public string cfim_r1 { get; set; } = "0";
        public string cfim_r2 { get; set; } = "0";
        public string cfim_r3 { get; set; } = "0";
        public string cfim_mss1 { get; set; } = "0";
        public string cfim_mss2 { get; set; } = "0";
        public string cfim_mss3 { get; set; } = "0";
        public string cfim_css1 { get; set; } = "0";
        public string cfim_css2 { get; set; } = "0";
        public string cfim_css3 { get; set; } = "0";
        public string cfim_tfs1 { get; set; } = "0";
        public string cfim_tfs2 { get; set; } = "0";
        public string cfim_tfs3 { get; set; } = "0";

        public string cfim_comments { get; set; }
        public string cfim_witness { get; set; }
        public DateTime cfim_date { get; set; }
        public DateTime cfim_date_created { get; set; }
        public string cfim_status { get; set; }
        public int cfim_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

    public class MonthlyEvaluation
    {
        public int cme_Id { get; set; }
        public int cme_appId { get; set; }
        public string cme_checkbox { get; set; }
        public string cme_Imp { get; set; }
        public string cme_gmsCmt { get; set; }
        public string cme_fmsCmt { get; set; }
        public string cme_pmiCmt { get; set; }
        public string cme_wsCmt { get; set; }
        public string cme_csCmt { get; set; }
        public string cme_sisCmt { get; set; }
        public string cme_bssCmt { get; set; }
        public string cme_adlCmt { get; set; }
        public string cme_g1 { get; set; }
        public string cme_g2 { get; set; }
        public string cme_g3 { get; set; }
        public string cme_g4 { get; set; }
        public string cme_p1 { get; set; }
        public string cme_p2 { get; set; }
        public string cme_p3 { get; set; }
        public string cme_p4 { get; set; }
        public DateTime cme_date { get; set; }
        public DateTime cme_date_created { get; set; }
        public string cme_status { get; set; }
        public int cme_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }


    public class InitialTherapyScreening
    {
        public int cot_Id { get; set; }
        public int cot_appId { get; set; }
        public string cot_checkbox { get; set; }
        public string cot_txt_sib { get; set; }
        public string cot_txt_inf { get; set; }
        public string cot_txt1 { get; set; }
        public string cot_txt2 { get; set; }
        public string cot_txt3 { get; set; }
        public string cot_txt4 { get; set; }
        public string cot_txt5 { get; set; }
        public string cot_txt6 { get; set; }
        public string cot_txt7 { get; set; }
        public string cot_txt8 { get; set; }
        public string cot_txt9 { get; set; }
        public string cot_txt10 { get; set; }
        public string cot_txt11 { get; set; }
        public string cot_txt12 { get; set; }
        public string cot_txt13 { get; set; }
        public string cot_txt14 { get; set; }
        public string cot_txt15 { get; set; }
        public string cot_txt16 { get; set; }
        public string cot_txt17 { get; set; }
        public string cot_txt18 { get; set; }
        public DateTime cot_date { get; set; }
        public DateTime cot_date_created { get; set; }
        public string cot_status { get; set; }
        public int cot_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
    public class EvaluationMonthlyProgress
    {
        public int cpe_Id { get; set; }
        public int cpe_appId { get; set; }
        public string cpe_checkbox { get; set; }

        public string cpe_txt1 { get; set; }
        public string cpe_txt2 { get; set; }
        public string cpe_txt3 { get; set; }
        public string cpe_txt4 { get; set; }
        public string cpe_txt5 { get; set; }
        public string cpe_txt6 { get; set; }
        public string cpe_txt7 { get; set; }
        public string cpe_txt8 { get; set; }
        public string cpe_txt9 { get; set; }
        public string cpe_txt10 { get; set; }
        public string cpe_txt11 { get; set; }
        public string cpe_txt12 { get; set; }
        public string cpe_txt13 { get; set; }
        public string cpe_txt14 { get; set; }
        public string cpe_txt15 { get; set; }
        public string cpe_txt16 { get; set; }
        public string cpe_txt17 { get; set; }
        public string cpe_txt18 { get; set; }
        public string cpe_txt19 { get; set; }
        public string cpe_txt20 { get; set; }
        public string cpe_txt21 { get; set; }

        public string cpe_txt22 { get; set; }
        public string cpe_txt23 { get; set; }
        public string cpe_txt24 { get; set; }
        public string cpe_txt25 { get; set; }
        public string cpe_txt26 { get; set; }
        public string cpe_txt27 { get; set; }
        public string cpe_txt28 { get; set; }
        public string cpe_txt29 { get; set; }
        public string cpe_txt30 { get; set; }
        public string cpe_txt31 { get; set; }
        public string cpe_txt32 { get; set; }
        public string cpe_txt33 { get; set; }
        public string cpe_txt34 { get; set; }
        public string cpe_txt35 { get; set; }
        public string cpe_txt36 { get; set; }
        public string cpe_txt37 { get; set; }
        public string cpe_txt38 { get; set; }
        public string cpe_txt39 { get; set; }
        public string cpe_txt40 { get; set; }
        public string cpe_txt41 { get; set; }
        public string cpe_txt42 { get; set; }
        public string cpe_txt43 { get; set; }
        public string cpe_txt44 { get; set; }
        public string cpe_txt45 { get; set; }
        public string cpe_txt46 { get; set; }
        public string cpe_txt47 { get; set; }
        public string cpe_txt48 { get; set; }
        public string cpe_txt49 { get; set; }
        public string cpe_txt50 { get; set; }
        public string cpe_txt51 { get; set; }
        public string cpe_txt52 { get; set; }
        public string cpe_txt53 { get; set; }
        public string cpe_txt54 { get; set; }
        public string cpe_txt55 { get; set; }
        public string cpe_txt56 { get; set; }
        public string cpe_txt57 { get; set; }
        public string cpe_txt58 { get; set; }
        public string cpe_txt59 { get; set; }
        public string cpe_txt60 { get; set; }
        public string cpe_txt61 { get; set; }
        public string cpe_txt62 { get; set; }
        public string cpe_txt63 { get; set; }
        public string cpe_txt64 { get; set; }
        public string cpe_txt65 { get; set; }
        public string cpe_txt66 { get; set; }
        public string cpe_txt67 { get; set; }
        public string cpe_txt68 { get; set; }
        public string cpe_txt69 { get; set; }
        public string cpe_txt70 { get; set; }
        public string cpe_txt71 { get; set; }
        public string cpe_txt72 { get; set; }
        public string cpe_txt73 { get; set; }
        public string cpe_txt74 { get; set; }
        public string cpe_txt75 { get; set; }
        public string cpe_txt76 { get; set; }
        public string cpe_txt77 { get; set; }
        public string cpe_txt78 { get; set; }
        public string cpe_txt79 { get; set; }
        public string cpe_txt80 { get; set; }
        public string cpe_txt81 { get; set; }
        public string cpe_txt82 { get; set; }
        public string cpe_txt83 { get; set; }
        public string cpe_txt84 { get; set; }
        public string cpe_txt85 { get; set; }
        public string cpe_txt86 { get; set; }
        public string cpe_txt87 { get; set; }
        public string cpe_txt88 { get; set; }
        public string cpe_txt89 { get; set; }
        public string cpe_txt90 { get; set; }
        public string cpe_txt91 { get; set; }
        public string cpe_txt92 { get; set; }
        public string cpe_txt93 { get; set; }
        public string cpe_txt94 { get; set; }
        public string cpe_txt95 { get; set; }
        public string cpe_txt96 { get; set; }
        public string cpe_txt97 { get; set; }
        public string cpe_txt98 { get; set; }
        public string cpe_txt99 { get; set; }
        public string cpe_txt100 { get; set; }
        public string cpe_txt101 { get; set; }
        public string cpe_txt102 { get; set; }
        public string cpe_txt103 { get; set; }
        public string cpe_txt104 { get; set; }
        public string cpe_txt105 { get; set; }
        public string cpe_txt106 { get; set; }
        public string cpe_txt107 { get; set; }
        public string cpe_txt108 { get; set; }
        public string cpe_txt109 { get; set; }
        public string cpe_txt110 { get; set; }
        public string cpe_txt111 { get; set; }
        public string cpe_txt112 { get; set; }
        public string cpe_txt113 { get; set; }
        public string cpe_txt114 { get; set; }
        public string cpe_txt115 { get; set; }
        public string cpe_txt116 { get; set; }
        public string cpe_txt117 { get; set; }
        public string cpe_txt118 { get; set; }
        public string cpe_txt119 { get; set; }
        public string cpe_txt120 { get; set; }
        public string cpe_txt121 { get; set; }
        public string cpe_txt122 { get; set; }
        public string cpe_txt123 { get; set; }
        public string cpe_txt124 { get; set; }
        public string cpe_txt125 { get; set; }
        public string cpe_txt126 { get; set; }
        public string cpe_txt127 { get; set; }
        public string cpe_txt128 { get; set; }
        public string cpe_txt129 { get; set; }
        public string cpe_txt130 { get; set; }
        public string cpe_txt131 { get; set; }
        public string cpe_txt132 { get; set; }
        public string cpe_txt133 { get; set; }
        public string cpe_txt134 { get; set; }
        public string cpe_txt135 { get; set; }
        public string cpe_txt136 { get; set; }
        public string cpe_txt137 { get; set; }
        public string cpe_txt138 { get; set; }
        public string cpe_txt139 { get; set; }
        public string cpe_txt140 { get; set; }
        public string cpe_txt141 { get; set; }
        public string cpe_txt142 { get; set; }
        public string cpe_txt143 { get; set; }
        public string cpe_txt144 { get; set; }
        public string cpe_txt145 { get; set; }
        public string cpe_txt146 { get; set; }
        public string cpe_txt147 { get; set; }
        public string cpe_txt148 { get; set; }
        public string cpe_txt149 { get; set; }
        public string cpe_txt150 { get; set; }
        public string cpe_txt151 { get; set; }
        public string cpe_txt152 { get; set; }
        public string cpe_txt153 { get; set; }
        public string cpe_txt154 { get; set; }
        public string cpe_txt155 { get; set; }
        public string cpe_txt156 { get; set; }
        public string cpe_txt157 { get; set; }
        public string cpe_txt158 { get; set; }
        public string cpe_txt159 { get; set; }
        public string cpe_txt160 { get; set; }
        public string cpe_txt161 { get; set; }
        public string cpe_txt162 { get; set; }
        public string cpe_txt163 { get; set; }
        public string cpe_txt164 { get; set; }
        public string cpe_txt165 { get; set; }
        public string cpe_txt166 { get; set; }
        public string cpe_txt167 { get; set; }
        public string cpe_txt168 { get; set; }
        public string cpe_txt169 { get; set; }
        public string cpe_txt170 { get; set; }
        public string cpe_txt171 { get; set; }
        public string cpe_txt172 { get; set; }
        public string cpe_txt173 { get; set; }
        public string cpe_txt174 { get; set; }
        public string cpe_txt175 { get; set; }
        public string cpe_txt176 { get; set; }
        public string cpe_txt177 { get; set; }
        public string cpe_txt178 { get; set; }
        public string cpe_txt179 { get; set; }
        public string cpe_txt180 { get; set; }
        public string cpe_txt181 { get; set; }
        public string cpe_txt182 { get; set; }
        public string cpe_txt183 { get; set; }
        public string cpe_txt184 { get; set; }
        public string cpe_txt185 { get; set; }
        public string cpe_txt186 { get; set; }
        public string cpe_txt187 { get; set; }
        public string cpe_txt188 { get; set; }
        public string cpe_txt189 { get; set; }
        public string cpe_txt190 { get; set; }
        public string cpe_txt191 { get; set; }
        public string cpe_txt192 { get; set; }
        public string cpe_txt193 { get; set; }
        public string cpe_txt194 { get; set; }
        public string cpe_txt195 { get; set; }
        public string cpe_txt196 { get; set; }
        public string cpe_txt197 { get; set; }
        public string cpe_txt198 { get; set; }
        public string cpe_txt199 { get; set; }
        public string cpe_txt200 { get; set; }
        public string cpe_txt201 { get; set; }
        public string cpe_txt202 { get; set; }
        public string cpe_txt203 { get; set; }
        public string cpe_txt204 { get; set; }
        public string cpe_txt205 { get; set; }
        public string cpe_txt206 { get; set; }
        public string cpe_txt207 { get; set; }
        public string cpe_txt208 { get; set; }
        public string cpe_txt209 { get; set; }
        public string cpe_txt210 { get; set; }
        public string cpe_txt211 { get; set; }
        public string cpe_txt212 { get; set; }
        public string cpe_txt213 { get; set; }
        public string cpe_txt214 { get; set; }
        public string cpe_txt215 { get; set; }
        public string cpe_txt216 { get; set; }

        public DateTime cpe_date { get; set; }
        public DateTime cpe_date_created { get; set; }
        public string cpe_status { get; set; }
        public int cpe_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

}
