using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class NomogramData
    {
        public static List<BusinessEntities.ConsentForms.NomogramData> GetNomogramDataData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.NomogramData.GetNomogramDataData(appId);
            List<BusinessEntities.ConsentForms.NomogramData> list = new List<BusinessEntities.ConsentForms.NomogramData>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.NomogramData
                {
                    ndnId = Convert.ToInt32(dr["ndnId"]),
                    ndn_appId = Convert.ToInt32(dr["ndn_appId"]),
                    ndn_1 = dr["ndn_1"].ToString(),
                    ndn_2 = dr["ndn_2"].ToString(),
                    ndn_3 = dr["ndn_3"].ToString(),
                    ndn_4 = dr["ndn_4"].ToString(),
                    ndn_5 = dr["ndn_5"].ToString(),
                    ndn_6 = dr["ndn_6"].ToString(),
                    ndn_7 = dr["ndn_7"].ToString(),
                    ndn_8 = dr["ndn_8"].ToString(),
                    ndn_9 = dr["ndn_9"].ToString(),
                    ndn_10 = dr["ndn_10"].ToString(),
                    ndn_11 = dr["ndn_11"].ToString(),
                    ndn_12 = dr["ndn_12"].ToString(),
                    ndn_13 = dr["ndn_13"].ToString(),
                    ndn_14 = dr["ndn_14"].ToString(),
                    ndn_15 = dr["ndn_15"].ToString(),
                    ndn_16 = dr["ndn_16"].ToString(),
                    ndn_17 = dr["ndn_17"].ToString(),
                    ndn_18 = dr["ndn_18"].ToString(),
                    ndn_19 = dr["ndn_19"].ToString(),
                    ndn_20 = dr["ndn_20"].ToString(),
                    ndn_21 = dr["ndn_21"].ToString(),
                    ndn_22 = dr["ndn_22"].ToString(),
                    ndn_23 = dr["ndn_23"].ToString(),
                    ndn_24 = dr["ndn_24"].ToString(),

                    ndn_dd_1 = dr["ndn_dd_1"].ToString(),
                    ndn_dd_2 = dr["ndn_dd_2"].ToString(),
                    ndn_dd_3 = dr["ndn_dd_3"].ToString(),
                    ndn_dd_4 = dr["ndn_dd_4"].ToString(),
                    ndn_dd_5 = dr["ndn_dd_5"].ToString(),
                    ndn_dd_6 = dr["ndn_dd_6"].ToString(),
                    ndn_dd_7 = dr["ndn_dd_7"].ToString(),
                    ndn_dd_8 = dr["ndn_dd_8"].ToString(),
                    ndn_dd_9 = dr["ndn_dd_9"].ToString(),
                    ndn_dd_10 = dr["ndn_dd_10"].ToString(),
                    ndn_dd_11 = dr["ndn_dd_11"].ToString(),
                    ndn_dd_12 = dr["ndn_dd_12"].ToString(),
                    ndn_dd_13 = dr["ndn_dd_13"].ToString(),
                    ndn_dd_14 = dr["ndn_dd_14"].ToString(),
                    ndn_dd_15 = dr["ndn_dd_15"].ToString(),
                    ndn_dd_16 = dr["ndn_dd_16"].ToString(),
                    ndn_dd_17 = dr["ndn_dd_17"].ToString(),

                    ndn_chk_1 = dr["ndn_chk_1"].ToString(),

                    ndn_date_1 = dr["ndn_date_1"].ToString(),

                    ndn_doc1 = dr["ndn_doc1"].ToString(),
                    ndn_doc2 = dr["ndn_doc2"].ToString(),

                    ndn_status = dr["ndn_status"].ToString(),
                    ndn_date_modified = Convert.ToDateTime(dr["ndn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveNomogramData(BusinessEntities.ConsentForms.NomogramData ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.NomogramData.SaveNomogramData(ophtha, madeby);
        }
        public static int DeleteNomogramData(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.NomogramData.DeleteNomogramData(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetNomogramDataPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.NomogramData.GetNomogramDataPreviousHistory(appId);
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
