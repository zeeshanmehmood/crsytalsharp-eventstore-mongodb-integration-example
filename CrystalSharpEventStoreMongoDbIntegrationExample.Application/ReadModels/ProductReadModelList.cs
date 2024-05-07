using System.Collections.Generic;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.ReadModels
{
    public class ProductReadModelList
    {
        public IEnumerable<ProductReadModel> Products { get; set; }
    }
}
