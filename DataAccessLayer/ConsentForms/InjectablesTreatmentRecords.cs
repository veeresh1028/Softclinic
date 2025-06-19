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
    public class InjectablesTreatmentRecords
    {
        public static DataTable GetInjectablesTreatmentRecordsData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Injectable_Treatment_Record_Select");

                db.AddInParameter(dbCommand, "itr_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveInjectablesTreatmentRecords(BusinessEntities.ConsentForms.InjectablesTreatmentRecords injectables, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Injectable_Treatment_Record_Insert");

                db.AddInParameter(dbCommand, "itr_appId", DbType.Int32, injectables.itr_appId);
                db.AddInParameter(dbCommand, "itr_1", DbType.String, string.IsNullOrEmpty(injectables.itr_1) ? "" : injectables.itr_1);
                db.AddInParameter(dbCommand, "itr_doc", DbType.String, injectables.image);
                db.AddInParameter(dbCommand, "itr_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "itrId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _itrId = Convert.ToInt32(db.GetParameterValue(dbCommand, "itrId"));
                return _itrId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteInjectablesTreatmentRecords(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Injectable_Treatment_Record_Delete");

                db.AddInParameter(dbCommand, "itr_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "itr_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "itr_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _itr_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "itr_output"));

                return _itr_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetInjectablesTreatmentRecordsPreviousHistroy(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Injectable_Treatment_Record_PreviousHistroy");

                db.AddInParameter(dbCommand, "itr_appId", DbType.Int32, appId);
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
