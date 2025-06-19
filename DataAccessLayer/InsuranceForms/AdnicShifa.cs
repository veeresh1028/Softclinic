using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InsuranceForms
{
    public class AdnicShifa
    {
        public static DataTable GetAdnicShifaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Shifa_select");

                db.AddInParameter(dbCommand, "ads_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int SaveAdnicShifa(BusinessEntities.InsuranceForms.AdnicShifa Shifa, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Shifa_Insert");

                db.AddInParameter(dbCommand, "ads_appId", DbType.Int32, Shifa.ads_appId);
                db.AddInParameter(dbCommand, "ads_voucher", DbType.String, string.IsNullOrEmpty(Shifa.ads_voucher) ? "" : Shifa.ads_voucher);
                db.AddInParameter(dbCommand, "ads_group_mem", DbType.String, string.IsNullOrEmpty(Shifa.ads_group_mem) ? "" : Shifa.ads_group_mem);
                db.AddInParameter(dbCommand, "ads_type_plan", DbType.String, string.IsNullOrEmpty(Shifa.ads_type_plan) ? "" : Shifa.ads_type_plan);
                db.AddInParameter(dbCommand, "ads_reason", DbType.String, string.IsNullOrEmpty(Shifa.ads_reason) ? "" : Shifa.ads_reason);
                db.AddInParameter(dbCommand, "ads_reason_other", DbType.String, string.IsNullOrEmpty(Shifa.ads_reason_other) ? "" : Shifa.ads_reason_other);
                db.AddInParameter(dbCommand, "ads_condition", DbType.String, string.IsNullOrEmpty(Shifa.ads_condition) ? "" : Shifa.ads_condition);
                db.AddInParameter(dbCommand, "ads_visit", DbType.String, string.IsNullOrEmpty(Shifa.ads_visit) ? "" : Shifa.ads_visit);
                db.AddInParameter(dbCommand, "ads_treat_details", DbType.String, string.IsNullOrEmpty(Shifa.ads_treat_details) ? "" : Shifa.ads_treat_details);
                db.AddInParameter(dbCommand, "ads_addr1", DbType.String, string.IsNullOrEmpty(Shifa.ads_addr1) ? "" : Shifa.ads_addr1);
                db.AddInParameter(dbCommand, "ads_bill1", DbType.String, string.IsNullOrEmpty(Shifa.ads_bill1) ? "" : Shifa.ads_bill1);
                db.AddInParameter(dbCommand, "ads_tdate1", DbType.String, string.IsNullOrEmpty(Shifa.ads_tdate1) ? "" : Shifa.ads_tdate1);
                db.AddInParameter(dbCommand, "ads_desc1", DbType.String, string.IsNullOrEmpty(Shifa.ads_desc1) ? "" : Shifa.ads_desc1);
                db.AddInParameter(dbCommand, "ads_amt1", DbType.String, string.IsNullOrEmpty(Shifa.ads_amt1) ? "" : Shifa.ads_amt1);
                db.AddInParameter(dbCommand, "ads_addr2", DbType.String, string.IsNullOrEmpty(Shifa.ads_addr2) ? "" : Shifa.ads_addr2);
                db.AddInParameter(dbCommand, "ads_bill2", DbType.String, string.IsNullOrEmpty(Shifa.ads_bill2) ? "" : Shifa.ads_bill2);
                db.AddInParameter(dbCommand, "ads_tdate2", DbType.String, string.IsNullOrEmpty(Shifa.ads_tdate2) ? "" : Shifa.ads_tdate2);
                db.AddInParameter(dbCommand, "ads_desc2", DbType.String, string.IsNullOrEmpty(Shifa.ads_desc2) ? "" : Shifa.ads_desc2);
                db.AddInParameter(dbCommand, "ads_amt2", DbType.String, string.IsNullOrEmpty(Shifa.ads_amt2) ? "" : Shifa.ads_amt2);
                db.AddInParameter(dbCommand, "ads_addr3", DbType.String, string.IsNullOrEmpty(Shifa.ads_addr3) ? "" : Shifa.ads_addr3);
                db.AddInParameter(dbCommand, "ads_bill3", DbType.String, string.IsNullOrEmpty(Shifa.ads_bill3) ? "" : Shifa.ads_bill3);
                db.AddInParameter(dbCommand, "ads_tdate3", DbType.String, string.IsNullOrEmpty(Shifa.ads_tdate3) ? "" : Shifa.ads_tdate3);
                db.AddInParameter(dbCommand, "ads_desc3", DbType.String, string.IsNullOrEmpty(Shifa.ads_desc3) ? "" : Shifa.ads_desc3);
                db.AddInParameter(dbCommand, "ads_amt3", DbType.String, string.IsNullOrEmpty(Shifa.ads_amt3) ? "" : Shifa.ads_amt3);
                db.AddInParameter(dbCommand, "ads_addr4", DbType.String, string.IsNullOrEmpty(Shifa.ads_addr4) ? "" : Shifa.ads_addr4);
                db.AddInParameter(dbCommand, "ads_bill4", DbType.String, string.IsNullOrEmpty(Shifa.ads_bill4) ? "" : Shifa.ads_bill4);
                db.AddInParameter(dbCommand, "ads_tdate4", DbType.String, string.IsNullOrEmpty(Shifa.ads_tdate4) ? "" : Shifa.ads_tdate4);
                db.AddInParameter(dbCommand, "ads_desc4", DbType.String, string.IsNullOrEmpty(Shifa.ads_desc4) ? "" : Shifa.ads_desc4);
                db.AddInParameter(dbCommand, "ads_amt4", DbType.String, string.IsNullOrEmpty(Shifa.ads_amt4) ? "" : Shifa.ads_amt4);
                db.AddInParameter(dbCommand, "ads_addr5", DbType.String, string.IsNullOrEmpty(Shifa.ads_addr5) ? "" : Shifa.ads_addr5);
                db.AddInParameter(dbCommand, "ads_bill5", DbType.String, string.IsNullOrEmpty(Shifa.ads_bill5) ? "" : Shifa.ads_bill5);
                db.AddInParameter(dbCommand, "ads_tdate5", DbType.String, string.IsNullOrEmpty(Shifa.ads_tdate5) ? "" : Shifa.ads_tdate5);
                db.AddInParameter(dbCommand, "ads_desc5", DbType.String, string.IsNullOrEmpty(Shifa.ads_desc5) ? "" : Shifa.ads_desc5);
                db.AddInParameter(dbCommand, "ads_amt5", DbType.String, string.IsNullOrEmpty(Shifa.ads_amt5) ? "" : Shifa.ads_amt5);
                db.AddInParameter(dbCommand, "ads_total", DbType.String, string.IsNullOrEmpty(Shifa.ads_total) ? "" : Shifa.ads_total);
                db.AddInParameter(dbCommand, "ads_oth_above", DbType.String, string.IsNullOrEmpty(Shifa.ads_oth_above) ? "" : Shifa.ads_oth_above);
                db.AddInParameter(dbCommand, "ads_oth_above_det", DbType.String, string.IsNullOrEmpty(Shifa.ads_oth_above_det) ? "" : Shifa.ads_oth_above_det);
                db.AddInParameter(dbCommand, "ads_oth_claim", DbType.String, string.IsNullOrEmpty(Shifa.ads_oth_claim) ? "" : Shifa.ads_oth_claim);
                db.AddInParameter(dbCommand, "ads_oth_claim_det", DbType.String, string.IsNullOrEmpty(Shifa.ads_oth_claim_det) ? "" : Shifa.ads_oth_claim_det);
                db.AddInParameter(dbCommand, "ads_onset", DbType.String, string.IsNullOrEmpty(Shifa.ads_onset) ? "" : Shifa.ads_onset);
                db.AddInParameter(dbCommand, "ads_bank", DbType.String, string.IsNullOrEmpty(Shifa.ads_bank) ? "" : Shifa.ads_bank);
                db.AddInParameter(dbCommand, "ads_account", DbType.String, string.IsNullOrEmpty(Shifa.ads_account) ? "" : Shifa.ads_account);
                db.AddInParameter(dbCommand, "ads_bname", DbType.String, string.IsNullOrEmpty(Shifa.ads_bname) ? "" : Shifa.ads_bname);
                db.AddInParameter(dbCommand, "ads_baddress", DbType.String, string.IsNullOrEmpty(Shifa.ads_baddress) ? "" : Shifa.ads_baddress);
                db.AddInParameter(dbCommand, "ads_bcurrency", DbType.String, string.IsNullOrEmpty(Shifa.ads_bcurrency) ? "" : Shifa.ads_bcurrency);
                db.AddInParameter(dbCommand, "ads_bswiftcode", DbType.String, string.IsNullOrEmpty(Shifa.ads_bswiftcode) ? "" : Shifa.ads_bswiftcode);
                db.AddInParameter(dbCommand, "ads_witnessname", DbType.String, string.IsNullOrEmpty(Shifa.ads_witnessname) ? "" : Shifa.ads_witnessname);
                db.AddInParameter(dbCommand, "ads_contact", DbType.String, string.IsNullOrEmpty(Shifa.ads_contact) ? "" : Shifa.ads_contact);
                db.AddInParameter(dbCommand, "ads_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "adsId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _adsId = Convert.ToInt32(db.GetParameterValue(dbCommand, "adsId"));
                return _adsId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteAdnicShifa(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Shifa_Delete");

                db.AddInParameter(dbCommand, "ads_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ads_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ads_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ads_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ads_output"));

                return _ads_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAdnicShifaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Shifa_Previoushistory");

                db.AddInParameter(dbCommand, "ads_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
