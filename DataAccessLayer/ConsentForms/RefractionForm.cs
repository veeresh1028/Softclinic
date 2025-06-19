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
    public class RefractionForm
    {
        public static DataTable GetRefractionFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Refraction_Form_Select");

                db.AddInParameter(dbCommand, "rfc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveRefractionForm(BusinessEntities.ConsentForms.RefractionForm refraction, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Refraction_Form_Insert");

                db.AddInParameter(dbCommand, "rfc_appId", DbType.Int32, refraction.rfc_appId);
                db.AddInParameter(dbCommand, "rfc_type", DbType.String, string.IsNullOrEmpty(refraction.rfc_type) ? "" : refraction.rfc_type);
                db.AddInParameter(dbCommand, "rfc_odselecttype1", DbType.String, string.IsNullOrEmpty(refraction.rfc_odselecttype1) ? "" : refraction.rfc_odselecttype1);
                db.AddInParameter(dbCommand, "rfc_odselecttype2", DbType.String, string.IsNullOrEmpty(refraction.rfc_odselecttype2) ? "" : refraction.rfc_odselecttype2);
                db.AddInParameter(dbCommand, "rfc_osselecttype1", DbType.String, string.IsNullOrEmpty(refraction.rfc_osselecttype1) ? "" : refraction.rfc_osselecttype1);
                db.AddInParameter(dbCommand, "rfc_osselecttype2", DbType.String, string.IsNullOrEmpty(refraction.rfc_osselecttype2) ? "" : refraction.rfc_osselecttype2);
                db.AddInParameter(dbCommand, "rfc_phselecttype1", DbType.String, string.IsNullOrEmpty(refraction.rfc_phselecttype1) ? "" : refraction.rfc_phselecttype1);
                db.AddInParameter(dbCommand, "rfc_phselecttype2", DbType.String, string.IsNullOrEmpty(refraction.rfc_phselecttype2) ? "" : refraction.rfc_phselecttype2);
                db.AddInParameter(dbCommand, "rfc_phselecttype3", DbType.String, string.IsNullOrEmpty(refraction.rfc_phselecttype3) ? "" : refraction.rfc_phselecttype3);
                db.AddInParameter(dbCommand, "rfc_phselecttype4", DbType.String, string.IsNullOrEmpty(refraction.rfc_phselecttype4) ? "" : refraction.rfc_phselecttype4);
                db.AddInParameter(dbCommand, "rfc_glsselecttype1", DbType.String, string.IsNullOrEmpty(refraction.rfc_glsselecttype1) ? "" : refraction.rfc_glsselecttype1);
                db.AddInParameter(dbCommand, "rfc_glsselecttype2", DbType.String, string.IsNullOrEmpty(refraction.rfc_glsselecttype2) ? "" : refraction.rfc_glsselecttype2);
                db.AddInParameter(dbCommand, "rfc_glsselecttype3", DbType.String, string.IsNullOrEmpty(refraction.rfc_glsselecttype3) ? "" : refraction.rfc_glsselecttype3);
                db.AddInParameter(dbCommand, "rfc_glsselecttype4", DbType.String, string.IsNullOrEmpty(refraction.rfc_glsselecttype4) ? "" : refraction.rfc_glsselecttype4);
                db.AddInParameter(dbCommand, "rfc_clselecttype1", DbType.String, string.IsNullOrEmpty(refraction.rfc_clselecttype1) ? "" : refraction.rfc_clselecttype1);
                db.AddInParameter(dbCommand, "rfc_clselecttype2", DbType.String, string.IsNullOrEmpty(refraction.rfc_clselecttype2) ? "" : refraction.rfc_clselecttype2);
                db.AddInParameter(dbCommand, "rfc_clselecttype3", DbType.String, string.IsNullOrEmpty(refraction.rfc_clselecttype3) ? "" : refraction.rfc_clselecttype3);
                db.AddInParameter(dbCommand, "rfc_clselecttype4", DbType.String, string.IsNullOrEmpty(refraction.rfc_clselecttype4) ? "" : refraction.rfc_clselecttype4);
                db.AddInParameter(dbCommand, "rfc_od1", DbType.String, string.IsNullOrEmpty(refraction.rfc_od1) ? "" : refraction.rfc_od1);
                db.AddInParameter(dbCommand, "rfc_os1", DbType.String, string.IsNullOrEmpty(refraction.rfc_os1) ? "" : refraction.rfc_os1);
                db.AddInParameter(dbCommand, "rfc_glass1doc", DbType.String, string.IsNullOrEmpty(refraction.rfc_glass1doc) ? "" : refraction.rfc_glass1doc);
                db.AddInParameter(dbCommand, "rfc_glass2doc", DbType.String, string.IsNullOrEmpty(refraction.rfc_glass2doc) ? "" : refraction.rfc_glass2doc);
                db.AddInParameter(dbCommand, "rfc_chk", DbType.String, string.IsNullOrEmpty(refraction.rfc_chk) ? "" : refraction.rfc_chk);
                db.AddInParameter(dbCommand, "rfc_date1", DbType.String, string.IsNullOrEmpty(refraction.rfc_date1) ? "" : refraction.rfc_date1);
                db.AddInParameter(dbCommand, "rfc_subodsph1", DbType.String, string.IsNullOrEmpty(refraction.rfc_subodsph1) ? "" : refraction.rfc_subodsph1);
                db.AddInParameter(dbCommand, "rfc_subodsph2", DbType.String, string.IsNullOrEmpty(refraction.rfc_subodsph2) ? "" : refraction.rfc_subodsph2);
                db.AddInParameter(dbCommand, "rfc_subcyl1", DbType.String, string.IsNullOrEmpty(refraction.rfc_subcyl1) ? "" : refraction.rfc_subcyl1);
                db.AddInParameter(dbCommand, "rfc_subcyl2", DbType.String, string.IsNullOrEmpty(refraction.rfc_subcyl2) ? "" : refraction.rfc_subcyl2);
                db.AddInParameter(dbCommand, "rfc_subaxs1", DbType.String, string.IsNullOrEmpty(refraction.rfc_subaxs1) ? "" : refraction.rfc_subaxs1);
                db.AddInParameter(dbCommand, "rfc_subaxs2", DbType.String, string.IsNullOrEmpty(refraction.rfc_subaxs2) ? "" : refraction.rfc_subaxs2);
                db.AddInParameter(dbCommand, "rfc_subva1", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva1) ? "" : refraction.rfc_subva1);
                db.AddInParameter(dbCommand, "rfc_subva2", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva2) ? "" : refraction.rfc_subva2);
                db.AddInParameter(dbCommand, "rfc_subva3", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva3) ? "" : refraction.rfc_subva3);
                db.AddInParameter(dbCommand, "rfc_subva4", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva4) ? "" : refraction.rfc_subva4);
                db.AddInParameter(dbCommand, "rfc_subadd1", DbType.String, string.IsNullOrEmpty(refraction.rfc_subadd1) ? "" : refraction.rfc_subadd1);
                db.AddInParameter(dbCommand, "rfc_subadd2", DbType.String, string.IsNullOrEmpty(refraction.rfc_subadd2) ? "" : refraction.rfc_subadd2);
                db.AddInParameter(dbCommand, "rfc_subva5", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva5) ? "" : refraction.rfc_subva5);
                db.AddInParameter(dbCommand, "rfc_subva6", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva6) ? "" : refraction.rfc_subva6);
                db.AddInParameter(dbCommand, "rfc_subva7", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva7) ? "" : refraction.rfc_subva7);
                db.AddInParameter(dbCommand, "rfc_subva8", DbType.String, string.IsNullOrEmpty(refraction.rfc_subva8) ? "" : refraction.rfc_subva8);
                db.AddInParameter(dbCommand, "rfc_subph1", DbType.String, string.IsNullOrEmpty(refraction.rfc_subph1) ? "" : refraction.rfc_subph1);
                db.AddInParameter(dbCommand, "rfc_subph2", DbType.String, string.IsNullOrEmpty(refraction.rfc_subph2) ? "" : refraction.rfc_subph2);
                db.AddInParameter(dbCommand, "rfc_subph3", DbType.String, string.IsNullOrEmpty(refraction.rfc_subph3) ? "" : refraction.rfc_subph3);
                db.AddInParameter(dbCommand, "rfc_subph4", DbType.String, string.IsNullOrEmpty(refraction.rfc_subph4) ? "" : refraction.rfc_subph4);
                db.AddInParameter(dbCommand, "rfc_sub1", DbType.String, string.IsNullOrEmpty(refraction.rfc_sub1) ? "" : refraction.rfc_sub1);
                db.AddInParameter(dbCommand, "rfc_sub2", DbType.String, string.IsNullOrEmpty(refraction.rfc_sub2) ? "" : refraction.rfc_sub2);
                db.AddInParameter(dbCommand, "rfc_sub3", DbType.String, string.IsNullOrEmpty(refraction.rfc_sub3) ? "" : refraction.rfc_sub3);
                db.AddInParameter(dbCommand, "rfc_date2", DbType.String, string.IsNullOrEmpty(refraction.rfc_date2) ? "" : refraction.rfc_date2);
                db.AddInParameter(dbCommand, "rfc_cycloodsph1", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloodsph1) ? "" : refraction.rfc_cycloodsph1);
                db.AddInParameter(dbCommand, "rfc_cycloodsph2", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloodsph2) ? "" : refraction.rfc_cycloodsph2);
                db.AddInParameter(dbCommand, "rfc_cyclocyl1", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclocyl1) ? "" : refraction.rfc_cyclocyl1);
                db.AddInParameter(dbCommand, "rfc_cyclocyl2", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclocyl2) ? "" : refraction.rfc_cyclocyl2);
                db.AddInParameter(dbCommand, "rfc_cycloaxs1", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloaxs1) ? "" : refraction.rfc_cycloaxs1);
                db.AddInParameter(dbCommand, "rfc_cycloaxs2", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloaxs2) ? "" : refraction.rfc_cycloaxs2);
                db.AddInParameter(dbCommand, "rfc_cyclova1", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova1) ? "" : refraction.rfc_cyclova1);
                db.AddInParameter(dbCommand, "rfc_cyclova2", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova2) ? "" : refraction.rfc_cyclova2);
                db.AddInParameter(dbCommand, "rfc_cyclova3", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova3) ? "" : refraction.rfc_cyclova3);
                db.AddInParameter(dbCommand, "rfc_cyclova4", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova4) ? "" : refraction.rfc_cyclova4);
                db.AddInParameter(dbCommand, "rfc_cycloadd1", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloadd1) ? "" : refraction.rfc_cycloadd1);
                db.AddInParameter(dbCommand, "rfc_cycloadd2", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloadd2) ? "" : refraction.rfc_cycloadd2);
                db.AddInParameter(dbCommand, "rfc_cyclova5", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova5) ? "" : refraction.rfc_cyclova5);
                db.AddInParameter(dbCommand, "rfc_cyclova6", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova6) ? "" : refraction.rfc_cyclova6);
                db.AddInParameter(dbCommand, "rfc_cyclova7", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova7) ? "" : refraction.rfc_cyclova7);
                db.AddInParameter(dbCommand, "rfc_cyclova8", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclova8) ? "" : refraction.rfc_cyclova8);
                db.AddInParameter(dbCommand, "rfc_cycloph1", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloph1) ? "" : refraction.rfc_cycloph1);
                db.AddInParameter(dbCommand, "rfc_cycloph2", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloph2) ? "" : refraction.rfc_cycloph2);
                db.AddInParameter(dbCommand, "rfc_cycloph3", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloph3) ? "" : refraction.rfc_cycloph3);
                db.AddInParameter(dbCommand, "rfc_cycloph4", DbType.String, string.IsNullOrEmpty(refraction.rfc_cycloph4) ? "" : refraction.rfc_cycloph4);
                db.AddInParameter(dbCommand, "rfc_cyclo1", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclo1) ? "" : refraction.rfc_cyclo1);
                db.AddInParameter(dbCommand, "rfc_cyclo2", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclo2) ? "" : refraction.rfc_cyclo2);
                db.AddInParameter(dbCommand, "rfc_cyclo3", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclo3) ? "" : refraction.rfc_cyclo3);
                db.AddInParameter(dbCommand, "rfc_date3", DbType.String, string.IsNullOrEmpty(refraction.rfc_date3) ? "" : refraction.rfc_date3);
                db.AddInParameter(dbCommand, "rfc_dryodsph1", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryodsph1) ? "" : refraction.rfc_dryodsph1);
                db.AddInParameter(dbCommand, "rfc_dryodsph2", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryodsph2) ? "" : refraction.rfc_dryodsph2);
                db.AddInParameter(dbCommand, "rfc_drycyl1", DbType.String, string.IsNullOrEmpty(refraction.rfc_drycyl1) ? "" : refraction.rfc_drycyl1);
                db.AddInParameter(dbCommand, "rfc_drycyl2", DbType.String, string.IsNullOrEmpty(refraction.rfc_drycyl2) ? "" : refraction.rfc_drycyl2);
                db.AddInParameter(dbCommand, "rfc_dryaxs1", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryaxs1) ? "" : refraction.rfc_dryaxs1);
                db.AddInParameter(dbCommand, "rfc_dryaxs2", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryaxs2) ? "" : refraction.rfc_dryaxs2);
                db.AddInParameter(dbCommand, "rfc_dryva1", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva1) ? "" : refraction.rfc_dryva1);
                db.AddInParameter(dbCommand, "rfc_dryva2", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva2) ? "" : refraction.rfc_dryva2);
                db.AddInParameter(dbCommand, "rfc_dryva3", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva3) ? "" : refraction.rfc_dryva3);
                db.AddInParameter(dbCommand, "rfc_dryva4", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva4) ? "" : refraction.rfc_dryva4);
                db.AddInParameter(dbCommand, "rfc_dryadd1", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryadd1) ? "" : refraction.rfc_dryadd1);
                db.AddInParameter(dbCommand, "rfc_dryadd2", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryadd2) ? "" : refraction.rfc_dryadd2);
                db.AddInParameter(dbCommand, "rfc_dryva5", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva5) ? "" : refraction.rfc_dryva5);
                db.AddInParameter(dbCommand, "rfc_dryva6", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva6) ? "" : refraction.rfc_dryva6);
                db.AddInParameter(dbCommand, "rfc_dryva7", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva7) ? "" : refraction.rfc_dryva7);
                db.AddInParameter(dbCommand, "rfc_dryva8", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryva8) ? "" : refraction.rfc_dryva8);
                db.AddInParameter(dbCommand, "rfc_dryph1", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryph1) ? "" : refraction.rfc_dryph1);
                db.AddInParameter(dbCommand, "rfc_dryph2", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryph2) ? "" : refraction.rfc_dryph2);
                db.AddInParameter(dbCommand, "rfc_dryph3", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryph3) ? "" : refraction.rfc_dryph3);
                db.AddInParameter(dbCommand, "rfc_dryph4", DbType.String, string.IsNullOrEmpty(refraction.rfc_dryph4) ? "" : refraction.rfc_dryph4);
                db.AddInParameter(dbCommand, "rfc_dry1", DbType.String, string.IsNullOrEmpty(refraction.rfc_dry1) ? "" : refraction.rfc_dry1);
                db.AddInParameter(dbCommand, "rfc_dry2", DbType.String, string.IsNullOrEmpty(refraction.rfc_dry2) ? "" : refraction.rfc_dry2);
                db.AddInParameter(dbCommand, "rfc_dry3", DbType.String, string.IsNullOrEmpty(refraction.rfc_dry3) ? "" : refraction.rfc_dry3);
                db.AddInParameter(dbCommand, "rfc_autodoc", DbType.String, string.IsNullOrEmpty(refraction.rfc_autodoc) ? "" : refraction.rfc_autodoc);
                db.AddInParameter(dbCommand, "rfc_cyclodoc", DbType.String, string.IsNullOrEmpty(refraction.rfc_cyclodoc) ? "" : refraction.rfc_cyclodoc);
                db.AddInParameter(dbCommand, "rfc_drydoc", DbType.String, string.IsNullOrEmpty(refraction.rfc_drydoc) ? "" : refraction.rfc_drydoc);
                db.AddInParameter(dbCommand, "rfc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "rfcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _rfcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "rfcId"));
                return _rfcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteRefractionForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Refraction_Form_Delete");

                db.AddInParameter(dbCommand, "rfc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "rfc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "rfc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _rfc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "rfc_output"));

                return _rfc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetRefractionFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Refraction_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "rfc_appId", DbType.Int32, appId);
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
