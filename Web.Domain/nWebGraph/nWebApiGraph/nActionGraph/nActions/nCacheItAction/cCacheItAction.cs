using Newtonsoft.Json.Linq;
using Web.Domain.nWebGraph.nSessionManager;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActionIDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nHotSpotMessageAction;
using Bootstrapper.Core.nApplication;

namespace Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nCacheItAction
{
    public class cCacheItAction : cBaseActionWithProps<cCacheItProps>, IActionWithProps<cCacheItProps>
    {

        public cCacheItAction(cApp _App, cWebGraph _WebGraph)
           : base(_App, _WebGraph, ActionIDs.CacheIt)
        {
        }
    }
}
