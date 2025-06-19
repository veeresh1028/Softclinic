using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment
{
    public class Rooms
    {
        public static List<BusinessEntities.Appointment.Rooms> GetRoomData(string val = null, int setId = 0)
        {
            List<BusinessEntities.Appointment.Rooms> list = new List<BusinessEntities.Appointment.Rooms>();
            DataTable dt = DataAccessLayer.Appointment.Rooms.GetRooms(val, setId);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Appointment.Rooms d = new BusinessEntities.Appointment.Rooms();
                    d.id = dr["rId"].ToString();
                    d.title = dr["room"].ToString();

                    BusinessEntities.Appointment.RoomProperties prop = new BusinessEntities.Appointment.RoomProperties();
                    prop.room_color = string.IsNullOrEmpty(dr["room_color"].ToString()) ? "#38cb89" : dr["room_color"].ToString();
                    prop.room_account = dr["room_account"].ToString();
                    prop.room_branch = DataValidation.isIntValid(dr["room_branch"].ToString());
                    prop.room_order = DataValidation.isIntValid(dr["room_order"].ToString());
                    d.extendedProps = prop;
                    list.Add(d);
                }
            }

            return list;
        }
        public static List<BusinessEntities.Appointment.Rooms> RoomsActive(int roomId, int setId)
        {
            try
            {
                List<BusinessEntities.Appointment.Rooms> list = new List<BusinessEntities.Appointment.Rooms>();
                DataTable dt = DataAccessLayer.Appointment.Rooms.RoomsActive(roomId, setId);


                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.Rooms d = new BusinessEntities.Appointment.Rooms();
                        d.id = dr["id"].ToString();
                        d.title = dr["text"].ToString();

                        BusinessEntities.Appointment.RoomProperties prop = new BusinessEntities.Appointment.RoomProperties();
                        prop.room_color = dr["room_color"].ToString();
                        prop.room_account = dr["room_account"].ToString();
                        prop.room_branch = DataValidation.isIntValid(dr["room_branch"].ToString());
                        prop.room_order = DataValidation.isIntValid(dr["room_order"].ToString());

                        d.extendedProps = prop;
                        list.Add(d);
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
