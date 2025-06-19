using BusinessEntities.EMR;
using BusinessEntities.Lists;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class Examination
    {

        public static List<BusinessEntities.EMR.Examination> GetAllExamination(int? appId)
        {
            List<BusinessEntities.EMR.Examination> sclist = new List<BusinessEntities.EMR.Examination>();
            DataTable dt = DataAccessLayer.EMR.Examination.GetAllExamination(appId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.EMR.Examination ex = new BusinessEntities.EMR.Examination();
                    BusinessEntities.EMR.GeneralExamination genexam = new BusinessEntities.EMR.GeneralExamination();

                    if (!string.IsNullOrEmpty(dr["geId"].ToString()))
                    {
                        genexam.geId = Convert.ToInt32(dr["geId"]);
                        genexam.ge_appId = Convert.ToInt32(dr["ge_appId"]);
                        genexam.ge_1 = dr["ge_1"].ToString();
                        genexam.ge_2 = dr["ge_2"].ToString();
                        genexam.ge_3 = dr["ge_3"].ToString();
                        genexam.ge_4 = dr["ge_4"].ToString();
                        genexam.ge_5 = dr["ge_5"].ToString();
                        genexam.ge_6 = dr["ge_6"].ToString();
                        genexam.ge_7 = dr["ge_7"].ToString();
                        genexam.ge_8 = dr["ge_8"].ToString();
                        genexam.ge_9 = dr["ge_9"].ToString();
                        genexam.ge_10 = dr["ge_10"].ToString();
                        genexam.ge_11 = dr["ge_11"].ToString();
                        genexam.ge_12 = dr["ge_12"].ToString();
                        genexam.ge_13 = dr["ge_13"].ToString();
                        genexam.ge_14 = dr["ge_14"].ToString();
                        genexam.ge_15 = dr["ge_15"].ToString();
                        genexam.ge_16 = dr["ge_16"].ToString();
                        genexam.ge_17 = dr["ge_17"].ToString();
                        genexam.ge_18 = dr["ge_18"].ToString();
                        genexam.ge_19 = dr["ge_19"].ToString();
                        genexam.ge_20 = dr["ge_20"].ToString();
                        genexam.ge_21 = dr["ge_21"].ToString();
                        genexam.ge_22 = dr["ge_22"].ToString();
                        genexam.ge_23 = dr["ge_23"].ToString();
                        genexam.ge_24 = dr["ge_24"].ToString();
                        genexam.ge_25 = dr["ge_25"].ToString();
                        genexam.ge_1_type = dr["ge_1_type"].ToString();
                        genexam.ge_2_type = dr["ge_2_type"].ToString();
                        genexam.ge_3_type = dr["ge_3_type"].ToString();
                        genexam.ge_4_type = dr["ge_4_type"].ToString();
                        genexam.ge_5_type = dr["ge_5_type"].ToString();
                        genexam.ge_6_type = dr["ge_6_type"].ToString();
                        genexam.ge_7_type = dr["ge_7_type"].ToString();
                        genexam.ge_8_type = dr["ge_8_type"].ToString();
                        genexam.ge_9_type = dr["ge_9_type"].ToString();
                        genexam.ge_10_type = dr["ge_10_type"].ToString();
                        genexam.ge_11_type = dr["ge_11_type"].ToString();
                        genexam.ge_12_type = dr["ge_12_type"].ToString();
                        genexam.ge_13_type = dr["ge_13_type"].ToString();
                        genexam.ge_14_type = dr["ge_14_type"].ToString();
                        genexam.ge_15_type = dr["ge_15_type"].ToString();
                        genexam.ge_16_type = dr["ge_16_type"].ToString();
                        genexam.ge_17_type = dr["ge_17_type"].ToString();
                        genexam.ge_18_type = dr["ge_18_type"].ToString();
                        genexam.ge_19_type = dr["ge_19_type"].ToString();
                        genexam.ge_20_type = dr["ge_20_type"].ToString();
                        genexam.ge_21_type = dr["ge_21_type"].ToString();
                        genexam.ge_22_type = dr["ge_22_type"].ToString();
                        genexam.ge_23_type = dr["ge_23_type"].ToString();
                        genexam.ge_24_type = dr["ge_24_type"].ToString();
                        genexam.ge_25_type = dr["ge_25_type"].ToString();
                    }
                    BusinessEntities.EMR.CardioVascular cardio = new BusinessEntities.EMR.CardioVascular();
                    if (!string.IsNullOrEmpty(dr["cvId"].ToString()))
                    {
                        cardio.cvId = Convert.ToInt32(dr["cvId"]);
                        cardio.cv_appId = Convert.ToInt32(dr["cv_appId"]);
                        cardio.cv_1 = dr["cv_1"].ToString();
                        cardio.cv_2 = dr["cv_2"].ToString();
                        cardio.cv_3 = dr["cv_3"].ToString();
                        cardio.cv_4 = dr["cv_4"].ToString();
                        cardio.cv_5 = dr["cv_5"].ToString();
                        cardio.cv_6 = dr["cv_6"].ToString();
                        cardio.cv_1_type = dr["cv_1_type"].ToString();
                        cardio.cv_2_type = dr["cv_2_type"].ToString();
                        cardio.cv_3_type = dr["cv_3_type"].ToString();
                        cardio.cv_4_type = dr["cv_4_type"].ToString();
                        cardio.cv_5_type = dr["cv_5_type"].ToString();
                        cardio.cv_6_type = dr["cv_6_type"].ToString();
                        cardio.cv_status = dr["cv_status"].ToString();
                    }

                    BusinessEntities.EMR.RespiratorySystem respiratory = new BusinessEntities.EMR.RespiratorySystem();
                    if (!string.IsNullOrEmpty(dr["resId"].ToString()))
                    {
                        respiratory.resId = Convert.ToInt32(dr["resId"]);
                        respiratory.res_appId = Convert.ToInt32(dr["res_appId"]);
                        respiratory.res_1 = dr["res_1"].ToString();
                        respiratory.res_2 = dr["res_2"].ToString();
                        respiratory.res_3 = dr["res_3"].ToString();
                        respiratory.res_4 = dr["res_4"].ToString();
                        respiratory.res_5 = dr["res_5"].ToString();
                        respiratory.res_6 = dr["res_6"].ToString();
                        respiratory.res_7 = dr["res_7"].ToString();
                        respiratory.res_8 = dr["res_8"].ToString();
                        respiratory.res_1_type = dr["res_1_type"].ToString();
                        respiratory.res_2_type = dr["res_2_type"].ToString();
                        respiratory.res_3_type = dr["res_3_type"].ToString();
                        respiratory.res_4_type = dr["res_4_type"].ToString();
                        respiratory.res_5_type = dr["res_5_type"].ToString();
                        respiratory.res_6_type = dr["res_6_type"].ToString();
                        respiratory.res_7_type = dr["res_7_type"].ToString();
                        respiratory.res_8_type = dr["res_8_type"].ToString();
                        respiratory.res_status = dr["res_status"].ToString();
                    }

                    BusinessEntities.EMR.MusculoSkeletal musculo = new BusinessEntities.EMR.MusculoSkeletal();
                    if (!string.IsNullOrEmpty(dr["msId"].ToString()))
                    {
                        musculo.msId = Convert.ToInt32(dr["msId"]);
                        musculo.ms_appId = Convert.ToInt32(dr["ms_appId"]);
                        musculo.ms_1 = dr["ms_1"].ToString();
                        musculo.ms_2 = dr["ms_2"].ToString();
                        musculo.ms_3 = dr["ms_3"].ToString();
                        musculo.ms_4 = dr["ms_4"].ToString();
                        musculo.ms_5 = dr["ms_5"].ToString();
                        musculo.ms_6 = dr["ms_6"].ToString();
                        musculo.ms_1_type = dr["ms_1_type"].ToString();
                        musculo.ms_2_type = dr["ms_2_type"].ToString();
                        musculo.ms_3_type = dr["ms_3_type"].ToString();
                        musculo.ms_4_type = dr["ms_4_type"].ToString();
                        musculo.ms_5_type = dr["ms_5_type"].ToString();
                        musculo.ms_6_type = dr["ms_6_type"].ToString();
                        musculo.ms_status = dr["ms_status"].ToString();
                    }

                    BusinessEntities.EMR.CentralNervous nervous = new BusinessEntities.EMR.CentralNervous();
                    if (!string.IsNullOrEmpty(dr["cnId"].ToString()))
                    {
                        nervous.cnId = Convert.ToInt32(dr["cnId"]);
                        nervous.cn_appId = Convert.ToInt32(dr["cn_appId"]);
                        nervous.cn_1 = dr["cn_1"].ToString();
                        nervous.cn_2 = dr["cn_2"].ToString();
                        nervous.cn_3 = dr["cn_3"].ToString();
                        nervous.cn_4 = dr["cn_4"].ToString();
                        nervous.cn_5 = dr["cn_5"].ToString();
                        nervous.cn_6 = dr["cn_6"].ToString();
                        nervous.cn_7 = dr["cn_7"].ToString();
                        nervous.cn_8 = dr["cn_8"].ToString();
                        nervous.cn_9 = dr["cn_9"].ToString();
                        nervous.cn_1_type = dr["cn_1_type"].ToString();
                        nervous.cn_2_type = dr["cn_2_type"].ToString();
                        nervous.cn_3_type = dr["cn_3_type"].ToString();
                        nervous.cn_4_type = dr["cn_4_type"].ToString();
                        nervous.cn_5_type = dr["cn_5_type"].ToString();
                        nervous.cn_6_type = dr["cn_6_type"].ToString();
                        nervous.cn_7_type = dr["cn_7_type"].ToString();
                        nervous.cn_8_type = dr["cn_8_type"].ToString();
                        nervous.cn_9_type = dr["cn_9_type"].ToString();
                        nervous.cn_status = dr["cn_status"].ToString();
                    }

                    BusinessEntities.EMR.GastroIntestinal intestinal =new BusinessEntities.EMR.GastroIntestinal();
                    if (!string.IsNullOrEmpty(dr["giId"].ToString()))
                    {
                        intestinal.giId = Convert.ToInt32(dr["giId"]);
                        intestinal.gi_appId = Convert.ToInt32(dr["gi_appId"]);
                        intestinal.gi_1 = dr["gi_1"].ToString();
                        intestinal.gi_2 = dr["gi_2"].ToString();
                        intestinal.gi_3 = dr["gi_3"].ToString();
                        intestinal.gi_4 = dr["gi_4"].ToString();
                        intestinal.gi_5 = dr["gi_5"].ToString();
                        intestinal.gi_6 = dr["gi_6"].ToString();
                        intestinal.gi_7 = dr["gi_7"].ToString();
                        intestinal.gi_8 = dr["gi_8"].ToString();
                        intestinal.gi_9 = dr["gi_9"].ToString();
                        intestinal.gi_10 = dr["gi_10"].ToString();
                        intestinal.gi_11 = dr["gi_11"].ToString();
                        intestinal.gi_12 = dr["gi_12"].ToString();
                        intestinal.gi_13 = dr["gi_13"].ToString();
                        intestinal.gi_14 = dr["gi_14"].ToString();
                        intestinal.gi_1_type = dr["gi_1_type"].ToString();
                        intestinal.gi_2_type = dr["gi_2_type"].ToString();
                        intestinal.gi_3_type = dr["gi_3_type"].ToString();
                        intestinal.gi_4_type = dr["gi_4_type"].ToString();
                        intestinal.gi_5_type = dr["gi_5_type"].ToString();
                        intestinal.gi_6_type = dr["gi_6_type"].ToString();
                        intestinal.gi_7_type = dr["gi_7_type"].ToString();
                        intestinal.gi_8_type = dr["gi_8_type"].ToString();
                        intestinal.gi_9_type = dr["gi_9_type"].ToString();
                        intestinal.gi_10_type = dr["gi_10_type"].ToString();
                        intestinal.gi_11_type = dr["gi_11_type"].ToString();
                        intestinal.gi_12_type = dr["gi_12_type"].ToString();
                        intestinal.gi_13_type = dr["gi_13_type"].ToString();
                        intestinal.gi_14_type = dr["gi_14_type"].ToString();
                        intestinal.gi_status = dr["gi_status"].ToString();
                    }

                    BusinessEntities.EMR.GenitoUrinary urinary =new BusinessEntities.EMR.GenitoUrinary();
                    if (!string.IsNullOrEmpty(dr["genId"].ToString()))
                    {
                        urinary.genId = Convert.ToInt32(dr["genId"]);
                        urinary.gen_appId = Convert.ToInt32(dr["gen_appId"]);
                        urinary.gen_1 = dr["gen_1"].ToString();
                        urinary.gen_2 = dr["gen_2"].ToString();
                        urinary.gen_1_type = dr["gen_1_type"].ToString();
                        urinary.gen_2_type = dr["gen_2_type"].ToString();
                        urinary.gen_status = dr["gen_status"].ToString();
                    }
                    ex.genex = genexam;
                    ex.card = cardio;
                    ex.resp = respiratory;
                    ex.musc = musculo;
                    ex.nerv = nervous;
                    ex.gast = intestinal;
                    ex.geni = urinary;
                    sclist.Add(ex);
                    
                }
            }
            return sclist;
        }


        public static bool InsertUpdateExamination(BusinessEntities.EMR.Examination data, int madeby)
        {
            data.genex.ge_1 = string.IsNullOrEmpty(data.genex.ge_1) ? string.Empty : data.genex.ge_1;
            data.genex.ge_2 = string.IsNullOrEmpty(data.genex.ge_2) ? string.Empty : data.genex.ge_2;
            data.genex.ge_3 = string.IsNullOrEmpty(data.genex.ge_3) ? string.Empty : data.genex.ge_3;
            data.genex.ge_4 = string.IsNullOrEmpty(data.genex.ge_4) ? string.Empty : data.genex.ge_4;
            data.genex.ge_5 = string.IsNullOrEmpty(data.genex.ge_5) ? string.Empty : data.genex.ge_5;
            data.genex.ge_6 = string.IsNullOrEmpty(data.genex.ge_6) ? string.Empty : data.genex.ge_6;
            data.genex.ge_7 = string.IsNullOrEmpty(data.genex.ge_7) ? string.Empty : data.genex.ge_7;
            data.genex.ge_8 = string.IsNullOrEmpty(data.genex.ge_8) ? string.Empty : data.genex.ge_8;
            data.genex.ge_9 = string.IsNullOrEmpty(data.genex.ge_9) ? string.Empty : data.genex.ge_9;
            data.genex.ge_10 = string.IsNullOrEmpty(data.genex.ge_10) ? string.Empty : data.genex.ge_10;
            data.genex.ge_11 = string.IsNullOrEmpty(data.genex.ge_11) ? string.Empty : data.genex.ge_11;
            data.genex.ge_12 = string.IsNullOrEmpty(data.genex.ge_12) ? string.Empty : data.genex.ge_12;
            data.genex.ge_13 = string.IsNullOrEmpty(data.genex.ge_13) ? string.Empty : data.genex.ge_13;
            data.genex.ge_14 = string.IsNullOrEmpty(data.genex.ge_14) ? string.Empty : data.genex.ge_14;
            data.genex.ge_15 = string.IsNullOrEmpty(data.genex.ge_15) ? string.Empty : data.genex.ge_15;
            data.genex.ge_16 = string.IsNullOrEmpty(data.genex.ge_16) ? string.Empty : data.genex.ge_16;
            data.genex.ge_17 = string.IsNullOrEmpty(data.genex.ge_17) ? string.Empty : data.genex.ge_17;
            data.genex.ge_18 = string.IsNullOrEmpty(data.genex.ge_18) ? string.Empty : data.genex.ge_18;
            data.genex.ge_19 = string.IsNullOrEmpty(data.genex.ge_19) ? string.Empty : data.genex.ge_19;
            data.genex.ge_20 = string.IsNullOrEmpty(data.genex.ge_20) ? string.Empty : data.genex.ge_20;
            data.genex.ge_21 = string.IsNullOrEmpty(data.genex.ge_21) ? string.Empty : data.genex.ge_21;
            data.genex.ge_22 = string.IsNullOrEmpty(data.genex.ge_22) ? string.Empty : data.genex.ge_22;
            data.genex.ge_23 = string.IsNullOrEmpty(data.genex.ge_23) ? string.Empty : data.genex.ge_23;
            data.genex.ge_24 = string.IsNullOrEmpty(data.genex.ge_24) ? string.Empty : data.genex.ge_24;
            data.genex.ge_25 = string.IsNullOrEmpty(data.genex.ge_25) ? string.Empty : data.genex.ge_25;
            data.genex.ge_1_type = string.IsNullOrEmpty(data.genex.ge_1_type) ? string.Empty : data.genex.ge_1_type;
            data.genex.ge_2_type = string.IsNullOrEmpty(data.genex.ge_2_type) ? string.Empty : data.genex.ge_2_type;
            data.genex.ge_3_type = string.IsNullOrEmpty(data.genex.ge_3_type) ? string.Empty : data.genex.ge_3_type;
            data.genex.ge_4_type = string.IsNullOrEmpty(data.genex.ge_4_type) ? string.Empty : data.genex.ge_4_type;
            data.genex.ge_5_type = string.IsNullOrEmpty(data.genex.ge_5_type) ? string.Empty : data.genex.ge_5_type;
            data.genex.ge_6_type = string.IsNullOrEmpty(data.genex.ge_6_type) ? string.Empty : data.genex.ge_6_type;
            data.genex.ge_7_type = string.IsNullOrEmpty(data.genex.ge_7_type) ? string.Empty : data.genex.ge_7_type;
            data.genex.ge_8_type = string.IsNullOrEmpty(data.genex.ge_8_type) ? string.Empty : data.genex.ge_8_type;
            data.genex.ge_9_type = string.IsNullOrEmpty(data.genex.ge_9_type) ? string.Empty : data.genex.ge_9_type;
            data.genex.ge_10_type = string.IsNullOrEmpty(data.genex.ge_10_type) ? string.Empty : data.genex.ge_10_type;
            data.genex.ge_11_type = string.IsNullOrEmpty(data.genex.ge_11_type) ? string.Empty : data.genex.ge_11_type;
            data.genex.ge_12_type = string.IsNullOrEmpty(data.genex.ge_12_type) ? string.Empty : data.genex.ge_12_type;
            data.genex.ge_13_type = string.IsNullOrEmpty(data.genex.ge_13_type) ? string.Empty : data.genex.ge_13_type;
            data.genex.ge_14_type = string.IsNullOrEmpty(data.genex.ge_14_type) ? string.Empty : data.genex.ge_14_type;
            data.genex.ge_15_type = string.IsNullOrEmpty(data.genex.ge_15_type) ? string.Empty : data.genex.ge_15_type;
            data.genex.ge_16_type = string.IsNullOrEmpty(data.genex.ge_16_type) ? string.Empty : data.genex.ge_16_type;
            data.genex.ge_17_type = string.IsNullOrEmpty(data.genex.ge_17_type) ? string.Empty : data.genex.ge_17_type;
            data.genex.ge_18_type = string.IsNullOrEmpty(data.genex.ge_18_type) ? string.Empty : data.genex.ge_18_type;
            data.genex.ge_19_type = string.IsNullOrEmpty(data.genex.ge_19_type) ? string.Empty : data.genex.ge_19_type;
            data.genex.ge_20_type = string.IsNullOrEmpty(data.genex.ge_20_type) ? string.Empty : data.genex.ge_20_type;
            data.genex.ge_21_type = string.IsNullOrEmpty(data.genex.ge_21_type) ? string.Empty : data.genex.ge_21_type;
            data.genex.ge_22_type = string.IsNullOrEmpty(data.genex.ge_22_type) ? string.Empty : data.genex.ge_22_type;
            data.genex.ge_23_type = string.IsNullOrEmpty(data.genex.ge_23_type) ? string.Empty : data.genex.ge_23_type;
            data.genex.ge_24_type = string.IsNullOrEmpty(data.genex.ge_24_type) ? string.Empty : data.genex.ge_24_type;
            data.genex.ge_25_type = string.IsNullOrEmpty(data.genex.ge_25_type) ? string.Empty : data.genex.ge_25_type;

            data.card.cv_1 = string.IsNullOrEmpty(data.card.cv_1) ? string.Empty : data.card.cv_1;
            data.card.cv_2 = string.IsNullOrEmpty(data.card.cv_2) ? string.Empty : data.card.cv_2;
            data.card.cv_3 = string.IsNullOrEmpty(data.card.cv_3) ? string.Empty : data.card.cv_3;
            data.card.cv_4 = string.IsNullOrEmpty(data.card.cv_4) ? string.Empty : data.card.cv_4;
            data.card.cv_5 = string.IsNullOrEmpty(data.card.cv_5) ? string.Empty : data.card.cv_5;
            data.card.cv_6 = string.IsNullOrEmpty(data.card.cv_6) ? string.Empty : data.card.cv_6;
            data.card.cv_1_type = string.IsNullOrEmpty(data.card.cv_1_type) ? string.Empty : data.card.cv_1_type;
            data.card.cv_2_type = string.IsNullOrEmpty(data.card.cv_2_type) ? string.Empty : data.card.cv_2_type;
            data.card.cv_3_type = string.IsNullOrEmpty(data.card.cv_3_type) ? string.Empty : data.card.cv_3_type;
            data.card.cv_4_type = string.IsNullOrEmpty(data.card.cv_4_type) ? string.Empty : data.card.cv_4_type;
            data.card.cv_5_type = string.IsNullOrEmpty(data.card.cv_5_type) ? string.Empty : data.card.cv_5_type;
            data.card.cv_6_type = string.IsNullOrEmpty(data.card.cv_6_type) ? string.Empty : data.card.cv_6_type;

            data.nerv.cn_1 = string.IsNullOrEmpty(data.nerv.cn_1) ? string.Empty : data.nerv.cn_1;
            data.nerv.cn_2 = string.IsNullOrEmpty(data.nerv.cn_2) ? string.Empty : data.nerv.cn_2;
            data.nerv.cn_3 = string.IsNullOrEmpty(data.nerv.cn_3) ? string.Empty : data.nerv.cn_3;
            data.nerv.cn_4 = string.IsNullOrEmpty(data.nerv.cn_4) ? string.Empty : data.nerv.cn_4;
            data.nerv.cn_5 = string.IsNullOrEmpty(data.nerv.cn_5) ? string.Empty : data.nerv.cn_5;
            data.nerv.cn_6 = string.IsNullOrEmpty(data.nerv.cn_6) ? string.Empty : data.nerv.cn_6;
            data.nerv.cn_7 = string.IsNullOrEmpty(data.nerv.cn_7) ? string.Empty : data.nerv.cn_7;
            data.nerv.cn_8 = string.IsNullOrEmpty(data.nerv.cn_8) ? string.Empty : data.nerv.cn_8;
            data.nerv.cn_9 = string.IsNullOrEmpty(data.nerv.cn_9) ? string.Empty : data.nerv.cn_9;
            data.nerv.cn_1_type = string.IsNullOrEmpty(data.nerv.cn_1_type) ? string.Empty : data.nerv.cn_1_type;
            data.nerv.cn_2_type = string.IsNullOrEmpty(data.nerv.cn_2_type) ? string.Empty : data.nerv.cn_2_type;
            data.nerv.cn_3_type = string.IsNullOrEmpty(data.nerv.cn_3_type) ? string.Empty : data.nerv.cn_3_type;
            data.nerv.cn_4_type = string.IsNullOrEmpty(data.nerv.cn_4_type) ? string.Empty : data.nerv.cn_4_type;
            data.nerv.cn_5_type = string.IsNullOrEmpty(data.nerv.cn_5_type) ? string.Empty : data.nerv.cn_5_type;
            data.nerv.cn_6_type = string.IsNullOrEmpty(data.nerv.cn_6_type) ? string.Empty : data.nerv.cn_6_type;
            data.nerv.cn_7_type = string.IsNullOrEmpty(data.nerv.cn_7_type) ? string.Empty : data.nerv.cn_7_type;
            data.nerv.cn_8_type = string.IsNullOrEmpty(data.nerv.cn_8_type) ? string.Empty : data.nerv.cn_8_type;
            data.nerv.cn_9_type = string.IsNullOrEmpty(data.nerv.cn_9_type) ? string.Empty : data.nerv.cn_9_type;

            data.gast.gi_1 = string.IsNullOrEmpty(data.gast.gi_1) ? string.Empty : data.gast.gi_1;
            data.gast.gi_2 = string.IsNullOrEmpty(data.gast.gi_2) ? string.Empty : data.gast.gi_2;
            data.gast.gi_3 = string.IsNullOrEmpty(data.gast.gi_3) ? string.Empty : data.gast.gi_3;
            data.gast.gi_4 = string.IsNullOrEmpty(data.gast.gi_4) ? string.Empty : data.gast.gi_4;
            data.gast.gi_5 = string.IsNullOrEmpty(data.gast.gi_5) ? string.Empty : data.gast.gi_5;
            data.gast.gi_6 = string.IsNullOrEmpty(data.gast.gi_6) ? string.Empty : data.gast.gi_6;
            data.gast.gi_7 = string.IsNullOrEmpty(data.gast.gi_7) ? string.Empty : data.gast.gi_7;
            data.gast.gi_8 = string.IsNullOrEmpty(data.gast.gi_8) ? string.Empty : data.gast.gi_8;
            data.gast.gi_9 = string.IsNullOrEmpty(data.gast.gi_9) ? string.Empty : data.gast.gi_9;
            data.gast.gi_10 = string.IsNullOrEmpty(data.gast.gi_10) ? string.Empty : data.gast.gi_10;
            data.gast.gi_11 = string.IsNullOrEmpty(data.gast.gi_11) ? string.Empty : data.gast.gi_11;
            data.gast.gi_12 = string.IsNullOrEmpty(data.gast.gi_12) ? string.Empty : data.gast.gi_12;
            data.gast.gi_13 = string.IsNullOrEmpty(data.gast.gi_13) ? string.Empty : data.gast.gi_13;
            data.gast.gi_14 = string.IsNullOrEmpty(data.gast.gi_14) ? string.Empty : data.gast.gi_14;
            data.gast.gi_1_type = string.IsNullOrEmpty(data.gast.gi_1_type) ? string.Empty : data.gast.gi_1_type;
            data.gast.gi_2_type = string.IsNullOrEmpty(data.gast.gi_2_type) ? string.Empty : data.gast.gi_2_type;
            data.gast.gi_3_type = string.IsNullOrEmpty(data.gast.gi_3_type) ? string.Empty : data.gast.gi_3_type;
            data.gast.gi_4_type = string.IsNullOrEmpty(data.gast.gi_4_type) ? string.Empty : data.gast.gi_4_type;
            data.gast.gi_5_type = string.IsNullOrEmpty(data.gast.gi_5_type) ? string.Empty : data.gast.gi_5_type;
            data.gast.gi_6_type = string.IsNullOrEmpty(data.gast.gi_6_type) ? string.Empty : data.gast.gi_6_type;
            data.gast.gi_7_type = string.IsNullOrEmpty(data.gast.gi_7_type) ? string.Empty : data.gast.gi_7_type;
            data.gast.gi_8_type = string.IsNullOrEmpty(data.gast.gi_8_type) ? string.Empty : data.gast.gi_8_type;
            data.gast.gi_9_type = string.IsNullOrEmpty(data.gast.gi_9_type) ? string.Empty : data.gast.gi_9_type;
            data.gast.gi_10_type = string.IsNullOrEmpty(data.gast.gi_10_type) ? string.Empty : data.gast.gi_10_type;
            data.gast.gi_11_type = string.IsNullOrEmpty(data.gast.gi_11_type) ? string.Empty : data.gast.gi_11_type;
            data.gast.gi_12_type = string.IsNullOrEmpty(data.gast.gi_12_type) ? string.Empty : data.gast.gi_12_type;
            data.gast.gi_13_type = string.IsNullOrEmpty(data.gast.gi_13_type) ? string.Empty : data.gast.gi_13_type;
            data.gast.gi_14_type = string.IsNullOrEmpty(data.gast.gi_14_type) ? string.Empty : data.gast.gi_14_type;

            data.geni.gen_1 = string.IsNullOrEmpty(data.geni.gen_1) ? string.Empty : data.geni.gen_1;
            data.geni.gen_2 = string.IsNullOrEmpty(data.geni.gen_2) ? string.Empty : data.geni.gen_2;
            data.geni.gen_1_type = string.IsNullOrEmpty(data.geni.gen_1_type) ? string.Empty : data.geni.gen_1_type;
            data.geni.gen_2_type = string.IsNullOrEmpty(data.geni.gen_2_type) ? string.Empty : data.geni.gen_2_type;

            data.musc.ms_1 = string.IsNullOrEmpty(data.musc.ms_1) ? string.Empty : data.musc.ms_1;
            data.musc.ms_2 = string.IsNullOrEmpty(data.musc.ms_2) ? string.Empty : data.musc.ms_2;
            data.musc.ms_3 = string.IsNullOrEmpty(data.musc.ms_3) ? string.Empty : data.musc.ms_3;
            data.musc.ms_4 = string.IsNullOrEmpty(data.musc.ms_4) ? string.Empty : data.musc.ms_4;
            data.musc.ms_5 = string.IsNullOrEmpty(data.musc.ms_5) ? string.Empty : data.musc.ms_5;
            data.musc.ms_6 = string.IsNullOrEmpty(data.musc.ms_6) ? string.Empty : data.musc.ms_6;
            data.musc.ms_1_type = string.IsNullOrEmpty(data.musc.ms_1_type) ? string.Empty : data.musc.ms_1_type;
            data.musc.ms_2_type = string.IsNullOrEmpty(data.musc.ms_2_type) ? string.Empty : data.musc.ms_2_type;
            data.musc.ms_3_type = string.IsNullOrEmpty(data.musc.ms_3_type) ? string.Empty : data.musc.ms_3_type;
            data.musc.ms_4_type = string.IsNullOrEmpty(data.musc.ms_4_type) ? string.Empty : data.musc.ms_4_type;
            data.musc.ms_5_type = string.IsNullOrEmpty(data.musc.ms_5_type) ? string.Empty : data.musc.ms_5_type;
            data.musc.ms_6_type = string.IsNullOrEmpty(data.musc.ms_6_type) ? string.Empty : data.musc.ms_6_type;

            data.resp.res_1 = string.IsNullOrEmpty(data.resp.res_1) ? string.Empty : data.resp.res_1;
            data.resp.res_2 = string.IsNullOrEmpty(data.resp.res_2) ? string.Empty : data.resp.res_2;
            data.resp.res_3 = string.IsNullOrEmpty(data.resp.res_3) ? string.Empty : data.resp.res_3;
            data.resp.res_4 = string.IsNullOrEmpty(data.resp.res_4) ? string.Empty : data.resp.res_4;
            data.resp.res_5 = string.IsNullOrEmpty(data.resp.res_5) ? string.Empty : data.resp.res_5;
            data.resp.res_6 = string.IsNullOrEmpty(data.resp.res_6) ? string.Empty : data.resp.res_6;
            data.resp.res_7 = string.IsNullOrEmpty(data.resp.res_7) ? string.Empty : data.resp.res_7;
            data.resp.res_8 = string.IsNullOrEmpty(data.resp.res_8) ? string.Empty : data.resp.res_8;
            data.resp.res_1_type = string.IsNullOrEmpty(data.resp.res_1_type) ? string.Empty : data.resp.res_1_type;
            data.resp.res_2_type = string.IsNullOrEmpty(data.resp.res_2_type) ? string.Empty : data.resp.res_2_type;
            data.resp.res_3_type = string.IsNullOrEmpty(data.resp.res_3_type) ? string.Empty : data.resp.res_3_type;
            data.resp.res_4_type = string.IsNullOrEmpty(data.resp.res_4_type) ? string.Empty : data.resp.res_4_type;
            data.resp.res_5_type = string.IsNullOrEmpty(data.resp.res_5_type) ? string.Empty : data.resp.res_5_type;
            data.resp.res_6_type = string.IsNullOrEmpty(data.resp.res_6_type) ? string.Empty : data.resp.res_6_type;
            data.resp.res_7_type = string.IsNullOrEmpty(data.resp.res_7_type) ? string.Empty : data.resp.res_7_type;
            data.resp.res_8_type = string.IsNullOrEmpty(data.resp.res_8_type) ? string.Empty : data.resp.res_8_type;

            return DataAccessLayer.EMR.Examination.InsertUpdateExamination(data, madeby);

        }

        public static int DeleteExamination(int geId, int resId, int cvId, int cnId, int giId, int genId, int msId, int madeby)
        {
            return DataAccessLayer.EMR.Examination.DeleteExamination(geId, resId, cvId, cnId, giId, genId, msId, madeby);
        }
    }
}
