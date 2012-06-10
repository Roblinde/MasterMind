using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Hubs;

namespace MasterMind.Web.Hubs
{
    [HubName("masterMind")]
    public class MasterMindHub : Hub
    {
        public void BroadcastMessage(string message)
        {
            Clients.showMessage(Context.ConnectionId + " says: " + message, Context.ConnectionId);
        }
    }
}
