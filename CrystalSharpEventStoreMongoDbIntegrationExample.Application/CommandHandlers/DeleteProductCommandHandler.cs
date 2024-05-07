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
    public class DeleteProductCommandHandler : CommandHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IAggregateEventStore<string> _eventStore;

        public DeleteProductCommandHandler(IAggregateEventStore<string> eventStore)
        {
            _eventStore = eventStore;
        }

        public override async Task<CommandExecutionResult<DeleteProductResponse>> Handle(DeleteProductCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Product existingProduct = await _eventStore.Get<Product>(request.GlobalUId, cancellationToken).ConfigureAwait(false);

            if (existingProduct == null)
            {
                await Fail("Product not found.");
            }

            await _eventStore.Delete<Product>(request.GlobalUId, cancellationToken).ConfigureAwait(false);

            DeleteProductResponse response = new() { GlobalUId = existingProduct.GlobalUId };

            return await Ok(response);
        }
    }
}
