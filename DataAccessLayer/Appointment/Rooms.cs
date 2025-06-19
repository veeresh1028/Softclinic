using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Appointment
{
    public class Rooms
    {
        public static DataTable GetRooms(string val = null, int setId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Resources_Rooms");

                if (!string.IsNullOrEmpty(val))
                {
                    db.AddInParameter(dbCommand, "roomIds", DbType.String, val);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "room_branch", DbType.Int32, setId);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable RoomsActive(int roomId, int setId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Get_Rooms");

                if (roomId > 0)
                {
                    db.AddInParameter(dbCommand, "roomId", DbType.Int32, roomId);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "setId", DbType.Int32, setId);
                }
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
