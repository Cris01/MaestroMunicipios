using MaestroMunicipios.Application.Command;
using MaestroMunicipios.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaestroMunicipios.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentManagerController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public DepartmentManagerController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpPost]
        [Route("addCity")]
        public async Task<Department> AddCityToDepartment([FromBody] AddCityCommand request)
        {
            return await _Mediator.Send(request).ConfigureAwait(false);
        }
    }
}
