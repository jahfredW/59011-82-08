using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eval_maquette
{
    static class ObjectHelper
    {
        
            public static void Dump(this object data)
            {
                string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                Trace.WriteLine("");
                Trace.WriteLine(json);
            }
        
    }
}
