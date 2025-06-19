using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Diagnosis
    {
        #region Diagnosis Master (Page Load)
        public static List<BusinessEntities.Masters.Diagnosis> SearchDiagnosis(SearchDiagnosis data)
        {
            List<BusinessEntities.Masters.Diagnosis> diagnosis = new List<BusinessEntities.Masters.Diagnosis>();

            DataTable dt = new DataTable();

            if (data.search_type == 1)
            {
                dt = DataAccessLayer.Masters.Diagnosis.SearchDiagnosis(data);
            }
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    diagnosis.Add(new BusinessEntities.Masters.Diagnosis
                    {
                        diagId = Convert.ToInt32(dr["diagId"]),
                        diag_dept = Convert.ToInt32(dr["diag_dept"]),
                        diag_class = dr["diag_class"].ToString(),
                        department = dr["department"].ToString(),
                        diag_code = dr["diag_code"].ToString(),
                        diag_name = dr["diag_name"].ToString(),
                        diag_notes = dr["diag_notes"].ToString(),
                        actionvisible = dr["actionvisible"].ToString(),
                        diag_status = dr["diag_status"].ToString()
                    });
                }
            }

            return diagnosis;
        }

        public static List<BusinessEntities.Masters.Diagnosis> GetDiagnosis(int? diagId, int? diag_dept)
        {
            List<BusinessEntities.Masters.Diagnosis> diaglist = new List<BusinessEntities.Masters.Diagnosis>();
            DataTable dt = DataAccessLayer.Masters.Diagnosis.GetDiagnosis(diagId, diag_dept);

            foreach (DataRow dr in dt.Rows)
            {
                diaglist.Add(new BusinessEntities.Masters.Diagnosis
                {
                    diagId = Convert.ToInt32(dr["diagId"]),
                    diag_dept = Convert.ToInt32(dr["diag_dept"]),
                    diag_class = dr["diag_class"].ToString(),
                    department = dr["department"].ToString(),
                    diag_code = dr["diag_code"].ToString(),
                    diag_name = dr["diag_name"].ToString(),
                    diag_notes = dr["diag_notes"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    diag_status = dr["diag_status"].ToString()
                });
            }
            return diaglist;
        }

        public static List<CommonDDL> GetDiagnosisCodes(GetDiagnosisCode code)
        {
            DataTable dt = DataAccessLayer.Masters.Diagnosis.GetDiagnosisCodes(code);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }
        #endregion

        #region Diagnosis CRUD Operations
        public static bool InsertUpdateDiagnosis(BusinessEntities.Masters.Diagnosis diagnosis)
        {
            return DataAccessLayer.Masters.Diagnosis.InsertUpdateDiagnosis(diagnosis);
        }

        public static List<BusinessEntities.Masters.Diagnosis> GetDiagnosisById(int diagId)
        {
            List<BusinessEntities.Masters.Diagnosis> diaglist = new List<BusinessEntities.Masters.Diagnosis>();
            DataTable dt = DataAccessLayer.Masters.Diagnosis.GetDiagnosisById(diagId);

            foreach (DataRow dr in dt.Rows)
            {
                diaglist.Add(new BusinessEntities.Masters.Diagnosis
                {
                    diagId = Convert.ToInt32(dr["diagId"]),
                    diag_dept = Convert.ToInt32(dr["diag_dept"]),
                    diag_class = dr["diag_class"].ToString(),
                    diag_code = dr["diag_code"].ToString(),
                    diag_name = dr["diag_name"].ToString(),
                    diag_notes = dr["diag_notes"].ToString(),
                    diag_status = dr["diag_status"].ToString()
                });
            }
            return diaglist;
        }

        public static int UpdateDiagnosisStatus(int diagId, string diag_status)
        {
            return DataAccessLayer.Masters.Diagnosis.UpdateDiagnosisStatus(diagId, diag_status);
        }
        #endregion
    }
}