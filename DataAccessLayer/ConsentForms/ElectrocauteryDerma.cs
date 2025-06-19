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
    public class ElectrocauteryDerma
    {
        public static DataTable GetElectrocauteryDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Derma_Select");

                db.AddInParameter(dbCommand, "elec_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveElectrocauteryDerma(BusinessEntities.ConsentForms.ElectrocauteryDerma electro, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Derma_Insert");

                db.AddInParameter(dbCommand, "elec_appId", DbType.Int32, electro.elec_appId);
                db.AddInParameter(dbCommand, "elec_1", DbType.String, string.IsNullOrEmpty(electro.elec_1) ? "" : electro.elec_1);
                db.AddInParameter(dbCommand, "elec_2", DbType.String, string.IsNullOrEmpty(electro.elec_2) ? "" : electro.elec_2);
                db.AddInParameter(dbCommand, "elec_3", DbType.String, string.IsNullOrEmpty(electro.elec_3) ? "" : electro.elec_3);
                db.AddInParameter(dbCommand, "elec_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "elecId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _elecId = Convert.ToInt32(db.GetParameterValue(dbCommand, "elecId"));
                return _elecId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteElectrocauteryDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Derma_Delete");

                db.AddInParameter(dbCommand, "elec_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "elec_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "elec_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _elec_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "elec_output"));

                return _elec_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetElectrocauteryDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Electrocautery_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "elec_appId", DbType.Int32, appId);
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
