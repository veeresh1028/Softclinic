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
    public class VascularConsent
    {
        public static DataTable GetVascularConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Informed_Consent_Select");

                db.AddInParameter(dbCommand, "pic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveVascularConsent(BusinessEntities.ConsentForms.VascularConsent crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Informed_Consent_Insert");

                db.AddInParameter(dbCommand, "pic_appId", DbType.Int32, crown.pic_appId);
                db.AddInParameter(dbCommand, "pic_1", DbType.String, string.IsNullOrEmpty(crown.pic_1) ? "" : crown.pic_1);
                db.AddInParameter(dbCommand, "pic_2", DbType.String, string.IsNullOrEmpty(crown.pic_2) ? "" : crown.pic_2);
                db.AddInParameter(dbCommand, "pic_3", DbType.String, string.IsNullOrEmpty(crown.pic_3) ? "" : crown.pic_3);
                db.AddInParameter(dbCommand, "pic_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "picId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _picId = Convert.ToInt32(db.GetParameterValue(dbCommand, "picId"));
                return _picId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteVascularConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Informed_Consent_Delete");

                db.AddInParameter(dbCommand, "pic_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pic_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pic_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pic_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pic_output"));

                return _pic_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetVascularConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Informed_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "pic_appId", DbType.Int32, appId);
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
