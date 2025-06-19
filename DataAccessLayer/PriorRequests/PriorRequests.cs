using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.PriorRequests;

namespace DataAccessLayer.PriorRequests
{
    public class PriorRequests
    {

        #region Search Prior Requests
        public static DataTable SearchPriorAppointments(PriorAppointmentSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Search_PriorAppointments");

                if (!string.IsNullOrEmpty(filters.branch_ids))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.branch_ids);
                }

                if (!string.IsNullOrEmpty(filters.dept_ids))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filters.dept_ids);
                }

                if (!string.IsNullOrEmpty(filters.doc_ids))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, filters.doc_ids);
                }

                if (!string.IsNullOrEmpty(filters.types))
                {
                    string app_type = string.Join(",", filters.types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, app_type);
                }

                if (!string.IsNullOrEmpty(filters.status))
                {
                    string app_status = string.Join(",", filters.status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_status", DbType.String, app_status);
                }

                if (filters.patient > 0)
                {
                    db.AddInParameter(dbCommand, "select_patient", DbType.Int32, filters.patient);
                }

                if (!string.IsNullOrEmpty(filters.ins_tpa))
                {
                    db.AddInParameter(dbCommand, "select_ins_tpa", DbType.String, filters.ins_tpa);
                }

                if (!string.IsNullOrEmpty(filters.ins_payer))
                {
                    db.AddInParameter(dbCommand, "select_ins_payers", DbType.String, filters.ins_payer);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
