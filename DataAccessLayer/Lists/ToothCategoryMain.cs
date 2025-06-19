using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Lists
{
    public class ToothCategoryMain
    {
        public static DataTable GetToothCategoryMain(int? ctcyId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_TOOTHS_CATEGORY_select_all_info");

                if (ctcyId > 0)
                {
                    db.AddInParameter(dbCommand, "ctcyId", DbType.Int32, ctcyId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetToothSubCategory(int? ctsyId, int? ctsy_code)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_TOOTHS_SUBCATEGORY_select_all_info");

                if (ctsyId > 0)
                {
                    db.AddInParameter(dbCommand, "ctsyId", DbType.Int32, ctsyId);
                }

                if (ctsy_code > 0)
                {
                    db.AddInParameter(dbCommand, "ctsy_code", DbType.Int32, ctsy_code);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetActiveTreatmentCodes()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENTS_ACTIVE_ALL_INFO");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}