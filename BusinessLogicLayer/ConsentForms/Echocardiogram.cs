using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class Echocardiogram
    {
        public static List<BusinessEntities.ConsentForms.Echocardiogram> GetEchocardiogramData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Echocardiogram.GetEchocardiogramData(appId);
            List<BusinessEntities.ConsentForms.Echocardiogram> list = new List<BusinessEntities.ConsentForms.Echocardiogram>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.Echocardiogram
                {
                    ernId = Convert.ToInt32(dr["ernId"]),
                    ern_appId = Convert.ToInt32(dr["ern_appId"]),
                    ern_1 = dr["ern_1"].ToString(),
                    ern_2 = dr["ern_2"].ToString(),
                    ern_3 = dr["ern_3"].ToString(),
                    ern_4 = dr["ern_4"].ToString(),
                    ern_5 = dr["ern_5"].ToString(),
                    ern_6 = dr["ern_6"].ToString(),
                    ern_7 = dr["ern_7"].ToString(),
                    ern_8 = dr["ern_8"].ToString(),
                    ern_9 = dr["ern_9"].ToString(),
                    ern_10 = dr["ern_10"].ToString(),
                    ern_11 = dr["ern_11"].ToString(),
                    ern_12 = dr["ern_12"].ToString(),
                    ern_13 = dr["ern_13"].ToString(),
                    ern_14 = dr["ern_14"].ToString(),
                    ern_15 = dr["ern_15"].ToString(),
                    ern_16 = dr["ern_16"].ToString(),
                    ern_17 = dr["ern_17"].ToString(),
                    ern_18 = dr["ern_18"].ToString(),
                    ern_19 = dr["ern_19"].ToString(),
                    ern_20 = dr["ern_20"].ToString(),
                    ern_21 = dr["ern_21"].ToString(),
                    ern_22 = dr["ern_22"].ToString(),
                    ern_23 = dr["ern_23"].ToString(),
                    ern_24 = dr["ern_24"].ToString(),
                    ern_25 = dr["ern_25"].ToString(),
                    ern_26 = dr["ern_26"].ToString(),
                    ern_27 = dr["ern_27"].ToString(),
                    ern_28 = dr["ern_28"].ToString(),
                    ern_29 = dr["ern_29"].ToString(),
                    ern_30 = dr["ern_30"].ToString(),
                    ern_31 = dr["ern_31"].ToString(),
                    ern_32 = dr["ern_32"].ToString(),
                    ern_33 = dr["ern_33"].ToString(),
                    ern_34 = dr["ern_34"].ToString(),
                    ern_35 = dr["ern_35"].ToString(),
                    ern_36 = dr["ern_36"].ToString(),
                    ern_37 = dr["ern_37"].ToString(),
                    ern_38 = dr["ern_38"].ToString(),
                    ern_39 = dr["ern_39"].ToString(),
                    ern_40 = dr["ern_40"].ToString(),
                    ern_41 = dr["ern_41"].ToString(),
                    ern_42 = dr["ern_42"].ToString(),
                    ern_43 = dr["ern_43"].ToString(),
                    ern_44 = dr["ern_44"].ToString(),
                    ern_45 = dr["ern_45"].ToString(),
                    ern_46 = dr["ern_46"].ToString(),
                    ern_47 = dr["ern_47"].ToString(),
                    ern_48 = dr["ern_48"].ToString(),
                    ern_49 = dr["ern_49"].ToString(),
                    ern_50 = dr["ern_50"].ToString(),
                    ern_51 = dr["ern_51"].ToString(),
                    ern_52 = dr["ern_52"].ToString(),
                    ern_53 = dr["ern_53"].ToString(),
                    ern_54 = dr["ern_54"].ToString(),
                    ern_55 = dr["ern_55"].ToString(),
                    ern_56 = dr["ern_56"].ToString(),
                    ern_57 = dr["ern_57"].ToString(),
                    ern_58 = dr["ern_58"].ToString(),
                    ern_59 = dr["ern_59"].ToString(),
                    ern_60 = dr["ern_60"].ToString(),
                    ern_61 = dr["ern_61"].ToString(),
                    ern_62 = dr["ern_62"].ToString(),
                    ern_63 = dr["ern_63"].ToString(),
                    ern_64 = dr["ern_64"].ToString(),
                    ern_65 = dr["ern_65"].ToString(),
                    ern_66 = dr["ern_66"].ToString(),
                    ern_67 = dr["ern_67"].ToString(),
                    ern_68 = dr["ern_68"].ToString(),
                    ern_69 = dr["ern_69"].ToString(),

                    ern_doc1 = dr["ern_doc1"].ToString(),

                    ern_status = dr["ern_status"].ToString(),
                    ern_date_modified = Convert.ToDateTime(dr["ern_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveEchocardiogram(BusinessEntities.ConsentForms.Echocardiogram ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.Echocardiogram.SaveEchocardiogram(ophtha, madeby);
        }
        public static int DeleteEchocardiogram(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.Echocardiogram.DeleteEchocardiogram(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetEchocardiogramPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.Echocardiogram.GetEchocardiogramPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistory
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
