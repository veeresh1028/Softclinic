using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DataAccessLayer.NurseStation
{
    public class LaboratoryRadiology
    {
        public static DataTable GetAllLaboratoryRadiology(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetLABRadiology");
                
                db.AddInParameter(dbCommand, "appId", DbType.Int32, 19068);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool UpdatePatinetTreatmentCollection(BusinessEntities.NurseStation.LaboratoryRadiology data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_update_collection");
               
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, data.ptId);
                db.AddInParameter(dbCommand, "pt_lab_status", DbType.String, data.pt_lab_status);
                db.AddInParameter(dbCommand, "pt_notes", DbType.String, "");
                db.AddInParameter(dbCommand, "pt_sur", DbType.String, "");
                db.AddInParameter(dbCommand, "pt_date_collected", DbType.DateTime, data.pt_date_collected);
                db.AddInParameter(dbCommand, "pt_coll_by", DbType.Int32, data.pt_coll_by);


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

        public static DataTable GetBarcodePrintData(BusinessEntities.NurseStation.BarcodeServices data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPrintBarcode");
                 //db.AddInParameter(dbCommand, "ptId", DbType.Int32, data.ptId);
                 db.AddInParameter(dbCommand, "ptId", DbType.Int32, 1006);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
