using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class DentalImplants
    {
        public static DataTable GetDentalImplantsData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_Select");

                db.AddInParameter(dbCommand, "pcd_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveDentalImplants(BusinessEntities.ConcentForms.DentalImplants dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_Insert");

                db.AddInParameter(dbCommand, "pcd_appId", DbType.Int32, dental.pcd_appId);
                db.AddInParameter(dbCommand, "pcd_1", DbType.String, string.IsNullOrEmpty(dental.pcd_1) ? "" : dental.pcd_1);
                db.AddInParameter(dbCommand, "pcd_2", DbType.String, string.IsNullOrEmpty(dental.pcd_2) ? "" : dental.pcd_2);
                db.AddInParameter(dbCommand, "pcd_3", DbType.String, string.IsNullOrEmpty(dental.pcd_3) ? "" : dental.pcd_3);
                db.AddInParameter(dbCommand, "pcd_4", DbType.String, string.IsNullOrEmpty(dental.pcd_4) ? "" : dental.pcd_4);
                db.AddInParameter(dbCommand, "pcd_5", DbType.String, string.IsNullOrEmpty(dental.pcd_5) ? "" : dental.pcd_5);
                db.AddInParameter(dbCommand, "pcd_made_by", DbType.Int32, madeby);
                
                db.AddOutParameter(dbCommand, "pcdId", DbType.Int32, 100);               
                
                int val = db.ExecuteNonQuery(dbCommand);

                int _pcdId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcdId"));
                return _pcdId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public static int DeleteDentalImplants(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_Delete");

                db.AddInParameter(dbCommand, "pcd_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pcd_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pcd_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pcd_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcd_output"));

                return _pcd_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDentalImplantsPreviousHistroy(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_PreviousHistroy");

                db.AddInParameter(dbCommand, "pcd_appId", DbType.Int32, appId);
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
