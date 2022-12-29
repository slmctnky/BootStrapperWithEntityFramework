﻿using Web.Domain.Controllers;
using Web.Domain.nWebGraph.nSessionManager;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;
using Bootstrapper.Core.nCore;

namespace Web.Domain.nWebGraph.nWebApiGraph.nListenerGraph
{
    public class cBaseListener : cCoreObject
    {
        public cWebGraph WebGraph { get; set; }

        public cDataService DataService { get; set; }

        public Dictionary<Type, int> ListenerOrders { get; set; }

		protected IHubContext<SignalRHub> SignalHub { get; set; }


		public cBaseListener(cApp _App,  cWebGraph _WebGraph, cDataService _DataService, Dictionary<Type, int> _ListenerOrders = null)
			: base(_App)
        {
            if (_ListenerOrders != null)
            {
                ListenerOrders = _ListenerOrders;
            }
            else
            {
                ListenerOrders = new Dictionary<Type, int>();
            }
            
            WebGraph = _WebGraph;
            DataService = _DataService;
        }

        public override void Init()
        {
			WebGraph.CommandGraph.ConnectToCommands(this); 
        }


		private void SendMessageToSessions(List<cSignalSessionMatcher> _SignalSessions)
		{
			_SignalSessions.ForEach(__Item =>
			{
				if (__Item.Session == null)
				{
					WebGraph.SessionManager.GetSessionList().ForEach(__SessionItems =>
					{
						//SignalHub.Clients.All.SendAsync("CommandChannel", __Item.ActionJson.ToString());
						if (__SessionItems.IsLogined)
						{
							foreach (string __SignalRID in __SessionItems.SignalRIDList)
							{
								SignalHub.Clients.Client(__SignalRID).SendAsync("CommandChannel", __Item.ActionJson.ToString());
							}
						}
					});
				}
				else
				{
					if (__Item.Session.IsLogined)
					{
						foreach (string __SignalRID in __Item.Session.SignalRIDList)
						{
							SignalHub.Clients.Client(__SignalRID).SendAsync("CommandChannel", __Item.ActionJson.ToString());
						}
					}
				}
			});
		}

	
		public void InstantSendSignal(List<cSession> _Sessionlist, JObject _Object)
		{
			if (SignalHub == null)
			{
				SignalHub = App.Factories.ObjectFactory.ResolveInstance<IHubContext<SignalRHub>>();
			}			
			if (_Sessionlist != null)
			{
				List<cSignalSessionMatcher> __SignalSessions = new List<cSignalSessionMatcher>();
				if (_Sessionlist.Count > 0)
				{
					_Sessionlist.ForEach(__Item =>
					{
						cSignalSessionMatcher __FindItem = __SignalSessions.Find(__Main => __Main.Session.SessionID == __Item.SessionID);
						if (__FindItem == null)
						{
							__FindItem = new cSignalSessionMatcher(__Item);
							__SignalSessions.Add(__FindItem);
						}
						__FindItem.ActionJson.Add(_Object);
					});
				}

				SendMessageToSessions(__SignalSessions);
			}
		}


	}
}
