using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class Allergies
    {
        #region Allergies
        public static List<BusinessEntities.NurseStation.Allergies> GetAllAllergies(int ? appId, int? allId)
        {
            List<BusinessEntities.NurseStation.Allergies> sclist = new List<BusinessEntities.NurseStation.Allergies>();
            DataTable dt = DataAccessLayer.NurseStation.Allergies.GetAllAllergies(appId, allId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.Allergies
                {
                    allId = Convert.ToInt32(dr["allId"]),
                    all_appId = Convert.ToInt32(dr["all_appId"]),
                    allergies = dr["allergies"].ToString(),
                    all_for = dr["all_for"].ToString(),
                    all_pexam = dr["all_pexam"].ToString(),
                    all_type = dr["all_type"].ToString(),
                    all_severity = dr["all_severity"].ToString(),
                    all_status = dr["all_status"].ToString(),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.NurseStation.Allergies> GetAllPreAllergies(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.Allergies> sclist = new List<BusinessEntities.NurseStation.Allergies>();
            DataTable dt = DataAccessLayer.NurseStation.Allergies.GetAllPreAllergies(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.Allergies
                {
                    allId = Convert.ToInt32(dr["allId"]),
                    all_appId = Convert.ToInt32(dr["all_appId"]),
                    allergies = dr["allergies"].ToString(),
                    all_for = dr["all_for"].ToString(),
                    all_pexam = dr["all_pexam"].ToString(),
                    all_type = dr["all_type"].ToString(),
                    all_severity = dr["all_severity"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        public static bool InsertUpdateAllergies(BusinessEntities.NurseStation.Allergies data)
        {
            data.allergies = string.IsNullOrEmpty(data.allergies) ? string.Empty : data.allergies;
            data.all_for = string.IsNullOrEmpty(data.all_for) ? string.Empty : data.all_for;
            data.all_pexam = string.IsNullOrEmpty(data.all_pexam) ? string.Empty : data.all_pexam;
            data.all_type = string.IsNullOrEmpty(data.all_type) ? string.Empty : data.all_type;
            data.all_severity = string.IsNullOrEmpty(data.all_severity) ? string.Empty : data.all_severity;

            return DataAccessLayer.NurseStation.Allergies.InsertUpdateAllergies(data);
        }
        public static List<CommonDDL> get_MalaffiNabihRiyatiData(string query,string type)
        {
            DataTable dt = DataAccessLayer.NurseStation.Allergies.get_MalaffiNabihRiyatiData(query, type);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
        public static int DeleteAllergies(int allId,  int all_madeby)
        {
            return DataAccessLayer.NurseStation.Allergies.DeleteAllergies(allId, all_madeby);
        }

        #endregion Allergies

    }
}
