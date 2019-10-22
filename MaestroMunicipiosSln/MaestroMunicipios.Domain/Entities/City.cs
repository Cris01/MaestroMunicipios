using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroMunicipios.Domain.Entities
{
    public class City : DomainEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
