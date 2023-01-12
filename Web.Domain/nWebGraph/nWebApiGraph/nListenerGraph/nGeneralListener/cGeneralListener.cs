using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;
using Web.Domain.Controllers;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nCheckLoginCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nLogoutCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nFirstInitCommand;

namespace Web.Domain.nWebGraph.nWebApiGraph.nListenerGraph.nGeneralListener
{
     public class cGeneralListener : cBaseListener
        , IFirstInitReceiver
    {
        public cGeneralListener(cApp _App, cWebGraph _WebGraph, cDataService _DataService)
               : base(_App, _WebGraph, _DataService)
        {
        }

        public void ReceiveFirstInitData(cListenerEvent _ListenerEvent, IController _Controller, cFirstInitCommandData _ReceivedData)
        {
            
        }
    }
}
