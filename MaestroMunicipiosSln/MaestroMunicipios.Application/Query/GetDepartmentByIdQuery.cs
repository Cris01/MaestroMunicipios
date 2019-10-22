using MaestroMunicipios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroMunicipios.Application.Query
{
    public class GetDepartmentByIdQuery : IRequest<Department>
    {
        [Required]
        public int IdDepartment { get; set; }
    }
}
