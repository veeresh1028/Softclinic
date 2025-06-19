using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class TreatmentGroups
    {
        #region Treatment Groups (Page Load)
        public static List<BusinessEntities.Masters.TreatmentGroups> GetTreatmentGroupLists(int? tgId)
        {
            List<BusinessEntities.Masters.TreatmentGroups> tglist = new List<BusinessEntities.Masters.TreatmentGroups>();
            DataTable dt = DataAccessLayer.Masters.TreatmentGroups.GetTreatmentGroups(tgId);

            foreach (DataRow dr in dt.Rows)
            {
                tglist.Add(new BusinessEntities.Masters.TreatmentGroups
                {
                    tgId = Convert.ToInt32(dr["tgId"]),
                    tg_group = dr["tg_group"].ToString(),
                    tg_cost = DataValidation.isDecimalValid(dr["tg_cost"].ToString()),
                    tg_disc = DataValidation.isDecimalValid(dr["tg_disc"].ToString()),
                    tg_vat = DataValidation.isDecimalValid(dr["tg_vat"].ToString()),
                    tg_status = dr["tg_status"].ToString(),
                    actionvisible = dr["ActionVisible"].ToString()
                });
            }
            return tglist;
        }
        #endregion

        #region Treatment Groups CRUD Opertaions
        public static bool InsertUpdateTreatmentGroups(BusinessEntities.Masters.TreatmentGroups treatmentgroup)
        {
            return DataAccessLayer.Masters.TreatmentGroups.InsertUpdateTreatmentGroups(treatmentgroup);
        }

        public static int UpdateTreatmentGroupStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.TreatmentGroups.UpdateUpdateTreatmentStatus(tgId, tg_status);
        }

        public static int GenerateSalesAccount(int tgId)
        {
            return DataAccessLayer.Masters.TreatmentGroups.GenerateSalesAccount(tgId);
        }
        #endregion

        #region Package Services (Document Load)
        public static List<BusinessEntities.Masters.Packages> GetPackages(int tgId)
        {
            List<BusinessEntities.Masters.Packages> packages = new List<BusinessEntities.Masters.Packages>();
            DataTable dt = DataAccessLayer.Masters.TreatmentGroups.GetPackages(tgId);

            foreach (DataRow dr in dt.Rows)
            {
                packages.Add(new BusinessEntities.Masters.Packages
                {
                    psId = Convert.ToInt32(dr["psId"]),
                    ps_madeby = Convert.ToInt32(dr["ps_madeby"]),
                    ps_status = dr["ps_status"].ToString(),
                    ps_oriPrice = DataValidation.isDecimalValid(dr["ps_oriPrice"].ToString()),
                    ps_disPrice = DataValidation.isDecimalValid(dr["ps_disPrice"].ToString()),
                    tr_name = dr["tr_name"].ToString(),
                    tr_code = dr["tr_code"].ToString(),
                    ps_qty = int.Parse(dr["ps_qty"].ToString()),
                    actionvisible = dr["ActionVisible"].ToString()
                });
            }
            return packages;
        }

        
        #endregion

        #region Package Services CRUD Operations
        public static bool InsertPackage(BusinessEntities.Masters.Packages package)
        {
            return DataAccessLayer.Masters.TreatmentGroups.InsertPackage(package);
        }

        public static int UpdatePackageStatus(int psId, string ps_status)
        {
            return DataAccessLayer.Masters.TreatmentGroups.UpdatePackageStatus(psId, ps_status);
        }

        public static List<CommonDDL> GetCPTCodes(string query)
        {
            DataTable dt = DataAccessLayer.Masters.TreatmentGroups.GetCPTCodes(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
        #endregion
    }
}