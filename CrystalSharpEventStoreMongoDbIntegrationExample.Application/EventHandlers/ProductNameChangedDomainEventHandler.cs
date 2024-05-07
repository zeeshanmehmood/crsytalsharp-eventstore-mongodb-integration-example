using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate.Events;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.EventHandlers
{
    public class ProductNameChangedDomainEventHandler : ISynchronousDomainEventHandler<ProductNameChangedDomainEvent>
    {
        public async Task Handle(ProductNameChangedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
