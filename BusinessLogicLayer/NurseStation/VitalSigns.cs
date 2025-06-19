using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class VitalSigns
    {
        #region VitalSigns
        public static List<BusinessEntities.NurseStation.VitalSigns> GetAllVitalSigns(int appId, int? signId)
        {
            List<BusinessEntities.NurseStation.VitalSigns> sclist = new List<BusinessEntities.NurseStation.VitalSigns>();
            DataTable dt = DataAccessLayer.NurseStation.VitalSigns.GetAllVitalSigns(appId, signId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.VitalSigns
                {
                    signId = Convert.ToInt32(dr["signId"]),
                    sign_appId = Convert.ToInt32(dr["sign_appId"]),
                    sign_temp = dr["sign_temp"].ToString(),
                    sign_pulse = dr["sign_pulse"].ToString(),
                    sign_bp = dr["sign_bp"].ToString(),
                    sign_notes = dr["sign_notes"].ToString(),
                    sign_height = dr["sign_height"].ToString(),
                    sign_weight = dr["sign_weight"].ToString(),
                    sign_resp = dr["sign_resp"].ToString(),
                    sign_spo2 = dr["sign_spo2"].ToString(),
                    sign_waist = dr["sign_waist"].ToString(),
                    sign_hip = dr["sign_hip"].ToString(),
                    sign_uri = dr["sign_uri"].ToString(),
                    sign_head = dr["sign_head"].ToString(),
                    sign_bmi = dr["sign_bmi"].ToString(),
                    sign_status = dr["sign_status"].ToString(),
                    sign_bpd = dr["sign_bpd"].ToString(),
                    sign_sugar = dr["sign_sugar"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.NurseStation.VitalSigns> GetAllPreVitalSigns(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.VitalSigns> sclist = new List<BusinessEntities.NurseStation.VitalSigns>();
            DataTable dt = DataAccessLayer.NurseStation.VitalSigns.GetAllPreVitalSigns(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.VitalSigns
                {
                    signId = Convert.ToInt32(dr["signId"]),
                    sign_appId = Convert.ToInt32(dr["sign_appId"]),
                    sign_temp = dr["sign_temp"].ToString(),
                    sign_pulse = dr["sign_pulse"].ToString(),
                    sign_bp = dr["sign_bp"].ToString(),
                    sign_notes = dr["sign_notes"].ToString(),
                    sign_height = dr["sign_height"].ToString(),
                    sign_weight = dr["sign_weight"].ToString(),
                    sign_resp = dr["sign_resp"].ToString(),
                    sign_spo2 = dr["sign_spo2"].ToString(),
                    sign_waist = dr["sign_waist"].ToString(),
                    sign_hip = dr["sign_hip"].ToString(),
                    sign_uri = dr["sign_uri"].ToString(),
                    sign_head = dr["sign_head"].ToString(),
                    sign_bmi = dr["sign_bmi"].ToString(),
                    sign_bpd = dr["sign_bpd"].ToString(),
                    sign_sugar = dr["sign_sugar"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static int InsertUpdateVitalSigns(BusinessEntities.NurseStation.VitalSigns data)
        {
            data.sign_height = string.IsNullOrEmpty(data.sign_height) ? string.Empty : data.sign_height;
            data.sign_weight = string.IsNullOrEmpty(data.sign_weight) ? string.Empty : data.sign_weight;
            data.sign_resp = string.IsNullOrEmpty(data.sign_resp) ? string.Empty : data.sign_resp;
            data.sign_spo2 = string.IsNullOrEmpty(data.sign_spo2) ? string.Empty : data.sign_spo2;
            data.sign_hip = string.IsNullOrEmpty(data.sign_hip) ? string.Empty : data.sign_hip;
            data.sign_waist = string.IsNullOrEmpty(data.sign_waist) ? string.Empty : data.sign_waist;
            data.sign_head = string.IsNullOrEmpty(data.sign_head) ? string.Empty : data.sign_head;
            data.sign_uri = string.IsNullOrEmpty(data.sign_uri) ? string.Empty : data.sign_uri;
            data.sign_notes = string.IsNullOrEmpty(data.sign_notes) ? string.Empty : data.sign_notes;
            data.sign_sugar = string.IsNullOrEmpty(data.sign_sugar) ? string.Empty : data.sign_sugar;

            return DataAccessLayer.NurseStation.VitalSigns.InsertUpdateVitalSigns(data);
        }

        public static int DeleteVitalSigns(int signId, int sign_madeby)
        {
            return DataAccessLayer.NurseStation.VitalSigns.DeleteVitalSigns(signId, sign_madeby);
        }

        #endregion VitalSigns
    }
}
