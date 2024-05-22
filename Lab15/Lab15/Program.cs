using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public class Lab15Main
    {
        public static void Main()
        {
            var openText = "asya";
            Steganography.HideMessage(openText);
            Steganography.ShowMessage();
        }
    }
}