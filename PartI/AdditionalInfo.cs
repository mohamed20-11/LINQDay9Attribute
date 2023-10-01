using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartI
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, 
        Inherited =false, AllowMultiple =true)]
    public class AdditionalInfo : Attribute
    {
        public AdditionalInfo(string data)
        {
            Console.WriteLine("Additional");
        }
    }


    public class MoreInfo : AdditionalInfo
    {
        public MoreInfo () : base("")
            {}
    }
}
