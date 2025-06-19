using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Marketing.Reports
{
    public class GraphicalReport
    {
        #region Graphical Report (Managed By / By Source / By Status)
        public static GraphicalChartsData GetGraphicalReport(BusinessEntities.Marketing.Reports.GraphicalReport _filters)
        {
            try
            {
                BusinessEntities.Marketing.Reports.GraphicalChartsData response = new BusinessEntities.Marketing.Reports.GraphicalChartsData();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);                   
                }

                DataSet ds = DataAccessLayer.Marketing.Reports.GraphicalReport.GetGraphicalReport(_filters);

                List<GraphicalManagedChart> managedbyList = new List<GraphicalManagedChart>();
                List<GraphicalSourceChart> sourceList = new List<GraphicalSourceChart>();
                List<GraphicalStatusChart> statusList = new List<GraphicalStatusChart>();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {                            
                            GraphicalManagedChart mb = new GraphicalManagedChart();
                            mb.labels = dr["app_madeby_name"].ToString();
                            mb.total = Convert.ToInt32(dr["total"]);
                            managedbyList.Add(mb);
                        }
                    }
                    else
                    {
                        GraphicalManagedChart mb = new GraphicalManagedChart();
                        mb.labels = "N/A";
                        mb.total = 0;
                        managedbyList.Add(mb);
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GraphicalSourceChart source = new GraphicalSourceChart();
                            source.labels = dr["app_source_name"].ToString();
                            source.total = Convert.ToInt32(dr["total"]);
                            sourceList.Add(source);
                        }
                    }
                    else
                    {
                        GraphicalSourceChart source = new GraphicalSourceChart();
                        source.labels = "N/A";
                        source.total = 0;
                        sourceList.Add(source);
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            GraphicalStatusChart status = new GraphicalStatusChart();
                            status.labels = dr["as_status"].ToString();
                            status.total = Convert.ToInt32(dr["total"]);
                            statusList.Add(status);
                        }
                    }
                    else
                    {
                        GraphicalStatusChart status = new GraphicalStatusChart();
                        status.labels = "N/A";
                        status.total = 0;
                        statusList.Add(status);
                    }
                }
                
                response.mbChart = managedbyList;
                response.sourceChart = sourceList;
                response.statusChart = statusList;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
