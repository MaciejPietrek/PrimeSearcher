using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSearcher
{
    class Formator
    {
        private static string ReplaceFirst(string text, string searchedString, string targetString)
        {
            int position = text.IndexOf(searchedString);
            return position < 0 ? text : text.Substring(0, position) + targetString + text.Substring(position + searchedString.Length);
        }
        
        public static string Process(string[] strings, Format format)
        {

            string formatedString = format.Form;

            foreach(string str in strings)
            {
                formatedString = ReplaceFirst(formatedString, format.Nest, str);
            }

            return formatedString;
        }

        public static string ProcessAll(string[] strings, Format format)
        {
            string formatedString = format.Form;

            foreach (string str in strings)
            {
                if (!formatedString.Contains(format.Nest))
                    formatedString += format.Form + format.Form;
                formatedString = ReplaceFirst(formatedString, format.Nest, str);
            }

            return formatedString;
        }
    }
}
