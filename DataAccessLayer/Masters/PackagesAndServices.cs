using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class PackagesAndServices
    {
        #region Packages And Services (Page Load)
        public static DataTable GetPackagesAndServices(int? pkgId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Package_Master_select_all_info");
                if (pkgId > 0)
                {
                    db.AddInParameter(dbCommand, "pkgId", DbType.Int32, pkgId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        public static bool InsertUpdatePackages(BusinessEntities.Masters.PackagesAndServices package)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Package_Master_insert");

                if (package.pkgId > 0)
                {
                    db.AddInParameter(dbCommand, "pkgId", DbType.Int32, package.pkgId);
                }

                db.AddInParameter(dbCommand, "pkg_code", DbType.String, package.pkg_code);
                db.AddInParameter(dbCommand, "pkg_name", DbType.String, package.pkg_name);
                db.AddInParameter(dbCommand, "pkg_price", DbType.Decimal, package.pkg_price);
                db.AddInParameter(dbCommand, "pkg_madeby", DbType.Int32, package.pkg_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Package Services (Document Load)
        public static DataTable GetPackages(int pkgId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_SERVICES_select_all_info_new");

                if (pkgId > 0)
                {
                    db.AddInParameter(dbCommand, "pkgId", DbType.Int32, pkgId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        public static bool InsertSevicesToPackage(BusinessEntities.Masters.Packages package)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_SERVICES_insert");

                if (package.psId > 0)
                {
                    db.AddInParameter(dbCommand, "psId", DbType.Int32, package.psId);
                }

                db.AddInParameter(dbCommand, "ps_services", DbType.Int32, package.ps_services);
                db.AddInParameter(dbCommand, "ps_package", DbType.Int32, package.ps_package);
                db.AddInParameter(dbCommand, "ps_madeby", DbType.Int32, package.ps_madeby);
                db.AddInParameter(dbCommand, "ps_qty", DbType.Int32, package.ps_qty);
                db.AddInParameter(dbCommand, "ps_oriPrice", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "ps_total", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "ps_package_amt", DbType.Int32, 1);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdatePackageStatus(int psId, string ps_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_SERVICES_update_status");

                db.AddInParameter(dbCommand, "psId", DbType.Int32, psId);
                db.AddInParameter(dbCommand, "ps_status", DbType.String, ps_status);
                db.AddOutParameter(dbCommand, "ps_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ps_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetCPTCodes(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("sp_GetTreatments");

                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
