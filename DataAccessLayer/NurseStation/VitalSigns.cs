using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NurseStation
{
    public class VitalSigns
    {
        #region VitalSigns

        public static DataTable GetAllVitalSigns(int appId, int? signId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SIGNS_select_all_info");
                if (signId > 0)
                {
                    db.AddInParameter(dbCommand, "signId", DbType.Int32, signId);
                }
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreVitalSigns(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SIGNS_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int InsertUpdateVitalSigns(BusinessEntities.NurseStation.VitalSigns data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SIGNS_INSERT_UPDATE");
                if (data.signId > 0)
                {
                    db.AddInParameter(dbCommand, "signId", DbType.Int32, data.signId);
                }
                db.AddInParameter(dbCommand, "sign_appId", DbType.Int32, data.sign_appId);
                db.AddInParameter(dbCommand, "sign_temp", DbType.String, data.sign_temp);
                db.AddInParameter(dbCommand, "sign_pulse", DbType.String, data.sign_pulse);
                db.AddInParameter(dbCommand, "sign_bp", DbType.String, data.sign_bp);
                db.AddInParameter(dbCommand, "sign_bpd", DbType.String, data.sign_bpd);
                db.AddInParameter(dbCommand, "sign_height", DbType.String, data.sign_height);
                db.AddInParameter(dbCommand, "sign_weight", DbType.String, data.sign_weight);
                db.AddInParameter(dbCommand, "sign_resp", DbType.String, data.sign_resp);
                db.AddInParameter(dbCommand, "sign_spo2", DbType.String, data.sign_spo2);
                db.AddInParameter(dbCommand, "sign_hip", DbType.String, data.sign_hip);
                db.AddInParameter(dbCommand, "sign_waist", DbType.String, data.sign_waist);
                db.AddInParameter(dbCommand, "sign_head", DbType.String, data.sign_head);
                db.AddInParameter(dbCommand, "sign_uri", DbType.String, data.sign_uri);
                db.AddInParameter(dbCommand, "sign_notes", DbType.String, data.sign_notes);
                db.AddInParameter(dbCommand, "sign_madeby", DbType.Int32, data.sign_madeby);
                db.AddInParameter(dbCommand, "sign_modifyby", DbType.Int32, data.sign_madeby);
                db.AddInParameter(dbCommand, "sign_sugar", DbType.String, data.sign_sugar);
                db.AddOutParameter(dbCommand, "sign_Id", DbType.Int32, 100);
                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "sign_Id").ToString());
                //int result = db.ExecuteNonQuery(dbCommand);

                //if (result > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }

         public static int DeleteVitalSigns(int signId,  int sign_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SIGNS_delete");


                db.AddInParameter(dbCommand, "signId", DbType.Int32, signId);
                db.AddInParameter(dbCommand, "sign_modifyby", DbType.Int32, sign_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion VitalSigns
    }
}
