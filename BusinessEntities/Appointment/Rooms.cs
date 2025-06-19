using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment
{
    public class Rooms
    {
        public string id { get; set; }
        public string title { get; set; }
        public RoomProperties extendedProps { get; set; }
    }

    public class RoomProperties
    {
        public string room_color { get; set; }        
        public string room_account { get; set; }
        public int room_branch { get; set; }
        public int room_order { get; set; }
    }
}
