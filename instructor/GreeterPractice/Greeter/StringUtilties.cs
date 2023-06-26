using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeter;
public static  class StringUtilties
{
    // Jayden => J****n
    public static string Elide(this string name)
    {
        if(name.Length == 1) { return name[0].ToString(); }
        if(name.Length == 2) {  return name[0].ToString() + "*"; }
        var result = name[0] + new string('*', name.Length - 2) + name[name.Length - 1];
        return result;
    }
}
 