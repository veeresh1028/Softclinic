using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class DenialCodes
    {
        #region Denial Codes (Page Load)
        public static List<BusinessEntities.Masters.DenialCodes> GetDenialCodes(int? dcId)
        {
            List<BusinessEntities.Masters.DenialCodes> denialcodelist = new List<BusinessEntities.Masters.DenialCodes>();

            DataTable dt = DataAccessLayer.Masters.DenialCodes.GetDenialCodes(dcId);

            foreach (DataRow dr in dt.Rows)
            {
                denialcodelist.Add(new BusinessEntities.Masters.DenialCodes
                {
                    dcId = Convert.ToInt32(dr["dcId"]),
                    dc_code = dr["dc_code"].ToString(),
                    dc_desc = dr["dc_desc"].ToString(),
                    dc_status = dr["dc_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    dc_date_created = Convert.ToDateTime(dr["dc_date_created"]),
                    dc_madeby_name = dr["dc_madeby_name"].ToString(),
                });
            }
            return denialcodelist;
        }
        #endregion

        #region Denial Codes CRUD Operations
        public static bool InsertUpdateDenialCode(BusinessEntities.Masters.DenialCodes denialcode)
        {
            return DataAccessLayer.Masters.DenialCodes.InsertUpdateDenialCode(denialcode);
        }

        public static int UpdateDenialCodeStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.DenialCodes.UpdateDenialCodeStatus(tgId, tg_status);
        }
        #endregion
    }
}