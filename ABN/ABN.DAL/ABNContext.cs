using ABN.DAL.Entities;
using ABN.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace ABN.DAL
{
    public class ABNContext : OpenAccessContext, IUnitOfWork
    {
        static string connectionStringName = @"ABNConnection";
        static MetadataContainer metadataContainer = new ABNMetadataSource().GetModel();
        static BackendConfiguration backendConfiguration = new BackendConfiguration()
        {
            Backend = "MsSql",
            ProviderName = "System.Data.SqlClient"
        };

        Dictionary<string, string> mappingDic;

        public ABNContext() : base(connectionStringName, backendConfiguration, metadataContainer)
        {
            mappingDic = new Dictionary<string, string>();
            foreach (var item in Metadata.PersistentTypes)
            {
                mappingDic.Add(item.Name, item.Table.Name);
            }
        }

        public void UpdateSchema()
        {
            var handler = GetSchemaHandler();
            string script = null;
            try
            {
                script = handler.CreateUpdateDDLScript(null);
            }
            catch
            {
                bool throwException = false;
                try
                {
                    handler.CreateDatabase();
                    script = handler.CreateDDLScript();
                }
                catch
                {
                    throwException = true;
                }
                if (throwException)
                    throw;
            }

            if (string.IsNullOrEmpty(script) == false)
            {
                handler.ExecuteDDLScript(script);
            }
        }

        public virtual void AddBySqlBulkCopy(DataTable dt)
        {
            using (SqlBulkCopy sbc = new SqlBulkCopy(Connection.ConnectionString))
            {
                sbc.DestinationTableName = dt.TableName;
                sbc.BatchSize = 30000;
                foreach (DataColumn item in dt.Columns)
                {
                    sbc.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                }
                sbc.WriteToServer(dt);
            }
        }

        public virtual void AddBySqlBulkCopy<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity
        {
            DataTable dt = entities.GetDataTable(mappingDic[typeof(TEntity).Name]);
            AddBySqlBulkCopy(dt);
        }
    }
}
