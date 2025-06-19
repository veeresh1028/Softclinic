using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class AppointmentStatusColor
    {
        #region Appointment Status Color (Page Load)
        public static List<BusinessEntities.Masters.AppointmentStatusColor> GetAppointmentStatusColor(int? apsId)
        {
            List<BusinessEntities.Masters.AppointmentStatusColor> apscolorlist = new List<BusinessEntities.Masters.AppointmentStatusColor>();

            DataTable dt = DataAccessLayer.Masters.AppointmentStatusColor.GetAppointmentStatusColor(apsId);

            foreach (DataRow dr in dt.Rows)
            {
                apscolorlist.Add(new BusinessEntities.Masters.AppointmentStatusColor
                {
                    apsId = Convert.ToInt32(dr["apsId"]),
                    aps_status = dr["aps_status"].ToString(),
                    aps_color = dr["aps_color"].ToString(),
                    aps_activity_status = dr["aps_activity_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    aps_date_created = Convert.ToDateTime(dr["aps_date_created"]),
                    cm_madeby_name = dr["cm_madeby_name"].ToString(),
                });
            }
            return apscolorlist;
        }
        #endregion

        #region Appointment Status Color CRUD Operations
        public static bool InsertUpdateAppointmentStatusColor(BusinessEntities.Masters.AppointmentStatusColor appointmentstatuscolor)
        {
            return DataAccessLayer.Masters.AppointmentStatusColor.InsertUpdateAppointmentStatusColor(appointmentstatuscolor);
        }

        public static int UpdateAppointmentStatusColorStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.AppointmentStatusColor.UpdateAppointmentStatusColorStatus(tgId, tg_status);
        }
        #endregion
    }
}