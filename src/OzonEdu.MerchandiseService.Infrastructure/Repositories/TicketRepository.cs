using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.CreateTicketAggregate.Abstract;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Abstract;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _connectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;

        public TicketRepository(IDbConnectionFactory<NpgsqlConnection> connectionFactory, IChangeTracker changeTracker)
        {
            _connectionFactory = connectionFactory;
            _changeTracker = changeTracker;
        }
        
        public async Task<Ticket> CreateAsync(Ticket ticketToCreate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                INSERT INTO tickets (employee_id, sku, status, created_at, updated_at)
                VALUES(:EmployeeId, :Sku, :TicketStatusId, :CreatedAt, :UpdatedAt)";
            
            var parameters = new
            {
                EmployeeId = ticketToCreate.Employee.EmployeeId,
                Sku = ticketToCreate.Sku.Value,
                TicketStatusId = ticketToCreate.TicketStatus.Id,
                CreatedAt = ticketToCreate.CreatedAt,
                UpdatedAt = ticketToCreate.UpdatedAt
            };
            
            var commandDefinition = new CommandDefinition(
                query,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken
            );
            
            
            var connection = await _connectionFactory.CreateConnection(cancellationToken);
            
            var createdTicketId = await connection.ExecuteScalarAsync(commandDefinition);

            if (createdTicketId != null 
                && ulong.TryParse(createdTicketId.ToString(), out var returnedId))
            {
                ticketToCreate.SetTicketNumber(returnedId);
            }
            else
            {
                throw new Exception("Record in the database does not exist.");
            }
            
            _changeTracker.Track(ticketToCreate);
            return ticketToCreate;
        }

        public async Task<Ticket> UpdateAsync(Ticket ticketToUpdate, CancellationToken cancellationToken = default)
        {
            /*const string query = @"
                UPDATE tickets
                SET employee_id = :EmployeeId, 
                    sku = :Sku, 
                    status = :TicketStatusId,
                    created_at = :CreatedAt,
                    updated_at = :UpdatedAt
                WHERE id = :Id;";*/

            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsByEmployeeIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default)
        {
            const string query = @"
                SELECT id AS Id,
                       employee_id AS EmployeeId,
                       sku AS Sku,
                       status AS TicketStatusId,
                       created_at AS CreatedAt,
                       updated_at AS UpdatedAt
                FROM tickets 
                WHERE employee_id = :EmployeeId;";
            
            var parameters = new
            {
                EmployeeId = employeeId.Value,
            };

            var commandDefinition = new CommandDefinition(
                query,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken
            );

            var connection = await _connectionFactory.CreateConnection(cancellationToken);

            var result = await connection.QueryAsync<Models.Ticket>(commandDefinition);

            return result.Select(t =>
                {
                    var ticket = new Ticket(
                        new Employee(new EmployeeId(t.EmployeeId)),
                        new Sku(t.Sku),
                        // todo вот хз как тут мапить имя...
                        new TicketStatus(t.TicketStatusId, string.Empty),
                        t.CreatedAt,
                        t.UpdatedAt);
                    
                    ticket.SetTicketNumber(t.Id);

                    return ticket;
                }
            );
        }
    }
}