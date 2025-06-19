using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
//Test
namespace ClinicSoft
{
    public class PageControl
    {
        public static bool haveAccess(int PageId, int Action)
        {
            int _empId = 0;
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            var sid = claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
            int.TryParse(sid, out _empId);

            if (_empId > 0)
            {
                return SecurityLayer.PageAccess.isAllow(PageId, _empId, Action);
            }
            else
            {
                return false;
            }

        }

        public static Dictionary<int, bool> getMenuAccess(int empId)
        {
            Dictionary<int, bool> dict = new Dictionary<int, bool>();

            if (empId > 0)
            {
                dict = SecurityLayer.PageAccess.HaveMenuAccess(empId);
            }

            return dict;
        }

        public static int getLoggedinId()
        {
            int _empId = 0;
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            var sid = claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
            int.TryParse(sid, out _empId);

            return _empId;
        }
    }
}