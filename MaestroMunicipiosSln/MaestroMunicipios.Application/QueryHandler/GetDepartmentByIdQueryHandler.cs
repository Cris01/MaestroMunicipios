using MaestroMunicipios.Application.Query;
using MaestroMunicipios.Domain.Entities;
using MaestroMunicipios.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaestroMunicipios.Application.QueryHandler
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
    {
        private readonly CityManagerService _CityManagerService;
        public GetDepartmentByIdQueryHandler(CityManagerService cityManagerService)
        {
            _CityManagerService = cityManagerService;
        }
        public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _CityManagerService.GetDepartmentById(request.IdDepartment).ConfigureAwait(false);
        }
    }
}