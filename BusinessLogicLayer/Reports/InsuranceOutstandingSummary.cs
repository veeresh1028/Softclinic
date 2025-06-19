using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer.Reports
{
    public class InsuranceOutstandingSummary
    {
        public static DataTable SearchInsuranceOutstandingSummary()
        {
            try
            {
                BusinessEntities.Reports.InsuranceOutstandingSummary io_report = new BusinessEntities.Reports.InsuranceOutstandingSummary();

                DataTable dt = DataAccessLayer.Reports.InsuranceOutstandingSummary.SearchInsuranceOutstandingSummary();

                DataTable table = new DataTable();

                // Dynamic Columns
                int count = 12 + DateTime.Now.Month;

                table.Columns.Add("Insurance/Period", typeof(string));

                for (int i = 0; i > -count; i--)
                {
                    table.Columns.Add(DateTime.Now.AddMonths(i).ToString("MMMM") + " - " + DateTime.Now.AddMonths(i).Year, typeof(decimal));
                }

                int count2 = DateTime.Now.AddMonths(-count).Year;
                table.Columns.Add(count2.ToString(), typeof(decimal));
                table.Columns.Add((count2 - 1).ToString(), typeof(decimal));
                table.Columns.Add((count2 - 2).ToString(), typeof(decimal));
                table.Columns.Add((count2 - 3).ToString(), typeof(decimal));
                table.Columns.Add((count2 - 4).ToString(), typeof(decimal));

                // Dynamic Rows
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int dcount = 12 + DateTime.Now.Month;
                        DataRow newRow = table.NewRow();
                        newRow["Insurance/Period"] = dr["ic_name"].ToString();

                        for (int x = 0; x > -dcount; x--)
                        {
                            int month = DateTime.Now.AddMonths(x).Month;
                            int year = DateTime.Now.AddMonths(x).Year;
                            decimal dynamicValue = DataAccessLayer.Reports.InsuranceOutstandingSummary.GetBalance(Convert.ToInt32(dr["inv_insurance"]), month, year);
                            newRow[DateTime.Now.AddMonths(x).ToString("MMMM") + " - " + year] = dynamicValue.ToString("N2");
                        }

                        int count2_2 = DateTime.Now.AddMonths(-dcount).Year;
                        newRow[count2_2.ToString()] = DataAccessLayer.Reports.InsuranceOutstandingSummary.GetBalance(Convert.ToInt32(dr["inv_insurance"]), 0, count2_2).ToString("N2");
                        newRow[(count2_2 - 1).ToString()] = DataAccessLayer.Reports.InsuranceOutstandingSummary.GetBalance(Convert.ToInt32(dr["inv_insurance"]), 0, (count2_2 - 1)).ToString("N2");
                        newRow[(count2_2 - 2).ToString()] = DataAccessLayer.Reports.InsuranceOutstandingSummary.GetBalance(Convert.ToInt32(dr["inv_insurance"]), 0, (count2_2 - 2)).ToString("N2");
                        newRow[(count2_2 - 3).ToString()] = DataAccessLayer.Reports.InsuranceOutstandingSummary.GetBalance(Convert.ToInt32(dr["inv_insurance"]), 0, (count2_2 - 3)).ToString("N2");
                        newRow[(count2_2 - 4).ToString()] = DataAccessLayer.Reports.InsuranceOutstandingSummary.GetBalance(Convert.ToInt32(dr["inv_insurance"]), 0, (count2_2 - 4)).ToString("N2");

                        table.Rows.Add(newRow);
                    }
                }

                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}