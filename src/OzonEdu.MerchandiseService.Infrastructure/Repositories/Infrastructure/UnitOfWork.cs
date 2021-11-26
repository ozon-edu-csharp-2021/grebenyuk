using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Abstract;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private NpgsqlTransaction _npgsqlTransaction;
        
        private readonly IDbConnectionFactory<NpgsqlConnection> _connectionFactory;
        private readonly IPublisher _publisher;
        private readonly IChangeTracker _changeTracker;

        public UnitOfWork(
            IDbConnectionFactory<NpgsqlConnection> connectionFactory,
            IPublisher publisher,
            IChangeTracker changeTracker)
        {
            _connectionFactory = connectionFactory;
            _publisher = publisher;
            _changeTracker = changeTracker;
        }

        public async ValueTask StartTransaction(CancellationToken token)
        {
            if (_npgsqlTransaction is not null)
            {
                return;
            }
            var connection = await _connectionFactory.CreateConnection(token);
            _npgsqlTransaction = await connection.BeginTransactionAsync(token);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (_npgsqlTransaction is null)
            {
                throw new TransactionException("No active transaction started.");
            }

            var domainEvents = new Queue<INotification>(
                _changeTracker.TrackedEntities
                    .SelectMany(x =>
                    {
                        var events = x.DomainEvents.ToList();
                        x.ClearDomainEvents();
                        return events;
                    }));
            // Можно отправлять все и сразу через Task.WhenAll.
            while (domainEvents.TryDequeue(out var notification))
            {
                await _publisher.Publish(notification, cancellationToken);
            }

            await _npgsqlTransaction.CommitAsync(cancellationToken);
        }

        void IDisposable.Dispose()
        {
            _npgsqlTransaction?.Dispose();
            _connectionFactory?.Dispose();
        }
    }
}