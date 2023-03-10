using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.nUtils.nValueTypes;

using Newtonsoft.Json.Linq;

namespace Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nLanguageAction
{
    public class cLanguageProps : cBaseProps
    {
        public virtual string LanguageCode { get; set; }
        public virtual JObject Language { get; set; }
        public virtual List<string> DefinedLanguages { get; set; }
    }
}
