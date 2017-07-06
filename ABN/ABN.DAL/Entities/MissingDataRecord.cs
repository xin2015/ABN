using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.DAL.Entities
{
    public class MissingDataRecord : IModificationEntity
    {
        private DateTime creationTime;
        public DateTime CreationTime
        {
            get
            {
                return creationTime;
            }
        }

        private DateTime lastModificationTime;
        public DateTime? LastModificationTime
        {
            get
            {
                return lastModificationTime;
            }
        }

        private string code;
        public string Code
        {
            get
            {
                return code;
            }
        }

        private string conditions;
        public string Conditions
        {
            get
            {
                return conditions;
            }
        }

        private DateTime time;
        public DateTime Time
        {
            get
            {
                return time;
            }
        }

        private bool status;
        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                lastModificationTime = DateTime.Now;
            }
        }

        private int missTimes;
        public int MissTimes
        {
            get
            {
                return missTimes;
            }
            set
            {
                missTimes = value;
                lastModificationTime = DateTime.Now;
            }
        }

        private string exception;
        public string Exception
        {
            get
            {
                return exception;
            }
            set
            {
                exception = value;
                lastModificationTime = DateTime.Now;
            }
        }

        public MissingDataRecord()
        {
            creationTime = DateTime.Now;
        }

        public MissingDataRecord(string code, string conditions, DateTime time) : this()
        {
            this.code = code;
            this.conditions = conditions;
            this.time = time;
        }

        public MissingDataRecord(string code, string conditions, DateTime time, string exception) : this(code, conditions, time)
        {
            this.exception = exception;
        }
    }
}
