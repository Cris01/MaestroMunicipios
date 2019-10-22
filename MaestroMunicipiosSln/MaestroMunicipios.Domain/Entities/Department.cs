using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroMunicipios.Domain.Entities
{
    public class Department : DomainEntity
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
