using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class LaserMarking
    {
        #region Botex Picture Men (Page Load)
        public static DataTable GetAllPreLaserMarking(int appId, int patId, string lfm_form)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_LASER_FACE_MARKING_PREVIOUS");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lfm_form", DbType.String, lfm_form);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Get 
        public static DataTable GetLaserMarking(int? appId, int? lfmId, string lfm_form)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_LASER_FACE_MARKING_Select");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "lfm_appId", DbType.Int32, appId);
                    
                }
                //if (lfm_form != "")
                //{
                //    db.AddInParameter(dbCommand, "lfm_form", DbType.String, lfm_form);

                //}
                db.AddInParameter(dbCommand, "lfm_form", DbType.String, lfm_form);
                if (lfmId > 0)
                {
                    db.AddInParameter(dbCommand, "lfmId", DbType.Int32, lfmId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Botex Picture Men (Page Load)
        #region Botex Picture Men  CRUD Operations
        //upload Botex Picture Men
        public static bool UploadLaserMarking(BusinessEntities.EMR.LaserMarking data, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_LASER_FACE_MARKING_INSERT_UPDATE");
                if (data.lfmId > 0)
                {
                    db.AddInParameter(dbCommand, "lfmId", DbType.Int32, data.lfmId);
                }
                db.AddInParameter(dbCommand, "lfm_appId", DbType.Int32, data.lfm_appId);
                db.AddInParameter(dbCommand, "lfm_patId", DbType.Int32, data.lfm_patId);
                db.AddInParameter(dbCommand, "lfm_madeby", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "lfm_doc", DbType.String, data.image);
                db.AddInParameter(dbCommand, "lfm_form", DbType.String, data.lfm_form);
                db.AddInParameter(dbCommand, "lfm_doc2", DbType.String, data.lfm_doc2);

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
        public static int DeleteLaserMarking(int lfmId, int lfm_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_LASER_FACE_MARKING_delete");

                db.AddInParameter(dbCommand, "lfmId", DbType.Int32, lfmId);
                db.AddInParameter(dbCommand, "lfm_madeby", DbType.String, lfm_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Botex Picture Men  CRUD Operations
    }
}
