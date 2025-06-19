using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class PhysicianOrders
    {
        public static List<BusinessEntities.NurseStation.PhysicianOrders> GetAllPhysicianOrders(int appId, int? ptId)
        {
            List<BusinessEntities.NurseStation.PhysicianOrders> sclist = new List<BusinessEntities.NurseStation.PhysicianOrders>();
            DataTable dt = DataAccessLayer.NurseStation.PhysicianOrders.GetAllPhysicianOrders(appId, ptId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.PhysicianOrders
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    pt_appId = Convert.ToInt32(dr["pt_appId"]),
                    pt_date_collected = Convert.ToDateTime(dr["pt_date_collected"].ToString()),
                    pt_date_received = Convert.ToDateTime(dr["pt_date_received"].ToString()),
                    pt_exe_date = Convert.ToDateTime(dr["pt_exe_date"].ToString()),
                    pt_date_modified = Convert.ToDateTime(dr["pt_date_modified"].ToString()),
                    pt_date_created = Convert.ToDateTime(dr["pt_date_created"].ToString()),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    pt_notes = dr["pt_notes"].ToString(),
                    emp_name = dr["emp_name"].ToString(),
                    


                });
            }
            return sclist;
        }

        public static bool UpdatePhysicianNotes(int ptId, string pt_notes)
        {
            return DataAccessLayer.NurseStation.PhysicianOrders.UpdatePhysicianNotes(ptId, pt_notes);
        }

        public static bool UpdatePhysicianOrderTime(int ptId, DateTime pt_date_collected, DateTime pt_date_received)
        {
            return DataAccessLayer.NurseStation.PhysicianOrders.UpdatePhysicianOrderTime(ptId, pt_date_collected, pt_date_received);
        }
    }
}
