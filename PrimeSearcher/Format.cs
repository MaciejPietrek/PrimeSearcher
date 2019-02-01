using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSearcher
{
    class Format
    {
        public Format(string nest, string form, string separator = null)
        {
            Nest = nest;
            Form = form;
            Separator = separator;
        }

        public string Nest { get; }
        public string Form { get; }
        public string Separator { get; }
    }
}
