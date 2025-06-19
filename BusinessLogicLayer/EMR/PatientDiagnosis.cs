using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BusinessLogicLayer.EMR
{
    public class PatientDiagnosis
    {
        #region Patient Diagnosis (Page Load)
        public static List<BusinessEntities.EMR.PatientDiagnosis> GetAllPatientDiagnosis(int? appId, int? padId)
        {
            List<BusinessEntities.EMR.PatientDiagnosis> pdlist = new List<BusinessEntities.EMR.PatientDiagnosis>();

            DataTable dt = DataAccessLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, padId);

            foreach (DataRow dr in dt.Rows)
            {
                pdlist.Add(new BusinessEntities.EMR.PatientDiagnosis
                {
                    padId = Convert.ToInt32(dr["padId"]),
                    pad_appId = Convert.ToInt32(dr["pad_appId"]),
                    pad_type = dr["pad_type"].ToString(),
                    diag_name = dr["diag_name"].ToString(),
                    pad_notes = dr["pad_notes"].ToString(),
                    pad_year = Convert.ToInt32(dr["pad_year"].ToString()),
                    pad_diagnosis = Convert.ToInt32(dr["pad_diagnosis"].ToString()),
                    diag_code = dr["diag_code"].ToString(),
                    pad_status = dr["pad_status"].ToString()
                });
            }

            return pdlist;
        }

        public static DataTable GetAllPatientDiagnosisPR(int appId, int padId)
        {
            return DataAccessLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, padId);
        }

        public static List<BusinessEntities.EMR.PatientDiagnosis> GetAllPrePatientDiagnosis(int appId, int patId)
        {
            List<BusinessEntities.EMR.PatientDiagnosis> pdlist = new List<BusinessEntities.EMR.PatientDiagnosis>();

            DataTable dt = DataAccessLayer.EMR.PatientDiagnosis.GetAllPrePatientDiagnosis(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                pdlist.Add(new BusinessEntities.EMR.PatientDiagnosis
                {
                    padId = Convert.ToInt32(dr["padId"]),
                    pad_appId = Convert.ToInt32(dr["pad_appId"]),
                    pad_type = dr["pad_type"].ToString(),
                    diag_code = dr["diag_code"].ToString(),
                    diag_name = dr["diag_name"].ToString(),
                    pad_notes = dr["pad_notes"].ToString(),
                    pad_year = Convert.ToInt32(dr["pad_year"].ToString()),
                    emp_license = dr["emp_license"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString())
                });
            }

            return pdlist;
        }

        public static List<CommonDDL> GetDiagnosis(string query, int type, int pad_madeby)
        {
            DataTable dt = DataAccessLayer.EMR.PatientDiagnosis.GetDiagnosis(query, type, pad_madeby);

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
        #endregion

        #region Patient Diagnosis CRUD Operations
        public static int InsertPatientDiagnosis(BusinessEntities.EMR.PatientDiagnosis data)
        {
            data.pad_type = string.IsNullOrEmpty(data.pad_type) ? string.Empty : data.pad_type;
            data.pad_notes = string.IsNullOrEmpty(data.pad_notes) ? string.Empty : data.pad_notes;

            return DataAccessLayer.EMR.PatientDiagnosis.InsertPatientDiagnosis(data);
        }

        public static bool UpdatePatientDiagnosis(BusinessEntities.EMR.PatientDiagnosis data)
        {
            data.pad_type = string.IsNullOrEmpty(data.pad_type) ? string.Empty : data.pad_type;
            data.pad_notes = string.IsNullOrEmpty(data.pad_notes) ? string.Empty : data.pad_notes;

            return DataAccessLayer.EMR.PatientDiagnosis.UpdatePatientDiagnosis(data);
        }

        public static int ChangeDiagnosisType(int padId, string pad_type)
        {
            return DataAccessLayer.EMR.PatientDiagnosis.ChangeDiagnosisType(padId, pad_type);
        }

        public static int DeletePatientDiagnosis(int padId, int pad_madeby)
        {
            return DataAccessLayer.EMR.PatientDiagnosis.DeletePatientDiagnosis(padId, pad_madeby);
        }
        #endregion 
    }
}