using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Visitor
    {
        public Visitor(string fullname) => Fullname = fullname;
       

        public string Fullname { get; set; }

        public override string ToString() => Fullname;
    }
}
