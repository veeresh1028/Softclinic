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
    public class DermalFillers
    {
        public static DataTable GetDermalFillersData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermal_Fillers_Form_Select");

                db.AddInParameter(dbCommand, "dff_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDermalFillers(BusinessEntities.ConsentForms.DermalFillers derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermal_Fillers_Form_Insert");

                db.AddInParameter(dbCommand, "dff_appId", DbType.Int32, derma.dff_appId);
                db.AddInParameter(dbCommand, "dff_1", DbType.String, string.IsNullOrEmpty(derma.dff_1) ? "" : derma.dff_1);
                db.AddInParameter(dbCommand, "dff_2", DbType.String, string.IsNullOrEmpty(derma.dff_2) ? "" : derma.dff_2);
                db.AddInParameter(dbCommand, "dff_chk", DbType.String, string.IsNullOrEmpty(derma.dff_chk) ? "" : derma.dff_chk);

                db.AddInParameter(dbCommand, "dff_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dffId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dffId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dffId"));
                return _dffId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDermalFillers(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermal_Fillers_Form_Delete");

                db.AddInParameter(dbCommand, "dff_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dff_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dff_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dff_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dff_output"));

                return _dff_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDermalFillersPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermal_Fillers_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "dff_appId", DbType.Int32, appId);
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
