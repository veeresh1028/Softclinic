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
    public class ChemicalPeelingArb
    {
        public static DataTable GetChemicalPeelingArbData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "cpfa_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveChemicalPeelingArb(BusinessEntities.ConsentForms.ChemicalPeelingArb derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "cpfa_appId", DbType.Int32, derma.cpfa_appId);
                db.AddInParameter(dbCommand, "cpfa_1", DbType.String, string.IsNullOrEmpty(derma.cpfa_1) ? "" : derma.cpfa_1);
                db.AddInParameter(dbCommand, "cpfa_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cpfaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cpfaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpfaId"));
                return _cpfaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteChemicalPeelingArb(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "cpfa_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cpfa_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cpfa_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cpfa_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpfa_output"));

                return _cpfa_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetChemicalPeelingArbPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chemical_Peeling_Form_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "cpfa_appId", DbType.Int32, appId);
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
