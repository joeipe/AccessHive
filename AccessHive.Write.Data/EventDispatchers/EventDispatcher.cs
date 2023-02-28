using AccessHive.Integration.MessagingBus;
using AccessHive.Write.Data.Events;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHive.Write.Data.EventDispatchers
{
    public class EventDispatcher
    {
        private readonly MessageBus _messageBus;

        public EventDispatcher(MessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Dispatch(IEnumerable<IDomainEvent> events)
        {
            foreach (IDomainEvent ev in events)
            {
                Dispatch(ev);
            }
        }

        public void Dispatch(IDomainEvent ev)
        {
            switch (ev)
            {
                case RoleAddedEvent roleAddedEvent:
                    _messageBus.SendMessage(roleAddedEvent, "RoleAddedMessageQueue");
                    break;

                default:
                    throw new Exception($"Unknown event type: '{ev.GetType()}'");
            }
        }
    }
}
