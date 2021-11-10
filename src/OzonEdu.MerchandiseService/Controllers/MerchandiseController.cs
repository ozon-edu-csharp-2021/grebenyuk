using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeMerchAggregate;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Abstract;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseTicketsService _merchandiseTicketsService;
        private readonly IMediator _mediator;

        public MerchandiseController(IMerchandiseTicketsService merchandiseTicketsService, IMediator mediator)
        {
            _merchandiseTicketsService = merchandiseTicketsService;
            _mediator = mediator;
        }
        
        /// <summary>
        /// Получить информацию о выдаче мерча
        /// </summary>
        /// <param name="employeeId">Employee id</param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("{employeeId:long}")]
        public async Task<ActionResult<MerchandiseTicketResponse>> GetById(long employeeId, CancellationToken token)
        {
            var query = new GetEmployeeMerch
            {
                EmployeeId = employeeId
            };
            var result = await _mediator.Send(query, token);
            // todo refact here
            var merchandiseTicket = await _merchandiseTicketsService.GetByIdAsync(employeeId, token);
            if (result is null)
            {
                return NotFound();
            }

            // todo map MerchandiseTicket to MerchandiseTicketResponse
            var response = new MerchandiseTicketResponse
            {
                Id = merchandiseTicket.Id,
                EmployeeId = merchandiseTicket.EmployeeId,
                Sku = merchandiseTicket.Sku,
            };
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MerchandiseTicketResponse>> Add(MerchandiseTicketPostRequest request, 
            CancellationToken token)
        {
            var command = new CreateTicketCommand()
            {
                EmployeeId = request.EmployeeId,
                Sku = request.Sku
            };

            var result = await _mediator.Send(command, token);

            // todo refact here
            var createdTicket = await _merchandiseTicketsService.AddAsync(
                new MerchandiseTicketCreationModel(request.EmployeeId, request.Sku),
                token);
            
            var response = new MerchandiseTicketResponse
            {
                Id = createdTicket.Id,
                EmployeeId = createdTicket.EmployeeId,
                Sku = createdTicket.Sku,
            };
            return Ok(response);
        }
    }
}