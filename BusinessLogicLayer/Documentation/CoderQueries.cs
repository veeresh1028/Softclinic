using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BusinessLogicLayer.Documentation
{
    public class CoderQueries
    {
        public static List<BusinessEntities.Documentation.CoderQueries> GetAllCoderQueries(int? appId, int? qaId)
        {
            List<BusinessEntities.Documentation.CoderQueries> sclist = new List<BusinessEntities.Documentation.CoderQueries>();

            DataTable dt = DataAccessLayer.Documentation.CoderQueries.GetAllCoderQueries(appId, qaId);

            foreach (DataRow dr in dt.Rows)
            {
                var coderQuery = new BusinessEntities.Documentation.CoderQueries
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

                coderQuery.DocumentPaths = new List<string>();

                foreach (var path in dr["qad_paths"].ToString().Split(','))
                {
                    coderQuery.DocumentPaths.Add(path.Trim());
                }

                sclist.Add(coderQuery);
            }

            return sclist;
        }

        public static int InsertDocuments(BusinessEntities.Documentation.FileInformation fileInfo, int qaId)
        {
            return DataAccessLayer.Documentation.CoderQueries.InsertDocuments(fileInfo, qaId);
        }

        public static int DeleteCoderQueries(int qaId, int qa_madeby)
        {
            return DataAccessLayer.Documentation.CoderQueries.DeleteCoderQueries(qaId, qa_madeby);
        }

        public static int InsertUpdateCoderQueries(BusinessEntities.Documentation.CoderQueries data)
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

            return DataAccessLayer.Documentation.CoderQueries.InsertUpdateCoderQueries(data);
        }

        public static int UpdateCoderQueries(BusinessEntities.Documentation.CoderQueries data)
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

            return DataAccessLayer.Documentation.CoderQueries.UpdateCoderQueries(data);
        }

        public static List<CommonDDL> GetMsgType(string query, int mt_branch, int? mtId)
        {
            mtId = mtId ?? 0;

            DataTable dt = DataAccessLayer.Documentation.CoderQueries.GetMsgType(query, mt_branch, mtId);

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
    }
}