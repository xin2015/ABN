using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.DAL.Entities
{
    public interface ICodeTime
    {
        string Code { get; set; }
        DateTime Time { get; set; }
    }
}
