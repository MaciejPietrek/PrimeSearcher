using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSearcher
{
    class Messenger
    {
        Action<string> function;
        Format format;

        public Messenger(Format format, Action<string> function)
        {
            this.function = function;
            this.format = format;
        }

        public void Write(string text)
        {
            function(Formator.Process(new string[] {text}, format));
        }

        public void Write(string[] texts)
        {
            function(Formator.Process(texts, format));
        }
    }
}
