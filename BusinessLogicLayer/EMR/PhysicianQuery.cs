using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class PhysicianQuery
    {
        #region  Physician Query (Page Load)
        public static List<BusinessEntities.EMR.PhysicianQuery> GetAllPhysicianQuery(int? appId, int? pqId)
        {
            List<BusinessEntities.EMR.PhysicianQuery> sclist = new List<BusinessEntities.EMR.PhysicianQuery>();
            DataTable dt = DataAccessLayer.EMR.PhysicianQuery.GetAllPhysicianQuery(appId, pqId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PhysicianQuery
                {
                    pqId = Convert.ToInt32(dr["pqId"]),
                    pq_appId = Convert.ToInt32(dr["pq_appId"]),
                    pq_txt1 = dr["pq_txt1"].ToString(),
                    pq_txt2 = dr["pq_txt2"].ToString(),
                    pq_txt3 = dr["pq_txt3"].ToString(),
                    pq_txt4 = dr["pq_txt4"].ToString(),
                    pq_txt5 = dr["pq_txt5"].ToString(),
                    pq_status = dr["pq_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.PhysicianQuery> GetAllPrePhysicianQuery(int appId, int patId)
        {
            List<BusinessEntities.EMR.PhysicianQuery> sclist = new List<BusinessEntities.EMR.PhysicianQuery>();
            DataTable dt = DataAccessLayer.EMR.PhysicianQuery.GetAllPrePhysicianQuery(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PhysicianQuery
                {
                    pqId = Convert.ToInt32(dr["pqId"]),
                    pq_appId = Convert.ToInt32(dr["pq_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Physician Query (Page Load)
        #region  Physician Query CRUD Operations
        public static bool InsertUpdatePhysicianQuery(BusinessEntities.EMR.PhysicianQuery data)
        {
            data.pq_txt1 = string.IsNullOrEmpty(data.pq_txt1) ? string.Empty : data.pq_txt1;
            data.pq_txt2 = string.IsNullOrEmpty(data.pq_txt2) ? string.Empty : data.pq_txt2;
            data.pq_txt3 = string.IsNullOrEmpty(data.pq_txt3) ? string.Empty : data.pq_txt3;
            data.pq_txt4 = string.IsNullOrEmpty(data.pq_txt4) ? string.Empty : data.pq_txt4;
            data.pq_txt5 = string.IsNullOrEmpty(data.pq_txt5) ? string.Empty : data.pq_txt5;

            return DataAccessLayer.EMR.PhysicianQuery.InsertUpdatePhysicianQuery(data);
        }

        public static int DeletePhysicianQuery(int pqId, int pq_madeby)
        {
            return DataAccessLayer.EMR.PhysicianQuery.DeletePhysicianQuery(pqId, pq_madeby);
        }
        #endregion  Physician Query CRUD Operations

        #region  Physician Nursing Query (Page Load)
        public static List<BusinessEntities.EMR.PhysicianNursingQuery> GetAllPhysicianNursingQuery(int? appId, int? pnqId)
        {
            List<BusinessEntities.EMR.PhysicianNursingQuery> sclist = new List<BusinessEntities.EMR.PhysicianNursingQuery>();
            DataTable dt = DataAccessLayer.EMR.PhysicianQuery.GetAllPhysicianNursingQuery(appId, pnqId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PhysicianNursingQuery
                {
                    pnqId = Convert.ToInt32(dr["pnqId"]),
                    pnq_appId = Convert.ToInt32(dr["pnq_appId"]),
                    pnq_query = dr["pnq_query"].ToString(),
                    pnq_response = dr["pnq_response"].ToString(),
                    pnq_status = dr["pnq_status"].ToString(),
                    fromemp = dr["fromemp"].ToString(),
                    toemp = dr["toemp"].ToString(),
                    pnq_date_created = Convert.ToDateTime(dr["pnq_date_created"].ToString()),
                    pnq_date_modified = Convert.ToDateTime(dr["pnq_date_modified"].ToString()),


                });
            }
            return sclist;
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
        public static List<CommonDDL> GetEmployeeDetailsByID(int empId)
        {
            DataTable dt = DataAccessLayer.EMR.PhysicianQuery.GetEmployeeDetailsByID(empId);
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

        #endregion  Physician Nursing Query (Page Load)
        #region  Physician Nursing Query CRUD Operations
        public static bool InsertUpdatePhysicianNursingQuery(BusinessEntities.EMR.PhysicianNursingQuery data)
        {
            data.pnq_query = string.IsNullOrEmpty(data.pnq_query) ? string.Empty : data.pnq_query;
            data.pnq_response = string.IsNullOrEmpty(data.pnq_response) ? string.Empty : data.pnq_response;
            
            return DataAccessLayer.EMR.PhysicianQuery.InsertUpdatePhysicianNursingQuery(data);
        }

        public static int DeletePhysicianNursingQuery(int pnqId, int pnq_madeby)
        {
            return DataAccessLayer.EMR.PhysicianQuery.DeletePhysicianNursingQuery(pnqId, pnq_madeby);
        }
        #endregion  Physician Nursing Query CRUD Operations

    }
}
