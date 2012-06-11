using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMind.Game;
using SignalR.Hubs;

namespace MasterMind.Web.Hubs
{

    [HubName("masterMind")]
    public class MasterMindHub : Hub
    {
        private static GameHandler _gameHandler = new GameHandler();
        
        public MasterMindHub()
        {
            _gameHandler.GetInitialColors();
        }

        public bool ClientGuess(List<GameColors> guess)
        {
            if (Clients != null)
            {
                Clients.showGuess(guess, Context.ConnectionId);
            }
            return _gameHandler.Guess(guess);
        }
    }
}
