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
    public class ImageComparision
    {
        public static DataTable GetImageComparisionData(int appId, int? cicId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_Select");
                if (cicId > 0)
                {
                    db.AddInParameter(dbCommand, "cicId", DbType.Int32, cicId);
                }
                db.AddInParameter(dbCommand, "cic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveImageComparision(BusinessEntities.ConsentForms.ImageComparision image, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_Insert");

                db.AddInParameter(dbCommand, "cic_appId", DbType.Int32, image.cic_appId);
                db.AddInParameter(dbCommand, "cicIds", DbType.Int32, image.cicId);
                db.AddInParameter(dbCommand, "cic_title", DbType.String, string.IsNullOrEmpty(image.cic_title) ? "" : image.cic_title);
                db.AddInParameter(dbCommand, "cic_discription", DbType.String, string.IsNullOrEmpty(image.cic_discription) ? "" : image.cic_discription);
                db.AddInParameter(dbCommand, "cic_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cicId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cicId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cicId"));
                return _cicId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteImageComparision(int cicId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_Delete");

                db.AddInParameter(dbCommand, "cicId", DbType.Int32, cicId);
                db.AddInParameter(dbCommand, "cic_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cic_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cic_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cic_output"));

                return _cic_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetImageComparisionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_PreviousHistory");

                db.AddInParameter(dbCommand, "cic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static bool SaveImageComparision(BusinessEntities.ConsentForms.ImageComparision image)
        //{
        //    try
        //    {
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database db = factory.CreateDefault();
        //        DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_Insert");

        //        db.AddInParameter(dbCommand, "cic_refId", DbType.Int32, image.cic_refId);
        //        db.AddInParameter(dbCommand, "cic_reftype", DbType.String, image.cic_reftype);
        //        db.AddInParameter(dbCommand, "cic_label", DbType.String, image.cic_label);
        //        db.AddInParameter(dbCommand, "cic_1", DbType.String, image.cic_1);
        //        db.AddInParameter(dbCommand, "cic_name", DbType.String, image.cic_name);
        //        db.AddInParameter(dbCommand, "cic_ext", DbType.String, image.cic_ext);
        //        db.AddInParameter(dbCommand, "cic_path", DbType.String, image.cic_path);
        //        db.AddInParameter(dbCommand, "cic_uploadedBy", DbType.Int32, image.cic_uploadedBy);
        //        db.AddInParameter(dbCommand, "cic_category", DbType.String, image.cic_category);
        //        int result = db.ExecuteNonQuery(dbCommand);

        //        if (result > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        //public static DataTable GetImageComparisionData(int id, int type)
        //{
        //    try
        //    {
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database db = factory.CreateDefault();
        //        DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_Select");

        //        db.AddInParameter(dbCommand, "id", DbType.Int32, id);
        //        db.AddInParameter(dbCommand, "type", DbType.Int32, type);
        //        DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

        //        return dt;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static bool DeleteImageComparision(int cicId, int madeBy)
        //{
        //    try
        //    {
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database db = factory.CreateDefault();
        //        DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_Delete");

        //        db.AddInParameter(dbCommand, "cicId", DbType.Int32, cicId);
        //        db.AddInParameter(dbCommand, "cic_employee", DbType.Int32, madeBy);
        //        int result = db.ExecuteNonQuery(dbCommand);

        //        if (result > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public static DataTable GetImageComparisionPreviousHistory(int id, int type)
        //{
        //    try
        //    {
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database db = factory.CreateDefault();
        //        DbCommand dbCommand = db.GetStoredProcCommand("SP_Image_Comparison_New_PreviousHistory");

        //        db.AddInParameter(dbCommand, "id", DbType.Int32, id);
        //        db.AddInParameter(dbCommand, "type", DbType.Int32, type);
        //        DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

        //        return dt;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
