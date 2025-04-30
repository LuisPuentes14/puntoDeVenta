using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Metodologia
{
    public static class CONSTANS
    {
        public static  string USER { get; set; }
        public static string ROL { get; set; }
        public static void Reset() 
        { 
            USER = null;
            ROL = null;
        }
    }
}
