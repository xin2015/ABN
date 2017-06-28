using ABN.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ABNContext db = new ABNContext())
            {
                var meta = db.Metadata;
            }
        }
    }
}
