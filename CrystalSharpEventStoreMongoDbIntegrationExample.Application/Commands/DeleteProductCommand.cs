using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreMongoDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreMongoDbIntegrationExample.Application.Commands
{
    public class DeleteProductCommand : ICommand<CommandExecutionResult<DeleteProductResponse>>
    {
        public Guid GlobalUId { get; set; }
    }
}
