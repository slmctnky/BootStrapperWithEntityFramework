import React, { Component } from 'react';


import GenericWebGraph from "../../WebGraph/GenericWebController/GenericWebGraph"
//import { CommandInterfaces } from "../GenericWebController/CommandInterpreter/cCommandInterpreter"
import { DebugAlert, Class, Interface, Abstract, ObjectTypes, JSTypeOperator } from "../../WebGraph/GenericCoreGraph/ClassFramework/Class"
import cBaseObject from "../GenericCoreGraph/BaseObject/cBaseObject";

//import TObject from "../../WebGraph/TagComponents/TObject"
//import Actions from "../../WebGraph/GenericWebController/ActionGraph/Actions"
import { CommandIDs } from "../../WebGraph/GenericWebController/CommandInterpreter/CommandIDs/CommandIDs"
import { ActionIDs } from "../../WebGraph/GenericWebController/ActionGraph/ActionIDs/ActionIDs";
//import { WebGraph } from "../../WebGraph/GenericCoreGraph/WebGraph/WebGraph"
//import cCommandListenerGraph from "../../WebGraph/GenericWebController/CommandListenerGraph/cCommandListenerGraph"
//import cManagersWithListener from "../../WebGraph/GenericWebController/ManagersWithListener/cManagersWithListener"

import cManagers from "../../WebGraph/GenericWebController/Managers/cManagers";
import { cCommandInterpreter } from "../../WebGraph/GenericWebController/CommandInterpreter/cCommandInterpreter";
import cActionGraph from "../../WebGraph/GenericWebController/ActionGraph/cActionGraph";

import TLoading from "./Utilities/TLoading";

var TDynamicLoader = Class(cBaseObject, //TObject,
  {
    ObjectType: ObjectTypes.Get("TDynamicLoader")
    ,
    constructor: function (_Props)
    {
        TDynamicLoader.BaseObject.constructor.call(this, _Props);
        this.state = {
            innerChilds: <div className="container">
                <div className="center">
                    <div className="lds-ripple"><div></div><div></div></div>
                </div>
            </div>
        }
        this.InitFirstLoad();
    }
    ,
    InitFirstLoad: function()
    {
        var __LanguageCode = window.GetLanguageCodeFromUrl();
        if (__LanguageCode.length != 2)
        {
            __LanguageCode = "";
        }

        var __This = this;
        fetch('/webgraph/webapi', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                CID: 1,
                Data: {
                    LanguageCode: __LanguageCode
                }
            })
        })
            .then(response => response.json())
            .then(response => {
                var __CommandList = __This.GetCommandByNameInCommandArray(response, "CommandList");
                CommandIDs.LoadCommands(__CommandList.Data.CommandList);

                var __ActionList = __This.GetCommandByNameInCommandArray(response, "ActionList");
                ActionIDs.LoadActions(__ActionList.Data.ActionList);

                GenericWebGraph.Managers = new cManagers();

                var __Language = __This.GetCommandByNameInCommandArray(response, "Language");
                GenericWebGraph.Managers.LanguageManager.HandleSetActiveLanguage(__Language.Data);

                GenericWebGraph.CommandInterpreter = new cCommandInterpreter();
                GenericWebGraph.ActionGraph = new cActionGraph();

                window.GenericWebGraph = GenericWebGraph;

                

                __This.setState({
                    innerChilds: __This.props.getInnerChilds()
                });


            }).catch(err =>
            {
                DebugAlert.Show("hata", err);
            });

      }
        ,
      GetCommandByNameInCommandArray: function (_CommandArray, _CommandName)
      {
          for (var i = 0; i < _CommandArray.length; i++)
          {
              if (_CommandArray[i].ActionID.Code === _CommandName)
              {
                  return _CommandArray[i];
              }
          }
      }
    ,
    Destroy: function ()
    {
      TDynamicLoader.BaseObject.Destroy.call(this);
    }
    ,
    render()
    {
        return (
            this.state.innerChilds
      );
    }
  }, {});

export default TDynamicLoader;
