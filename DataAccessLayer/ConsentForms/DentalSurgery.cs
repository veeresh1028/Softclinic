using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class DentalSurgery
    {
        public static DataTable GetDentalSurgeryData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_Select");

                db.AddInParameter(dbCommand, "pds_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDentalSurgery(BusinessEntities.ConcentForms.DentalSurgery dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_Insert");

                db.AddInParameter(dbCommand, "pds_appId", DbType.Int32, dental.pds_appId);
                db.AddInParameter(dbCommand, "pds_1", DbType.String, string.IsNullOrEmpty(dental.pds_1) ? "" : dental.pds_1);
                db.AddInParameter(dbCommand, "pds_2", DbType.String, string.IsNullOrEmpty(dental.pds_2) ? "" : dental.pds_2);
                db.AddInParameter(dbCommand, "pds_3", DbType.String, string.IsNullOrEmpty(dental.pds_3) ? "" : dental.pds_3);
                db.AddInParameter(dbCommand, "pds_4", DbType.String, string.IsNullOrEmpty(dental.pds_4) ? "" : dental.pds_4);
                db.AddInParameter(dbCommand, "pds_5", DbType.String, string.IsNullOrEmpty(dental.pds_5) ? "" : dental.pds_5);
                db.AddInParameter(dbCommand, "pds_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pdsId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pdsId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pdsId"));
                return _pdsId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDentalSurgery(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_Delete");

                db.AddInParameter(dbCommand, "pds_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pds_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pds_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pds_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pds_output"));

                return _pds_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDentalSurgeryPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_PreviousHistory");

                db.AddInParameter(dbCommand, "pds_appId", DbType.Int32, appId);
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
