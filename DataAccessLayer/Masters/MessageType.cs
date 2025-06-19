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
    public class MessageType
    {
        #region Message Types (Page Load)
        public static DataTable GetMessageType(int? mtId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MESSAGE_TYPE_select_all_info");

                if (mtId > 0)
                {
                    db.AddInParameter(dbCommand, "mtId", DbType.Int32, mtId);
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

        #region Message Types CRUD Operations
        public static bool InsertUpdateMessagetype(BusinessEntities.Masters.MessageType message)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MESSAGE_TYPE_INSERT_UPDATE");

                if (message.mtId > 0)
                {
                    db.AddInParameter(dbCommand, "mtId", DbType.Int32, message.mtId);
                }

                db.AddInParameter(dbCommand, "mt_type", DbType.String, message.mt_type);
                db.AddInParameter(dbCommand, "mt_branch", DbType.Int32, message.mt_branch);
                db.AddInParameter(dbCommand, "mt_desig", DbType.Int32, message.mt_desig);
                db.AddInParameter(dbCommand, "mt_emp", DbType.Int32, message.mt_emp);
                db.AddInParameter(dbCommand, "mt_tat", DbType.String, message.mt_tat);
                db.AddInParameter(dbCommand, "mt_madeby", DbType.Int32, message.mt_madeby);

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

        public static int UpdateMessageTypeStatus(int mtId, string mt_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MESSAGE_TYPE_update_status");

                db.AddInParameter(dbCommand, "mtId", DbType.Int32, mtId);
                db.AddInParameter(dbCommand, "mt_status", DbType.String, mt_status);
                db.AddOutParameter(dbCommand, "mt_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "mt_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Load Dropdown
        public static DataTable GetAllEmployees(int? empId, int? emp_desig)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Employees_designation_allinfo");

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }

                if (emp_desig > 0)
                {
                    db.AddInParameter(dbCommand, "emp_desig", DbType.Int32, emp_desig);
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
    }
}