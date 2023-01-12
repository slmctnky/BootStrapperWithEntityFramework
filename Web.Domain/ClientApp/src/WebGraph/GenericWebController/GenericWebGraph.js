import React from "react";
import {
  JSTypeOperator,
  DebugAlert,
  Class,
  Interface,
  Abstract,
  ObjectTypes,
  cListForBase,
} from "../GenericCoreGraph/ClassFramework/Class";
import { cCommandInterpreter } from "./CommandInterpreter/cCommandInterpreter";
import cActionGraph from "./ActionGraph/cActionGraph";
import Actions from "./ActionGraph/Actions";
//import cSignalListerner from "./SignalListerner/cSignalListerner";
import cCommandListenerGraph from "../../WebGraph/GenericWebController/CommandListenerGraph/cCommandListenerGraph"
import cManagersWithListener from "../../WebGraph/GenericWebController/ManagersWithListener/cManagersWithListener"



import cManagers from "./Managers/cManagers";
//import Pages from "../TagComponents/Pages";
import { CommandIDs } from "../GenericWebController/CommandInterpreter/CommandIDs/CommandIDs";
import { WebGraph } from "../../WebGraph/GenericCoreGraph/WebGraph/WebGraph";
import moment from "moment";

function GenericWebGraph() {}

GenericWebGraph.Init = function () {
  GenericWebGraph.Managers = new cManagers();
  GenericWebGraph.CommandInterpreter = new cCommandInterpreter();
  GenericWebGraph.ActionGraph = new cActionGraph();
  GenericWebGraph.CommandListenerGraph = new cCommandListenerGraph();
  GenericWebGraph.ManagersWithListener = new cManagersWithListener();
};

GenericWebGraph.ObjectList = function () {
  var __Temp = WebGraph.GetInstancesByBaseClass(ObjectTypes.TBaseDialogModal);

  for (var i = 0; i < __Temp.length; i++) {
    var __Item = __Temp[i];
    console.log(__Item.GetObjectType());
  }

  /*for (var i = 0; i < WebGraph.ObjectList.Count(); i++)
    {
      var __Item = WebGraph.ObjectList.GetItem(i);
      console.log(__Item.GetObjectType())
    }*/
};

GenericWebGraph.CloseAllModals = function () {
  var __Temp = WebGraph.GetInstancesByBaseClass(ObjectTypes.TBaseDialogModal);

  for (var i = 0; i < __Temp.length; i++) {
    var __Item = __Temp[i];
    try {
      __Item.HandleClose();
    } catch (_Ex) {
      console.log(_Ex);
      alert("Hata");
    }
  }

  /*for (var i = 0; i < WebGraph.ObjectList.Count(); i++)
  {
    var __Item = WebGraph.ObjectList.GetItem(i);
    console.log(__Item.GetObjectType())
  }*/
};
GenericWebGraph.CloseAllHotSpotMessage = function () {
  var __Temp = WebGraph.GetInstancesByBaseClass(ObjectTypes.THotSpotMessage);

  for (var i = 0; i < __Temp.length; i++) {
    var __Item = __Temp[i];
    try {
      __Item.HandleClose();
    } catch (_Ex) {
      console.log(_Ex);
      alert("Hata");
    }
  }

  /*for (var i = 0; i < WebGraph.ObjectList.Count(); i++)
    {
      var __Item = WebGraph.ObjectList.GetItem(i);
      console.log(__Item.GetObjectType())
    }*/
};

GenericWebGraph.ShowRenderCount = function () {
  var __Temp = WebGraph.GetInstancesByBaseClass(ObjectTypes.TObject);

  for (var i = 0; i < __Temp.length; i++) {
    var __Item = __Temp[i];
    console.log(
      __Item.GetObjectType().ObjectName +
        " -> Render Count : " +
        __Item.RenderCount
    );
  }
};

window.GenericWebGraph = GenericWebGraph;

GenericWebGraph.ResizeEvent = [];

GenericWebGraph.MainContainerSize = {
  Height: document.documentElement.clientHeight,
  Width: document.documentElement.clientWidth,
};

GenericWebGraph.AddResizeEvent = function (_Function) {
  GenericWebGraph.ResizeEvent.push(_Function);
};

GenericWebGraph.RemoveResizeEvent = function (_Function) {
  for (var i = GenericWebGraph.ResizeEvent.length - 1; i > -1; i--) {
    if (GenericWebGraph.ResizeEvent[i] == _Function) {
      GenericWebGraph.ResizeEvent.splice(i, 1);
    }
  }
};

GenericWebGraph.TriggerResizeEvent = function () {
  for (var i = 0; i < GenericWebGraph.ResizeEvent.length; i++) {
    GenericWebGraph.ResizeEvent[i](GenericWebGraph.MainContainerSize);
  }
};

GenericWebGraph.ResizedTimer = null;

function WindowSizeChanged() {
  GenericWebGraph.MainContainerSize = {
    Height: document.documentElement.clientHeight,
    Width: document.documentElement.clientWidth,
  };

  GenericWebGraph.IsMobile = GenericWebGraph.MainContainerSize.Width <= 768;

  if (GenericWebGraph.ResizedTimer != null) {
    clearTimeout(GenericWebGraph.ResizedTimer);
  }
  GenericWebGraph.ResizedTimer = setTimeout(function () {
    GenericWebGraph.ResizedTimer = null;
    GenericWebGraph.TriggerResizeEvent();
  }, 50);
}
GenericWebGraph.IsPageExists = function (_PageName, _ControlOnlyRootPage) {
  /*if (_PageName == "/" || _PageName == "") {
    return true;
  }

  if (!_PageName.startsWith("/")) {
    _PageName = "/" + _PageName;
  }

  if (_ControlOnlyRootPage) {
    var __PageNameList = _PageName.split("/");
    _PageName = "/" + __PageNameList[1];
  }
  var __Found = Pages.Routes.find((__Item) => __Item.purepath == _PageName);
  if (__Found == undefined) {
    if (__PageNameList.length > 2 && __PageNameList[1].length == 2) {
      _PageName = "/" + __PageNameList[2];
    }
    __Found = Pages.Routes.find((__Item) => __Item.purepath == _PageName);
  }
  return JSTypeOperator.IsDefined(__Found) && __Found;*/
};
GenericWebGraph.SetCookie = function (params) {
  var name = params.name,
    value = params.value,
    expireDays = params.days,
    expireHours = params.hours,
    expireMinutes = params.minutes,
    expireSeconds = params.seconds;

  var expireDate = new Date();
  if (expireDays) {
    expireDate.setDate(expireDate.getDate() + expireDays);
  }
  if (expireHours) {
    expireDate.setHours(expireDate.getHours() + expireHours);
  }
  if (expireMinutes) {
    expireDate.setMinutes(expireDate.getMinutes() + expireMinutes);
  }
  if (expireSeconds) {
    expireDate.setSeconds(expireDate.getSeconds() + expireSeconds);
  }

  document.cookie =
    name +
    "=" +
    escape(value) +
    ";domain=" +
    window.location.hostname +
    ";path=/" +
    ";expires=" +
    expireDate.toUTCString();
};
// Attaching the event listener function to window's resize event
window.addEventListener("resize", WindowSizeChanged);

GenericWebGraph.GoPage = function (_Page, _First = false) 
{
  /*if (GenericWebGraph.MainPage && GenericWebGraph.MainPage != null) {
    if (_Page == null) {
      window.SetUrl("", _First);
    } else {
      window.SetUrl(_Page, _First);
    }
  } else {
    Pages.LoadPages(function () 
    {
      window.App.App.forceUpdate();
      //WebGraph.ForceUpdateAllWithAsyncLoad(true);
     //console.log("Pages Loaded...");
    });
  }*/
};

GenericWebGraph.GoMainPage = function (_First = false) {
  GenericWebGraph.GoPage("", _First);
};

GenericWebGraph.GetDayIDByDate = function (_Date) {
  var __DayNumber = _Date.getDay();
  return __DayNumber == 0 ? 6 : __DayNumber - 1;
};

GenericWebGraph.GetDayNameByID = function (_ID, _Format = "ddd") {
  var __Date = new Date(2020, 0, 6 + _ID, 1, 0, 0, 0); ////new Date(moment("01 06 2020"));
  return GenericWebGraph.GetDateDayNameByDate(__Date, _Format);
};

GenericWebGraph.GetDateDayNameByDate = function (_Date, _Format = "ddd") {
  var __DayName = moment(_Date)
    .locale(
      GenericWebGraph.Managers.LanguageManager.ActiveLanguage.LanguageCode
    )
    .format(_Format);
  return __DayName;
};

export default GenericWebGraph;
