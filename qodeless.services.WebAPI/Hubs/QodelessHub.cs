using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace qodeless.services.WebApi.Hubs
{
    //SignarlR SERVER
    public class QodelessHub : Hub
    {
        public async Task SendMessage(string user,bool status, string message)
        {
            //Clients.Others.SendAsync
            await Clients.All.SendAsync("ReceiveMessage", user, status, message);
        }
    }
}
