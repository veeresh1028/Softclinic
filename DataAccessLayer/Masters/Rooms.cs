using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class Rooms
    {
        #region Rooms Master (Page Load)
        public static DataTable GetRooms(int? roomId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ROOMS_select_all_info");

                if (roomId > 0)
                {
                    db.AddInParameter(dbCommand, "rId", DbType.Int32, roomId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Rooms CRUD Operations
        public static bool InsertUpdateRoom(BusinessEntities.Masters.Rooms room)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ROOMS_INSERT_UPDATE");

                if (room.rId > 0)
                {
                    db.AddInParameter(dbCommand, "rId", DbType.Int32, room.rId);
                }

                db.AddInParameter(dbCommand, "room", DbType.String, room.room);
                db.AddInParameter(dbCommand, "room_branch", DbType.Int32, room.room_branch);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateRoomStatus(int rId, string room_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ROOMS_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "rId", DbType.Int32, rId);
                db.AddInParameter(dbCommand, "room_status", DbType.String, room_status);
                db.AddOutParameter(dbCommand, "room_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "room_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetBranchRooms(int room_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Branch_Rooms");
                if (room_branch > 0)
                {
                    db.AddInParameter(dbCommand, "room_branch", DbType.Int32, room_branch);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}