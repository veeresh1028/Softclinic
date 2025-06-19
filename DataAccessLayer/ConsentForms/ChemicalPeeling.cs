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
    public class ChemicalPeeling
    {
        public static DataTable GetChemicalPeelingData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Derma_Select");

                db.AddInParameter(dbCommand, "cpf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveChemicalPeeling(BusinessEntities.ConsentForms.ChemicalPeeling derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Derma_Insert");

                db.AddInParameter(dbCommand, "cpf_appId", DbType.Int32, derma.cpf_appId);
                db.AddInParameter(dbCommand, "cpf_1", DbType.String, string.IsNullOrEmpty(derma.cpf_1) ? "" : derma.cpf_1);
                db.AddInParameter(dbCommand, "cpf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cpfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cpfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpfId"));
                return _cpfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteChemicalPeeling(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Derma_Delete");

                db.AddInParameter(dbCommand, "cpf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cpf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cpf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cpf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpf_output"));

                return _cpf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetChemicalPeelingPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "cpf_appId", DbType.Int32, appId);
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
