using BusinessEntities;
using BusinessEntities.NurseStation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class LaboratoryRadiology
    {

        public static List<BusinessEntities.NurseStation.LaboratoryRadiology> GetAllLaboratoryRadiology(int appId)
        {
            List<BusinessEntities.NurseStation.LaboratoryRadiology> sclist = new List<BusinessEntities.NurseStation.LaboratoryRadiology>();
            DataTable dt = DataAccessLayer.NurseStation.LaboratoryRadiology.GetAllLaboratoryRadiology(appId);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.NurseStation.LaboratoryRadiology a = new BusinessEntities.NurseStation.LaboratoryRadiology();
                //sclist.Add(new BusinessEntities.NurseStation.LaboratoryRadiology
                //{
                a.ptId = Convert.ToInt32(dr["ptId"]);
                a.pt_appId = Convert.ToInt32(dr["pt_appId"]);


                a.pt_exe_date = Convert.ToDateTime(dr["pt_exe_date"].ToString());
                a.pt_date_modified = Convert.ToDateTime(dr["pt_date_modified"].ToString());
                a.pt_date_created = Convert.ToDateTime(dr["pt_date_created"].ToString());
                a.pt_tr_code = dr["pt_tr_code"].ToString();
                a.pt_notes = dr["pt_notes"].ToString();
                a.pt_lab_status = dr["pt_lab_status"].ToString();
                a.pt_discard_reason = dr["pt_discard_reason"].ToString();


                //});
                DateTime value = Convert.ToDateTime(dr["pt_date_collected"].ToString());
                DateTime value1 = Convert.ToDateTime(dr["pt_date_received"].ToString());
                DateTime value2 = Convert.ToDateTime(dr["pt_date_entered"].ToString());
                DateTime value3 = Convert.ToDateTime(dr["pt_date_authenticated"].ToString());
                DateTime value4 = Convert.ToDateTime(dr["pt_date_discarded"].ToString());
                if ((!string.IsNullOrEmpty(dr["pt_date_collected"].ToString())))
                {
                    a.pt_date_collected= value.ToString("dd-MM-yyyy hh:mm:ss tt");
                }
                else
                {
                    a.pt_date_collected = "Not Collected";
                }
                if ((!string.IsNullOrEmpty(dr["pt_date_received"].ToString())))
                {
                    a.pt_date_received = value1.ToString("dd-MM-yyyy hh:mm:ss tt");
                }
                else
                {
                    a.pt_date_received = "Not Collected";
                }
                if ((!string.IsNullOrEmpty(dr["pt_date_entered"].ToString())))
                {
                    
                        a.pt_date_entered = value2.ToString("dd-MM-yyyy hh:mm:ss tt");
                        
                }
                else
                {
                    a.pt_date_entered = "Not Collected";
                }
                if ((!string.IsNullOrEmpty(dr["pt_date_authenticated"].ToString())))
                {
                    a.pt_date_authenticated = value3.ToString("dd-MM-yyyy hh:mm:ss tt");
                }
                else
                {
                    a.pt_date_authenticated = "Not Collected";
                }
                if ((!string.IsNullOrEmpty(dr["pt_date_discarded"].ToString())))
                {
                    a.pt_date_discarded = value4.ToString("dd-MM-yyyy hh:mm:ss tt");
                }
                else
                {
                    a.pt_date_discarded = "N/A";
                }

                sclist.Add(a);
            }
            return sclist;
        }

        public static bool UpdatePatinetTreatmentCollection(BusinessEntities.NurseStation.LaboratoryRadiology data)
        {
            data.pt_lab_status = string.IsNullOrEmpty(data.pt_lab_status) ? string.Empty : data.pt_lab_status;
           
           

            return DataAccessLayer.NurseStation.LaboratoryRadiology.UpdatePatinetTreatmentCollection(data);
        }

        public static BarcodeServices GetBarcodePrintData(BarcodeServices data)
        {
            DataTable dt = DataAccessLayer.NurseStation.LaboratoryRadiology.GetBarcodePrintData(data);
            BarcodeServices barcodeService = new BarcodeServices();

            if (dt.Rows.Count > 0)
            {
                barcodeService.pt_appId = Convert.ToInt32(dt.Rows[0]["pt_appId"]);
                barcodeService.pat_code = dt.Rows[0]["pat_code"].ToString();
                barcodeService.pt_date_collected = Convert.ToDateTime(dt.Rows[0]["app_fdate"].ToString());
                barcodeService.pat_gender = dt.Rows[0]["pat_gender"].ToString();
                barcodeService.pat_name = dt.Rows[0]["pat_name"].ToString();
                barcodeService.pat_age_years = dt.Rows[0]["pat_age_years"].ToString();
            }
            return barcodeService;
        }
    }
}
