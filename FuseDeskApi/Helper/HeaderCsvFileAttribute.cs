using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuseDeskApi.Helper
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class HeaderCsvFileAttribute : Attribute
    {
        public string HeaderName { get; set; }

    }
}
