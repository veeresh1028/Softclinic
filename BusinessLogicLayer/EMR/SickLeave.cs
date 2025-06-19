using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class SickLeave
    {
        #region  Sick Leave General (Page Load)
        public static List<BusinessEntities.EMR.SickLeaveGeneral> GetAllSickLeaveGeneral(int? appId, int? slId)
        {
            List<BusinessEntities.EMR.SickLeaveGeneral> sclist = new List<BusinessEntities.EMR.SickLeaveGeneral>();
            DataTable dt = DataAccessLayer.EMR.SickLeave.GetAllSickLeaveGeneral(appId, slId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SickLeaveGeneral
                {
                    slId = Convert.ToInt32(dr["slId"]),
                    sl_appId = Convert.ToInt32(dr["sl_appId"]),
                    sl_disease = dr["sl_disease"].ToString(),
                    sl_rest = dr["sl_rest"].ToString(),
                    sl_date1 = Convert.ToDateTime(dr["sl_date1"].ToString()),
                    sl_date2 = Convert.ToDateTime(dr["sl_date2"].ToString()),
                    sl_status = dr["sl_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.SickLeaveGeneral> GetAllPreSickLeaveGeneral(int appId, int patId)
        {
            List<BusinessEntities.EMR.SickLeaveGeneral> sclist = new List<BusinessEntities.EMR.SickLeaveGeneral>();
            DataTable dt = DataAccessLayer.EMR.SickLeave.GetAllPreSickLeaveGeneral(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SickLeaveGeneral
                {
                    slId = Convert.ToInt32(dr["slId"]),
                    sl_appId = Convert.ToInt32(dr["sl_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Sick Leave General (Page Load)
        #region  Sick Leave General CRUD Operations
        public static bool InsertUpdateSickLeaveGeneral(BusinessEntities.EMR.SickLeaveGeneral data)
        {
            data.sl_disease = string.IsNullOrEmpty(data.sl_disease) ? string.Empty : data.sl_disease;
            data.sl_rest = string.IsNullOrEmpty(data.sl_rest) ? string.Empty : data.sl_rest;

            return DataAccessLayer.EMR.SickLeave.InsertUpdateSickLeaveGeneral(data);
        }

        public static int DeleteSickLeaveGeneral(int slId, int sl_madeby)
        {
            return DataAccessLayer.EMR.SickLeave.DeleteSickLeaveGeneral(slId, sl_madeby);
        }
        #endregion  Sick Leave General CRUD Operations

        #region  Sick Leave MOH (Page Load)
        public static List<BusinessEntities.EMR.SickLeaveMOH> GetAllSickLeaveMOH(int? appId, int? slId)
        {
            List<BusinessEntities.EMR.SickLeaveMOH> sclist = new List<BusinessEntities.EMR.SickLeaveMOH>();
            DataTable dt = DataAccessLayer.EMR.SickLeave.GetAllSickLeaveMOH(appId, slId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SickLeaveMOH
                {
                    slId = Convert.ToInt32(dr["slId"]),
                    sl_appId = Convert.ToInt32(dr["sl_appId"]),
                    sl_words = dr["sl_words"].ToString(),
                    pat_city = dr["pat_city"].ToString(),
                    sl_date1 = Convert.ToDateTime(dr["sl_date1"].ToString()),
                    sl_date2 = Convert.ToDateTime(dr["sl_date2"].ToString()),
                    sl_status = dr["sl_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.SickLeaveMOH> GetAllPreSickLeaveMOH(int appId, int patId)
        {
            List<BusinessEntities.EMR.SickLeaveMOH> sclist = new List<BusinessEntities.EMR.SickLeaveMOH>();
            DataTable dt = DataAccessLayer.EMR.SickLeave.GetAllPreSickLeaveMOH(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SickLeaveMOH
                {
                    slId = Convert.ToInt32(dr["slId"]),
                    sl_appId = Convert.ToInt32(dr["sl_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Sick Leave MOH (Page Load)
        #region  Sick Leave MOH CRUD Operations
        public static bool InsertUpdateSickLeaveMOH(BusinessEntities.EMR.SickLeaveMOH data)
        {
            data.sl_words = string.IsNullOrEmpty(data.sl_words) ? string.Empty : data.sl_words;

            return DataAccessLayer.EMR.SickLeave.InsertUpdateSickLeaveMOH(data);
        }

        public static int DeleteSickLeaveMOH(int slId, int sl_madeby)
        {
            return DataAccessLayer.EMR.SickLeave.DeleteSickLeaveMOH(slId, sl_madeby);
        }
        #endregion  Sick Leave MOH CRUD Operations

        #region  Sick Leave DHA (Page Load)
        public static List<BusinessEntities.EMR.SickLeaveDHA> GetAllSickLeaveDHA(int? appId, int? slmId)
        {
            List<BusinessEntities.EMR.SickLeaveDHA> sclist = new List<BusinessEntities.EMR.SickLeaveDHA>();
            DataTable dt = DataAccessLayer.EMR.SickLeave.GetAllSickLeaveDHA(appId, slmId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SickLeaveDHA
                {
                    slmId = Convert.ToInt32(dr["slmId"]),
                    slm_appId = Convert.ToInt32(dr["slm_appId"]),
                    slm_1 = dr["slm_1"].ToString(),
                    slm_4 = dr["slm_4"].ToString(),
                    slm_2 = Convert.ToDateTime(dr["slm_2"].ToString()),
                    slm_3 = Convert.ToDateTime(dr["slm_3"].ToString()),
                    slm_status = dr["slm_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.SickLeaveDHA> GetAllPreSickLeaveDHA(int appId, int patId)
        {
            List<BusinessEntities.EMR.SickLeaveDHA> sclist = new List<BusinessEntities.EMR.SickLeaveDHA>();
            DataTable dt = DataAccessLayer.EMR.SickLeave.GetAllPreSickLeaveDHA(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.SickLeaveDHA
                {
                    slmId = Convert.ToInt32(dr["slmId"]),
                    slm_appId = Convert.ToInt32(dr["slm_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Sick Leave DHA (Page Load)
        #region  Sick Leave DHA CRUD Operations
        public static bool InsertUpdateSickLeaveDHA(BusinessEntities.EMR.SickLeaveDHA data)
        {
            data.slm_4 = string.IsNullOrEmpty(data.slm_4) ? string.Empty : data.slm_4;
            data.slm_1 = string.IsNullOrEmpty(data.slm_1) ? string.Empty : data.slm_1;

            return DataAccessLayer.EMR.SickLeave.InsertUpdateSickLeaveDHA(data);
        }

        public static int DeleteSickLeaveDHA(int slmId, int slm_madeby)
        {
            return DataAccessLayer.EMR.SickLeave.DeleteSickLeaveDHA(slmId, slm_madeby);
        }
        #endregion  Sick Leave DHA CRUD Operations
    }
}
