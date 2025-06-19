using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Masters
{
    public class ItemLocation
    {
        public static int InsertUpdateItemLocation(BusinessEntities.Accounts.Masters.ItemLocation data)
        {
            return DataAccessLayer.Accounts.Masters.ItemLocation.InsertUpdateItemLocation(data);
        }
        public static List<BusinessEntities.Accounts.Masters.ItemLocation> GetItemLocation(int? ilId, string il_location, string il_status, int empId)
        {
            List<BusinessEntities.Accounts.Masters.ItemLocation> ItemLocationlist = new List<BusinessEntities.Accounts.Masters.ItemLocation>();

            DataTable dt = DataAccessLayer.Accounts.Masters.ItemLocation.GetItemLocation(ilId, il_location, il_status, empId);
            foreach (DataRow dr in dt.Rows)
            {
                ItemLocationlist.Add(new BusinessEntities.Accounts.Masters.ItemLocation
                {
                    ilId = Convert.ToInt32(dr["ilId"].ToString()),
                    il_location = dr["il_location"].ToString(),
                    il_status = dr["il_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString()
                });
            }
            return ItemLocationlist;
        }
        public static int UpdateItemLocation_Status(int ilId, string il_status, int empId)
        {
            return DataAccessLayer.Accounts.Masters.ItemLocation.UpdateItemLocation_Status(ilId, il_status, empId);
        }
    }
}
