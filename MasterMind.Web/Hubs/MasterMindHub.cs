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
        public bool ClientGuess(int[] guess)
        {
            var correct = new int[] { 0, 1, 2, 3 };

            for (int i = 0; i < correct.Length; i++)
            {
                if (correct[i] != guess[i])
                {
                    Clients.showGuess(guess, Context.ConnectionId);
                    return false;
                }
            }

            Clients.showGuess(guess, Context.ConnectionId);
            return true;
        }
    }
}
