using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;
using Web.Domain.Controllers;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nCheckLoginCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nLogoutCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nFirstInitCommand;
using Bootstrapper.Core.nHandlers.nLanguageHandler;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nLanguageAction;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nShowMessageAction;
using Base.Data.nDatabaseService;

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
            WebGraph.ActionGraph.CommandListAction.Action(_Controller);
            WebGraph.ActionGraph.ActionListAction.Action(_Controller);

            if (string.IsNullOrEmpty(_ReceivedData.LanguageCode))
            {
                if (_Controller.ClientSession.IsLogined)
                {
                    _ReceivedData.LanguageCode = _Controller.ClientSession.Language;
                }
                else
                {
                    _ReceivedData.LanguageCode = App.Handlers.LanguageHandler.LanguageNameList[0].Code;
                }
            }
            cLanguageItem __LanguageItem = App.Handlers.LanguageHandler.GetLanguageByCode(_ReceivedData.LanguageCode);
            List<string> __DefinedLanguages = new List<string>();
            foreach (KeyValuePair<string, cLanguageItem> __LanguageItemDictionary in App.Handlers.LanguageHandler.LanguageList)
            {
                __DefinedLanguages.Add(__LanguageItemDictionary.Key);
            }

            if (_Controller.ClientSession.IsLogined)
            {
                cDatabaseContext __DatabaseContext = DataService.GetDatabaseContext();
                __DatabaseContext.Perform(() =>
                {
                    _Controller.ClientSession.User.Language = _ReceivedData.LanguageCode;
                    __DatabaseContext.SaveChanges();
                });
            }

            WebGraph.ActionGraph.LanguageAction.Action(_Controller, new cLanguageProps() { Language = __LanguageItem.LanguageObject, LanguageCode = _ReceivedData.LanguageCode, DefinedLanguages = __DefinedLanguages });

        }
    }
}
