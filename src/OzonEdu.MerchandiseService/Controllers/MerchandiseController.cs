using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
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

        public MerchandiseController(IMerchandiseTicketsService merchandiseTicketsService)
        {
            _merchandiseTicketsService = merchandiseTicketsService;
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
            var merchandiseTicket = await _merchandiseTicketsService.GetByIdAsync(employeeId, token);
            if (merchandiseTicket is null)
            {
                return NotFound();
            }

            // todo map MerchandiseTicket to MerchandiseTicketResponse
            var response = new MerchandiseTicketResponse
            {
                Id = merchandiseTicket.Id,
                EmployeeId = merchandiseTicket.EmployeeId,
                ItemId = merchandiseTicket.ItemId,
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
            var createdTicket = await _merchandiseTicketsService.AddAsync(
                new MerchandiseTicketCreationModel(request.EmployeeId, request.ItemId),
                token);
            
            // todo map MerchandiseTicket to MerchandiseTicketResponse
            var response = new MerchandiseTicketResponse
            {
                Id = createdTicket.Id,
                EmployeeId = createdTicket.EmployeeId,
                ItemId = createdTicket.ItemId,
            };
            return Ok(response);
        }
    }
}