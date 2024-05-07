using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.Commands
{
    public class ChangeProductInfoCommand : ICommand<CommandExecutionResult<ProductResponse>>
    {
        public Guid GlobalUId { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
