using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    #region eSignature
    public class eSignature
    {
        //upload eSignature
        public static bool UploadSignature(BusinessEntities.Common.eSignature sign, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_eSignature_Upload");

                db.AddInParameter(dbCommand, "psb_appId", DbType.Int32, sign.appId);                
                db.AddInParameter(dbCommand, "psb_patId", DbType.Int32, sign.patId);
                db.AddInParameter(dbCommand, "psb_empId", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "psb_file", DbType.String, sign.formname);
                db.AddInParameter(dbCommand, "psb_sign", DbType.String, sign.eSign);
                db.AddInParameter(dbCommand, "psb_person", DbType.String, sign.person);
                db.AddInParameter(dbCommand, "psb_form", DbType.String, sign.form);
                db.AddInParameter(dbCommand, "psb_formlink", DbType.String, sign.formlink);
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

        //Get eSignature
        public static DataTable GetSignature(int? appId, string person, string form)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_eSignature_Select");
                
                db.AddInParameter(dbCommand, "psb_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "psb_person", DbType.String, person);
                db.AddInParameter(dbCommand, "psb_form", DbType.String, form);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];


                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    #endregion eSignature
}
