using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    public class Rights
    {
        public static int HavePageAccess(int PageId, int EmpId, int Action)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HaveL3Rights");
                db.AddInParameter(dbCommand, "L3Id", DbType.Int32, PageId);
                db.AddInParameter(dbCommand, "EmpId", DbType.Int32, EmpId);
                db.AddInParameter(dbCommand, "Action", DbType.Int32, Action);
                db.AddOutParameter(dbCommand, "HaveRights", DbType.Int32, 100);
                int val = db.ExecuteNonQuery(dbCommand);

                int _output = Convert.ToInt32(db.GetParameterValue(dbCommand, "HaveRights"));
                return _output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable HaveMenuAccess(int EmpId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MenuAccess");
                db.AddInParameter(dbCommand, "EmpId", DbType.Int32, EmpId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
