using System;
using System.Collections.Generic;

namespace People.Infrastructure.Entities
{
    public partial class Director
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
    }
}
