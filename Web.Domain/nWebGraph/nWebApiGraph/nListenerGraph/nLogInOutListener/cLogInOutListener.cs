using Web.Domain.Controllers;
using Web.Domain.nUtils.nValueTypes;
using Web.Domain.nWebGraph.nSessionManager;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nDoCheckLoginRequestAction;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nHotSpotMessageAction;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nShowMessageAction;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nCheckLoginCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nLogoutCommand;
using Data.GenericWebScaffold.nDefaultValueTypes;
using System;
using System.Collections.Generic;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;

namespace Web.Domain.nWebGraph.nWebApiGraph.nListenerGraph.nLogInOutListener
{
    public class cLogInOutListener : cBaseListener
		, ILoginReceiver
		, ILogoutReceiver
		, ICheckLoginReceiver
	{
		public cLogInOutListener(cApp _App, cWebGraph _WebGraph, cDataService _DataService)
		   : base(_App, _WebGraph, _DataService)
		{
		}

		public void ReceiveLogoutData(cListenerEvent _ListenerEvent, IController _Controller, cLogoutCommandData _ReceivedData)
		{
			
		}

		public void ReceiveLoginData(cListenerEvent _ListenerEvent, IController _Controller, cLoginCommandData _ReceivedData)
		{
			
		}

		public void ReceiveCheckLoginData(cListenerEvent _ListenerEvent, IController _Controller, cCheckLoginCommandData _ReceivedData)
		{
			
		}

		

	}
}