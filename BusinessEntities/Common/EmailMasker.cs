using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
    public static class EmailMasker
    {
        private static string _PATTERN = @"(?<=[\w]{1})[\w-\._\+%\\]*(?=[\w]{1}@)|(?<=@[\w]{1})[\w-_\+%]*(?=\.)";

        public static string MaskEmail(this string s)
        {
            if (!s.Contains("@"))
                return new String('*', s.Length);
            if (s.Split('@')[0].Length < 4)
                return @"*@*.*";
            return Regex.Replace(s, _PATTERN, m => new string('*', m.Length));
        }
    }
}
