using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHive.Integration.MessagingBus.Interfaces
{
    public interface IBus
    {
        void Send(string message, string queueName);
    }
}
