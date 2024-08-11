using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pschool.Application.CQRS.StudentFolder.Commands.CreateStudent;
using Pschool.Application.CQRS.StudentFolder.Commands.DeleteStudent;
using Pschool.Application.CQRS.StudentFolder.Commands.UpdateStudent;
using Pschool.Application.CQRS.StudentFolder.Queries.GetStudentById;
using Pschool.Application.CQRS.StudentFolder.Queries.GetStudentsByParent;
using Pschool.Application.DTOs;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;

namespace Pschool.Presentation.Controllers.HomeController
{
    public class StundetController : ControllerBase
    {
        private readonly ILogger<StundetController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StundetController(ILogger<StundetController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("api/student")]
        public async Task<ActionResult<Result<List<StudentDto>>>> CreateStundet([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        [Route("/api/delete-student")]
        public async Task<ActionResult<Result<List<Guid>>>> DeleteStundet([FromBody] Guid stundetId)
        {
            var command = new DeleteStudentCommand { StudentId = stundetId };
            var result = await _mediator.Send(command);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        [Route("/api/getStudent")]
        public async Task<ActionResult<Result<StudentDto>>> GetStudentById([FromBody] Guid studentId)
        {
            var request = new GetStudentByIdQuery { StudentId = studentId };
            var result = await _mediator.Send(request);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("api/students/getByParentId/")]
        public async Task<ActionResult<Result<List<StudentDto>>>> GetStudentByParentId([FromQuery] Guid parentId)
        {
            var request = new GetStudentByParentIdQuery { ParentId = parentId };
            var result = await _mediator.Send(request);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("api/updateStudent")]
        public async Task<ActionResult<Result<StudentDto>>> UpdateStudent([FromBody] Student student)
        {
            var updateCommand = _mapper.Map<UpdateStudentCommand>(student);
            var result = await _mediator.Send(updateCommand);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
