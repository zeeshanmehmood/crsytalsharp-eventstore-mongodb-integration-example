using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Infrastructure.EventStoresPersistence;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.Commands;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.CommandHandlers
{
    public class CreateProductCommandHandler : CommandHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IAggregateEventStore<string> _eventStore;

        public CreateProductCommandHandler(IAggregateEventStore<string> eventStore)
        {
            _eventStore = eventStore;
        }

        public override async Task<CommandExecutionResult<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Product product = Product.Create(request.Name, new ProductInfo(request.Sku, request.Price));

            await _eventStore.Store(product, cancellationToken).ConfigureAwait(false);

            ProductResponse response = new() { GlobalUId = product.GlobalUId, Name = product.Name };

            return await Ok(response);
        }
    }
}
