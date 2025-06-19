using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class DoctorQueries
    {
        public static List<BusinessEntities.EMR.DoctorQueries> GetAllDoctorQueries(int? appId, int? qaId)
        {
            List<BusinessEntities.EMR.DoctorQueries> dqlist = new List<BusinessEntities.EMR.DoctorQueries>();

            DataTable dt = DataAccessLayer.EMR.DoctorQueries.GetAllDoctorQueries(appId, qaId);

            foreach (DataRow dr in dt.Rows)
            {
                var doctorQuery = new BusinessEntities.EMR.DoctorQueries
                {
                    emp_license = dr["emp_license"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),
                    doctor_name = dr["doctor_name"].ToString(),
                    qaId = Convert.ToInt32(dr["qaId"]),
                    app_doctor = Convert.ToInt32(dr["app_doctor"]),
                    qa_branch = Convert.ToInt32(dr["qa_branch"]),
                    qa_branch_name = dr["qa_branch_name"].ToString(),
                    pat_name_code = dr["pat_name_code"].ToString(),
                    qa_date_display = dr["qa_date_display"].ToString(),
                    qa_from_name = dr["qa_from_name"].ToString(),
                    qa_to_name = dr["qa_to_name"].ToString(),
                    qa_subject = dr["qa_subject"].ToString(),
                    qa_type_name = dr["qa_type_name"].ToString(),
                    qa_query = dr["qa_query"].ToString(),
                    qa_screen = dr["qa_screen"].ToString(),
                    response = dr["response"].ToString(),
                    qa_status = dr["qa_status"].ToString(),
                    qa_appId = Convert.ToInt32(dr["qa_appId"]),
                    qa_from = Convert.ToInt32(dr["qa_from"]),
                    qa_to = Convert.ToInt32(dr["qa_to"]),
                    qa_date = Convert.ToDateTime(dr["qa_date"].ToString()),
                    qa_type = Convert.ToInt32(dr["qa_type"]),
                    qa_madeby = Convert.ToInt32(dr["qa_madeby"]),
                    qa_date_created = Convert.ToDateTime(dr["qa_date_created"].ToString()),
                    qa_date_modified = Convert.ToDateTime(dr["qa_date_modified"].ToString())
                };

                doctorQuery.DocumentPaths = new List<string>();

                foreach (var path in dr["qad_paths"].ToString().Split(','))
                {
                    doctorQuery.DocumentPaths.Add(path.Trim());
                }

                dqlist.Add(doctorQuery);
            }

            return dqlist;
        }

        public static int InsertDocuments(BusinessEntities.EMR.DoctorFileInformation fileInfo, int qaId)
        {
            return DataAccessLayer.EMR.DoctorQueries.InsertDocuments(fileInfo, qaId);
        }

        public static int DeleteDoctorQuery(int qaId, int qa_madeby)
        {
            return DataAccessLayer.EMR.DoctorQueries.DeleteDoctorQuery(qaId, qa_madeby);
        }

        public static int InsertDoctorQuery(BusinessEntities.EMR.DoctorQueries data)
        {
            data.qa_query = string.IsNullOrEmpty(data.qa_query) ? string.Empty : data.qa_query;
            data.qa_subject = string.IsNullOrEmpty(data.qa_subject) ? string.Empty : data.qa_subject;
            DateTime? card21 = data.qa_date;

            if (data.qa_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.qa_date = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.qa_date = DateTime.Parse("01/01/1950");
            }
            return DataAccessLayer.EMR.DoctorQueries.InsertDoctorQuery(data);
        }

        public static int UpdateDoctorQuery(BusinessEntities.EMR.DoctorQueries data)
        {
            data.qa_query = string.IsNullOrEmpty(data.qa_query) ? string.Empty : data.qa_query;
            data.qa_subject = string.IsNullOrEmpty(data.qa_subject) ? string.Empty : data.qa_subject;
            DateTime? card21 = data.qa_date;

            if (data.qa_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.qa_date = card21.HasValue ? card21.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.qa_date = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.DoctorQueries.UpdateDoctorQuery(data);
        }

        public static List<CommonDDL> GetMsgType(string query, int mt_branch, int? mtId)
        {
            mtId = mtId ?? 0;

            DataTable dt = DataAccessLayer.EMR.DoctorQueries.GetMsgType(query, mt_branch, mtId);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["mtId"].ToString());
                    _data.text = dr["mt_type"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<CommonDDL> GetEmployeeDept(string query)
        {
            DataTable dt = DataAccessLayer.EMR.PhysicianQuery.GetEmployeeDept(query);

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

        public static List<CommonDDL> GetCoders()
        {
            DataTable dt = DataAccessLayer.EMR.DoctorQueries.GetCoders();

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
    }
}