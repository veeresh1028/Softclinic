using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class WebToken
    {
        public int userId { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
    }

    public class RefreshToken
    {
        public string refresh_token { get; set; }
    }
}
