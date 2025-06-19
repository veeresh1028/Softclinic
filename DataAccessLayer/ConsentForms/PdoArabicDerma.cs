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
    public class PdoArabicDerma
    {
        public static DataTable GetPdoArabicDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pdo_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "pdoa_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SavePdoArabicDerma(BusinessEntities.ConsentForms.PdoArabicDerma pdo, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pdo_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "pdoa_appId", DbType.Int32, pdo.pdoa_appId);
                db.AddInParameter(dbCommand, "pdoa_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pdoaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pdoaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pdoaId"));
                return _pdoaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeletePdoArabicDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pdo_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "pdoa_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pdoa_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pdoa_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pdoa_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pdoa_output"));

                return _pdoa_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetPdoArabicDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pdo_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "pdoa_appId", DbType.Int32, appId);
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
