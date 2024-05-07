using System;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Api.Dto
{
    public class ChangeProductNameRequest
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
