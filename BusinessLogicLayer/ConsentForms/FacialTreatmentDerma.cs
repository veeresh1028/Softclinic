using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FacialTreatmentDerma
    {
        public static List<BusinessEntities.ConsentForms.FacialTreatmentDerma> GetFacialTreatmentDermaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialTreatmentDerma.GetFacialTreatmentDermaData(appId);
            List<BusinessEntities.ConsentForms.FacialTreatmentDerma> list = new List<BusinessEntities.ConsentForms.FacialTreatmentDerma>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FacialTreatmentDerma
                {
                    ftfId = Convert.ToInt32(dr["ftfId"]),
                    ftf_appId = Convert.ToInt32(dr["ftf_appId"]),
                    ftf_1 = dr["ftf_1"].ToString(),
                    ftf_2 = dr["ftf_2"].ToString(),
                    ftf_3 = dr["ftf_3"].ToString(),
                    ftf_4 = dr["ftf_4"].ToString(),
                    ftf_5 = dr["ftf_5"].ToString(),
                    ftf_6 = dr["ftf_6"].ToString(),
                    ftf_7 = dr["ftf_7"].ToString(),
                    ftf_8 = dr["ftf_8"].ToString(),
                    ftf_9 = dr["ftf_9"].ToString(),
                    ftf_10 = dr["ftf_10"].ToString(),
                    ftf_11 = dr["ftf_11"].ToString(),
                    ftf_12 = dr["ftf_12"].ToString(),
                    ftf_13 = dr["ftf_13"].ToString(),
                    ftf_14 = dr["ftf_14"].ToString(),
                    ftf_15 = dr["ftf_15"].ToString(),
                    ftf_16 = dr["ftf_16"].ToString(),
                    ftf_17 = dr["ftf_17"].ToString(),
                    ftf_18 = dr["ftf_18"].ToString(),
                    ftf_19 = dr["ftf_19"].ToString(),
                    ftf_20 = dr["ftf_20"].ToString(),
                    ftf_21 = dr["ftf_21"].ToString(),
                    ftf_22 = dr["ftf_22"].ToString(),
                    ftf_23 = dr["ftf_23"].ToString(),
                    ftf_24 = dr["ftf_24"].ToString(),
                    ftf_25 = dr["ftf_25"].ToString(),
                    ftf_26 = dr["ftf_26"].ToString(),
                    ftf_27 = dr["ftf_27"].ToString(),
                    ftf_28 = dr["ftf_28"].ToString(),
                    ftf_29 = dr["ftf_29"].ToString(),
                    ftf_30 = dr["ftf_30"].ToString(),
                    ftf_status = dr["ftf_status"].ToString(),
                    ftf_date_modified = Convert.ToDateTime(dr["ftf_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveFacialTreatmentDerma(BusinessEntities.ConsentForms.FacialTreatmentDerma facial, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialTreatmentDerma.SaveFacialTreatmentDerma(facial, madeby);
        }

        public static int DeleteFacialTreatmentDerma(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialTreatmentDerma.DeleteFacialTreatmentDerma(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetFacialTreatmentDermaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialTreatmentDerma.GetFacialTreatmentDermaPreviousHistory(appId);
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
