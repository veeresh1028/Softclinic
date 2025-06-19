using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class ProgressNotes
    {
        #region ProgressNotes (Page Load)
        public static List<BusinessEntities.EMR.ProgressNotes> GetAllProgressNotes(int? appId, int? mnId)
        {
            List<BusinessEntities.EMR.ProgressNotes> sclist = new List<BusinessEntities.EMR.ProgressNotes>();
            DataTable dt = DataAccessLayer.EMR.ProgressNotes.GetAllProgressNotes(appId, mnId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ProgressNotes
                {
                    mnId = Convert.ToInt32(dr["mnId"]),
                    mn_appId = Convert.ToInt32(dr["mn_appId"]),
                    mn_visitPlan = dr["mn_visitPlan"].ToString(),
                    mn_notes = dr["mn_notes"].ToString(),
                    mn_instructions = dr["mn_instructions"].ToString(),
                    mn_date_created = Convert.ToDateTime(dr["mn_date_created"].ToString()),
                    mn_status = dr["mn_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.ProgressNotes> GetAllPreProgressNotes(int appId, int patId)
        {
            List<BusinessEntities.EMR.ProgressNotes> sclist = new List<BusinessEntities.EMR.ProgressNotes>();
            DataTable dt = DataAccessLayer.EMR.ProgressNotes.GetAllPreProgressNotes(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ProgressNotes
                {
                    mnId = Convert.ToInt32(dr["mnId"]),
                    mn_appId = Convert.ToInt32(dr["mn_appId"]),
                    mn_visitPlan = dr["mn_visitPlan"].ToString(),
                    mn_notes = dr["mn_notes"].ToString(),
                    mn_instructions = dr["mn_instructions"].ToString(),
                    emp_license = dr["emp_license"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    mn_date_created = Convert.ToDateTime(dr["mn_date_created"].ToString()),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static List<GetByName> GetNotes(string query,string nsm_flag)
        {
            DataTable dt = DataAccessLayer.EMR.ProgressNotes.GetNotes(query , nsm_flag);
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

        #endregion ProgressNotes (Page Load)

        #region ProgressNotes CRUD Operations

        public static bool InsertUpdateProgressNotes(BusinessEntities.EMR.ProgressNotes data)
        {

            return DataAccessLayer.EMR.ProgressNotes.InsertUpdateProgressNotes(data);
        }

        public static int DeleteProgressNotes(int mnId, int mn_madeby)
        {
            return DataAccessLayer.EMR.ProgressNotes.DeleteProgressNotes(mnId, mn_madeby);
        }
        #endregion ProgressNotes  CRUD Operations
    }
}
