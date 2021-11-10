using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeMerchAggregate;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchandiseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Получить информацию о выдаче мерча
        /// </summary>
        /// <param name="employeeId">Employee id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{employeeId:long}")]
        public async Task<ActionResult<EmployeeMerchResponse>> GetById(long employeeId, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeMerch
            {
                EmployeeId = employeeId
            };
            
            var result = await _mediator.Send(query, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            // todo ок или не ок?
            var response = new EmployeeMerchResponse
            {
                Items = result.Items.Select(i => new Item
                {
                    Sku = i.Sku.Value,
                    Name = i.Name.Value,
                    ClothingSizeId = i.ClothingSize.Id,
                    ItemTypeId = i.ItemType.Id
                })
            };
            
            return Ok(response);
        }

        /// <summary>
        /// Создать тикет на выдачу мерча
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<long>> Add(MerchandiseTicketPostRequest request, 
            CancellationToken cancellationToken)
        {
            var command = new CreateTicketCommand
            {
                EmployeeId = request.EmployeeId,
                Sku = request.Sku
            };

            var createdTicketId = await _mediator.Send(command, cancellationToken);
            
            return Ok(createdTicketId);
        }
    }
}