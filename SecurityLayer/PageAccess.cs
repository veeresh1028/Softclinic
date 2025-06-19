using DataAccessLayer;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System;

namespace SecurityLayer
{
    public class PageAccess
    {
        public static bool isAllow(int pageId, int empId, int action)
        {
            int haveAccess= Rights.HavePageAccess(pageId, empId, action);

            if (haveAccess == 1) return true;
            else return false;
        }

        public static Dictionary<int, bool> HaveMenuAccess(int EmpId)
        {
            try
            {
                Dictionary<int, bool> dict = new Dictionary<int, bool>();
                
                DataTable dt = Rights.HaveMenuAccess(EmpId);

                foreach (DataRow dr in dt.Rows)
                {
                    int _val = string.IsNullOrEmpty(dr["isVisible"].ToString()) ? 0 : int.Parse(dr["isVisible"].ToString());
                    bool _isValue = (_val == 1) ? true: false;
                    dict.Add(int.Parse(dr["PageId"].ToString()), _isValue);
                }
                return dict;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
