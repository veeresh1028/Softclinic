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
    public class DischargeChalazionIncisionNew
    {
        public static DataTable GetDischargeChalazionIncisionNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Chalazion_Incision_New_Select");

                db.AddInParameter(dbCommand, "dci_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeChalazionIncisionNew(BusinessEntities.ConsentForms.DischargeChalazionIncisionNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Chalazion_Incision_New_Insert");

                db.AddInParameter(dbCommand, "dci_appId", DbType.Int32, discharge.dci_appId);
                db.AddInParameter(dbCommand, "dci_1", DbType.String, string.IsNullOrEmpty(discharge.dci_1) ? "" : discharge.dci_1);
                db.AddInParameter(dbCommand, "dci_2", DbType.String, string.IsNullOrEmpty(discharge.dci_2) ? "" : discharge.dci_2);
                db.AddInParameter(dbCommand, "dci_3", DbType.String, string.IsNullOrEmpty(discharge.dci_3) ? "" : discharge.dci_3);
                db.AddInParameter(dbCommand, "dci_4", DbType.String, string.IsNullOrEmpty(discharge.dci_4) ? "" : discharge.dci_4);
                db.AddInParameter(dbCommand, "dci_5", DbType.String, string.IsNullOrEmpty(discharge.dci_5) ? "" : discharge.dci_5);
                db.AddInParameter(dbCommand, "dci_6", DbType.String, string.IsNullOrEmpty(discharge.dci_6) ? "" : discharge.dci_6);
                db.AddInParameter(dbCommand, "dci_7", DbType.String, string.IsNullOrEmpty(discharge.dci_7) ? "" : discharge.dci_7);
                db.AddInParameter(dbCommand, "dci_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dciId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dciId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dciId"));
                return _dciId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeChalazionIncisionNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Chalazion_Incision_New_Delete");

                db.AddInParameter(dbCommand, "dci_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dci_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dci_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dci_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dci_output"));

                return _dci_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeChalazionIncisionNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Chalazion_Incision_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dci_appId", DbType.Int32, appId);
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
