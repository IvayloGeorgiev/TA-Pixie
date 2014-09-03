#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace Bunniverse.Data	
{
	public partial class MySqlEntities : OpenAccessContext, IMySqlEntitiesUnitOfWork
	{
        private static string connectionStringName = @"MySqlEntities";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = new MySqlEntitiesMetadataSource();
		
		public MySqlEntities()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public MySqlEntities(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public MySqlEntities(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public MySqlEntities(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public MySqlEntities(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }

        public IQueryable<ShipsTravel> ShipsTravel
        {
            get
            {
                return this.GetAll<ShipsTravel>();
            }
        }

		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MySql";
			backend.ProviderName = "MySql.Data.MySqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of MySqlEntities.
		/// </summary>
		/// <param name="config">The BackendConfiguration of MySqlEntities.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface IMySqlEntitiesUnitOfWork : IUnitOfWork
	{
	}
}
#pragma warning restore 1591
