using MaestroMunicipios.Application.Command;
using MaestroMunicipios.Application.Query;
using MaestroMunicipios.Domain.Entities;
using MaestroMunicipios.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaestroMunicipios.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentManagerController : ControllerBase
    {
        private readonly IMediator _Mediator;
        private readonly CityManagerService _CityManagerService;

        public DepartmentManagerController(IMediator mediator, CityManagerService cityManagerService)
        {
            _Mediator = mediator;
            _CityManagerService = cityManagerService;
        }

        [HttpPost]
        [Route("addCity")]
        public async Task<ActionResult> AddCityToDepartment([FromBody] AddCityCommand request)
        {
            var updateDepartment= await _Mediator.Send(request).ConfigureAwait(false);
            if (updateDepartment.Id==0)
            {
              return  BadRequest("The name of this city already exist.");
            }
            else
            {
                return Ok(updateDepartment);
            }
        }

        [HttpPost]
        [Route("updateCity")]
        public async Task<Department> UpdateCity([FromBody] UpdateCityCommand request)
        {
            return await _Mediator.Send(request).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("deleteCity")]
        public async Task<Department> DeleteCity([FromBody] DeleteCityCommand request)
        {
            return await _Mediator.Send(request).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("getDepartments")]
        public async Task<List<Department>> GetDepartments()
        {
            return await _CityManagerService.GetDepartments().ConfigureAwait(false);
        }

        [HttpGet]
        [Route("getDepartmentById")]
        public async Task<Department> GetDepartmentById([FromQuery] GetDepartmentByIdQuery request)
        {
            return await _CityManagerService.GetDepartmentById(request.IdDepartment).ConfigureAwait(false);
        }
    }
}
