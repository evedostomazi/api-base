using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _message;

        public ServiceMessage(IMessage message)
        {
            _message = message;
        }
    }
}
