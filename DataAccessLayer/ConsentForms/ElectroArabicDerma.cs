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
    public class ElectroArabicDerma
    {
        public static DataTable GetElectroArabicDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "eleca_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveElectroArabicDerma(BusinessEntities.ConsentForms.ElectroArabicDerma electro, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "eleca_appId", DbType.Int32, electro.eleca_appId);
                db.AddInParameter(dbCommand, "eleca_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "elecaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _elecaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "elecaId"));
                return _elecaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static int DeleteElectroArabicDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "eleca_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "eleca_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "eleca_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _eleca_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "eleca_output"));

                return _eleca_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetElectroArabicDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "eleca_appId", DbType.Int32, appId);
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
