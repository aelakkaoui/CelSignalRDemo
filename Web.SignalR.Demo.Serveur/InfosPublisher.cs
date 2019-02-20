using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Web.SignalR.Demo.Serveur
{
    public class InfosPublisher : Hub
    {
        public Task PublishInfo(MessageInfo message)
        {
            return Clients.All.SendAsync("OnInfoPublished", message);
        }
    }

    public class MessageInfo
    {
        public string UserName { get; set; }
        public string UserMessage { get; set; }
    }
}
