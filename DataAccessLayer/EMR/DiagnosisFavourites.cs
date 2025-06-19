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
    public class DiagnosisFavourites
    {
        #region Diagnosis Favourites (Page Load)
        public static DataTable GetAllDiagnosisFavourites(int? empId, int? pdfId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DIAGNOSIS_FAVOURITES_select_all_info");
                if (pdfId > 0)
                {
                    db.AddInParameter(dbCommand, "pdfId", DbType.Int32, pdfId);
                }
                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Diagnosis Favourites (Page Load)

        #region Diagnosis Favourites CRUD Operations

        public static int InsertUpdateDiagnosisFavourites(BusinessEntities.EMR.DiagnosisFavourites data)
        {
            try
            {
                int padId_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DIAGNOSIS_FAVOURITES_INSERT_UPDATE");
                if (data.pdfId > 0)
                {
                    db.AddInParameter(dbCommand, "pdfId", DbType.Int32,data.pdfId);
                }
                db.AddInParameter(dbCommand, "pdf_empId", DbType.Int32, data.pdf_empId);
                db.AddInParameter(dbCommand, "pdf_diagnosis", DbType.Int32, data.pdf_diagnosis);
                db.AddInParameter(dbCommand, "pdf_notes", DbType.String, data.pdf_notes);
                db.AddInParameter(dbCommand, "pdf_madeby", DbType.Int32, data.pdf_madeby);
                

                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int DeleteDiagnosisFavourites(int pdfId, int pdf_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DIAGNOSIS_FAVOURITES_delete");
                db.AddInParameter(dbCommand, "pdfId", DbType.Int32, pdfId);
                db.AddInParameter(dbCommand, "pdf_madeby", DbType.Int32, pdf_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion Diagnosis Favourites CRUD Operations
    }
}
