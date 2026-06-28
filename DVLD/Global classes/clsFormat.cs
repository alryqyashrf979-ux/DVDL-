using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global_classes
{
    internal static class clsFormat
    
    {
        static public string FormatDateToString(DateTime date)
        {
            return date.ToString("dd/mm/yyyy");
        }
    }
}
