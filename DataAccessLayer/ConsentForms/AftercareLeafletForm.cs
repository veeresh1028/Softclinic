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
    public class AftercareLeafletForm
    {
        public static DataTable GetAftercareLeafletFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Aftercare_Leaflet_Form_Select");

                db.AddInParameter(dbCommand, "alf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAftercareLeafletForm(BusinessEntities.ConsentForms.AftercareLeafletForm after, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Aftercare_Leaflet_Form_Insert");

                db.AddInParameter(dbCommand, "alf_appId", DbType.Int32, after.alf_appId);
                db.AddInParameter(dbCommand, "alf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "alfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _alfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "alfId"));
                return _alfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAftercareLeafletForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Aftercare_Leaflet_Form_Delete");

                db.AddInParameter(dbCommand, "alf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "alf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "alf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _alf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "alf_output"));

                return _alf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAftercareLeafletFormPreviousHistroy(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Aftercare_Leaflet_Form_PreviousHistroy");

                db.AddInParameter(dbCommand, "alf_appId", DbType.Int32, appId);
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
