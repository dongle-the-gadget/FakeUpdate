using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeUpdate.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CmdParameterAttribute : Attribute
    {
        public string Parameter { get; set; }

        public CmdParameterAttribute(string parameter)
        {
            Parameter = parameter;
        }
    }
}
