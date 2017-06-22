using ABN.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace ABN.DAL
{
    public class ABNMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            configurations.Add(GetMissingDataRecordMappingConfiguration());
            configurations.Add(GetStationHourAirQualityMappingConfiguration());

            return configurations;
        }

        protected override MetadataContainer CreateModel()
        {
            MetadataContainer container = base.CreateModel();
            container.NameGenerator.RemoveCamelCase = false;
            container.NameGenerator.ResolveReservedWords = false;
            container.NameGenerator.SourceStrategy = NamingSourceStrategy.Property;
            return container;
        }

        #region MappingConfigurations
        private MappingConfiguration<MissingDataRecord> GetMissingDataRecordMappingConfiguration()
        {
            MappingConfiguration<MissingDataRecord> configuration = new MappingConfiguration<MissingDataRecord>();

            configuration.MapType().ToTable("MissingDataRecords");

            configuration.HasProperty(x => x.Id).IsIdentity(KeyGenerator.Autoinc);
            configuration.HasProperty(x => x.Code).IsNotNullable().HasColumnType("nvarchar").HasLength(64);
            configuration.HasProperty(x => x.Exception).HasColumnType("nvarchar(max)");
            configuration.HasProperty(x => x.Conditions).HasColumnType("nvarchar(max)");
            configuration.HasProperty(x => x.Status).HasColumnType("bit");

            return configuration;
        }

        private MappingConfiguration<StationHourAirQuality> GetStationHourAirQualityMappingConfiguration()
        {
            MappingConfiguration<StationHourAirQuality> configuration = new MappingConfiguration<StationHourAirQuality>();

            configuration.MapType().ToTable("StationHourAirQualities");

            configuration.HasProperty(x => x.Id).IsIdentity(KeyGenerator.Autoinc);
            configuration.HasProperty(x => x.Code).IsNotNullable().HasColumnType("nvarchar").HasLength(64);
            configuration.HasProperty(x => x.PrimaryPollutant).HasColumnType("nvarchar").HasLength(64);
            configuration.HasProperty(x => x.Type).HasColumnType("nvarchar").HasLength(8);

            return configuration;
        }
        #endregion
    }
}
