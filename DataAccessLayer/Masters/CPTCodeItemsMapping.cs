using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataAccessLayer.Masters
{
    public class CPTCodeItemsMapping
    {
        #region CPT Code - Items Mapping Master (Page Load)
        public static DataTable CPTCodeItems(int? cptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_ITEMS_select_all_info");
                if (cptId > 0)
                {
                    db.AddInParameter(dbCommand, "cptId", DbType.Int32, cptId);
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

        #region Load Dropdowns
        public static DataTable GetItems(string query, int emp_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GETITEMS_CPTCode_ItemsMapping");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, emp_branch);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetCPTCodes(string query, int emp_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GETCPTCODE_CPTCode_ItemsMapping");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, emp_branch);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetUOMByItem(string icode, int branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UOM_BY_ITEM");

                if (!string.IsNullOrEmpty(icode))
                {
                    db.AddInParameter(dbCommand, "itemCode", DbType.String, icode);
                }

                if (branch > 0)
                {
                    db.AddInParameter(dbCommand, "item_branch", DbType.Int32, branch);
                }

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region CPT Code (Items Mapping) CRUD Operations
        public static bool InsertUpdateCPTCodeItem(BusinessEntities.Masters.CPTCodeItemsMapping cptcodeitem)

        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_ITEMS_INSERT_UPDATE");

                if (cptcodeitem.cptId > 0)
                {
                    db.AddInParameter(dbCommand, "cptId", DbType.Int32, cptcodeitem.cptId);
                }
                db.AddInParameter(dbCommand, "cpt_code", DbType.String, cptcodeitem.cpt_code);
                db.AddInParameter(dbCommand, "cpt_item", DbType.String, cptcodeitem.cpt_item);
                db.AddInParameter(dbCommand, "cpt_qty", DbType.Int32, cptcodeitem.cpt_qty);
                db.AddInParameter(dbCommand, "cpt_uom", DbType.String, cptcodeitem.cpt_uom);
                db.AddInParameter(dbCommand, "cpt_notes", DbType.String, cptcodeitem.cpt_notes);
                db.AddInParameter(dbCommand, "cpt_madeby", DbType.Int32, cptcodeitem.cpt_madeby);
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

        public static int UpdateCPTCodeItemStatus(int cptId, string cpt_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_ITEMS_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "cptId", DbType.Int32, cptId);
                db.AddInParameter(dbCommand, "cpt_status", DbType.String, cpt_status);
                db.AddOutParameter(dbCommand, "cpt_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "cpt_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
