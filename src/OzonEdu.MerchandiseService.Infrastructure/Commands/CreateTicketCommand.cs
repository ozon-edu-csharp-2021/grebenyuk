using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands
{
    public class CreateTicketCommand : IRequest<long>
    {
        /// <summary>
        /// Id сотрудника
        /// </summary>
        public long EmployeeId { get; set; }
        
        /// <summary>
        /// Товарная позиция, которая выдается в качестве мерча
        /// </summary>
        public long Sku { get; set; }
    }
}