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
    public class ToothTreatmentsCategory
    {
        #region Tooth Treatments Category Master (Page Load)
        public static DataTable GetToothTreatmentsCategory(int? cctId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_TOOTHS_SELECT_ALL_INFO");
                if (cctId > 0)
                {
                    db.AddInParameter(dbCommand, "cctId", DbType.Int32, cctId);
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

        #region Tooth Treatments Category CRUD Operations
        public static DataTable GetActiveTreatmentCodes(int? Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENTS_ACTIVE_ALL_INFO");
                if (Id > 0)
                {
                    db.AddInParameter(dbCommand, "Id", DbType.Int32, Id);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InserUpdatetToothTreatmentsCategory(BusinessEntities.Masters.ToothTreatmentsCategory trcodecategory)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_TOOTHS_INSERT_UPDATE");

                if (trcodecategory.cctId > 0)
                {
                    db.AddInParameter(dbCommand, "cctId", DbType.Int32, trcodecategory.cctId);
                }

                db.AddInParameter(dbCommand, "cct_code", DbType.String, trcodecategory.cct_code);
                db.AddInParameter(dbCommand, "cct_category", DbType.String, trcodecategory.cct_category);
                db.AddInParameter(dbCommand, "cct_sub_category", DbType.String, trcodecategory.cct_sub_category);
                db.AddInParameter(dbCommand, "cct_madeby", DbType.Int32, trcodecategory.cct_madeby);
                
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

        public static int UpdateToothTreatmentsCategoryStatus(int cctId, string cct_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CPT_TOOTHS_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "cctId", DbType.Int32, cctId);
                db.AddInParameter(dbCommand, "cct_status", DbType.String, cct_status);
                db.AddOutParameter(dbCommand, "cct_output", DbType.Int32, 10);
                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "cct_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
