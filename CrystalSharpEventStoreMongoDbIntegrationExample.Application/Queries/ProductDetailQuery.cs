using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.Queries
{
    public class ProductDetailQuery : IQuery<QueryExecutionResult<ProductReadModel>>
    {
        public Guid GlobalUId { get; set; }
    }
}
