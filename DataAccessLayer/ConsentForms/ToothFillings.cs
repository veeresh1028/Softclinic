using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class ToothFillings
    {
        public static DataTable GetToothFillingsData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_Select");

                db.AddInParameter(dbCommand, "itf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveToothFillings(BusinessEntities.ConcentForms.ToothFillings tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_Insert");

                db.AddInParameter(dbCommand, "itf_appId", DbType.Int32, tooth.itf_appId);
                db.AddInParameter(dbCommand, "itf_1", DbType.String, tooth.itf_1);
                db.AddInParameter(dbCommand, "itf_2", DbType.String, tooth.itf_2);
                db.AddInParameter(dbCommand, "itf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "itfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _itfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "itfId"));
                return _itfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteToothFillings(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_Delete");

                db.AddInParameter(dbCommand, "itf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "itf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "itf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _itf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "itf_output"));

                return _itf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetToothFillingsPreviousHistroy(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_PreviousHistroy");

                db.AddInParameter(dbCommand, "itf_appId", DbType.Int32, appId);
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
