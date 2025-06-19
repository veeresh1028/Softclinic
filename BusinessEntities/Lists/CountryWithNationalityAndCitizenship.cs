using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Lists
{
    public class CountryWithNationalityAndCitizenship
    {
        public Countries countries { get; set; }
        public Nationalities nationalities { get; set; }
        public Citizenship citizenship { get; set; }
    }
}
