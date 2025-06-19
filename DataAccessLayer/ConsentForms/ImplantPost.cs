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
    public class ImplantPost
    {
        public static DataTable GetImplantPostData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Post_Select");

                db.AddInParameter(dbCommand, "ipp_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveImplantPost(BusinessEntities.ConcentForms.ImplantPost tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Post_Insert");

                db.AddInParameter(dbCommand, "ipp_appId", DbType.Int32, tooth.ipp_appId);
                db.AddInParameter(dbCommand, "ipp_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ippId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ippId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ippId"));
                return _ippId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteImplantPost(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Post_Delete");

                db.AddInParameter(dbCommand, "ipp_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ipp_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ipp_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ipp_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ipp_output"));

                return _ipp_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetImplantPostPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Post_PreviousHistory");

                db.AddInParameter(dbCommand, "ipp_appId", DbType.Int32, appId);
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
