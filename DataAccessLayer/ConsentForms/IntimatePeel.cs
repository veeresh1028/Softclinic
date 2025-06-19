using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConsentForms
{
    public class IntimatePeel
    {
        public static DataTable GetIntimatePeelData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intimate_Peel_Informed_Select");

                db.AddInParameter(dbCommand, "cipl_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveIntimatePeel(BusinessEntities.ConsentForms.IntimatePeel tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intimate_Peel_Informed_Insert");

                db.AddInParameter(dbCommand, "cipl_appId", DbType.Int32, tooth.cipl_appId);
                db.AddInParameter(dbCommand, "cipl_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ciplId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ciplId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ciplId"));
                return _ciplId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteIntimatePeel(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intimate_Peel_Informed_Delete");

                db.AddInParameter(dbCommand, "cipl_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cipl_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cipl_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cipl_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cipl_output"));

                return _cipl_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetIntimatePeelPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intimate_Peel_Informed_PreviousHistory");

                db.AddInParameter(dbCommand, "cipl_appId", DbType.Int32, appId);
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
