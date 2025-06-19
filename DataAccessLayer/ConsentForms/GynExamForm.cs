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
    public class GynExamForm
    {
        public static DataTable GetGynExamFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Gyn_Exam_Form_Select");

                db.AddInParameter(dbCommand, "gef_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveGynExamForm(BusinessEntities.ConsentForms.GynExamForm gyna, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Gyn_Exam_Form_Insert");

                db.AddInParameter(dbCommand, "gef_appId", DbType.Int32, gyna.gef_appId);
                db.AddInParameter(dbCommand, "gef_1", DbType.String, string.IsNullOrEmpty(gyna.gef_1) ? "" : gyna.gef_1);
                db.AddInParameter(dbCommand, "gef_2", DbType.String, string.IsNullOrEmpty(gyna.gef_2) ? "" : gyna.gef_2);
                db.AddInParameter(dbCommand, "gef_3", DbType.String, string.IsNullOrEmpty(gyna.gef_3) ? "" : gyna.gef_3);
                db.AddInParameter(dbCommand, "gef_4", DbType.String, string.IsNullOrEmpty(gyna.gef_4) ? "" : gyna.gef_4);
                db.AddInParameter(dbCommand, "gef_5", DbType.String, string.IsNullOrEmpty(gyna.gef_5) ? "" : gyna.gef_5);
                db.AddInParameter(dbCommand, "gef_6", DbType.String, string.IsNullOrEmpty(gyna.gef_6) ? "" : gyna.gef_6);
                db.AddInParameter(dbCommand, "gef_7", DbType.String, string.IsNullOrEmpty(gyna.gef_7) ? "" : gyna.gef_7);
                db.AddInParameter(dbCommand, "gef_8", DbType.String, string.IsNullOrEmpty(gyna.gef_8) ? "" : gyna.gef_8);
                db.AddInParameter(dbCommand, "gef_9", DbType.String, string.IsNullOrEmpty(gyna.gef_9) ? "" : gyna.gef_9);
                db.AddInParameter(dbCommand, "gef_10", DbType.String, string.IsNullOrEmpty(gyna.gef_10) ? "" : gyna.gef_10);
                db.AddInParameter(dbCommand, "gef_11", DbType.String, string.IsNullOrEmpty(gyna.gef_11) ? "" : gyna.gef_11);
                db.AddInParameter(dbCommand, "gef_12", DbType.String, string.IsNullOrEmpty(gyna.gef_12) ? "" : gyna.gef_12);
                db.AddInParameter(dbCommand, "gef_13", DbType.String, string.IsNullOrEmpty(gyna.gef_13) ? "" : gyna.gef_13);
                db.AddInParameter(dbCommand, "gef_14", DbType.String, string.IsNullOrEmpty(gyna.gef_14) ? "" : gyna.gef_14);
                db.AddInParameter(dbCommand, "gef_15", DbType.String, string.IsNullOrEmpty(gyna.gef_15) ? "" : gyna.gef_15);
                db.AddInParameter(dbCommand, "gef_16", DbType.String, string.IsNullOrEmpty(gyna.gef_16) ? "" : gyna.gef_16);
                db.AddInParameter(dbCommand, "gef_17", DbType.String, string.IsNullOrEmpty(gyna.gef_17) ? "" : gyna.gef_17);
                db.AddInParameter(dbCommand, "gef_18", DbType.String, string.IsNullOrEmpty(gyna.gef_18) ? "" : gyna.gef_18);
                db.AddInParameter(dbCommand, "gef_19", DbType.String, string.IsNullOrEmpty(gyna.gef_19) ? "" : gyna.gef_19);
                db.AddInParameter(dbCommand, "gef_20", DbType.String, string.IsNullOrEmpty(gyna.gef_20) ? "" : gyna.gef_20);
                db.AddInParameter(dbCommand, "gef_21", DbType.String, string.IsNullOrEmpty(gyna.gef_21) ? "" : gyna.gef_21);
                db.AddInParameter(dbCommand, "gef_22", DbType.String, string.IsNullOrEmpty(gyna.gef_22) ? "" : gyna.gef_22);
                db.AddInParameter(dbCommand, "gef_23", DbType.String, string.IsNullOrEmpty(gyna.gef_23) ? "" : gyna.gef_23);
                db.AddInParameter(dbCommand, "gef_24", DbType.String, string.IsNullOrEmpty(gyna.gef_24) ? "" : gyna.gef_24);
                db.AddInParameter(dbCommand, "gef_25", DbType.String, string.IsNullOrEmpty(gyna.gef_25) ? "" : gyna.gef_25);
                db.AddInParameter(dbCommand, "gef_26", DbType.String, string.IsNullOrEmpty(gyna.gef_26) ? "" : gyna.gef_26);
                db.AddInParameter(dbCommand, "gef_27", DbType.String, string.IsNullOrEmpty(gyna.gef_27) ? "" : gyna.gef_27);
                db.AddInParameter(dbCommand, "gef_28", DbType.String, string.IsNullOrEmpty(gyna.gef_28) ? "" : gyna.gef_28);
                db.AddInParameter(dbCommand, "gef_29", DbType.String, string.IsNullOrEmpty(gyna.gef_29) ? "" : gyna.gef_29);
                db.AddInParameter(dbCommand, "gef_30", DbType.String, string.IsNullOrEmpty(gyna.gef_30) ? "" : gyna.gef_30);
                db.AddInParameter(dbCommand, "gef_31", DbType.String, string.IsNullOrEmpty(gyna.gef_31) ? "" : gyna.gef_31);
                db.AddInParameter(dbCommand, "gef_32", DbType.String, string.IsNullOrEmpty(gyna.gef_32) ? "" : gyna.gef_32);
                db.AddInParameter(dbCommand, "gef_33", DbType.String, string.IsNullOrEmpty(gyna.gef_33) ? "" : gyna.gef_33);
               
                db.AddInParameter(dbCommand, "gef_radio1", DbType.String, string.IsNullOrEmpty(gyna.gef_radio1) ? "" : gyna.gef_radio1);
                db.AddInParameter(dbCommand, "gef_radio2", DbType.String, string.IsNullOrEmpty(gyna.gef_radio2) ? "" : gyna.gef_radio2);
                db.AddInParameter(dbCommand, "gef_radio3", DbType.String, string.IsNullOrEmpty(gyna.gef_radio3) ? "" : gyna.gef_radio3);
                db.AddInParameter(dbCommand, "gef_radio4", DbType.String, string.IsNullOrEmpty(gyna.gef_radio4) ? "" : gyna.gef_radio4);
                db.AddInParameter(dbCommand, "gef_radio5", DbType.String, string.IsNullOrEmpty(gyna.gef_radio5) ? "" : gyna.gef_radio5);
                db.AddInParameter(dbCommand, "gef_radio6", DbType.String, string.IsNullOrEmpty(gyna.gef_radio6) ? "" : gyna.gef_radio6);
                db.AddInParameter(dbCommand, "gef_radio7", DbType.String, string.IsNullOrEmpty(gyna.gef_radio7) ? "" : gyna.gef_radio7);
                db.AddInParameter(dbCommand, "gef_radio8", DbType.String, string.IsNullOrEmpty(gyna.gef_radio8) ? "" : gyna.gef_radio8);
                db.AddInParameter(dbCommand, "gef_radio9", DbType.String, string.IsNullOrEmpty(gyna.gef_radio9) ? "" : gyna.gef_radio9);
                db.AddInParameter(dbCommand, "gef_radio10", DbType.String, string.IsNullOrEmpty(gyna.gef_radio10) ? "" : gyna.gef_radio10);
                db.AddInParameter(dbCommand, "gef_radio11", DbType.String, string.IsNullOrEmpty(gyna.gef_radio11) ? "" : gyna.gef_radio11);
                db.AddInParameter(dbCommand, "gef_radio12", DbType.String, string.IsNullOrEmpty(gyna.gef_radio12) ? "" : gyna.gef_radio12);
                db.AddInParameter(dbCommand, "gef_radio13", DbType.String, string.IsNullOrEmpty(gyna.gef_radio13) ? "" : gyna.gef_radio13);
                db.AddInParameter(dbCommand, "gef_radio14", DbType.String, string.IsNullOrEmpty(gyna.gef_radio14) ? "" : gyna.gef_radio14);
                db.AddInParameter(dbCommand, "gef_radio15", DbType.String, string.IsNullOrEmpty(gyna.gef_radio15) ? "" : gyna.gef_radio15);
                db.AddInParameter(dbCommand, "gef_radio16", DbType.String, string.IsNullOrEmpty(gyna.gef_radio16) ? "" : gyna.gef_radio16);
                db.AddInParameter(dbCommand, "gef_radio17", DbType.String, string.IsNullOrEmpty(gyna.gef_radio17) ? "" : gyna.gef_radio17);
                db.AddInParameter(dbCommand, "gef_radio18", DbType.String, string.IsNullOrEmpty(gyna.gef_radio18) ? "" : gyna.gef_radio18);
                db.AddInParameter(dbCommand, "gef_radio19", DbType.String, string.IsNullOrEmpty(gyna.gef_radio19) ? "" : gyna.gef_radio19);
                db.AddInParameter(dbCommand, "gef_radio20", DbType.String, string.IsNullOrEmpty(gyna.gef_radio20) ? "" : gyna.gef_radio20);
                db.AddInParameter(dbCommand, "gef_radio21", DbType.String, string.IsNullOrEmpty(gyna.gef_radio21) ? "" : gyna.gef_radio21);
                db.AddInParameter(dbCommand, "gef_radio22", DbType.String, string.IsNullOrEmpty(gyna.gef_radio22) ? "" : gyna.gef_radio22);
                db.AddInParameter(dbCommand, "gef_radio23", DbType.String, string.IsNullOrEmpty(gyna.gef_radio23) ? "" : gyna.gef_radio23);
                db.AddInParameter(dbCommand, "gef_radio24", DbType.String, string.IsNullOrEmpty(gyna.gef_radio24) ? "" : gyna.gef_radio24);
                db.AddInParameter(dbCommand, "gef_radio25", DbType.String, string.IsNullOrEmpty(gyna.gef_radio25) ? "" : gyna.gef_radio25);
                db.AddInParameter(dbCommand, "gef_radio26", DbType.String, string.IsNullOrEmpty(gyna.gef_radio26) ? "" : gyna.gef_radio26);
                db.AddInParameter(dbCommand, "gef_radio27", DbType.String, string.IsNullOrEmpty(gyna.gef_radio27) ? "" : gyna.gef_radio27);
                db.AddInParameter(dbCommand, "gef_radio28", DbType.String, string.IsNullOrEmpty(gyna.gef_radio28) ? "" : gyna.gef_radio28);
                db.AddInParameter(dbCommand, "gef_radio29", DbType.String, string.IsNullOrEmpty(gyna.gef_radio29) ? "" : gyna.gef_radio29);
                db.AddInParameter(dbCommand, "gef_radio30", DbType.String, string.IsNullOrEmpty(gyna.gef_radio30) ? "" : gyna.gef_radio30);
                db.AddInParameter(dbCommand, "gef_radio31", DbType.String, string.IsNullOrEmpty(gyna.gef_radio31) ? "" : gyna.gef_radio31);
                db.AddInParameter(dbCommand, "gef_radio32", DbType.String, string.IsNullOrEmpty(gyna.gef_radio32) ? "" : gyna.gef_radio32);
                db.AddInParameter(dbCommand, "gef_radio33", DbType.String, string.IsNullOrEmpty(gyna.gef_radio33) ? "" : gyna.gef_radio33);
                db.AddInParameter(dbCommand, "gef_radio34", DbType.String, string.IsNullOrEmpty(gyna.gef_radio34) ? "" : gyna.gef_radio34);
                db.AddInParameter(dbCommand, "gef_radio35", DbType.String, string.IsNullOrEmpty(gyna.gef_radio35) ? "" : gyna.gef_radio35);
                db.AddInParameter(dbCommand, "gef_radio36", DbType.String, string.IsNullOrEmpty(gyna.gef_radio36) ? "" : gyna.gef_radio36);
                db.AddInParameter(dbCommand, "gef_radio37", DbType.String, string.IsNullOrEmpty(gyna.gef_radio37) ? "" : gyna.gef_radio37);
                db.AddInParameter(dbCommand, "gef_radio38", DbType.String, string.IsNullOrEmpty(gyna.gef_radio38) ? "" : gyna.gef_radio38);
                db.AddInParameter(dbCommand, "gef_radio39", DbType.String, string.IsNullOrEmpty(gyna.gef_radio39) ? "" : gyna.gef_radio39);
                db.AddInParameter(dbCommand, "gef_radio40", DbType.String, string.IsNullOrEmpty(gyna.gef_radio40) ? "" : gyna.gef_radio40);
                db.AddInParameter(dbCommand, "gef_radio41", DbType.String, string.IsNullOrEmpty(gyna.gef_radio41) ? "" : gyna.gef_radio41);
                db.AddInParameter(dbCommand, "gef_radio42", DbType.String, string.IsNullOrEmpty(gyna.gef_radio42) ? "" : gyna.gef_radio42);
                db.AddInParameter(dbCommand, "gef_radio43", DbType.String, string.IsNullOrEmpty(gyna.gef_radio43) ? "" : gyna.gef_radio43);
                db.AddInParameter(dbCommand, "gef_radio44", DbType.String, string.IsNullOrEmpty(gyna.gef_radio44) ? "" : gyna.gef_radio44);
                db.AddInParameter(dbCommand, "gef_radio45", DbType.String, string.IsNullOrEmpty(gyna.gef_radio45) ? "" : gyna.gef_radio45);
                db.AddInParameter(dbCommand, "gef_radio46", DbType.String, string.IsNullOrEmpty(gyna.gef_radio46) ? "" : gyna.gef_radio46);
                db.AddInParameter(dbCommand, "gef_radio47", DbType.String, string.IsNullOrEmpty(gyna.gef_radio47) ? "" : gyna.gef_radio47);
                db.AddInParameter(dbCommand, "gef_radio48", DbType.String, string.IsNullOrEmpty(gyna.gef_radio48) ? "" : gyna.gef_radio48);
                db.AddInParameter(dbCommand, "gef_radio49", DbType.String, string.IsNullOrEmpty(gyna.gef_radio49) ? "" : gyna.gef_radio49);
                db.AddInParameter(dbCommand, "gef_radio50", DbType.String, string.IsNullOrEmpty(gyna.gef_radio50) ? "" : gyna.gef_radio50);
                db.AddInParameter(dbCommand, "gef_radio51", DbType.String, string.IsNullOrEmpty(gyna.gef_radio51) ? "" : gyna.gef_radio51);
                db.AddInParameter(dbCommand, "gef_radio52", DbType.String, string.IsNullOrEmpty(gyna.gef_radio52) ? "" : gyna.gef_radio52);
                db.AddInParameter(dbCommand, "gef_radio53", DbType.String, string.IsNullOrEmpty(gyna.gef_radio53) ? "" : gyna.gef_radio53);
                db.AddInParameter(dbCommand, "gef_radio54", DbType.String, string.IsNullOrEmpty(gyna.gef_radio54) ? "" : gyna.gef_radio54);
                db.AddInParameter(dbCommand, "gef_radio55", DbType.String, string.IsNullOrEmpty(gyna.gef_radio55) ? "" : gyna.gef_radio55);
                db.AddInParameter(dbCommand, "gef_radio56", DbType.String, string.IsNullOrEmpty(gyna.gef_radio56) ? "" : gyna.gef_radio56);
                db.AddInParameter(dbCommand, "gef_radio57", DbType.String, string.IsNullOrEmpty(gyna.gef_radio57) ? "" : gyna.gef_radio57);
                db.AddInParameter(dbCommand, "gef_radio58", DbType.String, string.IsNullOrEmpty(gyna.gef_radio58) ? "" : gyna.gef_radio58);
                db.AddInParameter(dbCommand, "gef_radio59", DbType.String, string.IsNullOrEmpty(gyna.gef_radio59) ? "" : gyna.gef_radio59);
                db.AddInParameter(dbCommand, "gef_radio60", DbType.String, string.IsNullOrEmpty(gyna.gef_radio60) ? "" : gyna.gef_radio60);
                db.AddInParameter(dbCommand, "gef_radio61", DbType.String, string.IsNullOrEmpty(gyna.gef_radio61) ? "" : gyna.gef_radio61);
                db.AddInParameter(dbCommand, "gef_radio62", DbType.String, string.IsNullOrEmpty(gyna.gef_radio62) ? "" : gyna.gef_radio62);
                db.AddInParameter(dbCommand, "gef_radio63", DbType.String, string.IsNullOrEmpty(gyna.gef_radio63) ? "" : gyna.gef_radio63);
                db.AddInParameter(dbCommand, "gef_radio64", DbType.String, string.IsNullOrEmpty(gyna.gef_radio64) ? "" : gyna.gef_radio64);

                db.AddInParameter(dbCommand, "gef_date1", DbType.String, string.IsNullOrEmpty(gyna.gef_date1) ? "" : gyna.gef_date1);
                db.AddInParameter(dbCommand, "gef_date2", DbType.String, string.IsNullOrEmpty(gyna.gef_date2) ? "" : gyna.gef_date2);
                db.AddInParameter(dbCommand, "gef_date3", DbType.String, string.IsNullOrEmpty(gyna.gef_date3) ? "" : gyna.gef_date3);
                db.AddInParameter(dbCommand, "gef_date4", DbType.String, string.IsNullOrEmpty(gyna.gef_date4) ? "" : gyna.gef_date4);
                db.AddInParameter(dbCommand, "gef_date5", DbType.String, string.IsNullOrEmpty(gyna.gef_date5) ? "" : gyna.gef_date5);
                db.AddInParameter(dbCommand, "gef_date6", DbType.String, string.IsNullOrEmpty(gyna.gef_date6) ? "" : gyna.gef_date6);
                db.AddInParameter(dbCommand, "gef_date7", DbType.String, string.IsNullOrEmpty(gyna.gef_date7) ? "" : gyna.gef_date7);
                db.AddInParameter(dbCommand, "gef_date8", DbType.String, string.IsNullOrEmpty(gyna.gef_date8) ? "" : gyna.gef_date8);
                db.AddInParameter(dbCommand, "gef_date9", DbType.String, string.IsNullOrEmpty(gyna.gef_date9) ? "" : gyna.gef_date9);

                db.AddInParameter(dbCommand, "gef_chk1", DbType.String, string.IsNullOrEmpty(gyna.gef_chk1) ? "" : gyna.gef_chk1);

                db.AddInParameter(dbCommand, "gef_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "gefId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _gefId = Convert.ToInt32(db.GetParameterValue(dbCommand, "gefId"));
                return _gefId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteGynExamForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Gyn_Exam_Form_Delete");

                db.AddInParameter(dbCommand, "gef_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "gef_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "gef_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _gef_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "gef_output"));

                return _gef_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetGynExamFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Gyn_Exam_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "gef_appId", DbType.Int32, appId);
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
