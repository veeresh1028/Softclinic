using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Referals
    {
        #region Referals Master (Page Load)
        public static DataTable GetReferals(int? refId, int? ref_country)
        {
            return DataAccessLayer.Masters.Referals.GetReferrals(refId, ref_country);
        }

        public static List<BusinessEntities.Masters.Referals> GetAllReferrals(int? refId)
        {
            List<BusinessEntities.Masters.Referals> referrals = new List<BusinessEntities.Masters.Referals>();

            DataTable dt = DataAccessLayer.Masters.Referals.GetAllReferrals(refId);

            foreach (DataRow dr in dt.Rows)
            {
                referrals.Add(new BusinessEntities.Masters.Referals
                {
                    refId = Convert.ToInt32(dr["refId"]),
                    ref_login = dr["ref_login"].ToString(),
                    ref_pass = dr["ref_pass"].ToString(),
                    ref_status = dr["ref_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    ref_date_created = Convert.ToDateTime(dr["ref_date_created"]),
                    ref_name = dr["ref_name"].ToString(),
                    ref_mob = dr["ref_mob"].ToString(),
                    ref_tel = dr["ref_tel"].ToString(),
                    ref_fax = dr["ref_fax"].ToString(),
                    ref_city = dr["ref_city"].ToString(),
                    ref_email = dr["ref_email"].ToString(),
                    ref_country = Convert.ToInt32(dr["ref_country"]),
                    ref_company = dr["ref_company"].ToString(),
                    ref_type = dr["ref_type"].ToString(),
                    country = dr["country"].ToString(),
                    country_code = dr["country_code"].ToString(),
                });
            }
            return referrals;
        }
        #endregion

        #region Referals Master (Page Load)
        public static bool InsertUpdateReferral(BusinessEntities.Masters.Referals data)
        {
            data.ref_mob = (data.ref_mob.Trim() == "+971") ? "" : data.ref_mob.Trim().Replace("+", "");

            if (!string.IsNullOrEmpty(data.ref_tel))
            {
                data.ref_tel = (data.ref_tel.Trim() == "+971") ? "" : data.ref_tel.Trim().Replace("+", "");
            }
            else
            {
                data.ref_tel = string.IsNullOrEmpty(data.ref_tel) ? string.Empty : data.ref_tel;
            }

            return DataAccessLayer.Masters.Referals.InsertUpdateReferral(data);
        }

        public static int UpdateReferralStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.Referals.UpdateReferralStatus(tgId, tg_status);
        }
        #endregion
    }
}