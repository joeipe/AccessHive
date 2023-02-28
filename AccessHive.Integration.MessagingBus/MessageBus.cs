using AccessHive.Integration.MessagingBus.Interfaces;
using SharedKernel.Extensions;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHive.Integration.MessagingBus
{
    public class MessageBus
    {
        private readonly IBus _bus;

        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public void SendMessage(IDomainEvent ev, string queueName)
        {
            _bus.Send(ev.OutputJson(), queueName);
        }
    }
}
