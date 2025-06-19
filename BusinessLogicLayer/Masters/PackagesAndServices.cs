using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class PackagesAndServices
    {
        #region Packages And Services (Page Load)
        public static List<BusinessEntities.Masters.PackagesAndServices> GetAllPackagesServices(int? pkgId)
        {
            List<BusinessEntities.Masters.PackagesAndServices> trlist = new List<BusinessEntities.Masters.PackagesAndServices>();
            DataTable dt = DataAccessLayer.Masters.PackagesAndServices.GetPackagesAndServices(pkgId);

            foreach (DataRow dr in dt.Rows)
            {
                trlist.Add(new BusinessEntities.Masters.PackagesAndServices
                {
                    pkgId = Convert.ToInt32(dr["pkgId"]),
                    pkg_code = dr["pkg_code"].ToString(),
                    pkg_name = dr["pkg_name"].ToString(),
                    pkg_price = DataValidation.isDecimalValid(dr["pkg_price"].ToString()),
                    pkg_status = dr["pkg_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    pkg_madeby_name = dr["pkg_madeby_name"].ToString(),
                    pkg_date_created = dr["pkg_date_created"].ToString()
                });
            }
            return trlist;
        }
        #endregion
        public static bool InsertUpdatePackages(BusinessEntities.Masters.PackagesAndServices package)
        {
            return DataAccessLayer.Masters.PackagesAndServices.InsertUpdatePackages(package);
        }

        #region Package Services (Document Load)
        public static List<BusinessEntities.Masters.Packages> GetPackages(int tgId)
        {
            List<BusinessEntities.Masters.Packages> packages = new List<BusinessEntities.Masters.Packages>();
            DataTable dt = DataAccessLayer.Masters.PackagesAndServices.GetPackages(tgId);

            foreach (DataRow dr in dt.Rows)
            {
                packages.Add(new BusinessEntities.Masters.Packages
                {
                    psId = Convert.ToInt32(dr["psId"]),
                    ps_madeby = Convert.ToInt32(dr["ps_madeby"]),
                    ps_status = dr["ps_status"].ToString(),
                    ps_oriPrice = DataValidation.isDecimalValid(dr["ps_oriPrice"].ToString()),
                    ps_disPrice = DataValidation.isDecimalValid(dr["ps_disPrice"].ToString()),
                    tr_name = dr["tr_name"].ToString(),
                    tr_code = dr["tr_code"].ToString(),
                    ps_qty = int.Parse(dr["ps_qty"].ToString()),
                    actionvisible = dr["ActionVisible"].ToString()
                });
            }
            return packages;
        }
        #endregion

        public static int UpdatePackageStatus(int psId, string ps_status)
        {
            return DataAccessLayer.Masters.PackagesAndServices.UpdatePackageStatus(psId, ps_status);
        }
        public static bool InsertSevicesToPackage(BusinessEntities.Masters.Packages package)
        {
            return DataAccessLayer.Masters.PackagesAndServices.InsertSevicesToPackage(package);
        }

        public static List<CommonDDL> GetCPTCodes(string query)
        {
            DataTable dt = DataAccessLayer.Masters.PackagesAndServices.GetCPTCodes(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
    }
}
