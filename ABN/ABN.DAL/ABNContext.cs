using System;
using System.Collections.Generic;
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

        public ABNContext() : base(connectionStringName, backendConfiguration, metadataContainer) { }

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
    }
}
