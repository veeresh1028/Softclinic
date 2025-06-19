using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserHairRemoval
    {
        public static List<BusinessEntities.ConsentForms.LaserHairRemoval> GetLaserHairRemovalData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHairRemoval.GetLaserHairRemovalData(appId);
            List<BusinessEntities.ConsentForms.LaserHairRemoval> list = new List<BusinessEntities.ConsentForms.LaserHairRemoval>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserHairRemoval
                {
                    lhrId = Convert.ToInt32(dr["lhrId"]),
                    lhr_appId = Convert.ToInt32(dr["lhr_appId"]),
                    lhr_1 = dr["lhr_1"].ToString(),
                    lhr_2 = dr["lhr_2"].ToString(),
                    lhr_3 = dr["lhr_3"].ToString(),
                    lhr_4 = dr["lhr_4"].ToString(),
                    lhr_5 = dr["lhr_5"].ToString(),
                    lhr_6 = dr["lhr_6"].ToString(),
                    lhr_7 = dr["lhr_7"].ToString(),
                    lhr_8 = dr["lhr_8"].ToString(),
                    lhr_9 = dr["lhr_9"].ToString(),
                    lhr_10 = dr["lhr_10"].ToString(),
                    lhr_11 = dr["lhr_11"].ToString(),
                    lhr_12 = dr["lhr_12"].ToString(),
                    lhr_13 = dr["lhr_13"].ToString(),
                    lhr_14 = dr["lhr_14"].ToString(),
                    lhr_15 = dr["lhr_15"].ToString(),
                    lhr_16 = dr["lhr_16"].ToString(),
                    lhr_17 = dr["lhr_17"].ToString(),
                    lhr_18 = dr["lhr_18"].ToString(),
                    lhr_19 = dr["lhr_19"].ToString(),
                    lhr_20 = dr["lhr_20"].ToString(),
                    lhr_21 = dr["lhr_21"].ToString(),
                    lhr_22 = dr["lhr_22"].ToString(),
                    lhr_23 = dr["lhr_23"].ToString(),
                    lhr_24 = dr["lhr_24"].ToString(),
                    lhr_25 = dr["lhr_25"].ToString(),
                    lhr_26 = dr["lhr_26"].ToString(),
                    lhr_27 = dr["lhr_27"].ToString(),
                    lhr_28 = dr["lhr_28"].ToString(),
                    lhr_29 = dr["lhr_29"].ToString(),
                    lhr_30 = dr["lhr_30"].ToString(),
                    lhr_31 = dr["lhr_31"].ToString(),
                    lhr_32 = dr["lhr_32"].ToString(),
                    lhr_33 = dr["lhr_33"].ToString(),
                    lhr_34 = dr["lhr_34"].ToString(),
                    lhr_35 = dr["lhr_35"].ToString(),
                    lhr_36 = dr["lhr_36"].ToString(),
                    lhr_37 = dr["lhr_37"].ToString(),
                    lhr_38 = dr["lhr_38"].ToString(),
                    lhr_39 = dr["lhr_39"].ToString(),
                    lhr_40 = dr["lhr_40"].ToString(),
                    lhr_41 = dr["lhr_41"].ToString(),
                    lhr_42 = dr["lhr_42"].ToString(),
                    lhr_43 = dr["lhr_43"].ToString(),
                    lhr_44 = dr["lhr_44"].ToString(),
                    lhr_45 = dr["lhr_45"].ToString(),
                    lhr_46 = dr["lhr_46"].ToString(),
                    lhr_47 = dr["lhr_47"].ToString(),
                    lhr_48 = dr["lhr_48"].ToString(),
                    lhr_49 = dr["lhr_49"].ToString(),
                    lhr_50 = dr["lhr_50"].ToString(),
                    lhr_51 = dr["lhr_51"].ToString(),
                    lhr_52 = dr["lhr_52"].ToString(),
                    lhr_53 = dr["lhr_53"].ToString(),
                    lhr_54 = dr["lhr_54"].ToString(),
                    lhr_55 = dr["lhr_55"].ToString(),
                    lhr_56 = dr["lhr_56"].ToString(),

                    lhr_dd_1 = dr["lhr_dd_1"].ToString(),
                    lhr_dd_2 = dr["lhr_dd_2"].ToString(),
                    lhr_dd_3 = dr["lhr_dd_3"].ToString(),
                    lhr_dd_4 = dr["lhr_dd_4"].ToString(),
                    lhr_dd_5 = dr["lhr_dd_5"].ToString(),
                    lhr_dd_6 = dr["lhr_dd_6"].ToString(),
                    lhr_dd_7 = dr["lhr_dd_7"].ToString(),
                    lhr_dd_8 = dr["lhr_dd_8"].ToString(),
                    lhr_dd_9 = dr["lhr_dd_9"].ToString(),
                    lhr_dd_10 = dr["lhr_dd_10"].ToString(),
                    lhr_dd_11 = dr["lhr_dd_11"].ToString(),
                    lhr_dd_12 = dr["lhr_dd_12"].ToString(),
                    lhr_dd_13 = dr["lhr_dd_13"].ToString(),
                    lhr_dd_14 = dr["lhr_dd_14"].ToString(),
                    lhr_dd_15 = dr["lhr_dd_15"].ToString(),
                    lhr_dd_16 = dr["lhr_dd_16"].ToString(),

                    lhr_radio_1 = dr["lhr_radio_1"].ToString(),

                    lhr_chk_1 = dr["lhr_chk_1"].ToString(),

                    lhr_doc1 = dr["lhr_doc1"].ToString(),

                    lhr_status = dr["lhr_status"].ToString(),
                    lhr_date_modified = Convert.ToDateTime(dr["lhr_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveLaserHairRemoval(BusinessEntities.ConsentForms.LaserHairRemoval ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHairRemoval.SaveLaserHairRemoval(ophtha, madeby);
        }
        public static int DeleteLaserHairRemoval(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserHairRemoval.DeleteLaserHairRemoval(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLaserHairRemovalPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserHairRemoval.GetLaserHairRemovalPreviousHistory(appId);
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
