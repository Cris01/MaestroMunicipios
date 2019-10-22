using MaestroMunicipios.Application.Command;
using MaestroMunicipios.Domain.Entities;
using MaestroMunicipios.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaestroMunicipios.Application.CommandHandler
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Department>
    {
        private readonly CityManagerService _CityManagerService;

        public UpdateCityCommandHandler(CityManagerService cityManagerService)
        {
            _CityManagerService = cityManagerService;
        }
        public async Task<Department> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            return await _CityManagerService.UpdateCity(request.IdDepartment, request.CodeCity, request.NameCity, request.IdCity).ConfigureAwait(false);
        }
    }
}
