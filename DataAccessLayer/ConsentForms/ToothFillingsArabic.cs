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
    public class ToothFillingsArabic
    {
        public static DataTable GetToothFillingsArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_Arabic_Select");

                db.AddInParameter(dbCommand, "itfa_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveToothFillingsArabic(BusinessEntities.ConsentForms.ToothFillingsArabic fillings, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_Arabic_Insert");

                db.AddInParameter(dbCommand, "itfa_appId", DbType.Int32, fillings.itfa_appId);
                db.AddInParameter(dbCommand, "itfa_1", DbType.String, fillings.itfa_1);
                db.AddInParameter(dbCommand, "itfa_2", DbType.String, fillings.itfa_2);
                db.AddInParameter(dbCommand, "itfa_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "itfaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _itfaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "itfaId"));
                return _itfaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteToothFillingsArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_Arabic_Delete");

                db.AddInParameter(dbCommand, "itfa_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "itfa_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "itfa_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _itfa_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "itfa_output"));

                return _itfa_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetToothFillingsArabicPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Tooth_Fillings_Arabic_PreviousHistory");

                db.AddInParameter(dbCommand, "itfa_appId", DbType.Int32, appId);
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
