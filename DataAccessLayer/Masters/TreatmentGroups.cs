using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class TreatmentGroups
    {
        #region Treatment Groups (Page Load)
        public static DataTable GetTreatmentGroups(int? tgId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_GROUPS_select_all_info2");
                if (tgId > 0)
                {
                    db.AddInParameter(dbCommand, "tgId", DbType.Int32, tgId);
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

        #region Treatment Groups CRUD Opertaions
        public static bool InsertUpdateTreatmentGroups(BusinessEntities.Masters.TreatmentGroups treamtnetgroups)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_GROUPS_insert");

                if (treamtnetgroups.tgId > 0)
                {
                    db.AddInParameter(dbCommand, "tgId", DbType.Int32, treamtnetgroups.tgId);
                }

                db.AddInParameter(dbCommand, "tg_group", DbType.String, treamtnetgroups.tg_group);
                db.AddInParameter(dbCommand, "tg_cost", DbType.Decimal, treamtnetgroups.tg_cost);
                db.AddInParameter(dbCommand, "tg_disc", DbType.Decimal, treamtnetgroups.tg_disc);
                db.AddInParameter(dbCommand, "tg_vat", DbType.Decimal, treamtnetgroups.tg_vat);

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

        public static int UpdateUpdateTreatmentStatus(int tgId, string tg_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_GROUPS_update_status");

                db.AddInParameter(dbCommand, "tgId", DbType.Int32, tgId);
                db.AddInParameter(dbCommand, "tg_status", DbType.String, tg_status);
                db.AddOutParameter(dbCommand, "tg_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "tg_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int GenerateSalesAccount(int tgId)
        {
            try
            {
                int result = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_GROUPS_GENERATE_SALES_ACCOUNT");

                db.AddInParameter(dbCommand, "tgId", DbType.Int32, tgId);

                result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Package Services (Document Load)
        public static DataTable GetPackages(int tgId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_SERVICES_select_all_info");

                if (tgId > 0)
                {
                    db.AddInParameter(dbCommand, "tr_group", DbType.Int32, tgId);
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

        #region Package Services CRUD Operations
        public static bool InsertPackage(BusinessEntities.Masters.Packages package)
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
                db.AddInParameter(dbCommand, "ps_qty", DbType.Int32,package.ps_qty);
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
        #endregion
    }
}