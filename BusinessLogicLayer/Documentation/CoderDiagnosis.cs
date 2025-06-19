using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Documentation
{
    public class CoderDiagnosis
    {
        public static List<BusinessEntities.Documentation.CoderDiagnosis> GetCoderDiagnosis(int? appId, int? codId)
        {
            List<BusinessEntities.Documentation.CoderDiagnosis> sclist = new List<BusinessEntities.Documentation.CoderDiagnosis>();

            DataTable dt = DataAccessLayer.Documentation.CoderDiagnosis.GetCoderDiagnosis(appId, codId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.Documentation.CoderDiagnosis
                {
                    codId = Convert.ToInt32(dr["codId"]),
                    cod_appId = Convert.ToInt32(dr["cod_appId"]),
                    cod_type = dr["cod_type"].ToString(),
                    diag_name = dr["diag_name"].ToString(),
                    cod_notes = dr["cod_notes"].ToString(),
                    cod_year = Convert.ToInt32(dr["cod_year"].ToString()),
                    cod_diagnosis = Convert.ToInt32(dr["cod_diagnosis"].ToString()),
                    diag_code = dr["diag_code"].ToString(),
                    cod_status = dr["cod_status"].ToString(),
                });
            }

            return sclist;
        }

        public static DataTable GetAllCoderDiagnosisForPriorRequests(int appId, int padId)
        {
            return DataAccessLayer.Documentation.CoderDiagnosis.GetCoderDiagnosis(appId, padId);
        }

        public static int ChangeDiagnosisType(int codId, string cod_type)
        {
            return DataAccessLayer.Documentation.CoderDiagnosis.ChangeDiagnosisType(codId, cod_type);
        }

        public static List<CommonDDL> GetDiagnosis(string query, int type, int cod_madeby)
        {
            DataTable dt = DataAccessLayer.Documentation.CoderDiagnosis.GetDiagnosis(query, type, cod_madeby);

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

        public static int InsertCoderDiagnosis(BusinessEntities.Documentation.CoderDiagnosis data)
        {
            data.cod_type = string.IsNullOrEmpty(data.cod_type) ? string.Empty : data.cod_type;
            data.cod_notes = string.IsNullOrEmpty(data.cod_notes) ? string.Empty : data.cod_notes;

            return DataAccessLayer.Documentation.CoderDiagnosis.InsertCoderDiagnosis(data);
        }

        public static bool UpdateCoderDiagnosis(BusinessEntities.Documentation.CoderDiagnosis data)
        {
            data.cod_notes = string.IsNullOrEmpty(data.cod_notes) ? string.Empty : data.cod_notes;

            return DataAccessLayer.Documentation.CoderDiagnosis.UpdateCoderDiagnosis(data);
        }

        public static int DeleteCoderDiagnosis(int codId, int cod_madeby)
        {
            return DataAccessLayer.Documentation.CoderDiagnosis.DeleteCoderDiagnosis(codId, cod_madeby);
        }

        public static List<BusinessEntities.Documentation.CoderDiagnosis> GetAllPreviousCoderDiagnosis(int appId, int patId)
        {
            List<BusinessEntities.Documentation.CoderDiagnosis> sclist = new List<BusinessEntities.Documentation.CoderDiagnosis>();

            DataTable dt = DataAccessLayer.Documentation.CoderDiagnosis.GetAllPreCoderDiagnosis(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.Documentation.CoderDiagnosis
                {
                    codId = Convert.ToInt32(dr["codId"]),
                    cod_appId = Convert.ToInt32(dr["cod_appId"]),
                    cod_type = dr["cod_type"].ToString(),
                    diag_code = dr["diag_code"].ToString(),
                    diag_name = dr["diag_name"].ToString(),
                    cod_notes = dr["cod_notes"].ToString(),
                    cod_year = Convert.ToInt32(dr["cod_year"].ToString()),
                    doctor_Name = dr["doctor_Name"].ToString(),
                    madeby_name = dr["emp_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }

            return sclist;
        }

        public static int CopyCoderDiagnosis(int codId, int cod_appId, int cod_madeby)
        {
            return DataAccessLayer.Documentation.CoderDiagnosis.CopyCoderDiagnosis(codId, cod_appId, cod_madeby);
        }
    }
}