using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PatientLaserHairRemovalDerma
    {
        public static List<BusinessEntities.ConsentForms.PatientLaserHairRemovalDerma> GetPatientLaserHairRemovalDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PatientLaserHairRemovalDerma.GetPatientLaserHairRemovalDermaData(appId);
            List<BusinessEntities.ConsentForms.PatientLaserHairRemovalDerma> list = new List<BusinessEntities.ConsentForms.PatientLaserHairRemovalDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PatientLaserHairRemovalDerma
                {
                    plhrId = Convert.ToInt32(dr["plhrId"]),
                    plhr_appId = Convert.ToInt32(dr["plhr_appId"]),
                    plhr_1 = dr["plhr_1"].ToString(),
                    plhr_2 = dr["plhr_2"].ToString(),
                    plhr_3 = dr["plhr_3"].ToString(),
                    plhr_4 = dr["plhr_4"].ToString(),
                    plhr_5 = dr["plhr_5"].ToString(),
                    plhr_6 = dr["plhr_6"].ToString(),
                    plhr_7 = dr["plhr_7"].ToString(),
                    plhr_8 = dr["plhr_8"].ToString(),
                    plhr_9 = dr["plhr_9"].ToString(),
                    plhr_10 = dr["plhr_10"].ToString(),
                    plhr_11 = dr["plhr_11"].ToString(),
                    plhr_12 = dr["plhr_12"].ToString(),
                    plhr_13 = dr["plhr_13"].ToString(),
                    plhr_14 = dr["plhr_14"].ToString(),
                    plhr_15 = dr["plhr_15"].ToString(),
                    plhr_16 = dr["plhr_16"].ToString(),
                    plhr_17 = dr["plhr_17"].ToString(),
                    plhr_18 = dr["plhr_18"].ToString(),
                    plhr_19 = dr["plhr_19"].ToString(),
                    plhr_20 = dr["plhr_20"].ToString(),
                    plhr_21 = dr["plhr_21"].ToString(),
                    plhr_22 = dr["plhr_22"].ToString(),
                    plhr_23 = dr["plhr_23"].ToString(),
                    plhr_24 = dr["plhr_24"].ToString(),
                    plhr_25 = dr["plhr_25"].ToString(),
                    plhr_26 = dr["plhr_26"].ToString(),
                    plhr_27 = dr["plhr_27"].ToString(),
                    plhr_28 = dr["plhr_28"].ToString(),
                    plhr_29 = dr["plhr_29"].ToString(),
                    plhr_30 = dr["plhr_30"].ToString(),
                    plhr_31 = dr["plhr_31"].ToString(),
                    plhr_32 = dr["plhr_32"].ToString(),
                    plhr_33 = dr["plhr_33"].ToString(),
                    plhr_34 = dr["plhr_34"].ToString(),
                    plhr_35 = dr["plhr_35"].ToString(),
                    plhr_36 = dr["plhr_36"].ToString(),
                    plhr_37 = dr["plhr_37"].ToString(),
                    plhr_38 = dr["plhr_38"].ToString(),
                    plhr_39 = dr["plhr_39"].ToString(),
                    plhr_40 = dr["plhr_40"].ToString(),
                    plhr_41 = dr["plhr_41"].ToString(),
                    plhr_42 = dr["plhr_42"].ToString(),
                    plhr_43 = dr["plhr_43"].ToString(),
                    plhr_44 = dr["plhr_44"].ToString(),
                    plhr_45 = dr["plhr_45"].ToString(),
                    plhr_46 = dr["plhr_46"].ToString(),
                    plhr_47 = dr["plhr_47"].ToString(),
                    plhr_48 = dr["plhr_48"].ToString(),
                    plhr_49 = dr["plhr_49"].ToString(),
                    plhr_50 = dr["plhr_50"].ToString(),
                    plhr_51 = dr["plhr_51"].ToString(),
                    plhr_52 = dr["plhr_52"].ToString(),
                    plhr_53 = dr["plhr_53"].ToString(),
                    plhr_54 = dr["plhr_54"].ToString(),
                    plhr_55 = dr["plhr_55"].ToString(),
                    plhr_56 = dr["plhr_56"].ToString(),
                    plhr_57 = dr["plhr_57"].ToString(),
                    plhr_58 = dr["plhr_58"].ToString(),
                    plhr_59 = dr["plhr_59"].ToString(),
                    plhr_60 = dr["plhr_60"].ToString(),
                    plhr_61 = dr["plhr_61"].ToString(),
                    plhr_62 = dr["plhr_62"].ToString(),
                    plhr_63 = dr["plhr_63"].ToString(),
                    plhr_64 = dr["plhr_64"].ToString(),
                    plhr_65 = dr["plhr_65"].ToString(),
                    plhr_66 = dr["plhr_66"].ToString(),
                    plhr_67 = dr["plhr_67"].ToString(),
                    plhr_68 = dr["plhr_68"].ToString(),
                    plhr_69 = dr["plhr_69"].ToString(),
                    plhr_70 = dr["plhr_70"].ToString(),
                    plhr_71 = dr["plhr_71"].ToString(),
                    plhr_72 = dr["plhr_72"].ToString(),
                    plhr_73 = dr["plhr_73"].ToString(),
                    plhr_74 = dr["plhr_74"].ToString(),
                    plhr_75 = dr["plhr_75"].ToString(),
                    plhr_76 = dr["plhr_76"].ToString(),
                    plhr_77 = dr["plhr_77"].ToString(),
                    plhr_78 = dr["plhr_78"].ToString(),
                    plhr_79 = dr["plhr_79"].ToString(),
                    plhr_status = dr["plhr_status"].ToString(),
                    plhr_date_modified = Convert.ToDateTime(dr["plhr_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SavePatientLaserHairRemovalDerma(BusinessEntities.ConsentForms.PatientLaserHairRemovalDerma patient, int madeby)
        {
            return DataAccessLayer.ConsentForms.PatientLaserHairRemovalDerma.SavePatientLaserHairRemovalDerma(patient, madeby);
        }
        public static int DeletePatientLaserHairRemovalDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PatientLaserHairRemovalDerma.DeletePatientLaserHairRemovalDerma(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPatientLaserHairRemovalDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PatientLaserHairRemovalDerma.GetPatientLaserHairRemovalDermaPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
                {
                    formId = Convert.ToInt32(dr["formId"]),
                    appId = Convert.ToInt32(dr["appId"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_name = dr["emp_name"].ToString() + " " + dr["emp_lname"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString()
                });
            }
            return list;
        }

    }
}
