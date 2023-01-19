using Base.Data.nDatabaseService;
using Bootstrapper.Core.nApplication;
using Data.Domain.nDatabaseService;
using Data.Domain.nDatabaseService.nSystemEntities;
using Data.Domain.nDataService.nDataManagers;
using Data.Domain.nDefaultValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Controllers;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nMenuResultAction;
using Web.Domain.nWebGraph.nWebApiGraph.nActionGraph.nActions.nPageResultAction;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nGetMenuListCommand;
using Web.Domain.nWebGraph.nWebApiGraph.nCommandGraph.nCommands.nGetPageListCommand;

namespace Web.Domain.nWebGraph.nWebApiGraph.nListenerGraph.nPermissionListener
{
    public class cPermissionListener : cBaseListener, IGetMenuListReceiver, IGetPageListReceiver
    {
        public cMenuDataManager MenuDataManager { get; set; }

        public cPermissionListener(cApp _App, cWebGraph _WebGraph, cDataService _DataService, cMenuDataManager _MenuDataManager)
          : base(_App, _WebGraph, _DataService)
        {
            WebGraph = _WebGraph;
            MenuDataManager = _MenuDataManager;
        }

		public cMenuResultProps PreparePageResultProps(IController _Controller, cGetMenuListCommandData _ReceivedData)
		{
            cMenuResultProps __PageResultProps = new cMenuResultProps();

            List<cMenuEntity> __Menus2 = MenuDataManager.GetMenuByUser(null, _ReceivedData.MenuTypeCode, _ReceivedData.RootMenuCode);


            if (_Controller.ClientSession.IsLogined)
            {

                List<cMenuEntity> __Menus = MenuDataManager.GetMenuByUser(_Controller.ClientSession.User, _ReceivedData.MenuTypeCode, _ReceivedData.RootMenuCode);

                /*foreach (cMenuEntity __MenuEntity in __Menus)
                {
                    MenuIDs __MenuID = MenuIDs.GetByCode(__MenuEntity.Code, null);
                    if (__MenuID != null)
                    {
                        if (__MenuID.IsMainMenu)
                        {
                            List<dynamic> __SubMenus = ActorDataManager.GetMenuByActorToDynamicList(
                                _Controller.ClientSession.User.Actor.GetValue(), MenuTypes.CenterMenu.Code, __MenuID.Code,
                                (_Item) =>
                                {
                                    cPageEntity __Page = __MenuEntity.Page.GetValue();

                                    _Item.icon = _Item.Icon;
                                    _Item.name = _Item.Name;
                                    _Item.mainMenu = false;
                                    _Item.subMenu = new object[] { };
                                    _Item.Active = false;
                                    _Item.url = _Item.Url;
                                });

                            __ResultList.Add(new
                            {
                                icon = __MenuID.Icon,
                                name = __MenuID.Name,
                                mainMenu = true,
                                subMenu = __SubMenus
                            });
                        }
                        else
                        {
                            cPageEntity __Page = __MenuEntity.Page;
                            __ResultList.Add(new
                            {
                                url = __Page.Url,
                                icon = __MenuEntity.Icon,
                                name = __MenuEntity.Name,
                                mainMenu = false,
                                subMenu = new object[] { }
                            });
                        }
                    }
                }*/
            }
            else
            {

                foreach (MenuIDs __MenuEntity in MenuIDs.TypeList)
                {
                    if (__MenuEntity.UnloginedPage)
                    {
                        if (__MenuEntity.IsMainMenu)
                        {
                            __PageResultProps.PagesItems.Add(new cMenuItem()
                            {
                                Url = "menupage/" + __MenuEntity.Code,
                                Icon = __MenuEntity.Icon,
                                Name = __MenuEntity.Name
                            });
                        }
                        else
                        {
                            PageIDs __PageID = PageIDs.GetByCode(__MenuEntity.Code, PageIDs.MainPage);
                            __PageResultProps.PagesItems.Add(new cMenuItem()
                            {
                                //url = __PageID.Code == PageIDs.MainPage.Code ? "global" : __PageID.Url,
                                Url = __PageID.Url,
                                Icon = __MenuEntity.Icon,
                                Name = __MenuEntity.Name
                            });
                        }





                    }
                }
            }


            return __PageResultProps;
        }

        public void ReceiveGetMenuListData(cListenerEvent _ListenerEvent, IController _Controller, cGetMenuListCommandData _ReceivedData)
        {
            WebGraph.ActionGraph.MenuResultAction.Action(_Controller, PreparePageResultProps(_Controller, _ReceivedData));

        }

        public void ReceiveGetPageListData(cListenerEvent _ListenerEvent, IController _Controller, cGetPageListCommandData _ReceivedData)
        {
            /*if (_Controller.ClientSession.IsLogined)
            {
                List<cPageEntity> __Pages = ActorDataManager.GetPageByActor(_Controller.ClientSession.User.Actor.GetValue());

                List<object> __ResultList = new List<object>();
                foreach (cPageEntity __Page in __Pages)
                {
                    __ResultList.Add(new
                    {
                        path = __Page.Url,
                        name = __Page.Name,
                        originalCode = PageIDs.GetByCode(__Page.Code, PageIDs.MainPage).OriginalCode,
                        subParamName = PageIDs.GetByCode(__Page.Code, PageIDs.MainPage).SubParamName,
                        component = __Page.ComponentName
                    });
                }

                WebGraph.ActionGraph.ResultListAction.Action(_Controller, new nActionGraph.nActions.nResultListAction.cResultListProps() { ResultList = __ResultList, Page = 1, Total = __ResultList.Count });
            }
            else
            {

                List<object> __ResultList = new List<object>();
                foreach (PageIDs __Page in PageIDs.TypeList)
                {
                    if (__Page.UnloginedPage)
                    {
                        __ResultList.Add(new
                        {
                            path = __Page.Url,
                            name = __Page.Name,
                            originalCode = __Page.OriginalCode,
                            subParamName = PageIDs.GetByCode(__Page.Code, PageIDs.MainPage).SubParamName,
                            component = __Page.Component
                        });
                    }
                }

                WebGraph.ActionGraph.ResultListAction.Action(_Controller, new nActionGraph.nActions.nResultListAction.cResultListProps() { ResultList = __ResultList, Page = 1, Total = __ResultList.Count });
            }*/
        }
    }
}
