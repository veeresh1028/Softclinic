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
    public class Vaccination
    {
        #region Patient Vaccination (Page Load)
        public static DataTable GetAllVaccination(int? appId, int? pvId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_VACCINATIONS_select_all_info");
                if (pvId > 0)
                {
                    db.AddInParameter(dbCommand, "pvId", DbType.Int32, pvId);
                }
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

        public static DataTable GetAllPreVaccination(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_VACCINATIONS_PREVIOUS");
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
        public static DataTable GetVaccine(string query, string flag)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetVaccineDoseMaster");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "flag", DbType.String, flag);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }

        }


        #endregion Patient Vaccination (Page Load)

        #region Patient Vaccination  CRUD Operations
        public static bool InsertUpdateVaccination(BusinessEntities.EMR.Vaccination data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_VACCINATIONS_INSERT_UPDATE");
                if (data.pvId > 0)
                {
                    db.AddInParameter(dbCommand, "pvId", DbType.Int32, data.pvId);
                }
                db.AddInParameter(dbCommand, "pv_appId", DbType.Int32, data.pv_appId);
                db.AddInParameter(dbCommand, "pv_vaccination", DbType.Int32, data.pv_vaccination);
                db.AddInParameter(dbCommand, "pv_notes", DbType.String, data.pv_notes);
                db.AddInParameter(dbCommand, "pv_batchno", DbType.String, data.pv_batchno);
                db.AddInParameter(dbCommand, "pv_manufacturer", DbType.String, data.pv_manufacturer);
                db.AddInParameter(dbCommand, "pv_exp_date", DbType.DateTime, data.pv_exp_date);
                db.AddInParameter(dbCommand, "pv_dose", DbType.String, data.pv_dose);
                db.AddInParameter(dbCommand, "pv_reminder_notes", DbType.String, data.pv_reminder_notes);
                db.AddInParameter(dbCommand, "pv_date", DbType.DateTime, data.pv_date);
                db.AddInParameter(dbCommand, "pv_madeby", DbType.Int32, data.pv_madeby);

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

        public static int DeleteVaccination(int pvId, int pv_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_VACCINATIONS_delete");
                db.AddInParameter(dbCommand, "pvId", DbType.Int32, pvId);
                db.AddInParameter(dbCommand, "pv_madeby", DbType.Int32, pv_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion Patient Vaccination  CRUD Operations


        #region Patient Vaccination Record(Page Load)
        public static DataTable GetAllVaccinationRecord(int? patId, int? vac_recId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VACCINATIONS_RECORD_select_all_info");
                if (vac_recId > 0)
                {
                    db.AddInParameter(dbCommand, "vac_recId", DbType.Int32, vac_recId);
                }
                if (patId > 0)
                {
                    db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Patient Vaccination Record(Page Load)

        #region Patient Vaccination  CRUD Operations
        public static bool InsertUpdateVaccinationRecord(BusinessEntities.EMR.VaccinationRecord data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VACCINATIONS_RECORD_INSERT_UPDATE");
                if (data.vac_recId > 0)
                {
                    db.AddInParameter(dbCommand, "vac_recId", DbType.Int32, data.vac_recId);
                }
                db.AddInParameter(dbCommand, "vac_rec_patId", DbType.Int32, data.vac_rec_patId);
                db.AddInParameter(dbCommand, "vac_rec_date1", DbType.DateTime, data.vac_rec_date1);
                db.AddInParameter(dbCommand, "vac_rec_date2", DbType.DateTime, data.vac_rec_date2);
                db.AddInParameter(dbCommand, "vac_rec_date3", DbType.DateTime, data.vac_rec_date3);
                db.AddInParameter(dbCommand, "vac_rec_date4", DbType.DateTime, data.vac_rec_date4);
                db.AddInParameter(dbCommand, "vac_rec_date5", DbType.DateTime, data.vac_rec_date5);
                db.AddInParameter(dbCommand, "vac_rec_date6", DbType.DateTime, data.vac_rec_date6);
                db.AddInParameter(dbCommand, "vac_rec_date7", DbType.DateTime, data.vac_rec_date7);
                db.AddInParameter(dbCommand, "vac_rec_date8", DbType.DateTime, data.vac_rec_date8);
                db.AddInParameter(dbCommand, "vac_rec_date9", DbType.DateTime, data.vac_rec_date9);
                db.AddInParameter(dbCommand, "vac_rec_date10", DbType.DateTime, data.vac_rec_date10);
                db.AddInParameter(dbCommand, "vac_rec_date11", DbType.DateTime, data.vac_rec_date11);
                db.AddInParameter(dbCommand, "vac_rec_date12", DbType.DateTime, data.vac_rec_date12);
                db.AddInParameter(dbCommand, "vac_rec_date13", DbType.DateTime, data.vac_rec_date13);
                db.AddInParameter(dbCommand, "vac_rec_date14", DbType.DateTime, data.vac_rec_date14);
                db.AddInParameter(dbCommand, "vac_rec_date15", DbType.DateTime, data.vac_rec_date15);
                db.AddInParameter(dbCommand, "vac_rec_date16", DbType.DateTime, data.vac_rec_date16);
                db.AddInParameter(dbCommand, "vac_rec_date17", DbType.DateTime, data.vac_rec_date17);
                db.AddInParameter(dbCommand, "vac_rec_date18", DbType.DateTime, data.vac_rec_date18);
                db.AddInParameter(dbCommand, "vac_rec_date19", DbType.DateTime, data.vac_rec_date19);
                db.AddInParameter(dbCommand, "vac_rec_date20", DbType.DateTime, data.vac_rec_date20);
                db.AddInParameter(dbCommand, "vac_rec_date21", DbType.DateTime, data.vac_rec_date21);
                db.AddInParameter(dbCommand, "vac_rec_date22", DbType.DateTime, data.vac_rec_date22);
                db.AddInParameter(dbCommand, "vac_rec_date23", DbType.DateTime, data.vac_rec_date23);
                db.AddInParameter(dbCommand, "vac_rec_date24", DbType.DateTime, data.vac_rec_date24);
                db.AddInParameter(dbCommand, "vac_rec_date25", DbType.DateTime, data.vac_rec_date25);
                db.AddInParameter(dbCommand, "vac_rec_date26", DbType.DateTime, data.vac_rec_date26);
                db.AddInParameter(dbCommand, "vac_rec_date27", DbType.DateTime, data.vac_rec_date27);
                db.AddInParameter(dbCommand, "vac_rec_date28", DbType.DateTime, data.vac_rec_date28);
                db.AddInParameter(dbCommand, "vac_rec_date29", DbType.DateTime, data.vac_rec_date29);
                db.AddInParameter(dbCommand, "vac_rec_date30", DbType.DateTime, data.vac_rec_date30);
                db.AddInParameter(dbCommand, "vac_rec_date31", DbType.DateTime, data.vac_rec_date31);
                db.AddInParameter(dbCommand, "vac_rec_date32", DbType.DateTime, data.vac_rec_date32);
                db.AddInParameter(dbCommand, "vac_rec_date33", DbType.DateTime, data.vac_rec_date33);
                db.AddInParameter(dbCommand, "vac_rec_date34", DbType.DateTime, data.vac_rec_date34);
                db.AddInParameter(dbCommand, "vac_rec_date35", DbType.DateTime, data.vac_rec_date35);
                db.AddInParameter(dbCommand, "vac_rec_date36", DbType.DateTime, data.vac_rec_date36);
                db.AddInParameter(dbCommand, "vac_rec_madeby", DbType.Int32, data.vac_rec_madeby);

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
                throw ex;
            }
        }

        public static int DeleteVaccinationRecord(int vac_recId, int vac_rec_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VACCINATIONS_RECORD_delete");
                db.AddInParameter(dbCommand, "vac_recId", DbType.Int32, vac_recId);
                db.AddInParameter(dbCommand, "vac_madeby", DbType.Int32, vac_rec_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion Patient Vaccination Record CRUD Operations
    }
}
