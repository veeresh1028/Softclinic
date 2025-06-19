using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class Examination
    {

        public static DataTable GetAllExamination(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Examination_select_all_info");
               
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
        public static bool InsertUpdateExamination(BusinessEntities.EMR.Examination data,int madeby)
        {
            
            bool isInserted = false;
            bool isDone1 = false;
            bool isDone2 = false;
            bool isDone3 = false;
            bool isDone4 = false;
            bool isDone5 = false;
            bool isDone6 = false;

            BusinessEntities.EMR.GeneralExamination genexam = new BusinessEntities.EMR.GeneralExamination();
            genexam.geId = data.genex.geId;
            genexam.ge_appId = data.genex.ge_appId;
            genexam.ge_1 = data.genex.ge_1;
            genexam.ge_2 = data.genex.ge_2;
            genexam.ge_3 = data.genex.ge_3;
            genexam.ge_4 = data.genex.ge_4;
            genexam.ge_5 = data.genex.ge_5;
            genexam.ge_6 = data.genex.ge_6;
            genexam.ge_7 = data.genex.ge_7;
            genexam.ge_8 = data.genex.ge_8;
            genexam.ge_9 = data.genex.ge_9;
            genexam.ge_10 = data.genex.ge_10;
            genexam.ge_11 = data.genex.ge_11;
            genexam.ge_12 = data.genex.ge_12;
            genexam.ge_13 = data.genex.ge_13;
            genexam.ge_14 = data.genex.ge_14;
            genexam.ge_15 = data.genex.ge_15;
            genexam.ge_16 = data.genex.ge_16;
            genexam.ge_17 = data.genex.ge_17;
            genexam.ge_18 = data.genex.ge_18;
            genexam.ge_19 = data.genex.ge_19;
            genexam.ge_20 = data.genex.ge_20;
            genexam.ge_21 = data.genex.ge_21;
            genexam.ge_22 = data.genex.ge_22;
            genexam.ge_23 = data.genex.ge_23;
            genexam.ge_24 = data.genex.ge_24;
            genexam.ge_25 = data.genex.ge_25;
            genexam.ge_1_type = data.genex.ge_1_type;
            genexam.ge_2_type = data.genex.ge_2_type;
            genexam.ge_3_type = data.genex.ge_3_type;
            genexam.ge_4_type = data.genex.ge_4_type;
            genexam.ge_5_type = data.genex.ge_5_type;
            genexam.ge_6_type = data.genex.ge_6_type;
            genexam.ge_7_type = data.genex.ge_7_type;
            genexam.ge_8_type = data.genex.ge_8_type;
            genexam.ge_9_type = data.genex.ge_9_type;
            genexam.ge_10_type = data.genex.ge_10_type;
            genexam.ge_11_type = data.genex.ge_11_type;
            genexam.ge_12_type = data.genex.ge_12_type;
            genexam.ge_13_type = data.genex.ge_13_type;
            genexam.ge_14_type = data.genex.ge_14_type;
            genexam.ge_15_type = data.genex.ge_15_type;
            genexam.ge_16_type = data.genex.ge_16_type;
            genexam.ge_17_type = data.genex.ge_17_type;
            genexam.ge_18_type = data.genex.ge_18_type;
            genexam.ge_19_type = data.genex.ge_19_type;
            genexam.ge_20_type = data.genex.ge_20_type;
            genexam.ge_21_type = data.genex.ge_21_type;
            genexam.ge_22_type = data.genex.ge_22_type;
            genexam.ge_23_type = data.genex.ge_23_type;
            genexam.ge_24_type = data.genex.ge_24_type;
            genexam.ge_25_type = data.genex.ge_25_type;
            genexam.ge_madeby = madeby;
            isDone1 = DataAccessLayer.EMR.GeneralExamination.InsertUpdateGeneralExamination(genexam);


           
            if (isDone1)
            {
                BusinessEntities.EMR.RespiratorySystem respiratory = new BusinessEntities.EMR.RespiratorySystem();
                respiratory.resId = data.resp.resId;
                respiratory.res_appId = data.resp.res_appId;
                respiratory.res_1 = data.resp.res_1;
                respiratory.res_2 = data.resp.res_2;
                respiratory.res_3 = data.resp.res_3;
                respiratory.res_4 = data.resp.res_4;
                respiratory.res_5 = data.resp.res_5;
                respiratory.res_6 = data.resp.res_6;
                respiratory.res_7 = data.resp.res_7;
                respiratory.res_8 = data.resp.res_8;
                respiratory.res_1_type = data.resp.res_1_type;
                respiratory.res_2_type = data.resp.res_2_type;
                respiratory.res_3_type = data.resp.res_3_type;
                respiratory.res_4_type = data.resp.res_4_type;
                respiratory.res_5_type = data.resp.res_5_type;
                respiratory.res_6_type = data.resp.res_6_type;
                respiratory.res_7_type = data.resp.res_7_type;
                respiratory.res_8_type = data.resp.res_8_type;
                respiratory.res_madeby = madeby;
                isDone2 = DataAccessLayer.EMR.RespiratorySystem.InsertUpdateRespiratorySystem(respiratory);

            }


            if (isDone2)
            {

                BusinessEntities.EMR.CardioVascular vascular = new BusinessEntities.EMR.CardioVascular();
                vascular.cvId = data.card.cvId;
                vascular.cv_appId = data.card.cv_appId;
                vascular.cv_1 = data.card.cv_1;
                vascular.cv_2 = data.card.cv_2;
                vascular.cv_3 = data.card.cv_3;
                vascular.cv_4 = data.card.cv_4;
                vascular.cv_5 = data.card.cv_5;
                vascular.cv_6 = data.card.cv_6;
                vascular.cv_1_type = data.card.cv_1_type;
                vascular.cv_2_type = data.card.cv_2_type;
                vascular.cv_3_type = data.card.cv_3_type;
                vascular.cv_4_type = data.card.cv_4_type;
                vascular.cv_5_type = data.card.cv_5_type;
                vascular.cv_6_type = data.card.cv_6_type;
                vascular.cv_madeby = madeby;
                isDone3 = DataAccessLayer.EMR.CardioVascular.InsertUpdateCardioVascular(vascular);
            }
            if (isDone3)
            {
                BusinessEntities.EMR.CentralNervous nervous = new BusinessEntities.EMR.CentralNervous();
                nervous.cnId = data.nerv.cnId;
                nervous.cn_appId = data.nerv.cn_appId;
                nervous.cn_1 = data.nerv.cn_1;
                nervous.cn_2 = data.nerv.cn_2;
                nervous.cn_3 = data.nerv.cn_3;
                nervous.cn_4 = data.nerv.cn_4;
                nervous.cn_5 = data.nerv.cn_5;
                nervous.cn_6 = data.nerv.cn_6;
                nervous.cn_7 = data.nerv.cn_7;
                nervous.cn_8 = data.nerv.cn_8;
                nervous.cn_9 = data.nerv.cn_9;
                nervous.cn_1_type = data.nerv.cn_1_type;
                nervous.cn_2_type = data.nerv.cn_2_type;
                nervous.cn_3_type = data.nerv.cn_3_type;
                nervous.cn_4_type = data.nerv.cn_4_type;
                nervous.cn_5_type = data.nerv.cn_5_type;
                nervous.cn_6_type = data.nerv.cn_6_type;
                nervous.cn_7_type = data.nerv.cn_7_type;
                nervous.cn_8_type = data.nerv.cn_8_type;
                nervous.cn_9_type = data.nerv.cn_9_type;
                nervous.cn_madeby = madeby;
                isDone4 = DataAccessLayer.EMR.CentralNervous.InsertUpdateCentralNervous(nervous);
            }
            if (isDone4)
            {
                BusinessEntities.EMR.GastroIntestinal Intestinal = new BusinessEntities.EMR.GastroIntestinal();
                Intestinal.giId = data.gast.giId;
                Intestinal.gi_appId = data.gast.gi_appId;
                Intestinal.gi_1 = data.gast.gi_1;
                Intestinal.gi_2 = data.gast.gi_2;
                Intestinal.gi_3 = data.gast.gi_3;
                Intestinal.gi_4 = data.gast.gi_4;
                Intestinal.gi_5 = data.gast.gi_5;
                Intestinal.gi_6 = data.gast.gi_6;
                Intestinal.gi_7 = data.gast.gi_7;
                Intestinal.gi_8 = data.gast.gi_8;
                Intestinal.gi_9 = data.gast.gi_9;
                Intestinal.gi_10 = data.gast.gi_10;
                Intestinal.gi_11 = data.gast.gi_11;
                Intestinal.gi_12 = data.gast.gi_12;
                Intestinal.gi_13 = data.gast.gi_13;
                Intestinal.gi_14 = data.gast.gi_14;
                Intestinal.gi_1_type = data.gast.gi_1_type;
                Intestinal.gi_2_type = data.gast.gi_2_type;
                Intestinal.gi_3_type = data.gast.gi_3_type;
                Intestinal.gi_4_type = data.gast.gi_4_type;
                Intestinal.gi_5_type = data.gast.gi_5_type;
                Intestinal.gi_6_type = data.gast.gi_6_type;
                Intestinal.gi_7_type = data.gast.gi_7_type;
                Intestinal.gi_8_type = data.gast.gi_8_type;
                Intestinal.gi_9_type = data.gast.gi_9_type;
                Intestinal.gi_10_type = data.gast.gi_10_type;
                Intestinal.gi_11_type = data.gast.gi_11_type;
                Intestinal.gi_12_type = data.gast.gi_12_type;
                Intestinal.gi_13_type = data.gast.gi_13_type;
                Intestinal.gi_14_type = data.gast.gi_14_type;
                Intestinal.gi_madeby = madeby;
                isDone5 = DataAccessLayer.EMR.GastroIntestinal.InsertUpdateGastroIntestinal(Intestinal);
            }

            if (isDone5)
            {
                BusinessEntities.EMR.GenitoUrinary urinary = new BusinessEntities.EMR.GenitoUrinary();
                urinary.genId = data.geni.genId;
                urinary.gen_appId = data.geni.gen_appId;
                urinary.gen_1 = data.geni.gen_1;
                urinary.gen_2 = data.geni.gen_2;
                urinary.gen_1_type = data.geni.gen_1_type;
                urinary.gen_2_type = data.geni.gen_2_type;
                urinary.gen_madeby = madeby;
                isDone6 = DataAccessLayer.EMR.GenitoUrinary.InsertUpdateGenitoUrinary(urinary);
            }
            if (isDone6)
            {
                BusinessEntities.EMR.MusculoSkeletal skeletal = new BusinessEntities.EMR.MusculoSkeletal();
                skeletal.msId = data.musc.msId;
                skeletal.ms_appId = data.musc.ms_appId;
                skeletal.ms_1 = data.musc.ms_1;
                skeletal.ms_2 = data.musc.ms_2;
                skeletal.ms_3 = data.musc.ms_3;
                skeletal.ms_4 = data.musc.ms_4;
                skeletal.ms_5 = data.musc.ms_5;
                skeletal.ms_6 = data.musc.ms_6;
                skeletal.ms_1_type = data.musc.ms_1_type;
                skeletal.ms_2_type = data.musc.ms_2_type;
                skeletal.ms_3_type = data.musc.ms_3_type;
                skeletal.ms_4_type = data.musc.ms_4_type;
                skeletal.ms_5_type = data.musc.ms_5_type;
                skeletal.ms_6_type = data.musc.ms_6_type;
                skeletal.ms_madeby = madeby;
                isInserted = DataAccessLayer.EMR.MusculoSkeletal.InsertUpdateMusculoSkeletal(skeletal);
            }
            if (isInserted)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public static int DeleteExamination(int geId, int resId, int cvId, int cnId, int giId, int genId, int msId, int madeby)
        {
            int count = 0;
            int result= DataAccessLayer.EMR.GeneralExamination.DeleteGeneralExamination(geId,madeby);
            count++;
            if (count == 1)
            {
               result = DataAccessLayer.EMR.RespiratorySystem.DeleteRespiratorySystem(resId, madeby);
                count++;
            }
            if (count == 2)
            {
                result = DataAccessLayer.EMR.CardioVascular.DeleteCardioVascular(cvId, madeby);
                count++;
            }
            if (count == 3)
            {
                result = DataAccessLayer.EMR.CentralNervous.DeleteCentralNervous(cnId, madeby);
                count++;
            } 
            if (count == 4)
            {
                result = DataAccessLayer.EMR.GastroIntestinal.DeleteGastroIntestinal(giId, madeby);
                count++;
            }
            if (count == 5)
            {
                result = DataAccessLayer.EMR.GenitoUrinary.DeleteGenitoUrinary(genId, madeby);
                count++;
            }
            if (count == 6)
            {
                result = DataAccessLayer.EMR.MusculoSkeletal.DeleteMusculoSkeletal(msId, madeby);
                count++;
            }
            return result;
        }

    }
}
