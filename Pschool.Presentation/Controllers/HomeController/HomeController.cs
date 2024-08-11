using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pschool.Application.CQRS.ParentFolder.Queries.GetAllParents;
using Pschool.Application.CQRS.StudentFolder.Queries.GetAllStudents;
using Pschool.Application.DTOs;
using Pschool.Shared.Results;


namespace Pschool.Presentation.Controller.HomeController
{
    [ApiController]
    [Route("")]
    [EnableRateLimiting("fixedWindow")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet]
        [Route("/ping")]
        public IActionResult Ping()
        {    
            return Ok("pong");
        }


        [HttpGet]
        [Route("/api/parents")]
        public async Task<ActionResult<Result<List<ParentDto>>>> GetAllParents()
        {
            return await _mediator.Send(new GetAllParentsQuery());
        }

        [HttpGet]
        [Route("/api/students")]
        public async Task<ActionResult<Result<List<StudentDto>>>> GetAllStudents()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }




    }
}
