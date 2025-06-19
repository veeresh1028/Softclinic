using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class NurseNotes
    {
        #region NurseNotes (Page Load)
        public static List<BusinessEntities.NurseStation.NurseNotes> GetAllNurseNotes(int appId, int? nurseId)
        {
            List<BusinessEntities.NurseStation.NurseNotes> sclist = new List<BusinessEntities.NurseStation.NurseNotes>();
            DataTable dt = DataAccessLayer.NurseStation.NurseNotes.GetAllNurseNotes(appId, nurseId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.NurseNotes
                {
                    nurseId = Convert.ToInt32(dr["nurseId"]),
                    nurse_appId = Convert.ToInt32(dr["nurse_appId"]),
                    nurse_notes = dr["nurse_notes"].ToString(),
                    nurse_date_created = Convert.ToDateTime(dr["nurse_date_created"].ToString()),
                    nurse_status = dr["nurse_status"].ToString(),
                    madeby_name = dr["emp_name"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.NurseStation.NurseNotes> GetAllPreNurseNotes(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.NurseNotes> sclist = new List<BusinessEntities.NurseStation.NurseNotes>();
            DataTable dt = DataAccessLayer.NurseStation.NurseNotes.GetAllPreNurseNotes(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.NurseNotes
                {
                    nurseId = Convert.ToInt32(dr["nurseId"]),
                    nurse_appId = Convert.ToInt32(dr["nurse_appId"]),
                    nurse_notes = dr["nurse_notes"].ToString(),
                    emp_license = dr["emp_license"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    nurse_date_created = Convert.ToDateTime(dr["nurse_date_created"].ToString()),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),
                    madeby_name = dr["emp_name"].ToString(),

                });
            }
            return sclist;
        }


        #endregion NurseNotes (Page Load)

        #region NurseNotes Favourites CRUD Operations

        public static bool InsertUpdateNurseNotes(BusinessEntities.NurseStation.NurseNotes data)
        {

            return DataAccessLayer.NurseStation.NurseNotes.InsertUpdateNurseNotes(data);
        }
        public static int DeleteNurseNotes(int nurseId, int nurse_madeby)
        {
            return DataAccessLayer.NurseStation.NurseNotes.DeleteNurseNotes(nurseId, nurse_madeby);
        }

        #endregion NurseNotes Favourites CRUD Operations
    }
}
