using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Invoice
{
    public class TreatmentItem
    {
        public static DataTable SearchTreatmentItems(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentItemsByQuery");
                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateTreatmentItems(BusinessEntities.Invoice.TreatmentItem item, int madeby)
        {
            try
            {
                int titId = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_ITEMS_insert");
                db.AddInParameter(dbCommand, "tit_ptId", DbType.Int32, item.tit_ptId);
                db.AddInParameter(dbCommand, "tit_item", DbType.String, item.tit_item);
                db.AddInParameter(dbCommand, "tit_itemId", DbType.Int32, item.tit_itemId);
                db.AddInParameter(dbCommand, "tit_qty", DbType.Decimal, item.tit_qty);
                db.AddInParameter(dbCommand, "tit_notes", DbType.String, item.tit_notes);
                db.AddInParameter(dbCommand, "tit_madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "titId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                titId = Convert.ToInt32(db.GetParameterValue(dbCommand, "titId").ToString());
                return titId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetTreatmentItems(int ptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENT_ITEMS_select");
                db.AddInParameter(dbCommand, "tit_ptId", DbType.String, ptId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateTreatmentItemStatus(int titId, string status, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UpdateTreatmentItemStatus");
                db.AddInParameter(dbCommand, "titId", DbType.Int32, titId);
                db.AddInParameter(dbCommand, "tit_status", DbType.String, status);
                db.AddInParameter(dbCommand, "tit_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}