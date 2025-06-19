using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.FrontDesk
{
    public class RegistrationForm
    {
        public static DataTable GetRegistrationForm(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REGISTRATION_FORM_select_all_info");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool UpdateRegistrationForm(BusinessEntities.FrontDesk.RegistrationForm data)

        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENTS_REGISTRATIONFORM_UPDATE");

                db.AddInParameter(dbCommand, "patId", DbType.Int32, data.patId);
                db.AddInParameter(dbCommand, "pat_dob", DbType.DateTime, data.pat_dob);
                db.AddInParameter(dbCommand, "pat_tel", DbType.String, data.pat_tel);
                db.AddInParameter(dbCommand, "pat_email", DbType.String, data.pat_email);
                db.AddInParameter(dbCommand, "pat_mob", DbType.String, data.pat_mob);
                db.AddInParameter(dbCommand, "pat_address", DbType.String, data.pat_address);
                db.AddInParameter(dbCommand, "pat_hear", DbType.String, data.pat_hear);
                db.AddInParameter(dbCommand, "pat_referal", DbType.Int32, data.pat_referal);
                db.AddInParameter(dbCommand, "pat_madeby", DbType.Int32, data.pat_madeby);
                db.AddInParameter(dbCommand, "pat_nat", DbType.Int32, data.pat_nat);
                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
