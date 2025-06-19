using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class PastHistory
    {
        #region PastHistory
        public static List<BusinessEntities.NurseStation.PastHistory> GetAllPastHistory(int appId)
        {
            List<BusinessEntities.NurseStation.PastHistory> sclist = new List<BusinessEntities.NurseStation.PastHistory>();
            DataTable dt = DataAccessLayer.NurseStation.PastHistory.GetAllPastHistory(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.PastHistory
                {
                    pfId = Convert.ToInt32(dr["pfId"]),
                    pf_appId = Convert.ToInt32(dr["pf_appId"]),
                    pf_past = dr["pf_past"].ToString(),
                    pf_other = dr["pf_other"].ToString(),
                    pf_family = dr["pf_family"].ToString(),
                    pf_surgical = dr["pf_surgical"].ToString(),
                    pf_smok = dr["pf_smok"].ToString(),
                    pf_smok_habit = dr["pf_smok_habit"].ToString(),
                    pf_smok_details = dr["pf_smok_details"].ToString(),
                    pf_alco = dr["pf_alco"].ToString(),
                    pf_alco_habit = dr["pf_alco_habit"].ToString(),
                    pf_alco_details = dr["pf_alco_details"].ToString(),
                    pf_drug = dr["pf_drug"].ToString(),
                    pf_drug_habit = dr["pf_drug_habit"].ToString(),
                    pf_drug_details = dr["pf_drug_details"].ToString(),
                    pf_status = dr["pf_status"].ToString(),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.NurseStation.PastHistory> GetAllPrePastHistory(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.PastHistory> sclist = new List<BusinessEntities.NurseStation.PastHistory>();
            DataTable dt = DataAccessLayer.NurseStation.PastHistory.GetAllPrePastHistory(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.PastHistory
                {
                    pfId = Convert.ToInt32(dr["pfId"]),
                    pf_appId = Convert.ToInt32(dr["pf_appId"]),
                    pf_past = dr["pf_past"].ToString(),
                    pf_other = dr["pf_other"].ToString(),
                    pf_family = dr["pf_family"].ToString(),
                    pf_surgical = dr["pf_surgical"].ToString(),
                    pf_smok = dr["pf_smok"].ToString(),
                    pf_smok_habit = dr["pf_smok_habit"].ToString(),
                    pf_smok_details = dr["pf_smok_details"].ToString(),
                    pf_alco = dr["pf_alco"].ToString(),
                    pf_alco_habit = dr["pf_alco_habit"].ToString(),
                    pf_alco_details = dr["pf_alco_details"].ToString(),
                    pf_drug = dr["pf_drug"].ToString(),
                    pf_drug_habit = dr["pf_drug_habit"].ToString(),
                    pf_drug_details = dr["pf_drug_details"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        public static int InsertUpdatePastHistory(BusinessEntities.NurseStation.PastHistory data)
        {
            data.pf_past = string.IsNullOrEmpty(data.pf_past) ? string.Empty : data.pf_past;
            data.pf_family = string.IsNullOrEmpty(data.pf_family) ? string.Empty : data.pf_family;
            data.pf_other = string.IsNullOrEmpty(data.pf_other) ? string.Empty : data.pf_other;
            data.pf_surgical = string.IsNullOrEmpty(data.pf_surgical) ? string.Empty : data.pf_surgical;
            data.pf_smok = string.IsNullOrEmpty(data.pf_smok) ? string.Empty : data.pf_smok;
            data.pf_smok_habit = string.IsNullOrEmpty(data.pf_smok_habit) ? string.Empty : data.pf_smok_habit;
            data.pf_smok_details = string.IsNullOrEmpty(data.pf_smok_details) ? string.Empty : data.pf_smok_details;
            data.pf_alco = string.IsNullOrEmpty(data.pf_alco) ? string.Empty : data.pf_alco;
            data.pf_alco_habit = string.IsNullOrEmpty(data.pf_alco_habit) ? string.Empty : data.pf_alco_habit;
            data.pf_alco_details = string.IsNullOrEmpty(data.pf_alco_details) ? string.Empty : data.pf_alco_details;
            data.pf_drug = string.IsNullOrEmpty(data.pf_drug) ? string.Empty : data.pf_drug;
            data.pf_drug_habit = string.IsNullOrEmpty(data.pf_drug_habit) ? string.Empty : data.pf_drug_habit;
            data.pf_drug_details = string.IsNullOrEmpty(data.pf_drug_details) ? string.Empty : data.pf_drug_details;



            return DataAccessLayer.NurseStation.PastHistory.InsertUpdatePastHistory(data);
        }
        public static int DeletePastHistory(int pfId,  int pf_madeby)
        {
            return DataAccessLayer.NurseStation.PastHistory.DeletePastHistory(pfId, pf_madeby);
        }

        #endregion PastHistory
    }
}
