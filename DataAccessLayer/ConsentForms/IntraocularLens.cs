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
    public class IntraocularLens
    {
        public static DataTable GetIntraocularLensData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intraocular_Lens_Procedure_New_Select");

                db.AddInParameter(dbCommand, "ilp_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveIntraocularLens(BusinessEntities.ConsentForms.IntraocularLens ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intraocular_Lens_Procedure_New_Insert");

                db.AddInParameter(dbCommand, "ilp_appId", DbType.Int32, ophtha.ilp_appId);
                db.AddInParameter(dbCommand, "ilp_1", DbType.String, string.IsNullOrEmpty(ophtha.ilp_1) ? "" : ophtha.ilp_1);
                db.AddInParameter(dbCommand, "ilp_2", DbType.String, string.IsNullOrEmpty(ophtha.ilp_2) ? "" : ophtha.ilp_2);
                db.AddInParameter(dbCommand, "ilp_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ilpId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ilpId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ilpId"));
                return _ilpId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteIntraocularLens(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intraocular_Lens_Procedure_New_Delete");

                db.AddInParameter(dbCommand, "ilp_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ilp_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ilp_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ilp_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ilp_output"));

                return _ilp_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetIntraocularLensPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intraocular_Lens_Procedure_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ilp_appId", DbType.Int32, appId);
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
