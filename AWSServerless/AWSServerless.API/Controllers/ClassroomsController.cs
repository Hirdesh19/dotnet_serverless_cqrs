using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerless.API.ResponseModels;
using AWSServerless.Domain.BTOs;
using AWSServerless.Domain.Commands.CreateClassroom;
using AWSServerless.Domain.Commands.DeleteClassroom;
using AWSServerless.Domain.Commands.UpdateClassroom;
using AWSServerless.Domain.DTOs;
using AWSServerless.Domain.Helpers;
using AWSServerless.Domain.Queries.Classroom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AWSServerless.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : BaseController
    {
        private readonly IClassroomQueries _classroomQueries;
        private IMediator _mediator;

        public ClassroomsController(
            IClassroomQueries classroomQueries,
            IMediator mediator
        ) {
            _classroomQueries = classroomQueries;
            _mediator = mediator;
        }

        // GET: api/<ClassroomController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TableQueryParams queryParams)
        {
            TableResult<ClassroomDto> result = await _classroomQueries
                .GetManyAsync(
                    c => c != null,
                    queryParams.Skip,
                    queryParams.Limit,
                    queryParams.SortProp,
                    queryParams.SortDir
                );

            return GenerateResponse(
                StatusType.Success,
                result.Values,
                count: result.Count
            );
        }

        // GET api/<ClassroomController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return GenerateResponse(StatusType.Success,
                await _classroomQueries.GetByIdAsync(id)
            );
        }

        // POST api/<ClassroomController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClassroomCommand command)
        {
            if (command == null)
            {
                return GenerateResponse(StatusType.Fail,
                    null,
                    "Invalid Parameters"
                );
            }

            return GenerateResponse(
                StatusType.Success,
                await _mediator.Send(command)
            );
        }

        // PUT api/<ClassroomController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClassroomCommand command)
        {

            if (command == null)
            {
                return GenerateResponse(StatusType.Fail,
                    null,
                    "Invalid Parameters"
                );
            }

            return GenerateResponse(
                StatusType.Success,
                await _mediator.Send(command)
            );
        }

        // DELETE api/<ClassroomController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteClassroomCommand command = new DeleteClassroomCommand
            {
                Id = id
            };

            bool result = await _mediator.Send(command);

            return GenerateResponse(
                result ? StatusType.Success : StatusType.Fail,
                result
            );
        }
    }
}
