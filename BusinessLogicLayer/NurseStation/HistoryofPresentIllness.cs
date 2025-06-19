using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class HistoryofPresentIllness
    {
        #region HPI (Page Load)
        public static List<BusinessEntities.NurseStation.HistoryofPresentIllness> GetAllHPI(int ? appId, int? hpiId)
        {
            List<BusinessEntities.NurseStation.HistoryofPresentIllness> sclist = new List<BusinessEntities.NurseStation.HistoryofPresentIllness>();
            DataTable dt = DataAccessLayer.NurseStation.HistoryofPresentIllness.GetAllHPI(appId, hpiId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.HistoryofPresentIllness
                {
                    hpiId = Convert.ToInt32(dr["hpiId"]),
                    hpi_appId = Convert.ToInt32(dr["hpi_appId"]),
                    hpi_loc = dr["hpi_loc"].ToString(),
                    hpi_qua = dr["hpi_qua"].ToString(),
                    hpi_sev = dr["hpi_sev"].ToString(),
                    hpi_dur = dr["hpi_dur"].ToString(),
                    hpi_tim = dr["hpi_tim"].ToString(),
                    hpi_con = dr["hpi_con"].ToString(),
                    hpi_mod = dr["hpi_mod"].ToString(),
                    hpi_sym = dr["hpi_sym"].ToString(),
                    hpi_other = dr["hpi_other"].ToString(),
                    hpi_status = dr["hpi_status"].ToString(),
                    
                });
            }
            return sclist;
        }

        public static List<BusinessEntities.NurseStation.HistoryofPresentIllness> GetAllPreviousHPI(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.HistoryofPresentIllness> sclist = new List<BusinessEntities.NurseStation.HistoryofPresentIllness>();
            DataTable dt = DataAccessLayer.NurseStation.HistoryofPresentIllness.GetAllPreviousHPI(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.HistoryofPresentIllness
                {
                    hpiId = Convert.ToInt32(dr["hpiId"]),
                    hpi_appId = Convert.ToInt32(dr["hpi_appId"]),
                    hpi_loc = dr["hpi_loc"].ToString(),
                    hpi_qua = dr["hpi_qua"].ToString(),
                    hpi_sev = dr["hpi_sev"].ToString(),
                    hpi_dur = dr["hpi_dur"].ToString(),
                    hpi_tim = dr["hpi_tim"].ToString(),
                    hpi_con = dr["hpi_con"].ToString(),
                    hpi_mod = dr["hpi_mod"].ToString(),
                    hpi_sym = dr["hpi_sym"].ToString(),
                    hpi_other = dr["hpi_other"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        #endregion HPI (Page Load)
        #region HPI  CRUD Operations
        public static bool InsertUpdateHPI(BusinessEntities.NurseStation.HistoryofPresentIllness data)
        {
            data.hpi_loc = string.IsNullOrEmpty(data.hpi_loc) ? string.Empty : data.hpi_loc;
            data.hpi_qua = string.IsNullOrEmpty(data.hpi_qua) ? string.Empty : data.hpi_qua;
            data.hpi_sev = string.IsNullOrEmpty(data.hpi_sev) ? string.Empty : data.hpi_sev;
            data.hpi_dur = string.IsNullOrEmpty(data.hpi_dur) ? string.Empty : data.hpi_dur;
            data.hpi_tim = string.IsNullOrEmpty(data.hpi_tim) ? string.Empty : data.hpi_tim;
            data.hpi_con = string.IsNullOrEmpty(data.hpi_con) ? string.Empty : data.hpi_con;
            data.hpi_mod = string.IsNullOrEmpty(data.hpi_mod) ? string.Empty : data.hpi_mod;
            data.hpi_sym = string.IsNullOrEmpty(data.hpi_sym) ? string.Empty : data.hpi_sym;
            data.hpi_other = string.IsNullOrEmpty(data.hpi_other) ? string.Empty : data.hpi_other;

            return DataAccessLayer.NurseStation.HistoryofPresentIllness.InsertUpdateHPI(data);
        }

        public static int DeleteHPI(int hpiId,  int hpi_madeby)
        {
            return DataAccessLayer.NurseStation.HistoryofPresentIllness.DeleteHPI(hpiId, hpi_madeby);
        }


        #endregion HPI  CRUD Operations

    }
}
