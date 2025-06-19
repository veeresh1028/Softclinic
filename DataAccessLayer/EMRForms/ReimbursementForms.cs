using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMRForms
{
    public class Adnic
    {
        public static DataTable GetAllAdnic(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Shifa_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAdnic(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADNIC_SHIFA_PREVIOUS_History");
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
        public static DataTable GetAllPatientTreatments(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_All_Patient_Treatments");
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
        public static DataTable Get_Patient_Complaints(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Complaints");
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
        public static DataTable Get_Patient_Signs(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Signs");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable Get_Patient_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetPrintAdnic(int? adsId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADNIC_SHIFA_Print");
                if (adsId > 0)
                {
                    db.AddInParameter(dbCommand, "adsId", DbType.Int32, adsId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool InsertUpdateAdnic(BusinessEntities.EMRForms.Adnic data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADNIC_SHIFA_INSERT_UPDATE");
                if (data.adsId > 0)
                {
                    db.AddInParameter(dbCommand, "adsId", DbType.Int32, data.adsId);
                }
                db.AddInParameter(dbCommand, "ads_appId", DbType.Int32, data.ads_appId);
                db.AddInParameter(dbCommand, "ads_reason", DbType.String, data.ads_reason);
                db.AddInParameter(dbCommand, "ads_voucher", DbType.String, data.ads_voucher);
                db.AddInParameter(dbCommand, "ads_group_mem", DbType.String, data.ads_group_mem);
                db.AddInParameter(dbCommand, "ads_type_plan", DbType.String, data.ads_type_plan);
                db.AddInParameter(dbCommand, "ads_reason_other", DbType.String, data.ads_reason_other);
                db.AddInParameter(dbCommand, "ads_condition", DbType.String, data.ads_condition);
                db.AddInParameter(dbCommand, "ads_visit", DbType.String, data.ads_visit);
                db.AddInParameter(dbCommand, "ads_treat_details", DbType.String, data.ads_treat_details);
                db.AddInParameter(dbCommand, "ads_addr1", DbType.String, data.ads_addr1);
                db.AddInParameter(dbCommand, "ads_bill1", DbType.String, data.ads_bill1);
                db.AddInParameter(dbCommand, "ads_tdate1", DbType.String, data.ads_tdate1);
                db.AddInParameter(dbCommand, "ads_desc1", DbType.String, data.ads_desc1);
                db.AddInParameter(dbCommand, "ads_amt1", DbType.String, data.ads_amt1);

                db.AddInParameter(dbCommand, "ads_addr2", DbType.String, data.ads_addr2);
                db.AddInParameter(dbCommand, "ads_bill2", DbType.String, data.ads_bill2);
                db.AddInParameter(dbCommand, "ads_tdate2", DbType.String, data.ads_tdate2);
                db.AddInParameter(dbCommand, "ads_desc2", DbType.String, data.ads_desc2);
                db.AddInParameter(dbCommand, "ads_amt2", DbType.String, data.ads_amt2);

                db.AddInParameter(dbCommand, "ads_addr3", DbType.String, data.ads_addr3);
                db.AddInParameter(dbCommand, "ads_bill3", DbType.String, data.ads_bill3);
                db.AddInParameter(dbCommand, "ads_tdate3", DbType.String, data.ads_tdate3);
                db.AddInParameter(dbCommand, "ads_desc3", DbType.String, data.ads_desc3);
                db.AddInParameter(dbCommand, "ads_amt3", DbType.String, data.ads_amt3);

                db.AddInParameter(dbCommand, "ads_addr4", DbType.String, data.ads_addr4);
                db.AddInParameter(dbCommand, "ads_bill4", DbType.String, data.ads_bill4);
                db.AddInParameter(dbCommand, "ads_tdate4", DbType.String, data.ads_tdate4);
                db.AddInParameter(dbCommand, "ads_desc4", DbType.String, data.ads_desc4);
                db.AddInParameter(dbCommand, "ads_amt4", DbType.String, data.ads_amt4);

                db.AddInParameter(dbCommand, "ads_total", DbType.String, data.ads_total);

                db.AddInParameter(dbCommand, "ads_addr5", DbType.String, data.ads_addr5);
                db.AddInParameter(dbCommand, "ads_bill5", DbType.String, data.ads_bill5);
                db.AddInParameter(dbCommand, "ads_tdate5", DbType.String, data.ads_tdate5);
                db.AddInParameter(dbCommand, "ads_desc5", DbType.String, data.ads_desc5);
                db.AddInParameter(dbCommand, "ads_amt5", DbType.String, data.ads_amt5);
                db.AddInParameter(dbCommand, "ads_oth_above", DbType.String, data.ads_oth_above);
                db.AddInParameter(dbCommand, "ads_oth_claim", DbType.String, data.ads_oth_claim);
                db.AddInParameter(dbCommand, "ads_oth_claim_det", DbType.String, data.ads_oth_claim_det);
                db.AddInParameter(dbCommand, "ads_oth_above_det", DbType.String, data.ads_oth_above_det);
                db.AddInParameter(dbCommand, "ads_onset", DbType.String, data.ads_onset);
                db.AddInParameter(dbCommand, "ads_bank", DbType.String, data.ads_bank);
                db.AddInParameter(dbCommand, "ads_account", DbType.String, data.ads_account);
                db.AddInParameter(dbCommand, "ads_bname", DbType.String, data.ads_bname);
                db.AddInParameter(dbCommand, "ads_baddress", DbType.String, data.ads_baddress);
                db.AddInParameter(dbCommand, "ads_bcurrency", DbType.String, data.ads_bcurrency);
                db.AddInParameter(dbCommand, "ads_bswiftcode", DbType.String, data.ads_bswiftcode);
                db.AddInParameter(dbCommand, "ads_witnessname", DbType.String, data.ads_witnessname);
                db.AddInParameter(dbCommand, "ads_contact", DbType.String, data.ads_contact);
                db.AddInParameter(dbCommand, "ads_madeby", DbType.Int32, data.ads_madeby);
                db.AddInParameter(dbCommand, "ads_modifyby", DbType.Int32, data.ads_madeby);

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

        public static int DeleteAdnic(int adsId, int ads_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADNIC_SHIFA_delete");

                db.AddInParameter(dbCommand, "adsId", DbType.Int32, adsId);
                db.AddInParameter(dbCommand, "ads_modifyby", DbType.String, ads_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Aetna
    {
        public static DataTable GetPrintAetna(int? car_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AETNA_REIMBURSEMENT_Print");
                if (car_Id > 0)
                {
                    db.AddInParameter(dbCommand, "car_Id", DbType.Int32, car_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllAetna(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AETNA_REIMBURSEMENT_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAetna(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AETNA_REIMBURSEMENT_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateAetna(BusinessEntities.EMRForms.Aetna data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AETNA_REIMBURSEMENT_INSERT_UPDATE");
                if (data.car_Id > 0)
                {
                    db.AddInParameter(dbCommand, "car_Id", DbType.Int32, data.car_Id);
                }
                db.AddInParameter(dbCommand, "car_appId", DbType.Int32, data.car_appId);
                db.AddInParameter(dbCommand, "car_checkbox", DbType.String, data.car_checkbox);
                db.AddInParameter(dbCommand, "car_r1", DbType.String, data.car_r1);
                db.AddInParameter(dbCommand, "car_r2", DbType.String, data.car_r2);
                db.AddInParameter(dbCommand, "car_r3", DbType.String, data.car_r3);
                db.AddInParameter(dbCommand, "car_r4", DbType.String, data.car_r4);
                db.AddInParameter(dbCommand, "car_r5", DbType.String, data.car_r5);
                db.AddInParameter(dbCommand, "car_r6", DbType.String, data.car_r6);
                db.AddInParameter(dbCommand, "car_r7", DbType.String, data.car_r7);
                db.AddInParameter(dbCommand, "car_r8", DbType.String, data.car_r8);
                db.AddInParameter(dbCommand, "car_r9", DbType.String, data.car_r9);
                db.AddInParameter(dbCommand, "car_r10", DbType.String, data.car_r10);
                db.AddInParameter(dbCommand, "car_r11", DbType.String, data.car_r11);
                db.AddInParameter(dbCommand, "car_r12", DbType.String, data.car_r12);
                db.AddInParameter(dbCommand, "car_r13", DbType.String, data.car_r13);
                db.AddInParameter(dbCommand, "car_r14", DbType.String, data.car_r14);
                db.AddInParameter(dbCommand, "car_r15", DbType.String, data.car_r15);
                db.AddInParameter(dbCommand, "car_r16", DbType.String, data.car_r16);
                db.AddInParameter(dbCommand, "car_r17", DbType.String, data.car_r17);
                db.AddInParameter(dbCommand, "car_r18", DbType.String, data.car_r18);
                db.AddInParameter(dbCommand, "car_r19", DbType.String, data.car_r19);
                db.AddInParameter(dbCommand, "car_r20", DbType.String, data.car_r20);
                db.AddInParameter(dbCommand, "car_r21", DbType.String, data.car_r21);
                db.AddInParameter(dbCommand, "car_r22", DbType.String, data.car_r22);
                db.AddInParameter(dbCommand, "car_r23", DbType.String, data.car_r23);
                db.AddInParameter(dbCommand, "car_r24", DbType.String, data.car_r24);
                db.AddInParameter(dbCommand, "car_r25", DbType.String, data.car_r25);
                db.AddInParameter(dbCommand, "car_r26", DbType.String, data.car_r26);
                db.AddInParameter(dbCommand, "car_r27", DbType.String, data.car_r27);
                db.AddInParameter(dbCommand, "car_r28", DbType.String, data.car_r28);
                db.AddInParameter(dbCommand, "car_r29", DbType.String, data.car_r29);
                db.AddInParameter(dbCommand, "car_r30", DbType.String, data.car_r30);
                db.AddInParameter(dbCommand, "car_r31", DbType.String, data.car_r31);
                db.AddInParameter(dbCommand, "car_r32", DbType.String, data.car_r32);
                db.AddInParameter(dbCommand, "car_r33", DbType.String, data.car_r33);
                db.AddInParameter(dbCommand, "car_r34", DbType.String, data.car_r34);
                db.AddInParameter(dbCommand, "car_r35", DbType.String, data.car_r35);
                db.AddInParameter(dbCommand, "car_r36", DbType.String, data.car_r36);
                db.AddInParameter(dbCommand, "car_r37", DbType.String, data.car_r37);
                db.AddInParameter(dbCommand, "car_r38", DbType.String, data.car_r38);
                db.AddInParameter(dbCommand, "car_r39", DbType.String, data.car_r39);
                db.AddInParameter(dbCommand, "car_r40", DbType.String, data.car_r40);
                db.AddInParameter(dbCommand, "car_r41", DbType.String, data.car_r41);
                db.AddInParameter(dbCommand, "car_r42", DbType.String, data.car_r42);
                db.AddInParameter(dbCommand, "car_r43", DbType.String, data.car_r43);
                db.AddInParameter(dbCommand, "car_r44", DbType.String, data.car_r44);
                db.AddInParameter(dbCommand, "car_r45", DbType.String, data.car_r45);
                db.AddInParameter(dbCommand, "car_r46", DbType.String, data.car_r46);
                db.AddInParameter(dbCommand, "car_r47", DbType.String, data.car_r47);
                db.AddInParameter(dbCommand, "car_r48", DbType.String, data.car_r48);
                db.AddInParameter(dbCommand, "car_r49", DbType.String, data.car_r49);
                db.AddInParameter(dbCommand, "car_r50", DbType.String, data.car_r50);
                db.AddInParameter(dbCommand, "car_r51", DbType.String, data.car_r51);
                db.AddInParameter(dbCommand, "car_r52", DbType.String, data.car_r52);
                db.AddInParameter(dbCommand, "car_r53", DbType.String, data.car_r53);
                db.AddInParameter(dbCommand, "car_r54", DbType.String, data.car_r54);
                db.AddInParameter(dbCommand, "car_r55", DbType.String, data.car_r55);
                db.AddInParameter(dbCommand, "car_r56", DbType.String, data.car_r56);
                db.AddInParameter(dbCommand, "car_r57", DbType.String, data.car_r57);
                db.AddInParameter(dbCommand, "car_r58", DbType.String, data.car_r58);
                db.AddInParameter(dbCommand, "car_r59", DbType.String, data.car_r59);
                db.AddInParameter(dbCommand, "car_r60", DbType.String, data.car_r60);
                db.AddInParameter(dbCommand, "car_r61", DbType.String, data.car_r61);
                db.AddInParameter(dbCommand, "car_r62", DbType.String, data.car_r62);
                db.AddInParameter(dbCommand, "car_r63", DbType.String, data.car_r63);
                db.AddInParameter(dbCommand, "car_r64", DbType.String, data.car_r64);
                db.AddInParameter(dbCommand, "car_r65", DbType.String, data.car_r65);
                db.AddInParameter(dbCommand, "car_r66", DbType.String, data.car_r66);
                db.AddInParameter(dbCommand, "car_r67", DbType.String, data.car_r67);
                db.AddInParameter(dbCommand, "car_r68", DbType.String, data.car_r68);
                db.AddInParameter(dbCommand, "car_r69", DbType.String, data.car_r69);
                db.AddInParameter(dbCommand, "car_r70", DbType.String, data.car_r70);
                db.AddInParameter(dbCommand, "car_r71", DbType.String, data.car_r71);
                db.AddInParameter(dbCommand, "car_r72", DbType.String, data.car_r72);
                db.AddInParameter(dbCommand, "car_r73", DbType.String, data.car_r73);
                db.AddInParameter(dbCommand, "car_r74", DbType.String, data.car_r74);
                db.AddInParameter(dbCommand, "car_r75", DbType.String, data.car_r75);
                db.AddInParameter(dbCommand, "car_d1", DbType.DateTime, data.car_d1);
                db.AddInParameter(dbCommand, "car_d2", DbType.DateTime, data.car_d2);
                db.AddInParameter(dbCommand, "car_d3", DbType.DateTime, data.car_d3);
                db.AddInParameter(dbCommand, "car_d4", DbType.DateTime, data.car_d4);
                db.AddInParameter(dbCommand, "car_d5", DbType.DateTime, data.car_d5);
                db.AddInParameter(dbCommand, "car_d6", DbType.DateTime, data.car_d6);
                db.AddInParameter(dbCommand, "car_d7", DbType.DateTime, data.car_d7);
                db.AddInParameter(dbCommand, "car_d8", DbType.DateTime, data.car_d8);

                db.AddInParameter(dbCommand, "car_madeby", DbType.Int32, data.car_madeby);
                db.AddInParameter(dbCommand, "car_modifyby", DbType.Int32, data.car_madeby);

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

        public static int DeleteAetna(int car_Id, int car_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AETNA_REIMBURSEMENT_delete");

                db.AddInParameter(dbCommand, "car_Id", DbType.Int32, car_Id);
                db.AddInParameter(dbCommand, "car_modifyby", DbType.String, car_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Amity
    {
        public static DataTable GetPrintAmity(int? car_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AMITY_REIMB_Print");
                if (car_Id > 0)
                {
                    db.AddInParameter(dbCommand, "car_Id", DbType.Int32, car_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllAmity(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AMITY_REIMB_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAmity(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AMITY_REIMB_PREVIOUS_History");
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
        public static bool InsertUpdateAmity(BusinessEntities.EMRForms.Amity data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AMITY_REIMB_INSERT_UPDATE");
                if (data.car_Id > 0)
                {
                    db.AddInParameter(dbCommand, "car_Id", DbType.Int32, data.car_Id);
                }
                db.AddInParameter(dbCommand, "car_appId", DbType.Int32, data.car_appId);
                db.AddInParameter(dbCommand, "car_checkbox", DbType.String, data.car_checkbox);
                db.AddInParameter(dbCommand, "car_e1", DbType.String, data.car_e1);
                db.AddInParameter(dbCommand, "car_e2", DbType.String, data.car_e2);
                db.AddInParameter(dbCommand, "car_e3", DbType.String, data.car_e3);
                db.AddInParameter(dbCommand, "car_e4", DbType.String, data.car_e4);
                db.AddInParameter(dbCommand, "car_e5", DbType.String, data.car_e5);
                db.AddInParameter(dbCommand, "car_e6", DbType.String, data.car_e6);
                db.AddInParameter(dbCommand, "car_e7", DbType.String, data.car_e7);
                db.AddInParameter(dbCommand, "car_e8", DbType.String, data.car_e8);
                db.AddInParameter(dbCommand, "car_e9", DbType.String, data.car_e9);
                db.AddInParameter(dbCommand, "car_e10", DbType.String, data.car_e10);
                db.AddInParameter(dbCommand, "car_e11", DbType.String, data.car_e11);
                db.AddInParameter(dbCommand, "car_e12", DbType.String, data.car_e12);
                db.AddInParameter(dbCommand, "car_e13", DbType.String, data.car_e13);
                db.AddInParameter(dbCommand, "car_d1", DbType.DateTime, data.car_d1);
                db.AddInParameter(dbCommand, "car_d2", DbType.DateTime, data.car_d2);

                db.AddInParameter(dbCommand, "car_madeby", DbType.Int32, data.car_madeby);
                db.AddInParameter(dbCommand, "car_modifyby", DbType.Int32, data.car_madeby);

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

        public static int DeleteAmity(int car_Id, int car_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AMITY_REIMB_delete");

                db.AddInParameter(dbCommand, "car_Id", DbType.Int32, car_Id);
                db.AddInParameter(dbCommand, "car_modifyby", DbType.String, car_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Alico
    {
        public static DataTable GetPrintAlico(int? aliId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALICO_Print");
                if (aliId > 0)
                {
                    db.AddInParameter(dbCommand, "aliId", DbType.Int32, aliId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllAlico(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALICO_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAlico(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALICO_PREVIOUS_History");
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

        public static bool InsertUpdateAlico(BusinessEntities.EMRForms.Alico data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALICO_INSERT_UPDATE");
                if (data.aliId > 0)
                {
                    db.AddInParameter(dbCommand, "aliId", DbType.Int32, data.aliId);
                }
                db.AddInParameter(dbCommand, "ali_appId", DbType.Int32, data.ali_appId);
                db.AddInParameter(dbCommand, "ali_checkbox", DbType.String, data.ali_checkbox);
                db.AddInParameter(dbCommand, "ali_ins1", DbType.String, data.ali_ins1);
                db.AddInParameter(dbCommand, "ali_ins2", DbType.String, data.ali_ins2);
                db.AddInParameter(dbCommand, "ali_ins3", DbType.String, data.ali_ins3);
                db.AddInParameter(dbCommand, "ali_ins4", DbType.String, data.ali_ins4);
                db.AddInParameter(dbCommand, "ali_ins5", DbType.String, data.ali_ins5);
                db.AddInParameter(dbCommand, "ali_ins6", DbType.String, data.ali_ins6);
                db.AddInParameter(dbCommand, "ali_ins7", DbType.String, data.ali_ins7);
                db.AddInParameter(dbCommand, "ali_ins8", DbType.String, data.ali_ins8);
                db.AddInParameter(dbCommand, "ali_ins9", DbType.String, data.ali_ins9);
                db.AddInParameter(dbCommand, "ali_ins10", DbType.String, data.ali_ins10);
                db.AddInParameter(dbCommand, "ali_ins11", DbType.String, data.ali_ins11);
                db.AddInParameter(dbCommand, "ali_ins12", DbType.String, data.ali_ins12);
                db.AddInParameter(dbCommand, "ali_ins13", DbType.String, data.ali_ins13);
                db.AddInParameter(dbCommand, "ali_ins14", DbType.String, data.ali_ins14);

                db.AddInParameter(dbCommand, "ali_madeby", DbType.Int32, data.ali_madeby);
                db.AddInParameter(dbCommand, "ali_modifyby", DbType.Int32, data.ali_madeby);

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

        public static int DeleteAlico(int aliId, int ali_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALICO_delete");

                db.AddInParameter(dbCommand, "aliId", DbType.Int32, aliId);
                db.AddInParameter(dbCommand, "ali_modifyby", DbType.String, ali_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Allianz
    {
        public static DataTable GetPrintAllianz(int? allId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLIANZ_CLAIM_FORM_Print");
                if (allId > 0)
                {
                    db.AddInParameter(dbCommand, "allId", DbType.Int32, allId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllAllianz(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLIANZ_CLAIM_FORM_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAllianz(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLIANZ_CLAIM_FORM_PREVIOUS_History");
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

        public static bool InsertUpdateAllianz(BusinessEntities.EMRForms.Allianz data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLIANZ_CLAIM_FORM_INSERT_UPDATE");
                if (data.allId > 0)
                {
                    db.AddInParameter(dbCommand, "allId", DbType.Int32, data.allId);
                }
                db.AddInParameter(dbCommand, "all_appId", DbType.Int32, data.all_appId);
                db.AddInParameter(dbCommand, "all_1", DbType.String, data.all_1);
                db.AddInParameter(dbCommand, "all_2", DbType.String, data.all_2);
                db.AddInParameter(dbCommand, "all_3", DbType.String, data.all_3);
                db.AddInParameter(dbCommand, "all_4", DbType.String, data.all_4);
                db.AddInParameter(dbCommand, "all_5", DbType.String, data.all_5);
                db.AddInParameter(dbCommand, "all_6", DbType.String, data.all_6);
                db.AddInParameter(dbCommand, "all_7", DbType.String, data.all_7);
                db.AddInParameter(dbCommand, "all_8", DbType.String, data.all_8);
                db.AddInParameter(dbCommand, "all_9", DbType.String, data.all_9);
                db.AddInParameter(dbCommand, "all_10", DbType.String, data.all_10);
                db.AddInParameter(dbCommand, "all_11", DbType.String, data.all_11);
                db.AddInParameter(dbCommand, "all_12", DbType.String, data.all_12);
                db.AddInParameter(dbCommand, "all_13", DbType.DateTime, data.all_13);
                db.AddInParameter(dbCommand, "all_14", DbType.DateTime, data.all_14);
                db.AddInParameter(dbCommand, "all_15", DbType.DateTime, data.all_15);

                db.AddInParameter(dbCommand, "all_madeby", DbType.Int32, data.all_madeby);
                db.AddInParameter(dbCommand, "all_modifyby", DbType.Int32, data.all_madeby);

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

        public static int DeleteAllianz(int allId, int all_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLIANZ_CLAIM_FORM_delete");

                db.AddInParameter(dbCommand, "allId", DbType.Int32, allId);
                db.AddInParameter(dbCommand, "all_modifyby", DbType.String, all_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Axa
    {
        public static DataTable GetPrintAxa(int? carfId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AXA_REIMBURSEMENT_FORM_Print");
                if (carfId > 0)
                {
                    db.AddInParameter(dbCommand, "carfId", DbType.Int32, carfId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllAxa(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AXA_REIMBURSEMENT_FORM_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAxa(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AXA_REIMBURSEMENT_FORM_PREVIOUS_History");
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
        public static DataTable GetAllPatientDiagnosis(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_All_Patient_Diagnosis");
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
         public static DataTable GetAllPatientDrugs(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Prescriptions");
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

        public static bool InsertUpdateAxa(BusinessEntities.EMRForms.Axa data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AXA_REIMBURSEMENT_FORM_INSERT_UPDATE");
                if (data.carfId > 0)
                {
                    db.AddInParameter(dbCommand, "carfId", DbType.Int32, data.carfId);
                }
                db.AddInParameter(dbCommand, "carf_appId", DbType.Int32, data.carf_appId);
                db.AddInParameter(dbCommand, "carf_1", DbType.String, data.carf_1);
                db.AddInParameter(dbCommand, "carf_2", DbType.String, data.carf_2);
                db.AddInParameter(dbCommand, "carf_3", DbType.String, data.carf_3);
                db.AddInParameter(dbCommand, "carf_4", DbType.String, data.carf_4);
                db.AddInParameter(dbCommand, "carf_5", DbType.String, data.carf_5);
                db.AddInParameter(dbCommand, "carf_6", DbType.String, data.carf_6);
                db.AddInParameter(dbCommand, "carf_7", DbType.String, data.carf_7);
                db.AddInParameter(dbCommand, "carf_8", DbType.String, data.carf_8);
                db.AddInParameter(dbCommand, "carf_9", DbType.String, data.carf_9);
                db.AddInParameter(dbCommand, "carf_10", DbType.String, data.carf_10);
                db.AddInParameter(dbCommand, "carf_11", DbType.String, data.carf_11);
                db.AddInParameter(dbCommand, "carf_12", DbType.String, data.carf_12);
                db.AddInParameter(dbCommand, "carf_13", DbType.String, data.carf_13);
                db.AddInParameter(dbCommand, "carf_14", DbType.String, data.carf_14);
                db.AddInParameter(dbCommand, "carf_15", DbType.String, data.carf_15);
                db.AddInParameter(dbCommand, "carf_16", DbType.String, data.carf_16);
                db.AddInParameter(dbCommand, "carf_17", DbType.String, data.carf_17);
                db.AddInParameter(dbCommand, "carf_18", DbType.String, data.carf_18);
                db.AddInParameter(dbCommand, "carf_19", DbType.String, data.carf_19);
                db.AddInParameter(dbCommand, "carf_20", DbType.String, data.carf_20);
                db.AddInParameter(dbCommand, "carf_21", DbType.DateTime, data.carf_21);
                db.AddInParameter(dbCommand, "carf_22", DbType.DateTime, data.carf_22);
                db.AddInParameter(dbCommand, "carf_23", DbType.DateTime, data.carf_23);
                db.AddInParameter(dbCommand, "carf_24", DbType.DateTime, data.carf_24);
                db.AddInParameter(dbCommand, "carf_25", DbType.DateTime, data.carf_25);
                db.AddInParameter(dbCommand, "carf_26", DbType.DateTime, data.carf_26);
                db.AddInParameter(dbCommand, "carf_madeby", DbType.Int32, data.carf_madeby);
                db.AddInParameter(dbCommand, "carf_modifyby", DbType.Int32, data.carf_madeby);

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

        public static int DeleteAxa(int carfId, int carf_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AXA_REIMBURSEMENT_FORM_delete");

                db.AddInParameter(dbCommand, "carfId", DbType.Int32, carfId);
                db.AddInParameter(dbCommand, "carf_modifyby", DbType.String, carf_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class MSH
    {
        public static DataTable GetPrintMSH(int? cmr_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MSH_REIMB_CLAIM_Print");
                if (cmr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cmr_Id", DbType.Int32, cmr_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllMSH(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MSH_REIMB_CLAIM_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreMSH(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MSH_REIMB_CLAIM_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateMSH(BusinessEntities.EMRForms.MSH data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MSH_REIMB_CLAIM_INSERT_UPDATE");
                if (data.cmr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cmr_Id", DbType.Int32, data.cmr_Id);
                }
                db.AddInParameter(dbCommand, "cmr_appId", DbType.Int32, data.cmr_appId);
                db.AddInParameter(dbCommand, "cmr_checkbox", DbType.String, data.cmr_checkbox);	
                db.AddInParameter(dbCommand, "cmr_groupname", DbType.String, data.cmr_groupname);
                db.AddInParameter(dbCommand, "cmr_health", DbType.String, data.cmr_health);
                db.AddInParameter(dbCommand, "cmr_dental", DbType.String, data.cmr_dental);
                db.AddInParameter(dbCommand, "cmr_amount", DbType.String, data.cmr_amount);
                db.AddInParameter(dbCommand, "cmr_total", DbType.String, data.cmr_total);
                db.AddInParameter(dbCommand, "cmr_madeby", DbType.Int32, data.cmr_madeby);
                db.AddInParameter(dbCommand, "cmr_modifyby", DbType.Int32, data.cmr_madeby);

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

        public static int DeleteMSH(int cmr_Id, int cmr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MSH_REIMB_CLAIM_delete");

                db.AddInParameter(dbCommand, "cmr_Id", DbType.Int32, cmr_Id);
                db.AddInParameter(dbCommand, "cmr_modifyby", DbType.String, cmr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Dubaicare
    {
        public static DataTable GetPrintDubaicare(int? cdr_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DUBAICARE_REIMB_Print");
                if (cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllDubaicare(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DUBAICARE_REIMB_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreDubaicare(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DUBAICARE_REIMB_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateDubaicare(BusinessEntities.EMRForms.Dubaicare data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DUBAICARE_REIMB_INSERT_UPDATE");
                if (data.cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, data.cdr_Id);
                }
                db.AddInParameter(dbCommand, "cdr_appId", DbType.Int32, data.cdr_appId);
                db.AddInParameter(dbCommand, "cdr_name", DbType.String, data.cdr_name);
                db.AddInParameter(dbCommand, "cdr_address", DbType.String, data.cdr_address);
                db.AddInParameter(dbCommand, "cdr_account", DbType.String, data.cdr_account);
                db.AddInParameter(dbCommand, "cdr_iban", DbType.String, data.cdr_iban);
                db.AddInParameter(dbCommand, "cdr_scode", DbType.String, data.cdr_scode);
                db.AddInParameter(dbCommand, "cdr_bank", DbType.String, data.cdr_bank);
                db.AddInParameter(dbCommand, "cdr_branch", DbType.String, data.cdr_branch);
                db.AddInParameter(dbCommand, "cdr_phy_find", DbType.String, data.cdr_phy_find);
                db.AddInParameter(dbCommand, "cdr_invest", DbType.String, data.cdr_invest);
                db.AddInParameter(dbCommand, "cdr_madeby", DbType.Int32, data.cdr_madeby);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.Int32, data.cdr_madeby);

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

        public static int DeleteDubaicare(int cdr_Id, int cdr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DUBAICARE_REIMB_delete");

                db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.String, cdr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Emirates
    {
        public static DataTable GetPrintEmirates(int? cer_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_REIMB_Print");
                if (cer_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cer_Id", DbType.Int32, cer_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllEmirates(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_REIMB_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreEmirates(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_REIMB_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateEmirates(BusinessEntities.EMRForms.Emirates data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_REIMB_INSERT_UPDATE");
                if (data.cer_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cer_Id", DbType.Int32, data.cer_Id);
                }
                db.AddInParameter(dbCommand, "cer_appId", DbType.Int32, data.cer_appId);
                db.AddInParameter(dbCommand, "cer_checkbox", DbType.String, data.cer_checkbox);
                db.AddInParameter(dbCommand, "cer_processor", DbType.String, data.cer_processor);
                db.AddInParameter(dbCommand, "cer_payable", DbType.String, data.cer_payable);
                db.AddInParameter(dbCommand, "cer_nonpayable", DbType.String, data.cer_nonpayable);
                db.AddInParameter(dbCommand, "cer_madeby", DbType.Int32, data.cer_madeby);
                db.AddInParameter(dbCommand, "cer_modifyby", DbType.Int32, data.cer_madeby);

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

        public static int DeleteEmirates(int cer_Id, int cer_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_REIMB_delete");

                db.AddInParameter(dbCommand, "cer_Id", DbType.Int32, cer_Id);
                db.AddInParameter(dbCommand, "cer_modifyby", DbType.String, cer_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class FMC
    {
        public static DataTable GetPrintFMC(int? fcId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FMC_CLAIM_Print");
                if (fcId > 0)
                {
                    db.AddInParameter(dbCommand, "fcId", DbType.Int32, fcId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllFMC(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FMC_CLAIM_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreFMC(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FMC_CLAIM_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateFMC(BusinessEntities.EMRForms.FMC data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FMC_CLAIM_INSERT_UPDATE");
                if (data.fcId > 0)
                {
                    db.AddInParameter(dbCommand, "fcId", DbType.Int32, data.fcId);
                }
                db.AddInParameter(dbCommand, "fc_appId", DbType.Int32, data.fc_appId);
                db.AddInParameter(dbCommand, "fc_symptoms_date", DbType.DateTime, data.fc_symptoms_date);
                db.AddInParameter(dbCommand, "fc_visit", DbType.String, data.fc_visit);
                db.AddInParameter(dbCommand, "fc_diag", DbType.String, data.fc_diag);
                db.AddInParameter(dbCommand, "fc_madeby", DbType.Int32, data.fc_madeby);
                db.AddInParameter(dbCommand, "fc_modifyby", DbType.Int32, data.fc_madeby);

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

        public static int DeleteFMC(int fcId, int fc_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_FMC_CLAIM_delete");

                db.AddInParameter(dbCommand, "fcId", DbType.Int32, fcId);
                db.AddInParameter(dbCommand, "fc_modifyby", DbType.String, fc_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Neuron
    {
        public static DataTable GetPrintNeuron(int? nrId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEURON_REIMB_Print");
                if (nrId > 0)
                {
                    db.AddInParameter(dbCommand, "nrId", DbType.Int32, nrId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNeuron(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEURON_REIMB_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNeuron(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEURON_REIMB_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateNeuron(BusinessEntities.EMRForms.Neuron data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEURON_REIMB_INSERT_UPDATE");
                if (data.nrId > 0)
                {
                    db.AddInParameter(dbCommand, "nrId", DbType.Int32, data.nrId);
                }
                db.AddInParameter(dbCommand, "nr_appId", DbType.Int32, data.nr_appId);
                db.AddInParameter(dbCommand, "nr_his", DbType.String, data.nr_his);
                db.AddInParameter(dbCommand, "nr_date1", DbType.DateTime, data.nr_date1);
                db.AddInParameter(dbCommand, "nr_date2", DbType.DateTime, data.nr_date2);
                db.AddInParameter(dbCommand, "nr_1", DbType.String, data.nr_1);
                db.AddInParameter(dbCommand, "nr_2", DbType.String, data.nr_2);
                db.AddInParameter(dbCommand, "nr_madeby", DbType.Int32, data.nr_madeby);
                db.AddInParameter(dbCommand, "nr_modifyby", DbType.Int32, data.nr_madeby);

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

        public static int DeleteNeuron(int nrId, int nr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEURON_REIMB_delete");

                db.AddInParameter(dbCommand, "nrId", DbType.Int32, nrId);
                db.AddInParameter(dbCommand, "nr_modifyby", DbType.String, nr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Starwell
    {
        public static DataTable GetPrintStarwell(int? swId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STARWELL_Print");
                if (swId > 0)
                {
                    db.AddInParameter(dbCommand, "swId", DbType.Int32, swId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllStarwell(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STARWELL_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreStarwell(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STARWELL_PREVIOUS_History");
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

        public static bool InsertUpdateStarwell(BusinessEntities.EMRForms.Starwell data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STARWELL_INSERT_UPDATE");
                if (data.swId > 0)
                {
                    db.AddInParameter(dbCommand, "swId", DbType.Int32, data.swId);
                }
                db.AddInParameter(dbCommand, "sw_appId", DbType.Int32, data.sw_appId);
                db.AddInParameter(dbCommand, "sw_type", DbType.String, data.sw_type);
                db.AddInParameter(dbCommand, "sw_pappr", DbType.String, data.sw_pappr);
                db.AddInParameter(dbCommand, "sw_pamount", DbType.Decimal, data.sw_pamount);
                db.AddInParameter(dbCommand, "sw_comments", DbType.String, data.sw_comments);
                db.AddInParameter(dbCommand, "sw_pdate", DbType.DateTime, data.sw_pdate);
                db.AddInParameter(dbCommand, "sw_madeby", DbType.Int32, data.sw_madeby);
                db.AddInParameter(dbCommand, "sw_modifyby", DbType.Int32, data.sw_madeby);

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

        public static int DeleteStarwell(int swId, int sw_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STARWELL_delete");

                db.AddInParameter(dbCommand, "swId", DbType.Int32, swId);
                db.AddInParameter(dbCommand, "sw_modifyby", DbType.String, sw_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class NGI
    {
        public static DataTable GetPrintNGI(int? ngId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NGI_Print");
                if (ngId > 0)
                {
                    db.AddInParameter(dbCommand, "ngId", DbType.Int32, ngId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNGI(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NGI_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
         public static DataTable GetEmrInfo(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMR_INFO");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreNGI(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NGI_PREVIOUS_History");
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

        public static bool InsertUpdateNGI(BusinessEntities.EMRForms.NGI data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NGI_INSERT_UPDATE");
                if (data.ngId > 0)
                {
                    db.AddInParameter(dbCommand, "ngId", DbType.Int32, data.ngId);
                }
                db.AddInParameter(dbCommand, "ng_appId", DbType.Int32, data.ng_appId);
                db.AddInParameter(dbCommand, "ng_1", DbType.String, data.ng_1);
                db.AddInParameter(dbCommand, "ng_2", DbType.String, data.ng_2);
                db.AddInParameter(dbCommand, "ng_3", DbType.DateTime, data.ng_3);
                db.AddInParameter(dbCommand, "ng_5", DbType.String, data.ng_5);
                db.AddInParameter(dbCommand, "ng_on", DbType.String, data.ng_on);
                db.AddInParameter(dbCommand, "ng_eti", DbType.String, data.ng_eti);
                db.AddInParameter(dbCommand, "ng_no", DbType.Int32, data.ng_no);
                db.AddInParameter(dbCommand, "ng_comments", DbType.String, data.ng_comments);
                db.AddInParameter(dbCommand, "ng_4", DbType.DateTime, data.ng_4);
                db.AddInParameter(dbCommand, "ng_madeby", DbType.Int32, data.ng_madeby);
                db.AddInParameter(dbCommand, "ng_modifyby", DbType.Int32, data.ng_madeby);

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

        public static int DeleteNGI(int ngId, int ng_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NGI_delete");

                db.AddInParameter(dbCommand, "ngId", DbType.Int32, ngId);
                db.AddInParameter(dbCommand, "ng_modifyby", DbType.String, ng_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Inayah
    {
        public static DataTable GetPrintInayah(int? cir_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INAYAH_REIMB_CLAIM_Print");
                if (cir_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cir_Id", DbType.Int32, cir_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllInayah(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INAYAH_REIMB_CLAIM_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreInayah(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INAYAH_REIMB_CLAIM_PREVIOUS_History");
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
        public static DataTable GetAllPatientDiagnosis(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_All_Patient_Diagnosis");
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
        public static DataTable GetAllPatientDrugs(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Prescriptions");
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

        public static bool InsertUpdateInayah(BusinessEntities.EMRForms.Inayah data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INAYAH_REIMB_CLAIM_INSERT_UPDATE");
                if (data.cir_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cir_Id", DbType.Int32, data.cir_Id);
                }
                db.AddInParameter(dbCommand, "cir_appId", DbType.Int32, data.cir_appId);
                db.AddInParameter(dbCommand, "cir_checkbox", DbType.String, data.cir_checkbox);
                db.AddInParameter(dbCommand, "cir_details", DbType.String, data.cir_details);
                db.AddInParameter(dbCommand, "cir_claim", DbType.String, data.cir_claim);
                db.AddInParameter(dbCommand, "cir_total", DbType.String, data.cir_total);
                db.AddInParameter(dbCommand, "cir_medicines", DbType.String, data.cir_medicines);
                db.AddInParameter(dbCommand, "cir_expenses", DbType.String, data.cir_expenses);
                db.AddInParameter(dbCommand, "cir_grand", DbType.String, data.cir_grand);
                db.AddInParameter(dbCommand, "cir_d1", DbType.DateTime, data.cir_d1);
                db.AddInParameter(dbCommand, "cir_madeby", DbType.Int32, data.cir_madeby);
                db.AddInParameter(dbCommand, "cir_modifyby", DbType.Int32, data.cir_madeby);

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

        public static int DeleteInayah(int cir_Id, int cir_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INAYAH_REIMB_CLAIM_delete");

                db.AddInParameter(dbCommand, "cir_Id", DbType.Int32, cir_Id);
                db.AddInParameter(dbCommand, "cir_modifyby", DbType.String, cir_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Healthnet
    {
        public static DataTable GetPrintHealthnet(int? chr_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTHNET_REIMB_CLAIM_Print");
                if (chr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "chr_Id", DbType.Int32, chr_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllHealthnet(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTHNET_REIMB_CLAIM_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        public static DataTable GetAllPreHealthnet(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTHNET_REIMB_CLAIM_PREVIOUS_History");
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

        public static bool InsertUpdateHealthnet(BusinessEntities.EMRForms.Healthnet data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTHNET_REIMB_CLAIM_INSERT_UPDATE");
                if (data.chr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "chr_Id", DbType.Int32, data.chr_Id);
                }
                db.AddInParameter(dbCommand, "chr_appId", DbType.Int32, data.chr_appId);
                db.AddInParameter(dbCommand, "chr_1", DbType.String, data.chr_1);
                db.AddInParameter(dbCommand, "chr_2", DbType.String, data.chr_2);
                db.AddInParameter(dbCommand, "chr_checkbox", DbType.String, data.chr_checkbox);
                db.AddInParameter(dbCommand, "chr_amount", DbType.String, data.chr_amount);
                db.AddInParameter(dbCommand, "chr_symptom", DbType.String, data.chr_symptom);
                db.AddInParameter(dbCommand, "chr_condition", DbType.String, data.chr_condition);
                db.AddInParameter(dbCommand, "chr_history", DbType.String, data.chr_history);
                db.AddInParameter(dbCommand, "chr_etiology", DbType.String, data.chr_etiology);
                db.AddInParameter(dbCommand, "chr_lab", DbType.String, data.chr_lab);
                db.AddInParameter(dbCommand, "chr_radiology", DbType.String, data.chr_radiology);
                db.AddInParameter(dbCommand, "chr_remarks", DbType.String, data.chr_remarks);
                db.AddInParameter(dbCommand, "chr_d1", DbType.DateTime, data.chr_d1);
                db.AddInParameter(dbCommand, "chr_d2", DbType.DateTime, data.chr_d2);
                db.AddInParameter(dbCommand, "chr_madeby", DbType.Int32, data.chr_madeby);
                db.AddInParameter(dbCommand, "chr_modifyby", DbType.Int32, data.chr_madeby);

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

        public static int DeleteHealthnet(int chr_Id, int chr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTHNET_REIMB_CLAIM_delete");

                db.AddInParameter(dbCommand, "chr_Id", DbType.Int32, chr_Id);
                db.AddInParameter(dbCommand, "chr_modifyby", DbType.String, chr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Daman
    {
        public static DataTable GetPrintDaman(int? cdr_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ENG_Print");
                if (cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllDaman(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ENG_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreDaman(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ENG_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateDaman(BusinessEntities.EMRForms.Daman data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ENG_INSERT_UPDATE");
                if (data.cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, data.cdr_Id);
                }
                db.AddInParameter(dbCommand, "cdr_appId", DbType.Int32, data.cdr_appId);
                db.AddInParameter(dbCommand, "cdr_checkbox", DbType.String, data.cdr_checkbox);
                db.AddInParameter(dbCommand, "cdr_e1", DbType.String, data.cdr_e1);
                db.AddInParameter(dbCommand, "cdr_e2", DbType.String, data.cdr_e2);
                db.AddInParameter(dbCommand, "cdr_e3", DbType.String, data.cdr_e3);
                db.AddInParameter(dbCommand, "cdr_e4", DbType.String, data.cdr_e4);
                db.AddInParameter(dbCommand, "cdr_e5", DbType.String, data.cdr_e5);
                db.AddInParameter(dbCommand, "cdr_e6", DbType.String, data.cdr_e6);
                db.AddInParameter(dbCommand, "cdr_e7", DbType.String, data.cdr_e7);
                db.AddInParameter(dbCommand, "cdr_e8", DbType.String, data.cdr_e8);
                db.AddInParameter(dbCommand, "cdr_e9", DbType.String, data.cdr_e9);
                db.AddInParameter(dbCommand, "cdr_e10", DbType.String, data.cdr_e10);
                db.AddInParameter(dbCommand, "cdr_e11", DbType.String, data.cdr_e11);
                db.AddInParameter(dbCommand, "cdr_e12", DbType.String, data.cdr_e12);
                db.AddInParameter(dbCommand, "cdr_e13", DbType.String, data.cdr_e13);
                db.AddInParameter(dbCommand, "cdr_d1", DbType.DateTime, data.cdr_d1);

                db.AddInParameter(dbCommand, "cdr_madeby", DbType.Int32, data.cdr_madeby);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.Int32, data.cdr_madeby);

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

        public static int DeleteDaman(int cdr_Id, int cdr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ENG_delete");

                db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.String, cdr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class DamanArabic
    {
        public static DataTable GetPrintDamanArabic(int? cdr_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ARB_Print");
                if (cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllDamanArabic(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ARB_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreDamanArabic(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ARB_PREVIOUS_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateDamanArabic(BusinessEntities.EMRForms.DamanArabic data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ARB_INSERT_UPDATE");
                if (data.cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, data.cdr_Id);
                }
                db.AddInParameter(dbCommand, "cdr_appId", DbType.Int32, data.cdr_appId);
                db.AddInParameter(dbCommand, "cdr_checkbox", DbType.String, data.cdr_checkbox);
                db.AddInParameter(dbCommand, "cdr_e1", DbType.String, data.cdr_e1);
                db.AddInParameter(dbCommand, "cdr_e2", DbType.String, data.cdr_e2);
                db.AddInParameter(dbCommand, "cdr_e3", DbType.String, data.cdr_e3);
                db.AddInParameter(dbCommand, "cdr_e4", DbType.String, data.cdr_e4);
                db.AddInParameter(dbCommand, "cdr_e5", DbType.String, data.cdr_e5);
                db.AddInParameter(dbCommand, "cdr_e6", DbType.String, data.cdr_e6);
                db.AddInParameter(dbCommand, "cdr_e7", DbType.String, data.cdr_e7);
                db.AddInParameter(dbCommand, "cdr_e8", DbType.String, data.cdr_e8);
                db.AddInParameter(dbCommand, "cdr_e9", DbType.String, data.cdr_e9);
                db.AddInParameter(dbCommand, "cdr_e10", DbType.String, data.cdr_e10);
                db.AddInParameter(dbCommand, "cdr_e11", DbType.String, data.cdr_e11);
                db.AddInParameter(dbCommand, "cdr_e12", DbType.String, data.cdr_e12);
                db.AddInParameter(dbCommand, "cdr_e13", DbType.String, data.cdr_e13);
                db.AddInParameter(dbCommand, "cdr_d1", DbType.DateTime, data.cdr_d1);

                db.AddInParameter(dbCommand, "cdr_madeby", DbType.Int32, data.cdr_madeby);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.Int32, data.cdr_madeby);

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

        public static int DeleteDamanArabic(int cdr_Id, int cdr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_ARB_delete");

                db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.String, cdr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class DamanWT
    {
        public static DataTable GetPrintDamanWT(int? cdr_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_WT_Print");
                if (cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllDamanWT(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_WT_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreDamanWT(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_WT_PREVIOUS_History");
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
        public static DataTable getDataDaman(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_TREATMENTS_INVOICES_History");
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
        public static DataTable Get_Patient_Diagnosis(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_App_Diagnosis");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable Get_Patient_Lab_Treatment(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Lab_Treatments");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool InsertUpdateDamanWT(BusinessEntities.EMRForms.DamanWT data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_WT_INSERT_UPDATE");
                if (data.cdr_Id > 0)
                {
                    db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, data.cdr_Id);
                }
                db.AddInParameter(dbCommand, "cdr_appId", DbType.Int32, data.cdr_appId);
                db.AddInParameter(dbCommand, "cdr_checkbox", DbType.String, data.cdr_checkbox);
                db.AddInParameter(dbCommand, "cdr_e1", DbType.String, data.cdr_e1);
                db.AddInParameter(dbCommand, "cdr_e2", DbType.String, data.cdr_e2);
                db.AddInParameter(dbCommand, "cdr_e3", DbType.String, data.cdr_e3);
                db.AddInParameter(dbCommand, "cdr_e4", DbType.String, data.cdr_e4);
                db.AddInParameter(dbCommand, "cdr_e5", DbType.String, data.cdr_e5);
                db.AddInParameter(dbCommand, "cdr_e6", DbType.String, data.cdr_e6);
                db.AddInParameter(dbCommand, "cdr_e7", DbType.String, data.cdr_e7);
                db.AddInParameter(dbCommand, "cdr_e8", DbType.String, data.cdr_e8);
                db.AddInParameter(dbCommand, "cdr_e9", DbType.String, data.cdr_e9);
                db.AddInParameter(dbCommand, "cdr_e10", DbType.String, data.cdr_e10);
                db.AddInParameter(dbCommand, "cdr_e11", DbType.String, data.cdr_e11);
                db.AddInParameter(dbCommand, "cdr_e12", DbType.String, data.cdr_e12);
                db.AddInParameter(dbCommand, "cdr_d1", DbType.DateTime, data.cdr_d1);

                db.AddInParameter(dbCommand, "cdr_madeby", DbType.Int32, data.cdr_madeby);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.Int32, data.cdr_madeby);

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
        public static int DeleteDamanWT(int cdr_Id, int cdr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DAMAN_REIMB_WT_delete");

                db.AddInParameter(dbCommand, "cdr_Id", DbType.Int32, cdr_Id);
                db.AddInParameter(dbCommand, "cdr_modifyby", DbType.String, cdr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class NAS
    {
        public static DataTable GetPrintNAS(int? nasnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_NEW_Print");
                if (nasnId > 0)
                {
                    db.AddInParameter(dbCommand, "nasnId", DbType.Int32, nasnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNAS(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNAS(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNAS(BusinessEntities.EMRForms.NAS data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_NEW_INSERT_UPDATE");
                if (data.nasnId > 0)
                {
                    db.AddInParameter(dbCommand, "nasnId", DbType.Int32, data.nasnId);
                }
                db.AddInParameter(dbCommand, "nasn_appId", DbType.Int32, data.nasn_appId);
                db.AddInParameter(dbCommand, "nasn_1", DbType.String, data.nasn_1);
                db.AddInParameter(dbCommand, "nasn_2", DbType.String, data.nasn_2);
                db.AddInParameter(dbCommand, "nasn_3", DbType.String, data.nasn_3);
                db.AddInParameter(dbCommand, "nasn_4", DbType.String, data.nasn_4);
                db.AddInParameter(dbCommand, "nasn_5", DbType.String, data.nasn_5);
                db.AddInParameter(dbCommand, "nasn_6", DbType.String, data.nasn_6);
                db.AddInParameter(dbCommand, "nasn_7", DbType.String, data.nasn_7);
                db.AddInParameter(dbCommand, "nasn_8", DbType.String, data.nasn_8);
                db.AddInParameter(dbCommand, "nasn_9", DbType.String, data.nasn_9);
                db.AddInParameter(dbCommand, "nasn_10", DbType.String, data.nasn_10);
                db.AddInParameter(dbCommand, "nasn_11", DbType.String, data.nasn_11);
                db.AddInParameter(dbCommand, "nasn_12", DbType.String, data.nasn_12);
                db.AddInParameter(dbCommand, "nasn_13", DbType.String, data.nasn_13);
                db.AddInParameter(dbCommand, "nasn_14", DbType.String, data.nasn_14);
                db.AddInParameter(dbCommand, "nasn_15", DbType.String, data.nasn_15);
                db.AddInParameter(dbCommand, "nasn_16", DbType.String, data.nasn_16);
                db.AddInParameter(dbCommand, "nasn_17", DbType.String, data.nasn_17);
                db.AddInParameter(dbCommand, "nasn_18", DbType.String, data.nasn_18);
                db.AddInParameter(dbCommand, "nasn_date1", DbType.DateTime, data.nasn_date1);
                db.AddInParameter(dbCommand, "nasn_madeby", DbType.Int32, data.nasn_madeby);
                db.AddInParameter(dbCommand, "nasn_modifyby", DbType.Int32, data.nasn_madeby);

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
        public static int DeleteNAS(int nasnId, int nasn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_NEW_delete");

                db.AddInParameter(dbCommand, "nasnId", DbType.Int32, nasnId);
                db.AddInParameter(dbCommand, "nasn_modifyby", DbType.String, nasn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Metlife
    {
        public static DataTable GetPrintMetlife(int? metId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_METLIFE_Print");
                if (metId > 0)
                {
                    db.AddInParameter(dbCommand, "metId", DbType.Int32, metId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllMetlife(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_METLIFE_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreMetlife(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_METLIFE_PREVIOUS_History");
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
        public static bool InsertUpdateMetlife(BusinessEntities.EMRForms.Metlife data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_METLIFE_INSERT_UPDATE");
                if (data.metId > 0)
                {
                    db.AddInParameter(dbCommand, "metId", DbType.Int32, data.metId);
                }
                db.AddInParameter(dbCommand, "met_appId", DbType.Int32, data.met_appId);
                db.AddInParameter(dbCommand, "met_1", DbType.String, data.met_1);
                db.AddInParameter(dbCommand, "met_2", DbType.String, data.met_2);
                db.AddInParameter(dbCommand, "met_3", DbType.String, data.met_3);
                db.AddInParameter(dbCommand, "met_4", DbType.DateTime, data.met_4);
                db.AddInParameter(dbCommand, "met_check", DbType.String, data.met_check);
                db.AddInParameter(dbCommand, "met_claim_amount", DbType.String, data.met_claim_amount);
                db.AddInParameter(dbCommand, "met_currency", DbType.String, data.met_currency);
                db.AddInParameter(dbCommand, "met_madeby", DbType.Int32, data.met_madeby);
                db.AddInParameter(dbCommand, "met_modifyby", DbType.Int32, data.met_madeby);

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
        public static int DeleteMetlife(int metId, int met_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_METLIFE_delete");

                db.AddInParameter(dbCommand, "metId", DbType.Int32, metId);
                db.AddInParameter(dbCommand, "met_modifyby", DbType.String, met_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Mednet
    {
        public static DataTable GetPrintMednet(int? cmcnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_CLAIM_NEW_Print");
                if (cmcnId > 0)
                {
                    db.AddInParameter(dbCommand, "cmcnId", DbType.Int32, cmcnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllMednet(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_CLAIM_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreMednet(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_CLAIM_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateMednet(BusinessEntities.EMRForms.Mednet data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_CLAIM_NEW_INSERT_UPDATE");
                if (data.cmcnId > 0)
                {
                    db.AddInParameter(dbCommand, "cmcnId", DbType.Int32, data.cmcnId);
                }
                db.AddInParameter(dbCommand, "cmcn_appId", DbType.Int32, data.cmcn_appId);
                db.AddInParameter(dbCommand, "cmcn_1", DbType.String, data.cmcn_1);
                db.AddInParameter(dbCommand, "cmcn_2", DbType.String, data.cmcn_2);
                db.AddInParameter(dbCommand, "cmcn_3", DbType.String, data.cmcn_3);
                db.AddInParameter(dbCommand, "cmcn_4", DbType.String, data.cmcn_4);
                db.AddInParameter(dbCommand, "cmcn_5", DbType.String, data.cmcn_5);
                db.AddInParameter(dbCommand, "cmcn_6", DbType.String, data.cmcn_6);
                db.AddInParameter(dbCommand, "cmcn_7", DbType.String, data.cmcn_7);
                db.AddInParameter(dbCommand, "cmcn_chk", DbType.String, data.cmcn_chk);
                db.AddInParameter(dbCommand, "cmcn_date1", DbType.DateTime, data.cmcn_date1);
                db.AddInParameter(dbCommand, "cmcn_date2", DbType.DateTime, data.cmcn_date2);
                db.AddInParameter(dbCommand, "cmcn_date3", DbType.DateTime, data.cmcn_date3);
                db.AddInParameter(dbCommand, "cmcn_madeby", DbType.Int32, data.cmcn_madeby);
                db.AddInParameter(dbCommand, "cmcn_modifyby", DbType.Int32, data.cmcn_madeby);

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
        public static int DeleteMednet(int cmcnId, int cmcn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_CLAIM_NEW_delete");

                db.AddInParameter(dbCommand, "cmcnId", DbType.Int32, cmcnId);
                db.AddInParameter(dbCommand, "cmcn_modifyby", DbType.String, cmcn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Nextcare
    {
        public static DataTable GetPrintNextcare(int? cncnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_CLAIM_NEW_Print");
                if (cncnId > 0)
                {
                    db.AddInParameter(dbCommand, "cncnId", DbType.Int32, cncnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNextcare(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_CLAIM_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNextcare(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_CLAIM_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNextcare(BusinessEntities.EMRForms.Nextcare data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_CLAIM_NEW_INSERT_UPDATE");
                if (data.cncnId > 0)
                {
                    db.AddInParameter(dbCommand, "cncnId", DbType.Int32, data.cncnId);
                }
                db.AddInParameter(dbCommand, "cncn_appId", DbType.Int32, data.cncn_appId);
                db.AddInParameter(dbCommand, "cncn_1", DbType.String, data.cncn_1);
                db.AddInParameter(dbCommand, "cncn_2", DbType.String, data.cncn_2);
                db.AddInParameter(dbCommand, "cncn_3", DbType.String, data.cncn_3);
                db.AddInParameter(dbCommand, "cncn_4", DbType.String, data.cncn_4);
                db.AddInParameter(dbCommand, "cncn_5", DbType.String, data.cncn_5);
                db.AddInParameter(dbCommand, "cncn_6", DbType.String, data.cncn_6);
                db.AddInParameter(dbCommand, "cncn_7", DbType.String, data.cncn_7);
                db.AddInParameter(dbCommand, "cncn_8", DbType.String, data.cncn_8);
                db.AddInParameter(dbCommand, "cncn_9", DbType.String, data.cncn_9);
                db.AddInParameter(dbCommand, "cncn_10", DbType.String, data.cncn_10);
                db.AddInParameter(dbCommand, "cncn_11", DbType.String, data.cncn_11);
                db.AddInParameter(dbCommand, "cncn_12", DbType.String, data.cncn_12);
                db.AddInParameter(dbCommand, "cncn_13", DbType.String, data.cncn_13);
                db.AddInParameter(dbCommand, "cncn_14", DbType.String, data.cncn_14);
                db.AddInParameter(dbCommand, "cncn_15", DbType.String, data.cncn_15);
                db.AddInParameter(dbCommand, "cncn_chk", DbType.String, data.cncn_chk);
                db.AddInParameter(dbCommand, "cncn_date1", DbType.DateTime, data.cncn_date1);
                db.AddInParameter(dbCommand, "cncn_date2", DbType.DateTime, data.cncn_date2);
                db.AddInParameter(dbCommand, "cncn_madeby", DbType.Int32, data.cncn_madeby);
                db.AddInParameter(dbCommand, "cncn_modifyby", DbType.Int32, data.cncn_madeby);

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
        public static int DeleteNextcare(int cncnId, int cncn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_CLAIM_NEW_delete");

                db.AddInParameter(dbCommand, "cncnId", DbType.Int32, cncnId);
                db.AddInParameter(dbCommand, "cncn_modifyby", DbType.String, cncn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Alkhazna
    {
        public static DataTable GetPrintAlkhazna(int? ckneId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_Print");
                if (ckneId > 0)
                {
                    db.AddInParameter(dbCommand, "ckneId", DbType.Int32, ckneId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllAlkhazna(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAlkhazna(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateAlkhazna(BusinessEntities.EMRForms.Alkhazna data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_INSERT_UPDATE");
                if (data.ckneId > 0)
                {
                    db.AddInParameter(dbCommand, "ckneId", DbType.Int32, data.ckneId);
                }
                db.AddInParameter(dbCommand, "ckne_appId", DbType.Int32, data.ckne_appId);
                db.AddInParameter(dbCommand, "ckne_chk", DbType.String, data.ckne_chk);
                db.AddInParameter(dbCommand, "ckne_1", DbType.String, data.ckne_1);
                db.AddInParameter(dbCommand, "ckne_2", DbType.String, data.ckne_2);
                db.AddInParameter(dbCommand, "ckne_3", DbType.String, data.ckne_3);
                db.AddInParameter(dbCommand, "ckne_4", DbType.String, data.ckne_4);
                db.AddInParameter(dbCommand, "ckne_5", DbType.String, data.ckne_5);
                db.AddInParameter(dbCommand, "ckne_6", DbType.String, data.ckne_6);
                db.AddInParameter(dbCommand, "ckne_7", DbType.String, data.ckne_7);
                db.AddInParameter(dbCommand, "ckne_8", DbType.String, data.ckne_8);
                db.AddInParameter(dbCommand, "ckne_9", DbType.String, data.ckne_9);
                db.AddInParameter(dbCommand, "ckne_10", DbType.String, data.ckne_10);
                db.AddInParameter(dbCommand, "ckne_11", DbType.String, data.ckne_11);
                db.AddInParameter(dbCommand, "ckne_12", DbType.String, data.ckne_12);
                db.AddInParameter(dbCommand, "ckne_13", DbType.String, data.ckne_13);
                db.AddInParameter(dbCommand, "ckne_14", DbType.String, data.ckne_14);
                db.AddInParameter(dbCommand, "ckne_15", DbType.String, data.ckne_15);
                db.AddInParameter(dbCommand, "ckne_16", DbType.String, data.ckne_16);
                db.AddInParameter(dbCommand, "ckne_17", DbType.String, data.ckne_17);
                db.AddInParameter(dbCommand, "ckne_18", DbType.String, data.ckne_18);
                db.AddInParameter(dbCommand, "ckne_19", DbType.String, data.ckne_19);
                db.AddInParameter(dbCommand, "ckne_20", DbType.String, data.ckne_20);
                db.AddInParameter(dbCommand, "ckne_21", DbType.String, data.ckne_21);
                db.AddInParameter(dbCommand, "ckne_22", DbType.String, data.ckne_22);
                db.AddInParameter(dbCommand, "ckne_23", DbType.String, data.ckne_23);
                db.AddInParameter(dbCommand, "ckne_24", DbType.String, data.ckne_24);
                db.AddInParameter(dbCommand, "ckne_25", DbType.String, data.ckne_25);
                db.AddInParameter(dbCommand, "ckne_26", DbType.String, data.ckne_26);
                db.AddInParameter(dbCommand, "ckne_27", DbType.String, data.ckne_27);
                db.AddInParameter(dbCommand, "ckne_28", DbType.String, data.ckne_28);
                db.AddInParameter(dbCommand, "ckne_29", DbType.String, data.ckne_29);
                db.AddInParameter(dbCommand, "ckne_30", DbType.String, data.ckne_30);
                db.AddInParameter(dbCommand, "ckne_31", DbType.String, data.ckne_31);
                db.AddInParameter(dbCommand, "ckne_32", DbType.String, data.ckne_32);
                db.AddInParameter(dbCommand, "ckne_33", DbType.String, data.ckne_33);
                db.AddInParameter(dbCommand, "ckne_34", DbType.String, data.ckne_34);
                db.AddInParameter(dbCommand, "ckne_35", DbType.String, data.ckne_35);
                db.AddInParameter(dbCommand, "ckne_date1", DbType.DateTime, data.ckne_date1);
                db.AddInParameter(dbCommand, "ckne_date2", DbType.DateTime, data.ckne_date2);

                db.AddInParameter(dbCommand, "ckne_madeby", DbType.Int32, data.ckne_madeby);
                db.AddInParameter(dbCommand, "ckne_modifyby", DbType.Int32, data.ckne_madeby);

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
        public static int DeleteAlkhazna(int ckneId, int ckne_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_delete");

                db.AddInParameter(dbCommand, "ckneId", DbType.Int32, ckneId);
                db.AddInParameter(dbCommand, "ckne_modifyby", DbType.String, ckne_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class ArabOrient
    {
        public static DataTable GetPrintArabOrient(int? caonId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARAB_ORIENT_NEW_Print");
                if (caonId > 0)
                {
                    db.AddInParameter(dbCommand, "caonId", DbType.Int32, caonId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllArabOrient(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARAB_ORIENT_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreArabOrient(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARAB_ORIENT_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateArabOrient(BusinessEntities.EMRForms.ArabOrient data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARAB_ORIENT_NEW_INSERT_UPDATE");
                if (data.caonId > 0)
                {
                    db.AddInParameter(dbCommand, "caonId", DbType.Int32, data.caonId);
                }
                db.AddInParameter(dbCommand, "caon_appId", DbType.Int32, data.caon_appId);
                db.AddInParameter(dbCommand, "caon_chk", DbType.String, data.caon_chk);
                db.AddInParameter(dbCommand, "caon_1", DbType.String, data.caon_1);
                db.AddInParameter(dbCommand, "caon_2", DbType.String, data.caon_2);
                db.AddInParameter(dbCommand, "caon_3", DbType.String, data.caon_3);
                db.AddInParameter(dbCommand, "caon_4", DbType.String, data.caon_4);
                db.AddInParameter(dbCommand, "caon_5", DbType.String, data.caon_5);
                db.AddInParameter(dbCommand, "caon_6", DbType.String, data.caon_6);
                db.AddInParameter(dbCommand, "caon_7", DbType.String, data.caon_7);
                db.AddInParameter(dbCommand, "caon_8", DbType.String, data.caon_8);
                db.AddInParameter(dbCommand, "caon_9", DbType.String, data.caon_9);
                db.AddInParameter(dbCommand, "caon_10", DbType.String, data.caon_10);
                db.AddInParameter(dbCommand, "caon_11", DbType.String, data.caon_11);
                db.AddInParameter(dbCommand, "caon_12", DbType.String, data.caon_12);
                db.AddInParameter(dbCommand, "caon_13", DbType.String, data.caon_13);
                db.AddInParameter(dbCommand, "caon_14", DbType.String, data.caon_14);
                db.AddInParameter(dbCommand, "caon_15", DbType.String, data.caon_15);
                db.AddInParameter(dbCommand, "caon_16", DbType.String, data.caon_16);
                db.AddInParameter(dbCommand, "caon_17", DbType.String, data.caon_17);
                db.AddInParameter(dbCommand, "caon_18", DbType.String, data.caon_18);
                db.AddInParameter(dbCommand, "caon_19", DbType.String, data.caon_19);
                db.AddInParameter(dbCommand, "caon_20", DbType.String, data.caon_20);
                db.AddInParameter(dbCommand, "caon_21", DbType.String, data.caon_21);
                db.AddInParameter(dbCommand, "caon_22", DbType.DateTime, data.caon_22);

                db.AddInParameter(dbCommand, "caon_madeby", DbType.Int32, data.caon_madeby);
                db.AddInParameter(dbCommand, "caon_modifyby", DbType.Int32, data.caon_madeby);

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
        public static int DeleteArabOrient(int caonId, int caon_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ARAB_ORIENT_NEW_delete");

                db.AddInParameter(dbCommand, "caonId", DbType.Int32, caonId);
                db.AddInParameter(dbCommand, "caon_modifyby", DbType.String, caon_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class EmiratesDental
    {
        public static DataTable GetPrintEmiratesDental(int? emdnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_Print");
                if (emdnId > 0)
                {
                    db.AddInParameter(dbCommand, "emdnId", DbType.Int32, emdnId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllEmiratesDental(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreEmiratesDental(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateEmiratesDental(BusinessEntities.EMRForms.EmiratesDental data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_INSERT_UPDATE");
                if (data.emdnId > 0)
                {
                    db.AddInParameter(dbCommand, "emdnId", DbType.Int32, data.emdnId);
                }
                db.AddInParameter(dbCommand, "emdn_appId", DbType.Int32, data.emdn_appId);
                db.AddInParameter(dbCommand, "emdn_chk", DbType.String, data.emdn_chk);
                db.AddInParameter(dbCommand, "emdn_1", DbType.String, data.emdn_1);
                db.AddInParameter(dbCommand, "emdn_2", DbType.String, data.emdn_2);
                db.AddInParameter(dbCommand, "emdn_3", DbType.String, data.emdn_3);
                db.AddInParameter(dbCommand, "emdn_4", DbType.String, data.emdn_4);
                db.AddInParameter(dbCommand, "emdn_5", DbType.String, data.emdn_5);
                db.AddInParameter(dbCommand, "emdn_6", DbType.String, data.emdn_6);
                db.AddInParameter(dbCommand, "emdn_7", DbType.String, data.emdn_7);
                db.AddInParameter(dbCommand, "emdn_8", DbType.String, data.emdn_8);
                db.AddInParameter(dbCommand, "emdn_9", DbType.String, data.emdn_9);
                db.AddInParameter(dbCommand, "emdn_10", DbType.String, data.emdn_10);
                db.AddInParameter(dbCommand, "emdn_11", DbType.String, data.emdn_11);
                db.AddInParameter(dbCommand, "emdn_12", DbType.String, data.emdn_12);
                db.AddInParameter(dbCommand, "emdn_13", DbType.String, data.emdn_13);
                db.AddInParameter(dbCommand, "emdn_14", DbType.String, data.emdn_14);
                db.AddInParameter(dbCommand, "emdn_15", DbType.String, data.emdn_15);
                db.AddInParameter(dbCommand, "emdn_16", DbType.String, data.emdn_16);
                db.AddInParameter(dbCommand, "emdn_17", DbType.String, data.emdn_17);
                db.AddInParameter(dbCommand, "emdn_18", DbType.String, data.emdn_18);
                db.AddInParameter(dbCommand, "emdn_19", DbType.String, data.emdn_19);
                db.AddInParameter(dbCommand, "emdn_20", DbType.String, data.emdn_20);
                db.AddInParameter(dbCommand, "emdn_21", DbType.String, data.emdn_21);
                db.AddInParameter(dbCommand, "emdn_22", DbType.String, data.emdn_22);
                db.AddInParameter(dbCommand, "emdn_23", DbType.String, data.emdn_23);
                db.AddInParameter(dbCommand, "emdn_24", DbType.String, data.emdn_24);
                db.AddInParameter(dbCommand, "emdn_25", DbType.String, data.emdn_25);
                db.AddInParameter(dbCommand, "emdn_26", DbType.String, data.emdn_26);
                db.AddInParameter(dbCommand, "emdn_27", DbType.String, data.emdn_27);
                db.AddInParameter(dbCommand, "emdn_28", DbType.String, data.emdn_28);
                db.AddInParameter(dbCommand, "emdn_29", DbType.String, data.emdn_29);
                db.AddInParameter(dbCommand, "emdn_30", DbType.String, data.emdn_30);
                db.AddInParameter(dbCommand, "emdn_31", DbType.String, data.emdn_31);
                db.AddInParameter(dbCommand, "emdn_32", DbType.String, data.emdn_32);
                db.AddInParameter(dbCommand, "emdn_33", DbType.String, data.emdn_33);
                db.AddInParameter(dbCommand, "emdn_34", DbType.String, data.emdn_34);
                db.AddInParameter(dbCommand, "emdn_35", DbType.String, data.emdn_35);

                db.AddInParameter(dbCommand, "emdn_madeby", DbType.Int32, data.emdn_madeby);
                db.AddInParameter(dbCommand, "emdn_modifyby", DbType.Int32, data.emdn_madeby);

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
        public static int DeleteEmiratesDental(int emdnId, int emdn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMIRATES_DENTAL_NEW_delete");

                db.AddInParameter(dbCommand, "emdnId", DbType.Int32, emdnId);
                db.AddInParameter(dbCommand, "emdn_modifyby", DbType.String, emdn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class MednetTakaful
    {
        public static DataTable GetPrintMednetTakaful(int? cmtnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_TAKAFUL_NEW_Print");
                if (cmtnId > 0)
                {
                    db.AddInParameter(dbCommand, "cmtnId", DbType.Int32, cmtnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllMednetTakaful(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_TAKAFUL_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreMednetTakaful(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_TAKAFUL_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateMednetTakaful(BusinessEntities.EMRForms.MednetTakaful data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_TAKAFUL_NEW_INSERT_UPDATE");
                if (data.cmtnId > 0)
                {
                    db.AddInParameter(dbCommand, "cmtnId", DbType.Int32, data.cmtnId);
                }
                db.AddInParameter(dbCommand, "cmtn_appId", DbType.Int32, data.cmtn_appId);
                db.AddInParameter(dbCommand, "cmtn_1", DbType.String, data.cmtn_1);
                db.AddInParameter(dbCommand, "cmtn_2", DbType.String, data.cmtn_2);
                db.AddInParameter(dbCommand, "cmtn_3", DbType.String, data.cmtn_3);
                db.AddInParameter(dbCommand, "cmtn_4", DbType.String, data.cmtn_4);
                db.AddInParameter(dbCommand, "cmtn_5", DbType.String, data.cmtn_5);
                db.AddInParameter(dbCommand, "cmtn_6", DbType.String, data.cmtn_6);
                db.AddInParameter(dbCommand, "cmtn_7", DbType.String, data.cmtn_7);
                db.AddInParameter(dbCommand, "cmtn_chk", DbType.String, data.cmtn_chk);
                db.AddInParameter(dbCommand, "cmtn_date1", DbType.DateTime, data.cmtn_date1);
                db.AddInParameter(dbCommand, "cmtn_date2", DbType.DateTime, data.cmtn_date2);
                db.AddInParameter(dbCommand, "cmtn_date3", DbType.DateTime, data.cmtn_date3);
                db.AddInParameter(dbCommand, "cmtn_madeby", DbType.Int32, data.cmtn_madeby);
                db.AddInParameter(dbCommand, "cmtn_modifyby", DbType.Int32, data.cmtn_madeby);

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
        public static int DeleteMednetTakaful(int cmtnId, int cmtn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MEDNET_TAKAFUL_NEW_delete");

                db.AddInParameter(dbCommand, "cmtnId", DbType.Int32, cmtnId);
                db.AddInParameter(dbCommand, "cmtn_modifyby", DbType.String, cmtn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class NASQIC
    {
        public static DataTable GetPrintNASQIC(int? nasqId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_QIC_NEW_Print");
                if (nasqId > 0)
                {
                    db.AddInParameter(dbCommand, "nasqId", DbType.Int32, nasqId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNASQIC(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_QIC_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNASQIC(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_QIC_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNASQIC(BusinessEntities.EMRForms.NASQIC data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_QIC_NEW_INSERT_UPDATE");
                if (data.nasqId > 0)
                {
                    db.AddInParameter(dbCommand, "nasqId", DbType.Int32, data.nasqId);
                }
                db.AddInParameter(dbCommand, "nasq_appId", DbType.Int32, data.nasq_appId);
                db.AddInParameter(dbCommand, "nasq_1", DbType.String, data.nasq_1);
                db.AddInParameter(dbCommand, "nasq_2", DbType.String, data.nasq_2);
                db.AddInParameter(dbCommand, "nasq_3", DbType.String, data.nasq_3);
                db.AddInParameter(dbCommand, "nasq_4", DbType.String, data.nasq_4);
                db.AddInParameter(dbCommand, "nasq_5", DbType.String, data.nasq_5);
                db.AddInParameter(dbCommand, "nasq_6", DbType.String, data.nasq_6);
                db.AddInParameter(dbCommand, "nasq_7", DbType.String, data.nasq_7);
                db.AddInParameter(dbCommand, "nasq_8", DbType.String, data.nasq_8);
                db.AddInParameter(dbCommand, "nasq_9", DbType.String, data.nasq_9);
                db.AddInParameter(dbCommand, "nasq_10", DbType.String, data.nasq_10);
                db.AddInParameter(dbCommand, "nasq_11", DbType.String, data.nasq_11);
                db.AddInParameter(dbCommand, "nasq_12", DbType.String, data.nasq_12);
                db.AddInParameter(dbCommand, "nasq_13", DbType.String, data.nasq_13);
                db.AddInParameter(dbCommand, "nasq_14", DbType.String, data.nasq_14);
                db.AddInParameter(dbCommand, "nasq_15", DbType.String, data.nasq_15);
                db.AddInParameter(dbCommand, "nasq_16", DbType.String, data.nasq_16);
                db.AddInParameter(dbCommand, "nasq_17", DbType.String, data.nasq_17);
                db.AddInParameter(dbCommand, "nasq_18", DbType.String, data.nasq_18);
                db.AddInParameter(dbCommand, "nasq_date1", DbType.DateTime, data.nasq_date1);
                db.AddInParameter(dbCommand, "nasq_madeby", DbType.Int32, data.nasq_madeby);
                db.AddInParameter(dbCommand, "nasq_modifyby", DbType.Int32, data.nasq_madeby);

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
        public static int DeleteNASQIC(int nasqId, int nasq_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_CLAIM_QIC_NEW_delete");

                db.AddInParameter(dbCommand, "nasqId", DbType.Int32, nasqId);
                db.AddInParameter(dbCommand, "nasq_modifyby", DbType.String, nasq_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class SAICO
    {
        public static DataTable GetPrintSAICO(int? sacnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SAICO_CLAIM_NEW_Print");
                if (sacnId > 0)
                {
                    db.AddInParameter(dbCommand, "sacnId", DbType.Int32, sacnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllSAICO(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SAICO_CLAIM_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreSAICO(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SAICO_CLAIM_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateSAICO(BusinessEntities.EMRForms.SAICO data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SAICO_CLAIM_NEW_INSERT_UPDATE");
                if (data.sacnId > 0)
                {
                    db.AddInParameter(dbCommand, "sacnId", DbType.Int32, data.sacnId);
                }
                db.AddInParameter(dbCommand, "sacn_appId", DbType.Int32, data.sacn_appId);
                db.AddInParameter(dbCommand, "sacn_checkbox", DbType.String, data.sacn_checkbox);
                db.AddInParameter(dbCommand, "sacn_1", DbType.String, data.sacn_1);
                db.AddInParameter(dbCommand, "sacn_2", DbType.String, data.sacn_2);
                db.AddInParameter(dbCommand, "sacn_3", DbType.String, data.sacn_3);
                db.AddInParameter(dbCommand, "sacn_4", DbType.String, data.sacn_4);
                db.AddInParameter(dbCommand, "sacn_5", DbType.String, data.sacn_5);
                db.AddInParameter(dbCommand, "sacn_6", DbType.String, data.sacn_6);
                db.AddInParameter(dbCommand, "sacn_7", DbType.String, data.sacn_7);
                db.AddInParameter(dbCommand, "sacn_8", DbType.String, data.sacn_8);
                db.AddInParameter(dbCommand, "sacn_9", DbType.String, data.sacn_9);
                db.AddInParameter(dbCommand, "sacn_10", DbType.String, data.sacn_10);
                db.AddInParameter(dbCommand, "sacn_11", DbType.String, data.sacn_11);
                db.AddInParameter(dbCommand, "sacn_12", DbType.String, data.sacn_12);
                db.AddInParameter(dbCommand, "sacn_13", DbType.String, data.sacn_13);
                db.AddInParameter(dbCommand, "sacn_14", DbType.String, data.sacn_14);
                db.AddInParameter(dbCommand, "sacn_15", DbType.String, data.sacn_15);
                db.AddInParameter(dbCommand, "sacn_16", DbType.String, data.sacn_16);
                db.AddInParameter(dbCommand, "sacn_17", DbType.String, data.sacn_17);
                db.AddInParameter(dbCommand, "sacn_18", DbType.String, data.sacn_18);
                db.AddInParameter(dbCommand, "sacn_19", DbType.String, data.sacn_19);
                db.AddInParameter(dbCommand, "sacn_d1", DbType.DateTime, data.sacn_d1);
                db.AddInParameter(dbCommand, "sacn_d2", DbType.DateTime, data.sacn_d2);
                db.AddInParameter(dbCommand, "sacn_d3", DbType.DateTime, data.sacn_d3);
                db.AddInParameter(dbCommand, "sacn_d4", DbType.DateTime, data.sacn_d4);
                db.AddInParameter(dbCommand, "sacn_d5", DbType.DateTime, data.sacn_d5);
                db.AddInParameter(dbCommand, "sacn_d6", DbType.DateTime, data.sacn_d6);

                db.AddInParameter(dbCommand, "sacn_madeby", DbType.Int32, data.sacn_madeby);
                db.AddInParameter(dbCommand, "sacn_modifyby", DbType.Int32, data.sacn_madeby);

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
        public static int DeleteSAICO(int sacnId, int sacn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SAICO_CLAIM_NEW_delete");

                db.AddInParameter(dbCommand, "sacnId", DbType.Int32, sacnId);
                db.AddInParameter(dbCommand, "sacn_modifyby", DbType.String, sacn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
    public class Wamped
    {
        public static DataTable GetPrintWamped(int? wapnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_WAPMED_NEW_Print");
                if (wapnId > 0)
                {
                    db.AddInParameter(dbCommand, "wapnId", DbType.Int32, wapnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllWamped(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_WAPMED_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreWamped(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_WAPMED_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateWamped(BusinessEntities.EMRForms.Wamped data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_WAPMED_NEW_INSERT_UPDATE");
                if (data.wapnId > 0)
                {
                    db.AddInParameter(dbCommand, "wapnId", DbType.Int32, data.wapnId);
                }
                db.AddInParameter(dbCommand, "wapn_appId", DbType.Int32, data.wapn_appId);
                db.AddInParameter(dbCommand, "wapn_checkbox", DbType.String, data.wapn_checkbox);
                db.AddInParameter(dbCommand, "wapn_1", DbType.String, data.wapn_1);
                db.AddInParameter(dbCommand, "wapn_2", DbType.String, data.wapn_2);
                db.AddInParameter(dbCommand, "wapn_3", DbType.String, data.wapn_3);
                db.AddInParameter(dbCommand, "wapn_4", DbType.String, data.wapn_4);
                db.AddInParameter(dbCommand, "wapn_5", DbType.String, data.wapn_5);
                db.AddInParameter(dbCommand, "wapn_6", DbType.String, data.wapn_6);
                db.AddInParameter(dbCommand, "wapn_7", DbType.String, data.wapn_7);
                db.AddInParameter(dbCommand, "wapn_8", DbType.String, data.wapn_8);
                db.AddInParameter(dbCommand, "wapn_9", DbType.String, data.wapn_9);
                db.AddInParameter(dbCommand, "wapn_10", DbType.String, data.wapn_10);
                db.AddInParameter(dbCommand, "wapn_11", DbType.String, data.wapn_11);
                db.AddInParameter(dbCommand, "wapn_12", DbType.String, data.wapn_12);
                db.AddInParameter(dbCommand, "wapn_13", DbType.String, data.wapn_13);
                db.AddInParameter(dbCommand, "wapn_14", DbType.String, data.wapn_14);
                db.AddInParameter(dbCommand, "wapn_15", DbType.String, data.wapn_15);
                db.AddInParameter(dbCommand, "wapn_16", DbType.String, data.wapn_16);
                db.AddInParameter(dbCommand, "wapn_17", DbType.String, data.wapn_17);
                db.AddInParameter(dbCommand, "wapn_18", DbType.String, data.wapn_18);
                db.AddInParameter(dbCommand, "wapn_19", DbType.String, data.wapn_19);
                db.AddInParameter(dbCommand, "wapn_20", DbType.String, data.wapn_20);
                db.AddInParameter(dbCommand, "wapn_21", DbType.String, data.wapn_21);
                db.AddInParameter(dbCommand, "wapn_22", DbType.String, data.wapn_22);
                db.AddInParameter(dbCommand, "wapn_23", DbType.String, data.wapn_23);
                db.AddInParameter(dbCommand, "wapn_24", DbType.String, data.wapn_24);
                db.AddInParameter(dbCommand, "wapn_25", DbType.String, data.wapn_25);
                db.AddInParameter(dbCommand, "wapn_26", DbType.String, data.wapn_26);
                db.AddInParameter(dbCommand, "wapn_27", DbType.String, data.wapn_27);
                db.AddInParameter(dbCommand, "wapn_28", DbType.String, data.wapn_28);
                db.AddInParameter(dbCommand, "wapn_29", DbType.String, data.wapn_29);
                db.AddInParameter(dbCommand, "wapn_30", DbType.String, data.wapn_30);
                db.AddInParameter(dbCommand, "wapn_31", DbType.String, data.wapn_31);
                db.AddInParameter(dbCommand, "wapn_32", DbType.String, data.wapn_32);
                db.AddInParameter(dbCommand, "wapn_33", DbType.String, data.wapn_33);
                db.AddInParameter(dbCommand, "wapn_34", DbType.String, data.wapn_34);
                db.AddInParameter(dbCommand, "wapn_35", DbType.String, data.wapn_35);
                db.AddInParameter(dbCommand, "wapn_36", DbType.String, data.wapn_36);
                db.AddInParameter(dbCommand, "wapn_37", DbType.String, data.wapn_37);
                db.AddInParameter(dbCommand, "wapn_38", DbType.String, data.wapn_38);
                db.AddInParameter(dbCommand, "wapn_39", DbType.String, data.wapn_39);
                db.AddInParameter(dbCommand, "wapn_40", DbType.String, data.wapn_40);
                db.AddInParameter(dbCommand, "wapn_41", DbType.String, data.wapn_41);
                db.AddInParameter(dbCommand, "wapn_42", DbType.String, data.wapn_42);
                db.AddInParameter(dbCommand, "wapn_43", DbType.String, data.wapn_43);
                db.AddInParameter(dbCommand, "wapn_44", DbType.String, data.wapn_44);
                db.AddInParameter(dbCommand, "wapn_45", DbType.String, data.wapn_45);
                db.AddInParameter(dbCommand, "wapn_d1", DbType.DateTime, data.wapn_d1);
                db.AddInParameter(dbCommand, "wapn_d2", DbType.DateTime, data.wapn_d2);
                db.AddInParameter(dbCommand, "wapn_d3", DbType.DateTime, data.wapn_d3);

                db.AddInParameter(dbCommand, "wapn_madeby", DbType.Int32, data.wapn_madeby);
                db.AddInParameter(dbCommand, "wapn_modifyby", DbType.Int32, data.wapn_madeby);

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
        public static int DeleteWamped(int wapnId, int wapn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_WAPMED_NEW_delete");

                db.AddInParameter(dbCommand, "wapnId", DbType.Int32, wapnId);
                db.AddInParameter(dbCommand, "wapn_modifyby", DbType.String, wapn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class Orient
    {
        public static DataTable GetPrintOrient(int? orntId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ORIENT_REMB_NEW_Print");
                if (orntId > 0)
                {
                    db.AddInParameter(dbCommand, "orntId", DbType.Int32, orntId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllOrient(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ORIENT_REMB_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreOrient(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ORIENT_REMB_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateOrient(BusinessEntities.EMRForms.Orient data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ORIENT_REMB_NEW_INSERT_UPDATE");
                if (data.orntId > 0)
                {
                    db.AddInParameter(dbCommand, "orntId", DbType.Int32, data.orntId);
                }
                db.AddInParameter(dbCommand, "ornt_appId", DbType.Int32, data.ornt_appId);
                db.AddInParameter(dbCommand, "ornt_1", DbType.String, data.ornt_1);
                db.AddInParameter(dbCommand, "ornt_2", DbType.String, data.ornt_2);
                db.AddInParameter(dbCommand, "ornt_3", DbType.String, data.ornt_3);
                db.AddInParameter(dbCommand, "ornt_4", DbType.String, data.ornt_4);
                db.AddInParameter(dbCommand, "ornt_5", DbType.String, data.ornt_5);
                db.AddInParameter(dbCommand, "ornt_6", DbType.String, data.ornt_6);
                db.AddInParameter(dbCommand, "ornt_7", DbType.String, data.ornt_7);
                db.AddInParameter(dbCommand, "ornt_chk", DbType.String, data.ornt_chk);
                db.AddInParameter(dbCommand, "ornt_date1", DbType.DateTime, data.ornt_date1);
                db.AddInParameter(dbCommand, "ornt_date2", DbType.DateTime, data.ornt_date2);
                db.AddInParameter(dbCommand, "ornt_date3", DbType.DateTime, data.ornt_date3);
                db.AddInParameter(dbCommand, "ornt_madeby", DbType.Int32, data.ornt_madeby);
                db.AddInParameter(dbCommand, "ornt_modifyby", DbType.Int32, data.ornt_madeby);

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
        public static int DeleteOrient(int orntId, int ornt_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ORIENT_REMB_NEW_delete");

                db.AddInParameter(dbCommand, "orntId", DbType.Int32, orntId);
                db.AddInParameter(dbCommand, "ornt_modifyby", DbType.String, ornt_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class QICNAS
    {
        public static DataTable GetPrintQICNAS(int? qnasId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QIC_NAS_REMB_NEW_Print");
                if (qnasId > 0)
                {
                    db.AddInParameter(dbCommand, "qnasId", DbType.Int32, qnasId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllQICNAS(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QIC_NAS_REMB_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreQICNAS(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QIC_NAS_REMB_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateQICNAS(BusinessEntities.EMRForms.QICNAS data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QIC_NAS_REMB_NEW_INSERT_UPDATE");
                if (data.qnasId > 0)
                {
                    db.AddInParameter(dbCommand, "qnasId", DbType.Int32, data.qnasId);
                }
                db.AddInParameter(dbCommand, "qnas_appId", DbType.Int32, data.qnas_appId);
                db.AddInParameter(dbCommand, "qnas_1", DbType.String, data.qnas_1);
                db.AddInParameter(dbCommand, "qnas_2", DbType.String, data.qnas_2);
                db.AddInParameter(dbCommand, "qnas_3", DbType.String, data.qnas_3);
                db.AddInParameter(dbCommand, "qnas_4", DbType.String, data.qnas_4);
                db.AddInParameter(dbCommand, "qnas_5", DbType.String, data.qnas_5);
                db.AddInParameter(dbCommand, "qnas_6", DbType.String, data.qnas_6);
                db.AddInParameter(dbCommand, "qnas_7", DbType.String, data.qnas_7);
                db.AddInParameter(dbCommand, "qnas_8", DbType.String, data.qnas_8);
                db.AddInParameter(dbCommand, "qnas_9", DbType.String, data.qnas_9);
                db.AddInParameter(dbCommand, "qnas_10", DbType.String, data.qnas_10);
                db.AddInParameter(dbCommand, "qnas_11", DbType.String, data.qnas_11);
                db.AddInParameter(dbCommand, "qnas_12", DbType.String, data.qnas_12);
                db.AddInParameter(dbCommand, "qnas_13", DbType.String, data.qnas_13);
                db.AddInParameter(dbCommand, "qnas_14", DbType.String, data.qnas_14);
                db.AddInParameter(dbCommand, "qnas_15", DbType.String, data.qnas_15);
                db.AddInParameter(dbCommand, "qnas_16", DbType.String, data.qnas_16);
                db.AddInParameter(dbCommand, "qnas_17", DbType.String, data.qnas_17);
                db.AddInParameter(dbCommand, "qnas_18", DbType.String, data.qnas_18);
                db.AddInParameter(dbCommand, "qnas_19", DbType.String, data.qnas_19);
                db.AddInParameter(dbCommand, "qnas_20", DbType.String, data.qnas_20);
                db.AddInParameter(dbCommand, "qnas_21", DbType.String, data.qnas_21);
                db.AddInParameter(dbCommand, "qnas_date1", DbType.DateTime, data.qnas_date1);

                db.AddInParameter(dbCommand, "qnas_madeby", DbType.Int32, data.qnas_madeby);
                db.AddInParameter(dbCommand, "qnas_modifyby", DbType.Int32, data.qnas_madeby);

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
        public static int DeleteQICNAS(int qnasId, int qnas_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QIC_NAS_REMB_NEW_delete");

                db.AddInParameter(dbCommand, "qnasId", DbType.Int32, qnasId);
                db.AddInParameter(dbCommand, "qnas_modifyby", DbType.String, qnas_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Gulfcare
    {
        public static DataTable GetPrintGulfcare(int? gucnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GULFCARE_NEW_Print");
                if (gucnId > 0)
                {
                    db.AddInParameter(dbCommand, "gucnId", DbType.Int32, gucnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllGulfcare(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GULFCARE_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreGulfcare(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GULFCARE_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateGulfcare(BusinessEntities.EMRForms.Gulfcare data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GULFCARE_NEW_INSERT_UPDATE");
                if (data.gucnId > 0)
                {
                    db.AddInParameter(dbCommand, "gucnId", DbType.Int32, data.gucnId);
                }
                db.AddInParameter(dbCommand, "gucn_appId", DbType.Int32, data.gucn_appId);
                db.AddInParameter(dbCommand, "gucn_checkbox", DbType.String, data.gucn_checkbox);
                db.AddInParameter(dbCommand, "gucn_1", DbType.String, data.gucn_1);
                db.AddInParameter(dbCommand, "gucn_2", DbType.String, data.gucn_2);
                db.AddInParameter(dbCommand, "gucn_3", DbType.String, data.gucn_3);
                db.AddInParameter(dbCommand, "gucn_4", DbType.String, data.gucn_4);
                db.AddInParameter(dbCommand, "gucn_5", DbType.String, data.gucn_5);
                db.AddInParameter(dbCommand, "gucn_6", DbType.String, data.gucn_6);
                db.AddInParameter(dbCommand, "gucn_7", DbType.String, data.gucn_7);
                db.AddInParameter(dbCommand, "gucn_8", DbType.String, data.gucn_8);
                db.AddInParameter(dbCommand, "gucn_9", DbType.String, data.gucn_9);
                db.AddInParameter(dbCommand, "gucn_10", DbType.String, data.gucn_10);
                db.AddInParameter(dbCommand, "gucn_11", DbType.String, data.gucn_11);
                db.AddInParameter(dbCommand, "gucn_12", DbType.String, data.gucn_12);
                db.AddInParameter(dbCommand, "gucn_13", DbType.String, data.gucn_13);
                db.AddInParameter(dbCommand, "gucn_14", DbType.String, data.gucn_14);
                db.AddInParameter(dbCommand, "gucn_15", DbType.String, data.gucn_15);
                db.AddInParameter(dbCommand, "gucn_16", DbType.String, data.gucn_16);
                db.AddInParameter(dbCommand, "gucn_17", DbType.String, data.gucn_17);
                db.AddInParameter(dbCommand, "gucn_18", DbType.String, data.gucn_18);
                db.AddInParameter(dbCommand, "gucn_19", DbType.String, data.gucn_19);
                db.AddInParameter(dbCommand, "gucn_20", DbType.String, data.gucn_20);
                db.AddInParameter(dbCommand, "gucn_21", DbType.String, data.gucn_21);
                db.AddInParameter(dbCommand, "gucn_22", DbType.String, data.gucn_22);
                db.AddInParameter(dbCommand, "gucn_23", DbType.String, data.gucn_23);
                db.AddInParameter(dbCommand, "gucn_24", DbType.String, data.gucn_24);
                db.AddInParameter(dbCommand, "gucn_25", DbType.String, data.gucn_25);
                db.AddInParameter(dbCommand, "gucn_26", DbType.String, data.gucn_26);
                db.AddInParameter(dbCommand, "gucn_27", DbType.String, data.gucn_27);
                db.AddInParameter(dbCommand, "gucn_28", DbType.String, data.gucn_28);
                db.AddInParameter(dbCommand, "gucn_29", DbType.String, data.gucn_29);
                db.AddInParameter(dbCommand, "gucn_30", DbType.String, data.gucn_30);
                db.AddInParameter(dbCommand, "gucn_31", DbType.String, data.gucn_31);
                db.AddInParameter(dbCommand, "gucn_32", DbType.String, data.gucn_32);
                db.AddInParameter(dbCommand, "gucn_33", DbType.String, data.gucn_33);
                db.AddInParameter(dbCommand, "gucn_34", DbType.String, data.gucn_34);
                db.AddInParameter(dbCommand, "gucn_35", DbType.String, data.gucn_35);
                db.AddInParameter(dbCommand, "gucn_36", DbType.String, data.gucn_36);
                db.AddInParameter(dbCommand, "gucn_37", DbType.String, data.gucn_37);
                db.AddInParameter(dbCommand, "gucn_38", DbType.String, data.gucn_38);
                db.AddInParameter(dbCommand, "gucn_39", DbType.String, data.gucn_39);
                db.AddInParameter(dbCommand, "gucn_40", DbType.String, data.gucn_40);
                db.AddInParameter(dbCommand, "gucn_41", DbType.String, data.gucn_41);
                db.AddInParameter(dbCommand, "gucn_42", DbType.String, data.gucn_42);
                db.AddInParameter(dbCommand, "gucn_43", DbType.String, data.gucn_43);

                db.AddInParameter(dbCommand, "gucn_madeby", DbType.Int32, data.gucn_madeby);
                db.AddInParameter(dbCommand, "gucn_modifyby", DbType.Int32, data.gucn_madeby);

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
        public static int DeleteGulfcare(int gucnId, int gucn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GULFCARE_NEW_delete");

                db.AddInParameter(dbCommand, "gucnId", DbType.Int32, gucnId);
                db.AddInParameter(dbCommand, "gucn_modifyby", DbType.String, gucn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Goldstar
    {
        public static DataTable GetPrintGoldstar(int? cgsnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GOLDSTAR_NEW_Print");
                if (cgsnId > 0)
                {
                    db.AddInParameter(dbCommand, "cgsnId", DbType.Int32, cgsnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllGoldstar(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GOLDSTAR_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreGoldstar(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GOLDSTAR_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateGoldstar(BusinessEntities.EMRForms.Goldstar data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GOLDSTAR_NEW_INSERT_UPDATE");
                if (data.cgsnId > 0)
                {
                    db.AddInParameter(dbCommand, "cgsnId", DbType.Int32, data.cgsnId);
                }
                db.AddInParameter(dbCommand, "cgsn_appId", DbType.Int32, data.cgsn_appId);
                db.AddInParameter(dbCommand, "cgsn_checkbox", DbType.String, data.cgsn_checkbox);
                db.AddInParameter(dbCommand, "cgsn_1", DbType.String, data.cgsn_1);
                db.AddInParameter(dbCommand, "cgsn_2", DbType.String, data.cgsn_2);
                db.AddInParameter(dbCommand, "cgsn_3", DbType.String, data.cgsn_3);
                db.AddInParameter(dbCommand, "cgsn_4", DbType.String, data.cgsn_4);
                db.AddInParameter(dbCommand, "cgsn_5", DbType.String, data.cgsn_5);
                db.AddInParameter(dbCommand, "cgsn_6", DbType.String, data.cgsn_6);
                db.AddInParameter(dbCommand, "cgsn_7", DbType.String, data.cgsn_7);
                db.AddInParameter(dbCommand, "cgsn_8", DbType.String, data.cgsn_8);
                db.AddInParameter(dbCommand, "cgsn_9", DbType.String, data.cgsn_9);
                db.AddInParameter(dbCommand, "cgsn_10", DbType.String, data.cgsn_10);
                db.AddInParameter(dbCommand, "cgsn_11", DbType.String, data.cgsn_11);
                db.AddInParameter(dbCommand, "cgsn_12", DbType.String, data.cgsn_12);
                db.AddInParameter(dbCommand, "cgsn_13", DbType.String, data.cgsn_13);
                db.AddInParameter(dbCommand, "cgsn_14", DbType.String, data.cgsn_14);
                db.AddInParameter(dbCommand, "cgsn_15", DbType.String, data.cgsn_15);
                db.AddInParameter(dbCommand, "cgsn_16", DbType.String, data.cgsn_16);
                db.AddInParameter(dbCommand, "cgsn_17", DbType.String, data.cgsn_17);
                db.AddInParameter(dbCommand, "cgsn_18", DbType.String, data.cgsn_18);
                db.AddInParameter(dbCommand, "cgsn_19", DbType.String, data.cgsn_19);
                db.AddInParameter(dbCommand, "cgsn_20", DbType.String, data.cgsn_20);
                db.AddInParameter(dbCommand, "cgsn_21", DbType.String, data.cgsn_21);
                db.AddInParameter(dbCommand, "cgsn_22", DbType.String, data.cgsn_22);
                db.AddInParameter(dbCommand, "cgsn_23", DbType.String, data.cgsn_23);
                db.AddInParameter(dbCommand, "cgsn_24", DbType.String, data.cgsn_24);
                db.AddInParameter(dbCommand, "cgsn_25", DbType.String, data.cgsn_25);
                db.AddInParameter(dbCommand, "cgsn_26", DbType.String, data.cgsn_26);
                db.AddInParameter(dbCommand, "cgsn_27", DbType.String, data.cgsn_27);
                db.AddInParameter(dbCommand, "cgsn_28", DbType.String, data.cgsn_28);
                db.AddInParameter(dbCommand, "cgsn_29", DbType.String, data.cgsn_29);
                db.AddInParameter(dbCommand, "cgsn_30", DbType.String, data.cgsn_30);
                db.AddInParameter(dbCommand, "cgsn_31", DbType.String, data.cgsn_31);

                db.AddInParameter(dbCommand, "cgsn_madeby", DbType.Int32, data.cgsn_madeby);
                db.AddInParameter(dbCommand, "cgsn_modifyby", DbType.Int32, data.cgsn_madeby);

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
        public static int DeleteGoldstar(int cgsnId, int cgsn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GOLDSTAR_NEW_delete");

                db.AddInParameter(dbCommand, "cgsnId", DbType.Int32, cgsnId);
                db.AddInParameter(dbCommand, "cgsn_modifyby", DbType.String, cgsn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class HealthInternational
    {
        public static DataTable GetPrintHealthInternational(int? chinId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_INT_NEW_Print");
                if (chinId > 0)
                {
                    db.AddInParameter(dbCommand, "chinId", DbType.Int32, chinId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllHealthInternational(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_INT_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreHealthInternational(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_INT_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateHealthInternational(BusinessEntities.EMRForms.HealthInternational data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_INT_NEW_INSERT_UPDATE");
                if (data.chinId > 0)
                {
                    db.AddInParameter(dbCommand, "chinId", DbType.Int32, data.chinId);
                }
                db.AddInParameter(dbCommand, "chin_appId", DbType.Int32, data.chin_appId);
                db.AddInParameter(dbCommand, "chin_checkbox", DbType.String, data.chin_checkbox);
                db.AddInParameter(dbCommand, "chin_1", DbType.String, data.chin_1);
                db.AddInParameter(dbCommand, "chin_2", DbType.String, data.chin_2);
                db.AddInParameter(dbCommand, "chin_3", DbType.String, data.chin_3);
                db.AddInParameter(dbCommand, "chin_4", DbType.String, data.chin_4);
                db.AddInParameter(dbCommand, "chin_5", DbType.String, data.chin_5);
                db.AddInParameter(dbCommand, "chin_6", DbType.String, data.chin_6);
                db.AddInParameter(dbCommand, "chin_7", DbType.String, data.chin_7);
                db.AddInParameter(dbCommand, "chin_8", DbType.String, data.chin_8);
                db.AddInParameter(dbCommand, "chin_9", DbType.String, data.chin_9);
                db.AddInParameter(dbCommand, "chin_10", DbType.String, data.chin_10);
                db.AddInParameter(dbCommand, "chin_11", DbType.String, data.chin_11);
                db.AddInParameter(dbCommand, "chin_date1", DbType.DateTime, data.chin_date1);
                db.AddInParameter(dbCommand, "chin_date2", DbType.DateTime, data.chin_date2);
                db.AddInParameter(dbCommand, "chin_date3", DbType.DateTime, data.chin_date3);

                db.AddInParameter(dbCommand, "chin_madeby", DbType.Int32, data.chin_madeby);
                db.AddInParameter(dbCommand, "chin_modifyby", DbType.Int32, data.chin_madeby);

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
        public static int DeleteHealthInternational(int chinId, int chin_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_INT_NEW_delete");

                db.AddInParameter(dbCommand, "chinId", DbType.Int32, chinId);
                db.AddInParameter(dbCommand, "chin_modifyby", DbType.String, chin_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class NasDental
    {
        public static DataTable GetPrintNasDental(int? cndnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DENTAL_NEW_Print");
                if (cndnId > 0)
                {
                    db.AddInParameter(dbCommand, "cndnId", DbType.Int32, cndnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNasDental(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DENTAL_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNasDental(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DENTAL_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNasDental(BusinessEntities.EMRForms.NasDental data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DENTAL_NEW_INSERT_UPDATE");
                if (data.cndnId > 0)
                {
                    db.AddInParameter(dbCommand, "cndnId", DbType.Int32, data.cndnId);
                }
                db.AddInParameter(dbCommand, "cndn_appId", DbType.Int32, data.cndn_appId);
                db.AddInParameter(dbCommand, "cndn_chk", DbType.String, data.cndn_chk);
                db.AddInParameter(dbCommand, "cndn_1", DbType.String, data.cndn_1);
                db.AddInParameter(dbCommand, "cndn_2", DbType.String, data.cndn_2);
                db.AddInParameter(dbCommand, "cndn_3", DbType.String, data.cndn_3);
                db.AddInParameter(dbCommand, "cndn_4", DbType.String, data.cndn_4);
                db.AddInParameter(dbCommand, "cndn_5", DbType.String, data.cndn_5);
                db.AddInParameter(dbCommand, "cndn_6", DbType.String, data.cndn_6);
                db.AddInParameter(dbCommand, "cndn_7", DbType.String, data.cndn_7);

                db.AddInParameter(dbCommand, "cndn_madeby", DbType.Int32, data.cndn_madeby);
                db.AddInParameter(dbCommand, "cndn_modifyby", DbType.Int32, data.cndn_madeby);

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
        public static int DeleteNasDental(int cndnId, int cndn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DENTAL_NEW_delete");

                db.AddInParameter(dbCommand, "cndnId", DbType.Int32, cndnId);
                db.AddInParameter(dbCommand, "cndn_modifyby", DbType.String, cndn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class NasPrescription
    {
        public static DataTable GetPrintNasPrescription(int? cnrnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_PRESCRIPTION_NEW_Print");
                if (cnrnId > 0)
                {
                    db.AddInParameter(dbCommand, "cnrnId", DbType.Int32, cnrnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNasPrescription(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_PRESCRIPTION_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNasPrescription(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_PRESCRIPTION_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNasPrescription(BusinessEntities.EMRForms.NasPrescription data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_PRESCRIPTION_NEW_INSERT_UPDATE");
                if (data.cnrnId > 0)
                {
                    db.AddInParameter(dbCommand, "cnrnId", DbType.Int32, data.cnrnId);
                }
                db.AddInParameter(dbCommand, "cnrn_appId", DbType.Int32, data.cnrn_appId);
                db.AddInParameter(dbCommand, "cnrn_chk", DbType.String, data.cnrn_chk);
                db.AddInParameter(dbCommand, "cnrn_1", DbType.String, data.cnrn_1);
                db.AddInParameter(dbCommand, "cnrn_2", DbType.String, data.cnrn_2);
                db.AddInParameter(dbCommand, "cnrn_3", DbType.String, data.cnrn_3);
                db.AddInParameter(dbCommand, "cnrn_4", DbType.String, data.cnrn_4);
                db.AddInParameter(dbCommand, "cnrn_5", DbType.String, data.cnrn_5);
                db.AddInParameter(dbCommand, "cnrn_6", DbType.String, data.cnrn_6);

                db.AddInParameter(dbCommand, "cnrn_madeby", DbType.Int32, data.cnrn_madeby);
                db.AddInParameter(dbCommand, "cnrn_modifyby", DbType.Int32, data.cnrn_madeby);

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
        public static int DeleteNasPrescription(int cnrnId, int cnrn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_PRESCRIPTION_NEW_delete");

                db.AddInParameter(dbCommand, "cnrnId", DbType.Int32, cnrnId);
                db.AddInParameter(dbCommand, "cnrn_modifyby", DbType.String, cnrn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class OmanDental
    {
        public static DataTable GetPrintOmanDental(int? codnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_DENTAL_NEW_Print");
                if (codnId > 0)
                {
                    db.AddInParameter(dbCommand, "codnId", DbType.Int32, codnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllOmanDental(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_DENTAL_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreOmanDental(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_DENTAL_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateOmanDental(BusinessEntities.EMRForms.OmanDental data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_DENTAL_NEW_INSERT_UPDATE");
                if (data.codnId > 0)
                {
                    db.AddInParameter(dbCommand, "codnId", DbType.Int32, data.codnId);
                }
                db.AddInParameter(dbCommand, "codn_appId", DbType.Int32, data.codn_appId);
                db.AddInParameter(dbCommand, "codn_checkbox", DbType.String, data.codn_checkbox);
                db.AddInParameter(dbCommand, "codn_1", DbType.String, data.codn_1);
                db.AddInParameter(dbCommand, "codn_2", DbType.String, data.codn_2);
                db.AddInParameter(dbCommand, "codn_3", DbType.String, data.codn_3);
                db.AddInParameter(dbCommand, "codn_4", DbType.String, data.codn_4);
                db.AddInParameter(dbCommand, "codn_5", DbType.String, data.codn_5);
                db.AddInParameter(dbCommand, "codn_6", DbType.String, data.codn_6);
                db.AddInParameter(dbCommand, "codn_7", DbType.String, data.codn_7);
                db.AddInParameter(dbCommand, "codn_8", DbType.String, data.codn_8);
                db.AddInParameter(dbCommand, "codn_9", DbType.String, data.codn_9);
                db.AddInParameter(dbCommand, "codn_10", DbType.String, data.codn_10);
                db.AddInParameter(dbCommand, "codn_11", DbType.String, data.codn_11);
                db.AddInParameter(dbCommand, "codn_12", DbType.String, data.codn_12);
                db.AddInParameter(dbCommand, "codn_13", DbType.String, data.codn_13);
                db.AddInParameter(dbCommand, "codn_14", DbType.String, data.codn_14);
                db.AddInParameter(dbCommand, "codn_15", DbType.String, data.codn_15);
                db.AddInParameter(dbCommand, "codn_16", DbType.String, data.codn_16);
                db.AddInParameter(dbCommand, "codn_17", DbType.String, data.codn_17);
                db.AddInParameter(dbCommand, "codn_18", DbType.String, data.codn_18);
                db.AddInParameter(dbCommand, "codn_19", DbType.String, data.codn_19);
                db.AddInParameter(dbCommand, "codn_20", DbType.String, data.codn_20);
                db.AddInParameter(dbCommand, "codn_21", DbType.String, data.codn_21);
                db.AddInParameter(dbCommand, "codn_22", DbType.String, data.codn_22);
                db.AddInParameter(dbCommand, "codn_23", DbType.String, data.codn_23);
                db.AddInParameter(dbCommand, "codn_24", DbType.String, data.codn_24);
                db.AddInParameter(dbCommand, "codn_25", DbType.String, data.codn_25);
                db.AddInParameter(dbCommand, "codn_26", DbType.String, data.codn_26);
                db.AddInParameter(dbCommand, "codn_27", DbType.String, data.codn_27);
                db.AddInParameter(dbCommand, "codn_28", DbType.String, data.codn_28);
                db.AddInParameter(dbCommand, "codn_29", DbType.String, data.codn_29);
                db.AddInParameter(dbCommand, "codn_30", DbType.String, data.codn_30);
                db.AddInParameter(dbCommand, "codn_31", DbType.String, data.codn_31);
                db.AddInParameter(dbCommand, "codn_32", DbType.String, data.codn_32);
                db.AddInParameter(dbCommand, "codn_33", DbType.String, data.codn_33);
                db.AddInParameter(dbCommand, "codn_34", DbType.String, data.codn_34);
                db.AddInParameter(dbCommand, "codn_35", DbType.String, data.codn_35);
                db.AddInParameter(dbCommand, "codn_36", DbType.String, data.codn_36);
                db.AddInParameter(dbCommand, "codn_37", DbType.String, data.codn_37);
                db.AddInParameter(dbCommand, "codn_38", DbType.String, data.codn_38);
                db.AddInParameter(dbCommand, "codn_39", DbType.String, data.codn_39);
                db.AddInParameter(dbCommand, "codn_40", DbType.String, data.codn_40);
                db.AddInParameter(dbCommand, "codn_41", DbType.String, data.codn_41);
                db.AddInParameter(dbCommand, "codn_42", DbType.String, data.codn_42);
                db.AddInParameter(dbCommand, "codn_43", DbType.String, data.codn_43);
                db.AddInParameter(dbCommand, "codn_44", DbType.String, data.codn_44);
                db.AddInParameter(dbCommand, "codn_45", DbType.String, data.codn_45);
                db.AddInParameter(dbCommand, "codn_46", DbType.String, data.codn_46);
                db.AddInParameter(dbCommand, "codn_47", DbType.String, data.codn_47);
                db.AddInParameter(dbCommand, "codn_48", DbType.String, data.codn_48);
                db.AddInParameter(dbCommand, "codn_49", DbType.String, data.codn_49);
                db.AddInParameter(dbCommand, "codn_50", DbType.String, data.codn_50);
                db.AddInParameter(dbCommand, "codn_51", DbType.String, data.codn_51);
                db.AddInParameter(dbCommand, "codn_52", DbType.String, data.codn_52);
                db.AddInParameter(dbCommand, "codn_53", DbType.String, data.codn_53);
                db.AddInParameter(dbCommand, "codn_54", DbType.String, data.codn_54);
                db.AddInParameter(dbCommand, "codn_55", DbType.String, data.codn_55);
                db.AddInParameter(dbCommand, "codn_56", DbType.String, data.codn_56);
                db.AddInParameter(dbCommand, "codn_57", DbType.String, data.codn_57);
                db.AddInParameter(dbCommand, "codn_58", DbType.String, data.codn_58);
                db.AddInParameter(dbCommand, "codn_59", DbType.String, data.codn_59);
                db.AddInParameter(dbCommand, "codn_60", DbType.String, data.codn_60);
                db.AddInParameter(dbCommand, "codn_61", DbType.String, data.codn_61);
                db.AddInParameter(dbCommand, "codn_62", DbType.String, data.codn_62);
                db.AddInParameter(dbCommand, "codn_63", DbType.String, data.codn_63);
                db.AddInParameter(dbCommand, "codn_64", DbType.String, data.codn_64);
                db.AddInParameter(dbCommand, "codn_65", DbType.String, data.codn_65);
                db.AddInParameter(dbCommand, "codn_66", DbType.String, data.codn_66);
                db.AddInParameter(dbCommand, "codn_67", DbType.String, data.codn_67);
                db.AddInParameter(dbCommand, "codn_date1", DbType.DateTime, data.codn_date1);

                db.AddInParameter(dbCommand, "codn_madeby", DbType.Int32, data.codn_madeby);
                db.AddInParameter(dbCommand, "codn_modifyby", DbType.Int32, data.codn_madeby);

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
        public static int DeleteOmanDental(int codnId, int codn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_DENTAL_NEW_delete");

                db.AddInParameter(dbCommand, "codnId", DbType.Int32, codnId);
                db.AddInParameter(dbCommand, "codn_modifyby", DbType.String, codn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class NasDarAlTakaful
    {
        public static DataTable GetPrintNasDarAlTakaful(int? ndtnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DARAL_TAKAFUL_NEW_Print");
                if (ndtnId > 0)
                {
                    db.AddInParameter(dbCommand, "ndtnId", DbType.Int32, ndtnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNasDarAlTakaful(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DARAL_TAKAFUL_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNasDarAlTakaful(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DARAL_TAKAFUL_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNasDarAlTakaful(BusinessEntities.EMRForms.NasDarAlTakaful data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DARAL_TAKAFUL_NEW_INSERT_UPDATE");
                if (data.ndtnId > 0)
                {
                    db.AddInParameter(dbCommand, "ndtnId", DbType.Int32, data.ndtnId);
                }
                db.AddInParameter(dbCommand, "ndtn_appId", DbType.Int32, data.ndtn_appId);
                db.AddInParameter(dbCommand, "ndtn_checkbox", DbType.String, data.ndtn_checkbox);
                db.AddInParameter(dbCommand, "ndtn_1", DbType.String, data.ndtn_1);
                db.AddInParameter(dbCommand, "ndtn_2", DbType.String, data.ndtn_2);
                db.AddInParameter(dbCommand, "ndtn_3", DbType.String, data.ndtn_3);
                db.AddInParameter(dbCommand, "ndtn_4", DbType.String, data.ndtn_4);
                db.AddInParameter(dbCommand, "ndtn_5", DbType.String, data.ndtn_5);
                db.AddInParameter(dbCommand, "ndtn_6", DbType.String, data.ndtn_6);
                db.AddInParameter(dbCommand, "ndtn_7", DbType.String, data.ndtn_7);
                db.AddInParameter(dbCommand, "ndtn_8", DbType.String, data.ndtn_8);
                db.AddInParameter(dbCommand, "ndtn_9", DbType.String, data.ndtn_9);
                db.AddInParameter(dbCommand, "ndtn_10", DbType.String, data.ndtn_10);
                db.AddInParameter(dbCommand, "ndtn_11", DbType.String, data.ndtn_11);
                db.AddInParameter(dbCommand, "ndtn_12", DbType.String, data.ndtn_12);
                db.AddInParameter(dbCommand, "ndtn_13", DbType.String, data.ndtn_13);
                db.AddInParameter(dbCommand, "ndtn_14", DbType.String, data.ndtn_14);
                db.AddInParameter(dbCommand, "ndtn_15", DbType.String, data.ndtn_15);
                db.AddInParameter(dbCommand, "ndtn_16", DbType.String, data.ndtn_16);
                db.AddInParameter(dbCommand, "ndtn_17", DbType.String, data.ndtn_17);
                db.AddInParameter(dbCommand, "ndtn_18", DbType.String, data.ndtn_18);
                db.AddInParameter(dbCommand, "ndtn_19", DbType.String, data.ndtn_19);
                db.AddInParameter(dbCommand, "ndtn_20", DbType.String, data.ndtn_20);
                db.AddInParameter(dbCommand, "ndtn_21", DbType.String, data.ndtn_21);
                db.AddInParameter(dbCommand, "ndtn_22", DbType.String, data.ndtn_22);
                db.AddInParameter(dbCommand, "ndtn_23", DbType.String, data.ndtn_23);
                db.AddInParameter(dbCommand, "ndtn_24", DbType.String, data.ndtn_24);
                db.AddInParameter(dbCommand, "ndtn_25", DbType.String, data.ndtn_25);
                db.AddInParameter(dbCommand, "ndtn_26", DbType.String, data.ndtn_26);
                db.AddInParameter(dbCommand, "ndtn_27", DbType.String, data.ndtn_27);
                db.AddInParameter(dbCommand, "ndtn_28", DbType.String, data.ndtn_28);
                db.AddInParameter(dbCommand, "ndtn_29", DbType.String, data.ndtn_29);
                db.AddInParameter(dbCommand, "ndtn_30", DbType.String, data.ndtn_30);
                db.AddInParameter(dbCommand, "ndtn_31", DbType.String, data.ndtn_31);
                db.AddInParameter(dbCommand, "ndtn_32", DbType.String, data.ndtn_32);
                db.AddInParameter(dbCommand, "ndtn_33", DbType.String, data.ndtn_33);
                db.AddInParameter(dbCommand, "ndtn_34", DbType.String, data.ndtn_34);
                db.AddInParameter(dbCommand, "ndtn_35", DbType.String, data.ndtn_35);
                db.AddInParameter(dbCommand, "ndtn_36", DbType.String, data.ndtn_36);
                db.AddInParameter(dbCommand, "ndtn_37", DbType.String, data.ndtn_37);
                db.AddInParameter(dbCommand, "ndtn_38", DbType.String, data.ndtn_38);
                db.AddInParameter(dbCommand, "ndtn_39", DbType.String, data.ndtn_39);
                db.AddInParameter(dbCommand, "ndtn_40", DbType.String, data.ndtn_40);
                db.AddInParameter(dbCommand, "ndtn_41", DbType.String, data.ndtn_41);
                db.AddInParameter(dbCommand, "ndtn_42", DbType.String, data.ndtn_42);
                db.AddInParameter(dbCommand, "ndtn_43", DbType.String, data.ndtn_43);

                db.AddInParameter(dbCommand, "ndtn_madeby", DbType.Int32, data.ndtn_madeby);
                db.AddInParameter(dbCommand, "ndtn_modifyby", DbType.Int32, data.ndtn_madeby);

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
        public static int DeleteNasDarAlTakaful(int ndtnId, int ndtn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_DARAL_TAKAFUL_NEW_delete");

                db.AddInParameter(dbCommand, "ndtnId", DbType.Int32, ndtnId);
                db.AddInParameter(dbCommand, "ndtn_modifyby", DbType.String, ndtn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class OmanInsurance
    {
        public static DataTable GetPrintOmanInsurance(int? cornId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_REMB_NEW_Print");
                if (cornId > 0)
                {
                    db.AddInParameter(dbCommand, "cornId", DbType.Int32, cornId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllOmanInsurance(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_REMB_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreOmanInsurance(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_REMB_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateOmanInsurance(BusinessEntities.EMRForms.OmanInsurance data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_REMB_NEW_INSERT_UPDATE");
                if (data.cornId > 0)
                {
                    db.AddInParameter(dbCommand, "cornId", DbType.Int32, data.cornId);
                }
                db.AddInParameter(dbCommand, "corn_appId", DbType.Int32, data.corn_appId);
                db.AddInParameter(dbCommand, "corn_checkbox", DbType.String, data.corn_checkbox);
                db.AddInParameter(dbCommand, "corn_1", DbType.String, data.corn_1);
                db.AddInParameter(dbCommand, "corn_2", DbType.String, data.corn_2);
                db.AddInParameter(dbCommand, "corn_3", DbType.String, data.corn_3);
                db.AddInParameter(dbCommand, "corn_4", DbType.String, data.corn_4);
                db.AddInParameter(dbCommand, "corn_5", DbType.String, data.corn_5);
                db.AddInParameter(dbCommand, "corn_6", DbType.String, data.corn_6);
                db.AddInParameter(dbCommand, "corn_7", DbType.String, data.corn_7);
                db.AddInParameter(dbCommand, "corn_8", DbType.String, data.corn_8);
                db.AddInParameter(dbCommand, "corn_9", DbType.String, data.corn_9);
                db.AddInParameter(dbCommand, "corn_10", DbType.String, data.corn_10);
                db.AddInParameter(dbCommand, "corn_11", DbType.String, data.corn_11);
                db.AddInParameter(dbCommand, "corn_12", DbType.String, data.corn_12);
                db.AddInParameter(dbCommand, "corn_13", DbType.String, data.corn_13);
                db.AddInParameter(dbCommand, "corn_14", DbType.String, data.corn_14);
                db.AddInParameter(dbCommand, "corn_15", DbType.String, data.corn_15);
                db.AddInParameter(dbCommand, "corn_16", DbType.String, data.corn_16);
                db.AddInParameter(dbCommand, "corn_17", DbType.String, data.corn_17);
                db.AddInParameter(dbCommand, "corn_18", DbType.String, data.corn_18);
                db.AddInParameter(dbCommand, "corn_19", DbType.String, data.corn_19);
                db.AddInParameter(dbCommand, "corn_20", DbType.String, data.corn_20);
                db.AddInParameter(dbCommand, "corn_21", DbType.String, data.corn_21);
                db.AddInParameter(dbCommand, "corn_22", DbType.String, data.corn_22);
                db.AddInParameter(dbCommand, "corn_23", DbType.String, data.corn_23);
                db.AddInParameter(dbCommand, "corn_24", DbType.String, data.corn_24);
                db.AddInParameter(dbCommand, "corn_25", DbType.String, data.corn_25);
                db.AddInParameter(dbCommand, "corn_26", DbType.String, data.corn_26);
                db.AddInParameter(dbCommand, "corn_27", DbType.String, data.corn_27);
                db.AddInParameter(dbCommand, "corn_28", DbType.String, data.corn_28);
                db.AddInParameter(dbCommand, "corn_29", DbType.String, data.corn_29);
                db.AddInParameter(dbCommand, "corn_30", DbType.String, data.corn_30);
                db.AddInParameter(dbCommand, "corn_31", DbType.String, data.corn_31);
                db.AddInParameter(dbCommand, "corn_32", DbType.String, data.corn_32);
                db.AddInParameter(dbCommand, "corn_33", DbType.String, data.corn_33);
                db.AddInParameter(dbCommand, "corn_34", DbType.String, data.corn_34);
                db.AddInParameter(dbCommand, "corn_35", DbType.String, data.corn_35);
                db.AddInParameter(dbCommand, "corn_36", DbType.String, data.corn_36);
                db.AddInParameter(dbCommand, "corn_37", DbType.String, data.corn_37);
                db.AddInParameter(dbCommand, "corn_38", DbType.String, data.corn_38);
                db.AddInParameter(dbCommand, "corn_39", DbType.String, data.corn_39);
                db.AddInParameter(dbCommand, "corn_40", DbType.String, data.corn_40);
                db.AddInParameter(dbCommand, "corn_41", DbType.String, data.corn_41);
                db.AddInParameter(dbCommand, "corn_42", DbType.String, data.corn_42);
                db.AddInParameter(dbCommand, "corn_43", DbType.String, data.corn_43);
                db.AddInParameter(dbCommand, "corn_44", DbType.String, data.corn_44);
                db.AddInParameter(dbCommand, "corn_45", DbType.String, data.corn_45);
                db.AddInParameter(dbCommand, "corn_46", DbType.String, data.corn_46);
                db.AddInParameter(dbCommand, "corn_47", DbType.String, data.corn_47);
                db.AddInParameter(dbCommand, "corn_48", DbType.String, data.corn_48);
                db.AddInParameter(dbCommand, "corn_49", DbType.String, data.corn_49);
                db.AddInParameter(dbCommand, "corn_50", DbType.String, data.corn_50);
                db.AddInParameter(dbCommand, "corn_51", DbType.String, data.corn_51);
                db.AddInParameter(dbCommand, "corn_52", DbType.String, data.corn_52);
                db.AddInParameter(dbCommand, "corn_53", DbType.String, data.corn_53);
                db.AddInParameter(dbCommand, "corn_54", DbType.String, data.corn_54);
                db.AddInParameter(dbCommand, "corn_55", DbType.String, data.corn_55);
                db.AddInParameter(dbCommand, "corn_56", DbType.String, data.corn_56);
                db.AddInParameter(dbCommand, "corn_57", DbType.String, data.corn_57);
                db.AddInParameter(dbCommand, "corn_58", DbType.String, data.corn_58);
                db.AddInParameter(dbCommand, "corn_59", DbType.String, data.corn_59);
                db.AddInParameter(dbCommand, "corn_60", DbType.String, data.corn_60);
                db.AddInParameter(dbCommand, "corn_61", DbType.String, data.corn_61);
                db.AddInParameter(dbCommand, "corn_62", DbType.String, data.corn_62);
                db.AddInParameter(dbCommand, "corn_63", DbType.String, data.corn_63);
                db.AddInParameter(dbCommand, "corn_64", DbType.String, data.corn_64);
                db.AddInParameter(dbCommand, "corn_65", DbType.String, data.corn_65);
                db.AddInParameter(dbCommand, "corn_66", DbType.String, data.corn_66);
                db.AddInParameter(dbCommand, "corn_67", DbType.String, data.corn_67);
                db.AddInParameter(dbCommand, "corn_date1", DbType.DateTime, data.corn_date1);

                db.AddInParameter(dbCommand, "corn_madeby", DbType.Int32, data.corn_madeby);
                db.AddInParameter(dbCommand, "corn_modifyby", DbType.Int32, data.corn_madeby);

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
        public static int DeleteOmanInsurance(int cornId, int corn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_OMAN_REMB_NEW_delete");

                db.AddInParameter(dbCommand, "cornId", DbType.Int32, cornId);
                db.AddInParameter(dbCommand, "corn_modifyby", DbType.String, corn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class Union
    {
        public static DataTable GetPrintUnion(int? curnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UNION_REMB_NEW_Print");
                if (curnId > 0)
                {
                    db.AddInParameter(dbCommand, "curnId", DbType.Int32, curnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllUnion(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UNION_REMB_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreUnion(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UNION_REMB_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateUnion(BusinessEntities.EMRForms.Union data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UNION_REMB_NEW_INSERT_UPDATE");
                if (data.curnId > 0)
                {
                    db.AddInParameter(dbCommand, "curnId", DbType.Int32, data.curnId);
                }
                db.AddInParameter(dbCommand, "curn_appId", DbType.Int32, data.curn_appId);
                db.AddInParameter(dbCommand, "curn_checkbox", DbType.String, data.curn_checkbox);
                db.AddInParameter(dbCommand, "curn_1", DbType.String, data.curn_1);
                db.AddInParameter(dbCommand, "curn_2", DbType.String, data.curn_2);
                db.AddInParameter(dbCommand, "curn_3", DbType.String, data.curn_3);
                db.AddInParameter(dbCommand, "curn_4", DbType.String, data.curn_4);
                db.AddInParameter(dbCommand, "curn_5", DbType.String, data.curn_5);
                db.AddInParameter(dbCommand, "curn_6", DbType.String, data.curn_6);
                db.AddInParameter(dbCommand, "curn_7", DbType.String, data.curn_7);
                db.AddInParameter(dbCommand, "curn_8", DbType.String, data.curn_8);
                db.AddInParameter(dbCommand, "curn_9", DbType.String, data.curn_9);
                db.AddInParameter(dbCommand, "curn_10", DbType.String, data.curn_10);
                db.AddInParameter(dbCommand, "curn_11", DbType.String, data.curn_11);
                db.AddInParameter(dbCommand, "curn_12", DbType.String, data.curn_12);
                db.AddInParameter(dbCommand, "curn_13", DbType.String, data.curn_13);
                db.AddInParameter(dbCommand, "curn_14", DbType.String, data.curn_14);
                db.AddInParameter(dbCommand, "curn_15", DbType.String, data.curn_15);
                db.AddInParameter(dbCommand, "curn_16", DbType.String, data.curn_16);
                db.AddInParameter(dbCommand, "curn_17", DbType.String, data.curn_17);
                db.AddInParameter(dbCommand, "curn_18", DbType.String, data.curn_18);
                db.AddInParameter(dbCommand, "curn_19", DbType.String, data.curn_19);
                db.AddInParameter(dbCommand, "curn_20", DbType.String, data.curn_20);
                db.AddInParameter(dbCommand, "curn_21", DbType.String, data.curn_21);
                db.AddInParameter(dbCommand, "curn_22", DbType.String, data.curn_22);
                db.AddInParameter(dbCommand, "curn_23", DbType.String, data.curn_23);
                db.AddInParameter(dbCommand, "curn_24", DbType.String, data.curn_24);
                db.AddInParameter(dbCommand, "curn_25", DbType.String, data.curn_25);
                db.AddInParameter(dbCommand, "curn_26", DbType.String, data.curn_26);
                db.AddInParameter(dbCommand, "curn_27", DbType.String, data.curn_27);
                db.AddInParameter(dbCommand, "curn_28", DbType.String, data.curn_28);
                db.AddInParameter(dbCommand, "curn_29", DbType.String, data.curn_29);
                db.AddInParameter(dbCommand, "curn_30", DbType.String, data.curn_30);
                db.AddInParameter(dbCommand, "curn_31", DbType.String, data.curn_31);
                db.AddInParameter(dbCommand, "curn_32", DbType.String, data.curn_32);
                db.AddInParameter(dbCommand, "curn_33", DbType.String, data.curn_33);
                db.AddInParameter(dbCommand, "curn_34", DbType.String, data.curn_34);
                db.AddInParameter(dbCommand, "curn_35", DbType.String, data.curn_35);
                db.AddInParameter(dbCommand, "curn_36", DbType.String, data.curn_36);
                db.AddInParameter(dbCommand, "curn_37", DbType.String, data.curn_37);
                db.AddInParameter(dbCommand, "curn_38", DbType.String, data.curn_38);
                db.AddInParameter(dbCommand, "curn_39", DbType.String, data.curn_39);
                db.AddInParameter(dbCommand, "curn_40", DbType.String, data.curn_40);
                db.AddInParameter(dbCommand, "curn_date1", DbType.DateTime, data.curn_date1);
                db.AddInParameter(dbCommand, "curn_date2", DbType.DateTime, data.curn_date2);
                db.AddInParameter(dbCommand, "curn_date3", DbType.DateTime, data.curn_date3);

                db.AddInParameter(dbCommand, "curn_madeby", DbType.Int32, data.curn_madeby);
                db.AddInParameter(dbCommand, "curn_modifyby", DbType.Int32, data.curn_madeby);

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
        public static int DeleteUnion(int curnId, int curn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UNION_REMB_NEW_delete");

                db.AddInParameter(dbCommand, "curnId", DbType.Int32, curnId);
                db.AddInParameter(dbCommand, "curn_modifyby", DbType.String, curn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class NextcareOrient
    {
        public static DataTable GetPrintNextcareOrient(int? cnonId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ORIENT_NEW_Print");
                if (cnonId > 0)
                {
                    db.AddInParameter(dbCommand, "cnonId", DbType.Int32, cnonId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNextcareOrient(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ORIENT_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNextcareOrient(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ORIENT_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNextcareOrient(BusinessEntities.EMRForms.NextcareOrient data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ORIENT_NEW_INSERT_UPDATE");
                if (data.cnonId > 0)
                {
                    db.AddInParameter(dbCommand, "cnonId", DbType.Int32, data.cnonId);
                }
                db.AddInParameter(dbCommand, "cnon_appId", DbType.Int32, data.cnon_appId);
                db.AddInParameter(dbCommand, "cnon_checkbox", DbType.String, data.cnon_checkbox);
                db.AddInParameter(dbCommand, "cnon_1", DbType.String, data.cnon_1);
                db.AddInParameter(dbCommand, "cnon_2", DbType.String, data.cnon_2);
                db.AddInParameter(dbCommand, "cnon_3", DbType.String, data.cnon_3);
                db.AddInParameter(dbCommand, "cnon_4", DbType.String, data.cnon_4);
                db.AddInParameter(dbCommand, "cnon_5", DbType.String, data.cnon_5);
                db.AddInParameter(dbCommand, "cnon_6", DbType.String, data.cnon_6);
                db.AddInParameter(dbCommand, "cnon_7", DbType.String, data.cnon_7);
                db.AddInParameter(dbCommand, "cnon_8", DbType.String, data.cnon_8);
                db.AddInParameter(dbCommand, "cnon_9", DbType.String, data.cnon_9);
                db.AddInParameter(dbCommand, "cnon_10", DbType.String, data.cnon_10);
                db.AddInParameter(dbCommand, "cnon_11", DbType.String, data.cnon_11);
                db.AddInParameter(dbCommand, "cnon_12", DbType.String, data.cnon_12);
                db.AddInParameter(dbCommand, "cnon_13", DbType.String, data.cnon_13);
                db.AddInParameter(dbCommand, "cnon_14", DbType.String, data.cnon_14);
                db.AddInParameter(dbCommand, "cnon_15", DbType.String, data.cnon_15);
                db.AddInParameter(dbCommand, "cnon_16", DbType.String, data.cnon_16);
                db.AddInParameter(dbCommand, "cnon_17", DbType.String, data.cnon_17);
                db.AddInParameter(dbCommand, "cnon_18", DbType.String, data.cnon_18);
                db.AddInParameter(dbCommand, "cnon_19", DbType.String, data.cnon_19);
                db.AddInParameter(dbCommand, "cnon_20", DbType.String, data.cnon_20);
                db.AddInParameter(dbCommand, "cnon_21", DbType.String, data.cnon_21);
                db.AddInParameter(dbCommand, "cnon_22", DbType.String, data.cnon_22);
                db.AddInParameter(dbCommand, "cnon_23", DbType.String, data.cnon_23);
                db.AddInParameter(dbCommand, "cnon_24", DbType.String, data.cnon_24);
                db.AddInParameter(dbCommand, "cnon_25", DbType.String, data.cnon_25);
                db.AddInParameter(dbCommand, "cnon_26", DbType.String, data.cnon_26);
                db.AddInParameter(dbCommand, "cnon_27", DbType.String, data.cnon_27);
                db.AddInParameter(dbCommand, "cnon_28", DbType.String, data.cnon_28);
                db.AddInParameter(dbCommand, "cnon_29", DbType.String, data.cnon_29);
                db.AddInParameter(dbCommand, "cnon_30", DbType.String, data.cnon_30);
                db.AddInParameter(dbCommand, "cnon_31", DbType.String, data.cnon_31);
                db.AddInParameter(dbCommand, "cnon_32", DbType.String, data.cnon_32);
                db.AddInParameter(dbCommand, "cnon_33", DbType.String, data.cnon_33);
                db.AddInParameter(dbCommand, "cnon_34", DbType.String, data.cnon_34);
                db.AddInParameter(dbCommand, "cnon_35", DbType.String, data.cnon_35);
                db.AddInParameter(dbCommand, "cnon_36", DbType.String, data.cnon_36);
                db.AddInParameter(dbCommand, "cnon_37", DbType.String, data.cnon_37);
                db.AddInParameter(dbCommand, "cnon_38", DbType.String, data.cnon_38);
                db.AddInParameter(dbCommand, "cnon_39", DbType.String, data.cnon_39);
                db.AddInParameter(dbCommand, "cnon_40", DbType.String, data.cnon_40);
                db.AddInParameter(dbCommand, "cnon_41", DbType.String, data.cnon_41);
                db.AddInParameter(dbCommand, "cnon_date1", DbType.DateTime, data.cnon_date1);
                db.AddInParameter(dbCommand, "cnon_date2", DbType.DateTime, data.cnon_date2);
                db.AddInParameter(dbCommand, "cnon_date3", DbType.DateTime, data.cnon_date3);

                db.AddInParameter(dbCommand, "cnon_madeby", DbType.Int32, data.cnon_madeby);
                db.AddInParameter(dbCommand, "cnon_modifyby", DbType.Int32, data.cnon_madeby);

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
        public static int DeleteNextcareOrient(int cnonId, int cnon_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ORIENT_NEW_delete");

                db.AddInParameter(dbCommand, "cnonId", DbType.Int32, cnonId);
                db.AddInParameter(dbCommand, "cnon_modifyby", DbType.String, cnon_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class NextcareMajid
    {
        public static DataTable GetPrintNextcareMajid(int? cnmnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_MAJID_NEW_Print");
                if (cnmnId > 0)
                {
                    db.AddInParameter(dbCommand, "cnmnId", DbType.Int32, cnmnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNextcareMajid(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_MAJID_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNextcareMajid(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_MAJID_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNextcareMajid(BusinessEntities.EMRForms.NextcareMajid data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_MAJID_NEW_INSERT_UPDATE");
                if (data.cnmnId > 0)
                {
                    db.AddInParameter(dbCommand, "cnmnId", DbType.Int32, data.cnmnId);
                }
                db.AddInParameter(dbCommand, "cnmn_appId", DbType.Int32, data.cnmn_appId);
                db.AddInParameter(dbCommand, "cnmn_checkbox", DbType.String, data.cnmn_checkbox);
                db.AddInParameter(dbCommand, "cnmn_1", DbType.String, data.cnmn_1);
                db.AddInParameter(dbCommand, "cnmn_2", DbType.String, data.cnmn_2);
                db.AddInParameter(dbCommand, "cnmn_3", DbType.String, data.cnmn_3);
                db.AddInParameter(dbCommand, "cnmn_4", DbType.String, data.cnmn_4);
                db.AddInParameter(dbCommand, "cnmn_5", DbType.String, data.cnmn_5);
                db.AddInParameter(dbCommand, "cnmn_6", DbType.String, data.cnmn_6);
                db.AddInParameter(dbCommand, "cnmn_7", DbType.String, data.cnmn_7);
                db.AddInParameter(dbCommand, "cnmn_8", DbType.String, data.cnmn_8);
                db.AddInParameter(dbCommand, "cnmn_9", DbType.String, data.cnmn_9);
                db.AddInParameter(dbCommand, "cnmn_10", DbType.String, data.cnmn_10);
                db.AddInParameter(dbCommand, "cnmn_11", DbType.String, data.cnmn_11);
                db.AddInParameter(dbCommand, "cnmn_12", DbType.String, data.cnmn_12);
                db.AddInParameter(dbCommand, "cnmn_13", DbType.String, data.cnmn_13);
                db.AddInParameter(dbCommand, "cnmn_14", DbType.String, data.cnmn_14);
                db.AddInParameter(dbCommand, "cnmn_15", DbType.String, data.cnmn_15);
                db.AddInParameter(dbCommand, "cnmn_16", DbType.String, data.cnmn_16);
                db.AddInParameter(dbCommand, "cnmn_17", DbType.String, data.cnmn_17);
                db.AddInParameter(dbCommand, "cnmn_18", DbType.String, data.cnmn_18);
                db.AddInParameter(dbCommand, "cnmn_19", DbType.String, data.cnmn_19);
                db.AddInParameter(dbCommand, "cnmn_20", DbType.String, data.cnmn_20);
                db.AddInParameter(dbCommand, "cnmn_21", DbType.String, data.cnmn_21);
                db.AddInParameter(dbCommand, "cnmn_22", DbType.String, data.cnmn_22);
                db.AddInParameter(dbCommand, "cnmn_23", DbType.String, data.cnmn_23);
                db.AddInParameter(dbCommand, "cnmn_24", DbType.String, data.cnmn_24);
                db.AddInParameter(dbCommand, "cnmn_25", DbType.String, data.cnmn_25);
                db.AddInParameter(dbCommand, "cnmn_26", DbType.String, data.cnmn_26);
                db.AddInParameter(dbCommand, "cnmn_27", DbType.String, data.cnmn_27);
                db.AddInParameter(dbCommand, "cnmn_28", DbType.String, data.cnmn_28);
                db.AddInParameter(dbCommand, "cnmn_29", DbType.String, data.cnmn_29);
                db.AddInParameter(dbCommand, "cnmn_30", DbType.String, data.cnmn_30);
                db.AddInParameter(dbCommand, "cnmn_31", DbType.String, data.cnmn_31);
                db.AddInParameter(dbCommand, "cnmn_32", DbType.String, data.cnmn_32);
                db.AddInParameter(dbCommand, "cnmn_33", DbType.String, data.cnmn_33);
                db.AddInParameter(dbCommand, "cnmn_34", DbType.String, data.cnmn_34);
                db.AddInParameter(dbCommand, "cnmn_35", DbType.String, data.cnmn_35);
                db.AddInParameter(dbCommand, "cnmn_36", DbType.String, data.cnmn_36);
                db.AddInParameter(dbCommand, "cnmn_37", DbType.String, data.cnmn_37);
                db.AddInParameter(dbCommand, "cnmn_38", DbType.String, data.cnmn_38);
                db.AddInParameter(dbCommand, "cnmn_39", DbType.String, data.cnmn_39);
                db.AddInParameter(dbCommand, "cnmn_40", DbType.String, data.cnmn_40);
                db.AddInParameter(dbCommand, "cnmn_41", DbType.String, data.cnmn_41);
                db.AddInParameter(dbCommand, "cnmn_date1", DbType.DateTime, data.cnmn_date1);
                db.AddInParameter(dbCommand, "cnmn_date2", DbType.DateTime, data.cnmn_date2);
                db.AddInParameter(dbCommand, "cnmn_date3", DbType.DateTime, data.cnmn_date3);

                db.AddInParameter(dbCommand, "cnmn_madeby", DbType.Int32, data.cnmn_madeby);
                db.AddInParameter(dbCommand, "cnmn_modifyby", DbType.Int32, data.cnmn_madeby);

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
        public static int DeleteNextcareMajid(int cnmnId, int cnmn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_MAJID_NEW_delete");

                db.AddInParameter(dbCommand, "cnmnId", DbType.Int32, cnmnId);
                db.AddInParameter(dbCommand, "cnmn_modifyby", DbType.String, cnmn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class NextcareAsnic
    {
        public static DataTable GetPrintNextcareAsnic(int? cnanId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ASNIC_NEW_Print");
                if (cnanId > 0)
                {
                    db.AddInParameter(dbCommand, "cnanId", DbType.Int32, cnanId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNextcareAsnic(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ASNIC_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNextcareAsnic(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ASNIC_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNextcareAsnic(BusinessEntities.EMRForms.NextcareAsnic data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ASNIC_NEW_INSERT_UPDATE");
                if (data.cnanId > 0)
                {
                    db.AddInParameter(dbCommand, "cnanId", DbType.Int32, data.cnanId);
                }
                db.AddInParameter(dbCommand, "cnan_appId", DbType.Int32, data.cnan_appId);
                db.AddInParameter(dbCommand, "cnan_checkbox", DbType.String, data.cnan_checkbox);
                db.AddInParameter(dbCommand, "cnan_1", DbType.String, data.cnan_1);
                db.AddInParameter(dbCommand, "cnan_2", DbType.String, data.cnan_2);
                db.AddInParameter(dbCommand, "cnan_3", DbType.String, data.cnan_3);
                db.AddInParameter(dbCommand, "cnan_4", DbType.String, data.cnan_4);
                db.AddInParameter(dbCommand, "cnan_5", DbType.String, data.cnan_5);
                db.AddInParameter(dbCommand, "cnan_6", DbType.String, data.cnan_6);
                db.AddInParameter(dbCommand, "cnan_7", DbType.String, data.cnan_7);
                db.AddInParameter(dbCommand, "cnan_8", DbType.String, data.cnan_8);
                db.AddInParameter(dbCommand, "cnan_9", DbType.String, data.cnan_9);
                db.AddInParameter(dbCommand, "cnan_10", DbType.String, data.cnan_10);
                db.AddInParameter(dbCommand, "cnan_11", DbType.String, data.cnan_11);
                db.AddInParameter(dbCommand, "cnan_12", DbType.String, data.cnan_12);
                db.AddInParameter(dbCommand, "cnan_13", DbType.String, data.cnan_13);
                db.AddInParameter(dbCommand, "cnan_14", DbType.String, data.cnan_14);
                db.AddInParameter(dbCommand, "cnan_15", DbType.String, data.cnan_15);
                db.AddInParameter(dbCommand, "cnan_16", DbType.String, data.cnan_16);
                db.AddInParameter(dbCommand, "cnan_17", DbType.String, data.cnan_17);
                db.AddInParameter(dbCommand, "cnan_18", DbType.String, data.cnan_18);
                db.AddInParameter(dbCommand, "cnan_19", DbType.String, data.cnan_19);
                db.AddInParameter(dbCommand, "cnan_20", DbType.String, data.cnan_20);
                db.AddInParameter(dbCommand, "cnan_21", DbType.String, data.cnan_21);
                db.AddInParameter(dbCommand, "cnan_22", DbType.String, data.cnan_22);
                db.AddInParameter(dbCommand, "cnan_23", DbType.String, data.cnan_23);
                db.AddInParameter(dbCommand, "cnan_24", DbType.String, data.cnan_24);
                db.AddInParameter(dbCommand, "cnan_25", DbType.String, data.cnan_25);
                db.AddInParameter(dbCommand, "cnan_26", DbType.String, data.cnan_26);
                db.AddInParameter(dbCommand, "cnan_27", DbType.String, data.cnan_27);
                db.AddInParameter(dbCommand, "cnan_28", DbType.String, data.cnan_28);
                db.AddInParameter(dbCommand, "cnan_29", DbType.String, data.cnan_29);
                db.AddInParameter(dbCommand, "cnan_30", DbType.String, data.cnan_30);
                db.AddInParameter(dbCommand, "cnan_31", DbType.String, data.cnan_31);
                db.AddInParameter(dbCommand, "cnan_32", DbType.String, data.cnan_32);
                db.AddInParameter(dbCommand, "cnan_33", DbType.String, data.cnan_33);
                db.AddInParameter(dbCommand, "cnan_34", DbType.String, data.cnan_34);
                db.AddInParameter(dbCommand, "cnan_35", DbType.String, data.cnan_35);
                db.AddInParameter(dbCommand, "cnan_36", DbType.String, data.cnan_36);
                db.AddInParameter(dbCommand, "cnan_37", DbType.String, data.cnan_37);
                db.AddInParameter(dbCommand, "cnan_38", DbType.String, data.cnan_38);
                db.AddInParameter(dbCommand, "cnan_39", DbType.String, data.cnan_39);
                db.AddInParameter(dbCommand, "cnan_40", DbType.String, data.cnan_40);
                db.AddInParameter(dbCommand, "cnan_41", DbType.String, data.cnan_41);
                db.AddInParameter(dbCommand, "cnan_date1", DbType.DateTime, data.cnan_date1);
                db.AddInParameter(dbCommand, "cnan_date2", DbType.DateTime, data.cnan_date2);
                db.AddInParameter(dbCommand, "cnan_date3", DbType.DateTime, data.cnan_date3);

                db.AddInParameter(dbCommand, "cnan_madeby", DbType.Int32, data.cnan_madeby);
                db.AddInParameter(dbCommand, "cnan_modifyby", DbType.Int32, data.cnan_madeby);

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
        public static int DeleteNextcareAsnic(int cnanId, int cnan_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NEXTCARE_ASNIC_NEW_delete");

                db.AddInParameter(dbCommand, "cnanId", DbType.Int32, cnanId);
                db.AddInParameter(dbCommand, "cnan_modifyby", DbType.String, cnan_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Maxcare
    {
        public static DataTable GetPrintMaxcare(int? maxnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAXCARE_NEW_Print");
                if (maxnId > 0)
                {
                    db.AddInParameter(dbCommand, "maxnId", DbType.Int32, maxnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllMaxcare(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAXCARE_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreMaxcare(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAXCARE_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateMaxcare(BusinessEntities.EMRForms.Maxcare data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAXCARE_NEW_INSERT_UPDATE");
                if (data.maxnId > 0)
                {
                    db.AddInParameter(dbCommand, "maxnId", DbType.Int32, data.maxnId);
                }
                db.AddInParameter(dbCommand, "maxn_appId", DbType.Int32, data.maxn_appId);
                db.AddInParameter(dbCommand, "maxn_checkbox", DbType.String, data.maxn_checkbox);
                db.AddInParameter(dbCommand, "maxn_1", DbType.String, data.maxn_1);
                db.AddInParameter(dbCommand, "maxn_2", DbType.String, data.maxn_2);
                db.AddInParameter(dbCommand, "maxn_3", DbType.String, data.maxn_3);
                db.AddInParameter(dbCommand, "maxn_4", DbType.String, data.maxn_4);
                db.AddInParameter(dbCommand, "maxn_5", DbType.String, data.maxn_5);
                db.AddInParameter(dbCommand, "maxn_6", DbType.String, data.maxn_6);
                db.AddInParameter(dbCommand, "maxn_7", DbType.String, data.maxn_7);
                db.AddInParameter(dbCommand, "maxn_8", DbType.String, data.maxn_8);
                db.AddInParameter(dbCommand, "maxn_9", DbType.String, data.maxn_9);
                db.AddInParameter(dbCommand, "maxn_10", DbType.String, data.maxn_10);
                db.AddInParameter(dbCommand, "maxn_11", DbType.String, data.maxn_11);
                db.AddInParameter(dbCommand, "maxn_12", DbType.String, data.maxn_12);
                db.AddInParameter(dbCommand, "maxn_13", DbType.String, data.maxn_13);
                db.AddInParameter(dbCommand, "maxn_14", DbType.String, data.maxn_14);
                db.AddInParameter(dbCommand, "maxn_15", DbType.String, data.maxn_15);
                db.AddInParameter(dbCommand, "maxn_16", DbType.String, data.maxn_16);
                db.AddInParameter(dbCommand, "maxn_17", DbType.String, data.maxn_17);
                db.AddInParameter(dbCommand, "maxn_18", DbType.String, data.maxn_18);
                db.AddInParameter(dbCommand, "maxn_19", DbType.String, data.maxn_19);
                db.AddInParameter(dbCommand, "maxn_20", DbType.String, data.maxn_20);
                db.AddInParameter(dbCommand, "maxn_21", DbType.String, data.maxn_21);
                db.AddInParameter(dbCommand, "maxn_22", DbType.String, data.maxn_22);
                db.AddInParameter(dbCommand, "maxn_23", DbType.String, data.maxn_23);
                db.AddInParameter(dbCommand, "maxn_24", DbType.String, data.maxn_24);
                db.AddInParameter(dbCommand, "maxn_25", DbType.String, data.maxn_25);
                db.AddInParameter(dbCommand, "maxn_26", DbType.String, data.maxn_26);
                db.AddInParameter(dbCommand, "maxn_27", DbType.String, data.maxn_27);
                db.AddInParameter(dbCommand, "maxn_28", DbType.String, data.maxn_28);
                db.AddInParameter(dbCommand, "maxn_29", DbType.String, data.maxn_29);
                db.AddInParameter(dbCommand, "maxn_30", DbType.String, data.maxn_30);
                db.AddInParameter(dbCommand, "maxn_31", DbType.String, data.maxn_31);
                db.AddInParameter(dbCommand, "maxn_32", DbType.String, data.maxn_32);
                db.AddInParameter(dbCommand, "maxn_33", DbType.String, data.maxn_33);
                db.AddInParameter(dbCommand, "maxn_34", DbType.String, data.maxn_34);
                db.AddInParameter(dbCommand, "maxn_35", DbType.String, data.maxn_35);
                db.AddInParameter(dbCommand, "maxn_36", DbType.String, data.maxn_36);
                db.AddInParameter(dbCommand, "maxn_37", DbType.String, data.maxn_37);
                db.AddInParameter(dbCommand, "maxn_38", DbType.String, data.maxn_38);
                db.AddInParameter(dbCommand, "maxn_39", DbType.String, data.maxn_39);
                db.AddInParameter(dbCommand, "maxn_40", DbType.String, data.maxn_40);
                db.AddInParameter(dbCommand, "maxn_41", DbType.String, data.maxn_41);
                db.AddInParameter(dbCommand, "maxn_date1", DbType.DateTime, data.maxn_date1);
                db.AddInParameter(dbCommand, "maxn_date2", DbType.DateTime, data.maxn_date2);
                db.AddInParameter(dbCommand, "maxn_date3", DbType.DateTime, data.maxn_date3);

                db.AddInParameter(dbCommand, "maxn_madeby", DbType.Int32, data.maxn_madeby);
                db.AddInParameter(dbCommand, "maxn_modifyby", DbType.Int32, data.maxn_madeby);

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
        public static int DeleteMaxcare(int maxnId, int maxn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAXCARE_NEW_delete");

                db.AddInParameter(dbCommand, "maxnId", DbType.Int32, maxnId);
                db.AddInParameter(dbCommand, "maxn_modifyby", DbType.String, maxn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Cowan
    {
        public static DataTable GetPrintCowan(int? cownId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COWAN_NEW_Print");
                if (cownId > 0)
                {
                    db.AddInParameter(dbCommand, "cownId", DbType.Int32, cownId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllCowan(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COWAN_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreCowan(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COWAN_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateCowan(BusinessEntities.EMRForms.Cowan data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COWAN_NEW_INSERT_UPDATE");
                if (data.cownId > 0)
                {
                    db.AddInParameter(dbCommand, "cownId", DbType.Int32, data.cownId);
                }
                db.AddInParameter(dbCommand, "cown_appId", DbType.Int32, data.cown_appId);
                db.AddInParameter(dbCommand, "cown_chk", DbType.String, data.cown_chk);
                db.AddInParameter(dbCommand, "cown_1", DbType.String, data.cown_1);
                db.AddInParameter(dbCommand, "cown_2", DbType.String, data.cown_2);
                db.AddInParameter(dbCommand, "cown_3", DbType.String, data.cown_3);
                db.AddInParameter(dbCommand, "cown_4", DbType.String, data.cown_4);
                db.AddInParameter(dbCommand, "cown_5", DbType.String, data.cown_5);
                db.AddInParameter(dbCommand, "cown_6", DbType.String, data.cown_6);
                db.AddInParameter(dbCommand, "cown_7", DbType.String, data.cown_7);
                db.AddInParameter(dbCommand, "cown_8", DbType.String, data.cown_8);
                db.AddInParameter(dbCommand, "cown_9", DbType.String, data.cown_9);
                db.AddInParameter(dbCommand, "cown_10", DbType.String, data.cown_10);
                db.AddInParameter(dbCommand, "cown_11", DbType.String, data.cown_11);
                db.AddInParameter(dbCommand, "cown_12", DbType.String, data.cown_12);
                db.AddInParameter(dbCommand, "cown_13", DbType.String, data.cown_13);
                db.AddInParameter(dbCommand, "cown_14", DbType.String, data.cown_14);
                db.AddInParameter(dbCommand, "cown_15", DbType.String, data.cown_15);
                db.AddInParameter(dbCommand, "cown_16", DbType.String, data.cown_16);
                db.AddInParameter(dbCommand, "cown_17", DbType.String, data.cown_17);
                db.AddInParameter(dbCommand, "cown_18", DbType.String, data.cown_18);
                db.AddInParameter(dbCommand, "cown_19", DbType.String, data.cown_19);
                db.AddInParameter(dbCommand, "cown_20", DbType.String, data.cown_20);
                db.AddInParameter(dbCommand, "cown_21", DbType.String, data.cown_21);
                db.AddInParameter(dbCommand, "cown_22", DbType.String, data.cown_22);
                db.AddInParameter(dbCommand, "cown_23", DbType.String, data.cown_23);
                db.AddInParameter(dbCommand, "cown_24", DbType.String, data.cown_24);
                db.AddInParameter(dbCommand, "cown_25", DbType.String, data.cown_25);
                db.AddInParameter(dbCommand, "cown_26", DbType.String, data.cown_26);
                db.AddInParameter(dbCommand, "cown_27", DbType.String, data.cown_27);
                db.AddInParameter(dbCommand, "cown_28", DbType.String, data.cown_28);
                db.AddInParameter(dbCommand, "cown_29", DbType.String, data.cown_29);
                db.AddInParameter(dbCommand, "cown_30", DbType.String, data.cown_30);
                db.AddInParameter(dbCommand, "cown_31", DbType.String, data.cown_31);
                db.AddInParameter(dbCommand, "cown_32", DbType.String, data.cown_32);
                db.AddInParameter(dbCommand, "cown_33", DbType.String, data.cown_33);
                db.AddInParameter(dbCommand, "cown_34", DbType.String, data.cown_34);
                db.AddInParameter(dbCommand, "cown_35", DbType.String, data.cown_35);
                db.AddInParameter(dbCommand, "cown_36", DbType.String, data.cown_36);
                db.AddInParameter(dbCommand, "cown_37", DbType.String, data.cown_37);
                db.AddInParameter(dbCommand, "cown_38", DbType.String, data.cown_38);
                db.AddInParameter(dbCommand, "cown_39", DbType.String, data.cown_39);
                db.AddInParameter(dbCommand, "cown_40", DbType.String, data.cown_40);
                db.AddInParameter(dbCommand, "cown_41", DbType.String, data.cown_41);
                db.AddInParameter(dbCommand, "cown_42", DbType.String, data.cown_42);
                db.AddInParameter(dbCommand, "cown_43", DbType.String, data.cown_43);
                db.AddInParameter(dbCommand, "cown_44", DbType.String, data.cown_44);
                db.AddInParameter(dbCommand, "cown_45", DbType.String, data.cown_45);
                db.AddInParameter(dbCommand, "cown_46", DbType.String, data.cown_46);
                db.AddInParameter(dbCommand, "cown_47", DbType.String, data.cown_47);
                db.AddInParameter(dbCommand, "cown_48", DbType.String, data.cown_48);
                db.AddInParameter(dbCommand, "cown_49", DbType.String, data.cown_49);
                db.AddInParameter(dbCommand, "cown_50", DbType.String, data.cown_50);
                db.AddInParameter(dbCommand, "cown_51", DbType.String, data.cown_51);
                db.AddInParameter(dbCommand, "cown_52", DbType.String, data.cown_52);
                db.AddInParameter(dbCommand, "cown_53", DbType.String, data.cown_53);
                db.AddInParameter(dbCommand, "cown_54", DbType.String, data.cown_54);
                db.AddInParameter(dbCommand, "cown_55", DbType.String, data.cown_55);
                db.AddInParameter(dbCommand, "cown_56", DbType.String, data.cown_56);
                db.AddInParameter(dbCommand, "cown_57", DbType.String, data.cown_57);
                db.AddInParameter(dbCommand, "cown_58", DbType.String, data.cown_58);
                db.AddInParameter(dbCommand, "cown_59", DbType.String, data.cown_59);
                db.AddInParameter(dbCommand, "cown_60", DbType.String, data.cown_60);
                db.AddInParameter(dbCommand, "cown_61", DbType.String, data.cown_61);
                db.AddInParameter(dbCommand, "cown_62", DbType.String, data.cown_62);
                db.AddInParameter(dbCommand, "cown_63", DbType.String, data.cown_63);
                db.AddInParameter(dbCommand, "cown_64", DbType.String, data.cown_64);
                db.AddInParameter(dbCommand, "cown_65", DbType.String, data.cown_65);
                db.AddInParameter(dbCommand, "cown_66", DbType.String, data.cown_66);
                db.AddInParameter(dbCommand, "cown_67", DbType.String, data.cown_67);
                db.AddInParameter(dbCommand, "cown_68", DbType.String, data.cown_68);
                db.AddInParameter(dbCommand, "cown_69", DbType.String, data.cown_69);
                db.AddInParameter(dbCommand, "cown_70", DbType.String, data.cown_70);
                db.AddInParameter(dbCommand, "cown_71", DbType.String, data.cown_71);
                db.AddInParameter(dbCommand, "cown_date1", DbType.DateTime, data.cown_date1);
                db.AddInParameter(dbCommand, "cown_date2", DbType.DateTime, data.cown_date2);
                db.AddInParameter(dbCommand, "cown_date3", DbType.DateTime, data.cown_date3);
                db.AddInParameter(dbCommand, "cown_date4", DbType.DateTime, data.cown_date4);
                db.AddInParameter(dbCommand, "cown_date5", DbType.DateTime, data.cown_date5);
                db.AddInParameter(dbCommand, "cown_date6", DbType.DateTime, data.cown_date6);
                db.AddInParameter(dbCommand, "cown_date7", DbType.DateTime, data.cown_date7);
                db.AddInParameter(dbCommand, "cown_date8", DbType.DateTime, data.cown_date8);
                db.AddInParameter(dbCommand, "cown_date9", DbType.DateTime, data.cown_date9);
                db.AddInParameter(dbCommand, "cown_date10", DbType.DateTime, data.cown_date10);
                db.AddInParameter(dbCommand, "cown_date11", DbType.DateTime, data.cown_date11);
                db.AddInParameter(dbCommand, "cown_date12", DbType.DateTime, data.cown_date12);
                db.AddInParameter(dbCommand, "cown_madeby", DbType.Int32, data.cown_madeby);
                db.AddInParameter(dbCommand, "cown_modifyby", DbType.Int32, data.cown_madeby);

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
        public static int DeleteCowan(int cownId, int cown_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COWAN_NEW_delete");

                db.AddInParameter(dbCommand, "cownId", DbType.Int32, cownId);
                db.AddInParameter(dbCommand, "cown_modifyby", DbType.String, cown_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class NASNLGIC
    {
        public static DataTable GetPrintNASNLGIC(int? nalnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_NLGI_NEW_Print");
                if (nalnId > 0)
                {
                    db.AddInParameter(dbCommand, "nalnId", DbType.Int32, nalnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllNASNLGIC(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_NLGI_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreNASNLGIC(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_NLGI_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateNASNLGIC(BusinessEntities.EMRForms.NASNLGIC data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_NLGI_NEW_INSERT_UPDATE");
                if (data.nalnId > 0)
                {
                    db.AddInParameter(dbCommand, "nalnId", DbType.Int32, data.nalnId);
                }
                db.AddInParameter(dbCommand, "naln_appId", DbType.Int32, data.naln_appId);
                db.AddInParameter(dbCommand, "naln_1", DbType.String, data.naln_1);
                db.AddInParameter(dbCommand, "naln_2", DbType.String, data.naln_2);
                db.AddInParameter(dbCommand, "naln_3", DbType.String, data.naln_3);
                db.AddInParameter(dbCommand, "naln_4", DbType.String, data.naln_4);
                db.AddInParameter(dbCommand, "naln_5", DbType.String, data.naln_5);
                db.AddInParameter(dbCommand, "naln_6", DbType.String, data.naln_6);
                db.AddInParameter(dbCommand, "naln_7", DbType.String, data.naln_7);
                db.AddInParameter(dbCommand, "naln_8", DbType.String, data.naln_8);
                db.AddInParameter(dbCommand, "naln_9", DbType.String, data.naln_9);
                db.AddInParameter(dbCommand, "naln_10", DbType.String, data.naln_10);
                db.AddInParameter(dbCommand, "naln_11", DbType.String, data.naln_11);
                db.AddInParameter(dbCommand, "naln_12", DbType.String, data.naln_12);
                db.AddInParameter(dbCommand, "naln_13", DbType.String, data.naln_13);
                db.AddInParameter(dbCommand, "naln_14", DbType.String, data.naln_14);
                db.AddInParameter(dbCommand, "naln_15", DbType.String, data.naln_15);
                db.AddInParameter(dbCommand, "naln_16", DbType.String, data.naln_16);
                db.AddInParameter(dbCommand, "naln_17", DbType.String, data.naln_17);
                db.AddInParameter(dbCommand, "naln_18", DbType.String, data.naln_18);
                db.AddInParameter(dbCommand, "naln_date1", DbType.DateTime, data.naln_date1);
                db.AddInParameter(dbCommand, "naln_madeby", DbType.Int32, data.naln_madeby);
                db.AddInParameter(dbCommand, "naln_modifyby", DbType.Int32, data.naln_madeby);

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
        public static int DeleteNASNLGIC(int nalnId, int naln_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NAS_NLGI_NEW_delete");

                db.AddInParameter(dbCommand, "nalnId", DbType.Int32, nalnId);
                db.AddInParameter(dbCommand, "naln_modifyby", DbType.String, naln_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class EmiratesInsurance
    {
        public static DataTable GetPrintEmiratesInsurance(int? cceId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_emirates_reimberse_Print");
                if (cceId > 0)
                {
                    db.AddInParameter(dbCommand, "cceId", DbType.Int32, cceId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllEmiratesInsurance(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_emirates_reimberse_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreEmiratesInsurance(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_emirates_reimberse_PREVIOUS_History");
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
        public static bool InsertUpdateEmiratesInsurance(BusinessEntities.EMRForms.EmiratesInsurance data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_emirates_reimberse_INSERT_UPDATE");
                if (data.cceId > 0)
                {
                    db.AddInParameter(dbCommand, "cceId", DbType.Int32, data.cceId);
                }
                db.AddInParameter(dbCommand, "cce_appId", DbType.Int32, data.cce_appId);
                db.AddInParameter(dbCommand, "cce_chk", DbType.String, data.cce_chk);
                db.AddInParameter(dbCommand, "cce_1", DbType.String, data.cce_1);
                db.AddInParameter(dbCommand, "cce_2", DbType.String, data.cce_2);
                db.AddInParameter(dbCommand, "cce_3", DbType.String, data.cce_3);
                db.AddInParameter(dbCommand, "cce_4", DbType.String, data.cce_4);
                db.AddInParameter(dbCommand, "cce_5", DbType.String, data.cce_5);
                db.AddInParameter(dbCommand, "cce_6", DbType.String, data.cce_6);
                db.AddInParameter(dbCommand, "cce_7", DbType.String, data.cce_7);
                db.AddInParameter(dbCommand, "cce_8", DbType.String, data.cce_8);
                db.AddInParameter(dbCommand, "cce_9", DbType.String, data.cce_9);
                db.AddInParameter(dbCommand, "cce_10", DbType.String, data.cce_10);
                db.AddInParameter(dbCommand, "cce_11", DbType.String, data.cce_11);
                db.AddInParameter(dbCommand, "cce_12", DbType.String, data.cce_12);
                db.AddInParameter(dbCommand, "cce_13", DbType.String, data.cce_13);
                db.AddInParameter(dbCommand, "cce_14", DbType.String, data.cce_14);
                db.AddInParameter(dbCommand, "cce_15", DbType.String, data.cce_15);
                db.AddInParameter(dbCommand, "cce_16", DbType.String, data.cce_16);
                db.AddInParameter(dbCommand, "cce_17", DbType.String, data.cce_17);
                db.AddInParameter(dbCommand, "cce_18", DbType.String, data.cce_18);
                db.AddInParameter(dbCommand, "cce_19", DbType.String, data.cce_19);
                db.AddInParameter(dbCommand, "cce_20", DbType.String, data.cce_20);
                db.AddInParameter(dbCommand, "cce_21", DbType.String, data.cce_21);
                db.AddInParameter(dbCommand, "cce_date1", DbType.DateTime, data.cce_date1);
                db.AddInParameter(dbCommand, "cce_date2", DbType.DateTime, data.cce_date2);
                db.AddInParameter(dbCommand, "cce_date3", DbType.DateTime, data.cce_date3);
                db.AddInParameter(dbCommand, "cce_date4", DbType.DateTime, data.cce_date4);
                db.AddInParameter(dbCommand, "cce_date5", DbType.DateTime, data.cce_date5);
                db.AddInParameter(dbCommand, "cce_date6", DbType.DateTime, data.cce_date6);
                db.AddInParameter(dbCommand, "cce_date7", DbType.DateTime, data.cce_date7);
                db.AddInParameter(dbCommand, "cce_madeby", DbType.Int32, data.cce_madeby);
                db.AddInParameter(dbCommand, "cce_modifyby", DbType.Int32, data.cce_madeby);

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
        public static int DeleteEmiratesInsurance(int cceId, int cce_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_emirates_reimberse_delete");

                db.AddInParameter(dbCommand, "cceId", DbType.Int32, cceId);
                db.AddInParameter(dbCommand, "cce_modifyby", DbType.String, cce_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class Mapfre
    {
        public static DataTable GetPrintMapfre(int? maprId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAPFRE_NEW_Print");
                if (maprId > 0)
                {
                    db.AddInParameter(dbCommand, "maprId", DbType.Int32, maprId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllMapfre(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAPFRE_NEW_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreMapfre(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAPFRE_NEW_PREVIOUS_History");
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
        public static bool InsertUpdateMapfre(BusinessEntities.EMRForms.Mapfre data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAPFRE_NEW_INSERT_UPDATE");
                if (data.maprId > 0)
                {
                    db.AddInParameter(dbCommand, "maprId", DbType.Int32, data.maprId);
                }
                db.AddInParameter(dbCommand, "mapr_appId", DbType.Int32, data.mapr_appId);
                db.AddInParameter(dbCommand, "mapr_chk", DbType.String, data.mapr_chk);
                db.AddInParameter(dbCommand, "mapr_1", DbType.String, data.mapr_1);
                db.AddInParameter(dbCommand, "mapr_2", DbType.String, data.mapr_2);
                db.AddInParameter(dbCommand, "mapr_3", DbType.String, data.mapr_3);
                db.AddInParameter(dbCommand, "mapr_4", DbType.String, data.mapr_4);
                db.AddInParameter(dbCommand, "mapr_5", DbType.String, data.mapr_5);
                db.AddInParameter(dbCommand, "mapr_6", DbType.String, data.mapr_6);
                db.AddInParameter(dbCommand, "mapr_7", DbType.String, data.mapr_7);
                db.AddInParameter(dbCommand, "mapr_8", DbType.String, data.mapr_8);
                db.AddInParameter(dbCommand, "mapr_9", DbType.String, data.mapr_9);
                db.AddInParameter(dbCommand, "mapr_10", DbType.String, data.mapr_10);
                db.AddInParameter(dbCommand, "mapr_11", DbType.String, data.mapr_11);
                db.AddInParameter(dbCommand, "mapr_12", DbType.String, data.mapr_12);
                db.AddInParameter(dbCommand, "mapr_13", DbType.String, data.mapr_13);
                db.AddInParameter(dbCommand, "mapr_14", DbType.String, data.mapr_14);
                db.AddInParameter(dbCommand, "mapr_15", DbType.String, data.mapr_15);
                db.AddInParameter(dbCommand, "mapr_16", DbType.String, data.mapr_16);
                db.AddInParameter(dbCommand, "mapr_17", DbType.String, data.mapr_17);
                db.AddInParameter(dbCommand, "mapr_18", DbType.String, data.mapr_18);
                db.AddInParameter(dbCommand, "mapr_19", DbType.String, data.mapr_19);
                db.AddInParameter(dbCommand, "mapr_20", DbType.String, data.mapr_20);
                db.AddInParameter(dbCommand, "mapr_date1", DbType.DateTime, data.mapr_date1);
                db.AddInParameter(dbCommand, "mapr_date2", DbType.DateTime, data.mapr_date2);
                db.AddInParameter(dbCommand, "mapr_date3", DbType.DateTime, data.mapr_date3);
                db.AddInParameter(dbCommand, "mapr_date4", DbType.DateTime, data.mapr_date4);
                db.AddInParameter(dbCommand, "mapr_date5", DbType.DateTime, data.mapr_date5);
                db.AddInParameter(dbCommand, "mapr_date6", DbType.DateTime, data.mapr_date6);
                db.AddInParameter(dbCommand, "mapr_date7", DbType.DateTime, data.mapr_date7);
                db.AddInParameter(dbCommand, "mapr_date8", DbType.DateTime, data.mapr_date8);
                db.AddInParameter(dbCommand, "mapr_madeby", DbType.Int32, data.mapr_madeby);
                db.AddInParameter(dbCommand, "mapr_modifyby", DbType.Int32, data.mapr_madeby);

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
        public static int DeleteMapfre(int maprId, int mapr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MAPFRE_NEW_delete");

                db.AddInParameter(dbCommand, "maprId", DbType.Int32, maprId);
                db.AddInParameter(dbCommand, "mapr_modifyby", DbType.String, mapr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class AAFIYA
    {
        public static DataTable GetPrintAAFIYA(int? ccaId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AAFIYA_CLAIM_Print");
                if (ccaId > 0)
                {
                    db.AddInParameter(dbCommand, "ccaId", DbType.Int32, ccaId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllAAFIYA(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AAFIYA_CLAIM_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetAllPreAAFIYA(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AAFIYA_CLAIM_PREVIOUS_History");
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
        public static bool InsertUpdateAAFIYA(BusinessEntities.EMRForms.AAFIYA data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AAFIYA_CLAIM_INSERT_UPDATE");
                if (data.ccaId > 0)
                {
                    db.AddInParameter(dbCommand, "ccaId", DbType.Int32, data.ccaId);
                }
                db.AddInParameter(dbCommand, "cca_appId", DbType.Int32, data.cca_appId);
                db.AddInParameter(dbCommand, "cca_chk", DbType.String, data.cca_chk);
                db.AddInParameter(dbCommand, "cca_1", DbType.String, data.cca_1);
                db.AddInParameter(dbCommand, "cca_2", DbType.String, data.cca_2);
                db.AddInParameter(dbCommand, "cca_3", DbType.String, data.cca_3);
                db.AddInParameter(dbCommand, "cca_4", DbType.String, data.cca_4);
                db.AddInParameter(dbCommand, "cca_5", DbType.String, data.cca_5);
                db.AddInParameter(dbCommand, "cca_6", DbType.String, data.cca_6);
                db.AddInParameter(dbCommand, "cca_7", DbType.String, data.cca_7);
                db.AddInParameter(dbCommand, "cca_8", DbType.String, data.cca_8);
                db.AddInParameter(dbCommand, "cca_9", DbType.String, data.cca_9);
                db.AddInParameter(dbCommand, "cca_10", DbType.String, data.cca_10);
                db.AddInParameter(dbCommand, "cca_11", DbType.String, data.cca_11);
                db.AddInParameter(dbCommand, "cca_12", DbType.String, data.cca_12);
                db.AddInParameter(dbCommand, "cca_13", DbType.String, data.cca_13);
                db.AddInParameter(dbCommand, "cca_14", DbType.String, data.cca_14);
                db.AddInParameter(dbCommand, "cca_15", DbType.String, data.cca_15);
                db.AddInParameter(dbCommand, "cca_16", DbType.String, data.cca_16);
                db.AddInParameter(dbCommand, "cca_17", DbType.String, data.cca_17);
                db.AddInParameter(dbCommand, "cca_18", DbType.String, data.cca_18);
                db.AddInParameter(dbCommand, "cca_19", DbType.String, data.cca_19);
                db.AddInParameter(dbCommand, "cca_20", DbType.String, data.cca_20);
                db.AddInParameter(dbCommand, "cca_date1", DbType.DateTime, data.cca_date1);
                db.AddInParameter(dbCommand, "cca_madeby", DbType.Int32, data.cca_madeby);
                db.AddInParameter(dbCommand, "cca_modifyby", DbType.Int32, data.cca_madeby);

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
        public static int DeleteAAFIYA(int ccaId, int cca_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AAFIYA_CLAIM_delete");

                db.AddInParameter(dbCommand, "ccaId", DbType.Int32, ccaId);
                db.AddInParameter(dbCommand, "cca_modifyby", DbType.String, cca_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
