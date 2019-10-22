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
    class AddCityCommandHandler : IRequestHandler<AddCityCommand, Department>
    {
        private readonly CityManagerService _CityManagerService;

        public AddCityCommandHandler(CityManagerService cityManagerService)
        {
            _CityManagerService = cityManagerService;
        }
        public async Task<Department> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
          return await  _CityManagerService.SaveCity(request.IdDepartment, request.CodeCity, request.NameCity).ConfigureAwait(false);
        }
    }
}
