using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.EMR;
using System.Web.Mvc;

namespace DataAccessLayer.EMR
{
    public class TreatmentItems
    {
        public static int InsertTreatmentItems(BusinessEntities.EMR.TreatmentItems item, int madeby)
        {
            try
            {
                int titId = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PTreatment_Items_Insert");

                db.AddInParameter(dbCommand, "tit_ptId", DbType.Int32, item.tit_ptId);
                db.AddInParameter(dbCommand, "tit_item", DbType.String, item.tit_item);
                db.AddInParameter(dbCommand, "tit_itemId", DbType.Int32, item.tit_itemId);
                db.AddInParameter(dbCommand, "tit_batch", DbType.Int32, item.tit_batch);
                db.AddInParameter(dbCommand, "tit_qty", DbType.Decimal, item.tit_qty);
                db.AddInParameter(dbCommand, "tit_uom", DbType.String, item.tit_uom);
                db.AddInParameter(dbCommand, "tit_notes", DbType.String, item.tit_notes);
                db.AddInParameter(dbCommand, "tit_branch", DbType.Int32, item.tit_branch);
                db.AddInParameter(dbCommand, "tit_doctor", DbType.Int32, item.tit_doctor);
                db.AddInParameter(dbCommand, "tit_room", DbType.Int32, item.tit_room);
                db.AddInParameter(dbCommand, "tit_qty1", DbType.Decimal, item.Qty1);
                db.AddInParameter(dbCommand, "tit_qty2", DbType.Decimal, item.Qty2);
                db.AddInParameter(dbCommand, "tit_qty3", DbType.Decimal, item.Qty3);
                db.AddInParameter(dbCommand, "tit_madeby", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "titId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                titId = Convert.ToInt32(db.GetParameterValue(dbCommand, "titId").ToString());

                return titId;
            }
            catch (Exception)
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

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PTreatment_GetItems");

                db.AddInParameter(dbCommand, "tit_ptId", DbType.String, ptId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateTreatmentItemStatus(int titId, string tit_status, int empId)
        {
            try
            {
                int success = 0; int exceed = 0; int error = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TreatmentItemsConsumption_StatusChange");

                db.AddInParameter(dbCommand, "titId", DbType.Int32, titId);
                db.AddInParameter(dbCommand, "tit_status", DbType.String, tit_status);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int result = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                if (result > 0)
                    success++;

                if (result == -1)
                    exceed++;

                if (result == 0)
                    error++;

                if (success > 0 && exceed == 0 && error == 0)
                {
                    return 1;
                }
                else if (success > 0 && exceed > 0 && error == 0)
                {
                    return -2;
                }
                else if (success > 0 && exceed > 0 && error > 0)
                {
                    return -2;
                }
                else if (success == 0 && exceed > 0 && error == 0)
                {
                    return -1;
                }
                else
                {
                    return -3;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchInternalStockConsumptionReport(InternalStockConsumptionSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Internal_Stock_Consumption_Report");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                if (!string.IsNullOrEmpty(filters.select_room))
                {
                    db.AddInParameter(dbCommand, "select_room", DbType.String, filters.select_room);
                }

                if (!string.IsNullOrEmpty(filters.select_dept))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filters.select_dept);
                }

                if (!string.IsNullOrEmpty(filters.select_doctor))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, filters.select_doctor);
                }

                if (filters.select_patient > 0)
                {
                    db.AddInParameter(dbCommand, "select_patient", DbType.Int32, filters.select_patient);
                }

                if (!string.IsNullOrEmpty(filters.select_item))
                {
                    db.AddInParameter(dbCommand, "select_item", DbType.String, filters.select_item);
                }

                db.AddInParameter(dbCommand, "select_date_from", DbType.DateTime, filters.select_date_from);

                db.AddInParameter(dbCommand, "select_date_to", DbType.DateTime, filters.select_date_to);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int PostInternalStockConsumptionToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Internal_Stock_Consumption_Post_To_Account");
                    db.AddInParameter(dbCommand, "titId", DbType.Int32, id);
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                    db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                    db.ExecuteNonQuery(dbCommand);
                    int result = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());
                    if (result > 0)
                        sucsess++;
                    if (result == -1)
                        excced++;
                    if (result == 0)
                        error++;
                }
                if (sucsess > 0 && excced == 0 && error == 0)
                {
                    return 1;
                }
                else if (sucsess > 0 && excced > 0 && error == 0)
                {
                    return -2;
                }
                else if (sucsess > 0 && excced > 0 && error > 0)
                {
                    return -2;
                }
                else if (sucsess == 0 && excced > 0 && error == 0)
                {
                    return -1;
                }
                else
                {
                    return -3;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}