using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.UI.StartScreen;

namespace MarkupConverter
{
    public class XamlToHtml
    {
        //definitions
        int cursor, ElementStart, ElementEnd, LineStart, LineEnd;
        int StartOfFile = 0;
        int EndOFFile;
        string original, code, ElementName, ElementProps, ElementID, NewElement, OldElement;

        public XamlToHtml(string source)
        {
            //preperation
            EndOFFile = source.Length;
            cursor = 0;
            original = code = source;
        }

        public string Convert()
        {



            //test
            //return "this is a try" + source;

            //root element

            string eleCode = "Page";
            int NameLendth = eleCode.Length;
            cursor = code.IndexOf(eleCode);
            ElementStart = cursor;
            ElementEnd = code.IndexOf(">") + 1;
            OldElement = code.Substring(ElementStart, ElementEnd);
            //ElementName = OldElement.Substring(0+1, 4);

            //find name

            //learn how store data as xml file, access this file and get the detinatio nlelemt n name
            ElementName = resources.GetString(eleCode);

            //find id
            if (OldElement.Contains("Name="))
            {
                int nameStart = OldElement.IndexOf(" Name=") + 7;
                int nameEnd = OldElement.IndexOf('"', nameStart);
                ElementID = OldElement.Substring(nameStart, nameEnd);
            }





        }

    }
}
