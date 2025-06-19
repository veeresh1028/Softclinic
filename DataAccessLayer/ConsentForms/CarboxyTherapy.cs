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
    public class CarboxyTherapy
    {
        public static DataTable GetCarboxyTherapyData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Carboxy_Therapy_Consent_Form_Select");

                db.AddInParameter(dbCommand, "ctc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveCarboxyTherapy(BusinessEntities.ConsentForms.CarboxyTherapy carboxy, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Carboxy_Therapy_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "ctc_appId", DbType.Int32, carboxy.ctc_appId);
                db.AddInParameter(dbCommand, "ctc_1", DbType.String, string.IsNullOrEmpty(carboxy.ctc_1) ? "" : carboxy.ctc_1);
                db.AddInParameter(dbCommand, "ctc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ctcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ctcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ctcId"));
                return _ctcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteCarboxyTherapy(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Carboxy_Therapy_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "ctc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ctc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ctc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ctc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ctc_output"));

                return _ctc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetCarboxyTherapyPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Carboxy_Therapy_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "ctc_appId", DbType.Int32, appId);
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
