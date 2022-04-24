using System;
using System.Collections.Generic;

namespace People.Infrastructure.Entities
{
    public partial class Owner
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
    }
}
