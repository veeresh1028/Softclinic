using BusinessEntities.Appointment;
using BusinessEntities.Masters.Rights;
using BusinessEntities.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Designations
    {
        #region Designations Page Load
        public static List<BusinessEntities.Masters.Designations> GetDesignations(int? desiId)
        {
            List<BusinessEntities.Masters.Designations> designationlist = new List<BusinessEntities.Masters.Designations>();
            DataTable dt = DataAccessLayer.Masters.Designations.GetDesignations(desiId);

            foreach (DataRow dr in dt.Rows)
            {
                designationlist.Add(new BusinessEntities.Masters.Designations
                {
                    desiId = Convert.ToInt32(dr["desiId"]),
                    designation = dr["designation"].ToString(),
                    desi_status = dr["desi_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                });
            }
            return designationlist;
        }

        public static DataTable GetAllDesignations(int? desiId)
        {
            return DataAccessLayer.Masters.Designations.GetDesignations(desiId);
        }
        #endregion

        #region Designations CRUD Operations
        public static bool InsertUpdateDesignation(BusinessEntities.Masters.Designations designation)
        {
            return DataAccessLayer.Masters.Designations.InsertUpdateDesignation(designation);
        }

        public static int UpdateDesignationStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.Designations.UpdateDesignationStatus(tgId, tg_status);
        }

        public static List<BusinessEntities.Masters.EmployeesByDesignation> GetEmpDesignationById(int desiId)
        {
            List<BusinessEntities.Masters.EmployeesByDesignation> employeelist = new List<BusinessEntities.Masters.EmployeesByDesignation>();

            DataTable dt = DataAccessLayer.Masters.Designations.GetEmployeesByDesignation(desiId);

            foreach (DataRow dr in dt.Rows)
            {
                employeelist.Add(new BusinessEntities.Masters.EmployeesByDesignation
                {
                    empId = Convert.ToInt32(dr["empId"]),
                    emp_desig = Convert.ToInt32(dr["emp_desig"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_mob = dr["emp_mob"].ToString(),
                    emp_name = dr["emp_name"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    emp_desig_name = dr["emp_desig_name"].ToString(),
                    emp_status = dr["emp_status"].ToString()
                });
            }
            return employeelist;
        }

        public static DataTable GetProfessions(int? id)
        {
            return DataAccessLayer.Masters.Designations.GetProfessions(id);
        }

        public static List<CommonDDL> GetActiveDesignations(int? desiId)
        {
            DataTable dt = DataAccessLayer.Masters.Designations.GetActiveDesignations(desiId);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["desiid"].ToString());
                    _data.text = dr["designation"].ToString();
                    data.Add(_data);
                }
            }
            return data;
        }
        #endregion

        #region Employee Rights
        public static DesignationRights GetResourcesForRights(int desiId)
        {
            try
            {
                DesignationRights rights = new DesignationRights();

                DataSet ds = DataAccessLayer.Masters.Designations.GetResourcesForDesignationRights(desiId);

                List<BusinessEntities.Masters.Rights.Module> module_list = new List<BusinessEntities.Masters.Rights.Module>();
                List<BusinessEntities.Masters.Rights.Sub_Module> sub_module_list = new List<BusinessEntities.Masters.Rights.Sub_Module>();
                List<BusinessEntities.Masters.Rights.Pages> page_list = new List<BusinessEntities.Masters.Rights.Pages>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        BusinessEntities.Masters.Rights.Module mod = new BusinessEntities.Masters.Rights.Module();
                        mod.L1Id = Convert.ToInt32(dr["L1Id"]);
                        mod.L1_Value = dr["L1_Value"].ToString();
                        mod.L1_Status = dr["L1_Status"].ToString();

                        module_list.Add(mod);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        Sub_Module submod = new Sub_Module();
                        submod.L2Id = Convert.ToInt32(dr["L2Id"]);
                        submod.L1Id = Convert.ToInt32(dr["L1Id"]);
                        submod.L2_Value = dr["L2_Value"].ToString();
                        submod.L2_Status = dr["L2_Status"].ToString();

                        sub_module_list.Add(submod);
                    }
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        BusinessEntities.Masters.Rights.Pages page = new BusinessEntities.Masters.Rights.Pages();
                        page.L3Id = Convert.ToInt32(dr["L3Id"]);
                        page.L1Id = Convert.ToInt32(dr["L1Id"]);
                        page.L2Id = Convert.ToInt32(dr["L2Id"]);
                        page.L3_Value = dr["L3_Value"].ToString();
                        page.L3_Status = dr["L3_Status"].ToString();

                        page_list.Add(page);
                    }
                }

                rights.modules_list = module_list;
                rights.sub_modules_list = sub_module_list;
                rights.pages_list = page_list;

                List<string> checked_pages = new List<string>();

                int l1_cCount = 0;
                int l1_rCount = 0;
                int l1_uCount = 0;
                int l1_dCount = 0;
                int l1_eCount = 0;
                int l1_pCount = 0;
                int l1_aCount = 0;

                foreach (BusinessEntities.Masters.Rights.Module m in module_list)
                {
                    var sub_module = from submod in sub_module_list
                                     where submod.L1Id == m.L1Id
                                     select new { submod.L1Id, submod.L2Id, submod.L2_Value, submod.L2_Status };

                    int subModuleCount = sub_module.Count();

                    int l2_cCount = 0;
                    int l2_rCount = 0;
                    int l2_uCount = 0;
                    int l2_dCount = 0;
                    int l2_eCount = 0;
                    int l2_pCount = 0;
                    int l2_aCount = 0;

                    foreach (var sm in sub_module)
                    {
                        var page = from pg in page_list
                                   where pg.L2Id == sm.L2Id
                                   select new { pg.L1Id, pg.L2Id, pg.L3Id, pg.L3_Value };

                        int pagesCount = page.Count();

                        int cCount = 0;
                        int rCount = 0;
                        int uCount = 0;
                        int dCount = 0;
                        int eCount = 0;
                        int pCount = 0;
                        int aCount = 0;

                        foreach (var pg in page)
                        {
                            DataRow[] dr = ds.Tables[3].Select("L3Id = " + pg.L3Id);

                            if (dr.Length > 0)
                            {
                                bool isCreate = Convert.ToBoolean(dr[0]["isCreate"]);
                                bool isRead = Convert.ToBoolean(dr[0]["isRead"]);
                                bool isUpdate = Convert.ToBoolean(dr[0]["isUpdate"]);
                                bool isDelete = Convert.ToBoolean(dr[0]["isDelete"]);
                                bool isExport = Convert.ToBoolean(dr[0]["isExport"]);
                                bool isPrint = Convert.ToBoolean(dr[0]["isPrint"]);

                                if (isCreate)
                                {
                                    cCount++;
                                    checked_pages.Add("cl3_" + dr[0]["L3Id"]);
                                }

                                if (isRead)
                                {
                                    rCount++;
                                    checked_pages.Add("rl3_" + dr[0]["L3Id"]);
                                }

                                if (isUpdate)
                                {
                                    uCount++;
                                    checked_pages.Add("ul3_" + dr[0]["L3Id"]);
                                }

                                if (isDelete)
                                {
                                    dCount++;
                                    checked_pages.Add("dl3_" + dr[0]["L3Id"]);
                                }

                                if (isExport)
                                {
                                    eCount++;
                                    checked_pages.Add("el3_" + dr[0]["L3Id"]);
                                }

                                if (isPrint)
                                {
                                    pCount++;
                                    checked_pages.Add("pl3_" + dr[0]["L3Id"]);
                                }

                                if (isCreate && isRead && isUpdate && isDelete && isExport && isPrint)
                                {
                                    aCount++;
                                    checked_pages.Add("alll3_" + dr[0]["L3Id"]);
                                }
                            }
                        }

                        if (pagesCount == cCount)
                        {
                            l2_cCount++;
                            checked_pages.Add("cl2_" + sm.L2Id);
                        }

                        if (pagesCount == rCount)
                        {
                            l2_rCount++;
                            checked_pages.Add("rl2_" + sm.L2Id);
                        }

                        if (pagesCount == uCount)
                        {
                            l2_uCount++;
                            checked_pages.Add("ul2_" + sm.L2Id);
                        }

                        if (pagesCount == dCount)
                        {
                            l2_dCount++;
                            checked_pages.Add("dl2_" + sm.L2Id);
                        }

                        if (pagesCount == eCount)
                        {
                            l2_eCount++;
                            checked_pages.Add("el2_" + sm.L2Id);
                        }

                        if (pagesCount == pCount)
                        {
                            l2_pCount++;
                            checked_pages.Add("pl2_" + sm.L2Id);
                        }

                        if ((pagesCount == cCount) && (pagesCount == rCount) && (pagesCount == uCount) &&
                            (pagesCount == dCount) && (pagesCount == eCount) && (pagesCount == pCount))
                        {
                            l2_aCount++;
                            checked_pages.Add("alll2_" + sm.L2Id);
                        }
                    }

                    if (subModuleCount == l2_cCount)
                    {
                        l1_cCount++;
                        checked_pages.Add("cl1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_rCount)
                    {
                        l1_rCount++;
                        checked_pages.Add("rl1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_uCount)
                    {
                        l1_uCount++;
                        checked_pages.Add("ul1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_dCount)
                    {
                        l1_dCount++;
                        checked_pages.Add("dl1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_eCount)
                    {
                        l1_eCount++;
                        checked_pages.Add("el1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_pCount)
                    {
                        l1_pCount++;
                        checked_pages.Add("pl1_" + m.L1Id);
                    }

                    if ((subModuleCount == l2_cCount) && (subModuleCount == l2_rCount) && (subModuleCount == l2_uCount) &&
                        (subModuleCount == l2_dCount) && (subModuleCount == l2_eCount) && (subModuleCount == l2_pCount))
                    {
                        l1_aCount++;
                        checked_pages.Add("alll1_" + m.L1Id);
                    }
                }

                if (module_list.Count() == l1_cCount)
                {
                    checked_pages.Add("all_c");
                }

                if (module_list.Count() == l1_rCount)
                {
                    checked_pages.Add("all_r");
                }

                if (module_list.Count() == l1_uCount)
                {
                    checked_pages.Add("all_u");
                }

                if (module_list.Count() == l1_dCount)
                {
                    checked_pages.Add("all_d");
                }

                if (module_list.Count() == l1_eCount)
                {
                    checked_pages.Add("all_e");
                }

                if (module_list.Count() == l1_pCount)
                {
                    checked_pages.Add("all_p");
                }

                if ((module_list.Count() == l1_cCount) && (module_list.Count() == l1_rCount) && (module_list.Count() == l1_uCount) &&
                    (module_list.Count() == l1_dCount) && (module_list.Count() == l1_eCount) && (module_list.Count() == l1_pCount))
                {
                    checked_pages.Add("all_all");
                }

                rights.checked_pages = checked_pages;

                return rights;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string UpdateRights(List<BusinessEntities.Masters.Rights.DesignationPageAccess> rights)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DesiId", typeof(int));
            dt.Columns.Add("L3Id", typeof(int));
            dt.Columns.Add("isCreate", typeof(bool));
            dt.Columns.Add("isUpdate", typeof(bool));
            dt.Columns.Add("isRead", typeof(bool));
            dt.Columns.Add("isDelete", typeof(bool));
            dt.Columns.Add("isExport", typeof(bool));
            dt.Columns.Add("isPrint", typeof(bool));

            foreach (var right in rights)
            {
                DataRow dr = dt.NewRow();
                dr["DesiId"] = right.DesiId;
                dr["L3Id"] = right.L3Id;
                dr["isCreate"] = right.isCreate;
                dr["isUpdate"] = right.isUpdate;
                dr["isRead"] = right.isRead;
                dr["isDelete"] = right.isDelete;
                dr["isExport"] = right.isExport;
                dr["isPrint"] = right.isPrint;

                dt.Rows.Add(dr);
            }

            return DataAccessLayer.Masters.Designations.UpdateDesignationRights(dt);
        }
        #endregion
    }
}