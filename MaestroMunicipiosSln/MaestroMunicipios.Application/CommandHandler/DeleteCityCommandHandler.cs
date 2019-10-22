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
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Department>
    {
        private readonly CityManagerService _CityManagerService;

        public DeleteCityCommandHandler(CityManagerService cityManagerService)
        {
            _CityManagerService = cityManagerService;
        }
        public async Task<Department> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            return await _CityManagerService.DeleteCity(request.IdDepartment, request.IdCity).ConfigureAwait(false);
        }
    }
}
