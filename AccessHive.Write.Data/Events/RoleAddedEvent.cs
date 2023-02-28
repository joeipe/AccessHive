using AccessHive.Write.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHive.Write.Data.Events
{
    public class RoleAddedEvent : IDomainEvent
    {
        public string Name { get; set; } = null!;

        public RoleAddedEvent(string name)
        {
            Name = name;
        }
    }
}
