using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class Addendum
    {
        #region Addendum (Page Load)
        public static List<BusinessEntities.EMR.Addendum> GetAllAddendum(int appId, int? addeId)
        {
            List<BusinessEntities.EMR.Addendum> sclist = new List<BusinessEntities.EMR.Addendum>();
            DataTable dt = DataAccessLayer.EMR.Addendum.GetAllAddendum(appId, addeId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Addendum
                {
                    addeId = Convert.ToInt32(dr["addeId"]),
                    adde_appId = Convert.ToInt32(dr["adde_appId"]),
                    adde_for = dr["adde_for"].ToString(),
                    adde_notes = dr["adde_notes"].ToString(),
                    adde_for_name = dr["adde_for_name"].ToString(),
                    adde_date_created = Convert.ToDateTime(dr["adde_date_created"].ToString()),
                    adde_status = dr["adde_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.Addendum> GetAllPreAddendum(int appId, int patId)
        {
            List<BusinessEntities.EMR.Addendum> sclist = new List<BusinessEntities.EMR.Addendum>();
            DataTable dt = DataAccessLayer.EMR.Addendum.GetAllPreAddendum(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Addendum
                {
                    addeId = Convert.ToInt32(dr["addeId"]),
                    adde_appId = Convert.ToInt32(dr["adde_appId"]),
                    adde_notes = dr["adde_notes"].ToString(),
                    adde_for = dr["adde_for"].ToString(),
                    adde_for_name = dr["adde_for_name"].ToString(),
                    emp_license = dr["emp_license"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    adde_date_created = Convert.ToDateTime(dr["adde_date_created"].ToString()),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static List<CommonDDL> GetEMRTabMaster(string query)
        {
            DataTable dt = DataAccessLayer.EMR.Addendum.GetEMRTabMaster(query);
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
         public static List<CommonDDLFORMS> GetEMRTabMaster_for_Reimb_Forms(string query)
        {
            DataTable dt = DataAccessLayer.EMR.Addendum.GetEMRTabMaster_for_Reimb_Forms(query);
            List<CommonDDLFORMS> data = new List<CommonDDLFORMS>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDLFORMS _data = new CommonDDLFORMS();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }
            return data;

        }

        #endregion Addendum (Page Load)

        #region Addendum CRUD Operations

        public static bool InsertUpdateAddendum(BusinessEntities.EMR.Addendum data)
        {

            return DataAccessLayer.EMR.Addendum.InsertUpdateAddendum(data);
        }

        public static int DeleteAddendum(int addeId, int adde_madeby)
        {
            return DataAccessLayer.EMR.Addendum.DeleteAddendum(addeId, adde_madeby);
        }
        #endregion Addendum  CRUD Operations
    }
}
