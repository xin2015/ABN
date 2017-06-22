using ABN.DAL.Entities;
using ABN.DAL.Repositories;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace ABN.BLL.Syncs.Base
{
    public interface ISync
    {
        void Sync();
        void Cover();
        void Cover(IEnumerable<MissingDataRecord> list);
        void Cover(DateTime beginTime, DateTime endTime);
    }

    public class SyncBase<TEntity> : ISync where TEntity : IEntity
    {
        protected Repository<TEntity> Repository { get; set; }
        protected MissingDataRecordRepository MDRRepository { get; set; }
        protected ILog Logger { get; set; }
        protected string Code { get; set; }
        protected TimeSpan Interval { get; set; }

        public SyncBase(OpenAccessContext context)
        {
            Repository = new Repository<TEntity>(context);
            MDRRepository = new MissingDataRecordRepository(context);
            Code = typeof(TEntity).Name;
        }

        #region public
        public void Sync()
        {

        }

        public void Cover()
        {

        }

        public void Cover(IEnumerable<MissingDataRecord> list)
        {

        }

        public void Cover(DateTime beginTime, DateTime endTime)
        {

        }
        #endregion
    }
}
