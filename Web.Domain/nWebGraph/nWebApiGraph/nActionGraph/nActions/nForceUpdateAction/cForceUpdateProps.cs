﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.nUtils.nValueTypes;

using Newtonsoft.Json.Linq;

namespace Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nForceUpdateAction
{
    public class cForceUpdateProps : cBaseProps
    {
        public virtual string ObjectTypeName { get; set; }
    }
}
