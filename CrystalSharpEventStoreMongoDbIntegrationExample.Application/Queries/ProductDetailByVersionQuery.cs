using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.Queries
{
    public class ProductDetailByVersionQuery : IQuery<QueryExecutionResult<ProductReadModel>>
    {
        public Guid GlobalUId { get; set; }
        public long Version { get; set; }
    }
}
