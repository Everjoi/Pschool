using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pschool.Application.CQRS.ParentFolder.Commands.CreateParent;
using Pschool.Application.CQRS.ParentFolder.Commands.DeleteParent;
using Pschool.Application.CQRS.ParentFolder.Commands.UpdateParent;
using Pschool.Application.CQRS.ParentFolder.Queries.GetParentById;
using Pschool.Application.DTOs;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;

namespace Pschool.Presentation.Controllers.HomeController
{
    public class ParentController : ControllerBase
    {
        private readonly ILogger<ParentController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ParentController(ILogger<ParentController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("/api/parent")]
        public async Task<ActionResult<Result<List<ParentDto>>>> CreateParent([FromBody] CreateParentCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("/api/delete-parent")]
        public async Task<ActionResult<Result<List<Guid>>>> DeleteParent([FromBody] Guid parentId)
        {
            var command = new DeleteParentCommand { ParentId = parentId };
            var result = await _mediator.Send(command);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        [Route("/api/getParent")]
        public async Task<ActionResult<Result<ParentDto>>> GetParentById([FromBody] Guid parentId)
        {
            var request = new GetParentByIdQuery { ParentId = parentId };
            var result = await _mediator.Send(request);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        
        [HttpPost]
        [Route("api/updateParent")]
        public async Task<ActionResult<Result<ParentDto>>> UpdateParent([FromBody] Parent parent)
        {
            var updateCommand = _mapper.Map<UpdateParentCommand>(parent);
            var result = await _mediator.Send(updateCommand);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
