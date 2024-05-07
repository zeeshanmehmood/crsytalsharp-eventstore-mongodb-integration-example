using CrystalSharp.Application;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.Commands
{
    public class CreateProductCommand : ICommand<CommandExecutionResult<ProductResponse>>
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
