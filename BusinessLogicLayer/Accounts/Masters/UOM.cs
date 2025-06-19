using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Masters
{
    public class UOM
    {
        public static int InsertUpdateUOM(BusinessEntities.Accounts.Masters.UOM data)
        {
            return DataAccessLayer.Accounts.Masters.UOM.InsertUpdateUOM(data);
        }
        public static List<BusinessEntities.Accounts.Masters.UOM> GetUOM(int? uomId, string uom, string uom_category, string uom_status, int empId)
        {
            List<BusinessEntities.Accounts.Masters.UOM> UOMlist = new List<BusinessEntities.Accounts.Masters.UOM>();

            DataTable dt = DataAccessLayer.Accounts.Masters.UOM.GetUOM(uomId, uom, uom_category, uom_status, empId);
            foreach (DataRow dr in dt.Rows)
            {
                UOMlist.Add(new BusinessEntities.Accounts.Masters.UOM
                {
                    uomId = Convert.ToInt32(dr["uomId"].ToString()),
                    uom = dr["uom"].ToString(),
                    uom_category = dr["uom_category"].ToString(),
                    uom_status = dr["uom_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString()
                });
            }
            return UOMlist;
        }
        public static int UpdateUOM_Status(int uomId, string uom_status, int empId)
        {
            return DataAccessLayer.Accounts.Masters.UOM.UpdateUOM_Status(uomId, uom_status, empId);
        }
    }
}
