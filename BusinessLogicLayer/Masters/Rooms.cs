using BusinessEntities;
using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Rooms
    {
        #region Rooms Master (Page Load)
        public static DataTable GetRooms(int? rId)
        {
            return DataAccessLayer.Masters.Rooms.GetRooms(rId);
        }

        public static List<BusinessEntities.Masters.Rooms> GetRoomsLists(int? rId)
        {
            List<BusinessEntities.Masters.Rooms> Roomslist = new List<BusinessEntities.Masters.Rooms>();
            DataTable dt = DataAccessLayer.Masters.Rooms.GetRooms(rId);

            foreach (DataRow dr in dt.Rows)
            {
                Roomslist.Add(new BusinessEntities.Masters.Rooms
                {
                    rId = Convert.ToInt32(dr["rId"]),
                    room = dr["room"].ToString(),
                    room_branch = dr["room_branch"].ToString(),
                    room_branch_name = dr["room_branch_name"].ToString(),
                    ActionVisible = dr["ActionVisible"].ToString(),
                    room_status = dr["room_status"].ToString()
                });
            }
            return Roomslist;
        }
        #endregion

        #region Rooms CRUD Operations
        public static bool InsertRoom(BusinessEntities.Masters.Rooms room)
        {
            return DataAccessLayer.Masters.Rooms.InsertUpdateRoom(room);
        }

        public static int UpdateRoomStatus(int rId, string room_status)
        {
            return DataAccessLayer.Masters.Rooms.UpdateRoomStatus(rId, room_status);
        }

        public static DataTable GetBranchRooms(int room_branch)
        {
            return DataAccessLayer.Masters.Rooms.GetBranchRooms(room_branch);
        }

        public static List<CommonDDL> GetBranchRoomsList(int room_branch)
        {
            List<CommonDDL> branchroomslist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Masters.Rooms.GetBranchRooms(room_branch);

            foreach (DataRow dr in dt.Rows)
            {
                branchroomslist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["rId"]),
                    text = dr["room"].ToString()
                });
            }
            return branchroomslist;
        }
        #endregion
    }
}