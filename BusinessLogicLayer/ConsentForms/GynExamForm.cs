using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class GynExamForm
    {
        public static List<BusinessEntities.ConsentForms.GynExamForm> GetGynExamFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.GynExamForm.GetGynExamFormData(appId);
            List<BusinessEntities.ConsentForms.GynExamForm> list = new List<BusinessEntities.ConsentForms.GynExamForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.GynExamForm
                {
                    gefId = Convert.ToInt32(dr["gefId"]),
                    gef_appId = Convert.ToInt32(dr["gef_appId"]),
                    gef_1 = dr["gef_1"].ToString(),
                    gef_2 = dr["gef_2"].ToString(),
                    gef_3 = dr["gef_3"].ToString(),
                    gef_4 = dr["gef_4"].ToString(),
                    gef_5 = dr["gef_5"].ToString(),
                    gef_6 = dr["gef_6"].ToString(),
                    gef_7 = dr["gef_7"].ToString(),
                    gef_8 = dr["gef_8"].ToString(),
                    gef_9 = dr["gef_9"].ToString(),
                    gef_10 = dr["gef_10"].ToString(),
                    gef_11 = dr["gef_11"].ToString(),
                    gef_12 = dr["gef_12"].ToString(),
                    gef_13 = dr["gef_13"].ToString(),
                    gef_14 = dr["gef_14"].ToString(),
                    gef_15 = dr["gef_15"].ToString(),
                    gef_16 = dr["gef_16"].ToString(),
                    gef_17 = dr["gef_17"].ToString(),
                    gef_18 = dr["gef_18"].ToString(),
                    gef_19 = dr["gef_19"].ToString(),
                    gef_20 = dr["gef_20"].ToString(),
                    gef_21 = dr["gef_21"].ToString(),
                    gef_22 = dr["gef_22"].ToString(),
                    gef_23 = dr["gef_23"].ToString(),
                    gef_24 = dr["gef_24"].ToString(),
                    gef_25 = dr["gef_25"].ToString(),
                    gef_26 = dr["gef_26"].ToString(),
                    gef_27 = dr["gef_27"].ToString(),
                    gef_28 = dr["gef_28"].ToString(),
                    gef_29 = dr["gef_29"].ToString(),
                    gef_30 = dr["gef_30"].ToString(),
                    gef_31 = dr["gef_31"].ToString(),
                    gef_32 = dr["gef_32"].ToString(),
                    gef_33 = dr["gef_33"].ToString(),

                    gef_radio1 = dr["gef_radio1"].ToString(),
                    gef_radio2 = dr["gef_radio2"].ToString(),
                    gef_radio3 = dr["gef_radio3"].ToString(),
                    gef_radio4 = dr["gef_radio4"].ToString(),
                    gef_radio5 = dr["gef_radio5"].ToString(),
                    gef_radio6 = dr["gef_radio6"].ToString(),
                    gef_radio7 = dr["gef_radio7"].ToString(),
                    gef_radio8 = dr["gef_radio8"].ToString(),
                    gef_radio9 = dr["gef_radio9"].ToString(),
                    gef_radio10 = dr["gef_radio10"].ToString(),
                    gef_radio11 = dr["gef_radio11"].ToString(),
                    gef_radio12 = dr["gef_radio12"].ToString(),
                    gef_radio13 = dr["gef_radio13"].ToString(),
                    gef_radio14 = dr["gef_radio14"].ToString(),
                    gef_radio15 = dr["gef_radio15"].ToString(),
                    gef_radio16 = dr["gef_radio16"].ToString(),
                    gef_radio17 = dr["gef_radio17"].ToString(),
                    gef_radio18 = dr["gef_radio18"].ToString(),
                    gef_radio19 = dr["gef_radio19"].ToString(),
                    gef_radio20 = dr["gef_radio20"].ToString(),
                    gef_radio21 = dr["gef_radio21"].ToString(),
                    gef_radio22 = dr["gef_radio22"].ToString(),
                    gef_radio23 = dr["gef_radio23"].ToString(),
                    gef_radio24 = dr["gef_radio24"].ToString(),
                    gef_radio25 = dr["gef_radio25"].ToString(),
                    gef_radio26 = dr["gef_radio26"].ToString(),
                    gef_radio27 = dr["gef_radio27"].ToString(),
                    gef_radio28 = dr["gef_radio28"].ToString(),
                    gef_radio29 = dr["gef_radio29"].ToString(),
                    gef_radio30 = dr["gef_radio30"].ToString(),
                    gef_radio31 = dr["gef_radio31"].ToString(),
                    gef_radio32 = dr["gef_radio32"].ToString(),
                    gef_radio33 = dr["gef_radio33"].ToString(),
                    gef_radio34 = dr["gef_radio34"].ToString(),
                    gef_radio35 = dr["gef_radio35"].ToString(),
                    gef_radio36 = dr["gef_radio36"].ToString(),
                    gef_radio37 = dr["gef_radio37"].ToString(),
                    gef_radio38 = dr["gef_radio38"].ToString(),
                    gef_radio39 = dr["gef_radio39"].ToString(),
                    gef_radio40 = dr["gef_radio40"].ToString(),
                    gef_radio41 = dr["gef_radio41"].ToString(),
                    gef_radio42 = dr["gef_radio42"].ToString(),
                    gef_radio43 = dr["gef_radio43"].ToString(),
                    gef_radio44 = dr["gef_radio44"].ToString(),
                    gef_radio45 = dr["gef_radio45"].ToString(),
                    gef_radio46 = dr["gef_radio46"].ToString(),
                    gef_radio47 = dr["gef_radio47"].ToString(),
                    gef_radio48 = dr["gef_radio48"].ToString(),
                    gef_radio49 = dr["gef_radio49"].ToString(),
                    gef_radio50 = dr["gef_radio50"].ToString(),
                    gef_radio51 = dr["gef_radio51"].ToString(),
                    gef_radio52 = dr["gef_radio52"].ToString(),
                    gef_radio53 = dr["gef_radio53"].ToString(),
                    gef_radio54 = dr["gef_radio54"].ToString(),
                    gef_radio55 = dr["gef_radio55"].ToString(),
                    gef_radio56 = dr["gef_radio56"].ToString(),
                    gef_radio57 = dr["gef_radio57"].ToString(),
                    gef_radio58 = dr["gef_radio58"].ToString(),
                    gef_radio59 = dr["gef_radio59"].ToString(),
                    gef_radio60 = dr["gef_radio60"].ToString(),
                    gef_radio61 = dr["gef_radio61"].ToString(),
                    gef_radio62 = dr["gef_radio62"].ToString(),
                    gef_radio63 = dr["gef_radio63"].ToString(),
                    gef_radio64 = dr["gef_radio64"].ToString(),

                    gef_date1 = dr["gef_date1"].ToString(),
                    gef_date2 = dr["gef_date2"].ToString(),
                    gef_date3 = dr["gef_date3"].ToString(),
                    gef_date4 = dr["gef_date4"].ToString(),
                    gef_date5 = dr["gef_date5"].ToString(),
                    gef_date6 = dr["gef_date6"].ToString(),
                    gef_date7 = dr["gef_date7"].ToString(),
                    gef_date8 = dr["gef_date8"].ToString(),
                    gef_date9 = dr["gef_date9"].ToString(),

                    gef_chk1 = dr["gef_chk1"].ToString(),

                    gef_status = dr["gef_status"].ToString(),
                    gef_date_modified = Convert.ToDateTime(dr["gef_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveGynExamForm(BusinessEntities.ConsentForms.GynExamForm gyna, int madeby)
        {
            return DataAccessLayer.ConsentForms.GynExamForm.SaveGynExamForm(gyna, madeby);
        }
        public static int DeleteGynExamForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.GynExamForm.DeleteGynExamForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetGynExamFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.GynExamForm.GetGynExamFormPreviousHistory(appId);
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
