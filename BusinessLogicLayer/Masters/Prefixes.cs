using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Prefixes
    {
        #region Prefixes Master (Page Load)
        public static List<BusinessEntities.Masters.Prefixes> GetPrefixes(int? pfxId)
        {
            List<BusinessEntities.Masters.Prefixes> Prefixs = new List<BusinessEntities.Masters.Prefixes>();

            DataTable dt = DataAccessLayer.Masters.Prefixes.GetPrefixes(pfxId);

            foreach (DataRow dr in dt.Rows)
            {
                Prefixs.Add(new BusinessEntities.Masters.Prefixes
                {
                    pfxId = Convert.ToInt32(dr["pfxId"]),
                    pfx_prefix = dr["pfx_prefix"].ToString(),
                    pfx_date_modified = DateTime.Parse(dr["pfx_date_modified"].ToString()),
                    pfx_date_created = DateTime.Parse(dr["pfx_date_created"].ToString()),
                    pfx_type = dr["pfx_type"].ToString(),
                    pfx_slno = dr["pfx_slno"].ToString(),
                    pfx_change = dr["pfx_change"].ToString(),
                    pfx_branch = Convert.ToInt32(dr["pfx_branch"].ToString()),
                    pfx_madeby = Convert.ToInt32(dr["pfx_madeby"].ToString()),
                    pfx_status = dr["pfx_status"].ToString(),
                    pfx_branch_name = dr["pfx_branch_name"].ToString(),
                    pfx_madeby_name = dr["pfx_madeby_name"].ToString(),
                });
            }
            return Prefixs;
        }
        #endregion

        #region Prefix CRUD Operations
        public static bool InsertUpdatePrefix(BusinessEntities.Masters.Prefixes Prefix)
        {
            Prefix.pfx_type = string.IsNullOrEmpty(Prefix.pfx_type) ? string.Empty : Prefix.pfx_type;
            Prefix.pfx_slno = string.IsNullOrEmpty(Prefix.pfx_slno) ? string.Empty : Prefix.pfx_slno;

            return DataAccessLayer.Masters.Prefixes.InsertUpdatePrefix(Prefix);
        }

        public static int UpdatePrefixStatus(int pfxId, string tg_status)
        {
            return DataAccessLayer.Masters.Prefixes.UpdatePrefixStatus(pfxId, tg_status);
        }

        public static BusinessEntities.Masters.Prefixes GetPrefixesDetailsView(int? pfxId)
        {
            BusinessEntities.Masters.Prefixes Prefix = new BusinessEntities.Masters.Prefixes();

            DataTable dt = DataAccessLayer.Masters.Prefixes.GetPrefixes(pfxId);

            foreach (DataRow dr in dt.Rows)
            {
                Prefix.pfxId = Convert.ToInt32(dr["pfxId"]);
                Prefix.pfx_prefix = dr["pfx_prefix"].ToString();
                Prefix.pfx_date_modified = DateTime.Parse(dr["pfx_date_modified"].ToString());
                Prefix.pfx_date_created = DateTime.Parse(dr["pfx_date_created"].ToString());
                Prefix.pfx_type = dr["pfx_type"].ToString();
                Prefix.pfx_slno = dr["pfx_slno"].ToString();
                Prefix.pfx_branch = Convert.ToInt32(dr["pfx_branch"].ToString());
                Prefix.pfx_madeby = Convert.ToInt32(dr["pfx_madeby"].ToString());
                Prefix.pfx_status = dr["pfx_status"].ToString();
                Prefix.pfx_branch_name = dr["pfx_branch_name"].ToString();
                Prefix.pfx_madeby_name = dr["pfx_madeby_name"].ToString();
            }

            return Prefix;
        }
        #endregion
    }
}
