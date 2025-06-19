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
    public class CrownArabic
    {
        public static DataTable GetCrownArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Arabic_Select");

                db.AddInParameter(dbCommand, "icca_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveCrownArabic(BusinessEntities.ConcentForms.CrownArabic crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Arabic_Insert");

                db.AddInParameter(dbCommand, "icca_appId", DbType.Int32, crown.icca_appId);
                db.AddInParameter(dbCommand, "icca_1", DbType.String, crown.icca_1);
                db.AddInParameter(dbCommand, "icca_2", DbType.String, crown.icca_2);
                db.AddInParameter(dbCommand, "icca_3", DbType.String, crown.icca_3);
                db.AddInParameter(dbCommand, "icca_4", DbType.String, crown.icca_4);
                db.AddInParameter(dbCommand, "icca_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "iccaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _iccaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "iccaId"));
                return _iccaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteCrownArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Arabic_Delete");

                db.AddInParameter(dbCommand, "icca_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "icca_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "icca_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _icca_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "icca_output"));

                return _icca_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetCrownArabicPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Arabic_PreviousHistory");

                db.AddInParameter(dbCommand, "icca_appId", DbType.Int32, appId);
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
