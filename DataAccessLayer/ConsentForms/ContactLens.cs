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
    public class ContactLens
    {
        public static DataTable GetContactLensData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Contact_Lenses_New_Select");

                db.AddInParameter(dbCommand, "fcl_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveContactLens(BusinessEntities.ConsentForms.ContactLens ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Contact_Lenses_New_Insert");

                db.AddInParameter(dbCommand, "fcl_appId", DbType.Int32, ophtha.fcl_appId);
                db.AddInParameter(dbCommand, "fcl_1", DbType.String, string.IsNullOrEmpty(ophtha.fcl_1) ? "" : ophtha.fcl_1);
                db.AddInParameter(dbCommand, "fcl_2", DbType.String, string.IsNullOrEmpty(ophtha.fcl_2) ? "" : ophtha.fcl_2);
                db.AddInParameter(dbCommand, "fcl_3", DbType.String, string.IsNullOrEmpty(ophtha.fcl_3) ? "" : ophtha.fcl_3);
                db.AddInParameter(dbCommand, "fcl_4", DbType.String, string.IsNullOrEmpty(ophtha.fcl_4) ? "" : ophtha.fcl_4);
                db.AddInParameter(dbCommand, "fcl_5", DbType.String, string.IsNullOrEmpty(ophtha.fcl_5) ? "" : ophtha.fcl_5);
                db.AddInParameter(dbCommand, "fcl_6", DbType.String, string.IsNullOrEmpty(ophtha.fcl_6) ? "" : ophtha.fcl_6);
                db.AddInParameter(dbCommand, "fcl_7", DbType.String, string.IsNullOrEmpty(ophtha.fcl_7) ? "" : ophtha.fcl_7);
                db.AddInParameter(dbCommand, "fcl_8", DbType.String, string.IsNullOrEmpty(ophtha.fcl_8) ? "" : ophtha.fcl_8);
                db.AddInParameter(dbCommand, "fcl_9", DbType.String, string.IsNullOrEmpty(ophtha.fcl_9) ? "" : ophtha.fcl_9);
                db.AddInParameter(dbCommand, "fcl_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "fclId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _fclId = Convert.ToInt32(db.GetParameterValue(dbCommand, "fclId"));
                return _fclId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteContactLens(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Contact_Lenses_New_Delete");

                db.AddInParameter(dbCommand, "fcl_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "fcl_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "fcl_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _fcl_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "fcl_output"));

                return _fcl_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetContactLensPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Contact_Lenses_New_PreviousHistory");

                db.AddInParameter(dbCommand, "fcl_appId", DbType.Int32, appId);
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
