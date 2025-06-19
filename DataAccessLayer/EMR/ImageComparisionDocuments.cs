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
    public class ImageComparisionDocuments
    {

      
        public static DataTable GetImageComparisionDocumentsById(int id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ImageComparision_Uploaded_Select");

                db.AddInParameter(dbCommand, "id", DbType.Int32, id);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPrevImageComparisionDocumentsById(int id,int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PrevImageComparision_Uploaded_Select");

                db.AddInParameter(dbCommand, "id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SaveImageComparisionDocuments(BusinessEntities.EMR.ImageComparisionDocuments image, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ImageComparision_Uploaded");

                db.AddInParameter(dbCommand, "imgc_patId", DbType.Int32, image.imgc_patId);
                db.AddInParameter(dbCommand, "imgc_appId", DbType.Int32, image.imgc_appId);
                db.AddInParameter(dbCommand, "imgc_notes", DbType.String, string.IsNullOrEmpty(image.imgc_notes) ? "" : image.imgc_notes);
                db.AddInParameter(dbCommand, "imgc_image", DbType.String, image.imgc_image);
                db.AddInParameter(dbCommand, "imgc_type", DbType.String, image.imgc_type);
                db.AddInParameter(dbCommand, "imgc_made_by", DbType.Int32, madeby);
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


        public static bool DeleteImageComparisionDocuments(int imgcId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ImageComparision_Uploaded_Delete");

                db.AddInParameter(dbCommand, "imgcId", DbType.Int32, imgcId);
                db.AddInParameter(dbCommand, "imgc_made_by", DbType.Int32, madeby);
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
