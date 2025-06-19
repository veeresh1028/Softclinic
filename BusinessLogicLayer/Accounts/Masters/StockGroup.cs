using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Masters
{
    public class StockGroup
    {
        public static int InsertUpdateStockGroup(BusinessEntities.Accounts.Masters.StockGroup data)
        {
            return DataAccessLayer.Accounts.Masters.StockGroup.InsertUpdateStockGroup(data);
        }
        public static List<BusinessEntities.Accounts.Masters.StockGroup> GetStockGroup(int? igId, string ig_group, string ig_status, string ig_account, int empId)
        {
            List<BusinessEntities.Accounts.Masters.StockGroup> StockGrouplist = new List<BusinessEntities.Accounts.Masters.StockGroup>();

            DataTable dt = DataAccessLayer.Accounts.Masters.StockGroup.GetStockGroup(igId, ig_group, ig_status, ig_account, empId);
            foreach (DataRow dr in dt.Rows)
            {
                StockGrouplist.Add(new BusinessEntities.Accounts.Masters.StockGroup
                {
                    igId = Convert.ToInt32(dr["igId"].ToString()),
                    ig_branch = Convert.ToInt32(dr["ig_branch"].ToString()),
                    ig_group = dr["ig_group"].ToString(),
                    ig_account = dr["ig_account"].ToString(),
                    ig_status = dr["ig_status"].ToString(),
                    branch_name = dr["branch_name"].ToString(),
                    actionvisible = dr["actionvisible"].ToString()
                });
            }
            return StockGrouplist;
        }
        public static int UpdateStockGroup_Status(int igId, string ig_status, int empId)
        {
            return DataAccessLayer.Accounts.Masters.StockGroup.UpdateStockGroup_Status(igId, ig_status, empId);
        }
    }
}
