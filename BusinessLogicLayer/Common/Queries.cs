using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Common
{
    public class Queries
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

        #region Queries Page Load
        //public static List<BusinessEntities.Documentation.CoderQueries> GetAllQueries(int? empId)
        //{
        //    List<BusinessEntities.Documentation.CoderQueries> sclist = new List<BusinessEntities.Documentation.CoderQueries>();
        //    DataTable dt = DataAccessLayer.Common.Queries.GetAllQueries(empId);

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        sclist.Add(new BusinessEntities.Documentation.CoderQueries
        //        {
        //            emp_license = dr["emp_license"].ToString(),
        //            app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),
        //            doctor_name = dr["doctor_name"].ToString(),
        //            qaId = Convert.ToInt32(dr["qaId"]),
        //            qa_branch = Convert.ToInt32(dr["qa_branch"]),
        //            qa_branch_name = dr["qa_branch_name"].ToString(),
        //            pat_name_code = dr["pat_name_code"].ToString(),
        //            qa_date_display = dr["qa_date_display"].ToString(),
        //            qa_from_name = dr["qa_from_name"].ToString(),
        //            qa_to_name = dr["qa_to_name"].ToString(),
        //            qa_subject = dr["qa_subject"].ToString(),
        //            qa_type_name = dr["qa_type_name"].ToString(),
        //            qa_query = dr["qa_query"].ToString(),
        //            qa_screen = dr["qa_screen"].ToString(),
        //            response = dr["response"].ToString(),
        //            qa_status = dr["qa_status"].ToString(),
        //            qa_appId = Convert.ToInt32(dr["qa_appId"]),
        //            qa_from = Convert.ToInt32(dr["qa_from"]),
        //            qa_to = Convert.ToInt32(dr["qa_to"]),
        //            qa_date = Convert.ToDateTime(dr["qa_date"].ToString()),
        //            qa_type = Convert.ToInt32(dr["qa_type"]),
        //            qa_madeby = Convert.ToInt32(dr["qa_madeby"]),
        //            qa_date_created = Convert.ToDateTime(dr["qa_date_created"].ToString()),
        //            qa_date_modified = Convert.ToDateTime(dr["qa_date_modified"].ToString()),
        //            DocumentPaths = dr["qad_paths"].ToString().Split(',').Select(path => path.Trim()).ToList(),


        //    });
        //    }
        //    return sclist;
        //}

        public static List<BusinessEntities.Documentation.CoderQueries> GetAllQueries(QueriesSearch data)
        {
            List<BusinessEntities.Documentation.CoderQueries> sclist = new List<BusinessEntities.Documentation.CoderQueries>();

            DataTable dt = DataAccessLayer.Common.Queries.GetAllQueries(data);

            foreach (DataRow dr in dt.Rows)
            {
                var coderQuery = new BusinessEntities.Documentation.CoderQueries
                {
                    emp_license = dr["emp_license"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),
                    doctor_name = dr["doctor_name"].ToString(),
                    qaId = Convert.ToInt32(dr["qaId"]),
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

        public static bool InsertUpdateResponses(BusinessEntities.Common.Queries data)
        {
            data.res_desc = string.IsNullOrEmpty(data.res_desc) ? string.Empty : data.res_desc;

            return DataAccessLayer.Common.Queries.InsertUpdateResponses(data);
        } 
        #endregion
    }
}