using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OccupationalTherapyForm
    {
        public static List<BusinessEntities.ConsentForms.OccupationalTherapyForm> GetOccupationalTherapyFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OccupationalTherapyForm.GetOccupationalTherapyFormData(appId);
            List<BusinessEntities.ConsentForms.OccupationalTherapyForm> list = new List<BusinessEntities.ConsentForms.OccupationalTherapyForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OccupationalTherapyForm
                {
                    potId = Convert.ToInt32(dr["potId"]),
                    pot_appId = Convert.ToInt32(dr["pot_appId"]),
                    pot_1 = dr["pot_1"].ToString(),
                    pot_2 = dr["pot_2"].ToString(),
                    pot_3 = dr["pot_3"].ToString(),
                    pot_4 = dr["pot_4"].ToString(),
                    pot_5 = dr["pot_5"].ToString(),
                    pot_6 = dr["pot_6"].ToString(),
                    pot_7 = dr["pot_7"].ToString(),
                    pot_8 = dr["pot_8"].ToString(),
                    pot_9 = dr["pot_9"].ToString(),
                    pot_10 = dr["pot_10"].ToString(),
                    pot_11 = dr["pot_11"].ToString(),
                    pot_12 = dr["pot_12"].ToString(),
                    pot_13 = dr["pot_13"].ToString(),
                    pot_14 = dr["pot_14"].ToString(),
                    pot_15 = dr["pot_15"].ToString(),
                    pot_16 = dr["pot_16"].ToString(),
                    pot_17 = dr["pot_17"].ToString(),
                    pot_18 = dr["pot_18"].ToString(),
                    pot_19 = dr["pot_19"].ToString(),
                    //pot_20 = dr["pot_20"].ToString(),
                    //pot_21 = dr["pot_21"].ToString(),
                    pot_22 = dr["pot_22"].ToString(),
                    pot_23 = dr["pot_23"].ToString(),
                    pot_24 = dr["pot_24"].ToString(),
                    pot_25 = dr["pot_25"].ToString(),
                    pot_26 = dr["pot_26"].ToString(),
                    pot_27 = dr["pot_27"].ToString(),
                    pot_28 = dr["pot_28"].ToString(),
                    pot_29 = dr["pot_29"].ToString(),
                    pot_30 = dr["pot_30"].ToString(),
                    pot_31 = dr["pot_31"].ToString(),
                    pot_32 = dr["pot_32"].ToString(),
                    pot_33 = dr["pot_33"].ToString(),
                    pot_34 = dr["pot_34"].ToString(),
                    pot_35 = dr["pot_35"].ToString(),
                    pot_36 = dr["pot_36"].ToString(),
                    pot_37 = dr["pot_37"].ToString(),
                    pot_38 = dr["pot_38"].ToString(),
                    pot_39 = dr["pot_39"].ToString(),
                    pot_40 = dr["pot_40"].ToString(),
                    pot_41 = dr["pot_41"].ToString(),
                    pot_42 = dr["pot_42"].ToString(),
                    pot_43 = dr["pot_43"].ToString(),
                    pot_44 = dr["pot_44"].ToString(),
                    pot_45 = dr["pot_45"].ToString(),
                    pot_46 = dr["pot_46"].ToString(),
                    pot_47 = dr["pot_47"].ToString(),
                    pot_48 = dr["pot_48"].ToString(),
                    pot_49 = dr["pot_49"].ToString(),
                    pot_50 = dr["pot_50"].ToString(),
                    pot_51 = dr["pot_51"].ToString(),
                    pot_52 = dr["pot_52"].ToString(),
                    pot_53 = dr["pot_53"].ToString(),
                    pot_54 = dr["pot_54"].ToString(),
                    pot_55 = dr["pot_55"].ToString(),
                    pot_56 = dr["pot_56"].ToString(),
                    pot_57 = dr["pot_57"].ToString(),
                    pot_58 = dr["pot_58"].ToString(),
                    pot_59 = dr["pot_59"].ToString(),
                    pot_60 = dr["pot_60"].ToString(),
                    pot_61 = dr["pot_61"].ToString(),
                    pot_62 = dr["pot_62"].ToString(),
                    pot_63 = dr["pot_63"].ToString(),
                    pot_64 = dr["pot_64"].ToString(),
                    pot_65 = dr["pot_65"].ToString(),
                    pot_66 = dr["pot_66"].ToString(),
                    pot_67 = dr["pot_67"].ToString(),
                    pot_68 = dr["pot_68"].ToString(),
                    pot_69 = dr["pot_69"].ToString(),
                    pot_70 = dr["pot_70"].ToString(),
                    pot_71 = dr["pot_71"].ToString(),
                    pot_72 = dr["pot_72"].ToString(),
                    pot_73 = dr["pot_73"].ToString(),
                    pot_74 = dr["pot_74"].ToString(),
                    pot_75 = dr["pot_75"].ToString(),
                    pot_76 = dr["pot_76"].ToString(),
                    pot_77 = dr["pot_77"].ToString(),
                    pot_78 = dr["pot_78"].ToString(),
                    pot_79 = dr["pot_79"].ToString(),
                    pot_80 = dr["pot_80"].ToString(),
                    pot_81 = dr["pot_81"].ToString(),
                    pot_82 = dr["pot_82"].ToString(),
                    pot_83 = dr["pot_83"].ToString(),
                    pot_84 = dr["pot_84"].ToString(),
                    pot_85 = dr["pot_85"].ToString(),
                    pot_86 = dr["pot_86"].ToString(),
                    pot_87 = dr["pot_87"].ToString(),
                    pot_88 = dr["pot_88"].ToString(),
                    pot_89 = dr["pot_89"].ToString(),
                    pot_90 = dr["pot_90"].ToString(),
                    pot_91 = dr["pot_91"].ToString(),
                    pot_92 = dr["pot_92"].ToString(),
                    pot_93 = dr["pot_93"].ToString(),
                    pot_94 = dr["pot_94"].ToString(),
                    pot_95 = dr["pot_95"].ToString(),
                    pot_96 = dr["pot_96"].ToString(),
                    pot_97 = dr["pot_97"].ToString(),
                    pot_98 = dr["pot_98"].ToString(),
                    pot_99 = dr["pot_99"].ToString(),
                    pot_100 = dr["pot_100"].ToString(),
                    pot_101 = dr["pot_101"].ToString(),
                    pot_102 = dr["pot_102"].ToString(),
                    pot_103 = dr["pot_103"].ToString(),
                    pot_104 = dr["pot_104"].ToString(),
                    pot_105 = dr["pot_105"].ToString(),
                    pot_106 = dr["pot_106"].ToString(),
                    pot_107 = dr["pot_107"].ToString(),
                    pot_108 = dr["pot_108"].ToString(),
                    pot_109 = dr["pot_109"].ToString(),
                    pot_110 = dr["pot_110"].ToString(),
                    pot_111 = dr["pot_111"].ToString(),
                    pot_112 = dr["pot_112"].ToString(),
                    pot_113 = dr["pot_113"].ToString(),
                    pot_114 = dr["pot_114"].ToString(),
                    pot_115 = dr["pot_115"].ToString(),
                    pot_116 = dr["pot_116"].ToString(),
                    pot_117 = dr["pot_117"].ToString(),
                    pot_118 = dr["pot_118"].ToString(),
                    pot_119 = dr["pot_119"].ToString(),
                    pot_120 = dr["pot_120"].ToString(),
                    pot_121 = dr["pot_121"].ToString(),
                    pot_122 = dr["pot_122"].ToString(),
                    pot_123 = dr["pot_123"].ToString(),
                    pot_124 = dr["pot_124"].ToString(),
                    pot_125 = dr["pot_125"].ToString(),
                    pot_126 = dr["pot_126"].ToString(),
                    pot_127 = dr["pot_127"].ToString(),
                    pot_128 = dr["pot_128"].ToString(),
                    pot_129 = dr["pot_129"].ToString(),
                    pot_130 = dr["pot_130"].ToString(),
                    pot_131 = dr["pot_131"].ToString(),
                    pot_132 = dr["pot_132"].ToString(),
                    pot_133 = dr["pot_133"].ToString(),
                    pot_134 = dr["pot_134"].ToString(),
                    pot_135 = dr["pot_135"].ToString(),
                    pot_136 = dr["pot_136"].ToString(),
                    pot_137 = dr["pot_137"].ToString(),
                    pot_138 = dr["pot_138"].ToString(),
                    pot_139 = dr["pot_139"].ToString(),
                    pot_140 = dr["pot_140"].ToString(),
                    pot_141 = dr["pot_141"].ToString(),
                    pot_142 = dr["pot_142"].ToString(),
                    pot_143 = dr["pot_143"].ToString(),
                    pot_144 = dr["pot_144"].ToString(),
                    pot_145 = dr["pot_145"].ToString(),
                    pot_146 = dr["pot_146"].ToString(),
                    pot_147 = dr["pot_147"].ToString(),
                    pot_148 = dr["pot_148"].ToString(),
                    pot_149 = dr["pot_149"].ToString(),
                    pot_radio1 = dr["pot_radio1"].ToString(),
                    pot_radio2 = dr["pot_radio2"].ToString(),
                    pot_date1 = dr["pot_date1"].ToString(),
                    pot_time1 = dr["pot_time1"].ToString(),
                    pot_status = dr["pot_status"].ToString(),
                    pot_date_modified = Convert.ToDateTime(dr["pot_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveOccupationalTherapyForm(BusinessEntities.ConsentForms.OccupationalTherapyForm occupational, int madeby)
        {
            return DataAccessLayer.ConsentForms.OccupationalTherapyForm.SaveOccupationalTherapyForm(occupational, madeby);
        }
        public static int DeleteOccupationalTherapyForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OccupationalTherapyForm.DeleteOccupationalTherapyForm(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetOccupationalTherapyFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OccupationalTherapyForm.GetOccupationalTherapyFormPreviousHistory(appId);
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
