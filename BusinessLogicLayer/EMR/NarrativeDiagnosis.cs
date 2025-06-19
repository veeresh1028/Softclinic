using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class NarrativeDiagnosis
    {
        #region Narrative Diagnosis
        public static List<BusinessEntities.EMR.NarrativeDiagnosis> GetAllNarrativeDiagnosis(int? appId, int? ntdId)
        {
            List<BusinessEntities.EMR.NarrativeDiagnosis> sclist = new List<BusinessEntities.EMR.NarrativeDiagnosis>();
            DataTable dt = DataAccessLayer.EMR.NarrativeDiagnosis.GetAllNarrativeDiagnosis(appId, ntdId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.NarrativeDiagnosis
                {
                    ntdId = Convert.ToInt32(dr["ntdId"]),
                    ntd_appId = Convert.ToInt32(dr["ntd_appId"]),
                    ntd_1 = dr["ntd_1"].ToString(),
                    ntd_2 = dr["ntd_2"].ToString(),
                    ntd_status = dr["ntd_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.NarrativeDiagnosis> GetAllPreNarrativeDiagnosis(int appId, int patId)
        {
            List<BusinessEntities.EMR.NarrativeDiagnosis> sclist = new List<BusinessEntities.EMR.NarrativeDiagnosis>();
            DataTable dt = DataAccessLayer.EMR.NarrativeDiagnosis.GetAllPreNarrativeDiagnosis(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.NarrativeDiagnosis
                {
                    ntdId = Convert.ToInt32(dr["ntdId"]),
                    ntd_appId = Convert.ToInt32(dr["ntd_appId"]),
                    ntd_1 = dr["ntd_1"].ToString(),
                    ntd_2 = dr["ntd_2"].ToString(),
                    emp_license = dr["emp_license"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        public static List<GetByName> GetNarrative(string query)
        {
            DataTable dt = DataAccessLayer.EMR.NarrativeDiagnosis.GetNarrative(query);
            List<GetByName> data = new List<GetByName>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GetByName _data = new GetByName();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }
            return data;

        }
        public static bool InsertUpdateNarrativeDiagnosis(BusinessEntities.EMR.NarrativeDiagnosis data)
        {
            data.ntd_2=string.IsNullOrEmpty(data.ntd_2)?string.Empty:data.ntd_2;
            return DataAccessLayer.EMR.NarrativeDiagnosis.InsertUpdateNarrativeDiagnosis(data);
        }

        public static int DeleteNarrativeDiagnosis(int ntdId, int ntd_madeby)
        {
            return DataAccessLayer.EMR.NarrativeDiagnosis.DeleteNarrativeDiagnosis(ntdId, ntd_madeby);
        }
        #endregion Narrative Diagnosis
    }
}
