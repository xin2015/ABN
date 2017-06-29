using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.DAL.Entities
{
    public class MissingDataRecord : IModificationEntity
    {
        private DateTime _creationTime;
        public DateTime CreationTime
        {
            get
            {
                return _creationTime;
            }
        }

        private DateTime _lastModificationTime;
        public DateTime? LastModificationTime
        {
            get
            {
                return _lastModificationTime;
            }
        }

        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
        }

        private string _conditions;
        public string Conditions
        {
            get
            {
                return _conditions;
            }
        }

        private DateTime _time;
        public DateTime Time
        {
            get
            {
                return _time;
            }
        }

        private bool _status;
        public bool Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                _lastModificationTime = DateTime.Now;
            }
        }

        private int _missTimes;
        public int MissTimes
        {
            get
            {
                return _missTimes;
            }
            set
            {
                _missTimes = value;
                _lastModificationTime = DateTime.Now;
            }
        }

        private string _exception;
        public string Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
                _lastModificationTime = DateTime.Now;
            }
        }

        public MissingDataRecord(string code, string conditions, DateTime time) : this()
        {
            _creationTime = DateTime.Now;
            _code = code;
            _conditions = conditions;
            _time = time;
        }
    }
}
