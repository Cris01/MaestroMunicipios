using MaestroMunicipios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroMunicipios.Application.Command
{
    public class UpdateCityCommand : IRequest<Department>
    {
        [Required]
        public int IdDepartment { get; set; }
        [Required]
        public string NameCity { get; set; }
        [Required]
        public int CodeCity { get; set; }

        [Required]
        public int IdCity { get; set; }
    }
}
