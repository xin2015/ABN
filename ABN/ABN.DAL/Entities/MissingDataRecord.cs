using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.DAL.Entities
{
    public class MissingDataRecord : IModificationEntity
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public string Code { get; set; }

        public DateTime Time { get; set; }

        public bool Status { get; set; }

        public int MissTimes { get; set; }

        public string Exception { get; set; }

        public string Conditions { get; set; }
    }
}
